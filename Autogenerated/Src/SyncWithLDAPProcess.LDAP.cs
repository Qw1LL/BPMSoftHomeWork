namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.LDAP;
	using BPMSoft.Configuration.LDAPSysSettingsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities;
	using BPMSoft.Web.Common;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using SysSettings = BPMSoft.Core.Configuration.SysSettings;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.DirectoryServices.Protocols;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: SyncWithLDAPProcessSchema

	/// <exclude/>
	public class SyncWithLDAPProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SyncWithLDAPProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SyncWithLDAPProcessSchema(SyncWithLDAPProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SyncWithLDAPProcess";
			UId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,85,219,110,219,48,12,125,118,129,254,131,102,236,193,1,2,97,219,227,214,4,72,218,116,243,144,94,208,203,250,172,218,76,42,76,150,50,73,110,231,101,249,247,81,151,36,118,154,12,125,73,44,137,60,135,34,15,169,69,253,40,120,65,158,185,182,53,19,228,89,241,146,156,106,96,22,110,160,226,178,228,114,62,110,174,181,42,192,152,172,71,150,199,71,201,51,211,164,194,37,155,3,25,16,9,47,100,170,10,38,248,31,246,40,224,214,106,116,201,238,13,232,83,37,37,20,150,43,73,31,148,254,105,22,172,0,122,3,70,213,186,64,59,165,17,160,79,210,219,70,22,15,220,62,77,207,70,215,145,232,27,136,5,232,180,143,100,73,250,10,220,80,103,58,229,5,72,3,151,202,242,25,47,152,167,249,193,68,13,105,239,11,250,57,147,123,203,5,183,13,61,120,159,110,148,251,99,9,81,196,251,246,137,172,133,232,147,25,19,6,28,207,234,248,232,248,104,209,205,161,241,81,146,175,96,39,21,227,98,172,202,38,155,114,99,79,90,97,231,114,166,134,164,70,126,19,146,234,179,10,107,251,152,215,112,223,113,205,69,9,58,243,247,74,54,54,116,180,88,128,44,51,228,57,9,148,195,44,117,20,158,245,34,4,156,246,130,215,76,97,14,138,39,146,57,26,71,75,184,124,69,47,212,60,186,253,135,127,107,180,14,224,125,154,241,242,51,89,58,56,234,82,154,151,171,30,249,219,218,184,100,21,172,112,39,148,38,241,201,136,33,147,138,27,131,31,49,47,6,153,189,219,69,119,219,251,229,87,26,227,128,114,34,235,10,180,19,196,6,69,133,147,29,47,50,112,110,201,14,5,245,48,227,38,155,113,109,236,20,172,197,116,12,134,164,181,12,113,122,161,119,125,67,70,48,200,64,76,191,43,46,179,20,149,211,63,16,194,161,164,237,197,61,100,156,210,116,127,241,207,149,174,152,205,210,229,135,213,242,227,106,249,105,229,66,57,121,212,67,252,223,194,244,201,68,162,56,149,172,64,90,122,9,47,83,46,189,122,19,148,111,162,193,214,90,110,181,71,239,84,108,226,67,2,239,212,15,229,119,219,152,81,137,205,133,219,154,97,95,27,175,192,246,184,112,37,205,75,179,30,23,45,255,160,42,103,99,34,202,141,18,144,151,104,58,102,6,176,59,141,53,20,25,44,84,93,146,53,235,189,228,54,47,55,40,32,176,155,67,225,189,132,253,122,167,211,123,94,22,244,84,137,186,194,242,225,129,101,133,117,185,243,145,167,254,156,158,107,85,101,105,155,38,30,228,136,163,67,229,215,174,61,122,37,119,108,17,45,158,230,37,158,231,102,242,11,147,215,97,115,7,187,136,157,107,249,100,28,0,95,59,39,91,232,61,190,126,168,181,19,21,25,31,158,80,172,111,241,8,229,216,165,10,169,163,215,76,99,107,99,195,100,221,234,245,2,73,108,180,145,41,246,37,153,48,19,203,227,138,199,103,100,247,213,56,27,79,228,28,165,186,249,184,107,22,64,222,13,72,123,141,36,172,16,16,199,88,40,63,29,185,166,121,205,136,225,227,123,113,224,6,105,156,149,43,2,56,220,223,4,135,96,153,7,197,71,33,8,217,53,84,116,154,252,134,162,118,207,14,115,195,211,79,152,205,164,117,253,224,65,80,230,154,98,11,133,104,252,251,181,29,230,145,198,119,126,236,32,58,42,203,108,227,29,40,253,111,236,226,104,230,26,247,31,60,175,157,247,218,7,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617");
			Version = 0;
			PackageUId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e5c388b3-4785-4a2c-93b1-eb2829edce7e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("39bf6d5a-ff9c-4dc0-956a-35ae10d7f2e2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDoOpenListParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c4ff2517-a192-4965-8aef-e3dc495ae18d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"DoOpenList",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateShowLDAPMessageIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0e5163a5-e480-4e06-b4b9-8d121b6ab25b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ShowLDAPMessageId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"{83A1E9EA-651D-4600-B027-886C6EFA6524}",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNotLicensedUserNamesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6740fc54-80fe-4f42-acd8-d4ec48888997"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"NotLicensedUserNames",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c241e947-d0e3-48ca-b0eb-5109850b0a5f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"SyncResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNewUsersQuestionLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3eee1f90-cad9-48ab-9581-9a37ffd7cc9e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"NewUsersQuestionLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNotActiveUsersLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7c51318b-2807-4e95-8070-9952bce377ca"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"NotActiveUsersLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNewUsersInGroupLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("79cfd16f-6f0a-4429-8b33-20efbd7074bb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"NewUsersInGroupLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateProcessSynchWithLDAPLaunchedLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f4fa0f38-8445-4c0a-872a-08444b3b1da4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ProcessSynchWithLDAPLaunchedLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateErrorCheckRequiredLDAPSettingsLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c1351620-72ca-42c4-b8b1-b83dbf2f79a8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ErrorCheckRequiredLDAPSettingsLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLDAPUsersWereAddedLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3ff56a7f-b43f-454e-8320-db273d793916"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"LDAPUsersWereAddedLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateServerErrorLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ff35025d-d1a8-48b1-9355-f8a23f7413cb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ServerErrorLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateProcessEndedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("83c82239-ffec-4409-9bf6-9b8de6528de7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ProcessEnded",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateMessageLogParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fcf94a88-a3b6-4d21-a997-00a81b8c55c3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"MessageLog",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNoAccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ece68291-3e57-4d5a-a686-ac986c534ae8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("97916cee-c1a7-4a71-815d-9d80f3965c04"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"NoAccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateInvalidCredentialsErrorCodeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("eb1d1d1a-09c4-4cdc-ae6d-3cbc3d8c345c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"InvalidCredentialsErrorCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"49",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateInvalidCredentialMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e410db97-07f1-42a9-97c3-499e34692d6d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"InvalidCredentialMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateConnectionNotEstablishedMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f6d1588b-7930-4f8e-9038-661abad4372d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ConnectionNotEstablishedMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateErrorSyncResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a9370089-7daf-4b16-b51c-855fb82d5532"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ErrorSyncResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailSubjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("aeb1a392-036e-4295-8e8d-f388946495a5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"EmailSubject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailBodyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d7e3ec26-8976-4d26-a926-b73e739132ba"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"EmailBody",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRecipientEmailsStringParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6d9613e-c931-45a4-8289-34a64d103e30"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"RecipientEmailsString",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLDAPEmailMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2d31abe5-21af-4461-8c88-14c9cb2e037d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"LDAPEmailMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateDoOpenListParameter());
			Parameters.Add(CreateShowLDAPMessageIdParameter());
			Parameters.Add(CreateNotLicensedUserNamesParameter());
			Parameters.Add(CreateSyncResultParameter());
			Parameters.Add(CreateNewUsersQuestionLSParameter());
			Parameters.Add(CreateNotActiveUsersLSParameter());
			Parameters.Add(CreateNewUsersInGroupLSParameter());
			Parameters.Add(CreateProcessSynchWithLDAPLaunchedLSParameter());
			Parameters.Add(CreateErrorCheckRequiredLDAPSettingsLSParameter());
			Parameters.Add(CreateLDAPUsersWereAddedLSParameter());
			Parameters.Add(CreateServerErrorLSParameter());
			Parameters.Add(CreateProcessEndedParameter());
			Parameters.Add(CreateMessageLogParameter());
			Parameters.Add(CreateNoAccessMessageParameter());
			Parameters.Add(CreateInvalidCredentialsErrorCodeParameter());
			Parameters.Add(CreateInvalidCredentialMessageParameter());
			Parameters.Add(CreateConnectionNotEstablishedMessageParameter());
			Parameters.Add(CreateErrorSyncResultParameter());
			Parameters.Add(CreateEmailSubjectParameter());
			Parameters.Add(CreateEmailBodyParameter());
			Parameters.Add(CreateRecipientEmailsStringParameter());
			Parameters.Add(CreateLDAPEmailMessageParameter());
		}

		protected virtual void InitializeEmailSendUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ca308d49-70ae-4ee3-a7a6-576b39d0906d"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Send email 1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("9e636c72-feec-443d-80db-bbb11ca74373"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.961e2086-a12b-4d27-b095-40b1e64d6cc0.8038a396-7825-e011-8165-00155d043204#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("20c028fe-7707-4d7c-8ae9-cf1c90b232e7"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6194902c-224f-4855-9b2a-9d91ea50a55e"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fb8728ed-a9ef-4b57-8aa7-37c3bac33e7b"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a2c18195-1b0e-4559-8052-817ae92fd235"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3c731905-eb35-44ed-b3ca-dd1c63b9398b"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("22574204-b989-403f-aa68-6db44ddef273"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e151f18-e3c4-4475-aa5b-5dbaefa7a649"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7c910dbb-c563-4a34-acf6-c6a467c05210"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("13944a4c-7072-43a9-b1f5-b83b8de6253b"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97b9f11a-d877-4fb1-a48a-d0b0ca01eb23"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("83a900f2-650d-4af8-8b42-4730bdc2076e"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("b96b1ca6-35c7-4f2b-9344-720c982df478"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("396fe566-406a-403f-a5a5-6af7e082deb9"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("92959022-75ae-442f-86ef-9b01c388c38c"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				UId = new Guid("959b81bb-3ff0-43ae-9129-2f50675fc64d"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3b18e768-4724-4d67-836a-cc1b4310b25e"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("68f42e26-155e-4df5-9df2-41543aca9a91"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				UId = new Guid("73127a7c-1289-4e1b-8116-dc1191419c44"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var activityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7422cc60-2798-4064-84f0-b61ff20194c6"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"ActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityIdParameter.SourceValue = new ProcessSchemaParameterValue(activityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityIdParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6aa36187-c640-44b8-a099-21d088d631b1"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"IsActivityCompleted",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isActivityCompletedParameter.SourceValue = new ProcessSchemaParameterValue(isActivityCompletedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("131c861e-e4b5-4cb8-add0-76db6ac463ed"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("883ae716-c06b-41a5-a98f-cea9cde03256"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				UId = new Guid("334b7e03-c84d-46cc-ae02-30e60226da8a"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var contractParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("703db63c-a4c5-4d00-99aa-8886e6f8ad64"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("26810327-3097-4fe8-a1a1-66a1d38d218a"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2f922d07-1465-46ff-89a8-6baac78050de"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("77526092-2a5c-4e11-865e-760b484d2d5e"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var projectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("50d6e9c3-54bb-4a5a-afc0-2c939d94b1b4"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var problemParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b82ba56c-dfcc-46d3-a733-b779b91d801b"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				UId = new Guid("5acd32c6-85a3-4f51-8f40-b4528de854c7"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				UId = new Guid("533b40fc-4e3e-4725-acf6-d5d6f8a2c575"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
			var queueItemParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("00c6d940-fd61-4cf6-9434-c51565909d13"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"QueueItem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			queueItemParameter.SourceValue = new ProcessSchemaParameterValue(queueItemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(queueItemParameter);
			var senderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				UId = new Guid("db07491a-f5b1-439c-97a1-6af53ce909cd"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Sender",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			senderParameter.SourceValue = new ProcessSchemaParameterValue(senderParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysSettings.LDAPLogNotificationSender<Guid>#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(senderParameter);
			var importanceParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("953f4a27-0013-452f-8b74-5d28dbcbf8c6"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Importance",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			importanceParameter.SourceValue = new ProcessSchemaParameterValue(importanceParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(importanceParameter);
			var subjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b760a46f-1ff5-4b25-9a6f-af792f81b239"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Subject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			subjectParameter.SourceValue = new ProcessSchemaParameterValue(subjectParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{aeb1a392-036e-4295-8e8d-f388946495a5}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(subjectParameter);
			var ignoreErrorsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2a57e59-b1eb-4aaf-81ec-1719d9392746"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"IgnoreErrors",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreErrorsParameter.SourceValue = new ProcessSchemaParameterValue(ignoreErrorsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(ignoreErrorsParameter);
			var sendEmailTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b138f1ee-5c36-4c42-9abb-c1cd87be5b8e"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"SendEmailType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			sendEmailTypeParameter.SourceValue = new ProcessSchemaParameterValue(sendEmailTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(sendEmailTypeParameter);
			var bodyTemplateTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9c010bb6-8599-403e-b457-54ab13ff4c91"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"BodyTemplateType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			bodyTemplateTypeParameter.SourceValue = new ProcessSchemaParameterValue(bodyTemplateTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(bodyTemplateTypeParameter);
			var emailTemplateIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				UId = new Guid("09a73a34-9036-48e9-9e48-78e8873369b7"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"EmailTemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			emailTemplateIdParameter.SourceValue = new ProcessSchemaParameterValue(emailTemplateIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(emailTemplateIdParameter);
			var emailTemplateEntityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95428372-753c-42d5-b08f-5a8e7695dfa8"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"EmailTemplateEntityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			emailTemplateEntityIdParameter.SourceValue = new ProcessSchemaParameterValue(emailTemplateEntityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(emailTemplateEntityIdParameter);
			var bodyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("126ba0f1-9346-426c-865c-079a6d0e9101"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = true,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"Body",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			bodyParameter.SourceValue = new ProcessSchemaParameterValue(bodyParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,88,91,111,219,54,20,126,223,175,96,21,12,104,7,211,178,115,143,28,7,219,210,12,11,176,173,69,151,98,27,130,60,80,18,109,115,161,68,149,162,111,245,252,223,119,72,74,50,117,113,146,110,47,3,214,34,137,120,72,158,251,249,14,201,203,87,111,223,93,223,253,241,254,6,205,84,194,209,251,143,223,255,116,123,141,60,236,251,191,29,93,251,254,219,187,183,232,247,31,239,126,254,9,13,251,3,116,39,73,154,51,197,68,74,184,239,223,252,226,33,111,166,84,22,248,254,114,185,236,47,143,250,66,78,253,187,15,254,74,243,26,234,205,197,39,86,206,206,126,172,98,239,234,82,79,192,111,74,226,171,203,132,42,2,10,168,12,211,79,115,182,24,123,215,34,85,52,85,248,110,157,81,15,69,118,52,246,20,93,41,95,111,28,161,104,70,100,78,213,248,227,221,15,248,220,243,11,30,153,20,25,149,106,61,246,196,52,80,76,113,119,119,181,42,37,9,29,123,11,70,151,153,144,202,89,177,100,177,154,141,99,186,96,17,197,102,208,99,41,168,77,56,206,35,194,233,120,88,241,112,181,253,29,127,252,14,95,139,36,35,138,133,53,145,183,55,99,26,79,169,222,101,180,185,186,244,139,191,185,90,115,138,20,216,87,152,21,229,185,119,117,32,230,138,11,241,136,200,38,35,113,204,210,105,48,216,134,34,94,111,140,54,193,112,48,248,250,21,75,180,218,36,85,219,254,7,112,223,207,249,244,251,250,138,109,255,102,165,168,4,95,95,115,146,231,251,103,122,245,33,138,217,162,73,154,128,41,77,90,214,36,228,25,73,155,52,21,111,56,75,41,158,81,54,157,41,43,157,244,66,46,162,199,79,115,161,104,79,155,213,227,172,151,245,20,1,175,245,96,3,94,210,240,145,41,172,29,130,115,246,153,98,18,255,57,207,237,238,17,78,242,61,51,73,46,176,35,12,203,57,167,1,93,145,72,241,245,182,226,174,87,153,1,230,160,112,68,131,193,104,71,146,37,41,20,50,166,18,235,161,227,254,132,200,41,75,97,122,23,22,150,76,55,118,49,144,155,166,142,116,32,129,6,83,70,229,152,70,66,66,122,136,52,72,69,74,141,45,12,146,68,102,130,27,50,78,68,76,131,144,69,115,248,217,146,251,21,38,89,6,122,197,68,17,216,173,104,164,132,204,31,54,145,224,66,6,44,157,81,201,212,46,21,58,165,56,211,58,140,198,111,29,91,205,220,132,36,140,175,247,205,46,173,101,237,89,215,238,214,172,117,125,225,36,12,154,115,146,229,52,40,63,154,11,117,202,236,91,107,163,224,56,216,209,161,29,155,81,103,181,124,155,208,152,17,36,82,190,70,121,36,41,77,17,73,99,244,58,33,43,91,236,193,241,249,32,91,189,217,244,19,17,230,51,177,220,196,44,207,56,89,7,70,61,71,162,88,80,57,225,98,25,44,88,174,43,222,45,201,84,192,238,106,103,35,12,86,204,192,161,20,38,57,164,109,191,128,15,108,138,101,179,11,221,240,52,91,237,71,131,81,194,82,220,105,56,100,106,127,194,233,74,171,138,89,66,166,180,244,36,153,43,209,82,175,229,222,85,55,219,127,92,205,117,167,108,159,12,140,11,198,85,124,254,111,14,170,27,172,235,100,39,207,17,127,58,0,247,56,138,89,172,56,56,62,62,174,213,56,145,208,208,122,51,202,23,84,177,136,244,114,232,205,56,135,210,157,56,48,49,60,206,86,141,234,54,141,208,113,226,161,22,55,218,91,177,45,165,17,65,253,53,212,149,84,209,92,65,239,105,207,7,32,240,177,115,66,23,154,162,113,1,127,7,71,167,23,53,96,58,30,180,113,118,158,130,94,218,130,14,77,52,118,151,37,202,82,189,104,228,4,124,219,215,103,12,76,57,77,96,151,110,119,134,247,110,156,85,161,179,216,131,67,58,17,82,131,125,131,78,38,0,241,109,114,174,136,84,109,50,77,99,221,147,10,56,219,246,115,154,17,48,70,200,82,116,175,77,194,75,9,141,130,202,90,147,103,211,20,212,169,98,210,66,213,130,75,13,183,98,154,63,42,145,225,144,68,143,83,41,192,123,155,221,103,145,19,134,57,192,27,131,50,121,98,29,52,209,29,69,210,140,18,157,210,197,87,197,0,226,153,212,112,114,100,208,148,113,166,214,78,22,57,171,209,55,166,135,207,24,116,74,194,57,132,105,29,74,22,215,57,217,118,30,81,61,95,218,180,119,65,56,87,10,122,111,225,203,70,74,216,116,233,236,172,213,78,53,219,52,242,240,11,218,204,11,92,94,235,11,207,123,190,121,62,236,114,117,113,222,17,75,7,41,28,207,23,45,109,175,227,27,216,212,237,227,230,34,55,80,208,59,53,236,112,76,56,228,105,0,123,159,1,216,109,159,196,36,83,108,1,166,27,175,247,118,4,3,214,206,88,7,171,27,252,187,1,189,17,148,110,161,58,13,28,25,249,140,82,181,217,191,115,27,4,101,97,67,252,33,145,67,34,43,192,208,197,10,181,151,194,89,211,228,124,169,43,32,105,117,186,129,38,214,193,2,114,109,158,132,78,200,131,131,56,212,255,95,144,113,167,103,54,227,138,172,157,17,62,209,25,208,157,240,118,203,73,45,4,47,144,113,120,113,248,164,12,151,121,35,192,219,75,223,220,135,224,122,100,47,132,186,89,34,78,39,202,130,225,216,27,120,200,126,218,43,154,30,67,226,180,102,173,11,13,65,76,38,250,126,168,63,13,239,177,87,2,43,92,62,237,121,211,194,162,89,162,225,160,56,62,86,227,226,10,96,198,37,99,173,184,135,10,37,236,160,224,190,175,15,106,105,18,126,160,139,233,124,31,123,17,32,13,149,30,90,20,99,176,3,214,188,194,248,158,77,208,235,169,162,8,106,13,93,188,249,235,245,237,205,155,135,82,215,66,36,180,248,231,149,221,217,85,202,6,254,247,208,93,216,228,1,227,202,250,169,105,166,99,239,96,98,254,1,31,125,113,27,123,245,68,175,12,252,239,31,57,218,158,168,121,106,8,4,22,67,164,170,10,186,211,142,216,5,168,30,145,154,223,109,168,159,115,124,225,192,70,251,245,174,208,165,210,25,173,255,74,253,171,33,10,117,202,234,228,133,90,61,224,89,173,218,210,43,129,133,12,83,153,186,86,221,212,121,214,88,87,219,43,100,153,183,108,43,87,157,156,239,234,176,11,116,42,123,171,99,184,62,179,17,152,151,200,105,30,218,152,23,86,138,245,226,19,53,247,197,101,228,148,208,147,90,196,165,161,229,125,20,157,64,210,238,92,113,54,104,40,210,96,109,205,40,22,104,16,252,162,176,84,96,87,150,40,184,30,196,183,187,174,3,197,79,85,84,3,19,236,17,186,29,37,175,35,189,10,85,254,53,38,152,19,152,213,91,187,99,180,4,109,205,185,55,8,37,37,143,88,143,45,209,140,93,106,217,69,103,235,108,70,211,220,180,127,120,124,17,159,235,20,119,80,207,217,23,150,124,237,0,130,94,0,0,141,20,209,25,82,124,99,109,99,141,32,13,26,186,20,8,95,109,28,10,232,185,137,33,117,188,200,52,243,222,170,236,222,105,180,134,112,39,130,164,131,30,119,127,112,147,16,198,145,126,85,60,120,240,144,121,130,178,47,149,239,165,136,104,158,191,135,19,12,188,130,234,138,50,147,192,126,14,179,247,7,247,183,249,187,37,100,195,175,209,140,38,36,152,16,158,211,135,62,80,27,132,138,65,176,137,207,232,17,141,14,79,241,249,197,217,41,62,142,225,139,92,192,175,240,236,136,158,29,93,12,143,14,67,178,125,208,122,148,61,248,228,188,217,147,134,23,253,179,243,225,238,8,117,114,158,173,118,0,53,188,128,247,215,175,46,51,56,93,100,87,95,33,120,130,213,41,234,155,72,248,101,92,124,147,178,87,205,217,130,184,191,218,245,242,151,34,131,102,90,242,172,239,49,66,11,169,123,117,121,90,211,250,172,213,171,46,240,105,27,246,41,119,25,74,120,189,110,47,241,141,64,56,176,233,119,252,191,1,52,104,132,124,71,24,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(bodyParameter);
			var bodyConfigParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c828d5b0-a444-4243-a108-cd25dd3dd2a0"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = true,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Name = @"BodyConfig",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			bodyConfigParameter.SourceValue = new ProcessSchemaParameterValue(bodyConfigParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,77,111,194,48,12,253,43,85,184,82,190,10,180,116,12,105,160,29,56,13,141,73,59,20,14,166,49,109,69,218,68,77,24,32,196,127,159,147,193,132,134,214,67,107,191,103,63,187,182,207,108,110,176,252,56,41,100,49,211,57,162,97,77,54,3,101,10,89,17,50,147,149,193,202,120,28,117,145,85,88,19,105,227,53,139,147,243,125,230,70,200,116,247,31,105,240,232,84,165,216,151,36,218,105,178,119,121,112,95,130,150,10,8,235,245,29,248,227,56,194,213,165,228,113,81,102,30,8,243,188,98,73,227,181,132,66,120,83,201,79,141,245,138,121,169,0,173,137,32,147,131,1,223,80,61,114,23,181,76,81,235,5,212,80,162,193,250,70,127,129,216,91,62,105,36,115,253,118,160,223,89,166,57,150,16,111,65,104,92,183,8,253,3,252,74,196,103,30,98,128,105,111,232,71,163,112,232,247,57,89,48,162,215,38,12,48,12,70,221,160,183,129,203,218,181,149,99,145,229,182,225,65,68,158,54,39,97,171,30,10,110,242,216,235,118,71,173,48,234,170,227,211,53,46,246,6,17,121,20,233,34,40,146,66,200,107,79,86,213,88,77,198,109,69,6,141,111,105,117,104,182,103,166,128,243,162,202,124,129,91,59,161,129,58,18,125,3,107,171,249,128,26,169,30,176,141,52,70,150,87,248,114,89,223,149,112,222,167,109,135,197,195,14,237,99,10,233,46,171,229,190,226,180,50,89,83,82,99,235,30,219,152,189,154,23,65,247,65,112,74,91,115,103,50,173,17,118,74,22,149,185,234,244,163,206,229,27,177,2,245,144,110,2,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(bodyConfigParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("51944a09-9fbc-495d-8105-c8c1638523ef"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
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
				ModifiedInSchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var recipient1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("b976035c-f70e-41b8-b529-d345c403d06c"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"Recipient1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			recipient1Parameter.SourceValue = new ProcessSchemaParameterValue(recipient1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e6d9613e-c931-45a4-8289-34a64d103e30}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(recipient1Parameter);
			var omniChatParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				UId = new Guid("48c8cbfc-612a-4dab-b34f-c3eb75382329"),
				ContainerUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"OmniChat",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			omniChatParameter.SourceValue = new ProcessSchemaParameterValue(omniChatParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(omniChatParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet62 = CreateLaneSet62LaneSet();
			LaneSets.Add(schemaLaneSet62);
			ProcessSchemaLane schemaLane166 = CreateLane166Lane();
			schemaLaneSet62.Lanes.Add(schemaLane166);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask usersautoimportscripttask = CreateUsersAutoImportScriptTaskScriptTask();
			FlowElements.Add(usersautoimportscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaScriptTask noaccessscripttask = CreateNoAccessScriptTaskScriptTask();
			FlowElements.Add(noaccessscripttask);
			ProcessSchemaScriptTask insertldapelementsscripttask = CreateInsertLDAPElementsScriptTaskScriptTask();
			FlowElements.Add(insertldapelementsscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaUserTask emailsendusertask = CreateEmailSendUserTaskUserTask();
			FlowElements.Add(emailsendusertask);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			FlowElements.Add(CreateSequenceFlow541SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow541SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow541",
				UId = new Guid("d17d7a27-d07d-4922-9850-83e6c388d3cb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(130, 198),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d9b99a5-0778-4b16-90d6-7a385850e5cd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e5d193f0-85fe-4fd8-8ab4-8c85dbf6a304"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("4fa1d705-682f-4a80-aa72-3cedba1f4704"),
				ConditionExpression = @"UserConnection.DBSecurityEngine.GetCanExecuteOperation(""CanManageAdministration"")",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("97916cee-c1a7-4a71-815d-9d80f3965c04"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(298, 198),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e5d193f0-85fe-4fd8-8ab4-8c85dbf6a304"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("214f1782-408b-45a3-a66f-305ae7b2d818"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow2",
				UId = new Guid("4710cdc7-9c8a-481e-a7c0-b06862a27748"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("97916cee-c1a7-4a71-815d-9d80f3965c04"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(294, 142),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e5d193f0-85fe-4fd8-8ab4-8c85dbf6a304"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f80232b1-1c8f-416a-a6b8-7c40d3e44979"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(133, 113));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("2c194e57-1aba-40e3-9118-ded5469ab527"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("97916cee-c1a7-4a71-815d-9d80f3965c04"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(650, 137),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f80232b1-1c8f-416a-a6b8-7c40d3e44979"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6dce4d8c-057f-42ab-b2b1-ac53ac170c3e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1147, 113));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("b20b8d2d-d2aa-4d3d-b7b5-8e8e2abb02c9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("214f1782-408b-45a3-a66f-305ae7b2d818"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("233b45df-488c-4522-9045-2ed5b9134d61"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("2501ba77-13f6-4274-8b23-c777ef76faf0"),
				ConditionExpression = @"string.IsNullOrEmpty([#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c241e947-d0e3-48ca-b0eb-5109850b0a5f}]#])",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("233b45df-488c-4522-9045-2ed5b9134d61"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0efac1d8-6a81-4348-ad2a-9a2f49b1cbe0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("7333476f-2abe-4077-837e-624d27d28899"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("233b45df-488c-4522-9045-2ed5b9134d61"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6dce4d8c-057f-42ab-b2b1-ac53ac170c3e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(493, 467));
			schemaFlow.PolylinePointPositions.Add(new Point(1147, 467));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("bf0c8218-90dd-4e90-86d9-ba9f09e1e37f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0efac1d8-6a81-4348-ad2a-9a2f49b1cbe0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dcdec0b2-6fc0-412a-917b-cf38319bc27f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("3ba25dcf-2521-41cf-869e-28bff4f7b03d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dcdec0b2-6fc0-412a-917b-cf38319bc27f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6dce4d8c-057f-42ab-b2b1-ac53ac170c3e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(773, 336));
			schemaFlow.PolylinePointPositions.Add(new Point(1147, 336));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("02614f52-5d70-40a3-a124-8e4425535446"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d7e3ec26-8976-4d26-a926-b73e739132ba}]#] != null && [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d7e3ec26-8976-4d26-a926-b73e739132ba}]#].Length > 0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dcdec0b2-6fc0-412a-917b-cf38319bc27f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("df0b2e37-bec2-4692-b9be-a45e60c1d5ed"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6dce4d8c-057f-42ab-b2b1-ac53ac170c3e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet62LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet62 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("963140b4-7029-452f-a00d-20f3514133d6"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"LaneSet62",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet62;
		}

		protected virtual ProcessSchemaLane CreateLane166Lane() {
			ProcessSchemaLane schemaLane166 = new ProcessSchemaLane(this) {
				UId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("963140b4-7029-452f-a00d-20f3514133d6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"Lane166",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane166;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("3d9b99a5-0778-4b16-90d6-7a385850e5cd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"Start1",
				Position = new Point(36, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("6dce4d8c-057f-42ab-b2b1-ac53ac170c3e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"End1",
				Position = new Point(1133, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateUsersAutoImportScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("0efac1d8-6a81-4348-ad2a-9a2f49b1cbe0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"UsersAutoImportScriptTask",
				Position = new Point(620, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,209,110,218,64,16,124,54,82,254,97,227,135,200,72,200,244,29,181,82,66,81,170,202,169,34,220,132,231,139,189,192,54,230,206,221,187,43,117,171,254,123,247,124,38,20,36,42,25,201,236,205,206,204,206,158,167,83,152,111,177,122,133,226,227,237,35,88,116,142,244,198,94,141,104,13,217,117,81,171,246,201,81,67,142,208,230,61,110,137,223,61,49,214,1,94,14,232,236,201,34,207,141,214,88,57,50,122,60,134,223,87,163,164,236,116,181,68,235,27,7,239,97,193,108,248,34,65,81,206,164,193,109,217,236,65,227,30,22,63,43,108,3,85,118,36,25,11,228,207,213,104,58,133,80,139,118,189,232,138,215,31,138,193,74,113,69,110,27,234,143,108,42,180,246,19,54,45,178,136,7,202,242,210,249,185,121,145,185,200,149,255,203,146,5,232,201,144,3,118,161,107,172,103,209,86,112,88,144,13,167,151,89,239,209,5,19,54,156,62,144,181,18,73,65,21,106,139,182,23,161,117,118,224,201,231,198,107,7,31,224,93,12,57,104,236,89,181,255,29,244,1,221,214,212,118,21,113,153,219,146,13,180,201,208,152,207,25,149,195,37,238,72,215,162,125,215,13,125,189,120,18,110,66,217,217,195,174,242,175,220,137,225,103,213,120,60,203,110,2,105,80,45,204,230,139,113,180,166,74,133,106,137,146,7,167,19,48,222,65,240,203,113,159,16,39,232,249,99,9,174,101,4,223,52,112,115,3,217,189,167,122,12,199,131,240,63,95,236,90,215,13,125,201,98,167,168,41,253,203,55,81,31,134,47,76,165,26,250,165,94,26,44,29,139,221,51,135,249,202,240,171,109,85,133,185,108,205,120,174,4,103,88,109,112,210,83,38,233,197,123,146,134,233,206,233,173,56,58,154,200,251,80,210,62,181,193,222,157,169,59,241,118,72,90,130,123,43,191,237,116,192,199,104,42,106,9,117,68,217,211,78,89,194,109,45,59,146,22,86,226,218,70,80,220,82,146,44,79,123,163,193,112,239,250,151,252,179,33,157,165,51,25,227,76,36,182,203,167,21,126,242,48,58,207,26,28,123,156,253,5,62,157,81,226,30,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("e5d193f0-85fe-4fd8-8ab4-8c85dbf6a304"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("97916cee-c1a7-4a71-815d-9d80f3965c04"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ExclusiveGateway1",
				Position = new Point(105, 163),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateNoAccessScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("f80232b1-1c8f-416a-a6b8-7c40d3e44979"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("97916cee-c1a7-4a71-815d-9d80f3965c04"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"NoAccessScriptTask",
				Position = new Point(251, 85),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,174,204,75,14,74,45,46,205,41,81,176,85,240,203,119,76,78,78,45,46,246,5,226,196,244,84,107,94,174,178,196,34,133,156,252,116,160,156,79,126,186,111,98,30,80,180,72,207,61,181,4,200,3,178,52,148,124,92,28,3,148,52,129,10,129,138,244,92,82,147,74,211,53,130,225,38,130,196,139,82,75,74,139,242,20,74,138,74,83,173,1,251,185,135,195,108,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateInsertLDAPElementsScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("214f1782-408b-45a3-a66f-305ae7b2d818"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"InsertLDAPElementsScriptTask",
				Position = new Point(340, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,65,106,195,48,16,69,215,54,248,14,67,86,10,20,95,32,100,81,82,167,4,156,82,106,122,0,213,158,218,2,69,10,51,99,167,166,228,238,149,226,208,36,52,139,238,36,253,255,102,254,215,160,9,172,111,97,9,165,111,183,218,233,22,41,127,70,9,183,112,82,179,242,233,241,117,54,95,100,169,208,8,223,89,154,12,17,104,244,190,66,26,76,141,1,116,120,128,104,171,70,174,80,196,184,150,207,162,138,96,114,229,206,55,142,145,36,186,11,139,59,116,194,234,61,188,172,188,115,88,139,241,46,18,71,168,181,212,29,168,50,144,197,87,141,251,168,0,206,79,1,204,39,40,204,11,34,31,176,38,4,88,194,198,13,218,154,102,69,216,132,145,70,91,254,149,39,38,169,70,87,191,33,247,86,224,142,125,139,204,161,120,12,123,4,180,140,119,160,75,196,23,47,5,139,254,176,134,59,108,174,217,88,214,183,83,54,117,161,31,66,244,168,75,71,254,112,221,239,79,183,155,141,44,20,254,50,95,123,218,105,81,167,161,55,51,243,243,234,233,147,255,179,55,75,9,165,39,7,66,61,46,126,0,21,40,86,27,251,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("233b45df-488c-4522-9045-2ed5b9134d61"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ExclusiveGateway2",
				Position = new Point(465, 163),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateEmailSendUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"EmailSendUserTask",
				Position = new Point(971, 163),
				SchemaUId = new Guid("184dbb27-ce13-4d37-8dff-c2ff1df9cf19"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeEmailSendUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("dcdec0b2-6fc0-412a-917b-cf38319bc27f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e8dca88-60d7-4e46-8c62-837a3d952b4c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999"),
				CreatedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				Name = @"ExclusiveGateway3",
				Position = new Point(745, 163),
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

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("965baacf-c7aa-4161-a95e-2c2d7b8f4cbb"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1330ddd7-eaaa-4ca5-ab7c-57899370ec73"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3609334e-ba40-4df8-9807-fb41f44bfe91"),
				Name = "BPMSoft.Core.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("0ec5cb84-ec2a-43e2-819e-d638446aaf82"),
				Name = "System.DirectoryServices.Protocols",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("27850d19-dcd3-49e7-bdaa-192704764402"),
				Name = "BPMSoft.UI.WebControls.Controls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2fa6ea01-2c71-41e2-9c20-f42ca8fd5671"),
				Name = "BPMSoft.UI.WebControls.Utilities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("754b28c5-0a4a-42df-b596-d8563d7096d3"),
				Name = "BPMSoft.Web.Common",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9390cd3c-c416-4c74-95e9-5b85e347b815"),
				Name = "BPMSoft.Configuration.LDAP",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ac0921a0-6982-4abc-bdd3-4bac6be144f2"),
				Name = "global::Common.Logging",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2419d58a-33e7-4a62-b2b1-40e95835c2cf"),
				Name = "BPMSoft.Configuration.LDAPSysSettingsService",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7d24f034-b91f-4fdd-967f-79621e7072ce"),
				Name = "BPMSoft.Core.Configuration.SysSettings",
				Alias = "SysSettings",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a2de64c7-a361-4b8f-81a1-165cd75e35d7"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SyncWithLDAPProcess(userConnection);
		}

		public override object Clone() {
			return new SyncWithLDAPProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncWithLDAPProcessMethodsWrapper

	/// <exclude/>
	public class SyncWithLDAPProcessMethodsWrapper : ProcessModel
	{

		public SyncWithLDAPProcessMethodsWrapper(Process process)
			: base(process) {
		}

		#region Methods: Private

			public virtual void CreateRemindingByProcess() {
				var message = new LocalizableString(UserConnection.Workspace.ResourceStorage, "SyncWithLDAPProcessHelper",
					"LocalizableStrings.LDAPLicenseNotification.Value");
				LDAPUtility.CreateRemindingByProcess(UserConnection, "SyncWithLDAPProcess",
					message, null, false);
			}
			
			public virtual string GetEmailBody(List<LDAPLicenseInfo> users) {
					var emailBody = new StringBuilder();
					emailBody.Append(Get<string>("LDAPEmailMessage"));
					foreach (var user in users) {
					var logMessage = new StringBuilder();
					logMessage.Append($"(id: {user.UserId}) | {user.UserName} | ");
					List<string> missingLicenses = user.MissingLicenses;
					IOrderedEnumerable<string> orderedMissingLicenses =
						missingLicenses.OrderBy(firstLetter => firstLetter);
					var missingLicensesString = string.Join(", ", orderedMissingLicenses);
					logMessage.Append(missingLicensesString);
					logMessage.Append(".");
					emailBody.AppendFormat("{0}{1}{2}", "<br>", logMessage, Environment.NewLine);
				}
				return emailBody.ToString();
			}
			
			public virtual List<string> GetSysAdministratorsEmails() {
				var userIds = new List<string>();
				var sysAdminRoleId = BaseConsts.SystemAdministratorsSysAdminUnitId;
				var select =
					new Select(UserConnection)
						.Column("Contact", "Email")
					.From("SysAdminUnit")
					.InnerJoin("Contact").On("SysAdminUnit", "ContactId").IsEqual("Contact", "Id")
					.InnerJoin("SysAdminUnitInRole").On("SysAdminUnit", "Id")
						.IsEqual("SysAdminUnitInRole", "SysAdminUnitId")
					.Where("SysAdminUnitInRole", "SysAdminUnitRoleId")
						.IsEqual(Column.Parameter(sysAdminRoleId))
					.OrderByAsc("Contact", "Email") as Select;
				if (UserConnection.DBEngine.DBEngineType != DBEngineType.Oracle) {
					select.And("Contact", "Email").IsNotEqual(Column.Parameter(""));
				} else {
					select.And("Contact", "Email").Not().IsNull();
				}
				select.ExecuteReader(r => {
					var userEmail = r.GetColumnValue<string>("Email");
					userIds.Add(userEmail);
				});
				return userIds;
			}

		#endregion

	}

	#endregion

	#region Class: SyncWithLDAPProcess

	/// <exclude/>
	public class SyncWithLDAPProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane166

		/// <exclude/>
		public class ProcessLane166 : ProcessLane
		{

			public ProcessLane166(UserConnection userConnection, SyncWithLDAPProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: EmailSendUserTaskFlowElement

		/// <exclude/>
		public class EmailSendUserTaskFlowElement : EmailTemplateUserTask
		{

			#region Constructors: Public

			public EmailSendUserTaskFlowElement(UserConnection userConnection, SyncWithLDAPProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "EmailSendUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("39fd1969-f920-4b4f-8953-8d8f00efac7c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane166;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_sender = () => (Guid)(((Guid)SysSettings.GetValue(UserConnection, "LDAPLogNotificationSender")));
				_subject = () => new LocalizableString((process.EmailSubject));
				_recipient1 = () => new LocalizableString((process.RecipientEmailsString));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "BaseElements.EmailSendUserTask.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
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

			private int _duration = 5;
			public override int Duration {
				get {
					return _duration;
				}
				set {
					_duration = value;
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

			private int _startIn = 0;
			public override int StartIn {
				get {
					return _startIn;
				}
				set {
					_startIn = value;
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

			private int _remindBefore = 0;
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

			private bool _showInScheduler = false;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			private bool _showExecutionPage = true;
			public override bool ShowExecutionPage {
				get {
					return _showExecutionPage;
				}
				set {
					_showExecutionPage = value;
				}
			}

			internal Func<Guid> _sender;
			public override Guid Sender {
				get {
					return (_sender ?? (_sender = () => Guid.Empty)).Invoke();
				}
				set {
					_sender = () => { return value; };
				}
			}

			private int _importance = 1;
			public override int Importance {
				get {
					return _importance;
				}
				set {
					_importance = value;
				}
			}

			internal Func<LocalizableString> _subject;
			public override LocalizableString Subject {
				get {
					return (_subject ?? (_subject = () => null)).Invoke();
				}
				set {
					_subject = () => { return value; };
				}
			}

			private bool _ignoreErrors = true;
			public override bool IgnoreErrors {
				get {
					return _ignoreErrors;
				}
				set {
					_ignoreErrors = value;
				}
			}

			private int _sendEmailType = 0;
			public override int SendEmailType {
				get {
					return _sendEmailType;
				}
				set {
					_sendEmailType = value;
				}
			}

			private int _bodyTemplateType = 1;
			public override int BodyTemplateType {
				get {
					return _bodyTemplateType;
				}
				set {
					_bodyTemplateType = value;
				}
			}

			private string _body;
			public override string Body {
				get {
					return _body ?? (_body = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,88,91,111,219,54,20,126,223,175,96,21,12,104,7,211,178,115,143,28,7,219,210,12,11,176,173,69,151,98,27,130,60,80,18,109,115,161,68,149,162,111,245,252,223,119,72,74,50,117,113,146,110,47,3,214,34,137,120,72,158,251,249,14,201,203,87,111,223,93,223,253,241,254,6,205,84,194,209,251,143,223,255,116,123,141,60,236,251,191,29,93,251,254,219,187,183,232,247,31,239,126,254,9,13,251,3,116,39,73,154,51,197,68,74,184,239,223,252,226,33,111,166,84,22,248,254,114,185,236,47,143,250,66,78,253,187,15,254,74,243,26,234,205,197,39,86,206,206,126,172,98,239,234,82,79,192,111,74,226,171,203,132,42,2,10,168,12,211,79,115,182,24,123,215,34,85,52,85,248,110,157,81,15,69,118,52,246,20,93,41,95,111,28,161,104,70,100,78,213,248,227,221,15,248,220,243,11,30,153,20,25,149,106,61,246,196,52,80,76,113,119,119,181,42,37,9,29,123,11,70,151,153,144,202,89,177,100,177,154,141,99,186,96,17,197,102,208,99,41,168,77,56,206,35,194,233,120,88,241,112,181,253,29,127,252,14,95,139,36,35,138,133,53,145,183,55,99,26,79,169,222,101,180,185,186,244,139,191,185,90,115,138,20,216,87,152,21,229,185,119,117,32,230,138,11,241,136,200,38,35,113,204,210,105,48,216,134,34,94,111,140,54,193,112,48,248,250,21,75,180,218,36,85,219,254,7,112,223,207,249,244,251,250,138,109,255,102,165,168,4,95,95,115,146,231,251,103,122,245,33,138,217,162,73,154,128,41,77,90,214,36,228,25,73,155,52,21,111,56,75,41,158,81,54,157,41,43,157,244,66,46,162,199,79,115,161,104,79,155,213,227,172,151,245,20,1,175,245,96,3,94,210,240,145,41,172,29,130,115,246,153,98,18,255,57,207,237,238,17,78,242,61,51,73,46,176,35,12,203,57,167,1,93,145,72,241,245,182,226,174,87,153,1,230,160,112,68,131,193,104,71,146,37,41,20,50,166,18,235,161,227,254,132,200,41,75,97,122,23,22,150,76,55,118,49,144,155,166,142,116,32,129,6,83,70,229,152,70,66,66,122,136,52,72,69,74,141,45,12,146,68,102,130,27,50,78,68,76,131,144,69,115,248,217,146,251,21,38,89,6,122,197,68,17,216,173,104,164,132,204,31,54,145,224,66,6,44,157,81,201,212,46,21,58,165,56,211,58,140,198,111,29,91,205,220,132,36,140,175,247,205,46,173,101,237,89,215,238,214,172,117,125,225,36,12,154,115,146,229,52,40,63,154,11,117,202,236,91,107,163,224,56,216,209,161,29,155,81,103,181,124,155,208,152,17,36,82,190,70,121,36,41,77,17,73,99,244,58,33,43,91,236,193,241,249,32,91,189,217,244,19,17,230,51,177,220,196,44,207,56,89,7,70,61,71,162,88,80,57,225,98,25,44,88,174,43,222,45,201,84,192,238,106,103,35,12,86,204,192,161,20,38,57,164,109,191,128,15,108,138,101,179,11,221,240,52,91,237,71,131,81,194,82,220,105,56,100,106,127,194,233,74,171,138,89,66,166,180,244,36,153,43,209,82,175,229,222,85,55,219,127,92,205,117,167,108,159,12,140,11,198,85,124,254,111,14,170,27,172,235,100,39,207,17,127,58,0,247,56,138,89,172,56,56,62,62,174,213,56,145,208,208,122,51,202,23,84,177,136,244,114,232,205,56,135,210,157,56,48,49,60,206,86,141,234,54,141,208,113,226,161,22,55,218,91,177,45,165,17,65,253,53,212,149,84,209,92,65,239,105,207,7,32,240,177,115,66,23,154,162,113,1,127,7,71,167,23,53,96,58,30,180,113,118,158,130,94,218,130,14,77,52,118,151,37,202,82,189,104,228,4,124,219,215,103,12,76,57,77,96,151,110,119,134,247,110,156,85,161,179,216,131,67,58,17,82,131,125,131,78,38,0,241,109,114,174,136,84,109,50,77,99,221,147,10,56,219,246,115,154,17,48,70,200,82,116,175,77,194,75,9,141,130,202,90,147,103,211,20,212,169,98,210,66,213,130,75,13,183,98,154,63,42,145,225,144,68,143,83,41,192,123,155,221,103,145,19,134,57,192,27,131,50,121,98,29,52,209,29,69,210,140,18,157,210,197,87,197,0,226,153,212,112,114,100,208,148,113,166,214,78,22,57,171,209,55,166,135,207,24,116,74,194,57,132,105,29,74,22,215,57,217,118,30,81,61,95,218,180,119,65,56,87,10,122,111,225,203,70,74,216,116,233,236,172,213,78,53,219,52,242,240,11,218,204,11,92,94,235,11,207,123,190,121,62,236,114,117,113,222,17,75,7,41,28,207,23,45,109,175,227,27,216,212,237,227,230,34,55,80,208,59,53,236,112,76,56,228,105,0,123,159,1,216,109,159,196,36,83,108,1,166,27,175,247,118,4,3,214,206,88,7,171,27,252,187,1,189,17,148,110,161,58,13,28,25,249,140,82,181,217,191,115,27,4,101,97,67,252,33,145,67,34,43,192,208,197,10,181,151,194,89,211,228,124,169,43,32,105,117,186,129,38,214,193,2,114,109,158,132,78,200,131,131,56,212,255,95,144,113,167,103,54,227,138,172,157,17,62,209,25,208,157,240,118,203,73,45,4,47,144,113,120,113,248,164,12,151,121,35,192,219,75,223,220,135,224,122,100,47,132,186,89,34,78,39,202,130,225,216,27,120,200,126,218,43,154,30,67,226,180,102,173,11,13,65,76,38,250,126,168,63,13,239,177,87,2,43,92,62,237,121,211,194,162,89,162,225,160,56,62,86,227,226,10,96,198,37,99,173,184,135,10,37,236,160,224,190,175,15,106,105,18,126,160,139,233,124,31,123,17,32,13,149,30,90,20,99,176,3,214,188,194,248,158,77,208,235,169,162,8,106,13,93,188,249,235,245,237,205,155,135,82,215,66,36,180,248,231,149,221,217,85,202,6,254,247,208,93,216,228,1,227,202,250,169,105,166,99,239,96,98,254,1,31,125,113,27,123,245,68,175,12,252,239,31,57,218,158,168,121,106,8,4,22,67,164,170,10,186,211,142,216,5,168,30,145,154,223,109,168,159,115,124,225,192,70,251,245,174,208,165,210,25,173,255,74,253,171,33,10,117,202,234,228,133,90,61,224,89,173,218,210,43,129,133,12,83,153,186,86,221,212,121,214,88,87,219,43,100,153,183,108,43,87,157,156,239,234,176,11,116,42,123,171,99,184,62,179,17,152,151,200,105,30,218,152,23,86,138,245,226,19,53,247,197,101,228,148,208,147,90,196,165,161,229,125,20,157,64,210,238,92,113,54,104,40,210,96,109,205,40,22,104,16,252,162,176,84,96,87,150,40,184,30,196,183,187,174,3,197,79,85,84,3,19,236,17,186,29,37,175,35,189,10,85,254,53,38,152,19,152,213,91,187,99,180,4,109,205,185,55,8,37,37,143,88,143,45,209,140,93,106,217,69,103,235,108,70,211,220,180,127,120,124,17,159,235,20,119,80,207,217,23,150,124,237,0,130,94,0,0,141,20,209,25,82,124,99,109,99,141,32,13,26,186,20,8,95,109,28,10,232,185,137,33,117,188,200,52,243,222,170,236,222,105,180,134,112,39,130,164,131,30,119,127,112,147,16,198,145,126,85,60,120,240,144,121,130,178,47,149,239,165,136,104,158,191,135,19,12,188,130,234,138,50,147,192,126,14,179,247,7,247,183,249,187,37,100,195,175,209,140,38,36,152,16,158,211,135,62,80,27,132,138,65,176,137,207,232,17,141,14,79,241,249,197,217,41,62,142,225,139,92,192,175,240,236,136,158,29,93,12,143,14,67,178,125,208,122,148,61,248,228,188,217,147,134,23,253,179,243,225,238,8,117,114,158,173,118,0,53,188,128,247,215,175,46,51,56,93,100,87,95,33,120,130,213,41,234,155,72,248,101,92,124,147,178,87,205,217,130,184,191,218,245,242,151,34,131,102,90,242,172,239,49,66,11,169,123,117,121,90,211,250,172,213,171,46,240,105,27,246,41,119,25,74,120,189,110,47,241,141,64,56,176,233,119,252,191,1,52,104,132,124,71,24,0,0 })));
				}
				set {
					_body = value;
				}
			}

			private string _bodyConfig;
			public override string BodyConfig {
				get {
					return _bodyConfig ?? (_bodyConfig = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,77,111,194,48,12,253,43,85,184,82,190,10,180,116,12,105,160,29,56,13,141,73,59,20,14,166,49,109,69,218,68,77,24,32,196,127,159,147,193,132,134,214,67,107,191,103,63,187,182,207,108,110,176,252,56,41,100,49,211,57,162,97,77,54,3,101,10,89,17,50,147,149,193,202,120,28,117,145,85,88,19,105,227,53,139,147,243,125,230,70,200,116,247,31,105,240,232,84,165,216,151,36,218,105,178,119,121,112,95,130,150,10,8,235,245,29,248,227,56,194,213,165,228,113,81,102,30,8,243,188,98,73,227,181,132,66,120,83,201,79,141,245,138,121,169,0,173,137,32,147,131,1,223,80,61,114,23,181,76,81,235,5,212,80,162,193,250,70,127,129,216,91,62,105,36,115,253,118,160,223,89,166,57,150,16,111,65,104,92,183,8,253,3,252,74,196,103,30,98,128,105,111,232,71,163,112,232,247,57,89,48,162,215,38,12,48,12,70,221,160,183,129,203,218,181,149,99,145,229,182,225,65,68,158,54,39,97,171,30,10,110,242,216,235,118,71,173,48,234,170,227,211,53,46,246,6,17,121,20,233,34,40,146,66,200,107,79,86,213,88,77,198,109,69,6,141,111,105,117,104,182,103,166,128,243,162,202,124,129,91,59,161,129,58,18,125,3,107,171,249,128,26,169,30,176,141,52,70,150,87,248,114,89,223,149,112,222,167,109,135,197,195,14,237,99,10,233,46,171,229,190,226,180,50,89,83,82,99,235,30,219,152,189,154,23,65,247,65,112,74,91,115,103,50,173,17,118,74,22,149,185,234,244,163,206,229,27,177,2,245,144,110,2,0,0 })));
				}
				set {
					_bodyConfig = value;
				}
			}

			internal Func<string> _recipient1;
			public virtual string Recipient1 {
				get {
					return (_recipient1 ?? (_recipient1 = () => null)).Invoke();
				}
				set {
					_recipient1 = () => { return value; };
				}
			}

			public virtual Guid OmniChat {
				get;
				set;
			}

			#endregion

			#region Methods: Protected

			protected override void AfterActivitySaveScriptExecute(Entity activity) {
			}

			#endregion

		}

		#endregion

		public SyncWithLDAPProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncWithLDAPProcess";
			SchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new SyncWithLDAPProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c2aa62d6-6228-4d1a-a472-acaced886617");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SyncWithLDAPProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SyncWithLDAPProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string PageInstanceId {
			get;
			set;
		}

		public virtual Guid ActiveTreeGridCurrentRowId {
			get;
			set;
		}

		public virtual bool DoOpenList {
			get;
			set;
		}

		private Guid _showLDAPMessageId = new Guid("{83A1E9EA-651D-4600-B027-886C6EFA6524}");
		public Guid ShowLDAPMessageId {
			get {
				return _showLDAPMessageId;
			}
			set {
				_showLDAPMessageId = value;
			}
		}

		public virtual string NotLicensedUserNames {
			get;
			set;
		}

		public virtual string SyncResult {
			get;
			set;
		}

		private LocalizableString _newUsersQuestionLS;
		public virtual LocalizableString NewUsersQuestionLS {
			get {
				return _newUsersQuestionLS ?? (_newUsersQuestionLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.NewUsersQuestionLS.Value"));
			}
			set {
				_newUsersQuestionLS = value;
			}
		}

		private LocalizableString _notActiveUsersLS;
		public virtual LocalizableString NotActiveUsersLS {
			get {
				return _notActiveUsersLS ?? (_notActiveUsersLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.NotActiveUsersLS.Value"));
			}
			set {
				_notActiveUsersLS = value;
			}
		}

		private LocalizableString _newUsersInGroupLS;
		public virtual LocalizableString NewUsersInGroupLS {
			get {
				return _newUsersInGroupLS ?? (_newUsersInGroupLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.NewUsersInGroupLS.Value"));
			}
			set {
				_newUsersInGroupLS = value;
			}
		}

		private LocalizableString _processSynchWithLDAPLaunchedLS;
		public virtual LocalizableString ProcessSynchWithLDAPLaunchedLS {
			get {
				return _processSynchWithLDAPLaunchedLS ?? (_processSynchWithLDAPLaunchedLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.ProcessSynchWithLDAPLaunchedLS.Value"));
			}
			set {
				_processSynchWithLDAPLaunchedLS = value;
			}
		}

		private LocalizableString _errorCheckRequiredLDAPSettingsLS;
		public virtual LocalizableString ErrorCheckRequiredLDAPSettingsLS {
			get {
				return _errorCheckRequiredLDAPSettingsLS ?? (_errorCheckRequiredLDAPSettingsLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.ErrorCheckRequiredLDAPSettingsLS.Value"));
			}
			set {
				_errorCheckRequiredLDAPSettingsLS = value;
			}
		}

		private LocalizableString _lDAPUsersWereAddedLS;
		public virtual LocalizableString LDAPUsersWereAddedLS {
			get {
				return _lDAPUsersWereAddedLS ?? (_lDAPUsersWereAddedLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.LDAPUsersWereAddedLS.Value"));
			}
			set {
				_lDAPUsersWereAddedLS = value;
			}
		}

		private LocalizableString _serverErrorLS;
		public virtual LocalizableString ServerErrorLS {
			get {
				return _serverErrorLS ?? (_serverErrorLS = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.ServerErrorLS.Value"));
			}
			set {
				_serverErrorLS = value;
			}
		}

		private LocalizableString _processEnded;
		public virtual LocalizableString ProcessEnded {
			get {
				return _processEnded ?? (_processEnded = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.ProcessEnded.Value"));
			}
			set {
				_processEnded = value;
			}
		}

		private LocalizableString _messageLog;
		public virtual LocalizableString MessageLog {
			get {
				return _messageLog ?? (_messageLog = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.MessageLog.Value"));
			}
			set {
				_messageLog = value;
			}
		}

		private LocalizableString _noAccessMessage;
		public virtual LocalizableString NoAccessMessage {
			get {
				return _noAccessMessage ?? (_noAccessMessage = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.NoAccessMessage.Value"));
			}
			set {
				_noAccessMessage = value;
			}
		}

		private int _invalidCredentialsErrorCode = 49;
		public int InvalidCredentialsErrorCode {
			get {
				return _invalidCredentialsErrorCode;
			}
			set {
				_invalidCredentialsErrorCode = value;
			}
		}

		private string _invalidCredentialMessage;
		public virtual string InvalidCredentialMessage {
			get {
				return _invalidCredentialMessage ?? (_invalidCredentialMessage = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.InvalidCredentialMessage.Value"));
			}
			set {
				_invalidCredentialMessage = value;
			}
		}

		private string _connectionNotEstablishedMessage;
		public virtual string ConnectionNotEstablishedMessage {
			get {
				return _connectionNotEstablishedMessage ?? (_connectionNotEstablishedMessage = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.ConnectionNotEstablishedMessage.Value"));
			}
			set {
				_connectionNotEstablishedMessage = value;
			}
		}

		private string _errorSyncResult;
		public virtual string ErrorSyncResult {
			get {
				return _errorSyncResult ?? (_errorSyncResult = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.ErrorSyncResult.Value"));
			}
			set {
				_errorSyncResult = value;
			}
		}

		public virtual string EmailSubject {
			get;
			set;
		}

		public virtual string EmailBody {
			get;
			set;
		}

		public virtual string RecipientEmailsString {
			get;
			set;
		}

		private string _lDAPEmailMessage;
		public virtual string LDAPEmailMessage {
			get {
				return _lDAPEmailMessage ?? (_lDAPEmailMessage = GetLocalizableString("c2aa62d662284d1aa472acaced886617",
						 "Parameters.LDAPEmailMessage.Value"));
			}
			set {
				_lDAPEmailMessage = value;
			}
		}

		private ProcessLane166 _lane166;
		public ProcessLane166 Lane166 {
			get {
				return _lane166 ?? ((_lane166) = new ProcessLane166(UserConnection, this));
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
					SchemaElementUId = new Guid("3d9b99a5-0778-4b16-90d6-7a385850e5cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _end1;
		public ProcessEndEvent End1 {
			get {
				return _end1 ?? (_end1 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End1",
					SchemaElementUId = new Guid("6dce4d8c-057f-42ab-b2b1-ac53ac170c3e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _usersAutoImportScriptTask;
		public ProcessScriptTask UsersAutoImportScriptTask {
			get {
				return _usersAutoImportScriptTask ?? (_usersAutoImportScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UsersAutoImportScriptTask",
					SchemaElementUId = new Guid("0efac1d8-6a81-4348-ad2a-9a2f49b1cbe0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = UsersAutoImportScriptTaskExecute,
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
					SchemaElementUId = new Guid("e5d193f0-85fe-4fd8-8ab4-8c85dbf6a304"),
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

		private ProcessScriptTask _noAccessScriptTask;
		public ProcessScriptTask NoAccessScriptTask {
			get {
				return _noAccessScriptTask ?? (_noAccessScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "NoAccessScriptTask",
					SchemaElementUId = new Guid("f80232b1-1c8f-416a-a6b8-7c40d3e44979"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = NoAccessScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _insertLDAPElementsScriptTask;
		public ProcessScriptTask InsertLDAPElementsScriptTask {
			get {
				return _insertLDAPElementsScriptTask ?? (_insertLDAPElementsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InsertLDAPElementsScriptTask",
					SchemaElementUId = new Guid("214f1782-408b-45a3-a66f-305ae7b2d818"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = InsertLDAPElementsScriptTaskExecute,
				});
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
					SchemaElementUId = new Guid("233b45df-488c-4522-9045-2ed5b9134d61"),
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

		private EmailSendUserTaskFlowElement _emailSendUserTask;
		public EmailSendUserTaskFlowElement EmailSendUserTask {
			get {
				return _emailSendUserTask ?? (_emailSendUserTask = new EmailSendUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("dcdec0b2-6fc0-412a-917b-cf38319bc27f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway3.Question"),
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
					SchemaElementUId = new Guid("4fa1d705-682f-4a80-aa72-3cedba1f4704"),
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
					SchemaElementUId = new Guid("2501ba77-13f6-4274-8b23-c777ef76faf0"),
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
					SchemaElementUId = new Guid("02614f52-5d70-40a3-a124-8e4425535446"),
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
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[UsersAutoImportScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { UsersAutoImportScriptTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[NoAccessScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { NoAccessScriptTask };
			FlowElements[InsertLDAPElementsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertLDAPElementsScriptTask };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[EmailSendUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailSendUserTask };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "UsersAutoImportScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InsertLDAPElementsScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("NoAccessScriptTask", e.Context.SenderName));
						break;
					case "NoAccessScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "InsertLDAPElementsScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UsersAutoImportScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "EmailSendUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailSendUserTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageAdministration"));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "UserConnection.DBSecurityEngine.GetCanExecuteOperation(\"CanManageAdministration\")", result);
			return result;
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(string.IsNullOrEmpty((SyncResult)));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalSequenceFlow1", "string.IsNullOrEmpty((SyncResult))", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((EmailBody) != null && (EmailBody).Length > 0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalSequenceFlow2", "(EmailBody) != null && (EmailBody).Length > 0", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("EmailSendUserTask.Recipient1")) {
				writer.WriteValue("EmailSendUserTask.Recipient1", EmailSendUserTask.Recipient1, null);
			}
			if (!HasMapping("EmailSendUserTask.OmniChat")) {
				writer.WriteValue("EmailSendUserTask.OmniChat", EmailSendUserTask.OmniChat, Guid.Empty);
			}
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("DoOpenList")) {
				writer.WriteValue("DoOpenList", DoOpenList, false);
			}
			if (!HasMapping("ShowLDAPMessageId")) {
				writer.WriteValue("ShowLDAPMessageId", ShowLDAPMessageId, Guid.Empty);
			}
			if (!HasMapping("NotLicensedUserNames")) {
				writer.WriteValue("NotLicensedUserNames", NotLicensedUserNames, null);
			}
			if (!HasMapping("SyncResult")) {
				writer.WriteValue("SyncResult", SyncResult, null);
			}
			if (!HasMapping("InvalidCredentialsErrorCode")) {
				writer.WriteValue("InvalidCredentialsErrorCode", InvalidCredentialsErrorCode, 0);
			}
			if (!HasMapping("InvalidCredentialMessage")) {
				writer.WriteValue("InvalidCredentialMessage", InvalidCredentialMessage, null);
			}
			if (!HasMapping("ConnectionNotEstablishedMessage")) {
				writer.WriteValue("ConnectionNotEstablishedMessage", ConnectionNotEstablishedMessage, null);
			}
			if (!HasMapping("ErrorSyncResult")) {
				writer.WriteValue("ErrorSyncResult", ErrorSyncResult, null);
			}
			if (!HasMapping("EmailSubject")) {
				writer.WriteValue("EmailSubject", EmailSubject, null);
			}
			if (!HasMapping("EmailBody")) {
				writer.WriteValue("EmailBody", EmailBody, null);
			}
			if (!HasMapping("RecipientEmailsString")) {
				writer.WriteValue("RecipientEmailsString", RecipientEmailsString, null);
			}
			if (!HasMapping("LDAPEmailMessage")) {
				writer.WriteValue("LDAPEmailMessage", LDAPEmailMessage, null);
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
			MetaPathParameterValues.Add("e5c388b3-4785-4a2c-93b1-eb2829edce7e", () => PageInstanceId);
			MetaPathParameterValues.Add("39bf6d5a-ff9c-4dc0-956a-35ae10d7f2e2", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("c4ff2517-a192-4965-8aef-e3dc495ae18d", () => DoOpenList);
			MetaPathParameterValues.Add("0e5163a5-e480-4e06-b4b9-8d121b6ab25b", () => ShowLDAPMessageId);
			MetaPathParameterValues.Add("6740fc54-80fe-4f42-acd8-d4ec48888997", () => NotLicensedUserNames);
			MetaPathParameterValues.Add("c241e947-d0e3-48ca-b0eb-5109850b0a5f", () => SyncResult);
			MetaPathParameterValues.Add("3eee1f90-cad9-48ab-9581-9a37ffd7cc9e", () => NewUsersQuestionLS);
			MetaPathParameterValues.Add("7c51318b-2807-4e95-8070-9952bce377ca", () => NotActiveUsersLS);
			MetaPathParameterValues.Add("79cfd16f-6f0a-4429-8b33-20efbd7074bb", () => NewUsersInGroupLS);
			MetaPathParameterValues.Add("f4fa0f38-8445-4c0a-872a-08444b3b1da4", () => ProcessSynchWithLDAPLaunchedLS);
			MetaPathParameterValues.Add("c1351620-72ca-42c4-b8b1-b83dbf2f79a8", () => ErrorCheckRequiredLDAPSettingsLS);
			MetaPathParameterValues.Add("3ff56a7f-b43f-454e-8320-db273d793916", () => LDAPUsersWereAddedLS);
			MetaPathParameterValues.Add("ff35025d-d1a8-48b1-9355-f8a23f7413cb", () => ServerErrorLS);
			MetaPathParameterValues.Add("83c82239-ffec-4409-9bf6-9b8de6528de7", () => ProcessEnded);
			MetaPathParameterValues.Add("fcf94a88-a3b6-4d21-a997-00a81b8c55c3", () => MessageLog);
			MetaPathParameterValues.Add("ece68291-3e57-4d5a-a686-ac986c534ae8", () => NoAccessMessage);
			MetaPathParameterValues.Add("eb1d1d1a-09c4-4cdc-ae6d-3cbc3d8c345c", () => InvalidCredentialsErrorCode);
			MetaPathParameterValues.Add("e410db97-07f1-42a9-97c3-499e34692d6d", () => InvalidCredentialMessage);
			MetaPathParameterValues.Add("f6d1588b-7930-4f8e-9038-661abad4372d", () => ConnectionNotEstablishedMessage);
			MetaPathParameterValues.Add("a9370089-7daf-4b16-b51c-855fb82d5532", () => ErrorSyncResult);
			MetaPathParameterValues.Add("aeb1a392-036e-4295-8e8d-f388946495a5", () => EmailSubject);
			MetaPathParameterValues.Add("d7e3ec26-8976-4d26-a926-b73e739132ba", () => EmailBody);
			MetaPathParameterValues.Add("e6d9613e-c931-45a4-8289-34a64d103e30", () => RecipientEmailsString);
			MetaPathParameterValues.Add("2d31abe5-21af-4461-8c88-14c9cb2e037d", () => LDAPEmailMessage);
			MetaPathParameterValues.Add("ca308d49-70ae-4ee3-a7a6-576b39d0906d", () => EmailSendUserTask.Recommendation);
			MetaPathParameterValues.Add("9e636c72-feec-443d-80db-bbb11ca74373", () => EmailSendUserTask.ActivityCategory);
			MetaPathParameterValues.Add("20c028fe-7707-4d7c-8ae9-cf1c90b232e7", () => EmailSendUserTask.OwnerId);
			MetaPathParameterValues.Add("6194902c-224f-4855-9b2a-9d91ea50a55e", () => EmailSendUserTask.Duration);
			MetaPathParameterValues.Add("fb8728ed-a9ef-4b57-8aa7-37c3bac33e7b", () => EmailSendUserTask.DurationPeriod);
			MetaPathParameterValues.Add("a2c18195-1b0e-4559-8052-817ae92fd235", () => EmailSendUserTask.StartIn);
			MetaPathParameterValues.Add("3c731905-eb35-44ed-b3ca-dd1c63b9398b", () => EmailSendUserTask.StartInPeriod);
			MetaPathParameterValues.Add("22574204-b989-403f-aa68-6db44ddef273", () => EmailSendUserTask.RemindBefore);
			MetaPathParameterValues.Add("3e151f18-e3c4-4475-aa5b-5dbaefa7a649", () => EmailSendUserTask.RemindBeforePeriod);
			MetaPathParameterValues.Add("7c910dbb-c563-4a34-acf6-c6a467c05210", () => EmailSendUserTask.ShowInScheduler);
			MetaPathParameterValues.Add("13944a4c-7072-43a9-b1f5-b83b8de6253b", () => EmailSendUserTask.ShowExecutionPage);
			MetaPathParameterValues.Add("97b9f11a-d877-4fb1-a48a-d0b0ca01eb23", () => EmailSendUserTask.Lead);
			MetaPathParameterValues.Add("83a900f2-650d-4af8-8b42-4730bdc2076e", () => EmailSendUserTask.Account);
			MetaPathParameterValues.Add("b96b1ca6-35c7-4f2b-9344-720c982df478", () => EmailSendUserTask.Contact);
			MetaPathParameterValues.Add("396fe566-406a-403f-a5a5-6af7e082deb9", () => EmailSendUserTask.Opportunity);
			MetaPathParameterValues.Add("92959022-75ae-442f-86ef-9b01c388c38c", () => EmailSendUserTask.Invoice);
			MetaPathParameterValues.Add("959b81bb-3ff0-43ae-9129-2f50675fc64d", () => EmailSendUserTask.Document);
			MetaPathParameterValues.Add("3b18e768-4724-4d67-836a-cc1b4310b25e", () => EmailSendUserTask.ActivityResult);
			MetaPathParameterValues.Add("68f42e26-155e-4df5-9df2-41543aca9a91", () => EmailSendUserTask.Incident);
			MetaPathParameterValues.Add("73127a7c-1289-4e1b-8116-dc1191419c44", () => EmailSendUserTask.Case);
			MetaPathParameterValues.Add("7422cc60-2798-4064-84f0-b61ff20194c6", () => EmailSendUserTask.ActivityId);
			MetaPathParameterValues.Add("6aa36187-c640-44b8-a099-21d088d631b1", () => EmailSendUserTask.IsActivityCompleted);
			MetaPathParameterValues.Add("131c861e-e4b5-4cb8-add0-76db6ac463ed", () => EmailSendUserTask.ExecutionContext);
			MetaPathParameterValues.Add("883ae716-c06b-41a5-a98f-cea9cde03256", () => EmailSendUserTask.InformationOnStep);
			MetaPathParameterValues.Add("334b7e03-c84d-46cc-ae02-30e60226da8a", () => EmailSendUserTask.Order);
			MetaPathParameterValues.Add("703db63c-a4c5-4d00-99aa-8886e6f8ad64", () => EmailSendUserTask.Contract);
			MetaPathParameterValues.Add("26810327-3097-4fe8-a1a1-66a1d38d218a", () => EmailSendUserTask.Property);
			MetaPathParameterValues.Add("2f922d07-1465-46ff-89a8-6baac78050de", () => EmailSendUserTask.Listing);
			MetaPathParameterValues.Add("77526092-2a5c-4e11-865e-760b484d2d5e", () => EmailSendUserTask.Requests);
			MetaPathParameterValues.Add("50d6e9c3-54bb-4a5a-afc0-2c939d94b1b4", () => EmailSendUserTask.Project);
			MetaPathParameterValues.Add("b82ba56c-dfcc-46d3-a733-b779b91d801b", () => EmailSendUserTask.Problem);
			MetaPathParameterValues.Add("5acd32c6-85a3-4f51-8f40-b4528de854c7", () => EmailSendUserTask.Change);
			MetaPathParameterValues.Add("533b40fc-4e3e-4725-acf6-d5d6f8a2c575", () => EmailSendUserTask.Release);
			MetaPathParameterValues.Add("00c6d940-fd61-4cf6-9434-c51565909d13", () => EmailSendUserTask.QueueItem);
			MetaPathParameterValues.Add("db07491a-f5b1-439c-97a1-6af53ce909cd", () => EmailSendUserTask.Sender);
			MetaPathParameterValues.Add("953f4a27-0013-452f-8b74-5d28dbcbf8c6", () => EmailSendUserTask.Importance);
			MetaPathParameterValues.Add("b760a46f-1ff5-4b25-9a6f-af792f81b239", () => EmailSendUserTask.Subject);
			MetaPathParameterValues.Add("e2a57e59-b1eb-4aaf-81ec-1719d9392746", () => EmailSendUserTask.IgnoreErrors);
			MetaPathParameterValues.Add("b138f1ee-5c36-4c42-9abb-c1cd87be5b8e", () => EmailSendUserTask.SendEmailType);
			MetaPathParameterValues.Add("9c010bb6-8599-403e-b457-54ab13ff4c91", () => EmailSendUserTask.BodyTemplateType);
			MetaPathParameterValues.Add("09a73a34-9036-48e9-9e48-78e8873369b7", () => EmailSendUserTask.EmailTemplateId);
			MetaPathParameterValues.Add("95428372-753c-42d5-b08f-5a8e7695dfa8", () => EmailSendUserTask.EmailTemplateEntityId);
			MetaPathParameterValues.Add("126ba0f1-9346-426c-865c-079a6d0e9101", () => EmailSendUserTask.Body);
			MetaPathParameterValues.Add("c828d5b0-a444-4243-a108-cd25dd3dd2a0", () => EmailSendUserTask.BodyConfig);
			MetaPathParameterValues.Add("51944a09-9fbc-495d-8105-c8c1638523ef", () => EmailSendUserTask.CreateActivity);
			MetaPathParameterValues.Add("b976035c-f70e-41b8-b529-d345c403d06c", () => EmailSendUserTask.Recipient1);
			MetaPathParameterValues.Add("48c8cbfc-612a-4dab-b34f-c3eb75382329", () => EmailSendUserTask.OmniChat);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "EmailSendUserTask.Recipient1":
					EmailSendUserTask.Recipient1 = reader.GetValue<System.String>();
				break;
				case "EmailSendUserTask.OmniChat":
					EmailSendUserTask.OmniChat = reader.GetValue<System.Guid>();
				break;
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "ActiveTreeGridCurrentRowId":
					if (!hasValueToRead) break;
					ActiveTreeGridCurrentRowId = reader.GetValue<System.Guid>();
				break;
				case "DoOpenList":
					if (!hasValueToRead) break;
					DoOpenList = reader.GetValue<System.Boolean>();
				break;
				case "ShowLDAPMessageId":
					if (!hasValueToRead) break;
					ShowLDAPMessageId = reader.GetValue<System.Guid>();
				break;
				case "NotLicensedUserNames":
					if (!hasValueToRead) break;
					NotLicensedUserNames = reader.GetValue<System.String>();
				break;
				case "SyncResult":
					if (!hasValueToRead) break;
					SyncResult = reader.GetValue<System.String>();
				break;
				case "InvalidCredentialsErrorCode":
					if (!hasValueToRead) break;
					InvalidCredentialsErrorCode = reader.GetValue<System.Int32>();
				break;
				case "InvalidCredentialMessage":
					if (!hasValueToRead) break;
					InvalidCredentialMessage = reader.GetValue<System.String>();
				break;
				case "ConnectionNotEstablishedMessage":
					if (!hasValueToRead) break;
					ConnectionNotEstablishedMessage = reader.GetValue<System.String>();
				break;
				case "ErrorSyncResult":
					if (!hasValueToRead) break;
					ErrorSyncResult = reader.GetValue<System.String>();
				break;
				case "EmailSubject":
					if (!hasValueToRead) break;
					EmailSubject = reader.GetValue<System.String>();
				break;
				case "EmailBody":
					if (!hasValueToRead) break;
					EmailBody = reader.GetValue<System.String>();
				break;
				case "RecipientEmailsString":
					if (!hasValueToRead) break;
					RecipientEmailsString = reader.GetValue<System.String>();
				break;
				case "LDAPEmailMessage":
					if (!hasValueToRead) break;
					LDAPEmailMessage = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool UsersAutoImportScriptTaskExecute(ProcessExecutingContext context) {
			// Check LDAP settings
			if (!LdapUtilities.CheckRequiredLDAPSettings(UserConnection)) {
				SyncResult = ErrorCheckRequiredLDAPSettingsLS;
				throw new Exception(SyncResult);
			}
			// Sync LDAP users
			var syncWithLDAPProcessHelper = new SyncWithLDAPProcessHelper(UserConnection);
			syncWithLDAPProcessHelper.SyncWithLDAP();
			SyncResult = ProcessEnded;
			var userList = syncWithLDAPProcessHelper.GetUsersWithMissingLicenses();
			if(userList.Count > 0) {
				var wrapper = new SyncWithLDAPProcessMethodsWrapper(this);
				wrapper.CreateRemindingByProcess();
				if (SysSettings.TryGetValue(UserConnection, "LDAPLogNotificationSender", out var result) ) {
					if (result != null && (Guid) result != Guid.Empty) {
						EmailSubject = new LocalizableString(UserConnection.Workspace.ResourceStorage,
							"SyncWithLDAPProcessHelper", "LocalizableStrings.EmailSubject.Value");
						EmailBody = wrapper.GetEmailBody(userList);
						var recipientEmails = wrapper.GetSysAdministratorsEmails();
						RecipientEmailsString = string.Join(";", recipientEmails);
					}
				}
			}
			return true;
		}

		public virtual bool NoAccessScriptTaskExecute(ProcessExecutingContext context) {
			SyncResult = NoAccessMessage;
			var log = LogManager.GetLogger("LDAP");
			log.Debug(SyncResult);
			return true;
		}

		public virtual bool InsertLDAPElementsScriptTaskExecute(ProcessExecutingContext context) {
			var log = LogManager.GetLogger("LDAP");
			try {
				var ldapService = new LDAPSysSettingsService();
				ldapService.InsertLDAPElements(UserConnection);
			} catch (LdapException e) {
				if (e.ErrorCode == InvalidCredentialsErrorCode) {
					SyncResult = InvalidCredentialMessage;
				} else {
					SyncResult = ConnectionNotEstablishedMessage;
				}
				log.Error(SyncResult, e);
				throw;
			} catch (Exception e) {
				SyncResult = string.Format(ErrorSyncResult, e.Message);
				log.Error(SyncResult, e);
				throw;
			}
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
			var cloneItem = (SyncWithLDAPProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

