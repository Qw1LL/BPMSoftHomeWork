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

	#region Class: LeadManagementQualification10Schema

	/// <exclude/>
	public class LeadManagementQualification10Schema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LeadManagementQualification10Schema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LeadManagementQualification10Schema(LeadManagementQualification10Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LeadManagementQualification10";
			UId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a");
			CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = false;
			Tag = @"LeadManagementQualification10";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,90,221,111,219,54,16,127,78,129,254,15,108,30,10,25,48,148,237,185,77,129,196,118,10,111,77,147,38,233,10,108,216,131,44,211,54,87,89,202,40,41,137,183,246,127,223,145,60,82,164,68,74,14,178,13,27,80,244,161,230,241,190,121,247,227,135,242,252,217,109,189,200,88,74,238,24,175,234,36,35,119,5,91,146,75,94,164,180,44,79,210,180,168,243,42,26,145,63,159,63,59,120,91,195,76,162,72,243,37,57,38,239,104,178,68,150,249,242,21,112,44,138,34,35,41,167,73,69,145,14,92,19,123,124,145,127,0,35,108,197,210,164,98,69,46,132,238,18,174,181,2,119,78,239,201,233,229,249,117,177,170,226,73,145,175,216,186,230,146,53,214,206,124,44,41,135,153,156,166,130,60,50,118,81,199,236,129,149,85,9,154,86,73,86,82,49,203,86,36,50,110,199,243,114,182,189,173,118,209,72,5,117,96,7,36,34,140,223,211,123,241,127,36,53,127,37,20,180,56,156,198,0,142,227,51,90,165,155,51,94,108,167,167,141,29,37,141,214,95,56,162,104,88,76,56,185,66,250,129,147,214,198,142,74,177,113,35,238,155,187,166,213,148,174,38,69,86,111,243,159,146,172,166,165,10,199,137,231,128,211,170,230,114,13,164,167,198,219,178,226,44,95,67,166,222,215,89,118,193,85,190,44,175,222,39,91,218,74,95,44,104,110,73,8,138,157,4,175,86,91,92,171,108,220,18,162,16,138,140,64,179,142,201,225,197,125,78,121,185,97,183,243,229,225,88,154,52,20,25,101,72,196,101,15,177,206,243,101,13,190,238,12,183,38,132,4,48,222,9,172,228,186,176,228,90,244,144,56,36,34,43,118,148,66,94,182,11,203,201,22,61,104,61,207,161,163,174,232,29,205,107,218,216,182,169,82,84,103,26,218,231,100,185,101,249,21,91,111,220,62,49,197,147,220,209,72,82,149,205,93,158,234,80,138,237,182,206,177,119,75,179,120,88,237,193,154,61,89,234,92,192,47,14,184,226,182,9,172,178,248,231,195,33,19,239,44,175,88,181,35,84,254,55,38,170,150,200,157,152,19,165,51,38,23,139,223,0,16,20,69,213,145,168,57,57,36,199,0,43,80,115,228,203,23,213,225,178,244,226,217,239,96,166,84,44,35,49,231,45,80,57,29,223,20,215,114,18,80,195,91,164,202,47,209,118,86,207,69,150,123,202,74,127,176,8,186,128,109,85,146,58,160,155,42,146,1,93,100,81,217,21,248,137,12,189,248,169,245,122,240,19,211,137,90,172,86,70,25,221,202,18,178,180,237,14,146,134,177,195,82,172,153,15,236,152,186,184,107,230,195,80,102,56,164,10,163,110,24,230,212,156,244,86,171,176,33,220,104,242,47,245,163,162,212,250,49,165,22,135,86,103,150,178,29,131,41,125,164,66,171,79,105,194,177,191,197,207,81,128,109,16,235,26,214,31,138,197,13,171,50,138,188,103,16,141,38,133,68,174,97,92,201,138,186,217,221,54,128,211,144,123,108,25,110,248,29,98,155,210,219,132,87,91,232,40,195,221,144,66,66,111,105,190,180,98,86,195,176,133,148,149,224,232,85,145,53,254,219,68,41,168,151,78,54,17,223,82,177,64,21,175,169,61,23,198,82,83,189,93,44,197,21,111,97,105,83,204,10,75,151,216,123,26,49,221,249,62,200,12,154,112,161,68,85,232,148,73,20,72,248,238,181,152,214,200,250,134,100,178,251,109,121,4,151,144,132,234,202,254,243,195,105,93,178,28,162,185,220,20,185,233,145,174,165,95,132,29,137,5,14,93,212,27,68,6,39,168,248,83,193,63,75,37,16,199,175,136,85,142,242,225,110,21,34,231,197,130,101,244,201,222,88,106,44,127,44,234,126,222,204,182,9,203,158,226,135,84,96,121,32,199,205,57,42,19,27,36,21,71,80,176,175,14,21,122,81,213,100,123,107,16,126,196,10,121,163,67,37,112,168,136,2,42,163,67,95,153,33,195,167,13,229,212,112,64,151,141,196,118,33,118,220,72,41,140,47,19,14,48,88,81,238,0,110,82,162,47,194,237,119,224,234,107,93,144,169,99,204,41,73,155,79,149,161,40,133,53,137,166,167,179,7,154,214,85,193,201,114,97,126,30,19,55,206,120,150,151,53,167,211,211,134,100,246,52,84,52,159,38,85,114,5,41,165,156,192,145,93,252,119,220,78,101,172,12,80,197,22,53,6,71,35,181,15,221,111,160,30,72,164,228,99,193,102,204,152,157,194,9,47,134,230,215,236,111,105,133,71,144,239,70,112,28,121,87,220,131,141,17,238,132,95,237,35,188,204,198,143,116,39,97,239,50,97,220,237,83,145,73,187,172,224,104,3,136,1,225,248,171,14,87,50,39,199,111,200,11,175,147,114,141,25,224,75,30,75,147,150,119,210,83,112,71,45,202,170,128,88,210,13,137,194,206,185,190,17,150,123,157,197,164,89,7,31,199,103,172,10,95,117,250,14,63,173,212,43,198,240,177,195,203,173,74,64,110,225,54,89,10,134,165,58,125,140,167,0,155,7,114,213,167,32,112,120,8,196,228,110,70,95,7,247,17,255,177,223,125,7,248,95,239,35,231,80,184,127,195,62,114,150,60,60,197,11,16,183,236,195,104,63,171,159,232,162,100,213,211,246,81,186,176,44,163,194,127,112,199,240,21,148,187,99,152,75,100,223,142,209,20,223,183,29,227,219,142,241,184,29,3,107,199,183,99,248,170,211,187,99,248,116,132,119,12,47,247,224,142,225,149,122,204,142,225,85,16,126,87,244,199,244,152,29,163,115,103,241,93,56,4,164,201,7,42,197,35,98,104,30,18,200,203,151,196,60,129,78,196,139,138,127,234,138,174,133,119,1,57,17,6,247,137,94,135,144,244,103,120,56,28,230,66,151,253,207,2,71,71,147,13,77,63,19,86,146,68,241,145,36,19,103,55,120,180,146,175,190,24,251,188,68,53,234,45,56,146,38,245,57,25,167,224,74,234,144,229,37,213,125,52,193,113,43,147,99,55,123,227,118,198,198,157,44,89,20,72,66,87,107,48,88,249,112,109,222,157,116,200,43,64,121,185,149,184,239,82,168,204,61,152,233,42,241,52,152,43,22,236,172,246,221,30,249,197,163,104,147,147,230,73,180,161,13,72,139,220,25,49,49,24,224,87,201,53,18,106,56,100,67,229,191,49,163,198,3,82,176,70,200,47,74,118,175,28,184,209,251,210,27,60,69,182,151,193,1,131,126,32,104,189,247,250,142,140,223,144,192,135,4,110,226,12,18,52,199,34,164,152,100,254,71,144,64,127,193,11,33,1,206,187,72,208,170,18,15,18,184,98,195,72,224,242,63,22,9,58,210,3,72,208,225,223,3,9,186,54,246,65,130,142,84,15,18,132,114,224,65,130,86,122,131,167,131,246,50,236,129,4,242,155,108,123,183,195,15,13,88,36,55,201,34,195,239,35,56,193,105,38,15,30,106,133,213,148,196,14,119,66,198,137,51,137,93,244,54,69,213,189,77,209,165,239,112,233,234,71,15,254,96,183,168,221,245,85,18,85,11,200,114,86,84,188,34,237,125,37,18,171,230,82,244,218,88,183,164,118,118,236,251,81,55,65,61,215,36,79,210,218,23,38,125,201,180,178,216,253,66,110,199,26,159,228,203,168,213,85,125,55,53,171,213,90,159,196,155,85,218,199,34,118,226,176,41,217,165,94,83,237,83,99,216,152,105,227,97,115,216,226,254,216,218,39,209,158,240,12,8,236,17,33,2,132,177,169,254,236,162,216,194,87,18,10,21,214,254,219,135,23,222,19,173,46,116,237,148,30,131,180,254,217,188,228,197,55,156,109,241,58,179,191,202,3,199,39,253,241,196,60,84,218,110,55,251,194,30,174,59,45,233,230,84,135,96,15,31,27,134,79,253,65,199,207,78,56,255,202,155,179,91,58,225,23,103,244,250,232,232,134,150,240,132,35,158,93,81,52,30,126,139,110,160,16,44,246,190,63,219,9,53,114,250,8,224,145,253,62,40,43,139,1,44,158,39,240,37,214,46,3,61,135,90,125,243,71,71,31,106,86,145,251,13,205,141,113,184,135,109,147,106,163,24,212,119,107,83,139,112,211,83,254,124,172,88,198,42,70,75,252,99,128,249,58,135,55,234,73,82,82,81,203,99,211,8,77,106,68,155,104,23,76,5,224,3,188,51,217,252,148,247,115,52,253,170,227,207,9,250,187,143,79,24,219,216,221,147,26,223,90,41,234,250,215,98,112,135,198,79,116,201,242,213,4,3,94,218,66,141,105,117,42,236,154,116,190,76,32,147,94,58,121,110,248,11,3,56,63,23,128,38,0,0 };
			RealUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a");
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadAddressType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{66852a75-b22e-4390-a8df-49814cdb0131}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadCityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a00b4828-9039-473d-9786-1042a8a4d495"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadCity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{4258b690-fe71-4b7a-8278-f0a7b9dd4780}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadZipParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b9c2234b-9f29-4b4b-bff9-43ed0aee7fd4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadZip",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadRegionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b120b526-724c-470e-9bde-cca7c5bce38b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadRegion",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{dce30e38-3b37-40b3-b9f5-08b790d93420}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadCountryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7f25c2c6-3a0b-430a-b8f4-14dac4a33300"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadCountry",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{d79b4d09-4791-4993-952b-e097088b55c6}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadWebsiteParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7573b5d0-d90d-43fb-a4ff-b434212f304d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadWebsite",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadFaxParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ef248d37-29b4-41f3-ae05-29aa2ca78c1e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadFax",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadBusinessPhoneParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("237e51db-51d4-40d3-ba2e-657d419fe693"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadBusinessPhone",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6547686a-48b1-457a-810e-01431f20fcf7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadMobilePhoneParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f609b031-6cfd-4dbc-9110-5a3c4aaf1d59"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadMobilePhone",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadDecisionRoleParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7d3339ff-d4dd-47f4-aad0-f962a3c06682"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadDecisionRole",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{4a577f44-6cf7-40d0-b1f8-81c2cf6539d1}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadGenderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("26e960a5-407f-49ef-9aeb-194c10c5c07a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadGender",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{257a1321-f45d-4868-bf44-e9f2297661d3}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadDepartmentParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8ad4103a-0d1e-4f62-a22a-707a1d45a404"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadDepartment",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{c7fb190e-51d8-4c65-a5db-c3714d3b0af7}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadJobParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a0f4b101-277c-452d-94c8-b44202a3a196"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadJob",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{aa8c19b4-a8fb-4284-b969-8f15630a25ec}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadSalutationParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f34298ea-de28-49a3-a7dd-0537e9d81810"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadSalutation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{afdaca14-10c0-4767-b1f4-ed06946d37eb}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadDearParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("61ebe384-47c3-41a5-8f7a-689cc754debd"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadDear",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadFullJobTitleParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("69d73113-cfb5-46b5-bad8-db01b0089ad7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadFullJobTitle",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadContactNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9ccf4757-79ad-4fda-8a8d-091f07d873c6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadContactName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAccountNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d7cbdc44-a5b7-48dc-bbaf-a96bd83d7066"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadAccountName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAnnualRevenueParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("485ac59c-8ec0-45f6-b314-99549ce9eedf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadAnnualRevenue",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{718683e1-7d00-48d6-ad3f-c882ee2ce79f}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadEmployeesNumberParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("81219640-87de-43de-9f88-0867fbbd7c43"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadEmployeesNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{49508aa7-fa69-4ce3-aa4d-1eeb2c9d73a5}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAccountCategoryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("347c7337-e229-470b-a321-5aa2e5a4d102"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadAccountCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{a3200694-9a9a-42a6-824f-870d5b03e255}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadIndustryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7ab43aa0-0265-44da-baf7-13ae2e552bfe"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadIndustry",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{2edaf1d4-f64e-4351-aa6b-c81a7ebfc108}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadOwnershipParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5b328e21-1e24-46e8-a579-71076a3c942a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadOwnership",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{6a7045c5-ab82-4bf9-a929-9ac065c69343}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ae489f7c-9167-44af-a723-c61c0541a93a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadAccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{32949ae4-ff13-48f5-9f5d-45a74558ea55}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f302fbc3-0ce9-4626-9957-2cf93197d6fd"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{ad490d58-054a-4d85-9246-dd8466eb3983}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c945f2af-1eae-4ba3-a433-a8ea8b69d8b1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateAccountOnQualificationParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("70ebb313-bd3c-472f-bf4f-f07a23506a9c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"CreateAccountOnQualification",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a188ff27-c185-4b79-b24c-71503e5df1a6}].[Parameter:{411b2f2b-abb2-49c4-b63c-c589bc81bb8c}].[EntityColumn:{297f4697-d071-4be2-8509-9090c07dfe18}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadQualificationPassedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9c638b0f-7b13-46c3-bef4-2010a78fb3a4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadQualificationPassed",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{d46a1b66-17a7-4603-b1ce-49313701da31}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLeadOwnerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d957170c-e768-44a5-a025-d5d08a8f9f76"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8bf25d2e-0f4c-4ed1-b885-635952f9e063}].[Parameter:{724a8768-9516-4d2c-aa88-41a1bb2d5e37}].[EntityColumn:{52817348-4c01-4015-a766-cb10c7b554c8}]#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			Parameters.Add(CreateLeadQualificationPassedParameter());
			Parameters.Add(CreateLeadOwnerParameter());
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,47,62,119,43,127,102,215,189,65,9,40,18,208,72,169,122,169,123,24,175,103,147,21,118,108,237,110,10,33,202,127,103,214,78,76,138,34,8,92,168,79,222,167,55,111,222,124,237,2,89,131,181,159,161,193,224,38,120,59,255,180,104,149,187,126,175,107,135,230,131,105,55,93,112,21,88,52,26,106,253,29,171,1,159,86,218,189,3,7,20,176,43,126,198,23,193,77,113,78,161,8,174,138,64,59,108,44,49,40,0,243,68,114,89,166,172,226,50,99,169,82,156,229,10,36,203,75,145,169,60,142,34,224,147,129,121,94,250,182,109,58,48,56,100,232,197,85,255,123,191,237,60,49,34,64,246,20,109,219,245,1,76,188,5,59,93,67,89,99,69,111,103,54,72,144,51,186,161,74,240,94,55,56,7,67,153,188,78,235,33,34,41,168,173,103,213,168,220,244,91,103,208,90,221,174,127,111,173,222,52,235,83,46,133,227,248,60,152,9,123,135,158,57,7,183,234,5,102,100,106,223,123,124,179,92,26,92,130,211,207,167,22,190,224,182,231,93,214,59,10,168,104,62,15,80,111,240,36,231,203,58,110,161,115,67,57,67,122,34,24,189,92,93,88,233,216,173,63,21,27,19,216,29,201,23,41,158,245,31,79,8,124,246,192,160,113,252,45,130,199,153,189,251,186,70,179,144,43,108,96,232,216,211,53,161,191,0,163,254,205,142,87,144,84,73,158,50,153,149,49,117,177,4,86,98,202,25,79,57,132,97,149,76,68,134,251,167,193,135,182,93,13,219,135,49,221,71,132,161,89,190,103,244,22,32,243,80,37,33,139,50,80,164,149,100,44,15,243,152,133,25,207,34,94,42,41,33,162,217,250,207,143,160,93,106,9,245,93,135,134,70,220,183,56,60,191,154,47,118,218,23,111,218,214,13,37,141,173,27,189,28,215,67,240,112,34,100,38,88,34,115,100,105,84,77,152,64,81,178,36,230,101,44,34,81,10,9,100,134,110,218,247,119,209,110,140,60,220,145,29,142,249,159,206,244,63,156,223,223,220,212,217,173,190,100,79,95,203,14,206,94,203,166,237,131,253,15,19,148,195,146,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,77,76,241,75,204,77,181,50,180,50,212,241,76,177,50,176,50,0,0,197,68,70,233,19,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				UId = new Guid("d2014bab-ec05-4880-9e20-25862680d97a"),
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
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("12c2859f-0077-4ba5-a75e-9d121e261ff2"),
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,43,133,207,85,225,15,197,177,115,91,179,108,200,97,107,134,20,189,212,61,208,50,149,8,243,23,36,185,91,22,228,191,143,178,147,44,29,130,53,219,101,245,73,122,126,124,124,164,200,173,39,74,48,230,51,84,232,77,188,219,197,167,101,35,237,205,7,85,90,212,31,117,211,181,222,181,103,80,43,40,213,15,44,6,124,86,40,251,30,44,80,192,54,251,21,159,121,147,236,156,66,230,93,103,158,178,88,25,98,80,128,140,139,176,200,83,96,126,146,199,140,11,46,25,0,23,76,230,33,207,65,8,33,147,241,192,60,47,61,109,170,22,52,14,25,122,113,217,31,239,55,173,35,6,4,136,158,162,76,83,239,193,200,89,48,179,26,242,18,11,186,91,221,33,65,86,171,138,42,193,123,85,225,2,52,101,114,58,141,131,136,36,161,52,142,85,162,180,179,239,173,70,99,84,83,255,217,90,217,85,245,41,151,194,241,120,221,155,241,123,135,142,185,0,187,238,5,230,100,106,215,123,124,183,90,105,92,129,85,207,167,22,190,226,166,231,93,214,59,10,40,232,125,30,160,236,240,36,231,203,58,166,208,218,161,156,33,61,17,180,90,173,47,172,244,216,173,215,138,13,9,108,15,228,139,20,207,250,15,99,2,159,29,48,104,28,142,153,247,56,55,119,223,106,212,75,177,198,10,134,142,61,221,16,250,27,112,212,159,108,195,64,250,17,142,10,22,228,227,132,241,164,16,44,197,200,103,129,72,98,153,6,113,192,147,100,247,52,248,80,166,45,97,243,112,76,247,165,163,85,144,10,139,43,48,87,162,169,45,8,219,51,93,15,233,127,80,196,136,81,152,51,62,226,17,227,210,15,89,226,99,200,36,31,5,99,145,164,50,241,71,244,214,238,115,79,210,172,148,128,242,174,69,77,79,222,183,220,63,63,170,47,102,220,53,67,55,141,29,74,60,182,114,122,98,231,48,49,201,40,151,92,166,100,32,8,144,113,30,1,203,253,84,178,66,142,243,0,100,202,243,136,38,102,71,107,238,90,190,108,58,45,246,171,101,134,253,254,167,205,253,15,27,249,55,107,118,118,208,47,25,221,183,50,150,243,55,52,108,59,111,247,19,128,10,160,234,70,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,115,218,48,16,253,43,140,146,35,203,72,178,101,91,62,182,185,48,19,90,26,218,92,128,195,90,90,53,204,24,155,241,71,59,41,227,255,94,217,224,0,105,110,213,193,30,173,245,222,62,189,183,62,178,251,230,245,64,44,101,159,150,139,85,233,154,217,231,178,162,217,178,42,13,213,245,236,177,52,152,239,254,96,150,211,18,43,220,83,67,213,51,230,45,213,143,187,186,153,78,174,65,108,202,238,127,13,223,88,186,62,178,121,67,251,31,115,235,153,179,40,114,81,204,13,104,105,56,132,42,51,144,113,204,64,104,76,172,160,88,73,109,61,216,148,121,187,47,22,212,224,18,155,23,150,30,217,192,230,9,148,137,12,10,78,32,68,226,9,140,32,72,80,113,80,10,99,233,156,206,172,13,89,55,101,181,121,161,61,14,77,47,96,17,101,20,68,74,64,226,72,66,40,148,134,196,90,14,152,240,192,134,81,18,88,27,244,224,243,249,11,112,125,183,158,215,95,127,23,84,173,6,222,212,97,94,211,118,230,171,239,10,111,214,164,71,180,206,121,82,7,42,78,20,132,50,72,0,117,36,65,250,86,24,89,167,37,143,187,237,221,182,239,104,119,245,33,199,215,231,127,27,127,107,189,235,110,71,118,130,245,4,141,41,219,162,57,97,14,55,41,92,163,142,155,83,148,27,150,110,62,14,243,252,62,137,191,141,243,54,201,13,155,110,216,170,108,43,211,179,5,126,243,112,37,117,104,48,28,121,183,29,163,243,149,162,205,243,115,229,1,27,28,15,142,229,210,14,183,155,23,171,49,177,129,133,159,23,124,240,24,215,73,219,255,192,22,88,224,79,170,190,248,235,95,180,191,169,252,238,45,28,137,51,169,21,143,133,131,152,80,67,72,62,71,63,176,8,90,232,204,5,113,224,103,79,14,232,39,114,84,81,97,232,86,152,84,54,54,162,159,116,75,253,224,115,1,89,200,37,112,73,156,250,217,181,209,201,235,39,170,7,183,251,127,230,172,171,183,170,99,93,183,237,254,2,9,209,235,172,163,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8304f870-e9a4-4099-a63d-64aa798ebd01"),
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

		protected virtual void InitializeChangeLeadStageHandoffToSaleParameters(IParametrizedProcessSchemaElement parametrizedElement) {
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,93,79,219,48,20,253,43,83,158,49,74,109,39,78,120,219,24,155,144,182,193,84,196,11,229,193,177,175,75,180,124,201,113,216,58,212,255,190,235,164,148,82,10,203,144,16,172,79,206,237,245,241,185,31,231,222,155,64,21,178,109,191,201,18,130,131,224,195,233,215,105,109,220,254,167,188,112,96,63,219,186,107,130,189,160,5,155,203,34,255,13,122,176,31,233,220,125,148,78,226,133,155,217,221,253,89,112,48,219,133,48,11,246,102,65,238,160,108,209,3,47,8,158,170,144,198,134,200,48,52,132,199,6,79,137,138,136,86,44,82,210,232,80,11,143,245,40,244,97,93,54,210,194,240,66,15,110,250,227,217,162,241,142,19,52,168,222,37,111,235,106,101,100,158,66,123,84,201,172,0,141,223,206,118,128,38,103,243,18,35,129,179,188,132,83,105,241,37,143,83,123,19,58,25,89,180,222,171,0,227,142,126,53,22,218,54,175,171,167,169,21,93,89,109,250,226,117,88,127,174,200,132,61,67,239,121,42,221,85,15,112,140,164,150,61,199,247,243,185,133,185,116,249,245,38,133,31,176,232,253,198,229,14,47,104,172,207,185,44,58,216,120,243,126,28,135,178,113,67,56,195,243,232,96,243,249,213,200,72,215,217,250,91,176,20,141,205,173,243,40,196,157,252,105,140,198,107,111,24,48,110,143,179,224,226,184,61,249,89,129,157,170,43,40,229,144,177,203,125,180,110,25,214,248,7,55,66,75,166,89,202,137,138,50,74,184,201,36,201,128,11,34,184,192,188,106,22,39,17,44,47,7,30,121,219,20,114,113,190,126,238,11,200,33,89,62,103,248,109,120,150,0,103,138,48,150,70,132,43,30,147,52,230,25,73,19,153,9,26,103,201,68,167,88,91,252,249,170,103,70,42,157,132,132,25,145,17,46,76,70,36,101,146,8,166,133,194,218,113,206,216,83,57,58,174,30,235,122,254,63,118,253,247,14,199,138,89,76,157,116,93,59,78,0,227,50,184,163,129,38,79,43,192,151,245,93,235,228,124,144,143,5,3,22,42,5,67,19,173,67,222,98,252,80,51,126,198,93,188,25,213,244,65,111,168,102,213,179,90,164,161,228,145,38,33,195,1,194,181,198,118,213,32,73,18,38,66,80,170,162,132,170,30,111,43,238,92,97,89,86,148,239,4,56,26,237,129,150,182,80,81,35,151,189,76,138,122,142,198,226,164,1,187,250,171,239,158,29,173,124,79,3,126,68,216,186,118,91,53,91,43,246,182,135,168,160,108,18,43,65,96,194,53,225,60,53,36,161,148,147,40,165,72,151,71,19,70,35,100,131,155,207,231,115,90,119,86,173,182,77,59,172,188,103,45,179,87,88,82,255,178,121,118,206,254,49,125,249,86,38,245,203,206,227,87,24,182,207,156,160,118,247,64,122,78,41,239,141,143,177,66,127,73,17,47,131,229,31,179,84,118,137,177,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,143,218,48,16,253,43,200,187,71,38,114,226,96,199,28,219,61,20,9,42,84,218,189,44,123,24,219,227,46,106,136,81,18,42,109,17,255,189,38,36,11,84,91,169,82,125,72,228,201,188,143,204,179,15,236,190,125,221,17,155,178,15,203,197,42,248,54,249,24,106,74,150,117,176,212,52,201,60,88,44,55,191,208,148,180,196,26,183,212,82,253,136,229,158,154,249,166,105,199,163,107,16,27,179,251,159,221,55,54,125,58,176,89,75,219,111,51,23,153,125,97,56,106,225,1,165,70,200,51,233,65,115,101,32,35,36,99,140,39,145,242,8,182,161,220,111,171,5,181,184,196,246,133,77,15,172,99,139,4,198,114,155,57,201,97,130,194,65,94,228,28,16,115,2,43,57,161,82,146,50,46,217,113,204,26,251,66,91,236,68,47,224,60,69,95,104,210,160,38,220,64,30,21,161,176,104,193,123,161,141,140,100,41,217,19,184,239,191,0,159,238,230,33,252,216,239,146,44,19,121,106,93,10,19,35,4,228,54,202,107,158,166,32,189,146,90,144,151,148,231,137,37,163,184,17,22,116,49,241,209,163,84,128,164,44,20,133,215,206,169,148,203,162,184,123,62,9,185,77,179,43,241,245,241,175,122,115,66,55,106,90,252,78,201,39,172,92,240,126,212,134,81,131,37,53,103,134,221,77,20,215,28,135,245,57,207,53,155,174,223,79,180,127,175,186,81,221,102,122,27,231,154,141,215,108,21,246,181,61,177,137,184,121,184,50,222,9,116,45,127,108,135,252,98,165,218,151,101,95,121,192,22,135,198,161,28,220,198,111,200,205,170,213,16,91,199,194,251,5,239,60,134,117,246,246,63,176,5,86,113,190,245,231,248,251,23,239,111,46,191,198,17,14,196,38,211,19,174,82,15,138,80,199,243,35,51,40,92,138,160,83,109,188,80,34,243,62,235,208,95,200,83,77,149,165,91,99,255,114,122,122,124,211,77,251,116,113,122,95,167,81,29,217,241,248,124,252,13,243,178,171,200,168,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ba4d4400-3b0e-4ac7-8f2e-29fe2a55e99e"),
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,18,127,231,182,117,217,16,96,91,3,164,232,165,238,129,146,169,68,152,29,27,146,210,45,11,242,223,71,217,137,151,14,65,155,237,178,250,100,61,60,146,143,143,228,46,144,21,88,251,21,106,12,38,193,251,249,151,69,163,220,245,71,93,57,52,159,76,179,105,131,171,192,162,209,80,233,159,88,246,248,180,212,238,3,56,160,128,93,241,59,190,8,38,197,185,12,69,112,85,4,218,97,109,137,65,1,2,101,30,38,146,51,149,98,206,34,57,66,150,197,81,234,159,16,229,89,36,70,105,216,51,207,167,190,105,234,22,12,246,21,186,228,170,251,189,219,182,158,56,34,64,118,20,109,155,245,1,12,189,4,59,93,131,168,176,164,183,51,27,36,200,25,93,83,39,120,167,107,156,131,161,74,62,79,227,33,34,41,168,172,103,85,168,220,244,71,107,208,90,221,172,95,150,86,109,234,245,41,151,194,113,120,30,196,240,78,161,103,206,193,173,186,4,51,18,181,239,52,190,91,46,13,46,193,233,167,83,9,223,112,219,241,46,243,142,2,74,154,207,61,84,27,60,169,249,188,143,27,104,93,223,78,95,158,8,70,47,87,23,118,58,184,245,90,179,99,2,219,35,249,162,140,103,245,143,19,2,159,60,208,231,56,254,22,193,195,204,222,126,95,163,89,200,21,214,208,59,246,120,77,232,31,192,144,127,178,75,75,8,203,48,143,152,140,197,152,69,74,0,19,72,46,166,81,10,156,151,97,146,197,184,127,236,117,104,219,86,176,189,31,202,125,70,232,205,242,158,209,59,79,69,158,242,56,102,185,202,21,139,202,108,204,132,82,156,137,88,73,158,73,206,37,112,154,173,255,252,8,154,165,150,80,221,182,104,104,196,157,197,252,252,106,62,219,105,223,188,105,26,215,183,52,88,55,104,57,174,7,7,53,86,97,38,88,41,147,152,214,35,29,177,44,42,99,38,202,28,121,158,36,82,100,130,196,208,77,123,127,23,205,198,200,195,29,217,254,152,255,233,76,255,195,249,253,205,77,157,221,234,75,246,244,173,236,224,236,173,108,218,62,216,255,2,250,143,101,22,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,16,253,21,143,146,163,215,131,144,16,18,199,54,23,207,196,173,91,55,185,24,31,22,105,213,120,6,131,7,112,59,169,135,127,47,198,16,219,105,110,213,1,70,143,125,111,159,246,161,35,187,111,94,247,196,18,246,105,185,88,149,190,153,125,46,43,154,45,171,210,82,93,207,30,75,139,249,246,15,102,57,45,177,194,29,53,84,61,99,126,160,250,113,91,55,211,201,53,137,77,217,253,175,254,27,75,214,71,54,111,104,247,52,119,157,114,224,200,163,143,61,56,175,12,200,64,10,208,161,150,224,44,10,197,99,19,106,23,118,100,91,230,135,93,177,160,6,151,216,188,176,228,200,122,181,78,0,157,52,129,139,52,4,145,68,144,78,71,96,66,169,192,57,45,149,162,76,24,45,88,59,101,181,125,161,29,246,77,47,100,201,209,107,67,6,226,40,200,64,82,150,129,182,104,193,123,97,50,37,181,228,100,79,228,161,254,66,92,223,173,231,245,215,223,5,85,171,94,55,241,152,215,180,153,117,232,59,224,109,52,201,49,228,62,16,20,57,224,89,172,65,106,103,193,144,8,128,91,173,188,225,138,75,173,219,205,221,230,212,209,109,235,125,142,175,207,255,54,254,118,232,166,238,183,228,38,88,79,108,89,52,104,155,51,103,127,147,194,53,235,152,158,163,76,89,146,126,28,230,240,62,155,191,141,243,54,201,148,77,83,182,42,15,149,61,169,137,110,243,112,101,181,111,208,151,188,219,142,209,117,72,113,200,243,1,121,192,6,199,194,17,46,93,127,186,121,177,26,19,235,85,130,97,193,7,143,113,157,189,253,15,109,129,5,254,164,234,75,119,252,139,247,55,151,63,186,17,142,194,89,104,162,32,230,30,98,194,238,199,37,21,130,118,28,193,112,147,121,17,139,208,251,176,103,127,39,79,21,21,150,110,141,113,149,145,80,17,7,237,41,4,201,35,211,241,93,0,168,3,225,164,210,194,57,49,240,235,126,218,167,59,51,248,58,141,170,101,109,187,105,255,2,84,197,123,94,163,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("285ce719-432c-43ec-bc47-b74c40f38ded"),
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,191,63,122,219,186,108,8,176,173,1,82,244,82,247,64,201,84,34,204,142,13,73,233,150,5,254,239,163,236,196,75,135,96,203,118,89,117,146,30,30,31,31,41,114,239,137,26,140,249,12,13,122,55,222,219,197,167,101,43,237,245,123,85,91,212,31,116,187,237,188,43,207,160,86,80,171,239,88,141,248,172,82,246,29,88,160,128,125,249,51,190,244,110,202,115,10,165,119,85,122,202,98,99,136,65,1,9,151,97,234,71,25,11,179,84,176,184,74,10,198,19,153,50,145,201,16,5,15,69,2,201,200,60,47,125,219,54,29,104,28,51,12,226,114,184,222,239,58,71,12,8,16,3,69,153,118,115,0,35,103,193,204,54,192,107,172,232,109,245,22,9,178,90,53,84,9,222,171,6,23,160,41,147,211,105,29,68,36,9,181,113,172,26,165,157,125,235,52,26,163,218,205,239,173,213,219,102,115,202,165,112,156,158,7,51,254,224,208,49,23,96,215,131,192,156,76,245,131,199,55,171,149,198,21,88,245,124,106,225,11,238,6,222,101,189,163,128,138,254,231,1,234,45,158,228,124,89,199,45,116,118,44,103,76,79,4,173,86,235,11,43,157,186,245,167,98,67,2,187,35,249,34,197,179,254,195,148,192,103,7,140,26,199,107,233,61,206,205,221,215,13,234,165,88,99,3,99,199,158,174,9,253,5,152,244,111,246,89,5,81,21,21,49,19,9,15,89,44,57,48,142,113,198,178,56,3,223,175,162,52,79,176,127,26,125,40,211,213,176,123,152,210,125,68,24,155,229,122,70,239,128,34,100,142,130,249,60,40,88,156,103,25,203,179,48,102,73,44,162,40,71,8,11,55,112,189,59,238,11,218,149,18,80,223,117,168,233,139,135,22,251,231,71,243,197,76,187,226,117,219,218,177,164,169,117,147,151,227,120,248,65,94,113,224,146,133,69,80,177,24,115,206,184,204,5,43,82,25,7,228,147,115,73,145,61,237,180,235,239,178,221,106,113,216,35,51,46,243,63,173,233,127,88,191,191,217,169,179,83,125,201,156,190,150,25,156,191,150,73,235,189,254,7,189,141,72,168,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,115,218,48,16,253,43,140,146,35,98,44,89,178,37,31,219,92,152,9,45,13,109,46,192,97,37,173,26,102,140,205,248,163,157,148,241,127,175,176,113,128,52,183,234,96,143,214,251,222,190,221,183,62,146,251,230,245,128,36,35,159,150,139,85,233,155,217,231,178,194,217,178,42,45,214,245,236,177,180,144,239,254,128,201,113,9,21,236,177,193,234,25,242,22,235,199,93,221,76,39,215,32,50,37,247,191,250,111,36,91,31,201,188,193,253,143,185,11,204,156,41,153,184,88,209,196,128,167,66,36,64,193,24,65,117,10,90,37,130,25,175,76,0,219,50,111,247,197,2,27,88,66,243,66,178,35,233,217,2,65,204,181,208,128,130,122,207,98,42,148,151,84,123,233,168,144,144,10,41,21,130,148,164,155,146,218,190,224,30,250,162,23,176,96,224,149,70,77,83,25,25,42,208,24,170,44,216,192,21,107,147,8,37,24,218,19,248,156,127,1,174,239,214,243,250,235,239,2,171,85,207,155,121,200,107,220,206,66,244,93,224,109,52,217,17,156,247,34,81,158,202,84,73,42,120,232,26,116,194,41,119,161,237,196,121,205,163,180,219,222,109,79,21,221,174,62,228,240,250,252,111,225,111,109,152,186,223,161,155,64,61,1,107,203,182,104,6,204,225,198,133,107,212,113,51,88,185,33,217,230,99,51,207,239,65,252,173,157,183,78,110,200,116,67,86,101,91,217,19,91,28,46,15,87,82,251,2,125,202,187,235,104,93,136,20,109,158,159,35,15,208,192,152,56,134,75,215,119,55,47,86,163,99,61,75,116,62,244,131,199,120,6,109,255,3,91,64,1,63,177,250,18,218,191,104,127,83,249,61,140,112,36,54,92,203,40,101,158,166,8,58,172,78,240,81,57,6,84,51,109,124,156,198,220,123,222,163,159,208,99,133,133,197,91,97,92,186,212,50,48,148,57,140,194,182,70,140,26,17,113,26,113,140,48,236,46,119,201,48,235,39,172,251,105,159,254,153,179,174,211,168,58,210,117,219,238,47,218,12,157,22,163,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("25eb3e31-0d50-498e-a470-de230ef082fb"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,193,110,163,48,16,253,149,202,231,82,5,226,64,232,173,77,179,61,181,205,138,170,39,46,198,12,196,90,131,145,109,170,205,86,249,247,29,27,146,166,18,218,141,122,169,202,9,30,239,141,223,188,25,191,17,46,153,49,143,172,1,114,77,110,55,15,153,170,236,213,15,33,45,232,123,173,250,142,92,18,3,90,48,41,254,64,57,224,235,82,216,59,102,25,10,222,242,119,125,78,174,243,169,10,57,185,204,137,176,208,24,100,160,32,74,150,113,18,45,22,65,20,205,170,128,114,202,131,116,73,227,96,193,195,89,90,198,201,28,74,58,48,167,75,175,84,211,49,13,195,9,190,120,229,95,159,119,157,35,134,8,112,79,17,70,181,35,56,119,22,204,186,101,133,132,18,191,173,238,1,33,171,69,131,157,192,179,104,96,195,52,158,228,234,40,7,33,169,98,210,56,150,132,202,174,127,119,26,140,17,170,253,183,53,217,55,237,41,23,229,112,252,28,205,204,188,67,199,220,48,187,245,5,178,157,201,192,90,209,214,6,139,148,200,218,123,199,55,117,173,161,102,86,188,158,26,250,5,59,175,58,47,73,20,148,56,173,23,38,123,56,201,232,99,87,43,214,217,161,57,111,6,167,117,97,6,67,163,31,84,104,81,111,207,12,226,24,230,255,178,136,16,236,14,228,179,42,78,54,20,37,8,190,58,192,139,86,26,112,132,55,156,171,190,181,79,237,207,30,215,183,18,28,115,116,62,246,248,184,0,84,141,144,124,234,64,143,63,252,100,38,214,228,195,126,197,46,9,165,108,198,183,208,176,163,207,147,9,122,99,222,230,97,80,148,197,180,76,139,52,40,232,188,8,104,152,198,193,18,66,22,64,177,76,40,204,171,89,8,33,250,194,187,230,26,203,84,175,249,184,223,102,184,100,159,186,62,95,112,45,62,191,235,122,106,185,206,89,151,239,176,10,123,178,255,11,163,34,102,198,105,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
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
				UId = new Guid("7b761d52-e117-4dc0-a0c4-c2846c0292bb"),
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
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91d86af3-634e-48c9-b566-355568110d9f"),
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

		protected virtual void InitializeChangeLeadIsQualificationPassedTrueParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("2585e082-21c1-4b40-97bb-421446d5072b"),
				ContainerUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
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
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e537058-764d-485f-976a-f2c1892e719d"),
				ContainerUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7fa0d07d-a96d-43f6-8700-5d9b0a159e1c"),
				ContainerUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,211,48,16,253,47,57,175,87,78,157,38,110,111,176,44,168,18,176,149,186,218,11,217,195,196,158,180,22,73,19,217,238,66,169,250,223,25,39,109,232,162,2,133,11,155,83,252,244,230,205,155,175,93,164,42,112,238,35,212,24,77,163,215,243,15,139,166,244,215,111,77,229,209,190,179,205,166,141,174,34,135,214,64,101,190,161,238,241,91,109,252,27,240,64,1,187,252,71,124,30,77,243,115,10,121,116,149,71,198,99,237,136,65,1,99,145,102,137,156,20,140,67,172,88,146,140,52,155,164,24,179,82,22,56,134,130,11,5,65,235,151,210,55,77,221,130,197,62,67,39,94,118,191,247,219,54,16,99,2,84,71,49,174,89,31,64,17,44,184,219,53,20,21,106,122,123,187,65,130,188,53,53,85,130,247,166,198,57,88,202,20,116,154,0,17,169,132,202,5,86,133,165,191,253,218,90,116,206,52,235,223,91,171,54,245,250,148,75,225,56,60,15,102,120,231,48,48,231,224,87,157,192,140,76,237,59,143,175,150,75,139,75,240,230,233,212,194,103,220,118,188,203,122,71,1,154,230,243,0,213,6,79,114,62,175,227,6,90,223,151,211,167,39,130,53,203,213,133,149,14,221,250,83,177,35,2,219,35,249,34,197,179,254,71,41,129,79,1,232,53,142,191,121,244,105,230,238,190,172,209,46,212,10,107,232,59,246,120,77,232,79,192,160,63,221,101,26,132,22,147,132,169,113,49,98,73,89,0,43,48,201,88,150,100,192,185,22,169,28,227,254,177,247,97,92,91,193,246,97,72,247,30,161,111,86,232,25,189,179,76,198,49,231,130,201,146,147,22,40,201,164,206,144,41,165,116,1,82,76,120,60,161,217,134,47,140,160,89,26,5,213,93,139,150,70,220,181,152,159,95,205,103,59,29,138,183,77,227,251,146,134,214,13,94,142,235,81,136,76,201,130,107,38,199,144,176,36,149,25,131,68,72,22,143,82,45,48,35,79,49,39,51,116,211,161,191,139,102,99,213,225,142,92,127,204,255,116,166,255,225,252,254,230,166,206,110,245,37,123,250,82,118,112,246,82,54,109,31,237,191,3,170,25,33,130,48,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95da49a7-ccce-4ad9-befc-0d569ae20247"),
				ContainerUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,65,79,227,48,16,133,255,10,178,56,214,149,157,184,113,220,227,46,151,74,20,85,20,184,16,14,99,123,188,68,74,147,42,113,145,160,202,127,199,53,9,109,17,92,88,31,226,120,60,239,205,203,167,236,201,165,127,221,34,153,147,63,171,229,186,113,126,250,183,105,113,186,106,27,131,93,55,189,110,12,84,229,27,232,10,87,208,194,6,61,182,15,80,237,176,187,46,59,63,185,56,21,145,9,185,124,137,119,100,254,184,39,11,143,155,251,133,13,206,224,114,155,103,74,210,76,10,71,69,58,179,52,87,73,66,103,185,228,76,200,4,141,21,65,108,154,106,183,169,151,232,97,5,254,153,204,247,36,186,5,3,43,50,224,58,203,40,151,32,169,200,88,74,53,55,72,133,74,121,42,25,183,144,114,210,79,72,103,158,113,3,113,232,81,44,120,152,175,80,81,57,99,154,10,212,154,230,6,12,117,46,85,58,19,185,224,104,14,226,161,255,40,244,109,216,194,133,45,187,109,5,175,15,63,221,111,207,192,156,118,236,139,15,186,5,153,23,223,243,29,246,117,12,126,78,248,28,110,65,38,5,89,55,187,214,28,220,210,112,184,58,137,21,7,196,150,47,199,145,102,168,212,187,170,26,42,87,224,97,108,28,203,141,45,93,137,118,81,175,71,136,209,133,13,139,126,243,24,215,71,182,255,145,45,161,134,127,216,222,132,207,63,102,255,76,121,23,16,142,198,138,233,108,166,93,78,153,115,134,10,46,56,205,165,84,52,17,9,11,47,224,20,147,81,125,139,14,91,172,13,254,50,216,45,118,145,246,225,55,30,114,29,80,245,164,239,159,250,119,194,20,153,179,54,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cc4958aa-9cc3-4e6d-b485-82a192404f3c"),
				ContainerUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
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
			ProcessSchemaUserTask changeleadstagehandofftosale = CreateChangeLeadStageHandoffToSaleUserTask();
			FlowElements.Add(changeleadstagehandofftosale);
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
			ProcessSchemaExclusiveGateway exclusivegatewayisqualificationpassed = CreateExclusiveGatewayIsQualificationPassedExclusiveGateway();
			FlowElements.Add(exclusivegatewayisqualificationpassed);
			ProcessSchemaUserTask changeleadisqualificationpassedtrue = CreateChangeLeadIsQualificationPassedTrueUserTask();
			FlowElements.Add(changeleadisqualificationpassedtrue);
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
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateQualifiedAccountExistsSequenceFlowConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c65a1bbe-a2e1-4643-aea1-a3b83207ea88"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(176, 271),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			schemaFlow.PolylinePointPositions.Add(new Point(127, 416));
			schemaFlow.PolylinePointPositions.Add(new Point(126, 416));
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(231, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			schemaFlow.PolylinePointPositions.Add(new Point(195, 373));
			schemaFlow.PolylinePointPositions.Add(new Point(195, 687));
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(1084, 512),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			schemaFlow.PolylinePointPositions.Add(new Point(684, 512));
			schemaFlow.PolylinePointPositions.Add(new Point(684, 92));
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(1021, 601),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(1104, 628),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			schemaFlow.PolylinePointPositions.Add(new Point(830, 687));
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(1782, 434),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(793, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			schemaFlow.PolylinePointPositions.Add(new Point(274, 21));
			schemaFlow.PolylinePointPositions.Add(new Point(552, 21));
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
			schemaFlow.PolylinePointPositions.Add(new Point(552, 150));
			schemaFlow.PolylinePointPositions.Add(new Point(545, 150));
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
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

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("c084c45e-344c-4716-9e7d-5c2a2156f893"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("afcc2355-be16-486b-bcf6-db2841519eb1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("fce21b7b-3f73-4e8d-abd1-a8c48ebfab45"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{9c638b0f-7b13-46c3-bef4-2010a78fb3a4}]#]==true ",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("afcc2355-be16-486b-bcf6-db2841519eb1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("478ef5b0-3cfe-49aa-9d92-d33e5210847a"),
				TargetSequenceFlowPointLocalPosition = new Point(1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(313, 492));
			schemaFlow.PolylinePointPositions.Add(new Point(313, 791));
			schemaFlow.PolylinePointPositions.Add(new Point(155, 791));
			schemaFlow.PolylinePointPositions.Add(new Point(155, 506));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("164357f3-a851-4f43-b08a-6416dd1e9661"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("afcc2355-be16-486b-bcf6-db2841519eb1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("cd4daabe-3357-4592-82a8-76ba3320c72a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("279e66a8-61fb-4e2b-8559-0362a5ebb1fe"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLeadQualificationProcessLaneSet() {
			ProcessSchemaLaneSet schemaLeadQualificationProcess = new ProcessSchemaLaneSet(this) {
				UId = new Guid("52a0ec41-f948-487a-bbce-75440b557857"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadQualificationProcess",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LeadQualification",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"Start1",
				Position = new Point(20, 360),
				SerializeToDB = false,
				Size = new Size(27, 27),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"TerminateQualified",
				Position = new Point(1113, 79),
				SerializeToDB = false,
				Size = new Size(27, 27),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ExclusiveGatewayIsLeadSet",
				Position = new Point(100, 346),
				SerializeToDB = false,
				Size = new Size(55, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"Terminate2",
				Position = new Point(113, 493),
				SerializeToDB = false,
				Size = new Size(27, 27),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ReadLeadData",
				Position = new Point(236, 660),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ChangeContactAccount",
				Position = new Point(511, 660),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ExclusiveGatewayAccountConnection",
				Position = new Point(518, 485),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateChangeLeadStageHandoffToSaleUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ChangeLeadStageHandoffToSale",
				Position = new Point(796, 65),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeLeadStageHandoffToSaleParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateChangeAccountScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("97776b38-7f29-472a-ab13-e87884d17d43"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8ecfd6ca-7945-4fe1-b150-3316de6e5f08"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ChangeAccountScriptTask",
				Position = new Point(240, 51),
				SerializeToDB = false,
				Size = new Size(69, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ChangeContactScriptTask",
				Position = new Point(236, 185),
				SerializeToDB = false,
				Size = new Size(69, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LinkContactToLead",
				Position = new Point(518, 65),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"LinkAccountToLead",
				Position = new Point(511, 359),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ExclusiveGatewayQualifiedAccount",
				Position = new Point(518, 205),
				SerializeToDB = false,
				Size = new Size(55, 55),
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
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ReadSystemSettings",
				Position = new Point(236, 304),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadSystemSettingsParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGatewayIsQualificationPassedExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("afcc2355-be16-486b-bcf6-db2841519eb1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ExclusiveGatewayIsQualificationPassed",
				Position = new Point(243, 465),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateChangeLeadIsQualificationPassedTrueUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba73ea8a-5a22-4c8b-807e-e27f1d404045"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059"),
				CreatedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"),
				Name = @"ChangeLeadIsQualificationPassedTrue",
				Position = new Point(951, 65),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeLeadIsQualificationPassedTrueParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
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

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LeadManagementQualification10(userConnection);
		}

		public override object Clone() {
			return new LeadManagementQualification10Schema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadManagementQualification10

	/// <exclude/>
	public class LeadManagementQualification10 : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLeadQualification

		/// <exclude/>
		public class ProcessLeadQualification : ProcessLane
		{

			public ProcessLeadQualification(UserConnection userConnection, LeadManagementQualification10 process)
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

			public ReadLeadDataFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadLeadData";
				IsLogging = true;
				SchemaElementUId = new Guid("8bf25d2e-0f4c-4ed1-b885-635952f9e063");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,211,64,16,253,47,62,119,43,127,102,215,189,65,9,40,18,208,72,169,122,169,123,24,175,103,147,21,118,108,237,110,10,33,202,127,103,214,78,76,138,34,8,92,168,79,222,167,55,111,222,124,237,2,89,131,181,159,161,193,224,38,120,59,255,180,104,149,187,126,175,107,135,230,131,105,55,93,112,21,88,52,26,106,253,29,171,1,159,86,218,189,3,7,20,176,43,126,198,23,193,77,113,78,161,8,174,138,64,59,108,44,49,40,0,243,68,114,89,166,172,226,50,99,169,82,156,229,10,36,203,75,145,169,60,142,34,224,147,129,121,94,250,182,109,58,48,56,100,232,197,85,255,123,191,237,60,49,34,64,246,20,109,219,245,1,76,188,5,59,93,67,89,99,69,111,103,54,72,144,51,186,161,74,240,94,55,56,7,67,153,188,78,235,33,34,41,168,173,103,213,168,220,244,91,103,208,90,221,174,127,111,173,222,52,235,83,46,133,227,248,60,152,9,123,135,158,57,7,183,234,5,102,100,106,223,123,124,179,92,26,92,130,211,207,167,22,190,224,182,231,93,214,59,10,168,104,62,15,80,111,240,36,231,203,58,110,161,115,67,57,67,122,34,24,189,92,93,88,233,216,173,63,21,27,19,216,29,201,23,41,158,245,31,79,8,124,246,192,160,113,252,45,130,199,153,189,251,186,70,179,144,43,108,96,232,216,211,53,161,191,0,163,254,205,142,87,144,84,73,158,50,153,149,49,117,177,4,86,98,202,25,79,57,132,97,149,76,68,134,251,167,193,135,182,93,13,219,135,49,221,71,132,161,89,190,103,244,22,32,243,80,37,33,139,50,80,164,149,100,44,15,243,152,133,25,207,34,94,42,41,33,162,217,250,207,143,160,93,106,9,245,93,135,134,70,220,183,56,60,191,154,47,118,218,23,111,218,214,13,37,141,173,27,189,28,215,67,240,112,34,100,38,88,34,115,100,105,84,77,152,64,81,178,36,230,101,44,34,81,10,9,100,134,110,218,247,119,209,110,140,60,220,145,29,142,249,159,206,244,63,156,223,223,220,212,217,173,190,100,79,95,203,14,206,94,203,166,237,131,253,15,19,148,195,146,48,6,0,0 })));
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

		#region Class: ChangeContactAccountFlowElement

		/// <exclude/>
		public class ChangeContactAccountFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeContactAccountFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,43,133,207,85,225,15,197,177,115,91,179,108,200,97,107,134,20,189,212,61,208,50,149,8,243,23,36,185,91,22,228,191,143,178,147,44,29,130,53,219,101,245,73,122,126,124,124,164,200,173,39,74,48,230,51,84,232,77,188,219,197,167,101,35,237,205,7,85,90,212,31,117,211,181,222,181,103,80,43,40,213,15,44,6,124,86,40,251,30,44,80,192,54,251,21,159,121,147,236,156,66,230,93,103,158,178,88,25,98,80,128,140,139,176,200,83,96,126,146,199,140,11,46,25,0,23,76,230,33,207,65,8,33,147,241,192,60,47,61,109,170,22,52,14,25,122,113,217,31,239,55,173,35,6,4,136,158,162,76,83,239,193,200,89,48,179,26,242,18,11,186,91,221,33,65,86,171,138,42,193,123,85,225,2,52,101,114,58,141,131,136,36,161,52,142,85,162,180,179,239,173,70,99,84,83,255,217,90,217,85,245,41,151,194,241,120,221,155,241,123,135,142,185,0,187,238,5,230,100,106,215,123,124,183,90,105,92,129,85,207,167,22,190,226,166,231,93,214,59,10,40,232,125,30,160,236,240,36,231,203,58,166,208,218,161,156,33,61,17,180,90,173,47,172,244,216,173,215,138,13,9,108,15,228,139,20,207,250,15,99,2,159,29,48,104,28,142,153,247,56,55,119,223,106,212,75,177,198,10,134,142,61,221,16,250,27,112,212,159,108,195,64,250,17,142,10,22,228,227,132,241,164,16,44,197,200,103,129,72,98,153,6,113,192,147,100,247,52,248,80,166,45,97,243,112,76,247,165,163,85,144,10,139,43,48,87,162,169,45,8,219,51,93,15,233,127,80,196,136,81,152,51,62,226,17,227,210,15,89,226,99,200,36,31,5,99,145,164,50,241,71,244,214,238,115,79,210,172,148,128,242,174,69,77,79,222,183,220,63,63,170,47,102,220,53,67,55,141,29,74,60,182,114,122,98,231,48,49,201,40,151,92,166,100,32,8,144,113,30,1,203,253,84,178,66,142,243,0,100,202,243,136,38,102,71,107,238,90,190,108,58,45,246,171,101,134,253,254,167,205,253,15,27,249,55,107,118,118,208,47,25,221,183,50,150,243,55,52,108,59,111,247,19,128,10,160,234,70,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,115,218,48,16,253,43,140,146,35,203,72,178,101,91,62,182,185,48,19,90,26,218,92,128,195,90,90,53,204,24,155,241,71,59,41,227,255,94,217,224,0,105,110,213,193,30,173,245,222,62,189,183,62,178,251,230,245,64,44,101,159,150,139,85,233,154,217,231,178,162,217,178,42,13,213,245,236,177,52,152,239,254,96,150,211,18,43,220,83,67,213,51,230,45,213,143,187,186,153,78,174,65,108,202,238,127,13,223,88,186,62,178,121,67,251,31,115,235,153,179,40,114,81,204,13,104,105,56,132,42,51,144,113,204,64,104,76,172,160,88,73,109,61,216,148,121,187,47,22,212,224,18,155,23,150,30,217,192,230,9,148,137,12,10,78,32,68,226,9,140,32,72,80,113,80,10,99,233,156,206,172,13,89,55,101,181,121,161,61,14,77,47,96,17,101,20,68,74,64,226,72,66,40,148,134,196,90,14,152,240,192,134,81,18,88,27,244,224,243,249,11,112,125,183,158,215,95,127,23,84,173,6,222,212,97,94,211,118,230,171,239,10,111,214,164,71,180,206,121,82,7,42,78,20,132,50,72,0,117,36,65,250,86,24,89,167,37,143,187,237,221,182,239,104,119,245,33,199,215,231,127,27,127,107,189,235,110,71,118,130,245,4,141,41,219,162,57,97,14,55,41,92,163,142,155,83,148,27,150,110,62,14,243,252,62,137,191,141,243,54,201,13,155,110,216,170,108,43,211,179,5,126,243,112,37,117,104,48,28,121,183,29,163,243,149,162,205,243,115,229,1,27,28,15,142,229,210,14,183,155,23,171,49,177,129,133,159,23,124,240,24,215,73,219,255,192,22,88,224,79,170,190,248,235,95,180,191,169,252,238,45,28,137,51,169,21,143,133,131,152,80,67,72,62,71,63,176,8,90,232,204,5,113,224,103,79,14,232,39,114,84,81,97,232,86,152,84,54,54,162,159,116,75,253,224,115,1,89,200,37,112,73,156,250,217,181,209,201,235,39,170,7,183,251,127,230,172,171,183,170,99,93,183,237,254,2,9,209,235,172,163,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "63c69a324ff64ed8bdd02ff85dfbe88a",
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

		#region Class: ChangeLeadStageHandoffToSaleFlowElement

		/// <exclude/>
		public class ChangeLeadStageHandoffToSaleFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeLeadStageHandoffToSaleFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeLeadStageHandoffToSale";
				IsLogging = true;
				SchemaElementUId = new Guid("2b2b8a21-5d60-4170-a9eb-caa404a44b84");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualifyStatus = () => (Guid)(new Guid("ceb70b3c-985f-4867-ae7c-88f9dd710688"));
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,85,93,79,219,48,20,253,43,83,158,49,74,109,39,78,120,219,24,155,144,182,193,84,196,11,229,193,177,175,75,180,124,201,113,216,58,212,255,190,235,164,148,82,10,203,144,16,172,79,206,237,245,241,185,31,231,222,155,64,21,178,109,191,201,18,130,131,224,195,233,215,105,109,220,254,167,188,112,96,63,219,186,107,130,189,160,5,155,203,34,255,13,122,176,31,233,220,125,148,78,226,133,155,217,221,253,89,112,48,219,133,48,11,246,102,65,238,160,108,209,3,47,8,158,170,144,198,134,200,48,52,132,199,6,79,137,138,136,86,44,82,210,232,80,11,143,245,40,244,97,93,54,210,194,240,66,15,110,250,227,217,162,241,142,19,52,168,222,37,111,235,106,101,100,158,66,123,84,201,172,0,141,223,206,118,128,38,103,243,18,35,129,179,188,132,83,105,241,37,143,83,123,19,58,25,89,180,222,171,0,227,142,126,53,22,218,54,175,171,167,169,21,93,89,109,250,226,117,88,127,174,200,132,61,67,239,121,42,221,85,15,112,140,164,150,61,199,247,243,185,133,185,116,249,245,38,133,31,176,232,253,198,229,14,47,104,172,207,185,44,58,216,120,243,126,28,135,178,113,67,56,195,243,232,96,243,249,213,200,72,215,217,250,91,176,20,141,205,173,243,40,196,157,252,105,140,198,107,111,24,48,110,143,179,224,226,184,61,249,89,129,157,170,43,40,229,144,177,203,125,180,110,25,214,248,7,55,66,75,166,89,202,137,138,50,74,184,201,36,201,128,11,34,184,192,188,106,22,39,17,44,47,7,30,121,219,20,114,113,190,126,238,11,200,33,89,62,103,248,109,120,150,0,103,138,48,150,70,132,43,30,147,52,230,25,73,19,153,9,26,103,201,68,167,88,91,252,249,170,103,70,42,157,132,132,25,145,17,46,76,70,36,101,146,8,166,133,194,218,113,206,216,83,57,58,174,30,235,122,254,63,118,253,247,14,199,138,89,76,157,116,93,59,78,0,227,50,184,163,129,38,79,43,192,151,245,93,235,228,124,144,143,5,3,22,42,5,67,19,173,67,222,98,252,80,51,126,198,93,188,25,213,244,65,111,168,102,213,179,90,164,161,228,145,38,33,195,1,194,181,198,118,213,32,73,18,38,66,80,170,162,132,170,30,111,43,238,92,97,89,86,148,239,4,56,26,237,129,150,182,80,81,35,151,189,76,138,122,142,198,226,164,1,187,250,171,239,158,29,173,124,79,3,126,68,216,186,118,91,53,91,43,246,182,135,168,160,108,18,43,65,96,194,53,225,60,53,36,161,148,147,40,165,72,151,71,19,70,35,100,131,155,207,231,115,90,119,86,173,182,77,59,172,188,103,45,179,87,88,82,255,178,121,118,206,254,49,125,249,86,38,245,203,206,227,87,24,182,207,156,160,118,247,64,122,78,41,239,141,143,177,66,127,73,17,47,131,229,31,179,84,118,137,177,10,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,143,218,48,16,253,43,200,187,71,38,114,226,96,199,28,219,61,20,9,42,84,218,189,44,123,24,219,227,46,106,136,81,18,42,109,17,255,189,38,36,11,84,91,169,82,125,72,228,201,188,143,204,179,15,236,190,125,221,17,155,178,15,203,197,42,248,54,249,24,106,74,150,117,176,212,52,201,60,88,44,55,191,208,148,180,196,26,183,212,82,253,136,229,158,154,249,166,105,199,163,107,16,27,179,251,159,221,55,54,125,58,176,89,75,219,111,51,23,153,125,97,56,106,225,1,165,70,200,51,233,65,115,101,32,35,36,99,140,39,145,242,8,182,161,220,111,171,5,181,184,196,246,133,77,15,172,99,139,4,198,114,155,57,201,97,130,194,65,94,228,28,16,115,2,43,57,161,82,146,50,46,217,113,204,26,251,66,91,236,68,47,224,60,69,95,104,210,160,38,220,64,30,21,161,176,104,193,123,161,141,140,100,41,217,19,184,239,191,0,159,238,230,33,252,216,239,146,44,19,121,106,93,10,19,35,4,228,54,202,107,158,166,32,189,146,90,144,151,148,231,137,37,163,184,17,22,116,49,241,209,163,84,128,164,44,20,133,215,206,169,148,203,162,184,123,62,9,185,77,179,43,241,245,241,175,122,115,66,55,106,90,252,78,201,39,172,92,240,126,212,134,81,131,37,53,103,134,221,77,20,215,28,135,245,57,207,53,155,174,223,79,180,127,175,186,81,221,102,122,27,231,154,141,215,108,21,246,181,61,177,137,184,121,184,50,222,9,116,45,127,108,135,252,98,165,218,151,101,95,121,192,22,135,198,161,28,220,198,111,200,205,170,213,16,91,199,194,251,5,239,60,134,117,246,246,63,176,5,86,113,190,245,231,248,251,23,239,111,46,191,198,17,14,196,38,211,19,174,82,15,138,80,199,243,35,51,40,92,138,160,83,109,188,80,34,243,62,235,208,95,200,83,77,149,165,91,99,255,114,122,122,124,211,77,251,116,113,122,95,167,81,29,217,241,248,124,252,13,243,178,171,200,168,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "63c69a324ff64ed8bdd02ff85dfbe88a",
							"BaseElements.ChangeLeadStageHandoffToSale.Parameters.RecordColumnValues.Value");
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

			public LinkContactToLeadFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,18,127,231,182,117,217,16,96,91,3,164,232,165,238,129,146,169,68,152,29,27,146,210,45,11,242,223,71,217,137,151,14,65,155,237,178,250,100,61,60,146,143,143,228,46,144,21,88,251,21,106,12,38,193,251,249,151,69,163,220,245,71,93,57,52,159,76,179,105,131,171,192,162,209,80,233,159,88,246,248,180,212,238,3,56,160,128,93,241,59,190,8,38,197,185,12,69,112,85,4,218,97,109,137,65,1,2,101,30,38,146,51,149,98,206,34,57,66,150,197,81,234,159,16,229,89,36,70,105,216,51,207,167,190,105,234,22,12,246,21,186,228,170,251,189,219,182,158,56,34,64,118,20,109,155,245,1,12,189,4,59,93,131,168,176,164,183,51,27,36,200,25,93,83,39,120,167,107,156,131,161,74,62,79,227,33,34,41,168,172,103,85,168,220,244,71,107,208,90,221,172,95,150,86,109,234,245,41,151,194,113,120,30,196,240,78,161,103,206,193,173,186,4,51,18,181,239,52,190,91,46,13,46,193,233,167,83,9,223,112,219,241,46,243,142,2,74,154,207,61,84,27,60,169,249,188,143,27,104,93,223,78,95,158,8,70,47,87,23,118,58,184,245,90,179,99,2,219,35,249,162,140,103,245,143,19,2,159,60,208,231,56,254,22,193,195,204,222,126,95,163,89,200,21,214,208,59,246,120,77,232,31,192,144,127,178,75,75,8,203,48,143,152,140,197,152,69,74,0,19,72,46,166,81,10,156,151,97,146,197,184,127,236,117,104,219,86,176,189,31,202,125,70,232,205,242,158,209,59,79,69,158,242,56,102,185,202,21,139,202,108,204,132,82,156,137,88,73,158,73,206,37,112,154,173,255,252,8,154,165,150,80,221,182,104,104,196,157,197,252,252,106,62,219,105,223,188,105,26,215,183,52,88,55,104,57,174,7,7,53,86,97,38,88,41,147,152,214,35,29,177,44,42,99,38,202,28,121,158,36,82,100,130,196,208,77,123,127,23,205,198,200,195,29,217,254,152,255,233,76,255,195,249,253,205,77,157,221,234,75,246,244,173,236,224,236,173,108,218,62,216,255,2,250,143,101,22,48,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,193,114,155,48,16,253,21,143,146,163,215,131,144,16,18,199,54,23,207,196,173,91,55,185,24,31,22,105,213,120,6,131,7,112,59,169,135,127,47,198,16,219,105,110,213,1,70,143,125,111,159,246,161,35,187,111,94,247,196,18,246,105,185,88,149,190,153,125,46,43,154,45,171,210,82,93,207,30,75,139,249,246,15,102,57,45,177,194,29,53,84,61,99,126,160,250,113,91,55,211,201,53,137,77,217,253,175,254,27,75,214,71,54,111,104,247,52,119,157,114,224,200,163,143,61,56,175,12,200,64,10,208,161,150,224,44,10,197,99,19,106,23,118,100,91,230,135,93,177,160,6,151,216,188,176,228,200,122,181,78,0,157,52,129,139,52,4,145,68,144,78,71,96,66,169,192,57,45,149,162,76,24,45,88,59,101,181,125,161,29,246,77,47,100,201,209,107,67,6,226,40,200,64,82,150,129,182,104,193,123,97,50,37,181,228,100,79,228,161,254,66,92,223,173,231,245,215,223,5,85,171,94,55,241,152,215,180,153,117,232,59,224,109,52,201,49,228,62,16,20,57,224,89,172,65,106,103,193,144,8,128,91,173,188,225,138,75,173,219,205,221,230,212,209,109,235,125,142,175,207,255,54,254,118,232,166,238,183,228,38,88,79,108,89,52,104,155,51,103,127,147,194,53,235,152,158,163,76,89,146,126,28,230,240,62,155,191,141,243,54,201,148,77,83,182,42,15,149,61,169,137,110,243,112,101,181,111,208,151,188,219,142,209,117,72,113,200,243,1,121,192,6,199,194,17,46,93,127,186,121,177,26,19,235,85,130,97,193,7,143,113,157,189,253,15,109,129,5,254,164,234,75,119,252,139,247,55,151,63,186,17,142,194,89,104,162,32,230,30,98,194,238,199,37,21,130,118,28,193,112,147,121,17,139,208,251,176,103,127,39,79,21,21,150,110,141,113,149,145,80,17,7,237,41,4,201,35,211,241,93,0,168,3,225,164,210,194,57,49,240,235,126,218,167,59,51,248,58,141,170,101,109,187,105,255,2,84,197,123,94,163,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "63c69a324ff64ed8bdd02ff85dfbe88a",
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

			public LinkAccountToLeadFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,111,219,48,12,253,47,62,87,133,191,63,122,219,186,108,8,176,173,1,82,244,82,247,64,201,84,34,204,142,13,73,233,150,5,254,239,163,236,196,75,135,96,203,118,89,117,146,30,30,31,31,41,114,239,137,26,140,249,12,13,122,55,222,219,197,167,101,43,237,245,123,85,91,212,31,116,187,237,188,43,207,160,86,80,171,239,88,141,248,172,82,246,29,88,160,128,125,249,51,190,244,110,202,115,10,165,119,85,122,202,98,99,136,65,1,9,151,97,234,71,25,11,179,84,176,184,74,10,198,19,153,50,145,201,16,5,15,69,2,201,200,60,47,125,219,54,29,104,28,51,12,226,114,184,222,239,58,71,12,8,16,3,69,153,118,115,0,35,103,193,204,54,192,107,172,232,109,245,22,9,178,90,53,84,9,222,171,6,23,160,41,147,211,105,29,68,36,9,181,113,172,26,165,157,125,235,52,26,163,218,205,239,173,213,219,102,115,202,165,112,156,158,7,51,254,224,208,49,23,96,215,131,192,156,76,245,131,199,55,171,149,198,21,88,245,124,106,225,11,238,6,222,101,189,163,128,138,254,231,1,234,45,158,228,124,89,199,45,116,118,44,103,76,79,4,173,86,235,11,43,157,186,245,167,98,67,2,187,35,249,34,197,179,254,195,148,192,103,7,140,26,199,107,233,61,206,205,221,215,13,234,165,88,99,3,99,199,158,174,9,253,5,152,244,111,246,89,5,81,21,21,49,19,9,15,89,44,57,48,142,113,198,178,56,3,223,175,162,52,79,176,127,26,125,40,211,213,176,123,152,210,125,68,24,155,229,122,70,239,128,34,100,142,130,249,60,40,88,156,103,25,203,179,48,102,73,44,162,40,71,8,11,55,112,189,59,238,11,218,149,18,80,223,117,168,233,139,135,22,251,231,71,243,197,76,187,226,117,219,218,177,164,169,117,147,151,227,120,248,65,94,113,224,146,133,69,80,177,24,115,206,184,204,5,43,82,25,7,228,147,115,73,145,61,237,180,235,239,178,221,106,113,216,35,51,46,243,63,173,233,127,88,191,191,217,169,179,83,125,201,156,190,150,25,156,191,150,73,235,189,254,7,189,141,72,168,48,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,77,115,218,48,16,253,43,140,146,35,98,44,89,178,37,31,219,92,152,9,45,13,109,46,192,97,37,173,26,102,140,205,248,163,157,148,241,127,175,176,113,128,52,183,234,96,143,214,251,222,190,221,183,62,146,251,230,245,128,36,35,159,150,139,85,233,155,217,231,178,194,217,178,42,45,214,245,236,177,180,144,239,254,128,201,113,9,21,236,177,193,234,25,242,22,235,199,93,221,76,39,215,32,50,37,247,191,250,111,36,91,31,201,188,193,253,143,185,11,204,156,41,153,184,88,209,196,128,167,66,36,64,193,24,65,117,10,90,37,130,25,175,76,0,219,50,111,247,197,2,27,88,66,243,66,178,35,233,217,2,65,204,181,208,128,130,122,207,98,42,148,151,84,123,233,168,144,144,10,41,21,130,148,164,155,146,218,190,224,30,250,162,23,176,96,224,149,70,77,83,25,25,42,208,24,170,44,216,192,21,107,147,8,37,24,218,19,248,156,127,1,174,239,214,243,250,235,239,2,171,85,207,155,121,200,107,220,206,66,244,93,224,109,52,217,17,156,247,34,81,158,202,84,73,42,120,232,26,116,194,41,119,161,237,196,121,205,163,180,219,222,109,79,21,221,174,62,228,240,250,252,111,225,111,109,152,186,223,161,155,64,61,1,107,203,182,104,6,204,225,198,133,107,212,113,51,88,185,33,217,230,99,51,207,239,65,252,173,157,183,78,110,200,116,67,86,101,91,217,19,91,28,46,15,87,82,251,2,125,202,187,235,104,93,136,20,109,158,159,35,15,208,192,152,56,134,75,215,119,55,47,86,163,99,61,75,116,62,244,131,199,120,6,109,255,3,91,64,1,63,177,250,18,218,191,104,127,83,249,61,140,112,36,54,92,203,40,101,158,166,8,58,172,78,240,81,57,6,84,51,109,124,156,198,220,123,222,163,159,208,99,133,133,197,91,97,92,186,212,50,48,148,57,140,194,182,70,140,26,17,113,26,113,140,48,236,46,119,201,48,235,39,172,251,105,159,254,153,179,174,211,168,58,210,117,219,238,47,218,12,157,22,163,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "63c69a324ff64ed8bdd02ff85dfbe88a",
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

			public ReadSystemSettingsFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadSystemSettings";
				IsLogging = true;
				SchemaElementUId = new Guid("a188ff27-c185-4b79-b24c-71503e5df1a6");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,193,110,163,48,16,253,149,202,231,82,5,226,64,232,173,77,179,61,181,205,138,170,39,46,198,12,196,90,131,145,109,170,205,86,249,247,29,27,146,166,18,218,141,122,169,202,9,30,239,141,223,188,25,191,17,46,153,49,143,172,1,114,77,110,55,15,153,170,236,213,15,33,45,232,123,173,250,142,92,18,3,90,48,41,254,64,57,224,235,82,216,59,102,25,10,222,242,119,125,78,174,243,169,10,57,185,204,137,176,208,24,100,160,32,74,150,113,18,45,22,65,20,205,170,128,114,202,131,116,73,227,96,193,195,89,90,198,201,28,74,58,48,167,75,175,84,211,49,13,195,9,190,120,229,95,159,119,157,35,134,8,112,79,17,70,181,35,56,119,22,204,186,101,133,132,18,191,173,238,1,33,171,69,131,157,192,179,104,96,195,52,158,228,234,40,7,33,169,98,210,56,150,132,202,174,127,119,26,140,17,170,253,183,53,217,55,237,41,23,229,112,252,28,205,204,188,67,199,220,48,187,245,5,178,157,201,192,90,209,214,6,139,148,200,218,123,199,55,117,173,161,102,86,188,158,26,250,5,59,175,58,47,73,20,148,56,173,23,38,123,56,201,232,99,87,43,214,217,161,57,111,6,167,117,97,6,67,163,31,84,104,81,111,207,12,226,24,230,255,178,136,16,236,14,228,179,42,78,54,20,37,8,190,58,192,139,86,26,112,132,55,156,171,190,181,79,237,207,30,215,183,18,28,115,116,62,246,248,184,0,84,141,144,124,234,64,143,63,252,100,38,214,228,195,126,197,46,9,165,108,198,183,208,176,163,207,147,9,122,99,222,230,97,80,148,197,180,76,139,52,40,232,188,8,104,152,198,193,18,66,22,64,177,76,40,204,171,89,8,33,250,194,187,230,26,203,84,175,249,184,223,102,184,100,159,186,62,95,112,45,62,191,235,122,106,185,206,89,151,239,176,10,123,178,255,11,163,34,102,198,105,5,0,0 })));
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

		#region Class: ChangeLeadIsQualificationPassedTrueFlowElement

		/// <exclude/>
		public class ChangeLeadIsQualificationPassedTrueFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeLeadIsQualificationPassedTrueFlowElement(UserConnection userConnection, LeadManagementQualification10 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeLeadIsQualificationPassedTrue";
				IsLogging = true;
				SchemaElementUId = new Guid("d5956d29-6377-467e-a94b-24cf386951b3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_QualificationPassed = () => (bool)(true);
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_QualificationPassed", () => _recordColumnValues_QualificationPassed.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<bool> _recordColumnValues_QualificationPassed;

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

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,205,83,77,143,211,48,16,253,47,57,175,87,78,157,38,110,111,176,44,168,18,176,149,186,218,11,217,195,196,158,180,22,73,19,217,238,66,169,250,223,25,39,109,232,162,2,133,11,155,83,252,244,230,205,155,175,93,164,42,112,238,35,212,24,77,163,215,243,15,139,166,244,215,111,77,229,209,190,179,205,166,141,174,34,135,214,64,101,190,161,238,241,91,109,252,27,240,64,1,187,252,71,124,30,77,243,115,10,121,116,149,71,198,99,237,136,65,1,99,145,102,137,156,20,140,67,172,88,146,140,52,155,164,24,179,82,22,56,134,130,11,5,65,235,151,210,55,77,221,130,197,62,67,39,94,118,191,247,219,54,16,99,2,84,71,49,174,89,31,64,17,44,184,219,53,20,21,106,122,123,187,65,130,188,53,53,85,130,247,166,198,57,88,202,20,116,154,0,17,169,132,202,5,86,133,165,191,253,218,90,116,206,52,235,223,91,171,54,245,250,148,75,225,56,60,15,102,120,231,48,48,231,224,87,157,192,140,76,237,59,143,175,150,75,139,75,240,230,233,212,194,103,220,118,188,203,122,71,1,154,230,243,0,213,6,79,114,62,175,227,6,90,223,151,211,167,39,130,53,203,213,133,149,14,221,250,83,177,35,2,219,35,249,34,197,179,254,71,41,129,79,1,232,53,142,191,121,244,105,230,238,190,172,209,46,212,10,107,232,59,246,120,77,232,79,192,160,63,221,101,26,132,22,147,132,169,113,49,98,73,89,0,43,48,201,88,150,100,192,185,22,169,28,227,254,177,247,97,92,91,193,246,97,72,247,30,161,111,86,232,25,189,179,76,198,49,231,130,201,146,147,22,40,201,164,206,144,41,165,116,1,82,76,120,60,161,217,134,47,140,160,89,26,5,213,93,139,150,70,220,181,152,159,95,205,103,59,29,138,183,77,227,251,146,134,214,13,94,142,235,81,136,76,201,130,107,38,199,144,176,36,149,25,131,68,72,22,143,82,45,48,35,79,49,39,51,116,211,161,191,139,102,99,213,225,142,92,127,204,255,116,166,255,225,252,254,230,166,206,110,245,37,123,250,82,118,112,246,82,54,109,31,237,191,3,170,25,33,130,48,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,65,79,227,48,16,133,255,10,178,56,214,149,157,184,113,220,227,46,151,74,20,85,20,184,16,14,99,123,188,68,74,147,42,113,145,160,202,127,199,53,9,109,17,92,88,31,226,120,60,239,205,203,167,236,201,165,127,221,34,153,147,63,171,229,186,113,126,250,183,105,113,186,106,27,131,93,55,189,110,12,84,229,27,232,10,87,208,194,6,61,182,15,80,237,176,187,46,59,63,185,56,21,145,9,185,124,137,119,100,254,184,39,11,143,155,251,133,13,206,224,114,155,103,74,210,76,10,71,69,58,179,52,87,73,66,103,185,228,76,200,4,141,21,65,108,154,106,183,169,151,232,97,5,254,153,204,247,36,186,5,3,43,50,224,58,203,40,151,32,169,200,88,74,53,55,72,133,74,121,42,25,183,144,114,210,79,72,103,158,113,3,113,232,81,44,120,152,175,80,81,57,99,154,10,212,154,230,6,12,117,46,85,58,19,185,224,104,14,226,161,255,40,244,109,216,194,133,45,187,109,5,175,15,63,221,111,207,192,156,118,236,139,15,186,5,153,23,223,243,29,246,117,12,126,78,248,28,110,65,38,5,89,55,187,214,28,220,210,112,184,58,137,21,7,196,150,47,199,145,102,168,212,187,170,26,42,87,224,97,108,28,203,141,45,93,137,118,81,175,71,136,209,133,13,139,126,243,24,215,71,182,255,145,45,161,134,127,216,222,132,207,63,102,255,76,121,23,16,142,198,138,233,108,166,93,78,153,115,134,10,46,56,205,165,84,52,17,9,11,47,224,20,147,81,125,139,14,91,172,13,254,50,216,45,118,145,246,225,55,30,114,29,80,245,164,239,159,250,119,194,20,153,179,54,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "63c69a324ff64ed8bdd02ff85dfbe88a",
							"BaseElements.ChangeLeadIsQualificationPassedTrue.Parameters.RecordColumnValues.Value");
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

		public LeadManagementQualification10(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadManagementQualification10";
			SchemaUId = new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
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
			_leadQualificationPassed = () => { return (bool)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("QualificationPassed").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<bool>("QualificationPassed") : false))); };
			_leadOwner = () => { return (Guid)(((ReadLeadData.ResultEntity.IsColumnValueLoaded(ReadLeadData.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? ReadLeadData.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("63c69a32-4ff6-4ed8-bdd0-2ff85dfbe88a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LeadManagementQualification10, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LeadManagementQualification10, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<bool> _leadQualificationPassed;
		public virtual bool LeadQualificationPassed {
			get {
				return (_leadQualificationPassed ?? (_leadQualificationPassed = () => false)).Invoke();
			}
			set {
				_leadQualificationPassed = () => { return value; };
			}
		}

		private Func<Guid> _leadOwner;
		public virtual Guid LeadOwner {
			get {
				return (_leadOwner ?? (_leadOwner = () => Guid.Empty)).Invoke();
			}
			set {
				_leadOwner = () => { return value; };
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
					IsLogging = true,
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
					SchemaElementUId = new Guid("ed9cbb4d-b5c9-4231-ab67-76ffff3433b0"),
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
					IsLogging = true,
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
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayAccountConnection.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ChangeLeadStageHandoffToSaleFlowElement _changeLeadStageHandoffToSale;
		public ChangeLeadStageHandoffToSaleFlowElement ChangeLeadStageHandoffToSale {
			get {
				return _changeLeadStageHandoffToSale ?? (_changeLeadStageHandoffToSale = new ChangeLeadStageHandoffToSaleFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					IsLogging = true,
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
					IsLogging = true,
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
					IsLogging = true,
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

		private ProcessExclusiveGateway _exclusiveGatewayIsQualificationPassed;
		public ProcessExclusiveGateway ExclusiveGatewayIsQualificationPassed {
			get {
				return _exclusiveGatewayIsQualificationPassed ?? (_exclusiveGatewayIsQualificationPassed = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGatewayIsQualificationPassed",
					SchemaElementUId = new Guid("afcc2355-be16-486b-bcf6-db2841519eb1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGatewayIsQualificationPassed.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ChangeLeadIsQualificationPassedTrueFlowElement _changeLeadIsQualificationPassedTrue;
		public ChangeLeadIsQualificationPassedTrueFlowElement ChangeLeadIsQualificationPassedTrue {
			get {
				return _changeLeadIsQualificationPassedTrue ?? (_changeLeadIsQualificationPassedTrue = new ChangeLeadIsQualificationPassedTrueFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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

		private ProcessConditionalFlow _conditionalSequenceFlow1;
		public ProcessConditionalFlow ConditionalSequenceFlow1 {
			get {
				return _conditionalSequenceFlow1 ?? (_conditionalSequenceFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow1",
					SchemaElementUId = new Guid("fce21b7b-3f73-4e8d-abd1-a8c48ebfab45"),
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
			FlowElements[ChangeLeadStageHandoffToSale.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeLeadStageHandoffToSale };
			FlowElements[ChangeAccountScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeAccountScriptTask };
			FlowElements[ChangeContactScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeContactScriptTask };
			FlowElements[LinkContactToLead.SchemaElementUId] = new Collection<ProcessFlowElement> { LinkContactToLead };
			FlowElements[LinkAccountToLead.SchemaElementUId] = new Collection<ProcessFlowElement> { LinkAccountToLead };
			FlowElements[ExclusiveGatewayQualifiedAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayQualifiedAccount };
			FlowElements[ReadSystemSettings.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadSystemSettings };
			FlowElements[ExclusiveGatewayIsQualificationPassed.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGatewayIsQualificationPassed };
			FlowElements[ChangeLeadIsQualificationPassedTrue.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeLeadIsQualificationPassedTrue };
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
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGatewayIsQualificationPassed", e.Context.SenderName));
						break;
					case "ChangeContactAccount":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadStageHandoffToSale", e.Context.SenderName));
						break;
					case "ExclusiveGatewayAccountConnection":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeContactAccount", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadStageHandoffToSale", e.Context.SenderName));
						break;
					case "ChangeLeadStageHandoffToSale":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeLeadIsQualificationPassedTrue", e.Context.SenderName));
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
					case "ExclusiveGatewayIsQualificationPassed":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadSystemSettings", e.Context.SenderName));
						break;
					case "ChangeLeadIsQualificationPassedTrue":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateQualified", e.Context.SenderName));
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

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((LeadQualificationPassed)==true );
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGatewayIsQualificationPassed", "ConditionalSequenceFlow1", "(LeadQualificationPassed)==true ", result);
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
			if (!HasMapping("LeadQualificationPassed")) {
				writer.WriteValue("LeadQualificationPassed", LeadQualificationPassed, false);
			}
			if (!HasMapping("LeadOwner")) {
				writer.WriteValue("LeadOwner", LeadOwner, Guid.Empty);
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
			MetaPathParameterValues.Add("9c638b0f-7b13-46c3-bef4-2010a78fb3a4", () => LeadQualificationPassed);
			MetaPathParameterValues.Add("d957170c-e768-44a5-a025-d5d08a8f9f76", () => LeadOwner);
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
			MetaPathParameterValues.Add("d2014bab-ec05-4880-9e20-25862680d97a", () => ReadLeadData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("12c2859f-0077-4ba5-a75e-9d121e261ff2", () => ReadLeadData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("ea29a1a7-83b3-4850-9134-d716cf498910", () => ChangeContactAccount.EntitySchemaUId);
			MetaPathParameterValues.Add("2a3f5cb3-7035-42b2-9882-c80f7985168f", () => ChangeContactAccount.IsMatchConditions);
			MetaPathParameterValues.Add("0d8e007f-f368-46a3-840e-c8c133b97854", () => ChangeContactAccount.DataSourceFilters);
			MetaPathParameterValues.Add("c0fe375b-e8e3-406d-b4a8-8783f94f8903", () => ChangeContactAccount.RecordColumnValues);
			MetaPathParameterValues.Add("8304f870-e9a4-4099-a63d-64aa798ebd01", () => ChangeContactAccount.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("9e34dc39-7d39-421f-8d27-92a8af9a80c6", () => ChangeLeadStageHandoffToSale.EntitySchemaUId);
			MetaPathParameterValues.Add("bcf5b8fe-4737-4d4e-a037-b2c70a7900e8", () => ChangeLeadStageHandoffToSale.IsMatchConditions);
			MetaPathParameterValues.Add("bb68e8f2-44a8-4731-b948-176e754a5d8b", () => ChangeLeadStageHandoffToSale.DataSourceFilters);
			MetaPathParameterValues.Add("f994ffb6-8edf-41e3-892d-aa56db1c821b", () => ChangeLeadStageHandoffToSale.RecordColumnValues);
			MetaPathParameterValues.Add("ba4d4400-3b0e-4ac7-8f2e-29fe2a55e99e", () => ChangeLeadStageHandoffToSale.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6dd0bc3f-edfa-4078-87d0-79fe8307a8ab", () => LinkContactToLead.EntitySchemaUId);
			MetaPathParameterValues.Add("55ac08c6-ba80-4060-81f6-fb82943a2aa6", () => LinkContactToLead.IsMatchConditions);
			MetaPathParameterValues.Add("34908b60-ff49-4067-a7d9-fecfeba3d015", () => LinkContactToLead.DataSourceFilters);
			MetaPathParameterValues.Add("ee931748-590a-41b4-8229-e4dc1c8b23af", () => LinkContactToLead.RecordColumnValues);
			MetaPathParameterValues.Add("285ce719-432c-43ec-bc47-b74c40f38ded", () => LinkContactToLead.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("7b3e0e2a-6d32-492c-9290-46e7c194da0b", () => LinkAccountToLead.EntitySchemaUId);
			MetaPathParameterValues.Add("fbd3778b-b29e-4da4-878c-479ce66f6695", () => LinkAccountToLead.IsMatchConditions);
			MetaPathParameterValues.Add("e2572aab-9833-4451-bac3-3c93b4938008", () => LinkAccountToLead.DataSourceFilters);
			MetaPathParameterValues.Add("2c5dda1b-35c1-410a-8a66-b8e7dbef353d", () => LinkAccountToLead.RecordColumnValues);
			MetaPathParameterValues.Add("25eb3e31-0d50-498e-a470-de230ef082fb", () => LinkAccountToLead.ConsiderTimeInFilter);
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
			MetaPathParameterValues.Add("7b761d52-e117-4dc0-a0c4-c2846c0292bb", () => ReadSystemSettings.ResultCompositeObjectList);
			MetaPathParameterValues.Add("91d86af3-634e-48c9-b566-355568110d9f", () => ReadSystemSettings.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("2585e082-21c1-4b40-97bb-421446d5072b", () => ChangeLeadIsQualificationPassedTrue.EntitySchemaUId);
			MetaPathParameterValues.Add("8e537058-764d-485f-976a-f2c1892e719d", () => ChangeLeadIsQualificationPassedTrue.IsMatchConditions);
			MetaPathParameterValues.Add("7fa0d07d-a96d-43f6-8700-5d9b0a159e1c", () => ChangeLeadIsQualificationPassedTrue.DataSourceFilters);
			MetaPathParameterValues.Add("95da49a7-ccce-4ad9-befc-0d569ae20247", () => ChangeLeadIsQualificationPassedTrue.RecordColumnValues);
			MetaPathParameterValues.Add("cc4958aa-9cc3-4e6d-b485-82a192404f3c", () => ChangeLeadIsQualificationPassedTrue.ConsiderTimeInFilter);
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
				case "LeadQualificationPassed":
					if (!hasValueToRead) break;
					LeadQualificationPassed = reader.GetValue<System.Boolean>();
				break;
				case "LeadOwner":
					if (!hasValueToRead) break;
					LeadOwner = reader.GetValue<System.Guid>();
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
				SetValue(account, "OwnerId", LeadOwner);
				SetValue(account, "IndustryId", LeadIndustry);
				SetValue(account, "AccountCategoryId", LeadAccountCategory);
				SetValue(account, "EmployeesNumberId", LeadEmployeesNumber);
				SetValue(account, "AnnualRevenueId", LeadAnnualRevenue);
				account.UseAdminRights = false;
				account.Save(false);
				SyncAccountCommunications(account.Id);
				AccountId = accountId;
				AddAccountAddress(accountId);
			}
			
			
			public virtual void SetValue(Entity entity, string valueName, Object value) {
				if (value == null || Guid.Empty.Equals(value) || string.IsNullOrEmpty(value.ToString())) {
					return;
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
				SetValue(contact, "OwnerId", LeadOwner);
				SetValue(contact, "JobTitle", LeadFullJobTitle);
				SetValue(contact, "SalutationTypeId", LeadSalutation);
				SetValue(contact, "JobId", LeadJob);
				SetValue(contact, "DepartmentId", LeadDepartment);
				SetValue(contact, "GenderId", LeadGender);
				SetValue(contact, "DecisionRoleId", LeadDecisionRole);
				contact.Confirmed = true;
				contact.UseAdminRights = false;
				contact.Save(false);
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
					contactCommunication.Save(false);
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
					accountCommunication.Save(false);
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
				contactAddress.Save(false);
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
				accountAddress.Save(false);
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
			var cloneItem = (LeadManagementQualification10)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

