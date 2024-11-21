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

	#region Class: ContractVisaProcessSchema

	/// <exclude/>
	public class ContractVisaProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContractVisaProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContractVisaProcessSchema(ContractVisaProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContractVisaProcess";
			UId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d");
			CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0");
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
			Tag = @"Visa Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d");
			Version = 0;
			PackageUId = new Guid("29c7b5a2-1b24-4486-9276-6f30e0b427b5");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateEmailBodyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("74993b60-74e2-40cb-9814-23ff874d9202"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"EmailBody",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailSubjectParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3cb8a4b7-f45b-44ff-b96d-91b115085a87"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"EmailSubject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRecordIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7b7f0b9b-4163-46fa-9880-794c80c407c4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateEmailBodyParameter());
			Parameters.Add(CreateEmailSubjectParameter());
			Parameters.Add(CreateRecordIdParameter());
		}

		protected virtual void InitializeContractVisaSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var contractParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("310fad23-c110-4806-9d92-9b7ef68030a8"),
				ContainerUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{7b7f0b9b-4163-46fa-9880-794c80c407c4}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var visaOwnerParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				UId = new Guid("cf070ad1-6809-4a88-9acd-4c1050d73518"),
				ContainerUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			visaOwnerParameter.SourceValue = new ProcessSchemaParameterValue(visaOwnerParameter) {
				Source = ProcessSchemaParameterValueSource.Mapping,
				Value = @"836ca04a-78fa-4cf4-a449-453ee4c8b6cd.e0dd21fb-3d51-44e8-b854-0e07c860de49",
				MetaPath = @"836ca04a-78fa-4cf4-a449-453ee4c8b6cd.e0dd21fb-3d51-44e8-b854-0e07c860de49",
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(visaOwnerParameter);
			var visaObjectiveParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("68991ea2-632d-4c0d-bcc0-b0279a32a9da"),
				ContainerUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaObjective",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			visaObjectiveParameter.SourceValue = new ProcessSchemaParameterValue(visaObjectiveParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{836ca04a-78fa-4cf4-a449-453ee4c8b6cd}].[Parameter:{4e06d591-5e64-4ada-8d8c-ecc485ed6411}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(visaObjectiveParameter);
			var visaResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("194a72ce-4566-4d00-b100-8623165e187a"),
				ContainerUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"VisaResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText")
			};
			visaResultParameter.SourceValue = new ProcessSchemaParameterValue(visaResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53")
			};
			parametrizedElement.Parameters.Add(visaResultParameter);
			var isAllowedToDelegateParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("37892265-46bb-4ffe-aa15-ea2ccaae20b6"),
				ContainerUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"IsAllowedToDelegate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isAllowedToDelegateParameter.SourceValue = new ProcessSchemaParameterValue(isAllowedToDelegateParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{836ca04a-78fa-4cf4-a449-453ee4c8b6cd}].[Parameter:{e4157d41-c7c0-423c-90ea-9b31a9527bea}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(isAllowedToDelegateParameter);
			var isPreviousVisaCountsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8717320f-9266-4d6e-959e-f602a2bff5fd"),
				ContainerUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				Name = @"IsPreviousVisaCounts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isPreviousVisaCountsParameter.SourceValue = new ProcessSchemaParameterValue(isPreviousVisaCountsParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(isPreviousVisaCountsParameter);
		}

		protected virtual void InitializeInputVisaParametersParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var titleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15e74ec5-0326-4f08-8eff-34dd48372d46"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				Value = @"Добавить визу",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(titleParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("03bf1a8c-ab55-4047-aa71-9f75cf806d53"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95ea8e28-dccf-4a6e-bb68-8cf426150c7d"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var entityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("af3a440c-346a-45ea-b989-ad9edad884e9"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var buttonsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("64a3cca3-4c10-4274-aef0-5a1ef5d6712f"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				Value = @"{""$type"":""System.Collections.Generic.List`1[[System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib]], mscorlib"",""$values"":[{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""f3e3b4f4-4c3e-4efd-b334-bd6521c4fef7"",""name"":""ButtonOk"",""caption"":""Сохранить"",""style"":""green"",""performValidation"":true,""isEnabled"":true,""generateSignal"":""""},{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""95405807-f709-427d-bfe6-4207ccf780e3"",""name"":""ButtonCancel"",""caption"":""Отмена"",""style"":""default"",""performValidation"":false,""isEnabled"":true,""generateSignal"":""""}]}",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(buttonsParameter);
			var elementsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("67d2763d-f0c5-4de5-be15-11bb62ecf373"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				Value = @"{""$type"":""System.Collections.Generic.List`1[[System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib]], mscorlib"",""$values"":[{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""e0dd21fb-3d51-44e8-b854-0e07c860de49"",""name"":""VisaOwner"",""caption"":""Визирующий"",""controlEditType"":""SelectionField"",""isRequired"":true,""dataFilter"":"""",""controlDataValueType"":""10"",""dataSource"":""84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c""},{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""4e06d591-5e64-4ada-8d8c-ecc485ed6411"",""name"":""Objective"",""caption"":""Цель визы"",""controlEditType"":""1"",""isMultiline"":true,""isRequired"":false},{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""e4157d41-c7c0-423c-90ea-9b31a9527bea"",""name"":""IsAllowedToDelegate"",""caption"":""Разрешено делегирование"",""controlEditType"":""12""}]}",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(elementsParameter);
			var extendedClientModuleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05607c13-cca8-4ff4-9db7-ca1b00e9d924"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(extendedClientModuleParameter);
			var entryPointIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c1c4abc-e8a6-48a5-bc00-7f05f8db1732"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("d649bbc1-42b3-4dd3-b3f4-288751672e90"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("c36b3fbb-0cda-4054-9d6c-3f2764a2a299"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("725b0f21-bc47-4763-ac11-51f3e58ac1f6"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("49aa3b10-f4df-4db4-a710-7a3da112ae79"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(informationOnStepParameter);
			var isRunningParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a7674ac1-de80-4564-9a13-246fabb59722"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("df0a245a-f0d7-4b8d-be94-cbc9d3aa90f0"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("f0156928-27af-484e-9190-33b0a62a7a73"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("3ae7281e-db88-4abd-a773-5915956a6a36"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("cf8e13af-b73a-4d7e-9b81-4ac252fefc28"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("6bcd0bd5-95cb-4826-b8e0-e1efa8d5f968"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("e55250fe-8ea0-4354-baa1-9afc5d482f7a"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("48a1e8f5-a3e8-477c-a0a3-cc06380aa67c"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("ea87ad9d-1475-432f-b39b-c4c364ecf076"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("0c423b76-8605-4a06-b983-b75aa4392751"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("6a18d149-3924-4e6e-838a-0202591eb947"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("cbe0a2d5-d094-46cc-a276-48fb00d1f63a"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
				UId = new Guid("7e17c9b2-141c-470e-9741-0403708a75f3"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
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
			var visaOwnerParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				UId = new Guid("e0dd21fb-3d51-44e8-b854-0e07c860de49"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"VisaOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			visaOwnerParameter.SourceValue = new ProcessSchemaParameterValue(visaOwnerParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(visaOwnerParameter);
			var objectiveParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e06d591-5e64-4ada-8d8c-ecc485ed6411"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"Objective",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			objectiveParameter.SourceValue = new ProcessSchemaParameterValue(objectiveParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(objectiveParameter);
			var isAllowedToDelegateParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4157d41-c7c0-423c-90ea-9b31a9527bea"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"IsAllowedToDelegate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isAllowedToDelegateParameter.SourceValue = new ProcessSchemaParameterValue(isAllowedToDelegateParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(isAllowedToDelegateParameter);
		}

		protected virtual void InitializeForbitContractChangeParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6410dd64-cb18-4b43-92d8-ea4e92452489"),
				ContainerUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"897be3e4-0333-467d-88e2-b7a945c0d810",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5aca796c-35c6-418a-9deb-b088a8f677dc"),
				ContainerUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,217,210,90,146,123,92,182,101,47,105,104,211,82,72,150,48,150,198,89,129,191,98,201,52,193,236,127,175,188,206,166,144,67,41,189,21,116,152,25,233,189,121,243,24,205,247,62,124,244,77,196,177,172,161,9,72,167,189,43,9,86,160,81,129,102,96,56,103,18,100,206,64,11,203,16,220,38,203,242,76,41,173,9,237,160,197,146,172,232,157,243,145,80,31,177,13,229,237,252,155,52,142,19,210,251,250,156,124,181,71,108,225,219,210,64,27,85,161,64,201,184,16,130,201,66,57,166,53,230,172,82,96,228,198,114,167,51,78,86,45,133,179,66,10,44,152,144,117,197,164,114,46,189,66,199,76,198,193,22,149,209,149,0,66,27,172,227,238,105,24,49,4,223,119,229,140,175,241,205,243,144,84,174,189,183,125,51,181,29,161,45,70,184,134,120,44,9,32,199,212,16,152,149,102,195,100,141,138,129,48,142,9,168,84,174,52,102,69,166,8,181,48,196,133,150,236,29,161,14,34,124,135,102,194,51,243,236,147,198,92,240,76,111,138,132,205,146,75,82,228,156,233,66,43,86,187,162,54,40,10,99,42,119,241,235,211,228,83,236,195,213,212,226,232,237,139,237,152,252,235,199,114,182,125,23,199,190,89,168,175,206,207,111,240,41,174,230,190,92,253,88,7,138,169,190,128,200,137,78,1,183,141,199,46,238,58,219,59,223,61,172,156,167,83,130,180,3,140,62,92,92,216,61,78,208,16,58,250,135,227,31,221,218,78,33,246,237,127,52,42,77,99,38,142,136,227,89,238,178,131,206,135,161,129,231,115,94,146,119,143,83,31,63,124,65,219,143,110,239,214,140,188,65,149,228,142,168,74,213,188,50,105,209,178,98,89,204,26,152,209,154,51,101,164,213,220,74,174,172,188,35,73,201,63,242,223,238,195,231,159,221,229,47,172,234,15,239,83,245,77,225,250,130,44,231,191,145,116,58,44,162,14,167,116,126,1,34,246,238,123,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("24dfe4df-9bb5-49a4-95db-61542b4948d1"),
				ContainerUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,174,246,76,177,82,50,75,53,74,75,182,52,76,214,53,48,76,76,212,53,73,54,183,212,77,52,74,178,212,53,79,50,72,53,180,176,52,75,50,74,51,85,210,113,78,204,11,74,77,76,177,74,75,204,41,78,5,241,92,83,50,75,172,74,138,74,193,28,151,212,156,212,146,84,8,55,56,191,180,40,57,213,74,201,80,73,199,189,40,49,175,36,21,200,118,204,201,9,202,207,73,45,118,204,75,9,45,78,45,42,86,210,241,75,204,5,138,95,152,116,177,241,194,86,133,139,13,23,246,93,216,125,97,135,2,8,237,7,177,47,246,92,216,14,164,55,93,216,112,177,233,194,86,144,156,82,109,44,0,254,190,72,33,176,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("00434e0c-82ed-4624-aecf-e0253c869124"),
				ContainerUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6339a993-b155-4f8e-8ab1-188aa3fbcd7d"),
				ContainerUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeReadContractParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb5c0633-71b5-4885-bf63-9348c6e716fe"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,75,107,220,48,16,254,47,58,244,36,21,217,178,45,201,61,46,219,178,151,52,180,105,41,36,75,208,99,148,21,248,21,75,166,9,102,255,123,101,59,155,66,14,165,244,86,240,65,51,154,239,49,31,242,124,239,195,71,223,68,24,107,167,154,0,120,58,216,26,73,231,74,167,157,35,185,227,134,20,149,208,68,107,227,136,226,165,40,157,115,149,85,20,225,78,181,80,163,13,189,183,62,34,236,35,180,161,190,157,127,147,198,113,2,124,239,214,226,171,57,65,171,190,45,2,66,114,13,12,10,66,25,99,73,128,91,34,4,228,68,115,37,139,210,80,43,178,36,176,122,113,18,114,86,177,138,40,154,231,105,52,75,83,165,202,72,69,105,78,165,134,188,224,12,225,6,92,220,63,13,35,132,224,251,174,158,225,245,124,243,60,36,151,155,246,174,111,166,182,67,184,133,168,174,85,60,213,72,1,133,36,168,136,41,100,73,10,7,156,40,38,45,97,74,243,156,11,200,170,140,35,108,212,16,23,90,116,176,8,91,21,213,119,213,76,176,50,207,62,121,204,25,205,68,89,37,108,198,82,94,44,167,68,84,130,19,103,171,100,159,85,82,106,123,201,235,211,228,211,217,135,171,169,133,209,155,151,216,33,229,215,143,245,108,250,46,142,125,179,80,95,173,227,55,240,20,183,112,95,174,126,108,11,197,212,95,64,232,140,167,0,187,198,67,23,247,157,233,173,239,30,54,206,243,57,65,218,65,141,62,92,82,216,63,78,170,65,120,244,15,167,63,166,181,155,66,236,219,255,104,85,156,214,76,28,17,198,213,238,242,6,173,15,67,163,158,215,186,70,239,30,167,62,126,248,2,166,31,237,193,110,21,122,131,170,209,29,226,154,59,170,165,38,69,86,45,15,211,41,34,133,160,132,203,194,8,106,10,202,77,113,135,146,147,127,228,191,61,132,207,63,187,203,191,176,185,63,190,79,221,55,141,235,11,178,158,255,198,210,249,184,152,58,158,211,247,11,134,94,66,213,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("df762cbe-8d50-45aa-a692-fc3ca13753f4"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e9f1193-9fc1-4b4b-8432-b733eba80912"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9d143566-7ff6-4ddc-91a8-d591f09cd961"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e5201aee-681b-4744-8a31-9ddd18e21086"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("11075dd3-15ea-48cc-bc90-e0d56c7659c3"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9cc48116-aeb9-466b-8bfc-4e956a8a224a"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,212,241,76,177,50,176,50,0,0,237,33,101,51,17,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("7357770f-8b54-46b0-8ac6-9419f1e3851d"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8a5724d5-1ff6-487b-9fc6-200c9ad0f055"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ba20003a-340e-46d9-a946-c7b838095ecf"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("449de235-c6b7-424f-85d8-fb162b49bb7b"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ba4dd278-a683-4a23-bb70-76dbea3a6008"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("88ad9c3b-a5af-4854-a28b-1335fb70031e"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("e8e6e487-50e1-4bf3-8f69-9a817f3ab435"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("221e16c4-8293-45d9-8259-d695e5af79eb"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("43a99aa6-4673-4153-a178-a5b9790d2ad5"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("32c0ad0e-56cf-4c87-b1ac-2dd4e4bf0c7c"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("6c530e54-ccb1-4789-8368-bd42cd35d0f7"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f5fa984a-06a8-418c-8f7e-523441758aaf"),
				ContainerUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeSendEmailToOwnerParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var senderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				UId = new Guid("e23b91be-231f-435f-8517-737db19c220d"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"Sender",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			senderParameter.SourceValue = new ProcessSchemaParameterValue(senderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(senderParameter);
			var recepientParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eafc53b1-5965-4420-91e0-d855598a9606"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"Recepient",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			recepientParameter.SourceValue = new ProcessSchemaParameterValue(recepientParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{bff63975-7641-445b-a526-7e12cd421a7e}].[Parameter:{31f0b17f-eb70-4992-b1b1-bca006ff0170}].[EntityColumn:{dbf202ec-c444-479b-bcf4-d8e5b1863201}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(recepientParameter);
			var copyRecepientParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5267c7f6-bd77-4ed7-824c-b431dbd24c08"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"CopyRecepient",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			copyRecepientParameter.SourceValue = new ProcessSchemaParameterValue(copyRecepientParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(copyRecepientParameter);
			var blindCopyRecepientParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe9744a9-7550-407f-802d-aa723487447d"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"BlindCopyRecepient",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			blindCopyRecepientParameter.SourceValue = new ProcessSchemaParameterValue(blindCopyRecepientParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(blindCopyRecepientParameter);
			var subjectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d722c459-1025-4d56-86cc-230572deb759"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"Subject",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			subjectParameter.SourceValue = new ProcessSchemaParameterValue(subjectParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{3cb8a4b7-f45b-44ff-b96d-91b115085a87}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(subjectParameter);
			var bodyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("62b9d136-3ff8-48ad-91e5-9dc61486aef5"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"Body",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			bodyParameter.SourceValue = new ProcessSchemaParameterValue(bodyParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{74993b60-74e2-40cb-9814-23ff874d9202}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(bodyParameter);
			var importanceParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0ededcb2-d1f2-4ed5-8714-1a853d7276ec"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"Importance",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			importanceParameter.SourceValue = new ProcessSchemaParameterValue(importanceParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(importanceParameter);
			var isIgnoreErrorsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ed7f847d-ac6b-4f96-880b-b96226ea317b"),
				ContainerUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				Name = @"IsIgnoreErrors",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isIgnoreErrorsParameter.SourceValue = new ProcessSchemaParameterValue(isIgnoreErrorsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(isIgnoreErrorsParameter);
		}

		protected virtual void InitializeReadOwnerParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8584ab53-ba83-4f42-a7bc-feab37d28011"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,205,106,220,48,16,126,149,69,135,158,172,197,242,159,100,247,24,182,37,151,52,208,180,20,146,16,100,75,74,12,254,217,216,50,77,48,11,233,6,10,165,105,31,161,61,246,90,210,134,110,146,38,207,32,191,81,199,235,108,11,57,148,92,3,22,140,70,250,190,153,249,60,163,118,47,173,159,165,153,150,85,164,120,86,75,171,89,23,17,98,76,49,201,66,27,179,152,196,216,11,236,16,172,208,193,142,205,98,106,11,26,216,158,66,86,193,115,25,161,1,61,17,169,70,86,170,101,94,71,219,237,63,82,93,53,210,218,83,203,205,203,228,64,230,252,85,31,128,4,177,116,3,159,96,166,164,131,61,226,67,0,33,108,204,153,237,10,47,96,174,16,46,26,114,113,164,36,190,205,28,76,101,24,98,79,73,137,67,66,66,156,56,97,236,197,30,117,84,16,35,43,147,74,79,142,166,149,172,235,180,44,162,86,254,181,183,142,167,144,229,16,123,173,204,154,188,64,86,46,53,223,228,250,32,66,92,218,210,243,19,142,19,47,244,123,118,138,185,27,10,236,242,152,58,148,73,18,16,138,172,132,79,117,79,139,214,5,178,4,215,252,53,207,26,185,100,110,211,62,71,215,38,204,15,0,75,220,4,123,174,3,202,5,140,98,37,2,21,66,161,97,24,139,149,94,207,155,20,236,180,222,104,114,89,165,201,157,236,18,244,43,171,168,77,202,66,87,101,214,83,111,44,175,111,201,35,61,136,123,119,244,102,40,72,131,191,7,161,153,213,212,114,45,75,101,161,39,69,82,138,180,216,31,56,103,51,128,228,83,94,165,245,74,133,201,97,195,51,100,85,233,254,193,127,213,90,107,106,93,230,143,168,84,11,202,4,14,104,178,101,186,125,15,138,180,158,102,252,120,185,143,208,147,195,166,212,79,205,55,179,232,230,230,123,55,239,206,70,230,167,185,53,63,96,157,155,219,238,100,108,190,154,139,238,196,156,119,31,205,229,168,251,100,174,205,133,249,13,235,166,155,143,192,127,97,126,117,167,230,186,59,3,252,162,59,233,78,187,207,221,7,240,94,142,204,21,112,92,47,239,95,117,239,205,194,44,198,230,11,220,58,7,190,121,247,110,176,204,13,16,1,243,144,7,186,151,111,132,118,16,103,212,78,72,34,113,172,184,141,61,193,226,126,230,8,86,129,79,125,91,198,9,231,116,76,93,159,82,106,43,56,242,61,24,204,24,212,231,73,128,67,143,132,138,72,151,249,68,140,97,58,124,146,176,16,59,14,83,48,92,148,97,238,11,133,3,98,123,125,87,115,69,220,29,4,106,62,58,141,182,215,235,23,111,139,213,75,50,252,251,221,49,120,239,57,38,153,204,161,73,162,246,33,162,206,0,176,185,10,21,181,15,145,184,135,76,10,157,234,227,225,69,137,218,135,104,62,219,237,85,223,157,193,247,7,64,79,166,179,119,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c376d60e-a7a4-4e19-bd8a-dae2932a0e78"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9f2bb0a7-bb26-44d6-982d-bae251821d05"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8891e889-db66-4762-9171-8140dd7cf232"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5d406829-cb2c-4bc8-aee9-9b1c2127c6fd"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb921596-274f-4b21-8c44-b212fc1920ca"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("f1ff7012-8664-41bf-9c72-c0b8ed663964"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("31f0b17f-eb70-4992-b1b1-bca006ff0170"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aa386400-da48-4c38-ad31-fc6fc0b48215"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d69de283-3768-4fed-88cf-ba8a30d46115"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d49960ad-0a29-4f36-993a-f6d4071447e8"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2170fceb-72f6-4c84-8877-fe0d9df8d2db"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("2af17b6f-5672-4495-9124-0e90d072d034"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("ac4a8ce3-7747-409c-9280-55e75a467639"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("9d748d72-4039-430d-9516-9bf95155fd9b"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c3c00126-734d-41e9-bf79-8da33bbe8ad7"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("37fda484-0125-46f8-b450-58f5d24b2f0e"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("a35c56a5-1a56-42fd-bf45-ed9e38384a08"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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
				UId = new Guid("d1a6d76b-535b-4923-b30a-20554b325523"),
				ContainerUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
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

		protected virtual void InitializeGiveRightsToOwnerParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("db5af251-bee8-4545-8937-e1aa966c98be"),
				ContainerUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"897be3e4-0333-467d-88e2-b7a945c0d810",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cd06c729-8a50-4f14-a085-8c9bf142de19"),
				ContainerUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,27,49,16,253,47,58,244,36,21,201,146,245,177,61,26,183,248,146,134,54,45,133,196,4,125,204,198,130,253,112,86,90,154,176,248,191,87,235,141,83,200,161,148,222,10,58,204,140,244,222,188,121,140,166,251,152,62,198,38,195,80,213,182,73,128,199,93,168,208,218,57,45,193,10,18,184,51,68,48,182,38,58,56,75,140,98,178,102,160,13,247,18,225,206,182,80,161,5,189,13,49,35,28,51,180,169,186,157,126,147,230,97,4,124,95,159,147,175,254,0,173,253,54,55,208,70,57,224,32,8,229,156,19,33,85,32,90,195,138,56,101,141,88,123,26,52,163,104,209,34,197,202,59,78,57,209,138,49,34,132,119,196,50,33,8,55,192,29,85,134,130,99,8,55,80,231,237,211,113,128,148,98,223,85,19,188,198,55,207,199,162,114,233,189,233,155,177,237,16,110,33,219,107,155,15,21,178,64,161,52,180,196,11,179,38,162,6,69,44,55,129,112,235,212,74,105,96,146,41,132,189,61,230,153,22,237,2,194,193,102,251,221,54,35,156,153,167,88,52,174,56,101,122,45,11,150,113,79,4,95,81,162,165,86,164,14,178,46,50,165,49,46,92,252,250,52,198,18,199,116,53,182,48,68,255,98,59,20,255,250,161,154,124,223,229,161,111,102,234,171,243,243,27,120,202,139,185,47,87,63,150,129,114,169,207,32,116,194,99,130,77,19,161,203,219,206,247,33,118,15,11,231,233,84,32,237,209,14,49,93,92,216,62,142,182,65,120,136,15,135,63,186,181,25,83,238,219,255,104,84,92,198,44,28,25,134,179,220,121,7,67,76,199,198,62,159,243,10,189,123,28,251,252,225,11,248,126,8,187,176,100,232,13,170,66,119,72,57,85,83,103,92,89,122,57,47,102,93,150,94,107,74,148,17,94,83,47,168,242,226,14,21,37,255,200,127,187,75,159,127,118,151,191,176,168,223,191,47,213,55,133,235,11,178,154,254,70,210,105,63,139,218,159,202,249,5,66,7,222,161,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe09c0ea-c751-454d-9193-e03efc91f334"),
				ContainerUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3ce1b749-d0db-40c4-b82f-c8972441ef28"),
				ContainerUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,81,203,106,27,65,16,252,21,177,190,106,196,206,190,102,118,175,182,48,6,19,5,11,114,17,58,204,206,246,196,130,221,149,89,141,18,140,16,40,18,4,66,156,124,66,124,244,53,40,22,150,173,216,223,208,243,71,110,217,224,131,15,13,93,69,85,209,143,193,236,164,200,60,30,106,145,75,174,25,143,117,196,34,14,62,147,34,40,88,30,154,36,244,33,149,1,8,175,125,168,234,51,80,69,102,155,41,236,65,183,24,217,55,112,4,37,88,120,133,253,241,180,209,144,121,161,215,62,110,84,109,129,250,110,117,81,142,47,1,188,246,7,85,17,30,28,224,13,110,221,18,255,186,165,187,106,225,45,62,225,63,170,53,62,185,69,7,175,113,227,22,184,118,63,241,190,229,126,225,14,55,248,159,234,209,45,91,196,111,240,206,173,112,231,174,200,191,117,11,183,114,191,221,15,98,239,91,248,64,25,187,23,253,131,251,142,91,220,118,240,15,169,214,148,183,116,223,94,59,124,164,32,74,62,24,122,237,79,170,156,190,140,51,56,153,244,190,214,208,244,245,57,84,42,51,170,156,192,176,67,236,59,162,91,66,5,181,205,102,74,10,95,115,13,44,55,202,103,81,33,115,38,243,148,51,147,196,34,246,33,215,74,137,57,25,62,170,134,54,182,208,100,51,17,198,66,8,223,144,48,166,59,39,57,221,89,233,132,165,17,79,13,135,80,198,188,216,91,186,181,29,217,203,195,113,57,173,234,108,198,121,26,115,45,83,22,4,210,208,119,132,100,42,46,12,75,184,31,229,34,16,202,240,112,62,220,47,211,187,128,70,217,209,184,62,27,125,62,183,167,240,5,202,204,11,188,249,240,25,100,118,52,229,231,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5512dee7-aaf8-4f35-a70e-4df063f5d58e"),
				ContainerUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
			var employee1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("13c7b81c-15c4-41e0-872d-b3f630e982e7"),
				ContainerUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"Employee1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			employee1Parameter.SourceValue = new ProcessSchemaParameterValue(employee1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7}].[Parameter:{7357770f-8b54-46b0-8ac6-9419f1e3851d}].[EntityColumn:{11951c89-228f-4178-a5df-6104b727af13}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(employee1Parameter);
		}

		protected virtual void InitializeGiveRightsToVisaOwnerParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("db86a347-29e9-4743-9766-c6a508976d06"),
				ContainerUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"897be3e4-0333-467d-88e2-b7a945c0d810",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e9392949-f8f5-4add-bc89-a191956f1182"),
				ContainerUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,228,41,178,37,91,146,123,92,182,101,47,105,104,211,82,72,150,32,75,163,172,192,31,27,75,166,9,102,255,123,229,117,54,133,28,74,233,173,224,131,102,164,247,230,189,199,120,190,247,225,163,111,35,142,181,211,109,192,108,218,217,154,232,178,98,204,21,10,88,225,20,240,162,228,160,80,150,192,132,229,121,37,115,219,40,75,178,94,119,88,147,21,189,181,62,146,204,71,236,66,125,59,255,38,141,227,132,217,189,59,23,95,205,1,59,253,109,25,32,149,104,144,33,7,202,24,3,94,9,11,82,98,1,141,208,138,151,134,90,153,83,178,106,161,40,68,78,45,3,227,140,6,206,114,9,90,73,6,84,86,92,162,44,202,194,48,146,181,232,226,246,233,56,98,8,126,232,235,25,95,207,55,207,199,164,114,157,189,25,218,169,235,73,214,97,212,215,58,30,146,83,164,152,6,106,48,92,149,192,29,10,208,76,89,96,186,17,133,144,152,87,185,32,153,209,199,184,208,146,93,178,109,117,212,223,117,59,225,153,121,246,73,99,193,104,46,203,42,97,115,102,146,198,130,130,172,164,0,103,43,167,144,85,74,53,175,121,125,154,124,58,251,112,53,117,56,122,243,18,59,166,252,134,177,158,205,208,199,113,104,23,234,171,243,243,27,124,138,107,184,47,87,63,86,67,49,245,23,16,57,101,83,192,77,235,177,143,219,222,12,214,247,15,43,231,233,148,32,221,81,143,62,92,82,216,62,78,186,37,217,232,31,14,127,76,107,51,133,56,116,255,145,213,44,217,76,28,17,199,179,220,101,7,173,15,199,86,63,159,235,154,188,123,156,134,248,225,11,154,97,180,59,187,86,228,13,170,38,119,68,52,194,209,70,53,144,246,124,89,76,167,65,73,73,65,40,110,36,53,156,10,195,239,72,82,242,143,252,183,187,240,249,103,127,249,23,86,245,251,247,169,251,166,113,125,65,214,243,223,72,58,237,23,81,251,83,250,126,1,13,212,162,39,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c7fca4c4-fb67-44e2-b05f-2c3a3b6e3769"),
				ContainerUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"DeleteRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			deleteRightsParameter.SourceValue = new ProcessSchemaParameterValue(deleteRightsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,142,5,0,41,187,76,13,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aeae1d71-a282-4e9b-aa64-781333770500"),
				ContainerUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Name = @"AddRights",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			addRightsParameter.SourceValue = new ProcessSchemaParameterValue(addRightsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,142,65,74,195,64,20,134,175,82,166,219,76,73,154,151,100,102,182,90,164,32,86,90,112,83,178,152,204,188,216,66,146,74,58,213,69,41,20,93,73,197,133,87,240,2,69,144,86,17,188,194,228,70,78,171,43,119,223,247,193,123,252,227,101,95,11,162,98,237,203,46,36,52,14,65,83,8,130,144,50,72,2,202,115,133,60,207,18,206,121,68,188,19,89,13,81,106,97,234,5,30,164,167,167,70,228,178,152,31,237,20,11,52,248,231,163,217,162,86,40,72,72,188,179,90,86,6,29,15,103,5,18,239,66,150,142,199,109,251,106,63,237,214,238,236,182,185,111,158,90,246,219,193,218,133,47,251,238,194,186,217,180,236,155,221,219,93,179,233,216,151,3,216,189,171,15,205,115,243,232,236,163,157,18,239,74,22,139,227,175,113,127,62,184,171,176,30,169,9,150,242,119,66,218,113,245,95,232,21,88,98,101,196,146,133,177,146,62,72,154,176,92,82,80,57,80,9,192,41,68,33,34,40,150,197,74,175,220,193,165,172,221,92,131,181,88,162,175,117,55,200,51,26,234,40,160,0,200,104,198,34,160,62,250,137,98,177,175,17,248,42,61,204,26,220,96,45,205,116,86,13,167,215,19,115,142,183,88,8,210,37,171,244,7,12,21,168,95,108,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f4a92304-820b-48c6-b345-6dee099a1ded"),
				ContainerUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
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
				ModifiedInSchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
			var role1Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				UId = new Guid("c6d0a247-634d-4113-8471-9fce9fb79995"),
				ContainerUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"Role1",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			role1Parameter.SourceValue = new ProcessSchemaParameterValue(role1Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{836ca04a-78fa-4cf4-a449-453ee4c8b6cd}].[Parameter:{e0dd21fb-3d51-44e8-b854-0e07c860de49}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			parametrizedElement.Parameters.Add(role1Parameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaContractVisa = CreateContractVisaLaneSet();
			LaneSets.Add(schemaContractVisa);
			ProcessSchemaLane schemaContractAuthor = CreateContractAuthorLane();
			schemaContractVisa.Lanes.Add(schemaContractAuthor);
			ProcessSchemaSubProcess contractvisasubprocess = CreateContractVisaSubProcessSubProcess();
			FlowElements.Add(contractvisasubprocess);
			ProcessSchemaStartEvent start = CreateStartStartEvent();
			FlowElements.Add(start);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask inputvisaparameters = CreateInputVisaParametersUserTask();
			FlowElements.Add(inputvisaparameters);
			ProcessSchemaUserTask forbitcontractchange = CreateForbitContractChangeUserTask();
			FlowElements.Add(forbitcontractchange);
			ProcessSchemaUserTask readcontract = CreateReadContractUserTask();
			FlowElements.Add(readcontract);
			ProcessSchemaUserTask sendemailtoowner = CreateSendEmailToOwnerUserTask();
			FlowElements.Add(sendemailtoowner);
			ProcessSchemaUserTask readowner = CreateReadOwnerUserTask();
			FlowElements.Add(readowner);
			ProcessSchemaFormulaTask emailbodyvisaapproved = CreateEmailBodyVisaApprovedFormulaTask();
			FlowElements.Add(emailbodyvisaapproved);
			ProcessSchemaFormulaTask emailbodyvisarejected = CreateEmailBodyVisaRejectedFormulaTask();
			FlowElements.Add(emailbodyvisarejected);
			ProcessSchemaFormulaTask emailsubjectvisaapproved = CreateEmailSubjectVisaApprovedFormulaTask();
			FlowElements.Add(emailsubjectvisaapproved);
			ProcessSchemaFormulaTask emailsubjectvisarejected = CreateEmailSubjectVisaRejectedFormulaTask();
			FlowElements.Add(emailsubjectvisarejected);
			ProcessSchemaTerminateEvent terminate3 = CreateTerminate3TerminateEvent();
			FlowElements.Add(terminate3);
			ProcessSchemaUserTask giverightstoowner = CreateGiveRightsToOwnerUserTask();
			FlowElements.Add(giverightstoowner);
			ProcessSchemaUserTask giverightstovisaowner = CreateGiveRightsToVisaOwnerUserTask();
			FlowElements.Add(giverightstovisaowner);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateBodyRejectLocalizableString());
			LocalizableStrings.Add(CreateSubjectRejectLocalizableString());
			LocalizableStrings.Add(CreateBodyApprovedLocalizableString());
			LocalizableStrings.Add(CreateSubjectApprovedLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateBodyRejectLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f042b95a-60ab-4fd3-b3f3-a60bd4cb276e"),
				Name = "BodyReject",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSubjectRejectLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("85bb8129-5e20-4e72-89ab-a51ff02bf29a"),
				Name = "SubjectReject",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateBodyApprovedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("777f955c-3452-4fa8-a5aa-e4aae19e5518"),
				Name = "BodyApproved",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSubjectApprovedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("948131a3-1d35-4590-a85c-1699dd583f92"),
				Name = "SubjectApproved",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("6ac4d589-1703-4bd9-9a3f-88b534a48f9e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(245, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e046d5ca-5771-47ed-b113-a5824ad25bc6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("aba5b30f-9c17-4a77-bbec-1c8488f79339"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(312, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"), new Collection<Guid>() {
						new Guid("f3e3b4f4-4c3e-4efd-b334-bd6521c4fef7"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("706847f9-0bfa-47b0-a228-e0d77a6e8acb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(446, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("31dd8931-96c6-415d-90ff-536f846d4ec1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6bf142a4-d790-4de9-9883-b52824cb229a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("1fe18c6e-5fae-4cf2-abf4-49ce0f27ba8b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(446, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("54de2b68-b576-47e4-9a47-a115f2533a10"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("63ea368e-bf20-4fc5-a69f-5863c7bd43bb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("60239cd9-2e10-49bd-a633-089150c684f8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("5ec9aa40-eeed-4cd1-b847-2403184673c9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(618, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9e242f5f-62c8-4d23-b0b3-1f425b446b41"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3d69e54c-2a2f-4d7c-8fee-7e2cc579b767"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("7f3cd5bf-526f-46a2-839e-6b3179cef781"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("60239cd9-2e10-49bd-a633-089150c684f8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("bca4c2d0-76e4-41ef-825a-121357cf1a70"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{b062e06c-ab36-4672-9371-492d06198505}].[Parameter:{194a72ce-4566-4d00-b100-8623165e187a}]#]==""Rejected""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(728, 94),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9e242f5f-62c8-4d23-b0b3-1f425b446b41"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("ad718950-253b-41da-90af-a6d435f337ce"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{b062e06c-ab36-4672-9371-492d06198505}].[Parameter:{194a72ce-4566-4d00-b100-8623165e187a}]#] == ""Approved""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(809, 170),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("63ea368e-bf20-4fc5-a69f-5863c7bd43bb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("98b4e38b-b9d3-4a9d-a5dd-1ff52820bf70"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(969, 50),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d69e54c-2a2f-4d7c-8fee-7e2cc579b767"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("d8557f6c-50f7-450d-92f8-b2816c59a5bd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(1090, 94),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("b1ae1b36-6143-404c-8a15-efa8acad0a69"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(695, 250),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6f524cbd-d49d-4af0-988f-a66f91d84de2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("4adb2acb-6173-4018-a388-5ffdb1539388"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3e01c4c3-578b-4f86-81d1-2d518755ea13"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(628, 168),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("b3d624b6-4c0a-4f8e-a8c0-b6184792ed83"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3e01c4c3-578b-4f86-81d1-2d518755ea13"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				CurveCenterPosition = new Point(770, 170),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateContractVisaLaneSet() {
			ProcessSchemaLaneSet schemaContractVisa = new ProcessSchemaLaneSet(this) {
				UId = new Guid("03fb0d25-b184-4f90-913b-f93ec8ee15fe"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"ContractVisa",
				Position = new Point(5, 5),
				Size = new Size(1433, 400),
				UseBackgroundMode = false
			};
			return schemaContractVisa;
		}

		protected virtual ProcessSchemaLane CreateContractAuthorLane() {
			ProcessSchemaLane schemaContractAuthor = new ProcessSchemaLane(this) {
				UId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("03fb0d25-b184-4f90-913b-f93ec8ee15fe"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"ContractAuthor",
				Position = new Point(29, 0),
				Size = new Size(1404, 400),
				UseBackgroundMode = false
			};
			return schemaContractAuthor;
		}

		protected virtual ProcessSchemaStartEvent CreateStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("e046d5ca-5771-47ed-b113-a5824ad25bc6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"Start",
				Position = new Point(57, 149),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("6bf142a4-d790-4de9-9883-b52824cb229a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"Terminate1",
				Position = new Point(1345, 149),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateInputVisaParametersUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"InputVisaParameters",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 135),
				SchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeInputVisaParametersParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateForbitContractChangeUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"ForbitContractChange",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(491, 135),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeForbitContractChangeParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadContractUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"ReadContract",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(260, 135),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadContractParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateSendEmailToOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"SendEmailToOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1212, 135),
				SchemaUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeSendEmailToOwnerParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"ReadOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(365, 135),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadOwnerParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateEmailBodyVisaApprovedFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("63ea368e-bf20-4fc5-a69f-5863c7bd43bb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"EmailBodyVisaApproved",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(974, 135),
				ResultParameterMetaPath = @"74993b60-74e2-40cb-9814-23ff874d9202",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,141,193,106,195,48,16,5,127,165,144,75,11,217,32,197,146,87,246,173,9,9,244,212,66,143,193,135,149,180,106,3,150,28,100,37,37,152,252,123,213,107,175,51,111,120,115,201,231,244,181,57,78,57,82,121,222,77,254,254,122,185,228,233,198,126,253,116,90,157,222,230,247,159,196,249,211,125,115,164,62,208,56,243,176,169,244,31,56,140,28,57,149,126,33,131,194,73,199,96,3,9,80,222,88,48,182,147,16,90,141,90,176,117,68,248,168,193,7,101,138,92,56,247,11,54,26,17,69,168,67,173,64,181,86,128,33,215,66,167,100,23,36,55,70,75,255,151,28,82,57,151,251,126,26,175,49,245,139,181,222,43,212,4,141,176,18,20,169,109,189,116,18,58,35,183,109,208,88,125,243,24,86,195,203,47,90,7,220,208,225,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateEmailBodyVisaRejectedFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("9e242f5f-62c8-4d23-b0b3-1f425b446b41"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"EmailBodyVisaRejected",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(869, 16),
				ResultParameterMetaPath = @"74993b60-74e2-40cb-9814-23ff874d9202",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,141,193,106,195,48,16,5,127,37,144,75,10,221,32,197,146,87,246,177,37,133,158,26,154,99,240,97,37,173,146,20,75,6,89,165,4,147,127,143,122,205,117,230,13,111,46,249,154,206,219,143,41,71,42,155,183,201,223,190,249,135,93,121,93,157,214,167,207,249,235,47,113,62,186,11,71,234,3,141,51,15,219,74,159,192,126,228,200,169,244,11,25,20,78,58,6,27,72,128,242,198,130,177,157,132,208,106,212,130,173,35,194,123,13,14,148,41,114,225,220,47,216,104,68,20,161,14,181,2,213,90,1,134,92,11,157,146,93,144,220,24,45,253,127,178,79,229,90,110,239,211,248,27,83,191,88,235,189,66,77,208,8,43,65,145,218,213,75,39,161,51,114,215,6,141,213,55,247,97,61,188,60,0,25,25,188,34,223,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateEmailSubjectVisaApprovedFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("60239cd9-2e10-49bd-a633-089150c684f8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"EmailSubjectVisaApproved",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1100, 135),
				ResultParameterMetaPath = @"3cb8a4b7-f45b-44ff-b96d-91b115085a87",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,46,77,202,74,77,46,113,44,40,40,202,47,75,77,1,0,10,201,46,220,15,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateEmailSubjectVisaRejectedFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("3d69e54c-2a2f-4d7c-8fee-7e2cc579b767"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"EmailSubjectVisaRejected",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1002, 16),
				ResultParameterMetaPath = @"3cb8a4b7-f45b-44ff-b96d-91b115085a87",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,46,77,202,74,77,46,9,74,5,145,0,62,5,188,138,13,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate3TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("6f524cbd-d49d-4af0-988f-a66f91d84de2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"Terminate3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(687, 296),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaSubProcess CreateContractVisaSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaContractVisaSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("b062e06c-ab36-4672-9371-492d06198505"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"ContractVisaSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(771, 135),
				SchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeContractVisaSubProcessParameters(schemaContractVisaSubProcess);
			return schemaContractVisaSubProcess;
		}

		protected virtual ProcessSchemaUserTask CreateGiveRightsToOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("b9416b19-62b4-412d-8205-b053619588be"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"GiveRightsToOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1121, 16),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeGiveRightsToOwnerParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateGiveRightsToVisaOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3e01c4c3-578b-4f86-81d1-2d518755ea13"),
				CreatedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"),
				Name = @"GiveRightsToVisaOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(624, 135),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeGiveRightsToVisaOwnerParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ContractVisaProcess(userConnection);
		}

		public override object Clone() {
			return new ContractVisaProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d"));
		}

		#endregion

	}

	#endregion

	#region Class: ContractVisaProcess

	/// <exclude/>
	public class ContractVisaProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessContractAuthor

		/// <exclude/>
		public class ProcessContractAuthor : ProcessLane
		{

			public ProcessContractAuthor(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: InputVisaParametersFlowElement

		/// <exclude/>
		public class InputVisaParametersFlowElement : AutoGeneratedPageUserTask
		{

			#region Constructors: Public

			public InputVisaParametersFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "InputVisaParameters";
				IsLogging = true;
				SchemaElementUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.ContractAuthor;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("2d2d702c366b4b27b7c771c7307f7b9d",
						 "BaseElements.InputVisaParameters.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private LocalizableString _buttons;
			public override LocalizableString Buttons {
				get {
					return _buttons ?? (_buttons = GetLocalizableString("2d2d702c366b4b27b7c771c7307f7b9d",
						 "BaseElements.InputVisaParameters.Parameters.Buttons.Value"));
				}
				set {
					_buttons = value;
				}
			}

			private LocalizableString _elements;
			public override LocalizableString Elements {
				get {
					return _elements ?? (_elements = GetLocalizableString("2d2d702c366b4b27b7c771c7307f7b9d",
						 "BaseElements.InputVisaParameters.Parameters.Elements.Value"));
				}
				set {
					_elements = value;
				}
			}

			public virtual Guid VisaOwner {
				get;
				set;
			}

			public virtual string Objective {
				get;
				set;
			}

			public virtual bool IsAllowedToDelegate {
				get;
				set;
			}

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"f3e3b4f4-4c3e-4efd-b334-bd6521c4fef7\"]";
			}

			#endregion

		}

		#endregion

		#region Class: ForbitContractChangeFlowElement

		/// <exclude/>
		public class ForbitContractChangeFlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public ForbitContractChangeFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ForbitContractChange";
				IsLogging = true;
				SchemaElementUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,217,210,90,146,123,92,182,101,47,105,104,211,82,72,150,48,150,198,89,129,191,98,201,52,193,236,127,175,188,206,166,144,67,41,189,21,116,152,25,233,189,121,243,24,205,247,62,124,244,77,196,177,172,161,9,72,167,189,43,9,86,160,81,129,102,96,56,103,18,100,206,64,11,203,16,220,38,203,242,76,41,173,9,237,160,197,146,172,232,157,243,145,80,31,177,13,229,237,252,155,52,142,19,210,251,250,156,124,181,71,108,225,219,210,64,27,85,161,64,201,184,16,130,201,66,57,166,53,230,172,82,96,228,198,114,167,51,78,86,45,133,179,66,10,44,152,144,117,197,164,114,46,189,66,199,76,198,193,22,149,209,149,0,66,27,172,227,238,105,24,49,4,223,119,229,140,175,241,205,243,144,84,174,189,183,125,51,181,29,161,45,70,184,134,120,44,9,32,199,212,16,152,149,102,195,100,141,138,129,48,142,9,168,84,174,52,102,69,166,8,181,48,196,133,150,236,29,161,14,34,124,135,102,194,51,243,236,147,198,92,240,76,111,138,132,205,146,75,82,228,156,233,66,43,86,187,162,54,40,10,99,42,119,241,235,211,228,83,236,195,213,212,226,232,237,139,237,152,252,235,199,114,182,125,23,199,190,89,168,175,206,207,111,240,41,174,230,190,92,253,88,7,138,169,190,128,200,137,78,1,183,141,199,46,238,58,219,59,223,61,172,156,167,83,130,180,3,140,62,92,92,216,61,78,208,16,58,250,135,227,31,221,218,78,33,246,237,127,52,42,77,99,38,142,136,227,89,238,178,131,206,135,161,129,231,115,94,146,119,143,83,31,63,124,65,219,143,110,239,214,140,188,65,149,228,142,168,74,213,188,50,105,209,178,98,89,204,26,152,209,154,51,101,164,213,220,74,174,172,188,35,73,201,63,242,223,238,195,231,159,221,229,47,172,234,15,239,83,245,77,225,250,130,44,231,191,145,116,58,44,162,14,167,116,126,1,34,246,238,123,210,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _deleteRights;
			public override string DeleteRights {
				get {
					return _deleteRights ?? (_deleteRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,174,246,76,177,82,50,75,53,74,75,182,52,76,214,53,48,76,76,212,53,73,54,183,212,77,52,74,178,212,53,79,50,72,53,180,176,52,75,50,74,51,85,210,113,78,204,11,74,77,76,177,74,75,204,41,78,5,241,92,83,50,75,172,74,138,74,193,28,151,212,156,212,146,84,8,55,56,191,180,40,57,213,74,201,80,73,199,189,40,49,175,36,21,200,118,204,201,9,202,207,73,45,118,204,75,9,45,78,45,42,86,210,241,75,204,5,138,95,152,116,177,241,194,86,133,139,13,23,246,93,216,125,97,135,2,8,237,7,177,47,246,92,216,14,164,55,93,216,112,177,233,194,86,144,156,82,109,44,0,254,190,72,33,176,0,0,0 })));
				}
				set {
					_deleteRights = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadContractFlowElement

		/// <exclude/>
		public class ReadContractFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadContractFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadContract";
				IsLogging = true;
				SchemaElementUId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,75,107,220,48,16,254,47,58,244,36,21,217,178,45,201,61,46,219,178,151,52,180,105,41,36,75,208,99,148,21,248,21,75,166,9,102,255,123,101,59,155,66,14,165,244,86,240,65,51,154,239,49,31,242,124,239,195,71,223,68,24,107,167,154,0,120,58,216,26,73,231,74,167,157,35,185,227,134,20,149,208,68,107,227,136,226,165,40,157,115,149,85,20,225,78,181,80,163,13,189,183,62,34,236,35,180,161,190,157,127,147,198,113,2,124,239,214,226,171,57,65,171,190,45,2,66,114,13,12,10,66,25,99,73,128,91,34,4,228,68,115,37,139,210,80,43,178,36,176,122,113,18,114,86,177,138,40,154,231,105,52,75,83,165,202,72,69,105,78,165,134,188,224,12,225,6,92,220,63,13,35,132,224,251,174,158,225,245,124,243,60,36,151,155,246,174,111,166,182,67,184,133,168,174,85,60,213,72,1,133,36,168,136,41,100,73,10,7,156,40,38,45,97,74,243,156,11,200,170,140,35,108,212,16,23,90,116,176,8,91,21,213,119,213,76,176,50,207,62,121,204,25,205,68,89,37,108,198,82,94,44,167,68,84,130,19,103,171,100,159,85,82,106,123,201,235,211,228,211,217,135,171,169,133,209,155,151,216,33,229,215,143,245,108,250,46,142,125,179,80,95,173,227,55,240,20,183,112,95,174,126,108,11,197,212,95,64,232,140,167,0,187,198,67,23,247,157,233,173,239,30,54,206,243,57,65,218,65,141,62,92,82,216,63,78,170,65,120,244,15,167,63,166,181,155,66,236,219,255,104,85,156,214,76,28,17,198,213,238,242,6,173,15,67,163,158,215,186,70,239,30,167,62,126,248,2,166,31,237,193,110,21,122,131,170,209,29,226,154,59,170,165,38,69,86,45,15,211,41,34,133,160,132,203,194,8,106,10,202,77,113,135,146,147,127,228,191,61,132,207,63,187,203,191,176,185,63,190,79,221,55,141,235,11,178,158,255,198,210,249,184,152,58,158,211,247,11,134,94,66,213,210,3,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,212,241,76,177,50,176,50,0,0,237,33,101,51,17,0,0,0 })));
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
								new Guid("897be3e4-0333-467d-88e2-b7a945c0d810")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"));
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

		#region Class: SendEmailToOwnerFlowElement

		/// <exclude/>
		public class SendEmailToOwnerFlowElement : SendEmailUserTask
		{

			#region Constructors: Public

			public SendEmailToOwnerFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SendEmailToOwner";
				IsLogging = true;
				SchemaElementUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recepient = () => new LocalizableString(((process.ReadOwner.ResultEntity.IsColumnValueLoaded(process.ReadOwner.ResultEntity.Schema.Columns.GetByName("Email").ColumnValueName) ? process.ReadOwner.ResultEntity.GetTypedColumnValue<string>("Email") : null)));
				_subject = () => new LocalizableString((process.EmailSubject));
				_body = () => new LocalizableString((process.EmailBody));
			}

			#endregion

			#region Properties: Public

			internal Func<string> _recepient;
			public override string Recepient {
				get {
					return (_recepient ?? (_recepient = () => null)).Invoke();
				}
				set {
					_recepient = () => { return value; };
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

			internal Func<LocalizableString> _body;
			public override LocalizableString Body {
				get {
					return (_body ?? (_body = () => null)).Invoke();
				}
				set {
					_body = () => { return value; };
				}
			}

			private bool _isIgnoreErrors = true;
			public override bool IsIgnoreErrors {
				get {
					return _isIgnoreErrors;
				}
				set {
					_isIgnoreErrors = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadOwnerFlowElement

		/// <exclude/>
		public class ReadOwnerFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadOwnerFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadOwner";
				IsLogging = true;
				SchemaElementUId = new Guid("bff63975-7641-445b-a526-7e12cd421a7e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,205,106,220,48,16,126,149,69,135,158,172,197,242,159,100,247,24,182,37,151,52,208,180,20,146,16,100,75,74,12,254,217,216,50,77,48,11,233,6,10,165,105,31,161,61,246,90,210,134,110,146,38,207,32,191,81,199,235,108,11,57,148,92,3,22,140,70,250,190,153,249,60,163,118,47,173,159,165,153,150,85,164,120,86,75,171,89,23,17,98,76,49,201,66,27,179,152,196,216,11,236,16,172,208,193,142,205,98,106,11,26,216,158,66,86,193,115,25,161,1,61,17,169,70,86,170,101,94,71,219,237,63,82,93,53,210,218,83,203,205,203,228,64,230,252,85,31,128,4,177,116,3,159,96,166,164,131,61,226,67,0,33,108,204,153,237,10,47,96,174,16,46,26,114,113,164,36,190,205,28,76,101,24,98,79,73,137,67,66,66,156,56,97,236,197,30,117,84,16,35,43,147,74,79,142,166,149,172,235,180,44,162,86,254,181,183,142,167,144,229,16,123,173,204,154,188,64,86,46,53,223,228,250,32,66,92,218,210,243,19,142,19,47,244,123,118,138,185,27,10,236,242,152,58,148,73,18,16,138,172,132,79,117,79,139,214,5,178,4,215,252,53,207,26,185,100,110,211,62,71,215,38,204,15,0,75,220,4,123,174,3,202,5,140,98,37,2,21,66,161,97,24,139,149,94,207,155,20,236,180,222,104,114,89,165,201,157,236,18,244,43,171,168,77,202,66,87,101,214,83,111,44,175,111,201,35,61,136,123,119,244,102,40,72,131,191,7,161,153,213,212,114,45,75,101,161,39,69,82,138,180,216,31,56,103,51,128,228,83,94,165,245,74,133,201,97,195,51,100,85,233,254,193,127,213,90,107,106,93,230,143,168,84,11,202,4,14,104,178,101,186,125,15,138,180,158,102,252,120,185,143,208,147,195,166,212,79,205,55,179,232,230,230,123,55,239,206,70,230,167,185,53,63,96,157,155,219,238,100,108,190,154,139,238,196,156,119,31,205,229,168,251,100,174,205,133,249,13,235,166,155,143,192,127,97,126,117,167,230,186,59,3,252,162,59,233,78,187,207,221,7,240,94,142,204,21,112,92,47,239,95,117,239,205,194,44,198,230,11,220,58,7,190,121,247,110,176,204,13,16,1,243,144,7,186,151,111,132,118,16,103,212,78,72,34,113,172,184,141,61,193,226,126,230,8,86,129,79,125,91,198,9,231,116,76,93,159,82,106,43,56,242,61,24,204,24,212,231,73,128,67,143,132,138,72,151,249,68,140,97,58,124,146,176,16,59,14,83,48,92,148,97,238,11,133,3,98,123,125,87,115,69,220,29,4,106,62,58,141,182,215,235,23,111,139,213,75,50,252,251,221,49,120,239,57,38,153,204,161,73,162,246,33,162,206,0,176,185,10,21,181,15,145,184,135,76,10,157,234,227,225,69,137,218,135,104,62,219,237,85,223,157,193,247,7,64,79,166,179,119,5,0,0 })));
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

		#region Class: ContractVisaSubProcessFlowElement

		/// <exclude/>
		public class ContractVisaSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public ContractVisaSubProcessFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("b4ef173a-cd86-4fed-8781-695413ee6e53");
			}

			#endregion

			#region Properties: Public

			public Guid Contract {
				get {
					return GetParameterValue<Guid>("Contract");
				}
				set {
					SetParameterValue("Contract", value);
				}
			}

			public Guid VisaOwner {
				get {
					return GetParameterValue<Guid>("VisaOwner");
				}
				set {
					SetParameterValue("VisaOwner", value);
				}
			}

			public string VisaObjective {
				get {
					return GetParameterValue<string>("VisaObjective");
				}
				set {
					SetParameterValue("VisaObjective", value);
				}
			}

			public string VisaResult {
				get {
					return GetParameterValue<string>("VisaResult");
				}
				set {
					SetParameterValue("VisaResult", value);
				}
			}

			public bool IsAllowedToDelegate {
				get {
					return GetParameterValue<bool>("IsAllowedToDelegate");
				}
				set {
					SetParameterValue("IsAllowedToDelegate", value);
				}
			}

			public bool IsPreviousVisaCounts {
				get {
					return GetParameterValue<bool>("IsPreviousVisaCounts");
				}
				set {
					SetParameterValue("IsPreviousVisaCounts", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (ContractVisaProcess)owner;
				Name = "ContractVisaSubProcess";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("b062e06c-ab36-4672-9371-492d06198505");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.ContractAuthor;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (ContractVisaProcess)Owner;
				SetParameterValue("Contract", (Guid)((process.RecordId)));
				SetParameterValue("VisaOwner", process.InputVisaParameters.VisaOwner);
				SetParameterValue("VisaObjective", new LocalizableString((process.InputVisaParameters.Objective)));
				SetParameterValue("IsAllowedToDelegate", (bool)((process.InputVisaParameters.IsAllowedToDelegate)));
				SetParameterValue("IsPreviousVisaCounts", (bool)(false));
			}

			#endregion

		}

		#endregion

		#region Class: GiveRightsToOwnerFlowElement

		/// <exclude/>
		public class GiveRightsToOwnerFlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public GiveRightsToOwnerFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GiveRightsToOwner";
				IsLogging = true;
				SchemaElementUId = new Guid("b9416b19-62b4-412d-8205-b053619588be");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_employee1 = () => (Guid)(((process.ReadContract.ResultEntity.IsColumnValueLoaded(process.ReadContract.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadContract.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,27,49,16,253,47,58,244,36,21,201,146,245,177,61,26,183,248,146,134,54,45,133,196,4,125,204,198,130,253,112,86,90,154,176,248,191,87,235,141,83,200,161,148,222,10,58,204,140,244,222,188,121,140,166,251,152,62,198,38,195,80,213,182,73,128,199,93,168,208,218,57,45,193,10,18,184,51,68,48,182,38,58,56,75,140,98,178,102,160,13,247,18,225,206,182,80,161,5,189,13,49,35,28,51,180,169,186,157,126,147,230,97,4,124,95,159,147,175,254,0,173,253,54,55,208,70,57,224,32,8,229,156,19,33,85,32,90,195,138,56,101,141,88,123,26,52,163,104,209,34,197,202,59,78,57,209,138,49,34,132,119,196,50,33,8,55,192,29,85,134,130,99,8,55,80,231,237,211,113,128,148,98,223,85,19,188,198,55,207,199,162,114,233,189,233,155,177,237,16,110,33,219,107,155,15,21,178,64,161,52,180,196,11,179,38,162,6,69,44,55,129,112,235,212,74,105,96,146,41,132,189,61,230,153,22,237,2,194,193,102,251,221,54,35,156,153,167,88,52,174,56,101,122,45,11,150,113,79,4,95,81,162,165,86,164,14,178,46,50,165,49,46,92,252,250,52,198,18,199,116,53,182,48,68,255,98,59,20,255,250,161,154,124,223,229,161,111,102,234,171,243,243,27,120,202,139,185,47,87,63,150,129,114,169,207,32,116,194,99,130,77,19,161,203,219,206,247,33,118,15,11,231,233,84,32,237,209,14,49,93,92,216,62,142,182,65,120,136,15,135,63,186,181,25,83,238,219,255,104,84,92,198,44,28,25,134,179,220,121,7,67,76,199,198,62,159,243,10,189,123,28,251,252,225,11,248,126,8,187,176,100,232,13,170,66,119,72,57,85,83,103,92,89,122,57,47,102,93,150,94,107,74,148,17,94,83,47,168,242,226,14,21,37,255,200,127,187,75,159,127,118,151,191,176,168,223,191,47,213,55,133,235,11,178,154,254,70,210,105,63,139,218,159,202,249,5,66,7,222,161,210,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,81,203,106,27,65,16,252,21,177,190,106,196,206,190,102,118,175,182,48,6,19,5,11,114,17,58,204,206,246,196,130,221,149,89,141,18,140,16,40,18,4,66,156,124,66,124,244,53,40,22,150,173,216,223,208,243,71,110,217,224,131,15,13,93,69,85,209,143,193,236,164,200,60,30,106,145,75,174,25,143,117,196,34,14,62,147,34,40,88,30,154,36,244,33,149,1,8,175,125,168,234,51,80,69,102,155,41,236,65,183,24,217,55,112,4,37,88,120,133,253,241,180,209,144,121,161,215,62,110,84,109,129,250,110,117,81,142,47,1,188,246,7,85,17,30,28,224,13,110,221,18,255,186,165,187,106,225,45,62,225,63,170,53,62,185,69,7,175,113,227,22,184,118,63,241,190,229,126,225,14,55,248,159,234,209,45,91,196,111,240,206,173,112,231,174,200,191,117,11,183,114,191,221,15,98,239,91,248,64,25,187,23,253,131,251,142,91,220,118,240,15,169,214,148,183,116,223,94,59,124,164,32,74,62,24,122,237,79,170,156,190,140,51,56,153,244,190,214,208,244,245,57,84,42,51,170,156,192,176,67,236,59,162,91,66,5,181,205,102,74,10,95,115,13,44,55,202,103,81,33,115,38,243,148,51,147,196,34,246,33,215,74,137,57,25,62,170,134,54,182,208,100,51,17,198,66,8,223,144,48,166,59,39,57,221,89,233,132,165,17,79,13,135,80,198,188,216,91,186,181,29,217,203,195,113,57,173,234,108,198,121,26,115,45,83,22,4,210,208,119,132,100,42,46,12,75,184,31,229,34,16,202,240,112,62,220,47,211,187,128,70,217,209,184,62,27,125,62,183,167,240,5,202,204,11,188,249,240,25,100,118,52,229,231,1,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _employee1;
			public virtual Guid Employee1 {
				get {
					return (_employee1 ?? (_employee1 = () => Guid.Empty)).Invoke();
				}
				set {
					_employee1 = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: GiveRightsToVisaOwnerFlowElement

		/// <exclude/>
		public class GiveRightsToVisaOwnerFlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public GiveRightsToVisaOwnerFlowElement(UserConnection userConnection, ContractVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GiveRightsToVisaOwner";
				IsLogging = true;
				SchemaElementUId = new Guid("afdc5703-6023-42b4-a3bd-aa1a91271e3a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_role1 = () => (Guid)((process.InputVisaParameters.VisaOwner));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,228,41,178,37,91,146,123,92,182,101,47,105,104,211,82,72,150,32,75,163,172,192,31,27,75,166,9,102,255,123,229,117,54,133,28,74,233,173,224,131,102,164,247,230,189,199,120,190,247,225,163,111,35,142,181,211,109,192,108,218,217,154,232,178,98,204,21,10,88,225,20,240,162,228,160,80,150,192,132,229,121,37,115,219,40,75,178,94,119,88,147,21,189,181,62,146,204,71,236,66,125,59,255,38,141,227,132,217,189,59,23,95,205,1,59,253,109,25,32,149,104,144,33,7,202,24,3,94,9,11,82,98,1,141,208,138,151,134,90,153,83,178,106,161,40,68,78,45,3,227,140,6,206,114,9,90,73,6,84,86,92,162,44,202,194,48,146,181,232,226,246,233,56,98,8,126,232,235,25,95,207,55,207,199,164,114,157,189,25,218,169,235,73,214,97,212,215,58,30,146,83,164,152,6,106,48,92,149,192,29,10,208,76,89,96,186,17,133,144,152,87,185,32,153,209,199,184,208,146,93,178,109,117,212,223,117,59,225,153,121,246,73,99,193,104,46,203,42,97,115,102,146,198,130,130,172,164,0,103,43,167,144,85,74,53,175,121,125,154,124,58,251,112,53,117,56,122,243,18,59,166,252,134,177,158,205,208,199,113,104,23,234,171,243,243,27,124,138,107,184,47,87,63,86,67,49,245,23,16,57,101,83,192,77,235,177,143,219,222,12,214,247,15,43,231,233,148,32,221,81,143,62,92,82,216,62,78,186,37,217,232,31,14,127,76,107,51,133,56,116,255,145,213,44,217,76,28,17,199,179,220,101,7,173,15,199,86,63,159,235,154,188,123,156,134,248,225,11,154,97,180,59,187,86,228,13,170,38,119,68,52,194,209,70,53,144,246,124,89,76,167,65,73,73,65,40,110,36,53,156,10,195,239,72,82,242,143,252,183,187,240,249,103,127,249,23,86,245,251,247,169,251,166,113,125,65,214,243,223,72,58,237,23,81,251,83,250,126,1,13,212,162,39,210,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,142,65,74,195,64,20,134,175,82,166,219,76,73,154,151,100,102,182,90,164,32,86,90,112,83,178,152,204,188,216,66,146,74,58,213,69,41,20,93,73,197,133,87,240,2,69,144,86,17,188,194,228,70,78,171,43,119,223,247,193,123,252,227,101,95,11,162,98,237,203,46,36,52,14,65,83,8,130,144,50,72,2,202,115,133,60,207,18,206,121,68,188,19,89,13,81,106,97,234,5,30,164,167,167,70,228,178,152,31,237,20,11,52,248,231,163,217,162,86,40,72,72,188,179,90,86,6,29,15,103,5,18,239,66,150,142,199,109,251,106,63,237,214,238,236,182,185,111,158,90,246,219,193,218,133,47,251,238,194,186,217,180,236,155,221,219,93,179,233,216,151,3,216,189,171,15,205,115,243,232,236,163,157,18,239,74,22,139,227,175,113,127,62,184,171,176,30,169,9,150,242,119,66,218,113,245,95,232,21,88,98,101,196,146,133,177,146,62,72,154,176,92,82,80,57,80,9,192,41,68,33,34,40,150,197,74,175,220,193,165,172,221,92,131,181,88,162,175,117,55,200,51,26,234,40,160,0,200,104,198,34,160,62,250,137,98,177,175,17,248,42,61,204,26,220,96,45,205,116,86,13,167,215,19,115,142,183,88,8,210,37,171,244,7,12,21,168,95,108,1,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _role1;
			public virtual Guid Role1 {
				get {
					return (_role1 ?? (_role1 = () => Guid.Empty)).Invoke();
				}
				set {
					_role1 = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public ContractVisaProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContractVisaProcess";
			SchemaUId = new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d");
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
				return new Guid("2d2d702c-366b-4b27-b7c7-71c7307f7b9d");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContractVisaProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContractVisaProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string EmailBody {
			get;
			set;
		}

		public virtual string EmailSubject {
			get;
			set;
		}

		public virtual Guid RecordId {
			get;
			set;
		}

		private ProcessContractAuthor _contractAuthor;
		public ProcessContractAuthor ContractAuthor {
			get {
				return _contractAuthor ?? ((_contractAuthor) = new ProcessContractAuthor(UserConnection, this));
			}
		}

		private ProcessFlowElement _start;
		public ProcessFlowElement Start {
			get {
				return _start ?? (_start = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start",
					SchemaElementUId = new Guid("e046d5ca-5771-47ed-b113-a5824ad25bc6"),
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
					SchemaElementUId = new Guid("6bf142a4-d790-4de9-9883-b52824cb229a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private InputVisaParametersFlowElement _inputVisaParameters;
		public InputVisaParametersFlowElement InputVisaParameters {
			get {
				return _inputVisaParameters ?? (_inputVisaParameters = new InputVisaParametersFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ForbitContractChangeFlowElement _forbitContractChange;
		public ForbitContractChangeFlowElement ForbitContractChange {
			get {
				return _forbitContractChange ?? (_forbitContractChange = new ForbitContractChangeFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadContractFlowElement _readContract;
		public ReadContractFlowElement ReadContract {
			get {
				return _readContract ?? (_readContract = new ReadContractFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private SendEmailToOwnerFlowElement _sendEmailToOwner;
		public SendEmailToOwnerFlowElement SendEmailToOwner {
			get {
				return _sendEmailToOwner ?? (_sendEmailToOwner = new SendEmailToOwnerFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadOwnerFlowElement _readOwner;
		public ReadOwnerFlowElement ReadOwner {
			get {
				return _readOwner ?? (_readOwner = new ReadOwnerFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _emailBodyVisaApproved;
		public ProcessScriptTask EmailBodyVisaApproved {
			get {
				return _emailBodyVisaApproved ?? (_emailBodyVisaApproved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "EmailBodyVisaApproved",
					SchemaElementUId = new Guid("63ea368e-bf20-4fc5-a69f-5863c7bd43bb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = EmailBodyVisaApprovedExecute,
				});
			}
		}

		private ProcessScriptTask _emailBodyVisaRejected;
		public ProcessScriptTask EmailBodyVisaRejected {
			get {
				return _emailBodyVisaRejected ?? (_emailBodyVisaRejected = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "EmailBodyVisaRejected",
					SchemaElementUId = new Guid("9e242f5f-62c8-4d23-b0b3-1f425b446b41"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = EmailBodyVisaRejectedExecute,
				});
			}
		}

		private ProcessScriptTask _emailSubjectVisaApproved;
		public ProcessScriptTask EmailSubjectVisaApproved {
			get {
				return _emailSubjectVisaApproved ?? (_emailSubjectVisaApproved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "EmailSubjectVisaApproved",
					SchemaElementUId = new Guid("60239cd9-2e10-49bd-a633-089150c684f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = EmailSubjectVisaApprovedExecute,
				});
			}
		}

		private ProcessScriptTask _emailSubjectVisaRejected;
		public ProcessScriptTask EmailSubjectVisaRejected {
			get {
				return _emailSubjectVisaRejected ?? (_emailSubjectVisaRejected = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "EmailSubjectVisaRejected",
					SchemaElementUId = new Guid("3d69e54c-2a2f-4d7c-8fee-7e2cc579b767"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = EmailSubjectVisaRejectedExecute,
				});
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
					SchemaElementUId = new Guid("6f524cbd-d49d-4af0-988f-a66f91d84de2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ContractVisaSubProcessFlowElement _contractVisaSubProcess;
		public ContractVisaSubProcessFlowElement ContractVisaSubProcess {
			get {
				return _contractVisaSubProcess ?? ((_contractVisaSubProcess) = new ContractVisaSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private GiveRightsToOwnerFlowElement _giveRightsToOwner;
		public GiveRightsToOwnerFlowElement GiveRightsToOwner {
			get {
				return _giveRightsToOwner ?? (_giveRightsToOwner = new GiveRightsToOwnerFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private GiveRightsToVisaOwnerFlowElement _giveRightsToVisaOwner;
		public GiveRightsToVisaOwnerFlowElement GiveRightsToVisaOwner {
			get {
				return _giveRightsToVisaOwner ?? (_giveRightsToVisaOwner = new GiveRightsToVisaOwnerFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("aba5b30f-9c17-4a77-bbec-1c8488f79339"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"), new Collection<Guid>() {
							new Guid("f3e3b4f4-4c3e-4efd-b334-bd6521c4fef7"),
						}},
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
					SchemaElementUId = new Guid("bca4c2d0-76e4-41ef-825a-121357cf1a70"),
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
					SchemaElementUId = new Guid("ad718950-253b-41da-90af-a6d435f337ce"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _giveRightsToVisaOwnerContractVisaSubProcessToken;
		public ProcessToken GiveRightsToVisaOwnerContractVisaSubProcessToken {
			get {
				return _giveRightsToVisaOwnerContractVisaSubProcessToken ?? (_giveRightsToVisaOwnerContractVisaSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "GiveRightsToVisaOwnerContractVisaSubProcessToken",
					SchemaElementUId = new Guid("7801e91a-796a-4d7d-9e4e-410cfa9eedc8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private LocalizableString _bodyReject;
		public LocalizableString BodyReject {
			get {
				return _bodyReject ?? (_bodyReject = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.BodyReject.Value"));
			}
		}

		private LocalizableString _subjectReject;
		public LocalizableString SubjectReject {
			get {
				return _subjectReject ?? (_subjectReject = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.SubjectReject.Value"));
			}
		}

		private LocalizableString _bodyApproved;
		public LocalizableString BodyApproved {
			get {
				return _bodyApproved ?? (_bodyApproved = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.BodyApproved.Value"));
			}
		}

		private LocalizableString _subjectApproved;
		public LocalizableString SubjectApproved {
			get {
				return _subjectApproved ?? (_subjectApproved = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.SubjectApproved.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start.SchemaElementUId] = new Collection<ProcessFlowElement> { Start };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[InputVisaParameters.SchemaElementUId] = new Collection<ProcessFlowElement> { InputVisaParameters };
			FlowElements[ForbitContractChange.SchemaElementUId] = new Collection<ProcessFlowElement> { ForbitContractChange };
			FlowElements[ReadContract.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadContract };
			FlowElements[SendEmailToOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailToOwner };
			FlowElements[ReadOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadOwner };
			FlowElements[EmailBodyVisaApproved.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailBodyVisaApproved };
			FlowElements[EmailBodyVisaRejected.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailBodyVisaRejected };
			FlowElements[EmailSubjectVisaApproved.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailSubjectVisaApproved };
			FlowElements[EmailSubjectVisaRejected.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailSubjectVisaRejected };
			FlowElements[Terminate3.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate3 };
			FlowElements[ContractVisaSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ContractVisaSubProcess };
			FlowElements[GiveRightsToOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { GiveRightsToOwner };
			FlowElements[GiveRightsToVisaOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { GiveRightsToVisaOwner };
			FlowElements[GiveRightsToVisaOwnerContractVisaSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { GiveRightsToVisaOwnerContractVisaSubProcessToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InputVisaParameters", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "InputVisaParameters":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadContract", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "InputVisaParameters");
						break;
					case "ForbitContractChange":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GiveRightsToVisaOwner", e.Context.SenderName));
						break;
					case "ReadContract":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOwner", e.Context.SenderName));
						break;
					case "SendEmailToOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ForbitContractChange", e.Context.SenderName));
						break;
					case "EmailBodyVisaApproved":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailSubjectVisaApproved", e.Context.SenderName));
						break;
					case "EmailBodyVisaRejected":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailSubjectVisaRejected", e.Context.SenderName));
						break;
					case "EmailSubjectVisaApproved":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailToOwner", e.Context.SenderName));
						break;
					case "EmailSubjectVisaRejected":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GiveRightsToOwner", e.Context.SenderName));
						break;
					case "Terminate3":
						CompleteProcess();
						break;
					case "ContractVisaSubProcess":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailBodyVisaRejected", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailBodyVisaApproved", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate3", e.Context.SenderName));
						break;
					case "GiveRightsToOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailToOwner", e.Context.SenderName));
						break;
					case "GiveRightsToVisaOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GiveRightsToVisaOwnerContractVisaSubProcessToken", e.Context.SenderName));
						break;
					case "GiveRightsToVisaOwnerContractVisaSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ContractVisaSubProcess", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = InputVisaParameters.PressedButtonCode == @"ButtonOk";
			Log.InfoFormat(ConditionalExpressionLogMessage, "InputVisaParameters", "ConditionalFlow2", "InputVisaParameters.PressedButtonCode == @\"ButtonOk\"", result);
			Log.Info($"InputVisaParameters.PressedButtonCode: {InputVisaParameters.PressedButtonCode}");
			return result;
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((ContractVisaSubProcess.VisaResult)=="Rejected");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ContractVisaSubProcess", "ConditionalFlow1", "(ContractVisaSubProcess.VisaResult)==\"Rejected\"", result);
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean((ContractVisaSubProcess.VisaResult) == "Approved");
			Log.InfoFormat(ConditionalExpressionLogMessage, "ContractVisaSubProcess", "ConditionalFlow4", "(ContractVisaSubProcess.VisaResult) == \"Approved\"", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("InputVisaParameters.VisaOwner")) {
				writer.WriteValue("InputVisaParameters.VisaOwner", InputVisaParameters.VisaOwner, Guid.Empty);
			}
			if (!HasMapping("InputVisaParameters.Objective")) {
				writer.WriteValue("InputVisaParameters.Objective", InputVisaParameters.Objective, null);
			}
			if (!HasMapping("InputVisaParameters.IsAllowedToDelegate")) {
				writer.WriteValue("InputVisaParameters.IsAllowedToDelegate", InputVisaParameters.IsAllowedToDelegate, false);
			}
			if (!HasMapping("GiveRightsToOwner.Employee1")) {
				writer.WriteValue("GiveRightsToOwner.Employee1", GiveRightsToOwner.Employee1, Guid.Empty);
			}
			if (!HasMapping("GiveRightsToVisaOwner.Role1")) {
				writer.WriteValue("GiveRightsToVisaOwner.Role1", GiveRightsToVisaOwner.Role1, Guid.Empty);
			}
			if (!HasMapping("EmailBody")) {
				writer.WriteValue("EmailBody", EmailBody, null);
			}
			if (!HasMapping("EmailSubject")) {
				writer.WriteValue("EmailSubject", EmailSubject, null);
			}
			if (!HasMapping("RecordId")) {
				writer.WriteValue("RecordId", RecordId, Guid.Empty);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start", string.Empty));
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
			MetaPathParameterValues.Add("74993b60-74e2-40cb-9814-23ff874d9202", () => EmailBody);
			MetaPathParameterValues.Add("3cb8a4b7-f45b-44ff-b96d-91b115085a87", () => EmailSubject);
			MetaPathParameterValues.Add("7b7f0b9b-4163-46fa-9880-794c80c407c4", () => RecordId);
			MetaPathParameterValues.Add("15e74ec5-0326-4f08-8eff-34dd48372d46", () => InputVisaParameters.Title);
			MetaPathParameterValues.Add("03bf1a8c-ab55-4047-aa71-9f75cf806d53", () => InputVisaParameters.EntitySchemaUId);
			MetaPathParameterValues.Add("95ea8e28-dccf-4a6e-bb68-8cf426150c7d", () => InputVisaParameters.Recommendation);
			MetaPathParameterValues.Add("af3a440c-346a-45ea-b989-ad9edad884e9", () => InputVisaParameters.EntityId);
			MetaPathParameterValues.Add("64a3cca3-4c10-4274-aef0-5a1ef5d6712f", () => InputVisaParameters.Buttons);
			MetaPathParameterValues.Add("67d2763d-f0c5-4de5-be15-11bb62ecf373", () => InputVisaParameters.Elements);
			MetaPathParameterValues.Add("05607c13-cca8-4ff4-9db7-ca1b00e9d924", () => InputVisaParameters.ExtendedClientModule);
			MetaPathParameterValues.Add("2c1c4abc-e8a6-48a5-bc00-7f05f8db1732", () => InputVisaParameters.EntryPointId);
			MetaPathParameterValues.Add("d649bbc1-42b3-4dd3-b3f4-288751672e90", () => InputVisaParameters.PressedButtonCode);
			MetaPathParameterValues.Add("c36b3fbb-0cda-4054-9d6c-3f2764a2a299", () => InputVisaParameters.OwnerId);
			MetaPathParameterValues.Add("725b0f21-bc47-4763-ac11-51f3e58ac1f6", () => InputVisaParameters.ShowExecutionPage);
			MetaPathParameterValues.Add("49aa3b10-f4df-4db4-a710-7a3da112ae79", () => InputVisaParameters.InformationOnStep);
			MetaPathParameterValues.Add("a7674ac1-de80-4564-9a13-246fabb59722", () => InputVisaParameters.IsRunning);
			MetaPathParameterValues.Add("df0a245a-f0d7-4b8d-be94-cbc9d3aa90f0", () => InputVisaParameters.CurrentActivityId);
			MetaPathParameterValues.Add("f0156928-27af-484e-9190-33b0a62a7a73", () => InputVisaParameters.CreateActivity);
			MetaPathParameterValues.Add("3ae7281e-db88-4abd-a773-5915956a6a36", () => InputVisaParameters.ActivityPriority);
			MetaPathParameterValues.Add("cf8e13af-b73a-4d7e-9b81-4ac252fefc28", () => InputVisaParameters.StartIn);
			MetaPathParameterValues.Add("6bcd0bd5-95cb-4826-b8e0-e1efa8d5f968", () => InputVisaParameters.StartInPeriod);
			MetaPathParameterValues.Add("e55250fe-8ea0-4354-baa1-9afc5d482f7a", () => InputVisaParameters.Duration);
			MetaPathParameterValues.Add("48a1e8f5-a3e8-477c-a0a3-cc06380aa67c", () => InputVisaParameters.DurationPeriod);
			MetaPathParameterValues.Add("ea87ad9d-1475-432f-b39b-c4c364ecf076", () => InputVisaParameters.ShowInScheduler);
			MetaPathParameterValues.Add("0c423b76-8605-4a06-b983-b75aa4392751", () => InputVisaParameters.RemindBefore);
			MetaPathParameterValues.Add("6a18d149-3924-4e6e-838a-0202591eb947", () => InputVisaParameters.RemindBeforePeriod);
			MetaPathParameterValues.Add("cbe0a2d5-d094-46cc-a276-48fb00d1f63a", () => InputVisaParameters.ActivityResult);
			MetaPathParameterValues.Add("7e17c9b2-141c-470e-9741-0403708a75f3", () => InputVisaParameters.IsActivityCompleted);
			MetaPathParameterValues.Add("e0dd21fb-3d51-44e8-b854-0e07c860de49", () => InputVisaParameters.VisaOwner);
			MetaPathParameterValues.Add("4e06d591-5e64-4ada-8d8c-ecc485ed6411", () => InputVisaParameters.Objective);
			MetaPathParameterValues.Add("e4157d41-c7c0-423c-90ea-9b31a9527bea", () => InputVisaParameters.IsAllowedToDelegate);
			MetaPathParameterValues.Add("6410dd64-cb18-4b43-92d8-ea4e92452489", () => ForbitContractChange.EntitySchemaUId);
			MetaPathParameterValues.Add("5aca796c-35c6-418a-9deb-b088a8f677dc", () => ForbitContractChange.DataSourceFilters);
			MetaPathParameterValues.Add("24dfe4df-9bb5-49a4-95db-61542b4948d1", () => ForbitContractChange.DeleteRights);
			MetaPathParameterValues.Add("00434e0c-82ed-4624-aecf-e0253c869124", () => ForbitContractChange.AddRights);
			MetaPathParameterValues.Add("6339a993-b155-4f8e-8ab1-188aa3fbcd7d", () => ForbitContractChange.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("eb5c0633-71b5-4885-bf63-9348c6e716fe", () => ReadContract.DataSourceFilters);
			MetaPathParameterValues.Add("df762cbe-8d50-45aa-a692-fc3ca13753f4", () => ReadContract.ResultType);
			MetaPathParameterValues.Add("0e9f1193-9fc1-4b4b-8432-b733eba80912", () => ReadContract.ReadSomeTopRecords);
			MetaPathParameterValues.Add("9d143566-7ff6-4ddc-91a8-d591f09cd961", () => ReadContract.NumberOfRecords);
			MetaPathParameterValues.Add("e5201aee-681b-4744-8a31-9ddd18e21086", () => ReadContract.FunctionType);
			MetaPathParameterValues.Add("11075dd3-15ea-48cc-bc90-e0d56c7659c3", () => ReadContract.AggregationColumnName);
			MetaPathParameterValues.Add("9cc48116-aeb9-466b-8bfc-4e956a8a224a", () => ReadContract.OrderInfo);
			MetaPathParameterValues.Add("7357770f-8b54-46b0-8ac6-9419f1e3851d", () => ReadContract.ResultEntity);
			MetaPathParameterValues.Add("8a5724d5-1ff6-487b-9fc6-200c9ad0f055", () => ReadContract.ResultCount);
			MetaPathParameterValues.Add("ba20003a-340e-46d9-a946-c7b838095ecf", () => ReadContract.ResultIntegerFunction);
			MetaPathParameterValues.Add("449de235-c6b7-424f-85d8-fb162b49bb7b", () => ReadContract.ResultFloatFunction);
			MetaPathParameterValues.Add("ba4dd278-a683-4a23-bb70-76dbea3a6008", () => ReadContract.ResultDateTimeFunction);
			MetaPathParameterValues.Add("88ad9c3b-a5af-4854-a28b-1335fb70031e", () => ReadContract.ResultRowsCount);
			MetaPathParameterValues.Add("e8e6e487-50e1-4bf3-8f69-9a817f3ab435", () => ReadContract.CanReadUncommitedData);
			MetaPathParameterValues.Add("221e16c4-8293-45d9-8259-d695e5af79eb", () => ReadContract.ResultEntityCollection);
			MetaPathParameterValues.Add("43a99aa6-4673-4153-a178-a5b9790d2ad5", () => ReadContract.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("32c0ad0e-56cf-4c87-b1ac-2dd4e4bf0c7c", () => ReadContract.IgnoreDisplayValues);
			MetaPathParameterValues.Add("6c530e54-ccb1-4789-8368-bd42cd35d0f7", () => ReadContract.ResultCompositeObjectList);
			MetaPathParameterValues.Add("f5fa984a-06a8-418c-8f7e-523441758aaf", () => ReadContract.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e23b91be-231f-435f-8517-737db19c220d", () => SendEmailToOwner.Sender);
			MetaPathParameterValues.Add("eafc53b1-5965-4420-91e0-d855598a9606", () => SendEmailToOwner.Recepient);
			MetaPathParameterValues.Add("5267c7f6-bd77-4ed7-824c-b431dbd24c08", () => SendEmailToOwner.CopyRecepient);
			MetaPathParameterValues.Add("fe9744a9-7550-407f-802d-aa723487447d", () => SendEmailToOwner.BlindCopyRecepient);
			MetaPathParameterValues.Add("d722c459-1025-4d56-86cc-230572deb759", () => SendEmailToOwner.Subject);
			MetaPathParameterValues.Add("62b9d136-3ff8-48ad-91e5-9dc61486aef5", () => SendEmailToOwner.Body);
			MetaPathParameterValues.Add("0ededcb2-d1f2-4ed5-8714-1a853d7276ec", () => SendEmailToOwner.Importance);
			MetaPathParameterValues.Add("ed7f847d-ac6b-4f96-880b-b96226ea317b", () => SendEmailToOwner.IsIgnoreErrors);
			MetaPathParameterValues.Add("8584ab53-ba83-4f42-a7bc-feab37d28011", () => ReadOwner.DataSourceFilters);
			MetaPathParameterValues.Add("c376d60e-a7a4-4e19-bd8a-dae2932a0e78", () => ReadOwner.ResultType);
			MetaPathParameterValues.Add("9f2bb0a7-bb26-44d6-982d-bae251821d05", () => ReadOwner.ReadSomeTopRecords);
			MetaPathParameterValues.Add("8891e889-db66-4762-9171-8140dd7cf232", () => ReadOwner.NumberOfRecords);
			MetaPathParameterValues.Add("5d406829-cb2c-4bc8-aee9-9b1c2127c6fd", () => ReadOwner.FunctionType);
			MetaPathParameterValues.Add("cb921596-274f-4b21-8c44-b212fc1920ca", () => ReadOwner.AggregationColumnName);
			MetaPathParameterValues.Add("f1ff7012-8664-41bf-9c72-c0b8ed663964", () => ReadOwner.OrderInfo);
			MetaPathParameterValues.Add("31f0b17f-eb70-4992-b1b1-bca006ff0170", () => ReadOwner.ResultEntity);
			MetaPathParameterValues.Add("aa386400-da48-4c38-ad31-fc6fc0b48215", () => ReadOwner.ResultCount);
			MetaPathParameterValues.Add("d69de283-3768-4fed-88cf-ba8a30d46115", () => ReadOwner.ResultIntegerFunction);
			MetaPathParameterValues.Add("d49960ad-0a29-4f36-993a-f6d4071447e8", () => ReadOwner.ResultFloatFunction);
			MetaPathParameterValues.Add("2170fceb-72f6-4c84-8877-fe0d9df8d2db", () => ReadOwner.ResultDateTimeFunction);
			MetaPathParameterValues.Add("2af17b6f-5672-4495-9124-0e90d072d034", () => ReadOwner.ResultRowsCount);
			MetaPathParameterValues.Add("ac4a8ce3-7747-409c-9280-55e75a467639", () => ReadOwner.CanReadUncommitedData);
			MetaPathParameterValues.Add("9d748d72-4039-430d-9516-9bf95155fd9b", () => ReadOwner.ResultEntityCollection);
			MetaPathParameterValues.Add("c3c00126-734d-41e9-bf79-8da33bbe8ad7", () => ReadOwner.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("37fda484-0125-46f8-b450-58f5d24b2f0e", () => ReadOwner.IgnoreDisplayValues);
			MetaPathParameterValues.Add("a35c56a5-1a56-42fd-bf45-ed9e38384a08", () => ReadOwner.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d1a6d76b-535b-4923-b30a-20554b325523", () => ReadOwner.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("310fad23-c110-4806-9d92-9b7ef68030a8", () => ContractVisaSubProcess.Contract);
			MetaPathParameterValues.Add("cf070ad1-6809-4a88-9acd-4c1050d73518", () => ContractVisaSubProcess.VisaOwner);
			MetaPathParameterValues.Add("68991ea2-632d-4c0d-bcc0-b0279a32a9da", () => ContractVisaSubProcess.VisaObjective);
			MetaPathParameterValues.Add("194a72ce-4566-4d00-b100-8623165e187a", () => ContractVisaSubProcess.VisaResult);
			MetaPathParameterValues.Add("37892265-46bb-4ffe-aa15-ea2ccaae20b6", () => ContractVisaSubProcess.IsAllowedToDelegate);
			MetaPathParameterValues.Add("8717320f-9266-4d6e-959e-f602a2bff5fd", () => ContractVisaSubProcess.IsPreviousVisaCounts);
			MetaPathParameterValues.Add("db5af251-bee8-4545-8937-e1aa966c98be", () => GiveRightsToOwner.EntitySchemaUId);
			MetaPathParameterValues.Add("cd06c729-8a50-4f14-a085-8c9bf142de19", () => GiveRightsToOwner.DataSourceFilters);
			MetaPathParameterValues.Add("fe09c0ea-c751-454d-9193-e03efc91f334", () => GiveRightsToOwner.DeleteRights);
			MetaPathParameterValues.Add("3ce1b749-d0db-40c4-b82f-c8972441ef28", () => GiveRightsToOwner.AddRights);
			MetaPathParameterValues.Add("5512dee7-aaf8-4f35-a70e-4df063f5d58e", () => GiveRightsToOwner.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("13c7b81c-15c4-41e0-872d-b3f630e982e7", () => GiveRightsToOwner.Employee1);
			MetaPathParameterValues.Add("db86a347-29e9-4743-9766-c6a508976d06", () => GiveRightsToVisaOwner.EntitySchemaUId);
			MetaPathParameterValues.Add("e9392949-f8f5-4add-bc89-a191956f1182", () => GiveRightsToVisaOwner.DataSourceFilters);
			MetaPathParameterValues.Add("c7fca4c4-fb67-44e2-b05f-2c3a3b6e3769", () => GiveRightsToVisaOwner.DeleteRights);
			MetaPathParameterValues.Add("aeae1d71-a282-4e9b-aa64-781333770500", () => GiveRightsToVisaOwner.AddRights);
			MetaPathParameterValues.Add("f4a92304-820b-48c6-b345-6dee099a1ded", () => GiveRightsToVisaOwner.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c6d0a247-634d-4113-8471-9fce9fb79995", () => GiveRightsToVisaOwner.Role1);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "InputVisaParameters.VisaOwner":
					InputVisaParameters.VisaOwner = reader.GetValue<System.Guid>();
				break;
				case "InputVisaParameters.Objective":
					InputVisaParameters.Objective = reader.GetValue<System.String>();
				break;
				case "InputVisaParameters.IsAllowedToDelegate":
					InputVisaParameters.IsAllowedToDelegate = reader.GetValue<System.Boolean>();
				break;
				case "GiveRightsToOwner.Employee1":
					GiveRightsToOwner.Employee1 = reader.GetValue<System.Guid>();
				break;
				case "GiveRightsToVisaOwner.Role1":
					GiveRightsToVisaOwner.Role1 = reader.GetValue<System.Guid>();
				break;
				case "EmailBody":
					if (!hasValueToRead) break;
					EmailBody = reader.GetValue<System.String>();
				break;
				case "EmailSubject":
					if (!hasValueToRead) break;
					EmailSubject = reader.GetValue<System.String>();
				break;
				case "RecordId":
					if (!hasValueToRead) break;
					RecordId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool EmailBodyVisaApprovedExecute(ProcessExecutingContext context) {
			var localEmailBody = string.Format(BodyApproved, ((ReadContract.ResultEntity.IsColumnValueLoaded(ReadContract.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? ReadContract.ResultEntity.GetTypedColumnValue<string>("Number") : null)));
			EmailBody = (System.String)localEmailBody;
			return true;
		}

		public virtual bool EmailBodyVisaRejectedExecute(ProcessExecutingContext context) {
			var localEmailBody = string.Format(BodyReject, ((ReadContract.ResultEntity.IsColumnValueLoaded(ReadContract.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? ReadContract.ResultEntity.GetTypedColumnValue<string>("Number") : null)));
			EmailBody = (System.String)localEmailBody;
			return true;
		}

		public virtual bool EmailSubjectVisaApprovedExecute(ProcessExecutingContext context) {
			var localEmailSubject = SubjectApproved;
			EmailSubject = (System.String)localEmailSubject;
			return true;
		}

		public virtual bool EmailSubjectVisaRejectedExecute(ProcessExecutingContext context) {
			var localEmailSubject = SubjectReject;
			EmailSubject = (System.String)localEmailSubject;
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
			var cloneItem = (ContractVisaProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

