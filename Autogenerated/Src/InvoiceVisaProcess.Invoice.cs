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

	#region Class: InvoiceVisaProcessSchema

	/// <exclude/>
	public class InvoiceVisaProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public InvoiceVisaProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public InvoiceVisaProcessSchema(InvoiceVisaProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "InvoiceVisaProcess";
			UId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243");
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
			RealUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243");
			Version = 0;
			PackageUId = new Guid("e7a2c20a-9591-484e-bf77-5953f2dc592e");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateEmailBodyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("74993b60-74e2-40cb-9814-23ff874d9202"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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

		protected virtual void InitializeInvoiceVisaSubProcessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var invoiceParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3cff9b6a-3056-44a8-9a1f-c6bfec3caa52"),
				ContainerUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{7b7f0b9b-4163-46fa-9880-794c80c407c4}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var visaOwnerParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				UId = new Guid("3056cd61-172a-449e-999b-ce78323fd7ec"),
				ContainerUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Name = @"VisaOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			visaOwnerParameter.SourceValue = new ProcessSchemaParameterValue(visaOwnerParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{836ca04a-78fa-4cf4-a449-453ee4c8b6cd}].[Parameter:{e0dd21fb-3d51-44e8-b854-0e07c860de49}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(visaOwnerParameter);
			var visaObjectiveParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b499fc0-a472-4fc1-8168-5a7f139ed935"),
				ContainerUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(visaObjectiveParameter);
			var visaResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f1116ee-11da-40ee-bb56-440bdf99b269"),
				ContainerUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
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
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c")
			};
			parametrizedElement.Parameters.Add(visaResultParameter);
			var isAllowedToDelegateParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7ef81b65-2836-4432-b1da-f17b53c9a6de"),
				ContainerUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(isAllowedToDelegateParameter);
			var isPreviousVisaCountsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1f29d0dc-0ab8-4b13-a121-53bd4037b40d"),
				ContainerUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6fda6d18-1dcb-4cdc-beb8-3d93131256a5"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				Value = @"{""$type"":""System.Collections.Generic.List`1[[System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib]], mscorlib"",""$values"":[{""$type"":""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",""Id"":""f3e3b4f4-4c3e-4efd-b334-bd6521c4fef7"",""name"":""ButtonOk"",""caption"":""Сохранить"",""style"":""green"",""performValidation"":true,""isEnabled"":true,""generateSignal"":""""}]}",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				UId = new Guid("2f5005e0-98ac-49c4-95a3-093aed380ddb"),
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
				UId = new Guid("f789c4c3-1f20-4baa-9abc-19ae652beb7b"),
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
				UId = new Guid("2a68b2b8-60a8-47eb-873f-949b07b7200c"),
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
				UId = new Guid("37eb257f-2cfd-4531-b15a-d9090b85bad6"),
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
				UId = new Guid("282a01b7-5914-4764-ac43-fb8cad39d9d5"),
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
				UId = new Guid("049df9a1-60f7-4a91-9c90-86422972da2d"),
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
				UId = new Guid("467725db-47dc-44f0-9ac6-ec37517fc378"),
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
				UId = new Guid("34990377-9bbb-4062-9c9a-44da28f6407f"),
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
				UId = new Guid("ab80c556-bb27-4f9d-8309-097c7f88a301"),
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
				UId = new Guid("be924ba0-8330-41b9-b472-382b3f3afb92"),
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
				UId = new Guid("2d52e611-dcaa-498d-9936-d29a38cc3db9"),
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
				UId = new Guid("d1ecf2b7-b798-457f-8d1e-09fc1c77197e"),
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
				UId = new Guid("188ed528-ca0a-4414-a322-b793bea50c08"),
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
				UId = new Guid("22b3b17e-548d-4197-ac38-babf7d6b2014"),
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
				UId = new Guid("36bdffa9-5a67-4811-b992-8a08dc04092b"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"VisaOwner",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			visaOwnerParameter.SourceValue = new ProcessSchemaParameterValue(visaOwnerParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(visaOwnerParameter);
			var objectiveParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e06d591-5e64-4ada-8d8c-ecc485ed6411"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(objectiveParameter);
			var isAllowedToDelegateParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4157d41-c7c0-423c-90ea-9b31a9527bea"),
				ContainerUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(isAllowedToDelegateParameter);
		}

		protected virtual void InitializeForbitInvoiceChangeParameters(IParametrizedProcessSchemaElement parametrizedElement) {
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
				Value = @"bfb313dd-bb55-4e1b-8e42-3d346e0da7c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,217,146,45,217,61,46,219,178,151,52,180,105,41,36,75,24,75,163,172,192,31,27,75,166,9,102,255,123,229,117,54,133,28,74,233,173,160,195,204,104,222,155,55,15,105,190,247,225,163,111,35,142,181,131,54,32,157,118,182,38,216,128,70,5,154,65,197,57,147,32,115,6,90,24,134,96,139,44,203,51,165,180,38,180,135,14,107,178,162,183,214,71,66,125,196,46,212,183,243,111,210,56,78,72,239,221,57,249,106,14,216,193,183,101,64,227,26,145,9,107,89,211,20,5,147,152,53,76,99,154,34,172,144,37,114,11,202,20,100,213,82,42,225,56,55,142,85,210,165,86,153,33,131,162,228,172,40,65,229,206,84,182,112,142,208,22,93,220,62,29,71,12,193,15,125,61,227,107,124,243,124,76,42,215,217,155,161,157,186,158,208,14,35,92,67,60,212,4,144,163,44,12,48,35,171,196,238,80,49,16,149,101,2,26,149,43,141,89,153,41,66,13,28,227,66,75,118,150,80,11,17,190,67,59,225,153,121,246,73,99,46,120,166,139,50,97,179,228,146,20,57,103,186,212,138,57,91,186,10,69,89,85,141,189,248,245,105,242,41,246,225,106,234,112,244,230,197,118,76,254,13,99,61,155,161,143,227,208,46,212,87,231,246,27,124,138,171,185,47,87,63,214,133,98,170,47,32,114,162,83,192,77,235,177,143,219,222,12,214,247,15,43,231,233,148,32,221,17,70,31,46,46,108,31,39,104,9,29,253,195,225,143,110,109,166,16,135,238,63,90,149,166,53,19,71,196,241,44,119,121,131,214,135,99,11,207,231,188,38,239,30,167,33,126,248,130,102,24,237,206,174,25,121,131,170,201,29,81,141,114,188,169,26,38,179,82,48,89,58,96,149,214,156,169,74,26,205,141,228,202,200,59,146,148,252,35,255,237,46,124,254,217,95,254,194,170,126,255,62,85,223,20,174,47,200,122,254,27,73,167,253,34,106,127,74,231,23,218,18,108,245,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,174,246,76,177,82,50,182,72,74,51,51,78,74,209,77,52,50,179,208,53,73,75,49,213,77,76,78,4,178,76,44,146,13,12,82,45,76,76,210,18,149,116,156,19,243,130,82,19,83,172,210,18,115,138,83,65,60,215,148,204,18,171,146,162,82,48,199,37,53,39,181,36,21,194,13,206,47,45,74,78,181,82,50,84,210,113,47,74,204,43,73,5,178,29,115,114,130,242,115,82,139,29,243,82,66,139,83,139,138,149,116,252,18,115,129,226,23,38,93,108,188,176,85,225,98,195,133,125,23,118,95,216,161,0,66,251,65,236,139,61,23,182,3,233,77,23,54,92,108,186,176,21,36,167,84,27,11,0,246,20,105,89,176,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4e79e422-749c-4eea-bc6b-efc646d9060f"),
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

		protected virtual void InitializeReadInvoiceParameters(IParametrizedProcessSchemaElement parametrizedElement) {
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,77,107,220,48,16,134,255,139,14,61,89,197,182,100,75,118,143,203,182,236,37,13,109,90,10,201,18,244,49,147,21,248,43,150,76,19,140,255,123,229,117,54,133,28,74,233,173,224,131,102,236,247,157,103,94,228,249,222,249,143,174,9,48,214,168,26,15,201,116,176,53,169,16,11,212,136,52,71,97,40,47,165,166,90,27,164,74,20,178,64,196,210,170,148,36,157,106,161,38,155,122,111,93,32,137,11,208,250,250,118,254,109,26,198,9,146,123,60,23,95,205,9,90,245,109,29,160,81,179,140,89,27,109,139,130,114,200,52,149,192,115,202,44,227,37,164,86,9,83,144,141,69,11,198,202,170,224,20,36,90,202,109,142,84,231,134,211,220,128,177,156,153,220,72,75,146,6,48,236,159,134,17,188,119,125,87,207,240,122,190,121,30,34,229,54,123,215,55,83,219,145,164,133,160,174,85,56,213,68,65,10,188,48,138,26,94,69,16,4,65,21,171,44,101,74,139,92,72,200,202,76,144,196,168,33,172,182,228,16,71,89,21,212,119,213,76,112,118,158,93,100,204,89,154,201,162,140,218,140,197,188,88,158,82,89,74,65,209,150,88,65,196,175,180,189,228,245,105,114,241,236,252,213,212,194,232,204,75,236,16,243,235,199,122,54,125,23,198,190,89,173,175,206,159,223,192,83,216,194,125,121,245,99,91,40,196,254,42,34,75,50,121,216,53,14,186,176,239,76,111,93,247,176,121,46,75,148,180,131,26,157,191,164,176,127,156,84,67,146,209,61,156,254,152,214,110,242,161,111,255,163,85,147,184,102,244,8,48,158,113,215,59,104,157,31,26,245,124,174,107,242,238,113,234,195,135,47,96,250,209,30,236,86,145,55,170,154,220,17,161,5,166,186,210,148,103,37,139,55,31,21,173,164,76,169,168,184,145,169,225,169,48,252,142,68,146,127,244,191,61,248,207,63,187,203,191,176,209,31,223,199,238,155,198,245,69,89,207,127,131,180,28,87,168,227,18,159,95,36,175,107,249,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,1,0,242,67,189,42,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c85fb573-bcfe-41e9-a9a9-27b68c96c857"),
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
				UId = new Guid("5b217c23-ab59-497e-81b9-7bdc3f90f4fe"),
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
				UId = new Guid("7592d300-f54b-4af3-9bff-e643df029e41"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,205,106,220,48,16,126,149,69,135,158,172,197,242,159,36,247,24,182,37,151,52,208,180,20,146,16,100,73,78,12,254,217,216,50,77,88,22,210,4,90,74,211,62,66,123,236,181,4,66,55,73,211,103,144,223,168,227,117,182,133,28,74,174,1,27,143,70,243,125,51,250,60,163,217,94,214,60,203,114,163,235,56,21,121,163,157,118,93,197,136,177,148,105,198,93,204,18,146,224,32,114,57,88,220,195,158,203,18,234,42,26,185,65,138,156,82,20,58,70,3,122,162,50,131,156,204,232,162,137,183,103,255,72,77,221,106,103,47,93,46,94,202,3,93,136,87,125,2,18,37,218,143,66,130,89,170,61,28,144,16,18,40,229,98,193,92,95,5,17,243,149,242,209,80,139,167,53,9,93,230,97,170,57,199,65,170,53,230,132,112,44,61,158,4,73,64,189,52,74,144,147,235,212,76,142,166,181,110,154,172,42,227,153,254,107,111,29,79,161,202,33,247,90,149,183,69,137,156,66,27,177,41,204,65,140,132,118,117,16,74,129,101,192,195,158,157,98,225,115,133,125,145,80,143,50,77,34,66,145,35,197,212,244,180,104,93,33,71,9,35,94,139,188,213,75,230,89,214,215,232,187,132,133,17,96,137,47,113,224,123,160,92,196,40,78,85,148,114,56,40,231,137,90,233,245,188,205,192,206,154,141,182,208,117,38,239,100,215,160,95,85,199,51,89,149,166,174,242,158,122,99,25,190,165,143,204,32,238,221,214,155,225,64,6,252,61,8,205,157,182,209,107,121,166,75,51,41,101,165,178,114,127,224,156,207,1,82,76,69,157,53,43,21,38,135,173,200,145,83,103,251,7,255,85,107,173,109,76,85,60,162,163,58,112,76,224,128,38,91,150,219,247,160,202,154,105,46,142,151,235,24,61,57,108,43,243,212,126,183,139,238,212,254,232,78,187,243,81,247,174,251,96,47,187,211,177,253,6,159,19,123,209,125,178,87,163,238,179,189,177,151,246,23,188,183,221,233,8,252,151,246,103,119,102,111,186,115,64,46,186,147,238,172,251,210,125,4,239,213,200,94,219,223,16,221,199,95,119,239,237,194,46,198,246,43,68,93,244,180,64,191,180,236,45,16,1,243,80,1,186,87,105,140,118,144,96,212,149,68,106,156,164,194,197,129,98,73,63,109,4,167,81,72,67,87,39,82,8,58,166,126,72,41,117,83,216,10,3,24,201,4,116,23,50,194,60,32,60,37,218,103,33,81,99,233,43,79,135,190,192,161,27,193,88,113,31,38,74,9,137,169,76,164,226,202,79,67,38,119,16,232,248,136,212,217,94,111,94,188,45,87,183,199,240,191,119,199,224,189,231,152,228,186,128,198,136,103,15,145,115,14,128,205,85,170,120,246,16,113,123,200,164,52,153,57,30,110,17,104,224,7,168,61,223,237,245,222,157,195,243,7,77,254,130,103,107,5,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3ae21b6c-fec9-4c92-9a29-c7820bacc7cd"),
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
				UId = new Guid("a6bb09dc-121d-4aac-9e66-1065f1b4a03f"),
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
				UId = new Guid("4540fb83-a29d-4bb1-8ff1-7c78c6151f70"),
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
				UId = new Guid("06f32bdb-9ee2-46db-8d39-5c0ebc39ed25"),
				ContainerUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
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
				Value = @"bfb313dd-bb55-4e1b-8e42-3d346e0da7c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1b719a91-d070-4e60-a646-559e44548e48"),
				ContainerUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,217,146,245,225,30,151,109,217,75,26,218,180,20,146,37,232,99,148,21,248,99,99,203,52,193,236,127,175,188,206,166,144,67,41,189,21,116,152,25,205,123,122,243,24,205,247,113,252,24,155,4,67,29,76,51,2,158,118,190,70,166,244,37,19,178,34,76,128,32,156,243,130,232,146,75,2,146,105,85,81,102,33,112,132,59,211,66,141,86,244,214,199,132,112,76,208,142,245,237,252,155,52,13,19,224,251,112,78,190,186,3,180,230,219,242,128,13,150,21,204,123,98,109,85,17,14,133,37,10,120,73,152,103,92,0,245,70,186,10,173,90,172,161,249,90,1,145,62,119,113,65,43,162,105,165,137,84,74,72,199,101,0,160,8,55,16,210,246,233,56,192,56,198,190,171,103,120,141,111,158,143,89,229,250,246,166,111,166,182,67,184,133,100,174,77,58,228,73,129,2,175,156,33,142,235,44,36,128,36,134,105,79,152,177,178,148,10,10,81,72,132,157,57,166,133,22,237,60,194,222,36,243,221,52,19,156,153,231,152,53,150,140,22,170,18,25,91,48,71,56,43,41,81,66,73,18,188,8,26,152,208,218,250,139,95,159,166,152,227,56,94,77,45,12,209,189,216,14,217,191,126,168,103,215,119,105,232,155,133,250,234,220,126,3,79,105,53,247,229,234,199,58,80,202,245,5,132,78,120,26,97,211,68,232,210,182,115,189,143,221,195,202,121,58,101,72,123,52,67,28,47,46,108,31,39,211,32,60,196,135,195,31,221,218,76,99,234,219,255,104,84,156,199,204,28,9,134,179,220,101,7,125,28,143,141,121,62,231,53,122,247,56,245,233,195,23,112,253,224,119,126,205,208,27,84,141,238,144,180,50,80,171,243,162,21,130,229,109,11,134,104,165,40,145,154,59,69,29,167,121,229,238,80,86,242,143,252,183,187,241,243,207,238,242,23,86,245,251,247,185,250,166,112,125,65,214,243,223,72,58,237,23,81,251,83,62,191,0,21,93,69,91,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("53ae98a2-1434-4e56-92e4-392b7492161e"),
				ContainerUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c0b02be0-7324-41cb-a63d-7302690aac40"),
				ContainerUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,79,193,106,27,49,16,253,21,179,185,90,102,215,43,173,164,189,166,166,4,74,83,18,232,197,248,48,146,102,27,195,238,58,108,228,150,96,12,169,3,45,165,73,63,161,61,246,26,2,38,78,210,244,27,70,127,84,109,10,61,244,48,204,188,199,123,143,121,211,213,129,43,19,43,184,206,204,24,88,5,218,48,206,165,98,70,102,154,85,10,64,107,94,216,20,84,50,220,135,246,8,193,149,190,91,98,15,38,110,238,255,129,23,88,163,199,191,240,120,177,236,44,150,73,158,12,95,118,208,122,140,247,164,57,173,23,231,136,201,240,53,52,17,79,247,232,39,237,194,134,110,194,38,92,13,194,199,240,153,182,97,51,162,31,113,93,208,109,248,74,247,131,112,77,143,180,165,95,113,158,194,102,16,249,45,221,133,75,122,12,87,209,185,11,23,225,50,124,11,95,34,123,63,160,7,250,29,213,189,254,33,124,162,29,237,70,244,61,170,110,251,216,24,255,124,209,83,12,138,201,123,179,100,248,22,234,229,243,35,211,131,179,195,15,45,118,199,246,4,27,40,43,168,207,112,54,138,236,127,196,164,198,6,91,95,174,64,201,212,102,22,153,169,32,101,220,41,195,148,209,25,171,10,33,69,138,198,2,200,117,52,188,129,46,118,245,216,149,43,153,11,41,101,90,69,161,224,140,23,38,101,10,108,193,52,207,116,149,97,174,68,230,122,203,164,245,115,127,190,191,168,151,77,91,174,108,238,198,40,114,96,34,45,198,140,235,60,101,224,192,50,105,141,117,218,229,149,80,118,61,235,203,28,158,98,7,126,190,104,143,230,239,78,252,43,124,143,117,153,140,147,245,236,15,200,175,58,137,225,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("18cdcdbe-2c85-4567-b1d7-3e99a7c2d67a"),
				ContainerUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
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
			var employee2Parameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("c5491b2a-fa9b-4478-b719-f8aa9946c0a8"),
				ContainerUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"Employee2",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			employee2Parameter.SourceValue = new ProcessSchemaParameterValue(employee2Parameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7}].[Parameter:{7357770f-8b54-46b0-8ac6-9419f1e3851d}].[EntityColumn:{c3d2e53a-5062-4930-adac-7cbcd9d3f58c}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(employee2Parameter);
		}

		protected virtual void InitializeGiveRightsToVisaOwnerParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4b5986e6-7044-4e29-9c25-835d23c947d0"),
				ContainerUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
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
				Value = @"bfb313dd-bb55-4e1b-8e42-3d346e0da7c5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e3405dd4-6438-45db-8a22-33f5fa053c32"),
				ContainerUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,75,107,220,48,20,133,255,139,22,93,89,69,26,201,122,184,203,97,90,102,147,134,54,45,133,100,8,122,92,103,4,126,197,146,105,130,153,255,94,121,156,73,33,139,82,186,43,120,33,93,233,28,125,247,112,61,223,135,248,49,52,9,198,170,54,77,132,98,218,251,10,121,193,148,178,214,97,162,173,197,156,50,139,53,103,18,83,171,36,145,27,89,19,97,80,209,153,22,42,180,170,119,62,36,84,132,4,109,172,110,231,223,166,105,156,160,184,175,207,155,175,238,8,173,249,182,60,96,107,203,40,243,30,91,91,150,152,3,181,88,1,223,96,230,25,23,64,188,145,174,68,43,139,149,196,1,211,4,215,74,208,204,194,13,214,37,101,152,106,70,53,213,166,164,58,95,109,160,78,187,167,97,132,24,67,223,85,51,188,174,111,158,135,76,185,190,189,237,155,169,237,80,209,66,50,215,38,29,43,100,128,0,47,157,193,142,235,12,82,131,196,134,105,143,153,177,185,79,5,84,80,137,10,103,134,180,216,162,189,71,133,55,201,124,55,205,4,103,231,57,100,198,13,35,84,149,34,107,41,115,152,179,13,193,74,40,137,107,47,106,13,76,104,109,253,37,175,79,83,200,235,16,175,166,22,198,224,94,98,135,156,95,63,86,179,235,187,52,246,205,98,125,117,190,126,3,79,105,13,247,229,232,199,218,80,202,245,69,132,78,197,20,97,219,4,232,210,174,115,189,15,221,195,234,121,58,101,73,59,152,49,196,75,10,187,199,201,52,168,24,195,195,241,143,105,109,167,152,250,246,63,106,181,200,109,102,143,4,227,25,119,153,65,31,226,208,152,231,243,190,66,239,30,167,62,125,248,2,174,31,253,222,175,59,244,70,85,161,59,36,109,30,110,171,151,161,23,12,115,81,231,105,83,138,96,169,185,83,196,113,34,29,191,67,153,228,31,253,111,247,241,243,207,238,242,47,172,244,135,247,185,250,166,112,125,81,86,243,223,32,157,14,11,212,225,148,191,95,230,55,85,86,210,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var deleteRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe5895d5-2409-461c-8b7f-4db552d8ab2a"),
				ContainerUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(deleteRightsParameter);
			var addRightsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b5c1528f-4e52-4e27-b0ea-b872c51fb27f"),
				ContainerUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,143,193,74,195,64,20,69,127,165,76,183,153,50,105,166,105,50,91,45,82,16,43,45,184,41,89,188,204,188,177,133,36,149,233,84,23,165,80,116,37,21,23,254,130,63,80,4,105,21,193,95,152,252,145,211,234,202,221,185,7,222,227,222,241,178,175,4,209,152,107,208,28,40,143,83,78,185,76,36,5,166,57,77,67,25,170,24,66,137,33,35,193,9,84,67,4,37,172,89,224,33,244,212,212,10,13,197,252,152,78,177,64,139,127,121,52,91,24,137,130,68,36,56,51,80,89,244,60,156,21,72,130,11,40,61,143,155,238,213,125,186,173,219,185,109,125,95,63,53,220,183,135,181,23,95,238,221,139,117,189,105,184,55,183,119,187,122,211,114,47,7,112,123,111,31,234,231,250,209,167,143,102,70,130,43,40,22,199,95,227,254,124,112,87,161,25,201,9,150,240,91,33,107,121,251,79,244,10,44,177,178,98,153,68,177,4,230,247,118,19,237,71,75,63,21,56,79,41,239,68,136,126,126,30,75,181,242,7,151,96,124,93,139,70,44,145,41,213,14,117,78,35,213,9,41,231,152,208,60,233,112,202,144,117,101,18,51,133,60,93,101,135,90,131,27,52,96,167,179,106,56,189,158,216,115,188,197,66,144,54,89,101,63,117,20,13,137,108,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(addRightsParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ce5939bd-eefd-448c-b242-9e8a864e13d1"),
				ContainerUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
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
				UId = new Guid("febfaf4a-4694-4c8c-a0f4-91c1d6a1ce10"),
				ContainerUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			parametrizedElement.Parameters.Add(role1Parameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaInvoiceVisa = CreateInvoiceVisaLaneSet();
			LaneSets.Add(schemaInvoiceVisa);
			ProcessSchemaLane schemaInvoiceAuthor = CreateInvoiceAuthorLane();
			schemaInvoiceVisa.Lanes.Add(schemaInvoiceAuthor);
			ProcessSchemaSubProcess invoicevisasubprocess = CreateInvoiceVisaSubProcessSubProcess();
			FlowElements.Add(invoicevisasubprocess);
			ProcessSchemaStartEvent start = CreateStartStartEvent();
			FlowElements.Add(start);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask inputvisaparameters = CreateInputVisaParametersUserTask();
			FlowElements.Add(inputvisaparameters);
			ProcessSchemaUserTask forbitinvoicechange = CreateForbitInvoiceChangeUserTask();
			FlowElements.Add(forbitinvoicechange);
			ProcessSchemaUserTask readinvoice = CreateReadInvoiceUserTask();
			FlowElements.Add(readinvoice);
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
			ProcessSchemaUserTask giverightstoowner = CreateGiveRightsToOwnerUserTask();
			FlowElements.Add(giverightstoowner);
			ProcessSchemaTerminateEvent terminate3 = CreateTerminate3TerminateEvent();
			FlowElements.Add(terminate3);
			ProcessSchemaUserTask giverightstovisaowner = CreateGiveRightsToVisaOwnerUserTask();
			FlowElements.Add(giverightstovisaowner);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateBodyRejectedLocalizableString());
			LocalizableStrings.Add(CreateSubjectRejectedLocalizableString());
			LocalizableStrings.Add(CreateBodyApprovedLocalizableString());
			LocalizableStrings.Add(CreateSubjectApprovedLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateBodyRejectedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2f319cdd-0193-4bfe-b079-559e1c30124f"),
				Name = "BodyRejected",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSubjectRejectedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("c716efe5-10f7-456c-8133-e895bfdb5be5"),
				Name = "SubjectRejected",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateBodyApprovedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f94f0327-16e1-4334-b02a-7c721653c33b"),
				Name = "BodyApproved",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSubjectApprovedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("cf129e95-c580-4e13-82b0-7a76b2bcadf1"),
				Name = "SubjectApproved",
				CreatedInPackageId = new Guid("713adf76-4da1-47f0-97e7-6f284e391ea9"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243")
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(245, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(312, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("c109c02d-a7a5-43a6-85e7-7de3f50014f7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(428, 142),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(446, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(446, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(618, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("60239cd9-2e10-49bd-a633-089150c684f8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("2f16f1ec-3288-4324-af70-83a2b722a56f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(618, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d69e54c-2a2f-4d7c-8fee-7e2cc579b767"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("50c11efd-97ee-4cff-9eb8-aab3aacded01"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(618, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("9b782f6a-2b01-4398-babd-ec7161a1522d"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{542e8d6c-f4fa-4b4e-983a-9c865c132053}].[Parameter:{8f1116ee-11da-40ee-bb56-440bdf99b269}]#] == ""Approved""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(694, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("63ea368e-bf20-4fc5-a69f-5863c7bd43bb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("5316b598-2325-4f50-b2fd-af4afa22b081"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(714, 176),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("492364f3-9bfa-4554-b2f6-c86157c2f9e8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("0238eb90-0358-427e-b744-d6728b80e5fe"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{542e8d6c-f4fa-4b4e-983a-9c865c132053}].[Parameter:{8f1116ee-11da-40ee-bb56-440bdf99b269}]#]==""Rejected""",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(707, 102),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9e242f5f-62c8-4d23-b0b3-1f425b446b41"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("a25bf005-7191-430f-9e93-18b59af48bb5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db5558b0-2d71-4fc8-90f8-eaabbf477ee7"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				CurveCenterPosition = new Point(428, 142),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateInvoiceVisaLaneSet() {
			ProcessSchemaLaneSet schemaInvoiceVisa = new ProcessSchemaLaneSet(this) {
				UId = new Guid("03fb0d25-b184-4f90-913b-f93ec8ee15fe"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"InvoiceVisa",
				Position = new Point(5, 5),
				Size = new Size(1412, 400),
				UseBackgroundMode = false
			};
			return schemaInvoiceVisa;
		}

		protected virtual ProcessSchemaLane CreateInvoiceAuthorLane() {
			ProcessSchemaLane schemaInvoiceAuthor = new ProcessSchemaLane(this) {
				UId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("03fb0d25-b184-4f90-913b-f93ec8ee15fe"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"InvoiceAuthor",
				Position = new Point(29, 0),
				Size = new Size(1383, 400),
				UseBackgroundMode = false
			};
			return schemaInvoiceAuthor;
		}

		protected virtual ProcessSchemaStartEvent CreateStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("e046d5ca-5771-47ed-b113-a5824ad25bc6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"Start",
				Position = new Point(57, 170),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"Terminate1",
				Position = new Point(1324, 170),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"InputVisaParameters",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(127, 156),
				SchemaUId = new Guid("b5936328-09b2-45fd-b763-48d37c265644"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeInputVisaParametersParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateForbitInvoiceChangeUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"ForbitInvoiceChange",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(484, 156),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeForbitInvoiceChangeParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadInvoiceUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a870c1ce-bfa0-4d8b-8b91-f65750ebcaa7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"ReadInvoice",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(260, 156),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadInvoiceParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateSendEmailToOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a4f303ab-3ca4-40cf-bd61-6c4b651a7584"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ed1b5d86-de48-4aad-b58a-ff58e682dbe0"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b749e6e7-cde4-4a2e-ade0-0b8cf36b0926"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"SendEmailToOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1198, 156),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"ReadOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(365, 156),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"EmailBodyVisaApproved",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(974, 156),
				ResultParameterMetaPath = @"74993b60-74e2-40cb-9814-23ff874d9202",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,106,195,48,16,128,225,87,41,100,105,33,23,36,71,210,201,222,154,144,64,167,22,58,6,15,39,233,212,6,44,57,200,74,74,48,121,247,186,107,215,159,255,155,106,57,231,175,205,113,44,137,234,243,110,12,247,215,203,165,140,55,14,235,167,211,234,244,54,189,255,100,46,159,254,155,19,117,145,134,137,251,205,82,255,133,195,192,137,115,237,102,178,40,188,244,12,46,146,0,21,172,3,235,90,9,209,104,212,130,157,39,194,199,2,62,168,80,226,202,165,155,113,171,17,81,196,101,212,10,148,113,2,44,121,3,173,146,109,148,188,181,90,134,63,114,200,245,92,239,251,113,184,166,220,205,49,4,68,178,13,68,106,52,40,191,248,86,5,3,218,248,40,26,173,116,35,227,163,95,245,47,191,47,228,82,128,225,0,0,0 }
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"EmailBodyVisaRejected",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(862, 30),
				ResultParameterMetaPath = @"74993b60-74e2-40cb-9814-23ff874d9202",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,193,74,196,48,16,128,225,87,17,246,162,224,44,73,55,201,164,61,42,43,120,82,244,184,244,48,73,102,116,165,73,33,141,200,82,246,221,173,87,175,63,255,183,180,122,46,31,251,167,185,102,106,183,15,115,186,188,241,23,199,198,233,254,230,180,59,61,47,47,63,133,235,123,252,228,76,131,208,180,240,184,223,234,191,112,156,56,115,105,195,74,30,85,212,145,33,8,41,48,201,7,240,161,215,32,206,162,85,28,34,17,94,55,240,74,149,50,55,174,195,138,7,139,136,74,182,209,26,48,46,40,240,20,29,244,70,247,162,249,224,173,78,127,228,88,218,185,93,30,231,233,59,151,97,149,148,16,201,119,32,212,89,48,113,243,189,73,14,172,139,162,58,107,108,167,229,58,238,198,187,95,218,83,132,42,225,0,0,0 }
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"EmailSubjectVisaApproved",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1086, 156),
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
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"EmailSubjectVisaRejected",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(974, 30),
				ResultParameterMetaPath = @"3cb8a4b7-f45b-44ff-b96d-91b115085a87",
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,46,77,202,74,77,46,9,74,5,145,169,41,0,18,77,35,34,15,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateGiveRightsToOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"GiveRightsToOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1086, 30),
				SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeGiveRightsToOwnerParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaSubProcess CreateInvoiceVisaSubProcessSubProcess() {
			ProcessSchemaSubProcess schemaInvoiceVisaSubProcess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"SubProcess",
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"InvoiceVisaSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(757, 156),
				SchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c"),
				SerializeToDB = true,
				Size = new Size(70, 56),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeInvoiceVisaSubProcessParameters(schemaInvoiceVisaSubProcess);
			return schemaInvoiceVisaSubProcess;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate3TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("492364f3-9bfa-4554-b2f6-c86157c2f9e8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8b83e365-44e9-4039-b573-f0156747e76b"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"Terminate3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(778, 296),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateGiveRightsToVisaOwnerUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6f0e3dff-cc26-4371-b613-19572ae3e120"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db5558b0-2d71-4fc8-90f8-eaabbf477ee7"),
				CreatedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081"),
				ModifiedInSchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"),
				Name = @"GiveRightsToVisaOwner",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(610, 156),
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
			return new InvoiceVisaProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceVisaProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceVisaProcess

	/// <exclude/>
	public class InvoiceVisaProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessInvoiceAuthor

		/// <exclude/>
		public class ProcessInvoiceAuthor : ProcessLane
		{

			public ProcessInvoiceAuthor(UserConnection userConnection, InvoiceVisaProcess process)
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

			public InputVisaParametersFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "InputVisaParameters";
				IsLogging = true;
				SchemaElementUId = new Guid("836ca04a-78fa-4cf4-a449-453ee4c8b6cd");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.InvoiceAuthor;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("332eac2514434e4ea9726c0e66cb9243",
						 "BaseElements.InputVisaParameters.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private LocalizableString _buttons;
			public override LocalizableString Buttons {
				get {
					return _buttons ?? (_buttons = GetLocalizableString("332eac2514434e4ea9726c0e66cb9243",
						 "BaseElements.InputVisaParameters.Parameters.Buttons.Value"));
				}
				set {
					_buttons = value;
				}
			}

			private LocalizableString _elements;
			public override LocalizableString Elements {
				get {
					return _elements ?? (_elements = GetLocalizableString("332eac2514434e4ea9726c0e66cb9243",
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

		#region Class: ForbitInvoiceChangeFlowElement

		/// <exclude/>
		public class ForbitInvoiceChangeFlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public ForbitInvoiceChangeFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ForbitInvoiceChange";
				IsLogging = true;
				SchemaElementUId = new Guid("35a81948-7702-4db3-a7bf-3f258a365e3b");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,217,146,45,217,61,46,219,178,151,52,180,105,41,36,75,24,75,163,172,192,31,27,75,166,9,102,255,123,229,117,54,133,28,74,233,173,160,195,204,104,222,155,55,15,105,190,247,225,163,111,35,142,181,131,54,32,157,118,182,38,216,128,70,5,154,65,197,57,147,32,115,6,90,24,134,96,139,44,203,51,165,180,38,180,135,14,107,178,162,183,214,71,66,125,196,46,212,183,243,111,210,56,78,72,239,221,57,249,106,14,216,193,183,101,64,227,26,145,9,107,89,211,20,5,147,152,53,76,99,154,34,172,144,37,114,11,202,20,100,213,82,42,225,56,55,142,85,210,165,86,153,33,131,162,228,172,40,65,229,206,84,182,112,142,208,22,93,220,62,29,71,12,193,15,125,61,227,107,124,243,124,76,42,215,217,155,161,157,186,158,208,14,35,92,67,60,212,4,144,163,44,12,48,35,171,196,238,80,49,16,149,101,2,26,149,43,141,89,153,41,66,13,28,227,66,75,118,150,80,11,17,190,67,59,225,153,121,246,73,99,46,120,166,139,50,97,179,228,146,20,57,103,186,212,138,57,91,186,10,69,89,85,141,189,248,245,105,242,41,246,225,106,234,112,244,230,197,118,76,254,13,99,61,155,161,143,227,208,46,212,87,231,246,27,124,138,171,185,47,87,63,214,133,98,170,47,32,114,162,83,192,77,235,177,143,219,222,12,214,247,15,43,231,233,148,32,221,17,70,31,46,46,108,31,39,104,9,29,253,195,225,143,110,109,166,16,135,238,63,90,149,166,53,19,71,196,241,44,119,121,131,214,135,99,11,207,231,188,38,239,30,167,33,126,248,130,102,24,237,206,174,25,121,131,170,201,29,81,141,114,188,169,26,38,179,82,48,89,58,96,149,214,156,169,74,26,205,141,228,202,200,59,146,148,252,35,255,237,46,124,254,217,95,254,194,170,126,255,62,85,223,20,174,47,200,122,254,27,73,167,253,34,106,127,74,231,23,218,18,108,245,210,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _deleteRights;
			public override string DeleteRights {
				get {
					return _deleteRights ?? (_deleteRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,139,174,246,76,177,82,50,182,72,74,51,51,78,74,209,77,52,50,179,208,53,73,75,49,213,77,76,78,4,178,76,44,146,13,12,82,45,76,76,210,18,149,116,156,19,243,130,82,19,83,172,210,18,115,138,83,65,60,215,148,204,18,171,146,162,82,48,199,37,53,39,181,36,21,194,13,206,47,45,74,78,181,82,50,84,210,113,47,74,204,43,73,5,178,29,115,114,130,242,115,82,139,29,243,82,66,139,83,139,138,149,116,252,18,115,129,226,23,38,93,108,188,176,85,225,98,195,133,125,23,118,95,216,161,0,66,251,65,236,139,61,23,182,3,233,77,23,54,92,108,186,176,21,36,167,84,27,11,0,246,20,105,89,176,0,0,0 })));
				}
				set {
					_deleteRights = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadInvoiceFlowElement

		/// <exclude/>
		public class ReadInvoiceFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadInvoiceFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadInvoice";
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,77,107,220,48,16,134,255,139,14,61,89,197,182,100,75,118,143,203,182,236,37,13,109,90,10,201,18,244,49,147,21,248,43,150,76,19,140,255,123,229,117,54,133,28,74,233,173,224,131,102,236,247,157,103,94,228,249,222,249,143,174,9,48,214,168,26,15,201,116,176,53,169,16,11,212,136,52,71,97,40,47,165,166,90,27,164,74,20,178,64,196,210,170,148,36,157,106,161,38,155,122,111,93,32,137,11,208,250,250,118,254,109,26,198,9,146,123,60,23,95,205,9,90,245,109,29,160,81,179,140,89,27,109,139,130,114,200,52,149,192,115,202,44,227,37,164,86,9,83,144,141,69,11,198,202,170,224,20,36,90,202,109,142,84,231,134,211,220,128,177,156,153,220,72,75,146,6,48,236,159,134,17,188,119,125,87,207,240,122,190,121,30,34,229,54,123,215,55,83,219,145,164,133,160,174,85,56,213,68,65,10,188,48,138,26,94,69,16,4,65,21,171,44,101,74,139,92,72,200,202,76,144,196,168,33,172,182,228,16,71,89,21,212,119,213,76,112,118,158,93,100,204,89,154,201,162,140,218,140,197,188,88,158,82,89,74,65,209,150,88,65,196,175,180,189,228,245,105,114,241,236,252,213,212,194,232,204,75,236,16,243,235,199,122,54,125,23,198,190,89,173,175,206,159,223,192,83,216,194,125,121,245,99,91,40,196,254,42,34,75,50,121,216,53,14,186,176,239,76,111,93,247,176,121,46,75,148,180,131,26,157,191,164,176,127,156,84,67,146,209,61,156,254,152,214,110,242,161,111,255,163,85,147,184,102,244,8,48,158,113,215,59,104,157,31,26,245,124,174,107,242,238,113,234,195,135,47,96,250,209,30,236,86,145,55,170,154,220,17,161,5,166,186,210,148,103,37,139,55,31,21,173,164,76,169,168,184,145,169,225,169,48,252,142,68,146,127,244,191,61,248,207,63,187,203,191,176,209,31,223,199,238,155,198,245,69,89,207,127,131,180,28,87,168,227,18,159,95,36,175,107,249,210,3,0,0 })));
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

			private string _aggregationColumnName;
			public override string AggregationColumnName {
				get {
					return _aggregationColumnName ?? (_aggregationColumnName = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,1,0,242,67,189,42,2,0,0,0 })));
				}
				set {
					_aggregationColumnName = value;
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
								new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"));
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

			public SendEmailToOwnerFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
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

			public ReadOwnerFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,205,106,220,48,16,126,149,69,135,158,172,197,242,159,36,247,24,182,37,151,52,208,180,20,146,16,100,73,78,12,254,217,216,50,77,88,22,210,4,90,74,211,62,66,123,236,181,4,66,55,73,211,103,144,223,168,227,117,182,133,28,74,174,1,27,143,70,243,125,51,250,60,163,217,94,214,60,203,114,163,235,56,21,121,163,157,118,93,197,136,177,148,105,198,93,204,18,146,224,32,114,57,88,220,195,158,203,18,234,42,26,185,65,138,156,82,20,58,70,3,122,162,50,131,156,204,232,162,137,183,103,255,72,77,221,106,103,47,93,46,94,202,3,93,136,87,125,2,18,37,218,143,66,130,89,170,61,28,144,16,18,40,229,98,193,92,95,5,17,243,149,242,209,80,139,167,53,9,93,230,97,170,57,199,65,170,53,230,132,112,44,61,158,4,73,64,189,52,74,144,147,235,212,76,142,166,181,110,154,172,42,227,153,254,107,111,29,79,161,202,33,247,90,149,183,69,137,156,66,27,177,41,204,65,140,132,118,117,16,74,129,101,192,195,158,157,98,225,115,133,125,145,80,143,50,77,34,66,145,35,197,212,244,180,104,93,33,71,9,35,94,139,188,213,75,230,89,214,215,232,187,132,133,17,96,137,47,113,224,123,160,92,196,40,78,85,148,114,56,40,231,137,90,233,245,188,205,192,206,154,141,182,208,117,38,239,100,215,160,95,85,199,51,89,149,166,174,242,158,122,99,25,190,165,143,204,32,238,221,214,155,225,64,6,252,61,8,205,157,182,209,107,121,166,75,51,41,101,165,178,114,127,224,156,207,1,82,76,69,157,53,43,21,38,135,173,200,145,83,103,251,7,255,85,107,173,109,76,85,60,162,163,58,112,76,224,128,38,91,150,219,247,160,202,154,105,46,142,151,235,24,61,57,108,43,243,212,126,183,139,238,212,254,232,78,187,243,81,247,174,251,96,47,187,211,177,253,6,159,19,123,209,125,178,87,163,238,179,189,177,151,246,23,188,183,221,233,8,252,151,246,103,119,102,111,186,115,64,46,186,147,238,172,251,210,125,4,239,213,200,94,219,223,16,221,199,95,119,239,237,194,46,198,246,43,68,93,244,180,64,191,180,236,45,16,1,243,80,1,186,87,105,140,118,144,96,212,149,68,106,156,164,194,197,129,98,73,63,109,4,167,81,72,67,87,39,82,8,58,166,126,72,41,117,83,216,10,3,24,201,4,116,23,50,194,60,32,60,37,218,103,33,81,99,233,43,79,135,190,192,161,27,193,88,113,31,38,74,9,137,169,76,164,226,202,79,67,38,119,16,232,248,136,212,217,94,111,94,188,45,87,183,199,240,191,119,199,224,189,231,152,228,186,128,198,136,103,15,145,115,14,128,205,85,170,120,246,16,113,123,200,164,52,153,57,30,110,17,104,224,7,168,61,223,237,245,222,157,195,243,7,77,254,130,103,107,5,0,0 })));
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

		#region Class: GiveRightsToOwnerFlowElement

		/// <exclude/>
		public class GiveRightsToOwnerFlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public GiveRightsToOwnerFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GiveRightsToOwner";
				IsLogging = true;
				SchemaElementUId = new Guid("861a907f-8d89-4961-a75c-b5ea8d15568d");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_employee2 = () => (Guid)(((process.ReadInvoice.ResultEntity.IsColumnValueLoaded(process.ReadInvoice.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadInvoice.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,47,58,244,36,21,217,146,245,225,30,151,109,217,75,26,218,180,20,146,37,232,99,148,21,248,99,99,203,52,193,236,127,175,188,206,166,144,67,41,189,21,116,152,25,205,123,122,243,24,205,247,113,252,24,155,4,67,29,76,51,2,158,118,190,70,166,244,37,19,178,34,76,128,32,156,243,130,232,146,75,2,146,105,85,81,102,33,112,132,59,211,66,141,86,244,214,199,132,112,76,208,142,245,237,252,155,52,13,19,224,251,112,78,190,186,3,180,230,219,242,128,13,150,21,204,123,98,109,85,17,14,133,37,10,120,73,152,103,92,0,245,70,186,10,173,90,172,161,249,90,1,145,62,119,113,65,43,162,105,165,137,84,74,72,199,101,0,160,8,55,16,210,246,233,56,192,56,198,190,171,103,120,141,111,158,143,89,229,250,246,166,111,166,182,67,184,133,100,174,77,58,228,73,129,2,175,156,33,142,235,44,36,128,36,134,105,79,152,177,178,148,10,10,81,72,132,157,57,166,133,22,237,60,194,222,36,243,221,52,19,156,153,231,152,53,150,140,22,170,18,25,91,48,71,56,43,41,81,66,73,18,188,8,26,152,208,218,250,139,95,159,166,152,227,56,94,77,45,12,209,189,216,14,217,191,126,168,103,215,119,105,232,155,133,250,234,220,126,3,79,105,53,247,229,234,199,58,80,202,245,5,132,78,120,26,97,211,68,232,210,182,115,189,143,221,195,202,121,58,101,72,123,52,67,28,47,46,108,31,39,211,32,60,196,135,195,31,221,218,76,99,234,219,255,104,84,156,199,204,28,9,134,179,220,101,7,125,28,143,141,121,62,231,53,122,247,56,245,233,195,23,112,253,224,119,126,205,208,27,84,141,238,144,180,50,80,171,243,162,21,130,229,109,11,134,104,165,40,145,154,59,69,29,167,121,229,238,80,86,242,143,252,183,187,241,243,207,238,242,23,86,245,251,247,185,250,166,112,125,65,214,243,223,72,58,237,23,81,251,83,62,191,0,21,93,69,91,210,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,79,193,106,27,49,16,253,21,179,185,90,102,215,43,173,164,189,166,166,4,74,83,18,232,197,248,48,146,102,27,195,238,58,108,228,150,96,12,169,3,45,165,73,63,161,61,246,26,2,38,78,210,244,27,70,127,84,109,10,61,244,48,204,188,199,123,143,121,211,213,129,43,19,43,184,206,204,24,88,5,218,48,206,165,98,70,102,154,85,10,64,107,94,216,20,84,50,220,135,246,8,193,149,190,91,98,15,38,110,238,255,129,23,88,163,199,191,240,120,177,236,44,150,73,158,12,95,118,208,122,140,247,164,57,173,23,231,136,201,240,53,52,17,79,247,232,39,237,194,134,110,194,38,92,13,194,199,240,153,182,97,51,162,31,113,93,208,109,248,74,247,131,112,77,143,180,165,95,113,158,194,102,16,249,45,221,133,75,122,12,87,209,185,11,23,225,50,124,11,95,34,123,63,160,7,250,29,213,189,254,33,124,162,29,237,70,244,61,170,110,251,216,24,255,124,209,83,12,138,201,123,179,100,248,22,234,229,243,35,211,131,179,195,15,45,118,199,246,4,27,40,43,168,207,112,54,138,236,127,196,164,198,6,91,95,174,64,201,212,102,22,153,169,32,101,220,41,195,148,209,25,171,10,33,69,138,198,2,200,117,52,188,129,46,118,245,216,149,43,153,11,41,101,90,69,161,224,140,23,38,101,10,108,193,52,207,116,149,97,174,68,230,122,203,164,245,115,127,190,191,168,151,77,91,174,108,238,198,40,114,96,34,45,198,140,235,60,101,224,192,50,105,141,117,218,229,149,80,118,61,235,203,28,158,98,7,126,190,104,143,230,239,78,252,43,124,143,117,153,140,147,245,236,15,200,175,58,137,225,1,0,0 })));
				}
				set {
					_addRights = value;
				}
			}

			internal Func<Guid> _employee2;
			public virtual Guid Employee2 {
				get {
					return (_employee2 ?? (_employee2 = () => Guid.Empty)).Invoke();
				}
				set {
					_employee2 = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: InvoiceVisaSubProcessFlowElement

		/// <exclude/>
		public class InvoiceVisaSubProcessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public InvoiceVisaSubProcessFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("09e20650-fdc8-4209-9589-e4895ac21b3c");
			}

			#endregion

			#region Properties: Public

			public Guid Invoice {
				get {
					return GetParameterValue<Guid>("Invoice");
				}
				set {
					SetParameterValue("Invoice", value);
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
				var process = (InvoiceVisaProcess)owner;
				Name = "InvoiceVisaSubProcess";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("542e8d6c-f4fa-4b4e-983a-9c865c132053");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.InvoiceAuthor;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (InvoiceVisaProcess)Owner;
				SetParameterValue("Invoice", (Guid)((process.RecordId)));
				SetParameterValue("VisaOwner", (Guid)((process.InputVisaParameters.VisaOwner)));
				SetParameterValue("VisaObjective", new LocalizableString((process.InputVisaParameters.Objective)));
				SetParameterValue("IsAllowedToDelegate", (bool)((process.InputVisaParameters.IsAllowedToDelegate)));
				SetParameterValue("IsPreviousVisaCounts", (bool)(false));
			}

			#endregion

		}

		#endregion

		#region Class: GiveRightsToVisaOwnerFlowElement

		/// <exclude/>
		public class GiveRightsToVisaOwnerFlowElement : ChangeAdminRightsUserTask
		{

			#region Constructors: Public

			public GiveRightsToVisaOwnerFlowElement(UserConnection userConnection, InvoiceVisaProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GiveRightsToVisaOwner";
				IsLogging = true;
				SchemaElementUId = new Guid("7c567273-cb10-4531-ace7-344acf45ce1b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_role1 = () => (Guid)((process.InputVisaParameters.VisaOwner));
			}

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,75,107,220,48,20,133,255,139,22,93,89,69,26,201,122,184,203,97,90,102,147,134,54,45,133,100,8,122,92,103,4,126,197,146,105,130,153,255,94,121,156,73,33,139,82,186,43,120,33,93,233,28,125,247,112,61,223,135,248,49,52,9,198,170,54,77,132,98,218,251,10,121,193,148,178,214,97,162,173,197,156,50,139,53,103,18,83,171,36,145,27,89,19,97,80,209,153,22,42,180,170,119,62,36,84,132,4,109,172,110,231,223,166,105,156,160,184,175,207,155,175,238,8,173,249,182,60,96,107,203,40,243,30,91,91,150,152,3,181,88,1,223,96,230,25,23,64,188,145,174,68,43,139,149,196,1,211,4,215,74,208,204,194,13,214,37,101,152,106,70,53,213,166,164,58,95,109,160,78,187,167,97,132,24,67,223,85,51,188,174,111,158,135,76,185,190,189,237,155,169,237,80,209,66,50,215,38,29,43,100,128,0,47,157,193,142,235,12,82,131,196,134,105,143,153,177,185,79,5,84,80,137,10,103,134,180,216,162,189,71,133,55,201,124,55,205,4,103,231,57,100,198,13,35,84,149,34,107,41,115,152,179,13,193,74,40,137,107,47,106,13,76,104,109,253,37,175,79,83,200,235,16,175,166,22,198,224,94,98,135,156,95,63,86,179,235,187,52,246,205,98,125,117,190,126,3,79,105,13,247,229,232,199,218,80,202,245,69,132,78,197,20,97,219,4,232,210,174,115,189,15,221,195,234,121,58,101,73,59,152,49,196,75,10,187,199,201,52,168,24,195,195,241,143,105,109,167,152,250,246,63,106,181,200,109,102,143,4,227,25,119,153,65,31,226,208,152,231,243,190,66,239,30,167,62,125,248,2,174,31,253,222,175,59,244,70,85,161,59,36,109,30,110,171,151,161,23,12,115,81,231,105,83,138,96,169,185,83,196,113,34,29,191,67,153,228,31,253,111,247,241,243,207,238,242,47,172,244,135,247,185,250,166,112,125,81,86,243,223,32,157,14,11,212,225,148,191,95,230,55,85,86,210,3,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private string _addRights;
			public override string AddRights {
				get {
					return _addRights ?? (_addRights = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,93,143,193,74,195,64,20,69,127,165,76,183,153,50,105,166,105,50,91,45,82,16,43,45,184,41,89,188,204,188,177,133,36,149,233,84,23,165,80,116,37,21,23,254,130,63,80,4,105,21,193,95,152,252,145,211,234,202,221,185,7,222,227,222,241,178,175,4,209,152,107,208,28,40,143,83,78,185,76,36,5,166,57,77,67,25,170,24,66,137,33,35,193,9,84,67,4,37,172,89,224,33,244,212,212,10,13,197,252,152,78,177,64,139,127,121,52,91,24,137,130,68,36,56,51,80,89,244,60,156,21,72,130,11,40,61,143,155,238,213,125,186,173,219,185,109,125,95,63,53,220,183,135,181,23,95,238,221,139,117,189,105,184,55,183,119,187,122,211,114,47,7,112,123,111,31,234,231,250,209,167,143,102,70,130,43,40,22,199,95,227,254,124,112,87,161,25,201,9,150,240,91,33,107,121,251,79,244,10,44,177,178,98,153,68,177,4,230,247,118,19,237,71,75,63,21,56,79,41,239,68,136,126,126,30,75,181,242,7,151,96,124,93,139,70,44,145,41,213,14,117,78,35,213,9,41,231,152,208,60,233,112,202,144,117,101,18,51,133,60,93,101,135,90,131,27,52,96,167,179,106,56,189,158,216,115,188,197,66,144,54,89,101,63,117,20,13,137,108,1,0,0 })));
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

		public InvoiceVisaProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceVisaProcess";
			SchemaUId = new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243");
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
				return new Guid("332eac25-1443-4e4e-a972-6c0e66cb9243");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: InvoiceVisaProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: InvoiceVisaProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private ProcessInvoiceAuthor _invoiceAuthor;
		public ProcessInvoiceAuthor InvoiceAuthor {
			get {
				return _invoiceAuthor ?? ((_invoiceAuthor) = new ProcessInvoiceAuthor(UserConnection, this));
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

		private ForbitInvoiceChangeFlowElement _forbitInvoiceChange;
		public ForbitInvoiceChangeFlowElement ForbitInvoiceChange {
			get {
				return _forbitInvoiceChange ?? (_forbitInvoiceChange = new ForbitInvoiceChangeFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadInvoiceFlowElement _readInvoice;
		public ReadInvoiceFlowElement ReadInvoice {
			get {
				return _readInvoice ?? (_readInvoice = new ReadInvoiceFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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

		private GiveRightsToOwnerFlowElement _giveRightsToOwner;
		public GiveRightsToOwnerFlowElement GiveRightsToOwner {
			get {
				return _giveRightsToOwner ?? (_giveRightsToOwner = new GiveRightsToOwnerFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private InvoiceVisaSubProcessFlowElement _invoiceVisaSubProcess;
		public InvoiceVisaSubProcessFlowElement InvoiceVisaSubProcess {
			get {
				return _invoiceVisaSubProcess ?? ((_invoiceVisaSubProcess) = new InvoiceVisaSubProcessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("492364f3-9bfa-4554-b2f6-c86157c2f9e8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
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

		private ProcessConditionalFlow _conditionalFlow4;
		public ProcessConditionalFlow ConditionalFlow4 {
			get {
				return _conditionalFlow4 ?? (_conditionalFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow4",
					SchemaElementUId = new Guid("9b782f6a-2b01-4398-babd-ec7161a1522d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
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
					SchemaElementUId = new Guid("0238eb90-0358-427e-b744-d6728b80e5fe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _giveRightsToVisaOwnerInvoiceVisaSubProcessToken;
		public ProcessToken GiveRightsToVisaOwnerInvoiceVisaSubProcessToken {
			get {
				return _giveRightsToVisaOwnerInvoiceVisaSubProcessToken ?? (_giveRightsToVisaOwnerInvoiceVisaSubProcessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "GiveRightsToVisaOwnerInvoiceVisaSubProcessToken",
					SchemaElementUId = new Guid("dce0b146-c897-4928-a5d2-33f37941956e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private LocalizableString _bodyRejected;
		public LocalizableString BodyRejected {
			get {
				return _bodyRejected ?? (_bodyRejected = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.BodyRejected.Value"));
			}
		}

		private LocalizableString _subjectRejected;
		public LocalizableString SubjectRejected {
			get {
				return _subjectRejected ?? (_subjectRejected = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.SubjectRejected.Value"));
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
			FlowElements[ForbitInvoiceChange.SchemaElementUId] = new Collection<ProcessFlowElement> { ForbitInvoiceChange };
			FlowElements[ReadInvoice.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadInvoice };
			FlowElements[SendEmailToOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailToOwner };
			FlowElements[ReadOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadOwner };
			FlowElements[EmailBodyVisaApproved.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailBodyVisaApproved };
			FlowElements[EmailBodyVisaRejected.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailBodyVisaRejected };
			FlowElements[EmailSubjectVisaApproved.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailSubjectVisaApproved };
			FlowElements[EmailSubjectVisaRejected.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailSubjectVisaRejected };
			FlowElements[GiveRightsToOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { GiveRightsToOwner };
			FlowElements[InvoiceVisaSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceVisaSubProcess };
			FlowElements[Terminate3.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate3 };
			FlowElements[GiveRightsToVisaOwner.SchemaElementUId] = new Collection<ProcessFlowElement> { GiveRightsToVisaOwner };
			FlowElements[GiveRightsToVisaOwnerInvoiceVisaSubProcessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { GiveRightsToVisaOwnerInvoiceVisaSubProcessToken };
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
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadInvoice", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "InputVisaParameters");
						break;
					case "ForbitInvoiceChange":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GiveRightsToVisaOwner", e.Context.SenderName));
						break;
					case "ReadInvoice":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadOwner", e.Context.SenderName));
						break;
					case "SendEmailToOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ForbitInvoiceChange", e.Context.SenderName));
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
					case "GiveRightsToOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailToOwner", e.Context.SenderName));
						break;
					case "InvoiceVisaSubProcess":
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailBodyVisaApproved", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EmailBodyVisaRejected", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate3", e.Context.SenderName));
						break;
					case "Terminate3":
						CompleteProcess();
						break;
					case "GiveRightsToVisaOwner":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GiveRightsToVisaOwnerInvoiceVisaSubProcessToken", e.Context.SenderName));
						break;
					case "GiveRightsToVisaOwnerInvoiceVisaSubProcessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InvoiceVisaSubProcess", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = InputVisaParameters.PressedButtonCode == @"ButtonOk";
			Log.InfoFormat(ConditionalExpressionLogMessage, "InputVisaParameters", "ConditionalFlow2", "InputVisaParameters.PressedButtonCode == @\"ButtonOk\"", result);
			Log.Info($"InputVisaParameters.PressedButtonCode: {InputVisaParameters.PressedButtonCode}");
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean((InvoiceVisaSubProcess.VisaResult) == "Approved");
			Log.InfoFormat(ConditionalExpressionLogMessage, "InvoiceVisaSubProcess", "ConditionalFlow4", "(InvoiceVisaSubProcess.VisaResult) == \"Approved\"", result);
			return result;
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((InvoiceVisaSubProcess.VisaResult)=="Rejected");
			Log.InfoFormat(ConditionalExpressionLogMessage, "InvoiceVisaSubProcess", "ConditionalFlow1", "(InvoiceVisaSubProcess.VisaResult)==\"Rejected\"", result);
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
			if (!HasMapping("GiveRightsToOwner.Employee2")) {
				writer.WriteValue("GiveRightsToOwner.Employee2", GiveRightsToOwner.Employee2, Guid.Empty);
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
			MetaPathParameterValues.Add("6fda6d18-1dcb-4cdc-beb8-3d93131256a5", () => InputVisaParameters.Recommendation);
			MetaPathParameterValues.Add("af3a440c-346a-45ea-b989-ad9edad884e9", () => InputVisaParameters.EntityId);
			MetaPathParameterValues.Add("64a3cca3-4c10-4274-aef0-5a1ef5d6712f", () => InputVisaParameters.Buttons);
			MetaPathParameterValues.Add("67d2763d-f0c5-4de5-be15-11bb62ecf373", () => InputVisaParameters.Elements);
			MetaPathParameterValues.Add("05607c13-cca8-4ff4-9db7-ca1b00e9d924", () => InputVisaParameters.ExtendedClientModule);
			MetaPathParameterValues.Add("2c1c4abc-e8a6-48a5-bc00-7f05f8db1732", () => InputVisaParameters.EntryPointId);
			MetaPathParameterValues.Add("d649bbc1-42b3-4dd3-b3f4-288751672e90", () => InputVisaParameters.PressedButtonCode);
			MetaPathParameterValues.Add("c36b3fbb-0cda-4054-9d6c-3f2764a2a299", () => InputVisaParameters.OwnerId);
			MetaPathParameterValues.Add("2f5005e0-98ac-49c4-95a3-093aed380ddb", () => InputVisaParameters.ShowExecutionPage);
			MetaPathParameterValues.Add("f789c4c3-1f20-4baa-9abc-19ae652beb7b", () => InputVisaParameters.InformationOnStep);
			MetaPathParameterValues.Add("2a68b2b8-60a8-47eb-873f-949b07b7200c", () => InputVisaParameters.IsRunning);
			MetaPathParameterValues.Add("37eb257f-2cfd-4531-b15a-d9090b85bad6", () => InputVisaParameters.CurrentActivityId);
			MetaPathParameterValues.Add("282a01b7-5914-4764-ac43-fb8cad39d9d5", () => InputVisaParameters.CreateActivity);
			MetaPathParameterValues.Add("049df9a1-60f7-4a91-9c90-86422972da2d", () => InputVisaParameters.ActivityPriority);
			MetaPathParameterValues.Add("467725db-47dc-44f0-9ac6-ec37517fc378", () => InputVisaParameters.StartIn);
			MetaPathParameterValues.Add("34990377-9bbb-4062-9c9a-44da28f6407f", () => InputVisaParameters.StartInPeriod);
			MetaPathParameterValues.Add("ab80c556-bb27-4f9d-8309-097c7f88a301", () => InputVisaParameters.Duration);
			MetaPathParameterValues.Add("be924ba0-8330-41b9-b472-382b3f3afb92", () => InputVisaParameters.DurationPeriod);
			MetaPathParameterValues.Add("2d52e611-dcaa-498d-9936-d29a38cc3db9", () => InputVisaParameters.ShowInScheduler);
			MetaPathParameterValues.Add("d1ecf2b7-b798-457f-8d1e-09fc1c77197e", () => InputVisaParameters.RemindBefore);
			MetaPathParameterValues.Add("188ed528-ca0a-4414-a322-b793bea50c08", () => InputVisaParameters.RemindBeforePeriod);
			MetaPathParameterValues.Add("22b3b17e-548d-4197-ac38-babf7d6b2014", () => InputVisaParameters.ActivityResult);
			MetaPathParameterValues.Add("36bdffa9-5a67-4811-b992-8a08dc04092b", () => InputVisaParameters.IsActivityCompleted);
			MetaPathParameterValues.Add("e0dd21fb-3d51-44e8-b854-0e07c860de49", () => InputVisaParameters.VisaOwner);
			MetaPathParameterValues.Add("4e06d591-5e64-4ada-8d8c-ecc485ed6411", () => InputVisaParameters.Objective);
			MetaPathParameterValues.Add("e4157d41-c7c0-423c-90ea-9b31a9527bea", () => InputVisaParameters.IsAllowedToDelegate);
			MetaPathParameterValues.Add("6410dd64-cb18-4b43-92d8-ea4e92452489", () => ForbitInvoiceChange.EntitySchemaUId);
			MetaPathParameterValues.Add("5aca796c-35c6-418a-9deb-b088a8f677dc", () => ForbitInvoiceChange.DataSourceFilters);
			MetaPathParameterValues.Add("24dfe4df-9bb5-49a4-95db-61542b4948d1", () => ForbitInvoiceChange.DeleteRights);
			MetaPathParameterValues.Add("00434e0c-82ed-4624-aecf-e0253c869124", () => ForbitInvoiceChange.AddRights);
			MetaPathParameterValues.Add("4e79e422-749c-4eea-bc6b-efc646d9060f", () => ForbitInvoiceChange.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("eb5c0633-71b5-4885-bf63-9348c6e716fe", () => ReadInvoice.DataSourceFilters);
			MetaPathParameterValues.Add("df762cbe-8d50-45aa-a692-fc3ca13753f4", () => ReadInvoice.ResultType);
			MetaPathParameterValues.Add("0e9f1193-9fc1-4b4b-8432-b733eba80912", () => ReadInvoice.ReadSomeTopRecords);
			MetaPathParameterValues.Add("9d143566-7ff6-4ddc-91a8-d591f09cd961", () => ReadInvoice.NumberOfRecords);
			MetaPathParameterValues.Add("e5201aee-681b-4744-8a31-9ddd18e21086", () => ReadInvoice.FunctionType);
			MetaPathParameterValues.Add("11075dd3-15ea-48cc-bc90-e0d56c7659c3", () => ReadInvoice.AggregationColumnName);
			MetaPathParameterValues.Add("9cc48116-aeb9-466b-8bfc-4e956a8a224a", () => ReadInvoice.OrderInfo);
			MetaPathParameterValues.Add("7357770f-8b54-46b0-8ac6-9419f1e3851d", () => ReadInvoice.ResultEntity);
			MetaPathParameterValues.Add("8a5724d5-1ff6-487b-9fc6-200c9ad0f055", () => ReadInvoice.ResultCount);
			MetaPathParameterValues.Add("ba20003a-340e-46d9-a946-c7b838095ecf", () => ReadInvoice.ResultIntegerFunction);
			MetaPathParameterValues.Add("449de235-c6b7-424f-85d8-fb162b49bb7b", () => ReadInvoice.ResultFloatFunction);
			MetaPathParameterValues.Add("ba4dd278-a683-4a23-bb70-76dbea3a6008", () => ReadInvoice.ResultDateTimeFunction);
			MetaPathParameterValues.Add("88ad9c3b-a5af-4854-a28b-1335fb70031e", () => ReadInvoice.ResultRowsCount);
			MetaPathParameterValues.Add("e8e6e487-50e1-4bf3-8f69-9a817f3ab435", () => ReadInvoice.CanReadUncommitedData);
			MetaPathParameterValues.Add("221e16c4-8293-45d9-8259-d695e5af79eb", () => ReadInvoice.ResultEntityCollection);
			MetaPathParameterValues.Add("43a99aa6-4673-4153-a178-a5b9790d2ad5", () => ReadInvoice.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("c85fb573-bcfe-41e9-a9a9-27b68c96c857", () => ReadInvoice.IgnoreDisplayValues);
			MetaPathParameterValues.Add("5b217c23-ab59-497e-81b9-7bdc3f90f4fe", () => ReadInvoice.ResultCompositeObjectList);
			MetaPathParameterValues.Add("7592d300-f54b-4af3-9bff-e643df029e41", () => ReadInvoice.ConsiderTimeInFilter);
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
			MetaPathParameterValues.Add("3ae21b6c-fec9-4c92-9a29-c7820bacc7cd", () => ReadOwner.IgnoreDisplayValues);
			MetaPathParameterValues.Add("a6bb09dc-121d-4aac-9e66-1065f1b4a03f", () => ReadOwner.ResultCompositeObjectList);
			MetaPathParameterValues.Add("4540fb83-a29d-4bb1-8ff1-7c78c6151f70", () => ReadOwner.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("06f32bdb-9ee2-46db-8d39-5c0ebc39ed25", () => GiveRightsToOwner.EntitySchemaUId);
			MetaPathParameterValues.Add("1b719a91-d070-4e60-a646-559e44548e48", () => GiveRightsToOwner.DataSourceFilters);
			MetaPathParameterValues.Add("53ae98a2-1434-4e56-92e4-392b7492161e", () => GiveRightsToOwner.DeleteRights);
			MetaPathParameterValues.Add("c0b02be0-7324-41cb-a63d-7302690aac40", () => GiveRightsToOwner.AddRights);
			MetaPathParameterValues.Add("18cdcdbe-2c85-4567-b1d7-3e99a7c2d67a", () => GiveRightsToOwner.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("c5491b2a-fa9b-4478-b719-f8aa9946c0a8", () => GiveRightsToOwner.Employee2);
			MetaPathParameterValues.Add("3cff9b6a-3056-44a8-9a1f-c6bfec3caa52", () => InvoiceVisaSubProcess.Invoice);
			MetaPathParameterValues.Add("3056cd61-172a-449e-999b-ce78323fd7ec", () => InvoiceVisaSubProcess.VisaOwner);
			MetaPathParameterValues.Add("9b499fc0-a472-4fc1-8168-5a7f139ed935", () => InvoiceVisaSubProcess.VisaObjective);
			MetaPathParameterValues.Add("8f1116ee-11da-40ee-bb56-440bdf99b269", () => InvoiceVisaSubProcess.VisaResult);
			MetaPathParameterValues.Add("7ef81b65-2836-4432-b1da-f17b53c9a6de", () => InvoiceVisaSubProcess.IsAllowedToDelegate);
			MetaPathParameterValues.Add("1f29d0dc-0ab8-4b13-a121-53bd4037b40d", () => InvoiceVisaSubProcess.IsPreviousVisaCounts);
			MetaPathParameterValues.Add("4b5986e6-7044-4e29-9c25-835d23c947d0", () => GiveRightsToVisaOwner.EntitySchemaUId);
			MetaPathParameterValues.Add("e3405dd4-6438-45db-8a22-33f5fa053c32", () => GiveRightsToVisaOwner.DataSourceFilters);
			MetaPathParameterValues.Add("fe5895d5-2409-461c-8b7f-4db552d8ab2a", () => GiveRightsToVisaOwner.DeleteRights);
			MetaPathParameterValues.Add("b5c1528f-4e52-4e27-b0ea-b872c51fb27f", () => GiveRightsToVisaOwner.AddRights);
			MetaPathParameterValues.Add("ce5939bd-eefd-448c-b242-9e8a864e13d1", () => GiveRightsToVisaOwner.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("febfaf4a-4694-4c8c-a0f4-91c1d6a1ce10", () => GiveRightsToVisaOwner.Role1);
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
				case "GiveRightsToOwner.Employee2":
					GiveRightsToOwner.Employee2 = reader.GetValue<System.Guid>();
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
			var localEmailBody = string.Format(BodyApproved, ((ReadInvoice.ResultEntity.IsColumnValueLoaded(ReadInvoice.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? ReadInvoice.ResultEntity.GetTypedColumnValue<string>("Number") : null)));
			EmailBody = (System.String)localEmailBody;
			return true;
		}

		public virtual bool EmailBodyVisaRejectedExecute(ProcessExecutingContext context) {
			var localEmailBody = string.Format(BodyRejected, ((ReadInvoice.ResultEntity.IsColumnValueLoaded(ReadInvoice.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? ReadInvoice.ResultEntity.GetTypedColumnValue<string>("Number") : null)));
			EmailBody = (System.String)localEmailBody;
			return true;
		}

		public virtual bool EmailSubjectVisaApprovedExecute(ProcessExecutingContext context) {
			var localEmailSubject = SubjectApproved;
			EmailSubject = (System.String)localEmailSubject;
			return true;
		}

		public virtual bool EmailSubjectVisaRejectedExecute(ProcessExecutingContext context) {
			var localEmailSubject = SubjectRejected;
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
			var cloneItem = (InvoiceVisaProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

