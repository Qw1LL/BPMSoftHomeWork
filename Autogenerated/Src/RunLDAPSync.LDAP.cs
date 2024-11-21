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
	using System.DirectoryServices.Protocols;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: RunLDAPSyncSchema

	/// <exclude/>
	public class RunLDAPSyncSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public RunLDAPSyncSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public RunLDAPSyncSchema(RunLDAPSyncSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "RunLDAPSync";
			UId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a");
			CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.1152";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,143,49,107,195,48,16,133,103,27,252,31,14,77,46,136,208,172,45,29,154,148,78,45,4,135,76,117,6,215,81,195,81,89,42,210,41,96,140,254,123,207,145,8,109,73,183,227,221,221,247,222,171,202,175,240,174,177,135,19,58,10,157,134,147,197,3,60,91,55,116,212,40,31,52,213,158,28,154,35,12,202,251,238,168,110,96,170,202,34,107,238,124,241,154,54,240,0,73,94,164,247,90,76,83,43,62,213,216,138,59,104,197,116,27,91,33,121,200,160,172,46,89,141,81,10,201,212,34,175,228,197,236,158,213,237,104,250,20,229,154,3,51,178,191,159,137,111,108,179,135,24,217,233,87,184,153,20,171,178,186,90,119,237,84,71,170,81,3,154,3,211,87,227,198,217,158,255,234,84,22,63,160,254,115,146,22,197,203,211,227,102,71,168,145,198,197,191,144,157,87,110,109,141,81,61,161,53,18,68,19,204,252,56,247,74,181,127,84,148,96,130,214,18,200,133,212,158,67,159,115,127,3,195,251,233,121,169,1,0,0 };
			RealUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a");
			Version = 0;
			PackageUId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSyncResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("801ed569-bcea-4433-bd45-fcc466c2c8ed"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"SyncResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6201f425-7f69-417c-8235-f4500c09e1cc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"true",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNoSuccessResultMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("96ab4ed3-8e01-4f02-b7f7-d0a846900462"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c94edc4f-74f1-46a8-b11f-d3d8de7f0346"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"NoSuccessResultMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSyncResultParameter());
			Parameters.Add(CreateCreateRemindingParameter());
			Parameters.Add(CreateNoSuccessResultMessageParameter());
		}

		protected virtual void InitializeSyncLDAPSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var invalidCredentialsErrorCodeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f285fbfd-bf94-40bc-b2d8-8832a994478a"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			invalidCredentialsErrorCodeParameter.SourceValue = new ProcessSchemaParameterValue(invalidCredentialsErrorCodeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(invalidCredentialsErrorCodeParameter);
			var invalidCredentialMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bcb9fe1b-1383-4a07-a54f-7d94ab09bd6d"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			invalidCredentialMessageParameter.SourceValue = new ProcessSchemaParameterValue(invalidCredentialMessageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(invalidCredentialMessageParameter);
			var connectionNotEstablishedMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("33604bd1-55ce-48c3-af57-1d1202cf0085"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText")
			};
			connectionNotEstablishedMessageParameter.SourceValue = new ProcessSchemaParameterValue(connectionNotEstablishedMessageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(connectionNotEstablishedMessageParameter);
			var errorSyncResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0cc77f35-10d3-4448-bf32-28943c7cc31f"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText")
			};
			errorSyncResultParameter.SourceValue = new ProcessSchemaParameterValue(errorSyncResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(errorSyncResultParameter);
			var pageInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eec75451-e7bf-4f00-b7c0-7ee3a6e9ca37"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pageInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(pageInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageInstanceIdParameter);
			var activeTreeGridCurrentRowIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ff9d97aa-8ba0-473f-9be5-7a2b55f1c24a"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activeTreeGridCurrentRowIdParameter.SourceValue = new ProcessSchemaParameterValue(activeTreeGridCurrentRowIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activeTreeGridCurrentRowIdParameter);
			var doOpenListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3eb975cd-0ed7-47a1-9d12-d4007c226ef7"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			doOpenListParameter.SourceValue = new ProcessSchemaParameterValue(doOpenListParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a")
			};
			parametrizedElement.Parameters.Add(doOpenListParameter);
			var showLDAPMessageIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c783cb42-5282-4f5a-afa8-afeed3b9551e"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			showLDAPMessageIdParameter.SourceValue = new ProcessSchemaParameterValue(showLDAPMessageIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(showLDAPMessageIdParameter);
			var notLicensedUserNamesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7ac36cd5-389e-438b-bfbf-3114cf7468cb"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			notLicensedUserNamesParameter.SourceValue = new ProcessSchemaParameterValue(notLicensedUserNamesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(notLicensedUserNamesParameter);
			var syncResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("475b123b-f38e-48bc-a9b7-bd41831d66e0"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText")
			};
			syncResultParameter.SourceValue = new ProcessSchemaParameterValue(syncResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(syncResultParameter);
			var newUsersQuestionLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b9c722db-9aa2-4bbd-975c-57e0f24043ff"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			newUsersQuestionLSParameter.SourceValue = new ProcessSchemaParameterValue(newUsersQuestionLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(newUsersQuestionLSParameter);
			var notActiveUsersLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e06dba72-10a6-4ba5-b295-308f2d0780c2"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			notActiveUsersLSParameter.SourceValue = new ProcessSchemaParameterValue(notActiveUsersLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(notActiveUsersLSParameter);
			var newUsersInGroupLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5a2c3e6b-1d0e-430f-becd-8b526bdc1447"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			newUsersInGroupLSParameter.SourceValue = new ProcessSchemaParameterValue(newUsersInGroupLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(newUsersInGroupLSParameter);
			var processSynchWithLDAPLaunchedLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c11e43c4-5185-42f7-9c35-a3d9238f0466"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			processSynchWithLDAPLaunchedLSParameter.SourceValue = new ProcessSchemaParameterValue(processSynchWithLDAPLaunchedLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(processSynchWithLDAPLaunchedLSParameter);
			var errorCheckRequiredLDAPSettingsLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("533c2822-3b0b-484a-a8af-6971ccf43fbf"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			errorCheckRequiredLDAPSettingsLSParameter.SourceValue = new ProcessSchemaParameterValue(errorCheckRequiredLDAPSettingsLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(errorCheckRequiredLDAPSettingsLSParameter);
			var lDAPUsersWereAddedLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f6811b3-bb02-45cc-a8d4-35a26a09a789"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			lDAPUsersWereAddedLSParameter.SourceValue = new ProcessSchemaParameterValue(lDAPUsersWereAddedLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(lDAPUsersWereAddedLSParameter);
			var serverErrorLSParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("14acfeda-eb6c-4cf9-895e-8aef99240705"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			serverErrorLSParameter.SourceValue = new ProcessSchemaParameterValue(serverErrorLSParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(serverErrorLSParameter);
			var processEndedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ecb5a9ef-fceb-486a-8f75-7b37b133bbc5"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			processEndedParameter.SourceValue = new ProcessSchemaParameterValue(processEndedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(processEndedParameter);
			var messageLogParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1624b549-a9c1-4272-b0fd-661736c639cb"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			messageLogParameter.SourceValue = new ProcessSchemaParameterValue(messageLogParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(messageLogParameter);
			var noAccessMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1607e605-c0c2-42bc-b81f-655a0a8b0599"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			noAccessMessageParameter.SourceValue = new ProcessSchemaParameterValue(noAccessMessageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(noAccessMessageParameter);
			var emailSubjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb9b5d94-fbda-4746-97ff-c1f57cc10411"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			emailSubjectParameter.SourceValue = new ProcessSchemaParameterValue(emailSubjectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(emailSubjectParameter);
			var emailBodyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("72a6739b-378b-4fc0-b722-3e18bf6f9125"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			emailBodyParameter.SourceValue = new ProcessSchemaParameterValue(emailBodyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(emailBodyParameter);
			var recipientEmailsStringParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9aedb4ec-6c8b-4653-bf51-8fc91ea985fb"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			recipientEmailsStringParameter.SourceValue = new ProcessSchemaParameterValue(recipientEmailsStringParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recipientEmailsStringParameter);
			var lDAPEmailMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4c5a2579-4f4a-4b05-8c2b-eb3178b1dbf9"),
				ContainerUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
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
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText")
			};
			lDAPEmailMessageParameter.SourceValue = new ProcessSchemaParameterValue(lDAPEmailMessageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617")
			};
			parametrizedElement.Parameters.Add(lDAPEmailMessageParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaSubProcess syncldapsubprocess = CreateSyncLDAPSubProcessSubProcess();
			FlowElements.Add(syncldapsubprocess);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask createremindingscripttask = CreateCreateRemindingScriptTaskScriptTask();
			FlowElements.Add(createremindingscripttask);
			ProcessSchemaScriptTask syncresultscripttask = CreateSyncResultScriptTaskScriptTask();
			FlowElements.Add(syncresultscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("dab327c8-0d41-4dbc-a5ef-e9d640532e0d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				CurveCenterPosition = new Point(410, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("234406a6-cfa7-49c4-8c4c-f30caed125c1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("cb2087d9-bea2-48f8-b7d3-e8f5d4a27e1b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				CurveCenterPosition = new Point(410, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("eb8e635c-7003-4647-8ffe-37f51bc7ffe3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("78472b96-f647-41b0-8ffb-4ef66823ed09"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("98cd9a7c-8587-4ecf-ba31-e14bbd284e7b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				CurveCenterPosition = new Point(535, 281),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fde218bd-aefb-4caf-839b-66463be2ed95"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("a839c5cc-ac09-4db0-a923-d54acd86f70d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				CurveCenterPosition = new Point(659, 250),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fde218bd-aefb-4caf-839b-66463be2ed95"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("eb8e635c-7003-4647-8ffe-37f51bc7ffe3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("e09892a4-d298-49a5-b635-d8fc0f16fdb6"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("8e3e0667-0525-4474-b154-433be3afb005"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("e09892a4-d298-49a5-b635-d8fc0f16fdb6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("234406a6-cfa7-49c4-8c4c-f30caed125c1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e3e0667-0525-4474-b154-433be3afb005"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"Start1",
				Position = new Point(50, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("78472b96-f647-41b0-8ffb-4ef66823ed09"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e3e0667-0525-4474-b154-433be3afb005"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"Terminate1",
				Position = new Point(900, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateCreateRemindingScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("eb8e635c-7003-4647-8ffe-37f51bc7ffe3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e3e0667-0525-4474-b154-433be3afb005"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"CreateRemindingScriptTask",
				Position = new Point(680, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,13,74,205,205,204,75,201,204,75,119,170,12,40,202,79,78,45,46,214,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,194,144,239,51,41,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaSubProcess CreateSyncLDAPSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaSyncLDAPSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e3e0667-0525-4474-b154-433be3afb005"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"SyncLDAPSubProcess",
				Position = new Point(200, 163),
				SchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeSyncLDAPSubProcessParameters(schemaSyncLDAPSubProcess);
			return schemaSyncLDAPSubProcess;
		}

		protected virtual ProcessSchemaScriptTask CreateSyncResultScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("fde218bd-aefb-4caf-839b-66463be2ed95"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8e3e0667-0525-4474-b154-433be3afb005"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f"),
				CreatedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a"),
				Name = @"SyncResultScriptTask",
				Position = new Point(411, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,46,41,202,204,75,87,40,174,204,75,206,8,74,45,46,205,41,81,176,85,8,6,242,124,92,28,3,130,75,147,2,138,242,147,83,139,139,245,64,66,16,121,107,94,174,204,52,5,13,36,29,122,158,197,126,165,57,57,254,69,174,185,5,37,149,26,154,154,10,213,188,92,156,168,70,250,229,7,151,38,131,76,130,136,248,2,89,137,233,169,122,97,137,57,165,169,64,19,107,121,185,16,54,0,149,35,105,6,202,22,165,150,148,22,229,41,148,20,1,213,2,0,139,49,130,142,177,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6c0d5a73-b0e6-49b4-a399-b5ddc796ab8a"),
				Name = "System.DirectoryServices.Protocols",
				Alias = "",
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("f72630f5-8f8e-46e3-b0aa-c242da6d04c6"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("efd28ea3-6207-40cb-8108-c90e69e01e8f")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new RunLDAPSync(userConnection);
		}

		public override object Clone() {
			return new RunLDAPSyncSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63070430-d3fd-4167-8452-1e8094845a8a"));
		}

		#endregion

	}

	#endregion

	#region Class: RunLDAPSync

	/// <exclude/>
	public class RunLDAPSync : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, RunLDAPSync process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: SyncLDAPSubProcessFlowElement

		/// <exclude/>
		public class SyncLDAPSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public SyncLDAPSubProcessFlowElement(UserConnection userConnection, RunLDAPSync process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("c2aa62d6-6228-4d1a-a472-acaced886617");
			}

			#endregion

			#region Properties: Public

			public string PageInstanceId {
				get {
					return GetParameterValue<string>("PageInstanceId");
				}
				set {
					SetParameterValue("PageInstanceId", value);
				}
			}

			public Guid ActiveTreeGridCurrentRowId {
				get {
					return GetParameterValue<Guid>("ActiveTreeGridCurrentRowId");
				}
				set {
					SetParameterValue("ActiveTreeGridCurrentRowId", value);
				}
			}

			public bool DoOpenList {
				get {
					return GetParameterValue<bool>("DoOpenList");
				}
				set {
					SetParameterValue("DoOpenList", value);
				}
			}

			public Guid ShowLDAPMessageId {
				get {
					return GetParameterValue<Guid>("ShowLDAPMessageId");
				}
				set {
					SetParameterValue("ShowLDAPMessageId", value);
				}
			}

			public string NotLicensedUserNames {
				get {
					return GetParameterValue<string>("NotLicensedUserNames");
				}
				set {
					SetParameterValue("NotLicensedUserNames", value);
				}
			}

			public string SyncResult {
				get {
					return GetParameterValue<string>("SyncResult");
				}
				set {
					SetParameterValue("SyncResult", value);
				}
			}

			public LocalizableString NewUsersQuestionLS {
				get {
					return GetParameterValue<LocalizableString>("NewUsersQuestionLS");
				}
				set {
					SetParameterValue("NewUsersQuestionLS", value);
				}
			}

			public LocalizableString NotActiveUsersLS {
				get {
					return GetParameterValue<LocalizableString>("NotActiveUsersLS");
				}
				set {
					SetParameterValue("NotActiveUsersLS", value);
				}
			}

			public LocalizableString NewUsersInGroupLS {
				get {
					return GetParameterValue<LocalizableString>("NewUsersInGroupLS");
				}
				set {
					SetParameterValue("NewUsersInGroupLS", value);
				}
			}

			public LocalizableString ProcessSynchWithLDAPLaunchedLS {
				get {
					return GetParameterValue<LocalizableString>("ProcessSynchWithLDAPLaunchedLS");
				}
				set {
					SetParameterValue("ProcessSynchWithLDAPLaunchedLS", value);
				}
			}

			public LocalizableString ErrorCheckRequiredLDAPSettingsLS {
				get {
					return GetParameterValue<LocalizableString>("ErrorCheckRequiredLDAPSettingsLS");
				}
				set {
					SetParameterValue("ErrorCheckRequiredLDAPSettingsLS", value);
				}
			}

			public LocalizableString LDAPUsersWereAddedLS {
				get {
					return GetParameterValue<LocalizableString>("LDAPUsersWereAddedLS");
				}
				set {
					SetParameterValue("LDAPUsersWereAddedLS", value);
				}
			}

			public LocalizableString ServerErrorLS {
				get {
					return GetParameterValue<LocalizableString>("ServerErrorLS");
				}
				set {
					SetParameterValue("ServerErrorLS", value);
				}
			}

			public LocalizableString ProcessEnded {
				get {
					return GetParameterValue<LocalizableString>("ProcessEnded");
				}
				set {
					SetParameterValue("ProcessEnded", value);
				}
			}

			public LocalizableString MessageLog {
				get {
					return GetParameterValue<LocalizableString>("MessageLog");
				}
				set {
					SetParameterValue("MessageLog", value);
				}
			}

			public LocalizableString NoAccessMessage {
				get {
					return GetParameterValue<LocalizableString>("NoAccessMessage");
				}
				set {
					SetParameterValue("NoAccessMessage", value);
				}
			}

			public int InvalidCredentialsErrorCode {
				get {
					return GetParameterValue<int>("InvalidCredentialsErrorCode");
				}
				set {
					SetParameterValue("InvalidCredentialsErrorCode", value);
				}
			}

			public string InvalidCredentialMessage {
				get {
					return GetParameterValue<string>("InvalidCredentialMessage");
				}
				set {
					SetParameterValue("InvalidCredentialMessage", value);
				}
			}

			public string ConnectionNotEstablishedMessage {
				get {
					return GetParameterValue<string>("ConnectionNotEstablishedMessage");
				}
				set {
					SetParameterValue("ConnectionNotEstablishedMessage", value);
				}
			}

			public string ErrorSyncResult {
				get {
					return GetParameterValue<string>("ErrorSyncResult");
				}
				set {
					SetParameterValue("ErrorSyncResult", value);
				}
			}

			public string EmailSubject {
				get {
					return GetParameterValue<string>("EmailSubject");
				}
				set {
					SetParameterValue("EmailSubject", value);
				}
			}

			public string EmailBody {
				get {
					return GetParameterValue<string>("EmailBody");
				}
				set {
					SetParameterValue("EmailBody", value);
				}
			}

			public string RecipientEmailsString {
				get {
					return GetParameterValue<string>("RecipientEmailsString");
				}
				set {
					SetParameterValue("RecipientEmailsString", value);
				}
			}

			public string LDAPEmailMessage {
				get {
					return GetParameterValue<string>("LDAPEmailMessage");
				}
				set {
					SetParameterValue("LDAPEmailMessage", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (RunLDAPSync)owner;
				Name = "SyncLDAPSubProcess";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("f8b19a6d-4d28-4716-96f1-8cafb4e7dd96");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (RunLDAPSync)Owner;
			}

			#endregion

		}

		#endregion

		public RunLDAPSync(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunLDAPSync";
			SchemaUId = new Guid("63070430-d3fd-4167-8452-1e8094845a8a");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_createReminding = () => { return (bool)(true); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("63070430-d3fd-4167-8452-1e8094845a8a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: RunLDAPSync, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: RunLDAPSync, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string SyncResult {
			get;
			set;
		}

		private Func<bool> _createReminding;
		public virtual bool CreateReminding {
			get {
				return (_createReminding ?? (_createReminding = () => false)).Invoke();
			}
			set {
				_createReminding = () => { return value; };
			}
		}

		private LocalizableString _noSuccessResultMessage;
		public virtual LocalizableString NoSuccessResultMessage {
			get {
				return _noSuccessResultMessage ?? (_noSuccessResultMessage = new LocalizableString());
			}
			set {
				_noSuccessResultMessage = value;
			}
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
					SchemaElementUId = new Guid("234406a6-cfa7-49c4-8c4c-f30caed125c1"),
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
					SchemaElementUId = new Guid("78472b96-f647-41b0-8ffb-4ef66823ed09"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _createRemindingScriptTask;
		public ProcessScriptTask CreateRemindingScriptTask {
			get {
				return _createRemindingScriptTask ?? (_createRemindingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CreateRemindingScriptTask",
					SchemaElementUId = new Guid("eb8e635c-7003-4647-8ffe-37f51bc7ffe3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CreateRemindingScriptTaskExecute,
				});
			}
		}

		private SyncLDAPSubProcessFlowElement _syncLDAPSubProcess;
		public SyncLDAPSubProcessFlowElement SyncLDAPSubProcess {
			get {
				return _syncLDAPSubProcess ?? ((_syncLDAPSubProcess) = new SyncLDAPSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _syncResultScriptTask;
		public ProcessScriptTask SyncResultScriptTask {
			get {
				return _syncResultScriptTask ?? (_syncResultScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SyncResultScriptTask",
					SchemaElementUId = new Guid("fde218bd-aefb-4caf-839b-66463be2ed95"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SyncResultScriptTaskExecute,
				});
			}
		}

		private ProcessToken _start1SyncLDAPSubProcessToken;
		public ProcessToken Start1SyncLDAPSubProcessToken {
			get {
				return _start1SyncLDAPSubProcessToken ?? (_start1SyncLDAPSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "Start1SyncLDAPSubProcessToken",
					SchemaElementUId = new Guid("eea7f661-01bf-457b-a68a-63c07b60cf33"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[CreateRemindingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateRemindingScriptTask };
			FlowElements[SyncLDAPSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SyncLDAPSubProcess };
			FlowElements[SyncResultScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SyncResultScriptTask };
			FlowElements[Start1SyncLDAPSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1SyncLDAPSubProcessToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start1SyncLDAPSubProcessToken", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "CreateRemindingScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "SyncLDAPSubProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SyncResultScriptTask", e.Context.SenderName));
						break;
					case "SyncResultScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateRemindingScriptTask", e.Context.SenderName));
						break;
					case "Start1SyncLDAPSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SyncLDAPSubProcess", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SyncResult")) {
				writer.WriteValue("SyncResult", SyncResult, null);
			}
			if (!HasMapping("CreateReminding")) {
				writer.WriteValue("CreateReminding", CreateReminding, false);
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
			MetaPathParameterValues.Add("801ed569-bcea-4433-bd45-fcc466c2c8ed", () => SyncResult);
			MetaPathParameterValues.Add("6201f425-7f69-417c-8235-f4500c09e1cc", () => CreateReminding);
			MetaPathParameterValues.Add("96ab4ed3-8e01-4f02-b7f7-d0a846900462", () => NoSuccessResultMessage);
			MetaPathParameterValues.Add("f285fbfd-bf94-40bc-b2d8-8832a994478a", () => SyncLDAPSubProcess.InvalidCredentialsErrorCode);
			MetaPathParameterValues.Add("bcb9fe1b-1383-4a07-a54f-7d94ab09bd6d", () => SyncLDAPSubProcess.InvalidCredentialMessage);
			MetaPathParameterValues.Add("33604bd1-55ce-48c3-af57-1d1202cf0085", () => SyncLDAPSubProcess.ConnectionNotEstablishedMessage);
			MetaPathParameterValues.Add("0cc77f35-10d3-4448-bf32-28943c7cc31f", () => SyncLDAPSubProcess.ErrorSyncResult);
			MetaPathParameterValues.Add("eec75451-e7bf-4f00-b7c0-7ee3a6e9ca37", () => SyncLDAPSubProcess.PageInstanceId);
			MetaPathParameterValues.Add("ff9d97aa-8ba0-473f-9be5-7a2b55f1c24a", () => SyncLDAPSubProcess.ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("3eb975cd-0ed7-47a1-9d12-d4007c226ef7", () => SyncLDAPSubProcess.DoOpenList);
			MetaPathParameterValues.Add("c783cb42-5282-4f5a-afa8-afeed3b9551e", () => SyncLDAPSubProcess.ShowLDAPMessageId);
			MetaPathParameterValues.Add("7ac36cd5-389e-438b-bfbf-3114cf7468cb", () => SyncLDAPSubProcess.NotLicensedUserNames);
			MetaPathParameterValues.Add("475b123b-f38e-48bc-a9b7-bd41831d66e0", () => SyncLDAPSubProcess.SyncResult);
			MetaPathParameterValues.Add("b9c722db-9aa2-4bbd-975c-57e0f24043ff", () => SyncLDAPSubProcess.NewUsersQuestionLS);
			MetaPathParameterValues.Add("e06dba72-10a6-4ba5-b295-308f2d0780c2", () => SyncLDAPSubProcess.NotActiveUsersLS);
			MetaPathParameterValues.Add("5a2c3e6b-1d0e-430f-becd-8b526bdc1447", () => SyncLDAPSubProcess.NewUsersInGroupLS);
			MetaPathParameterValues.Add("c11e43c4-5185-42f7-9c35-a3d9238f0466", () => SyncLDAPSubProcess.ProcessSynchWithLDAPLaunchedLS);
			MetaPathParameterValues.Add("533c2822-3b0b-484a-a8af-6971ccf43fbf", () => SyncLDAPSubProcess.ErrorCheckRequiredLDAPSettingsLS);
			MetaPathParameterValues.Add("8f6811b3-bb02-45cc-a8d4-35a26a09a789", () => SyncLDAPSubProcess.LDAPUsersWereAddedLS);
			MetaPathParameterValues.Add("14acfeda-eb6c-4cf9-895e-8aef99240705", () => SyncLDAPSubProcess.ServerErrorLS);
			MetaPathParameterValues.Add("ecb5a9ef-fceb-486a-8f75-7b37b133bbc5", () => SyncLDAPSubProcess.ProcessEnded);
			MetaPathParameterValues.Add("1624b549-a9c1-4272-b0fd-661736c639cb", () => SyncLDAPSubProcess.MessageLog);
			MetaPathParameterValues.Add("1607e605-c0c2-42bc-b81f-655a0a8b0599", () => SyncLDAPSubProcess.NoAccessMessage);
			MetaPathParameterValues.Add("eb9b5d94-fbda-4746-97ff-c1f57cc10411", () => SyncLDAPSubProcess.EmailSubject);
			MetaPathParameterValues.Add("72a6739b-378b-4fc0-b722-3e18bf6f9125", () => SyncLDAPSubProcess.EmailBody);
			MetaPathParameterValues.Add("9aedb4ec-6c8b-4653-bf51-8fc91ea985fb", () => SyncLDAPSubProcess.RecipientEmailsString);
			MetaPathParameterValues.Add("4c5a2579-4f4a-4b05-8c2b-eb3178b1dbf9", () => SyncLDAPSubProcess.LDAPEmailMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SyncResult":
					if (!hasValueToRead) break;
					SyncResult = reader.GetValue<System.String>();
				break;
				case "CreateReminding":
					if (!hasValueToRead) break;
					CreateReminding = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool CreateRemindingScriptTaskExecute(ProcessExecutingContext context) {
			CreateRemindingByProcess();
			return true;
		}

		public virtual bool SyncResultScriptTaskExecute(ProcessExecutingContext context) {
			string synchResult = SyncLDAPSubProcess.SyncResult;
			if (synchResult.IsNullOrEmpty()) {
				synchResult = NoSuccessResultMessage.Value;
			}
			SyncResult = synchResult;
			return true;
		}

			
			public virtual void FormatResult(string message) {
				string resultMessage = string.Format("{{\"key\": \"{0}\", \"message\": \"{1}\"}},",
					message, message);
				SyncResult = string.Format("{{ \"Messages\": [{0}] }}", resultMessage);
			}
			
			public virtual void CreateRemindingByProcess() {
				if (CreateReminding) {
					LDAPUtility.CreateRemindingByProcess(UserConnection, "RunLDAPSync",
						SyncResult, null, true);
				}
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
			var cloneItem = (RunLDAPSync)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

