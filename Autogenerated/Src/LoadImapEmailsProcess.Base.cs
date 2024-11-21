namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using IntegrationApi.Interfaces;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: LoadImapEmailsProcessSchema

	/// <exclude/>
	public class LoadImapEmailsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LoadImapEmailsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LoadImapEmailsProcessSchema(LoadImapEmailsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LoadImapEmailsProcess";
			UId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,89,91,111,219,54,20,126,118,129,254,7,213,79,114,97,43,78,226,220,144,11,16,59,118,235,173,105,188,42,89,158,105,137,78,132,201,148,75,82,73,188,33,255,125,231,144,148,117,119,212,98,216,128,181,15,150,168,195,239,28,158,203,199,67,230,253,187,85,60,15,3,207,122,10,184,140,73,104,77,199,44,94,82,78,230,33,61,251,20,7,254,133,245,137,202,81,204,57,101,242,78,80,126,77,130,112,30,189,184,107,230,61,242,136,5,127,18,25,68,204,165,82,6,236,65,220,77,125,97,119,172,191,222,191,107,61,17,110,45,183,10,143,153,12,228,218,245,30,233,146,88,231,22,162,143,34,198,168,135,66,78,246,235,53,97,228,129,114,7,76,153,50,33,9,243,232,112,253,149,44,169,221,206,216,147,224,182,59,167,70,63,205,96,252,22,83,190,6,53,140,62,91,227,226,184,253,182,242,174,213,92,215,40,10,227,37,3,101,37,3,156,75,223,215,95,237,230,206,193,117,207,120,176,36,124,173,231,170,165,119,148,234,178,134,73,16,74,202,5,106,178,65,160,66,98,196,41,145,84,203,221,7,242,113,70,56,0,226,36,91,15,142,162,229,138,240,64,68,236,118,189,162,206,248,59,100,70,215,66,176,86,219,93,139,75,127,25,176,59,22,200,118,183,24,181,76,166,56,83,255,63,50,17,227,228,82,254,4,54,224,71,176,18,131,142,217,108,183,143,7,131,73,255,120,255,168,55,190,188,236,247,6,147,65,191,55,60,57,60,232,29,237,78,14,174,134,39,227,203,241,225,184,221,233,108,194,250,29,205,249,70,69,28,74,81,25,80,136,141,142,21,132,38,212,94,40,100,147,194,226,84,198,156,89,11,30,45,45,174,224,172,128,229,209,5,197,249,230,43,226,162,241,38,91,126,39,97,108,10,210,46,103,154,131,9,129,106,94,223,191,195,255,133,154,70,127,128,67,125,156,72,66,129,21,157,186,40,243,193,70,124,85,180,250,19,84,115,90,203,198,104,93,64,5,68,91,45,49,88,88,118,110,178,245,225,92,121,221,25,47,87,114,173,161,74,181,98,202,171,76,0,96,101,78,194,110,87,84,101,187,99,17,97,85,124,64,131,54,28,164,45,42,240,13,109,78,48,122,190,174,245,45,160,165,26,5,45,213,146,53,21,253,35,248,245,216,250,187,64,29,102,17,13,205,77,245,123,186,140,211,181,155,184,15,103,215,110,180,144,160,130,45,130,135,152,43,202,114,82,177,170,204,215,128,27,37,226,54,154,80,233,61,26,196,47,129,144,103,66,114,224,188,11,157,32,173,54,208,2,100,155,104,119,245,235,44,226,50,121,6,124,215,253,146,188,77,133,43,9,151,183,161,104,227,192,107,65,93,149,170,172,3,244,202,47,140,223,23,17,112,14,8,219,121,123,177,76,203,214,155,100,110,229,21,41,66,107,28,149,20,85,211,77,11,170,183,165,170,168,228,126,71,193,79,128,60,174,134,77,162,217,205,87,113,183,224,144,78,98,190,225,154,207,145,192,202,46,171,53,145,56,205,10,99,56,42,133,241,67,78,18,131,37,194,74,89,29,199,156,116,18,202,74,249,52,210,27,79,189,166,172,170,17,106,249,239,87,186,86,252,57,35,1,63,171,216,196,187,69,62,83,77,79,170,93,37,117,21,77,110,109,132,138,212,185,189,115,202,16,107,193,186,170,154,202,163,102,108,107,64,207,91,141,174,164,108,156,217,100,13,165,44,221,238,159,124,18,22,55,169,243,250,109,170,145,45,233,84,80,117,90,175,8,83,145,27,178,110,4,156,200,191,133,57,35,66,60,71,220,255,17,220,100,206,54,108,151,50,31,74,31,253,107,202,179,169,134,242,204,92,49,149,118,249,159,168,27,196,107,20,159,110,117,254,102,123,165,98,85,239,124,44,212,245,83,4,117,56,227,20,26,65,186,93,219,12,118,247,155,21,101,240,108,227,47,190,163,191,111,137,248,195,138,10,3,77,207,47,106,14,148,204,121,166,189,92,120,244,248,248,112,64,123,71,243,254,110,111,176,119,66,123,39,123,187,180,215,63,56,220,247,142,246,14,124,248,77,207,12,219,241,63,241,192,175,210,225,29,123,116,119,159,244,123,251,199,251,135,189,193,156,28,245,230,251,199,39,240,116,66,247,250,187,131,254,238,190,167,117,20,87,230,224,75,218,74,27,212,171,64,17,11,108,30,102,35,238,90,102,67,182,55,150,174,146,137,56,233,45,88,232,200,234,49,19,42,194,128,13,163,151,73,20,66,78,226,10,115,196,163,152,161,82,143,246,70,99,207,169,12,79,173,87,59,116,59,6,192,169,255,214,233,197,185,141,92,101,179,57,106,189,90,52,20,84,37,135,245,243,182,109,179,139,83,15,138,95,89,102,200,15,112,166,126,209,87,157,146,101,85,177,198,60,7,105,211,206,42,203,146,23,163,191,52,5,30,140,11,46,193,33,79,96,219,3,210,162,228,49,178,221,235,199,157,154,66,76,218,194,187,169,115,79,231,224,80,201,35,96,170,205,195,53,80,141,90,42,163,161,89,153,82,156,29,207,95,27,48,163,26,78,155,146,46,17,213,249,44,229,10,17,233,11,244,159,218,74,231,51,97,126,8,221,41,100,92,141,13,136,179,41,183,140,58,35,0,42,182,76,132,131,42,243,205,200,112,61,10,3,208,9,225,72,236,131,43,129,33,17,185,85,64,228,208,91,105,133,103,87,126,94,105,65,189,237,149,254,203,16,100,22,45,27,159,42,154,116,31,163,231,177,31,200,36,13,13,164,241,250,206,78,133,177,181,129,58,45,206,0,97,93,221,206,36,226,75,34,237,175,148,250,160,169,154,148,13,152,222,61,222,44,148,52,215,219,67,56,152,107,221,89,75,177,116,146,213,52,209,155,199,252,218,238,116,161,46,22,202,110,16,26,145,21,254,64,3,173,165,149,66,219,206,240,25,178,212,134,205,58,6,84,116,84,5,23,10,181,107,53,49,168,80,205,175,245,65,188,138,158,89,24,17,95,109,225,2,27,45,163,48,215,146,102,91,79,81,108,158,138,125,85,177,183,77,49,28,181,247,39,116,253,161,124,58,159,138,9,92,210,196,156,142,25,94,23,2,127,221,132,218,180,41,84,233,131,62,28,66,200,210,115,191,80,205,131,16,48,14,118,140,66,232,118,38,196,147,145,190,70,57,155,186,233,247,11,56,238,35,148,185,188,1,205,224,241,24,101,47,249,3,220,80,50,9,52,238,149,40,188,163,79,134,181,83,68,169,5,2,136,146,147,42,58,37,115,68,203,172,64,31,88,204,225,81,87,100,194,197,18,110,26,213,162,99,1,97,213,39,74,56,157,173,220,55,214,63,205,203,92,168,203,177,250,229,231,86,94,227,138,218,217,94,186,220,42,23,188,49,59,140,30,2,150,144,221,166,147,47,172,209,193,103,92,19,166,155,113,84,43,41,152,81,20,51,108,52,139,115,190,209,101,36,233,232,145,176,68,40,109,82,45,143,224,113,222,70,204,241,139,71,85,169,90,20,212,183,80,230,199,89,204,76,121,38,28,91,67,83,251,166,45,130,235,61,129,175,201,238,88,60,135,57,247,185,89,6,174,142,153,242,42,186,22,117,82,26,212,15,234,30,211,96,106,227,26,211,206,166,104,51,184,21,61,66,53,179,40,234,200,181,27,106,100,145,52,27,25,46,9,141,107,92,117,83,89,116,8,154,108,174,57,170,239,229,97,191,132,222,70,203,33,121,213,220,222,171,239,95,232,66,222,196,208,78,254,18,5,0,167,250,17,184,235,208,204,218,238,56,55,229,65,128,199,115,153,6,104,193,149,129,186,20,174,53,197,12,167,83,156,251,71,202,105,21,44,90,189,193,51,87,174,155,126,215,222,120,74,221,69,106,223,160,199,51,197,239,207,199,47,212,139,161,132,170,254,208,33,128,67,175,134,233,16,68,76,119,153,240,207,108,245,224,123,71,67,80,215,35,33,225,230,46,56,5,222,30,100,157,55,153,48,151,25,206,254,103,35,93,86,240,255,139,252,117,161,47,255,87,19,32,57,163,213,164,192,223,46,245,213,148,218,27,0,0 };
			RealUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4fe53caa-18f6-4c4b-b63b-d475fe7b8a0f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b9ae9fb7-09a7-4689-89fe-c1c439f10368"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentUserMailboxSynchronizationSettingsUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ff591096-1b06-47b0-a988-cbd658b46fef"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"CurrentUserMailboxSynchronizationSettingsUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMailboxSynchronizationSettingsPageUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("be94aa4b-5b04-442f-88b6-6841d5c40218"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"MailboxSynchronizationSettingsPageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"fce8864e-7b01-429e-921e-0563c725d563",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetMailboxSynchronizationMessageUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9891be68-d59b-4533-9be3-85e194af599f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"NeedSetMailboxSynchronizationMessageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"{E9D59B5B-D6D0-47D6-9F8E-C475806C019C}",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateMailBoxFolderIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3be2837e-0163-4330-836b-ffca8a2909be"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"MailBoxFolderId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("532cb61b-8379-42bc-9a48-99fd98f7801b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessagesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("574326c8-1b08-4af9-9e49-7da640ea2c9e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"Messages",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessagesCountParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("562516d4-4d62-4421-b65f-3924fb92a101"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"MessagesCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9df9ed0b-1c24-40f3-94dc-f7cfa995d7db"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetMailboxSynchronizationMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("21444bbc-5fee-4669-9cb3-26a7af386911"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"NeedSetMailboxSynchronizationMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateInformationCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c7cc5b5d-0efd-428c-80d5-c6feea55dec6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"InformationCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessLoadEmailsMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e255669d-4628-4d24-b91e-f4e34a99cc0a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"SuccessLoadEmailsMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateCurrentUserMailboxSynchronizationSettingsUIdParameter());
			Parameters.Add(CreateMailboxSynchronizationSettingsPageUIdParameter());
			Parameters.Add(CreateNeedSetMailboxSynchronizationMessageUIdParameter());
			Parameters.Add(CreateMailBoxFolderIdParameter());
			Parameters.Add(CreateLoadResultParameter());
			Parameters.Add(CreateMessagesParameter());
			Parameters.Add(CreateMessagesCountParameter());
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateNeedSetMailboxSynchronizationMessageParameter());
			Parameters.Add(CreateInformationCaptionParameter());
			Parameters.Add(CreateSuccessLoadEmailsMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLoadImapEmailsUserTaskLaneSet = CreateLoadImapEmailsUserTaskLaneSetLaneSet();
			LaneSets.Add(schemaLoadImapEmailsUserTaskLaneSet);
			ProcessSchemaLane schemaLoadImapEmailsUserTaskLane = CreateLoadImapEmailsUserTaskLaneLane();
			schemaLoadImapEmailsUserTaskLaneSet.Lanes.Add(schemaLoadImapEmailsUserTaskLane);
			ProcessSchemaStartEvent loadimapemailsusertaskstart = CreateLoadImapEmailsUserTaskStartStartEvent();
			FlowElements.Add(loadimapemailsusertaskstart);
			ProcessSchemaEndEvent loadimapemailsusertaskend = CreateLoadImapEmailsUserTaskEndEndEvent();
			FlowElements.Add(loadimapemailsusertaskend);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("336acfd9-6be3-4f8e-9ee0-842af3c10118"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				CurveCenterPosition = new Point(374, 210),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fb4cf670-1ecc-4fbe-ad34-44ab952d9f62"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("4fcbcae3-6713-47fc-ade0-561c841d572b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				CurveCenterPosition = new Point(440, 212),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("279c7f52-7577-4bf9-a283-8d6621415e69"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLoadImapEmailsUserTaskLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaLoadImapEmailsUserTaskLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("21cd00c5-c917-4b96-a25b-d555ef360329"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLoadImapEmailsUserTaskLaneSet;
		}

		protected virtual ProcessSchemaLane CreateLoadImapEmailsUserTaskLaneLane() {
			ProcessSchemaLane schemaLoadImapEmailsUserTaskLane = new ProcessSchemaLane(this) {
				UId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("21cd00c5-c917-4b96-a25b-d555ef360329"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLoadImapEmailsUserTaskLane;
		}

		protected virtual ProcessSchemaStartEvent CreateLoadImapEmailsUserTaskStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("fb4cf670-1ecc-4fbe-ad34-44ab952d9f62"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskStart",
				Position = new Point(50, 191),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateLoadImapEmailsUserTaskEndEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("279c7f52-7577-4bf9-a283-8d6621415e69"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"LoadImapEmailsUserTaskEnd",
				Position = new Point(547, 191),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a105506e-8d97-4c59-8fb8-a2e5b037ce28"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"),
				Name = @"ScriptTask1",
				Position = new Point(267, 177),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,147,81,79,219,48,20,133,159,139,196,127,184,228,1,37,162,137,18,65,17,99,235,164,209,164,168,26,29,18,21,123,161,60,120,205,165,181,148,216,147,237,80,186,42,255,125,118,236,38,93,181,13,41,15,177,125,239,185,223,57,113,166,40,37,89,162,132,33,48,92,67,74,23,138,114,70,196,230,211,109,69,243,62,72,37,40,91,126,246,131,143,199,71,175,68,128,224,92,101,37,161,197,152,23,57,138,73,238,26,77,181,239,37,87,201,248,67,122,126,17,14,210,44,11,179,56,73,194,47,87,151,55,97,28,39,131,65,26,95,140,226,36,245,140,20,125,1,127,170,85,110,248,91,39,52,108,84,162,172,252,169,54,1,108,143,143,122,179,21,95,103,57,85,51,84,74,99,200,169,165,109,104,122,2,85,37,24,40,81,161,94,214,86,244,47,124,67,56,152,100,181,141,27,154,27,227,183,168,70,149,16,200,212,163,68,97,138,127,240,183,217,134,45,86,130,51,250,139,152,68,118,4,143,147,92,218,241,102,154,238,143,70,188,98,202,15,204,156,216,42,255,31,91,131,246,94,184,64,178,88,249,150,1,40,51,36,174,57,229,107,86,112,146,55,46,228,88,240,210,225,235,105,86,0,180,91,192,66,98,235,163,180,204,205,215,208,110,156,133,73,126,152,113,11,222,53,156,236,167,14,167,167,240,199,17,171,138,226,93,174,182,195,225,181,104,239,6,161,159,6,191,187,132,246,190,89,26,93,180,31,148,171,50,105,249,255,186,167,129,155,224,194,108,133,207,90,229,49,23,37,81,190,183,221,206,61,154,207,189,107,152,123,219,184,158,123,125,253,226,234,221,110,162,119,235,186,175,79,220,126,244,21,55,221,226,59,41,42,52,78,220,213,59,113,19,38,242,155,78,237,94,52,30,252,29,66,112,64,52,108,93,71,15,88,242,87,108,43,163,59,100,75,181,130,16,18,167,126,167,99,127,64,89,21,170,75,168,243,161,81,119,174,13,248,147,118,243,12,117,221,97,75,35,179,255,183,252,6,75,100,250,205,245,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("276b5906-88fa-4d43-a6ea-8d6213245d72"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3e068d19-8d8c-4768-b6a9-83bd4995c9bc"),
				Name = "BPMSoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b6da2fd2-6cc9-4667-ab57-4f614f3fc9ca"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ef7eb62b-f609-42c2-af07-585c5670410d"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a973b80b-c06f-4f64-b532-26268ad871c3"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("997719b8-45ce-4814-939a-6ff72a85e213"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LoadImapEmailsProcess(userConnection);
		}

		public override object Clone() {
			return new LoadImapEmailsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f9740b2-eaba-4296-af86-64b5692d7435"));
		}

		#endregion

	}

	#endregion

	#region Class: LoadImapEmailsProcess

	/// <exclude/>
	public class LoadImapEmailsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLoadImapEmailsUserTaskLane

		/// <exclude/>
		public class ProcessLoadImapEmailsUserTaskLane : ProcessLane
		{

			public ProcessLoadImapEmailsUserTaskLane(UserConnection userConnection, LoadImapEmailsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public LoadImapEmailsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoadImapEmailsProcess";
			SchemaUId = new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2f9740b2-eaba-4296-af86-64b5692d7435");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LoadImapEmailsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LoadImapEmailsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid CurrentUserMailboxSynchronizationSettingsUId {
			get;
			set;
		}

		private Guid _mailboxSynchronizationSettingsPageUId = new Guid("fce8864e-7b01-429e-921e-0563c725d563");
		public Guid MailboxSynchronizationSettingsPageUId {
			get {
				return _mailboxSynchronizationSettingsPageUId;
			}
			set {
				_mailboxSynchronizationSettingsPageUId = value;
			}
		}

		private Guid _needSetMailboxSynchronizationMessageUId = new Guid("{E9D59B5B-D6D0-47D6-9F8E-C475806C019C}");
		public Guid NeedSetMailboxSynchronizationMessageUId {
			get {
				return _needSetMailboxSynchronizationMessageUId;
			}
			set {
				_needSetMailboxSynchronizationMessageUId = value;
			}
		}

		public virtual Guid MailBoxFolderId {
			get;
			set;
		}

		public virtual string LoadResult {
			get;
			set;
		}

		public virtual Object Messages {
			get;
			set;
		}

		public virtual int MessagesCount {
			get;
			set;
		}

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		private LocalizableString _needSetMailboxSynchronizationMessage;
		public virtual LocalizableString NeedSetMailboxSynchronizationMessage {
			get {
				return _needSetMailboxSynchronizationMessage ?? (_needSetMailboxSynchronizationMessage = GetLocalizableString("2f9740b2eaba4296af8664b5692d7435",
						 "Parameters.NeedSetMailboxSynchronizationMessage.Value"));
			}
			set {
				_needSetMailboxSynchronizationMessage = value;
			}
		}

		private LocalizableString _informationCaption;
		public virtual LocalizableString InformationCaption {
			get {
				return _informationCaption ?? (_informationCaption = GetLocalizableString("2f9740b2eaba4296af8664b5692d7435",
						 "Parameters.InformationCaption.Value"));
			}
			set {
				_informationCaption = value;
			}
		}

		private LocalizableString _successLoadEmailsMessage;
		public virtual LocalizableString SuccessLoadEmailsMessage {
			get {
				return _successLoadEmailsMessage ?? (_successLoadEmailsMessage = GetLocalizableString("2f9740b2eaba4296af8664b5692d7435",
						 "Parameters.SuccessLoadEmailsMessage.Value"));
			}
			set {
				_successLoadEmailsMessage = value;
			}
		}

		private ProcessLoadImapEmailsUserTaskLane _loadImapEmailsUserTaskLane;
		public ProcessLoadImapEmailsUserTaskLane LoadImapEmailsUserTaskLane {
			get {
				return _loadImapEmailsUserTaskLane ?? ((_loadImapEmailsUserTaskLane) = new ProcessLoadImapEmailsUserTaskLane(UserConnection, this));
			}
		}

		private ProcessFlowElement _loadImapEmailsUserTaskStart;
		public ProcessFlowElement LoadImapEmailsUserTaskStart {
			get {
				return _loadImapEmailsUserTaskStart ?? (_loadImapEmailsUserTaskStart = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "LoadImapEmailsUserTaskStart",
					SchemaElementUId = new Guid("fb4cf670-1ecc-4fbe-ad34-44ab952d9f62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _loadImapEmailsUserTaskEnd;
		public ProcessEndEvent LoadImapEmailsUserTaskEnd {
			get {
				return _loadImapEmailsUserTaskEnd ?? (_loadImapEmailsUserTaskEnd = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "LoadImapEmailsUserTaskEnd",
					SchemaElementUId = new Guid("279c7f52-7577-4bf9-a283-8d6621415e69"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("9ddd22ce-1f21-454f-8dff-aa6510f4434e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[LoadImapEmailsUserTaskStart.SchemaElementUId] = new Collection<ProcessFlowElement> { LoadImapEmailsUserTaskStart };
			FlowElements[LoadImapEmailsUserTaskEnd.SchemaElementUId] = new Collection<ProcessFlowElement> { LoadImapEmailsUserTaskEnd };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "LoadImapEmailsUserTaskStart":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "LoadImapEmailsUserTaskEnd":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LoadImapEmailsUserTaskEnd", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("CurrentUserMailboxSynchronizationSettingsUId")) {
				writer.WriteValue("CurrentUserMailboxSynchronizationSettingsUId", CurrentUserMailboxSynchronizationSettingsUId, Guid.Empty);
			}
			if (!HasMapping("MailboxSynchronizationSettingsPageUId")) {
				writer.WriteValue("MailboxSynchronizationSettingsPageUId", MailboxSynchronizationSettingsPageUId, Guid.Empty);
			}
			if (!HasMapping("NeedSetMailboxSynchronizationMessageUId")) {
				writer.WriteValue("NeedSetMailboxSynchronizationMessageUId", NeedSetMailboxSynchronizationMessageUId, Guid.Empty);
			}
			if (!HasMapping("MailBoxFolderId")) {
				writer.WriteValue("MailBoxFolderId", MailBoxFolderId, Guid.Empty);
			}
			if (!HasMapping("LoadResult")) {
				writer.WriteValue("LoadResult", LoadResult, null);
			}
			if (Messages != null) {
				if (Messages.GetType().IsSerializable ||
					Messages.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Messages", Messages, null);
				}
			}
			if (!HasMapping("MessagesCount")) {
				writer.WriteValue("MessagesCount", MessagesCount, 0);
			}
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("LoadImapEmailsUserTaskStart", string.Empty));
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
			MetaPathParameterValues.Add("4fe53caa-18f6-4c4b-b63b-d475fe7b8a0f", () => PageInstanceId);
			MetaPathParameterValues.Add("b9ae9fb7-09a7-4689-89fe-c1c439f10368", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("ff591096-1b06-47b0-a988-cbd658b46fef", () => CurrentUserMailboxSynchronizationSettingsUId);
			MetaPathParameterValues.Add("be94aa4b-5b04-442f-88b6-6841d5c40218", () => MailboxSynchronizationSettingsPageUId);
			MetaPathParameterValues.Add("9891be68-d59b-4533-9be3-85e194af599f", () => NeedSetMailboxSynchronizationMessageUId);
			MetaPathParameterValues.Add("3be2837e-0163-4330-836b-ffca8a2909be", () => MailBoxFolderId);
			MetaPathParameterValues.Add("532cb61b-8379-42bc-9a48-99fd98f7801b", () => LoadResult);
			MetaPathParameterValues.Add("574326c8-1b08-4af9-9e49-7da640ea2c9e", () => Messages);
			MetaPathParameterValues.Add("562516d4-4d62-4421-b65f-3924fb92a101", () => MessagesCount);
			MetaPathParameterValues.Add("9df9ed0b-1c24-40f3-94dc-f7cfa995d7db", () => SenderEmailAddress);
			MetaPathParameterValues.Add("21444bbc-5fee-4669-9cb3-26a7af386911", () => NeedSetMailboxSynchronizationMessage);
			MetaPathParameterValues.Add("c7cc5b5d-0efd-428c-80d5-c6feea55dec6", () => InformationCaption);
			MetaPathParameterValues.Add("e255669d-4628-4d24-b91e-f4e34a99cc0a", () => SuccessLoadEmailsMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "ActiveTreeGridCurrentRowId":
					if (!hasValueToRead) break;
					ActiveTreeGridCurrentRowId = reader.GetValue<System.Guid>();
				break;
				case "CurrentUserMailboxSynchronizationSettingsUId":
					if (!hasValueToRead) break;
					CurrentUserMailboxSynchronizationSettingsUId = reader.GetValue<System.Guid>();
				break;
				case "MailboxSynchronizationSettingsPageUId":
					if (!hasValueToRead) break;
					MailboxSynchronizationSettingsPageUId = reader.GetValue<System.Guid>();
				break;
				case "NeedSetMailboxSynchronizationMessageUId":
					if (!hasValueToRead) break;
					NeedSetMailboxSynchronizationMessageUId = reader.GetValue<System.Guid>();
				break;
				case "MailBoxFolderId":
					if (!hasValueToRead) break;
					MailBoxFolderId = reader.GetValue<System.Guid>();
				break;
				case "LoadResult":
					if (!hasValueToRead) break;
					LoadResult = reader.GetValue<System.String>();
				break;
				case "Messages":
					if (!hasValueToRead) break;
					Messages = reader.GetSerializableObjectValue();
				break;
				case "MessagesCount":
					if (!hasValueToRead) break;
					MessagesCount = reader.GetValue<System.Int32>();
				break;
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			Messages = new Dictionary<Guid, string>();
			var rootEmailFolderId = new Guid("181F9D34-5DEE-E011-A86B-00155D04C01D");
			if (MailBoxFolderId == Guid.Empty) {
				ShowEditSettingsMessage();
				return true;
			}
			if (rootEmailFolderId == MailBoxFolderId) {
				var ids = GetCurrentUserMailboxSynchronizationSettingsUIds();
				if (ids.Count() == 0) {
					ShowEditSettingsMessage();
				}
				foreach(var id in ids) {
					DownloadEmailsFromMailBox(id);
				} 
			} else {
				var mailboxId = GetMailboxId(MailBoxFolderId);
				if (mailboxId != Guid.Empty && mailboxId != null) {
					DownloadEmailsFromMailBox(mailboxId);
				} else {
					ShowEditSettingsMessage();
				}
			}
			var messages = string.Empty;
			foreach(var message in (Dictionary<Guid, string>)Messages) {
				messages += string.Format("{{\"id\": \"{0}\", \"message\": \"{1}\"}},", message.Key, message.Value);
			}
			if (!string.IsNullOrEmpty(messages)) {
				messages = messages.Remove(messages.Length - 1);
			}
			LoadResult = string.Format("{{ \"Messages\": [{0}] }}", messages);
			return true;
		}

			
			public virtual IEnumerable<Guid> GetCurrentUserMailboxSynchronizationSettingsUIds() {
				var mailboxSynchronizationSettingsEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
				var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MailboxSyncSettings");
				var entitySchemaColumn = entitySchemaQuery.AddColumn(mailboxSynchronizationSettingsEntitySchema.GetPrimaryColumnName());
				entitySchemaQuery.Filters.Add(
					entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
						"SysAdminUnit", UserConnection.CurrentUser.Id));
				entitySchemaQuery.Filters.Add(
					entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, 
						"MailServer.Type", new Guid("844F0837-EAA0-4F40-B965-71F5DB9EAE6E")));
				var queryResults = entitySchemaQuery.GetEntityCollection(UserConnection);
				return from result in queryResults select result.GetTypedColumnValue<Guid>(entitySchemaColumn.Name);
			}
			
			
			public virtual MailCredentials GetMailServerCredentials(Guid mailServerUId) {
				var result = new MailCredentials();
				if (mailServerUId != Guid.Empty) {
					var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
					var mailServerEntitySchema = entitySchemaManager.GetInstanceByName("MailServer");
					var mailServerEntitySchemaPrimaryColumnName = mailServerEntitySchema.GetPrimaryColumnName();
					var mailServerEntitySchemaPrimaryColumn = mailServerEntitySchema.Columns.GetByName(mailServerEntitySchemaPrimaryColumnName);
					var currentMailServer = new BPMSoft.Configuration.MailServer(UserConnection);
					var columnNamesToFetch = new List<string> {
						"Address",
						"Port",
						"UseSSL",
						"IsStartTls"
					};
					var columnsToFetch = new List<EntitySchemaColumn>();
					foreach (var columnName in columnNamesToFetch) {
						columnsToFetch.Add(mailServerEntitySchema.Columns.GetByName(columnName));
					}
					if (currentMailServer.FetchFromDB(mailServerEntitySchemaPrimaryColumn, mailServerUId, columnsToFetch)) {
						result.Host = currentMailServer.Address;
						result.Port = currentMailServer.Port;
						result.UseSsl = currentMailServer.UseSSL;
						result.StartTls = currentMailServer.IsStartTls;
					}
				}
				return result;
			}
			
			
			public virtual KeyValuePair<MailboxSyncSettings, MailCredentials> GetMailServerUserCredentials(Guid mailboxSynchronizationSettingsUId) {
				var resultMailboxSynchronizationSettings = new MailboxSyncSettings(UserConnection);
				var resultMailCredentials= new MailCredentials();
				if (mailboxSynchronizationSettingsUId != Guid.Empty) {
					if (resultMailboxSynchronizationSettings.FetchFromDB(mailboxSynchronizationSettingsUId)) {
						resultMailCredentials = GetMailServerCredentials(resultMailboxSynchronizationSettings.MailServerId);
						resultMailCredentials.UserName = resultMailboxSynchronizationSettings.UserName;
						resultMailCredentials.UserPassword = resultMailboxSynchronizationSettings.UserPassword;
						resultMailCredentials.SenderEmailAddress = resultMailboxSynchronizationSettings.SenderEmailAddress;
					}
				}
				var result = new KeyValuePair<MailboxSyncSettings, MailCredentials> 
					(resultMailboxSynchronizationSettings, resultMailCredentials);
				return result;
			}
			
			
			/*public virtual void PrepareMailboxSynchronizationSettingsPageOpening(OpenPageUserTask openPageUserTask) {
				var mailboxSynchronizationSettingsPageUId = new Guid("fce8864e-7b01-429e-921e-0563c725d563");
				var mailboxSynchronizationSettingsGridPageUId = new Guid("c8ce13a0-3836-4ba7-b389-4b9e2014013c");
				openPageUserTask.PageParameters = new Dictionary<string, string>();
				var pageParams = openPageUserTask.PageParameters as Dictionary<string, string>;
				if (MailBoxFolderId == Guid.Empty){
					openPageUserTask.PageUId = mailboxSynchronizationSettingsGridPageUId;
					pageParams.Add("userId", UserConnection.CurrentUser.Id.ToString());
				} else {
				 	openPageUserTask.PageUId = mailboxSynchronizationSettingsPageUId;
					pageParams.Add("recordId", GetMailboxId(MailBoxFolderId).ToString());
				}
				openPageUserTask.OpenerInstanceId = InstanceUId;
				openPageUserTask.UseCurrentActivePage = true;
			}*/
			
			
			/*public virtual BPMSoft.UI.WebControls.Controls.MessagePanel GetMainPageMessagePanel() {
				var mainPage = System.Web.HttpContext.Current.Handler as BPMSoft.UI.WebControls.Page;
				var messagePanelControl = BPMSoft.UI.WebControls.Page.FindControlByClientId(mainPage, "BaseMessagePanel", true);
				var messagePanel = messagePanelControl as BPMSoft.UI.WebControls.Controls.MessagePanel;
				return messagePanel;
			}*/
			
			
			public virtual void ShowEditSettingsMessage() {
				//var messagePanel = GetMainPageMessagePanel();
				//var message = string.Format(NeedSetMailboxSynchronizationMessage, MailboxSynchronizationSettingsPageUId.ToString("B"));
				//messagePanel.AddMessage(NeedSetMailboxSynchronizationMessageUId.ToString("N"), InformationCaption, message);
				((Dictionary<Guid, string>)Messages).Add(MailBoxFolderId, NeedSetMailboxSynchronizationMessage.ToString());
			}
			
			
			public virtual void DownloadEmailsFromMailBox(Guid mailboxId) {
				var serverCredentials = GetMailServerUserCredentials(mailboxId).Value;
				if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
					var syncSession = ClassFactory.Get<ISyncSession>("Email", new ConstructorArgument("uc", UserConnection),
						new ConstructorArgument("senderEmailAddress", serverCredentials.SenderEmailAddress));
					syncSession.Start();
					return;
				}
				try {
					using (var imapSyncSession = ClassFactory.Get<IImapSyncSession>(
					new ConstructorArgument("userConnection", UserConnection),
					new ConstructorArgument("credentials", serverCredentials),
					new ConstructorArgument("login", true))) {
						imapSyncSession.SyncImapMail();
						MessagesCount = imapSyncSession.RemoteChangesCount;
					}
				} catch (ImapException e) {	
					//var messagePanel = GetMainPageMessagePanel();
					//var warningCaption = new QuestionUserTask(UserConnection).WarningCaption;
					//messagePanel.AddMessage(warningCaption, e.Message, MessageType.Warning);
					((Dictionary<Guid, string>)Messages).Add(mailboxId, e.Message.ToString());
				}
			}
			
			
			public virtual Guid GetMailboxId(Guid folderId) {
				var sel = new Select(UserConnection)
					.Column("MailboxSyncSettings", "Id")
					.From("MailboxSyncSettings")
					.LeftOuterJoin("ActivityFolder").On("ActivityFolder", "Name")
						.IsEqual("MailboxSyncSettings", "MailboxName")
					.Where("ActivityFolder", "Id").IsEqual(Column.Parameter(folderId)) as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				    return sel.ExecuteScalar<Guid>(dbExecutor);
				}
			}
			
			
			public virtual string GetMailboxSenderEmailAddress() {
				var sel = new Select(UserConnection)
					.Column("MailboxSyncSettings", "SenderEmailAddress")
					.From("MailboxSyncSettings")
					.LeftOuterJoin("ActivityFolder").On("ActivityFolder", "Name")
						.IsEqual("MailboxSyncSettings", "MailboxName")
					.Where("ActivityFolder", "Id").IsEqual(Column.Parameter(MailBoxFolderId)) as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				    return sel.ExecuteScalar<string>(dbExecutor);
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
			var cloneItem = (LoadImapEmailsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Messages = Messages;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

