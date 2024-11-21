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

	#region Class: LeadManagementSchema

	/// <exclude/>
	public class LeadManagementSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementSchema(LeadManagementSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagement";
			UId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6");
			CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.1.0.2998";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"LeadManagement";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6");
			Version = 0;
			PackageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateLeadIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dcaf025e-49c8-42ea-8f2d-0ffad1fb7e33"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateShowDistributionPageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("76349b0a-e191-4050-abc2-0ee4dd58c60f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"ShowDistributionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateLeadIdParameter());
			Parameters.Add(CreateShowDistributionPageParameter());
		}

		protected virtual void InitializeQualificationSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var leadIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("eeb9b9b2-825c-436f-9921-05f3960028d4"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadIdParameter.SourceValue = new ProcessSchemaParameterValue(leadIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dcaf025e-49c8-42ea-8f2d-0ffad1fb7e33}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(leadIdParameter);
			var accountIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("10e69e19-8c95-4d62-81b4-503111e906aa"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"AccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountIdParameter.SourceValue = new ProcessSchemaParameterValue(accountIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(accountIdParameter);
			var contactIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("7fddaeb5-c6e0-480f-9676-30f009ff2c05"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactIdParameter.SourceValue = new ProcessSchemaParameterValue(contactIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(contactIdParameter);
			var leadAddressTypeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("50837bfc-43ff-466b-94bb-de0847eecd1b"),
				UId = new Guid("99711985-137d-41cf-a3b7-4a85494d651d"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadAddressType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadAddressTypeParameter.SourceValue = new ProcessSchemaParameterValue(leadAddressTypeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadAddressTypeParameter);
			var leadCityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d2d62cb2-50ce-4754-8b7c-20ed8b42c4b4"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadCity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadCityParameter.SourceValue = new ProcessSchemaParameterValue(leadCityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadCityParameter);
			var leadZipParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("59ed428c-989b-4597-85e5-ec4d9d8356fb"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadZip",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadZipParameter.SourceValue = new ProcessSchemaParameterValue(leadZipParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadZipParameter);
			var leadRegionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("efcd46e1-9bc7-4d35-8e20-7ac2ee8be116"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadRegion",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadRegionParameter.SourceValue = new ProcessSchemaParameterValue(leadRegionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadRegionParameter);
			var leadCountryParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e479c2d-1365-425e-b14b-e7f2158c06a3"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadCountry",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadCountryParameter.SourceValue = new ProcessSchemaParameterValue(leadCountryParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadCountryParameter);
			var leadWebsiteParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2cd8c2da-e379-46fb-b509-b8737a25a87f"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadWebsite",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadWebsiteParameter.SourceValue = new ProcessSchemaParameterValue(leadWebsiteParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadWebsiteParameter);
			var leadFaxParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4cc6cafe-0516-40bc-97b3-b5e71f487657"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadFax",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadFaxParameter.SourceValue = new ProcessSchemaParameterValue(leadFaxParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadFaxParameter);
			var leadBusinessPhoneParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("49d663bc-3ccb-4a5e-aedf-a5f9f46447b4"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadBusinessPhone",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadBusinessPhoneParameter.SourceValue = new ProcessSchemaParameterValue(leadBusinessPhoneParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadBusinessPhoneParameter);
			var leadEmailParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("47bc33cb-d759-4bb8-ad75-e71dc733eee1"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadEmailParameter.SourceValue = new ProcessSchemaParameterValue(leadEmailParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadEmailParameter);
			var leadMobilePhoneParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e164a6a3-88d8-4bb5-9bfe-c459a76ec7ff"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadMobilePhone",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadMobilePhoneParameter.SourceValue = new ProcessSchemaParameterValue(leadMobilePhoneParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadMobilePhoneParameter);
			var leadDecisionRoleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cf6f0a84-e41d-4d4f-a15f-77d327d0cccf"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadDecisionRole",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadDecisionRoleParameter.SourceValue = new ProcessSchemaParameterValue(leadDecisionRoleParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadDecisionRoleParameter);
			var leadGenderParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a4b5e57a-9139-4777-9db5-146902df80aa"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadGender",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadGenderParameter.SourceValue = new ProcessSchemaParameterValue(leadGenderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadGenderParameter);
			var leadDepartmentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d789022-045d-443b-b34b-0aa336be3e13"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadDepartment",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadDepartmentParameter.SourceValue = new ProcessSchemaParameterValue(leadDepartmentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadDepartmentParameter);
			var leadJobParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aaf509ea-15a4-419b-8fa8-500ac50c6ecf"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadJob",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadJobParameter.SourceValue = new ProcessSchemaParameterValue(leadJobParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadJobParameter);
			var leadSalutationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb90952a-c229-4b61-9ac9-d016ad9e3a4b"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadSalutation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			leadSalutationParameter.SourceValue = new ProcessSchemaParameterValue(leadSalutationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadSalutationParameter);
			var leadDearParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c63070fd-7eda-40db-82e0-701f84846784"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadDear",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadDearParameter.SourceValue = new ProcessSchemaParameterValue(leadDearParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadDearParameter);
			var leadFullJobTitleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ad2981e9-7c11-4c3d-9edd-f2c624c5c243"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadFullJobTitle",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadFullJobTitleParameter.SourceValue = new ProcessSchemaParameterValue(leadFullJobTitleParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadFullJobTitleParameter);
			var leadContactNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("82ae37f0-aa22-4258-af7c-a3fe6a41ccbe"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadContactName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadContactNameParameter.SourceValue = new ProcessSchemaParameterValue(leadContactNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadContactNameParameter);
			var leadAccountNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("efa48aa1-faab-4ea1-89e7-a96c6ce2837d"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadAccountName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadAccountNameParameter.SourceValue = new ProcessSchemaParameterValue(leadAccountNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadAccountNameParameter);
			var leadAnnualRevenueParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b206ab98-e66d-4031-8c12-13b8738f9fcc"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadAnnualRevenue",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadAnnualRevenueParameter.SourceValue = new ProcessSchemaParameterValue(leadAnnualRevenueParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadAnnualRevenueParameter);
			var leadEmployeesNumberParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1420e38c-30a9-48fe-9163-9893548c89e3"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadEmployeesNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadEmployeesNumberParameter.SourceValue = new ProcessSchemaParameterValue(leadEmployeesNumberParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadEmployeesNumberParameter);
			var leadAccountCategoryParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("04d43bf8-a0ab-4475-b724-69e8706c5820"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadAccountCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadAccountCategoryParameter.SourceValue = new ProcessSchemaParameterValue(leadAccountCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadAccountCategoryParameter);
			var leadIndustryParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a74798e5-72a3-4622-8e79-4545686f2b4f"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadIndustry",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadIndustryParameter.SourceValue = new ProcessSchemaParameterValue(leadIndustryParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadIndustryParameter);
			var leadOwnershipParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5016eabe-e16f-44f2-91ac-000358b10554"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadOwnership",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadOwnershipParameter.SourceValue = new ProcessSchemaParameterValue(leadOwnershipParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadOwnershipParameter);
			var leadAccountIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a5f40093-ea65-4f4a-a10b-9fa0852612ca"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadAccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadAccountIdParameter.SourceValue = new ProcessSchemaParameterValue(leadAccountIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadAccountIdParameter);
			var leadContactIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("98d88c5d-9ec8-446d-bb07-e2dcb6d0ccb0"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadContactIdParameter.SourceValue = new ProcessSchemaParameterValue(leadContactIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadContactIdParameter);
			var leadAddressParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c376c603-36de-4889-8393-2370fdf07849"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			leadAddressParameter.SourceValue = new ProcessSchemaParameterValue(leadAddressParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(leadAddressParameter);
			var createAccountOnQualificationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a958b03-2bb4-46e1-9fe8-0bdb1538eae6"),
				ContainerUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"CreateAccountOnQualification",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createAccountOnQualificationParameter.SourceValue = new ProcessSchemaParameterValue(createAccountOnQualificationParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(createAccountOnQualificationParameter);
		}

		protected virtual void InitializeDistributionSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var leadIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("c20f32d7-b843-4b74-8e39-3a6890ba55ff"),
				ContainerUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadIdParameter.SourceValue = new ProcessSchemaParameterValue(leadIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dcaf025e-49c8-42ea-8f2d-0ffad1fb7e33}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(leadIdParameter);
			var createReminderParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ca0ec7ac-1d90-4b8b-bcb9-9206dc58ea25"),
				ContainerUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Name = @"CreateReminder",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createReminderParameter.SourceValue = new ProcessSchemaParameterValue(createReminderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe")
			};
			parametrizedElement.Parameters.Add(createReminderParameter);
			var responsibleIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("5085de2a-f04e-4378-bfab-51bbac41aa61"),
				ContainerUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Name = @"ResponsibleId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			responsibleIdParameter.SourceValue = new ProcessSchemaParameterValue(responsibleIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe")
			};
			parametrizedElement.Parameters.Add(responsibleIdParameter);
			var showDistributionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aa63d8d4-2a94-4731-9a3d-b9b2be3fdb0d"),
				ContainerUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				Name = @"ShowDistributionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showDistributionPageParameter.SourceValue = new ProcessSchemaParameterValue(showDistributionPageParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{76349b0a-e191-4050-abc2-0ee4dd58c60f}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(showDistributionPageParameter);
		}

		protected virtual void InitializeHandoffSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var leadIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("012cc585-99f3-4ed1-8ccd-d387890c425e"),
				ContainerUId = new Guid("bf4fdb46-796a-4290-9134-de7fe2eab40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7ee7590a-758b-4ee3-990c-188743946765"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7ee7590a-758b-4ee3-990c-188743946765"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadIdParameter.SourceValue = new ProcessSchemaParameterValue(leadIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dcaf025e-49c8-42ea-8f2d-0ffad1fb7e33}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(leadIdParameter);
		}

		protected virtual void InitializeAwaitingSalesSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var leadIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("68e66100-46fa-4d20-a6ba-fbaf9d940720"),
				ContainerUId = new Guid("a9a73c32-a953-4b47-a375-b5b163a62fed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6c2f6588-5216-4902-9d51-e0adf8a1201a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6c2f6588-5216-4902-9d51-e0adf8a1201a"),
				Name = @"LeadId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadIdParameter.SourceValue = new ProcessSchemaParameterValue(leadIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dcaf025e-49c8-42ea-8f2d-0ffad1fb7e33}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(leadIdParameter);
		}

		protected virtual void InitializeReadLeadDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("79d7c595-8697-4a57-a10a-79ee7ae30ce4"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,205,106,220,48,20,133,223,69,139,174,172,162,63,219,178,187,28,166,101,54,105,160,105,41,36,67,184,150,174,50,2,255,76,108,153,38,152,121,146,190,70,23,125,140,121,164,202,227,76,10,89,132,208,93,193,139,171,43,157,163,239,30,228,233,214,15,31,125,29,176,47,29,212,3,38,227,198,150,68,26,5,90,166,41,181,92,91,170,156,200,169,22,80,80,149,67,202,152,19,10,101,65,146,22,26,44,201,162,94,91,31,72,226,3,54,67,121,61,253,53,13,253,136,201,173,59,45,190,152,29,54,240,117,190,64,113,112,186,192,130,230,41,171,168,194,170,162,218,128,161,206,201,162,202,148,86,28,13,89,88,84,198,25,207,29,167,169,19,145,192,161,166,21,103,154,162,117,76,102,194,178,44,175,72,82,163,11,235,135,125,143,195,224,187,182,156,240,185,190,122,220,71,202,229,238,85,87,143,77,75,146,6,3,92,66,216,149,4,144,161,74,13,80,163,138,116,118,207,41,200,194,82,9,85,46,114,141,60,227,57,73,12,236,195,108,75,54,150,36,22,2,124,131,122,196,147,243,228,35,163,144,140,235,52,139,90,46,13,85,82,48,170,51,157,83,103,51,87,160,204,138,162,178,231,188,62,141,62,214,126,184,24,27,236,189,121,138,29,99,126,93,95,78,166,107,67,223,213,179,245,197,233,248,21,62,132,37,220,167,173,239,203,64,33,246,103,17,57,36,227,128,171,218,99,27,214,173,233,172,111,239,22,207,195,33,74,154,61,244,126,56,167,176,190,31,161,38,73,239,239,118,175,166,181,26,135,208,53,255,209,168,73,28,51,122,196,71,118,194,157,223,160,245,195,190,134,199,211,186,36,239,238,199,46,124,56,254,60,254,62,254,90,106,242,66,83,146,27,98,13,56,38,82,164,170,48,154,42,129,64,181,19,150,50,231,192,114,87,229,40,229,13,137,28,255,228,126,189,25,62,255,104,207,255,193,66,190,125,31,187,47,26,151,103,101,57,189,5,232,176,157,145,182,135,248,253,1,61,113,12,15,206,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a18edb14-dfeb-4d04-90bb-d26913e2ac5a"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("af294c4d-71dd-4e98-b5ea-ca04bf60c63a"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("02aa9ff0-24e7-4104-b3be-a9743c914f93"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("366c7a6d-876d-435a-8556-d7b90838c1f2"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e0614378-f986-43e1-abbc-202a6926f125"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("23fa8dea-6c00-412e-9c43-408c3e68a1b9"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,73,77,76,241,75,204,77,181,50,180,50,4,0,119,185,58,103,19,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("410ce1cd-f5a9-43a4-81dd-e3ddcc55020d"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("32c199ed-0dd3-4cf1-818c-a1fe154b949b"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("dff9a69d-c27b-43d4-bb6f-65043863e873"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a8d7bc3f-493b-473f-9a5f-e05829be523a"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("b2e829b1-49d7-48b1-8ca0-11c5c2fb6a3f"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e2b7fb69-f082-4171-aa4b-62a5f4a7f7bf"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c38a2d93-07b6-45bb-8d39-cd8976a2f6e0"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("be3f7962-de04-4446-b20d-854d0c23e8c9"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("04dce9b6-f80f-43f3-ab64-d3b51a737d1d"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("62c4740f-9091-4733-97bc-8f6f4966d30e"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("957d027e-ee69-4ed3-b7f7-5f37fdf8c9a4"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d2e6c1cc-64d4-4482-acc5-d11dad3628ef"),
				ContainerUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaLaneSet schemaLeadManagementLaneSet = CreateLeadManagementLaneSetLaneSet();
			LaneSets.Add(schemaLeadManagementLaneSet);
			ProcessSchemaLane schemaLeadManagementLane = CreateLeadManagementLaneLane();
			schemaLeadManagementLaneSet.Lanes.Add(schemaLeadManagementLane);
			ProcessSchemaSubProcess qualificationsubprocess = CreateQualificationSubProcessSubProcess();
			FlowElements.Add(qualificationsubprocess);
			ProcessSchemaSubProcess distributionsubprocess = CreateDistributionSubProcessSubProcess();
			FlowElements.Add(distributionsubprocess);
			ProcessSchemaSubProcess handoffsubprocess = CreateHandoffSubProcessSubProcess();
			FlowElements.Add(handoffsubprocess);
			ProcessSchemaSubProcess awaitingsalessubprocess = CreateAwaitingSalesSubProcessSubProcess();
			FlowElements.Add(awaitingsalessubprocess);
			ProcessSchemaExclusiveGateway exclusivegatewaystage = CreateExclusiveGatewayStageExclusiveGateway();
			FlowElements.Add(exclusivegatewaystage);
			ProcessSchemaUserTask readleaddata = CreateReadLeadDataUserTask();
			FlowElements.Add(readleaddata);
			ProcessSchemaTerminateEvent terminateprocess = CreateTerminateProcessTerminateEvent();
			FlowElements.Add(terminateprocess);
			ProcessSchemaScriptTask attachleadtoprocessscripttask = CreateAttachLeadToProcessScriptTaskScriptTask();
			FlowElements.Add(attachleadtoprocessscripttask);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlowAfterQualificationSequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalFlowDistributionConditionalFlow());
			FlowElements.Add(CreateConditionalFlowQualificationConditionalFlow());
			FlowElements.Add(CreateSequenceFlowAfterDistributionSequenceFlow());
			FlowElements.Add(CreateConditionalFlowHandoffConditionalFlow());
			FlowElements.Add(CreateSequenceFlowAfterHandoffSequenceFlow());
			FlowElements.Add(CreateConditionalFlowAwaitingSalesConditionalFlow());
			FlowElements.Add(CreateSequenceFlowAfterAwaitingSalesSequenceFlow());
			FlowElements.Add(CreateReadLeadSequenceFlowSequenceFlow());
			FlowElements.Add(CreateAttachLeadSequenceFlowSequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("e79f3de4-a9c1-4d82-8991-94d9bcbe48ae"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(232, 157),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowAfterQualificationSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlowAfterQualification",
				UId = new Guid("5c9438da-436c-4ab8-8c7c-44ae46f9142c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(672, 114),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(862, 261));
			schemaFlow.PolylinePointPositions.Add(new Point(533, 261));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("37b88c6b-a9e5-4f0d-b00c-a51a1a18c6b4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(614, 176),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("26eee7a8-6134-4ef9-b114-ddab59ddb05b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowDistributionConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowDistribution",
				UId = new Guid("a0c89092-ae72-4c59-8105-e575a38e00ae"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{71939dca-8599-4c6d-963d-6537e0a150d0}].[Parameter:{410ce1cd-f5a9-43a4-81dd-e3ddcc55020d}].[EntityColumn:{bc0c2d60-5a3d-4840-aa4e-c60ea776e206}]#] == [#Lookup.22341cd1-5b33-4c40-9011-6f7693ef6e44.14cfc644-e3ed-497e-8279-ed4319bb8093#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(558, 176),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(659, 93));
			schemaFlow.PolylinePointPositions.Add(new Point(988, 93));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowQualificationConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowQualification",
				UId = new Guid("8fec8235-b166-461e-80f2-57875b3de386"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{71939dca-8599-4c6d-963d-6537e0a150d0}].[Parameter:{410ce1cd-f5a9-43a4-81dd-e3ddcc55020d}].[EntityColumn:{bc0c2d60-5a3d-4840-aa4e-c60ea776e206}]#] == [#Lookup.22341cd1-5b33-4c40-9011-6f7693ef6e44.d790a45d-03ff-4ddb-9dea-8087722c582c#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(500, 200),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowAfterDistributionSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlowAfterDistribution",
				UId = new Guid("8fa29a01-73ae-4bf7-8fc7-34c3b2e582c0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(584, 173),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(988, 282));
			schemaFlow.PolylinePointPositions.Add(new Point(533, 282));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowHandoffConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowHandoff",
				UId = new Guid("ad137d98-4229-4ff5-80f9-7b1a5c112e9d"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{71939dca-8599-4c6d-963d-6537e0a150d0}].[Parameter:{410ce1cd-f5a9-43a4-81dd-e3ddcc55020d}].[EntityColumn:{bc0c2d60-5a3d-4840-aa4e-c60ea776e206}]#] == [#Lookup.22341cd1-5b33-4c40-9011-6f7693ef6e44.ceb70b3c-985f-4867-ae7c-88f9dd710688#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(868, 124),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bf4fdb46-796a-4290-9134-de7fe2eab40d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(659, 51));
			schemaFlow.PolylinePointPositions.Add(new Point(1114, 51));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowAfterHandoffSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlowAfterHandoff",
				UId = new Guid("8cfa3ed4-1d9d-48dc-89a7-4137c4a46f71"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(800, 177),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bf4fdb46-796a-4290-9134-de7fe2eab40d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1114, 303));
			schemaFlow.PolylinePointPositions.Add(new Point(533, 303));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowAwaitingSalesConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowAwaitingSales",
				UId = new Guid("59385c40-88e6-4ba2-bb3c-9e0830ba6c41"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{71939dca-8599-4c6d-963d-6537e0a150d0}].[Parameter:{410ce1cd-f5a9-43a4-81dd-e3ddcc55020d}].[EntityColumn:{bc0c2d60-5a3d-4840-aa4e-c60ea776e206}]#] == [#Lookup.22341cd1-5b33-4c40-9011-6f7693ef6e44.7a90900b-53b5-4598-92b3-0aee90626c56#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(928, 120),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a9a73c32-a953-4b47-a375-b5b163a62fed"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(659, 9));
			schemaFlow.PolylinePointPositions.Add(new Point(1240, 9));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowAfterAwaitingSalesSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlowAfterAwaitingSales",
				UId = new Guid("8a5adc56-96f6-44aa-9c8e-235a05d1306b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(863, 178),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a9a73c32-a953-4b47-a375-b5b163a62fed"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1240, 324));
			schemaFlow.PolylinePointPositions.Add(new Point(533, 324));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateReadLeadSequenceFlowSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "ReadLeadSequenceFlow",
				UId = new Guid("8a311f82-72c4-4049-bba9-95d238e4a0d8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(406, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a345f734-629f-4b63-ad21-12ca047e4c89"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateAttachLeadSequenceFlowSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "AttachLeadSequenceFlow",
				UId = new Guid("580a67d9-18bb-4a27-9a36-607b69144423"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c4378b15-b4d5-4764-beda-4087a06455d5"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				CurveCenterPosition = new Point(263, 161),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1068b0b8-c902-43c4-8b8e-53cf6cc6d058"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a345f734-629f-4b63-ad21-12ca047e4c89"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLeadManagementLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaLeadManagementLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("82ac26ed-ce03-4305-a802-e8b49e625913"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"LeadManagementLaneSet",
				Position = new Point(5, 5),
				Size = new Size(1318, 402),
				UseBackgroundMode = false
			};
			return schemaLeadManagementLaneSet;
		}

		protected virtual ProcessSchemaLane CreateLeadManagementLaneLane() {
			ProcessSchemaLane schemaLeadManagementLane = new ProcessSchemaLane(this) {
				UId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("82ac26ed-ce03-4305-a802-e8b49e625913"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"LeadManagementLane",
				Position = new Point(29, 0),
				Size = new Size(1289, 402),
				UseBackgroundMode = false
			};
			return schemaLeadManagementLane;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayStageExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"ExclusiveGatewayStage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(631, 128),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"ReadLeadData",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(498, 128),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaSubProcess CreateQualificationSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaQualificationSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"QualificationSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(827, 128),
				SchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				SerializeToDB = false,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = true
			};
			InitializeQualificationSubProcessParameters(schemaQualificationSubProcess);
			return schemaQualificationSubProcess;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("26eee7a8-6134-4ef9-b114-ddab59ddb05b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"TerminateProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(645, 226),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaSubProcess CreateDistributionSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaDistributionSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"DistributionSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(953, 128),
				SchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = true
			};
			InitializeDistributionSubProcessParameters(schemaDistributionSubProcess);
			return schemaDistributionSubProcess;
		}

		protected virtual ProcessSchemaScriptTask CreateAttachLeadToProcessScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a345f734-629f-4b63-ad21-12ca047e4c89"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"AttachLeadToProcessScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(232, 128),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,206,187,10,194,48,20,6,224,217,66,223,33,100,202,129,146,23,232,88,58,4,28,42,82,156,67,114,138,129,54,105,79,18,84,196,119,55,85,55,231,255,194,231,38,38,142,168,173,178,82,197,126,89,211,67,0,176,103,93,29,8,83,38,207,38,61,71,108,235,234,85,87,30,111,108,92,173,78,40,198,136,212,5,239,209,36,23,124,195,248,254,193,161,204,228,25,147,224,167,172,103,55,57,163,247,120,160,96,48,70,101,121,195,186,48,231,197,203,65,147,94,48,33,137,81,89,248,236,46,87,36,20,188,180,96,167,108,229,65,252,181,191,84,0,217,223,209,228,2,129,66,251,73,19,101,108,223,168,174,143,80,208,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaSubProcess CreateHandoffSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaHandoffSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("bf4fdb46-796a-4290-9134-de7fe2eab40d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"HandoffSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1079, 128),
				SchemaUId = new Guid("7ee7590a-758b-4ee3-990c-188743946765"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeHandoffSubProcessParameters(schemaHandoffSubProcess);
			return schemaHandoffSubProcess;
		}

		protected virtual ProcessSchemaSubProcess CreateAwaitingSalesSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaAwaitingSalesSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("a9a73c32-a953-4b47-a375-b5b163a62fed"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"AwaitingSalesSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1205, 128),
				SchemaUId = new Guid("6c2f6588-5216-4902-9d51-e0adf8a1201a"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeAwaitingSalesSubProcessParameters(schemaAwaitingSalesSubProcess);
			return schemaAwaitingSalesSubProcess;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("1068b0b8-c902-43c4-8b8e-53cf6cc6d058"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2dff3312-98bc-4d7a-a7b0-f854e675b32a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c4378b15-b4d5-4764-beda-4087a06455d5"),
				CreatedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"),
				Name = @"Start1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(78, 142),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagement(userConnection);
		}

		public override object Clone() {
			return new LeadManagementSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagement

	/// <exclude/>
	public class LeadManagement : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLeadManagementLane

		/// <exclude/>
		public class ProcessLeadManagementLane : ProcessLane
		{

			public ProcessLeadManagementLane(UserConnection userConnection, LeadManagement process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ReadLeadDataFlowElement

		/// <exclude/>
		public class ReadLeadDataFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadLeadDataFlowElement(UserConnection userConnection, LeadManagement process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadData";
				IsLogging = true;
				SchemaElementUId = new Guid("71939dca-8599-4c6d-963d-6537e0a150d0");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,205,106,220,48,20,133,223,69,139,174,172,162,63,219,178,187,28,166,101,54,105,160,105,41,36,67,184,150,174,50,2,255,76,108,153,38,152,121,146,190,70,23,125,140,121,164,202,227,76,10,89,132,208,93,193,139,171,43,157,163,239,30,228,233,214,15,31,125,29,176,47,29,212,3,38,227,198,150,68,26,5,90,166,41,181,92,91,170,156,200,169,22,80,80,149,67,202,152,19,10,101,65,146,22,26,44,201,162,94,91,31,72,226,3,54,67,121,61,253,53,13,253,136,201,173,59,45,190,152,29,54,240,117,190,64,113,112,186,192,130,230,41,171,168,194,170,162,218,128,161,206,201,162,202,148,86,28,13,89,88,84,198,25,207,29,167,169,19,145,192,161,166,21,103,154,162,117,76,102,194,178,44,175,72,82,163,11,235,135,125,143,195,224,187,182,156,240,185,190,122,220,71,202,229,238,85,87,143,77,75,146,6,3,92,66,216,149,4,144,161,74,13,80,163,138,116,118,207,41,200,194,82,9,85,46,114,141,60,227,57,73,12,236,195,108,75,54,150,36,22,2,124,131,122,196,147,243,228,35,163,144,140,235,52,139,90,46,13,85,82,48,170,51,157,83,103,51,87,160,204,138,162,178,231,188,62,141,62,214,126,184,24,27,236,189,121,138,29,99,126,93,95,78,166,107,67,223,213,179,245,197,233,248,21,62,132,37,220,167,173,239,203,64,33,246,103,17,57,36,227,128,171,218,99,27,214,173,233,172,111,239,22,207,195,33,74,154,61,244,126,56,167,176,190,31,161,38,73,239,239,118,175,166,181,26,135,208,53,255,209,168,73,28,51,122,196,71,118,194,157,223,160,245,195,190,134,199,211,186,36,239,238,199,46,124,56,254,60,254,62,254,90,106,242,66,83,146,27,98,13,56,38,82,164,170,48,154,42,129,64,181,19,150,50,231,192,114,87,229,40,229,13,137,28,255,228,126,189,25,62,255,104,207,255,193,66,190,125,31,187,47,26,151,103,101,57,189,5,232,176,157,145,182,135,248,253,1,61,113,12,15,206,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,73,77,76,241,75,204,77,181,50,180,50,4,0,119,185,58,103,19,0,0,0 })));
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

		#region Class: QualificationSubProcessFlowElement

		/// <exclude/>
		public class QualificationSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public QualificationSubProcessFlowElement(UserConnection userConnection, LeadManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645");
			}

			#endregion

			#region Properties: Public

			public Guid LeadId {
				get {
					return GetParameterValue<Guid>("LeadId");
				}
				set {
					SetParameterValue("LeadId", value);
				}
			}

			public Guid AccountId {
				get {
					return GetParameterValue<Guid>("AccountId");
				}
				set {
					SetParameterValue("AccountId", value);
				}
			}

			public Guid ContactId {
				get {
					return GetParameterValue<Guid>("ContactId");
				}
				set {
					SetParameterValue("ContactId", value);
				}
			}

			public Guid LeadAddressType {
				get {
					return GetParameterValue<Guid>("LeadAddressType");
				}
				set {
					SetParameterValue("LeadAddressType", value);
				}
			}

			public Guid LeadCity {
				get {
					return GetParameterValue<Guid>("LeadCity");
				}
				set {
					SetParameterValue("LeadCity", value);
				}
			}

			public string LeadZip {
				get {
					return GetParameterValue<string>("LeadZip");
				}
				set {
					SetParameterValue("LeadZip", value);
				}
			}

			public Guid LeadRegion {
				get {
					return GetParameterValue<Guid>("LeadRegion");
				}
				set {
					SetParameterValue("LeadRegion", value);
				}
			}

			public Guid LeadCountry {
				get {
					return GetParameterValue<Guid>("LeadCountry");
				}
				set {
					SetParameterValue("LeadCountry", value);
				}
			}

			public string LeadWebsite {
				get {
					return GetParameterValue<string>("LeadWebsite");
				}
				set {
					SetParameterValue("LeadWebsite", value);
				}
			}

			public string LeadFax {
				get {
					return GetParameterValue<string>("LeadFax");
				}
				set {
					SetParameterValue("LeadFax", value);
				}
			}

			public string LeadBusinessPhone {
				get {
					return GetParameterValue<string>("LeadBusinessPhone");
				}
				set {
					SetParameterValue("LeadBusinessPhone", value);
				}
			}

			public string LeadEmail {
				get {
					return GetParameterValue<string>("LeadEmail");
				}
				set {
					SetParameterValue("LeadEmail", value);
				}
			}

			public string LeadMobilePhone {
				get {
					return GetParameterValue<string>("LeadMobilePhone");
				}
				set {
					SetParameterValue("LeadMobilePhone", value);
				}
			}

			public Guid LeadDecisionRole {
				get {
					return GetParameterValue<Guid>("LeadDecisionRole");
				}
				set {
					SetParameterValue("LeadDecisionRole", value);
				}
			}

			public Guid LeadGender {
				get {
					return GetParameterValue<Guid>("LeadGender");
				}
				set {
					SetParameterValue("LeadGender", value);
				}
			}

			public Guid LeadDepartment {
				get {
					return GetParameterValue<Guid>("LeadDepartment");
				}
				set {
					SetParameterValue("LeadDepartment", value);
				}
			}

			public Guid LeadJob {
				get {
					return GetParameterValue<Guid>("LeadJob");
				}
				set {
					SetParameterValue("LeadJob", value);
				}
			}

			public Guid LeadSalutation {
				get {
					return GetParameterValue<Guid>("LeadSalutation");
				}
				set {
					SetParameterValue("LeadSalutation", value);
				}
			}

			public string LeadDear {
				get {
					return GetParameterValue<string>("LeadDear");
				}
				set {
					SetParameterValue("LeadDear", value);
				}
			}

			public string LeadFullJobTitle {
				get {
					return GetParameterValue<string>("LeadFullJobTitle");
				}
				set {
					SetParameterValue("LeadFullJobTitle", value);
				}
			}

			public string LeadContactName {
				get {
					return GetParameterValue<string>("LeadContactName");
				}
				set {
					SetParameterValue("LeadContactName", value);
				}
			}

			public string LeadAccountName {
				get {
					return GetParameterValue<string>("LeadAccountName");
				}
				set {
					SetParameterValue("LeadAccountName", value);
				}
			}

			public Guid LeadAnnualRevenue {
				get {
					return GetParameterValue<Guid>("LeadAnnualRevenue");
				}
				set {
					SetParameterValue("LeadAnnualRevenue", value);
				}
			}

			public Guid LeadEmployeesNumber {
				get {
					return GetParameterValue<Guid>("LeadEmployeesNumber");
				}
				set {
					SetParameterValue("LeadEmployeesNumber", value);
				}
			}

			public Guid LeadAccountCategory {
				get {
					return GetParameterValue<Guid>("LeadAccountCategory");
				}
				set {
					SetParameterValue("LeadAccountCategory", value);
				}
			}

			public Guid LeadIndustry {
				get {
					return GetParameterValue<Guid>("LeadIndustry");
				}
				set {
					SetParameterValue("LeadIndustry", value);
				}
			}

			public Guid LeadOwnership {
				get {
					return GetParameterValue<Guid>("LeadOwnership");
				}
				set {
					SetParameterValue("LeadOwnership", value);
				}
			}

			public Guid LeadAccountId {
				get {
					return GetParameterValue<Guid>("LeadAccountId");
				}
				set {
					SetParameterValue("LeadAccountId", value);
				}
			}

			public Guid LeadContactId {
				get {
					return GetParameterValue<Guid>("LeadContactId");
				}
				set {
					SetParameterValue("LeadContactId", value);
				}
			}

			public string LeadAddress {
				get {
					return GetParameterValue<string>("LeadAddress");
				}
				set {
					SetParameterValue("LeadAddress", value);
				}
			}

			public bool CreateAccountOnQualification {
				get {
					return GetParameterValue<bool>("CreateAccountOnQualification");
				}
				set {
					SetParameterValue("CreateAccountOnQualification", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (LeadManagement)owner;
				Name = "QualificationSubProcess";
				SerializeToDB = false;
				IsLogging = false;
				SchemaElementUId = new Guid("00173f2d-130c-458b-950c-ccbef1bc016e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.LeadManagementLane;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (LeadManagement)Owner;
				SetParameterValue("LeadId", (Guid)((process.LeadId)));
			}

			#endregion

		}

		#endregion

		#region Class: DistributionSubProcessFlowElement

		/// <exclude/>
		public class DistributionSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public DistributionSubProcessFlowElement(UserConnection userConnection, LeadManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("d6c59ced-f94c-477d-aef1-7418c7544cfe");
			}

			#endregion

			#region Properties: Public

			public Guid LeadId {
				get {
					return GetParameterValue<Guid>("LeadId");
				}
				set {
					SetParameterValue("LeadId", value);
				}
			}

			public bool CreateReminder {
				get {
					return GetParameterValue<bool>("CreateReminder");
				}
				set {
					SetParameterValue("CreateReminder", value);
				}
			}

			public Guid ResponsibleId {
				get {
					return GetParameterValue<Guid>("ResponsibleId");
				}
				set {
					SetParameterValue("ResponsibleId", value);
				}
			}

			public bool ShowDistributionPage {
				get {
					return GetParameterValue<bool>("ShowDistributionPage");
				}
				set {
					SetParameterValue("ShowDistributionPage", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (LeadManagement)owner;
				Name = "DistributionSubProcess";
				SerializeToDB = true;
				IsLogging = false;
				SchemaElementUId = new Guid("60e186ba-1d76-49c6-9960-3f9af79ce90f");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.LeadManagementLane;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (LeadManagement)Owner;
				SetParameterValue("LeadId", (Guid)((process.LeadId)));
				SetParameterValue("ShowDistributionPage", (bool)((process.ShowDistributionPage)));
			}

			#endregion

		}

		#endregion

		#region Class: HandoffSubProcessFlowElement

		/// <exclude/>
		public class HandoffSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public HandoffSubProcessFlowElement(UserConnection userConnection, LeadManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("7ee7590a-758b-4ee3-990c-188743946765");
			}

			#endregion

			#region Properties: Public

			public Guid LeadId {
				get {
					return GetParameterValue<Guid>("LeadId");
				}
				set {
					SetParameterValue("LeadId", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (LeadManagement)owner;
				Name = "HandoffSubProcess";
				SerializeToDB = true;
				IsLogging = false;
				SchemaElementUId = new Guid("bf4fdb46-796a-4290-9134-de7fe2eab40d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.LeadManagementLane;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (LeadManagement)Owner;
				SetParameterValue("LeadId", (Guid)((process.LeadId)));
			}

			#endregion

		}

		#endregion

		#region Class: AwaitingSalesSubProcessFlowElement

		/// <exclude/>
		public class AwaitingSalesSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public AwaitingSalesSubProcessFlowElement(UserConnection userConnection, LeadManagement process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("6c2f6588-5216-4902-9d51-e0adf8a1201a");
			}

			#endregion

			#region Properties: Public

			public Guid LeadId {
				get {
					return GetParameterValue<Guid>("LeadId");
				}
				set {
					SetParameterValue("LeadId", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (LeadManagement)owner;
				Name = "AwaitingSalesSubProcess";
				SerializeToDB = true;
				IsLogging = false;
				SchemaElementUId = new Guid("a9a73c32-a953-4b47-a375-b5b163a62fed");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.LeadManagementLane;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (LeadManagement)Owner;
				SetParameterValue("LeadId", (Guid)((process.LeadId)));
			}

			#endregion

		}

		#endregion

		public LeadManagement(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagement";
			SchemaUId = new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6");
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
				return new Guid("d46cf489-214a-4b65-9521-9d01138f2ea6");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagement, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagement, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid LeadId {
			get;
			set;
		}

		public virtual bool ShowDistributionPage {
			get;
			set;
		}

		private ProcessLeadManagementLane _leadManagementLane;
		public ProcessLeadManagementLane LeadManagementLane {
			get {
				return _leadManagementLane ?? ((_leadManagementLane) = new ProcessLeadManagementLane(UserConnection, this));
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayStage;
		public ProcessExclusiveGateway ExclusiveGatewayStage {
			get {
				return _exclusiveGatewayStage ?? (_exclusiveGatewayStage = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayStage",
					SchemaElementUId = new Guid("1730fd69-e909-49b4-bee7-2e358d794c12"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayStage.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ReadLeadDataFlowElement _readLeadData;
		public ReadLeadDataFlowElement ReadLeadData {
			get {
				return _readLeadData ?? (_readLeadData = new ReadLeadDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private QualificationSubProcessFlowElement _qualificationSubProcess;
		public QualificationSubProcessFlowElement QualificationSubProcess {
			get {
				return _qualificationSubProcess ?? ((_qualificationSubProcess) = new QualificationSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessTerminateEvent _terminateProcess;
		public ProcessTerminateEvent TerminateProcess {
			get {
				return _terminateProcess ?? (_terminateProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateProcess",
					SchemaElementUId = new Guid("26eee7a8-6134-4ef9-b114-ddab59ddb05b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private DistributionSubProcessFlowElement _distributionSubProcess;
		public DistributionSubProcessFlowElement DistributionSubProcess {
			get {
				return _distributionSubProcess ?? ((_distributionSubProcess) = new DistributionSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _attachLeadToProcessScriptTask;
		public ProcessScriptTask AttachLeadToProcessScriptTask {
			get {
				return _attachLeadToProcessScriptTask ?? (_attachLeadToProcessScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "AttachLeadToProcessScriptTask",
					SchemaElementUId = new Guid("a345f734-629f-4b63-ad21-12ca047e4c89"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = AttachLeadToProcessScriptTaskExecute,
				});
			}
		}

		private HandoffSubProcessFlowElement _handoffSubProcess;
		public HandoffSubProcessFlowElement HandoffSubProcess {
			get {
				return _handoffSubProcess ?? ((_handoffSubProcess) = new HandoffSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AwaitingSalesSubProcessFlowElement _awaitingSalesSubProcess;
		public AwaitingSalesSubProcessFlowElement AwaitingSalesSubProcess {
			get {
				return _awaitingSalesSubProcess ?? ((_awaitingSalesSubProcess) = new AwaitingSalesSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("1068b0b8-c902-43c4-8b8e-53cf6cc6d058"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowDistribution;
		public ProcessConditionalFlow ConditionalFlowDistribution {
			get {
				return _conditionalFlowDistribution ?? (_conditionalFlowDistribution = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowDistribution",
					SchemaElementUId = new Guid("a0c89092-ae72-4c59-8105-e575a38e00ae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowQualification;
		public ProcessConditionalFlow ConditionalFlowQualification {
			get {
				return _conditionalFlowQualification ?? (_conditionalFlowQualification = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowQualification",
					SchemaElementUId = new Guid("8fec8235-b166-461e-80f2-57875b3de386"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowHandoff;
		public ProcessConditionalFlow ConditionalFlowHandoff {
			get {
				return _conditionalFlowHandoff ?? (_conditionalFlowHandoff = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowHandoff",
					SchemaElementUId = new Guid("ad137d98-4229-4ff5-80f9-7b1a5c112e9d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlowAwaitingSales;
		public ProcessConditionalFlow ConditionalFlowAwaitingSales {
			get {
				return _conditionalFlowAwaitingSales ?? (_conditionalFlowAwaitingSales = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlowAwaitingSales",
					SchemaElementUId = new Guid("59385c40-88e6-4ba2-bb3c-9e0830ba6c41"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _exclusiveGatewayStageQualificationSubProcessToken;
		public ProcessToken ExclusiveGatewayStageQualificationSubProcessToken {
			get {
				return _exclusiveGatewayStageQualificationSubProcessToken ?? (_exclusiveGatewayStageQualificationSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGatewayStageQualificationSubProcessToken",
					SchemaElementUId = new Guid("51033747-6996-4c1e-a9a1-06bb93d1d273"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _exclusiveGatewayStageDistributionSubProcessToken;
		public ProcessToken ExclusiveGatewayStageDistributionSubProcessToken {
			get {
				return _exclusiveGatewayStageDistributionSubProcessToken ?? (_exclusiveGatewayStageDistributionSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGatewayStageDistributionSubProcessToken",
					SchemaElementUId = new Guid("9cfb90da-2eef-4644-b1f9-4eaa73a0ae95"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _exclusiveGatewayStageHandoffSubProcessToken;
		public ProcessToken ExclusiveGatewayStageHandoffSubProcessToken {
			get {
				return _exclusiveGatewayStageHandoffSubProcessToken ?? (_exclusiveGatewayStageHandoffSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGatewayStageHandoffSubProcessToken",
					SchemaElementUId = new Guid("62fe82e8-336c-4bca-99e2-5924fe1f3a67"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _exclusiveGatewayStageAwaitingSalesSubProcessToken;
		public ProcessToken ExclusiveGatewayStageAwaitingSalesSubProcessToken {
			get {
				return _exclusiveGatewayStageAwaitingSalesSubProcessToken ?? (_exclusiveGatewayStageAwaitingSalesSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGatewayStageAwaitingSalesSubProcessToken",
					SchemaElementUId = new Guid("4c7008fc-6d13-4a90-956b-b43c3bd42628"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ExclusiveGatewayStage.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayStage };
			FlowElements[ReadLeadData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadData };
			FlowElements[QualificationSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { QualificationSubProcess };
			FlowElements[TerminateProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateProcess };
			FlowElements[DistributionSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { DistributionSubProcess };
			FlowElements[AttachLeadToProcessScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AttachLeadToProcessScriptTask };
			FlowElements[HandoffSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { HandoffSubProcess };
			FlowElements[AwaitingSalesSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { AwaitingSalesSubProcess };
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[ExclusiveGatewayStageQualificationSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayStageQualificationSubProcessToken };
			FlowElements[ExclusiveGatewayStageDistributionSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayStageDistributionSubProcessToken };
			FlowElements[ExclusiveGatewayStageHandoffSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayStageHandoffSubProcessToken };
			FlowElements[ExclusiveGatewayStageAwaitingSalesSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayStageAwaitingSalesSubProcessToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ExclusiveGatewayStage":
						if (ConditionalFlowDistributionExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayStageDistributionSubProcessToken", e.Context.SenderName));
							break;
						}
						if (ConditionalFlowQualificationExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayStageQualificationSubProcessToken", e.Context.SenderName));
							break;
						}
						if (ConditionalFlowHandoffExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayStageHandoffSubProcessToken", e.Context.SenderName));
							break;
						}
						if (ConditionalFlowAwaitingSalesExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayStageAwaitingSalesSubProcessToken", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateProcess", e.Context.SenderName));
						break;
					case "ReadLeadData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayStage", e.Context.SenderName));
						break;
					case "QualificationSubProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "TerminateProcess":
						CompleteProcess();
						break;
					case "DistributionSubProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "AttachLeadToProcessScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "HandoffSubProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "AwaitingSalesSubProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AttachLeadToProcessScriptTask", e.Context.SenderName));
						break;
					case "ExclusiveGatewayStageQualificationSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("QualificationSubProcess", e.Context.SenderName));
						break;
					case "ExclusiveGatewayStageDistributionSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DistributionSubProcess", e.Context.SenderName));
						break;
					case "ExclusiveGatewayStageHandoffSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("HandoffSubProcess", e.Context.SenderName));
						break;
					case "ExclusiveGatewayStageAwaitingSalesSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AwaitingSalesSubProcess", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlowDistributionExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualifyStatus").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("QualifyStatusId") : Guid.Empty)) == new Guid("14cfc644-e3ed-497e-8279-ed4319bb8093"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayStage", "ConditionalFlowDistribution", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"QualifyStatus\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>(\"QualifyStatusId\") : Guid.Empty)) == new Guid(\"14cfc644-e3ed-497e-8279-ed4319bb8093\")", result);
			return result;
		}

		private bool ConditionalFlowQualificationExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualifyStatus").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("QualifyStatusId") : Guid.Empty)) == new Guid("d790a45d-03ff-4ddb-9dea-8087722c582c"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayStage", "ConditionalFlowQualification", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"QualifyStatus\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>(\"QualifyStatusId\") : Guid.Empty)) == new Guid(\"d790a45d-03ff-4ddb-9dea-8087722c582c\")", result);
			return result;
		}

		private bool ConditionalFlowHandoffExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualifyStatus").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("QualifyStatusId") : Guid.Empty)) == new Guid("ceb70b3c-985f-4867-ae7c-88f9dd710688"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayStage", "ConditionalFlowHandoff", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"QualifyStatus\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>(\"QualifyStatusId\") : Guid.Empty)) == new Guid(\"ceb70b3c-985f-4867-ae7c-88f9dd710688\")", result);
			return result;
		}

		private bool ConditionalFlowAwaitingSalesExpressionExecute() {
			bool result = Convert.ToBoolean(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualifyStatus").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("QualifyStatusId") : Guid.Empty)) == new Guid("7a90900b-53b5-4598-92b3-0aee90626c56"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayStage", "ConditionalFlowAwaitingSales", "((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName(\"QualifyStatus\").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>(\"QualifyStatusId\") : Guid.Empty)) == new Guid(\"7a90900b-53b5-4598-92b3-0aee90626c56\")", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("LeadId")) {
				writer.WriteValue("LeadId", LeadId, Guid.Empty);
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
			MetaPathParameterValues.Add("dcaf025e-49c8-42ea-8f2d-0ffad1fb7e33", () => LeadId);
			MetaPathParameterValues.Add("76349b0a-e191-4050-abc2-0ee4dd58c60f", () => ShowDistributionPage);
			MetaPathParameterValues.Add("79d7c595-8697-4a57-a10a-79ee7ae30ce4", () => ReadLeadData.DataSourceFilters);
			MetaPathParameterValues.Add("a18edb14-dfeb-4d04-90bb-d26913e2ac5a", () => ReadLeadData.ResultType);
			MetaPathParameterValues.Add("af294c4d-71dd-4e98-b5ea-ca04bf60c63a", () => ReadLeadData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("02aa9ff0-24e7-4104-b3be-a9743c914f93", () => ReadLeadData.NumberOfRecords);
			MetaPathParameterValues.Add("366c7a6d-876d-435a-8556-d7b90838c1f2", () => ReadLeadData.FunctionType);
			MetaPathParameterValues.Add("e0614378-f986-43e1-abbc-202a6926f125", () => ReadLeadData.AggregationColumnName);
			MetaPathParameterValues.Add("23fa8dea-6c00-412e-9c43-408c3e68a1b9", () => ReadLeadData.OrderInfo);
			MetaPathParameterValues.Add("410ce1cd-f5a9-43a4-81dd-e3ddcc55020d", () => ReadLeadData.ResultEntity);
			MetaPathParameterValues.Add("32c199ed-0dd3-4cf1-818c-a1fe154b949b", () => ReadLeadData.ResultCount);
			MetaPathParameterValues.Add("dff9a69d-c27b-43d4-bb6f-65043863e873", () => ReadLeadData.ResultIntegerFunction);
			MetaPathParameterValues.Add("a8d7bc3f-493b-473f-9a5f-e05829be523a", () => ReadLeadData.ResultFloatFunction);
			MetaPathParameterValues.Add("b2e829b1-49d7-48b1-8ca0-11c5c2fb6a3f", () => ReadLeadData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("e2b7fb69-f082-4171-aa4b-62a5f4a7f7bf", () => ReadLeadData.ResultRowsCount);
			MetaPathParameterValues.Add("c38a2d93-07b6-45bb-8d39-cd8976a2f6e0", () => ReadLeadData.CanReadUncommitedData);
			MetaPathParameterValues.Add("be3f7962-de04-4446-b20d-854d0c23e8c9", () => ReadLeadData.ResultEntityCollection);
			MetaPathParameterValues.Add("04dce9b6-f80f-43f3-ab64-d3b51a737d1d", () => ReadLeadData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("62c4740f-9091-4733-97bc-8f6f4966d30e", () => ReadLeadData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("957d027e-ee69-4ed3-b7f7-5f37fdf8c9a4", () => ReadLeadData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d2e6c1cc-64d4-4482-acc5-d11dad3628ef", () => ReadLeadData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("eeb9b9b2-825c-436f-9921-05f3960028d4", () => QualificationSubProcess.LeadId);
			MetaPathParameterValues.Add("10e69e19-8c95-4d62-81b4-503111e906aa", () => QualificationSubProcess.AccountId);
			MetaPathParameterValues.Add("7fddaeb5-c6e0-480f-9676-30f009ff2c05", () => QualificationSubProcess.ContactId);
			MetaPathParameterValues.Add("99711985-137d-41cf-a3b7-4a85494d651d", () => QualificationSubProcess.LeadAddressType);
			MetaPathParameterValues.Add("d2d62cb2-50ce-4754-8b7c-20ed8b42c4b4", () => QualificationSubProcess.LeadCity);
			MetaPathParameterValues.Add("59ed428c-989b-4597-85e5-ec4d9d8356fb", () => QualificationSubProcess.LeadZip);
			MetaPathParameterValues.Add("efcd46e1-9bc7-4d35-8e20-7ac2ee8be116", () => QualificationSubProcess.LeadRegion);
			MetaPathParameterValues.Add("4e479c2d-1365-425e-b14b-e7f2158c06a3", () => QualificationSubProcess.LeadCountry);
			MetaPathParameterValues.Add("2cd8c2da-e379-46fb-b509-b8737a25a87f", () => QualificationSubProcess.LeadWebsite);
			MetaPathParameterValues.Add("4cc6cafe-0516-40bc-97b3-b5e71f487657", () => QualificationSubProcess.LeadFax);
			MetaPathParameterValues.Add("49d663bc-3ccb-4a5e-aedf-a5f9f46447b4", () => QualificationSubProcess.LeadBusinessPhone);
			MetaPathParameterValues.Add("47bc33cb-d759-4bb8-ad75-e71dc733eee1", () => QualificationSubProcess.LeadEmail);
			MetaPathParameterValues.Add("e164a6a3-88d8-4bb5-9bfe-c459a76ec7ff", () => QualificationSubProcess.LeadMobilePhone);
			MetaPathParameterValues.Add("cf6f0a84-e41d-4d4f-a15f-77d327d0cccf", () => QualificationSubProcess.LeadDecisionRole);
			MetaPathParameterValues.Add("a4b5e57a-9139-4777-9db5-146902df80aa", () => QualificationSubProcess.LeadGender);
			MetaPathParameterValues.Add("6d789022-045d-443b-b34b-0aa336be3e13", () => QualificationSubProcess.LeadDepartment);
			MetaPathParameterValues.Add("aaf509ea-15a4-419b-8fa8-500ac50c6ecf", () => QualificationSubProcess.LeadJob);
			MetaPathParameterValues.Add("cb90952a-c229-4b61-9ac9-d016ad9e3a4b", () => QualificationSubProcess.LeadSalutation);
			MetaPathParameterValues.Add("c63070fd-7eda-40db-82e0-701f84846784", () => QualificationSubProcess.LeadDear);
			MetaPathParameterValues.Add("ad2981e9-7c11-4c3d-9edd-f2c624c5c243", () => QualificationSubProcess.LeadFullJobTitle);
			MetaPathParameterValues.Add("82ae37f0-aa22-4258-af7c-a3fe6a41ccbe", () => QualificationSubProcess.LeadContactName);
			MetaPathParameterValues.Add("efa48aa1-faab-4ea1-89e7-a96c6ce2837d", () => QualificationSubProcess.LeadAccountName);
			MetaPathParameterValues.Add("b206ab98-e66d-4031-8c12-13b8738f9fcc", () => QualificationSubProcess.LeadAnnualRevenue);
			MetaPathParameterValues.Add("1420e38c-30a9-48fe-9163-9893548c89e3", () => QualificationSubProcess.LeadEmployeesNumber);
			MetaPathParameterValues.Add("04d43bf8-a0ab-4475-b724-69e8706c5820", () => QualificationSubProcess.LeadAccountCategory);
			MetaPathParameterValues.Add("a74798e5-72a3-4622-8e79-4545686f2b4f", () => QualificationSubProcess.LeadIndustry);
			MetaPathParameterValues.Add("5016eabe-e16f-44f2-91ac-000358b10554", () => QualificationSubProcess.LeadOwnership);
			MetaPathParameterValues.Add("a5f40093-ea65-4f4a-a10b-9fa0852612ca", () => QualificationSubProcess.LeadAccountId);
			MetaPathParameterValues.Add("98d88c5d-9ec8-446d-bb07-e2dcb6d0ccb0", () => QualificationSubProcess.LeadContactId);
			MetaPathParameterValues.Add("c376c603-36de-4889-8393-2370fdf07849", () => QualificationSubProcess.LeadAddress);
			MetaPathParameterValues.Add("0a958b03-2bb4-46e1-9fe8-0bdb1538eae6", () => QualificationSubProcess.CreateAccountOnQualification);
			MetaPathParameterValues.Add("c20f32d7-b843-4b74-8e39-3a6890ba55ff", () => DistributionSubProcess.LeadId);
			MetaPathParameterValues.Add("ca0ec7ac-1d90-4b8b-bcb9-9206dc58ea25", () => DistributionSubProcess.CreateReminder);
			MetaPathParameterValues.Add("5085de2a-f04e-4378-bfab-51bbac41aa61", () => DistributionSubProcess.ResponsibleId);
			MetaPathParameterValues.Add("aa63d8d4-2a94-4731-9a3d-b9b2be3fdb0d", () => DistributionSubProcess.ShowDistributionPage);
			MetaPathParameterValues.Add("012cc585-99f3-4ed1-8ccd-d387890c425e", () => HandoffSubProcess.LeadId);
			MetaPathParameterValues.Add("68e66100-46fa-4d20-a6ba-fbaf9d940720", () => AwaitingSalesSubProcess.LeadId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "LeadId":
					if (!hasValueToRead) break;
					LeadId = reader.GetValue<System.Guid>();
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

		public virtual bool AttachLeadToProcessScriptTaskExecute(ProcessExecutingContext context) {
			if (LeadId.IsEmpty()) {
				return false;
			}
			new Update(UserConnection, "Lead")
				.Set("QualificationProcessId", Column.Parameter(UId))
				.Where("Id").IsEqual(Column.Parameter(LeadId)).Execute();
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
			var cloneItem = (LeadManagement)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

