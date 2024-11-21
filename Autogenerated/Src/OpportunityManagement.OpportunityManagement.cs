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

	#region Class: OpportunityManagementSchema

	/// <exclude/>
	public class OpportunityManagementSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public OpportunityManagementSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public OpportunityManagementSchema(OpportunityManagementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "OpportunityManagement";
			UId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704");
			CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2936";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
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
			RealUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704");
			Version = 0;
			PackageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCurrentOpportunityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("af8eea9e-0e11-426e-a870-2cff33d00f84"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePresentationParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0eae6fcc-65b6-433e-b4dc-e42323c488c1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Presentation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMainContactParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b8d6c762-b63e-49b7-b651-c8d29f9c8d74"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccountParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("342aec56-8359-4c5b-826b-9e8489fd6a4b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsStageChangedByUserParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9786c0e4-cc5f-4c9f-b46d-090a297e2b74"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"IsStageChangedByUser",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateClientOpportunityCountParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("02b1469d-72ad-4909-a7cf-6b41b79d41a7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ClientOpportunityCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateOpportunityTitleParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("738ceb61-832b-4b27-a973-9347e26e827e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OpportunityTitle",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateContactParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b6534525-3848-4420-8930-e7bcc98a1756"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateClientNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b2b54e53-5309-4650-ac67-b8a4705d22b4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ClientName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCurrentOpportunityParameter());
			Parameters.Add(CreatePresentationParameter());
			Parameters.Add(CreateMainContactParameter());
			Parameters.Add(CreateAccountParameter());
			Parameters.Add(CreateIsStageChangedByUserParameter());
			Parameters.Add(CreateClientOpportunityCountParameter());
			Parameters.Add(CreateOpportunityTitleParameter());
			Parameters.Add(CreateContactParameter());
			Parameters.Add(CreateClientNameParameter());
		}

		protected virtual void InitializeProspectingParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("81432db0-f5f5-40d1-8f22-4d8c3bb4cf48"),
				ContainerUId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb29a402-5da5-4f9b-844c-e79f4e1f115a"),
				ContainerUId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("fdc628cc-1da4-4b5d-b397-d6c93e1e9517"),
				ContainerUId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeNeedsAnalysisParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("5b443132-caa7-4f82-80dd-cc84a5380caa"),
				ContainerUId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6a80392b-c787-4788-a532-fca2370b3840"),
				ContainerUId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("5e47a6d3-f9bb-404f-87e2-aed31c62acc3"),
				ContainerUId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b8d6c762-b63e-49b7-b651-c8d29f9c8d74}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeOppManagementValuePpropositionParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("4274528b-203f-43bc-87d3-abf86b9a792e"),
				ContainerUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b20705a6-a8bc-460d-8389-aaaa9b58be16"),
				ContainerUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var presentationParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("f7d5c580-2ff1-4209-a013-2bef80d7f3a9"),
				ContainerUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Name = @"Presentation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			presentationParameter.SourceValue = new ProcessSchemaParameterValue(presentationParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{0eae6fcc-65b6-433e-b4dc-e42323c488c1}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(presentationParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("2a0e89a7-92f6-4cf6-a9f2-a0140105ba95"),
				ContainerUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b8d6c762-b63e-49b7-b651-c8d29f9c8d74}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeIdDecisionMakersParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("76602486-f8b8-47cb-8b9f-d00841250f90"),
				ContainerUId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e6028b5e-002d-4bc7-bc34-8affd537f00c"),
				ContainerUId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("5dc6ce94-0fc5-4ffa-8e00-83c67ce5da35"),
				ContainerUId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b8d6c762-b63e-49b7-b651-c8d29f9c8d74}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeOppManagementPerceptionAnalysisParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("c647b290-fae9-4f2f-b291-b94262f923dc"),
				ContainerUId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2d34fbe8-274b-4c6e-88d8-7307f538cfee"),
				ContainerUId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("36230419-640f-4176-ad85-8beca7d791ca"),
				ContainerUId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b8d6c762-b63e-49b7-b651-c8d29f9c8d74}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeOppManagementProposalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("0a768934-39e6-4d8e-9fd4-4859b59f0779"),
				ContainerUId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2902276d-abfd-4fd2-b6f9-b5bda02f0222"),
				ContainerUId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("dc02a11c-a24c-4451-897b-9dce3a6a7178"),
				ContainerUId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{b8d6c762-b63e-49b7-b651-c8d29f9c8d74}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeOppManagementNegotiationsParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("f58812eb-a5a3-43ef-84a7-454b69c3aaed"),
				ContainerUId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("33eb9e90-615e-412b-86bf-8d9f6c8831a8"),
				ContainerUId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("47d1669f-a6cc-48ac-85b8-94795d69938e"),
				ContainerUId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeOppManagementContractationParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("a2600d6c-144b-4c75-acb3-f04cb1577884"),
				ContainerUId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var opportunityStageChangedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("16815d2d-6357-4be4-9265-46e9a99e093b"),
				ContainerUId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"OpportunityStageChanged",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			opportunityStageChangedParameter.SourceValue = new ProcessSchemaParameterValue(opportunityStageChangedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(opportunityStageChangedParameter);
			var mainContactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("b812d4a7-16f1-4a13-b2e9-f0b2c48a8532"),
				ContainerUId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				Name = @"MainContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			mainContactParameter.SourceValue = new ProcessSchemaParameterValue(mainContactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368")
			};
			parametrizedElement.Parameters.Add(mainContactParameter);
		}

		protected virtual void InitializeOppManagementEndStageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var currentOpportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("1494d351-8b28-4d15-a088-912b8872f732"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"CurrentOpportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			currentOpportunityParameter.SourceValue = new ProcessSchemaParameterValue(currentOpportunityParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(currentOpportunityParameter);
			var nextOpportunityStageNumberParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0fa7431c-1004-411e-ae2e-b485fc040737"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"NextOpportunityStageNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			nextOpportunityStageNumberParameter.SourceValue = new ProcessSchemaParameterValue(nextOpportunityStageNumberParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(nextOpportunityStageNumberParameter);
			var currentStageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dcb46392-5cd0-43ba-9004-211ef9690ca5"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"CurrentStage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentStageParameter.SourceValue = new ProcessSchemaParameterValue(currentStageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(currentStageParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9c2d0712-831e-499c-a94b-562db3eaed86"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var isStageChangedByUserParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2f2941be-b24c-4797-8b31-addbd6057927"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"IsStageChangedByUser",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isStageChangedByUserParameter.SourceValue = new ProcessSchemaParameterValue(isStageChangedByUserParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9786c0e4-cc5f-4c9f-b46d-090a297e2b74}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(isStageChangedByUserParameter);
			var dontShowPageEndOfStageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ef2201a2-720c-453d-8a5b-62d5077c6041"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"DontShowPageEndOfStage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			dontShowPageEndOfStageParameter.SourceValue = new ProcessSchemaParameterValue(dontShowPageEndOfStageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(dontShowPageEndOfStageParameter);
			var nextStageParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				UId = new Guid("a8f664f6-40f1-4b7e-9602-25265d8962b3"),
				ContainerUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				Name = @"NextStage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			nextStageParameter.SourceValue = new ProcessSchemaParameterValue(nextStageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8")
			};
			parametrizedElement.Parameters.Add(nextStageParameter);
		}

		protected virtual void InitializeReadOppDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("378a7c4d-c2ae-4dc0-8450-7d00de21889a"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,137,157,151,67,57,26,208,54,203,74,44,8,105,119,180,186,182,175,119,44,229,49,155,56,98,87,209,72,72,84,84,252,3,95,48,5,80,80,192,47,100,254,8,103,178,3,210,22,136,130,6,201,197,245,181,207,185,231,28,217,195,149,237,158,217,210,97,91,24,40,59,12,250,19,93,144,132,1,15,57,67,26,70,60,166,177,132,148,138,204,132,52,141,140,208,40,66,197,115,36,65,13,21,22,100,70,47,181,117,36,176,14,171,174,184,24,126,147,186,182,199,224,202,28,54,47,213,26,43,120,53,13,0,140,83,35,243,140,170,144,41,26,3,230,20,52,143,40,8,198,149,214,66,196,202,144,89,75,142,9,79,101,204,41,74,153,208,88,228,140,202,20,50,42,89,38,19,46,37,112,147,144,160,68,227,150,183,155,22,187,206,54,117,49,224,175,250,252,110,227,85,206,179,23,77,217,87,53,9,42,116,112,6,110,61,9,9,49,78,20,80,21,11,207,110,48,163,192,133,166,28,100,198,178,28,163,52,202,72,160,96,227,38,90,114,162,73,160,193,193,107,40,123,60,48,15,214,107,100,60,140,242,36,245,216,136,123,59,156,133,52,79,189,59,163,83,35,144,167,66,72,125,204,235,121,111,125,109,187,211,190,194,214,170,251,216,209,231,215,180,197,160,154,218,181,77,57,81,159,30,174,159,227,173,155,195,189,63,122,51,27,114,190,63,129,200,54,232,59,92,148,22,107,183,172,85,163,109,125,61,115,110,183,30,82,109,160,181,221,49,133,229,77,15,37,9,90,123,189,254,99,90,139,190,115,77,245,31,89,13,188,77,207,225,31,217,65,238,244,6,181,237,54,37,220,29,246,5,121,124,211,55,238,233,248,105,252,50,126,219,191,223,127,24,119,251,143,143,198,31,251,119,227,247,241,243,184,27,191,142,187,249,10,121,64,85,144,75,2,38,71,4,225,191,3,70,17,141,89,138,20,242,44,164,76,25,195,185,14,67,147,199,151,196,203,251,151,67,47,78,186,23,111,235,227,175,153,125,174,158,248,238,131,198,217,17,89,12,127,163,115,187,154,148,174,182,126,253,4,164,49,208,137,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("09ca5d94-4475-494b-bb1d-1711734825d0"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("809504a0-92ba-4c37-9223-2bd86178ceeb"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("47e4b981-ae34-43d6-80d1-541eb76f8886"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("093cfd0d-3919-4594-bdbd-243b89c2421c"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("99a55b65-320e-4a00-a443-906ccbd17195"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ea0a8aa9-15cc-4e7b-b857-0fde66046c9d"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("61d6f451-48d9-4c96-917b-f6c5ce85df83"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("10ddcd85-ccf7-42e5-8390-78074cc70ded"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c1248569-3f8c-43f3-9cb3-48975e8f84ef"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3feedf55-86a5-4ac5-bb7d-a85d1a84eb9d"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("734b2f72-a22c-41d7-900f-06d5bb7faf75"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d60364bd-0961-431f-8a33-c5f616c3de09"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5fc444a5-9b7a-422c-8693-86213fa317e7"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e4513fe5-860a-4300-889d-38b3328e8894"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("adee94c3-29c5-4b7a-960c-20c6b71d3afb"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("454dc5b0-a0d3-4a3d-b852-62380501a11c"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e7de2a0e-3600-4ca1-96eb-0f73a4d25ddb"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4dd88c3e-d496-44ef-93cf-f7f2ff5710a5"),
				ContainerUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeFindPresentationParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("590098f3-05ec-4bc7-ac56-18d861124c44"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,91,139,92,69,16,199,191,202,114,30,242,116,90,250,82,125,27,31,151,21,2,18,3,94,16,194,18,250,82,157,61,56,183,204,156,65,195,176,16,215,7,241,105,193,23,65,16,49,159,96,69,87,130,96,242,21,206,124,35,235,204,236,196,33,108,54,97,21,37,49,15,51,204,185,212,165,171,255,191,170,158,229,221,102,254,94,51,108,113,54,40,97,56,199,122,113,51,15,42,212,218,219,28,129,97,114,142,65,66,203,92,44,156,229,192,133,19,217,235,28,99,85,143,195,8,7,213,198,250,32,55,109,85,55,45,142,230,131,59,203,191,156,182,179,5,214,119,203,250,226,195,116,132,163,240,113,31,32,1,248,236,148,100,1,82,98,16,185,96,209,103,205,92,16,50,129,12,190,56,95,109,114,145,194,36,201,3,103,178,120,207,32,71,203,124,116,137,233,12,14,147,118,16,162,171,234,33,150,246,224,139,233,12,231,243,102,50,30,44,241,217,239,143,30,76,41,203,77,236,253,201,112,49,26,87,245,8,219,112,59,180,71,148,136,203,14,138,79,44,130,139,12,172,143,204,135,100,24,128,144,69,129,50,41,200,170,78,97,218,246,110,171,238,167,238,201,234,203,213,9,125,159,118,127,116,143,187,243,170,158,97,193,25,142,19,238,172,207,113,29,66,66,96,206,112,96,192,169,128,193,99,100,188,104,16,22,180,87,137,87,117,14,109,248,36,12,23,184,206,113,217,144,97,148,94,115,43,10,179,24,104,181,104,36,115,89,4,230,133,143,69,89,37,75,145,219,202,191,63,153,124,182,152,82,213,231,183,22,35,156,53,233,98,11,145,246,98,50,27,44,211,100,220,206,38,195,222,249,173,29,131,205,86,93,60,252,116,83,158,225,250,73,111,88,29,215,139,57,238,15,27,28,183,7,227,52,201,205,248,222,122,23,143,143,201,102,52,13,179,102,190,45,234,193,253,69,24,82,1,154,123,71,87,22,255,118,152,81,124,82,192,235,182,228,122,186,205,124,157,115,47,237,220,204,167,195,240,96,125,61,168,110,220,95,76,218,119,187,111,247,86,15,187,179,238,103,146,197,73,119,190,185,89,61,103,188,125,89,121,200,16,29,48,237,208,176,92,132,96,222,10,146,6,23,217,112,244,202,37,115,225,225,184,190,60,220,15,221,249,30,169,239,108,245,53,125,78,186,179,151,4,116,175,30,240,144,118,249,31,165,87,69,85,132,113,158,101,103,169,147,240,104,152,231,150,19,194,34,128,44,89,57,238,175,79,175,6,47,146,82,133,161,151,150,250,84,112,44,104,75,193,192,9,142,65,67,210,102,151,222,71,68,236,211,203,137,181,58,66,86,132,191,214,185,95,83,54,189,10,57,83,5,124,208,46,123,147,236,235,38,223,183,196,190,144,216,239,8,215,95,55,4,93,77,79,137,200,67,34,73,164,146,248,134,158,200,121,249,119,232,9,65,201,20,10,233,27,181,96,32,193,144,17,231,244,126,2,116,6,179,51,226,239,204,62,1,37,88,193,144,83,59,0,37,53,11,52,15,73,190,16,164,87,152,133,114,187,244,124,191,238,54,231,221,47,212,230,30,118,143,87,167,151,147,228,141,64,201,29,165,42,36,185,205,68,102,228,94,247,240,11,52,144,77,122,59,251,222,164,217,215,159,135,72,15,231,47,103,9,100,178,144,192,255,39,147,40,38,173,157,229,134,21,147,104,18,89,107,88,180,62,51,41,32,163,69,97,184,148,215,103,9,204,122,202,6,202,193,244,162,239,247,80,149,200,44,199,36,67,193,172,109,217,101,233,71,170,216,147,190,3,117,191,117,103,151,115,20,16,76,137,206,178,196,37,173,45,32,13,183,172,4,29,36,165,74,57,123,15,169,252,127,38,210,254,98,222,78,70,111,42,68,143,168,173,254,190,250,106,245,13,181,216,211,189,238,233,174,58,110,92,201,84,40,14,105,217,200,56,18,78,32,13,178,64,50,103,50,149,162,84,166,81,229,224,194,195,139,142,147,215,15,126,231,230,252,131,207,199,91,34,55,165,60,124,135,238,62,119,227,217,31,128,193,242,85,242,61,62,220,102,76,93,224,240,248,79,8,139,140,52,164,14,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d7349ecf-3808-499e-94e5-a6af0b6c8059"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3ddba6f3-67f9-46a5-bda4-c9be1d38263b"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7711d045-dde7-4665-b251-2b6cda4ba16c"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("14ac52bb-d8de-4e93-ba14-2092314ad9ec"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("44ef2079-3350-48f5-8417-a062c43f2a0e"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f79b49c3-44b7-458a-af53-ffc25ba8de44"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("bcd38317-a882-4317-8881-b21b8f0ca57b"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9371b699-8ba0-411a-be54-7912877edf8f"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ca81fffe-20a5-46bf-ab20-5fa6f0638a5f"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6c987b70-a95f-48b9-bcfb-8ddc2192e44a"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e64f2c49-b461-45e7-bb8f-1f660acca3cc"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b598adf2-e516-42e9-9f34-f99fb251a690"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5b343947-0aa5-4776-9b18-096d905e7603"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("6f8cde56-f764-4ad1-b528-0d9031cd1e8e"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6351aab6-3117-48e1-afe4-c9ad827a53d7"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1fbf3104-1357-48ca-926e-2f85305a4602"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6997cffd-7ec0-4409-93a0-9a20046659ca"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("3d06393e-9ac6-4e4e-966e-ddc4dff244dd"),
				ContainerUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeLinkOppToProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entityIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("41befda8-dd24-45a3-8e91-5fa9d9e03fa0"),
				ContainerUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("773490bc-4ab0-4078-9f03-a0ead61c8e69"),
				ContainerUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
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
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
		}

		protected virtual void InitializeReadOppMainContactParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ec44add-c3cb-4c83-aa2a-21116fe737ce"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,203,106,220,48,20,253,149,224,69,87,86,145,37,217,146,220,93,66,10,129,146,6,250,160,16,66,184,150,174,50,38,30,123,226,7,77,24,6,250,88,117,213,63,104,161,95,16,74,91,104,32,237,47,120,254,168,26,79,166,13,33,148,150,100,147,141,173,215,61,186,231,232,220,59,221,207,155,135,121,209,98,157,58,40,26,12,187,45,155,6,42,210,154,42,69,137,150,82,16,129,145,37,58,97,49,129,76,72,166,99,20,76,235,32,44,97,140,105,176,140,222,180,121,27,132,121,139,227,38,221,157,254,1,109,235,14,195,125,55,76,158,152,17,142,225,217,226,2,7,76,10,199,45,137,37,112,34,4,34,201,18,33,136,213,92,136,8,120,100,145,5,203,92,178,36,51,142,26,71,36,179,142,8,22,107,2,49,229,62,50,162,34,195,152,73,229,143,22,232,218,205,227,73,141,77,147,87,101,58,197,223,227,167,39,19,159,229,242,238,141,170,232,198,101,16,142,177,133,29,104,71,105,16,139,56,139,132,5,98,64,37,68,128,100,30,93,57,18,91,112,28,104,150,57,75,131,208,192,164,93,192,6,253,199,249,171,254,71,255,165,63,237,191,245,167,65,88,163,195,26,75,131,151,184,1,138,196,101,74,18,67,153,241,144,168,8,88,30,17,208,140,27,107,181,22,198,5,161,133,22,158,67,209,225,144,223,52,95,48,245,210,82,25,121,166,8,218,171,158,48,162,108,4,68,71,58,115,92,114,230,28,91,169,254,168,170,14,187,137,87,188,217,238,198,88,231,230,226,249,208,191,67,85,167,83,83,149,109,93,21,11,240,237,75,1,203,103,186,216,124,177,148,166,24,118,22,129,193,44,236,26,220,40,114,44,219,205,210,84,54,47,15,134,23,156,205,124,204,120,2,117,222,172,4,221,60,234,160,240,2,228,7,163,191,10,191,209,53,109,53,190,107,124,67,207,213,195,120,211,14,57,47,60,109,243,102,82,192,201,48,79,131,123,71,93,213,62,232,63,245,95,251,179,249,219,249,187,254,116,254,126,173,255,121,217,29,203,35,193,21,168,85,40,56,133,158,54,18,138,81,228,109,157,32,1,37,41,97,198,57,206,45,165,78,137,11,132,89,120,219,151,239,110,53,143,95,150,171,138,92,74,185,119,223,175,94,89,216,89,69,167,211,127,201,119,182,183,202,120,207,59,230,86,187,128,199,119,90,197,156,88,233,20,17,54,139,136,162,90,19,163,129,115,212,52,78,98,119,131,46,96,104,146,49,64,34,205,162,223,57,223,15,148,142,25,201,36,215,74,115,22,179,68,93,238,2,31,230,175,251,115,47,246,231,225,251,125,173,63,243,191,243,249,27,175,253,217,252,205,181,102,215,52,75,226,204,231,238,137,248,174,16,9,79,64,74,77,152,96,212,15,192,105,42,87,102,95,175,170,2,161,252,15,183,111,140,208,28,174,87,199,87,189,238,249,154,195,204,175,95,231,244,1,243,6,165,189,179,114,199,221,34,124,77,109,95,173,146,133,95,7,19,239,205,126,1,171,224,64,235,33,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d00d1284-6858-4e40-8c5e-a0f9533fcf07"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0d4d59f-c216-40cc-ae96-8a3781c09399"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e0d7bbe7-f11e-455f-b2e5-ea58c2f931f5"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c886b18d-6796-4aed-9bbf-b5cf5d06a8fb"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("57ed4753-40aa-4155-9040-01d05641a1f9"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5f7ffe6c-b419-41a7-92a7-41c7106f2edd"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,205,79,201,76,203,76,77,241,207,179,50,178,50,212,241,76,177,50,176,50,0,0,136,48,240,252,21,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("fa274f3d-57a3-44ee-b644-d93441a31de2"),
				UId = new Guid("7e1be2d8-91ed-49a9-b295-80136f24d052"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("57df5b20-4163-4583-a743-b3bd41e7476c"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("36a1459d-8951-4d2d-83c0-ce1785ad17d6"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5227d4a1-7e1a-488c-b08f-249e8af25b4f"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("26f8e2e7-d0a5-4cce-a1c4-005d27eac4ef"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a91ced74-aa15-4fc9-ad90-beb2c4848a91"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0597c0d4-7fe9-438b-996d-a1cec2485907"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("fa274f3d-57a3-44ee-b644-d93441a31de2"),
				UId = new Guid("24109401-bfc2-4470-b36d-6264dd15b451"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("213f4da0-dbd4-4801-9f20-61ad02c52c1a"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,5,193,65,1,0,32,8,3,192,68,123,224,112,64,28,132,254,25,188,107,157,92,118,35,74,6,47,39,50,245,96,212,149,237,206,148,62,148,174,20,226,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("14eb509a-8789-4d60-a6db-802311455631"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("abddd3f0-9e80-4557-bd19-1eb3675204b1"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ef1a0a6c-c921-4ec2-a56c-e573429c544a"),
				ContainerUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeStartSignalLeadStageChangeParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("db9eb8c4-a431-4aa1-9ee4-580f6ffe1896"),
				ContainerUId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
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
				UId = new Guid("e33c0cfe-adc7-4b51-8f8f-370d3a2a3f3d"),
				ContainerUId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeOpenEditPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("89651dda-ab13-4a9a-8a6c-4c658eb62d6b"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("26dd7e96-d79a-4c1d-a31a-e8388a3d205d"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("816e7c8a-2c10-4a6f-9be0-35eb9c4ddff5"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97a322a9-f1ca-49d6-ab97-756349dc65dc"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("c5f0d6a4-d18b-446e-8335-18fb080f660a"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dc433afb-dfc9-4098-97f6-caf21a16f74e"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("1c82493a-8e96-4e42-8e59-0050ff57ccc6"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("933618d4-76fc-43ac-ac72-94ef456a3325"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e24948f-5ffc-48eb-8cd6-6290a4458b50"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41355bca-971c-4003-990e-8da96ce29d27"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b8971ff1-f4b5-4bd1-ad83-92a56940fda8"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("6399efc5-9d36-4c8d-84c5-3e5851db8ea2"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("c482b777-a1a7-41d8-86f3-3deb50dd0ff8"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				Value = @"Заполните данные о продаже",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("8a4540f5-5964-49f6-9dd1-077938701455"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("4960bd57-b2f9-45a4-9184-feb6f57d727b"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("dbe4def5-6971-4b97-a463-8f91e0d395d8"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("865a5fc7-ff9d-42c1-b37f-e7d02f2ef7aa"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("f513407c-014f-4acb-a526-b212d7445f91"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("8dabbbff-449b-468b-a494-80ad1cb1636d"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("502e4584-f30e-4b9b-bc80-da8f5149d287"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("514f3679-fd23-41d3-ac6e-b13355c6b716"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("ea067875-15ce-466a-b805-9fd42938fa32"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("ab3aea55-ee61-4a61-8d37-c77f890582a6"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("e98d7ab1-5b31-4dfd-bd8a-01a99df1c13e"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("4fbdcb67-4e39-4e84-b5d0-e4916df0cc20"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("92150aaf-bd20-4b0b-aae5-802a6ddacaaf"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("b9c197e7-4fda-443b-af5d-04703f2512af"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("500c6c82-6637-4f8b-bb30-9fb30e6c5c7a"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("4450ed80-79a2-4253-bf53-f4c99757acd0"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("ad403374-d787-48cb-8401-24d5938fecff"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("29b687ca-aff7-43a8-8cf5-918beb75a406"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("12c7bcea-bbb6-467e-8b86-c73d6c2327ac"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("0b1c3a54-c7df-40ad-9016-020646d1af0f"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("f71b0056-5161-4704-b6e6-57433d6cec8d"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("8a103d16-ba6b-4bd1-8ddc-3e9254763dc8"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("ef2d226f-d2f6-44b9-8885-f2dc3c38e962"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41c2a0db-39ad-4b1a-9e9b-392fb44871ef"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("b75c6907-0060-42e9-a1b2-3ef95bc2be78"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("66c1e2c8-d668-462c-8641-cc41b2cb6ee7"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("aef3f8a1-0813-481c-8557-882ce62c0029"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("002eea98-0f7a-4a3f-843b-636f63d8cf6e"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("bc19d651-dabb-46b9-9f3b-b8da6581c36d"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("f650edfc-44d9-4d70-bb68-14bd3c9ad3d1"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("ca76ab70-8cff-4f21-81c9-b9e679c8ddff"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("b40747ec-b53b-4474-ba15-384d04322c33"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("35d9c012-2263-46ec-952f-e92631c411de"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("cd406c52-f5b6-4f47-9117-6e510888a57e"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("cae5665a-e99e-4f9a-9b64-97b513697bca"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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
				UId = new Guid("c552d799-9421-4e8e-aeff-e6cb6cc08f6d"),
				ContainerUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
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

		protected virtual void InitializeReadDataLeadParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9d21b7c3-5ea8-4f73-a5bf-f266ecb2b022"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,205,106,220,48,16,126,149,69,135,158,172,224,31,89,150,220,99,216,150,92,210,64,211,82,200,134,32,201,163,196,224,159,141,45,211,4,179,144,148,62,68,160,208,103,8,37,105,151,66,146,87,208,190,81,229,117,182,133,28,74,142,45,24,60,243,205,204,55,51,159,164,254,40,111,95,229,133,129,38,213,162,104,193,235,118,178,20,5,92,107,10,190,143,163,132,17,76,100,162,176,204,252,16,251,68,197,82,235,40,12,37,65,94,37,74,72,209,88,61,205,114,131,188,220,64,217,166,7,253,31,82,211,116,224,29,233,181,243,86,157,64,41,222,13,13,72,32,52,227,192,113,18,251,18,19,144,18,51,37,20,118,220,92,82,194,72,0,10,141,179,80,30,249,52,204,20,86,58,209,152,48,150,97,73,3,129,131,128,128,210,154,107,26,133,200,43,64,155,233,217,188,129,182,205,235,42,237,225,183,189,127,62,119,83,142,189,183,235,162,43,43,228,149,96,196,158,48,39,41,18,224,3,137,149,192,138,240,24,19,13,9,22,17,207,112,36,100,18,38,12,2,26,36,200,83,98,110,6,90,180,147,33,47,19,70,188,23,69,7,107,230,62,119,51,134,145,31,176,152,186,218,32,82,152,68,161,143,25,101,9,214,25,213,28,34,202,185,204,54,122,189,238,114,103,231,237,110,87,66,147,171,71,217,193,233,87,55,105,175,234,202,52,117,49,80,239,174,211,247,225,204,140,226,62,134,62,140,11,25,135,15,69,104,225,117,45,108,23,57,84,102,90,169,58,203,171,227,145,115,177,112,37,229,92,52,121,187,81,97,122,218,137,2,121,77,126,124,242,87,181,182,187,214,212,229,127,180,170,231,214,116,28,238,146,173,199,29,238,96,150,183,243,66,156,175,253,20,189,56,237,106,243,210,126,177,75,123,51,177,223,38,171,203,213,39,123,109,111,156,191,156,204,102,143,225,175,246,251,144,224,2,119,238,127,59,177,15,171,11,123,191,6,92,96,147,182,101,175,28,116,107,239,28,197,114,245,217,101,254,180,215,206,190,95,93,76,236,15,151,251,224,224,75,187,28,179,209,147,217,82,52,67,34,138,18,162,9,197,49,117,250,145,196,167,152,199,2,134,59,77,20,147,82,106,194,182,50,201,65,50,69,176,32,81,128,137,16,1,230,0,4,199,204,215,84,107,8,24,167,51,228,68,249,167,87,61,216,105,223,124,172,54,143,127,60,174,195,45,135,62,1,166,5,148,238,92,211,254,57,218,44,92,193,222,166,85,218,63,71,169,197,225,160,213,225,194,125,191,0,247,168,74,68,244,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ddb8f352-0211-44fc-8b93-f3abbd023649"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("65843b8b-f9d2-41cc-8170-734e51b1a5ca"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b341955e-cf2a-400b-907c-a8557f3c93c1"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1409c0d5-2885-44c0-8161-47a69431903e"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bf8e626b-4175-4de4-99ed-f96ac7a26c1d"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5b1ea493-ed30-4d02-bdbb-0efcafe849f9"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("d4413fda-e205-481c-828d-b4e67061712f"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95dce4e4-ff66-4664-b6f7-dacd9bf91bca"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9a35a728-e367-4047-bda3-0b7be164f5ae"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("7090f5b0-1f18-467e-9a40-60d3d177b9c4"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("11af421d-b60c-4cf9-a2f6-5d599eaa340c"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2c5d37d8-5236-42a7-b93f-6d4732c94385"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("83955bee-426f-4831-9715-4eda69412fb7"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2d0ef092-481e-4e72-920c-caa204e62d66"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e72ba4ac-d6aa-4c7c-8d86-2be667ba6622"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cc0389f7-a908-4db4-b2f9-dc8c55c3a68c"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9de08d90-800b-4623-8793-b9bdbb30f1f4"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1256d381-924c-4985-b42f-52e594574824"),
				ContainerUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeChangeDataLeadParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("f161763e-878f-4674-8e4e-3fc88a6a58b3"),
				ContainerUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("092165e2-051d-4f89-92cf-c710ba91ab13"),
				ContainerUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6c0d30ee-7c93-4ea8-9ca4-918c3d232658"),
				ContainerUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,203,106,220,48,20,253,149,65,139,174,172,193,15,217,146,221,101,152,150,217,164,129,166,165,144,132,32,75,215,137,193,143,137,45,211,4,51,16,18,40,148,166,253,133,46,187,13,165,67,39,73,211,111,144,255,168,242,56,211,66,22,101,150,45,216,32,29,223,115,238,189,199,87,106,15,211,250,89,154,41,168,162,132,103,53,88,205,84,70,8,128,242,192,21,18,187,68,134,152,80,143,226,144,250,2,123,129,112,2,226,3,13,125,138,172,130,231,16,161,129,61,145,169,66,86,170,32,175,163,189,246,143,168,170,26,176,14,147,213,230,165,56,134,156,191,234,19,16,135,39,44,132,16,83,223,142,49,129,56,198,76,112,129,147,196,11,227,128,48,226,128,64,15,181,4,64,5,179,37,166,52,78,48,97,60,196,92,50,138,169,11,177,207,92,106,251,194,71,86,6,137,154,156,206,42,168,235,180,44,162,22,126,175,119,207,102,166,202,33,247,86,153,53,121,129,172,28,20,223,225,234,56,66,28,108,32,190,224,88,144,208,199,36,1,138,185,23,74,236,241,152,186,148,129,19,56,166,83,193,103,170,151,69,83,137,44,201,21,127,205,179,6,86,202,109,106,106,116,61,219,97,126,96,184,142,39,48,241,92,27,179,192,212,152,200,32,9,193,11,194,48,150,107,191,158,55,169,89,167,245,118,147,67,149,138,7,219,193,248,87,86,81,43,202,66,85,101,214,75,111,175,194,119,225,84,13,230,62,124,122,51,52,164,12,222,147,208,220,106,106,216,202,82,40,212,164,16,165,76,139,163,65,115,62,55,148,124,198,171,180,94,187,48,57,105,120,134,172,42,61,58,254,171,91,91,77,173,202,252,63,106,213,50,109,26,13,51,100,171,114,251,25,148,105,61,203,248,217,106,31,161,39,39,77,169,158,234,47,122,217,93,232,235,238,162,187,26,233,111,250,90,223,235,251,238,131,94,140,244,157,94,246,192,88,127,214,139,238,92,127,53,232,205,168,251,104,240,133,254,97,222,251,238,98,100,240,133,254,222,93,234,187,238,202,200,44,187,243,238,178,251,212,189,55,232,205,72,223,234,159,38,186,143,191,237,222,25,181,229,120,42,135,180,232,81,121,17,218,71,9,16,201,24,216,152,4,230,96,17,22,115,28,58,177,192,16,74,144,196,143,61,225,219,99,73,136,227,37,146,99,112,109,51,157,204,17,152,185,76,226,152,64,64,109,51,154,142,155,140,55,25,225,125,100,204,251,215,45,217,155,214,47,222,22,235,123,98,248,179,7,99,131,62,2,38,25,228,102,4,162,118,19,15,231,134,176,179,78,21,181,155,56,218,83,38,133,74,213,217,112,95,68,237,38,22,207,15,122,147,15,230,230,249,5,24,107,95,83,85,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55a55d6a-8498-40c0-bdfe-95136f257586"),
				ContainerUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,111,211,48,24,254,43,149,217,177,174,18,219,137,227,28,161,67,170,180,65,197,96,151,181,7,127,188,222,42,165,201,148,164,192,168,42,49,184,114,228,135,12,132,96,28,216,254,66,250,143,112,221,148,182,176,19,142,148,200,175,253,124,196,239,227,57,58,168,175,46,1,165,232,241,240,248,164,176,117,239,73,81,66,111,88,22,26,170,170,119,84,104,153,77,222,73,149,193,80,150,114,10,53,148,167,50,155,65,117,52,169,234,110,103,23,132,186,232,224,181,95,67,233,217,28,13,106,152,190,26,24,199,12,138,11,45,72,132,85,24,38,152,41,77,176,208,65,132,41,13,19,17,146,40,33,148,56,176,46,178,217,52,63,134,90,14,101,125,129,210,57,242,108,142,128,107,107,45,163,9,22,0,142,128,112,130,147,48,54,56,50,142,218,4,90,24,26,163,69,23,85,250,2,166,210,139,110,193,44,148,54,17,32,48,143,2,133,25,40,133,19,45,53,182,150,10,21,179,132,133,160,87,224,118,255,22,120,246,232,108,80,61,127,147,67,121,226,121,83,43,179,10,198,61,87,253,171,112,152,193,20,242,58,157,51,22,217,56,1,130,149,9,40,102,156,197,88,198,156,99,74,184,82,192,57,177,177,94,56,192,159,179,76,231,38,214,84,154,196,217,163,130,99,102,140,131,16,34,176,141,8,88,169,168,97,84,45,198,143,198,43,139,102,82,93,102,242,234,244,95,167,205,231,230,174,249,210,220,52,95,155,219,229,135,229,167,78,115,191,124,239,74,223,92,233,251,242,99,111,96,58,203,107,55,255,225,43,191,220,115,215,252,236,184,233,77,115,239,16,215,205,237,90,225,114,175,201,187,26,243,209,58,41,35,148,142,30,206,74,251,93,159,205,126,90,246,131,50,66,221,17,58,41,102,165,94,177,209,213,100,211,56,207,30,180,3,63,240,218,140,53,135,135,29,203,92,158,67,249,204,233,121,184,95,234,203,90,122,233,151,206,243,134,88,17,17,5,60,180,152,131,20,46,10,177,203,145,9,37,22,161,80,150,114,74,172,37,30,253,2,44,148,144,107,216,55,38,129,197,86,37,28,235,128,104,204,164,11,163,52,52,196,82,16,170,141,17,130,105,235,241,94,121,107,102,147,105,87,201,103,89,230,5,42,255,255,171,75,210,26,111,87,250,59,61,222,97,40,204,196,78,192,12,242,255,60,170,62,88,79,249,180,40,15,223,186,171,59,201,207,219,126,237,72,111,247,244,245,180,173,47,208,98,49,94,252,6,51,223,62,160,39,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("39e4545b-9018-4881-9c69-65405bceb555"),
				ContainerUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
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

		protected virtual void InitializeAddDataContactToOpportunityParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("77b402b4-36ef-4afe-85ca-fbbfe0540b9f"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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
				Value = @"fa274f3d-57a3-44ee-b644-d93441a31de2",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("611d2131-f988-40c6-a266-7ac3720e4624"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f87e7355-4618-4675-ac15-23509e6ffedd"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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
				UId = new Guid("20e936ce-6092-493c-b50c-aaf70285c26b"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ccc51ea5-dba9-4d02-9514-ddb4ac2fa55c"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,205,111,27,69,20,255,87,172,109,143,30,107,118,190,199,71,154,32,69,106,32,34,165,151,36,135,55,95,173,37,127,68,246,6,8,150,165,54,65,72,168,45,39,78,92,56,114,13,21,161,110,66,218,127,97,247,63,226,237,218,33,78,169,82,132,56,160,136,181,236,245,252,102,126,239,189,125,243,222,111,118,154,221,45,14,247,99,214,205,62,218,218,220,30,165,162,115,111,52,142,157,173,241,200,199,201,164,115,127,228,161,223,251,26,92,63,110,193,24,6,177,136,227,135,208,63,136,147,251,189,73,209,110,173,146,178,118,118,247,139,102,46,235,238,76,179,141,34,14,62,223,8,104,25,0,2,64,4,34,83,226,68,196,24,136,99,218,146,164,117,176,134,91,198,153,70,178,31,245,15,6,195,205,88,192,22,20,143,179,238,52,107,172,161,1,41,164,203,69,0,226,193,40,34,64,51,2,210,36,34,3,36,14,212,185,20,104,54,107,103,19,255,56,14,160,113,122,69,78,192,180,72,60,16,169,1,189,163,123,226,148,16,36,88,46,68,14,60,15,145,213,228,229,250,43,226,206,157,157,141,201,167,95,14,227,120,187,177,219,77,208,159,196,189,14,162,239,0,235,253,56,136,195,162,59,21,66,38,101,34,35,46,80,244,165,133,34,160,180,38,248,128,206,69,173,89,82,126,134,132,63,115,217,157,6,229,57,4,99,137,230,86,19,17,2,82,24,195,228,72,22,19,56,30,4,119,179,189,59,123,117,136,161,55,217,239,195,225,195,191,70,90,254,80,190,41,127,41,79,202,151,229,188,58,170,158,183,202,183,213,19,132,126,69,232,183,234,184,179,17,90,213,83,28,191,106,144,11,252,188,41,95,183,112,120,82,190,69,198,211,114,190,240,176,127,109,147,87,125,76,119,23,149,178,155,117,119,223,95,43,203,251,34,55,215,171,229,122,161,236,102,237,221,108,123,116,48,246,181,53,94,15,46,55,174,177,78,151,23,121,207,207,229,181,176,209,208,54,97,8,143,226,248,19,244,215,208,155,169,53,40,160,113,253,0,99,190,52,236,152,149,84,231,137,232,8,22,11,81,49,98,66,14,196,230,214,37,174,57,75,137,53,236,207,98,138,227,56,244,241,122,96,16,133,74,206,104,226,41,243,88,135,209,16,8,60,39,128,37,236,67,176,86,248,212,240,27,207,87,193,92,214,52,34,195,131,126,191,113,48,105,158,191,110,146,101,224,203,153,181,149,61,94,177,48,10,189,212,139,97,99,248,15,83,181,22,83,99,242,227,209,120,253,43,108,221,222,240,209,114,191,86,92,95,173,89,243,131,37,62,203,102,179,246,106,55,99,6,25,151,78,146,148,59,67,68,110,48,9,42,49,194,172,213,52,129,183,49,230,55,118,51,40,102,2,7,32,218,170,156,8,43,56,49,70,57,146,115,37,85,30,130,247,86,253,39,186,57,69,17,140,137,148,8,37,113,187,141,171,43,197,121,18,109,136,1,37,137,123,73,223,237,102,12,130,39,84,170,200,168,68,74,238,137,193,167,37,14,139,77,83,149,235,156,165,154,178,62,44,122,197,225,189,38,71,221,41,4,97,105,144,134,80,41,0,53,192,72,98,25,106,71,8,70,40,21,29,71,149,252,27,26,240,115,221,251,229,201,162,255,151,125,94,61,43,79,91,229,121,57,175,129,78,249,83,121,138,186,240,18,209,215,173,234,5,226,167,229,239,248,189,168,142,90,136,159,150,175,170,227,242,188,122,142,102,230,213,147,234,184,250,190,250,14,81,84,138,51,20,140,243,102,253,89,245,45,90,155,119,202,31,81,108,78,106,211,213,55,248,69,176,81,156,26,187,168,215,159,148,103,11,26,26,175,7,213,209,255,18,243,97,137,201,149,139,216,7,57,49,9,143,17,145,75,139,18,21,40,1,67,241,40,80,134,135,192,111,189,196,24,27,92,110,146,34,146,171,250,188,167,152,4,41,29,81,2,146,151,50,58,160,230,230,23,6,79,149,99,16,137,246,90,16,81,55,164,177,18,143,101,60,100,141,229,76,50,101,254,125,137,41,198,120,187,161,69,47,231,111,247,33,107,169,83,210,37,20,179,148,80,53,115,129,181,172,241,109,143,9,70,241,15,36,75,245,77,29,64,151,215,7,3,187,101,29,176,55,251,3,201,197,155,205,140,11,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("77fca69f-0da0-430c-a3da-c7ed23ab5394"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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
				UId = new Guid("39b51b00-83a0-4835-8530-2e20f2ce420c"),
				ContainerUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
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

		protected virtual void InitializeAddDataOpportunityParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("36768833-e793-4cd5-8c7c-6fa9657737df"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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
				Value = @"ae46fb87-c02c-4ae8-ad31-a923cdd994cf",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1aa11035-b136-470f-8cb3-1f4060a6f342"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05d8eeec-d375-46f9-ae98-2ee983ccb91d"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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
				UId = new Guid("8513b4b5-7a5d-4bac-b336-7ffa764d5510"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("488491cb-2475-44b0-9985-39cc11395c42"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,90,91,111,92,213,21,254,43,163,3,15,32,188,205,190,95,44,241,66,146,74,145,72,137,26,202,75,156,135,181,111,96,105,60,99,205,140,219,166,150,37,218,72,85,171,82,162,74,125,168,42,21,36,94,120,77,83,12,38,1,243,23,206,252,35,190,115,198,38,118,73,199,40,60,96,121,236,135,185,236,57,107,173,115,246,222,223,183,214,250,182,247,154,151,103,247,119,74,179,209,188,121,251,214,157,113,157,173,95,27,79,202,250,237,201,56,149,233,116,253,173,113,162,225,214,239,41,14,203,109,154,208,118,153,149,201,187,52,220,45,211,183,182,166,179,181,193,105,163,102,173,121,249,55,253,111,205,198,221,189,230,230,172,108,255,250,102,134,103,34,41,148,21,158,229,228,2,211,58,115,230,117,138,204,81,8,156,172,20,78,5,24,167,241,112,119,123,116,171,204,232,54,205,222,111,54,246,154,222,27,28,232,24,76,81,181,178,154,141,100,154,138,96,145,147,97,50,25,193,49,46,12,185,102,127,173,153,166,247,203,54,245,65,159,25,83,209,182,70,239,88,226,50,117,198,158,81,86,130,81,144,42,229,28,130,78,181,51,62,190,254,153,225,221,151,238,222,156,190,253,219,81,153,220,233,253,110,84,26,78,203,189,117,140,254,207,192,247,83,179,177,167,180,164,146,140,101,94,25,60,107,50,145,121,105,35,11,197,107,31,106,182,164,227,254,189,151,238,117,17,243,214,116,103,72,247,223,253,97,224,246,95,237,81,251,205,252,143,243,15,218,71,237,127,219,131,238,243,194,102,231,204,42,156,182,218,219,92,44,229,102,179,177,249,252,197,60,126,95,220,252,217,229,60,187,146,155,205,218,102,115,103,188,59,73,157,55,213,125,57,153,217,222,59,63,254,99,207,121,57,249,91,248,232,205,110,209,136,222,43,147,95,34,94,111,222,255,116,157,102,212,135,126,7,247,124,226,56,202,96,184,19,149,185,66,152,189,98,37,243,89,16,11,34,196,170,156,146,181,202,222,250,87,165,150,73,25,165,114,246,198,164,201,46,9,138,76,228,194,153,54,28,27,69,115,201,184,44,188,96,147,200,108,23,15,215,71,126,118,51,39,155,14,35,163,221,225,176,15,48,237,159,191,219,197,199,55,126,252,203,245,83,171,118,202,195,56,111,213,173,146,111,142,94,112,170,174,151,218,187,252,197,120,114,227,119,192,214,214,232,189,227,245,58,21,250,217,53,215,211,246,241,248,126,179,191,191,118,26,110,209,215,32,180,244,76,7,109,24,246,99,135,22,89,153,84,150,84,226,190,56,103,151,194,205,5,110,172,74,29,220,132,102,58,155,204,200,212,204,162,45,57,71,193,179,205,234,130,192,45,202,104,116,49,138,25,197,177,97,172,225,140,146,117,44,122,210,142,155,44,101,212,29,220,6,131,215,6,155,205,235,155,13,222,95,121,161,72,92,70,161,109,200,204,73,202,152,90,132,35,135,57,178,81,139,232,66,214,130,92,23,233,53,241,234,250,59,227,59,179,9,22,240,149,87,207,129,249,63,219,175,231,15,7,237,147,246,105,123,184,64,121,251,232,7,55,123,109,184,85,70,179,183,119,118,198,147,217,238,104,107,118,255,218,120,119,52,123,94,164,203,77,14,38,145,50,85,96,133,5,112,173,187,101,166,96,137,41,175,50,89,170,148,106,90,70,14,63,250,198,46,51,57,100,10,78,0,196,204,80,42,200,197,49,49,111,53,146,170,86,25,220,25,99,18,105,121,46,86,218,123,30,10,179,149,119,236,98,225,192,131,98,131,241,181,150,192,163,0,187,252,140,228,112,99,88,182,1,151,141,189,90,116,246,190,75,3,214,32,150,143,93,26,193,227,150,144,75,214,38,170,100,248,254,89,140,103,173,133,170,153,88,145,221,179,121,129,103,147,30,196,135,76,228,184,21,78,200,218,153,220,24,205,122,24,118,115,180,177,231,189,140,85,100,199,84,70,230,210,146,123,230,121,34,22,65,195,42,249,172,107,103,117,110,202,255,172,61,236,224,143,164,255,225,160,253,28,121,255,27,240,193,95,219,131,65,79,14,24,88,111,63,105,15,80,17,60,198,232,87,131,249,223,48,126,208,126,189,160,141,1,198,15,218,47,231,15,218,167,243,15,225,230,112,254,193,252,193,252,163,249,95,48,250,85,71,48,71,184,186,187,254,201,252,79,240,118,184,222,254,125,254,17,156,126,1,143,43,81,89,152,148,60,183,60,51,155,193,32,218,57,197,80,142,97,125,147,64,81,80,173,9,100,175,200,227,28,242,64,253,170,93,69,250,203,21,117,173,14,10,144,146,82,177,18,117,174,74,101,239,210,114,242,80,68,81,145,148,12,16,180,12,41,211,178,224,35,92,197,228,18,73,30,35,255,89,201,227,5,242,253,224,141,55,6,124,57,180,255,95,2,255,222,244,114,67,15,57,193,154,88,61,227,21,128,211,66,11,230,29,26,65,217,81,165,115,84,3,119,87,208,59,7,122,69,129,168,124,81,172,202,128,73,148,168,231,201,0,127,146,140,32,99,173,226,64,206,50,232,89,175,13,12,80,51,25,108,106,32,137,24,85,29,89,77,206,150,80,139,178,65,175,86,222,54,137,87,114,193,162,59,242,10,251,82,90,244,14,37,176,84,115,78,18,147,21,136,95,188,188,253,49,174,122,220,101,237,249,31,22,159,142,227,225,234,47,219,71,131,246,91,120,60,234,239,227,139,249,131,85,200,236,63,85,51,16,54,98,243,27,144,82,45,168,131,5,100,27,159,33,81,145,231,42,107,139,230,34,171,75,223,22,4,153,200,11,43,88,146,9,189,21,20,53,70,214,24,150,67,137,148,52,180,171,98,150,211,75,228,57,121,40,5,202,69,40,15,34,117,69,112,32,102,139,226,57,83,21,85,201,85,163,23,27,240,179,102,86,226,121,160,69,161,226,180,177,50,84,62,54,97,83,89,149,205,197,163,151,79,241,246,45,88,164,61,234,213,199,131,246,63,8,120,212,115,205,225,21,155,156,207,38,133,231,88,34,42,92,84,199,120,41,165,128,72,170,100,36,181,131,136,150,138,247,254,210,179,73,173,16,222,184,130,64,95,29,38,161,70,5,60,3,48,220,107,232,223,62,64,27,143,75,217,36,249,106,160,50,162,88,193,17,1,170,157,0,58,234,21,221,90,45,132,116,14,106,170,171,197,38,58,41,178,85,224,32,33,100,20,43,145,42,250,87,163,25,119,86,58,156,168,88,103,210,197,99,147,127,116,161,78,170,146,67,248,120,216,155,61,236,61,205,255,220,23,47,248,186,10,196,146,165,40,161,84,141,93,105,33,170,115,33,89,148,222,178,74,2,153,23,154,28,105,125,213,5,157,67,44,210,3,59,70,10,108,251,14,115,18,58,112,144,213,48,156,184,145,162,130,178,69,212,165,196,34,76,229,149,7,193,138,181,157,86,151,113,60,199,29,186,32,157,208,230,91,133,234,101,197,212,75,210,56,130,213,93,55,200,11,97,95,22,72,50,218,161,21,50,33,137,92,99,12,234,2,170,151,255,70,132,142,83,30,161,3,122,186,160,145,46,214,227,51,253,79,123,176,10,196,242,83,251,31,147,161,12,64,213,98,194,116,219,45,23,131,134,24,47,84,113,212,87,173,11,232,147,47,125,197,34,141,247,72,170,26,106,95,198,36,86,66,197,86,160,81,121,25,64,204,137,114,116,124,121,255,163,137,67,228,194,105,148,129,200,172,51,10,253,88,179,103,53,26,23,200,233,170,66,185,32,202,38,212,56,165,141,52,56,56,211,104,76,192,162,40,37,20,103,197,197,148,130,39,225,140,253,241,255,162,0,160,61,89,141,35,132,43,161,161,188,16,208,238,237,127,7,17,208,0,48,101,36,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d6c3ad89-7397-4dd6-a229-f52efab3d43b"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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
				UId = new Guid("382303ab-5cc8-404c-8886-60dff832b89c"),
				ContainerUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
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

		protected virtual void InitializeReadDataCountOpportunityByAccountParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95d638cd-1142-40c7-b944-f9e7fdc8b952"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,219,106,220,48,16,253,23,61,228,201,42,178,46,182,229,62,46,91,8,148,52,208,11,133,176,132,177,52,74,76,125,139,45,211,134,101,161,244,51,250,21,133,146,199,246,27,54,127,84,217,187,110,67,40,165,15,125,41,232,65,154,225,156,57,115,102,180,189,44,135,103,101,229,177,207,29,84,3,70,227,169,205,73,138,130,185,66,41,154,90,157,81,105,132,163,133,192,132,166,12,140,52,177,202,172,6,18,53,80,99,78,14,232,181,45,61,137,74,143,245,144,95,108,127,145,250,126,196,232,210,205,143,151,230,26,107,120,61,21,0,148,137,43,178,148,26,198,13,149,128,25,5,43,98,10,154,11,99,173,214,210,56,114,208,82,136,204,10,6,5,77,82,107,169,76,101,65,51,192,148,38,90,88,6,232,10,233,50,18,85,232,252,250,67,215,227,48,148,109,147,111,241,231,253,213,109,23,84,30,106,175,218,106,172,27,18,213,232,225,28,252,117,78,100,161,21,10,231,168,179,138,79,66,98,90,48,80,148,27,21,179,16,143,21,164,36,50,208,249,137,150,236,63,239,191,239,191,221,127,186,255,184,255,178,255,186,191,155,238,36,234,209,97,143,141,193,7,29,114,101,83,19,7,217,177,69,70,165,98,129,88,50,78,25,71,134,129,148,219,4,73,100,193,195,27,168,70,156,85,110,203,169,95,174,21,75,99,71,83,4,77,37,38,156,102,54,6,170,99,93,56,145,10,238,28,95,188,127,222,182,239,198,46,248,62,156,141,53,246,165,57,14,17,195,52,218,62,223,154,182,241,125,91,77,228,103,15,0,135,97,29,147,111,15,6,85,115,102,2,146,93,52,14,184,170,74,108,252,186,49,173,45,155,171,121,142,187,93,192,212,29,244,229,176,216,186,190,25,161,10,6,148,87,215,127,180,127,53,14,190,173,255,183,126,163,208,107,160,9,171,59,107,158,54,219,150,67,87,193,237,252,206,201,201,205,216,250,167,191,91,138,147,57,67,30,49,44,8,33,57,160,81,9,205,132,10,61,27,21,118,154,39,5,213,152,201,76,59,155,128,44,142,12,187,232,31,213,188,56,29,94,188,111,150,95,120,48,110,243,36,68,31,5,206,23,116,190,253,27,153,187,205,34,116,179,11,231,7,119,61,242,64,80,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("baccf23b-370e-4e0b-b657-7bfa21cdd970"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("daf54a7f-8a62-4589-9c9c-c261921a13fd"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cf300c28-9b38-48ff-a8d5-ecb1fba12e64"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc3b5658-a8e6-4cab-b27b-819a3025ed71"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("693953ab-8637-4183-87d1-ee4988a862f8"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5e608114-da8f-4197-a7c1-9abde0e48dca"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("a81f55d7-8bc9-4327-b691-9ede33487823"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a83ce913-3e58-4db8-b563-712f4f1f1d4f"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f23fe366-df2c-4531-b2ed-ebdf444d985e"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("236f9f63-489b-4485-b92a-f5a499fe453e"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5a384c94-4c0e-46d6-ab9c-2f2f6cf1de5a"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("199f3817-15db-4ed6-b57f-350fc7b100b3"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d3ab4b8a-b637-47a5-bc47-da539d6683f1"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("156fda51-7aad-4289-bdf5-909adb3f882f"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("84c58779-0b9a-4c9a-92d9-5ba3900861f5"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d2b28272-8058-40a5-b869-30703026b4b7"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("65e21e52-02d5-4036-ab27-31a7bd141180"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bbb76cdb-6487-4e75-a4bf-d06db7d6e4b8"),
				ContainerUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadDataAccountParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("760c8144-4547-4f2e-9058-d28c8497d3e6"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,106,220,48,20,253,23,45,186,146,138,173,151,45,119,57,76,203,108,210,64,211,82,72,134,32,75,87,25,129,31,19,91,166,9,102,160,244,51,250,21,133,210,101,251,13,206,31,85,30,103,90,200,162,116,209,77,193,139,171,43,157,115,207,57,92,143,215,190,127,233,171,0,93,225,116,213,3,30,54,182,64,74,112,145,151,28,8,117,224,8,207,152,33,154,26,69,82,97,89,42,104,42,156,212,8,55,186,134,2,45,232,181,245,1,97,31,160,238,139,203,241,55,105,232,6,192,215,238,120,120,99,118,80,235,183,243,0,42,108,102,82,93,146,212,66,66,184,72,82,82,242,132,146,132,66,2,66,103,212,74,64,139,22,38,115,38,147,4,8,231,185,34,60,74,32,202,81,75,100,34,101,169,64,229,206,166,8,87,224,194,250,110,223,65,223,251,182,41,70,248,85,95,220,239,163,202,101,246,170,173,134,186,65,184,134,160,207,117,216,21,72,199,121,92,24,77,12,87,130,112,7,25,209,76,89,194,116,153,209,44,135,84,166,25,194,70,239,195,76,139,54,22,97,171,131,126,167,171,1,142,204,163,159,237,176,36,205,133,140,216,52,70,197,25,77,72,46,243,140,56,43,157,2,38,149,42,237,41,175,87,131,143,181,239,207,134,26,58,111,30,99,135,152,95,219,21,163,105,155,208,181,213,76,125,118,124,126,1,119,97,9,247,241,234,253,98,40,196,254,12,66,7,60,244,176,170,60,52,97,221,152,214,250,230,102,225,60,28,34,164,222,235,206,247,167,20,214,183,131,174,16,238,252,205,238,143,105,173,134,62,180,245,127,100,21,71,155,145,35,46,217,81,238,188,131,214,247,251,74,223,31,207,5,122,118,59,180,225,197,244,121,250,49,125,127,248,244,240,113,250,50,125,157,190,205,245,114,131,158,48,20,232,10,49,78,53,24,33,73,206,68,220,60,35,74,146,83,89,18,5,121,92,197,104,88,243,242,10,69,85,255,96,214,229,166,127,253,161,57,253,35,139,171,237,243,216,125,210,56,63,33,139,241,111,228,29,182,179,192,237,33,126,63,1,42,50,179,84,234,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("29d241ea-e7c1-468b-93dd-4fabc9692e05"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("99fe1d4f-11a3-4a99-a403-3f8329c46387"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("23c9ab4d-c03e-4823-a89d-b8157e04f637"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0481537e-1347-4a84-bc95-3f25b63bd2aa"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("98fe3323-90ae-4f77-9698-90cb6049bb21"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ab5fefa4-6698-4258-940b-0a2c6dd14a31"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("d3b28169-5be2-4f9c-97c0-eef28ed4f516"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3bc1a643-8bc8-4d8c-96c9-19e0df86a151"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("801aa1e5-b4cb-4d94-abad-0dfa07dffec6"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f75452e6-8240-4d69-825e-90cd8847e099"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("36ec811c-adc6-4e15-a536-d4bbcf966b71"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("affd0b02-dbe8-4101-aeb3-b62e33160dd3"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("591a5668-a8e2-41dc-a509-888da5a63e1a"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("9cc3666e-b170-44af-a775-f6810f7e7250"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("87a74108-882e-4315-a51f-706bae061c72"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e5436907-184b-4bae-b060-99c5407f2a22"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e77a1286-e9d2-4754-9186-5bb645bb8767"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("607a5352-158d-4931-bac2-3b4dc98d8819"),
				ContainerUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadDataContactParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f3d16d53-5568-4d10-85f2-ecee93297c69"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,221,84,205,106,220,48,16,126,149,69,135,158,172,69,182,101,91,114,143,97,91,114,73,3,77,75,33,9,65,182,228,196,224,159,205,90,166,9,102,33,108,74,161,52,237,3,244,210,99,175,33,116,233,38,233,230,25,228,55,234,120,157,109,33,135,146,107,11,22,104,62,207,124,51,243,105,164,230,32,173,158,165,153,86,147,48,17,89,165,172,122,83,134,200,102,132,197,60,74,176,226,1,193,148,4,62,102,194,150,216,77,4,11,184,112,164,29,217,200,42,68,174,66,212,71,143,100,170,145,149,106,149,87,225,110,243,135,84,79,106,101,29,36,43,227,101,124,164,114,241,106,149,192,143,148,235,123,54,102,137,114,48,181,61,142,153,148,4,11,70,92,73,125,230,74,233,162,190,150,196,141,136,23,113,142,133,207,25,166,126,36,49,243,29,23,147,128,36,137,205,41,241,57,65,86,166,18,61,58,25,79,84,85,165,101,17,54,234,247,126,231,116,12,85,246,185,55,202,172,206,11,100,229,74,139,109,161,143,66,36,20,81,212,139,5,142,41,247,48,77,84,128,133,203,161,83,17,5,78,192,148,237,219,1,178,98,49,214,29,45,218,148,200,146,66,139,215,34,171,213,138,185,73,161,70,199,37,54,243,124,136,181,221,24,83,215,33,80,35,11,112,34,253,132,67,163,156,71,114,173,215,243,58,133,125,90,109,213,185,154,164,241,189,236,10,244,43,39,97,19,151,133,158,148,89,71,189,181,114,223,81,39,186,23,247,254,215,155,190,33,13,120,23,132,166,86,93,169,141,44,85,133,30,21,113,41,211,226,176,231,156,78,33,36,31,139,73,90,173,85,24,29,215,34,67,214,36,61,60,250,171,90,27,117,165,203,252,31,106,213,130,54,129,3,134,108,85,110,55,131,50,173,198,153,56,93,217,33,122,114,92,151,250,169,249,102,22,237,204,92,182,179,246,98,96,190,155,75,179,52,203,246,163,153,15,204,173,89,116,192,208,124,53,243,246,204,92,1,122,61,104,63,1,62,55,63,97,45,219,217,0,240,185,249,209,158,155,219,246,2,104,22,237,89,123,222,126,110,63,0,122,61,48,55,230,14,188,59,255,155,246,61,176,45,134,230,139,185,130,28,64,221,190,131,5,32,48,220,173,176,101,231,127,105,110,250,48,32,239,140,118,214,151,137,30,180,19,162,61,148,40,42,25,83,112,27,125,15,116,103,145,192,220,142,98,184,161,82,73,234,69,110,236,145,161,164,212,118,19,41,176,114,8,76,51,179,99,204,28,38,113,68,149,31,16,24,101,219,73,134,66,82,78,164,199,48,241,168,192,192,234,97,238,80,31,75,201,168,239,171,200,229,204,221,67,32,246,255,38,225,238,102,245,226,109,177,126,135,250,201,217,31,2,250,0,24,101,42,135,17,11,155,199,104,62,133,128,237,117,170,176,121,204,9,116,33,163,66,167,250,180,127,143,194,230,49,71,50,221,239,14,101,127,10,223,47,9,165,86,29,181,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d0e3dc9-842e-46e7-8ec6-d71896474631"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("01b2e31d-1d81-4b50-bc28-b8d8b4b60976"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2fc79c56-2808-4e39-a3da-7b92d8218134"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4d312b88-dd01-43fa-a2cf-92d118789fc2"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("705dbcc7-95ff-47ba-a0de-e637092435f6"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0dfc2b7f-d9f0-4923-87e3-ce36e9fb5442"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("daa09ed7-2a7d-4450-a30a-dd8ac16c0a06"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c0aed0e-7343-442c-970e-e1e5c5a4ede4"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("957d85e9-6cea-4ba9-b671-6ff1d0faecee"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("96aba7e1-c060-491b-a648-67b8fed13557"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0afa84c8-ac3e-4b20-8ff2-a08e0f96f627"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("13f4af03-0d2b-4788-9a8d-f585fb5cfd13"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2c12c50b-6308-45df-becd-68952bb8177e"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("adb4ba05-85d5-4736-a24e-94b25bcf8904"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("04d717aa-6962-480f-b56d-1be4aba03d1c"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("67a25d02-1e6e-46fc-bb0a-c9e2f19819ab"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c7366f82-7e36-4b9b-ba4b-6ce38fde9f5b"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a3590db7-7310-416b-84eb-84237f10a0f1"),
				ContainerUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializePresentationTaskCreationParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("a81724cd-f82e-401e-bdc4-1f4968318e58"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dafab651-4b04-4a39-9ffa-a14a50789205"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ff84282e-f6d0-4910-a414-28117fa48082"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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
				UId = new Guid("5ad22c54-905a-451d-b9fd-76ff73069b58"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5cd8ef8c-6a8f-48a6-8cbb-13e448e5e606"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,90,93,111,156,71,21,254,43,214,166,23,32,101,86,243,253,225,59,104,130,176,148,64,68,160,55,113,46,206,124,181,22,182,55,218,93,3,169,101,41,31,8,132,40,69,66,149,144,122,65,5,55,220,154,148,80,39,105,147,191,240,238,63,226,153,119,109,226,132,116,109,53,169,148,218,107,203,187,222,121,223,153,121,119,230,60,207,57,231,57,179,59,120,103,122,251,86,25,172,14,126,120,237,234,245,81,157,14,223,29,141,203,240,218,120,148,202,100,50,188,50,74,180,185,241,33,197,205,114,141,198,180,85,166,101,252,30,109,238,148,201,149,141,201,244,226,202,241,78,131,139,131,119,126,213,95,27,172,222,216,29,172,77,203,214,47,214,50,70,22,129,170,115,50,48,81,76,102,90,151,192,188,182,150,185,36,120,142,42,88,67,6,157,211,104,115,103,107,251,106,153,210,53,154,126,48,88,221,29,244,163,97,0,157,83,229,164,4,115,53,59,166,115,36,70,156,107,86,180,80,81,56,163,180,18,131,189,139,131,73,250,160,108,81,63,233,243,206,73,235,144,189,146,140,116,74,76,71,46,88,12,217,48,79,66,38,45,41,84,31,90,231,195,251,159,119,92,31,116,159,205,238,116,79,187,7,221,195,217,221,217,189,238,96,165,123,134,134,135,221,23,248,251,10,13,251,179,223,117,7,179,143,215,7,173,127,222,152,220,218,164,219,239,189,230,48,183,94,88,230,227,3,237,174,207,247,106,125,176,186,254,234,221,58,124,191,222,47,195,139,251,245,226,86,173,15,46,174,15,174,143,118,198,169,141,166,218,135,163,165,235,71,231,135,63,236,21,47,71,63,243,49,250,110,87,105,155,222,47,227,159,96,190,190,123,127,233,18,77,169,159,250,231,120,230,163,129,77,34,101,170,224,140,4,246,65,39,235,24,5,75,76,121,149,201,82,165,84,83,223,251,103,165,150,113,217,78,229,27,62,88,63,243,243,135,57,178,42,180,108,239,108,110,246,19,76,250,239,223,204,244,240,193,15,175,92,58,182,145,199,70,24,229,141,186,81,242,218,246,55,124,162,75,165,246,67,254,104,52,190,252,27,128,103,99,251,253,195,253,58,54,245,243,123,46,165,173,195,246,189,193,222,222,197,227,120,138,181,22,19,171,99,85,120,44,98,76,158,121,83,43,43,213,91,83,141,53,190,186,197,120,178,94,103,13,20,233,104,35,240,36,136,5,85,35,115,188,36,73,181,100,227,234,155,199,211,141,11,55,214,38,63,253,245,118,25,207,87,112,181,210,230,164,220,28,162,245,165,134,203,155,101,171,108,79,87,119,181,54,213,250,34,89,204,92,49,237,180,101,100,157,99,74,186,24,11,56,165,218,180,135,14,255,179,245,213,221,108,147,162,236,3,115,42,52,174,200,232,34,193,61,213,200,82,41,170,172,85,220,187,121,225,230,34,200,222,184,208,125,2,192,254,171,219,7,104,15,102,247,102,31,205,33,251,180,251,55,154,254,51,187,63,92,203,43,179,187,248,252,69,223,242,21,126,159,118,143,86,240,113,191,123,134,30,119,187,131,249,12,103,27,205,81,6,195,157,168,204,21,10,76,23,43,153,239,141,73,132,88,149,83,178,86,185,8,205,84,180,173,209,59,150,184,132,41,81,241,140,50,104,158,130,84,41,231,16,116,170,103,30,205,34,194,72,133,171,192,48,204,91,71,87,88,172,38,49,229,82,230,82,241,154,133,94,136,102,163,131,72,74,1,255,65,194,226,19,97,21,141,11,44,107,47,120,33,163,147,177,223,6,154,175,140,70,191,220,185,53,116,6,95,64,133,200,140,201,109,4,0,14,70,192,153,170,58,144,241,57,216,228,134,53,22,78,9,215,193,239,156,229,42,48,13,231,21,235,42,178,229,37,40,159,236,137,152,252,123,15,194,134,201,167,179,223,3,114,7,221,227,97,247,15,188,61,91,65,235,227,230,90,113,13,80,156,187,217,97,247,87,52,3,159,184,121,127,9,199,147,225,120,154,157,60,243,112,148,153,92,2,126,88,13,165,57,200,92,89,136,148,224,63,52,72,73,122,135,248,117,33,28,147,23,186,146,19,172,112,1,231,170,164,97,148,124,198,82,106,146,65,149,44,148,255,22,225,24,172,40,146,123,120,61,33,155,111,7,37,68,30,12,211,60,138,98,53,220,99,226,67,45,147,211,73,7,102,124,177,115,56,6,135,167,125,125,56,126,10,184,221,67,92,251,57,26,239,192,19,254,249,107,160,249,151,246,79,139,130,151,224,60,157,175,60,205,190,158,121,112,218,170,106,177,41,48,153,35,50,201,98,1,171,22,20,166,152,130,141,90,25,39,194,66,112,98,145,115,73,70,48,239,225,98,181,244,196,128,0,188,240,196,147,208,81,104,165,223,60,56,167,99,188,45,0,211,209,245,179,29,45,6,30,45,210,22,207,120,173,88,62,161,177,11,14,113,138,212,176,107,231,168,6,62,119,47,203,220,239,235,17,224,149,78,28,62,132,57,7,179,213,158,35,55,18,240,214,134,156,17,228,124,42,49,47,68,64,179,85,50,202,51,43,34,146,71,172,57,11,21,78,142,139,96,131,176,200,143,114,126,43,114,191,90,116,246,190,112,166,109,131,170,71,186,26,68,76,136,114,115,201,218,68,149,12,127,57,247,211,16,132,106,38,6,166,4,51,122,145,152,151,112,189,17,76,225,184,21,78,200,218,186,92,222,158,110,76,111,191,219,175,209,234,110,169,9,78,186,151,35,20,150,212,192,214,125,37,205,68,118,60,217,88,165,173,225,20,25,227,63,91,166,216,188,95,203,22,15,179,194,217,31,187,135,43,221,19,56,63,52,12,187,207,224,238,238,116,15,208,250,104,101,246,39,180,63,236,190,156,107,64,43,115,65,104,118,191,123,50,251,168,121,200,217,157,217,253,217,199,179,63,160,21,121,229,99,164,151,79,250,251,31,55,173,168,57,208,79,122,71,187,191,210,228,164,7,125,239,47,155,179,125,112,204,175,158,139,28,52,75,81,66,169,26,57,164,213,240,134,2,128,144,112,147,149,4,121,236,120,38,173,151,172,114,82,14,234,92,49,170,10,112,177,192,34,66,42,97,209,39,199,76,72,10,209,161,34,147,227,98,69,137,35,100,44,80,2,132,137,18,136,85,80,248,98,180,140,39,167,64,237,81,167,16,151,172,242,42,86,25,254,32,231,31,3,55,147,239,137,239,127,23,25,230,229,231,95,178,205,146,109,78,96,155,224,75,147,182,32,88,101,40,126,189,206,16,121,196,71,72,12,41,104,110,35,4,171,133,81,60,119,202,86,82,204,5,68,66,218,89,176,77,177,129,5,139,216,222,134,160,160,136,189,21,108,227,32,203,197,146,4,203,166,246,90,64,128,182,135,140,59,90,69,69,241,192,161,227,191,28,195,84,146,185,221,88,33,149,161,88,214,252,89,69,217,12,234,65,136,153,2,234,36,229,255,99,24,8,250,198,40,66,53,197,4,36,70,88,28,70,85,71,12,226,108,9,181,40,27,244,107,197,48,199,228,239,198,13,111,146,103,254,134,187,90,109,236,94,175,13,224,191,195,89,31,157,135,240,229,117,37,116,97,35,54,183,37,180,21,101,18,45,12,106,171,57,3,15,158,35,148,183,40,171,101,117,230,101,129,196,155,30,130,84,210,154,0,9,93,202,246,253,67,96,156,130,14,210,24,75,214,47,36,148,88,137,66,130,6,159,148,5,35,105,100,85,94,245,85,74,103,45,175,84,133,246,231,43,41,162,140,212,48,27,36,235,70,35,41,202,222,176,32,161,180,228,220,74,247,5,85,123,175,222,190,164,232,83,208,199,126,27,122,246,91,252,181,170,250,188,240,142,121,219,253,80,34,231,221,250,170,123,147,37,151,20,179,164,152,83,81,76,230,41,36,79,25,110,85,2,15,182,81,116,84,138,1,29,64,121,130,56,155,22,199,44,25,126,88,11,208,59,84,74,164,88,200,169,24,10,247,56,195,34,132,207,213,20,143,164,235,156,81,76,225,69,227,64,8,67,33,2,189,106,65,244,162,16,189,40,138,78,58,95,4,58,190,117,20,179,150,151,148,113,50,101,104,65,176,72,156,243,114,134,35,238,45,49,50,159,90,17,173,162,188,104,181,215,128,203,153,143,74,20,36,109,30,161,180,226,100,19,14,175,68,21,225,66,125,100,82,21,18,2,135,157,170,89,124,76,167,70,158,45,202,255,76,56,66,154,67,56,241,70,194,160,156,136,99,59,90,37,155,249,121,139,74,144,23,161,20,93,52,12,73,96,73,125,69,84,210,146,35,13,249,27,9,144,199,105,7,243,157,142,74,250,130,234,231,243,137,150,68,115,50,209,72,147,113,138,148,34,100,181,102,126,77,197,143,45,122,231,18,206,5,70,33,225,118,207,34,209,220,220,251,47,39,220,99,173,185,43,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3b349266-cabe-4ac9-9bab-90e5a99b9312"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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
				UId = new Guid("47ce121a-112c-4d86-91bb-d5e256add4c7"),
				ContainerUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
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

		protected virtual void InitializeReadOppoortunityData2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e113eec9-67b0-4d53-8bd1-162890643787"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,113,236,60,28,202,209,128,182,89,86,98,65,72,187,163,213,141,125,189,99,41,143,217,196,17,187,138,70,66,162,162,226,31,248,130,41,128,130,2,126,33,243,71,56,147,29,144,182,64,20,52,72,46,236,107,159,115,207,57,186,30,174,108,247,204,150,14,219,220,64,217,97,208,159,232,156,96,172,116,17,25,160,172,40,128,10,153,196,52,99,92,80,174,1,89,161,50,46,140,32,65,13,21,230,100,70,47,181,117,36,176,14,171,46,191,24,126,147,186,182,199,224,202,28,14,47,213,26,43,120,53,53,0,20,137,41,178,148,170,48,82,84,0,102,20,52,103,20,100,196,149,214,82,10,101,200,172,37,73,51,141,38,10,169,17,50,165,194,36,9,149,156,73,42,211,48,78,50,196,52,100,138,4,37,26,183,188,221,180,216,117,182,169,243,1,127,237,207,239,54,94,229,220,123,209,148,125,85,147,160,66,7,103,224,214,147,144,16,69,172,128,42,33,99,207,142,41,5,46,53,229,80,164,81,154,33,75,88,74,2,5,27,55,209,146,19,77,2,13,14,94,67,217,227,129,121,176,94,99,196,67,150,197,137,199,50,238,237,112,175,54,75,188,59,163,19,35,145,39,82,22,250,152,215,243,222,250,189,237,78,251,10,91,171,238,99,71,159,95,211,230,131,106,106,215,54,229,68,125,122,120,126,142,183,110,14,247,254,234,205,108,200,249,250,4,34,219,160,239,112,81,90,172,221,178,86,141,182,245,245,204,185,221,122,72,181,129,214,118,199,20,150,55,61,148,36,104,237,245,250,143,105,45,250,206,53,213,127,100,53,240,54,61,135,31,178,131,220,105,6,181,237,54,37,220,29,206,57,121,124,211,55,238,233,248,105,252,50,126,219,191,223,127,24,119,251,143,143,198,31,251,119,227,247,241,243,184,27,191,142,187,249,9,121,64,149,147,75,2,198,207,25,72,164,33,50,70,69,148,32,133,44,13,105,164,140,225,92,135,161,201,196,37,241,242,254,101,211,139,147,238,197,219,250,248,107,102,159,171,39,190,250,160,112,118,68,230,195,223,232,220,174,38,165,171,173,95,63,1,158,168,110,199,252,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("da79942f-8a30-4c0f-855d-60c2d9a24472"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("314efddf-5361-477a-9ff8-a9cb5fab8b62"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("06b753c1-0d8b-436b-8acc-ddf113106da6"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ad17e1dd-e357-4be2-be8e-37597e384cc1"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9cb37f59-15e3-4146-8d7f-c8726fcb37d4"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6f41753d-91d4-4093-8fba-b44d89023e4c"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("dfa2d329-fcfc-4412-bf5d-d4a9bda93dae"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("820e9918-37b0-4611-aaf2-8d870ec7da7d"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("cb9c1fe1-8c58-4f12-89f1-7aae2156df27"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("813a52d4-0e07-46b4-a63f-229d35aa56c6"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a3dabfcb-04f6-4cea-92b9-d9ea7aee59b1"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fcd7d381-1523-402c-b1b8-ed682284f793"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e2a2ccd2-d26f-4f42-ae98-edf3516e1ea8"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b5926df2-7c95-4492-a867-2d430924a35b"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("701045a2-ff5b-4e90-ae4f-035211803404"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5402bebd-14b9-42b0-8196-579eb5bbe71e"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f1e7ad19-7dde-4e11-8f26-04409580f3d6"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a9301231-cf7b-4b68-bc33-88ca59cd75dc"),
				ContainerUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6fbea50a-fcc9-45a8-9318-18aaea6960f4"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,221,106,212,64,20,126,149,101,46,188,202,44,147,100,50,153,137,151,101,149,222,212,130,85,132,110,41,147,204,153,54,144,159,109,126,176,37,44,84,241,33,4,193,103,40,210,234,34,180,125,133,236,27,121,178,233,42,244,66,122,169,16,200,249,249,206,223,119,78,210,29,167,245,139,52,107,160,138,172,206,106,112,218,93,19,17,237,169,48,240,60,77,165,207,25,229,168,81,165,165,160,82,37,190,241,56,75,192,132,196,41,116,14,17,25,163,103,38,109,136,147,54,144,215,209,97,247,39,105,83,181,224,28,219,141,242,58,57,133,92,191,25,10,184,86,8,55,240,128,114,151,73,202,149,145,84,169,192,167,66,49,30,88,38,140,149,146,140,189,152,216,21,161,98,134,38,161,226,148,107,17,82,237,107,69,101,44,132,180,154,49,207,34,52,3,219,204,206,23,21,212,117,90,22,81,7,191,229,131,139,5,118,57,214,222,41,179,54,47,136,147,67,163,247,117,115,26,17,47,225,49,196,60,160,70,5,138,114,159,49,26,199,49,80,11,60,81,86,199,194,186,114,170,129,1,15,18,77,19,174,2,202,45,12,45,40,67,125,29,135,94,40,193,21,46,210,145,232,69,51,212,38,253,151,126,213,95,79,119,13,113,140,110,244,91,157,181,176,233,162,75,113,30,207,103,174,12,134,41,92,63,193,138,30,163,82,200,144,90,35,172,2,95,40,21,155,45,183,47,219,20,229,180,222,107,115,168,210,228,97,69,128,92,151,85,212,37,101,209,84,101,54,164,222,219,192,15,224,188,25,23,241,224,122,55,14,223,160,125,8,34,75,167,173,97,39,75,161,104,102,69,82,154,180,56,25,115,46,151,24,146,47,116,149,214,91,198,102,103,173,206,136,83,165,39,167,127,101,118,167,173,155,50,255,143,70,117,112,76,204,129,7,185,105,119,184,87,147,214,139,76,95,108,244,136,60,59,107,203,230,249,184,197,73,255,109,178,254,176,254,216,95,245,215,168,175,38,243,249,131,251,107,255,125,0,160,227,22,223,55,147,254,126,125,217,223,109,12,232,216,194,166,253,103,52,221,244,183,152,98,181,254,132,200,159,253,21,202,119,235,203,73,255,3,177,247,104,254,208,175,70,52,121,212,91,68,230,68,251,126,200,45,23,52,16,200,31,15,153,160,42,208,64,93,151,243,68,226,177,90,46,167,38,86,16,203,132,83,205,125,23,63,18,237,82,5,192,105,32,153,21,214,130,43,149,152,19,36,229,159,30,245,112,183,126,245,190,216,254,40,198,117,29,77,209,250,200,48,203,32,199,189,70,221,83,184,89,98,192,254,182,84,212,61,133,169,229,209,192,213,209,18,159,95,58,91,155,6,32,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("054c4df5-87b5-404f-85c8-f5bb3e7c2694"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("85e3b80e-36f9-4932-88fd-521181901c0a"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("335d8956-0dcb-469d-90e9-ceef1f2c5ecf"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d9f755be-cee7-464d-9e1b-b41958012cd7"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ea0c6605-f519-48fc-a673-083c99411a6a"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("04c4106d-1c1b-4e36-adfa-2bde0c00cacb"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,177,50,180,50,212,241,76,177,50,176,50,0,0,230,77,107,227,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("1f66152e-4108-49d8-9953-69045f06df88"),
				UId = new Guid("ee89e1ce-8692-4233-94c8-45e2768973be"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a73fd6bc-7349-44c8-9897-4cbf76d42e92"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("83effc4d-ad92-4d9f-8f5d-a8a8a9476b51"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("5877a9b3-2232-413f-bca4-841e0c74fcaf"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e49f79ee-5843-4cf5-8054-c5513d2f9295"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2bb22b1b-8777-4e67-bd6f-76818c3e0d4b"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("10b071ad-0944-459a-90cb-7bd9819ae222"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("1f66152e-4108-49d8-9953-69045f06df88"),
				UId = new Guid("35106250-8b54-4cad-8a40-45adb5f3cd75"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c1ba2a29-f542-4078-94a5-6af41945ce12"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9077d7fd-aab0-4d45-9d7d-e410dd871d90"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ae2d8985-2096-4b5d-b5b1-453648bd2c43"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("0c758ce1-ff47-4412-8e5c-64348552654a"),
				ContainerUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("07e87dc6-266d-4544-87cb-bfd58618dbfc"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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
				Value = @"a5657e6b-342d-4104-8ab8-aab37ef29860",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e34ab8a-aae1-49fa-a036-0f0b0ae39983"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,205,106,219,64,16,126,21,179,135,158,180,70,107,237,174,118,213,99,112,75,46,105,160,105,41,196,33,172,86,179,137,64,63,142,126,104,130,49,164,165,15,81,40,244,25,66,73,90,83,72,242,10,242,27,117,100,197,45,228,80,114,108,65,160,249,253,102,230,155,145,22,199,105,253,34,205,26,168,34,103,178,26,188,118,55,137,8,8,231,164,10,36,213,33,4,148,51,127,66,181,9,19,106,28,23,130,137,137,21,16,18,175,48,57,68,100,200,158,38,105,67,188,180,129,188,142,14,23,127,64,155,170,5,239,216,109,148,215,246,20,114,243,166,47,192,156,148,136,3,61,182,162,92,39,138,106,45,2,42,181,207,133,243,101,226,148,34,67,47,66,5,126,16,130,162,19,161,19,202,173,85,52,14,99,73,25,234,192,98,102,185,150,196,203,192,53,211,243,121,5,117,157,150,69,180,128,223,242,193,197,28,187,28,106,239,148,89,155,23,196,203,161,49,251,166,57,141,200,196,242,24,98,46,104,162,133,166,60,240,125,26,199,49,80,7,220,106,103,98,233,152,26,27,240,129,11,107,40,214,18,148,59,8,169,9,176,153,192,196,225,36,84,192,36,67,58,172,153,55,125,109,210,125,233,86,221,245,120,55,33,94,98,26,243,214,100,45,108,186,88,164,56,207,36,240,153,18,18,33,88,96,177,226,196,167,74,170,144,186,68,58,13,129,212,58,78,182,220,190,108,83,148,211,122,175,205,161,74,237,195,138,0,185,46,171,104,97,203,162,169,202,172,135,222,219,132,31,192,121,51,44,226,193,245,110,24,190,65,123,159,68,150,94,91,195,78,150,66,209,76,11,91,38,105,113,50,96,46,151,152,146,207,77,149,214,91,198,166,103,173,201,136,87,165,39,167,127,101,118,167,173,155,50,255,143,70,245,112,76,196,192,131,220,180,219,223,107,146,214,243,204,92,108,244,136,60,59,107,203,230,249,176,197,81,247,109,180,254,176,254,216,93,117,215,168,175,70,179,217,131,251,107,247,189,15,64,199,45,190,111,70,221,253,250,178,187,219,24,208,177,13,27,119,159,209,116,211,221,34,196,106,253,9,35,127,118,87,40,223,173,47,71,221,15,140,189,71,243,135,110,53,68,147,71,189,69,100,70,76,16,132,220,113,73,133,68,254,120,232,227,87,41,12,80,198,56,183,10,143,213,113,53,78,98,13,177,178,156,26,30,48,202,141,97,84,3,112,42,148,239,164,115,192,148,150,51,130,164,252,211,163,30,238,214,175,222,23,219,31,197,176,174,163,49,90,31,25,166,25,228,184,215,104,241,20,110,150,152,176,191,45,21,45,158,194,212,242,168,231,234,104,137,207,47,242,146,89,235,32,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b4c062c1-d149-4854-b95d-7d3101c49ba8"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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
				UId = new Guid("9b1e2c37-1ca0-4018-820c-534743d29771"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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
				Value = @"1f66152e-4108-49d8-9953-69045f06df88",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3f57e619-c84a-40cd-a0f1-b5c0fad5c3c5"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,205,110,211,64,16,126,149,202,237,49,19,173,119,215,94,111,142,208,34,69,106,33,162,208,75,146,195,254,204,182,145,156,164,178,29,254,162,72,180,189,114,228,206,43,20,132,160,32,209,190,130,243,70,108,156,148,164,85,85,68,85,129,176,37,91,59,158,239,155,217,153,253,198,227,96,163,120,125,136,65,35,120,208,218,217,29,186,162,254,112,152,97,189,149,13,13,230,121,125,123,104,84,218,123,163,116,138,45,149,169,62,22,152,237,169,116,132,249,118,47,47,106,107,171,160,160,22,108,188,168,190,5,141,246,56,104,22,216,127,222,180,158,153,114,21,197,194,90,48,206,40,224,214,34,72,212,8,206,42,225,56,77,132,100,220,131,205,48,29,245,7,59,88,168,150,42,14,130,198,56,168,216,60,1,11,157,78,24,55,64,108,28,3,167,130,130,34,132,130,164,78,32,74,105,141,225,193,164,22,228,230,0,251,170,10,186,4,251,216,145,192,88,3,227,212,2,15,9,135,68,233,4,148,210,76,160,163,50,137,201,12,188,240,95,2,5,147,196,49,35,129,160,147,192,157,21,62,42,50,32,26,165,149,72,99,71,194,186,66,130,60,242,219,50,92,70,222,9,189,19,147,22,152,210,130,138,4,195,56,20,51,118,219,203,15,83,245,122,239,122,144,242,195,244,109,121,94,126,158,158,148,223,167,199,117,159,186,119,62,188,82,234,85,247,113,103,222,175,78,208,232,220,220,177,197,123,183,42,197,213,158,93,109,87,39,168,117,130,221,225,40,51,51,182,120,182,184,44,95,197,78,22,23,220,240,184,188,230,28,21,108,71,13,212,62,102,143,125,188,10,94,125,218,84,133,170,66,63,243,57,255,49,241,83,116,152,225,192,224,29,19,171,34,47,147,185,60,89,149,229,222,154,187,200,52,175,10,57,59,243,139,10,12,70,105,58,171,192,74,223,87,82,25,218,158,235,161,109,14,238,184,181,77,116,21,229,163,97,182,245,202,43,177,55,216,95,52,126,37,244,210,103,211,244,23,246,73,48,153,212,86,197,25,242,132,36,82,88,112,58,12,129,27,201,65,197,200,33,10,145,105,73,184,148,68,220,42,78,37,35,197,145,39,32,18,233,9,152,39,208,168,13,72,175,122,106,169,73,152,213,247,47,206,246,122,187,153,63,121,57,192,108,94,193,134,83,105,142,221,186,183,94,51,108,165,216,199,65,209,24,115,30,185,56,65,10,218,18,6,92,240,216,239,84,8,96,84,104,141,66,80,23,155,137,7,252,18,77,99,108,99,195,148,77,36,248,227,34,102,147,203,67,40,149,224,34,138,206,167,104,57,211,147,238,122,247,54,133,183,215,203,247,94,225,31,203,211,242,83,121,54,61,158,190,91,43,47,230,162,247,166,47,211,19,47,250,181,233,145,95,127,173,44,63,252,125,94,126,91,243,203,211,242,194,35,142,202,179,121,132,127,48,22,216,223,27,11,154,202,136,136,208,129,64,229,21,137,49,133,196,134,10,100,40,181,99,130,81,231,232,109,99,65,33,143,253,111,66,128,33,212,0,87,232,79,145,101,33,40,73,153,177,86,74,110,220,111,198,194,66,56,255,151,154,187,147,159,4,168,197,49,196,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("916d8dad-7673-427b-a065-b9d623107663"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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
				UId = new Guid("ee12b588-6303-487f-bd23-3a6753741f2d"),
				ContainerUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
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

		protected virtual void InitializeReadDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("06208806-e8cf-4d1b-b140-1bb619b9ed9d"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,100,21,219,146,44,201,61,46,91,8,148,52,208,15,10,97,9,35,105,148,152,250,43,182,76,27,140,255,123,181,246,58,13,57,148,210,91,65,7,141,164,247,230,205,155,209,124,87,141,239,171,58,224,80,122,168,71,76,166,43,87,18,7,90,235,2,29,53,153,204,41,183,80,80,37,192,82,180,142,155,34,119,232,50,70,146,22,26,44,201,134,62,186,42,144,164,10,216,140,229,237,252,155,52,12,19,38,119,126,13,62,217,7,108,224,203,57,1,32,47,188,81,146,218,52,183,148,3,42,10,142,101,20,116,206,172,115,90,115,235,201,166,69,184,130,9,46,83,42,209,196,167,185,241,20,148,20,20,60,58,157,162,50,210,228,36,169,209,135,227,207,126,192,113,172,186,182,156,241,121,255,249,169,143,42,183,220,135,174,158,154,150,36,13,6,184,129,240,80,146,130,67,42,140,7,202,68,234,40,119,145,221,120,167,168,55,66,106,144,220,51,141,36,177,208,135,51,45,57,116,109,0,27,43,29,208,227,128,173,197,23,69,101,133,65,86,136,140,42,143,209,181,76,104,170,156,75,163,220,148,57,94,40,230,92,116,205,65,128,175,80,79,184,10,155,171,8,52,185,22,169,204,124,44,17,52,229,88,228,17,152,1,213,153,54,158,73,150,123,159,239,118,127,232,186,239,83,31,173,30,175,167,6,135,202,94,250,134,177,1,221,80,206,54,42,28,186,250,76,126,253,2,176,245,231,114,249,109,243,164,94,111,206,64,178,36,211,136,135,186,194,54,28,91,219,185,170,189,95,91,183,44,17,211,244,48,84,227,238,228,241,113,130,58,26,80,221,63,252,209,241,195,52,134,174,249,223,234,77,98,173,145,38,78,235,170,249,60,204,174,26,251,26,158,214,184,36,111,30,167,46,188,187,204,193,22,144,87,160,253,145,41,4,227,34,23,148,41,174,40,231,121,74,149,102,41,69,105,172,213,10,50,41,138,11,195,146,252,123,154,219,171,241,227,143,118,255,94,155,61,167,183,241,244,213,193,205,142,46,231,191,81,182,156,118,109,167,37,174,95,30,241,119,1,41,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7f8a702-1219-42b2-bf9d-1f55c8264391"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3792585d-cd7c-494c-b316-b160fa45ae28"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("faa46a7f-a96c-46cf-9a47-add578864b68"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("68383c19-2658-416e-958d-1489861993aa"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("80cefc71-5fc6-4296-b100-29c98156e0b1"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("35445f62-ccc0-4a74-94f0-9ec9ea65b343"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("6cba6276-dc6c-4940-803b-a32b756d2ebd"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d7147db-0aaa-41c5-8897-3ad2d88fd821"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("00aae8e4-4e62-4538-9bf7-d0b6178f7c93"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e696780e-c260-4f1d-ac47-1890fdb6b840"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("da459109-1578-45d4-9510-627e44859262"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("05f93e88-b9f0-488c-b37f-c86bd5b8d920"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("1ddf79d1-87fa-413b-b322-71e34392312d"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2f6fab91-5a02-44f1-9ea1-7012b00b2849"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d5f43f08-08d2-4c1d-aae8-d8cddf1e99e0"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b65917ae-2434-428b-b40e-92d5141b5034"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f4ae8dd2-b583-47bc-a13b-88ab93c3a5da"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eb514f36-66db-4ffd-8390-60718a1946c7"),
				ContainerUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaLaneSet schemaOpportunityMangement = CreateOpportunityMangementLaneSet();
			LaneSets.Add(schemaOpportunityMangement);
			ProcessSchemaLane schemaOpportunityMangementProcess = CreateOpportunityMangementProcessLane();
			schemaOpportunityMangement.Lanes.Add(schemaOpportunityMangementProcess);
			ProcessSchemaSubProcess prospecting = CreateProspectingSubProcess();
			FlowElements.Add(prospecting);
			ProcessSchemaSubProcess needsanalysis = CreateNeedsAnalysisSubProcess();
			FlowElements.Add(needsanalysis);
			ProcessSchemaSubProcess oppmanagementvaluepproposition = CreateOppManagementValuePpropositionSubProcess();
			FlowElements.Add(oppmanagementvaluepproposition);
			ProcessSchemaSubProcess iddecisionmakers = CreateIdDecisionMakersSubProcess();
			FlowElements.Add(iddecisionmakers);
			ProcessSchemaSubProcess oppmanagementperceptionanalysis = CreateOppManagementPerceptionAnalysisSubProcess();
			FlowElements.Add(oppmanagementperceptionanalysis);
			ProcessSchemaSubProcess oppmanagementproposal = CreateOppManagementProposalSubProcess();
			FlowElements.Add(oppmanagementproposal);
			ProcessSchemaSubProcess oppmanagementnegotiations = CreateOppManagementNegotiationsSubProcess();
			FlowElements.Add(oppmanagementnegotiations);
			ProcessSchemaSubProcess oppmanagementcontractation = CreateOppManagementContractationSubProcess();
			FlowElements.Add(oppmanagementcontractation);
			ProcessSchemaSubProcess oppmanagementendstage = CreateOppManagementEndStageSubProcess();
			FlowElements.Add(oppmanagementendstage);
			ProcessSchemaUserTask readoppdata = CreateReadOppDataUserTask();
			FlowElements.Add(readoppdata);
			ProcessSchemaExclusiveGateway opportunitystage = CreateOpportunityStageExclusiveGateway();
			FlowElements.Add(opportunitystage);
			ProcessSchemaTerminateEvent terminate3 = CreateTerminate3TerminateEvent();
			FlowElements.Add(terminate3);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaUserTask findpresentation = CreateFindPresentationUserTask();
			FlowElements.Add(findpresentation);
			ProcessSchemaFormulaTask savepresentationparameter2 = CreateSavePresentationParameter2FormulaTask();
			FlowElements.Add(savepresentationparameter2);
			ProcessSchemaUserTask linkopptoprocess = CreateLinkOppToProcessUserTask();
			FlowElements.Add(linkopptoprocess);
			ProcessSchemaUserTask readoppmaincontact = CreateReadOppMainContactUserTask();
			FlowElements.Add(readoppmaincontact);
			ProcessSchemaFormulaTask savemaincontactparameter = CreateSaveMainContactParameterFormulaTask();
			FlowElements.Add(savemaincontactparameter);
			ProcessSchemaStartSignalEvent startsignalleadstagechange = CreateStartSignalLeadStageChangeStartSignalEvent();
			FlowElements.Add(startsignalleadstagechange);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			ProcessSchemaStartEvent startoppbusinessprocess = CreateStartOppBusinessProcessStartEvent();
			FlowElements.Add(startoppbusinessprocess);
			ProcessSchemaUserTask openeditpageusertask1 = CreateOpenEditPageUserTask1UserTask();
			FlowElements.Add(openeditpageusertask1);
			ProcessSchemaExclusiveGateway exclusivegateway4 = CreateExclusiveGateway4ExclusiveGateway();
			FlowElements.Add(exclusivegateway4);
			ProcessSchemaTerminateEvent terminate4 = CreateTerminate4TerminateEvent();
			FlowElements.Add(terminate4);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			ProcessSchemaFormulaTask storeisstagechangedbyuser = CreateStoreIsStageChangedByUserFormulaTask();
			FlowElements.Add(storeisstagechangedbyuser);
			ProcessSchemaFormulaTask resetisstagechangedbyuser = CreateResetIsStageChangedByUserFormulaTask();
			FlowElements.Add(resetisstagechangedbyuser);
			ProcessSchemaUserTask readdatalead = CreateReadDataLeadUserTask();
			FlowElements.Add(readdatalead);
			ProcessSchemaUserTask changedatalead = CreateChangeDataLeadUserTask();
			FlowElements.Add(changedatalead);
			ProcessSchemaExclusiveGateway exclusivegatewaysetdatetimepresentation = CreateExclusiveGatewaySetDateTimePresentationExclusiveGateway();
			FlowElements.Add(exclusivegatewaysetdatetimepresentation);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			ProcessSchemaUserTask adddatacontacttoopportunity = CreateAddDataContactToOpportunityUserTask();
			FlowElements.Add(adddatacontacttoopportunity);
			ProcessSchemaExclusiveGateway exclusivegatewayleadqualifiedascontact = CreateExclusiveGatewayLeadQualifiedAsContactExclusiveGateway();
			FlowElements.Add(exclusivegatewayleadqualifiedascontact);
			ProcessSchemaUserTask adddataopportunity = CreateAddDataOpportunityUserTask();
			FlowElements.Add(adddataopportunity);
			ProcessSchemaUserTask readdatacountopportunitybyaccount = CreateReadDataCountOpportunityByAccountUserTask();
			FlowElements.Add(readdatacountopportunitybyaccount);
			ProcessSchemaUserTask readdataaccount = CreateReadDataAccountUserTask();
			FlowElements.Add(readdataaccount);
			ProcessSchemaFormulaTask formulataskaccountbylead = CreateFormulaTaskAccountByLeadFormulaTask();
			FlowElements.Add(formulataskaccountbylead);
			ProcessSchemaUserTask readdatacontact = CreateReadDataContactUserTask();
			FlowElements.Add(readdatacontact);
			ProcessSchemaExclusiveGateway exclusivegatewayqualifiedbyaccount = CreateExclusiveGatewayQualifiedByAccountExclusiveGateway();
			FlowElements.Add(exclusivegatewayqualifiedbyaccount);
			ProcessSchemaFormulaTask savecurroppparameter = CreateSaveCurrOppParameterFormulaTask();
			FlowElements.Add(savecurroppparameter);
			ProcessSchemaUserTask presentationtaskcreation = CreatePresentationTaskCreationUserTask();
			FlowElements.Add(presentationtaskcreation);
			ProcessSchemaFormulaTask savepresentationparameter = CreateSavePresentationParameterFormulaTask();
			FlowElements.Add(savepresentationparameter);
			ProcessSchemaUserTask readoppoortunitydata2 = CreateReadOppoortunityData2UserTask();
			FlowElements.Add(readoppoortunitydata2);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaFormulaTask formulatask3 = CreateFormulaTask3FormulaTask();
			FlowElements.Add(formulatask3);
			ProcessSchemaFormulaTask formulatask4 = CreateFormulaTask4FormulaTask();
			FlowElements.Add(formulatask4);
			ProcessSchemaFormulaTask formulatask5 = CreateFormulaTask5FormulaTask();
			FlowElements.Add(formulatask5);
			ProcessSchemaFormulaTask formulatask6 = CreateFormulaTask6FormulaTask();
			FlowElements.Add(formulatask6);
			ProcessSchemaFormulaTask formulatask7 = CreateFormulaTask7FormulaTask();
			FlowElements.Add(formulatask7);
			ProcessSchemaFormulaTask formulatask8 = CreateFormulaTask8FormulaTask();
			FlowElements.Add(formulatask8);
			ProcessSchemaFormulaTask formulatask9 = CreateFormulaTask9FormulaTask();
			FlowElements.Add(formulatask9);
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateProspectingStageConditionalFlow());
			FlowElements.Add(CreateNeedAnalysisStageConditionalFlow());
			FlowElements.Add(CreateValuePropositionConditionalFlow());
			FlowElements.Add(CreateDecisionMakersConditionalFlow());
			FlowElements.Add(CreatePerceptionAnalysisStageConditionalFlow());
			FlowElements.Add(CreateNegotiationsStageConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateContractationStageConditionalFlow());
			FlowElements.Add(CreateProposalStageConditionalFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow18SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow22SequenceFlow());
			FlowElements.Add(CreateSequenceFlow20SequenceFlow());
			FlowElements.Add(CreateSequenceFlow19SequenceFlow());
			FlowElements.Add(CreateSequenceFlow23SequenceFlow());
			FlowElements.Add(CreateSequenceFlow24SequenceFlow());
			FlowElements.Add(CreateSequenceFlow25SequenceFlow());
			FlowElements.Add(CreateSequenceFlow27SequenceFlow());
			FlowElements.Add(CreateConditionalFlow8ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow30SequenceFlow());
			FlowElements.Add(CreateSequenceFlow31SequenceFlow());
			FlowElements.Add(CreateSequenceFlow32SequenceFlow());
			FlowElements.Add(CreateSequenceFlow33SequenceFlow());
			FlowElements.Add(CreateConditionalFlow10ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow34SequenceFlow());
			FlowElements.Add(CreateSequenceFlow35SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow36SequenceFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow7ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow37SequenceFlow());
			FlowElements.Add(CreateConditionalFlow11ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow38SequenceFlow());
			FlowElements.Add(CreateSequenceFlow39SequenceFlow());
			FlowElements.Add(CreateConditionalFlow12ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow40SequenceFlow());
			FlowElements.Add(CreateSequenceFlow41SequenceFlow());
			FlowElements.Add(CreateSequenceFlow42SequenceFlow());
			FlowElements.Add(CreateSequenceFlow21SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow43SequenceFlow());
			FlowElements.Add(CreateSequenceFlow44SequenceFlow());
			FlowElements.Add(CreateSequenceFlow28SequenceFlow());
			FlowElements.Add(CreateConditionalFlow5ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow46SequenceFlow());
			FlowElements.Add(CreateSequenceFlow47SequenceFlow());
			FlowElements.Add(CreateSequenceFlow50SequenceFlow());
			FlowElements.Add(CreateSequenceFlow49SequenceFlow());
			FlowElements.Add(CreateSequenceFlow29SequenceFlow());
			FlowElements.Add(CreateSequenceFlow45SequenceFlow());
			FlowElements.Add(CreateSequenceFlow26SequenceFlow());
			FlowElements.Add(CreateSequenceFlow48SequenceFlow());
			FlowElements.Add(CreateSequenceFlow51SequenceFlow());
			FlowElements.Add(CreateSequenceFlow52SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("b7a4e901-cd6d-48d8-8ea3-b631737057d2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(772, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateProspectingStageConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ProspectingStage",
				UId = new Guid("6da9cfcb-81e5-48a4-a1c1-42a6279225e6"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.c2067b11-0ee0-df11-971b-001d60e938c6#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(736, 133),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateNeedAnalysisStageConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "NeedAnalysisStage",
				UId = new Guid("9301d50a-6c5b-4489-badd-4a28230234ae"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.2a6de0f7-44d9-4b8a-bce6-acddb7ed8915#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(750, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateValuePropositionConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ValueProposition",
				UId = new Guid("bb42fb47-5fbd-4f77-af1e-ce351db4f8f9"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.325f0619-0ee0-df11-971b-001d60e938c6#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(712, 283),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateDecisionMakersConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "DecisionMakers",
				UId = new Guid("f094c232-c29e-46d1-86fc-2e61dcac8e07"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.f4e4a00b-ec48-46d0-9ea0-c2b502165ee9#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(723, 322),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreatePerceptionAnalysisStageConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "PerceptionAnalysisStage",
				UId = new Guid("90dc5cd4-a514-48c4-9705-1babb54dc9a9"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.241ade6b-4256-4947-ba8a-7d96988a97b6#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(690, 398),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateNegotiationsStageConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "NegotiationsStage",
				UId = new Guid("3b93fd4b-c4ce-43ef-81de-d70f18e28cd9"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.f808c955-c5aa-4aba-95c0-ba7d584d2f32#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(693, 494),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a0baa7ff-239e-42e9-8768-1ee3435f5a90"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(346, 308),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("cc1b7702-073c-45cc-926b-05e107a8fd30"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4ba680da-7591-4eb5-8ede-25d1558e9149"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateContractationStageConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ContractationStage",
				UId = new Guid("97b5d2a4-5ab3-4fb5-9544-7ee6933c7e5a"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.fb563df2-5ae6-df11-971b-001d60e938c6#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(944, 656),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateProposalStageConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ProposalStage",
				UId = new Guid("94b519f4-4f88-4966-9c23-8a451496a11b"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{0c718c20-8264-4ad8-ac5f-2ec36a29a498}].[Parameter:{61d6f451-48d9-4c96-917b-f6c5ce85df83}].[EntityColumn:{797ac352-4979-4d28-906f-82feb6dbc9dc}]#]==[#Lookup.ccf7d813-fc83-47ad-be61-8f3b3b98a54f.423774cb-5ae6-df11-971b-001d60e938c6#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1006, 566),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow16",
				UId = new Guid("de2431a0-d30e-4cfc-b8cf-278b073a39f0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1261, 438),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a754a29c-40c0-420e-941d-f2b4a941c8ab"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("a681a1ef-7292-4df0-8fc4-8af2fec6edb9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1088, 494),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(2248, 716));
			schemaFlow.PolylinePointPositions.Add(new Point(1345, 716));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("8d4357f8-f4f9-48b5-a570-41ea6d475b92"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(919, 276),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("f96d1ad1-4a55-4afb-9ba8-e36591778f46"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(920, 333),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("3d3dd689-8fb9-4955-b1ca-b7d2ce229b92"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(936, 377),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("54731090-57ce-4f13-a4f0-8398e8e5479f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("0eb60d05-9aec-4c62-be1d-1178bca849d8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(936, 440),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("2b63dc8f-d13f-49c5-835d-3483f4523a44"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(936, 520),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("0e1f6ffa-18a8-4413-a8ec-e72659aa72f9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(936, 572),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("462272ae-0429-49e5-8618-a2a7fd3481fa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(918, 611),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("b535ac24-faf0-4bd6-ba78-19cfe825e870"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(917, 669),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a754a29c-40c0-420e-941d-f2b4a941c8ab"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("b131dc29-103b-498c-8cad-b0267ae02df9"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{af8eea9e-0e11-426e-a870-2cff33d00f84}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(330, 444),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4ba680da-7591-4eb5-8ede-25d1558e9149"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow14",
				UId = new Guid("be43f005-b89c-4be1-b699-0acc87df40c3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(320, 441),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4ba680da-7591-4eb5-8ede-25d1558e9149"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("656a4a04-8b53-40cb-9fe2-d14c1a49db28"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{da7cbb80-cd50-40b3-883c-6f5384f2478a}].[Parameter:{6f8cde56-f764-4ad1-b528-0d9031cd1e8e}]#].Count == 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(386, 495),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("945c5224-09ec-408a-b369-ae94b490e7b7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(218, 604),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d8643dcc-9a0d-40a5-abbb-c08fc8ced26b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow18SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow18",
				UId = new Guid("af05fdeb-fca0-41d3-9791-46dc1679ea6c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(218, 716),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d8643dcc-9a0d-40a5-abbb-c08fc8ced26b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("d530128e-0ad3-40af-b76a-b9da0f99dec8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(427, 311),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0b3df41d-a31f-4753-9ad5-bb8d4c5137fb"),
				SourceSequenceFlowPointLocalPosition = new Point(-1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1304, 338));
			schemaFlow.PolylinePointPositions.Add(new Point(1304, 390));
			schemaFlow.PolylinePointPositions.Add(new Point(1141, 390));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow22SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow22",
				UId = new Guid("f2e28c79-53c0-420e-bc3b-2fe8df5cb57d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(380, 318),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a914a2b0-15d2-4c81-938d-6f3bcc01c912"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b3df41d-a31f-4753-9ad5-bb8d4c5137fb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1421, 268));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow20SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow20",
				UId = new Guid("3a915671-271f-4aca-8ecb-49e7c53c9b5f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(380, 318),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a914a2b0-15d2-4c81-938d-6f3bcc01c912"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow19SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow19",
				UId = new Guid("44ae693f-6aa2-4a99-bdf0-2cde17ec3507"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(750, 303),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				SourceSequenceFlowPointLocalPosition = new Point(-1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow23SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow23",
				UId = new Guid("a580eaa3-fc67-44f4-97b8-d4612d7fe5bc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1134, 440),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow24SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow24",
				UId = new Guid("de750837-99b2-4b33-b71b-deba1897a823"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(772, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("90ba94c4-778e-4da8-b1fa-20caa11d06b9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow25SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow25",
				UId = new Guid("55a5a7b6-1fe9-43e6-8550-f6da9d2fcf2b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(772, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("90ba94c4-778e-4da8-b1fa-20caa11d06b9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c07da6a9-f9fc-4d1b-a11d-633a4992ae39"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow27SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow27",
				UId = new Guid("788216e9-2036-4a1f-831c-141dbdcba7b5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(386, 151),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ba7fb0fc-f887-4dd2-9494-28335297b5e4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("da838103-79ee-48ff-b9fb-43f5d9fb0543"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow8ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow8",
				UId = new Guid("12da4680-7947-44ac-bce4-174e2ea3d434"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{fe4d88e0-465c-48ba-91bc-e9ded45b3c50}].[Parameter:{d4413fda-e205-481c-828d-b4e67061712f}].[EntityColumn:{32949ae4-ff13-48f5-9f5d-45a74558ea55}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(456, 66),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ba7fb0fc-f887-4dd2-9494-28335297b5e4"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ab3f8e00-ffa9-4079-8f2d-c9aa8b4b4826"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow30SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow30",
				UId = new Guid("e15bb4f0-0213-4d52-8387-1a542b5d4eb4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(759, 158),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ab3f8e00-ffa9-4079-8f2d-c9aa8b4b4826"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow31SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow31",
				UId = new Guid("060a734c-031d-4892-97f8-7d1c8e825e30"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(896, 128),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("cecd8639-1f00-4d59-b112-9fbe4de5517a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow32SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow32",
				UId = new Guid("af864a06-1ac3-4766-bdb4-9064d35c26ca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1041, 126),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b120e00e-d3f2-4b09-8118-ef17c00af6bb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow33SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow33",
				UId = new Guid("3df63af1-a134-40e5-b6bf-b5a735392364"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1133, 190),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c017a416-4566-4caf-89f0-cd11dc760d58"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow10ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow10",
				UId = new Guid("fe99e954-54c6-4dbc-ae4e-724f11084d1e"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{fe4d88e0-465c-48ba-91bc-e9ded45b3c50}].[Parameter:{d4413fda-e205-481c-828d-b4e67061712f}].[EntityColumn:{ad490d58-054a-4d85-9246-dd8466eb3983}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1224, 186),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c017a416-4566-4caf-89f0-cd11dc760d58"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow34SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow34",
				UId = new Guid("9aa77dec-7ab7-4403-a78e-711f966d98a3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(915, 264),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c017a416-4566-4caf-89f0-cd11dc760d58"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1547, 120));
			schemaFlow.PolylinePointPositions.Add(new Point(1680, 120));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow35SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow35",
				UId = new Guid("598e3e34-6da9-4dea-8c0d-5f7bcfca6637"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(946, 218),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				TargetSequenceFlowPointLocalPosition = new Point(1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1729, 47));
			schemaFlow.PolylinePointPositions.Add(new Point(1729, 177));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow1",
				UId = new Guid("8add388c-07d2-4f83-bfa0-ac871ab00d61"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(218, 110),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("375b9e3c-98fc-4100-83c4-c571cfe22b08"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow36SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow36",
				UId = new Guid("5ec251e3-686c-42c6-8f99-34b869d3217c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(946, 283),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f7a393e4-d550-4f6e-aba4-c4a007307258"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0b3df41d-a31f-4753-9ad5-bb8d4c5137fb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("6f012dc4-0679-4da3-84ce-757680848a3c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{fe4d88e0-465c-48ba-91bc-e9ded45b3c50}].[Parameter:{d4413fda-e205-481c-828d-b4e67061712f}].[EntityColumn:{efc32501-4c3a-4500-8fa4-1d70c6bf26f9}]#] != null && !DateTime.MinValue.Equals([#[IsOwnerSchema:false].[IsSchema:false].[Element:{fe4d88e0-465c-48ba-91bc-e9ded45b3c50}].[Parameter:{d4413fda-e205-481c-828d-b4e67061712f}].[EntityColumn:{efc32501-4c3a-4500-8fa4-1d70c6bf26f9}]#])",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(862, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f7a393e4-d550-4f6e-aba4-c4a007307258"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow7ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow7",
				UId = new Guid("e1fae17b-971d-469e-82c9-0d8f1161f09b"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{fe4d88e0-465c-48ba-91bc-e9ded45b3c50}].[Parameter:{d4413fda-e205-481c-828d-b4e67061712f}].[EntityColumn:{7cfff438-9ee8-4272-816d-5deb7d0c9d36}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(342, 197),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ba7fb0fc-f887-4dd2-9494-28335297b5e4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow37SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow37",
				UId = new Guid("866016a6-730c-4f6d-8688-5ca07b0bba21"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(750, 303),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f7a393e4-d550-4f6e-aba4-c4a007307258"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow11ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow11",
				UId = new Guid("aff117cc-494a-447b-824c-ea45bf0c048a"),
				ConditionExpression = @"[#SysSettings.StartOppBusinessProcess#] == true",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(304, 236),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ef1d55e6-1755-412a-9d7c-f01d78a5edf9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow38SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow38",
				UId = new Guid("d775251b-c99c-4962-8c31-63e5179999be"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(298, 119),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ef1d55e6-1755-412a-9d7c-f01d78a5edf9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("375b9e3c-98fc-4100-83c4-c571cfe22b08"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(107, 176));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow39SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow39",
				UId = new Guid("2b69f135-398e-443a-a1a4-3237cbf24d5d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(768, 644),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("69c50fcc-abf2-43ac-a9d1-e9e6ed6a5397"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow12ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow12",
				UId = new Guid("b3fa892c-1d0a-4e76-a01e-553b47b9714a"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{b10332bd-27a4-46bc-a990-f59da9cdbb25}].[Parameter:{c5f0d6a4-d18b-446e-8335-18fb080f660a}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(834, 698),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("69c50fcc-abf2-43ac-a9d1-e9e6ed6a5397"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("129d65ec-f59b-44af-b1d6-cda0a6b4ff21"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow40SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow40",
				UId = new Guid("7eab7b7b-6047-42c1-a1fb-6279a4cd3a64"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1149, 544),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ad47ec52-76d5-44c0-b66d-9440119348ca"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow41SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow41",
				UId = new Guid("1c43080a-684a-4791-9f3b-a6ab1a023caa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(990, 644),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("69c50fcc-abf2-43ac-a9d1-e9e6ed6a5397"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ad47ec52-76d5-44c0-b66d-9440119348ca"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow42SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow42",
				UId = new Guid("a0e10bcc-d9cf-4167-8c98-8f859c88ba6a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(936, 377),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("54731090-57ce-4f13-a4f0-8398e8e5479f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow21SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow21",
				UId = new Guid("de731752-04c3-40a1-9853-07e0a87ba911"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(2100, 440),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("2f225a00-7172-4df7-b6bb-f13891d00109"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(772, 272),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c07da6a9-f9fc-4d1b-a11d-633a4992ae39"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("483624cb-e100-4417-b0d7-2d89990301bc"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{9d00770f-dda3-42a7-937d-59d67284f4c1}].[Parameter:{a73fd6bc-7349-44c8-9897-4cbf76d42e92}]#] == 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cbdfa4ab-c534-4027-a134-96b45d5b7770"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1183, 361),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow43SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow43",
				UId = new Guid("87a64e65-a497-4ebc-a9cf-14260e618e18"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cbdfa4ab-c534-4027-a134-96b45d5b7770"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1286, 280),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow44SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow44",
				UId = new Guid("a5997d52-51b6-48a5-a656-bd7d3854ca36"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cbdfa4ab-c534-4027-a134-96b45d5b7770"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1234, 350),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				TargetSequenceFlowPointLocalPosition = new Point(1, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1305, 500));
			schemaFlow.PolylinePointPositions.Add(new Point(1176, 500));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow28SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow28",
				UId = new Guid("72ab06d6-4130-493c-b2af-5c38d597d2ff"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(447, 123),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da838103-79ee-48ff-b9fb-43f5d9fb0543"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("375b9e3c-98fc-4100-83c4-c571cfe22b08"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow5ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow5",
				UId = new Guid("e9f42fb2-6bda-464a-8a5a-cfb4b9ca50b1"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{fe4d88e0-465c-48ba-91bc-e9ded45b3c50}].[Parameter:{d4413fda-e205-481c-828d-b4e67061712f}].[EntityColumn:{ad490d58-054a-4d85-9246-dd8466eb3983}]#]  != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(576, 108),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da838103-79ee-48ff-b9fb-43f5d9fb0543"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e71860b5-b65b-493b-8d7c-c65ed80dc169"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow46SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow46",
				UId = new Guid("59c61212-02fe-41a0-ad79-c40ccc35532c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(1041, 126),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b120e00e-d3f2-4b09-8118-ef17c00af6bb"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f284494f-5edb-489b-92c3-ddb20eaa0ab0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow47SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow47",
				UId = new Guid("17b0bf13-f217-45b1-afcc-b2adc6141887"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(991, 186),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("083b1a16-96f4-434c-bd21-1e475d6a546b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow50SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow50",
				UId = new Guid("a302bf3e-58ff-4854-bc1b-7eaa9052bfe8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(896, 128),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("cecd8639-1f00-4d59-b112-9fbe4de5517a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow49SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow49",
				UId = new Guid("17087fe4-cdf9-44bf-87ae-069f098e6b9f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(906, 184),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d527d260-953d-4177-b84b-fd337a8b9408"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow29SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow29",
				UId = new Guid("7f2af97b-9700-4293-ab0f-ab54f86bdd6c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(751, 186),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d527d260-953d-4177-b84b-fd337a8b9408"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow45SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow45",
				UId = new Guid("153b7c7c-46d1-44e7-b271-f8fcdeacae3b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(644, 184),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e71860b5-b65b-493b-8d7c-c65ed80dc169"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow26SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow26",
				UId = new Guid("c6c60e5b-a2e1-4af3-81b1-7c228375d5c9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f1915c3-7f07-42fa-9d85-bbbe0c864173"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ef1d55e6-1755-412a-9d7c-f01d78a5edf9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(66, 337));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow48SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow48",
				UId = new Guid("14dc3926-be2e-4381-aa61-5cf5889f09b2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48537fce-e726-43c7-8dd9-691e0e0c228e"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("083b1a16-96f4-434c-bd21-1e475d6a546b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7727ad4d-089b-417c-acfd-d66ee83afc06"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow51SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow51",
				UId = new Guid("d9b40787-f4db-4de9-a07f-63291d659ebb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48537fce-e726-43c7-8dd9-691e0e0c228e"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7727ad4d-089b-417c-acfd-d66ee83afc06"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1220, 176));
			schemaFlow.PolylinePointPositions.Add(new Point(1220, 47));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow52SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow52",
				UId = new Guid("29aaa936-4362-4814-a131-6dd7a498a947"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48537fce-e726-43c7-8dd9-691e0e0c228e"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f284494f-5edb-489b-92c3-ddb20eaa0ab0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1221, 337));
			schemaFlow.PolylinePointPositions.Add(new Point(1221, 47));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateOpportunityMangementLaneSet() {
			ProcessSchemaLaneSet schemaOpportunityMangement = new ProcessSchemaLaneSet(this) {
				UId = new Guid("8ea1b510-d580-4bce-a7d9-506d9c032358"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OpportunityMangement",
				Position = new Point(5, 5),
				Size = new Size(2403, 961),
				UseBackgroundMode = false
			};
			return schemaOpportunityMangement;
		}

		protected virtual ProcessSchemaLane CreateOpportunityMangementProcessLane() {
			ProcessSchemaLane schemaOpportunityMangementProcess = new ProcessSchemaLane(this) {
				UId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("8ea1b510-d580-4bce-a7d9-506d9c032358"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OpportunityMangementProcess",
				Position = new Point(29, 0),
				Size = new Size(2374, 961),
				UseBackgroundMode = false
			};
			return schemaOpportunityMangementProcess;
		}

		protected virtual ProcessSchemaUserTask CreateReadOppDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadOppData",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1310, 569),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadOppDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateOpportunityStageExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OpportunityStage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1772, 569),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaSubProcess CreateProspectingSubProcess() {
			ProcessSchemaSubProcess schemaProspecting = new ProcessSchemaSubProcess(this) {
				UId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Prospecting",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1898, 23),
				SchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeProspectingParameters(schemaProspecting);
			return schemaProspecting;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate3TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("a754a29c-40c0-420e-941d-f2b4a941c8ab"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Terminate3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(2332, 583),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaSubProcess CreateNeedsAnalysisSubProcess() {
			ProcessSchemaSubProcess schemaNeedsAnalysis = new ProcessSchemaSubProcess(this) {
				UId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"NeedsAnalysis",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1898, 128),
				SchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeNeedsAnalysisParameters(schemaNeedsAnalysis);
			return schemaNeedsAnalysis;
		}

		protected virtual ProcessSchemaSubProcess CreateOppManagementValuePpropositionSubProcess() {
			ProcessSchemaSubProcess schemaOppManagementValuePproposition = new ProcessSchemaSubProcess(this) {
				UId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OppManagementValuePproposition",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1898, 219),
				SchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeOppManagementValuePpropositionParameters(schemaOppManagementValuePproposition);
			return schemaOppManagementValuePproposition;
		}

		protected virtual ProcessSchemaSubProcess CreateIdDecisionMakersSubProcess() {
			ProcessSchemaSubProcess schemaIdDecisionMakers = new ProcessSchemaSubProcess(this) {
				UId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"IdDecisionMakers",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1898, 310),
				SchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeIdDecisionMakersParameters(schemaIdDecisionMakers);
			return schemaIdDecisionMakers;
		}

		protected virtual ProcessSchemaSubProcess CreateOppManagementPerceptionAnalysisSubProcess() {
			ProcessSchemaSubProcess schemaOppManagementPerceptionAnalysis = new ProcessSchemaSubProcess(this) {
				UId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OppManagementPerceptionAnalysis",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1905, 639),
				SchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeOppManagementPerceptionAnalysisParameters(schemaOppManagementPerceptionAnalysis);
			return schemaOppManagementPerceptionAnalysis;
		}

		protected virtual ProcessSchemaSubProcess CreateOppManagementProposalSubProcess() {
			ProcessSchemaSubProcess schemaOppManagementProposal = new ProcessSchemaSubProcess(this) {
				UId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OppManagementProposal",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1905, 723),
				SchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeOppManagementProposalParameters(schemaOppManagementProposal);
			return schemaOppManagementProposal;
		}

		protected virtual ProcessSchemaSubProcess CreateOppManagementNegotiationsSubProcess() {
			ProcessSchemaSubProcess schemaOppManagementNegotiations = new ProcessSchemaSubProcess(this) {
				UId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OppManagementNegotiations",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1905, 807),
				SchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeOppManagementNegotiationsParameters(schemaOppManagementNegotiations);
			return schemaOppManagementNegotiations;
		}

		protected virtual ProcessSchemaSubProcess CreateOppManagementContractationSubProcess() {
			ProcessSchemaSubProcess schemaOppManagementContractation = new ProcessSchemaSubProcess(this) {
				UId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OppManagementContractation",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1905, 891),
				SchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeOppManagementContractationParameters(schemaOppManagementContractation);
			return schemaOppManagementContractation;
		}

		protected virtual ProcessSchemaSubProcess CreateOppManagementEndStageSubProcess() {
			ProcessSchemaSubProcess schemaOppManagementEndStage = new ProcessSchemaSubProcess(this) {
				UId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OppManagementEndStage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(2213, 569),
				SchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeOppManagementEndStageParameters(schemaOppManagementEndStage);
			return schemaOppManagementEndStage;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("4ba680da-7591-4eb5-8ede-25d1558e9149"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGateway2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(638, 569),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateFindPresentationUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FindPresentation",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(778, 569),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeFindPresentationParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSavePresentationParameter2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("d8643dcc-9a0d-40a5-abbb-c08fc8ced26b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"SavePresentationParameter2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(939, 653),
				ResultParameterMetaPath = @"0eae6fcc-65b6-433e-b4dc-e42323c488c1",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,10,131,48,16,128,225,135,113,190,146,152,196,156,174,197,161,83,11,29,197,225,46,185,208,130,166,160,150,82,196,119,175,174,221,126,126,248,186,162,187,204,215,79,150,233,30,30,50,82,147,104,152,165,63,237,247,111,180,131,140,146,151,102,141,228,3,51,42,8,209,41,176,138,13,32,154,0,85,114,6,109,42,173,71,218,118,112,163,137,70,89,100,106,86,14,209,160,209,30,8,177,4,123,20,34,106,224,82,51,38,21,200,121,62,72,155,151,231,242,61,191,134,247,152,155,149,68,137,117,129,32,216,218,129,77,178,123,83,71,48,196,190,244,40,186,210,126,235,139,254,7,38,198,222,228,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateLinkOppToProcessUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"LinkOppToProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1107, 569),
				SchemaUId = new Guid("fcace79b-6103-4992-8a1f-8e443114321a"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeLinkOppToProcessParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadOppMainContactUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadOppMainContact",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1422, 569),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadOppMainContactParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSaveMainContactParameterFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("90ba94c4-778e-4da8-b1fa-20caa11d06b9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"SaveMainContactParameter",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1534, 569),
				ResultParameterMetaPath = @"b8d6c762-b63e-49b7-b651-c8d29f9c8d74",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,145,61,75,3,81,16,69,255,202,66,26,45,70,246,125,191,89,8,22,18,196,74,193,50,164,152,55,111,6,3,217,85,146,13,18,66,254,187,47,109,236,44,109,47,28,230,158,59,119,207,199,109,125,88,141,95,243,169,91,46,187,245,98,253,114,120,253,158,100,255,206,31,50,210,160,180,59,200,230,161,165,55,193,106,39,163,76,243,112,238,57,153,204,182,135,108,163,7,79,53,3,113,80,176,194,46,146,69,242,152,47,13,120,163,61,141,50,203,126,56,71,83,163,250,96,192,231,138,224,25,35,160,73,5,52,114,96,201,161,106,118,87,100,53,205,219,249,244,244,185,59,142,83,163,60,245,161,40,129,11,125,5,95,139,66,209,118,77,75,72,72,201,171,67,185,108,22,155,251,238,241,47,30,28,69,201,9,1,171,231,230,33,9,114,239,20,56,132,204,198,99,37,235,111,60,146,152,34,182,85,64,35,173,17,18,66,177,24,26,103,92,84,235,107,31,236,111,15,138,54,87,71,4,9,99,155,0,189,131,156,99,129,198,132,182,76,229,182,199,213,163,27,254,197,59,126,0,19,38,209,124,98,2,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignalLeadStageChangeStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"StartSignalLeadStageChange",
				NewEntityChangedColumns = false,
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(53, 60),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("bc0c2d60-5a3d-4840-aa4e-c60ea776e206");
			InitializeStartSignalLeadStageChangeParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ef1d55e6-1755-412a-9d7c-f01d78a5edf9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGateway3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(80, 310),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaStartEvent CreateStartOppBusinessProcessStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("cc1b7702-073c-45cc-926b-05e107a8fd30"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"StartOppBusinessProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(313, 583),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"OpenEditPageUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(631, 772),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway4ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("69c50fcc-abf2-43ac-a9d1-e9e6ed6a5397"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGateway4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(778, 772),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate4TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("129d65ec-f59b-44af-b1d6-cda0a6b4ff21"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Terminate4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(792, 877),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("ad47ec52-76d5-44c0-b66d-9440119348ca"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1107, 772),
				ResultParameterMetaPath = @"af8eea9e-0e11-426e-a870-2cff33d00f84",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,173,14,195,32,20,64,225,135,169,190,11,255,3,252,68,213,150,76,54,136,123,225,146,137,82,65,155,76,52,125,247,161,103,191,156,179,76,203,188,63,191,27,247,119,254,112,195,88,113,221,57,221,134,254,193,99,229,198,219,17,79,146,66,107,69,5,212,29,13,24,71,25,48,4,1,213,134,130,33,23,34,101,175,49,188,176,99,227,131,123,60,179,173,162,184,81,23,233,9,140,113,12,94,107,11,210,87,18,94,84,231,4,94,105,74,63,188,126,6,30,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("54731090-57ce-4f13-a4f0-8398e8e5479f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1c4add4a-0186-4391-8d42-9694825ccb10"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(2003, 219),
				ResultParameterMetaPath = @"0eae6fcc-65b6-433e-b4dc-e42323c488c1",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,47,205,76,209,115,205,45,40,169,4,0,200,160,7,199,10,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateStoreIsStageChangedByUserFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"StoreIsStageChangedByUser",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(2080, 569),
				ResultParameterMetaPath = @"9786c0e4-cc5f-4c9f-b46d-090a297e2b74",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,148,49,111,27,49,12,133,255,74,128,204,44,40,145,162,40,239,29,58,181,64,71,195,3,41,81,232,144,100,112,2,116,72,242,223,75,143,118,167,214,26,169,187,227,199,247,30,239,248,120,252,246,250,253,247,75,156,127,206,95,241,108,135,109,79,175,113,250,146,213,155,194,215,167,120,142,151,183,195,59,46,15,107,195,160,35,21,96,219,12,54,92,97,13,89,97,101,82,147,249,153,47,252,176,179,61,199,91,156,15,239,225,117,24,99,133,182,172,1,239,225,160,204,19,162,143,205,81,118,41,205,62,79,143,167,135,143,143,135,227,191,19,77,33,109,181,20,32,47,8,204,221,64,23,49,4,109,18,108,147,251,160,27,34,49,69,26,213,97,118,237,192,93,21,172,81,133,61,173,82,71,39,101,188,16,253,31,144,88,235,68,134,16,194,41,81,235,3,92,214,4,108,123,173,130,182,36,214,13,144,87,236,216,76,192,212,39,176,224,2,37,29,96,121,134,55,245,40,114,135,68,171,169,121,49,3,177,233,73,68,3,134,87,133,185,172,34,121,231,249,23,81,8,86,245,22,128,88,23,176,207,14,62,83,85,181,189,87,163,190,17,231,61,68,166,181,246,217,160,101,159,140,81,77,141,148,21,202,246,18,226,173,243,197,129,43,162,154,166,110,15,133,218,57,135,152,18,160,186,20,58,97,223,141,116,238,136,59,136,130,92,6,103,176,177,55,6,198,221,193,72,70,18,201,88,22,233,75,189,213,168,14,204,33,100,129,249,78,141,246,170,105,244,206,73,154,47,195,186,243,182,222,65,84,125,21,138,204,195,66,15,96,213,128,177,246,206,110,185,129,158,13,198,202,207,95,17,81,62,63,98,32,72,73,235,184,100,196,85,124,231,66,140,45,83,149,138,233,29,68,58,215,37,22,2,49,51,76,188,219,204,132,214,6,82,131,55,123,143,168,25,211,43,162,34,90,218,202,8,9,181,92,53,15,134,81,37,127,3,18,195,198,8,28,228,23,162,63,190,203,223,63,139,4,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateResetIsStageChangedByUserFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("c07da6a9-f9fc-4d1b-a11d-633a4992ae39"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("9348111f-aee1-4e53-aa53-fbb2eacd54f6"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ResetIsStageChangedByUser",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1660, 569),
				ResultParameterMetaPath = @"9786c0e4-cc5f-4c9f-b46d-090a297e2b74",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,75,75,204,41,78,5,0,48,104,205,43,5,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataLeadUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadDataLead",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(204, 310),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataLeadParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataLeadUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ChangeDataLead",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1505, 150),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataLeadParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewaySetDateTimePresentationExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("f7a393e4-d550-4f6e-aba4-c4a007307258"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGatewaySetDateTimePresentation",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1393, 150),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("375b9e3c-98fc-4100-83c4-c571cfe22b08"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"Terminate2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(225, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataContactToOpportunityUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"AddDataContactToOpportunity",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1640, 20),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataContactToOpportunityParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayLeadQualifiedAsContactExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("c017a416-4566-4caf-89f0-cd11dc760d58"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGatewayLeadQualifiedAsContact",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1520, 20),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataOpportunityUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"AddDataOpportunity",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1260, 20),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataOpportunityParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataCountOpportunityByAccountUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadDataCountOpportunityByAccount",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(862, 310),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataCountOpportunityByAccountParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataAccountUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadDataAccount",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(617, 310),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataAccountParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTaskAccountByLeadFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("ab3f8e00-ffa9-4079-8f2d-c9aa8b4b4826"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTaskAccountByLead",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(498, 310),
				ResultParameterMetaPath = @"342aec56-8359-4c5b-826b-9e8489fd6a4b",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,10,194,48,16,0,208,143,113,62,73,210,187,54,201,42,29,156,20,28,75,135,107,114,65,161,169,208,86,68,74,255,221,184,186,62,120,221,161,59,47,151,247,36,243,45,220,37,179,79,60,46,210,31,139,254,65,59,74,150,105,245,91,18,140,214,138,2,172,41,0,218,129,193,233,33,128,184,40,17,105,168,2,169,189,132,43,207,156,101,149,217,111,17,81,87,41,50,136,81,84,138,14,96,141,141,48,160,212,141,170,117,163,77,250,149,118,90,31,235,231,244,28,95,121,242,91,101,28,58,22,132,148,116,85,86,34,112,137,34,32,113,131,68,86,152,104,239,15,253,23,82,182,133,99,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataContactUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadDataContact",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(617, 149),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataContactParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayQualifiedByAccountExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ba7fb0fc-f887-4dd2-9494-28335297b5e4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("1800af83-2123-40e8-b79f-0e68449a9687"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGatewayQualifiedByAccount",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(372, 310),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateSaveCurrOppParameterFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("0b3df41d-a31f-4753-9ad5-bb8d4c5137fb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ff492f2e-7ec3-4894-8115-3064a4dbdf58"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"SaveCurrOppParameter",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1386, 311),
				ResultParameterMetaPath = @"af8eea9e-0e11-426e-a870-2cff33d00f84",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,10,195,32,16,0,208,143,201,124,165,156,198,139,238,29,58,165,208,49,56,156,222,73,135,152,193,4,58,132,252,123,157,187,62,120,203,176,60,247,249,187,105,123,231,143,86,14,133,215,93,227,173,235,31,60,86,173,186,29,225,180,118,44,110,82,132,36,119,3,150,172,3,118,68,96,144,82,82,34,44,46,95,61,188,184,113,213,67,91,56,197,101,195,50,121,32,227,9,172,72,47,136,30,202,136,90,56,25,177,38,93,113,136,63,181,94,204,26,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreatePresentationTaskCreationUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"PresentationTaskCreation",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1260, 150),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializePresentationTaskCreationParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSavePresentationParameterFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("a914a2b0-15d2-4c81-938d-6f3bcc01c912"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"SavePresentationParameter",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1260, 241),
				ResultParameterMetaPath = @"0eae6fcc-65b6-433e-b4dc-e42323c488c1",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,173,14,194,48,20,6,208,135,153,190,164,244,111,185,245,8,20,36,200,165,226,222,242,53,136,117,162,91,130,88,246,238,76,99,79,114,166,97,186,175,143,239,130,254,42,31,52,73,85,230,21,249,114,234,31,220,102,52,44,91,218,125,168,170,163,97,82,120,38,207,65,72,48,26,170,5,142,237,187,132,104,202,113,134,167,116,105,216,208,211,238,212,121,182,49,82,17,5,121,41,76,172,162,196,6,65,152,149,221,213,30,121,200,63,255,140,172,32,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadOppoortunityData2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("feedf149-5e02-44a6-b2c6-d31a10db7744"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadOppoortunityData2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1645, 150),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadOppoortunityData2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cbdfa4ab-c534-4027-a134-96b45d5b7770"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1107, 430),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cbdfa4ab-c534-4027-a134-96b45d5b7770"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"AddDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1271, 430),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("da838103-79ee-48ff-b9fb-43f5d9fb0543"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(372, 149),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"ReadDataUserTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(862, 149),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask3FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("083b1a16-96f4-434c-bd21-1e475d6a546b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(988, 149),
				ResultParameterMetaPath = @"02b1469d-72ad-4909-a7cf-6b41b79d41a7",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,14,130,48,16,0,208,143,97,62,67,185,150,187,118,119,112,210,196,145,48,156,189,35,14,148,161,144,56,16,255,221,206,174,47,121,83,55,221,246,251,103,179,250,204,111,43,146,22,89,119,155,47,77,255,224,186,90,177,237,72,39,179,68,99,18,136,153,50,120,66,6,238,205,131,71,68,195,16,108,84,247,109,225,33,85,138,29,86,211,57,42,57,79,250,130,94,68,192,187,28,128,57,18,160,232,160,204,139,242,208,74,55,255,0,207,157,35,16,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask4FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("b120e00e-d3f2-4b09-8118-ef17c00af6bb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(988, 310),
				ResultParameterMetaPath = @"02b1469d-72ad-4909-a7cf-6b41b79d41a7",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,14,194,32,16,0,208,143,233,124,70,188,131,30,236,14,78,154,56,54,12,7,28,113,40,29,104,19,135,166,255,110,103,215,151,188,105,152,30,235,243,187,104,127,231,143,54,9,85,230,85,227,229,212,63,184,207,218,116,217,194,158,172,225,76,226,128,144,5,40,97,2,246,236,193,120,66,29,179,43,104,175,199,25,94,210,165,233,166,61,236,194,152,213,27,4,84,203,64,37,49,36,235,16,70,115,171,84,77,53,133,234,17,135,248,3,216,229,173,9,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask5FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("cecd8639-1f00-4d59-b112-9fbe4de5517a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask5",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(736, 310),
				ResultParameterMetaPath = @"738ceb61-832b-4b27-a973-9347e26e827e",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,141,61,11,194,48,20,0,127,140,243,147,36,205,103,87,233,224,164,224,88,58,188,36,239,161,208,84,104,43,34,165,255,221,184,58,29,28,28,215,31,250,243,114,121,79,52,223,210,157,10,182,140,227,66,195,177,218,63,209,141,84,104,90,219,13,173,246,108,173,128,38,32,130,118,140,16,146,113,160,56,39,45,98,200,13,167,189,6,87,156,177,208,74,115,187,229,38,42,47,109,0,19,73,129,230,144,32,184,36,128,136,149,167,172,217,72,251,75,186,105,125,172,159,211,115,124,149,169,221,92,242,18,133,36,96,19,98,29,101,6,223,136,4,158,42,88,70,246,62,236,195,97,248,2,55,56,7,126,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask6FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("d527d260-953d-4177-b84b-fd337a8b9408"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask6",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(736, 149),
				ResultParameterMetaPath = @"738ceb61-832b-4b27-a973-9347e26e827e",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,187,10,194,48,20,0,208,143,113,190,146,230,157,172,210,193,73,193,177,116,184,73,110,80,104,34,180,17,145,210,127,183,174,174,7,206,112,24,206,203,229,93,105,190,197,59,21,244,25,167,133,198,227,174,127,208,79,84,168,54,191,146,205,150,132,203,64,74,56,144,204,26,64,169,29,32,23,193,201,46,68,45,205,182,135,43,206,88,168,209,236,215,132,200,28,37,3,28,77,2,41,21,3,20,12,33,37,139,177,211,145,33,211,191,210,215,246,104,159,211,115,122,149,234,87,84,49,162,113,28,164,73,251,226,22,193,138,28,64,69,199,67,74,206,228,108,183,241,48,126,1,146,45,47,48,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask7FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("e71860b5-b65b-493b-8d7c-c65ed80dc169"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7852560c-6de2-45bc-b542-143393a2f762"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask7",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(498, 149),
				ResultParameterMetaPath = @"b6534525-3848-4420-8930-e7bcc98a1756",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,205,177,10,194,48,16,128,225,135,113,62,73,154,75,122,201,42,29,156,20,28,75,135,36,119,69,161,141,208,86,68,74,223,221,186,186,254,240,241,183,135,246,60,95,222,69,166,91,190,203,24,67,31,135,89,186,227,94,255,66,51,200,40,101,9,107,47,200,68,162,0,157,205,128,148,34,120,157,50,136,103,97,180,201,100,171,182,29,92,227,20,71,89,100,10,43,35,106,211,115,4,169,148,221,137,206,64,21,49,36,20,87,43,167,107,93,245,63,210,148,229,177,124,78,207,225,53,150,176,70,70,175,216,18,40,139,17,246,169,5,95,161,3,102,66,231,36,25,79,102,235,14,221,23,218,197,238,43,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask8FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("7727ad4d-089b-417c-acfd-d66ee83afc06"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48537fce-e726-43c7-8dd9-691e0e0c228e"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask8",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1111, 149),
				ResultParameterMetaPath = @"b2b54e53-5309-4650-ac67-b8a4705d22b4",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,187,10,194,48,20,0,208,143,113,190,146,230,157,172,210,193,73,193,177,116,184,73,110,80,104,34,180,17,145,210,127,183,174,174,7,206,112,24,206,203,229,93,105,190,197,59,21,244,25,167,133,198,227,174,127,208,79,84,168,54,191,146,205,150,132,203,64,74,56,144,204,26,64,169,29,32,23,193,201,46,68,45,205,182,135,43,206,88,168,209,236,215,132,200,28,37,3,28,77,2,41,21,3,20,12,33,37,139,177,211,145,33,211,191,210,215,246,104,159,211,115,122,149,234,87,84,49,162,113,28,164,73,251,226,22,193,138,28,64,69,199,67,74,206,228,108,183,241,48,126,1,146,45,47,48,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask9FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("f284494f-5edb-489b-92c3-ddb20eaa0ab0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("08258488-7269-4cb1-8e76-d67a44d8d892"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48537fce-e726-43c7-8dd9-691e0e0c228e"),
				CreatedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"),
				Name = @"FormulaTask9",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1113, 310),
				ResultParameterMetaPath = @"b2b54e53-5309-4650-ac67-b8a4705d22b4",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,141,61,11,194,48,20,0,127,140,243,147,36,205,103,87,233,224,164,224,88,58,188,36,239,161,208,84,104,43,34,165,255,221,184,58,29,28,28,215,31,250,243,114,121,79,52,223,210,157,10,182,140,227,66,195,177,218,63,209,141,84,104,90,219,13,173,246,108,173,128,38,32,130,118,140,16,146,113,160,56,39,45,98,200,13,167,189,6,87,156,177,208,74,115,187,229,38,42,47,109,0,19,73,129,230,144,32,184,36,128,136,149,167,172,217,72,251,75,186,105,125,172,159,211,115,124,149,169,221,92,242,18,133,36,96,19,98,29,101,6,223,136,4,158,42,88,70,246,62,236,195,97,248,2,55,56,7,126,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new OpportunityManagement(userConnection);
		}

		public override object Clone() {
			return new OpportunityManagementSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a5f68bdc-2044-42c4-8830-9965e224d704"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityManagement

	/// <exclude/>
	public class OpportunityManagement : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessOpportunityMangementProcess

		/// <exclude/>
		public class ProcessOpportunityMangementProcess : ProcessLane
		{

			public ProcessOpportunityMangementProcess(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadOppDataFlowElement

		/// <exclude/>
		public class ReadOppDataFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadOppDataFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadOppData";
				IsLogging = true;
				SchemaElementUId = new Guid("0c718c20-8264-4ad8-ac5f-2ec36a29a498");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,137,157,151,67,57,26,208,54,203,74,44,8,105,119,180,186,182,175,119,44,229,49,155,56,98,87,209,72,72,84,84,252,3,95,48,5,80,80,192,47,100,254,8,103,178,3,210,22,136,130,6,201,197,245,181,207,185,231,28,217,195,149,237,158,217,210,97,91,24,40,59,12,250,19,93,144,132,1,15,57,67,26,70,60,166,177,132,148,138,204,132,52,141,140,208,40,66,197,115,36,65,13,21,22,100,70,47,181,117,36,176,14,171,174,184,24,126,147,186,182,199,224,202,28,54,47,213,26,43,120,53,13,0,140,83,35,243,140,170,144,41,26,3,230,20,52,143,40,8,198,149,214,66,196,202,144,89,75,142,9,79,101,204,41,74,153,208,88,228,140,202,20,50,42,89,38,19,46,37,112,147,144,160,68,227,150,183,155,22,187,206,54,117,49,224,175,250,252,110,227,85,206,179,23,77,217,87,53,9,42,116,112,6,110,61,9,9,49,78,20,80,21,11,207,110,48,163,192,133,166,28,100,198,178,28,163,52,202,72,160,96,227,38,90,114,162,73,160,193,193,107,40,123,60,48,15,214,107,100,60,140,242,36,245,216,136,123,59,156,133,52,79,189,59,163,83,35,144,167,66,72,125,204,235,121,111,125,109,187,211,190,194,214,170,251,216,209,231,215,180,197,160,154,218,181,77,57,81,159,30,174,159,227,173,155,195,189,63,122,51,27,114,190,63,129,200,54,232,59,92,148,22,107,183,172,85,163,109,125,61,115,110,183,30,82,109,160,181,221,49,133,229,77,15,37,9,90,123,189,254,99,90,139,190,115,77,245,31,89,13,188,77,207,225,31,217,65,238,244,6,181,237,54,37,220,29,246,5,121,124,211,55,238,233,248,105,252,50,126,219,191,223,127,24,119,251,143,143,198,31,251,119,227,247,241,243,184,27,191,142,187,249,10,121,64,85,144,75,2,38,71,4,225,191,3,70,17,141,89,138,20,242,44,164,76,25,195,185,14,67,147,199,151,196,203,251,151,67,47,78,186,23,111,235,227,175,153,125,174,158,248,238,131,198,217,17,89,12,127,163,115,187,154,148,174,182,126,253,4,164,49,208,137,252,3,0,0 })));
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

		#region Class: ProspectingFlowElement

		/// <exclude/>
		public class ProspectingFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public ProspectingFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("7fce678b-995e-4c53-9b43-ec2f04fae40f");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "Prospecting";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("0dbea59a-7031-4af4-a9b8-d96dea1c356c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
			}

			#endregion

		}

		#endregion

		#region Class: NeedsAnalysisFlowElement

		/// <exclude/>
		public class NeedsAnalysisFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public NeedsAnalysisFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("2c360bc7-48e6-45ca-a60f-a813cacd4299");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "NeedsAnalysis";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("c6385211-3b10-447a-8d34-e3f3605c4793");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
				SetParameterValue("MainContact", (Guid)((process.MainContact)));
			}

			#endregion

		}

		#endregion

		#region Class: OppManagementValuePpropositionFlowElement

		/// <exclude/>
		public class OppManagementValuePpropositionFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public OppManagementValuePpropositionFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("58cbaf95-b8d9-4650-8919-16e8dfa26bef");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid Presentation {
				get {
					return GetParameterValue<Guid>("Presentation");
				}
				set {
					SetParameterValue("Presentation", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "OppManagementValuePproposition";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("6a5733a0-e641-4579-b6dc-05fdd10ad6ed");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
				SetParameterValue("Presentation", (Guid)((process.Presentation)));
				SetParameterValue("MainContact", (Guid)((process.MainContact)));
			}

			#endregion

		}

		#endregion

		#region Class: IdDecisionMakersFlowElement

		/// <exclude/>
		public class IdDecisionMakersFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public IdDecisionMakersFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("c1ab3a28-ca5a-4a5a-8b66-0426e04e71c9");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "IdDecisionMakers";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("d58ab1aa-6acb-4539-9b28-cda203b74ced");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
				SetParameterValue("MainContact", (Guid)((process.MainContact)));
			}

			#endregion

		}

		#endregion

		#region Class: OppManagementPerceptionAnalysisFlowElement

		/// <exclude/>
		public class OppManagementPerceptionAnalysisFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public OppManagementPerceptionAnalysisFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("bcb1d0f8-c1a9-4754-8181-2f8570571c3a");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "OppManagementPerceptionAnalysis";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("da8227c5-5602-4a29-b848-1fb1e6b57440");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
				SetParameterValue("MainContact", (Guid)((process.MainContact)));
			}

			#endregion

		}

		#endregion

		#region Class: OppManagementProposalFlowElement

		/// <exclude/>
		public class OppManagementProposalFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public OppManagementProposalFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("032a799f-99c9-4e9d-8d1c-810f447a7791");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "OppManagementProposal";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("e3b6949a-0754-40f7-a369-1f69dae8bc2d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
				SetParameterValue("MainContact", (Guid)((process.MainContact)));
			}

			#endregion

		}

		#endregion

		#region Class: OppManagementNegotiationsFlowElement

		/// <exclude/>
		public class OppManagementNegotiationsFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public OppManagementNegotiationsFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("01359e67-5d64-45ca-9679-be70642e4ebc");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "OppManagementNegotiations";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("2bd13ebc-d0be-488e-9dff-abea5ba029d2");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
			}

			#endregion

		}

		#endregion

		#region Class: OppManagementContractationFlowElement

		/// <exclude/>
		public class OppManagementContractationFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public OppManagementContractationFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("b7ae2d23-17b7-4dca-bd06-4ac79c6dd368");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public bool OpportunityStageChanged {
				get {
					return GetParameterValue<bool>("OpportunityStageChanged");
				}
				set {
					SetParameterValue("OpportunityStageChanged", value);
				}
			}

			public Guid MainContact {
				get {
					return GetParameterValue<Guid>("MainContact");
				}
				set {
					SetParameterValue("MainContact", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "OppManagementContractation";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("8cd60286-ecaa-4f5c-aa25-62e4f4b7ee26");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
			}

			#endregion

		}

		#endregion

		#region Class: OppManagementEndStageFlowElement

		/// <exclude/>
		public class OppManagementEndStageFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public OppManagementEndStageFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("fea753ae-b6dc-408a-bac3-b7d60bec1df8");
			}

			#endregion

			#region Properties: Public

			public Guid CurrentOpportunity {
				get {
					return GetParameterValue<Guid>("CurrentOpportunity");
				}
				set {
					SetParameterValue("CurrentOpportunity", value);
				}
			}

			public int NextOpportunityStageNumber {
				get {
					return GetParameterValue<int>("NextOpportunityStageNumber");
				}
				set {
					SetParameterValue("NextOpportunityStageNumber", value);
				}
			}

			public Guid CurrentStage {
				get {
					return GetParameterValue<Guid>("CurrentStage");
				}
				set {
					SetParameterValue("CurrentStage", value);
				}
			}

			public LocalizableString Recommendation {
				get {
					return GetParameterValue<LocalizableString>("Recommendation");
				}
				set {
					SetParameterValue("Recommendation", value);
				}
			}

			public bool IsStageChangedByUser {
				get {
					return GetParameterValue<bool>("IsStageChangedByUser");
				}
				set {
					SetParameterValue("IsStageChangedByUser", value);
				}
			}

			public bool DontShowPageEndOfStage {
				get {
					return GetParameterValue<bool>("DontShowPageEndOfStage");
				}
				set {
					SetParameterValue("DontShowPageEndOfStage", value);
				}
			}

			public Guid NextStage {
				get {
					return GetParameterValue<Guid>("NextStage");
				}
				set {
					SetParameterValue("NextStage", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (OpportunityManagement)owner;
				Name = "OppManagementEndStage";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("a3d82030-af23-488b-b015-0c48be2056d9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (OpportunityManagement)Owner;
				SetParameterValue("CurrentOpportunity", (Guid)((process.CurrentOpportunity)));
				SetParameterValue("IsStageChangedByUser", (bool)((process.IsStageChangedByUser)));
			}

			#endregion

		}

		#endregion

		#region Class: FindPresentationFlowElement

		/// <exclude/>
		public class FindPresentationFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public FindPresentationFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "FindPresentation";
				IsLogging = true;
				SchemaElementUId = new Guid("da7cbb80-cd50-40b3-883c-6f5384f2478a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,151,91,139,92,69,16,199,191,202,114,30,242,116,90,250,82,125,27,31,151,21,2,18,3,94,16,194,18,250,82,157,61,56,183,204,156,65,195,176,16,215,7,241,105,193,23,65,16,49,159,96,69,87,130,96,242,21,206,124,35,235,204,236,196,33,108,54,97,21,37,49,15,51,204,185,212,165,171,255,191,170,158,229,221,102,254,94,51,108,113,54,40,97,56,199,122,113,51,15,42,212,218,219,28,129,97,114,142,65,66,203,92,44,156,229,192,133,19,217,235,28,99,85,143,195,8,7,213,198,250,32,55,109,85,55,45,142,230,131,59,203,191,156,182,179,5,214,119,203,250,226,195,116,132,163,240,113,31,32,1,248,236,148,100,1,82,98,16,185,96,209,103,205,92,16,50,129,12,190,56,95,109,114,145,194,36,201,3,103,178,120,207,32,71,203,124,116,137,233,12,14,147,118,16,162,171,234,33,150,246,224,139,233,12,231,243,102,50,30,44,241,217,239,143,30,76,41,203,77,236,253,201,112,49,26,87,245,8,219,112,59,180,71,148,136,203,14,138,79,44,130,139,12,172,143,204,135,100,24,128,144,69,129,50,41,200,170,78,97,218,246,110,171,238,167,238,201,234,203,213,9,125,159,118,127,116,143,187,243,170,158,97,193,25,142,19,238,172,207,113,29,66,66,96,206,112,96,192,169,128,193,99,100,188,104,16,22,180,87,137,87,117,14,109,248,36,12,23,184,206,113,217,144,97,148,94,115,43,10,179,24,104,181,104,36,115,89,4,230,133,143,69,89,37,75,145,219,202,191,63,153,124,182,152,82,213,231,183,22,35,156,53,233,98,11,145,246,98,50,27,44,211,100,220,206,38,195,222,249,173,29,131,205,86,93,60,252,116,83,158,225,250,73,111,88,29,215,139,57,238,15,27,28,183,7,227,52,201,205,248,222,122,23,143,143,201,102,52,13,179,102,190,45,234,193,253,69,24,82,1,154,123,71,87,22,255,118,152,81,124,82,192,235,182,228,122,186,205,124,157,115,47,237,220,204,167,195,240,96,125,61,168,110,220,95,76,218,119,187,111,247,86,15,187,179,238,103,146,197,73,119,190,185,89,61,103,188,125,89,121,200,16,29,48,237,208,176,92,132,96,222,10,146,6,23,217,112,244,202,37,115,225,225,184,190,60,220,15,221,249,30,169,239,108,245,53,125,78,186,179,151,4,116,175,30,240,144,118,249,31,165,87,69,85,132,113,158,101,103,169,147,240,104,152,231,150,19,194,34,128,44,89,57,238,175,79,175,6,47,146,82,133,161,151,150,250,84,112,44,104,75,193,192,9,142,65,67,210,102,151,222,71,68,236,211,203,137,181,58,66,86,132,191,214,185,95,83,54,189,10,57,83,5,124,208,46,123,147,236,235,38,223,183,196,190,144,216,239,8,215,95,55,4,93,77,79,137,200,67,34,73,164,146,248,134,158,200,121,249,119,232,9,65,201,20,10,233,27,181,96,32,193,144,17,231,244,126,2,116,6,179,51,226,239,204,62,1,37,88,193,144,83,59,0,37,53,11,52,15,73,190,16,164,87,152,133,114,187,244,124,191,238,54,231,221,47,212,230,30,118,143,87,167,151,147,228,141,64,201,29,165,42,36,185,205,68,102,228,94,247,240,11,52,144,77,122,59,251,222,164,217,215,159,135,72,15,231,47,103,9,100,178,144,192,255,39,147,40,38,173,157,229,134,21,147,104,18,89,107,88,180,62,51,41,32,163,69,97,184,148,215,103,9,204,122,202,6,202,193,244,162,239,247,80,149,200,44,199,36,67,193,172,109,217,101,233,71,170,216,147,190,3,117,191,117,103,151,115,20,16,76,137,206,178,196,37,173,45,32,13,183,172,4,29,36,165,74,57,123,15,169,252,127,38,210,254,98,222,78,70,111,42,68,143,168,173,254,190,250,106,245,13,181,216,211,189,238,233,174,58,110,92,201,84,40,14,105,217,200,56,18,78,32,13,178,64,50,103,50,149,162,84,166,81,229,224,194,195,139,142,147,215,15,126,231,230,252,131,207,199,91,34,55,165,60,124,135,238,62,119,227,217,31,128,193,242,85,242,61,62,220,102,76,93,224,240,248,79,8,139,140,52,164,14,0,0 })));
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
								new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"));
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

		#region Class: LinkOppToProcessFlowElement

		/// <exclude/>
		public class LinkOppToProcessFlowElement : LinkEntityToProcessUserTask
		{

			#region Constructors: Public

			public LinkOppToProcessFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "LinkOppToProcess";
				IsLogging = true;
				SchemaElementUId = new Guid("2a573100-970f-4c01-a74a-b5c18590a797");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_entityId = () => (Guid)((process.CurrentOpportunity));
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

			private Guid _entitySchemaId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
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

		#region Class: ReadOppMainContactFlowElement

		/// <exclude/>
		public class ReadOppMainContactFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadOppMainContactFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadOppMainContact";
				IsLogging = true;
				SchemaElementUId = new Guid("c6efa3ea-cf4c-4ae7-803f-c558c149da24");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,203,106,220,48,20,253,149,224,69,87,86,145,37,217,146,220,93,66,10,129,146,6,250,160,16,66,184,150,174,50,38,30,123,226,7,77,24,6,250,88,117,213,63,104,161,95,16,74,91,104,32,237,47,120,254,168,26,79,166,13,33,148,150,100,147,141,173,215,61,186,231,232,220,59,221,207,155,135,121,209,98,157,58,40,26,12,187,45,155,6,42,210,154,42,69,137,150,82,16,129,145,37,58,97,49,129,76,72,166,99,20,76,235,32,44,97,140,105,176,140,222,180,121,27,132,121,139,227,38,221,157,254,1,109,235,14,195,125,55,76,158,152,17,142,225,217,226,2,7,76,10,199,45,137,37,112,34,4,34,201,18,33,136,213,92,136,8,120,100,145,5,203,92,178,36,51,142,26,71,36,179,142,8,22,107,2,49,229,62,50,162,34,195,152,73,229,143,22,232,218,205,227,73,141,77,147,87,101,58,197,223,227,167,39,19,159,229,242,238,141,170,232,198,101,16,142,177,133,29,104,71,105,16,139,56,139,132,5,98,64,37,68,128,100,30,93,57,18,91,112,28,104,150,57,75,131,208,192,164,93,192,6,253,199,249,171,254,71,255,165,63,237,191,245,167,65,88,163,195,26,75,131,151,184,1,138,196,101,74,18,67,153,241,144,168,8,88,30,17,208,140,27,107,181,22,198,5,161,133,22,158,67,209,225,144,223,52,95,48,245,210,82,25,121,166,8,218,171,158,48,162,108,4,68,71,58,115,92,114,230,28,91,169,254,168,170,14,187,137,87,188,217,238,198,88,231,230,226,249,208,191,67,85,167,83,83,149,109,93,21,11,240,237,75,1,203,103,186,216,124,177,148,166,24,118,22,129,193,44,236,26,220,40,114,44,219,205,210,84,54,47,15,134,23,156,205,124,204,120,2,117,222,172,4,221,60,234,160,240,2,228,7,163,191,10,191,209,53,109,53,190,107,124,67,207,213,195,120,211,14,57,47,60,109,243,102,82,192,201,48,79,131,123,71,93,213,62,232,63,245,95,251,179,249,219,249,187,254,116,254,126,173,255,121,217,29,203,35,193,21,168,85,40,56,133,158,54,18,138,81,228,109,157,32,1,37,41,97,198,57,206,45,165,78,137,11,132,89,120,219,151,239,110,53,143,95,150,171,138,92,74,185,119,223,175,94,89,216,89,69,167,211,127,201,119,182,183,202,120,207,59,230,86,187,128,199,119,90,197,156,88,233,20,17,54,139,136,162,90,19,163,129,115,212,52,78,98,119,131,46,96,104,146,49,64,34,205,162,223,57,223,15,148,142,25,201,36,215,74,115,22,179,68,93,238,2,31,230,175,251,115,47,246,231,225,251,125,173,63,243,191,243,249,27,175,253,217,252,205,181,102,215,52,75,226,204,231,238,137,248,174,16,9,79,64,74,77,152,96,212,15,192,105,42,87,102,95,175,170,2,161,252,15,183,111,140,208,28,174,87,199,87,189,238,249,154,195,204,175,95,231,244,1,243,6,165,189,179,114,199,221,34,124,77,109,95,173,146,133,95,7,19,239,205,126,1,171,224,64,235,33,7,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,205,79,201,76,203,76,77,241,207,179,50,178,50,212,241,76,177,50,176,50,0,0,136,48,240,252,21,0,0,0 })));
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
								new Guid("fa274f3d-57a3-44ee-b644-d93441a31de2")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("fa274f3d-57a3-44ee-b644-d93441a31de2"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			private string _entityColumnMetaPathes;
			public override string EntityColumnMetaPathes {
				get {
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,5,193,65,1,0,32,8,3,192,68,123,224,112,64,28,132,254,25,188,107,157,92,118,35,74,6,47,39,50,245,96,212,149,237,206,148,62,148,174,20,226,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: OpenEditPageUserTask1FlowElement

		/// <exclude/>
		public class OpenEditPageUserTask1FlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenEditPageUserTask1FlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("b10332bd-27a4-46bc-a990-f59da9cdbb25");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.OpportunityMangementProcess;
				SerializeToDB = true;
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

			private int _editMode = 0;
			public override int EditMode {
				get {
					return _editMode;
				}
				set {
					_editMode = value;
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
					return _recommendation ?? (_recommendation = GetLocalizableString("a5f68bdc204442c488309965e224d704",
						 "BaseElements.OpenEditPageUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadDataLeadFlowElement

		/// <exclude/>
		public class ReadDataLeadFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataLeadFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataLead";
				IsLogging = true;
				SchemaElementUId = new Guid("fe4d88e0-465c-48ba-91bc-e9ded45b3c50");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,205,106,220,48,16,126,149,69,135,158,172,224,31,89,150,220,99,216,150,92,210,64,211,82,200,134,32,201,163,196,224,159,141,45,211,4,179,144,148,62,68,160,208,103,8,37,105,151,66,146,87,208,190,81,229,117,182,133,28,74,142,45,24,60,243,205,204,55,51,159,164,254,40,111,95,229,133,129,38,213,162,104,193,235,118,178,20,5,92,107,10,190,143,163,132,17,76,100,162,176,204,252,16,251,68,197,82,235,40,12,37,65,94,37,74,72,209,88,61,205,114,131,188,220,64,217,166,7,253,31,82,211,116,224,29,233,181,243,86,157,64,41,222,13,13,72,32,52,227,192,113,18,251,18,19,144,18,51,37,20,118,220,92,82,194,72,0,10,141,179,80,30,249,52,204,20,86,58,209,152,48,150,97,73,3,129,131,128,128,210,154,107,26,133,200,43,64,155,233,217,188,129,182,205,235,42,237,225,183,189,127,62,119,83,142,189,183,235,162,43,43,228,149,96,196,158,48,39,41,18,224,3,137,149,192,138,240,24,19,13,9,22,17,207,112,36,100,18,38,12,2,26,36,200,83,98,110,6,90,180,147,33,47,19,70,188,23,69,7,107,230,62,119,51,134,145,31,176,152,186,218,32,82,152,68,161,143,25,101,9,214,25,213,28,34,202,185,204,54,122,189,238,114,103,231,237,110,87,66,147,171,71,217,193,233,87,55,105,175,234,202,52,117,49,80,239,174,211,247,225,204,140,226,62,134,62,140,11,25,135,15,69,104,225,117,45,108,23,57,84,102,90,169,58,203,171,227,145,115,177,112,37,229,92,52,121,187,81,97,122,218,137,2,121,77,126,124,242,87,181,182,187,214,212,229,127,180,170,231,214,116,28,238,146,173,199,29,238,96,150,183,243,66,156,175,253,20,189,56,237,106,243,210,126,177,75,123,51,177,223,38,171,203,213,39,123,109,111,156,191,156,204,102,143,225,175,246,251,144,224,2,119,238,127,59,177,15,171,11,123,191,6,92,96,147,182,101,175,28,116,107,239,28,197,114,245,217,101,254,180,215,206,190,95,93,76,236,15,151,251,224,224,75,187,28,179,209,147,217,82,52,67,34,138,18,162,9,197,49,117,250,145,196,167,152,199,2,134,59,77,20,147,82,106,194,182,50,201,65,50,69,176,32,81,128,137,16,1,230,0,4,199,204,215,84,107,8,24,167,51,228,68,249,167,87,61,216,105,223,124,172,54,143,127,60,174,195,45,135,62,1,166,5,148,238,92,211,254,57,218,44,92,193,222,166,85,218,63,71,169,197,225,160,213,225,194,125,191,0,247,168,74,68,244,4,0,0 })));
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

		#region Class: ChangeDataLeadFlowElement

		/// <exclude/>
		public class ChangeDataLeadFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataLeadFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataLead";
				IsLogging = true;
				SchemaElementUId = new Guid("4174120c-c7f0-4e56-9ca1-71be449af2d1");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Opportunity = () => (Guid)((process.AddDataOpportunity.RecordId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Opportunity", () => _recordColumnValues_Opportunity.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Opportunity;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,203,106,220,48,20,253,149,65,139,174,172,193,15,217,146,221,101,152,150,217,164,129,166,165,144,132,32,75,215,137,193,143,137,45,211,4,51,16,18,40,148,166,253,133,46,187,13,165,67,39,73,211,111,144,255,168,242,56,211,66,22,101,150,45,216,32,29,223,115,238,189,199,87,106,15,211,250,89,154,41,168,162,132,103,53,88,205,84,70,8,128,242,192,21,18,187,68,134,152,80,143,226,144,250,2,123,129,112,2,226,3,13,125,138,172,130,231,16,161,129,61,145,169,66,86,170,32,175,163,189,246,143,168,170,26,176,14,147,213,230,165,56,134,156,191,234,19,16,135,39,44,132,16,83,223,142,49,129,56,198,76,112,129,147,196,11,227,128,48,226,128,64,15,181,4,64,5,179,37,166,52,78,48,97,60,196,92,50,138,169,11,177,207,92,106,251,194,71,86,6,137,154,156,206,42,168,235,180,44,162,22,126,175,119,207,102,166,202,33,247,86,153,53,121,129,172,28,20,223,225,234,56,66,28,108,32,190,224,88,144,208,199,36,1,138,185,23,74,236,241,152,186,148,129,19,56,166,83,193,103,170,151,69,83,137,44,201,21,127,205,179,6,86,202,109,106,106,116,61,219,97,126,96,184,142,39,48,241,92,27,179,192,212,152,200,32,9,193,11,194,48,150,107,191,158,55,169,89,167,245,118,147,67,149,138,7,219,193,248,87,86,81,43,202,66,85,101,214,75,111,175,194,119,225,84,13,230,62,124,122,51,52,164,12,222,147,208,220,106,106,216,202,82,40,212,164,16,165,76,139,163,65,115,62,55,148,124,198,171,180,94,187,48,57,105,120,134,172,42,61,58,254,171,91,91,77,173,202,252,63,106,213,50,109,26,13,51,100,171,114,251,25,148,105,61,203,248,217,106,31,161,39,39,77,169,158,234,47,122,217,93,232,235,238,162,187,26,233,111,250,90,223,235,251,238,131,94,140,244,157,94,246,192,88,127,214,139,238,92,127,53,232,205,168,251,104,240,133,254,97,222,251,238,98,100,240,133,254,222,93,234,187,238,202,200,44,187,243,238,178,251,212,189,55,232,205,72,223,234,159,38,186,143,191,237,222,25,181,229,120,42,135,180,232,81,121,17,218,71,9,16,201,24,216,152,4,230,96,17,22,115,28,58,177,192,16,74,144,196,143,61,225,219,99,73,136,227,37,146,99,112,109,51,157,204,17,152,185,76,226,152,64,64,109,51,154,142,155,140,55,25,225,125,100,204,251,215,45,217,155,214,47,222,22,235,123,98,248,179,7,99,131,62,2,38,25,228,102,4,162,118,19,15,231,134,176,179,78,21,181,155,56,218,83,38,133,74,213,217,112,95,68,237,38,22,207,15,122,147,15,230,230,249,5,24,107,95,83,85,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,111,211,48,24,254,43,149,217,177,174,18,219,137,227,28,161,67,170,180,65,197,96,151,181,7,127,188,222,42,165,201,148,164,192,168,42,49,184,114,228,135,12,132,96,28,216,254,66,250,143,112,221,148,182,176,19,142,148,200,175,253,124,196,239,227,57,58,168,175,46,1,165,232,241,240,248,164,176,117,239,73,81,66,111,88,22,26,170,170,119,84,104,153,77,222,73,149,193,80,150,114,10,53,148,167,50,155,65,117,52,169,234,110,103,23,132,186,232,224,181,95,67,233,217,28,13,106,152,190,26,24,199,12,138,11,45,72,132,85,24,38,152,41,77,176,208,65,132,41,13,19,17,146,40,33,148,56,176,46,178,217,52,63,134,90,14,101,125,129,210,57,242,108,142,128,107,107,45,163,9,22,0,142,128,112,130,147,48,54,56,50,142,218,4,90,24,26,163,69,23,85,250,2,166,210,139,110,193,44,148,54,17,32,48,143,2,133,25,40,133,19,45,53,182,150,10,21,179,132,133,160,87,224,118,255,22,120,246,232,108,80,61,127,147,67,121,226,121,83,43,179,10,198,61,87,253,171,112,152,193,20,242,58,157,51,22,217,56,1,130,149,9,40,102,156,197,88,198,156,99,74,184,82,192,57,177,177,94,56,192,159,179,76,231,38,214,84,154,196,217,163,130,99,102,140,131,16,34,176,141,8,88,169,168,97,84,45,198,143,198,43,139,102,82,93,102,242,234,244,95,167,205,231,230,174,249,210,220,52,95,155,219,229,135,229,167,78,115,191,124,239,74,223,92,233,251,242,99,111,96,58,203,107,55,255,225,43,191,220,115,215,252,236,184,233,77,115,239,16,215,205,237,90,225,114,175,201,187,26,243,209,58,41,35,148,142,30,206,74,251,93,159,205,126,90,246,131,50,66,221,17,58,41,102,165,94,177,209,213,100,211,56,207,30,180,3,63,240,218,140,53,135,135,29,203,92,158,67,249,204,233,121,184,95,234,203,90,122,233,151,206,243,134,88,17,17,5,60,180,152,131,20,46,10,177,203,145,9,37,22,161,80,150,114,74,172,37,30,253,2,44,148,144,107,216,55,38,129,197,86,37,28,235,128,104,204,164,11,163,52,52,196,82,16,170,141,17,130,105,235,241,94,121,107,102,147,105,87,201,103,89,230,5,42,255,255,171,75,210,26,111,87,250,59,61,222,97,40,204,196,78,192,12,242,255,60,170,62,88,79,249,180,40,15,223,186,171,59,201,207,219,126,237,72,111,247,244,245,180,173,47,208,98,49,94,252,6,51,223,62,160,39,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "a5f68bdc204442c488309965e224d704",
							"BaseElements.ChangeDataLead.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
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

		#region Class: AddDataContactToOpportunityFlowElement

		/// <exclude/>
		public class AddDataContactToOpportunityFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataContactToOpportunityFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataContactToOpportunity";
				IsLogging = true;
				SchemaElementUId = new Guid("c7fbc613-e8cf-48ac-9537-9cb0818cc78f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Opportunity = () => (Guid)((process.AddDataOpportunity.RecordId));
				_recordDefValues_Contact = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty)));
				_recordDefValues_IsMainContact = () => (bool)(true);
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Opportunity", () => _recordDefValues_Opportunity.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsMainContact", () => _recordDefValues_IsMainContact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Opportunity;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<bool> _recordDefValues_IsMainContact;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("fa274f3d-57a3-44ee-b644-d93441a31de2");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,205,111,27,69,20,255,87,172,109,143,30,107,118,190,199,71,154,32,69,106,32,34,165,151,36,135,55,95,173,37,127,68,246,6,8,150,165,54,65,72,168,45,39,78,92,56,114,13,21,161,110,66,218,127,97,247,63,226,237,218,33,78,169,82,132,56,160,136,181,236,245,252,102,126,239,189,125,243,222,111,118,154,221,45,14,247,99,214,205,62,218,218,220,30,165,162,115,111,52,142,157,173,241,200,199,201,164,115,127,228,161,223,251,26,92,63,110,193,24,6,177,136,227,135,208,63,136,147,251,189,73,209,110,173,146,178,118,118,247,139,102,46,235,238,76,179,141,34,14,62,223,8,104,25,0,2,64,4,34,83,226,68,196,24,136,99,218,146,164,117,176,134,91,198,153,70,178,31,245,15,6,195,205,88,192,22,20,143,179,238,52,107,172,161,1,41,164,203,69,0,226,193,40,34,64,51,2,210,36,34,3,36,14,212,185,20,104,54,107,103,19,255,56,14,160,113,122,69,78,192,180,72,60,16,169,1,189,163,123,226,148,16,36,88,46,68,14,60,15,145,213,228,229,250,43,226,206,157,157,141,201,167,95,14,227,120,187,177,219,77,208,159,196,189,14,162,239,0,235,253,56,136,195,162,59,21,66,38,101,34,35,46,80,244,165,133,34,160,180,38,248,128,206,69,173,89,82,126,134,132,63,115,217,157,6,229,57,4,99,137,230,86,19,17,2,82,24,195,228,72,22,19,56,30,4,119,179,189,59,123,117,136,161,55,217,239,195,225,195,191,70,90,254,80,190,41,127,41,79,202,151,229,188,58,170,158,183,202,183,213,19,132,126,69,232,183,234,184,179,17,90,213,83,28,191,106,144,11,252,188,41,95,183,112,120,82,190,69,198,211,114,190,240,176,127,109,147,87,125,76,119,23,149,178,155,117,119,223,95,43,203,251,34,55,215,171,229,122,161,236,102,237,221,108,123,116,48,246,181,53,94,15,46,55,174,177,78,151,23,121,207,207,229,181,176,209,208,54,97,8,143,226,248,19,244,215,208,155,169,53,40,160,113,253,0,99,190,52,236,152,149,84,231,137,232,8,22,11,81,49,98,66,14,196,230,214,37,174,57,75,137,53,236,207,98,138,227,56,244,241,122,96,16,133,74,206,104,226,41,243,88,135,209,16,8,60,39,128,37,236,67,176,86,248,212,240,27,207,87,193,92,214,52,34,195,131,126,191,113,48,105,158,191,110,146,101,224,203,153,181,149,61,94,177,48,10,189,212,139,97,99,248,15,83,181,22,83,99,242,227,209,120,253,43,108,221,222,240,209,114,191,86,92,95,173,89,243,131,37,62,203,102,179,246,106,55,99,6,25,151,78,146,148,59,67,68,110,48,9,42,49,194,172,213,52,129,183,49,230,55,118,51,40,102,2,7,32,218,170,156,8,43,56,49,70,57,146,115,37,85,30,130,247,86,253,39,186,57,69,17,140,137,148,8,37,113,187,141,171,43,197,121,18,109,136,1,37,137,123,73,223,237,102,12,130,39,84,170,200,168,68,74,238,137,193,167,37,14,139,77,83,149,235,156,165,154,178,62,44,122,197,225,189,38,71,221,41,4,97,105,144,134,80,41,0,53,192,72,98,25,106,71,8,70,40,21,29,71,149,252,27,26,240,115,221,251,229,201,162,255,151,125,94,61,43,79,91,229,121,57,175,129,78,249,83,121,138,186,240,18,209,215,173,234,5,226,167,229,239,248,189,168,142,90,136,159,150,175,170,227,242,188,122,142,102,230,213,147,234,184,250,190,250,14,81,84,138,51,20,140,243,102,253,89,245,45,90,155,119,202,31,81,108,78,106,211,213,55,248,69,176,81,156,26,187,168,215,159,148,103,11,26,26,175,7,213,209,255,18,243,97,137,201,149,139,216,7,57,49,9,143,17,145,75,139,18,21,40,1,67,241,40,80,134,135,192,111,189,196,24,27,92,110,146,34,146,171,250,188,167,152,4,41,29,81,2,146,151,50,58,160,230,230,23,6,79,149,99,16,137,246,90,16,81,55,164,177,18,143,101,60,100,141,229,76,50,101,254,125,137,41,198,120,187,161,69,47,231,111,247,33,107,169,83,210,37,20,179,148,80,53,115,129,181,172,241,109,143,9,70,241,15,36,75,245,77,29,64,151,215,7,3,187,101,29,176,55,251,3,201,197,155,205,140,11,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "a5f68bdc204442c488309965e224d704",
							"BaseElements.AddDataContactToOpportunity.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
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

		#region Class: AddDataOpportunityFlowElement

		/// <exclude/>
		public class AddDataOpportunityFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataOpportunityFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataOpportunity";
				IsLogging = true;
				SchemaElementUId = new Guid("445f68e2-bd03-4746-a677-327bbe772f6c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Account = () => (Guid)((process.Account));
				_recordDefValues_Title = () => new LocalizableString((process.ClientName)  + "/" + ((process.ClientOpportunityCount)+1).ToString());
				_recordDefValues_Budget = () => (Decimal)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("Budget").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Decimal>("Budget") : 0m)));
				_recordDefValues_IsPrimary = () => (bool)((process.ClientOpportunityCount) == 0);
				_recordDefValues_Owner = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("SalesOwner").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("SalesOwnerId") : Guid.Empty)));
				_recordDefValues_LeadType = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("LeadType").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("LeadTypeId") : Guid.Empty)));
				_recordDefValues_DueDate = () => (DateTime)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("DecisionDate").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>("DecisionDate") : DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))));
				_recordDefValues_ResponsibleDepartment = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("OpportunityDepartment").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("OpportunityDepartmentId") : Guid.Empty)));
				_recordDefValues_Contact = () => (Guid)((process.Contact));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Title", () => _recordDefValues_Title.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Budget", () => _recordDefValues_Budget.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_IsPrimary", () => _recordDefValues_IsPrimary.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_LeadType", () => _recordDefValues_LeadType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DueDate", () => _recordDefValues_DueDate.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_ResponsibleDepartment", () => _recordDefValues_ResponsibleDepartment.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Account;
			internal Func<string> _recordDefValues_Title;
			internal Func<Decimal> _recordDefValues_Budget;
			internal Func<bool> _recordDefValues_IsPrimary;
			internal Func<Guid> _recordDefValues_Owner;
			internal Func<Guid> _recordDefValues_LeadType;
			internal Func<DateTime> _recordDefValues_DueDate;
			internal Func<Guid> _recordDefValues_ResponsibleDepartment;
			internal Func<Guid> _recordDefValues_Contact;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,90,91,111,92,213,21,254,43,163,3,15,32,188,205,190,95,44,241,66,146,74,145,72,137,26,202,75,156,135,181,111,96,105,60,99,205,140,219,166,150,37,218,72,85,171,82,162,74,125,168,42,21,36,94,120,77,83,12,38,1,243,23,206,252,35,190,115,198,38,118,73,199,40,60,96,121,236,135,185,236,57,107,173,115,246,222,223,183,214,250,182,247,154,151,103,247,119,74,179,209,188,121,251,214,157,113,157,173,95,27,79,202,250,237,201,56,149,233,116,253,173,113,162,225,214,239,41,14,203,109,154,208,118,153,149,201,187,52,220,45,211,183,182,166,179,181,193,105,163,102,173,121,249,55,253,111,205,198,221,189,230,230,172,108,255,250,102,134,103,34,41,148,21,158,229,228,2,211,58,115,230,117,138,204,81,8,156,172,20,78,5,24,167,241,112,119,123,116,171,204,232,54,205,222,111,54,246,154,222,27,28,232,24,76,81,181,178,154,141,100,154,138,96,145,147,97,50,25,193,49,46,12,185,102,127,173,153,166,247,203,54,245,65,159,25,83,209,182,70,239,88,226,50,117,198,158,81,86,130,81,144,42,229,28,130,78,181,51,62,190,254,153,225,221,151,238,222,156,190,253,219,81,153,220,233,253,110,84,26,78,203,189,117,140,254,207,192,247,83,179,177,167,180,164,146,140,101,94,25,60,107,50,145,121,105,35,11,197,107,31,106,182,164,227,254,189,151,238,117,17,243,214,116,103,72,247,223,253,97,224,246,95,237,81,251,205,252,143,243,15,218,71,237,127,219,131,238,243,194,102,231,204,42,156,182,218,219,92,44,229,102,179,177,249,252,197,60,126,95,220,252,217,229,60,187,146,155,205,218,102,115,103,188,59,73,157,55,213,125,57,153,217,222,59,63,254,99,207,121,57,249,91,248,232,205,110,209,136,222,43,147,95,34,94,111,222,255,116,157,102,212,135,126,7,247,124,226,56,202,96,184,19,149,185,66,152,189,98,37,243,89,16,11,34,196,170,156,146,181,202,222,250,87,165,150,73,25,165,114,246,198,164,201,46,9,138,76,228,194,153,54,28,27,69,115,201,184,44,188,96,147,200,108,23,15,215,71,126,118,51,39,155,14,35,163,221,225,176,15,48,237,159,191,219,197,199,55,126,252,203,245,83,171,118,202,195,56,111,213,173,146,111,142,94,112,170,174,151,218,187,252,197,120,114,227,119,192,214,214,232,189,227,245,58,21,250,217,53,215,211,246,241,248,126,179,191,191,118,26,110,209,215,32,180,244,76,7,109,24,246,99,135,22,89,153,84,150,84,226,190,56,103,151,194,205,5,110,172,74,29,220,132,102,58,155,204,200,212,204,162,45,57,71,193,179,205,234,130,192,45,202,104,116,49,138,25,197,177,97,172,225,140,146,117,44,122,210,142,155,44,101,212,29,220,6,131,215,6,155,205,235,155,13,222,95,121,161,72,92,70,161,109,200,204,73,202,152,90,132,35,135,57,178,81,139,232,66,214,130,92,23,233,53,241,234,250,59,227,59,179,9,22,240,149,87,207,129,249,63,219,175,231,15,7,237,147,246,105,123,184,64,121,251,232,7,55,123,109,184,85,70,179,183,119,118,198,147,217,238,104,107,118,255,218,120,119,52,123,94,164,203,77,14,38,145,50,85,96,133,5,112,173,187,101,166,96,137,41,175,50,89,170,148,106,90,70,14,63,250,198,46,51,57,100,10,78,0,196,204,80,42,200,197,49,49,111,53,146,170,86,25,220,25,99,18,105,121,46,86,218,123,30,10,179,149,119,236,98,225,192,131,98,131,241,181,150,192,163,0,187,252,140,228,112,99,88,182,1,151,141,189,90,116,246,190,75,3,214,32,150,143,93,26,193,227,150,144,75,214,38,170,100,248,254,89,140,103,173,133,170,153,88,145,221,179,121,129,103,147,30,196,135,76,228,184,21,78,200,218,153,220,24,205,122,24,118,115,180,177,231,189,140,85,100,199,84,70,230,210,146,123,230,121,34,22,65,195,42,249,172,107,103,117,110,202,255,172,61,236,224,143,164,255,225,160,253,28,121,255,27,240,193,95,219,131,65,79,14,24,88,111,63,105,15,80,17,60,198,232,87,131,249,223,48,126,208,126,189,160,141,1,198,15,218,47,231,15,218,167,243,15,225,230,112,254,193,252,193,252,163,249,95,48,250,85,71,48,71,184,186,187,254,201,252,79,240,118,184,222,254,125,254,17,156,126,1,143,43,81,89,152,148,60,183,60,51,155,193,32,218,57,197,80,142,97,125,147,64,81,80,173,9,100,175,200,227,28,242,64,253,170,93,69,250,203,21,117,173,14,10,144,146,82,177,18,117,174,74,101,239,210,114,242,80,68,81,145,148,12,16,180,12,41,211,178,224,35,92,197,228,18,73,30,35,255,89,201,227,5,242,253,224,141,55,6,124,57,180,255,95,2,255,222,244,114,67,15,57,193,154,88,61,227,21,128,211,66,11,230,29,26,65,217,81,165,115,84,3,119,87,208,59,7,122,69,129,168,124,81,172,202,128,73,148,168,231,201,0,127,146,140,32,99,173,226,64,206,50,232,89,175,13,12,80,51,25,108,106,32,137,24,85,29,89,77,206,150,80,139,178,65,175,86,222,54,137,87,114,193,162,59,242,10,251,82,90,244,14,37,176,84,115,78,18,147,21,136,95,188,188,253,49,174,122,220,101,237,249,31,22,159,142,227,225,234,47,219,71,131,246,91,120,60,234,239,227,139,249,131,85,200,236,63,85,51,16,54,98,243,27,144,82,45,168,131,5,100,27,159,33,81,145,231,42,107,139,230,34,171,75,223,22,4,153,200,11,43,88,146,9,189,21,20,53,70,214,24,150,67,137,148,52,180,171,98,150,211,75,228,57,121,40,5,202,69,40,15,34,117,69,112,32,102,139,226,57,83,21,85,201,85,163,23,27,240,179,102,86,226,121,160,69,161,226,180,177,50,84,62,54,97,83,89,149,205,197,163,151,79,241,246,45,88,164,61,234,213,199,131,246,63,8,120,212,115,205,225,21,155,156,207,38,133,231,88,34,42,92,84,199,120,41,165,128,72,170,100,36,181,131,136,150,138,247,254,210,179,73,173,16,222,184,130,64,95,29,38,161,70,5,60,3,48,220,107,232,223,62,64,27,143,75,217,36,249,106,160,50,162,88,193,17,1,170,157,0,58,234,21,221,90,45,132,116,14,106,170,171,197,38,58,41,178,85,224,32,33,100,20,43,145,42,250,87,163,25,119,86,58,156,168,88,103,210,197,99,147,127,116,161,78,170,146,67,248,120,216,155,61,236,61,205,255,220,23,47,248,186,10,196,146,165,40,161,84,141,93,105,33,170,115,33,89,148,222,178,74,2,153,23,154,28,105,125,213,5,157,67,44,210,3,59,70,10,108,251,14,115,18,58,112,144,213,48,156,184,145,162,130,178,69,212,165,196,34,76,229,149,7,193,138,181,157,86,151,113,60,199,29,186,32,157,208,230,91,133,234,101,197,212,75,210,56,130,213,93,55,200,11,97,95,22,72,50,218,161,21,50,33,137,92,99,12,234,2,170,151,255,70,132,142,83,30,161,3,122,186,160,145,46,214,227,51,253,79,123,176,10,196,242,83,251,31,147,161,12,64,213,98,194,116,219,45,23,131,134,24,47,84,113,212,87,173,11,232,147,47,125,197,34,141,247,72,170,26,106,95,198,36,86,66,197,86,160,81,121,25,64,204,137,114,116,124,121,255,163,137,67,228,194,105,148,129,200,172,51,10,253,88,179,103,53,26,23,200,233,170,66,185,32,202,38,212,56,165,141,52,56,56,211,104,76,192,162,40,37,20,103,197,197,148,130,39,225,140,253,241,255,162,0,160,61,89,141,35,132,43,161,161,188,16,208,238,237,127,7,17,208,0,48,101,36,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "a5f68bdc204442c488309965e224d704",
							"BaseElements.AddDataOpportunity.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
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

		#region Class: ReadDataCountOpportunityByAccountFlowElement

		/// <exclude/>
		public class ReadDataCountOpportunityByAccountFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataCountOpportunityByAccountFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataCountOpportunityByAccount";
				IsLogging = true;
				SchemaElementUId = new Guid("b518c4a6-438a-4b3b-8989-1943e7c6d350");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,219,106,220,48,16,253,23,61,228,201,42,178,46,182,229,62,46,91,8,148,52,208,11,133,176,132,177,52,74,76,125,139,45,211,134,101,161,244,51,250,21,133,146,199,246,27,54,127,84,217,187,110,67,40,165,15,125,41,232,65,154,225,156,57,115,102,180,189,44,135,103,101,229,177,207,29,84,3,70,227,169,205,73,138,130,185,66,41,154,90,157,81,105,132,163,133,192,132,166,12,140,52,177,202,172,6,18,53,80,99,78,14,232,181,45,61,137,74,143,245,144,95,108,127,145,250,126,196,232,210,205,143,151,230,26,107,120,61,21,0,148,137,43,178,148,26,198,13,149,128,25,5,43,98,10,154,11,99,173,214,210,56,114,208,82,136,204,10,6,5,77,82,107,169,76,101,65,51,192,148,38,90,88,6,232,10,233,50,18,85,232,252,250,67,215,227,48,148,109,147,111,241,231,253,213,109,23,84,30,106,175,218,106,172,27,18,213,232,225,28,252,117,78,100,161,21,10,231,168,179,138,79,66,98,90,48,80,148,27,21,179,16,143,21,164,36,50,208,249,137,150,236,63,239,191,239,191,221,127,186,255,184,255,178,255,186,191,155,238,36,234,209,97,143,141,193,7,29,114,101,83,19,7,217,177,69,70,165,98,129,88,50,78,25,71,134,129,148,219,4,73,100,193,195,27,168,70,156,85,110,203,169,95,174,21,75,99,71,83,4,77,37,38,156,102,54,6,170,99,93,56,145,10,238,28,95,188,127,222,182,239,198,46,248,62,156,141,53,246,165,57,14,17,195,52,218,62,223,154,182,241,125,91,77,228,103,15,0,135,97,29,147,111,15,6,85,115,102,2,146,93,52,14,184,170,74,108,252,186,49,173,45,155,171,121,142,187,93,192,212,29,244,229,176,216,186,190,25,161,10,6,148,87,215,127,180,127,53,14,190,173,255,183,126,163,208,107,160,9,171,59,107,158,54,219,150,67,87,193,237,252,206,201,201,205,216,250,167,191,91,138,147,57,67,30,49,44,8,33,57,160,81,9,205,132,10,61,27,21,118,154,39,5,213,152,201,76,59,155,128,44,142,12,187,232,31,213,188,56,29,94,188,111,150,95,120,48,110,243,36,68,31,5,206,23,116,190,253,27,153,187,205,34,116,179,11,231,7,119,61,242,64,80,4,0,0 })));
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

		#region Class: ReadDataAccountFlowElement

		/// <exclude/>
		public class ReadDataAccountFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataAccountFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataAccount";
				IsLogging = true;
				SchemaElementUId = new Guid("a648f660-39aa-47fa-9c57-2fdc40b9d3fc");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,106,220,48,20,253,23,45,186,146,138,173,151,45,119,57,76,203,108,210,64,211,82,72,134,32,75,87,25,129,31,19,91,166,9,102,160,244,51,250,21,133,210,101,251,13,206,31,85,30,103,90,200,162,116,209,77,193,139,171,43,157,115,207,57,92,143,215,190,127,233,171,0,93,225,116,213,3,30,54,182,64,74,112,145,151,28,8,117,224,8,207,152,33,154,26,69,82,97,89,42,104,42,156,212,8,55,186,134,2,45,232,181,245,1,97,31,160,238,139,203,241,55,105,232,6,192,215,238,120,120,99,118,80,235,183,243,0,42,108,102,82,93,146,212,66,66,184,72,82,82,242,132,146,132,66,2,66,103,212,74,64,139,22,38,115,38,147,4,8,231,185,34,60,74,32,202,81,75,100,34,101,169,64,229,206,166,8,87,224,194,250,110,223,65,223,251,182,41,70,248,85,95,220,239,163,202,101,246,170,173,134,186,65,184,134,160,207,117,216,21,72,199,121,92,24,77,12,87,130,112,7,25,209,76,89,194,116,153,209,44,135,84,166,25,194,70,239,195,76,139,54,22,97,171,131,126,167,171,1,142,204,163,159,237,176,36,205,133,140,216,52,70,197,25,77,72,46,243,140,56,43,157,2,38,149,42,237,41,175,87,131,143,181,239,207,134,26,58,111,30,99,135,152,95,219,21,163,105,155,208,181,213,76,125,118,124,126,1,119,97,9,247,241,234,253,98,40,196,254,12,66,7,60,244,176,170,60,52,97,221,152,214,250,230,102,225,60,28,34,164,222,235,206,247,167,20,214,183,131,174,16,238,252,205,238,143,105,173,134,62,180,245,127,100,21,71,155,145,35,46,217,81,238,188,131,214,247,251,74,223,31,207,5,122,118,59,180,225,197,244,121,250,49,125,127,248,244,240,113,250,50,125,157,190,205,245,114,131,158,48,20,232,10,49,78,53,24,33,73,206,68,220,60,35,74,146,83,89,18,5,121,92,197,104,88,243,242,10,69,85,255,96,214,229,166,127,253,161,57,253,35,139,171,237,243,216,125,210,56,63,33,139,241,111,228,29,182,179,192,237,33,126,63,1,42,50,179,84,234,3,0,0 })));
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
								new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"));
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

		#region Class: ReadDataContactFlowElement

		/// <exclude/>
		public class ReadDataContactFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataContactFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataContact";
				IsLogging = true;
				SchemaElementUId = new Guid("e8f8e39f-e539-4087-a469-a23b941bc647");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,221,84,205,106,220,48,16,126,149,69,135,158,172,69,182,101,91,114,143,97,91,114,73,3,77,75,33,9,65,182,228,196,224,159,205,90,166,9,102,33,108,74,161,52,237,3,244,210,99,175,33,116,233,38,233,230,25,228,55,234,120,157,109,33,135,146,107,11,22,104,62,207,124,51,243,105,164,230,32,173,158,165,153,86,147,48,17,89,165,172,122,83,134,200,102,132,197,60,74,176,226,1,193,148,4,62,102,194,150,216,77,4,11,184,112,164,29,217,200,42,68,174,66,212,71,143,100,170,145,149,106,149,87,225,110,243,135,84,79,106,101,29,36,43,227,101,124,164,114,241,106,149,192,143,148,235,123,54,102,137,114,48,181,61,142,153,148,4,11,70,92,73,125,230,74,233,162,190,150,196,141,136,23,113,142,133,207,25,166,126,36,49,243,29,23,147,128,36,137,205,41,241,57,65,86,166,18,61,58,25,79,84,85,165,101,17,54,234,247,126,231,116,12,85,246,185,55,202,172,206,11,100,229,74,139,109,161,143,66,36,20,81,212,139,5,142,41,247,48,77,84,128,133,203,161,83,17,5,78,192,148,237,219,1,178,98,49,214,29,45,218,148,200,146,66,139,215,34,171,213,138,185,73,161,70,199,37,54,243,124,136,181,221,24,83,215,33,80,35,11,112,34,253,132,67,163,156,71,114,173,215,243,58,133,125,90,109,213,185,154,164,241,189,236,10,244,43,39,97,19,151,133,158,148,89,71,189,181,114,223,81,39,186,23,247,254,215,155,190,33,13,120,23,132,166,86,93,169,141,44,85,133,30,21,113,41,211,226,176,231,156,78,33,36,31,139,73,90,173,85,24,29,215,34,67,214,36,61,60,250,171,90,27,117,165,203,252,31,106,213,130,54,129,3,134,108,85,110,55,131,50,173,198,153,56,93,217,33,122,114,92,151,250,169,249,102,22,237,204,92,182,179,246,98,96,190,155,75,179,52,203,246,163,153,15,204,173,89,116,192,208,124,53,243,246,204,92,1,122,61,104,63,1,62,55,63,97,45,219,217,0,240,185,249,209,158,155,219,246,2,104,22,237,89,123,222,126,110,63,0,122,61,48,55,230,14,188,59,255,155,246,61,176,45,134,230,139,185,130,28,64,221,190,131,5,32,48,220,173,176,101,231,127,105,110,250,48,32,239,140,118,214,151,137,30,180,19,162,61,148,40,42,25,83,112,27,125,15,116,103,145,192,220,142,98,184,161,82,73,234,69,110,236,145,161,164,212,118,19,41,176,114,8,76,51,179,99,204,28,38,113,68,149,31,16,24,101,219,73,134,66,82,78,164,199,48,241,168,192,192,234,97,238,80,31,75,201,168,239,171,200,229,204,221,67,32,246,255,38,225,238,102,245,226,109,177,126,135,250,201,217,31,2,250,0,24,101,42,135,17,11,155,199,104,62,133,128,237,117,170,176,121,204,9,116,33,163,66,167,250,180,127,143,194,230,49,71,50,221,239,14,101,127,10,223,47,9,165,86,29,181,5,0,0 })));
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

		#region Class: PresentationTaskCreationFlowElement

		/// <exclude/>
		public class PresentationTaskCreationFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public PresentationTaskCreationFlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "PresentationTaskCreation";
				IsLogging = true;
				SchemaElementUId = new Guid("45fbb709-be49-495a-ae70-fce392dc560c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Title = () => new LocalizableString("Провести презентацию");
				_recordDefValues_Opportunity = () => (Guid)((process.AddDataOpportunity.RecordId));
				_recordDefValues_Type = () => (Guid)(new Guid("fbe0acdc-cfc0-df11-b00f-001d60e938c6"));
				_recordDefValues_ActivityCategory = () => (Guid)(new Guid("42c74c49-58e6-df11-971b-001d60e938c6"));
				_recordDefValues_ShowInScheduler = () => (bool)(true);
				_recordDefValues_StartDate = () => (DateTime)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("MeetingDate").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>("MeetingDate") : DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))));
				_recordDefValues_DueDate = () => (DateTime)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("MeetingDate").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>("MeetingDate") : DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).AddHours(1));
				_recordDefValues_Owner = () => (Guid)(((process.ReadOppoortunityData2.ResultEntity.IsColumnValueLoaded(process.ReadOppoortunityData2.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadOppoortunityData2.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_recordDefValues_Contact = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty)));
				_recordDefValues_Lead = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_recordDefValues_Account = () => (Guid)(((process.ReadDataLead.ResultEntity.IsColumnValueLoaded(process.ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? process.ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Title", () => _recordDefValues_Title.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Opportunity", () => _recordDefValues_Opportunity.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Type", () => _recordDefValues_Type.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_ActivityCategory", () => _recordDefValues_ActivityCategory.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_ShowInScheduler", () => _recordDefValues_ShowInScheduler.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_StartDate", () => _recordDefValues_StartDate.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DueDate", () => _recordDefValues_DueDate.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Lead", () => _recordDefValues_Lead.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Title;
			internal Func<Guid> _recordDefValues_Opportunity;
			internal Func<Guid> _recordDefValues_Type;
			internal Func<Guid> _recordDefValues_ActivityCategory;
			internal Func<bool> _recordDefValues_ShowInScheduler;
			internal Func<DateTime> _recordDefValues_StartDate;
			internal Func<DateTime> _recordDefValues_DueDate;
			internal Func<Guid> _recordDefValues_Owner;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_Lead;
			internal Func<Guid> _recordDefValues_Account;

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

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,90,93,111,156,71,21,254,43,214,166,23,32,101,86,243,253,225,59,104,130,176,148,64,68,160,55,113,46,206,124,181,22,182,55,218,93,3,169,101,41,31,8,132,40,69,66,149,144,122,65,5,55,220,154,148,80,39,105,147,191,240,238,63,226,153,119,109,226,132,116,109,53,169,148,218,107,203,187,222,121,223,153,121,119,230,60,207,57,231,57,179,59,120,103,122,251,86,25,172,14,126,120,237,234,245,81,157,14,223,29,141,203,240,218,120,148,202,100,50,188,50,74,180,185,241,33,197,205,114,141,198,180,85,166,101,252,30,109,238,148,201,149,141,201,244,226,202,241,78,131,139,131,119,126,213,95,27,172,222,216,29,172,77,203,214,47,214,50,70,22,129,170,115,50,48,81,76,102,90,151,192,188,182,150,185,36,120,142,42,88,67,6,157,211,104,115,103,107,251,106,153,210,53,154,126,48,88,221,29,244,163,97,0,157,83,229,164,4,115,53,59,166,115,36,70,156,107,86,180,80,81,56,163,180,18,131,189,139,131,73,250,160,108,81,63,233,243,206,73,235,144,189,146,140,116,74,76,71,46,88,12,217,48,79,66,38,45,41,84,31,90,231,195,251,159,119,92,31,116,159,205,238,116,79,187,7,221,195,217,221,217,189,238,96,165,123,134,134,135,221,23,248,251,10,13,251,179,223,117,7,179,143,215,7,173,127,222,152,220,218,164,219,239,189,230,48,183,94,88,230,227,3,237,174,207,247,106,125,176,186,254,234,221,58,124,191,222,47,195,139,251,245,226,86,173,15,46,174,15,174,143,118,198,169,141,166,218,135,163,165,235,71,231,135,63,236,21,47,71,63,243,49,250,110,87,105,155,222,47,227,159,96,190,190,123,127,233,18,77,169,159,250,231,120,230,163,129,77,34,101,170,224,140,4,246,65,39,235,24,5,75,76,121,149,201,82,165,84,83,223,251,103,165,150,113,217,78,229,27,62,88,63,243,243,135,57,178,42,180,108,239,108,110,246,19,76,250,239,223,204,244,240,193,15,175,92,58,182,145,199,70,24,229,141,186,81,242,218,246,55,124,162,75,165,246,67,254,104,52,190,252,27,128,103,99,251,253,195,253,58,54,245,243,123,46,165,173,195,246,189,193,222,222,197,227,120,138,181,22,19,171,99,85,120,44,98,76,158,121,83,43,43,213,91,83,141,53,190,186,197,120,178,94,103,13,20,233,104,35,240,36,136,5,85,35,115,188,36,73,181,100,227,234,155,199,211,141,11,55,214,38,63,253,245,118,25,207,87,112,181,210,230,164,220,28,162,245,165,134,203,155,101,171,108,79,87,119,181,54,213,250,34,89,204,92,49,237,180,101,100,157,99,74,186,24,11,56,165,218,180,135,14,255,179,245,213,221,108,147,162,236,3,115,42,52,174,200,232,34,193,61,213,200,82,41,170,172,85,220,187,121,225,230,34,200,222,184,208,125,2,192,254,171,219,7,104,15,102,247,102,31,205,33,251,180,251,55,154,254,51,187,63,92,203,43,179,187,248,252,69,223,242,21,126,159,118,143,86,240,113,191,123,134,30,119,187,131,249,12,103,27,205,81,6,195,157,168,204,21,10,76,23,43,153,239,141,73,132,88,149,83,178,86,185,8,205,84,180,173,209,59,150,184,132,41,81,241,140,50,104,158,130,84,41,231,16,116,170,103,30,205,34,194,72,133,171,192,48,204,91,71,87,88,172,38,49,229,82,230,82,241,154,133,94,136,102,163,131,72,74,1,255,65,194,226,19,97,21,141,11,44,107,47,120,33,163,147,177,223,6,154,175,140,70,191,220,185,53,116,6,95,64,133,200,140,201,109,4,0,14,70,192,153,170,58,144,241,57,216,228,134,53,22,78,9,215,193,239,156,229,42,48,13,231,21,235,42,178,229,37,40,159,236,137,152,252,123,15,194,134,201,167,179,223,3,114,7,221,227,97,247,15,188,61,91,65,235,227,230,90,113,13,80,156,187,217,97,247,87,52,3,159,184,121,127,9,199,147,225,120,154,157,60,243,112,148,153,92,2,126,88,13,165,57,200,92,89,136,148,224,63,52,72,73,122,135,248,117,33,28,147,23,186,146,19,172,112,1,231,170,164,97,148,124,198,82,106,146,65,149,44,148,255,22,225,24,172,40,146,123,120,61,33,155,111,7,37,68,30,12,211,60,138,98,53,220,99,226,67,45,147,211,73,7,102,124,177,115,56,6,135,167,125,125,56,126,10,184,221,67,92,251,57,26,239,192,19,254,249,107,160,249,151,246,79,139,130,151,224,60,157,175,60,205,190,158,121,112,218,170,106,177,41,48,153,35,50,201,98,1,171,22,20,166,152,130,141,90,25,39,194,66,112,98,145,115,73,70,48,239,225,98,181,244,196,128,0,188,240,196,147,208,81,104,165,223,60,56,167,99,188,45,0,211,209,245,179,29,45,6,30,45,210,22,207,120,173,88,62,161,177,11,14,113,138,212,176,107,231,168,6,62,119,47,203,220,239,235,17,224,149,78,28,62,132,57,7,179,213,158,35,55,18,240,214,134,156,17,228,124,42,49,47,68,64,179,85,50,202,51,43,34,146,71,172,57,11,21,78,142,139,96,131,176,200,143,114,126,43,114,191,90,116,246,190,112,166,109,131,170,71,186,26,68,76,136,114,115,201,218,68,149,12,127,57,247,211,16,132,106,38,6,166,4,51,122,145,152,151,112,189,17,76,225,184,21,78,200,218,186,92,222,158,110,76,111,191,219,175,209,234,110,169,9,78,186,151,35,20,150,212,192,214,125,37,205,68,118,60,217,88,165,173,225,20,25,227,63,91,166,216,188,95,203,22,15,179,194,217,31,187,135,43,221,19,56,63,52,12,187,207,224,238,238,116,15,208,250,104,101,246,39,180,63,236,190,156,107,64,43,115,65,104,118,191,123,50,251,168,121,200,217,157,217,253,217,199,179,63,160,21,121,229,99,164,151,79,250,251,31,55,173,168,57,208,79,122,71,187,191,210,228,164,7,125,239,47,155,179,125,112,204,175,158,139,28,52,75,81,66,169,26,57,164,213,240,134,2,128,144,112,147,149,4,121,236,120,38,173,151,172,114,82,14,234,92,49,170,10,112,177,192,34,66,42,97,209,39,199,76,72,10,209,161,34,147,227,98,69,137,35,100,44,80,2,132,137,18,136,85,80,248,98,180,140,39,167,64,237,81,167,16,151,172,242,42,86,25,254,32,231,31,3,55,147,239,137,239,127,23,25,230,229,231,95,178,205,146,109,78,96,155,224,75,147,182,32,88,101,40,126,189,206,16,121,196,71,72,12,41,104,110,35,4,171,133,81,60,119,202,86,82,204,5,68,66,218,89,176,77,177,129,5,139,216,222,134,160,160,136,189,21,108,227,32,203,197,146,4,203,166,246,90,64,128,182,135,140,59,90,69,69,241,192,161,227,191,28,195,84,146,185,221,88,33,149,161,88,214,252,89,69,217,12,234,65,136,153,2,234,36,229,255,99,24,8,250,198,40,66,53,197,4,36,70,88,28,70,85,71,12,226,108,9,181,40,27,244,107,197,48,199,228,239,198,13,111,146,103,254,134,187,90,109,236,94,175,13,224,191,195,89,31,157,135,240,229,117,37,116,97,35,54,183,37,180,21,101,18,45,12,106,171,57,3,15,158,35,148,183,40,171,101,117,230,101,129,196,155,30,130,84,210,154,0,9,93,202,246,253,67,96,156,130,14,210,24,75,214,47,36,148,88,137,66,130,6,159,148,5,35,105,100,85,94,245,85,74,103,45,175,84,133,246,231,43,41,162,140,212,48,27,36,235,70,35,41,202,222,176,32,161,180,228,220,74,247,5,85,123,175,222,190,164,232,83,208,199,126,27,122,246,91,252,181,170,250,188,240,142,121,219,253,80,34,231,221,250,170,123,147,37,151,20,179,164,152,83,81,76,230,41,36,79,25,110,85,2,15,182,81,116,84,138,1,29,64,121,130,56,155,22,199,44,25,126,88,11,208,59,84,74,164,88,200,169,24,10,247,56,195,34,132,207,213,20,143,164,235,156,81,76,225,69,227,64,8,67,33,2,189,106,65,244,162,16,189,40,138,78,58,95,4,58,190,117,20,179,150,151,148,113,50,101,104,65,176,72,156,243,114,134,35,238,45,49,50,159,90,17,173,162,188,104,181,215,128,203,153,143,74,20,36,109,30,161,180,226,100,19,14,175,68,21,225,66,125,100,82,21,18,2,135,157,170,89,124,76,167,70,158,45,202,255,76,56,66,154,67,56,241,70,194,160,156,136,99,59,90,37,155,249,121,139,74,144,23,161,20,93,52,12,73,96,73,125,69,84,210,146,35,13,249,27,9,144,199,105,7,243,157,142,74,250,130,234,231,243,137,150,68,115,50,209,72,147,113,138,148,34,100,181,102,126,77,197,143,45,122,231,18,206,5,70,33,225,118,207,34,209,220,220,251,47,39,220,99,173,185,43,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "a5f68bdc204442c488309965e224d704",
							"BaseElements.PresentationTaskCreation.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
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

		#region Class: ReadOppoortunityData2FlowElement

		/// <exclude/>
		public class ReadOppoortunityData2FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadOppoortunityData2FlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadOppoortunityData2";
				IsLogging = true;
				SchemaElementUId = new Guid("733fbec1-d5fb-4329-bfe6-b63ae3090e5b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,187,142,212,48,20,253,21,228,130,42,70,113,236,60,28,202,209,128,182,89,86,98,65,72,187,163,213,141,125,189,99,41,143,217,196,17,187,138,70,66,162,162,226,31,248,130,41,128,130,2,126,33,243,71,56,147,29,144,182,64,20,52,72,46,236,107,159,115,207,57,186,30,174,108,247,204,150,14,219,220,64,217,97,208,159,232,156,96,172,116,17,25,160,172,40,128,10,153,196,52,99,92,80,174,1,89,161,50,46,140,32,65,13,21,230,100,70,47,181,117,36,176,14,171,46,191,24,126,147,186,182,199,224,202,28,14,47,213,26,43,120,53,53,0,20,137,41,178,148,170,48,82,84,0,102,20,52,103,20,100,196,149,214,82,10,101,200,172,37,73,51,141,38,10,169,17,50,165,194,36,9,149,156,73,42,211,48,78,50,196,52,100,138,4,37,26,183,188,221,180,216,117,182,169,243,1,127,237,207,239,54,94,229,220,123,209,148,125,85,147,160,66,7,103,224,214,147,144,16,69,172,128,42,33,99,207,142,41,5,46,53,229,80,164,81,154,33,75,88,74,2,5,27,55,209,146,19,77,2,13,14,94,67,217,227,129,121,176,94,99,196,67,150,197,137,199,50,238,237,112,175,54,75,188,59,163,19,35,145,39,82,22,250,152,215,243,222,250,189,237,78,251,10,91,171,238,99,71,159,95,211,230,131,106,106,215,54,229,68,125,122,120,126,142,183,110,14,247,254,234,205,108,200,249,250,4,34,219,160,239,112,81,90,172,221,178,86,141,182,245,245,204,185,221,122,72,181,129,214,118,199,20,150,55,61,148,36,104,237,245,250,143,105,45,250,206,53,213,127,100,53,240,54,61,135,31,178,131,220,105,6,181,237,54,37,220,29,206,57,121,124,211,55,238,233,248,105,252,50,126,219,191,223,127,24,119,251,143,143,198,31,251,119,227,247,241,243,184,27,191,142,187,249,9,121,64,149,147,75,2,198,207,25,72,164,33,50,70,69,148,32,133,44,13,105,164,140,225,92,135,161,201,196,37,241,242,254,101,211,139,147,238,197,219,250,248,107,102,159,171,39,190,250,160,112,118,68,230,195,223,232,220,174,38,165,171,173,95,63,1,158,168,110,199,252,3,0,0 })));
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

		#region Class: ReadDataUserTask1FlowElement

		/// <exclude/>
		public class ReadDataUserTask1FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask1FlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("9d00770f-dda3-42a7-937d-59d67284f4c1");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,221,106,212,64,20,126,149,101,46,188,202,44,147,100,50,153,137,151,101,149,222,212,130,85,132,110,41,147,204,153,54,144,159,109,126,176,37,44,84,241,33,4,193,103,40,210,234,34,180,125,133,236,27,121,178,233,42,244,66,122,169,16,200,249,249,206,223,119,78,210,29,167,245,139,52,107,160,138,172,206,106,112,218,93,19,17,237,169,48,240,60,77,165,207,25,229,168,81,165,165,160,82,37,190,241,56,75,192,132,196,41,116,14,17,25,163,103,38,109,136,147,54,144,215,209,97,247,39,105,83,181,224,28,219,141,242,58,57,133,92,191,25,10,184,86,8,55,240,128,114,151,73,202,149,145,84,169,192,167,66,49,30,88,38,140,149,146,140,189,152,216,21,161,98,134,38,161,226,148,107,17,82,237,107,69,101,44,132,180,154,49,207,34,52,3,219,204,206,23,21,212,117,90,22,81,7,191,229,131,139,5,118,57,214,222,41,179,54,47,136,147,67,163,247,117,115,26,17,47,225,49,196,60,160,70,5,138,114,159,49,26,199,49,80,11,60,81,86,199,194,186,114,170,129,1,15,18,77,19,174,2,202,45,12,45,40,67,125,29,135,94,40,193,21,46,210,145,232,69,51,212,38,253,151,126,213,95,79,119,13,113,140,110,244,91,157,181,176,233,162,75,113,30,207,103,174,12,134,41,92,63,193,138,30,163,82,200,144,90,35,172,2,95,40,21,155,45,183,47,219,20,229,180,222,107,115,168,210,228,97,69,128,92,151,85,212,37,101,209,84,101,54,164,222,219,192,15,224,188,25,23,241,224,122,55,14,223,160,125,8,34,75,167,173,97,39,75,161,104,102,69,82,154,180,56,25,115,46,151,24,146,47,116,149,214,91,198,102,103,173,206,136,83,165,39,167,127,101,118,167,173,155,50,255,143,70,117,112,76,204,129,7,185,105,119,184,87,147,214,139,76,95,108,244,136,60,59,107,203,230,249,184,197,73,255,109,178,254,176,254,216,95,245,215,168,175,38,243,249,131,251,107,255,125,0,160,227,22,223,55,147,254,126,125,217,223,109,12,232,216,194,166,253,103,52,221,244,183,152,98,181,254,132,200,159,253,21,202,119,235,203,73,255,3,177,247,104,254,208,175,70,52,121,212,91,68,230,68,251,126,200,45,23,52,16,200,31,15,153,160,42,208,64,93,151,243,68,226,177,90,46,167,38,86,16,203,132,83,205,125,23,63,18,237,82,5,192,105,32,153,21,214,130,43,149,152,19,36,229,159,30,245,112,183,126,245,190,216,254,40,198,117,29,77,209,250,200,48,203,32,199,189,70,221,83,184,89,98,192,254,182,84,212,61,133,169,229,209,192,213,209,18,159,95,58,91,155,6,32,5,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,177,50,180,50,212,241,76,177,50,176,50,0,0,230,77,107,227,15,0,0,0 })));
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
								new Guid("1f66152e-4108-49d8-9953-69045f06df88")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("1f66152e-4108-49d8-9953-69045f06df88"));
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

			public AddDataUserTask1FlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("8cefef55-2cb9-4d67-93b5-1c6727144b04");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Opportunity = () => (Guid)((process.AddDataOpportunity.RecordId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Product", () => _recordDefValues_Product.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Opportunity", () => _recordDefValues_Opportunity.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Product;
			internal Func<Guid> _recordDefValues_Opportunity;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("a5657e6b-342d-4104-8ab8-aab37ef29860");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,205,106,219,64,16,126,21,179,135,158,180,70,107,237,174,118,213,99,112,75,46,105,160,105,41,196,33,172,86,179,137,64,63,142,126,104,130,49,164,165,15,81,40,244,25,66,73,90,83,72,242,10,242,27,117,100,197,45,228,80,114,108,65,160,249,253,102,230,155,145,22,199,105,253,34,205,26,168,34,103,178,26,188,118,55,137,8,8,231,164,10,36,213,33,4,148,51,127,66,181,9,19,106,28,23,130,137,137,21,16,18,175,48,57,68,100,200,158,38,105,67,188,180,129,188,142,14,23,127,64,155,170,5,239,216,109,148,215,246,20,114,243,166,47,192,156,148,136,3,61,182,162,92,39,138,106,45,2,42,181,207,133,243,101,226,148,34,67,47,66,5,126,16,130,162,19,161,19,202,173,85,52,14,99,73,25,234,192,98,102,185,150,196,203,192,53,211,243,121,5,117,157,150,69,180,128,223,242,193,197,28,187,28,106,239,148,89,155,23,196,203,161,49,251,166,57,141,200,196,242,24,98,46,104,162,133,166,60,240,125,26,199,49,80,7,220,106,103,98,233,152,26,27,240,129,11,107,40,214,18,148,59,8,169,9,176,153,192,196,225,36,84,192,36,67,58,172,153,55,125,109,210,125,233,86,221,245,120,55,33,94,98,26,243,214,100,45,108,186,88,164,56,207,36,240,153,18,18,33,88,96,177,226,196,167,74,170,144,186,68,58,13,129,212,58,78,182,220,190,108,83,148,211,122,175,205,161,74,237,195,138,0,185,46,171,104,97,203,162,169,202,172,135,222,219,132,31,192,121,51,44,226,193,245,110,24,190,65,123,159,68,150,94,91,195,78,150,66,209,76,11,91,38,105,113,50,96,46,151,152,146,207,77,149,214,91,198,166,103,173,201,136,87,165,39,167,127,101,118,167,173,155,50,255,143,70,245,112,76,196,192,131,220,180,219,223,107,146,214,243,204,92,108,244,136,60,59,107,203,230,249,176,197,81,247,109,180,254,176,254,216,93,117,215,168,175,70,179,217,131,251,107,247,189,15,64,199,45,190,111,70,221,253,250,178,187,219,24,208,177,13,27,119,159,209,116,211,221,34,196,106,253,9,35,127,118,87,40,223,173,47,71,221,15,140,189,71,243,135,110,53,68,147,71,189,69,100,70,76,16,132,220,113,73,133,68,254,120,232,227,87,41,12,80,198,56,183,10,143,213,113,53,78,98,13,177,178,156,26,30,48,202,141,97,84,3,112,42,148,239,164,115,192,148,150,51,130,164,252,211,163,30,238,214,175,222,23,219,31,197,176,174,163,49,90,31,25,166,25,228,184,215,104,241,20,110,150,152,176,191,45,21,45,158,194,212,242,168,231,234,104,137,207,47,242,146,89,235,32,5,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private Guid _filterEntitySchemaId = new Guid("1f66152e-4108-49d8-9953-69045f06df88");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,205,110,211,64,16,126,149,202,237,49,19,173,119,215,94,111,142,208,34,69,106,33,162,208,75,146,195,254,204,182,145,156,164,178,29,254,162,72,180,189,114,228,206,43,20,132,160,32,209,190,130,243,70,108,156,148,164,85,85,68,85,129,176,37,91,59,158,239,155,217,153,253,198,227,96,163,120,125,136,65,35,120,208,218,217,29,186,162,254,112,152,97,189,149,13,13,230,121,125,123,104,84,218,123,163,116,138,45,149,169,62,22,152,237,169,116,132,249,118,47,47,106,107,171,160,160,22,108,188,168,190,5,141,246,56,104,22,216,127,222,180,158,153,114,21,197,194,90,48,206,40,224,214,34,72,212,8,206,42,225,56,77,132,100,220,131,205,48,29,245,7,59,88,168,150,42,14,130,198,56,168,216,60,1,11,157,78,24,55,64,108,28,3,167,130,130,34,132,130,164,78,32,74,105,141,225,193,164,22,228,230,0,251,170,10,186,4,251,216,145,192,88,3,227,212,2,15,9,135,68,233,4,148,210,76,160,163,50,137,201,12,188,240,95,2,5,147,196,49,35,129,160,147,192,157,21,62,42,50,32,26,165,149,72,99,71,194,186,66,130,60,242,219,50,92,70,222,9,189,19,147,22,152,210,130,138,4,195,56,20,51,118,219,203,15,83,245,122,239,122,144,242,195,244,109,121,94,126,158,158,148,223,167,199,117,159,186,119,62,188,82,234,85,247,113,103,222,175,78,208,232,220,220,177,197,123,183,42,197,213,158,93,109,87,39,168,117,130,221,225,40,51,51,182,120,182,184,44,95,197,78,22,23,220,240,184,188,230,28,21,108,71,13,212,62,102,143,125,188,10,94,125,218,84,133,170,66,63,243,57,255,49,241,83,116,152,225,192,224,29,19,171,34,47,147,185,60,89,149,229,222,154,187,200,52,175,10,57,59,243,139,10,12,70,105,58,171,192,74,223,87,82,25,218,158,235,161,109,14,238,184,181,77,116,21,229,163,97,182,245,202,43,177,55,216,95,52,126,37,244,210,103,211,244,23,246,73,48,153,212,86,197,25,242,132,36,82,88,112,58,12,129,27,201,65,197,200,33,10,145,105,73,184,148,68,220,42,78,37,35,197,145,39,32,18,233,9,152,39,208,168,13,72,175,122,106,169,73,152,213,247,47,206,246,122,187,153,63,121,57,192,108,94,193,134,83,105,142,221,186,183,94,51,108,165,216,199,65,209,24,115,30,185,56,65,10,218,18,6,92,240,216,239,84,8,96,84,104,141,66,80,23,155,137,7,252,18,77,99,108,99,195,148,77,36,248,227,34,102,147,203,67,40,149,224,34,138,206,167,104,57,211,147,238,122,247,54,133,183,215,203,247,94,225,31,203,211,242,83,121,54,61,158,190,91,43,47,230,162,247,166,47,211,19,47,250,181,233,145,95,127,173,44,63,252,125,94,126,91,243,203,211,242,194,35,142,202,179,121,132,127,48,22,216,223,27,11,154,202,136,136,208,129,64,229,21,137,49,133,196,134,10,100,40,181,99,130,81,231,232,109,99,65,33,143,253,111,66,128,33,212,0,87,232,79,145,101,33,40,73,153,177,86,74,110,220,111,198,194,66,56,255,151,154,187,147,159,4,168,197,49,196,7,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "a5f68bdc204442c488309965e224d704",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("75b64d44-f646-4025-b2dc-16a7526ff5fd");
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

		#region Class: ReadDataUserTask2FlowElement

		/// <exclude/>
		public class ReadDataUserTask2FlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadDataUserTask2FlowElement(UserConnection userConnection, OpportunityManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("88a9e87a-9c7c-4738-80e4-4333e355e6d1");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,100,21,219,146,44,201,61,46,91,8,148,52,208,15,10,97,9,35,105,148,152,250,43,182,76,27,140,255,123,181,246,58,13,57,148,210,91,65,7,141,164,247,230,205,155,209,124,87,141,239,171,58,224,80,122,168,71,76,166,43,87,18,7,90,235,2,29,53,153,204,41,183,80,80,37,192,82,180,142,155,34,119,232,50,70,146,22,26,44,201,134,62,186,42,144,164,10,216,140,229,237,252,155,52,12,19,38,119,126,13,62,217,7,108,224,203,57,1,32,47,188,81,146,218,52,183,148,3,42,10,142,101,20,116,206,172,115,90,115,235,201,166,69,184,130,9,46,83,42,209,196,167,185,241,20,148,20,20,60,58,157,162,50,210,228,36,169,209,135,227,207,126,192,113,172,186,182,156,241,121,255,249,169,143,42,183,220,135,174,158,154,150,36,13,6,184,129,240,80,146,130,67,42,140,7,202,68,234,40,119,145,221,120,167,168,55,66,106,144,220,51,141,36,177,208,135,51,45,57,116,109,0,27,43,29,208,227,128,173,197,23,69,101,133,65,86,136,140,42,143,209,181,76,104,170,156,75,163,220,148,57,94,40,230,92,116,205,65,128,175,80,79,184,10,155,171,8,52,185,22,169,204,124,44,17,52,229,88,228,17,152,1,213,153,54,158,73,150,123,159,239,118,127,232,186,239,83,31,173,30,175,167,6,135,202,94,250,134,177,1,221,80,206,54,42,28,186,250,76,126,253,2,176,245,231,114,249,109,243,164,94,111,206,64,178,36,211,136,135,186,194,54,28,91,219,185,170,189,95,91,183,44,17,211,244,48,84,227,238,228,241,113,130,58,26,80,221,63,252,209,241,195,52,134,174,249,223,234,77,98,173,145,38,78,235,170,249,60,204,174,26,251,26,158,214,184,36,111,30,167,46,188,187,204,193,22,144,87,160,253,145,41,4,227,34,23,148,41,174,40,231,121,74,149,102,41,69,105,172,213,10,50,41,138,11,195,146,252,123,154,219,171,241,227,143,118,255,94,155,61,167,183,241,244,213,193,205,142,46,231,191,81,182,156,118,109,167,37,174,95,30,241,119,1,41,4,0,0 })));
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
					return _aggregationColumnName ?? (_aggregationColumnName = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })));
				}
				set {
					_aggregationColumnName = value;
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

		public OpportunityManagement(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityManagement";
			SchemaUId = new Guid("a5f68bdc-2044-42c4-8830-9965e224d704");
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
				return new Guid("a5f68bdc-2044-42c4-8830-9965e224d704");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: OpportunityManagement, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: OpportunityManagement, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid CurrentOpportunity {
			get;
			set;
		}

		public virtual Guid Presentation {
			get;
			set;
		}

		public virtual Guid MainContact {
			get;
			set;
		}

		public virtual Guid Account {
			get;
			set;
		}

		public virtual bool IsStageChangedByUser {
			get;
			set;
		}

		public virtual int ClientOpportunityCount {
			get;
			set;
		}

		public virtual string OpportunityTitle {
			get;
			set;
		}

		public virtual Guid Contact {
			get;
			set;
		}

		public virtual string ClientName {
			get;
			set;
		}

		private ProcessOpportunityMangementProcess _opportunityMangementProcess;
		public ProcessOpportunityMangementProcess OpportunityMangementProcess {
			get {
				return _opportunityMangementProcess ?? ((_opportunityMangementProcess) = new ProcessOpportunityMangementProcess(UserConnection, this));
			}
		}

		private ReadOppDataFlowElement _readOppData;
		public ReadOppDataFlowElement ReadOppData {
			get {
				return _readOppData ?? (_readOppData = new ReadOppDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _opportunityStage;
		public ProcessExclusiveGateway OpportunityStage {
			get {
				return _opportunityStage ?? (_opportunityStage = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "OpportunityStage",
					SchemaElementUId = new Guid("fd6a7aba-01a4-4537-95f0-71af43bde436"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.OpportunityStage.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProspectingFlowElement _prospecting;
		public ProspectingFlowElement Prospecting {
			get {
				return _prospecting ?? ((_prospecting) = new ProspectingFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessTerminateEvent _terminate3;
		public ProcessTerminateEvent Terminate3 {
			get {
				return _terminate3 ?? (_terminate3 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate3",
					SchemaElementUId = new Guid("a754a29c-40c0-420e-941d-f2b4a941c8ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private NeedsAnalysisFlowElement _needsAnalysis;
		public NeedsAnalysisFlowElement NeedsAnalysis {
			get {
				return _needsAnalysis ?? ((_needsAnalysis) = new NeedsAnalysisFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OppManagementValuePpropositionFlowElement _oppManagementValuePproposition;
		public OppManagementValuePpropositionFlowElement OppManagementValuePproposition {
			get {
				return _oppManagementValuePproposition ?? ((_oppManagementValuePproposition) = new OppManagementValuePpropositionFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private IdDecisionMakersFlowElement _idDecisionMakers;
		public IdDecisionMakersFlowElement IdDecisionMakers {
			get {
				return _idDecisionMakers ?? ((_idDecisionMakers) = new IdDecisionMakersFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OppManagementPerceptionAnalysisFlowElement _oppManagementPerceptionAnalysis;
		public OppManagementPerceptionAnalysisFlowElement OppManagementPerceptionAnalysis {
			get {
				return _oppManagementPerceptionAnalysis ?? ((_oppManagementPerceptionAnalysis) = new OppManagementPerceptionAnalysisFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OppManagementProposalFlowElement _oppManagementProposal;
		public OppManagementProposalFlowElement OppManagementProposal {
			get {
				return _oppManagementProposal ?? ((_oppManagementProposal) = new OppManagementProposalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OppManagementNegotiationsFlowElement _oppManagementNegotiations;
		public OppManagementNegotiationsFlowElement OppManagementNegotiations {
			get {
				return _oppManagementNegotiations ?? ((_oppManagementNegotiations) = new OppManagementNegotiationsFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OppManagementContractationFlowElement _oppManagementContractation;
		public OppManagementContractationFlowElement OppManagementContractation {
			get {
				return _oppManagementContractation ?? ((_oppManagementContractation) = new OppManagementContractationFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OppManagementEndStageFlowElement _oppManagementEndStage;
		public OppManagementEndStageFlowElement OppManagementEndStage {
			get {
				return _oppManagementEndStage ?? ((_oppManagementEndStage) = new OppManagementEndStageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("4ba680da-7591-4eb5-8ede-25d1558e9149"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway2.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private FindPresentationFlowElement _findPresentation;
		public FindPresentationFlowElement FindPresentation {
			get {
				return _findPresentation ?? (_findPresentation = new FindPresentationFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _savePresentationParameter2;
		public ProcessScriptTask SavePresentationParameter2 {
			get {
				return _savePresentationParameter2 ?? (_savePresentationParameter2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SavePresentationParameter2",
					SchemaElementUId = new Guid("d8643dcc-9a0d-40a5-abbb-c08fc8ced26b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SavePresentationParameter2Execute,
				});
			}
		}

		private LinkOppToProcessFlowElement _linkOppToProcess;
		public LinkOppToProcessFlowElement LinkOppToProcess {
			get {
				return _linkOppToProcess ?? (_linkOppToProcess = new LinkOppToProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadOppMainContactFlowElement _readOppMainContact;
		public ReadOppMainContactFlowElement ReadOppMainContact {
			get {
				return _readOppMainContact ?? (_readOppMainContact = new ReadOppMainContactFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _saveMainContactParameter;
		public ProcessScriptTask SaveMainContactParameter {
			get {
				return _saveMainContactParameter ?? (_saveMainContactParameter = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SaveMainContactParameter",
					SchemaElementUId = new Guid("90ba94c4-778e-4da8-b1fa-20caa11d06b9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveMainContactParameterExecute,
				});
			}
		}

		private ProcessStartSignalEvent _startSignalLeadStageChange;
		public ProcessStartSignalEvent StartSignalLeadStageChange {
			get {
				return _startSignalLeadStageChange ?? (_startSignalLeadStageChange = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "StartSignalLeadStageChange",
					SerializeToDB = false,
					IsLogging = false,
					SchemaElementUId = new Guid("a3374f46-5620-4706-95ae-1144c8bbbf48"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway3;
		public ProcessExclusiveGateway ExclusiveGateway3 {
			get {
				return _exclusiveGateway3 ?? (_exclusiveGateway3 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway3",
					SchemaElementUId = new Guid("ef1d55e6-1755-412a-9d7c-f01d78a5edf9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway3.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessFlowElement _startOppBusinessProcess;
		public ProcessFlowElement StartOppBusinessProcess {
			get {
				return _startOppBusinessProcess ?? (_startOppBusinessProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartOppBusinessProcess",
					SchemaElementUId = new Guid("cc1b7702-073c-45cc-926b-05e107a8fd30"),
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

		private ProcessExclusiveGateway _exclusiveGateway4;
		public ProcessExclusiveGateway ExclusiveGateway4 {
			get {
				return _exclusiveGateway4 ?? (_exclusiveGateway4 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway4",
					SchemaElementUId = new Guid("69c50fcc-abf2-43ac-a9d1-e9e6ed6a5397"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway4.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessTerminateEvent _terminate4;
		public ProcessTerminateEvent Terminate4 {
			get {
				return _terminate4 ?? (_terminate4 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate4",
					SchemaElementUId = new Guid("129d65ec-f59b-44af-b1d6-cda0a6b4ff21"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("ad47ec52-76d5-44c0-b66d-9440119348ca"),
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
					SchemaElementUId = new Guid("54731090-57ce-4f13-a4f0-8398e8e5479f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask2Execute,
				});
			}
		}

		private ProcessScriptTask _storeIsStageChangedByUser;
		public ProcessScriptTask StoreIsStageChangedByUser {
			get {
				return _storeIsStageChangedByUser ?? (_storeIsStageChangedByUser = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "StoreIsStageChangedByUser",
					SchemaElementUId = new Guid("437d217c-6201-420a-a4e5-134fac88d589"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = StoreIsStageChangedByUserExecute,
				});
			}
		}

		private ProcessScriptTask _resetIsStageChangedByUser;
		public ProcessScriptTask ResetIsStageChangedByUser {
			get {
				return _resetIsStageChangedByUser ?? (_resetIsStageChangedByUser = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "ResetIsStageChangedByUser",
					SchemaElementUId = new Guid("c07da6a9-f9fc-4d1b-a11d-633a4992ae39"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ResetIsStageChangedByUserExecute,
				});
			}
		}

		private ReadDataLeadFlowElement _readDataLead;
		public ReadDataLeadFlowElement ReadDataLead {
			get {
				return _readDataLead ?? (_readDataLead = new ReadDataLeadFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataLeadFlowElement _changeDataLead;
		public ChangeDataLeadFlowElement ChangeDataLead {
			get {
				return _changeDataLead ?? (_changeDataLead = new ChangeDataLeadFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewaySetDateTimePresentation;
		public ProcessExclusiveGateway ExclusiveGatewaySetDateTimePresentation {
			get {
				return _exclusiveGatewaySetDateTimePresentation ?? (_exclusiveGatewaySetDateTimePresentation = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewaySetDateTimePresentation",
					SchemaElementUId = new Guid("f7a393e4-d550-4f6e-aba4-c4a007307258"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewaySetDateTimePresentation.Question"),
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
					SchemaElementUId = new Guid("375b9e3c-98fc-4100-83c4-c571cfe22b08"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private AddDataContactToOpportunityFlowElement _addDataContactToOpportunity;
		public AddDataContactToOpportunityFlowElement AddDataContactToOpportunity {
			get {
				return _addDataContactToOpportunity ?? (_addDataContactToOpportunity = new AddDataContactToOpportunityFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayLeadQualifiedAsContact;
		public ProcessExclusiveGateway ExclusiveGatewayLeadQualifiedAsContact {
			get {
				return _exclusiveGatewayLeadQualifiedAsContact ?? (_exclusiveGatewayLeadQualifiedAsContact = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayLeadQualifiedAsContact",
					SchemaElementUId = new Guid("c017a416-4566-4caf-89f0-cd11dc760d58"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayLeadQualifiedAsContact.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private AddDataOpportunityFlowElement _addDataOpportunity;
		public AddDataOpportunityFlowElement AddDataOpportunity {
			get {
				return _addDataOpportunity ?? (_addDataOpportunity = new AddDataOpportunityFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataCountOpportunityByAccountFlowElement _readDataCountOpportunityByAccount;
		public ReadDataCountOpportunityByAccountFlowElement ReadDataCountOpportunityByAccount {
			get {
				return _readDataCountOpportunityByAccount ?? (_readDataCountOpportunityByAccount = new ReadDataCountOpportunityByAccountFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataAccountFlowElement _readDataAccount;
		public ReadDataAccountFlowElement ReadDataAccount {
			get {
				return _readDataAccount ?? (_readDataAccount = new ReadDataAccountFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _formulaTaskAccountByLead;
		public ProcessScriptTask FormulaTaskAccountByLead {
			get {
				return _formulaTaskAccountByLead ?? (_formulaTaskAccountByLead = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTaskAccountByLead",
					SchemaElementUId = new Guid("ab3f8e00-ffa9-4079-8f2d-c9aa8b4b4826"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTaskAccountByLeadExecute,
				});
			}
		}

		private ReadDataContactFlowElement _readDataContact;
		public ReadDataContactFlowElement ReadDataContact {
			get {
				return _readDataContact ?? (_readDataContact = new ReadDataContactFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayQualifiedByAccount;
		public ProcessExclusiveGateway ExclusiveGatewayQualifiedByAccount {
			get {
				return _exclusiveGatewayQualifiedByAccount ?? (_exclusiveGatewayQualifiedByAccount = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayQualifiedByAccount",
					SchemaElementUId = new Guid("ba7fb0fc-f887-4dd2-9494-28335297b5e4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayQualifiedByAccount.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _saveCurrOppParameter;
		public ProcessScriptTask SaveCurrOppParameter {
			get {
				return _saveCurrOppParameter ?? (_saveCurrOppParameter = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SaveCurrOppParameter",
					SchemaElementUId = new Guid("0b3df41d-a31f-4753-9ad5-bb8d4c5137fb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveCurrOppParameterExecute,
				});
			}
		}

		private PresentationTaskCreationFlowElement _presentationTaskCreation;
		public PresentationTaskCreationFlowElement PresentationTaskCreation {
			get {
				return _presentationTaskCreation ?? (_presentationTaskCreation = new PresentationTaskCreationFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _savePresentationParameter;
		public ProcessScriptTask SavePresentationParameter {
			get {
				return _savePresentationParameter ?? (_savePresentationParameter = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SavePresentationParameter",
					SchemaElementUId = new Guid("a914a2b0-15d2-4c81-938d-6f3bcc01c912"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SavePresentationParameterExecute,
				});
			}
		}

		private ReadOppoortunityData2FlowElement _readOppoortunityData2;
		public ReadOppoortunityData2FlowElement ReadOppoortunityData2 {
			get {
				return _readOppoortunityData2 ?? (_readOppoortunityData2 = new ReadOppoortunityData2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddDataUserTask1FlowElement _addDataUserTask1;
		public AddDataUserTask1FlowElement AddDataUserTask1 {
			get {
				return _addDataUserTask1 ?? (_addDataUserTask1 = new AddDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("da838103-79ee-48ff-b9fb-43f5d9fb0543"),
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

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("083b1a16-96f4-434c-bd21-1e475d6a546b"),
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
					SchemaElementUId = new Guid("b120e00e-d3f2-4b09-8118-ef17c00af6bb"),
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
					SchemaElementUId = new Guid("cecd8639-1f00-4d59-b112-9fbe4de5517a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask5Execute,
				});
			}
		}

		private ProcessScriptTask _formulaTask6;
		public ProcessScriptTask FormulaTask6 {
			get {
				return _formulaTask6 ?? (_formulaTask6 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask6",
					SchemaElementUId = new Guid("d527d260-953d-4177-b84b-fd337a8b9408"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask6Execute,
				});
			}
		}

		private ProcessScriptTask _formulaTask7;
		public ProcessScriptTask FormulaTask7 {
			get {
				return _formulaTask7 ?? (_formulaTask7 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask7",
					SchemaElementUId = new Guid("e71860b5-b65b-493b-8d7c-c65ed80dc169"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask7Execute,
				});
			}
		}

		private ProcessScriptTask _formulaTask8;
		public ProcessScriptTask FormulaTask8 {
			get {
				return _formulaTask8 ?? (_formulaTask8 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask8",
					SchemaElementUId = new Guid("7727ad4d-089b-417c-acfd-d66ee83afc06"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask8Execute,
				});
			}
		}

		private ProcessScriptTask _formulaTask9;
		public ProcessScriptTask FormulaTask9 {
			get {
				return _formulaTask9 ?? (_formulaTask9 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask9",
					SchemaElementUId = new Guid("f284494f-5edb-489b-92c3-ddb20eaa0ab0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = FormulaTask9Execute,
				});
			}
		}

		private ProcessConditionalFlow _prospectingStage;
		public ProcessConditionalFlow ProspectingStage {
			get {
				return _prospectingStage ?? (_prospectingStage = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ProspectingStage",
					SchemaElementUId = new Guid("6da9cfcb-81e5-48a4-a1c1-42a6279225e6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _needAnalysisStage;
		public ProcessConditionalFlow NeedAnalysisStage {
			get {
				return _needAnalysisStage ?? (_needAnalysisStage = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "NeedAnalysisStage",
					SchemaElementUId = new Guid("9301d50a-6c5b-4489-badd-4a28230234ae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _valueProposition;
		public ProcessConditionalFlow ValueProposition {
			get {
				return _valueProposition ?? (_valueProposition = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ValueProposition",
					SchemaElementUId = new Guid("bb42fb47-5fbd-4f77-af1e-ce351db4f8f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _decisionMakers;
		public ProcessConditionalFlow DecisionMakers {
			get {
				return _decisionMakers ?? (_decisionMakers = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "DecisionMakers",
					SchemaElementUId = new Guid("f094c232-c29e-46d1-86fc-2e61dcac8e07"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _perceptionAnalysisStage;
		public ProcessConditionalFlow PerceptionAnalysisStage {
			get {
				return _perceptionAnalysisStage ?? (_perceptionAnalysisStage = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "PerceptionAnalysisStage",
					SchemaElementUId = new Guid("90dc5cd4-a514-48c4-9705-1babb54dc9a9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _negotiationsStage;
		public ProcessConditionalFlow NegotiationsStage {
			get {
				return _negotiationsStage ?? (_negotiationsStage = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "NegotiationsStage",
					SchemaElementUId = new Guid("3b93fd4b-c4ce-43ef-81de-d70f18e28cd9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _contractationStage;
		public ProcessConditionalFlow ContractationStage {
			get {
				return _contractationStage ?? (_contractationStage = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ContractationStage",
					SchemaElementUId = new Guid("97b5d2a4-5ab3-4fb5-9544-7ee6933c7e5a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _proposalStage;
		public ProcessConditionalFlow ProposalStage {
			get {
				return _proposalStage ?? (_proposalStage = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ProposalStage",
					SchemaElementUId = new Guid("94b519f4-4f88-4966-9c23-8a451496a11b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
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
					SchemaElementUId = new Guid("b131dc29-103b-498c-8cad-b0267ae02df9"),
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
					SchemaElementUId = new Guid("656a4a04-8b53-40cb-9fe2-d14c1a49db28"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow8;
		public ProcessConditionalFlow ConditionalFlow8 {
			get {
				return _conditionalFlow8 ?? (_conditionalFlow8 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow8",
					SchemaElementUId = new Guid("12da4680-7947-44ac-bce4-174e2ea3d434"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow10;
		public ProcessConditionalFlow ConditionalFlow10 {
			get {
				return _conditionalFlow10 ?? (_conditionalFlow10 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow10",
					SchemaElementUId = new Guid("fe99e954-54c6-4dbc-ae4e-724f11084d1e"),
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
					SchemaElementUId = new Guid("6f012dc4-0679-4da3-84ce-757680848a3c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow7;
		public ProcessConditionalFlow ConditionalFlow7 {
			get {
				return _conditionalFlow7 ?? (_conditionalFlow7 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow7",
					SchemaElementUId = new Guid("e1fae17b-971d-469e-82c9-0d8f1161f09b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow11;
		public ProcessConditionalFlow ConditionalFlow11 {
			get {
				return _conditionalFlow11 ?? (_conditionalFlow11 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow11",
					SchemaElementUId = new Guid("aff117cc-494a-447b-824c-ea45bf0c048a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow12;
		public ProcessConditionalFlow ConditionalFlow12 {
			get {
				return _conditionalFlow12 ?? (_conditionalFlow12 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow12",
					SchemaElementUId = new Guid("b3fa892c-1d0a-4e76-a01e-553b47b9714a"),
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
					SchemaElementUId = new Guid("483624cb-e100-4417-b0d7-2d89990301bc"),
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
					SchemaElementUId = new Guid("e9f42fb2-6bda-464a-8a5a-cfb4b9ca50b1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _opportunityStageProspectingToken;
		public ProcessToken OpportunityStageProspectingToken {
			get {
				return _opportunityStageProspectingToken ?? (_opportunityStageProspectingToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageProspectingToken",
					SchemaElementUId = new Guid("c395622a-ac35-46b1-aea4-ad621f85fb34"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageNeedsAnalysisToken;
		public ProcessToken OpportunityStageNeedsAnalysisToken {
			get {
				return _opportunityStageNeedsAnalysisToken ?? (_opportunityStageNeedsAnalysisToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageNeedsAnalysisToken",
					SchemaElementUId = new Guid("fde9aee8-e98b-4a76-bd09-de70ca0b169b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageOppManagementValuePpropositionToken;
		public ProcessToken OpportunityStageOppManagementValuePpropositionToken {
			get {
				return _opportunityStageOppManagementValuePpropositionToken ?? (_opportunityStageOppManagementValuePpropositionToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageOppManagementValuePpropositionToken",
					SchemaElementUId = new Guid("980f6433-0b3e-424b-9dc9-d7edfaa724a1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageIdDecisionMakersToken;
		public ProcessToken OpportunityStageIdDecisionMakersToken {
			get {
				return _opportunityStageIdDecisionMakersToken ?? (_opportunityStageIdDecisionMakersToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageIdDecisionMakersToken",
					SchemaElementUId = new Guid("33adacb2-3580-4698-9d53-76584190d072"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageOppManagementPerceptionAnalysisToken;
		public ProcessToken OpportunityStageOppManagementPerceptionAnalysisToken {
			get {
				return _opportunityStageOppManagementPerceptionAnalysisToken ?? (_opportunityStageOppManagementPerceptionAnalysisToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageOppManagementPerceptionAnalysisToken",
					SchemaElementUId = new Guid("3986a51c-ec7f-42e3-817f-6408010784b2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageOppManagementProposalToken;
		public ProcessToken OpportunityStageOppManagementProposalToken {
			get {
				return _opportunityStageOppManagementProposalToken ?? (_opportunityStageOppManagementProposalToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageOppManagementProposalToken",
					SchemaElementUId = new Guid("8b74b380-091c-4a65-ba30-5e6ee8cb1323"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageOppManagementNegotiationsToken;
		public ProcessToken OpportunityStageOppManagementNegotiationsToken {
			get {
				return _opportunityStageOppManagementNegotiationsToken ?? (_opportunityStageOppManagementNegotiationsToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageOppManagementNegotiationsToken",
					SchemaElementUId = new Guid("50180ccb-c2d2-4f35-a992-01257f299f13"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _opportunityStageOppManagementContractationToken;
		public ProcessToken OpportunityStageOppManagementContractationToken {
			get {
				return _opportunityStageOppManagementContractationToken ?? (_opportunityStageOppManagementContractationToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "OpportunityStageOppManagementContractationToken",
					SchemaElementUId = new Guid("dfce3ae2-1f94-4b73-ab97-617397f01650"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _storeIsStageChangedByUserOppManagementEndStageToken;
		public ProcessToken StoreIsStageChangedByUserOppManagementEndStageToken {
			get {
				return _storeIsStageChangedByUserOppManagementEndStageToken ?? (_storeIsStageChangedByUserOppManagementEndStageToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "StoreIsStageChangedByUserOppManagementEndStageToken",
					SchemaElementUId = new Guid("16679216-6a44-41b6-873e-591155004316"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ReadOppData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadOppData };
			FlowElements[OpportunityStage.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStage };
			FlowElements[Prospecting.SchemaElementUId] = new Collection<ProcessFlowElement> { Prospecting };
			FlowElements[Terminate3.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate3 };
			FlowElements[NeedsAnalysis.SchemaElementUId] = new Collection<ProcessFlowElement> { NeedsAnalysis };
			FlowElements[OppManagementValuePproposition.SchemaElementUId] = new Collection<ProcessFlowElement> { OppManagementValuePproposition };
			FlowElements[IdDecisionMakers.SchemaElementUId] = new Collection<ProcessFlowElement> { IdDecisionMakers };
			FlowElements[OppManagementPerceptionAnalysis.SchemaElementUId] = new Collection<ProcessFlowElement> { OppManagementPerceptionAnalysis };
			FlowElements[OppManagementProposal.SchemaElementUId] = new Collection<ProcessFlowElement> { OppManagementProposal };
			FlowElements[OppManagementNegotiations.SchemaElementUId] = new Collection<ProcessFlowElement> { OppManagementNegotiations };
			FlowElements[OppManagementContractation.SchemaElementUId] = new Collection<ProcessFlowElement> { OppManagementContractation };
			FlowElements[OppManagementEndStage.SchemaElementUId] = new Collection<ProcessFlowElement> { OppManagementEndStage };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[FindPresentation.SchemaElementUId] = new Collection<ProcessFlowElement> { FindPresentation };
			FlowElements[SavePresentationParameter2.SchemaElementUId] = new Collection<ProcessFlowElement> { SavePresentationParameter2 };
			FlowElements[LinkOppToProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { LinkOppToProcess };
			FlowElements[ReadOppMainContact.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadOppMainContact };
			FlowElements[SaveMainContactParameter.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveMainContactParameter };
			FlowElements[StartSignalLeadStageChange.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignalLeadStageChange };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
			FlowElements[StartOppBusinessProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { StartOppBusinessProcess };
			FlowElements[OpenEditPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask1 };
			FlowElements[ExclusiveGateway4.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway4 };
			FlowElements[Terminate4.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate4 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
			FlowElements[StoreIsStageChangedByUser.SchemaElementUId] = new Collection<ProcessFlowElement> { StoreIsStageChangedByUser };
			FlowElements[ResetIsStageChangedByUser.SchemaElementUId] = new Collection<ProcessFlowElement> { ResetIsStageChangedByUser };
			FlowElements[ReadDataLead.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataLead };
			FlowElements[ChangeDataLead.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataLead };
			FlowElements[ExclusiveGatewaySetDateTimePresentation.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewaySetDateTimePresentation };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
			FlowElements[AddDataContactToOpportunity.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataContactToOpportunity };
			FlowElements[ExclusiveGatewayLeadQualifiedAsContact.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayLeadQualifiedAsContact };
			FlowElements[AddDataOpportunity.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataOpportunity };
			FlowElements[ReadDataCountOpportunityByAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataCountOpportunityByAccount };
			FlowElements[ReadDataAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataAccount };
			FlowElements[FormulaTaskAccountByLead.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTaskAccountByLead };
			FlowElements[ReadDataContact.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataContact };
			FlowElements[ExclusiveGatewayQualifiedByAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayQualifiedByAccount };
			FlowElements[SaveCurrOppParameter.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveCurrOppParameter };
			FlowElements[PresentationTaskCreation.SchemaElementUId] = new Collection<ProcessFlowElement> { PresentationTaskCreation };
			FlowElements[SavePresentationParameter.SchemaElementUId] = new Collection<ProcessFlowElement> { SavePresentationParameter };
			FlowElements[ReadOppoortunityData2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadOppoortunityData2 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[FormulaTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask3 };
			FlowElements[FormulaTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask4 };
			FlowElements[FormulaTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask5 };
			FlowElements[FormulaTask6.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask6 };
			FlowElements[FormulaTask7.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask7 };
			FlowElements[FormulaTask8.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask8 };
			FlowElements[FormulaTask9.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask9 };
			FlowElements[OpportunityStageProspectingToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageProspectingToken };
			FlowElements[OpportunityStageNeedsAnalysisToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageNeedsAnalysisToken };
			FlowElements[OpportunityStageOppManagementValuePpropositionToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageOppManagementValuePpropositionToken };
			FlowElements[OpportunityStageIdDecisionMakersToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageIdDecisionMakersToken };
			FlowElements[OpportunityStageOppManagementPerceptionAnalysisToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageOppManagementPerceptionAnalysisToken };
			FlowElements[OpportunityStageOppManagementProposalToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageOppManagementProposalToken };
			FlowElements[OpportunityStageOppManagementNegotiationsToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageOppManagementNegotiationsToken };
			FlowElements[OpportunityStageOppManagementContractationToken.SchemaElementUId] = new Collection<ProcessFlowElement> { OpportunityStageOppManagementContractationToken };
			FlowElements[StoreIsStageChangedByUserOppManagementEndStageToken.SchemaElementUId] = new Collection<ProcessFlowElement> { StoreIsStageChangedByUserOppManagementEndStageToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ReadOppData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOppMainContact", e.Context.SenderName));
						break;
					case "OpportunityStage":
						if (ProspectingStageExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageProspectingToken", e.Context.SenderName));
							break;
						}
						if (NeedAnalysisStageExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageNeedsAnalysisToken", e.Context.SenderName));
							break;
						}
						if (ValuePropositionExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageOppManagementValuePpropositionToken", e.Context.SenderName));
							break;
						}
						if (DecisionMakersExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageIdDecisionMakersToken", e.Context.SenderName));
							break;
						}
						if (PerceptionAnalysisStageExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageOppManagementPerceptionAnalysisToken", e.Context.SenderName));
							break;
						}
						if (NegotiationsStageExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageOppManagementNegotiationsToken", e.Context.SenderName));
							break;
						}
						if (ContractationStageExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageOppManagementContractationToken", e.Context.SenderName));
							break;
						}
						if (ProposalStageExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStageOppManagementProposalToken", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate3", e.Context.SenderName));
						break;
					case "Prospecting":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "Terminate3":
						CompleteProcess();
						break;
					case "NeedsAnalysis":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "OppManagementValuePproposition":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
						break;
					case "IdDecisionMakers":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "OppManagementPerceptionAnalysis":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "OppManagementProposal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "OppManagementNegotiations":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "OppManagementContractation":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate3", e.Context.SenderName));
						break;
					case "OppManagementEndStage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOppData", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FindPresentation", e.Context.SenderName));
						break;
					case "FindPresentation":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkOppToProcess", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SavePresentationParameter2", e.Context.SenderName));
						break;
					case "SavePresentationParameter2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkOppToProcess", e.Context.SenderName));
						break;
					case "LinkOppToProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOppData", e.Context.SenderName));
						break;
					case "ReadOppMainContact":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveMainContactParameter", e.Context.SenderName));
						break;
					case "SaveMainContactParameter":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ResetIsStageChangedByUser", e.Context.SenderName));
						break;
					case "StartSignalLeadStageChange":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalFlow11ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataLead", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "StartOppBusinessProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "OpenEditPageUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway4", e.Context.SenderName));
						break;
					case "ExclusiveGateway4":
						if (ConditionalFlow12ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate4", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "Terminate4":
						CompleteProcess();
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkOppToProcess", e.Context.SenderName));
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUser", e.Context.SenderName));
						break;
					case "StoreIsStageChangedByUser":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("StoreIsStageChangedByUserOppManagementEndStageToken", e.Context.SenderName));
						break;
					case "ResetIsStageChangedByUser":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpportunityStage", e.Context.SenderName));
						break;
					case "ReadDataLead":
						if (ConditionalFlow7ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayQualifiedByAccount", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "ChangeDataLead":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewaySetDateTimePresentation", e.Context.SenderName));
						break;
					case "ExclusiveGatewaySetDateTimePresentation":
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PresentationTaskCreation", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveCurrOppParameter", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
					case "AddDataContactToOpportunity":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOppoortunityData2", e.Context.SenderName));
						break;
					case "ExclusiveGatewayLeadQualifiedAsContact":
						if (ConditionalFlow10ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataContactToOpportunity", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOppoortunityData2", e.Context.SenderName));
						break;
					case "AddDataOpportunity":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayLeadQualifiedAsContact", e.Context.SenderName));
						break;
					case "ReadDataCountOpportunityByAccount":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask4", e.Context.SenderName));
						break;
					case "ReadDataAccount":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask5", e.Context.SenderName));
						break;
					case "FormulaTaskAccountByLead":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataAccount", e.Context.SenderName));
						break;
					case "ReadDataContact":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask6", e.Context.SenderName));
						break;
					case "ExclusiveGatewayQualifiedByAccount":
						if (ConditionalFlow8ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTaskAccountByLead", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "SaveCurrOppParameter":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "PresentationTaskCreation":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SavePresentationParameter", e.Context.SenderName));
						break;
					case "SavePresentationParameter":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveCurrOppParameter", e.Context.SenderName));
						break;
					case "ReadOppoortunityData2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataLead", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkOppToProcess", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkOppToProcess", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow5ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask7", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
						break;
					case "FormulaTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask8", e.Context.SenderName));
						break;
					case "FormulaTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask9", e.Context.SenderName));
						break;
					case "FormulaTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataCountOpportunityByAccount", e.Context.SenderName));
						break;
					case "FormulaTask6":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "FormulaTask7":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataContact", e.Context.SenderName));
						break;
					case "FormulaTask8":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataOpportunity", e.Context.SenderName));
						break;
					case "FormulaTask9":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataOpportunity", e.Context.SenderName));
						break;
					case "OpportunityStageProspectingToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Prospecting", e.Context.SenderName));
						break;
					case "OpportunityStageNeedsAnalysisToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("NeedsAnalysis", e.Context.SenderName));
						break;
					case "OpportunityStageOppManagementValuePpropositionToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OppManagementValuePproposition", e.Context.SenderName));
						break;
					case "OpportunityStageIdDecisionMakersToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IdDecisionMakers", e.Context.SenderName));
						break;
					case "OpportunityStageOppManagementPerceptionAnalysisToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OppManagementPerceptionAnalysis", e.Context.SenderName));
						break;
					case "OpportunityStageOppManagementProposalToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OppManagementProposal", e.Context.SenderName));
						break;
					case "OpportunityStageOppManagementNegotiationsToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OppManagementNegotiations", e.Context.SenderName));
						break;
					case "OpportunityStageOppManagementContractationToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OppManagementContractation", e.Context.SenderName));
						break;
					case "StoreIsStageChangedByUserOppManagementEndStageToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OppManagementEndStage", e.Context.SenderName));
						break;
			}
		}

		private bool ProspectingStageExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("c2067b11-0ee0-df11-971b-001d60e938c6"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "ProspectingStage", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"c2067b11-0ee0-df11-971b-001d60e938c6\")", result);
			return result;
		}

		private bool NeedAnalysisStageExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("2a6de0f7-44d9-4b8a-bce6-acddb7ed8915"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "NeedAnalysisStage", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"2a6de0f7-44d9-4b8a-bce6-acddb7ed8915\")", result);
			return result;
		}

		private bool ValuePropositionExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("325f0619-0ee0-df11-971b-001d60e938c6"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "ValueProposition", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"325f0619-0ee0-df11-971b-001d60e938c6\")", result);
			return result;
		}

		private bool DecisionMakersExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("f4e4a00b-ec48-46d0-9ea0-c2b502165ee9"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "DecisionMakers", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"f4e4a00b-ec48-46d0-9ea0-c2b502165ee9\")", result);
			return result;
		}

		private bool PerceptionAnalysisStageExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("241ade6b-4256-4947-ba8a-7d96988a97b6"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "PerceptionAnalysisStage", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"241ade6b-4256-4947-ba8a-7d96988a97b6\")", result);
			return result;
		}

		private bool NegotiationsStageExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("f808c955-c5aa-4aba-95c0-ba7d584d2f32"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "NegotiationsStage", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"f808c955-c5aa-4aba-95c0-ba7d584d2f32\")", result);
			return result;
		}

		private bool ContractationStageExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("fb563df2-5ae6-df11-971b-001d60e938c6"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "ContractationStage", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"fb563df2-5ae6-df11-971b-001d60e938c6\")", result);
			return result;
		}

		private bool ProposalStageExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Stage").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("StageId") : Guid.Empty))==new Guid("423774cb-5ae6-df11-971b-001d60e938c6"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpportunityStage", "ProposalStage", "((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName(\"Stage\").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>(\"StageId\") : Guid.Empty))==new Guid(\"423774cb-5ae6-df11-971b-001d60e938c6\")", result);
			return result;
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((CurrentOpportunity) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalFlow1", "(CurrentOpportunity) == Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((FindPresentation.ResultEntityCollection).Count == 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "FindPresentation", "ConditionalFlow2", "(FindPresentation.ResultEntityCollection).Count == 0", result);
			return result;
		}

		private bool ConditionalFlow8ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayQualifiedByAccount", "ConditionalFlow8", "((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName(\"QualifiedAccount\").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>(\"QualifiedAccountId\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow10ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty)) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayLeadQualifiedAsContact", "ConditionalFlow10", "((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName(\"QualifiedContact\").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>(\"QualifiedContactId\") : Guid.Empty)) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("MeetingDate").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>("MeetingDate") : DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))) != null && !DateTime.MinValue.Equals(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("MeetingDate").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>("MeetingDate") : DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture)))));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewaySetDateTimePresentation", "ConditionalFlow4", "((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName(\"MeetingDate\").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>(\"MeetingDate\") : DateTime.ParseExact(\"01.01.0001 0:00\", \"dd.MM.yyyy H:mm\", CultureInfo.InvariantCulture))) != null && !DateTime.MinValue.Equals(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName(\"MeetingDate\").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<DateTime>(\"MeetingDate\") : DateTime.ParseExact(\"01.01.0001 0:00\", \"dd.MM.yyyy H:mm\", CultureInfo.InvariantCulture))))", result);
			return result;
		}

		private bool ConditionalFlow7ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("Opportunity").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("OpportunityId") : Guid.Empty)) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataLead", "ConditionalFlow7", "((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName(\"Opportunity\").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>(\"OpportunityId\") : Guid.Empty)) == Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow11ExpressionExecute() {
			bool result = Convert.ToBoolean(((Boolean)SysSettings.GetValue(UserConnection, "StartOppBusinessProcess")) == true);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalFlow11", "((Boolean)SysSettings.GetValue(UserConnection, \"StartOppBusinessProcess\")) == true", result);
			return result;
		}

		private bool ConditionalFlow12ExpressionExecute() {
			bool result = Convert.ToBoolean((OpenEditPageUserTask1.RecordId) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway4", "ConditionalFlow12", "(OpenEditPageUserTask1.RecordId) == Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadDataUserTask1.ResultCount) == 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadDataUserTask1", "ConditionalFlow3", "(ReadDataUserTask1.ResultCount) == 0", result);
			return result;
		}

		private bool ConditionalFlow5ExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty))  != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow5", "((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName(\"QualifiedContact\").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>(\"QualifiedContactId\") : Guid.Empty))  != Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CurrentOpportunity")) {
				writer.WriteValue("CurrentOpportunity", CurrentOpportunity, Guid.Empty);
			}
			if (!HasMapping("Presentation")) {
				writer.WriteValue("Presentation", Presentation, Guid.Empty);
			}
			if (!HasMapping("MainContact")) {
				writer.WriteValue("MainContact", MainContact, Guid.Empty);
			}
			if (!HasMapping("Account")) {
				writer.WriteValue("Account", Account, Guid.Empty);
			}
			if (!HasMapping("IsStageChangedByUser")) {
				writer.WriteValue("IsStageChangedByUser", IsStageChangedByUser, false);
			}
			if (!HasMapping("ClientOpportunityCount")) {
				writer.WriteValue("ClientOpportunityCount", ClientOpportunityCount, 0);
			}
			if (!HasMapping("OpportunityTitle")) {
				writer.WriteValue("OpportunityTitle", OpportunityTitle, null);
			}
			if (!HasMapping("Contact")) {
				writer.WriteValue("Contact", Contact, Guid.Empty);
			}
			if (!HasMapping("ClientName")) {
				writer.WriteValue("ClientName", ClientName, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartOppBusinessProcess", string.Empty));
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
			MetaPathParameterValues.Add("af8eea9e-0e11-426e-a870-2cff33d00f84", () => CurrentOpportunity);
			MetaPathParameterValues.Add("0eae6fcc-65b6-433e-b4dc-e42323c488c1", () => Presentation);
			MetaPathParameterValues.Add("b8d6c762-b63e-49b7-b651-c8d29f9c8d74", () => MainContact);
			MetaPathParameterValues.Add("342aec56-8359-4c5b-826b-9e8489fd6a4b", () => Account);
			MetaPathParameterValues.Add("9786c0e4-cc5f-4c9f-b46d-090a297e2b74", () => IsStageChangedByUser);
			MetaPathParameterValues.Add("02b1469d-72ad-4909-a7cf-6b41b79d41a7", () => ClientOpportunityCount);
			MetaPathParameterValues.Add("738ceb61-832b-4b27-a973-9347e26e827e", () => OpportunityTitle);
			MetaPathParameterValues.Add("b6534525-3848-4420-8930-e7bcc98a1756", () => Contact);
			MetaPathParameterValues.Add("b2b54e53-5309-4650-ac67-b8a4705d22b4", () => ClientName);
			MetaPathParameterValues.Add("378a7c4d-c2ae-4dc0-8450-7d00de21889a", () => ReadOppData.DataSourceFilters);
			MetaPathParameterValues.Add("09ca5d94-4475-494b-bb1d-1711734825d0", () => ReadOppData.ResultType);
			MetaPathParameterValues.Add("809504a0-92ba-4c37-9223-2bd86178ceeb", () => ReadOppData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("47e4b981-ae34-43d6-80d1-541eb76f8886", () => ReadOppData.NumberOfRecords);
			MetaPathParameterValues.Add("093cfd0d-3919-4594-bdbd-243b89c2421c", () => ReadOppData.FunctionType);
			MetaPathParameterValues.Add("99a55b65-320e-4a00-a443-906ccbd17195", () => ReadOppData.AggregationColumnName);
			MetaPathParameterValues.Add("ea0a8aa9-15cc-4e7b-b857-0fde66046c9d", () => ReadOppData.OrderInfo);
			MetaPathParameterValues.Add("61d6f451-48d9-4c96-917b-f6c5ce85df83", () => ReadOppData.ResultEntity);
			MetaPathParameterValues.Add("10ddcd85-ccf7-42e5-8390-78074cc70ded", () => ReadOppData.ResultCount);
			MetaPathParameterValues.Add("c1248569-3f8c-43f3-9cb3-48975e8f84ef", () => ReadOppData.ResultIntegerFunction);
			MetaPathParameterValues.Add("3feedf55-86a5-4ac5-bb7d-a85d1a84eb9d", () => ReadOppData.ResultFloatFunction);
			MetaPathParameterValues.Add("734b2f72-a22c-41d7-900f-06d5bb7faf75", () => ReadOppData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("d60364bd-0961-431f-8a33-c5f616c3de09", () => ReadOppData.ResultRowsCount);
			MetaPathParameterValues.Add("5fc444a5-9b7a-422c-8693-86213fa317e7", () => ReadOppData.CanReadUncommitedData);
			MetaPathParameterValues.Add("e4513fe5-860a-4300-889d-38b3328e8894", () => ReadOppData.ResultEntityCollection);
			MetaPathParameterValues.Add("adee94c3-29c5-4b7a-960c-20c6b71d3afb", () => ReadOppData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("454dc5b0-a0d3-4a3d-b852-62380501a11c", () => ReadOppData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("e7de2a0e-3600-4ca1-96eb-0f73a4d25ddb", () => ReadOppData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("4dd88c3e-d496-44ef-93cf-f7f2ff5710a5", () => ReadOppData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("81432db0-f5f5-40d1-8f22-4d8c3bb4cf48", () => Prospecting.CurrentOpportunity);
			MetaPathParameterValues.Add("eb29a402-5da5-4f9b-844c-e79f4e1f115a", () => Prospecting.OpportunityStageChanged);
			MetaPathParameterValues.Add("fdc628cc-1da4-4b5d-b397-d6c93e1e9517", () => Prospecting.MainContact);
			MetaPathParameterValues.Add("5b443132-caa7-4f82-80dd-cc84a5380caa", () => NeedsAnalysis.CurrentOpportunity);
			MetaPathParameterValues.Add("6a80392b-c787-4788-a532-fca2370b3840", () => NeedsAnalysis.OpportunityStageChanged);
			MetaPathParameterValues.Add("5e47a6d3-f9bb-404f-87e2-aed31c62acc3", () => NeedsAnalysis.MainContact);
			MetaPathParameterValues.Add("4274528b-203f-43bc-87d3-abf86b9a792e", () => OppManagementValuePproposition.CurrentOpportunity);
			MetaPathParameterValues.Add("b20705a6-a8bc-460d-8389-aaaa9b58be16", () => OppManagementValuePproposition.OpportunityStageChanged);
			MetaPathParameterValues.Add("f7d5c580-2ff1-4209-a013-2bef80d7f3a9", () => OppManagementValuePproposition.Presentation);
			MetaPathParameterValues.Add("2a0e89a7-92f6-4cf6-a9f2-a0140105ba95", () => OppManagementValuePproposition.MainContact);
			MetaPathParameterValues.Add("76602486-f8b8-47cb-8b9f-d00841250f90", () => IdDecisionMakers.CurrentOpportunity);
			MetaPathParameterValues.Add("e6028b5e-002d-4bc7-bc34-8affd537f00c", () => IdDecisionMakers.OpportunityStageChanged);
			MetaPathParameterValues.Add("5dc6ce94-0fc5-4ffa-8e00-83c67ce5da35", () => IdDecisionMakers.MainContact);
			MetaPathParameterValues.Add("c647b290-fae9-4f2f-b291-b94262f923dc", () => OppManagementPerceptionAnalysis.CurrentOpportunity);
			MetaPathParameterValues.Add("2d34fbe8-274b-4c6e-88d8-7307f538cfee", () => OppManagementPerceptionAnalysis.OpportunityStageChanged);
			MetaPathParameterValues.Add("36230419-640f-4176-ad85-8beca7d791ca", () => OppManagementPerceptionAnalysis.MainContact);
			MetaPathParameterValues.Add("0a768934-39e6-4d8e-9fd4-4859b59f0779", () => OppManagementProposal.CurrentOpportunity);
			MetaPathParameterValues.Add("2902276d-abfd-4fd2-b6f9-b5bda02f0222", () => OppManagementProposal.OpportunityStageChanged);
			MetaPathParameterValues.Add("dc02a11c-a24c-4451-897b-9dce3a6a7178", () => OppManagementProposal.MainContact);
			MetaPathParameterValues.Add("f58812eb-a5a3-43ef-84a7-454b69c3aaed", () => OppManagementNegotiations.CurrentOpportunity);
			MetaPathParameterValues.Add("33eb9e90-615e-412b-86bf-8d9f6c8831a8", () => OppManagementNegotiations.OpportunityStageChanged);
			MetaPathParameterValues.Add("47d1669f-a6cc-48ac-85b8-94795d69938e", () => OppManagementNegotiations.MainContact);
			MetaPathParameterValues.Add("a2600d6c-144b-4c75-acb3-f04cb1577884", () => OppManagementContractation.CurrentOpportunity);
			MetaPathParameterValues.Add("16815d2d-6357-4be4-9265-46e9a99e093b", () => OppManagementContractation.OpportunityStageChanged);
			MetaPathParameterValues.Add("b812d4a7-16f1-4a13-b2e9-f0b2c48a8532", () => OppManagementContractation.MainContact);
			MetaPathParameterValues.Add("1494d351-8b28-4d15-a088-912b8872f732", () => OppManagementEndStage.CurrentOpportunity);
			MetaPathParameterValues.Add("0fa7431c-1004-411e-ae2e-b485fc040737", () => OppManagementEndStage.NextOpportunityStageNumber);
			MetaPathParameterValues.Add("dcb46392-5cd0-43ba-9004-211ef9690ca5", () => OppManagementEndStage.CurrentStage);
			MetaPathParameterValues.Add("9c2d0712-831e-499c-a94b-562db3eaed86", () => OppManagementEndStage.Recommendation);
			MetaPathParameterValues.Add("2f2941be-b24c-4797-8b31-addbd6057927", () => OppManagementEndStage.IsStageChangedByUser);
			MetaPathParameterValues.Add("ef2201a2-720c-453d-8a5b-62d5077c6041", () => OppManagementEndStage.DontShowPageEndOfStage);
			MetaPathParameterValues.Add("a8f664f6-40f1-4b7e-9602-25265d8962b3", () => OppManagementEndStage.NextStage);
			MetaPathParameterValues.Add("590098f3-05ec-4bc7-ac56-18d861124c44", () => FindPresentation.DataSourceFilters);
			MetaPathParameterValues.Add("d7349ecf-3808-499e-94e5-a6af0b6c8059", () => FindPresentation.ResultType);
			MetaPathParameterValues.Add("3ddba6f3-67f9-46a5-bda4-c9be1d38263b", () => FindPresentation.ReadSomeTopRecords);
			MetaPathParameterValues.Add("7711d045-dde7-4665-b251-2b6cda4ba16c", () => FindPresentation.NumberOfRecords);
			MetaPathParameterValues.Add("14ac52bb-d8de-4e93-ba14-2092314ad9ec", () => FindPresentation.FunctionType);
			MetaPathParameterValues.Add("44ef2079-3350-48f5-8417-a062c43f2a0e", () => FindPresentation.AggregationColumnName);
			MetaPathParameterValues.Add("f79b49c3-44b7-458a-af53-ffc25ba8de44", () => FindPresentation.OrderInfo);
			MetaPathParameterValues.Add("bcd38317-a882-4317-8881-b21b8f0ca57b", () => FindPresentation.ResultEntity);
			MetaPathParameterValues.Add("9371b699-8ba0-411a-be54-7912877edf8f", () => FindPresentation.ResultCount);
			MetaPathParameterValues.Add("ca81fffe-20a5-46bf-ab20-5fa6f0638a5f", () => FindPresentation.ResultIntegerFunction);
			MetaPathParameterValues.Add("6c987b70-a95f-48b9-bcfb-8ddc2192e44a", () => FindPresentation.ResultFloatFunction);
			MetaPathParameterValues.Add("e64f2c49-b461-45e7-bb8f-1f660acca3cc", () => FindPresentation.ResultDateTimeFunction);
			MetaPathParameterValues.Add("b598adf2-e516-42e9-9f34-f99fb251a690", () => FindPresentation.ResultRowsCount);
			MetaPathParameterValues.Add("5b343947-0aa5-4776-9b18-096d905e7603", () => FindPresentation.CanReadUncommitedData);
			MetaPathParameterValues.Add("6f8cde56-f764-4ad1-b528-0d9031cd1e8e", () => FindPresentation.ResultEntityCollection);
			MetaPathParameterValues.Add("6351aab6-3117-48e1-afe4-c9ad827a53d7", () => FindPresentation.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("1fbf3104-1357-48ca-926e-2f85305a4602", () => FindPresentation.IgnoreDisplayValues);
			MetaPathParameterValues.Add("6997cffd-7ec0-4409-93a0-9a20046659ca", () => FindPresentation.ResultCompositeObjectList);
			MetaPathParameterValues.Add("3d06393e-9ac6-4e4e-966e-ddc4dff244dd", () => FindPresentation.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("41befda8-dd24-45a3-8e91-5fa9d9e03fa0", () => LinkOppToProcess.EntityId);
			MetaPathParameterValues.Add("773490bc-4ab0-4078-9f03-a0ead61c8e69", () => LinkOppToProcess.EntitySchemaId);
			MetaPathParameterValues.Add("6ec44add-c3cb-4c83-aa2a-21116fe737ce", () => ReadOppMainContact.DataSourceFilters);
			MetaPathParameterValues.Add("d00d1284-6858-4e40-8c5e-a0f9533fcf07", () => ReadOppMainContact.ResultType);
			MetaPathParameterValues.Add("b0d4d59f-c216-40cc-ae96-8a3781c09399", () => ReadOppMainContact.ReadSomeTopRecords);
			MetaPathParameterValues.Add("e0d7bbe7-f11e-455f-b2e5-ea58c2f931f5", () => ReadOppMainContact.NumberOfRecords);
			MetaPathParameterValues.Add("c886b18d-6796-4aed-9bbf-b5cf5d06a8fb", () => ReadOppMainContact.FunctionType);
			MetaPathParameterValues.Add("57ed4753-40aa-4155-9040-01d05641a1f9", () => ReadOppMainContact.AggregationColumnName);
			MetaPathParameterValues.Add("5f7ffe6c-b419-41a7-92a7-41c7106f2edd", () => ReadOppMainContact.OrderInfo);
			MetaPathParameterValues.Add("7e1be2d8-91ed-49a9-b295-80136f24d052", () => ReadOppMainContact.ResultEntity);
			MetaPathParameterValues.Add("57df5b20-4163-4583-a743-b3bd41e7476c", () => ReadOppMainContact.ResultCount);
			MetaPathParameterValues.Add("36a1459d-8951-4d2d-83c0-ce1785ad17d6", () => ReadOppMainContact.ResultIntegerFunction);
			MetaPathParameterValues.Add("5227d4a1-7e1a-488c-b08f-249e8af25b4f", () => ReadOppMainContact.ResultFloatFunction);
			MetaPathParameterValues.Add("26f8e2e7-d0a5-4cce-a1c4-005d27eac4ef", () => ReadOppMainContact.ResultDateTimeFunction);
			MetaPathParameterValues.Add("a91ced74-aa15-4fc9-ad90-beb2c4848a91", () => ReadOppMainContact.ResultRowsCount);
			MetaPathParameterValues.Add("0597c0d4-7fe9-438b-996d-a1cec2485907", () => ReadOppMainContact.CanReadUncommitedData);
			MetaPathParameterValues.Add("24109401-bfc2-4470-b36d-6264dd15b451", () => ReadOppMainContact.ResultEntityCollection);
			MetaPathParameterValues.Add("213f4da0-dbd4-4801-9f20-61ad02c52c1a", () => ReadOppMainContact.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("14eb509a-8789-4d60-a6db-802311455631", () => ReadOppMainContact.IgnoreDisplayValues);
			MetaPathParameterValues.Add("abddd3f0-9e80-4557-bd19-1eb3675204b1", () => ReadOppMainContact.ResultCompositeObjectList);
			MetaPathParameterValues.Add("ef1a0a6c-c921-4ec2-a56c-e573429c544a", () => ReadOppMainContact.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("db9eb8c4-a431-4aa1-9ee4-580f6ffe1896", () => StartSignalLeadStageChange.RecordId);
			MetaPathParameterValues.Add("e33c0cfe-adc7-4b51-8f8f-370d3a2a3f3d", () => StartSignalLeadStageChange.EntitySchemaUId);
			MetaPathParameterValues.Add("89651dda-ab13-4a9a-8a6c-4c658eb62d6b", () => OpenEditPageUserTask1.ObjectSchemaId);
			MetaPathParameterValues.Add("26dd7e96-d79a-4c1d-a31a-e8388a3d205d", () => OpenEditPageUserTask1.PageSchemaId);
			MetaPathParameterValues.Add("816e7c8a-2c10-4a6f-9be0-35eb9c4ddff5", () => OpenEditPageUserTask1.EditMode);
			MetaPathParameterValues.Add("97a322a9-f1ca-49d6-ab97-756349dc65dc", () => OpenEditPageUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("c5f0d6a4-d18b-446e-8335-18fb080f660a", () => OpenEditPageUserTask1.RecordId);
			MetaPathParameterValues.Add("dc433afb-dfc9-4098-97f6-caf21a16f74e", () => OpenEditPageUserTask1.ExecutedMode);
			MetaPathParameterValues.Add("1c82493a-8e96-4e42-8e59-0050ff57ccc6", () => OpenEditPageUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("933618d4-76fc-43ac-ac72-94ef456a3325", () => OpenEditPageUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("0e24948f-5ffc-48eb-8cd6-6290a4458b50", () => OpenEditPageUserTask1.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("41355bca-971c-4003-990e-8da96ce29d27", () => OpenEditPageUserTask1.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("b8971ff1-f4b5-4bd1-ad83-92a56940fda8", () => OpenEditPageUserTask1.ResultParameter);
			MetaPathParameterValues.Add("6399efc5-9d36-4c8d-84c5-3e5851db8ea2", () => OpenEditPageUserTask1.IsReexecution);
			MetaPathParameterValues.Add("c482b777-a1a7-41d8-86f3-3deb50dd0ff8", () => OpenEditPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("8a4540f5-5964-49f6-9dd1-077938701455", () => OpenEditPageUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("4960bd57-b2f9-45a4-9184-feb6f57d727b", () => OpenEditPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("dbe4def5-6971-4b97-a463-8f91e0d395d8", () => OpenEditPageUserTask1.Duration);
			MetaPathParameterValues.Add("865a5fc7-ff9d-42c1-b37f-e7d02f2ef7aa", () => OpenEditPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("f513407c-014f-4acb-a526-b212d7445f91", () => OpenEditPageUserTask1.StartIn);
			MetaPathParameterValues.Add("8dabbbff-449b-468b-a494-80ad1cb1636d", () => OpenEditPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("502e4584-f30e-4b9b-bc80-da8f5149d287", () => OpenEditPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("514f3679-fd23-41d3-ac6e-b13355c6b716", () => OpenEditPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("ea067875-15ce-466a-b805-9fd42938fa32", () => OpenEditPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("ab3aea55-ee61-4a61-8d37-c77f890582a6", () => OpenEditPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("e98d7ab1-5b31-4dfd-bd8a-01a99df1c13e", () => OpenEditPageUserTask1.Lead);
			MetaPathParameterValues.Add("4fbdcb67-4e39-4e84-b5d0-e4916df0cc20", () => OpenEditPageUserTask1.Account);
			MetaPathParameterValues.Add("92150aaf-bd20-4b0b-aae5-802a6ddacaaf", () => OpenEditPageUserTask1.Contact);
			MetaPathParameterValues.Add("b9c197e7-4fda-443b-af5d-04703f2512af", () => OpenEditPageUserTask1.Opportunity);
			MetaPathParameterValues.Add("500c6c82-6637-4f8b-bb30-9fb30e6c5c7a", () => OpenEditPageUserTask1.Invoice);
			MetaPathParameterValues.Add("4450ed80-79a2-4253-bf53-f4c99757acd0", () => OpenEditPageUserTask1.Document);
			MetaPathParameterValues.Add("ad403374-d787-48cb-8401-24d5938fecff", () => OpenEditPageUserTask1.Incident);
			MetaPathParameterValues.Add("29b687ca-aff7-43a8-8cf5-918beb75a406", () => OpenEditPageUserTask1.Case);
			MetaPathParameterValues.Add("12c7bcea-bbb6-467e-8b86-c73d6c2327ac", () => OpenEditPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("0b1c3a54-c7df-40ad-9016-020646d1af0f", () => OpenEditPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("f71b0056-5161-4704-b6e6-57433d6cec8d", () => OpenEditPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("8a103d16-ba6b-4bd1-8ddc-3e9254763dc8", () => OpenEditPageUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("ef2d226f-d2f6-44b9-8885-f2dc3c38e962", () => OpenEditPageUserTask1.PageTypeUId);
			MetaPathParameterValues.Add("41c2a0db-39ad-4b1a-9e9b-392fb44871ef", () => OpenEditPageUserTask1.ActivitySchemaUId);
			MetaPathParameterValues.Add("b75c6907-0060-42e9-a1b2-3ef95bc2be78", () => OpenEditPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("66c1e2c8-d668-462c-8641-cc41b2cb6ee7", () => OpenEditPageUserTask1.Order);
			MetaPathParameterValues.Add("aef3f8a1-0813-481c-8557-882ce62c0029", () => OpenEditPageUserTask1.Requests);
			MetaPathParameterValues.Add("002eea98-0f7a-4a3f-843b-636f63d8cf6e", () => OpenEditPageUserTask1.Listing);
			MetaPathParameterValues.Add("bc19d651-dabb-46b9-9f3b-b8da6581c36d", () => OpenEditPageUserTask1.Property);
			MetaPathParameterValues.Add("f650edfc-44d9-4d70-bb68-14bd3c9ad3d1", () => OpenEditPageUserTask1.Contract);
			MetaPathParameterValues.Add("ca76ab70-8cff-4f21-81c9-b9e679c8ddff", () => OpenEditPageUserTask1.Problem);
			MetaPathParameterValues.Add("b40747ec-b53b-4474-ba15-384d04322c33", () => OpenEditPageUserTask1.Change);
			MetaPathParameterValues.Add("35d9c012-2263-46ec-952f-e92631c411de", () => OpenEditPageUserTask1.Release);
			MetaPathParameterValues.Add("cd406c52-f5b6-4f47-9117-6e510888a57e", () => OpenEditPageUserTask1.Project);
			MetaPathParameterValues.Add("cae5665a-e99e-4f9a-9b64-97b513697bca", () => OpenEditPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("c552d799-9421-4e8e-aeff-e6cb6cc08f6d", () => OpenEditPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("9d21b7c3-5ea8-4f73-a5bf-f266ecb2b022", () => ReadDataLead.DataSourceFilters);
			MetaPathParameterValues.Add("ddb8f352-0211-44fc-8b93-f3abbd023649", () => ReadDataLead.ResultType);
			MetaPathParameterValues.Add("65843b8b-f9d2-41cc-8170-734e51b1a5ca", () => ReadDataLead.ReadSomeTopRecords);
			MetaPathParameterValues.Add("b341955e-cf2a-400b-907c-a8557f3c93c1", () => ReadDataLead.NumberOfRecords);
			MetaPathParameterValues.Add("1409c0d5-2885-44c0-8161-47a69431903e", () => ReadDataLead.FunctionType);
			MetaPathParameterValues.Add("bf8e626b-4175-4de4-99ed-f96ac7a26c1d", () => ReadDataLead.AggregationColumnName);
			MetaPathParameterValues.Add("5b1ea493-ed30-4d02-bdbb-0efcafe849f9", () => ReadDataLead.OrderInfo);
			MetaPathParameterValues.Add("d4413fda-e205-481c-828d-b4e67061712f", () => ReadDataLead.ResultEntity);
			MetaPathParameterValues.Add("95dce4e4-ff66-4664-b6f7-dacd9bf91bca", () => ReadDataLead.ResultCount);
			MetaPathParameterValues.Add("9a35a728-e367-4047-bda3-0b7be164f5ae", () => ReadDataLead.ResultIntegerFunction);
			MetaPathParameterValues.Add("7090f5b0-1f18-467e-9a40-60d3d177b9c4", () => ReadDataLead.ResultFloatFunction);
			MetaPathParameterValues.Add("11af421d-b60c-4cf9-a2f6-5d599eaa340c", () => ReadDataLead.ResultDateTimeFunction);
			MetaPathParameterValues.Add("2c5d37d8-5236-42a7-b93f-6d4732c94385", () => ReadDataLead.ResultRowsCount);
			MetaPathParameterValues.Add("83955bee-426f-4831-9715-4eda69412fb7", () => ReadDataLead.CanReadUncommitedData);
			MetaPathParameterValues.Add("2d0ef092-481e-4e72-920c-caa204e62d66", () => ReadDataLead.ResultEntityCollection);
			MetaPathParameterValues.Add("e72ba4ac-d6aa-4c7c-8d86-2be667ba6622", () => ReadDataLead.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("cc0389f7-a908-4db4-b2f9-dc8c55c3a68c", () => ReadDataLead.IgnoreDisplayValues);
			MetaPathParameterValues.Add("9de08d90-800b-4623-8793-b9bdbb30f1f4", () => ReadDataLead.ResultCompositeObjectList);
			MetaPathParameterValues.Add("1256d381-924c-4985-b42f-52e594574824", () => ReadDataLead.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("f161763e-878f-4674-8e4e-3fc88a6a58b3", () => ChangeDataLead.EntitySchemaUId);
			MetaPathParameterValues.Add("092165e2-051d-4f89-92cf-c710ba91ab13", () => ChangeDataLead.IsMatchConditions);
			MetaPathParameterValues.Add("6c0d30ee-7c93-4ea8-9ca4-918c3d232658", () => ChangeDataLead.DataSourceFilters);
			MetaPathParameterValues.Add("55a55d6a-8498-40c0-bdfe-95136f257586", () => ChangeDataLead.RecordColumnValues);
			MetaPathParameterValues.Add("39e4545b-9018-4881-9c69-65405bceb555", () => ChangeDataLead.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("77b402b4-36ef-4afe-85ca-fbbfe0540b9f", () => AddDataContactToOpportunity.EntitySchemaId);
			MetaPathParameterValues.Add("611d2131-f988-40c6-a266-7ac3720e4624", () => AddDataContactToOpportunity.DataSourceFilters);
			MetaPathParameterValues.Add("f87e7355-4618-4675-ac15-23509e6ffedd", () => AddDataContactToOpportunity.RecordAddMode);
			MetaPathParameterValues.Add("20e936ce-6092-493c-b50c-aaf70285c26b", () => AddDataContactToOpportunity.FilterEntitySchemaId);
			MetaPathParameterValues.Add("ccc51ea5-dba9-4d02-9514-ddb4ac2fa55c", () => AddDataContactToOpportunity.RecordDefValues);
			MetaPathParameterValues.Add("77fca69f-0da0-430c-a3da-c7ed23ab5394", () => AddDataContactToOpportunity.RecordId);
			MetaPathParameterValues.Add("39b51b00-83a0-4835-8530-2e20f2ce420c", () => AddDataContactToOpportunity.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("36768833-e793-4cd5-8c7c-6fa9657737df", () => AddDataOpportunity.EntitySchemaId);
			MetaPathParameterValues.Add("1aa11035-b136-470f-8cb3-1f4060a6f342", () => AddDataOpportunity.DataSourceFilters);
			MetaPathParameterValues.Add("05d8eeec-d375-46f9-ae98-2ee983ccb91d", () => AddDataOpportunity.RecordAddMode);
			MetaPathParameterValues.Add("8513b4b5-7a5d-4bac-b336-7ffa764d5510", () => AddDataOpportunity.FilterEntitySchemaId);
			MetaPathParameterValues.Add("488491cb-2475-44b0-9985-39cc11395c42", () => AddDataOpportunity.RecordDefValues);
			MetaPathParameterValues.Add("d6c3ad89-7397-4dd6-a229-f52efab3d43b", () => AddDataOpportunity.RecordId);
			MetaPathParameterValues.Add("382303ab-5cc8-404c-8886-60dff832b89c", () => AddDataOpportunity.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("95d638cd-1142-40c7-b944-f9e7fdc8b952", () => ReadDataCountOpportunityByAccount.DataSourceFilters);
			MetaPathParameterValues.Add("baccf23b-370e-4e0b-b657-7bfa21cdd970", () => ReadDataCountOpportunityByAccount.ResultType);
			MetaPathParameterValues.Add("daf54a7f-8a62-4589-9c9c-c261921a13fd", () => ReadDataCountOpportunityByAccount.ReadSomeTopRecords);
			MetaPathParameterValues.Add("cf300c28-9b38-48ff-a8d5-ecb1fba12e64", () => ReadDataCountOpportunityByAccount.NumberOfRecords);
			MetaPathParameterValues.Add("fc3b5658-a8e6-4cab-b27b-819a3025ed71", () => ReadDataCountOpportunityByAccount.FunctionType);
			MetaPathParameterValues.Add("693953ab-8637-4183-87d1-ee4988a862f8", () => ReadDataCountOpportunityByAccount.AggregationColumnName);
			MetaPathParameterValues.Add("5e608114-da8f-4197-a7c1-9abde0e48dca", () => ReadDataCountOpportunityByAccount.OrderInfo);
			MetaPathParameterValues.Add("a81f55d7-8bc9-4327-b691-9ede33487823", () => ReadDataCountOpportunityByAccount.ResultEntity);
			MetaPathParameterValues.Add("a83ce913-3e58-4db8-b563-712f4f1f1d4f", () => ReadDataCountOpportunityByAccount.ResultCount);
			MetaPathParameterValues.Add("f23fe366-df2c-4531-b2ed-ebdf444d985e", () => ReadDataCountOpportunityByAccount.ResultIntegerFunction);
			MetaPathParameterValues.Add("236f9f63-489b-4485-b92a-f5a499fe453e", () => ReadDataCountOpportunityByAccount.ResultFloatFunction);
			MetaPathParameterValues.Add("5a384c94-4c0e-46d6-ab9c-2f2f6cf1de5a", () => ReadDataCountOpportunityByAccount.ResultDateTimeFunction);
			MetaPathParameterValues.Add("199f3817-15db-4ed6-b57f-350fc7b100b3", () => ReadDataCountOpportunityByAccount.ResultRowsCount);
			MetaPathParameterValues.Add("d3ab4b8a-b637-47a5-bc47-da539d6683f1", () => ReadDataCountOpportunityByAccount.CanReadUncommitedData);
			MetaPathParameterValues.Add("156fda51-7aad-4289-bdf5-909adb3f882f", () => ReadDataCountOpportunityByAccount.ResultEntityCollection);
			MetaPathParameterValues.Add("84c58779-0b9a-4c9a-92d9-5ba3900861f5", () => ReadDataCountOpportunityByAccount.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("d2b28272-8058-40a5-b869-30703026b4b7", () => ReadDataCountOpportunityByAccount.IgnoreDisplayValues);
			MetaPathParameterValues.Add("65e21e52-02d5-4036-ab27-31a7bd141180", () => ReadDataCountOpportunityByAccount.ResultCompositeObjectList);
			MetaPathParameterValues.Add("bbb76cdb-6487-4e75-a4bf-d06db7d6e4b8", () => ReadDataCountOpportunityByAccount.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("760c8144-4547-4f2e-9058-d28c8497d3e6", () => ReadDataAccount.DataSourceFilters);
			MetaPathParameterValues.Add("29d241ea-e7c1-468b-93dd-4fabc9692e05", () => ReadDataAccount.ResultType);
			MetaPathParameterValues.Add("99fe1d4f-11a3-4a99-a403-3f8329c46387", () => ReadDataAccount.ReadSomeTopRecords);
			MetaPathParameterValues.Add("23c9ab4d-c03e-4823-a89d-b8157e04f637", () => ReadDataAccount.NumberOfRecords);
			MetaPathParameterValues.Add("0481537e-1347-4a84-bc95-3f25b63bd2aa", () => ReadDataAccount.FunctionType);
			MetaPathParameterValues.Add("98fe3323-90ae-4f77-9698-90cb6049bb21", () => ReadDataAccount.AggregationColumnName);
			MetaPathParameterValues.Add("ab5fefa4-6698-4258-940b-0a2c6dd14a31", () => ReadDataAccount.OrderInfo);
			MetaPathParameterValues.Add("d3b28169-5be2-4f9c-97c0-eef28ed4f516", () => ReadDataAccount.ResultEntity);
			MetaPathParameterValues.Add("3bc1a643-8bc8-4d8c-96c9-19e0df86a151", () => ReadDataAccount.ResultCount);
			MetaPathParameterValues.Add("801aa1e5-b4cb-4d94-abad-0dfa07dffec6", () => ReadDataAccount.ResultIntegerFunction);
			MetaPathParameterValues.Add("f75452e6-8240-4d69-825e-90cd8847e099", () => ReadDataAccount.ResultFloatFunction);
			MetaPathParameterValues.Add("36ec811c-adc6-4e15-a536-d4bbcf966b71", () => ReadDataAccount.ResultDateTimeFunction);
			MetaPathParameterValues.Add("affd0b02-dbe8-4101-aeb3-b62e33160dd3", () => ReadDataAccount.ResultRowsCount);
			MetaPathParameterValues.Add("591a5668-a8e2-41dc-a509-888da5a63e1a", () => ReadDataAccount.CanReadUncommitedData);
			MetaPathParameterValues.Add("9cc3666e-b170-44af-a775-f6810f7e7250", () => ReadDataAccount.ResultEntityCollection);
			MetaPathParameterValues.Add("87a74108-882e-4315-a51f-706bae061c72", () => ReadDataAccount.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("e5436907-184b-4bae-b060-99c5407f2a22", () => ReadDataAccount.IgnoreDisplayValues);
			MetaPathParameterValues.Add("e77a1286-e9d2-4754-9186-5bb645bb8767", () => ReadDataAccount.ResultCompositeObjectList);
			MetaPathParameterValues.Add("607a5352-158d-4931-bac2-3b4dc98d8819", () => ReadDataAccount.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("f3d16d53-5568-4d10-85f2-ecee93297c69", () => ReadDataContact.DataSourceFilters);
			MetaPathParameterValues.Add("6d0e3dc9-842e-46e7-8ec6-d71896474631", () => ReadDataContact.ResultType);
			MetaPathParameterValues.Add("01b2e31d-1d81-4b50-bc28-b8d8b4b60976", () => ReadDataContact.ReadSomeTopRecords);
			MetaPathParameterValues.Add("2fc79c56-2808-4e39-a3da-7b92d8218134", () => ReadDataContact.NumberOfRecords);
			MetaPathParameterValues.Add("4d312b88-dd01-43fa-a2cf-92d118789fc2", () => ReadDataContact.FunctionType);
			MetaPathParameterValues.Add("705dbcc7-95ff-47ba-a0de-e637092435f6", () => ReadDataContact.AggregationColumnName);
			MetaPathParameterValues.Add("0dfc2b7f-d9f0-4923-87e3-ce36e9fb5442", () => ReadDataContact.OrderInfo);
			MetaPathParameterValues.Add("daa09ed7-2a7d-4450-a30a-dd8ac16c0a06", () => ReadDataContact.ResultEntity);
			MetaPathParameterValues.Add("1c0aed0e-7343-442c-970e-e1e5c5a4ede4", () => ReadDataContact.ResultCount);
			MetaPathParameterValues.Add("957d85e9-6cea-4ba9-b671-6ff1d0faecee", () => ReadDataContact.ResultIntegerFunction);
			MetaPathParameterValues.Add("96aba7e1-c060-491b-a648-67b8fed13557", () => ReadDataContact.ResultFloatFunction);
			MetaPathParameterValues.Add("0afa84c8-ac3e-4b20-8ff2-a08e0f96f627", () => ReadDataContact.ResultDateTimeFunction);
			MetaPathParameterValues.Add("13f4af03-0d2b-4788-9a8d-f585fb5cfd13", () => ReadDataContact.ResultRowsCount);
			MetaPathParameterValues.Add("2c12c50b-6308-45df-becd-68952bb8177e", () => ReadDataContact.CanReadUncommitedData);
			MetaPathParameterValues.Add("adb4ba05-85d5-4736-a24e-94b25bcf8904", () => ReadDataContact.ResultEntityCollection);
			MetaPathParameterValues.Add("04d717aa-6962-480f-b56d-1be4aba03d1c", () => ReadDataContact.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("67a25d02-1e6e-46fc-bb0a-c9e2f19819ab", () => ReadDataContact.IgnoreDisplayValues);
			MetaPathParameterValues.Add("c7366f82-7e36-4b9b-ba4b-6ce38fde9f5b", () => ReadDataContact.ResultCompositeObjectList);
			MetaPathParameterValues.Add("a3590db7-7310-416b-84eb-84237f10a0f1", () => ReadDataContact.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a81724cd-f82e-401e-bdc4-1f4968318e58", () => PresentationTaskCreation.EntitySchemaId);
			MetaPathParameterValues.Add("dafab651-4b04-4a39-9ffa-a14a50789205", () => PresentationTaskCreation.DataSourceFilters);
			MetaPathParameterValues.Add("ff84282e-f6d0-4910-a414-28117fa48082", () => PresentationTaskCreation.RecordAddMode);
			MetaPathParameterValues.Add("5ad22c54-905a-451d-b9fd-76ff73069b58", () => PresentationTaskCreation.FilterEntitySchemaId);
			MetaPathParameterValues.Add("5cd8ef8c-6a8f-48a6-8cbb-13e448e5e606", () => PresentationTaskCreation.RecordDefValues);
			MetaPathParameterValues.Add("3b349266-cabe-4ac9-9bab-90e5a99b9312", () => PresentationTaskCreation.RecordId);
			MetaPathParameterValues.Add("47ce121a-112c-4d86-91bb-d5e256add4c7", () => PresentationTaskCreation.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e113eec9-67b0-4d53-8bd1-162890643787", () => ReadOppoortunityData2.DataSourceFilters);
			MetaPathParameterValues.Add("da79942f-8a30-4c0f-855d-60c2d9a24472", () => ReadOppoortunityData2.ResultType);
			MetaPathParameterValues.Add("314efddf-5361-477a-9ff8-a9cb5fab8b62", () => ReadOppoortunityData2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("06b753c1-0d8b-436b-8acc-ddf113106da6", () => ReadOppoortunityData2.NumberOfRecords);
			MetaPathParameterValues.Add("ad17e1dd-e357-4be2-be8e-37597e384cc1", () => ReadOppoortunityData2.FunctionType);
			MetaPathParameterValues.Add("9cb37f59-15e3-4146-8d7f-c8726fcb37d4", () => ReadOppoortunityData2.AggregationColumnName);
			MetaPathParameterValues.Add("6f41753d-91d4-4093-8fba-b44d89023e4c", () => ReadOppoortunityData2.OrderInfo);
			MetaPathParameterValues.Add("dfa2d329-fcfc-4412-bf5d-d4a9bda93dae", () => ReadOppoortunityData2.ResultEntity);
			MetaPathParameterValues.Add("820e9918-37b0-4611-aaf2-8d870ec7da7d", () => ReadOppoortunityData2.ResultCount);
			MetaPathParameterValues.Add("cb9c1fe1-8c58-4f12-89f1-7aae2156df27", () => ReadOppoortunityData2.ResultIntegerFunction);
			MetaPathParameterValues.Add("813a52d4-0e07-46b4-a63f-229d35aa56c6", () => ReadOppoortunityData2.ResultFloatFunction);
			MetaPathParameterValues.Add("a3dabfcb-04f6-4cea-92b9-d9ea7aee59b1", () => ReadOppoortunityData2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("fcd7d381-1523-402c-b1b8-ed682284f793", () => ReadOppoortunityData2.ResultRowsCount);
			MetaPathParameterValues.Add("e2a2ccd2-d26f-4f42-ae98-edf3516e1ea8", () => ReadOppoortunityData2.CanReadUncommitedData);
			MetaPathParameterValues.Add("b5926df2-7c95-4492-a867-2d430924a35b", () => ReadOppoortunityData2.ResultEntityCollection);
			MetaPathParameterValues.Add("701045a2-ff5b-4e90-ae4f-035211803404", () => ReadOppoortunityData2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("5402bebd-14b9-42b0-8196-579eb5bbe71e", () => ReadOppoortunityData2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("f1e7ad19-7dde-4e11-8f26-04409580f3d6", () => ReadOppoortunityData2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("a9301231-cf7b-4b68-bc33-88ca59cd75dc", () => ReadOppoortunityData2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6fbea50a-fcc9-45a8-9318-18aaea6960f4", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("054c4df5-87b5-404f-85c8-f5bb3e7c2694", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("85e3b80e-36f9-4932-88fd-521181901c0a", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("335d8956-0dcb-469d-90e9-ceef1f2c5ecf", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("d9f755be-cee7-464d-9e1b-b41958012cd7", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("ea0c6605-f519-48fc-a673-083c99411a6a", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("04c4106d-1c1b-4e36-adfa-2bde0c00cacb", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("ee89e1ce-8692-4233-94c8-45e2768973be", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("a73fd6bc-7349-44c8-9897-4cbf76d42e92", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("83effc4d-ad92-4d9f-8f5d-a8a8a9476b51", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("5877a9b3-2232-413f-bca4-841e0c74fcaf", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("e49f79ee-5843-4cf5-8054-c5513d2f9295", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("2bb22b1b-8777-4e67-bd6f-76818c3e0d4b", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("10b071ad-0944-459a-90cb-7bd9819ae222", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("35106250-8b54-4cad-8a40-45adb5f3cd75", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("c1ba2a29-f542-4078-94a5-6af41945ce12", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9077d7fd-aab0-4d45-9d7d-e410dd871d90", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ae2d8985-2096-4b5d-b5b1-453648bd2c43", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("0c758ce1-ff47-4412-8e5c-64348552654a", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("07e87dc6-266d-4544-87cb-bfd58618dbfc", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("8e34ab8a-aae1-49fa-a036-0f0b0ae39983", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("b4c062c1-d149-4854-b95d-7d3101c49ba8", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("9b1e2c37-1ca0-4018-820c-534743d29771", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("3f57e619-c84a-40cd-a0f1-b5c0fad5c3c5", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("916d8dad-7673-427b-a065-b9d623107663", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("ee12b588-6303-487f-bd23-3a6753741f2d", () => AddDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("06208806-e8cf-4d1b-b140-1bb619b9ed9d", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("c7f8a702-1219-42b2-bf9d-1f55c8264391", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("3792585d-cd7c-494c-b316-b160fa45ae28", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("faa46a7f-a96c-46cf-9a47-add578864b68", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("68383c19-2658-416e-958d-1489861993aa", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("80cefc71-5fc6-4296-b100-29c98156e0b1", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("35445f62-ccc0-4a74-94f0-9ec9ea65b343", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("6cba6276-dc6c-4940-803b-a32b756d2ebd", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("6d7147db-0aaa-41c5-8897-3ad2d88fd821", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("00aae8e4-4e62-4538-9bf7-d0b6178f7c93", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("e696780e-c260-4f1d-ac47-1890fdb6b840", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("da459109-1578-45d4-9510-627e44859262", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("05f93e88-b9f0-488c-b37f-c86bd5b8d920", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("1ddf79d1-87fa-413b-b322-71e34392312d", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("2f6fab91-5a02-44f1-9ea1-7012b00b2849", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("d5f43f08-08d2-4c1d-aae8-d8cddf1e99e0", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("b65917ae-2434-428b-b40e-92d5141b5034", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("f4ae8dd2-b583-47bc-a13b-88ab93c3a5da", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("eb514f36-66db-4ffd-8390-60718a1946c7", () => ReadDataUserTask2.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CurrentOpportunity":
					if (!hasValueToRead) break;
					CurrentOpportunity = reader.GetValue<System.Guid>();
				break;
				case "Presentation":
					if (!hasValueToRead) break;
					Presentation = reader.GetValue<System.Guid>();
				break;
				case "MainContact":
					if (!hasValueToRead) break;
					MainContact = reader.GetValue<System.Guid>();
				break;
				case "Account":
					if (!hasValueToRead) break;
					Account = reader.GetValue<System.Guid>();
				break;
				case "IsStageChangedByUser":
					if (!hasValueToRead) break;
					IsStageChangedByUser = reader.GetValue<System.Boolean>();
				break;
				case "ClientOpportunityCount":
					if (!hasValueToRead) break;
					ClientOpportunityCount = reader.GetValue<System.Int32>();
				break;
				case "OpportunityTitle":
					if (!hasValueToRead) break;
					OpportunityTitle = reader.GetValue<System.String>();
				break;
				case "Contact":
					if (!hasValueToRead) break;
					Contact = reader.GetValue<System.Guid>();
				break;
				case "ClientName":
					if (!hasValueToRead) break;
					ClientName = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SavePresentationParameter2Execute(ProcessExecutingContext context) {
			var localPresentation = ((FindPresentation.ResultEntity.IsColumnValueLoaded(FindPresentation.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? FindPresentation.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty));
			Presentation = (System.Guid)localPresentation;
			return true;
		}

		public virtual bool SaveMainContactParameterExecute(ProcessExecutingContext context) {
			var localMainContact = (Guid.Empty == ((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty))) ? ((ReadOppMainContact.ResultEntity.IsColumnValueLoaded(ReadOppMainContact.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? ReadOppMainContact.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)) : ((ReadOppData.ResultEntity.IsColumnValueLoaded(ReadOppData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? ReadOppData.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty));
			MainContact = (System.Guid)localMainContact;
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localCurrentOpportunity = (OpenEditPageUserTask1.RecordId);
			CurrentOpportunity = (System.Guid)localCurrentOpportunity;
			return true;
		}

		public virtual bool FormulaTask2Execute(ProcessExecutingContext context) {
			var localPresentation = Guid.Empty;
			Presentation = (System.Guid)localPresentation;
			return true;
		}

		public virtual bool StoreIsStageChangedByUserExecute(ProcessExecutingContext context) {
			var localIsStageChangedByUser = (Prospecting.OpportunityStageChanged) || (NeedsAnalysis.OpportunityStageChanged)|| (OppManagementValuePproposition.OpportunityStageChanged) || (IdDecisionMakers.OpportunityStageChanged) || (OppManagementPerceptionAnalysis.OpportunityStageChanged) || (OppManagementProposal.OpportunityStageChanged) || (OppManagementNegotiations.OpportunityStageChanged) || (OppManagementContractation.OpportunityStageChanged);
			IsStageChangedByUser = (System.Boolean)localIsStageChangedByUser;
			return true;
		}

		public virtual bool ResetIsStageChangedByUserExecute(ProcessExecutingContext context) {
			var localIsStageChangedByUser = false;
			IsStageChangedByUser = (System.Boolean)localIsStageChangedByUser;
			return true;
		}

		public virtual bool FormulaTaskAccountByLeadExecute(ProcessExecutingContext context) {
			var localAccount = ((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty));
			Account = (System.Guid)localAccount;
			return true;
		}

		public virtual bool SaveCurrOppParameterExecute(ProcessExecutingContext context) {
			var localCurrentOpportunity = (AddDataOpportunity.RecordId);
			CurrentOpportunity = (System.Guid)localCurrentOpportunity;
			return true;
		}

		public virtual bool SavePresentationParameterExecute(ProcessExecutingContext context) {
			var localPresentation = (PresentationTaskCreation.RecordId);
			Presentation = (System.Guid)localPresentation;
			return true;
		}

		public virtual bool FormulaTask3Execute(ProcessExecutingContext context) {
			var localClientOpportunityCount = (ReadDataUserTask2.ResultCount);
			ClientOpportunityCount = (System.Int32)localClientOpportunityCount;
			return true;
		}

		public virtual bool FormulaTask4Execute(ProcessExecutingContext context) {
			var localClientOpportunityCount = (ReadDataCountOpportunityByAccount.ResultCount);
			ClientOpportunityCount = (System.Int32)localClientOpportunityCount;
			return true;
		}

		public virtual bool FormulaTask5Execute(ProcessExecutingContext context) {
			var localOpportunityTitle = ((ReadDataAccount.ResultEntity.IsColumnValueLoaded(ReadDataAccount.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? ReadDataAccount.ResultEntity.GetTypedColumnValue<string>("Name") : null));
			OpportunityTitle = (System.String)localOpportunityTitle;
			return true;
		}

		public virtual bool FormulaTask6Execute(ProcessExecutingContext context) {
			var localOpportunityTitle = ((ReadDataContact.ResultEntity.IsColumnValueLoaded(ReadDataContact.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? ReadDataContact.ResultEntity.GetTypedColumnValue<string>("Name") : null));
			OpportunityTitle = (System.String)localOpportunityTitle;
			return true;
		}

		public virtual bool FormulaTask7Execute(ProcessExecutingContext context) {
			var localContact = ((ReadDataLead.ResultEntity.IsColumnValueLoaded(ReadDataLead.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? ReadDataLead.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty));
			Contact = (System.Guid)localContact;
			return true;
		}

		public virtual bool FormulaTask8Execute(ProcessExecutingContext context) {
			var localClientName = ((ReadDataContact.ResultEntity.IsColumnValueLoaded(ReadDataContact.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? ReadDataContact.ResultEntity.GetTypedColumnValue<string>("Name") : null));
			ClientName = (System.String)localClientName;
			return true;
		}

		public virtual bool FormulaTask9Execute(ProcessExecutingContext context) {
			var localClientName = ((ReadDataAccount.ResultEntity.IsColumnValueLoaded(ReadDataAccount.ResultEntity.Schema.Columns.GetByName("Name").ColumnValueName) ? ReadDataAccount.ResultEntity.GetTypedColumnValue<string>("Name") : null));
			ClientName = (System.String)localClientName;
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
			var cloneItem = (OpportunityManagement)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

