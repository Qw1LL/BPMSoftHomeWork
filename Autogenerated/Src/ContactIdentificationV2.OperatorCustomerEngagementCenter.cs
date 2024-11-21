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

	#region Class: ContactIdentificationV2Schema

	/// <exclude/>
	public class ContactIdentificationV2Schema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContactIdentificationV2Schema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContactIdentificationV2Schema(ContactIdentificationV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContactIdentificationV2";
			UId = new Guid("f58fbc05-8179-4074-9636-19e734769536");
			CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.10.1.444";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsActiveVersion = false;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			Version = 1;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("f58fbc05-8179-4074-9636-19e734769536");
			Version = 1;
			PackageUId = new Guid("e16ad5af-f2b8-4128-ab85-84768b536fe3");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("deefb406-4a64-4513-9f48-328ba955695b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("839ed405-68e4-4e40-bd9c-062c634c4a20"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePhoneNumberParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("244eac40-5473-4748-aa26-e77b96a35846"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"PhoneNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNewContactParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fe1f7c0c-c8cf-47c3-bbfe-363c45186118"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"NewContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsCaseIncludedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e5e56c22-18ea-449c-b1be-62a59c96abd7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"IsCaseIncluded",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccountSelectedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("22ed503f-1097-4afd-9c1c-e7591592243a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AccountSelected",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateContactButtonCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("77a86efd-52da-41d3-b551-b2af78145723"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"CreateContactButtonCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchDetailSelectButtonCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ce1af657-ffbd-40aa-8ba8-92e5d0b88a47"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"SearchDetailSelectButtonCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDefaultContactNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("04c9b73f-67bc-483e-9d66-6c2494c5be0f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"DefaultContactName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateContactIdParameter());
			Parameters.Add(CreateAccountIdParameter());
			Parameters.Add(CreatePhoneNumberParameter());
			Parameters.Add(CreateNewContactParameter());
			Parameters.Add(CreateIsCaseIncludedParameter());
			Parameters.Add(CreateAccountSelectedParameter());
			Parameters.Add(CreateCreateContactButtonCaptionParameter());
			Parameters.Add(CreateSearchDetailSelectButtonCaptionParameter());
			Parameters.Add(CreateDefaultContactNameParameter());
		}

		protected virtual void InitializePreconfiguredPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var titleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("69b15c71-905e-4fe2-b8c8-13247e6c2e08"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Title",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			titleParameter.SourceValue = new ProcessSchemaParameterValue(titleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Страница поиска Контактов и Контрагентов",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(titleParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7e141f0a-9d5c-457c-a67f-0a1d278e31bd"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var clientUnitSchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1b7e2a98-62c5-480f-87de-803a6fd6bd04"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ClientUnitSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			clientUnitSchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(clientUnitSchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"4f01d1ce-b5c7-4d19-b354-b5bef74d6e95",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(clientUnitSchemaUIdParameter);
			var entityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55b46c6d-9866-4800-b1a5-66f885cd2355"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entityIdParameter.SourceValue = new ProcessSchemaParameterValue(entityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var entryPointIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0ae7e716-e7cc-4a75-ae50-55d0030ffc0a"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntryPointId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entryPointIdParameter.SourceValue = new ProcessSchemaParameterValue(entryPointIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entryPointIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("d602fd51-f1ec-46f8-a61c-e2a65578dafd"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var useCardProcessModuleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03340eb8-8dc3-4cfa-803e-9f3b3bc34101"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"UseCardProcessModule",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCardProcessModuleParameter.SourceValue = new ProcessSchemaParameterValue(useCardProcessModuleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(useCardProcessModuleParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("8c360d85-bf72-4c87-8c17-d3163c1c7d9d"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("972c2fff-1e7a-4897-88b5-1b6a3de96469"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6943ab1a-dce8-4c57-bd3b-eb4715dcb1d5"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
			var isRunningParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("23145d3b-45a3-4a9a-b019-f296e0cbcfb0"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"IsRunning",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isRunningParameter.SourceValue = new ProcessSchemaParameterValue(isRunningParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(isRunningParameter);
			var templateParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("4a5221ff-1dfa-4371-aa3b-b83fc6ef48f2"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Template",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			templateParameter.SourceValue = new ProcessSchemaParameterValue(templateParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.90fa6d02-3e93-45d6-a72b-58dcffa411ae.21620f25-166f-42f1-8b4d-224a959040a3#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(templateParameter);
			var moduleParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("c003612c-32bf-4743-9ddc-9cd6eddfff56"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Module",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			moduleParameter.SourceValue = new ProcessSchemaParameterValue(moduleParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#Lookup.90fa6d02-3e93-45d6-a72b-58dcffa411ae.eb89c336-08b9-4951-bffd-3f5abc433174#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(moduleParameter);
			var pressedButtonCodeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("993430b0-b3fc-4871-a50f-48baed943409"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"PressedButtonCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pressedButtonCodeParameter.SourceValue = new ProcessSchemaParameterValue(pressedButtonCodeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pressedButtonCodeParameter);
			var urlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3f7bb4ba-649e-4dbc-9238-e0630e06179b"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"Url",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			urlParameter.SourceValue = new ProcessSchemaParameterValue(urlParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"""[Module]/[Page]/add""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(urlParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7a49fc04-38a9-4809-aec0-282d2aa6ba54"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("600a02ef-64f6-47b5-8021-550c9e427a26"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("7a1862e0-f2e8-44ea-a181-df8c4fd86dbc"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8b1376c3-c592-4be8-852a-e32e91666d97"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0b30a414-d93a-4e57-9d9f-bcd21eab3ec2"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c04d1c17-233a-4d13-b677-655677eda715"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0f642ba7-028a-4058-b612-0a57908c5bf5"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("de2c28af-3a24-4677-b6a2-5bd4692715ff"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4d444dcf-ee8c-40fe-a7ae-87d0c4bd16a0"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5f38947b-5a32-460e-9a75-e976c0ba8f57"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03f97b5a-a5d9-42b7-a205-9112ca7bb735"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a8ccfb46-f2d5-46df-a395-ea5bc63c79bd"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
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
				ModifiedInSchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var contactIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("12fe9831-090b-4b80-938e-a6c2149a2993"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactIdParameter.SourceValue = new ProcessSchemaParameterValue(contactIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(contactIdParameter);
			var accountIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("6f5535c1-cef2-4fab-aa8c-101f094e1360"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountIdParameter.SourceValue = new ProcessSchemaParameterValue(accountIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(accountIdParameter);
			var contactNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aba17913-301c-4b8a-8b12-d315eba94a55"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ContactName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			contactNameParameter.SourceValue = new ProcessSchemaParameterValue(contactNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(contactNameParameter);
			var phoneNumberParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f0c052d1-ca27-43fa-bd30-40cbc6d55b3d"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"PhoneNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			phoneNumberParameter.SourceValue = new ProcessSchemaParameterValue(phoneNumberParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(phoneNumberParameter);
			var emailParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc1e2817-ed80-4462-81b7-66965f9c76df"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Email",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			emailParameter.SourceValue = new ProcessSchemaParameterValue(emailParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(emailParameter);
			var isContactSelectedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("154e18f3-415a-442d-a42b-a1ab3f228aa9"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"IsContactSelected",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isContactSelectedParameter.SourceValue = new ProcessSchemaParameterValue(isContactSelectedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(isContactSelectedParameter);
			var resultCodeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("17a010c9-438a-4621-b397-adfd1bbf6b2c"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ResultCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			resultCodeParameter.SourceValue = new ProcessSchemaParameterValue(resultCodeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultCodeParameter);
			var isCaseIncludedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f9936a9b-7364-4807-886d-c47923aa5526"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"IsCaseIncluded",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isCaseIncludedParameter.SourceValue = new ProcessSchemaParameterValue(isCaseIncludedParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{e5e56c22-18ea-449c-b1be-62a59c96abd7}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(isCaseIncludedParameter);
			var accountNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc227909-1872-4ba3-9409-260e522e5bda"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AccountName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			accountNameParameter.SourceValue = new ProcessSchemaParameterValue(accountNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(accountNameParameter);
			var createContactButtonCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("932357b5-6b5b-4d70-b80b-a52c2cd999a5"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"CreateContactButtonCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			createContactButtonCaptionParameter.SourceValue = new ProcessSchemaParameterValue(createContactButtonCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{77a86efd-52da-41d3-b551-b2af78145723}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(createContactButtonCaptionParameter);
			var searchDetailSelectButtonCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("36bf19ed-4a1b-46d1-8360-7b98a0a05451"),
				ContainerUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"SearchDetailSelectButtonCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			searchDetailSelectButtonCaptionParameter.SourceValue = new ProcessSchemaParameterValue(searchDetailSelectButtonCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{ce1af657-ffbd-40aa-8ba8-92e5d0b88a47}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(searchDetailSelectButtonCaptionParameter);
		}

		protected virtual void InitializeAddDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("2cc3931e-cae7-49e3-8cf0-9ce37b4622d1"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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
				Value = @"16be3651-8fe2-4159-8dd0-a803d4683dd3",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("52f0c27a-aa7b-4b1a-81a6-d96439fb602b"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e33fa283-1e3e-45ee-a4c9-cd8f02f2bd1f"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("3b08e0b0-95c8-4039-b074-cc84d0e02189"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03c59888-3e70-4fc6-b8d8-8ca80b0c1a0f"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,77,111,219,70,16,253,43,2,147,67,11,120,133,253,254,208,165,104,99,31,12,196,137,16,183,185,216,62,204,238,206,198,2,40,202,32,169,6,174,160,255,222,33,109,217,114,144,186,169,91,4,13,98,30,36,114,119,223,204,227,236,188,153,229,166,122,217,95,95,97,53,171,126,153,159,156,174,74,63,125,181,106,113,58,111,87,9,187,110,250,122,149,160,94,252,1,177,198,57,180,176,196,30,219,247,80,175,177,123,189,232,250,131,201,62,168,58,168,94,254,62,206,85,179,179,77,117,220,227,242,183,227,76,150,189,9,18,133,224,172,36,204,76,251,104,24,184,104,25,104,193,93,9,166,160,19,4,78,171,122,189,108,78,176,135,57,244,151,213,108,83,141,214,200,0,152,148,192,5,201,180,203,100,64,122,96,94,149,200,76,10,50,230,28,92,41,190,218,30,84,93,186,196,37,140,78,239,193,194,70,84,214,8,230,11,146,5,97,2,243,57,115,6,158,171,172,173,87,57,171,1,124,187,254,30,216,245,237,162,249,48,61,238,222,172,235,250,109,123,180,188,234,175,127,56,123,113,118,220,189,253,216,96,123,58,58,155,21,168,59,188,152,210,232,39,3,71,53,46,177,233,103,155,18,133,200,57,59,166,115,176,76,39,69,190,131,163,59,147,117,176,60,39,205,243,150,0,119,1,158,109,172,210,220,138,68,113,10,94,15,184,200,188,45,132,43,90,73,151,64,131,144,219,139,23,23,147,31,39,63,77,190,156,210,158,7,174,83,136,78,21,102,93,76,180,39,10,89,200,214,50,155,164,14,58,153,136,188,12,30,166,227,110,79,102,147,255,217,139,15,59,150,23,221,85,13,215,239,191,112,227,94,181,8,61,77,76,26,252,56,73,171,166,135,212,79,223,144,231,187,56,30,98,129,117,221,239,38,39,205,56,185,23,130,199,76,12,140,174,30,104,100,159,211,230,252,70,104,231,213,236,252,243,82,187,253,191,9,230,67,177,61,212,217,121,117,112,94,157,174,214,109,26,172,41,122,56,220,11,196,232,96,92,242,201,227,78,88,52,210,80,92,110,71,14,161,135,221,194,221,240,42,47,202,2,243,113,115,186,211,211,104,133,223,94,236,51,63,187,235,134,219,191,129,157,64,3,31,176,29,130,122,207,253,142,229,175,20,194,157,225,156,163,2,129,200,184,67,79,185,98,37,139,14,2,203,28,173,240,145,243,18,243,136,126,135,5,91,108,18,62,145,216,59,236,198,104,15,21,237,150,215,16,170,109,181,221,30,236,215,57,107,178,201,158,184,40,101,12,211,220,81,153,2,31,41,243,163,84,145,146,93,41,120,180,206,229,88,36,151,152,88,210,154,178,223,81,246,199,84,52,35,163,38,10,111,149,228,226,191,175,115,95,71,217,6,108,145,54,123,134,46,13,244,136,99,240,209,49,37,48,3,12,27,23,248,160,236,199,132,253,23,2,60,90,194,162,190,65,62,11,240,123,22,160,180,26,53,102,197,184,49,148,155,142,27,234,30,146,51,69,231,143,98,131,181,209,243,71,5,104,146,77,32,56,50,33,60,167,188,22,72,10,54,156,25,3,78,150,18,232,176,161,191,85,1,74,239,157,142,64,111,84,4,21,23,77,171,163,74,150,41,159,56,207,78,121,94,212,19,5,248,115,74,171,117,211,63,75,240,171,247,192,40,131,225,78,20,230,144,132,167,145,36,232,179,0,22,68,136,69,57,69,73,43,31,147,160,52,217,37,1,145,137,140,148,240,134,11,70,141,74,50,234,66,28,135,164,207,22,255,145,4,169,184,71,142,158,138,128,225,64,132,168,133,129,26,168,9,149,173,74,144,245,223,244,64,79,135,79,207,233,132,239,232,179,129,96,193,179,8,22,152,212,42,5,3,74,113,30,191,85,9,134,168,99,150,212,208,131,83,130,190,99,184,99,192,105,203,66,146,66,21,130,40,237,158,40,193,249,229,170,161,83,232,115,15,252,14,15,161,23,219,63,1,13,143,166,213,198,15,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c9d9c923-3eb2-47cf-b2d5-b699ef55d643"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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
				UId = new Guid("27131716-0f0d-4f40-b1ac-e0aa6399e182"),
				ContainerUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
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

		protected virtual void InitializeAddDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("50baaec3-b4b2-4696-8e6e-0a52599c84ce"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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
				Value = @"004a9121-21f8-4a1e-8918-45c0f756ea41",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95bbe5fe-f292-4542-8914-7e0d64c9dd0b"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0a7fa4bd-042f-431c-bd8d-a294932edf78"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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
				UId = new Guid("4314f4b3-ed6a-4fd8-be55-31d309df8a90"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("362a0f68-4c27-4983-b9fe-775a0850402c"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,203,110,219,70,20,253,21,129,201,82,35,204,251,161,101,237,46,4,196,169,80,53,217,88,94,220,153,185,19,11,160,72,67,164,26,184,130,254,189,151,148,92,203,109,26,23,5,138,182,104,185,16,71,51,60,231,62,15,47,15,213,219,254,241,1,171,121,245,205,242,102,213,150,126,118,213,238,112,182,220,181,9,187,110,246,174,77,80,111,126,130,88,227,18,118,176,197,30,119,31,161,222,99,247,110,211,245,211,201,37,168,154,86,111,127,28,207,170,249,237,161,90,244,184,253,176,200,196,172,141,225,169,216,204,138,4,199,52,104,100,49,70,199,138,87,232,81,67,137,220,16,56,181,245,126,219,220,96,15,75,232,239,171,249,161,26,217,136,32,21,41,173,54,158,37,145,56,211,153,39,6,5,13,211,194,90,93,100,54,142,99,117,156,86,93,186,199,45,140,70,159,193,156,107,8,66,10,38,69,241,100,93,32,243,65,208,202,36,94,156,177,8,90,12,224,243,243,207,192,219,55,183,139,238,187,207,13,238,86,35,239,188,64,221,225,221,140,118,127,181,241,109,141,91,108,250,249,65,42,233,164,85,156,41,52,153,105,167,21,243,202,43,54,56,233,33,137,168,157,59,18,224,151,92,206,15,41,228,144,130,84,4,137,146,32,169,176,72,17,177,104,67,192,98,76,182,90,29,239,222,220,13,46,230,77,247,80,195,227,199,223,122,250,30,63,79,82,219,244,144,250,217,176,222,97,106,119,121,178,200,39,224,195,139,218,93,66,15,235,83,3,172,171,249,250,203,45,112,190,159,66,126,217,4,47,235,191,174,166,235,106,213,238,119,105,96,83,195,159,167,122,140,236,252,124,177,47,252,60,93,39,142,17,118,3,13,124,194,221,123,178,55,194,199,163,107,232,97,52,253,3,249,252,68,28,101,48,220,137,194,28,66,96,26,173,100,62,11,96,65,132,88,148,83,178,20,57,162,191,199,130,59,108,18,190,116,76,216,136,202,26,193,124,65,42,129,48,129,240,153,51,240,92,101,109,189,202,89,141,248,209,242,179,51,79,173,74,59,205,190,174,71,3,221,24,255,208,251,103,199,207,39,215,23,165,187,96,104,243,166,108,48,47,154,63,147,170,99,117,60,78,47,133,22,149,226,136,134,98,72,150,212,225,130,96,49,15,221,152,56,216,108,40,21,230,235,66,19,178,136,236,20,48,173,18,17,0,81,133,152,45,245,38,199,4,37,171,18,245,95,33,180,213,99,183,194,190,223,52,159,186,217,53,22,216,215,253,213,169,155,175,218,237,118,223,108,18,244,155,182,25,138,254,154,18,136,138,242,49,233,78,116,179,51,13,137,227,130,103,210,62,140,183,161,241,39,241,113,146,79,38,255,215,202,235,90,201,94,219,20,117,97,69,120,122,195,217,64,69,86,165,48,12,86,20,106,15,240,238,223,161,21,99,68,161,1,20,88,212,129,94,208,26,135,85,22,76,24,26,47,14,125,226,206,126,85,43,92,150,4,104,104,140,65,33,193,32,229,36,40,235,88,52,94,9,7,22,37,166,191,115,40,93,204,24,73,225,65,210,156,25,237,40,86,167,61,3,144,150,161,115,49,88,80,134,138,250,250,140,89,222,183,13,254,23,230,73,206,81,81,69,144,113,234,3,250,220,160,121,18,29,77,150,204,209,10,31,57,47,145,30,252,125,141,252,97,199,254,129,26,185,59,254,12,0,202,212,143,18,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eec63597-7c61-4178-ab9d-589c0450ab30"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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
				UId = new Guid("3d6c5148-5bce-421d-9699-c3f057391470"),
				ContainerUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
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

		protected virtual void InitializeAddDataUserTask3Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("040ed64a-eb19-4f89-925d-c9522c5d6854"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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
				Value = @"004a9121-21f8-4a1e-8918-45c0f756ea41",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cda6b132-0e59-45bb-988a-dd98d098385b"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("611a2e2a-44ad-46d6-a803-86b905065d78"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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
				UId = new Guid("a85205de-fa99-4c50-85d5-7011ef3b4d0e"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ac5bb6e7-6eff-457f-b790-d236a0edda50"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,143,227,68,16,253,43,145,119,143,169,168,191,63,114,100,135,195,72,59,16,17,118,47,147,57,84,119,87,239,68,114,236,145,237,128,66,148,255,78,199,73,152,12,44,59,8,9,1,2,31,236,164,219,239,85,185,235,189,170,125,245,118,216,61,81,53,175,190,90,220,45,219,60,204,222,181,29,205,22,93,27,169,239,103,239,219,136,245,250,39,12,53,45,176,195,13,13,212,125,196,122,75,253,251,117,63,76,39,215,160,106,90,189,253,97,220,171,230,247,251,234,118,160,205,135,219,84,152,189,180,70,201,100,65,25,198,64,161,246,16,188,42,55,206,180,142,9,163,101,177,128,99,91,111,55,205,29,13,184,192,225,177,154,239,171,145,173,16,196,44,132,81,218,65,228,177,16,36,22,1,51,105,80,220,24,149,69,210,150,81,117,152,86,125,124,164,13,142,65,159,193,140,41,244,92,112,16,60,187,18,157,19,56,207,203,47,29,89,182,218,16,42,126,4,159,223,127,6,222,191,185,191,237,191,253,177,161,110,57,242,206,51,214,61,61,204,202,234,175,22,190,174,105,67,205,48,223,19,243,50,202,18,193,112,30,75,162,42,131,39,195,128,43,145,13,37,29,68,198,67,1,252,114,150,243,61,23,153,188,147,28,152,103,1,84,112,12,188,116,4,104,162,224,202,163,240,94,30,30,222,60,28,83,76,235,254,169,198,221,199,223,102,186,36,236,226,227,36,183,221,36,110,251,161,221,80,87,106,210,12,24,135,19,244,233,69,245,174,193,251,213,73,2,171,106,190,250,188,8,206,207,211,71,191,148,193,75,5,172,170,233,170,90,182,219,46,30,217,228,241,207,165,34,35,59,59,95,240,153,219,229,58,113,140,176,59,108,240,19,117,223,148,120,35,124,220,186,193,1,199,208,223,151,156,47,196,65,120,205,44,207,96,9,61,40,50,2,92,226,8,158,251,144,165,149,34,103,49,162,191,163,76,29,53,145,94,38,198,77,32,105,52,7,151,73,20,89,21,133,186,148,24,160,99,50,41,227,100,74,114,196,143,145,159,147,185,136,181,172,52,219,186,30,3,244,227,247,31,213,127,78,252,188,115,115,85,188,43,134,54,173,243,154,210,109,243,103,142,234,80,29,14,211,107,171,41,111,28,247,198,67,20,198,128,146,232,32,48,85,196,21,116,210,201,218,200,156,254,162,213,138,28,121,178,18,11,54,22,131,161,22,224,67,50,32,137,81,196,156,100,14,234,175,176,218,114,215,47,105,24,214,205,167,126,118,67,25,183,245,112,214,239,187,118,179,217,54,235,136,195,186,109,142,69,127,213,11,187,190,156,199,164,63,209,93,108,48,137,215,60,147,246,105,124,28,133,63,9,187,73,58,133,252,223,43,175,123,37,57,101,98,40,157,45,115,151,74,75,247,165,200,50,103,32,111,120,46,242,64,103,255,37,94,177,214,71,42,242,148,17,143,205,154,33,96,52,14,28,41,45,52,227,69,252,244,69,175,48,145,35,146,182,144,49,23,195,208,177,219,75,99,33,232,210,207,45,26,18,20,255,206,177,116,53,101,132,82,132,81,49,208,202,74,80,86,57,64,20,6,200,218,224,13,74,93,138,250,250,148,89,60,182,13,253,23,230,73,74,65,150,138,16,48,75,165,36,169,204,147,96,203,100,73,140,12,119,129,177,28,202,139,191,239,145,63,156,216,63,208,35,15,135,159,1,241,26,134,200,20,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("415de17c-c12f-4817-8781-82b8431e8c3d"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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
				UId = new Guid("17b9ed8b-e5b9-40a0-bcfd-f28cf677f061"),
				ContainerUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
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

		protected virtual void InitializeAutoGeneratedPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var titleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("369adb53-be77-4d6a-9958-3b4c83ca70fe"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"Title",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			titleParameter.SourceValue = new ProcessSchemaParameterValue(titleParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Создание нового контакта",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(titleParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("6e13b431-433e-4be7-8eee-468eed2a7d09"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5408038c-ac80-4220-b5cc-f215a44ba230"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Укажите данные контакта",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var entityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("206826a5-918d-4250-8a64-287b1bde9a2b"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"EntityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entityIdParameter.SourceValue = new ProcessSchemaParameterValue(entityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var buttonsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b9a46d74-6ecd-4ff8-8131-73d06aa4f4bd"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"Buttons",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			buttonsParameter.SourceValue = new ProcessSchemaParameterValue(buttonsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"{""$type"":""System.Collections.Generic.List`1[[System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib]], mscorlib"",""$values"":[{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""aa2b00e5-ba27-432d-9421-d457baffb853"",""name"":""Next"",""caption"":""Далее"",""style"":""green"",""performValidation"":true,""isEnabled"":true,""generateSignal"":""""}]}",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(buttonsParameter);
			var elementsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5e2f306b-000b-4710-81f9-7b949ea2ad54"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"Elements",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			elementsParameter.SourceValue = new ProcessSchemaParameterValue(elementsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"{""$type"":""System.Collections.Generic.List`1[[System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib]], mscorlib"",""$values"":[{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""634061c5-a984-4d9b-86f0-af4327ca4a12"",""name"":""ContactName"",""caption"":""ФИО"",""controlEditType"":""1"",""isMultiline"":false,""isRequired"":false},{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""9b4bd2f4-9731-4207-a062-9c213f0dc347"",""name"":""Phone"",""caption"":""Телефон"",""controlEditType"":""1"",""isMultiline"":false,""isRequired"":false},{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""28874bae-8f14-4476-b3c6-38c00d7380f3"",""name"":""Account"",""caption"":""Контрагент"",""controlEditType"":""SelectionField"",""isRequired"":false,""dataFilter"":"""",""controlDataValueType"":""10"",""dataSource"":""25d7c1ab-1de0-4501-b402-02e0e5a72d6e""},{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""5a6f26d8-e7c2-41e2-98b7-31edaab7a990"",""name"":""Email"",""caption"":""E-mail"",""controlEditType"":""1"",""isMultiline"":false,""isRequired"":false}]}",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(elementsParameter);
			var extendedClientModuleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("830320f1-bd81-4cea-9f95-a80eadbd7767"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"ExtendedClientModule",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			extendedClientModuleParameter.SourceValue = new ProcessSchemaParameterValue(extendedClientModuleParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(extendedClientModuleParameter);
			var entryPointIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6098bc34-95ad-496c-a3b2-81e95b073100"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"EntryPointId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entryPointIdParameter.SourceValue = new ProcessSchemaParameterValue(entryPointIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(entryPointIdParameter);
			var pressedButtonCodeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("300e12bc-e3f7-49b2-8167-6ffb30b989af"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"PressedButtonCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pressedButtonCodeParameter.SourceValue = new ProcessSchemaParameterValue(pressedButtonCodeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pressedButtonCodeParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("0f482d41-ab86-41fc-b865-2e19e647b9aa"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8c0b7c0a-66fd-4a5b-9457-bf3729096fef"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ecbfdeeb-28bb-4777-abb9-4dc8ec14f22e"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"InformationOnStep",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			informationOnStepParameter.SourceValue = new ProcessSchemaParameterValue(informationOnStepParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"После заполнения данных, нажмите кнопку ""Далее""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(informationOnStepParameter);
			var isRunningParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("76840c62-b319-4288-b212-45c7398a6f01"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"IsRunning",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isRunningParameter.SourceValue = new ProcessSchemaParameterValue(isRunningParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(isRunningParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("40cd9fca-93de-43ac-bad9-b6bd650fb71e"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1c402117-d798-4d9b-9fe0-f4186fd38fac"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("8f809c9a-02c3-4421-a374-6ac4a55445e1"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3bf36bca-a471-4703-a862-b9393ef52169"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2219fd0b-9ccc-45c9-ba9e-637746c3b390"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c9784dc8-2609-4d7b-9904-3e783b2ab74f"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("18bbfc80-fce6-41ff-a52f-5e09da88f551"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("20cc44f9-e57a-48b5-8307-e2df7f3fbc07"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"EntityColumnValue",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5b9d1868-2e7f-43d6-bdd4-b971351edbc9"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5731ebdf-634e-4ff9-9a72-9cc02f274b9c"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0dd35ab2-a915-4647-9458-e2ff46c1fce1"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("040523b9-4115-41a3-a912-2a611ac7fd3d"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
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
				ModifiedInSchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var contactNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("634061c5-a984-4d9b-86f0-af4327ca4a12"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ContactName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			contactNameParameter.SourceValue = new ProcessSchemaParameterValue(contactNameParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e093c31e-611c-4d4f-9e60-142f6ed5b2fa}].[Parameter:{aba17913-301c-4b8a-8b12-d315eba94a55}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(contactNameParameter);
			var phoneParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b4bd2f4-9731-4207-a062-9c213f0dc347"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Phone",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			phoneParameter.SourceValue = new ProcessSchemaParameterValue(phoneParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e093c31e-611c-4d4f-9e60-142f6ed5b2fa}].[Parameter:{f0c052d1-ca27-43fa-bd30-40cbc6d55b3d}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(phoneParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("28874bae-8f14-4476-b3c6-38c00d7380f3"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{50fc9fed-3694-412a-846f-9e7f49617296}].[Parameter:{5efb285c-200d-4e01-90d9-5acd97f421c3}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var emailParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5a6f26d8-e7c2-41e2-98b7-31edaab7a990"),
				ContainerUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Email",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			emailParameter.SourceValue = new ProcessSchemaParameterValue(emailParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e093c31e-611c-4d4f-9e60-142f6ed5b2fa}].[Parameter:{fc1e2817-ed80-4462-81b7-66965f9c76df}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(emailParameter);
		}

		protected virtual void InitializeReadDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b1517598-2489-44aa-aaa6-5640f2853121"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,115,211,48,16,253,43,29,159,171,142,37,171,142,149,27,148,192,244,0,237,76,58,189,144,30,214,210,42,209,224,175,145,148,66,201,228,191,179,182,211,144,50,25,8,92,0,159,228,55,111,87,111,119,223,106,147,232,10,66,248,0,53,38,211,228,245,237,251,121,107,227,197,91,87,69,244,239,124,187,238,146,243,36,160,119,80,185,175,104,70,124,102,92,124,3,17,40,96,179,248,30,191,72,166,139,99,25,22,201,249,34,113,17,235,64,12,10,80,165,2,200,120,206,172,180,41,147,89,161,89,201,83,203,184,49,92,235,137,17,133,46,70,230,241,212,87,109,221,129,199,241,134,33,185,29,142,119,79,93,79,228,4,232,129,226,66,219,236,192,172,151,16,102,13,148,21,26,250,143,126,141,4,69,239,106,170,4,239,92,141,183,224,233,166,62,79,219,67,68,178,80,133,158,85,161,141,179,47,157,199,16,92,219,252,92,90,181,174,155,67,46,133,227,254,119,39,38,29,20,246,204,91,136,171,33,193,53,137,218,14,26,95,45,151,30,151,16,221,227,161,132,79,248,52,240,78,235,29,5,24,154,207,61,84,107,60,184,243,101,29,87,208,197,177,156,241,122,34,120,183,92,157,88,233,190,91,191,42,86,16,216,61,147,79,202,120,84,191,200,9,124,236,129,49,199,243,113,145,124,188,14,55,159,27,244,115,189,194,26,198,142,61,92,16,250,3,48,171,176,198,38,78,55,152,170,76,103,28,89,206,185,102,210,72,203,20,230,41,227,82,216,28,205,101,41,44,108,41,96,47,104,186,225,194,162,42,50,206,82,149,150,76,150,69,202,84,86,32,131,92,11,46,21,8,165,178,237,195,40,220,133,174,130,167,251,189,190,57,130,215,171,51,219,250,51,189,14,177,173,209,147,79,154,8,58,14,1,125,239,137,118,89,90,147,229,166,100,90,43,100,82,138,130,41,121,41,25,218,66,25,133,150,11,208,228,145,254,235,71,217,46,157,134,234,166,67,79,86,25,70,149,30,183,248,139,221,232,155,232,219,54,142,173,217,143,224,80,206,179,211,228,4,209,106,174,24,215,146,156,166,38,57,43,76,154,50,81,98,10,34,199,73,38,36,233,161,231,161,31,213,188,93,123,189,91,201,48,190,11,127,180,241,127,97,147,127,103,61,143,46,200,41,150,255,111,237,124,253,15,185,115,155,108,191,1,206,190,183,153,175,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6afebec2-bcc5-4267-b4d1-642bc77d9b47"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("27a93232-ccc8-48ad-9eff-1ad1ea4b60eb"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("60e46248-0ebb-4ee8-a1bc-4ee2f5b4a0b1"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dd28bfbd-e627-4d61-a3fd-91ebd0891488"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1b16fad7-4ecc-4715-be57-b6aa7d76d4b9"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("4ae849fb-aa93-4b31-98f6-6818622659e0"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("cdf7b7b2-89b5-4196-a299-d432ec544639"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3c555a9a-084f-46b0-97da-7805b5965ddc"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("628c1898-b678-4647-b7e5-8624e2a20a4b"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("05f3c3a8-49ec-4ef1-923a-b82935dad796"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("bc3bc9a9-a676-4a08-b8d4-3eca60a51ec1"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("712197a2-16fc-411c-a0b8-ad059a020d40"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("fb660a18-6ba8-4292-86c1-b614908a8d63"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2519b17d-ed42-4ff6-bb3c-7ebb21fcc7d5"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c735c402-0b9e-406d-a4e0-cbb66e7839f7"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,77,54,75,78,52,52,72,213,53,52,180,48,208,53,73,54,76,213,181,72,52,53,208,53,53,77,52,55,74,75,179,76,74,73,49,1,0,215,224,64,129,36,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("75c9c0ab-0f22-4b23-9b18-aa90e393a626"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a27c7b13-58a7-4ad4-b15a-448de74c1d65"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9ddc6a96-8c0e-469b-9ff3-8706adc2e1ae"),
				ContainerUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeReadDataUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbab1060-c0b1-4f93-867c-7266001affb5"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,143,211,48,16,253,43,171,156,215,85,226,124,52,233,109,89,10,234,1,182,82,87,123,33,28,198,246,164,181,72,226,200,118,22,74,213,255,142,157,180,165,139,42,40,92,128,156,236,167,55,227,55,51,111,178,11,120,13,198,188,135,6,131,89,240,106,249,110,165,42,59,121,35,107,139,250,173,86,125,23,220,6,6,181,132,90,126,69,49,226,115,33,237,107,176,224,2,118,229,247,248,50,152,149,151,50,148,193,109,25,72,139,141,113,12,23,128,9,21,69,62,173,8,134,73,68,146,60,14,9,132,84,144,152,199,113,200,83,154,209,40,30,153,151,83,223,171,166,3,141,227,11,67,242,106,56,62,110,59,79,140,28,192,7,138,52,170,61,128,177,151,96,230,45,176,26,133,187,91,221,163,131,172,150,141,171,4,31,101,131,75,208,238,37,159,71,121,200,145,42,168,141,103,213,88,217,249,151,78,163,49,82,181,63,151,86,247,77,123,206,117,225,120,186,30,196,132,131,66,207,92,130,221,12,9,198,76,251,65,229,221,122,173,113,13,86,62,159,139,248,132,219,129,121,93,247,92,128,112,19,122,130,186,199,179,190,188,172,228,30,58,59,22,116,20,224,40,90,174,55,87,86,123,234,216,175,10,166,14,236,142,228,171,50,94,172,128,102,14,124,246,192,152,227,120,44,131,15,11,243,240,185,69,189,226,27,108,96,236,217,199,137,67,127,0,230,53,54,216,218,217,14,195,194,53,44,66,146,69,17,39,137,72,42,82,96,22,146,40,161,85,134,34,101,180,130,189,11,56,9,154,237,42,78,233,180,8,11,18,229,83,74,18,6,49,41,18,119,165,89,136,41,165,152,50,225,66,70,225,210,116,53,108,159,78,250,86,8,154,111,110,42,165,111,120,111,172,106,80,79,238,56,87,125,107,111,218,99,231,23,222,152,101,0,201,52,135,41,75,73,145,22,21,73,138,40,34,133,16,140,112,193,50,22,211,188,136,41,56,171,248,207,79,84,173,37,135,250,161,67,237,28,51,204,43,188,236,245,23,75,226,59,169,149,178,99,127,78,115,56,104,26,228,28,13,151,67,206,34,193,4,97,17,56,61,28,252,137,79,9,195,4,170,48,201,57,11,185,211,227,254,19,126,94,43,213,107,126,216,77,51,254,32,254,104,245,255,194,74,255,222,158,94,220,147,107,156,255,223,186,122,241,15,249,115,31,236,191,1,12,233,27,129,186,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("924fc06b-cb19-4f36-a6b8-cf093ff6c691"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7c0f02aa-82a3-47c5-8208-d996fae17d12"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("29bb462d-f9de-41f8-a19f-9a0a6f6c1b19"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2a4fe780-6a8d-4f63-b87b-5a80ff81bce7"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2195e600-5141-46fb-b239-3e0e4a1d1c65"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("023d4b5d-869b-486b-b744-24dbdc8bba9c"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("5efb285c-200d-4e01-90d9-5acd97f421c3"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("638e86b2-8f33-425f-aaa1-33fb04bf366d"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9eb12b6f-8e40-4fd0-b12e-2a3ef8ae2d3e"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("92940858-d280-4045-be1c-4dfc9c628640"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("392ebbf9-7eb2-467c-8926-251c70dea54e"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d723185e-d81c-4915-b608-d9baa29f3ad5"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("02fb567d-b208-4a18-85e9-4dfe4ee10e81"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a33a0ba3-e017-4a51-892a-31febdf691b4"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e85fcae9-ec25-43af-bcd0-47641523512d"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9526e9cd-5214-40c4-a8ce-b2cd44a5bc1e"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ebd64a2d-e832-4590-8e4e-d17eb77d95d2"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("8306da24-e061-4f3c-bcaa-f7f14df26208"),
				ContainerUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask preconfiguredpageusertask1 = CreatePreconfiguredPageUserTask1UserTask();
			FlowElements.Add(preconfiguredpageusertask1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaFormulaTask formulatask2 = CreateFormulaTask2FormulaTask();
			FlowElements.Add(formulatask2);
			ProcessSchemaUserTask adddatausertask1 = CreateAddDataUserTask1UserTask();
			FlowElements.Add(adddatausertask1);
			ProcessSchemaFormulaTask formulatask3 = CreateFormulaTask3FormulaTask();
			FlowElements.Add(formulatask3);
			ProcessSchemaInclusiveGateway inclusivegateway1 = CreateInclusiveGateway1InclusiveGateway();
			FlowElements.Add(inclusivegateway1);
			ProcessSchemaFormulaTask formulatask4 = CreateFormulaTask4FormulaTask();
			FlowElements.Add(formulatask4);
			ProcessSchemaUserTask adddatausertask2 = CreateAddDataUserTask2UserTask();
			FlowElements.Add(adddatausertask2);
			ProcessSchemaUserTask adddatausertask3 = CreateAddDataUserTask3UserTask();
			FlowElements.Add(adddatausertask3);
			ProcessSchemaUserTask autogeneratedpageusertask1 = CreateAutoGeneratedPageUserTask1UserTask();
			FlowElements.Add(autogeneratedpageusertask1);
			ProcessSchemaFormulaTask formulatask5 = CreateFormulaTask5FormulaTask();
			FlowElements.Add(formulatask5);
			ProcessSchemaUserTask readdatausertask1 = CreateReadDataUserTask1UserTask();
			FlowElements.Add(readdatausertask1);
			ProcessSchemaUserTask readdatausertask2 = CreateReadDataUserTask2UserTask();
			FlowElements.Add(readdatausertask2);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaFormulaTask formulatask6 = CreateFormulaTask6FormulaTask();
			FlowElements.Add(formulatask6);
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("0374f97e-d765-44ea-9d30-3be8ae09bd89"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{deefb406-4a64-4513-9f48-328ba955695b}]#] != Guid.Empty || [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{839ed405-68e4-4e40-bd9c-062c634c4a20}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(482, 191),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(1401, 100),
				SequenceFlowStartPointPosition = new Point(162, 198),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dc06821c-b4ef-4f7c-b1bc-fbc4a11a2b5f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b116d3eb-3bf3-46c8-bc63-fc3476d31a3b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(162, 11));
			schemaFlow.PolylinePointPositions.Add(new Point(1401, 11));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("5ad4e173-04b5-4649-837c-d22c26b2674f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(327, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("5f92367a-0974-4ebf-a32c-d55c04e48d6a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(645, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("d688193f-9dd6-4af8-b948-cde51b4c7904"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(645, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b226b71-a1a2-47fa-8ea6-40796f17cd9b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("507376ca-fdf6-4662-bea7-7d15e3985c6a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("8fa9aea6-0bc2-46bc-9e80-649f429aa652"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(144, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c4b6fd4c-b7fd-4417-a51e-f9c612519b8d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dc06821c-b4ef-4f7c-b1bc-fbc4a11a2b5f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow7",
				UId = new Guid("25b9392e-704d-42ed-9624-4190b568f6ae"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(277, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dc06821c-b4ef-4f7c-b1bc-fbc4a11a2b5f"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("5deb83d5-d535-4f74-8eca-57097cadb848"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(645, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("507376ca-fdf6-4662-bea7-7d15e3985c6a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("20522a18-5cd9-4713-b542-1cf712c3a705"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("88059cf2-ff4e-44cb-920a-375a1aa1430f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(645, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b226b71-a1a2-47fa-8ea6-40796f17cd9b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("c7e99f46-3a51-422f-be23-20e5e667edab"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e093c31e-611c-4d4f-9e60-142f6ed5b2fa}].[Parameter:{17a010c9-438a-4621-b397-adfd1bbf6b2c}]#] == ""ContactSelected""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(420, 282),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("592683c9-85dd-45a8-9431-d7587c13f066"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("6736c170-cc87-479a-89bc-5a92e7dab75c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(582, 330),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("592683c9-85dd-45a8-9431-d7587c13f066"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("32c6ad93-f028-469b-bdf3-bc06033eb7ea"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(730, 376),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("721dfa93-c964-4ad1-bcc6-54248fddf0c9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(903, 333),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("20522a18-5cd9-4713-b542-1cf712c3a705"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("96344677-1e02-4847-98db-c6b2b8f63ade"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow10",
				UId = new Guid("7058391b-7d68-4265-a336-03f8c9347da3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(327, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("9eb9df03-804c-4569-a976-83ca81356295"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(730, 376),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("44d743fe-0bf2-4e53-9cff-ffff18b3c9e0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b116d3eb-3bf3-46c8-bc63-fc3476d31a3b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("d393627d-e9ed-4c4a-81df-a49ea5c1fcdd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(730, 376),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("44d743fe-0bf2-4e53-9cff-ffff18b3c9e0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("67a31b03-747e-4e89-b588-dcf4ad465052"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(368, 114),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("20233c44-02c5-4422-af20-c4c3cefd67f0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(1282, 86),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("af1f1aea-ca64-4bd3-97e9-55794de511f9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b116d3eb-3bf3-46c8-bc63-fc3476d31a3b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow15",
				UId = new Guid("6fb5aaeb-187b-4bb5-8135-48362af4d054"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(1246, 120),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("96344677-1e02-4847-98db-c6b2b8f63ade"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b116d3eb-3bf3-46c8-bc63-fc3476d31a3b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("b4a7612b-41dd-4dee-9113-e84a5423a170"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e093c31e-611c-4d4f-9e60-142f6ed5b2fa}].[Parameter:{17a010c9-438a-4621-b397-adfd1bbf6b2c}]#] == ""AccountSelected""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				CurveCenterPosition = new Point(1190, 90),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("96344677-1e02-4847-98db-c6b2b8f63ade"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("af1f1aea-ca64-4bd3-97e9-55794de511f9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a2eacbc5-b538-476c-8c03-51467abed9ec"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a2eacbc5-b538-476c-8c03-51467abed9ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("c4b6fd4c-b7fd-4417-a51e-f9c612519b8d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Start1",
				Position = new Point(43, 212),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("b116d3eb-3bf3-46c8-bc63-fc3476d31a3b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"Terminate1",
				Position = new Point(1387, 100),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreatePreconfiguredPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"PreconfiguredPageUserTask1",
				Position = new Point(232, 198),
				SchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializePreconfiguredPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("592683c9-85dd-45a8-9431-d7587c13f066"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"FormulaTask1",
				Position = new Point(449, 198),
				ResultParameterMetaPath = @"deefb406-4a64-4513-9f48-328ba955695b",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,161,14,131,48,16,6,224,135,65,223,210,107,187,166,87,63,49,197,146,73,130,56,202,223,76,80,68,33,153,32,188,251,208,179,95,242,13,221,240,220,250,239,138,246,206,31,84,77,69,151,13,227,237,210,63,120,44,168,88,247,116,192,136,203,142,65,129,57,147,159,125,33,65,48,196,222,150,128,249,62,217,162,231,21,94,218,180,98,71,75,7,219,2,137,142,201,136,153,200,79,209,144,184,8,210,144,45,123,81,43,226,206,177,27,127,142,172,191,195,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask2FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("20522a18-5cd9-4713-b542-1cf712c3a705"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"FormulaTask2",
				Position = new Point(953, 86),
				ResultParameterMetaPath = @"839ed405-68e4-4e40-bd9c-062c634c4a20",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,139,187,14,194,48,12,0,63,166,179,81,66,76,94,59,3,19,72,140,85,6,39,118,196,208,116,72,43,49,84,253,119,50,179,157,78,119,243,52,63,182,231,119,149,254,46,31,105,20,43,45,155,164,203,176,127,226,190,72,147,117,143,71,205,90,51,179,3,228,96,1,139,81,64,193,13,186,49,6,171,184,160,226,115,12,47,234,212,100,151,30,143,171,247,14,51,9,248,170,17,16,71,157,77,177,96,124,81,138,157,241,170,154,51,77,233,7,66,56,231,37,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AddDataUserTask1",
				Position = new Point(449, 86),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask3FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("9b226b71-a1a2-47fa-8ea6-40796f17cd9b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"FormulaTask3",
				Position = new Point(708, 86),
				ResultParameterMetaPath = @"deefb406-4a64-4513-9f48-328ba955695b",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,59,14,194,48,12,0,208,195,116,54,2,219,249,238,12,76,32,49,86,25,242,113,196,208,116,72,43,49,84,189,59,153,89,159,244,230,105,126,108,207,239,42,253,157,63,210,162,175,113,217,36,92,134,254,193,125,145,38,235,238,15,36,52,168,233,10,36,170,0,27,38,176,100,9,184,98,177,49,223,18,27,115,142,240,138,61,54,217,165,251,35,187,226,178,67,26,37,225,40,185,66,194,162,32,105,231,164,42,85,52,211,25,166,240,3,91,238,63,192,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaInclusiveGateway CreateInclusiveGateway1InclusiveGateway() {
			ProcessSchemaInclusiveGateway gateway = new ProcessSchemaInclusiveGateway(this) {
				UId = new Guid("dc06821c-b4ef-4f7c-b1bc-fbc4a11a2b5f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("ffa4a06a-5747-49d4-96c2-c32a727a3b14"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"InclusiveGateway1",
				Position = new Point(134, 198),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask4FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("507376ca-fdf6-4662-bea7-7d15e3985c6a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"FormulaTask4",
				Position = new Point(834, 86),
				ResultParameterMetaPath = @"fe1f7c0c-c8cf-47c3-bbfe-363c45186118",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,41,42,77,5,0,141,76,252,253,4,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AddDataUserTask2",
				Position = new Point(575, 86),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAddDataUserTask3UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AddDataUserTask3",
				Position = new Point(575, 198),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDataUserTask3Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateAutoGeneratedPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"AutoGeneratedPageUserTask1",
				Position = new Point(344, 86),
				SchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAutoGeneratedPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask5FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("44d743fe-0bf2-4e53-9cff-ffff18b3c9e0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"FormulaTask5",
				Position = new Point(834, 198),
				ResultParameterMetaPath = @"839ed405-68e4-4e40-bd9c-062c634c4a20",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,205,187,10,194,48,20,128,225,135,113,62,146,251,165,171,116,112,82,112,44,29,78,146,19,20,154,8,109,68,164,244,221,173,171,235,15,31,255,112,24,206,203,229,93,105,190,197,59,21,236,50,78,11,141,199,189,254,133,126,162,66,181,117,43,70,169,165,205,26,152,13,25,148,37,130,224,131,3,135,129,71,76,86,120,105,182,29,92,113,198,66,141,230,110,141,41,219,96,131,0,231,131,6,197,189,1,20,222,67,82,82,80,212,74,25,233,127,164,175,237,209,62,167,231,244,42,181,91,117,52,17,57,35,224,220,49,80,145,211,254,208,12,180,70,43,114,246,33,37,181,141,135,241,11,190,245,233,142,196,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ReadDataUserTask1",
				Position = new Point(708, 198),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadDataUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ReadDataUserTask2",
				Position = new Point(232, 86),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadDataUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("96344677-1e02-4847-98db-c6b2b8f63ade"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"ExclusiveGateway1",
				Position = new Point(1072, 86),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask6FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("af1f1aea-ca64-4bd3-97e9-55794de511f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cd2e686-06a5-468f-ac9d-3a0b8a0b4a1f"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7bf1cfd3-8c1f-4948-b39c-36d3910b43c5"),
				CreatedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536"),
				Name = @"FormulaTask6",
				Position = new Point(1177, 23),
				ResultParameterMetaPath = @"22ed503f-1097-4afd-9c1c-e7591592243a",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,41,42,77,5,0,141,76,252,253,4,0,0,0 }
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
			return new ContactIdentificationV2(userConnection);
		}

		public override object Clone() {
			return new ContactIdentificationV2Schema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f58fbc05-8179-4074-9636-19e734769536"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactIdentificationV2

	/// <exclude/>
	public class ContactIdentificationV2 : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: PreconfiguredPageUserTask1FlowElement

		/// <exclude/>
		public class PreconfiguredPageUserTask1FlowElement : PreconfiguredPageUserTask
		{

			#region Constructors: Public

			public PreconfiguredPageUserTask1FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "PreconfiguredPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("e093c31e-611c-4d4f-9e60-142f6ed5b2fa");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_isCaseIncluded = () => (bool)((process.IsCaseIncluded));
				_createContactButtonCaption = () => new LocalizableString((process.CreateContactButtonCaption));
				_searchDetailSelectButtonCaption = () => new LocalizableString((process.SearchDetailSelectButtonCaption));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "BaseElements.PreconfiguredPageUserTask1.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private Guid _clientUnitSchemaUId = new Guid("4f01d1ce-b5c7-4d19-b354-b5bef74d6e95");
			public override Guid ClientUnitSchemaUId {
				get {
					return _clientUnitSchemaUId;
				}
				set {
					_clientUnitSchemaUId = value;
				}
			}

			private bool _useCardProcessModule = true;
			public override bool UseCardProcessModule {
				get {
					return _useCardProcessModule;
				}
				set {
					_useCardProcessModule = value;
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

			public virtual Guid ContactId {
				get;
				set;
			}

			public virtual Guid AccountId {
				get;
				set;
			}

			public virtual string ContactName {
				get;
				set;
			}

			public virtual string PhoneNumber {
				get;
				set;
			}

			public virtual string Email {
				get;
				set;
			}

			public virtual bool IsContactSelected {
				get;
				set;
			}

			public virtual string ResultCode {
				get;
				set;
			}

			internal Func<bool> _isCaseIncluded;
			public virtual bool IsCaseIncluded {
				get {
					return (_isCaseIncluded ?? (_isCaseIncluded = () => false)).Invoke();
				}
				set {
					_isCaseIncluded = () => { return value; };
				}
			}

			public virtual string AccountName {
				get;
				set;
			}

			internal Func<string> _createContactButtonCaption;
			public virtual string CreateContactButtonCaption {
				get {
					return (_createContactButtonCaption ?? (_createContactButtonCaption = () => null)).Invoke();
				}
				set {
					_createContactButtonCaption = () => { return value; };
				}
			}

			internal Func<string> _searchDetailSelectButtonCaption;
			public virtual string SearchDetailSelectButtonCaption {
				get {
					return (_searchDetailSelectButtonCaption ?? (_searchDetailSelectButtonCaption = () => null)).Invoke();
				}
				set {
					_searchDetailSelectButtonCaption = () => { return value; };
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

			public AddDataUserTask1FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("23272630-3e5d-4743-8383-4f2d8ac1b477");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Name = () => new LocalizableString(string.IsNullOrEmpty((process.AutoGeneratedPageUserTask1.ContactName) ) ? (process.DefaultContactName).Value : (process.AutoGeneratedPageUserTask1.ContactName) );
				_recordDefValues_Email = () => new LocalizableString((process.AutoGeneratedPageUserTask1.Email));
				_recordDefValues_Account = () => (Guid)((process.AutoGeneratedPageUserTask1.Account));
				_recordDefValues_Phone = () => new LocalizableString((process.AutoGeneratedPageUserTask1.Phone));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Name", () => _recordDefValues_Name.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Email", () => _recordDefValues_Email.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Phone", () => _recordDefValues_Phone.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<string> _recordDefValues_Name;
			internal Func<string> _recordDefValues_Email;
			internal Func<Guid> _recordDefValues_Account;
			internal Func<string> _recordDefValues_Phone;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,77,111,219,70,16,253,43,2,147,67,11,120,133,253,254,208,165,104,99,31,12,196,137,16,183,185,216,62,204,238,206,198,2,40,202,32,169,6,174,160,255,222,33,109,217,114,144,186,169,91,4,13,98,30,36,114,119,223,204,227,236,188,153,229,166,122,217,95,95,97,53,171,126,153,159,156,174,74,63,125,181,106,113,58,111,87,9,187,110,250,122,149,160,94,252,1,177,198,57,180,176,196,30,219,247,80,175,177,123,189,232,250,131,201,62,168,58,168,94,254,62,206,85,179,179,77,117,220,227,242,183,227,76,150,189,9,18,133,224,172,36,204,76,251,104,24,184,104,25,104,193,93,9,166,160,19,4,78,171,122,189,108,78,176,135,57,244,151,213,108,83,141,214,200,0,152,148,192,5,201,180,203,100,64,122,96,94,149,200,76,10,50,230,28,92,41,190,218,30,84,93,186,196,37,140,78,239,193,194,70,84,214,8,230,11,146,5,97,2,243,57,115,6,158,171,172,173,87,57,171,1,124,187,254,30,216,245,237,162,249,48,61,238,222,172,235,250,109,123,180,188,234,175,127,56,123,113,118,220,189,253,216,96,123,58,58,155,21,168,59,188,152,210,232,39,3,71,53,46,177,233,103,155,18,133,200,57,59,166,115,176,76,39,69,190,131,163,59,147,117,176,60,39,205,243,150,0,119,1,158,109,172,210,220,138,68,113,10,94,15,184,200,188,45,132,43,90,73,151,64,131,144,219,139,23,23,147,31,39,63,77,190,156,210,158,7,174,83,136,78,21,102,93,76,180,39,10,89,200,214,50,155,164,14,58,153,136,188,12,30,166,227,110,79,102,147,255,217,139,15,59,150,23,221,85,13,215,239,191,112,227,94,181,8,61,77,76,26,252,56,73,171,166,135,212,79,223,144,231,187,56,30,98,129,117,221,239,38,39,205,56,185,23,130,199,76,12,140,174,30,104,100,159,211,230,252,70,104,231,213,236,252,243,82,187,253,191,9,230,67,177,61,212,217,121,117,112,94,157,174,214,109,26,172,41,122,56,220,11,196,232,96,92,242,201,227,78,88,52,210,80,92,110,71,14,161,135,221,194,221,240,42,47,202,2,243,113,115,186,211,211,104,133,223,94,236,51,63,187,235,134,219,191,129,157,64,3,31,176,29,130,122,207,253,142,229,175,20,194,157,225,156,163,2,129,200,184,67,79,185,98,37,139,14,2,203,28,173,240,145,243,18,243,136,126,135,5,91,108,18,62,145,216,59,236,198,104,15,21,237,150,215,16,170,109,181,221,30,236,215,57,107,178,201,158,184,40,101,12,211,220,81,153,2,31,41,243,163,84,145,146,93,41,120,180,206,229,88,36,151,152,88,210,154,178,223,81,246,199,84,52,35,163,38,10,111,149,228,226,191,175,115,95,71,217,6,108,145,54,123,134,46,13,244,136,99,240,209,49,37,48,3,12,27,23,248,160,236,199,132,253,23,2,60,90,194,162,190,65,62,11,240,123,22,160,180,26,53,102,197,184,49,148,155,142,27,234,30,146,51,69,231,143,98,131,181,209,243,71,5,104,146,77,32,56,50,33,60,167,188,22,72,10,54,156,25,3,78,150,18,232,176,161,191,85,1,74,239,157,142,64,111,84,4,21,23,77,171,163,74,150,41,159,56,207,78,121,94,212,19,5,248,115,74,171,117,211,63,75,240,171,247,192,40,131,225,78,20,230,144,132,167,145,36,232,179,0,22,68,136,69,57,69,73,43,31,147,160,52,217,37,1,145,137,140,148,240,134,11,70,141,74,50,234,66,28,135,164,207,22,255,145,4,169,184,71,142,158,138,128,225,64,132,168,133,129,26,168,9,149,173,74,144,245,223,244,64,79,135,79,207,233,132,239,232,179,129,96,193,179,8,22,152,212,42,5,3,74,113,30,191,85,9,134,168,99,150,212,208,131,83,130,190,99,184,99,192,105,203,66,146,66,21,130,40,237,158,40,193,249,229,170,161,83,232,115,15,252,14,15,161,23,219,63,1,13,143,166,213,198,15,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "f58fbc0581794074963619e734769536",
							"BaseElements.AddDataUserTask1.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("e16ad5af-f2b8-4128-ab85-84768b536fe3");
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

		#region Class: AddDataUserTask2FlowElement

		/// <exclude/>
		public class AddDataUserTask2FlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataUserTask2FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("317b5386-d177-44ef-9b11-32ee8526b126");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Contact = () => (Guid)((process.AddDataUserTask1.RecordId));
				_recordDefValues_CommunicationType = () => (Guid)(((Guid)SysSettings.GetValue(UserConnection, "DefaultContactCommunicationType")));
				_recordDefValues_Number = () => new LocalizableString((process.PhoneNumber));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_CommunicationType", () => _recordDefValues_CommunicationType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Number", () => _recordDefValues_Number.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_CommunicationType;
			internal Func<string> _recordDefValues_Number;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,203,110,219,70,20,253,21,129,201,82,35,204,251,161,101,237,46,4,196,169,80,53,217,88,94,220,153,185,19,11,160,72,67,164,26,184,130,254,189,151,148,92,203,109,26,23,5,138,182,104,185,16,71,51,60,231,62,15,47,15,213,219,254,241,1,171,121,245,205,242,102,213,150,126,118,213,238,112,182,220,181,9,187,110,246,174,77,80,111,126,130,88,227,18,118,176,197,30,119,31,161,222,99,247,110,211,245,211,201,37,168,154,86,111,127,28,207,170,249,237,161,90,244,184,253,176,200,196,172,141,225,169,216,204,138,4,199,52,104,100,49,70,199,138,87,232,81,67,137,220,16,56,181,245,126,219,220,96,15,75,232,239,171,249,161,26,217,136,32,21,41,173,54,158,37,145,56,211,153,39,6,5,13,211,194,90,93,100,54,142,99,117,156,86,93,186,199,45,140,70,159,193,156,107,8,66,10,38,69,241,100,93,32,243,65,208,202,36,94,156,177,8,90,12,224,243,243,207,192,219,55,183,139,238,187,207,13,238,86,35,239,188,64,221,225,221,140,118,127,181,241,109,141,91,108,250,249,65,42,233,164,85,156,41,52,153,105,167,21,243,202,43,54,56,233,33,137,168,157,59,18,224,151,92,206,15,41,228,144,130,84,4,137,146,32,169,176,72,17,177,104,67,192,98,76,182,90,29,239,222,220,13,46,230,77,247,80,195,227,199,223,122,250,30,63,79,82,219,244,144,250,217,176,222,97,106,119,121,178,200,39,224,195,139,218,93,66,15,235,83,3,172,171,249,250,203,45,112,190,159,66,126,217,4,47,235,191,174,166,235,106,213,238,119,105,96,83,195,159,167,122,140,236,252,124,177,47,252,60,93,39,142,17,118,3,13,124,194,221,123,178,55,194,199,163,107,232,97,52,253,3,249,252,68,28,101,48,220,137,194,28,66,96,26,173,100,62,11,96,65,132,88,148,83,178,20,57,162,191,199,130,59,108,18,190,116,76,216,136,202,26,193,124,65,42,129,48,129,240,153,51,240,92,101,109,189,202,89,141,248,209,242,179,51,79,173,74,59,205,190,174,71,3,221,24,255,208,251,103,199,207,39,215,23,165,187,96,104,243,166,108,48,47,154,63,147,170,99,117,60,78,47,133,22,149,226,136,134,98,72,150,212,225,130,96,49,15,221,152,56,216,108,40,21,230,235,66,19,178,136,236,20,48,173,18,17,0,81,133,152,45,245,38,199,4,37,171,18,245,95,33,180,213,99,183,194,190,223,52,159,186,217,53,22,216,215,253,213,169,155,175,218,237,118,223,108,18,244,155,182,25,138,254,154,18,136,138,242,49,233,78,116,179,51,13,137,227,130,103,210,62,140,183,161,241,39,241,113,146,79,38,255,215,202,235,90,201,94,219,20,117,97,69,120,122,195,217,64,69,86,165,48,12,86,20,106,15,240,238,223,161,21,99,68,161,1,20,88,212,129,94,208,26,135,85,22,76,24,26,47,14,125,226,206,126,85,43,92,150,4,104,104,140,65,33,193,32,229,36,40,235,88,52,94,9,7,22,37,166,191,115,40,93,204,24,73,225,65,210,156,25,237,40,86,167,61,3,144,150,161,115,49,88,80,134,138,250,250,140,89,222,183,13,254,23,230,73,206,81,81,69,144,113,234,3,250,220,160,121,18,29,77,150,204,209,10,31,57,47,145,30,252,125,141,252,97,199,254,129,26,185,59,254,12,0,202,212,143,18,10,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "f58fbc0581794074963619e734769536",
							"BaseElements.AddDataUserTask2.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("e16ad5af-f2b8-4128-ab85-84768b536fe3");
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

		#region Class: AddDataUserTask3FlowElement

		/// <exclude/>
		public class AddDataUserTask3FlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDataUserTask3FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDataUserTask3";
				IsLogging = true;
				SchemaElementUId = new Guid("6865b758-30cc-4e9e-891c-65dc7ef5244b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_Contact = () => (Guid)((process.PreconfiguredPageUserTask1.ContactId));
				_recordDefValues_CommunicationType = () => (Guid)(((Guid)SysSettings.GetValue(UserConnection, "DefaultContactCommunicationType")));
				_recordDefValues_Number = () => new LocalizableString((process.PhoneNumber));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_CommunicationType", () => _recordDefValues_CommunicationType.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Number", () => _recordDefValues_Number.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_CommunicationType;
			internal Func<string> _recordDefValues_Number;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("004a9121-21f8-4a1e-8918-45c0f756ea41");
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,143,227,68,16,253,43,145,119,143,169,168,191,63,114,100,135,195,72,59,16,17,118,47,147,57,84,119,87,239,68,114,236,145,237,128,66,148,255,78,199,73,152,12,44,59,8,9,1,2,31,236,164,219,239,85,185,235,189,170,125,245,118,216,61,81,53,175,190,90,220,45,219,60,204,222,181,29,205,22,93,27,169,239,103,239,219,136,245,250,39,12,53,45,176,195,13,13,212,125,196,122,75,253,251,117,63,76,39,215,160,106,90,189,253,97,220,171,230,247,251,234,118,160,205,135,219,84,152,189,180,70,201,100,65,25,198,64,161,246,16,188,42,55,206,180,142,9,163,101,177,128,99,91,111,55,205,29,13,184,192,225,177,154,239,171,145,173,16,196,44,132,81,218,65,228,177,16,36,22,1,51,105,80,220,24,149,69,210,150,81,117,152,86,125,124,164,13,142,65,159,193,140,41,244,92,112,16,60,187,18,157,19,56,207,203,47,29,89,182,218,16,42,126,4,159,223,127,6,222,191,185,191,237,191,253,177,161,110,57,242,206,51,214,61,61,204,202,234,175,22,190,174,105,67,205,48,223,19,243,50,202,18,193,112,30,75,162,42,131,39,195,128,43,145,13,37,29,68,198,67,1,252,114,150,243,61,23,153,188,147,28,152,103,1,84,112,12,188,116,4,104,162,224,202,163,240,94,30,30,222,60,28,83,76,235,254,169,198,221,199,223,102,186,36,236,226,227,36,183,221,36,110,251,161,221,80,87,106,210,12,24,135,19,244,233,69,245,174,193,251,213,73,2,171,106,190,250,188,8,206,207,211,71,191,148,193,75,5,172,170,233,170,90,182,219,46,30,217,228,241,207,165,34,35,59,59,95,240,153,219,229,58,113,140,176,59,108,240,19,117,223,148,120,35,124,220,186,193,1,199,208,223,151,156,47,196,65,120,205,44,207,96,9,61,40,50,2,92,226,8,158,251,144,165,149,34,103,49,162,191,163,76,29,53,145,94,38,198,77,32,105,52,7,151,73,20,89,21,133,186,148,24,160,99,50,41,227,100,74,114,196,143,145,159,147,185,136,181,172,52,219,186,30,3,244,227,247,31,213,127,78,252,188,115,115,85,188,43,134,54,173,243,154,210,109,243,103,142,234,80,29,14,211,107,171,41,111,28,247,198,67,20,198,128,146,232,32,48,85,196,21,116,210,201,218,200,156,254,162,213,138,28,121,178,18,11,54,22,131,161,22,224,67,50,32,137,81,196,156,100,14,234,175,176,218,114,215,47,105,24,214,205,167,126,118,67,25,183,245,112,214,239,187,118,179,217,54,235,136,195,186,109,142,69,127,213,11,187,190,156,199,164,63,209,93,108,48,137,215,60,147,246,105,124,28,133,63,9,187,73,58,133,252,223,43,175,123,37,57,101,98,40,157,45,115,151,74,75,247,165,200,50,103,32,111,120,46,242,64,103,255,37,94,177,214,71,42,242,148,17,143,205,154,33,96,52,14,28,41,45,52,227,69,252,244,69,175,48,145,35,146,182,144,49,23,195,208,177,219,75,99,33,232,210,207,45,26,18,20,255,206,177,116,53,101,132,82,132,81,49,208,202,74,80,86,57,64,20,6,200,218,224,13,74,93,138,250,250,148,89,60,182,13,253,23,230,73,74,65,150,138,16,48,75,165,36,169,204,147,96,203,100,73,140,12,119,129,177,28,202,139,191,239,145,63,156,216,63,208,35,15,135,159,1,241,26,134,200,20,10,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "f58fbc0581794074963619e734769536",
							"BaseElements.AddDataUserTask3.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("e16ad5af-f2b8-4128-ab85-84768b536fe3");
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

		#region Class: AutoGeneratedPageUserTask1FlowElement

		/// <exclude/>
		public class AutoGeneratedPageUserTask1FlowElement : AutoGeneratedPageUserTask
		{

			#region Constructors: Public

			public AutoGeneratedPageUserTask1FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AutoGeneratedPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("fb11ddd7-4d96-4c30-a976-45d4960dc40d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_contactName = () => new LocalizableString((process.PreconfiguredPageUserTask1.ContactName));
				_phone = () => new LocalizableString((process.PreconfiguredPageUserTask1.PhoneNumber));
				_account = () => (Guid)(((process.ReadDataUserTask2.ResultEntity.IsColumnValueLoaded(process.ReadDataUserTask2.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadDataUserTask2.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_email = () => new LocalizableString((process.PreconfiguredPageUserTask1.Email));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "BaseElements.AutoGeneratedPageUserTask1.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "BaseElements.AutoGeneratedPageUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			private LocalizableString _buttons;
			public override LocalizableString Buttons {
				get {
					return _buttons ?? (_buttons = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "BaseElements.AutoGeneratedPageUserTask1.Parameters.Buttons.Value"));
				}
				set {
					_buttons = value;
				}
			}

			private LocalizableString _elements;
			public override LocalizableString Elements {
				get {
					return _elements ?? (_elements = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "BaseElements.AutoGeneratedPageUserTask1.Parameters.Elements.Value"));
				}
				set {
					_elements = value;
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

			private LocalizableString _informationOnStep;
			public override LocalizableString InformationOnStep {
				get {
					return _informationOnStep ?? (_informationOnStep = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "BaseElements.AutoGeneratedPageUserTask1.Parameters.InformationOnStep.Value"));
				}
				set {
					_informationOnStep = value;
				}
			}

			internal Func<string> _contactName;
			public virtual string ContactName {
				get {
					return (_contactName ?? (_contactName = () => null)).Invoke();
				}
				set {
					_contactName = () => { return value; };
				}
			}

			internal Func<string> _phone;
			public virtual string Phone {
				get {
					return (_phone ?? (_phone = () => null)).Invoke();
				}
				set {
					_phone = () => { return value; };
				}
			}

			internal Func<Guid> _account;
			public virtual Guid Account {
				get {
					return (_account ?? (_account = () => Guid.Empty)).Invoke();
				}
				set {
					_account = () => { return value; };
				}
			}

			internal Func<string> _email;
			public virtual string Email {
				get {
					return (_email ?? (_email = () => null)).Invoke();
				}
				set {
					_email = () => { return value; };
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

			public ReadDataUserTask1FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("ac3537f5-07bf-47ee-b9b8-8ab1cad72936");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,115,211,48,16,253,43,29,159,171,142,37,171,142,149,27,148,192,244,0,237,76,58,189,144,30,214,210,42,209,224,175,145,148,66,201,228,191,179,182,211,144,50,25,8,92,0,159,228,55,111,87,111,119,223,106,147,232,10,66,248,0,53,38,211,228,245,237,251,121,107,227,197,91,87,69,244,239,124,187,238,146,243,36,160,119,80,185,175,104,70,124,102,92,124,3,17,40,96,179,248,30,191,72,166,139,99,25,22,201,249,34,113,17,235,64,12,10,80,165,2,200,120,206,172,180,41,147,89,161,89,201,83,203,184,49,92,235,137,17,133,46,70,230,241,212,87,109,221,129,199,241,134,33,185,29,142,119,79,93,79,228,4,232,129,226,66,219,236,192,172,151,16,102,13,148,21,26,250,143,126,141,4,69,239,106,170,4,239,92,141,183,224,233,166,62,79,219,67,68,178,80,133,158,85,161,141,179,47,157,199,16,92,219,252,92,90,181,174,155,67,46,133,227,254,119,39,38,29,20,246,204,91,136,171,33,193,53,137,218,14,26,95,45,151,30,151,16,221,227,161,132,79,248,52,240,78,235,29,5,24,154,207,61,84,107,60,184,243,101,29,87,208,197,177,156,241,122,34,120,183,92,157,88,233,190,91,191,42,86,16,216,61,147,79,202,120,84,191,200,9,124,236,129,49,199,243,113,145,124,188,14,55,159,27,244,115,189,194,26,198,142,61,92,16,250,3,48,171,176,198,38,78,55,152,170,76,103,28,89,206,185,102,210,72,203,20,230,41,227,82,216,28,205,101,41,44,108,41,96,47,104,186,225,194,162,42,50,206,82,149,150,76,150,69,202,84,86,32,131,92,11,46,21,8,165,178,237,195,40,220,133,174,130,167,251,189,190,57,130,215,171,51,219,250,51,189,14,177,173,209,147,79,154,8,58,14,1,125,239,137,118,89,90,147,229,166,100,90,43,100,82,138,130,41,121,41,25,218,66,25,133,150,11,208,228,145,254,235,71,217,46,157,134,234,166,67,79,86,25,70,149,30,183,248,139,221,232,155,232,219,54,142,173,217,143,224,80,206,179,211,228,4,209,106,174,24,215,146,156,166,38,57,43,76,154,50,81,98,10,34,199,73,38,36,233,161,231,161,31,213,188,93,123,189,91,201,48,190,11,127,180,241,127,97,147,127,103,61,143,46,200,41,150,255,111,237,124,253,15,185,115,155,108,191,1,206,190,183,153,175,6,0,0 })));
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

			private string _entityColumnMetaPathes;
			public override string EntityColumnMetaPathes {
				get {
					return _entityColumnMetaPathes ?? (_entityColumnMetaPathes = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,77,54,75,78,52,52,72,213,53,52,180,48,208,53,73,54,76,213,181,72,52,53,208,53,53,77,52,55,74,75,179,76,74,73,49,1,0,215,224,64,129,36,0,0,0 })));
				}
				set {
					_entityColumnMetaPathes = value;
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

			public ReadDataUserTask2FlowElement(UserConnection userConnection, ContactIdentificationV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadDataUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("50fc9fed-3694-412a-846f-9e7f49617296");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,143,211,48,16,253,43,171,156,215,85,226,124,52,233,109,89,10,234,1,182,82,87,123,33,28,198,246,164,181,72,226,200,118,22,74,213,255,142,157,180,165,139,42,40,92,128,156,236,167,55,227,55,51,111,178,11,120,13,198,188,135,6,131,89,240,106,249,110,165,42,59,121,35,107,139,250,173,86,125,23,220,6,6,181,132,90,126,69,49,226,115,33,237,107,176,224,2,118,229,247,248,50,152,149,151,50,148,193,109,25,72,139,141,113,12,23,128,9,21,69,62,173,8,134,73,68,146,60,14,9,132,84,144,152,199,113,200,83,154,209,40,30,153,151,83,223,171,166,3,141,227,11,67,242,106,56,62,110,59,79,140,28,192,7,138,52,170,61,128,177,151,96,230,45,176,26,133,187,91,221,163,131,172,150,141,171,4,31,101,131,75,208,238,37,159,71,121,200,145,42,168,141,103,213,88,217,249,151,78,163,49,82,181,63,151,86,247,77,123,206,117,225,120,186,30,196,132,131,66,207,92,130,221,12,9,198,76,251,65,229,221,122,173,113,13,86,62,159,139,248,132,219,129,121,93,247,92,128,112,19,122,130,186,199,179,190,188,172,228,30,58,59,22,116,20,224,40,90,174,55,87,86,123,234,216,175,10,166,14,236,142,228,171,50,94,172,128,102,14,124,246,192,152,227,120,44,131,15,11,243,240,185,69,189,226,27,108,96,236,217,199,137,67,127,0,230,53,54,216,218,217,14,195,194,53,44,66,146,69,17,39,137,72,42,82,96,22,146,40,161,85,134,34,101,180,130,189,11,56,9,154,237,42,78,233,180,8,11,18,229,83,74,18,6,49,41,18,119,165,89,136,41,165,152,50,225,66,70,225,210,116,53,108,159,78,250,86,8,154,111,110,42,165,111,120,111,172,106,80,79,238,56,87,125,107,111,218,99,231,23,222,152,101,0,201,52,135,41,75,73,145,22,21,73,138,40,34,133,16,140,112,193,50,22,211,188,136,41,56,171,248,207,79,84,173,37,135,250,161,67,237,28,51,204,43,188,236,245,23,75,226,59,169,149,178,99,127,78,115,56,104,26,228,28,13,151,67,206,34,193,4,97,17,56,61,28,252,137,79,9,195,4,170,48,201,57,11,185,211,227,254,19,126,94,43,213,107,126,216,77,51,254,32,254,104,245,255,194,74,255,222,158,94,220,147,107,156,255,223,186,122,241,15,249,115,31,236,191,1,12,233,27,129,186,6,0,0 })));
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

		public ContactIdentificationV2(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactIdentificationV2";
			SchemaUId = new Guid("f58fbc05-8179-4074-9636-19e734769536");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f58fbc05-8179-4074-9636-19e734769536");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContactIdentificationV2, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContactIdentificationV2, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid ContactId {
			get;
			set;
		}

		public virtual Guid AccountId {
			get;
			set;
		}

		public virtual string PhoneNumber {
			get;
			set;
		}

		public virtual bool NewContact {
			get;
			set;
		}

		public virtual bool IsCaseIncluded {
			get;
			set;
		}

		public virtual bool AccountSelected {
			get;
			set;
		}

		public virtual string CreateContactButtonCaption {
			get;
			set;
		}

		public virtual string SearchDetailSelectButtonCaption {
			get;
			set;
		}

		private LocalizableString _defaultContactName;
		public virtual LocalizableString DefaultContactName {
			get {
				return _defaultContactName ?? (_defaultContactName = GetLocalizableString("f58fbc0581794074963619e734769536",
						 "Parameters.DefaultContactName.Value"));
			}
			set {
				_defaultContactName = value;
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
					SchemaElementUId = new Guid("c4b6fd4c-b7fd-4417-a51e-f9c612519b8d"),
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
					SchemaElementUId = new Guid("b116d3eb-3bf3-46c8-bc63-fc3476d31a3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private PreconfiguredPageUserTask1FlowElement _preconfiguredPageUserTask1;
		public PreconfiguredPageUserTask1FlowElement PreconfiguredPageUserTask1 {
			get {
				return _preconfiguredPageUserTask1 ?? (_preconfiguredPageUserTask1 = new PreconfiguredPageUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("592683c9-85dd-45a8-9431-d7587c13f066"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("20522a18-5cd9-4713-b542-1cf712c3a705"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask2Execute,
				});
			}
		}

		private AddDataUserTask1FlowElement _addDataUserTask1;
		public AddDataUserTask1FlowElement AddDataUserTask1 {
			get {
				return _addDataUserTask1 ?? (_addDataUserTask1 = new AddDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("9b226b71-a1a2-47fa-8ea6-40796f17cd9b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask3Execute,
				});
			}
		}

		private ProcessInclusiveGateway _inclusiveGateway1;
		public ProcessInclusiveGateway InclusiveGateway1 {
			get {
				return _inclusiveGateway1 ?? (_inclusiveGateway1 = new ProcessInclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaInclusiveGateway",
					Name = "InclusiveGateway1",
					SchemaElementUId = new Guid("dc06821c-b4ef-4f7c-b1bc-fbc4a11a2b5f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.InclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
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
					SchemaElementUId = new Guid("507376ca-fdf6-4662-bea7-7d15e3985c6a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask4Execute,
				});
			}
		}

		private AddDataUserTask2FlowElement _addDataUserTask2;
		public AddDataUserTask2FlowElement AddDataUserTask2 {
			get {
				return _addDataUserTask2 ?? (_addDataUserTask2 = new AddDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddDataUserTask3FlowElement _addDataUserTask3;
		public AddDataUserTask3FlowElement AddDataUserTask3 {
			get {
				return _addDataUserTask3 ?? (_addDataUserTask3 = new AddDataUserTask3FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AutoGeneratedPageUserTask1FlowElement _autoGeneratedPageUserTask1;
		public AutoGeneratedPageUserTask1FlowElement AutoGeneratedPageUserTask1 {
			get {
				return _autoGeneratedPageUserTask1 ?? (_autoGeneratedPageUserTask1 = new AutoGeneratedPageUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("44d743fe-0bf2-4e53-9cff-ffff18b3c9e0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask5Execute,
				});
			}
		}

		private ReadDataUserTask1FlowElement _readDataUserTask1;
		public ReadDataUserTask1FlowElement ReadDataUserTask1 {
			get {
				return _readDataUserTask1 ?? (_readDataUserTask1 = new ReadDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadDataUserTask2FlowElement _readDataUserTask2;
		public ReadDataUserTask2FlowElement ReadDataUserTask2 {
			get {
				return _readDataUserTask2 ?? (_readDataUserTask2 = new ReadDataUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("96344677-1e02-4847-98db-c6b2b8f63ade"),
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

		private ProcessScriptTask _formulaTask6;
		public ProcessScriptTask FormulaTask6 {
			get {
				return _formulaTask6 ?? (_formulaTask6 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask6",
					SchemaElementUId = new Guid("af1f1aea-ca64-4bd3-97e9-55794de511f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask6Execute,
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
					SchemaElementUId = new Guid("0374f97e-d765-44ea-9d30-3be8ae09bd89"),
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
					SchemaElementUId = new Guid("c7e99f46-3a51-422f-be23-20e5e667edab"),
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
					SchemaElementUId = new Guid("b4a7612b-41dd-4dee-9113-e84a5423a170"),
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
			FlowElements[PreconfiguredPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { PreconfiguredPageUserTask1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[FormulaTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask2 };
			FlowElements[AddDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask1 };
			FlowElements[FormulaTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask3 };
			FlowElements[InclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { InclusiveGateway1 };
			FlowElements[FormulaTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask4 };
			FlowElements[AddDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask2 };
			FlowElements[AddDataUserTask3.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDataUserTask3 };
			FlowElements[AutoGeneratedPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { AutoGeneratedPageUserTask1 };
			FlowElements[FormulaTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask5 };
			FlowElements[ReadDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask1 };
			FlowElements[ReadDataUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadDataUserTask2 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[FormulaTask6.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask6 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InclusiveGateway1", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "PreconfiguredPageUserTask1":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask2", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask3", e.Context.SenderName));
						break;
					case "FormulaTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "AddDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask2", e.Context.SenderName));
						break;
					case "FormulaTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask4", e.Context.SenderName));
						break;
					case "InclusiveGateway1":
						bool isInclusiveGateway1ConditionsEvulated = false;
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							isInclusiveGateway1ConditionsEvulated = true;
						} 
						if (!isInclusiveGateway1ConditionsEvulated) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PreconfiguredPageUserTask1", e.Context.SenderName));
						} 
						break;
					case "FormulaTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask2", e.Context.SenderName));
						break;
					case "AddDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask3", e.Context.SenderName));
						break;
					case "AddDataUserTask3":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadDataUserTask1", e.Context.SenderName));
						break;
					case "AutoGeneratedPageUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDataUserTask1", e.Context.SenderName));
						break;
					case "FormulaTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask5", e.Context.SenderName));
						break;
					case "ReadDataUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AutoGeneratedPageUserTask1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask6", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "FormulaTask6":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((ContactId) != Guid.Empty || (AccountId) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "InclusiveGateway1", "ConditionalFlow1", "(ContactId) != Guid.Empty || (AccountId) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((PreconfiguredPageUserTask1.ResultCode) == "ContactSelected");
			Log.InfoFormat(ConditionalExpressionLogMessage, "PreconfiguredPageUserTask1", "ConditionalFlow2", "(PreconfiguredPageUserTask1.ResultCode) == \"ContactSelected\"", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((PreconfiguredPageUserTask1.ResultCode) == "AccountSelected");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow3", "(PreconfiguredPageUserTask1.ResultCode) == \"AccountSelected\"", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PreconfiguredPageUserTask1.ContactId")) {
				writer.WriteValue("PreconfiguredPageUserTask1.ContactId", PreconfiguredPageUserTask1.ContactId, Guid.Empty);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.AccountId")) {
				writer.WriteValue("PreconfiguredPageUserTask1.AccountId", PreconfiguredPageUserTask1.AccountId, Guid.Empty);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.ContactName")) {
				writer.WriteValue("PreconfiguredPageUserTask1.ContactName", PreconfiguredPageUserTask1.ContactName, null);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.PhoneNumber")) {
				writer.WriteValue("PreconfiguredPageUserTask1.PhoneNumber", PreconfiguredPageUserTask1.PhoneNumber, null);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.Email")) {
				writer.WriteValue("PreconfiguredPageUserTask1.Email", PreconfiguredPageUserTask1.Email, null);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.IsContactSelected")) {
				writer.WriteValue("PreconfiguredPageUserTask1.IsContactSelected", PreconfiguredPageUserTask1.IsContactSelected, false);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.ResultCode")) {
				writer.WriteValue("PreconfiguredPageUserTask1.ResultCode", PreconfiguredPageUserTask1.ResultCode, null);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.IsCaseIncluded")) {
				writer.WriteValue("PreconfiguredPageUserTask1.IsCaseIncluded", PreconfiguredPageUserTask1.IsCaseIncluded, false);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.AccountName")) {
				writer.WriteValue("PreconfiguredPageUserTask1.AccountName", PreconfiguredPageUserTask1.AccountName, null);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.CreateContactButtonCaption")) {
				writer.WriteValue("PreconfiguredPageUserTask1.CreateContactButtonCaption", PreconfiguredPageUserTask1.CreateContactButtonCaption, null);
			}
			if (!HasMapping("PreconfiguredPageUserTask1.SearchDetailSelectButtonCaption")) {
				writer.WriteValue("PreconfiguredPageUserTask1.SearchDetailSelectButtonCaption", PreconfiguredPageUserTask1.SearchDetailSelectButtonCaption, null);
			}
			if (!HasMapping("AutoGeneratedPageUserTask1.ContactName")) {
				writer.WriteValue("AutoGeneratedPageUserTask1.ContactName", AutoGeneratedPageUserTask1.ContactName, null);
			}
			if (!HasMapping("AutoGeneratedPageUserTask1.Phone")) {
				writer.WriteValue("AutoGeneratedPageUserTask1.Phone", AutoGeneratedPageUserTask1.Phone, null);
			}
			if (!HasMapping("AutoGeneratedPageUserTask1.Account")) {
				writer.WriteValue("AutoGeneratedPageUserTask1.Account", AutoGeneratedPageUserTask1.Account, Guid.Empty);
			}
			if (!HasMapping("AutoGeneratedPageUserTask1.Email")) {
				writer.WriteValue("AutoGeneratedPageUserTask1.Email", AutoGeneratedPageUserTask1.Email, null);
			}
			if (!HasMapping("ContactId")) {
				writer.WriteValue("ContactId", ContactId, Guid.Empty);
			}
			if (!HasMapping("AccountId")) {
				writer.WriteValue("AccountId", AccountId, Guid.Empty);
			}
			if (!HasMapping("PhoneNumber")) {
				writer.WriteValue("PhoneNumber", PhoneNumber, null);
			}
			if (!HasMapping("NewContact")) {
				writer.WriteValue("NewContact", NewContact, false);
			}
			if (!HasMapping("IsCaseIncluded")) {
				writer.WriteValue("IsCaseIncluded", IsCaseIncluded, false);
			}
			if (!HasMapping("AccountSelected")) {
				writer.WriteValue("AccountSelected", AccountSelected, false);
			}
			if (!HasMapping("CreateContactButtonCaption")) {
				writer.WriteValue("CreateContactButtonCaption", CreateContactButtonCaption, null);
			}
			if (!HasMapping("SearchDetailSelectButtonCaption")) {
				writer.WriteValue("SearchDetailSelectButtonCaption", SearchDetailSelectButtonCaption, null);
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
			MetaPathParameterValues.Add("deefb406-4a64-4513-9f48-328ba955695b", () => ContactId);
			MetaPathParameterValues.Add("839ed405-68e4-4e40-bd9c-062c634c4a20", () => AccountId);
			MetaPathParameterValues.Add("244eac40-5473-4748-aa26-e77b96a35846", () => PhoneNumber);
			MetaPathParameterValues.Add("fe1f7c0c-c8cf-47c3-bbfe-363c45186118", () => NewContact);
			MetaPathParameterValues.Add("e5e56c22-18ea-449c-b1be-62a59c96abd7", () => IsCaseIncluded);
			MetaPathParameterValues.Add("22ed503f-1097-4afd-9c1c-e7591592243a", () => AccountSelected);
			MetaPathParameterValues.Add("77a86efd-52da-41d3-b551-b2af78145723", () => CreateContactButtonCaption);
			MetaPathParameterValues.Add("ce1af657-ffbd-40aa-8ba8-92e5d0b88a47", () => SearchDetailSelectButtonCaption);
			MetaPathParameterValues.Add("04c9b73f-67bc-483e-9d66-6c2494c5be0f", () => DefaultContactName);
			MetaPathParameterValues.Add("69b15c71-905e-4fe2-b8c8-13247e6c2e08", () => PreconfiguredPageUserTask1.Title);
			MetaPathParameterValues.Add("7e141f0a-9d5c-457c-a67f-0a1d278e31bd", () => PreconfiguredPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("1b7e2a98-62c5-480f-87de-803a6fd6bd04", () => PreconfiguredPageUserTask1.ClientUnitSchemaUId);
			MetaPathParameterValues.Add("55b46c6d-9866-4800-b1a5-66f885cd2355", () => PreconfiguredPageUserTask1.EntityId);
			MetaPathParameterValues.Add("0ae7e716-e7cc-4a75-ae50-55d0030ffc0a", () => PreconfiguredPageUserTask1.EntryPointId);
			MetaPathParameterValues.Add("d602fd51-f1ec-46f8-a61c-e2a65578dafd", () => PreconfiguredPageUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("03340eb8-8dc3-4cfa-803e-9f3b3bc34101", () => PreconfiguredPageUserTask1.UseCardProcessModule);
			MetaPathParameterValues.Add("8c360d85-bf72-4c87-8c17-d3163c1c7d9d", () => PreconfiguredPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("972c2fff-1e7a-4897-88b5-1b6a3de96469", () => PreconfiguredPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("6943ab1a-dce8-4c57-bd3b-eb4715dcb1d5", () => PreconfiguredPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("23145d3b-45a3-4a9a-b019-f296e0cbcfb0", () => PreconfiguredPageUserTask1.IsRunning);
			MetaPathParameterValues.Add("4a5221ff-1dfa-4371-aa3b-b83fc6ef48f2", () => PreconfiguredPageUserTask1.Template);
			MetaPathParameterValues.Add("c003612c-32bf-4743-9ddc-9cd6eddfff56", () => PreconfiguredPageUserTask1.Module);
			MetaPathParameterValues.Add("993430b0-b3fc-4871-a50f-48baed943409", () => PreconfiguredPageUserTask1.PressedButtonCode);
			MetaPathParameterValues.Add("3f7bb4ba-649e-4dbc-9238-e0630e06179b", () => PreconfiguredPageUserTask1.Url);
			MetaPathParameterValues.Add("7a49fc04-38a9-4809-aec0-282d2aa6ba54", () => PreconfiguredPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("600a02ef-64f6-47b5-8021-550c9e427a26", () => PreconfiguredPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("7a1862e0-f2e8-44ea-a181-df8c4fd86dbc", () => PreconfiguredPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("8b1376c3-c592-4be8-852a-e32e91666d97", () => PreconfiguredPageUserTask1.StartIn);
			MetaPathParameterValues.Add("0b30a414-d93a-4e57-9d9f-bcd21eab3ec2", () => PreconfiguredPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("c04d1c17-233a-4d13-b677-655677eda715", () => PreconfiguredPageUserTask1.Duration);
			MetaPathParameterValues.Add("0f642ba7-028a-4058-b612-0a57908c5bf5", () => PreconfiguredPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("de2c28af-3a24-4677-b6a2-5bd4692715ff", () => PreconfiguredPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("4d444dcf-ee8c-40fe-a7ae-87d0c4bd16a0", () => PreconfiguredPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("5f38947b-5a32-460e-9a75-e976c0ba8f57", () => PreconfiguredPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("03f97b5a-a5d9-42b7-a205-9112ca7bb735", () => PreconfiguredPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("a8ccfb46-f2d5-46df-a395-ea5bc63c79bd", () => PreconfiguredPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("12fe9831-090b-4b80-938e-a6c2149a2993", () => PreconfiguredPageUserTask1.ContactId);
			MetaPathParameterValues.Add("6f5535c1-cef2-4fab-aa8c-101f094e1360", () => PreconfiguredPageUserTask1.AccountId);
			MetaPathParameterValues.Add("aba17913-301c-4b8a-8b12-d315eba94a55", () => PreconfiguredPageUserTask1.ContactName);
			MetaPathParameterValues.Add("f0c052d1-ca27-43fa-bd30-40cbc6d55b3d", () => PreconfiguredPageUserTask1.PhoneNumber);
			MetaPathParameterValues.Add("fc1e2817-ed80-4462-81b7-66965f9c76df", () => PreconfiguredPageUserTask1.Email);
			MetaPathParameterValues.Add("154e18f3-415a-442d-a42b-a1ab3f228aa9", () => PreconfiguredPageUserTask1.IsContactSelected);
			MetaPathParameterValues.Add("17a010c9-438a-4621-b397-adfd1bbf6b2c", () => PreconfiguredPageUserTask1.ResultCode);
			MetaPathParameterValues.Add("f9936a9b-7364-4807-886d-c47923aa5526", () => PreconfiguredPageUserTask1.IsCaseIncluded);
			MetaPathParameterValues.Add("fc227909-1872-4ba3-9409-260e522e5bda", () => PreconfiguredPageUserTask1.AccountName);
			MetaPathParameterValues.Add("932357b5-6b5b-4d70-b80b-a52c2cd999a5", () => PreconfiguredPageUserTask1.CreateContactButtonCaption);
			MetaPathParameterValues.Add("36bf19ed-4a1b-46d1-8360-7b98a0a05451", () => PreconfiguredPageUserTask1.SearchDetailSelectButtonCaption);
			MetaPathParameterValues.Add("2cc3931e-cae7-49e3-8cf0-9ce37b4622d1", () => AddDataUserTask1.EntitySchemaId);
			MetaPathParameterValues.Add("52f0c27a-aa7b-4b1a-81a6-d96439fb602b", () => AddDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("e33fa283-1e3e-45ee-a4c9-cd8f02f2bd1f", () => AddDataUserTask1.RecordAddMode);
			MetaPathParameterValues.Add("3b08e0b0-95c8-4039-b074-cc84d0e02189", () => AddDataUserTask1.FilterEntitySchemaId);
			MetaPathParameterValues.Add("03c59888-3e70-4fc6-b8d8-8ca80b0c1a0f", () => AddDataUserTask1.RecordDefValues);
			MetaPathParameterValues.Add("c9d9c923-3eb2-47cf-b2d5-b699ef55d643", () => AddDataUserTask1.RecordId);
			MetaPathParameterValues.Add("27131716-0f0d-4f40-b1ac-e0aa6399e182", () => AddDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("50baaec3-b4b2-4696-8e6e-0a52599c84ce", () => AddDataUserTask2.EntitySchemaId);
			MetaPathParameterValues.Add("95bbe5fe-f292-4542-8914-7e0d64c9dd0b", () => AddDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("0a7fa4bd-042f-431c-bd8d-a294932edf78", () => AddDataUserTask2.RecordAddMode);
			MetaPathParameterValues.Add("4314f4b3-ed6a-4fd8-be55-31d309df8a90", () => AddDataUserTask2.FilterEntitySchemaId);
			MetaPathParameterValues.Add("362a0f68-4c27-4983-b9fe-775a0850402c", () => AddDataUserTask2.RecordDefValues);
			MetaPathParameterValues.Add("eec63597-7c61-4178-ab9d-589c0450ab30", () => AddDataUserTask2.RecordId);
			MetaPathParameterValues.Add("3d6c5148-5bce-421d-9699-c3f057391470", () => AddDataUserTask2.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("040ed64a-eb19-4f89-925d-c9522c5d6854", () => AddDataUserTask3.EntitySchemaId);
			MetaPathParameterValues.Add("cda6b132-0e59-45bb-988a-dd98d098385b", () => AddDataUserTask3.DataSourceFilters);
			MetaPathParameterValues.Add("611a2e2a-44ad-46d6-a803-86b905065d78", () => AddDataUserTask3.RecordAddMode);
			MetaPathParameterValues.Add("a85205de-fa99-4c50-85d5-7011ef3b4d0e", () => AddDataUserTask3.FilterEntitySchemaId);
			MetaPathParameterValues.Add("ac5bb6e7-6eff-457f-b790-d236a0edda50", () => AddDataUserTask3.RecordDefValues);
			MetaPathParameterValues.Add("415de17c-c12f-4817-8781-82b8431e8c3d", () => AddDataUserTask3.RecordId);
			MetaPathParameterValues.Add("17b9ed8b-e5b9-40a0-bcfd-f28cf677f061", () => AddDataUserTask3.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("369adb53-be77-4d6a-9958-3b4c83ca70fe", () => AutoGeneratedPageUserTask1.Title);
			MetaPathParameterValues.Add("6e13b431-433e-4be7-8eee-468eed2a7d09", () => AutoGeneratedPageUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("5408038c-ac80-4220-b5cc-f215a44ba230", () => AutoGeneratedPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("206826a5-918d-4250-8a64-287b1bde9a2b", () => AutoGeneratedPageUserTask1.EntityId);
			MetaPathParameterValues.Add("b9a46d74-6ecd-4ff8-8131-73d06aa4f4bd", () => AutoGeneratedPageUserTask1.Buttons);
			MetaPathParameterValues.Add("5e2f306b-000b-4710-81f9-7b949ea2ad54", () => AutoGeneratedPageUserTask1.Elements);
			MetaPathParameterValues.Add("830320f1-bd81-4cea-9f95-a80eadbd7767", () => AutoGeneratedPageUserTask1.ExtendedClientModule);
			MetaPathParameterValues.Add("6098bc34-95ad-496c-a3b2-81e95b073100", () => AutoGeneratedPageUserTask1.EntryPointId);
			MetaPathParameterValues.Add("300e12bc-e3f7-49b2-8167-6ffb30b989af", () => AutoGeneratedPageUserTask1.PressedButtonCode);
			MetaPathParameterValues.Add("0f482d41-ab86-41fc-b865-2e19e647b9aa", () => AutoGeneratedPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("8c0b7c0a-66fd-4a5b-9457-bf3729096fef", () => AutoGeneratedPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("ecbfdeeb-28bb-4777-abb9-4dc8ec14f22e", () => AutoGeneratedPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("76840c62-b319-4288-b212-45c7398a6f01", () => AutoGeneratedPageUserTask1.IsRunning);
			MetaPathParameterValues.Add("40cd9fca-93de-43ac-bad9-b6bd650fb71e", () => AutoGeneratedPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("1c402117-d798-4d9b-9fe0-f4186fd38fac", () => AutoGeneratedPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("8f809c9a-02c3-4421-a374-6ac4a55445e1", () => AutoGeneratedPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("3bf36bca-a471-4703-a862-b9393ef52169", () => AutoGeneratedPageUserTask1.StartIn);
			MetaPathParameterValues.Add("2219fd0b-9ccc-45c9-ba9e-637746c3b390", () => AutoGeneratedPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("c9784dc8-2609-4d7b-9904-3e783b2ab74f", () => AutoGeneratedPageUserTask1.Duration);
			MetaPathParameterValues.Add("18bbfc80-fce6-41ff-a52f-5e09da88f551", () => AutoGeneratedPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("20cc44f9-e57a-48b5-8307-e2df7f3fbc07", () => AutoGeneratedPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("5b9d1868-2e7f-43d6-bdd4-b971351edbc9", () => AutoGeneratedPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("5731ebdf-634e-4ff9-9a72-9cc02f274b9c", () => AutoGeneratedPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("0dd35ab2-a915-4647-9458-e2ff46c1fce1", () => AutoGeneratedPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("040523b9-4115-41a3-a912-2a611ac7fd3d", () => AutoGeneratedPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("634061c5-a984-4d9b-86f0-af4327ca4a12", () => AutoGeneratedPageUserTask1.ContactName);
			MetaPathParameterValues.Add("9b4bd2f4-9731-4207-a062-9c213f0dc347", () => AutoGeneratedPageUserTask1.Phone);
			MetaPathParameterValues.Add("28874bae-8f14-4476-b3c6-38c00d7380f3", () => AutoGeneratedPageUserTask1.Account);
			MetaPathParameterValues.Add("5a6f26d8-e7c2-41e2-98b7-31edaab7a990", () => AutoGeneratedPageUserTask1.Email);
			MetaPathParameterValues.Add("b1517598-2489-44aa-aaa6-5640f2853121", () => ReadDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("6afebec2-bcc5-4267-b4d1-642bc77d9b47", () => ReadDataUserTask1.ResultType);
			MetaPathParameterValues.Add("27a93232-ccc8-48ad-9eff-1ad1ea4b60eb", () => ReadDataUserTask1.ReadSomeTopRecords);
			MetaPathParameterValues.Add("60e46248-0ebb-4ee8-a1bc-4ee2f5b4a0b1", () => ReadDataUserTask1.NumberOfRecords);
			MetaPathParameterValues.Add("dd28bfbd-e627-4d61-a3fd-91ebd0891488", () => ReadDataUserTask1.FunctionType);
			MetaPathParameterValues.Add("1b16fad7-4ecc-4715-be57-b6aa7d76d4b9", () => ReadDataUserTask1.AggregationColumnName);
			MetaPathParameterValues.Add("4ae849fb-aa93-4b31-98f6-6818622659e0", () => ReadDataUserTask1.OrderInfo);
			MetaPathParameterValues.Add("cdf7b7b2-89b5-4196-a299-d432ec544639", () => ReadDataUserTask1.ResultEntity);
			MetaPathParameterValues.Add("3c555a9a-084f-46b0-97da-7805b5965ddc", () => ReadDataUserTask1.ResultCount);
			MetaPathParameterValues.Add("628c1898-b678-4647-b7e5-8624e2a20a4b", () => ReadDataUserTask1.ResultIntegerFunction);
			MetaPathParameterValues.Add("05f3c3a8-49ec-4ef1-923a-b82935dad796", () => ReadDataUserTask1.ResultFloatFunction);
			MetaPathParameterValues.Add("bc3bc9a9-a676-4a08-b8d4-3eca60a51ec1", () => ReadDataUserTask1.ResultDateTimeFunction);
			MetaPathParameterValues.Add("712197a2-16fc-411c-a0b8-ad059a020d40", () => ReadDataUserTask1.ResultRowsCount);
			MetaPathParameterValues.Add("fb660a18-6ba8-4292-86c1-b614908a8d63", () => ReadDataUserTask1.CanReadUncommitedData);
			MetaPathParameterValues.Add("2519b17d-ed42-4ff6-bb3c-7ebb21fcc7d5", () => ReadDataUserTask1.ResultEntityCollection);
			MetaPathParameterValues.Add("c735c402-0b9e-406d-a4e0-cbb66e7839f7", () => ReadDataUserTask1.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("75c9c0ab-0f22-4b23-9b18-aa90e393a626", () => ReadDataUserTask1.IgnoreDisplayValues);
			MetaPathParameterValues.Add("a27c7b13-58a7-4ad4-b15a-448de74c1d65", () => ReadDataUserTask1.ResultCompositeObjectList);
			MetaPathParameterValues.Add("9ddc6a96-8c0e-469b-9ff3-8706adc2e1ae", () => ReadDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("fbab1060-c0b1-4f93-867c-7266001affb5", () => ReadDataUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("924fc06b-cb19-4f36-a6b8-cf093ff6c691", () => ReadDataUserTask2.ResultType);
			MetaPathParameterValues.Add("7c0f02aa-82a3-47c5-8208-d996fae17d12", () => ReadDataUserTask2.ReadSomeTopRecords);
			MetaPathParameterValues.Add("29bb462d-f9de-41f8-a19f-9a0a6f6c1b19", () => ReadDataUserTask2.NumberOfRecords);
			MetaPathParameterValues.Add("2a4fe780-6a8d-4f63-b87b-5a80ff81bce7", () => ReadDataUserTask2.FunctionType);
			MetaPathParameterValues.Add("2195e600-5141-46fb-b239-3e0e4a1d1c65", () => ReadDataUserTask2.AggregationColumnName);
			MetaPathParameterValues.Add("023d4b5d-869b-486b-b744-24dbdc8bba9c", () => ReadDataUserTask2.OrderInfo);
			MetaPathParameterValues.Add("5efb285c-200d-4e01-90d9-5acd97f421c3", () => ReadDataUserTask2.ResultEntity);
			MetaPathParameterValues.Add("638e86b2-8f33-425f-aaa1-33fb04bf366d", () => ReadDataUserTask2.ResultCount);
			MetaPathParameterValues.Add("9eb12b6f-8e40-4fd0-b12e-2a3ef8ae2d3e", () => ReadDataUserTask2.ResultIntegerFunction);
			MetaPathParameterValues.Add("92940858-d280-4045-be1c-4dfc9c628640", () => ReadDataUserTask2.ResultFloatFunction);
			MetaPathParameterValues.Add("392ebbf9-7eb2-467c-8926-251c70dea54e", () => ReadDataUserTask2.ResultDateTimeFunction);
			MetaPathParameterValues.Add("d723185e-d81c-4915-b608-d9baa29f3ad5", () => ReadDataUserTask2.ResultRowsCount);
			MetaPathParameterValues.Add("02fb567d-b208-4a18-85e9-4dfe4ee10e81", () => ReadDataUserTask2.CanReadUncommitedData);
			MetaPathParameterValues.Add("a33a0ba3-e017-4a51-892a-31febdf691b4", () => ReadDataUserTask2.ResultEntityCollection);
			MetaPathParameterValues.Add("e85fcae9-ec25-43af-bcd0-47641523512d", () => ReadDataUserTask2.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9526e9cd-5214-40c4-a8ce-b2cd44a5bc1e", () => ReadDataUserTask2.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ebd64a2d-e832-4590-8e4e-d17eb77d95d2", () => ReadDataUserTask2.ResultCompositeObjectList);
			MetaPathParameterValues.Add("8306da24-e061-4f3c-bcaa-f7f14df26208", () => ReadDataUserTask2.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PreconfiguredPageUserTask1.ContactId":
					PreconfiguredPageUserTask1.ContactId = reader.GetValue<System.Guid>();
				break;
				case "PreconfiguredPageUserTask1.AccountId":
					PreconfiguredPageUserTask1.AccountId = reader.GetValue<System.Guid>();
				break;
				case "PreconfiguredPageUserTask1.ContactName":
					PreconfiguredPageUserTask1.ContactName = reader.GetValue<System.String>();
				break;
				case "PreconfiguredPageUserTask1.PhoneNumber":
					PreconfiguredPageUserTask1.PhoneNumber = reader.GetValue<System.String>();
				break;
				case "PreconfiguredPageUserTask1.Email":
					PreconfiguredPageUserTask1.Email = reader.GetValue<System.String>();
				break;
				case "PreconfiguredPageUserTask1.IsContactSelected":
					PreconfiguredPageUserTask1.IsContactSelected = reader.GetValue<System.Boolean>();
				break;
				case "PreconfiguredPageUserTask1.ResultCode":
					PreconfiguredPageUserTask1.ResultCode = reader.GetValue<System.String>();
				break;
				case "PreconfiguredPageUserTask1.IsCaseIncluded":
					PreconfiguredPageUserTask1.IsCaseIncluded = reader.GetValue<System.Boolean>();
				break;
				case "PreconfiguredPageUserTask1.AccountName":
					PreconfiguredPageUserTask1.AccountName = reader.GetValue<System.String>();
				break;
				case "PreconfiguredPageUserTask1.CreateContactButtonCaption":
					PreconfiguredPageUserTask1.CreateContactButtonCaption = reader.GetValue<System.String>();
				break;
				case "PreconfiguredPageUserTask1.SearchDetailSelectButtonCaption":
					PreconfiguredPageUserTask1.SearchDetailSelectButtonCaption = reader.GetValue<System.String>();
				break;
				case "AutoGeneratedPageUserTask1.ContactName":
					AutoGeneratedPageUserTask1.ContactName = reader.GetValue<System.String>();
				break;
				case "AutoGeneratedPageUserTask1.Phone":
					AutoGeneratedPageUserTask1.Phone = reader.GetValue<System.String>();
				break;
				case "AutoGeneratedPageUserTask1.Account":
					AutoGeneratedPageUserTask1.Account = reader.GetValue<System.Guid>();
				break;
				case "AutoGeneratedPageUserTask1.Email":
					AutoGeneratedPageUserTask1.Email = reader.GetValue<System.String>();
				break;
				case "ContactId":
					if (!hasValueToRead) break;
					ContactId = reader.GetValue<System.Guid>();
				break;
				case "AccountId":
					if (!hasValueToRead) break;
					AccountId = reader.GetValue<System.Guid>();
				break;
				case "PhoneNumber":
					if (!hasValueToRead) break;
					PhoneNumber = reader.GetValue<System.String>();
				break;
				case "NewContact":
					if (!hasValueToRead) break;
					NewContact = reader.GetValue<System.Boolean>();
				break;
				case "IsCaseIncluded":
					if (!hasValueToRead) break;
					IsCaseIncluded = reader.GetValue<System.Boolean>();
				break;
				case "AccountSelected":
					if (!hasValueToRead) break;
					AccountSelected = reader.GetValue<System.Boolean>();
				break;
				case "CreateContactButtonCaption":
					if (!hasValueToRead) break;
					CreateContactButtonCaption = reader.GetValue<System.String>();
				break;
				case "SearchDetailSelectButtonCaption":
					if (!hasValueToRead) break;
					SearchDetailSelectButtonCaption = reader.GetValue<System.String>();
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
			var localContactId = (PreconfiguredPageUserTask1.ContactId);
			ContactId = (System.Guid)localContactId;
			return true;
		}

		public virtual bool FormulaTask2Execute(ProcessExecutingContext context) {
			var localAccountId = (AutoGeneratedPageUserTask1.Account);
			AccountId = (System.Guid)localAccountId;
			return true;
		}

		public virtual bool FormulaTask3Execute(ProcessExecutingContext context) {
			var localContactId = (AddDataUserTask1.RecordId);
			ContactId = (System.Guid)localContactId;
			return true;
		}

		public virtual bool FormulaTask4Execute(ProcessExecutingContext context) {
			var localNewContact = true;
			NewContact = (System.Boolean)localNewContact;
			return true;
		}

		public virtual bool FormulaTask5Execute(ProcessExecutingContext context) {
			var localAccountId = ((ReadDataUserTask1.ResultEntity.IsColumnValueLoaded(ReadDataUserTask1.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? ReadDataUserTask1.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty));
			AccountId = (System.Guid)localAccountId;
			return true;
		}

		public virtual bool FormulaTask6Execute(ProcessExecutingContext context) {
			var localAccountSelected = true;
			AccountSelected = (System.Boolean)localAccountSelected;
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
			var cloneItem = (ContactIdentificationV2)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

