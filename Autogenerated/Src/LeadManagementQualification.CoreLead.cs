namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
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
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: LeadManagementQualificationSchema

	/// <exclude/>
	public class LeadManagementQualificationSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementQualificationSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementQualificationSchema(LeadManagementQualificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagementQualification";
			UId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645");
			CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2936";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = false;
			Tag = @"LeadManagementQualification";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645");
			Version = 0;
			PackageUId = new Guid("34a08715-d94b-478c-887e-dbb951baceeb");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateLeadIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7da3d394-c5b2-4fba-be47-747a00d3685e"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("adff468f-5785-4238-a962-2d46a6df9207"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("21f03e5d-1b78-48dc-9e30-1c86f9161488"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAddressTypeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2365f649-230d-4d6e-b38b-15932b94c2d9"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{66852a75-b22e-4390-a8df-49814cdb0131}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadCityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a00b4828-9039-473d-9786-1042a8a4d495"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{4258b690-fe71-4b7a-8278-f0a7b9dd4780}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadZipParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b9c2234b-9f29-4b4b-bff9-43ed0aee7fd4"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadRegionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b120b526-724c-470e-9bde-cca7c5bce38b"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{dce30e38-3b37-40b3-b9f5-08b790d93420}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadCountryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7f25c2c6-3a0b-430a-b8f4-14dac4a33300"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{d79b4d09-4791-4993-952b-e097088b55c6}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadWebsiteParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7573b5d0-d90d-43fb-a4ff-b434212f304d"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadFaxParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ef248d37-29b4-41f3-ae05-29aa2ca78c1e"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadBusinessPhoneParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("237e51db-51d4-40d3-ba2e-657d419fe693"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6547686a-48b1-457a-810e-01431f20fcf7"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadMobilePhoneParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f609b031-6cfd-4dbc-9110-5a3c4aaf1d59"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadDecisionRoleParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7d3339ff-d4dd-47f4-aad0-f962a3c06682"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{4a577f44-6cf7-40d0-b1f8-81c2cf6539d1}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadGenderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("26e960a5-407f-49ef-9aeb-194c10c5c07a"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{257a1321-f45d-4868-bf44-e9f2297661d3}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadDepartmentParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8ad4103a-0d1e-4f62-a22a-707a1d45a404"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{c7fb190e-51d8-4c65-a5db-c3714d3b0af7}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadJobParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a0f4b101-277c-452d-94c8-b44202a3a196"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{aa8c19b4-a8fb-4284-b969-8f15630a25ec}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadSalutationParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f34298ea-de28-49a3-a7dd-0537e9d81810"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{afdaca14-10c0-4767-b1f4-ed06946d37eb}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadDearParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("61ebe384-47c3-41a5-8f7a-689cc754debd"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadFullJobTitleParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("69d73113-cfb5-46b5-bad8-db01b0089ad7"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadContactNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9ccf4757-79ad-4fda-8a8d-091f07d873c6"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAccountNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d7cbdc44-a5b7-48dc-bbaf-a96bd83d7066"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAnnualRevenueParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("485ac59c-8ec0-45f6-b314-99549ce9eedf"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{718683e1-7d00-48d6-ad3f-c882ee2ce79f}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadEmployeesNumberParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("81219640-87de-43de-9f88-0867fbbd7c43"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{49508aa7-fa69-4ce3-aa4d-1eeb2c9d73a5}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAccountCategoryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("347c7337-e229-470b-a321-5aa2e5a4d102"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{a3200694-9a9a-42a6-824f-870d5b03e255}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadIndustryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7ab43aa0-0265-44da-baf7-13ae2e552bfe"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{2edaf1d4-f64e-4351-aa6b-c81a7ebfc108}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadOwnershipParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5b328e21-1e24-46e8-a579-71076a3c942a"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{6a7045c5-ab82-4bf9-a929-9ac065c69343}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ae489f7c-9167-44af-a723-c61c0541a93a"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{32949ae4-ff13-48f5-9f5d-45a74558ea55}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f302fbc3-0ce9-4626-9957-2cf93197d6fd"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{ad490d58-054a-4d85-9246-dd8466eb3983}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c945f2af-1eae-4ba3-a433-a8ea8b69d8b1"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateAccountOnQualificationParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("70ebb313-bd3c-472f-bf4f-f07a23506a9c"),
				ContainerUId = Guid.Empty,
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a188ff27-c185-4b79-b24c-71503e5df1a6}].[Parameter:{411b2f2b-abb2-49c4-b63c-c589bc81bb8c}].[EntityColumn:{297f4697-d071-4be2-8509-9090c07dfe18}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateLeadIdParameter());
			Parameters.Add(CreateAccountIdParameter());
			Parameters.Add(CreateContactIdParameter());
			Parameters.Add(CreateLeadAddressTypeParameter());
			Parameters.Add(CreateLeadCityParameter());
			Parameters.Add(CreateLeadZipParameter());
			Parameters.Add(CreateLeadRegionParameter());
			Parameters.Add(CreateLeadCountryParameter());
			Parameters.Add(CreateLeadWebsiteParameter());
			Parameters.Add(CreateLeadFaxParameter());
			Parameters.Add(CreateLeadBusinessPhoneParameter());
			Parameters.Add(CreateLeadEmailParameter());
			Parameters.Add(CreateLeadMobilePhoneParameter());
			Parameters.Add(CreateLeadDecisionRoleParameter());
			Parameters.Add(CreateLeadGenderParameter());
			Parameters.Add(CreateLeadDepartmentParameter());
			Parameters.Add(CreateLeadJobParameter());
			Parameters.Add(CreateLeadSalutationParameter());
			Parameters.Add(CreateLeadDearParameter());
			Parameters.Add(CreateLeadFullJobTitleParameter());
			Parameters.Add(CreateLeadContactNameParameter());
			Parameters.Add(CreateLeadAccountNameParameter());
			Parameters.Add(CreateLeadAnnualRevenueParameter());
			Parameters.Add(CreateLeadEmployeesNumberParameter());
			Parameters.Add(CreateLeadAccountCategoryParameter());
			Parameters.Add(CreateLeadIndustryParameter());
			Parameters.Add(CreateLeadOwnershipParameter());
			Parameters.Add(CreateLeadAccountIdParameter());
			Parameters.Add(CreateLeadContactIdParameter());
			Parameters.Add(CreateLeadAddressParameter());
			Parameters.Add(CreateCreateAccountOnQualificationParameter());
		}

		protected virtual void InitializeReadLeadDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb174310-4f6b-4191-b705-5ac74e8d6810"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,219,146,45,201,61,46,219,178,80,210,64,211,82,72,150,48,146,70,89,129,63,54,182,76,19,204,254,247,202,235,108,10,57,148,210,91,65,135,209,104,222,155,55,143,209,124,31,198,143,161,137,56,212,30,154,17,233,180,115,53,81,50,171,148,45,21,227,86,35,19,185,171,152,66,101,24,47,164,41,84,174,140,178,64,104,7,45,214,100,69,111,93,136,132,134,136,237,88,223,206,191,73,227,48,33,189,247,231,203,87,123,192,22,190,45,13,68,14,94,105,212,76,150,153,97,2,141,97,137,210,50,239,185,54,149,80,34,71,75,86,45,168,185,149,214,8,230,164,45,153,240,94,50,237,83,169,54,170,244,186,200,115,144,21,161,13,250,184,125,58,14,56,142,161,239,234,25,95,227,155,231,99,82,185,246,222,244,205,212,118,132,182,24,225,26,226,161,38,128,25,138,210,2,179,66,47,236,40,25,112,237,24,7,35,11,169,48,175,114,73,168,133,99,92,104,201,206,17,234,32,194,119,104,38,60,51,207,33,105,44,120,150,171,178,74,216,156,91,38,120,145,49,85,41,201,188,171,188,70,94,105,109,220,197,175,79,83,72,113,24,175,166,22,135,96,95,108,199,228,95,63,212,179,237,187,56,244,205,66,125,117,46,191,193,167,184,154,251,242,244,99,29,40,166,252,2,34,39,58,141,184,105,2,118,113,219,217,222,133,238,97,229,60,157,18,164,61,194,16,198,139,11,219,199,9,26,66,135,240,112,248,163,91,155,105,140,125,251,31,141,74,211,152,137,35,45,217,89,238,178,131,46,140,199,6,158,207,247,154,188,123,156,250,248,225,51,130,91,35,242,6,81,147,59,34,29,112,199,181,96,182,52,69,218,5,3,204,160,144,76,10,9,89,230,120,165,74,188,35,73,197,63,112,223,238,198,47,63,187,203,31,88,85,239,223,167,236,155,196,245,5,89,207,127,35,231,180,95,4,237,79,233,252,2,53,129,193,231,202,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c5fddb8-7f3b-431c-a140-15c790c47997"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c9715250-2f51-47c6-ae51-692c6ef09e35"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7aa6f27f-9136-4c8a-95c8-d11d8c5dd57c"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("105c3fa8-1208-4d19-bf97-40057718c52f"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("001d410e-1ab8-4cd6-bb61-83ee17b39a5b"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a1588d18-597e-4d60-95bc-bd4c78338608"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("724a8768-9516-4d2c-aa88-41a1bb2d5e37"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1eb2f334-3b2d-4e66-96ae-e2c0468ec136"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("02e6f3dc-c3b7-48c5-b1bb-858d7d4b6706"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("552d4238-195d-4289-9c82-72b9a2a6cc13"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2ee6855b-3c07-41fe-9ed9-dce8afc87598"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d8c1e15f-029b-46de-8fb1-c9ab4e292106"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("30fc9f29-8bc3-4e4c-8238-8d93757cf810"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2ab23a86-7cff-4fa0-b600-4001d8b72aca"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fd8b3b5a-0afb-4d72-b51c-4907de28ec37"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d962028-129a-453e-8ba9-f69a2f78e60c"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("dc91c698-f36e-4d9e-a27e-2af4201959fd"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("214e4e0f-5eaf-4d51-bf9c-17715613f73d"),
				ContainerUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeChangeContactAccountParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("ea29a1a7-83b3-4850-9134-d716cf498910"),
				ContainerUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
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
				Value = @"16be3651-8fe2-4159-8dd0-a803d4683dd3",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2a3f5cb3-7035-42b2-9882-c80f7985168f"),
				ContainerUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d8e007f-f368-46a3-840e-c8c133b97854"),
				ContainerUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,43,65,135,158,60,197,178,100,91,118,143,203,182,236,37,77,105,90,2,73,8,35,105,148,21,248,99,99,203,52,193,236,127,175,188,206,182,144,67,233,161,151,130,14,210,72,239,205,123,143,209,252,224,199,143,190,9,52,212,14,155,145,146,105,103,107,166,114,237,164,171,50,112,156,19,72,41,16,116,90,57,176,174,212,28,93,37,181,40,89,210,97,75,53,91,209,91,235,3,75,124,160,118,172,111,231,223,164,97,152,40,121,112,167,195,87,179,167,22,191,45,13,120,161,73,20,57,7,229,40,3,201,243,10,148,181,41,160,74,133,149,133,18,214,10,182,106,113,133,205,172,174,16,82,165,11,144,70,58,64,148,6,156,206,164,70,99,140,83,81,75,67,46,108,159,15,3,141,163,239,187,122,166,95,251,235,151,67,84,185,246,222,244,205,212,118,44,105,41,224,21,134,125,205,144,82,146,185,65,48,178,202,65,58,42,1,69,101,65,160,46,179,82,17,47,120,100,55,120,8,11,45,219,89,150,88,12,248,29,155,137,78,204,179,143,26,51,145,114,149,23,17,203,133,1,41,178,20,84,161,74,112,182,112,85,52,90,85,218,158,243,250,52,249,184,247,227,229,212,210,224,205,107,236,20,243,235,135,122,54,125,23,134,190,89,168,47,79,207,175,233,57,172,225,190,94,221,172,134,66,172,47,32,118,76,166,145,54,141,167,46,108,59,211,91,223,61,174,156,199,99,132,180,7,28,252,120,78,97,251,52,97,195,146,193,63,238,255,152,214,102,26,67,223,254,71,86,147,104,51,114,196,33,59,201,93,102,208,250,241,208,224,203,233,92,179,119,79,83,31,62,124,137,246,189,243,100,47,112,188,88,154,160,9,235,13,123,195,80,179,59,150,113,151,10,202,45,112,93,42,144,202,26,136,14,83,224,70,69,175,113,50,164,82,119,44,170,250,7,189,110,119,227,231,31,221,249,143,172,174,238,223,199,234,155,194,213,25,89,207,127,35,239,120,191,8,188,63,198,245,19,156,38,180,91,234,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c0fe375b-e8e3-406d-b4a8-8783f94f8903"),
				ContainerUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,143,218,48,16,253,43,200,187,71,140,108,39,78,156,28,91,90,9,105,105,105,105,247,2,28,38,246,120,23,41,36,40,31,109,183,40,255,125,29,39,20,104,247,84,31,108,101,198,239,189,241,188,201,137,220,55,47,71,36,41,121,183,90,174,75,219,204,222,151,21,206,86,85,169,177,174,103,15,165,134,124,255,27,178,28,87,80,193,1,27,172,30,33,111,177,126,216,215,205,116,114,13,34,83,114,255,195,231,72,186,57,145,69,131,135,239,11,227,152,49,146,76,4,161,165,74,101,49,13,33,182,52,139,33,162,42,9,172,230,81,36,117,98,28,88,151,121,123,40,150,216,192,10,154,103,146,158,136,103,115,4,82,71,26,56,67,202,185,98,52,212,28,169,2,201,168,148,16,11,107,147,204,152,144,116,83,82,235,103,60,128,23,189,128,121,148,97,16,73,78,149,69,65,67,46,19,170,140,97,20,20,11,76,24,169,192,152,160,7,143,247,47,192,205,221,102,81,127,254,89,96,181,246,188,169,133,188,198,221,204,69,255,10,252,105,77,122,2,99,173,35,181,84,198,74,210,80,4,138,66,18,9,42,156,20,68,198,38,130,197,221,238,110,215,43,154,125,125,204,225,229,241,95,225,47,173,235,186,221,163,153,64,61,1,173,203,182,104,6,204,241,198,133,107,212,105,59,88,185,37,233,246,109,51,199,115,40,254,214,206,91,39,183,100,186,37,235,178,173,116,207,22,244,31,231,206,122,118,54,46,250,198,118,94,3,135,135,45,161,128,39,172,62,57,61,15,247,169,57,52,224,165,191,185,154,207,196,153,72,36,139,185,165,49,66,66,67,116,141,83,134,3,77,120,146,217,32,14,156,217,194,163,191,162,197,10,11,141,183,133,9,105,98,205,33,163,220,160,27,20,201,56,205,66,38,40,19,200,176,31,22,19,13,143,243,202,151,98,206,67,231,34,69,155,231,94,160,246,239,239,167,120,44,124,204,204,175,92,187,98,40,141,55,108,81,252,103,171,230,104,61,229,199,178,250,240,203,253,91,251,226,105,244,235,74,250,114,103,174,15,99,188,35,93,183,235,94,1,39,159,89,138,200,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("321d44b2-f7f8-4aae-8f55-74e37a4f7da5"),
				ContainerUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
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

		protected virtual void InitializeChangeLeadStageDistributionParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("9e34dc39-7d39-421f-8d27-92a8af9a80c6"),
				ContainerUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bcf5b8fe-4737-4d4e-a037-b2c70a7900e8"),
				ContainerUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bb68e8f2-44a8-4731-b948-176e754a5d8b"),
				ContainerUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,91,146,45,203,61,46,219,178,80,210,64,211,82,72,150,48,150,70,89,129,63,54,150,76,19,204,254,247,202,235,108,10,57,148,210,91,65,135,153,145,222,155,55,143,209,124,239,195,71,223,70,28,107,7,109,64,58,237,108,77,184,226,34,47,141,98,152,75,203,164,212,142,85,156,75,86,104,206,185,145,69,46,120,65,104,15,29,214,100,69,111,173,143,132,250,136,93,168,111,231,223,164,113,156,144,222,187,115,242,213,28,176,131,111,75,3,153,131,171,52,106,166,138,172,97,18,155,134,85,6,12,115,78,232,166,148,149,204,209,144,85,139,146,218,100,188,116,12,178,204,49,89,186,20,85,166,96,214,136,194,128,179,153,85,72,104,139,46,110,159,142,35,134,224,135,190,158,241,53,190,121,62,38,149,107,239,205,208,78,93,79,104,135,17,174,33,30,106,2,152,161,76,60,204,72,93,48,233,80,49,16,218,50,1,141,226,170,194,188,204,21,161,6,142,113,161,37,59,75,168,133,8,223,161,157,240,204,60,251,197,47,145,229,85,81,38,108,46,12,147,130,103,172,42,43,197,156,45,157,70,81,106,221,216,139,95,159,38,159,98,31,174,166,14,71,111,94,108,199,228,223,48,214,179,25,250,56,14,237,66,125,117,126,126,131,79,113,53,247,229,234,199,58,80,76,245,5,68,78,116,10,184,105,61,246,113,219,155,193,250,254,97,229,60,157,18,164,59,194,232,195,197,133,237,227,4,45,161,163,127,56,252,209,173,205,20,226,208,253,71,163,210,52,102,226,72,75,118,150,187,236,160,245,225,216,194,243,57,175,201,187,199,105,136,31,62,35,216,53,34,111,16,53,185,35,202,130,176,66,75,102,138,134,167,93,104,128,53,40,21,83,82,165,221,179,162,172,10,188,35,73,197,63,112,223,238,194,151,159,253,229,15,172,170,247,239,83,245,77,225,250,130,172,231,191,145,115,218,47,130,246,167,116,126,1,123,109,74,170,202,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f994ffb6-8edf-41e3-892d-aa56db1c821b"),
				ContainerUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,203,142,219,32,20,253,149,138,153,101,176,192,96,48,89,182,105,165,72,73,21,53,237,108,38,179,184,198,151,25,171,142,137,252,168,58,141,242,239,37,196,105,18,105,42,85,101,1,130,203,121,112,15,123,114,223,191,238,144,76,201,251,213,114,237,93,159,124,240,45,38,171,214,91,236,186,100,225,45,212,213,47,40,106,92,65,11,91,236,177,125,128,122,192,110,81,117,253,228,221,53,136,76,200,253,143,88,35,211,199,61,153,247,184,253,54,47,3,179,150,37,207,178,162,160,82,0,82,9,96,41,100,70,83,230,148,205,83,46,144,233,34,128,173,175,135,109,179,196,30,86,208,191,144,233,158,68,182,64,80,88,102,211,82,49,154,129,40,169,204,37,163,0,18,169,85,12,65,107,133,41,83,228,48,33,157,125,193,45,68,209,11,88,114,112,185,65,67,117,198,130,5,12,62,114,27,44,56,39,76,161,2,25,71,123,4,143,247,47,192,199,187,133,247,223,135,93,146,166,66,114,91,114,154,21,66,80,105,131,188,97,156,83,229,180,50,2,157,66,41,19,46,173,179,74,74,138,2,131,71,163,145,230,169,54,20,75,41,184,41,138,156,25,113,247,116,20,42,171,110,87,195,235,195,95,245,214,61,60,99,50,11,13,110,171,98,232,43,223,156,128,187,155,4,174,161,251,205,41,198,13,153,110,222,14,114,92,215,177,67,183,81,222,166,184,33,147,13,89,251,161,181,71,54,113,220,156,187,26,217,217,56,232,27,211,121,156,56,34,108,9,77,120,76,251,57,232,69,120,44,205,160,135,40,253,53,120,62,19,23,169,201,152,230,142,106,4,19,114,82,41,205,75,14,212,132,238,57,161,69,234,92,26,209,95,208,97,139,141,197,91,99,233,63,164,20,241,81,249,98,230,252,225,194,73,51,212,117,20,232,226,251,143,63,120,52,62,86,66,38,127,162,187,98,240,101,229,42,44,231,205,127,182,106,134,46,82,126,242,237,199,159,33,246,170,121,30,243,186,146,190,220,153,217,237,120,126,32,135,195,211,225,55,219,125,202,39,196,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7362a45-71b1-4fb8-a1e4-17017c3aba0e"),
				ContainerUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
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

		protected virtual void InitializeLinkContactToLeadParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("6dd0bc3f-edfa-4078-87d0-79fe8307a8ab"),
				ContainerUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55ac08c6-ba80-4060-81f6-fb82943a2aa6"),
				ContainerUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34908b60-ff49-4067-a7d9-fecfeba3d015"),
				ContainerUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,100,21,219,146,45,201,61,46,219,178,80,210,64,211,82,72,150,48,146,70,89,129,63,54,150,76,19,204,254,247,202,235,108,10,57,148,210,91,65,135,153,145,222,155,55,143,209,124,239,195,71,223,70,28,27,7,109,192,108,218,217,134,228,224,74,199,164,166,214,212,21,229,70,20,84,114,91,81,109,21,230,170,174,141,150,154,100,61,116,216,144,21,189,181,62,146,204,71,236,66,115,59,255,38,141,227,132,217,189,59,39,95,205,1,59,248,182,52,224,5,56,169,80,81,81,229,154,114,212,154,74,3,134,58,199,148,174,185,228,5,26,178,106,209,104,20,171,77,78,157,72,239,185,41,144,202,138,139,37,5,174,36,215,133,96,36,107,209,197,237,211,113,196,16,252,208,55,51,190,198,55,207,199,164,114,237,189,25,218,169,235,73,214,97,132,107,136,135,134,0,230,200,43,3,212,112,149,38,117,40,40,48,101,41,3,45,74,33,177,168,11,65,50,3,199,184,208,146,157,37,153,133,8,223,161,157,240,204,60,251,164,177,100,121,33,171,58,97,11,102,40,103,101,78,101,45,147,70,91,59,133,172,86,74,219,139,95,159,38,159,98,31,174,166,14,71,111,94,108,199,228,223,48,54,179,25,250,56,14,237,66,125,117,126,126,131,79,113,53,247,229,234,199,58,80,76,245,5,68,78,217,20,112,211,122,236,227,182,55,131,245,253,195,202,121,58,37,72,119,132,209,135,139,11,219,199,9,90,146,141,254,225,240,71,183,54,83,136,67,247,31,141,154,165,49,19,71,90,178,179,220,101,7,173,15,199,22,158,207,121,67,222,61,78,67,252,240,25,193,174,17,121,131,104,200,29,17,22,152,101,138,83,83,233,50,237,130,6,170,49,109,154,224,2,242,220,178,90,86,120,71,146,138,127,224,190,221,133,47,63,251,203,31,88,85,239,223,167,234,155,194,245,5,217,204,127,35,231,180,95,4,237,79,233,252,2,68,233,196,17,202,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ee931748-590a-41b4-8229-e4dc1c8b23af"),
				ContainerUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,143,218,48,16,253,43,200,187,71,140,236,216,9,118,142,45,173,132,180,180,180,180,123,1,14,99,123,188,139,20,18,148,132,182,91,148,255,190,198,132,2,237,158,234,67,162,204,248,125,120,158,115,32,247,237,203,14,73,78,222,205,103,139,202,183,163,247,85,141,163,121,93,89,108,154,209,67,101,161,216,252,6,83,224,28,106,216,98,139,245,35,20,123,108,30,54,77,59,28,92,131,200,144,220,255,136,61,146,47,15,100,218,226,246,251,212,5,102,101,156,179,222,27,154,24,207,168,84,192,41,112,233,104,194,153,245,137,100,152,24,23,192,182,42,246,219,114,134,45,204,161,125,38,249,129,68,182,64,0,78,106,230,82,69,89,42,129,74,167,82,170,19,153,81,231,148,204,50,52,66,43,65,186,33,105,236,51,110,33,138,94,192,146,131,87,26,53,29,167,204,80,137,198,80,101,193,82,239,133,54,153,84,146,163,61,130,251,253,23,224,242,110,57,109,62,255,44,177,94,68,222,220,67,209,224,122,20,170,127,21,254,140,38,63,36,220,51,129,169,163,220,140,85,56,171,179,84,163,96,148,91,149,121,205,51,46,149,234,214,119,235,163,162,219,52,187,2,94,30,255,21,254,178,15,83,247,27,116,3,104,6,182,42,91,176,237,9,179,187,73,225,26,117,88,157,162,92,145,124,245,118,152,253,251,100,254,54,206,219,36,87,100,184,34,139,106,95,219,35,155,56,126,156,39,27,217,89,191,232,27,143,243,58,113,68,216,12,74,120,194,250,83,208,139,240,216,154,64,11,81,250,91,240,124,38,54,137,78,217,152,123,58,70,208,33,171,44,161,202,113,160,154,107,227,197,88,36,222,39,17,253,21,61,214,88,90,188,53,198,51,131,34,75,57,85,30,19,42,121,170,3,222,49,10,138,9,39,51,37,156,19,17,31,149,47,102,206,151,46,84,202,125,81,68,129,38,158,255,120,139,123,227,125,103,114,149,218,21,67,229,98,96,211,242,63,71,53,65,31,41,63,86,245,135,95,225,223,218,148,79,125,94,87,210,151,61,19,187,237,235,29,233,186,117,247,10,28,110,164,247,200,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3204a423-4821-4b15-91b5-96120c20f596"),
				ContainerUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
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

		protected virtual void InitializeLinkAccountToLeadParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("7b3e0e2a-6d32-492c-9290-46e7c194da0b"),
				ContainerUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
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
				Value = @"41af89e9-750b-4ebb-8cac-ff39b64841ec",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbd3778b-b29e-4da4-878c-479ce66f6695"),
				ContainerUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2572aab-9833-4451-bac3-3c93b4938008"),
				ContainerUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,127,72,150,229,30,151,109,89,40,105,160,105,41,36,75,24,73,163,172,192,31,27,75,166,9,102,255,123,229,117,54,133,28,74,233,173,160,195,204,72,239,205,155,199,104,190,247,225,163,111,35,142,141,131,54,32,157,118,182,33,89,94,91,13,218,177,66,229,150,113,172,53,211,174,54,76,85,142,231,89,230,180,118,72,104,15,29,54,100,69,111,173,143,132,250,136,93,104,110,231,223,164,113,156,144,222,187,115,242,213,28,176,131,111,75,3,158,131,171,21,42,38,69,166,83,3,173,89,109,192,48,231,74,165,43,94,243,28,13,89,181,8,237,138,42,43,37,43,100,101,24,183,66,49,45,92,197,140,116,5,26,93,24,1,130,208,22,93,220,62,29,71,12,193,15,125,51,227,107,124,243,124,76,42,215,222,155,161,157,186,158,208,14,35,92,67,60,52,4,48,67,46,12,48,195,149,96,220,161,100,80,42,203,74,208,178,144,53,230,85,46,9,53,112,140,11,45,217,89,66,45,68,248,14,237,132,103,230,217,39,141,69,153,28,19,85,194,230,101,210,88,22,25,171,171,90,50,103,43,167,176,172,148,210,246,226,215,167,201,167,216,135,171,169,195,209,155,23,219,49,249,55,140,205,108,134,62,142,67,187,80,95,157,159,223,224,83,92,205,125,185,250,177,14,20,83,125,1,145,19,157,2,110,90,143,125,220,246,102,176,190,127,88,57,79,167,4,233,142,48,250,112,113,97,251,56,65,75,232,232,31,14,127,116,107,51,133,56,116,255,209,168,52,141,153,56,210,146,157,229,46,59,104,125,56,182,240,124,206,27,242,238,113,26,226,135,207,8,118,141,200,27,68,67,238,136,180,80,218,82,113,102,132,46,210,46,104,96,26,185,100,146,75,200,50,91,86,181,192,59,146,84,252,3,247,237,46,124,249,217,95,254,192,170,122,255,62,85,223,20,174,47,200,102,254,27,57,167,253,34,104,127,74,231,23,52,11,173,221,202,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c5dda1b-35c1-410a-8a66-b8e7dbef353d"),
				ContainerUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,143,218,48,16,253,43,200,187,71,140,108,199,78,226,28,91,90,9,105,105,105,105,247,2,28,38,246,120,23,41,36,40,31,109,183,40,255,125,141,9,5,218,61,213,7,91,153,241,123,111,60,111,114,32,247,237,203,30,73,70,222,45,230,203,202,181,147,247,85,141,147,69,93,25,108,154,201,67,101,160,216,254,134,188,192,5,212,176,195,22,235,71,40,58,108,30,182,77,59,30,93,131,200,152,220,255,8,57,146,173,14,100,214,226,238,251,204,122,230,36,22,142,229,86,81,33,29,167,146,69,150,66,110,13,229,44,145,2,45,143,53,139,60,216,84,69,183,43,231,216,194,2,218,103,146,29,72,96,243,4,145,208,82,3,74,234,28,143,168,76,157,162,218,41,75,165,130,68,42,149,34,40,69,250,49,105,204,51,238,32,136,94,192,146,131,75,53,106,154,40,150,83,137,121,78,83,3,198,115,69,58,143,101,42,57,154,35,120,184,127,1,174,238,86,179,230,243,207,18,235,101,224,205,28,20,13,110,38,62,250,87,224,79,107,178,3,88,231,100,156,58,170,146,84,81,41,162,148,130,142,5,21,86,198,16,91,167,5,75,250,205,221,230,168,104,183,205,190,128,151,199,127,133,191,116,190,235,110,139,118,4,205,8,140,169,186,178,61,97,246,55,46,92,163,14,235,147,149,107,146,173,223,54,115,56,79,197,223,218,121,235,228,154,140,215,100,89,117,181,57,178,69,199,143,115,103,3,59,27,22,125,99,59,175,19,71,128,205,161,132,39,172,63,121,189,0,15,169,41,180,16,164,191,249,154,207,196,185,208,138,37,220,209,4,65,123,175,124,227,82,203,129,106,174,115,23,37,145,112,78,4,244,87,116,88,99,105,240,182,48,161,108,98,56,228,148,91,100,126,60,24,167,185,100,130,50,129,12,253,176,8,27,159,30,23,148,47,197,156,135,206,71,202,174,40,130,64,19,222,127,156,226,161,240,33,51,189,114,237,138,161,178,193,176,89,249,159,173,154,162,11,148,31,171,250,195,47,255,111,109,203,167,193,175,43,233,203,157,169,217,13,241,158,244,253,166,127,5,211,140,104,81,200,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9bc7cdf4-c634-485f-a341-909e45a7cc26"),
				ContainerUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
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

		protected virtual void InitializeReadSystemSettingsParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5b47b7b3-1c3a-4e76-8b27-d2d1429d61ee"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,82,77,107,220,48,20,252,43,69,135,158,172,32,75,178,100,187,167,178,108,161,151,52,101,211,82,40,37,60,73,79,89,129,63,54,150,12,89,150,253,239,149,237,164,133,30,10,61,22,116,208,199,155,55,243,102,116,121,8,241,67,232,18,78,173,135,46,98,49,127,116,45,145,160,164,107,76,67,141,20,134,202,178,81,180,198,18,40,154,90,75,20,158,149,88,146,98,128,30,91,178,161,247,46,36,82,132,132,125,108,191,95,126,55,77,211,140,197,131,95,15,7,123,196,30,190,44,4,77,85,26,110,140,161,204,128,160,146,201,134,54,192,51,95,229,164,101,70,185,138,121,178,105,225,186,86,154,87,21,229,156,121,42,173,180,180,169,165,162,149,45,89,227,148,22,232,36,41,58,244,105,255,124,154,48,198,48,14,237,5,127,237,239,207,167,172,114,227,222,141,221,220,15,164,232,49,193,29,164,99,75,152,119,168,124,137,185,187,173,168,172,173,166,141,173,27,170,60,99,162,68,174,153,195,155,82,0,184,74,74,138,86,48,42,81,43,10,66,11,234,153,245,94,112,198,145,103,9,22,78,105,225,38,135,115,204,62,188,137,152,82,24,30,111,118,163,67,82,56,72,240,21,186,25,87,61,151,144,39,19,188,2,45,76,77,153,151,154,74,9,140,214,178,228,84,43,166,188,174,179,0,176,175,46,31,142,227,148,238,241,121,49,57,222,206,61,78,193,190,36,134,217,250,113,106,47,118,28,210,52,118,75,255,219,21,179,148,111,185,188,60,125,219,188,72,249,126,1,145,107,49,71,220,117,1,135,180,31,236,232,178,218,53,176,235,53,35,250,19,76,33,190,250,183,127,154,161,35,197,20,30,143,127,245,249,14,166,204,157,195,254,207,38,46,242,180,155,240,85,242,242,137,93,136,167,14,206,235,185,37,111,159,230,49,189,219,77,8,9,223,91,59,206,67,250,52,124,206,166,4,31,44,44,193,111,21,228,143,78,255,128,188,254,184,230,245,19,237,231,240,99,146,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("055337fb-4c12-4162-baa0-f0a6f82b04f1"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("61008822-6246-4cb7-94b5-d7ab2c0e761f"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a18bad05-72bd-47e8-8a76-9adc5adb727a"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05ce4b0d-7adf-4370-a4da-9a578ae526a6"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b54c1807-d3db-417d-acc8-5ec641e8f114"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("eb5b205e-4427-45cf-8b2f-e5c11ffb5d04"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,174,44,14,78,45,41,201,204,75,47,182,50,180,50,212,241,76,177,50,176,50,0,0,176,83,7,250,22,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				UId = new Guid("411b2f2b-abb2-49c4-b63c-c589bc81bb8c"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0107e886-cf9e-458c-9fa5-10337b71312c"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("c92f52ed-8123-486d-ae9b-c9c0f3e785cf"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6c8845de-fd11-481f-ba54-02935c4aeb9d"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("63c46681-2887-41fe-8ea5-3cd9bd9e60fe"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f0232a3c-912e-48ab-9927-5fc33677f7ba"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("06e3ef5a-2fa6-49b7-bfa6-3a114e683d05"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				UId = new Guid("0a40e220-4683-47e0-a0c2-892934668fc3"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("44d1abb0-802b-49e6-9571-d667de498b3e"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("11fe36aa-20e3-41b3-99f4-0a35fd3628cc"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("63184008-db16-4d16-8b86-316b860a485d"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("db44c7f2-37f4-4a89-9abc-c1530f1150c9"),
				ContainerUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaLaneSet schemaLeadQualificationProcess = CreateLeadQualificationProcessLaneSet();
			LaneSets.Add(schemaLeadQualificationProcess);
			ProcessSchemaLane schemaLeadQualification = CreateLeadQualificationLane();
			schemaLeadQualificationProcess.Lanes.Add(schemaLeadQualification);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminatequalified = CreateTerminateQualifiedTerminateEvent();
			FlowElements.Add(terminatequalified);
			ProcessSchemaExclusiveGateway exclusivegatewayisleadset = CreateExclusiveGatewayIsLeadSetExclusiveGateway();
			FlowElements.Add(exclusivegatewayisleadset);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			ProcessSchemaUserTask readleaddata = CreateReadLeadDataUserTask();
			FlowElements.Add(readleaddata);
			ProcessSchemaUserTask changecontactaccount = CreateChangeContactAccountUserTask();
			FlowElements.Add(changecontactaccount);
			ProcessSchemaExclusiveGateway exclusivegatewayaccountconnection = CreateExclusiveGatewayAccountConnectionExclusiveGateway();
			FlowElements.Add(exclusivegatewayaccountconnection);
			ProcessSchemaUserTask changeleadstagedistribution = CreateChangeLeadStageDistributionUserTask();
			FlowElements.Add(changeleadstagedistribution);
			ProcessSchemaScriptTask changeaccountscripttask = CreateChangeAccountScriptTaskScriptTask();
			FlowElements.Add(changeaccountscripttask);
			ProcessSchemaScriptTask changecontactscripttask = CreateChangeContactScriptTaskScriptTask();
			FlowElements.Add(changecontactscripttask);
			ProcessSchemaUserTask linkcontacttolead = CreateLinkContactToLeadUserTask();
			FlowElements.Add(linkcontacttolead);
			ProcessSchemaUserTask linkaccounttolead = CreateLinkAccountToLeadUserTask();
			FlowElements.Add(linkaccounttolead);
			ProcessSchemaExclusiveGateway exclusivegatewayqualifiedaccount = CreateExclusiveGatewayQualifiedAccountExclusiveGateway();
			FlowElements.Add(exclusivegatewayqualifiedaccount);
			ProcessSchemaUserTask readsystemsettings = CreateReadSystemSettingsUserTask();
			FlowElements.Add(readsystemsettings);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlowLeadUndefinedConditionalFlow());
			FlowElements.Add(CreateLeadDefinedSequenceFlow());
			FlowElements.Add(CreateSequenceFlowNoAccountSequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow23SequenceFlow());
			FlowElements.Add(CreateSequenceFlow26SequenceFlow());
			FlowElements.Add(CreateQualifiedContactExistsSequenceFlowConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateQualifiedAccountExistsSequenceFlowConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c65a1bbe-a2e1-4643-aea1-a3b83207ea88"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bf1b5b17-6f6d-4e3d-8136-b213854f53b7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ed9cbb4d-b5c9-4231-ab67-76ffff3433b0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlowLeadUndefinedConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlowLeadUndefined",
				UId = new Guid("00b2c101-a67f-4a28-a60e-f6ef8f988808"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{7da3d394-c5b2-4fba-be47-747a00d3685e}]#] == Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(176, 271),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ed9cbb4d-b5c9-4231-ab67-76ffff3433b0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("478ef5b0-3cfe-49aa-9d92-d33e5210847a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateLeadDefinedSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "LeadDefined",
				UId = new Guid("756698c0-b46a-4130-a2ea-3b7d3f77b46b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(231, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ed9cbb4d-b5c9-4231-ab67-76ffff3433b0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(202, 372));
			schemaFlow.PolylinePointPositions.Add(new Point(202, 491));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlowNoAccountSequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlowNoAccount",
				UId = new Guid("c7e87ab7-7efe-4228-b1ed-7c57a2135e50"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(1084, 512),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("968e7a35-4c26-459a-806f-a3b34d7fe1c2"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(636, 512));
			schemaFlow.PolylinePointPositions.Add(new Point(636, 92));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("8df03451-825f-4626-947e-1c39dddd618f"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{adff468f-5785-4238-a962-2d46a6df9207}]#]!= Guid.Empty && [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{21f03e5d-1b78-48dc-9e30-1c86f9161488}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(1021, 601),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("968e7a35-4c26-459a-806f-a3b34d7fe1c2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("d11e3a52-d220-4d16-b36a-25b6d32fa2d8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(1104, 628),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(734, 687));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow23SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow23",
				UId = new Guid("aecc3666-b64f-448b-92d5-e58fceb68420"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(1782, 434),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("279e66a8-61fb-4e2b-8559-0362a5ebb1fe"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow26SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow26",
				UId = new Guid("d5c984cc-6130-459a-87b9-d537c71ee823"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(793, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9970214a-b543-4895-ab00-ab57461e70cf"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("97776b38-7f29-472a-ab13-e87884d17d43"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(270, 121));
			schemaFlow.PolylinePointPositions.Add(new Point(274, 121));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateQualifiedContactExistsSequenceFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "QualifiedContactExistsSequenceFlow",
				UId = new Guid("644d1a44-d831-44e0-982d-8da2dc9c15bf"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{21f03e5d-1b78-48dc-9e30-1c86f9161488}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92323026-06de-4fcc-b310-6de28b5b7964"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("97776b38-7f29-472a-ab13-e87884d17d43"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(274, 36));
			schemaFlow.PolylinePointPositions.Add(new Point(552, 36));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("2f920b5d-24b3-48d4-8c77-b0608b4cbdac"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92323026-06de-4fcc-b310-6de28b5b7964"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("97776b38-7f29-472a-ab13-e87884d17d43"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("045b9d72-61cb-4f5f-8a92-c02297c04e1d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(413, 78));
			schemaFlow.PolylinePointPositions.Add(new Point(413, 232));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("b8793434-8131-45af-9836-038f53b3d96f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("968e7a35-4c26-459a-806f-a3b34d7fe1c2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("48ad4d37-ec71-49c5-bbbc-48d071c60c63"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("045b9d72-61cb-4f5f-8a92-c02297c04e1d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(552, 135));
			schemaFlow.PolylinePointPositions.Add(new Point(545, 135));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("2115af57-31f8-4299-8456-bf03d959df4a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("5307b755-7675-4cab-b5a0-bbf36f487016"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9970214a-b543-4895-ab00-ab57461e70cf"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateQualifiedAccountExistsSequenceFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "QualifiedAccountExistsSequenceFlow",
				UId = new Guid("2e0ed20e-8966-4d04-847a-b6b5a83c0b82"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{adff468f-5785-4238-a962-2d46a6df9207}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("045b9d72-61cb-4f5f-8a92-c02297c04e1d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(588, 232));
			schemaFlow.PolylinePointPositions.Add(new Point(588, 344));
			schemaFlow.PolylinePointPositions.Add(new Point(545, 344));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("8f67e700-62e9-40c4-a643-f73bb5f05cad"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("045b9d72-61cb-4f5f-8a92-c02297c04e1d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("968e7a35-4c26-459a-806f-a3b34d7fe1c2"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(545, 275));
			schemaFlow.PolylinePointPositions.Add(new Point(445, 275));
			schemaFlow.PolylinePointPositions.Add(new Point(445, 512));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLeadQualificationProcessLaneSet() {
			ProcessSchemaLaneSet schemaLeadQualificationProcess = new ProcessSchemaLaneSet(this) {
				UId = new Guid("52a0ec41-f948-487a-bbce-75440b557857"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadQualificationProcess",
				Position = new Point(5, 5),
				Size = new Size(1156, 948),
				UseBackgroundMode = false
			};
			return schemaLeadQualificationProcess;
		}

		protected virtual ProcessSchemaLane CreateLeadQualificationLane() {
			ProcessSchemaLane schemaLeadQualification = new ProcessSchemaLane(this) {
				UId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("52a0ec41-f948-487a-bbce-75440b557857"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LeadQualification",
				Position = new Point(29, 0),
				Size = new Size(1127, 948),
				UseBackgroundMode = false
			};
			return schemaLeadQualification;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("bf1b5b17-6f6d-4e3d-8136-b213854f53b7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"Start1",
				Position = new Point(50, 359),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateQualifiedTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("279e66a8-61fb-4e2b-8559-0362a5ebb1fe"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"TerminateQualified",
				Position = new Point(820, 79),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayIsLeadSetExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ed9cbb4d-b5c9-4231-ab67-76ffff3433b0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ExclusiveGatewayIsLeadSet",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(113, 345),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("478ef5b0-3cfe-49aa-9d92-d33e5210847a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"Terminate2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 478),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateReadLeadDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ReadLeadData",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(236, 464),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadLeadDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeContactAccountUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ChangeContactAccount",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(511, 660),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeContactAccountParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayAccountConnectionExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("968e7a35-4c26-459a-806f-a3b34d7fe1c2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ExclusiveGatewayAccountConnection",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(518, 485),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateChangeLeadStageDistributionUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ChangeLeadStageDistribution",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(700, 65),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeLeadStageDistributionParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateChangeAccountScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("97776b38-7f29-472a-ab13-e87884d17d43"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ChangeAccountScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(240, 51),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,40,202,79,78,45,46,118,76,78,206,47,205,43,209,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,181,13,239,214,31,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateChangeContactScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9970214a-b543-4895-ab00-ab57461e70cf"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ChangeContactScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(236, 185),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,40,202,79,78,45,46,118,206,207,43,73,76,46,209,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,245,187,243,113,31,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateLinkContactToLeadUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92323026-06de-4fcc-b310-6de28b5b7964"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LinkContactToLead",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(518, 65),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeLinkContactToLeadParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateLinkAccountToLeadUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"LinkAccountToLead",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(511, 359),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeLinkAccountToLeadParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayQualifiedAccountExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("045b9d72-61cb-4f5f-8a92-c02297c04e1d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ExclusiveGatewayQualifiedAccount",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(518, 205),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateReadSystemSettingsUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("06d6585a-7cd3-4bd9-a9f3-7b52c8d29213"),
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Name = @"ReadSystemSettings",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(236, 304),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadSystemSettingsParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateProcessAccountMethod());
			Methods.Add(CreateSetValueMethod());
			Methods.Add(CreateProcessContactMethod());
			Methods.Add(CreateSyncContactCommunicationsMethod());
			Methods.Add(CreateSyncAccountCommunicationsMethod());
			Methods.Add(CreateAddContacAddressMethod());
			Methods.Add(CreateAddAccountAddressMethod());
			Methods.Add(CreateIsAddressExistsMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3c6ecdc6-bc79-4245-a9cc-a34cb13e3cc3"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("44f94bf0-4527-4bb4-ac7e-a66ed2ff2653"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("86b4ee06-6bcf-45c0-ab44-66865e38fa0d"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
		}

		protected virtual SchemaMethod CreateProcessAccountMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("7194e5eb-0600-4b2b-86c7-7401514d65b6"),
				Name = "ProcessAccount",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,83,203,110,194,48,16,60,39,95,225,114,10,18,202,15,160,30,32,60,20,169,133,182,168,189,155,100,3,150,28,27,249,1,141,42,254,189,235,16,135,4,133,83,236,241,206,206,236,216,89,91,150,19,154,101,210,10,147,230,228,149,188,1,205,103,126,63,13,247,82,114,146,41,160,6,26,20,107,146,238,126,43,62,45,229,172,96,25,53,76,138,105,120,166,202,119,196,90,1,23,50,255,120,223,201,194,196,137,20,5,59,88,85,23,198,13,63,250,214,160,240,68,64,230,224,113,163,217,116,88,254,50,109,52,246,41,40,215,48,13,89,65,162,214,110,156,234,101,121,50,85,52,30,147,191,48,232,142,177,198,185,226,13,92,220,55,194,158,87,2,200,239,84,181,141,155,125,188,2,147,29,87,74,150,139,249,93,193,49,107,205,151,30,173,150,115,112,47,153,26,13,122,1,222,251,187,48,3,47,30,63,63,217,129,89,64,145,72,110,75,241,67,185,5,237,236,7,119,255,129,2,99,21,230,28,92,189,55,109,20,19,7,76,99,99,57,223,170,91,38,29,31,27,90,66,47,162,216,33,253,203,118,136,31,118,176,95,151,122,107,230,141,92,67,52,93,123,245,69,19,50,218,94,4,40,125,100,167,52,31,77,106,161,22,193,121,6,8,169,200,45,10,87,109,189,7,134,203,27,219,9,198,127,144,29,214,3,62,76,198,137,184,172,0,112,192,114,15,170,37,63,224,79,148,133,192,7,255,5,103,16,22,238,186,93,20,137,237,125,210,51,184,27,220,85,34,243,222,100,89,90,209,252,47,186,13,182,126,109,79,94,206,44,247,131,225,74,129,110,89,142,244,15,241,39,49,182,196,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSetValueMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("4296bf57-0225-4b64-95fe-60bd8aaaea6b"),
				Name = "SetValue",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("5c388a48-f5cf-4d1f-bbfc-c91b2053934b"),
				Name = "entity",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Entity",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("a6ef6811-9020-4a4d-8757-7b1bdd89267b"),
				Name = "valueName",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("b8a1b0c7-b023-4f0d-bd4f-3debae11e7cc"),
				Name = "value",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Object",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,203,76,83,208,112,47,205,76,209,115,205,45,40,169,212,115,45,44,77,204,41,214,40,75,204,41,77,213,212,84,168,230,226,4,51,21,108,21,242,74,115,114,172,185,106,185,82,243,74,50,129,10,131,83,75,156,243,115,74,115,243,194,64,242,16,13,126,137,185,169,58,10,16,189,214,0,45,199,129,174,89,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateProcessContactMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("44a20dbd-1c99-4ff3-948f-6b89c23345d0"),
				Name = "ProcessContact",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,77,111,194,48,12,61,175,191,34,227,84,36,212,63,128,118,24,116,32,166,141,77,43,219,61,107,93,22,169,73,80,62,64,104,226,191,207,73,155,208,74,229,176,83,29,191,231,231,103,215,107,203,42,82,74,97,104,105,54,21,121,32,47,64,171,101,120,207,147,35,85,1,70,80,192,137,44,222,95,11,89,155,12,73,53,219,91,69,13,147,194,189,28,39,253,212,160,48,22,80,186,244,116,158,104,163,152,216,7,141,45,229,48,108,226,50,243,132,213,36,141,46,178,141,126,226,7,115,78,167,83,242,155,220,57,236,190,149,65,100,107,155,230,77,181,120,79,180,165,222,245,39,89,227,104,217,22,78,238,155,162,147,136,102,5,152,28,234,165,108,44,23,95,180,177,160,135,184,47,143,82,136,92,8,52,26,124,7,5,198,42,225,114,73,151,245,254,66,233,10,76,249,179,82,146,231,139,235,64,173,185,80,121,73,254,49,81,208,237,22,215,195,157,80,252,81,67,191,56,159,31,43,200,205,200,36,7,170,38,51,191,120,23,78,71,73,207,242,123,199,76,3,29,113,133,198,66,106,188,160,192,183,241,7,176,59,31,96,83,117,133,215,244,205,62,145,139,241,56,41,135,3,85,134,131,192,145,162,243,144,26,47,89,131,168,64,69,122,251,188,165,94,50,141,6,63,100,115,245,221,79,98,89,216,189,191,116,197,193,109,217,40,139,155,143,135,68,143,224,78,167,56,139,178,251,23,75,201,185,21,172,244,227,235,208,17,79,10,105,143,85,119,245,24,40,208,67,244,15,128,243,153,219,138,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSyncContactCommunicationsMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("234f41ed-2721-40f9-8ad1-4155addd81c3"),
				Name = "SyncContactCommunications",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("b6a91fab-21a7-4075-adab-1a9161a98693"),
				Name = "contactId",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,93,107,219,48,20,134,175,237,95,161,230,74,134,33,118,159,166,176,196,94,9,203,186,176,100,235,197,216,133,98,159,52,98,182,212,73,114,83,51,242,223,119,36,57,173,157,56,20,54,48,88,31,231,188,231,57,31,74,69,110,133,146,92,55,215,183,181,40,222,17,99,181,144,15,55,164,4,94,204,84,85,213,82,228,220,153,24,50,33,18,246,36,189,224,65,147,113,44,182,132,94,133,61,155,155,187,186,44,191,232,172,122,180,13,93,160,220,180,54,66,130,49,203,157,146,144,36,228,79,28,157,71,249,225,98,56,97,218,59,95,55,143,48,195,107,107,216,189,210,191,188,196,188,72,126,34,212,153,244,56,62,188,65,242,89,109,68,9,255,201,209,17,233,144,116,78,223,230,200,42,46,202,127,39,240,238,157,216,126,239,162,174,160,132,220,18,120,22,198,98,228,187,186,218,128,62,54,48,92,210,111,6,52,234,72,92,163,106,18,71,108,166,202,186,146,116,20,204,71,238,232,163,86,21,29,161,153,229,185,237,97,248,235,251,29,104,120,185,159,23,163,4,147,204,126,215,188,164,65,140,45,185,230,21,88,208,52,63,26,97,190,220,180,20,227,120,129,136,215,199,161,203,123,129,122,99,215,181,115,163,230,26,254,64,104,58,205,158,33,175,173,210,164,216,188,44,39,164,159,29,203,164,169,53,164,211,215,35,26,202,222,202,204,83,110,249,87,44,33,104,162,195,111,114,90,62,22,228,33,152,209,215,112,73,130,66,209,126,135,125,39,52,120,51,103,212,134,136,162,161,180,216,135,162,56,26,223,130,93,249,204,232,251,132,173,213,66,237,81,63,193,36,163,232,16,227,119,8,85,250,4,205,119,94,214,176,228,66,247,223,158,171,92,119,116,214,106,213,200,28,83,24,154,171,182,107,146,76,110,200,213,32,154,239,167,144,134,74,230,3,118,152,60,31,194,184,22,108,21,242,231,59,66,47,131,245,185,136,144,131,160,190,76,79,92,159,244,191,117,10,253,31,154,65,122,50,195,88,176,33,5,182,2,155,194,54,76,164,7,53,14,127,216,54,52,27,131,246,64,67,29,46,249,156,189,207,121,113,38,128,53,186,236,222,190,12,239,212,174,47,230,194,159,192,209,31,254,2,57,252,38,237,186,5,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateSyncAccountCommunicationsMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("27a03f5a-1438-4ae9-a779-d2f9955dee17"),
				Name = "SyncAccountCommunications",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("8557cb9d-31d3-4eec-beaf-715049caeaec"),
				Name = "accountId",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,107,219,64,16,61,75,191,98,227,211,10,202,210,187,227,64,108,57,65,212,77,77,237,52,135,210,195,90,26,199,11,210,110,186,31,177,77,241,127,239,172,86,118,164,88,38,208,130,64,210,238,204,123,111,222,204,164,34,183,66,73,174,247,215,247,78,20,159,136,177,90,200,231,27,82,2,47,38,170,170,156,20,57,247,33,134,140,136,132,45,73,47,100,208,100,24,139,53,161,87,225,159,101,230,193,149,229,55,61,173,94,236,158,206,16,110,236,140,144,96,204,124,163,36,36,9,249,19,71,231,44,63,61,135,7,166,157,243,229,254,5,38,120,109,13,251,202,133,172,33,178,34,249,133,162,206,160,135,241,225,3,37,119,124,247,239,252,152,220,98,198,191,143,249,158,96,101,132,253,143,154,17,160,197,217,192,121,222,5,148,144,91,2,59,97,44,114,63,184,106,5,250,216,170,112,73,31,13,104,196,145,248,141,168,73,28,177,137,42,93,37,233,32,132,15,252,209,157,86,21,29,220,230,185,114,210,118,100,212,215,79,27,208,112,186,207,138,65,130,101,78,127,59,94,210,0,198,230,92,243,10,44,104,202,143,65,88,47,55,141,138,97,60,67,137,215,199,241,202,149,180,60,63,18,117,6,172,29,231,135,202,183,246,153,208,116,60,221,65,238,172,210,164,88,157,62,71,164,91,29,155,74,227,52,164,227,183,35,26,108,111,96,178,148,91,254,29,77,4,77,116,120,141,222,219,199,2,60,132,48,250,70,151,36,8,20,109,55,162,4,66,67,54,243,65,13,69,20,245,149,197,110,139,226,24,124,15,118,81,87,70,63,39,108,169,102,106,139,248,9,22,25,69,135,24,159,67,112,233,11,236,127,240,210,193,156,11,221,221,50,239,92,123,116,150,106,177,151,57,150,208,55,87,77,215,36,25,221,144,171,94,105,232,146,197,117,50,84,178,154,176,165,169,214,135,98,124,11,214,10,245,231,27,66,47,11,235,234,34,66,246,10,173,109,122,229,154,52,51,210,209,219,244,191,111,6,233,187,25,70,195,250,16,216,2,108,10,235,48,145,181,80,227,229,247,199,134,102,35,105,71,104,240,225,82,206,217,126,102,197,25,0,122,116,41,253,180,62,152,116,218,146,139,181,240,87,240,234,15,127,1,174,157,147,242,164,5,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateAddContacAddressMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("cd18d00b-aa43-475e-ae43-9ecf1f939583"),
				Name = "AddContacAddress",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("0ddfb326-8961-4ab4-8126-049433cf4cc8"),
				Name = "contactId",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,132,48,16,61,211,95,49,225,176,129,132,236,254,128,141,7,131,123,32,49,154,184,234,193,91,3,195,218,8,133,180,101,149,24,255,187,3,101,145,175,224,30,223,204,123,51,125,175,35,82,240,238,145,39,183,73,162,80,235,231,186,196,109,164,15,121,105,106,207,135,205,6,152,227,52,253,80,152,122,177,241,132,39,81,200,101,77,81,73,163,230,178,163,81,66,158,168,252,80,101,217,163,178,205,70,240,38,202,127,57,221,67,125,31,190,153,163,208,84,74,238,217,15,219,237,194,119,140,63,64,104,224,150,1,60,83,196,175,1,191,132,54,154,9,114,26,233,78,126,104,107,30,45,114,195,66,26,30,155,174,225,6,48,40,70,137,197,241,5,182,104,146,87,48,204,40,24,231,18,76,178,232,49,89,157,206,90,176,68,6,12,66,183,189,55,150,170,34,135,70,200,206,92,93,186,221,16,184,1,137,159,48,54,229,189,104,84,84,146,24,27,122,148,191,103,99,209,246,136,230,14,211,176,200,170,92,190,242,172,66,237,17,137,170,45,240,198,236,0,220,129,251,54,162,73,34,171,218,38,165,94,20,18,88,101,219,24,123,190,133,235,243,109,210,127,43,44,94,213,208,111,116,236,230,4,175,112,62,246,60,15,180,191,31,250,143,254,120,230,177,243,51,82,208,191,63,222,231,250,132,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateAddAccountAddressMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("c1936540-1ff1-47e9-8013-34aeccc38053"),
				Name = "AddAccountAddress",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("2d48371a-4f61-405e-9589-e551c3d14f9d"),
				Name = "accountId",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("e0d01508-647f-45d1-be6b-8fb83a5b47c5")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,132,48,16,61,211,95,49,225,176,129,132,236,254,128,141,135,13,238,129,196,104,226,170,7,111,13,12,107,35,20,210,150,85,98,252,239,14,148,69,190,130,30,223,204,123,51,243,94,43,82,240,238,144,39,135,36,81,168,245,83,93,226,54,210,199,188,52,181,231,195,102,3,204,113,154,126,40,76,189,216,120,196,179,40,228,178,166,168,164,81,115,217,201,40,33,207,84,190,175,178,236,65,217,102,35,120,21,229,159,156,238,80,223,135,47,230,40,52,149,146,123,246,205,118,187,240,13,227,119,16,26,184,101,0,207,20,241,107,192,79,161,141,102,130,156,70,186,147,31,219,154,71,139,220,67,28,55,119,118,13,55,128,65,49,74,44,230,87,216,162,73,94,193,48,163,96,156,75,48,201,162,199,100,117,58,107,193,18,25,48,8,221,246,222,88,170,138,28,26,33,187,112,117,237,118,67,224,6,36,126,192,216,148,247,172,81,133,133,148,24,27,58,202,223,179,177,104,123,66,115,139,105,88,100,85,46,95,120,86,161,246,136,68,213,22,120,99,118,0,238,192,125,27,209,36,145,85,109,147,82,47,10,9,172,178,109,140,61,223,194,245,249,54,233,223,21,22,175,106,232,53,58,118,243,5,255,225,124,236,121,30,104,255,127,232,61,250,207,51,143,157,95,144,130,254,1,163,166,142,59,132,3,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateIsAddressExistsMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("3d37119b-b810-4927-95c8-ffee3a0a27c7"),
				Name = "IsAddressExists",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379"),
				ResultValueTypeName = "bool"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("258a6dc1-5e41-4901-addf-a7af2fe52b05"),
				Name = "addressTableName",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("da2d55bf-4fbf-4838-a333-05200575d3ac"),
				Name = "relationColumnName",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("3a752f8e-a144-4878-bd56-30da77de8d1c"),
				Name = "relationColumnValue",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("ea2df1f1-d4c9-4d49-bc75-bf54b8eef7a9"),
				Name = "addressType",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("f7502380-4bd6-48e2-909f-b7c1c545fe6d"),
				Name = "addressCity",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("3a0fc0f1-64cc-4b3e-9d9e-d9158c5206c4"),
				Name = "addressRegion",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("f62327f0-975d-4954-a7e0-337e6ffc6ad2"),
				Name = "addressCountry",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("18230e13-130e-493d-aa00-f8182b70c96e"),
				Name = "zipValue",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("f8dc2466-bd41-44ed-aad4-e3b32f147719"),
				Name = "addressValue",
				CreatedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				ModifiedInSchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,77,143,211,48,16,61,167,191,194,244,176,114,164,85,10,231,170,135,221,182,160,74,176,192,110,23,36,110,110,51,219,90,114,236,226,15,74,65,251,223,25,199,142,155,180,133,13,135,40,182,231,205,123,111,60,227,31,76,19,86,150,26,140,121,0,1,107,75,38,68,194,158,132,13,125,52,160,167,74,74,92,115,37,243,65,86,76,149,112,149,164,195,111,124,55,108,239,111,2,73,125,246,86,171,138,70,214,37,91,9,184,99,21,248,192,215,45,104,160,26,4,243,116,33,181,142,21,11,51,255,238,152,160,225,172,248,196,52,30,91,208,39,224,47,76,56,200,115,194,76,116,56,30,12,248,19,161,175,26,181,195,14,60,87,181,179,7,138,184,223,131,172,83,93,113,35,203,228,213,131,23,229,240,31,226,45,214,60,31,15,158,59,90,83,110,15,47,107,121,84,47,17,15,60,23,185,135,13,22,255,178,76,192,245,18,10,208,11,245,40,39,173,238,83,82,0,246,171,42,96,131,218,74,41,65,214,170,218,49,13,56,63,56,106,79,76,24,24,7,27,15,86,115,185,65,198,59,39,196,71,29,76,252,226,187,166,231,104,166,217,97,102,179,44,150,234,189,218,163,96,94,44,53,175,40,10,101,125,233,178,142,23,171,29,90,201,158,79,140,198,97,233,99,54,214,220,82,104,159,32,67,123,251,127,198,207,169,179,51,127,173,2,156,65,10,66,103,183,243,159,176,118,86,105,82,174,210,114,66,186,207,186,152,75,227,52,204,110,143,71,177,249,145,102,49,99,150,221,3,43,65,19,29,126,169,150,56,24,129,28,2,136,30,197,162,215,209,104,9,198,18,96,235,109,147,88,224,241,126,203,5,16,124,227,62,171,240,201,81,56,203,76,125,11,190,205,168,21,1,239,192,134,203,161,175,243,75,215,151,178,162,196,165,204,55,127,201,172,91,142,106,31,152,69,143,169,217,77,36,50,158,71,71,163,207,142,91,178,223,130,76,178,220,144,138,217,173,15,251,142,182,166,236,234,138,4,31,143,150,11,110,57,152,162,126,63,102,177,145,74,195,148,25,240,51,122,157,198,187,185,14,63,250,141,120,236,115,134,157,238,6,142,203,73,235,153,213,208,150,143,102,96,250,120,137,21,93,119,38,55,121,58,185,148,174,175,147,96,119,155,252,69,51,201,99,42,1,221,181,83,26,73,13,214,105,217,149,194,207,207,124,12,133,214,252,1,137,231,50,148,216,6,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagementQualification(userConnection);
		}

		public override object Clone() {
			return new LeadManagementQualificationSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagementQualification

	/// <exclude/>
	public class LeadManagementQualification : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLeadQualification

		/// <exclude/>
		public class ProcessLeadQualification : ProcessLane
		{

			public ProcessLeadQualification(UserConnection userConnection, LeadManagementQualification process)
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

			public ReadLeadDataFlowElement(UserConnection userConnection, LeadManagementQualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadData";
				IsLogging = true;
				SchemaElementUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,219,146,45,201,61,46,219,178,80,210,64,211,82,72,150,48,146,70,89,129,63,54,182,76,19,204,254,247,202,235,108,10,57,148,210,91,65,135,209,104,222,155,55,143,209,124,31,198,143,161,137,56,212,30,154,17,233,180,115,53,81,50,171,148,45,21,227,86,35,19,185,171,152,66,101,24,47,164,41,84,174,140,178,64,104,7,45,214,100,69,111,93,136,132,134,136,237,88,223,206,191,73,227,48,33,189,247,231,203,87,123,192,22,190,45,13,68,14,94,105,212,76,150,153,97,2,141,97,137,210,50,239,185,54,149,80,34,71,75,86,45,168,185,149,214,8,230,164,45,153,240,94,50,237,83,169,54,170,244,186,200,115,144,21,161,13,250,184,125,58,14,56,142,161,239,234,25,95,227,155,231,99,82,185,246,222,244,205,212,118,132,182,24,225,26,226,161,38,128,25,138,210,2,179,66,47,236,40,25,112,237,24,7,35,11,169,48,175,114,73,168,133,99,92,104,201,206,17,234,32,194,119,104,38,60,51,207,33,105,44,120,150,171,178,74,216,156,91,38,120,145,49,85,41,201,188,171,188,70,94,105,109,220,197,175,79,83,72,113,24,175,166,22,135,96,95,108,199,228,95,63,212,179,237,187,56,244,205,66,125,117,46,191,193,167,184,154,251,242,244,99,29,40,166,252,2,34,39,58,141,184,105,2,118,113,219,217,222,133,238,97,229,60,157,18,164,61,194,16,198,139,11,219,199,9,26,66,135,240,112,248,163,91,155,105,140,125,251,31,141,74,211,152,137,35,45,217,89,238,178,131,46,140,199,6,158,207,247,154,188,123,156,250,248,225,51,130,91,35,242,6,81,147,59,34,29,112,199,181,96,182,52,69,218,5,3,204,160,144,76,10,9,89,230,120,165,74,188,35,73,197,63,112,223,238,198,47,63,187,203,31,88,85,239,223,167,236,155,196,245,5,89,207,127,35,231,180,95,4,237,79,233,252,2,53,129,193,231,202,3,0,0 })));
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

		#region Class: ChangeContactAccountFlowElement

		/// <exclude/>
		public class ChangeContactAccountFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeContactAccountFlowElement(UserConnection userConnection, LeadManagementQualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeContactAccount";
				IsLogging = true;
				SchemaElementUId = new Guid("304c2e1a-af0b-4016-a95f-ee471f292c6e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Account = () => (Guid)((process.AccountId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Account", () => _recordColumnValues_Account.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Account;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,43,65,135,158,60,197,178,100,91,118,143,203,182,236,37,77,105,90,2,73,8,35,105,148,21,248,99,99,203,52,193,236,127,175,188,206,182,144,67,233,161,151,130,14,210,72,239,205,123,143,209,252,224,199,143,190,9,52,212,14,155,145,146,105,103,107,166,114,237,164,171,50,112,156,19,72,41,16,116,90,57,176,174,212,28,93,37,181,40,89,210,97,75,53,91,209,91,235,3,75,124,160,118,172,111,231,223,164,97,152,40,121,112,167,195,87,179,167,22,191,45,13,120,161,73,20,57,7,229,40,3,201,243,10,148,181,41,160,74,133,149,133,18,214,10,182,106,113,133,205,172,174,16,82,165,11,144,70,58,64,148,6,156,206,164,70,99,140,83,81,75,67,46,108,159,15,3,141,163,239,187,122,166,95,251,235,151,67,84,185,246,222,244,205,212,118,44,105,41,224,21,134,125,205,144,82,146,185,65,48,178,202,65,58,42,1,69,101,65,160,46,179,82,17,47,120,100,55,120,8,11,45,219,89,150,88,12,248,29,155,137,78,204,179,143,26,51,145,114,149,23,17,203,133,1,41,178,20,84,161,74,112,182,112,85,52,90,85,218,158,243,250,52,249,184,247,227,229,212,210,224,205,107,236,20,243,235,135,122,54,125,23,134,190,89,168,47,79,207,175,233,57,172,225,190,94,221,172,134,66,172,47,32,118,76,166,145,54,141,167,46,108,59,211,91,223,61,174,156,199,99,132,180,7,28,252,120,78,97,251,52,97,195,146,193,63,238,255,152,214,102,26,67,223,254,71,86,147,104,51,114,196,33,59,201,93,102,208,250,241,208,224,203,233,92,179,119,79,83,31,62,124,137,246,189,243,100,47,112,188,88,154,160,9,235,13,123,195,80,179,59,150,113,151,10,202,45,112,93,42,144,202,26,136,14,83,224,70,69,175,113,50,164,82,119,44,170,250,7,189,110,119,227,231,31,221,249,143,172,174,238,223,199,234,155,194,213,25,89,207,127,35,239,120,191,8,188,63,198,245,19,156,38,180,91,234,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,143,218,48,16,253,43,200,187,71,140,108,39,78,156,28,91,90,9,105,105,105,105,247,2,28,38,246,120,23,41,36,40,31,109,183,40,255,125,29,39,20,104,247,84,31,108,101,198,239,189,241,188,201,137,220,55,47,71,36,41,121,183,90,174,75,219,204,222,151,21,206,86,85,169,177,174,103,15,165,134,124,255,27,178,28,87,80,193,1,27,172,30,33,111,177,126,216,215,205,116,114,13,34,83,114,255,195,231,72,186,57,145,69,131,135,239,11,227,152,49,146,76,4,161,165,74,101,49,13,33,182,52,139,33,162,42,9,172,230,81,36,117,98,28,88,151,121,123,40,150,216,192,10,154,103,146,158,136,103,115,4,82,71,26,56,67,202,185,98,52,212,28,169,2,201,168,148,16,11,107,147,204,152,144,116,83,82,235,103,60,128,23,189,128,121,148,97,16,73,78,149,69,65,67,46,19,170,140,97,20,20,11,76,24,169,192,152,160,7,143,247,47,192,205,221,102,81,127,254,89,96,181,246,188,169,133,188,198,221,204,69,255,10,252,105,77,122,2,99,173,35,181,84,198,74,210,80,4,138,66,18,9,42,156,20,68,198,38,130,197,221,238,110,215,43,154,125,125,204,225,229,241,95,225,47,173,235,186,221,163,153,64,61,1,173,203,182,104,6,204,241,198,133,107,212,105,59,88,185,37,233,246,109,51,199,115,40,254,214,206,91,39,183,100,186,37,235,178,173,116,207,22,244,31,231,206,122,118,54,46,250,198,118,94,3,135,135,45,161,128,39,172,62,57,61,15,247,169,57,52,224,165,191,185,154,207,196,153,72,36,139,185,165,49,66,66,67,116,141,83,134,3,77,120,146,217,32,14,156,217,194,163,191,162,197,10,11,141,183,133,9,105,98,205,33,163,220,160,27,20,201,56,205,66,38,40,19,200,176,31,22,19,13,143,243,202,151,98,206,67,231,34,69,155,231,94,160,246,239,239,167,120,44,124,204,204,175,92,187,98,40,141,55,108,81,252,103,171,230,104,61,229,199,178,250,240,203,253,91,251,226,105,244,235,74,250,114,103,174,15,99,188,35,93,183,235,94,1,39,159,89,138,200,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "4e764f9106384bdbb584bf89b9bf3645",
							"BaseElements.ChangeContactAccount.Parameters.RecordColumnValues.Value");
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

		#region Class: ChangeLeadStageDistributionFlowElement

		/// <exclude/>
		public class ChangeLeadStageDistributionFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeLeadStageDistributionFlowElement(UserConnection userConnection, LeadManagementQualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeLeadStageDistribution";
				IsLogging = true;
				SchemaElementUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifyStatus = () => (Guid)(new Guid("14cfc644-e3ed-497e-8279-ed4319bb8093"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifyStatus", () => _recordColumnValues_QualifyStatus.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifyStatus;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,91,146,45,203,61,46,219,178,80,210,64,211,82,72,150,48,150,70,89,129,63,54,150,76,19,204,254,247,202,235,108,10,57,148,210,91,65,135,153,145,222,155,55,143,209,124,239,195,71,223,70,28,107,7,109,64,58,237,108,77,184,226,34,47,141,98,152,75,203,164,212,142,85,156,75,86,104,206,185,145,69,46,120,65,104,15,29,214,100,69,111,173,143,132,250,136,93,168,111,231,223,164,113,156,144,222,187,115,242,213,28,176,131,111,75,3,153,131,171,52,106,166,138,172,97,18,155,134,85,6,12,115,78,232,166,148,149,204,209,144,85,139,146,218,100,188,116,12,178,204,49,89,186,20,85,166,96,214,136,194,128,179,153,85,72,104,139,46,110,159,142,35,134,224,135,190,158,241,53,190,121,62,38,149,107,239,205,208,78,93,79,104,135,17,174,33,30,106,2,152,161,76,60,204,72,93,48,233,80,49,16,218,50,1,141,226,170,194,188,204,21,161,6,142,113,161,37,59,75,168,133,8,223,161,157,240,204,60,251,197,47,145,229,85,81,38,108,46,12,147,130,103,172,42,43,197,156,45,157,70,81,106,221,216,139,95,159,38,159,98,31,174,166,14,71,111,94,108,199,228,223,48,214,179,25,250,56,14,237,66,125,117,126,126,131,79,113,53,247,229,234,199,58,80,76,245,5,68,78,116,10,184,105,61,246,113,219,155,193,250,254,97,229,60,157,18,164,59,194,232,195,197,133,237,227,4,45,161,163,127,56,252,209,173,205,20,226,208,253,71,163,210,52,102,226,72,75,118,150,187,236,160,245,225,216,194,243,57,175,201,187,199,105,136,31,62,35,216,53,34,111,16,53,185,35,202,130,176,66,75,102,138,134,167,93,104,128,53,40,21,83,82,165,221,179,162,172,10,188,35,73,197,63,112,223,238,194,151,159,253,229,15,172,170,247,239,83,245,77,225,250,130,172,231,191,145,115,218,47,130,246,167,116,126,1,123,109,74,170,202,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,203,142,219,32,20,253,149,138,153,101,176,192,96,48,89,182,105,165,72,73,21,53,237,108,38,179,184,198,151,25,171,142,137,252,168,58,141,242,239,37,196,105,18,105,42,85,101,1,130,203,121,112,15,123,114,223,191,238,144,76,201,251,213,114,237,93,159,124,240,45,38,171,214,91,236,186,100,225,45,212,213,47,40,106,92,65,11,91,236,177,125,128,122,192,110,81,117,253,228,221,53,136,76,200,253,143,88,35,211,199,61,153,247,184,253,54,47,3,179,150,37,207,178,162,160,82,0,82,9,96,41,100,70,83,230,148,205,83,46,144,233,34,128,173,175,135,109,179,196,30,86,208,191,144,233,158,68,182,64,80,88,102,211,82,49,154,129,40,169,204,37,163,0,18,169,85,12,65,107,133,41,83,228,48,33,157,125,193,45,68,209,11,88,114,112,185,65,67,117,198,130,5,12,62,114,27,44,56,39,76,161,2,25,71,123,4,143,247,47,192,199,187,133,247,223,135,93,146,166,66,114,91,114,154,21,66,80,105,131,188,97,156,83,229,180,50,2,157,66,41,19,46,173,179,74,74,138,2,131,71,163,145,230,169,54,20,75,41,184,41,138,156,25,113,247,116,20,42,171,110,87,195,235,195,95,245,214,61,60,99,50,11,13,110,171,98,232,43,223,156,128,187,155,4,174,161,251,205,41,198,13,153,110,222,14,114,92,215,177,67,183,81,222,166,184,33,147,13,89,251,161,181,71,54,113,220,156,187,26,217,217,56,232,27,211,121,156,56,34,108,9,77,120,76,251,57,232,69,120,44,205,160,135,40,253,53,120,62,19,23,169,201,152,230,142,106,4,19,114,82,41,205,75,14,212,132,238,57,161,69,234,92,26,209,95,208,97,139,141,197,91,99,233,63,164,20,241,81,249,98,230,252,225,194,73,51,212,117,20,232,226,251,143,63,120,52,62,86,66,38,127,162,187,98,240,101,229,42,44,231,205,127,182,106,134,46,82,126,242,237,199,159,33,246,170,121,30,243,186,146,190,220,153,217,237,120,126,32,135,195,211,225,55,219,125,202,39,196,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "4e764f9106384bdbb584bf89b9bf3645",
							"BaseElements.ChangeLeadStageDistribution.Parameters.RecordColumnValues.Value");
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

		#region Class: LinkContactToLeadFlowElement

		/// <exclude/>
		public class LinkContactToLeadFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public LinkContactToLeadFlowElement(UserConnection userConnection, LeadManagementQualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "LinkContactToLead";
				IsLogging = true;
				SchemaElementUId = new Guid("9da5af0d-7621-41eb-8e00-f682895bb04e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifiedContact = () => (Guid)((process.ContactId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifiedContact", () => _recordColumnValues_QualifiedContact.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifiedContact;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,100,21,219,146,45,201,61,46,219,178,80,210,64,211,82,72,150,48,146,70,89,129,63,54,150,76,19,204,254,247,202,235,108,10,57,148,210,91,65,135,153,145,222,155,55,143,209,124,239,195,71,223,70,28,27,7,109,192,108,218,217,134,228,224,74,199,164,166,214,212,21,229,70,20,84,114,91,81,109,21,230,170,174,141,150,154,100,61,116,216,144,21,189,181,62,146,204,71,236,66,115,59,255,38,141,227,132,217,189,59,39,95,205,1,59,248,182,52,224,5,56,169,80,81,81,229,154,114,212,154,74,3,134,58,199,148,174,185,228,5,26,178,106,209,104,20,171,77,78,157,72,239,185,41,144,202,138,139,37,5,174,36,215,133,96,36,107,209,197,237,211,113,196,16,252,208,55,51,190,198,55,207,199,164,114,237,189,25,218,169,235,73,214,97,132,107,136,135,134,0,230,200,43,3,212,112,149,38,117,40,40,48,101,41,3,45,74,33,177,168,11,65,50,3,199,184,208,146,157,37,153,133,8,223,161,157,240,204,60,251,164,177,100,121,33,171,58,97,11,102,40,103,101,78,101,45,147,70,91,59,133,172,86,74,219,139,95,159,38,159,98,31,174,166,14,71,111,94,108,199,228,223,48,54,179,25,250,56,14,237,66,125,117,126,126,131,79,113,53,247,229,234,199,58,80,76,245,5,68,78,217,20,112,211,122,236,227,182,55,131,245,253,195,202,121,58,37,72,119,132,209,135,139,11,219,199,9,90,146,141,254,225,240,71,183,54,83,136,67,247,31,141,154,165,49,19,71,90,178,179,220,101,7,173,15,199,22,158,207,121,67,222,61,78,67,252,240,25,193,174,17,121,131,104,200,29,17,22,152,101,138,83,83,233,50,237,130,6,170,49,109,154,224,2,242,220,178,90,86,120,71,146,138,127,224,190,221,133,47,63,251,203,31,88,85,239,223,167,234,155,194,245,5,217,204,127,35,231,180,95,4,237,79,233,252,2,68,233,196,17,202,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,143,218,48,16,253,43,200,187,71,140,236,216,9,118,142,45,173,132,180,180,180,180,123,1,14,99,123,188,139,20,18,148,132,182,91,148,255,190,198,132,2,237,158,234,67,162,204,248,125,120,158,115,32,247,237,203,14,73,78,222,205,103,139,202,183,163,247,85,141,163,121,93,89,108,154,209,67,101,161,216,252,6,83,224,28,106,216,98,139,245,35,20,123,108,30,54,77,59,28,92,131,200,144,220,255,136,61,146,47,15,100,218,226,246,251,212,5,102,101,156,179,222,27,154,24,207,168,84,192,41,112,233,104,194,153,245,137,100,152,24,23,192,182,42,246,219,114,134,45,204,161,125,38,249,129,68,182,64,0,78,106,230,82,69,89,42,129,74,167,82,170,19,153,81,231,148,204,50,52,66,43,65,186,33,105,236,51,110,33,138,94,192,146,131,87,26,53,29,167,204,80,137,198,80,101,193,82,239,133,54,153,84,146,163,61,130,251,253,23,224,242,110,57,109,62,255,44,177,94,68,222,220,67,209,224,122,20,170,127,21,254,140,38,63,36,220,51,129,169,163,220,140,85,56,171,179,84,163,96,148,91,149,121,205,51,46,149,234,214,119,235,163,162,219,52,187,2,94,30,255,21,254,178,15,83,247,27,116,3,104,6,182,42,91,176,237,9,179,187,73,225,26,117,88,157,162,92,145,124,245,118,152,253,251,100,254,54,206,219,36,87,100,184,34,139,106,95,219,35,155,56,126,156,39,27,217,89,191,232,27,143,243,58,113,68,216,12,74,120,194,250,83,208,139,240,216,154,64,11,81,250,91,240,124,38,54,137,78,217,152,123,58,70,208,33,171,44,161,202,113,160,154,107,227,197,88,36,222,39,17,253,21,61,214,88,90,188,53,198,51,131,34,75,57,85,30,19,42,121,170,3,222,49,10,138,9,39,51,37,156,19,17,31,149,47,102,206,151,46,84,202,125,81,68,129,38,158,255,120,139,123,227,125,103,114,149,218,21,67,229,98,96,211,242,63,71,53,65,31,41,63,86,245,135,95,225,223,218,148,79,125,94,87,210,151,61,19,187,237,235,29,233,186,117,247,10,28,110,164,247,200,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "4e764f9106384bdbb584bf89b9bf3645",
							"BaseElements.LinkContactToLead.Parameters.RecordColumnValues.Value");
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

		#region Class: LinkAccountToLeadFlowElement

		/// <exclude/>
		public class LinkAccountToLeadFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public LinkAccountToLeadFlowElement(UserConnection userConnection, LeadManagementQualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "LinkAccountToLead";
				IsLogging = true;
				SchemaElementUId = new Guid("1337590d-7ee1-488b-b0db-de061f6759f5");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifiedAccount = () => (Guid)((process.AccountId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualifiedAccount", () => _recordColumnValues_QualifiedAccount.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_QualifiedAccount;

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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,127,72,150,229,30,151,109,89,40,105,160,105,41,36,75,24,73,163,172,192,31,27,75,166,9,102,255,123,229,117,54,133,28,74,233,173,160,195,204,72,239,205,155,199,104,190,247,225,163,111,35,142,141,131,54,32,157,118,182,33,89,94,91,13,218,177,66,229,150,113,172,53,211,174,54,76,85,142,231,89,230,180,118,72,104,15,29,54,100,69,111,173,143,132,250,136,93,104,110,231,223,164,113,156,144,222,187,115,242,213,28,176,131,111,75,3,158,131,171,21,42,38,69,166,83,3,173,89,109,192,48,231,74,165,43,94,243,28,13,89,181,8,237,138,42,43,37,43,100,101,24,183,66,49,45,92,197,140,116,5,26,93,24,1,130,208,22,93,220,62,29,71,12,193,15,125,51,227,107,124,243,124,76,42,215,222,155,161,157,186,158,208,14,35,92,67,60,52,4,48,67,46,12,48,195,149,96,220,161,100,80,42,203,74,208,178,144,53,230,85,46,9,53,112,140,11,45,217,89,66,45,68,248,14,237,132,103,230,217,39,141,69,153,28,19,85,194,230,101,210,88,22,25,171,171,90,50,103,43,167,176,172,148,210,246,226,215,167,201,167,216,135,171,169,195,209,155,23,219,49,249,55,140,205,108,134,62,142,67,187,80,95,157,159,223,224,83,92,205,125,185,250,177,14,20,83,125,1,145,19,157,2,110,90,143,125,220,246,102,176,190,127,88,57,79,167,4,233,142,48,250,112,113,97,251,56,65,75,232,232,31,14,127,116,107,51,133,56,116,255,209,168,52,141,153,56,210,146,157,229,46,59,104,125,56,182,240,124,206,27,242,238,113,26,226,135,207,8,118,141,200,27,68,67,238,136,180,80,218,82,113,102,132,46,210,46,104,96,26,185,100,146,75,200,50,91,86,181,192,59,146,84,252,3,247,237,46,124,249,217,95,254,192,170,122,255,62,85,223,20,174,47,200,102,254,27,57,167,253,34,104,127,74,231,23,52,11,173,221,202,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,143,218,48,16,253,43,200,187,71,140,108,199,78,226,28,91,90,9,105,105,105,105,247,2,28,38,246,120,23,41,36,40,31,109,183,40,255,125,141,9,5,218,61,213,7,91,153,241,123,111,60,111,114,32,247,237,203,30,73,70,222,45,230,203,202,181,147,247,85,141,147,69,93,25,108,154,201,67,101,160,216,254,134,188,192,5,212,176,195,22,235,71,40,58,108,30,182,77,59,30,93,131,200,152,220,255,8,57,146,173,14,100,214,226,238,251,204,122,230,36,22,142,229,86,81,33,29,167,146,69,150,66,110,13,229,44,145,2,45,143,53,139,60,216,84,69,183,43,231,216,194,2,218,103,146,29,72,96,243,4,145,208,82,3,74,234,28,143,168,76,157,162,218,41,75,165,130,68,42,149,34,40,69,250,49,105,204,51,238,32,136,94,192,146,131,75,53,106,154,40,150,83,137,121,78,83,3,198,115,69,58,143,101,42,57,154,35,120,184,127,1,174,238,86,179,230,243,207,18,235,101,224,205,28,20,13,110,38,62,250,87,224,79,107,178,3,88,231,100,156,58,170,146,84,81,41,162,148,130,142,5,21,86,198,16,91,167,5,75,250,205,221,230,168,104,183,205,190,128,151,199,127,133,191,116,190,235,110,139,118,4,205,8,140,169,186,178,61,97,246,55,46,92,163,14,235,147,149,107,146,173,223,54,115,56,79,197,223,218,121,235,228,154,140,215,100,89,117,181,57,178,69,199,143,115,103,3,59,27,22,125,99,59,175,19,71,128,205,161,132,39,172,63,121,189,0,15,169,41,180,16,164,191,249,154,207,196,185,208,138,37,220,209,4,65,123,175,124,227,82,203,129,106,174,115,23,37,145,112,78,4,244,87,116,88,99,105,240,182,48,161,108,98,56,228,148,91,100,126,60,24,167,185,100,130,50,129,12,253,176,8,27,159,30,23,148,47,197,156,135,206,71,202,174,40,130,64,19,222,127,156,226,161,240,33,51,189,114,237,138,161,178,193,176,89,249,159,173,154,162,11,148,31,171,250,195,47,255,111,109,203,167,193,175,43,233,203,157,169,217,13,241,158,244,253,166,127,5,211,140,104,81,200,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "4e764f9106384bdbb584bf89b9bf3645",
							"BaseElements.LinkAccountToLead.Parameters.RecordColumnValues.Value");
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

		#region Class: ReadSystemSettingsFlowElement

		/// <exclude/>
		public class ReadSystemSettingsFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadSystemSettingsFlowElement(UserConnection userConnection, LeadManagementQualification process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadSystemSettings";
				IsLogging = true;
				SchemaElementUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,82,77,107,220,48,20,252,43,69,135,158,172,32,75,178,100,187,167,178,108,161,151,52,101,211,82,40,37,60,73,79,89,129,63,54,150,12,89,150,253,239,149,237,164,133,30,10,61,22,116,208,199,155,55,243,102,116,121,8,241,67,232,18,78,173,135,46,98,49,127,116,45,145,160,164,107,76,67,141,20,134,202,178,81,180,198,18,40,154,90,75,20,158,149,88,146,98,128,30,91,178,161,247,46,36,82,132,132,125,108,191,95,126,55,77,211,140,197,131,95,15,7,123,196,30,190,44,4,77,85,26,110,140,161,204,128,160,146,201,134,54,192,51,95,229,164,101,70,185,138,121,178,105,225,186,86,154,87,21,229,156,121,42,173,180,180,169,165,162,149,45,89,227,148,22,232,36,41,58,244,105,255,124,154,48,198,48,14,237,5,127,237,239,207,167,172,114,227,222,141,221,220,15,164,232,49,193,29,164,99,75,152,119,168,124,137,185,187,173,168,172,173,166,141,173,27,170,60,99,162,68,174,153,195,155,82,0,184,74,74,138,86,48,42,81,43,10,66,11,234,153,245,94,112,198,145,103,9,22,78,105,225,38,135,115,204,62,188,137,152,82,24,30,111,118,163,67,82,56,72,240,21,186,25,87,61,151,144,39,19,188,2,45,76,77,153,151,154,74,9,140,214,178,228,84,43,166,188,174,179,0,176,175,46,31,142,227,148,238,241,121,49,57,222,206,61,78,193,190,36,134,217,250,113,106,47,118,28,210,52,118,75,255,219,21,179,148,111,185,188,60,125,219,188,72,249,126,1,145,107,49,71,220,117,1,135,180,31,236,232,178,218,53,176,235,53,35,250,19,76,33,190,250,183,127,154,161,35,197,20,30,143,127,245,249,14,166,204,157,195,254,207,38,46,242,180,155,240,85,242,242,137,93,136,167,14,206,235,185,37,111,159,230,49,189,219,77,8,9,223,91,59,206,67,250,52,124,206,166,4,31,44,44,193,111,21,228,143,78,255,128,188,254,184,230,245,19,237,231,240,99,146,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,174,44,14,78,45,41,201,204,75,47,182,50,180,50,212,241,76,177,50,176,50,0,0,176,83,7,250,22,0,0,0 })));
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
								new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"));
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

		public LeadManagementQualification(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagementQualification";
			SchemaUId = new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_leadAddressType = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("AddressType").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("AddressTypeId") : Guid.Empty))); };
			_leadCity = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("City").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("CityId") : Guid.Empty))); };
			_leadZip = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Zip").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Zip") : null))); };
			_leadRegion = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Region").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("RegionId") : Guid.Empty))); };
			_leadCountry = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Country").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("CountryId") : Guid.Empty))); };
			_leadWebsite = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Website").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Website") : null))); };
			_leadFax = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Fax").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Fax") : null))); };
			_leadBusinessPhone = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("BusinesPhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("BusinesPhone") : null))); };
			_leadEmail = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Email") : null))); };
			_leadMobilePhone = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("MobilePhone").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("MobilePhone") : null))); };
			_leadDecisionRole = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("DecisionRole").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("DecisionRoleId") : Guid.Empty))); };
			_leadGender = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Gender").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("GenderId") : Guid.Empty))); };
			_leadDepartment = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Department").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("DepartmentId") : Guid.Empty))); };
			_leadJob = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Job").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("JobId") : Guid.Empty))); };
			_leadSalutation = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Title").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("TitleId") : Guid.Empty))); };
			_leadDear = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Dear").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Dear") : null))); };
			_leadFullJobTitle = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("FullJobTitle").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("FullJobTitle") : null))); };
			_leadContactName = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Contact") : null))); };
			_leadAccountName = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Account") : null))); };
			_leadAnnualRevenue = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("AnnualRevenue").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("AnnualRevenueId") : Guid.Empty))); };
			_leadEmployeesNumber = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("EmployeesNumber").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("EmployeesNumberId") : Guid.Empty))); };
			_leadAccountCategory = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("AccountCategory").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("AccountCategoryId") : Guid.Empty))); };
			_leadIndustry = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Industry").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("IndustryId") : Guid.Empty))); };
			_leadOwnership = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("AccountOwnership").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("AccountOwnershipId") : Guid.Empty))); };
			_leadAccountId = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualifiedAccount").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("QualifiedAccountId") : Guid.Empty))); };
			_leadContactId = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualifiedContact").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("QualifiedContactId") : Guid.Empty))); };
			_leadAddress = () => { return new LocalizableString(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Address").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<string>("Address") : null))); };
			_createAccountOnQualification = () => { return (bool)(((ReadSystemSettings.ResultEntity.IsColumnValueLoaded(ReadSystemSettings.ResultEntity.Schema.Columns.GetByName("BooleanValue").ColumnValueName) ? ReadSystemSettings.ResultEntity.GetTypedColumnValue<bool>("BooleanValue") : false))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4e764f91-0638-4bdb-b584-bf89b9bf3645");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagementQualification, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagementQualification, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid LeadId {
			get;
			set;
		}

		public virtual Guid AccountId {
			get;
			set;
		}

		public virtual Guid ContactId {
			get;
			set;
		}

		private Func<Guid> _leadAddressType;
		public virtual Guid LeadAddressType {
			get {
				return (_leadAddressType ?? (_leadAddressType = () => Guid.Empty)).Invoke();
			}
			set {
				_leadAddressType = () => { return value; };
			}
		}

		private Func<Guid> _leadCity;
		public virtual Guid LeadCity {
			get {
				return (_leadCity ?? (_leadCity = () => Guid.Empty)).Invoke();
			}
			set {
				_leadCity = () => { return value; };
			}
		}

		private Func<string> _leadZip;
		public virtual string LeadZip {
			get {
				return (_leadZip ?? (_leadZip = () => null)).Invoke();
			}
			set {
				_leadZip = () => { return value; };
			}
		}

		private Func<Guid> _leadRegion;
		public virtual Guid LeadRegion {
			get {
				return (_leadRegion ?? (_leadRegion = () => Guid.Empty)).Invoke();
			}
			set {
				_leadRegion = () => { return value; };
			}
		}

		private Func<Guid> _leadCountry;
		public virtual Guid LeadCountry {
			get {
				return (_leadCountry ?? (_leadCountry = () => Guid.Empty)).Invoke();
			}
			set {
				_leadCountry = () => { return value; };
			}
		}

		private Func<string> _leadWebsite;
		public virtual string LeadWebsite {
			get {
				return (_leadWebsite ?? (_leadWebsite = () => null)).Invoke();
			}
			set {
				_leadWebsite = () => { return value; };
			}
		}

		private Func<string> _leadFax;
		public virtual string LeadFax {
			get {
				return (_leadFax ?? (_leadFax = () => null)).Invoke();
			}
			set {
				_leadFax = () => { return value; };
			}
		}

		private Func<string> _leadBusinessPhone;
		public virtual string LeadBusinessPhone {
			get {
				return (_leadBusinessPhone ?? (_leadBusinessPhone = () => null)).Invoke();
			}
			set {
				_leadBusinessPhone = () => { return value; };
			}
		}

		private Func<string> _leadEmail;
		public virtual string LeadEmail {
			get {
				return (_leadEmail ?? (_leadEmail = () => null)).Invoke();
			}
			set {
				_leadEmail = () => { return value; };
			}
		}

		private Func<string> _leadMobilePhone;
		public virtual string LeadMobilePhone {
			get {
				return (_leadMobilePhone ?? (_leadMobilePhone = () => null)).Invoke();
			}
			set {
				_leadMobilePhone = () => { return value; };
			}
		}

		private Func<Guid> _leadDecisionRole;
		public virtual Guid LeadDecisionRole {
			get {
				return (_leadDecisionRole ?? (_leadDecisionRole = () => Guid.Empty)).Invoke();
			}
			set {
				_leadDecisionRole = () => { return value; };
			}
		}

		private Func<Guid> _leadGender;
		public virtual Guid LeadGender {
			get {
				return (_leadGender ?? (_leadGender = () => Guid.Empty)).Invoke();
			}
			set {
				_leadGender = () => { return value; };
			}
		}

		private Func<Guid> _leadDepartment;
		public virtual Guid LeadDepartment {
			get {
				return (_leadDepartment ?? (_leadDepartment = () => Guid.Empty)).Invoke();
			}
			set {
				_leadDepartment = () => { return value; };
			}
		}

		private Func<Guid> _leadJob;
		public virtual Guid LeadJob {
			get {
				return (_leadJob ?? (_leadJob = () => Guid.Empty)).Invoke();
			}
			set {
				_leadJob = () => { return value; };
			}
		}

		private Func<Guid> _leadSalutation;
		public virtual Guid LeadSalutation {
			get {
				return (_leadSalutation ?? (_leadSalutation = () => Guid.Empty)).Invoke();
			}
			set {
				_leadSalutation = () => { return value; };
			}
		}

		private Func<string> _leadDear;
		public virtual string LeadDear {
			get {
				return (_leadDear ?? (_leadDear = () => null)).Invoke();
			}
			set {
				_leadDear = () => { return value; };
			}
		}

		private Func<string> _leadFullJobTitle;
		public virtual string LeadFullJobTitle {
			get {
				return (_leadFullJobTitle ?? (_leadFullJobTitle = () => null)).Invoke();
			}
			set {
				_leadFullJobTitle = () => { return value; };
			}
		}

		private Func<string> _leadContactName;
		public virtual string LeadContactName {
			get {
				return (_leadContactName ?? (_leadContactName = () => null)).Invoke();
			}
			set {
				_leadContactName = () => { return value; };
			}
		}

		private Func<string> _leadAccountName;
		public virtual string LeadAccountName {
			get {
				return (_leadAccountName ?? (_leadAccountName = () => null)).Invoke();
			}
			set {
				_leadAccountName = () => { return value; };
			}
		}

		private Func<Guid> _leadAnnualRevenue;
		public virtual Guid LeadAnnualRevenue {
			get {
				return (_leadAnnualRevenue ?? (_leadAnnualRevenue = () => Guid.Empty)).Invoke();
			}
			set {
				_leadAnnualRevenue = () => { return value; };
			}
		}

		private Func<Guid> _leadEmployeesNumber;
		public virtual Guid LeadEmployeesNumber {
			get {
				return (_leadEmployeesNumber ?? (_leadEmployeesNumber = () => Guid.Empty)).Invoke();
			}
			set {
				_leadEmployeesNumber = () => { return value; };
			}
		}

		private Func<Guid> _leadAccountCategory;
		public virtual Guid LeadAccountCategory {
			get {
				return (_leadAccountCategory ?? (_leadAccountCategory = () => Guid.Empty)).Invoke();
			}
			set {
				_leadAccountCategory = () => { return value; };
			}
		}

		private Func<Guid> _leadIndustry;
		public virtual Guid LeadIndustry {
			get {
				return (_leadIndustry ?? (_leadIndustry = () => Guid.Empty)).Invoke();
			}
			set {
				_leadIndustry = () => { return value; };
			}
		}

		private Func<Guid> _leadOwnership;
		public virtual Guid LeadOwnership {
			get {
				return (_leadOwnership ?? (_leadOwnership = () => Guid.Empty)).Invoke();
			}
			set {
				_leadOwnership = () => { return value; };
			}
		}

		private Func<Guid> _leadAccountId;
		public virtual Guid LeadAccountId {
			get {
				return (_leadAccountId ?? (_leadAccountId = () => Guid.Empty)).Invoke();
			}
			set {
				_leadAccountId = () => { return value; };
			}
		}

		private Func<Guid> _leadContactId;
		public virtual Guid LeadContactId {
			get {
				return (_leadContactId ?? (_leadContactId = () => Guid.Empty)).Invoke();
			}
			set {
				_leadContactId = () => { return value; };
			}
		}

		private Func<string> _leadAddress;
		public virtual string LeadAddress {
			get {
				return (_leadAddress ?? (_leadAddress = () => null)).Invoke();
			}
			set {
				_leadAddress = () => { return value; };
			}
		}

		private Func<bool> _createAccountOnQualification;
		public virtual bool CreateAccountOnQualification {
			get {
				return (_createAccountOnQualification ?? (_createAccountOnQualification = () => false)).Invoke();
			}
			set {
				_createAccountOnQualification = () => { return value; };
			}
		}

		private ProcessLeadQualification _leadQualification;
		public ProcessLeadQualification LeadQualification {
			get {
				return _leadQualification ?? ((_leadQualification) = new ProcessLeadQualification(UserConnection, this));
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
					SchemaElementUId = new Guid("bf1b5b17-6f6d-4e3d-8136-b213854f53b7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessTerminateEvent _terminateQualified;
		public ProcessTerminateEvent TerminateQualified {
			get {
				return _terminateQualified ?? (_terminateQualified = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateQualified",
					SchemaElementUId = new Guid("279e66a8-61fb-4e2b-8559-0362a5ebb1fe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("ed9cbb4d-b5c9-4231-ab67-76ffff3433b0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayIsLeadSet.Question"),
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
					SchemaElementUId = new Guid("478ef5b0-3cfe-49aa-9d92-d33e5210847a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ReadLeadDataFlowElement _readLeadData;
		public ReadLeadDataFlowElement ReadLeadData {
			get {
				return _readLeadData ?? (_readLeadData = new ReadLeadDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeContactAccountFlowElement _changeContactAccount;
		public ChangeContactAccountFlowElement ChangeContactAccount {
			get {
				return _changeContactAccount ?? (_changeContactAccount = new ChangeContactAccountFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayAccountConnection;
		public ProcessExclusiveGateway ExclusiveGatewayAccountConnection {
			get {
				return _exclusiveGatewayAccountConnection ?? (_exclusiveGatewayAccountConnection = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayAccountConnection",
					SchemaElementUId = new Guid("968e7a35-4c26-459a-806f-a3b34d7fe1c2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayAccountConnection.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ChangeLeadStageDistributionFlowElement _changeLeadStageDistribution;
		public ChangeLeadStageDistributionFlowElement ChangeLeadStageDistribution {
			get {
				return _changeLeadStageDistribution ?? (_changeLeadStageDistribution = new ChangeLeadStageDistributionFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _changeAccountScriptTask;
		public ProcessScriptTask ChangeAccountScriptTask {
			get {
				return _changeAccountScriptTask ?? (_changeAccountScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ChangeAccountScriptTask",
					SchemaElementUId = new Guid("97776b38-7f29-472a-ab13-e87884d17d43"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ChangeAccountScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _changeContactScriptTask;
		public ProcessScriptTask ChangeContactScriptTask {
			get {
				return _changeContactScriptTask ?? (_changeContactScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ChangeContactScriptTask",
					SchemaElementUId = new Guid("9970214a-b543-4895-ab00-ab57461e70cf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ChangeContactScriptTaskExecute,
				});
			}
		}

		private LinkContactToLeadFlowElement _linkContactToLead;
		public LinkContactToLeadFlowElement LinkContactToLead {
			get {
				return _linkContactToLead ?? (_linkContactToLead = new LinkContactToLeadFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private LinkAccountToLeadFlowElement _linkAccountToLead;
		public LinkAccountToLeadFlowElement LinkAccountToLead {
			get {
				return _linkAccountToLead ?? (_linkAccountToLead = new LinkAccountToLeadFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGatewayQualifiedAccount;
		public ProcessExclusiveGateway ExclusiveGatewayQualifiedAccount {
			get {
				return _exclusiveGatewayQualifiedAccount ?? (_exclusiveGatewayQualifiedAccount = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayQualifiedAccount",
					SchemaElementUId = new Guid("045b9d72-61cb-4f5f-8a92-c02297c04e1d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayQualifiedAccount.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ReadSystemSettingsFlowElement _readSystemSettings;
		public ReadSystemSettingsFlowElement ReadSystemSettings {
			get {
				return _readSystemSettings ?? (_readSystemSettings = new ReadSystemSettingsFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("00b2c101-a67f-4a28-a60e-f6ef8f988808"),
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
					SchemaElementUId = new Guid("8df03451-825f-4626-947e-1c39dddd618f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _qualifiedContactExistsSequenceFlow;
		public ProcessConditionalFlow QualifiedContactExistsSequenceFlow {
			get {
				return _qualifiedContactExistsSequenceFlow ?? (_qualifiedContactExistsSequenceFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "QualifiedContactExistsSequenceFlow",
					SchemaElementUId = new Guid("644d1a44-d831-44e0-982d-8da2dc9c15bf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _qualifiedAccountExistsSequenceFlow;
		public ProcessConditionalFlow QualifiedAccountExistsSequenceFlow {
			get {
				return _qualifiedAccountExistsSequenceFlow ?? (_qualifiedAccountExistsSequenceFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "QualifiedAccountExistsSequenceFlow",
					SchemaElementUId = new Guid("2e0ed20e-8966-4d04-847a-b6b5a83c0b82"),
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
			FlowElements[TerminateQualified.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateQualified };
			FlowElements[ExclusiveGatewayIsLeadSet.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayIsLeadSet };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
			FlowElements[ReadLeadData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadLeadData };
			FlowElements[ChangeContactAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeContactAccount };
			FlowElements[ExclusiveGatewayAccountConnection.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayAccountConnection };
			FlowElements[ChangeLeadStageDistribution.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeLeadStageDistribution };
			FlowElements[ChangeAccountScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeAccountScriptTask };
			FlowElements[ChangeContactScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeContactScriptTask };
			FlowElements[LinkContactToLead.SchemaElementUId] = new Collection<ProcessFlowElement> { LinkContactToLead };
			FlowElements[LinkAccountToLead.SchemaElementUId] = new Collection<ProcessFlowElement> { LinkAccountToLead };
			FlowElements[ExclusiveGatewayQualifiedAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayQualifiedAccount };
			FlowElements[ReadSystemSettings.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadSystemSettings };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayIsLeadSet", e.Context.SenderName));
						break;
					case "TerminateQualified":
						CompleteProcess();
						break;
					case "ExclusiveGatewayIsLeadSet":
						if (ConditionalFlowLeadUndefinedExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadLeadData", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
					case "ReadLeadData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadSystemSettings", e.Context.SenderName));
						break;
					case "ChangeContactAccount":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadStageDistribution", e.Context.SenderName));
						break;
					case "ExclusiveGatewayAccountConnection":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeContactAccount", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadStageDistribution", e.Context.SenderName));
						break;
					case "ChangeLeadStageDistribution":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateQualified", e.Context.SenderName));
						break;
					case "ChangeAccountScriptTask":
						if (QualifiedContactExistsSequenceFlowExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkContactToLead", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayQualifiedAccount", e.Context.SenderName));
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ChangeAccountScriptTask");
						break;
					case "ChangeContactScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeAccountScriptTask", e.Context.SenderName));
						break;
					case "LinkContactToLead":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayQualifiedAccount", e.Context.SenderName));
						break;
					case "LinkAccountToLead":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayAccountConnection", e.Context.SenderName));
						break;
					case "ExclusiveGatewayQualifiedAccount":
						if (QualifiedAccountExistsSequenceFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LinkAccountToLead", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayAccountConnection", e.Context.SenderName));
						break;
					case "ReadSystemSettings":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeContactScriptTask", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlowLeadUndefinedExpressionExecute() {
			bool result = Convert.ToBoolean((LeadId) == Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayIsLeadSet", "ConditionalFlowLeadUndefined", "(LeadId) == Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((AccountId)!= Guid.Empty && (ContactId) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayAccountConnection", "ConditionalFlow3", "(AccountId)!= Guid.Empty && (ContactId) != Guid.Empty", result);
			return result;
		}

		private bool QualifiedContactExistsSequenceFlowExpressionExecute() {
			bool result = Convert.ToBoolean((ContactId) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ChangeAccountScriptTask", "QualifiedContactExistsSequenceFlow", "(ContactId) != Guid.Empty", result);
			return result;
		}

		private bool QualifiedAccountExistsSequenceFlowExpressionExecute() {
			bool result = Convert.ToBoolean((AccountId) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayQualifiedAccount", "QualifiedAccountExistsSequenceFlow", "(AccountId) != Guid.Empty", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("LeadId")) {
				writer.WriteValue("LeadId", LeadId, Guid.Empty);
			}
			if (!HasMapping("AccountId")) {
				writer.WriteValue("AccountId", AccountId, Guid.Empty);
			}
			if (!HasMapping("ContactId")) {
				writer.WriteValue("ContactId", ContactId, Guid.Empty);
			}
			if (!HasMapping("LeadAddressType")) {
				writer.WriteValue("LeadAddressType", LeadAddressType, Guid.Empty);
			}
			if (!HasMapping("LeadCity")) {
				writer.WriteValue("LeadCity", LeadCity, Guid.Empty);
			}
			if (!HasMapping("LeadZip")) {
				writer.WriteValue("LeadZip", LeadZip, null);
			}
			if (!HasMapping("LeadRegion")) {
				writer.WriteValue("LeadRegion", LeadRegion, Guid.Empty);
			}
			if (!HasMapping("LeadCountry")) {
				writer.WriteValue("LeadCountry", LeadCountry, Guid.Empty);
			}
			if (!HasMapping("LeadWebsite")) {
				writer.WriteValue("LeadWebsite", LeadWebsite, null);
			}
			if (!HasMapping("LeadFax")) {
				writer.WriteValue("LeadFax", LeadFax, null);
			}
			if (!HasMapping("LeadBusinessPhone")) {
				writer.WriteValue("LeadBusinessPhone", LeadBusinessPhone, null);
			}
			if (!HasMapping("LeadEmail")) {
				writer.WriteValue("LeadEmail", LeadEmail, null);
			}
			if (!HasMapping("LeadMobilePhone")) {
				writer.WriteValue("LeadMobilePhone", LeadMobilePhone, null);
			}
			if (!HasMapping("LeadDecisionRole")) {
				writer.WriteValue("LeadDecisionRole", LeadDecisionRole, Guid.Empty);
			}
			if (!HasMapping("LeadGender")) {
				writer.WriteValue("LeadGender", LeadGender, Guid.Empty);
			}
			if (!HasMapping("LeadDepartment")) {
				writer.WriteValue("LeadDepartment", LeadDepartment, Guid.Empty);
			}
			if (!HasMapping("LeadJob")) {
				writer.WriteValue("LeadJob", LeadJob, Guid.Empty);
			}
			if (!HasMapping("LeadSalutation")) {
				writer.WriteValue("LeadSalutation", LeadSalutation, Guid.Empty);
			}
			if (!HasMapping("LeadDear")) {
				writer.WriteValue("LeadDear", LeadDear, null);
			}
			if (!HasMapping("LeadFullJobTitle")) {
				writer.WriteValue("LeadFullJobTitle", LeadFullJobTitle, null);
			}
			if (!HasMapping("LeadContactName")) {
				writer.WriteValue("LeadContactName", LeadContactName, null);
			}
			if (!HasMapping("LeadAccountName")) {
				writer.WriteValue("LeadAccountName", LeadAccountName, null);
			}
			if (!HasMapping("LeadAnnualRevenue")) {
				writer.WriteValue("LeadAnnualRevenue", LeadAnnualRevenue, Guid.Empty);
			}
			if (!HasMapping("LeadEmployeesNumber")) {
				writer.WriteValue("LeadEmployeesNumber", LeadEmployeesNumber, Guid.Empty);
			}
			if (!HasMapping("LeadAccountCategory")) {
				writer.WriteValue("LeadAccountCategory", LeadAccountCategory, Guid.Empty);
			}
			if (!HasMapping("LeadIndustry")) {
				writer.WriteValue("LeadIndustry", LeadIndustry, Guid.Empty);
			}
			if (!HasMapping("LeadOwnership")) {
				writer.WriteValue("LeadOwnership", LeadOwnership, Guid.Empty);
			}
			if (!HasMapping("LeadAccountId")) {
				writer.WriteValue("LeadAccountId", LeadAccountId, Guid.Empty);
			}
			if (!HasMapping("LeadContactId")) {
				writer.WriteValue("LeadContactId", LeadContactId, Guid.Empty);
			}
			if (!HasMapping("LeadAddress")) {
				writer.WriteValue("LeadAddress", LeadAddress, null);
			}
			if (!HasMapping("CreateAccountOnQualification")) {
				writer.WriteValue("CreateAccountOnQualification", CreateAccountOnQualification, false);
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
			MetaPathParameterValues.Add("7da3d394-c5b2-4fba-be47-747a00d3685e", () => LeadId);
			MetaPathParameterValues.Add("adff468f-5785-4238-a962-2d46a6df9207", () => AccountId);
			MetaPathParameterValues.Add("21f03e5d-1b78-48dc-9e30-1c86f9161488", () => ContactId);
			MetaPathParameterValues.Add("2365f649-230d-4d6e-b38b-15932b94c2d9", () => LeadAddressType);
			MetaPathParameterValues.Add("a00b4828-9039-473d-9786-1042a8a4d495", () => LeadCity);
			MetaPathParameterValues.Add("b9c2234b-9f29-4b4b-bff9-43ed0aee7fd4", () => LeadZip);
			MetaPathParameterValues.Add("b120b526-724c-470e-9bde-cca7c5bce38b", () => LeadRegion);
			MetaPathParameterValues.Add("7f25c2c6-3a0b-430a-b8f4-14dac4a33300", () => LeadCountry);
			MetaPathParameterValues.Add("7573b5d0-d90d-43fb-a4ff-b434212f304d", () => LeadWebsite);
			MetaPathParameterValues.Add("ef248d37-29b4-41f3-ae05-29aa2ca78c1e", () => LeadFax);
			MetaPathParameterValues.Add("237e51db-51d4-40d3-ba2e-657d419fe693", () => LeadBusinessPhone);
			MetaPathParameterValues.Add("6547686a-48b1-457a-810e-01431f20fcf7", () => LeadEmail);
			MetaPathParameterValues.Add("f609b031-6cfd-4dbc-9110-5a3c4aaf1d59", () => LeadMobilePhone);
			MetaPathParameterValues.Add("7d3339ff-d4dd-47f4-aad0-f962a3c06682", () => LeadDecisionRole);
			MetaPathParameterValues.Add("26e960a5-407f-49ef-9aeb-194c10c5c07a", () => LeadGender);
			MetaPathParameterValues.Add("8ad4103a-0d1e-4f62-a22a-707a1d45a404", () => LeadDepartment);
			MetaPathParameterValues.Add("a0f4b101-277c-452d-94c8-b44202a3a196", () => LeadJob);
			MetaPathParameterValues.Add("f34298ea-de28-49a3-a7dd-0537e9d81810", () => LeadSalutation);
			MetaPathParameterValues.Add("61ebe384-47c3-41a5-8f7a-689cc754debd", () => LeadDear);
			MetaPathParameterValues.Add("69d73113-cfb5-46b5-bad8-db01b0089ad7", () => LeadFullJobTitle);
			MetaPathParameterValues.Add("9ccf4757-79ad-4fda-8a8d-091f07d873c6", () => LeadContactName);
			MetaPathParameterValues.Add("d7cbdc44-a5b7-48dc-bbaf-a96bd83d7066", () => LeadAccountName);
			MetaPathParameterValues.Add("485ac59c-8ec0-45f6-b314-99549ce9eedf", () => LeadAnnualRevenue);
			MetaPathParameterValues.Add("81219640-87de-43de-9f88-0867fbbd7c43", () => LeadEmployeesNumber);
			MetaPathParameterValues.Add("347c7337-e229-470b-a321-5aa2e5a4d102", () => LeadAccountCategory);
			MetaPathParameterValues.Add("7ab43aa0-0265-44da-baf7-13ae2e552bfe", () => LeadIndustry);
			MetaPathParameterValues.Add("5b328e21-1e24-46e8-a579-71076a3c942a", () => LeadOwnership);
			MetaPathParameterValues.Add("ae489f7c-9167-44af-a723-c61c0541a93a", () => LeadAccountId);
			MetaPathParameterValues.Add("f302fbc3-0ce9-4626-9957-2cf93197d6fd", () => LeadContactId);
			MetaPathParameterValues.Add("c945f2af-1eae-4ba3-a433-a8ea8b69d8b1", () => LeadAddress);
			MetaPathParameterValues.Add("70ebb313-bd3c-472f-bf4f-f07a23506a9c", () => CreateAccountOnQualification);
			MetaPathParameterValues.Add("eb174310-4f6b-4191-b705-5ac74e8d6810", () => ReadLeadData.DataSourceFilters);
			MetaPathParameterValues.Add("2c5fddb8-7f3b-431c-a140-15c790c47997", () => ReadLeadData.ResultType);
			MetaPathParameterValues.Add("c9715250-2f51-47c6-ae51-692c6ef09e35", () => ReadLeadData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("7aa6f27f-9136-4c8a-95c8-d11d8c5dd57c", () => ReadLeadData.NumberOfRecords);
			MetaPathParameterValues.Add("105c3fa8-1208-4d19-bf97-40057718c52f", () => ReadLeadData.FunctionType);
			MetaPathParameterValues.Add("001d410e-1ab8-4cd6-bb61-83ee17b39a5b", () => ReadLeadData.AggregationColumnName);
			MetaPathParameterValues.Add("a1588d18-597e-4d60-95bc-bd4c78338608", () => ReadLeadData.OrderInfo);
			MetaPathParameterValues.Add("724a8768-9516-4d2c-aa88-41a1bb2d5e37", () => ReadLeadData.ResultEntity);
			MetaPathParameterValues.Add("1eb2f334-3b2d-4e66-96ae-e2c0468ec136", () => ReadLeadData.ResultCount);
			MetaPathParameterValues.Add("02e6f3dc-c3b7-48c5-b1bb-858d7d4b6706", () => ReadLeadData.ResultIntegerFunction);
			MetaPathParameterValues.Add("552d4238-195d-4289-9c82-72b9a2a6cc13", () => ReadLeadData.ResultFloatFunction);
			MetaPathParameterValues.Add("2ee6855b-3c07-41fe-9ed9-dce8afc87598", () => ReadLeadData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("d8c1e15f-029b-46de-8fb1-c9ab4e292106", () => ReadLeadData.ResultRowsCount);
			MetaPathParameterValues.Add("30fc9f29-8bc3-4e4c-8238-8d93757cf810", () => ReadLeadData.CanReadUncommitedData);
			MetaPathParameterValues.Add("2ab23a86-7cff-4fa0-b600-4001d8b72aca", () => ReadLeadData.ResultEntityCollection);
			MetaPathParameterValues.Add("fd8b3b5a-0afb-4d72-b51c-4907de28ec37", () => ReadLeadData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("6d962028-129a-453e-8ba9-f69a2f78e60c", () => ReadLeadData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("dc91c698-f36e-4d9e-a27e-2af4201959fd", () => ReadLeadData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("214e4e0f-5eaf-4d51-bf9c-17715613f73d", () => ReadLeadData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("ea29a1a7-83b3-4850-9134-d716cf498910", () => ChangeContactAccount.EntitySchemaUId);
			MetaPathParameterValues.Add("2a3f5cb3-7035-42b2-9882-c80f7985168f", () => ChangeContactAccount.IsMatchConditions);
			MetaPathParameterValues.Add("0d8e007f-f368-46a3-840e-c8c133b97854", () => ChangeContactAccount.DataSourceFilters);
			MetaPathParameterValues.Add("c0fe375b-e8e3-406d-b4a8-8783f94f8903", () => ChangeContactAccount.RecordColumnValues);
			MetaPathParameterValues.Add("321d44b2-f7f8-4aae-8f55-74e37a4f7da5", () => ChangeContactAccount.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("9e34dc39-7d39-421f-8d27-92a8af9a80c6", () => ChangeLeadStageDistribution.EntitySchemaUId);
			MetaPathParameterValues.Add("bcf5b8fe-4737-4d4e-a037-b2c70a7900e8", () => ChangeLeadStageDistribution.IsMatchConditions);
			MetaPathParameterValues.Add("bb68e8f2-44a8-4731-b948-176e754a5d8b", () => ChangeLeadStageDistribution.DataSourceFilters);
			MetaPathParameterValues.Add("f994ffb6-8edf-41e3-892d-aa56db1c821b", () => ChangeLeadStageDistribution.RecordColumnValues);
			MetaPathParameterValues.Add("c7362a45-71b1-4fb8-a1e4-17017c3aba0e", () => ChangeLeadStageDistribution.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6dd0bc3f-edfa-4078-87d0-79fe8307a8ab", () => LinkContactToLead.EntitySchemaUId);
			MetaPathParameterValues.Add("55ac08c6-ba80-4060-81f6-fb82943a2aa6", () => LinkContactToLead.IsMatchConditions);
			MetaPathParameterValues.Add("34908b60-ff49-4067-a7d9-fecfeba3d015", () => LinkContactToLead.DataSourceFilters);
			MetaPathParameterValues.Add("ee931748-590a-41b4-8229-e4dc1c8b23af", () => LinkContactToLead.RecordColumnValues);
			MetaPathParameterValues.Add("3204a423-4821-4b15-91b5-96120c20f596", () => LinkContactToLead.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("7b3e0e2a-6d32-492c-9290-46e7c194da0b", () => LinkAccountToLead.EntitySchemaUId);
			MetaPathParameterValues.Add("fbd3778b-b29e-4da4-878c-479ce66f6695", () => LinkAccountToLead.IsMatchConditions);
			MetaPathParameterValues.Add("e2572aab-9833-4451-bac3-3c93b4938008", () => LinkAccountToLead.DataSourceFilters);
			MetaPathParameterValues.Add("2c5dda1b-35c1-410a-8a66-b8e7dbef353d", () => LinkAccountToLead.RecordColumnValues);
			MetaPathParameterValues.Add("9bc7cdf4-c634-485f-a341-909e45a7cc26", () => LinkAccountToLead.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("5b47b7b3-1c3a-4e76-8b27-d2d1429d61ee", () => ReadSystemSettings.DataSourceFilters);
			MetaPathParameterValues.Add("055337fb-4c12-4162-baa0-f0a6f82b04f1", () => ReadSystemSettings.ResultType);
			MetaPathParameterValues.Add("61008822-6246-4cb7-94b5-d7ab2c0e761f", () => ReadSystemSettings.ReadSomeTopRecords);
			MetaPathParameterValues.Add("a18bad05-72bd-47e8-8a76-9adc5adb727a", () => ReadSystemSettings.NumberOfRecords);
			MetaPathParameterValues.Add("05ce4b0d-7adf-4370-a4da-9a578ae526a6", () => ReadSystemSettings.FunctionType);
			MetaPathParameterValues.Add("b54c1807-d3db-417d-acc8-5ec641e8f114", () => ReadSystemSettings.AggregationColumnName);
			MetaPathParameterValues.Add("eb5b205e-4427-45cf-8b2f-e5c11ffb5d04", () => ReadSystemSettings.OrderInfo);
			MetaPathParameterValues.Add("411b2f2b-abb2-49c4-b63c-c589bc81bb8c", () => ReadSystemSettings.ResultEntity);
			MetaPathParameterValues.Add("0107e886-cf9e-458c-9fa5-10337b71312c", () => ReadSystemSettings.ResultCount);
			MetaPathParameterValues.Add("c92f52ed-8123-486d-ae9b-c9c0f3e785cf", () => ReadSystemSettings.ResultIntegerFunction);
			MetaPathParameterValues.Add("6c8845de-fd11-481f-ba54-02935c4aeb9d", () => ReadSystemSettings.ResultFloatFunction);
			MetaPathParameterValues.Add("63c46681-2887-41fe-8ea5-3cd9bd9e60fe", () => ReadSystemSettings.ResultDateTimeFunction);
			MetaPathParameterValues.Add("f0232a3c-912e-48ab-9927-5fc33677f7ba", () => ReadSystemSettings.ResultRowsCount);
			MetaPathParameterValues.Add("06e3ef5a-2fa6-49b7-bfa6-3a114e683d05", () => ReadSystemSettings.CanReadUncommitedData);
			MetaPathParameterValues.Add("0a40e220-4683-47e0-a0c2-892934668fc3", () => ReadSystemSettings.ResultEntityCollection);
			MetaPathParameterValues.Add("44d1abb0-802b-49e6-9571-d667de498b3e", () => ReadSystemSettings.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("11fe36aa-20e3-41b3-99f4-0a35fd3628cc", () => ReadSystemSettings.IgnoreDisplayValues);
			MetaPathParameterValues.Add("63184008-db16-4d16-8b86-316b860a485d", () => ReadSystemSettings.ResultCompositeObjectList);
			MetaPathParameterValues.Add("db44c7f2-37f4-4a89-9abc-c1530f1150c9", () => ReadSystemSettings.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "LeadId":
					if (!hasValueToRead) break;
					LeadId = reader.GetValue<System.Guid>();
				break;
				case "AccountId":
					if (!hasValueToRead) break;
					AccountId = reader.GetValue<System.Guid>();
				break;
				case "ContactId":
					if (!hasValueToRead) break;
					ContactId = reader.GetValue<System.Guid>();
				break;
				case "LeadAddressType":
					if (!hasValueToRead) break;
					LeadAddressType = reader.GetValue<System.Guid>();
				break;
				case "LeadCity":
					if (!hasValueToRead) break;
					LeadCity = reader.GetValue<System.Guid>();
				break;
				case "LeadZip":
					if (!hasValueToRead) break;
					LeadZip = reader.GetValue<System.String>();
				break;
				case "LeadRegion":
					if (!hasValueToRead) break;
					LeadRegion = reader.GetValue<System.Guid>();
				break;
				case "LeadCountry":
					if (!hasValueToRead) break;
					LeadCountry = reader.GetValue<System.Guid>();
				break;
				case "LeadWebsite":
					if (!hasValueToRead) break;
					LeadWebsite = reader.GetValue<System.String>();
				break;
				case "LeadFax":
					if (!hasValueToRead) break;
					LeadFax = reader.GetValue<System.String>();
				break;
				case "LeadBusinessPhone":
					if (!hasValueToRead) break;
					LeadBusinessPhone = reader.GetValue<System.String>();
				break;
				case "LeadEmail":
					if (!hasValueToRead) break;
					LeadEmail = reader.GetValue<System.String>();
				break;
				case "LeadMobilePhone":
					if (!hasValueToRead) break;
					LeadMobilePhone = reader.GetValue<System.String>();
				break;
				case "LeadDecisionRole":
					if (!hasValueToRead) break;
					LeadDecisionRole = reader.GetValue<System.Guid>();
				break;
				case "LeadGender":
					if (!hasValueToRead) break;
					LeadGender = reader.GetValue<System.Guid>();
				break;
				case "LeadDepartment":
					if (!hasValueToRead) break;
					LeadDepartment = reader.GetValue<System.Guid>();
				break;
				case "LeadJob":
					if (!hasValueToRead) break;
					LeadJob = reader.GetValue<System.Guid>();
				break;
				case "LeadSalutation":
					if (!hasValueToRead) break;
					LeadSalutation = reader.GetValue<System.Guid>();
				break;
				case "LeadDear":
					if (!hasValueToRead) break;
					LeadDear = reader.GetValue<System.String>();
				break;
				case "LeadFullJobTitle":
					if (!hasValueToRead) break;
					LeadFullJobTitle = reader.GetValue<System.String>();
				break;
				case "LeadContactName":
					if (!hasValueToRead) break;
					LeadContactName = reader.GetValue<System.String>();
				break;
				case "LeadAccountName":
					if (!hasValueToRead) break;
					LeadAccountName = reader.GetValue<System.String>();
				break;
				case "LeadAnnualRevenue":
					if (!hasValueToRead) break;
					LeadAnnualRevenue = reader.GetValue<System.Guid>();
				break;
				case "LeadEmployeesNumber":
					if (!hasValueToRead) break;
					LeadEmployeesNumber = reader.GetValue<System.Guid>();
				break;
				case "LeadAccountCategory":
					if (!hasValueToRead) break;
					LeadAccountCategory = reader.GetValue<System.Guid>();
				break;
				case "LeadIndustry":
					if (!hasValueToRead) break;
					LeadIndustry = reader.GetValue<System.Guid>();
				break;
				case "LeadOwnership":
					if (!hasValueToRead) break;
					LeadOwnership = reader.GetValue<System.Guid>();
				break;
				case "LeadAccountId":
					if (!hasValueToRead) break;
					LeadAccountId = reader.GetValue<System.Guid>();
				break;
				case "LeadContactId":
					if (!hasValueToRead) break;
					LeadContactId = reader.GetValue<System.Guid>();
				break;
				case "LeadAddress":
					if (!hasValueToRead) break;
					LeadAddress = reader.GetValue<System.String>();
				break;
				case "CreateAccountOnQualification":
					if (!hasValueToRead) break;
					CreateAccountOnQualification = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ChangeAccountScriptTaskExecute(ProcessExecutingContext context) {
			ProcessAccount();
			return true;
		}

		public virtual bool ChangeContactScriptTaskExecute(ProcessExecutingContext context) {
			ProcessContact();
			return true;
		}

		public virtual void ProcessAccount() {
			Guid accountId = LeadAccountId;
			bool createAccount = CreateAccountOnQualification;
			var account = new BPMSoft.Configuration.Account(UserConnection);
			bool accountExists = false;
			if (accountId.IsEmpty()) {
				accountId = Guid.NewGuid();
			} else {
				accountExists = account.FetchFromDB(accountId);
			}
			if (!accountExists) {
				if (createAccount) {
					LeadAccountId = accountId;
					account.Id = accountId;
					account.SetDefColumnValues();
				} else {
					return;
				}
			}
			if (!string.IsNullOrEmpty(LeadAccountName)) {
				account.Name = LeadAccountName;
			}
			if (string.IsNullOrEmpty(account.Name)) {
				return;
			}
			SetValue(account, "OwnershipId", LeadOwnership);
			SetValue(account, "IndustryId", LeadIndustry);
			SetValue(account, "AccountCategoryId", LeadAccountCategory);
			SetValue(account, "EmployeesNumberId", LeadEmployeesNumber);
			SetValue(account, "AnnualRevenueId", LeadAnnualRevenue);
			account.Save();
			SyncAccountCommunications(account.Id);
			AccountId = accountId;
			AddAccountAddress(accountId);
		}

		public virtual void SetValue(Entity entity, string valueName, Object value) {
			if (Guid.Empty.Equals(value)) {
				value = null;
			}
			entity.SetColumnValue(valueName, value);
		}

		public virtual void ProcessContact() {
			Guid contactId = LeadContactId;
			var contact = new BPMSoft.Configuration.Contact(UserConnection);
			string contactName = LeadContactName;
			if (contactId.IsEmpty()) {
				if (!string.IsNullOrEmpty(contactName)) {
					contactId = Guid.NewGuid();
					contact.SetDefColumnValues();
					contact.Id = contactId;
				} else {
					return;
				}
			} else if (!contact.FetchFromDB(contactId)) {
				return;
			}
			if (!string.IsNullOrEmpty(contactName)) {
				contact.Name = contactName;
			}
			ContactId = contactId;
			SetValue(contact, "Dear", LeadDear);
			SetValue(contact, "JobTitle", LeadFullJobTitle);
			SetValue(contact, "SalutationTypeId", LeadSalutation);
			SetValue(contact, "JobId", LeadJob);
			SetValue(contact, "DepartmentId", LeadDepartment);
			SetValue(contact, "GenderId", LeadGender);
			SetValue(contact, "DecisionRoleId", LeadDecisionRole);
			contact.Confirmed = true;
			contact.Save();
			SyncContactCommunications(contact.Id);
			AddContacAddress(contact.Id);
		}

		public virtual void SyncContactCommunications(Guid contactId) {
			Dictionary<Guid, string> leadCommunications = new Dictionary<Guid, string>();
			if (!string.IsNullOrEmpty(LeadBusinessPhone)) {
				leadCommunications[new Guid(CommunicationTypeConsts.WorkPhoneId)] = LeadBusinessPhone;
			}
			if (!string.IsNullOrEmpty(LeadMobilePhone)) {
				leadCommunications[new Guid(CommunicationTypeConsts.MobilePhoneId)] = LeadMobilePhone;
			}
			if (!string.IsNullOrEmpty(LeadEmail)) {
				leadCommunications[new Guid(CommunicationTypeConsts.EmailId)] = LeadEmail;
			}
			Select existingNumbers = new Select(UserConnection)
				.Column("Number")
				.From("ContactCommunication")
				.Where("ContactId").IsEqual(Column.Parameter(contactId)) as Select;
			List<string> contactCommuniations = new List<string>();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = existingNumbers.ExecuteReader(dbExecutor)){
					while (reader.Read()) {
						contactCommuniations.Add(reader.GetString(0).ToLower());
					}
				}
			}
			List<KeyValuePair<Guid, string>> communicationsToSync = 
				leadCommunications.Where(n => !contactCommuniations.Contains(n.Value.ToLower())).ToList();
			foreach (KeyValuePair<Guid, string> communication in communicationsToSync) {
				var contactCommunication = new ContactCommunication(UserConnection);
				contactCommunication.SetDefColumnValues();
				contactCommunication.Number = communication.Value;
				contactCommunication.CommunicationTypeId = communication.Key;
				contactCommunication.ContactId = contactId;
				contactCommunication.Save();
			}
		}

		public virtual void SyncAccountCommunications(Guid accountId) {
			Dictionary<Guid, string> leadCommunications = new Dictionary<Guid, string>();
			if (!string.IsNullOrEmpty(LeadBusinessPhone)) {
				leadCommunications[new Guid(CommunicationTypeConsts.MainPhoneId)] = LeadBusinessPhone;
			}
			if (!string.IsNullOrEmpty(LeadFax)) {
				leadCommunications[new Guid(CommunicationTypeConsts.FaxId)] = LeadFax;
			}
			if (!string.IsNullOrEmpty(LeadWebsite)) {
				leadCommunications[new Guid(CommunicationTypeConsts.WebId)] = LeadWebsite;
			}
			Select existingNumbers = new Select(UserConnection)
				.Column("Number")
				.From("AccountCommunication")
				.Where("AccountId").IsEqual(Column.Parameter(accountId)) as Select;
			List<string> contactCommuniations = new List<string>();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = existingNumbers.ExecuteReader(dbExecutor)){
					while (reader.Read()) {
						contactCommuniations.Add(reader.GetString(0).ToLower());
					}
				}
			}
			List<KeyValuePair<Guid, string>> communicationsToSync = 
				leadCommunications.Where(n => !contactCommuniations.Contains(n.Value.ToLower())).ToList();
			foreach (KeyValuePair<Guid, string> communication in communicationsToSync) {
				var accountCommunication = new AccountCommunication(UserConnection);
				accountCommunication.SetDefColumnValues();
				accountCommunication.Number = communication.Value;
				accountCommunication.CommunicationTypeId = communication.Key;
				accountCommunication.AccountId = accountId;
				accountCommunication.Save();
			}
		}

		public virtual void AddContacAddress(Guid contactId) {
			if (LeadAddressType.IsEmpty() && 
					LeadCity.IsEmpty() && 
					LeadRegion.IsEmpty() && 
					LeadCountry.IsEmpty() && 
					String.IsNullOrEmpty(LeadZip) && 
					String.IsNullOrEmpty(LeadAddress)) {
				return;
			}
			//Check is address already exists
			if (IsAddressExists(
					"ContactAddress", 
					"ContactId", 
					contactId, 
					LeadAddressType, 
					LeadCity, 
					LeadRegion, 
					LeadCountry, 
					LeadZip, 
					LeadAddress)) {
				return;
			}
			//Create contact address from Lead
			var contactAddress = new ContactAddress(UserConnection);
			contactAddress.SetDefColumnValues();
			SetValue(contactAddress, "AddressTypeId", LeadAddressType);
			SetValue(contactAddress, "CityId", LeadCity);
			SetValue(contactAddress, "RegionId", LeadRegion);
			SetValue(contactAddress, "CountryId", LeadCountry);
			SetValue(contactAddress, "Zip", LeadZip);
			SetValue(contactAddress, "Address", LeadAddress);
			contactAddress.ContactId = contactId;
			contactAddress.Save();
		}

		public virtual void AddAccountAddress(Guid accountId) {
			if (LeadAddressType.IsEmpty() && 
					LeadCity.IsEmpty() && 
					LeadRegion.IsEmpty() && 
					LeadCountry.IsEmpty() && 
					String.IsNullOrEmpty(LeadZip) && 
					String.IsNullOrEmpty(LeadAddress)) {
				return;
			}
			//Check is address already exists
			if (IsAddressExists(
					"AccountAddress", 
					"AccountId", 
					accountId, 
					LeadAddressType, 
					LeadCity, 
					LeadRegion, 
					LeadCountry, 
					LeadZip, 
					LeadAddress)) {
				return;
			}
			//Create account address from Lead
			var accountAddress = new AccountAddress(UserConnection);
			accountAddress.SetDefColumnValues();
			SetValue(accountAddress, "AddressTypeId", LeadAddressType);
			SetValue(accountAddress, "CityId", LeadCity);
			SetValue(accountAddress, "RegionId", LeadRegion);
			SetValue(accountAddress, "CountryId", LeadCountry);
			SetValue(accountAddress, "Zip", LeadZip);
			SetValue(accountAddress, "Address", LeadAddress);
			accountAddress.AccountId = accountId;
			accountAddress.Save();
		}

		public virtual bool IsAddressExists(string addressTableName, string relationColumnName, Guid relationColumnValue, Guid addressType, Guid addressCity, Guid addressRegion, Guid addressCountry, string zipValue, string addressValue) {
			var addressSelect = new Select(UserConnection)
				.Column("Zip")
				.Column("Address")
				.From(addressTableName)
				.Where(relationColumnName).IsEqual(Column.Parameter(relationColumnValue)) as Select;
			
			if (!addressType.IsEmpty()) {
				addressSelect.And("AddressTypeId").IsEqual(Column.Parameter(addressType));
			}
			if (!addressCity.IsEmpty()) {
				addressSelect.And("CityId").IsEqual(Column.Parameter(addressCity));
			}
			if (!addressRegion.IsEmpty()) {
				addressSelect.And("RegionId").IsEqual(Column.Parameter(addressRegion));
			}
			if (!addressCountry.IsEmpty()) {
				addressSelect.And("CountryId").IsEqual(Column.Parameter(addressCountry));
			}
			bool compareZip = false;
			if (!String.IsNullOrEmpty(zipValue)) {
				zipValue = zipValue.ToLower().Trim();
				if (!String.IsNullOrEmpty(zipValue)) {
					compareZip = true;
				}
			}
			bool compareAddress = false;
			if (!String.IsNullOrEmpty(addressValue)) {
				addressValue = addressValue.ToLower().Trim();
				if (!String.IsNullOrEmpty(addressValue)) {
					compareAddress = true;
				}
			}
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = addressSelect.ExecuteReader(dbExecutor)) {
					//Test each address.
					while (reader.Read()) {
						string zip = reader.GetString(0).ToLower().Trim();
						string address = reader.GetString(1).ToLower().Trim();
						bool zipMatch = false;
						bool addressMatch = false;
						//Quit when address is math
						if (compareZip && StringUtilities.EqualsIgnoreCase(zip, zipValue)) {
							zipMatch = true;
						}
						zipMatch = zipMatch == compareZip;
						if (compareAddress && StringUtilities.EqualsIgnoreCase(address, addressValue)) {
							addressMatch = true;
						}
						addressMatch = addressMatch == compareAddress;
						if (zipMatch && addressMatch) {
							return true;
						}
					}
				}
			}
			return false;
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
			var cloneItem = (LeadManagementQualification)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

