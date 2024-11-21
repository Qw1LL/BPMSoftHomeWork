namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.MandrillService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
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

	#region Class: UpdateTargetAudienceProcessSchema

	/// <exclude/>
	public class UpdateTargetAudienceProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public UpdateTargetAudienceProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public UpdateTargetAudienceProcessSchema(UpdateTargetAudienceProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "UpdateTargetAudienceProcess";
			UId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37");
			CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37");
			Version = 0;
			PackageUId = new Guid("883305e0-1bdc-497c-a518-bbe2bd7bf1c3");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateTargetSchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f65369cb-ab82-414a-945a-59e9c8482e10"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"TargetSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTargetFolderSchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a94dc61d-8e34-478c-99b3-5c9f0feee8ae"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"TargetFolderSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRootSchemaRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("135bcc1d-bca0-46c7-bce1-5e822af82bae"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"RootSchemaRecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTargetSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e7bfb385-9147-4c21-8b13-f66c80c51207"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"TargetSchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTargetSchemaBindingColumnValueNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4a647122-7876-4827-9514-2bf21714309e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"TargetSchemaBindingColumnValueName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRootSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f454fd08-2214-4a01-b0ad-7abc9236f933"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"RootSchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSegmentSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b8bd6e76-7cdb-4da7-93cf-bf8db8633278"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"SegmentSchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDefResponseIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("216d1947-3e22-4554-91d2-a32beab8fa94"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"DefResponseId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateResponseColumnNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7a46110a-ff72-49e8-b1ea-4af281e3679d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"ResponseColumnName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTargetNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1a80a615-67eb-4ac6-8d93-4af4f62db8bb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"TargetName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSegmentTargetReferenceSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f9fb7850-e2b3-4df5-a668-efaf667239d4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"SegmentTargetReferenceSchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoggerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6c81130b-4301-4a3d-8b55-6f2b414f2f2a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"Logger",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSessionKeyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3cfe05e4-c735-4adb-84a7-c7f1be972a24"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"SessionKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRootSchemaRecordRIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("36e28d83-36ad-4d30-855c-d92c8c092899"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"RootSchemaRecordRId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessStatusIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9b29d5eb-bb38-4bbd-bb36-1daf124828a9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"SuccessStatusId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsSetCampaignFirstStepParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("67318a1f-ff32-49f2-9fd6-c2acada5472c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"IsSetCampaignFirstStep",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("196f09e4-75e9-4c74-ad18-9d0c13b1bd96"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"SuccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateRemindingCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("03951f65-ea37-4345-b626-7e47a0736d11"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"RemindingCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateEventRemindingCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e57643ca-d156-4a68-9033-7b62654594e2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"EventRemindingCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCampaignRemindingCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e0ca4181-ec0c-445f-9983-94f42ff8946b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("919d1406-f784-40ca-b1dc-bf0f04e5a2ce"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"CampaignRemindingCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateFailMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b9ae0c46-9105-4e99-acb4-4efd209d4d17"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("d6253bad-76e1-4d34-9458-192b873c5402"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"FailMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateTargetSchemaUIdParameter());
			Parameters.Add(CreateTargetFolderSchemaUIdParameter());
			Parameters.Add(CreateRootSchemaRecordIdParameter());
			Parameters.Add(CreateTargetSchemaNameParameter());
			Parameters.Add(CreateTargetSchemaBindingColumnValueNameParameter());
			Parameters.Add(CreateRootSchemaNameParameter());
			Parameters.Add(CreateSegmentSchemaNameParameter());
			Parameters.Add(CreateDefResponseIdParameter());
			Parameters.Add(CreateResponseColumnNameParameter());
			Parameters.Add(CreateTargetNameParameter());
			Parameters.Add(CreateSegmentTargetReferenceSchemaNameParameter());
			Parameters.Add(CreateLoggerParameter());
			Parameters.Add(CreateSessionKeyParameter());
			Parameters.Add(CreateRootSchemaRecordRIdParameter());
			Parameters.Add(CreateSuccessStatusIdParameter());
			Parameters.Add(CreateIsSetCampaignFirstStepParameter());
			Parameters.Add(CreateSuccessMessageParameter());
			Parameters.Add(CreateRemindingCaptionParameter());
			Parameters.Add(CreateEventRemindingCaptionParameter());
			Parameters.Add(CreateCampaignRemindingCaptionParameter());
			Parameters.Add(CreateFailMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaMainLaneSet = CreateMainLaneSetLaneSet();
			LaneSets.Add(schemaMainLaneSet);
			ProcessSchemaLane schemaMainLane = CreateMainLaneLane();
			schemaMainLaneSet.Lanes.Add(schemaMainLane);
			ProcessSchemaStartEvent startprocess = CreateStartProcessStartEvent();
			FlowElements.Add(startprocess);
			ProcessSchemaTerminateEvent terminateprocess = CreateTerminateProcessTerminateEvent();
			FlowElements.Add(terminateprocess);
			ProcessSchemaScriptTask processscripttask = CreateProcessScriptTaskScriptTask();
			FlowElements.Add(processscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("352057e2-2fe3-42ba-8884-bc25c37fa23a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7ecf7ac7-4ab2-4d68-8394-8f918ec112c7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3c2692f1-b937-4938-be4b-a0d69b3203aa"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("55042cf7-56c0-4a60-bafd-5679f1f9ccea"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3c2692f1-b937-4938-be4b-a0d69b3203aa"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6b1ec621-ec4e-45ca-a64d-e9a481e1e0f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateMainLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaMainLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a2e87067-697d-4ffc-9d56-3bb994af6073"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"MainLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaMainLaneSet;
		}

		protected virtual ProcessSchemaLane CreateMainLaneLane() {
			ProcessSchemaLane schemaMainLane = new ProcessSchemaLane(this) {
				UId = new Guid("9ff77051-ffdc-4070-8fce-29158f915638"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a2e87067-697d-4ffc-9d56-3bb994af6073"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"MainLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaMainLane;
		}

		protected virtual ProcessSchemaStartEvent CreateStartProcessStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("7ecf7ac7-4ab2-4d68-8394-8f918ec112c7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("9ff77051-ffdc-4070-8fce-29158f915638"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"StartProcess",
				Position = new Point(57, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("6b1ec621-ec4e-45ca-a64d-e9a481e1e0f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("9ff77051-ffdc-4070-8fce-29158f915638"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"TerminateProcess",
				Position = new Point(358, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateProcessScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("3c2692f1-b937-4938-be4b-a0d69b3203aa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("9ff77051-ffdc-4070-8fce-29158f915638"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266"),
				CreatedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"),
				Name = @"ProcessScriptTask",
				Position = new Point(155, 37),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,106,195,48,12,134,207,43,244,29,76,79,41,140,246,1,186,13,218,64,183,50,54,70,210,238,46,28,45,51,36,114,144,229,141,190,253,236,140,29,220,5,154,28,253,235,215,103,249,183,189,94,191,128,161,108,185,153,207,190,128,149,239,42,16,60,2,215,40,91,95,25,36,141,111,108,53,58,247,132,77,135,172,238,85,222,128,115,123,208,98,249,188,122,68,185,59,93,107,122,200,230,179,27,194,111,149,91,114,194,62,182,110,185,246,45,146,100,11,239,144,67,129,80,139,177,180,184,85,167,68,88,198,217,174,206,181,42,172,149,82,127,98,11,5,106,203,213,161,10,163,254,23,39,178,94,161,197,132,19,133,81,140,18,235,120,188,95,75,129,31,200,209,147,80,175,89,70,238,227,92,72,233,25,207,61,241,111,49,174,215,235,184,42,5,196,187,62,176,11,101,20,229,224,74,148,28,218,14,76,77,123,195,78,74,193,46,192,134,11,163,152,233,19,8,172,84,152,114,3,67,145,79,204,248,216,215,18,208,165,52,153,179,51,84,25,170,115,219,248,150,222,161,241,56,64,30,54,141,75,112,192,209,127,115,70,241,76,42,124,67,220,252,0,26,98,201,213,254,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bc0fdf07-97e4-42b6-9683-ca433eca68ac"),
				Name = "BPMSoft.Configuration.MandrillService",
				Alias = "",
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fa674b9d-6bd8-42dc-ba6b-f763086e6ae1"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5059ab4d-1e12-420f-8087-43327c731c4d"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7b7bbe19-7d82-4c7a-abfb-5f27604b364c"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b6833282-46a4-4232-af7d-557cbcce2d5e"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("d29fa55e-3363-47c1-bff2-631609e0e3ec")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new UpdateTargetAudienceProcess(userConnection);
		}

		public override object Clone() {
			return new UpdateTargetAudienceProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("35495b19-5d3e-46fc-9729-4ff00543af37"));
		}

		#endregion

	}

	#endregion

	#region Class: UpdateTargetAudienceProcess

	/// <exclude/>
	public class UpdateTargetAudienceProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessMainLane

		/// <exclude/>
		public class ProcessMainLane : ProcessLane
		{

			public ProcessMainLane(UserConnection userConnection, UpdateTargetAudienceProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public UpdateTargetAudienceProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UpdateTargetAudienceProcess";
			SchemaUId = new Guid("35495b19-5d3e-46fc-9729-4ff00543af37");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("35495b19-5d3e-46fc-9729-4ff00543af37");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: UpdateTargetAudienceProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: UpdateTargetAudienceProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid TargetSchemaUId {
			get;
			set;
		}

		public virtual Guid TargetFolderSchemaUId {
			get;
			set;
		}

		public virtual Guid RootSchemaRecordId {
			get;
			set;
		}

		public virtual string TargetSchemaName {
			get;
			set;
		}

		public virtual string TargetSchemaBindingColumnValueName {
			get;
			set;
		}

		public virtual string RootSchemaName {
			get;
			set;
		}

		public virtual string SegmentSchemaName {
			get;
			set;
		}

		public virtual Guid DefResponseId {
			get;
			set;
		}

		public virtual string ResponseColumnName {
			get;
			set;
		}

		public virtual string TargetName {
			get;
			set;
		}

		public virtual string SegmentTargetReferenceSchemaName {
			get;
			set;
		}

		public virtual Object Logger {
			get;
			set;
		}

		public virtual string SessionKey {
			get;
			set;
		}

		public virtual int RootSchemaRecordRId {
			get;
			set;
		}

		public virtual Guid SuccessStatusId {
			get;
			set;
		}

		public virtual bool IsSetCampaignFirstStep {
			get;
			set;
		}

		private LocalizableString _successMessage;
		public virtual LocalizableString SuccessMessage {
			get {
				return _successMessage ?? (_successMessage = GetLocalizableString("35495b195d3e46fc97294ff00543af37",
						 "Parameters.SuccessMessage.Value"));
			}
			set {
				_successMessage = value;
			}
		}

		private LocalizableString _remindingCaption;
		public virtual LocalizableString RemindingCaption {
			get {
				return _remindingCaption ?? (_remindingCaption = GetLocalizableString("35495b195d3e46fc97294ff00543af37",
						 "Parameters.RemindingCaption.Value"));
			}
			set {
				_remindingCaption = value;
			}
		}

		private LocalizableString _eventRemindingCaption;
		public virtual LocalizableString EventRemindingCaption {
			get {
				return _eventRemindingCaption ?? (_eventRemindingCaption = GetLocalizableString("35495b195d3e46fc97294ff00543af37",
						 "Parameters.EventRemindingCaption.Value"));
			}
			set {
				_eventRemindingCaption = value;
			}
		}

		private LocalizableString _campaignRemindingCaption;
		public virtual LocalizableString CampaignRemindingCaption {
			get {
				return _campaignRemindingCaption ?? (_campaignRemindingCaption = GetLocalizableString("35495b195d3e46fc97294ff00543af37",
						 "Parameters.CampaignRemindingCaption.Value"));
			}
			set {
				_campaignRemindingCaption = value;
			}
		}

		private LocalizableString _failMessage;
		public virtual LocalizableString FailMessage {
			get {
				return _failMessage ?? (_failMessage = GetLocalizableString("35495b195d3e46fc97294ff00543af37",
						 "Parameters.FailMessage.Value"));
			}
			set {
				_failMessage = value;
			}
		}

		private ProcessMainLane _mainLane;
		public ProcessMainLane MainLane {
			get {
				return _mainLane ?? ((_mainLane) = new ProcessMainLane(UserConnection, this));
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
					SchemaElementUId = new Guid("7ecf7ac7-4ab2-4d68-8394-8f918ec112c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("6b1ec621-ec4e-45ca-a64d-e9a481e1e0f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _processScriptTask;
		public ProcessScriptTask ProcessScriptTask {
			get {
				return _processScriptTask ?? (_processScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ProcessScriptTask",
					SchemaElementUId = new Guid("3c2692f1-b937-4938-be4b-a0d69b3203aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { StartProcess };
			FlowElements[TerminateProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateProcess };
			FlowElements[ProcessScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ProcessScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartProcess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ProcessScriptTask", e.Context.SenderName));
						break;
					case "TerminateProcess":
						CompleteProcess();
						break;
					case "ProcessScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateProcess", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("TargetSchemaUId")) {
				writer.WriteValue("TargetSchemaUId", TargetSchemaUId, Guid.Empty);
			}
			if (!HasMapping("TargetFolderSchemaUId")) {
				writer.WriteValue("TargetFolderSchemaUId", TargetFolderSchemaUId, Guid.Empty);
			}
			if (!HasMapping("RootSchemaRecordId")) {
				writer.WriteValue("RootSchemaRecordId", RootSchemaRecordId, Guid.Empty);
			}
			if (!HasMapping("TargetSchemaName")) {
				writer.WriteValue("TargetSchemaName", TargetSchemaName, null);
			}
			if (!HasMapping("TargetSchemaBindingColumnValueName")) {
				writer.WriteValue("TargetSchemaBindingColumnValueName", TargetSchemaBindingColumnValueName, null);
			}
			if (!HasMapping("RootSchemaName")) {
				writer.WriteValue("RootSchemaName", RootSchemaName, null);
			}
			if (!HasMapping("SegmentSchemaName")) {
				writer.WriteValue("SegmentSchemaName", SegmentSchemaName, null);
			}
			if (!HasMapping("DefResponseId")) {
				writer.WriteValue("DefResponseId", DefResponseId, Guid.Empty);
			}
			if (!HasMapping("ResponseColumnName")) {
				writer.WriteValue("ResponseColumnName", ResponseColumnName, null);
			}
			if (!HasMapping("TargetName")) {
				writer.WriteValue("TargetName", TargetName, null);
			}
			if (!HasMapping("SegmentTargetReferenceSchemaName")) {
				writer.WriteValue("SegmentTargetReferenceSchemaName", SegmentTargetReferenceSchemaName, null);
			}
			if (Logger != null) {
				if (Logger.GetType().IsSerializable ||
					Logger.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Logger", Logger, null);
				}
			}
			if (!HasMapping("SessionKey")) {
				writer.WriteValue("SessionKey", SessionKey, null);
			}
			if (!HasMapping("RootSchemaRecordRId")) {
				writer.WriteValue("RootSchemaRecordRId", RootSchemaRecordRId, 0);
			}
			if (!HasMapping("SuccessStatusId")) {
				writer.WriteValue("SuccessStatusId", SuccessStatusId, Guid.Empty);
			}
			if (!HasMapping("IsSetCampaignFirstStep")) {
				writer.WriteValue("IsSetCampaignFirstStep", IsSetCampaignFirstStep, false);
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
			MetaPathParameterValues.Add("f65369cb-ab82-414a-945a-59e9c8482e10", () => TargetSchemaUId);
			MetaPathParameterValues.Add("a94dc61d-8e34-478c-99b3-5c9f0feee8ae", () => TargetFolderSchemaUId);
			MetaPathParameterValues.Add("135bcc1d-bca0-46c7-bce1-5e822af82bae", () => RootSchemaRecordId);
			MetaPathParameterValues.Add("e7bfb385-9147-4c21-8b13-f66c80c51207", () => TargetSchemaName);
			MetaPathParameterValues.Add("4a647122-7876-4827-9514-2bf21714309e", () => TargetSchemaBindingColumnValueName);
			MetaPathParameterValues.Add("f454fd08-2214-4a01-b0ad-7abc9236f933", () => RootSchemaName);
			MetaPathParameterValues.Add("b8bd6e76-7cdb-4da7-93cf-bf8db8633278", () => SegmentSchemaName);
			MetaPathParameterValues.Add("216d1947-3e22-4554-91d2-a32beab8fa94", () => DefResponseId);
			MetaPathParameterValues.Add("7a46110a-ff72-49e8-b1ea-4af281e3679d", () => ResponseColumnName);
			MetaPathParameterValues.Add("1a80a615-67eb-4ac6-8d93-4af4f62db8bb", () => TargetName);
			MetaPathParameterValues.Add("f9fb7850-e2b3-4df5-a668-efaf667239d4", () => SegmentTargetReferenceSchemaName);
			MetaPathParameterValues.Add("6c81130b-4301-4a3d-8b55-6f2b414f2f2a", () => Logger);
			MetaPathParameterValues.Add("3cfe05e4-c735-4adb-84a7-c7f1be972a24", () => SessionKey);
			MetaPathParameterValues.Add("36e28d83-36ad-4d30-855c-d92c8c092899", () => RootSchemaRecordRId);
			MetaPathParameterValues.Add("9b29d5eb-bb38-4bbd-bb36-1daf124828a9", () => SuccessStatusId);
			MetaPathParameterValues.Add("67318a1f-ff32-49f2-9fd6-c2acada5472c", () => IsSetCampaignFirstStep);
			MetaPathParameterValues.Add("196f09e4-75e9-4c74-ad18-9d0c13b1bd96", () => SuccessMessage);
			MetaPathParameterValues.Add("03951f65-ea37-4345-b626-7e47a0736d11", () => RemindingCaption);
			MetaPathParameterValues.Add("e57643ca-d156-4a68-9033-7b62654594e2", () => EventRemindingCaption);
			MetaPathParameterValues.Add("e0ca4181-ec0c-445f-9983-94f42ff8946b", () => CampaignRemindingCaption);
			MetaPathParameterValues.Add("b9ae0c46-9105-4e99-acb4-4efd209d4d17", () => FailMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "TargetSchemaUId":
					if (!hasValueToRead) break;
					TargetSchemaUId = reader.GetValue<System.Guid>();
				break;
				case "TargetFolderSchemaUId":
					if (!hasValueToRead) break;
					TargetFolderSchemaUId = reader.GetValue<System.Guid>();
				break;
				case "RootSchemaRecordId":
					if (!hasValueToRead) break;
					RootSchemaRecordId = reader.GetValue<System.Guid>();
				break;
				case "TargetSchemaName":
					if (!hasValueToRead) break;
					TargetSchemaName = reader.GetValue<System.String>();
				break;
				case "TargetSchemaBindingColumnValueName":
					if (!hasValueToRead) break;
					TargetSchemaBindingColumnValueName = reader.GetValue<System.String>();
				break;
				case "RootSchemaName":
					if (!hasValueToRead) break;
					RootSchemaName = reader.GetValue<System.String>();
				break;
				case "SegmentSchemaName":
					if (!hasValueToRead) break;
					SegmentSchemaName = reader.GetValue<System.String>();
				break;
				case "DefResponseId":
					if (!hasValueToRead) break;
					DefResponseId = reader.GetValue<System.Guid>();
				break;
				case "ResponseColumnName":
					if (!hasValueToRead) break;
					ResponseColumnName = reader.GetValue<System.String>();
				break;
				case "TargetName":
					if (!hasValueToRead) break;
					TargetName = reader.GetValue<System.String>();
				break;
				case "SegmentTargetReferenceSchemaName":
					if (!hasValueToRead) break;
					SegmentTargetReferenceSchemaName = reader.GetValue<System.String>();
				break;
				case "Logger":
					if (!hasValueToRead) break;
					Logger = reader.GetSerializableObjectValue();
				break;
				case "SessionKey":
					if (!hasValueToRead) break;
					SessionKey = reader.GetValue<System.String>();
				break;
				case "RootSchemaRecordRId":
					if (!hasValueToRead) break;
					RootSchemaRecordRId = reader.GetValue<System.Int32>();
				break;
				case "SuccessStatusId":
					if (!hasValueToRead) break;
					SuccessStatusId = reader.GetValue<System.Guid>();
				break;
				case "IsSetCampaignFirstStep":
					if (!hasValueToRead) break;
					IsSetCampaignFirstStep = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ProcessScriptTaskExecute(ProcessExecutingContext context) {
			//Main();
			var updateTargetAudienceProcessHelper = ClassFactory.Get<UpdateTargetAudienceProcessHelper>(
				new ConstructorArgument("userConnection", UserConnection));
			updateTargetAudienceProcessHelper.RootSchemaRecordId = RootSchemaRecordId;
			updateTargetAudienceProcessHelper.RootSchemaName = RootSchemaName;
			updateTargetAudienceProcessHelper.SegmentTargetReferenceSchemaName = SegmentTargetReferenceSchemaName;
			updateTargetAudienceProcessHelper.SessionKey = SessionKey;
			updateTargetAudienceProcessHelper.SuccessStatusId = SuccessStatusId;
			updateTargetAudienceProcessHelper.IsSetCampaignFirstStep = IsSetCampaignFirstStep;
			updateTargetAudienceProcessHelper.UserConnection = UserConnection;
			updateTargetAudienceProcessHelper.SegmentSchemaName = SegmentSchemaName;
			updateTargetAudienceProcessHelper.TargetSchemaName = TargetSchemaName;
			updateTargetAudienceProcessHelper.TargetSchemaBindingColumnValueName = TargetSchemaBindingColumnValueName;
			updateTargetAudienceProcessHelper.UpdateTargetAudience();
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
			var cloneItem = (UpdateTargetAudienceProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Logger = Logger;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

