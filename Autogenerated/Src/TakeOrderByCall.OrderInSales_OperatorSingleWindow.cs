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

	#region Class: TakeOrderByCallSchema

	/// <exclude/>
	public class TakeOrderByCallSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public TakeOrderByCallSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public TakeOrderByCallSchema(TakeOrderByCallSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "TakeOrderByCall";
			UId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b");
			CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b");
			Version = 0;
			PackageUId = new Guid("256c1fdd-eb0d-4417-8768-8be76ab2d4f6");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fd3ea490-1c55-4290-a3e1-c7a1941f47cb"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"ContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7305d3f2-e670-44a3-b0a8-f38a1f208418"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"AccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePhoneNumberParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c66bb9a8-418c-4e0e-8c6b-0c8ef1e53719"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"PhoneNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsNewContactParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d06d3769-0077-45f8-b47b-d40813b7783b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"IsNewContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateContactIdParameter());
			Parameters.Add(CreateAccountIdParameter());
			Parameters.Add(CreatePhoneNumberParameter());
			Parameters.Add(CreateIsNewContactParameter());
		}

		protected virtual void InitializeContactIdentificationParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var contactIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("393e1dd3-d5c4-4b85-9cc0-67c913be750f"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"ContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactIdParameter.SourceValue = new ProcessSchemaParameterValue(contactIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{fd3ea490-1c55-4290-a3e1-c7a1941f47cb}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(contactIdParameter);
			var accountIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("cd7064c7-e5b7-4594-9d61-cdae77aa7799"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"AccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountIdParameter.SourceValue = new ProcessSchemaParameterValue(accountIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{7305d3f2-e670-44a3-b0a8-f38a1f208418}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(accountIdParameter);
			var phoneNumberParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6640386f-8254-43f5-9e98-391bfa7d84cb"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"PhoneNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			phoneNumberParameter.SourceValue = new ProcessSchemaParameterValue(phoneNumberParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c66bb9a8-418c-4e0e-8c6b-0c8ef1e53719}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(phoneNumberParameter);
			var newContactParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7290cfb4-c777-49e6-9de1-b7bc797fe1ef"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"NewContact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			newContactParameter.SourceValue = new ProcessSchemaParameterValue(newContactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443")
			};
			parametrizedElement.Parameters.Add(newContactParameter);
			var isCaseIncludedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("48a65493-eaa5-412b-9f3a-9fa9cf12f56d"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"IsCaseIncluded",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isCaseIncludedParameter.SourceValue = new ProcessSchemaParameterValue(isCaseIncludedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443")
			};
			parametrizedElement.Parameters.Add(isCaseIncludedParameter);
			var accountSelectedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4af2691c-1763-4fc0-bb7d-f286b330f5c9"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"AccountSelected",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			accountSelectedParameter.SourceValue = new ProcessSchemaParameterValue(accountSelectedParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443")
			};
			parametrizedElement.Parameters.Add(accountSelectedParameter);
			var createContactButtonCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("72eed8c3-6c81-47fe-80f6-1e03e64d181a"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"CreateContactButtonCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			createContactButtonCaptionParameter.SourceValue = new ProcessSchemaParameterValue(createContactButtonCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"""Создать заказ и контакт""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(createContactButtonCaptionParameter);
			var searchDetailSelectButtonCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("70898dfa-7bc3-4733-9077-90399d21aa15"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"SearchDetailSelectButtonCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			searchDetailSelectButtonCaptionParameter.SourceValue = new ProcessSchemaParameterValue(searchDetailSelectButtonCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"""Создать заказ""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(searchDetailSelectButtonCaptionParameter);
			var defaultContactNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d11bfaa-eadc-484e-8db6-96e56c94c8ee"),
				ContainerUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				Name = @"DefaultContactName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			defaultContactNameParameter.SourceValue = new ProcessSchemaParameterValue(defaultContactNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"New contact",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443")
			};
			parametrizedElement.Parameters.Add(defaultContactNameParameter);
		}

		protected virtual void InitializeOpenEditPageUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("cc60e6ad-de03-4561-b0ef-dc6660e33b11"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Value = @"80294582-06b5-4faa-a85f-3323e5536b71",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("f3e69a81-b379-4a4b-a562-84b5eea41a3a"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Value = @"23d86ac4-1d23-4314-a5e3-5da5e61b495a",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f64d65f5-f1a1-4d95-b24b-798f0ca456c8"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("07a46fc5-7242-4f02-be66-5bb1bdf6bd36"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,19,49,20,253,149,106,96,25,71,246,248,157,37,143,69,37,10,21,133,110,154,46,238,216,119,32,210,36,169,50,83,16,68,145,120,137,21,123,16,95,81,9,144,42,36,218,95,112,254,136,155,73,10,9,32,144,216,0,18,94,120,52,247,250,156,123,109,159,227,105,118,185,121,116,132,89,47,187,178,187,179,55,46,155,238,213,241,4,187,187,147,113,192,186,238,222,24,7,168,6,143,161,168,112,23,38,48,196,6,39,251,80,29,99,125,99,80,55,157,173,117,80,214,201,46,63,104,115,89,239,96,154,109,55,56,188,187,29,137,57,106,29,4,23,145,73,225,45,83,101,68,230,131,87,12,132,2,13,94,90,85,0,129,195,184,58,30,142,118,176,129,93,104,238,103,189,105,214,178,17,129,67,231,157,14,192,92,148,200,84,8,156,8,10,96,185,50,70,74,207,115,97,124,54,235,100,117,184,143,67,104,139,174,129,121,238,149,118,57,227,166,208,84,29,128,129,211,37,147,50,151,168,181,52,133,21,11,240,106,253,87,224,193,165,131,237,250,214,195,17,78,246,90,222,94,9,85,141,135,93,138,126,19,184,94,225,16,71,77,111,26,208,136,66,241,192,10,231,61,83,6,34,243,57,4,230,2,20,46,216,220,10,12,51,2,124,57,203,222,84,122,137,34,70,201,162,14,138,169,194,105,218,27,109,208,216,224,133,44,208,106,94,206,14,47,29,46,90,140,131,250,168,130,71,251,223,119,154,94,167,147,116,62,127,62,127,58,127,150,78,231,207,230,175,182,210,121,58,75,239,41,248,36,157,205,95,166,15,148,122,186,149,222,80,232,67,250,212,174,122,145,78,211,199,116,66,201,211,116,186,149,222,210,250,69,226,36,125,92,204,221,205,192,178,131,163,13,17,172,247,48,237,47,149,212,207,122,253,31,107,105,245,93,158,221,166,154,54,133,212,207,58,253,108,111,124,60,9,11,54,185,248,185,184,216,150,157,175,6,251,193,116,49,150,28,45,108,7,70,112,15,39,55,169,94,11,111,83,215,160,129,182,244,29,234,249,130,184,200,189,230,86,148,204,34,208,245,161,201,73,113,2,152,23,190,40,165,149,121,89,230,45,250,54,150,56,193,81,192,205,198,132,41,80,26,45,152,43,49,103,74,104,79,248,200,73,111,92,70,101,156,164,123,110,241,109,229,175,205,92,104,158,34,163,227,170,106,11,212,237,254,23,38,90,53,190,202,92,91,211,192,26,195,56,14,202,1,198,237,209,239,28,213,44,155,205,58,235,142,149,220,185,232,10,18,165,139,228,88,101,104,15,222,57,210,168,83,86,163,14,166,84,63,117,108,176,68,28,131,100,222,1,57,182,180,228,118,69,222,181,14,189,246,134,171,144,255,179,142,13,209,114,163,130,101,168,11,58,28,77,47,153,143,70,176,16,1,173,5,176,214,251,63,235,88,34,56,73,239,150,168,255,190,181,242,87,190,205,117,180,65,64,193,68,68,78,55,202,5,35,77,144,254,114,228,168,193,230,209,44,31,165,191,208,183,135,179,207,28,68,237,214,195,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("366bcdb5-976d-45d6-9fe7-b6bed812a95b"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2b0692bf-47fe-43d5-9e2e-9e19bf788ee4"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("4de13d18-2212-4973-ad89-9d1f2cf717e0"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("90a05111-f7d7-43cc-b25a-9db862b2d9cf"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ee6dda22-be0e-4d1a-91a1-1bd645edaed2"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6a30ad5d-a4bf-409c-8735-5da0095ed23c"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("342d5bb7-4ff5-4555-9665-2b3c43897b67"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("286e73d7-6301-47e6-8739-c59f7d4760b2"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("c58d8358-c7f4-484c-a1c0-f3e608d1972f"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Value = @"Внесите данные о заказе",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("4405b00e-b519-4ddc-8378-9592bbf0e5d3"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("383fb29e-8678-4563-a390-190db5adf28f"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysVariable.CurrentUserContact#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b813f85f-84a0-4a57-9009-6cd7cc5af4c5"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Value = @"15",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34d7ce15-726b-4e95-aa21-563b9bc38d9b"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8b7619b2-64d8-42c1-831c-1a7fc3b11da0"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("fc30c187-43ba-47e6-8d7e-cacbc496472a"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("649b1eb2-495a-4ae3-bcad-103fba8a0d6a"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("79a216ef-ce46-47c8-9b0b-d4db518424ef"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("276d8ef7-8993-4c85-954f-2db5bf99f77f"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("18d254bc-3c97-4da8-bab9-54447916f2db"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("8d716619-ddc5-4eb3-a0ba-980fb247ab90"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("300b1b18-9d75-4004-a562-6cc390990974"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{cd7064c7-e5b7-4594-9d61-cdae77aa7799}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("b796671a-b989-468f-947e-174ce2d96220"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{393e1dd3-d5c4-4b85-9cc0-67c913be750f}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("6a1a04b8-bd1f-482f-9c1e-62bcb731d696"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("bf417665-89ab-42b8-87cc-f48a42e3f6e3"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("efd87117-69ee-4051-bcac-ff6b816178d1"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("7e1e88fe-f343-4fcc-a999-efbea006bab2"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("5255bfdc-21e9-4df6-b2d7-5b4b576c6e9e"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("fd3d661a-af89-49db-88c9-e3ba80b5adf8"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("e6846fd9-dbd9-42a3-b4a1-d388f519657f"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("ff98d3c6-ee26-45c2-821d-70fec952223a"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("55af0d01-7bbb-4fc5-9d6a-7d867eb7485a"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("d1957622-4b21-4f73-894a-1e30db240580"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5f1659ee-f908-40b8-98a7-1c6cfdafa820"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("263e5b19-12b7-4ed2-8d85-f3fcdcc4de43"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1. Укажите продукты в заказе;
2. Заполните планируемый график выполнения заказа;
3. Укажите информацию о доставке и оплате;
4. Получите подтверждение от клиента, что вся информация указана правильно.",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(informationOnStepParameter);
			var orderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("ec941755-453f-4ff2-b360-5b10123c1eca"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("49d88184-4dd0-4af0-aed4-5471b2e040e3"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("854d33df-b538-4780-b650-3ba1e7128f0f"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("aa2c6903-2f9b-452f-8564-b46be756ff24"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("9d61be59-c470-4d60-b223-6a2ae898d030"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("a79878c7-843f-4c44-b52b-090d8e96344d"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("a5f4be1a-5cce-4ae8-b725-313f9ef531fa"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("008316f9-efc0-427d-855d-f2bc3983e119"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("28185a19-88ee-4be5-83fa-18f00be27b35"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("d90405d0-8040-408f-8702-fa02c4358f2b"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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
				UId = new Guid("35e73697-3131-4eba-a5de-fbb6d9193677"),
				ContainerUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
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

		protected virtual void InitializeUserQuestionUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var branchingDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("242fc279-4701-420c-9817-ff9bf2bd25de"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"BranchingDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableParameterValuesListDataValueType")
			};
			branchingDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(branchingDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,205,74,195,64,20,133,95,69,6,151,153,50,127,153,73,186,180,69,40,84,41,248,179,17,23,119,110,238,96,48,53,37,73,5,91,178,241,25,220,250,14,110,124,143,250,70,78,186,144,138,40,238,46,156,243,93,206,183,101,199,221,211,138,216,152,157,44,206,46,234,208,141,38,117,67,163,69,83,35,181,237,104,94,35,84,229,6,124,69,11,104,96,73,29,53,215,80,173,169,157,151,109,151,28,29,66,44,97,199,143,251,140,141,111,182,108,214,209,242,106,86,196,207,129,114,16,194,3,55,186,240,220,32,164,220,163,83,92,99,64,111,193,144,81,69,132,135,238,150,237,63,68,72,58,167,77,200,82,158,58,31,161,66,104,158,27,97,185,179,182,8,86,161,7,176,172,79,216,121,28,117,200,77,9,203,182,172,31,196,16,78,96,213,197,123,200,203,118,142,155,253,116,54,238,154,53,37,95,196,238,101,247,54,148,167,20,38,119,132,247,244,109,199,101,236,178,190,79,14,133,180,247,10,133,64,110,164,206,185,17,58,240,76,203,156,107,149,162,139,219,148,70,253,67,72,65,144,82,134,156,147,200,84,132,64,114,31,140,224,153,183,6,69,158,42,4,247,151,144,252,191,208,235,238,253,227,249,119,165,83,168,218,193,233,182,255,4,188,10,155,229,254,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(branchingDecisionsParameter);
			var resultDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7ea1f8f-9bc8-4754-9565-95b1b7ed85fb"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ResultDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			resultDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(resultDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDecisionsParameter);
			var decisionModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5865056c-667d-4196-bfb2-93ab9bb3f880"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DecisionMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			decisionModeParameter.SourceValue = new ProcessSchemaParameterValue(decisionModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(decisionModeParameter);
			var isDecisionRequiredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a38de23c-3485-4d1b-9081-4257aeb1f0cb"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"IsDecisionRequired",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isDecisionRequiredParameter.SourceValue = new ProcessSchemaParameterValue(isDecisionRequiredParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(isDecisionRequiredParameter);
			var questionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("54bd1525-bba9-4114-9d45-6885640ed63d"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Question",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			questionParameter.SourceValue = new ProcessSchemaParameterValue(questionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Отредактировать данные контакта?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(questionParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4213a79c-4d3e-48cf-a5e7-c3cc235019aa"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Страница выбора ответа для элемента ""Редактировать данные контакта?""",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e0347d3-8a22-4ce7-8f04-2284ab9832bd"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Отредактировать данные контакта?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("333e3f7d-361a-448d-8a84-1a9810c42f1a"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("ac5a5fc3-8a97-4567-a69d-0a33f1640ec4"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4514de81-e0b5-44cf-bbdb-e51b25152986"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"15",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3fc44c2d-675b-4234-880c-1a871a813e53"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7772497-e1fc-4c0d-9b89-c69494634c95"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7b8f9df2-b9a1-4bde-ac1b-14a761e98330"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("135b7ef1-c96a-4226-912e-adfdfce0ae33"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8bb237fb-0984-4c96-8414-bd727e19f9df"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c36964d-6861-41a5-a4d7-dd8e3f3d6524"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("75dcb4b8-f9de-4f3c-82e6-683fc40fb5e7"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("eed9b133-5bb5-4331-a2ed-e7e35848250f"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("1110c6e4-c088-4308-92bc-098e62be250d"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{cd7064c7-e5b7-4594-9d61-cdae77aa7799}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("c680b79c-943f-49f3-bd29-db32dc87837d"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{393e1dd3-d5c4-4b85-9cc0-67c913be750f}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("6251ed82-c743-4bd7-b257-ea16931e0593"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("f970ffb4-b565-4912-b74e-9665b287e554"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("05acd2b8-eb7f-4530-8f91-31ee541874b3"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("c5964f8c-df11-409f-ab6a-b323471ce4ab"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("2609150c-3b90-4408-ac84-b29fa9fe8740"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("c1487f5a-e5c3-4cd3-afc0-290965d651e5"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("60e13508-4a0f-44eb-8ce7-2866e74a9146"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("fc76a430-c50c-4fc2-b03d-fc5f7af678bb"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("029e4048-a171-4af0-a135-ee0bc84027ce"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("441b7b8b-820a-41ab-a54e-9c986ff06c68"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("fffb72f7-73ff-43a0-901c-af061d200009"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("ece8c629-15f7-4d70-bf2a-2f368584bcf7"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("df84dc0d-fbbd-4b8e-8d88-41e0896f035b"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("5a52a36c-a72a-41d0-b85d-87b4acb4ba89"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("35cde648-05d5-445c-826b-ca9260c0d3c0"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("4892e8d7-6fc4-4c8c-9849-5b7ed1db0dcb"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("3bfd9e82-741d-4a59-8eff-f6ff59f595d5"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("4e974ee6-3919-4099-8fdb-109651dec5d2"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				UId = new Guid("38921604-2793-4ae7-ba81-6f8e05508efd"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0af07ffb-01d5-4387-adaf-dba180b5a289"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("3c3fc15e-549b-482d-81be-18269f9b02ee"),
				ContainerUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
		}

		protected virtual void InitializeOpenEditPageUserTask2Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("bf89ef1c-af66-4671-bc99-ab29e04ef274"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"16be3651-8fe2-4159-8dd0-a803d4683dd3",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("e76aa928-2b7a-4c0e-9fe3-65b1b3dbdc96"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"8737e39c-ac08-4903-acd0-11570570691d",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e585f4f1-f6d9-4588-8568-f275845f7776"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("84fa8cac-0acd-4cb9-a5da-f0e657b00351"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("08b08ada-67d4-436f-8fb7-c269cf2d3f6f"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{393e1dd3-d5c4-4b85-9cc0-67c913be750f}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{393e1dd3-d5c4-4b85-9cc0-67c913be750f}]#]",
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("65c15211-5b35-4c47-a593-0e148fe507cf"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("b3e431b0-b262-4888-947b-0742cdccb7e9"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0943620-be2b-4434-aa33-05e9908d30de"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a50f8137-b46a-4c9c-aca3-f67b5af037c1"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e310cc54-11ad-4846-a59e-f1cedc6fa29f"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ab2a5b55-b25c-4e8f-89b1-08ebf2b242f9"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("ab06fa1a-baaa-4208-95e8-4e113e3a161a"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("d0bcc08a-0e38-4ac0-864f-30caa50830a0"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"Заполните данные контакта",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("079279b5-8793-49d7-b217-3a115881d4ec"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("aa2c680f-8193-4e90-b895-1cc7d0804f81"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysVariable.CurrentUserContact#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a1fed64c-6b91-4eeb-a70d-f84c03cdf787"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"15",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b99cf94-32a9-4da1-9f9e-85f517aa6cfd"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("44dd0c12-d4fc-4409-b49e-f717ab223493"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("dd1f16ab-1cf5-48eb-9789-6b561b131c1e"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4278771d-9cc8-4d1e-be2a-65bfd3c08ac6"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("58b7077c-5122-4489-9e7e-e3a4dd0faa2b"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6a937388-e8cc-4c10-870e-32fd5f54c9a6"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("65d213a2-2237-4862-97e1-e566882ed229"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("4fbbbfff-cd22-424f-a95f-a15192ebc70f"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("124d5cd0-bc07-4c65-bf96-a1fe056e0eff"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{cd7064c7-e5b7-4594-9d61-cdae77aa7799}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("cfceb661-b87a-4686-bf85-226e99854373"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{393e1dd3-d5c4-4b85-9cc0-67c913be750f}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("339b8c23-a004-4c2a-8ea6-48a9cd04fccf"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("5d1d78e1-1e1f-40d9-8cf4-bfd91259bb4c"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("3e38360c-29d8-462c-a3c8-15c917a704ff"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("98823996-3da5-404e-87b0-005b701c8c00"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("9df09cc8-b941-4469-ac9d-9c2d614b96bc"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("c547483b-e0b7-4219-a57e-acca9ea6eeac"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("c40d5e8f-a839-491b-9ca8-297d12952755"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("20172dfd-6fa1-4be4-b1f3-2a4404d59444"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("e4b9bcec-0e11-4a0d-b3e9-303c8673d170"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("e068a907-4ecb-451e-85fe-659a40b7e971"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("75e31b52-aadd-47e2-a13e-9e958e88e0f2"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("4f1a0a7b-84a0-4889-a0dc-82651658d577"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("65ea4a95-d580-4fab-bc9a-bd2dead86bbf"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("cd039377-af7f-4bff-912d-d1d10f532547"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("58b787ce-206d-41bd-bc0f-0819e08fbc07"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("63fa99c0-05ba-4811-8a2e-2df466264008"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("759206d2-03de-43f9-9ff5-7be41b1e19cd"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("6aef599c-841b-4c28-871b-cc7def0d0d10"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("b7a6ab9a-067b-45bf-846a-c2b2683f7f7c"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("654c811c-8d84-4c85-8879-6f2252212386"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("6a71e918-e32c-49c8-adc8-825211514808"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("7e17bf4d-ed30-4ec6-bb86-2d716438be4c"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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
				UId = new Guid("6b10b87f-d69c-46ba-941d-1006da8651f2"),
				ContainerUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
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

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaSubProcess contactidentification = CreateContactIdentificationSubProcess();
			FlowElements.Add(contactidentification);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask openeditpageusertask1 = CreateOpenEditPageUserTask1UserTask();
			FlowElements.Add(openeditpageusertask1);
			ProcessSchemaUserTask userquestionusertask1 = CreateUserQuestionUserTask1UserTask();
			FlowElements.Add(userquestionusertask1);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaUserTask openeditpageusertask2 = CreateOpenEditPageUserTask2UserTask();
			FlowElements.Add(openeditpageusertask2);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("fb191fcb-2a04-48c2-a473-c2e293e634d6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6e60e4c1-aedd-4177-9376-3d5f070e8eac"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("0df49e43-3edb-456a-b533-1a6005aa31eb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("d75499af-0e49-42ad-b6dc-24dbf14400d9"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{ce61b40c-b899-46ad-92ac-8cab8c7271ec}].[Parameter:{7290cfb4-c777-49e6-9de1-b7bc797fe1ef}]#] || [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d06d3769-0077-45f8-b47b-d40813b7783b}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(418, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("41c4ad87-edff-4a3e-a026-04aa7707a1e2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(580, 225),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c1cbd6a-7d89-4ad6-8026-3960ea98d6f2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(316, 296));
			schemaFlow.PolylinePointPositions.Add(new Point(771, 296));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("d3145de2-24eb-4ea7-af4d-26d28b230b47"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(594, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e95ea45e-9888-4d0f-b09f-e1c2674d956d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("e41ceed2-ccb2-4f02-9674-bfb59073f22c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(744, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e95ea45e-9888-4d0f-b09f-e1c2674d956d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c1cbd6a-7d89-4ad6-8026-3960ea98d6f2"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"), new Collection<Guid>() {
						new Guid("2af111f9-e082-40a1-bf40-8b64c0952ca7"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("4d7288fa-c27d-4dea-bef9-8943720de14f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(691, 148),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e95ea45e-9888-4d0f-b09f-e1c2674d956d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"), new Collection<Guid>() {
						new Guid("17734f85-57bb-4d03-9406-766df62cbaa6"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("af32b40f-5e57-40bd-9004-3a0d0e68728e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				CurveCenterPosition = new Point(790, 138),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c1cbd6a-7d89-4ad6-8026-3960ea98d6f2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("fb478814-960f-4af5-8be0-2e410fac66f8"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1006, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("fb478814-960f-4af5-8be0-2e410fac66f8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(977, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("6e60e4c1-aedd-4177-9376-3d5f070e8eac"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("0c1cbd6a-7d89-4ad6-8026-3960ea98d6f2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"Terminate1",
				Position = new Point(757, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaSubProcess CreateContactIdentificationSubProcess() {
			ProcessSchemaSubProcess schemaContactIdentification = new ProcessSchemaSubProcess(this) {
				UId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"ContactIdentification",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(134, 170),
				SchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeContactIdentificationParameters(schemaContactIdentification);
			return schemaContactIdentification;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"OpenEditPageUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(281, 170),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateUserQuestionUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"UserQuestionUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(442, 170),
				SchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserQuestionUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("e95ea45e-9888-4d0f-b09f-e1c2674d956d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(603, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEditPageUserTask2UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8c878877-1250-4bb9-a62a-f8b2476f3b90"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0cce7e8b-c985-435f-8005-0c0ee9b342c6"),
				CreatedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"),
				Name = @"OpenEditPageUserTask2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(673, 51),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEditPageUserTask2Parameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new TakeOrderByCall(userConnection);
		}

		public override object Clone() {
			return new TakeOrderByCallSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b"));
		}

		#endregion

	}

	#endregion

	#region Class: TakeOrderByCall

	/// <exclude/>
	public class TakeOrderByCall : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, TakeOrderByCall process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ContactIdentificationFlowElement

		/// <exclude/>
		public class ContactIdentificationFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public ContactIdentificationFlowElement(UserConnection userConnection, TakeOrderByCall process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("a3fe75d8-b709-481e-8829-23289dfa0443");
			}

			#endregion

			#region Properties: Public

			public Guid ContactId {
				get {
					return GetParameterValue<Guid>("ContactId");
				}
				set {
					SetParameterValue("ContactId", value);
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

			public string PhoneNumber {
				get {
					return GetParameterValue<string>("PhoneNumber");
				}
				set {
					SetParameterValue("PhoneNumber", value);
				}
			}

			public bool NewContact {
				get {
					return GetParameterValue<bool>("NewContact");
				}
				set {
					SetParameterValue("NewContact", value);
				}
			}

			public bool IsCaseIncluded {
				get {
					return GetParameterValue<bool>("IsCaseIncluded");
				}
				set {
					SetParameterValue("IsCaseIncluded", value);
				}
			}

			public bool AccountSelected {
				get {
					return GetParameterValue<bool>("AccountSelected");
				}
				set {
					SetParameterValue("AccountSelected", value);
				}
			}

			public string CreateContactButtonCaption {
				get {
					return GetParameterValue<string>("CreateContactButtonCaption");
				}
				set {
					SetParameterValue("CreateContactButtonCaption", value);
				}
			}

			public string SearchDetailSelectButtonCaption {
				get {
					return GetParameterValue<string>("SearchDetailSelectButtonCaption");
				}
				set {
					SetParameterValue("SearchDetailSelectButtonCaption", value);
				}
			}

			public LocalizableString DefaultContactName {
				get {
					return GetParameterValue<LocalizableString>("DefaultContactName");
				}
				set {
					SetParameterValue("DefaultContactName", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (TakeOrderByCall)owner;
				Name = "ContactIdentification";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("ce61b40c-b899-46ad-92ac-8cab8c7271ec");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (TakeOrderByCall)Owner;
				SetParameterValue("ContactId", (Guid)((process.ContactId)));
				SetParameterValue("AccountId", (Guid)((process.AccountId)));
				SetParameterValue("PhoneNumber", new LocalizableString((process.PhoneNumber)));
				SetParameterValue("CreateContactButtonCaption", new LocalizableString("Создать заказ и контакт"));
				SetParameterValue("SearchDetailSelectButtonCaption", new LocalizableString("Создать заказ"));
			}

			#endregion

		}

		#endregion

		#region Class: OpenEditPageUserTask1FlowElement

		/// <exclude/>
		public class OpenEditPageUserTask1FlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenEditPageUserTask1FlowElement(UserConnection userConnection, TakeOrderByCall process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("da92b821-ad75-4fa5-8e66-93d4755fd2f7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_recordColumnValues_Contact = () => (Guid)((process.ContactIdentification.ContactId));
				_recordColumnValues_Account = () => (Guid)((process.ContactIdentification.AccountId));
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_account = () => (Guid)((process.ContactIdentification.AccountId));
				_contact = () => (Guid)((process.ContactIdentification.ContactId));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Contact", () => _recordColumnValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Account", () => _recordColumnValues_Account.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Contact;
			internal Func<Guid> _recordColumnValues_Account;

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("23d86ac4-1d23-4314-a5e3-5da5e61b495a");
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

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,19,49,20,253,149,106,96,25,71,246,248,157,37,143,69,37,10,21,133,110,154,46,238,216,119,32,210,36,169,50,83,16,68,145,120,137,21,123,16,95,81,9,144,42,36,218,95,112,254,136,155,73,10,9,32,144,216,0,18,94,120,52,247,250,156,123,109,159,227,105,118,185,121,116,132,89,47,187,178,187,179,55,46,155,238,213,241,4,187,187,147,113,192,186,238,222,24,7,168,6,143,161,168,112,23,38,48,196,6,39,251,80,29,99,125,99,80,55,157,173,117,80,214,201,46,63,104,115,89,239,96,154,109,55,56,188,187,29,137,57,106,29,4,23,145,73,225,45,83,101,68,230,131,87,12,132,2,13,94,90,85,0,129,195,184,58,30,142,118,176,129,93,104,238,103,189,105,214,178,17,129,67,231,157,14,192,92,148,200,84,8,156,8,10,96,185,50,70,74,207,115,97,124,54,235,100,117,184,143,67,104,139,174,129,121,238,149,118,57,227,166,208,84,29,128,129,211,37,147,50,151,168,181,52,133,21,11,240,106,253,87,224,193,165,131,237,250,214,195,17,78,246,90,222,94,9,85,141,135,93,138,126,19,184,94,225,16,71,77,111,26,208,136,66,241,192,10,231,61,83,6,34,243,57,4,230,2,20,46,216,220,10,12,51,2,124,57,203,222,84,122,137,34,70,201,162,14,138,169,194,105,218,27,109,208,216,224,133,44,208,106,94,206,14,47,29,46,90,140,131,250,168,130,71,251,223,119,154,94,167,147,116,62,127,62,127,58,127,150,78,231,207,230,175,182,210,121,58,75,239,41,248,36,157,205,95,166,15,148,122,186,149,222,80,232,67,250,212,174,122,145,78,211,199,116,66,201,211,116,186,149,222,210,250,69,226,36,125,92,204,221,205,192,178,131,163,13,17,172,247,48,237,47,149,212,207,122,253,31,107,105,245,93,158,221,166,154,54,133,212,207,58,253,108,111,124,60,9,11,54,185,248,185,184,216,150,157,175,6,251,193,116,49,150,28,45,108,7,70,112,15,39,55,169,94,11,111,83,215,160,129,182,244,29,234,249,130,184,200,189,230,86,148,204,34,208,245,161,201,73,113,2,152,23,190,40,165,149,121,89,230,45,250,54,150,56,193,81,192,205,198,132,41,80,26,45,152,43,49,103,74,104,79,248,200,73,111,92,70,101,156,164,123,110,241,109,229,175,205,92,104,158,34,163,227,170,106,11,212,237,254,23,38,90,53,190,202,92,91,211,192,26,195,56,14,202,1,198,237,209,239,28,213,44,155,205,58,235,142,149,220,185,232,10,18,165,139,228,88,101,104,15,222,57,210,168,83,86,163,14,166,84,63,117,108,176,68,28,131,100,222,1,57,182,180,228,118,69,222,181,14,189,246,134,171,144,255,179,142,13,209,114,163,130,101,168,11,58,28,77,47,153,143,70,176,16,1,173,5,176,214,251,63,235,88,34,56,73,239,150,168,255,190,181,242,87,190,205,117,180,65,64,193,68,68,78,55,202,5,35,77,144,254,114,228,168,193,230,209,44,31,165,191,208,183,135,179,207,28,68,237,214,195,7,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "583ad5c91de94bb4b37d2f226fecca4b",
							"BaseElements.OpenEditPageUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("256c1fdd-eb0d-4417-8768-8be76ab2d4f6");
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
					return _recommendation ?? (_recommendation = GetLocalizableString("583ad5c91de94bb4b37d2f226fecca4b",
						 "BaseElements.OpenEditPageUserTask1.Parameters.Recommendation.Value"));
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

			private int _duration = 15;
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

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
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

			private LocalizableString _informationOnStep;
			public override LocalizableString InformationOnStep {
				get {
					return _informationOnStep ?? (_informationOnStep = GetLocalizableString("583ad5c91de94bb4b37d2f226fecca4b",
						 "BaseElements.OpenEditPageUserTask1.Parameters.InformationOnStep.Value"));
				}
				set {
					_informationOnStep = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: UserQuestionUserTask1FlowElement

		/// <exclude/>
		public class UserQuestionUserTask1FlowElement : UserQuestionUserTask
		{

			#region Constructors: Public

			public UserQuestionUserTask1FlowElement(UserConnection userConnection, TakeOrderByCall process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserQuestionUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_account = () => (Guid)((process.ContactIdentification.AccountId));
				_contact = () => (Guid)((process.ContactIdentification.ContactId));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _branchingDecisions;
			public override LocalizableString BranchingDecisions {
				get {
					if (_branchingDecisions == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,143,203,106,195,48,16,69,127,165,136,44,173,160,151,37,59,203,38,20,2,105,9,244,177,41,93,140,198,35,106,234,212,193,82,10,77,240,191,87,206,42,165,208,69,118,3,119,206,204,61,39,54,75,223,123,98,11,118,187,189,127,236,67,154,47,251,129,230,219,161,71,138,113,190,233,17,186,246,8,190,163,45,12,176,163,68,195,11,116,7,138,155,54,166,226,230,18,98,5,155,125,157,51,182,120,61,177,117,162,221,243,186,201,151,3,213,32,132,7,110,116,227,185,65,40,185,71,167,184,198,128,222,130,33,163,154,12,79,187,39,118,190,144,33,233,156,54,161,42,121,233,124,134,26,161,121,109,132,229,206,218,38,88,133,30,192,178,177,96,15,185,212,37,183,34,108,99,219,127,138,41,92,194,62,229,121,202,219,184,193,227,185,58,91,164,225,64,57,93,81,88,190,19,126,208,175,199,79,57,100,227,88,92,26,104,239,21,10,129,220,72,93,115,35,116,224,149,150,53,215,170,68,151,203,40,141,250,143,129,130,32,165,12,53,39,81,169,12,129,228,62,24,193,43,111,13,138,186,84,8,238,63,3,121,173,193,29,116,113,82,120,27,127,0,57,82,233,88,222,1,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "583ad5c91de94bb4b37d2f226fecca4b",
							"BaseElements.UserQuestionUserTask1.Parameters.BranchingDecisions.Value");
						dataList.LoadLocalizableValues();
						_branchingDecisions = dataList.GetSerializedItems();
						};
					return _branchingDecisions;
				}
				set {
					_branchingDecisions = value;
				}
			}

			private int _decisionMode = 0;
			public override int DecisionMode {
				get {
					return _decisionMode;
				}
				set {
					_decisionMode = value;
				}
			}

			private bool _isDecisionRequired = true;
			public override bool IsDecisionRequired {
				get {
					return _isDecisionRequired;
				}
				set {
					_isDecisionRequired = value;
				}
			}

			private LocalizableString _question;
			public override LocalizableString Question {
				get {
					return _question ?? (_question = GetLocalizableString("583ad5c91de94bb4b37d2f226fecca4b",
						 "BaseElements.UserQuestionUserTask1.Parameters.Question.Value"));
				}
				set {
					_question = value;
				}
			}

			private LocalizableString _windowCaption;
			public override LocalizableString WindowCaption {
				get {
					return _windowCaption ?? (_windowCaption = GetLocalizableString("583ad5c91de94bb4b37d2f226fecca4b",
						 "BaseElements.UserQuestionUserTask1.Parameters.WindowCaption.Value"));
				}
				set {
					_windowCaption = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("583ad5c91de94bb4b37d2f226fecca4b",
						 "BaseElements.UserQuestionUserTask1.Parameters.Recommendation.Value"));
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

			private int _duration = 15;
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

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
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

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"2af111f9-e082-40a1-bf40-8b64c0952ca7\",\"17734f85-57bb-4d03-9406-766df62cbaa6\"]";
			}

			#endregion

		}

		#endregion

		#region Class: OpenEditPageUserTask2FlowElement

		/// <exclude/>
		public class OpenEditPageUserTask2FlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenEditPageUserTask2FlowElement(UserConnection userConnection, TakeOrderByCall process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEditPageUserTask2";
				IsLogging = true;
				SchemaElementUId = new Guid("2bf73f22-54fe-4a50-ab84-3dee99b6973d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_recordId = () => (Guid)((process.ContactIdentification.ContactId));
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
				_account = () => (Guid)((process.ContactIdentification.AccountId));
				_contact = () => (Guid)((process.ContactIdentification.ContactId));
			}

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("8737e39c-ac08-4903-acd0-11570570691d");
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
					return _recommendation ?? (_recommendation = GetLocalizableString("583ad5c91de94bb4b37d2f226fecca4b",
						 "BaseElements.OpenEditPageUserTask2.Parameters.Recommendation.Value"));
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

			private int _duration = 15;
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

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
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

			#endregion

		}

		#endregion

		public TakeOrderByCall(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TakeOrderByCall";
			SchemaUId = new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b");
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
				return new Guid("583ad5c9-1de9-4bb4-b37d-2f226fecca4b");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: TakeOrderByCall, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: TakeOrderByCall, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

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

		public virtual bool IsNewContact {
			get;
			set;
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
					SchemaElementUId = new Guid("6e60e4c1-aedd-4177-9376-3d5f070e8eac"),
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
					SchemaElementUId = new Guid("0c1cbd6a-7d89-4ad6-8026-3960ea98d6f2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ContactIdentificationFlowElement _contactIdentification;
		public ContactIdentificationFlowElement ContactIdentification {
			get {
				return _contactIdentification ?? ((_contactIdentification) = new ContactIdentificationFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OpenEditPageUserTask1FlowElement _openEditPageUserTask1;
		public OpenEditPageUserTask1FlowElement OpenEditPageUserTask1 {
			get {
				return _openEditPageUserTask1 ?? (_openEditPageUserTask1 = new OpenEditPageUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private UserQuestionUserTask1FlowElement _userQuestionUserTask1;
		public UserQuestionUserTask1FlowElement UserQuestionUserTask1 {
			get {
				return _userQuestionUserTask1 ?? (_userQuestionUserTask1 = new UserQuestionUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("e95ea45e-9888-4d0f-b09f-e1c2674d956d"),
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

		private OpenEditPageUserTask2FlowElement _openEditPageUserTask2;
		public OpenEditPageUserTask2FlowElement OpenEditPageUserTask2 {
			get {
				return _openEditPageUserTask2 ?? (_openEditPageUserTask2 = new OpenEditPageUserTask2FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("d75499af-0e49-42ad-b6dc-24dbf14400d9"),
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
					SchemaElementUId = new Guid("e41ceed2-ccb2-4f02-9674-bfb59073f22c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"), new Collection<Guid>() {
							new Guid("2af111f9-e082-40a1-bf40-8b64c0952ca7"),
						}},
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
					SchemaElementUId = new Guid("4d7288fa-c27d-4dea-bef9-8943720de14f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749"), new Collection<Guid>() {
							new Guid("17734f85-57bb-4d03-9406-766df62cbaa6"),
						}},
					},
				});
			}
		}

		private ProcessToken _start1ContactIdentificationToken;
		public ProcessToken Start1ContactIdentificationToken {
			get {
				return _start1ContactIdentificationToken ?? (_start1ContactIdentificationToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "Start1ContactIdentificationToken",
					SchemaElementUId = new Guid("e90c3916-6e2f-4725-8cfe-b97105d5969f"),
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
			FlowElements[ContactIdentification.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactIdentification };
			FlowElements[OpenEditPageUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask1 };
			FlowElements[UserQuestionUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { UserQuestionUserTask1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[OpenEditPageUserTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEditPageUserTask2 };
			FlowElements[Start1ContactIdentificationToken.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1ContactIdentificationToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start1ContactIdentificationToken", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ContactIdentification":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask1", e.Context.SenderName));
						break;
					case "OpenEditPageUserTask1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserQuestionUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "UserQuestionUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEditPageUserTask2", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ExclusiveGateway1");
						break;
					case "OpenEditPageUserTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "Start1ContactIdentificationToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ContactIdentification", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((ContactIdentification.NewContact) || (IsNewContact));
			Log.InfoFormat(ConditionalExpressionLogMessage, "OpenEditPageUserTask1", "ConditionalFlow1", "(ContactIdentification.NewContact) || (IsNewContact)", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow2.ProcessActivitiesSelectedResults[new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow2", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow2.ProcessActivitiesSelectedResults[new Guid(\"3aa6b74f-7e82-42be-9030-19e3b79c9749\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow3.ProcessActivitiesSelectedResults[new Guid("3aa6b74f-7e82-42be-9030-19e3b79c9749")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow3", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow3.ProcessActivitiesSelectedResults[new Guid(\"3aa6b74f-7e82-42be-9030-19e3b79c9749\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ContactId")) {
				writer.WriteValue("ContactId", ContactId, Guid.Empty);
			}
			if (!HasMapping("AccountId")) {
				writer.WriteValue("AccountId", AccountId, Guid.Empty);
			}
			if (!HasMapping("PhoneNumber")) {
				writer.WriteValue("PhoneNumber", PhoneNumber, null);
			}
			if (!HasMapping("IsNewContact")) {
				writer.WriteValue("IsNewContact", IsNewContact, false);
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
			MetaPathParameterValues.Add("fd3ea490-1c55-4290-a3e1-c7a1941f47cb", () => ContactId);
			MetaPathParameterValues.Add("7305d3f2-e670-44a3-b0a8-f38a1f208418", () => AccountId);
			MetaPathParameterValues.Add("c66bb9a8-418c-4e0e-8c6b-0c8ef1e53719", () => PhoneNumber);
			MetaPathParameterValues.Add("d06d3769-0077-45f8-b47b-d40813b7783b", () => IsNewContact);
			MetaPathParameterValues.Add("393e1dd3-d5c4-4b85-9cc0-67c913be750f", () => ContactIdentification.ContactId);
			MetaPathParameterValues.Add("cd7064c7-e5b7-4594-9d61-cdae77aa7799", () => ContactIdentification.AccountId);
			MetaPathParameterValues.Add("6640386f-8254-43f5-9e98-391bfa7d84cb", () => ContactIdentification.PhoneNumber);
			MetaPathParameterValues.Add("7290cfb4-c777-49e6-9de1-b7bc797fe1ef", () => ContactIdentification.NewContact);
			MetaPathParameterValues.Add("48a65493-eaa5-412b-9f3a-9fa9cf12f56d", () => ContactIdentification.IsCaseIncluded);
			MetaPathParameterValues.Add("4af2691c-1763-4fc0-bb7d-f286b330f5c9", () => ContactIdentification.AccountSelected);
			MetaPathParameterValues.Add("72eed8c3-6c81-47fe-80f6-1e03e64d181a", () => ContactIdentification.CreateContactButtonCaption);
			MetaPathParameterValues.Add("70898dfa-7bc3-4733-9077-90399d21aa15", () => ContactIdentification.SearchDetailSelectButtonCaption);
			MetaPathParameterValues.Add("0d11bfaa-eadc-484e-8db6-96e56c94c8ee", () => ContactIdentification.DefaultContactName);
			MetaPathParameterValues.Add("cc60e6ad-de03-4561-b0ef-dc6660e33b11", () => OpenEditPageUserTask1.ObjectSchemaId);
			MetaPathParameterValues.Add("f3e69a81-b379-4a4b-a562-84b5eea41a3a", () => OpenEditPageUserTask1.PageSchemaId);
			MetaPathParameterValues.Add("f64d65f5-f1a1-4d95-b24b-798f0ca456c8", () => OpenEditPageUserTask1.EditMode);
			MetaPathParameterValues.Add("07a46fc5-7242-4f02-be66-5bb1bdf6bd36", () => OpenEditPageUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("366bcdb5-976d-45d6-9fe7-b6bed812a95b", () => OpenEditPageUserTask1.RecordId);
			MetaPathParameterValues.Add("2b0692bf-47fe-43d5-9e2e-9e19bf788ee4", () => OpenEditPageUserTask1.ExecutedMode);
			MetaPathParameterValues.Add("4de13d18-2212-4973-ad89-9d1f2cf717e0", () => OpenEditPageUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("90a05111-f7d7-43cc-b25a-9db862b2d9cf", () => OpenEditPageUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("ee6dda22-be0e-4d1a-91a1-1bd645edaed2", () => OpenEditPageUserTask1.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("6a30ad5d-a4bf-409c-8735-5da0095ed23c", () => OpenEditPageUserTask1.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("342d5bb7-4ff5-4555-9665-2b3c43897b67", () => OpenEditPageUserTask1.ResultParameter);
			MetaPathParameterValues.Add("286e73d7-6301-47e6-8739-c59f7d4760b2", () => OpenEditPageUserTask1.IsReexecution);
			MetaPathParameterValues.Add("c58d8358-c7f4-484c-a1c0-f3e608d1972f", () => OpenEditPageUserTask1.Recommendation);
			MetaPathParameterValues.Add("4405b00e-b519-4ddc-8378-9592bbf0e5d3", () => OpenEditPageUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("383fb29e-8678-4563-a390-190db5adf28f", () => OpenEditPageUserTask1.OwnerId);
			MetaPathParameterValues.Add("b813f85f-84a0-4a57-9009-6cd7cc5af4c5", () => OpenEditPageUserTask1.Duration);
			MetaPathParameterValues.Add("34d7ce15-726b-4e95-aa21-563b9bc38d9b", () => OpenEditPageUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("8b7619b2-64d8-42c1-831c-1a7fc3b11da0", () => OpenEditPageUserTask1.StartIn);
			MetaPathParameterValues.Add("fc30c187-43ba-47e6-8d7e-cacbc496472a", () => OpenEditPageUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("649b1eb2-495a-4ae3-bcad-103fba8a0d6a", () => OpenEditPageUserTask1.RemindBefore);
			MetaPathParameterValues.Add("79a216ef-ce46-47c8-9b0b-d4db518424ef", () => OpenEditPageUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("276d8ef7-8993-4c85-954f-2db5bf99f77f", () => OpenEditPageUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("18d254bc-3c97-4da8-bab9-54447916f2db", () => OpenEditPageUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("8d716619-ddc5-4eb3-a0ba-980fb247ab90", () => OpenEditPageUserTask1.Lead);
			MetaPathParameterValues.Add("300b1b18-9d75-4004-a562-6cc390990974", () => OpenEditPageUserTask1.Account);
			MetaPathParameterValues.Add("b796671a-b989-468f-947e-174ce2d96220", () => OpenEditPageUserTask1.Contact);
			MetaPathParameterValues.Add("6a1a04b8-bd1f-482f-9c1e-62bcb731d696", () => OpenEditPageUserTask1.Opportunity);
			MetaPathParameterValues.Add("bf417665-89ab-42b8-87cc-f48a42e3f6e3", () => OpenEditPageUserTask1.Invoice);
			MetaPathParameterValues.Add("efd87117-69ee-4051-bcac-ff6b816178d1", () => OpenEditPageUserTask1.Document);
			MetaPathParameterValues.Add("7e1e88fe-f343-4fcc-a999-efbea006bab2", () => OpenEditPageUserTask1.Incident);
			MetaPathParameterValues.Add("5255bfdc-21e9-4df6-b2d7-5b4b576c6e9e", () => OpenEditPageUserTask1.Case);
			MetaPathParameterValues.Add("fd3d661a-af89-49db-88c9-e3ba80b5adf8", () => OpenEditPageUserTask1.ActivityResult);
			MetaPathParameterValues.Add("e6846fd9-dbd9-42a3-b4a1-d388f519657f", () => OpenEditPageUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("ff98d3c6-ee26-45c2-821d-70fec952223a", () => OpenEditPageUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("55af0d01-7bbb-4fc5-9d6a-7d867eb7485a", () => OpenEditPageUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("d1957622-4b21-4f73-894a-1e30db240580", () => OpenEditPageUserTask1.PageTypeUId);
			MetaPathParameterValues.Add("5f1659ee-f908-40b8-98a7-1c6cfdafa820", () => OpenEditPageUserTask1.ActivitySchemaUId);
			MetaPathParameterValues.Add("263e5b19-12b7-4ed2-8d85-f3fcdcc4de43", () => OpenEditPageUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("ec941755-453f-4ff2-b360-5b10123c1eca", () => OpenEditPageUserTask1.Order);
			MetaPathParameterValues.Add("49d88184-4dd0-4af0-aed4-5471b2e040e3", () => OpenEditPageUserTask1.Requests);
			MetaPathParameterValues.Add("854d33df-b538-4780-b650-3ba1e7128f0f", () => OpenEditPageUserTask1.Listing);
			MetaPathParameterValues.Add("aa2c6903-2f9b-452f-8564-b46be756ff24", () => OpenEditPageUserTask1.Property);
			MetaPathParameterValues.Add("9d61be59-c470-4d60-b223-6a2ae898d030", () => OpenEditPageUserTask1.Contract);
			MetaPathParameterValues.Add("a79878c7-843f-4c44-b52b-090d8e96344d", () => OpenEditPageUserTask1.Problem);
			MetaPathParameterValues.Add("a5f4be1a-5cce-4ae8-b725-313f9ef531fa", () => OpenEditPageUserTask1.Change);
			MetaPathParameterValues.Add("008316f9-efc0-427d-855d-f2bc3983e119", () => OpenEditPageUserTask1.Release);
			MetaPathParameterValues.Add("28185a19-88ee-4be5-83fa-18f00be27b35", () => OpenEditPageUserTask1.Project);
			MetaPathParameterValues.Add("d90405d0-8040-408f-8702-fa02c4358f2b", () => OpenEditPageUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("35e73697-3131-4eba-a5de-fbb6d9193677", () => OpenEditPageUserTask1.CreateActivity);
			MetaPathParameterValues.Add("242fc279-4701-420c-9817-ff9bf2bd25de", () => UserQuestionUserTask1.BranchingDecisions);
			MetaPathParameterValues.Add("c7ea1f8f-9bc8-4754-9565-95b1b7ed85fb", () => UserQuestionUserTask1.ResultDecisions);
			MetaPathParameterValues.Add("5865056c-667d-4196-bfb2-93ab9bb3f880", () => UserQuestionUserTask1.DecisionMode);
			MetaPathParameterValues.Add("a38de23c-3485-4d1b-9081-4257aeb1f0cb", () => UserQuestionUserTask1.IsDecisionRequired);
			MetaPathParameterValues.Add("54bd1525-bba9-4114-9d45-6885640ed63d", () => UserQuestionUserTask1.Question);
			MetaPathParameterValues.Add("4213a79c-4d3e-48cf-a5e7-c3cc235019aa", () => UserQuestionUserTask1.WindowCaption);
			MetaPathParameterValues.Add("3e0347d3-8a22-4ce7-8f04-2284ab9832bd", () => UserQuestionUserTask1.Recommendation);
			MetaPathParameterValues.Add("333e3f7d-361a-448d-8a84-1a9810c42f1a", () => UserQuestionUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("ac5a5fc3-8a97-4567-a69d-0a33f1640ec4", () => UserQuestionUserTask1.OwnerId);
			MetaPathParameterValues.Add("4514de81-e0b5-44cf-bbdb-e51b25152986", () => UserQuestionUserTask1.Duration);
			MetaPathParameterValues.Add("3fc44c2d-675b-4234-880c-1a871a813e53", () => UserQuestionUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("c7772497-e1fc-4c0d-9b89-c69494634c95", () => UserQuestionUserTask1.StartIn);
			MetaPathParameterValues.Add("7b8f9df2-b9a1-4bde-ac1b-14a761e98330", () => UserQuestionUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("135b7ef1-c96a-4226-912e-adfdfce0ae33", () => UserQuestionUserTask1.RemindBefore);
			MetaPathParameterValues.Add("8bb237fb-0984-4c96-8414-bd727e19f9df", () => UserQuestionUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("2c36964d-6861-41a5-a4d7-dd8e3f3d6524", () => UserQuestionUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("75dcb4b8-f9de-4f3c-82e6-683fc40fb5e7", () => UserQuestionUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("eed9b133-5bb5-4331-a2ed-e7e35848250f", () => UserQuestionUserTask1.Lead);
			MetaPathParameterValues.Add("1110c6e4-c088-4308-92bc-098e62be250d", () => UserQuestionUserTask1.Account);
			MetaPathParameterValues.Add("c680b79c-943f-49f3-bd29-db32dc87837d", () => UserQuestionUserTask1.Contact);
			MetaPathParameterValues.Add("6251ed82-c743-4bd7-b257-ea16931e0593", () => UserQuestionUserTask1.Opportunity);
			MetaPathParameterValues.Add("f970ffb4-b565-4912-b74e-9665b287e554", () => UserQuestionUserTask1.Invoice);
			MetaPathParameterValues.Add("05acd2b8-eb7f-4530-8f91-31ee541874b3", () => UserQuestionUserTask1.Document);
			MetaPathParameterValues.Add("c5964f8c-df11-409f-ab6a-b323471ce4ab", () => UserQuestionUserTask1.Incident);
			MetaPathParameterValues.Add("2609150c-3b90-4408-ac84-b29fa9fe8740", () => UserQuestionUserTask1.Case);
			MetaPathParameterValues.Add("c1487f5a-e5c3-4cd3-afc0-290965d651e5", () => UserQuestionUserTask1.ActivityResult);
			MetaPathParameterValues.Add("60e13508-4a0f-44eb-8ce7-2866e74a9146", () => UserQuestionUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("fc76a430-c50c-4fc2-b03d-fc5f7af678bb", () => UserQuestionUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("029e4048-a171-4af0-a135-ee0bc84027ce", () => UserQuestionUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("441b7b8b-820a-41ab-a54e-9c986ff06c68", () => UserQuestionUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("fffb72f7-73ff-43a0-901c-af061d200009", () => UserQuestionUserTask1.Order);
			MetaPathParameterValues.Add("ece8c629-15f7-4d70-bf2a-2f368584bcf7", () => UserQuestionUserTask1.Requests);
			MetaPathParameterValues.Add("df84dc0d-fbbd-4b8e-8d88-41e0896f035b", () => UserQuestionUserTask1.Listing);
			MetaPathParameterValues.Add("5a52a36c-a72a-41d0-b85d-87b4acb4ba89", () => UserQuestionUserTask1.Property);
			MetaPathParameterValues.Add("35cde648-05d5-445c-826b-ca9260c0d3c0", () => UserQuestionUserTask1.Contract);
			MetaPathParameterValues.Add("4892e8d7-6fc4-4c8c-9849-5b7ed1db0dcb", () => UserQuestionUserTask1.Project);
			MetaPathParameterValues.Add("3bfd9e82-741d-4a59-8eff-f6ff59f595d5", () => UserQuestionUserTask1.Problem);
			MetaPathParameterValues.Add("4e974ee6-3919-4099-8fdb-109651dec5d2", () => UserQuestionUserTask1.Change);
			MetaPathParameterValues.Add("38921604-2793-4ae7-ba81-6f8e05508efd", () => UserQuestionUserTask1.Release);
			MetaPathParameterValues.Add("0af07ffb-01d5-4387-adaf-dba180b5a289", () => UserQuestionUserTask1.CreateActivity);
			MetaPathParameterValues.Add("3c3fc15e-549b-482d-81be-18269f9b02ee", () => UserQuestionUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("bf89ef1c-af66-4671-bc99-ab29e04ef274", () => OpenEditPageUserTask2.ObjectSchemaId);
			MetaPathParameterValues.Add("e76aa928-2b7a-4c0e-9fe3-65b1b3dbdc96", () => OpenEditPageUserTask2.PageSchemaId);
			MetaPathParameterValues.Add("e585f4f1-f6d9-4588-8568-f275845f7776", () => OpenEditPageUserTask2.EditMode);
			MetaPathParameterValues.Add("84fa8cac-0acd-4cb9-a5da-f0e657b00351", () => OpenEditPageUserTask2.RecordColumnValues);
			MetaPathParameterValues.Add("08b08ada-67d4-436f-8fb7-c269cf2d3f6f", () => OpenEditPageUserTask2.RecordId);
			MetaPathParameterValues.Add("65c15211-5b35-4c47-a593-0e148fe507cf", () => OpenEditPageUserTask2.ExecutedMode);
			MetaPathParameterValues.Add("b3e431b0-b262-4888-947b-0742cdccb7e9", () => OpenEditPageUserTask2.IsMatchConditions);
			MetaPathParameterValues.Add("b0943620-be2b-4434-aa33-05e9908d30de", () => OpenEditPageUserTask2.DataSourceFilters);
			MetaPathParameterValues.Add("a50f8137-b46a-4c9c-aca3-f67b5af037c1", () => OpenEditPageUserTask2.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("e310cc54-11ad-4846-a59e-f1cedc6fa29f", () => OpenEditPageUserTask2.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("ab2a5b55-b25c-4e8f-89b1-08ebf2b242f9", () => OpenEditPageUserTask2.ResultParameter);
			MetaPathParameterValues.Add("ab06fa1a-baaa-4208-95e8-4e113e3a161a", () => OpenEditPageUserTask2.IsReexecution);
			MetaPathParameterValues.Add("d0bcc08a-0e38-4ac0-864f-30caa50830a0", () => OpenEditPageUserTask2.Recommendation);
			MetaPathParameterValues.Add("079279b5-8793-49d7-b217-3a115881d4ec", () => OpenEditPageUserTask2.ActivityCategory);
			MetaPathParameterValues.Add("aa2c680f-8193-4e90-b895-1cc7d0804f81", () => OpenEditPageUserTask2.OwnerId);
			MetaPathParameterValues.Add("a1fed64c-6b91-4eeb-a70d-f84c03cdf787", () => OpenEditPageUserTask2.Duration);
			MetaPathParameterValues.Add("9b99cf94-32a9-4da1-9f9e-85f517aa6cfd", () => OpenEditPageUserTask2.DurationPeriod);
			MetaPathParameterValues.Add("44dd0c12-d4fc-4409-b49e-f717ab223493", () => OpenEditPageUserTask2.StartIn);
			MetaPathParameterValues.Add("dd1f16ab-1cf5-48eb-9789-6b561b131c1e", () => OpenEditPageUserTask2.StartInPeriod);
			MetaPathParameterValues.Add("4278771d-9cc8-4d1e-be2a-65bfd3c08ac6", () => OpenEditPageUserTask2.RemindBefore);
			MetaPathParameterValues.Add("58b7077c-5122-4489-9e7e-e3a4dd0faa2b", () => OpenEditPageUserTask2.RemindBeforePeriod);
			MetaPathParameterValues.Add("6a937388-e8cc-4c10-870e-32fd5f54c9a6", () => OpenEditPageUserTask2.ShowInScheduler);
			MetaPathParameterValues.Add("65d213a2-2237-4862-97e1-e566882ed229", () => OpenEditPageUserTask2.ShowExecutionPage);
			MetaPathParameterValues.Add("4fbbbfff-cd22-424f-a95f-a15192ebc70f", () => OpenEditPageUserTask2.Lead);
			MetaPathParameterValues.Add("124d5cd0-bc07-4c65-bf96-a1fe056e0eff", () => OpenEditPageUserTask2.Account);
			MetaPathParameterValues.Add("cfceb661-b87a-4686-bf85-226e99854373", () => OpenEditPageUserTask2.Contact);
			MetaPathParameterValues.Add("339b8c23-a004-4c2a-8ea6-48a9cd04fccf", () => OpenEditPageUserTask2.Opportunity);
			MetaPathParameterValues.Add("5d1d78e1-1e1f-40d9-8cf4-bfd91259bb4c", () => OpenEditPageUserTask2.Invoice);
			MetaPathParameterValues.Add("3e38360c-29d8-462c-a3c8-15c917a704ff", () => OpenEditPageUserTask2.Document);
			MetaPathParameterValues.Add("98823996-3da5-404e-87b0-005b701c8c00", () => OpenEditPageUserTask2.Incident);
			MetaPathParameterValues.Add("9df09cc8-b941-4469-ac9d-9c2d614b96bc", () => OpenEditPageUserTask2.Case);
			MetaPathParameterValues.Add("c547483b-e0b7-4219-a57e-acca9ea6eeac", () => OpenEditPageUserTask2.ActivityResult);
			MetaPathParameterValues.Add("c40d5e8f-a839-491b-9ca8-297d12952755", () => OpenEditPageUserTask2.CurrentActivityId);
			MetaPathParameterValues.Add("20172dfd-6fa1-4be4-b1f3-2a4404d59444", () => OpenEditPageUserTask2.IsActivityCompleted);
			MetaPathParameterValues.Add("e4b9bcec-0e11-4a0d-b3e9-303c8673d170", () => OpenEditPageUserTask2.ExecutionContext);
			MetaPathParameterValues.Add("e068a907-4ecb-451e-85fe-659a40b7e971", () => OpenEditPageUserTask2.PageTypeUId);
			MetaPathParameterValues.Add("75e31b52-aadd-47e2-a13e-9e958e88e0f2", () => OpenEditPageUserTask2.ActivitySchemaUId);
			MetaPathParameterValues.Add("4f1a0a7b-84a0-4889-a0dc-82651658d577", () => OpenEditPageUserTask2.InformationOnStep);
			MetaPathParameterValues.Add("65ea4a95-d580-4fab-bc9a-bd2dead86bbf", () => OpenEditPageUserTask2.Order);
			MetaPathParameterValues.Add("cd039377-af7f-4bff-912d-d1d10f532547", () => OpenEditPageUserTask2.Requests);
			MetaPathParameterValues.Add("58b787ce-206d-41bd-bc0f-0819e08fbc07", () => OpenEditPageUserTask2.Listing);
			MetaPathParameterValues.Add("63fa99c0-05ba-4811-8a2e-2df466264008", () => OpenEditPageUserTask2.Property);
			MetaPathParameterValues.Add("759206d2-03de-43f9-9ff5-7be41b1e19cd", () => OpenEditPageUserTask2.Contract);
			MetaPathParameterValues.Add("6aef599c-841b-4c28-871b-cc7def0d0d10", () => OpenEditPageUserTask2.Problem);
			MetaPathParameterValues.Add("b7a6ab9a-067b-45bf-846a-c2b2683f7f7c", () => OpenEditPageUserTask2.Change);
			MetaPathParameterValues.Add("654c811c-8d84-4c85-8879-6f2252212386", () => OpenEditPageUserTask2.Release);
			MetaPathParameterValues.Add("6a71e918-e32c-49c8-adc8-825211514808", () => OpenEditPageUserTask2.Project);
			MetaPathParameterValues.Add("7e17bf4d-ed30-4ec6-bb86-2d716438be4c", () => OpenEditPageUserTask2.ActivityPriority);
			MetaPathParameterValues.Add("6b10b87f-d69c-46ba-941d-1006da8651f2", () => OpenEditPageUserTask2.CreateActivity);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
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
				case "IsNewContact":
					if (!hasValueToRead) break;
					IsNewContact = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

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
			var cloneItem = (TakeOrderByCall)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

