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
	using System.Linq;
	using System.Text;

	#region Class: SearchForParentSchema

	/// <exclude/>
	public class SearchForParentSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SearchForParentSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SearchForParentSchema(SearchForParentSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SearchForParent";
			UId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a");
			CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab");
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
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a");
			Version = 0;
			PackageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateIncidentIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d270a8e7-f283-4e0c-9abb-71cd7fc777c6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"IncidentId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsCaseCollectionAnyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f83d82b0-58af-4e46-968e-7c6ef3d7b958"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"IsCaseCollectionAny",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"false",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateIncidentIdParameter());
			Parameters.Add(CreateIsCaseCollectionAnyParameter());
		}

		protected virtual void InitializeSearchForParentPreconfiguredPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var titleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("425b83a9-1efb-4042-8357-a8bb999509f4"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				Value = @"Открыть страницу поиска похожих обращений",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(titleParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("22d91d0f-7c9a-4ab4-be73-b242a2d32322"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("1396cfec-96e9-4358-ba2a-db56f25466d7"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				Value = @"a463ec0c-c9f2-4b07-9247-27dcb61a6a91",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(clientUnitSchemaUIdParameter);
			var entityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91d5ab47-a61f-4071-804e-e9f0565f3ccc"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(entityIdParameter);
			var entryPointIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3f5d1bed-0e68-4f37-b37a-fa58e5f88671"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("f80ca0e3-df11-4e51-8ed1-7b98c0dffeee"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var useCardProcessModuleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a30c0fcd-9d71-4b13-82ee-e7dba8cf37b0"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(useCardProcessModuleParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("dea4a681-ca88-4b34-bd1d-b2d572da8b1b"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("659d70cd-0a71-48d8-9eff-11a205ff4b3d"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("b662c6d3-20ec-4889-a118-c2838daa4b62"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("c2cbff2b-348c-417e-8ba3-b85b5b4ef5b8"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(isRunningParameter);
			var templateParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				UId = new Guid("8ba33687-5e4c-454f-8aa0-d22b56e32508"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("95c6ed03-2663-4205-847c-1137f59adb30"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("8e7559c6-ad77-4d0f-8512-f964ffb9a186"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("e05f2695-cd1e-4a51-ad6d-a9fa60f22136"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("4c783172-9a5a-450a-baea-b52e66e02f52"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("642ed77b-26bf-41d7-9c9c-98038397b24d"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("3e47ec93-aacf-48c8-b3ce-f6281a04dc99"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("1f4f05a6-085a-4578-8188-cbe09e32ee8a"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("04c34bd7-c7ac-46c8-b841-8acbd9d11b5e"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("9ea41743-58bb-4efa-8847-c42b2553eb3a"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("78518cc8-fc5d-4014-bc90-7588d6c84bc5"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("d83282e1-0bb3-44be-bb06-84420718be91"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("6249bf0f-aa58-49c2-a544-c5fa3852885e"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("1142a5af-7c39-4c81-878b-c9f0efae8c95"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("835359b5-1e6b-4d27-8fbe-92df87561c96"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
				UId = new Guid("f9723d34-5a49-42e5-8f2a-717b8a87feee"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
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
			var serviceItemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				UId = new Guid("0a201783-e5a9-49bb-aa18-483539cd7e45"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"ServiceItem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			serviceItemParameter.SourceValue = new ProcessSchemaParameterValue(serviceItemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(serviceItemParameter);
			var totalPagesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6220e5ea-1f4c-4e9b-b033-f97c376b240c"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"TotalPages",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			totalPagesParameter.SourceValue = new ProcessSchemaParameterValue(totalPagesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(totalPagesParameter);
			var currentPageNumberParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e9db3967-c4c4-4bc4-8167-944c1682b12c"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"CurrentPageNumber",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			currentPageNumberParameter.SourceValue = new ProcessSchemaParameterValue(currentPageNumberParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(currentPageNumberParameter);
			var resultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6eda63e0-df98-4e32-8946-8d99267b8943"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"Result",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			resultParameter.SourceValue = new ProcessSchemaParameterValue(resultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultParameter);
			var pageTitleParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("929b077b-0f50-49ff-a5b4-a1f72fb2e16c"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"PageTitle",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText")
			};
			pageTitleParameter.SourceValue = new ProcessSchemaParameterValue(pageTitleParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(pageTitleParameter);
			var hidePageNumbersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("11939531-2013-4afa-b680-6c5672ac4563"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"HidePageNumbers",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			hidePageNumbersParameter.SourceValue = new ProcessSchemaParameterValue(hidePageNumbersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(hidePageNumbersParameter);
			var caseIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("0662da67-49e4-4828-8aac-06b388cca81f"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"CaseId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			caseIdParameter.SourceValue = new ProcessSchemaParameterValue(caseIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d270a8e7-f283-4e0c-9abb-71cd7fc777c6}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(caseIdParameter);
			var caseCollectionParamParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("21cdc12a-97d7-4875-9cbc-8e89b57b8f11"),
				ContainerUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"CaseCollectionParam",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			caseCollectionParamParameter.SourceValue = new ProcessSchemaParameterValue(caseCollectionParamParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(caseCollectionParamParameter);
		}

		protected virtual void InitializeChangeDataUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("ace78947-8c57-47c0-ae85-c57a5821bb13"),
				ContainerUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
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
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d8ec807d-7f8d-4037-b2ab-9c88007c0121"),
				ContainerUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d9594b77-041b-46f3-9024-1bd044d68726"),
				ContainerUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,205,106,220,48,20,133,95,165,104,209,149,85,172,31,91,150,187,28,166,101,54,105,160,105,41,36,67,144,165,171,68,224,159,137,45,211,132,97,160,100,209,77,223,33,207,144,148,22,90,104,222,193,243,70,149,199,153,22,178,40,221,116,81,48,230,234,218,231,232,187,7,105,125,234,186,23,174,244,208,230,86,149,29,68,253,194,228,72,211,130,101,5,43,112,102,164,193,220,0,193,5,85,20,83,73,140,182,49,209,134,0,138,106,85,65,142,38,245,220,56,143,34,231,161,234,242,227,245,111,83,223,246,16,157,218,221,226,181,62,135,74,189,25,55,32,68,24,70,173,196,25,21,9,230,9,227,56,227,132,96,162,211,148,144,68,131,212,6,77,44,68,153,20,98,201,49,145,220,98,206,53,195,202,170,2,83,67,172,40,50,65,18,169,81,84,130,245,243,203,85,11,93,231,154,58,95,195,175,250,232,106,21,40,167,189,103,77,217,87,53,138,42,240,234,80,249,243,28,41,136,129,39,90,97,205,101,0,177,32,176,98,97,102,166,10,65,69,6,36,37,2,69,90,173,252,104,139,22,129,202,40,175,222,170,178,135,157,243,218,5,70,202,98,146,37,105,208,18,166,49,103,52,198,89,154,9,108,77,106,37,176,84,202,194,236,243,122,217,187,80,187,238,160,175,160,117,250,33,118,8,249,53,109,190,214,77,237,219,166,28,173,15,118,191,31,193,165,159,194,125,248,244,110,26,200,135,254,40,66,155,168,239,96,86,58,168,253,188,214,141,113,245,217,228,185,217,4,73,181,82,173,235,246,41,204,47,122,85,162,168,117,103,231,127,76,107,214,119,190,169,254,163,81,163,48,102,240,8,135,108,135,59,158,65,227,186,85,169,174,118,235,28,61,189,232,27,255,124,184,25,238,182,31,134,219,225,110,184,221,94,111,63,13,159,67,253,117,248,17,170,239,79,134,111,195,253,246,99,120,127,9,173,251,237,245,36,65,143,172,115,116,130,12,21,177,202,194,81,177,52,99,152,67,172,177,84,69,129,69,184,24,194,106,33,132,78,79,80,192,253,151,16,199,139,238,213,251,122,127,171,166,28,150,207,66,247,81,227,112,175,204,215,127,195,189,89,142,228,203,77,120,126,2,75,84,71,149,28,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55f85150-f401-4e97-9d12-0f211ee35972"),
				ContainerUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,209,110,211,48,20,253,149,202,219,99,93,213,177,19,199,121,132,14,169,210,6,213,54,246,210,246,193,137,175,183,74,105,82,37,41,48,170,74,219,208,144,16,124,3,223,48,30,64,48,9,248,133,228,143,112,220,148,182,176,7,132,31,18,251,218,231,156,235,123,143,23,104,191,184,156,1,10,208,163,193,209,73,170,139,206,227,52,131,206,32,75,35,200,243,206,97,26,201,120,242,90,134,49,12,100,38,167,80,64,118,38,227,57,228,135,147,188,104,183,182,65,168,141,246,95,216,61,20,12,23,168,95,192,244,121,95,25,102,77,92,144,76,133,24,164,71,48,35,196,193,130,42,134,149,75,153,175,32,34,20,184,1,71,105,60,159,38,71,80,200,129,44,46,80,176,64,150,205,16,72,215,231,33,19,12,51,174,41,102,161,195,113,8,204,193,210,113,5,184,92,232,174,71,208,178,141,242,232,2,166,210,138,110,192,132,112,69,29,45,176,239,112,23,51,163,137,125,147,3,38,145,231,17,226,70,32,34,85,131,155,243,27,224,112,111,216,207,159,189,76,32,59,177,188,129,150,113,14,227,142,137,254,17,56,136,97,10,73,17,44,40,227,156,185,92,99,136,234,155,130,6,236,19,87,97,74,185,2,209,85,212,85,116,105,0,191,107,25,44,60,80,210,163,208,197,74,11,223,64,168,131,125,193,60,236,43,33,28,143,135,102,97,32,123,227,58,69,53,201,103,177,188,60,251,59,211,242,99,117,83,222,87,87,213,251,234,166,250,208,170,174,205,239,170,188,43,191,151,95,171,183,213,155,86,249,179,252,97,166,215,229,125,121,103,23,213,173,9,124,49,161,219,150,153,124,170,15,87,239,202,207,53,160,252,214,57,134,124,30,23,43,209,217,78,223,183,101,23,163,149,121,70,40,24,61,108,159,230,191,42,215,174,129,118,189,51,66,237,17,58,73,231,89,84,179,209,122,177,238,165,101,239,54,3,63,240,89,143,21,135,133,29,201,68,158,67,246,212,232,89,184,221,234,201,66,90,233,83,147,243,154,56,116,132,219,229,68,99,14,82,152,242,123,166,252,138,72,44,136,8,53,229,198,56,218,177,232,99,211,204,12,146,8,118,19,35,255,224,46,139,183,202,155,100,214,54,55,145,100,30,199,86,32,183,247,175,223,77,147,120,179,211,219,106,251,22,67,170,38,122,2,170,159,252,103,169,122,160,45,229,147,52,59,120,101,94,243,36,57,111,250,181,37,189,57,211,139,166,77,124,137,150,203,241,242,23,117,86,173,172,58,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b83b75e8-6acc-4689-bbf7-582ce39c2c52"),
				ContainerUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
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

		protected virtual void InitializeReadConfItemDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cd861df3-40fb-4186-b65e-25dba80f9e24"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,138,212,64,20,253,21,169,133,171,148,84,165,147,170,36,46,155,22,6,100,28,240,129,48,52,67,61,110,77,7,243,154,164,130,14,161,65,102,33,200,252,131,223,224,136,13,10,206,63,164,255,200,74,210,209,97,22,226,198,133,16,194,173,170,156,83,231,156,123,211,157,165,205,147,52,179,80,39,70,100,13,120,237,145,78,80,100,4,72,170,37,14,162,208,224,32,16,4,75,2,11,236,135,76,131,10,12,1,30,35,175,16,57,36,104,66,175,116,106,145,151,90,200,155,228,180,251,77,106,235,22,188,51,51,46,158,171,13,228,226,229,112,65,168,184,111,98,31,48,209,204,199,129,207,8,22,68,26,172,21,1,144,38,8,25,143,208,164,133,73,202,164,84,18,71,140,51,247,41,15,177,4,18,99,67,165,111,152,34,42,146,1,242,50,48,118,245,174,170,161,105,210,178,72,58,248,85,191,184,172,156,202,233,238,101,153,181,121,129,188,28,172,56,17,118,147,32,195,165,17,190,86,216,128,136,113,192,132,112,78,7,207,210,15,35,18,48,231,95,32,79,137,202,14,180,168,255,212,223,236,223,247,159,247,31,251,93,127,219,127,235,119,200,171,193,64,13,133,130,59,254,40,229,122,225,28,226,104,208,27,132,139,0,71,1,165,152,42,198,40,13,21,196,74,35,79,11,43,94,137,172,133,81,99,151,58,160,244,227,144,112,106,48,31,245,128,75,39,210,84,224,152,198,210,44,184,227,52,254,156,252,211,178,124,211,86,46,245,230,184,205,161,78,213,161,133,224,122,81,214,73,167,202,194,214,101,54,144,31,223,1,76,173,58,28,190,158,226,201,198,147,1,136,182,94,219,192,50,75,161,176,171,66,149,58,45,206,199,46,110,183,14,147,87,162,78,155,57,212,213,69,43,50,23,64,122,190,249,99,248,203,182,177,101,254,191,249,245,156,87,71,227,6,119,212,60,204,181,78,155,42,19,151,227,58,65,15,47,218,210,62,158,71,162,191,113,99,113,181,191,238,191,184,122,215,255,112,213,247,7,110,66,110,247,31,220,251,235,48,47,251,171,9,130,238,81,39,7,42,237,115,34,34,224,216,248,209,194,133,65,20,142,133,148,152,83,165,185,81,156,115,197,14,12,91,239,95,139,57,61,106,158,189,45,230,191,118,138,122,253,200,237,222,219,56,153,209,73,247,55,250,183,235,217,193,122,235,158,159,87,89,205,122,128,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("84cb8b09-ef03-435e-8588-4e64e6ef5a4f"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97a0ecd6-d533-479c-a450-c4a2577641d4"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("05538184-0f57-423a-b191-c5dbdac068f8"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c73f9f80-fd7b-4cf1-acb9-d60091d0f344"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a13349cc-1228-4922-a0ff-008c512c950b"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("93e4cd31-714c-41ca-ae3a-d8696adcf3dd"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,113,78,44,78,181,50,180,50,4,0,241,126,40,137,15,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				UId = new Guid("5f8f8252-4b03-4c7c-bd80-b7808545ec0c"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c76d235a-b599-4654-ba0e-21d29510a3b3"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("7fde92e2-24aa-451d-bd80-ee4640257ed9"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("0294f17d-4f4c-41a8-84bd-41091d1e9884"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("d1c4b637-39da-474d-980c-8c8ad96125c5"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("44873c50-da69-45fb-b889-4e99c0c63fba"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("4066fd99-ee9a-4434-9b7d-3d6cfe69c3ed"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ReferenceSchemaUId = new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"),
				UId = new Guid("2b138545-6ab5-4b6c-bd27-a904e645cb89"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cf362cd5-a00c-4a73-a580-9a64f6cb55ac"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("46bc0544-e508-430d-b9ad-6eb5ebd0d48b"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("b3b88c4d-1145-42ce-ad37-072eba74f9e9"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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
				UId = new Guid("fc16705b-812d-4776-9714-918b172caedb"),
				ContainerUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
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

		protected virtual void InitializeReadCaseDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("acf43b55-9bc9-4f23-ab2f-4be0d0fda31f"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,207,106,220,48,16,198,95,165,232,208,147,85,44,75,182,100,247,184,108,203,94,210,64,211,82,72,150,32,75,163,68,224,63,27,91,166,9,102,161,228,208,75,223,33,207,144,148,22,90,104,222,193,251,70,149,237,108,11,57,148,94,122,40,24,49,26,123,190,249,205,199,184,63,181,237,11,91,56,104,50,35,139,22,130,110,165,51,68,146,144,42,78,82,12,32,36,102,130,50,44,104,204,49,85,64,153,49,132,18,17,162,160,146,37,100,104,174,94,106,235,80,96,29,148,109,118,220,255,22,117,77,7,193,169,153,46,175,213,57,148,242,205,212,128,112,77,35,147,98,17,241,24,179,120,108,192,8,193,68,37,9,33,177,130,84,105,52,179,104,145,231,58,52,28,231,161,72,48,99,113,132,165,72,4,54,41,136,148,168,152,135,73,140,130,2,140,91,94,110,26,104,91,91,87,89,15,191,226,163,171,141,167,156,123,47,234,162,43,43,20,148,224,228,161,116,231,25,146,16,2,139,149,196,138,165,30,196,0,199,146,166,26,83,153,243,136,11,32,9,225,40,80,114,227,70,89,180,242,84,90,58,249,86,22,29,76,202,189,245,140,17,13,137,136,19,95,75,168,194,140,70,33,246,136,28,27,157,120,76,154,164,105,174,247,126,189,236,172,143,109,123,208,149,208,88,245,96,59,120,255,234,38,235,85,93,185,166,46,70,233,131,233,243,35,184,116,179,185,15,175,222,205,3,57,159,31,139,208,54,232,90,88,20,22,42,183,172,84,173,109,117,54,107,110,183,190,164,220,200,198,182,123,23,150,23,157,44,80,208,216,179,243,63,186,181,232,90,87,151,255,209,168,129,31,211,107,248,37,155,112,199,29,212,182,221,20,242,106,186,103,232,233,69,87,187,231,195,205,112,183,251,48,220,14,119,195,237,238,122,247,105,248,236,227,175,195,15,31,125,127,50,124,27,238,119,31,253,249,197,167,238,119,215,115,9,122,36,157,161,19,164,35,30,74,225,87,197,68,130,98,6,161,194,169,204,115,204,137,210,220,40,206,185,74,78,144,199,253,151,16,199,171,246,213,251,106,255,87,205,62,172,159,249,236,163,196,225,190,50,235,255,134,123,187,30,201,215,91,255,252,4,105,242,231,189,28,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("870b6336-1d39-430f-af59-ef5b32142e14"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("14b1a615-9e84-4bf2-95fa-7edb14a5255f"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dd90fd1c-0563-48f6-ab88-502b7089d065"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fbbe03b2-1467-4b16-bce2-946a0ea9dde1"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2a0c0741-97b6-4dfb-9773-ab3e71bf05e7"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("e50d1955-15fb-4f03-add8-674d9bdd2878"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,43,205,77,74,45,178,50,180,50,4,0,178,212,123,197,17,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("72430e28-8bf4-41c4-8aa3-392123b79311"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("64981203-3d0d-4db5-b21e-8d95f119545f"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("0594e91b-20aa-47ba-b7b9-c3c046612aff"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("e97c2cc7-5ef7-4027-b501-41a79b2a21b2"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("6fb0bacd-1017-4b1c-8458-a9b76a08c1d0"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("380ab258-c3ad-496b-ad59-c7ba3f40c610"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("6ce7255d-b559-43d6-bed7-f3e91167dbf8"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("19c3b6f8-27ba-43df-be8e-76a89b378ea5"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1087a0aa-984b-42e6-b132-8d5478f65528"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4faa6e56-1123-4ec1-909d-aaad325be138"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("ecf2b48d-c38d-48cb-a233-e4b616357e3c"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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
				UId = new Guid("d7133309-cc59-49d6-b3fd-885a5d735a8b"),
				ContainerUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
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

		protected virtual void InitializePrepareTagCollectionParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6418d70e-c8df-4215-a8a3-cb363d472ec0"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,43,69,135,158,172,98,201,178,101,185,199,101,11,129,146,4,250,65,33,44,97,60,26,101,213,250,43,182,76,27,204,254,247,106,215,187,109,200,161,244,208,75,193,7,105,164,247,230,189,55,242,114,239,167,119,190,9,52,86,14,154,137,146,249,202,86,172,48,169,74,157,1,158,167,96,185,146,2,57,128,149,60,43,50,5,90,164,89,86,58,150,116,208,82,197,86,244,214,250,192,18,31,168,157,170,187,229,55,105,24,103,74,238,221,105,243,1,247,212,194,167,99,3,139,70,213,86,58,158,231,105,206,85,89,35,47,177,208,92,89,89,107,2,109,106,202,217,170,69,230,166,52,89,234,56,24,225,184,50,46,94,5,68,46,44,90,161,82,68,43,21,75,26,114,97,251,99,24,105,154,124,223,85,11,253,90,127,124,26,162,202,181,247,166,111,230,182,99,73,75,1,110,33,236,43,6,25,213,37,101,5,47,108,30,133,216,210,114,131,66,113,145,202,26,181,113,164,74,96,9,194,16,142,180,236,166,254,74,24,141,142,228,104,164,14,233,153,39,33,180,205,164,51,188,148,58,82,229,153,226,165,18,130,11,44,10,33,114,36,131,150,37,22,2,124,134,102,166,147,174,197,71,96,45,77,158,234,104,46,58,55,92,81,33,121,105,5,112,35,76,237,50,29,57,157,188,164,253,190,239,191,205,67,76,122,186,158,91,26,61,158,199,70,49,255,126,172,22,236,187,48,246,205,145,252,250,25,96,29,207,249,240,203,26,73,115,58,57,2,217,33,153,39,218,52,158,186,176,237,176,183,190,123,56,77,238,112,136,152,118,128,209,79,151,32,183,143,51,52,49,0,255,176,255,99,224,155,121,10,125,251,191,249,77,162,215,72,19,31,235,73,243,241,45,91,63,13,13,60,157,246,21,123,253,56,247,225,237,237,216,99,52,75,246,149,239,208,219,72,179,214,217,11,252,229,190,149,58,133,146,52,119,178,204,162,227,20,185,129,186,230,90,160,213,14,181,214,88,156,25,14,201,63,233,120,119,53,221,124,239,46,255,220,26,218,238,77,172,190,40,220,94,208,213,242,55,34,15,187,139,204,221,33,126,63,1,218,179,228,98,62,4,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ad80f9ab-24d3-4614-ac24-e78e1e7f8cc9"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fd932721-9572-4d4d-9ae0-a53f2f7a9404"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8fe4967a-019f-4732-8095-d40150ef5806"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5fb9d631-8efe-459a-9bd5-6fed2139169c"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e4e5c77d-f138-4aa2-94e0-b84a088abacc"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("259d4266-8c7e-4c27-b0f0-98cdf9128a23"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,9,73,76,183,50,180,50,4,0,218,2,59,40,14,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("dc94bd2f-5505-48bc-8c67-4d2b7ea79be5"),
				UId = new Guid("21277763-11c1-45b5-85ba-7d1933f003a9"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fe355ae7-ae4c-401b-9d39-9d56030ea11c"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("db47687b-5a80-4a97-8e54-fd79fc9357df"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("8db483e0-0d10-4173-987c-761a50993f1c"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("66a32598-4247-4928-9458-69deda5a2d2d"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("03fa10e4-0653-4807-96a6-5f7afd87fa99"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("e7e86faa-f353-40d1-bda1-b828e648e3e6"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ReferenceSchemaUId = new Guid("dc94bd2f-5505-48bc-8c67-4d2b7ea79be5"),
				UId = new Guid("7964a7ec-d994-44ef-b450-d3fd3382705c"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2ed44ec2-017e-412a-9306-9b3ae4a16754"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9dd501c5-5d42-4870-8c69-3f4c0982c50a"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("0a753d00-49c7-4c86-aa62-204444f905ca"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
				UId = new Guid("594f66a8-16d4-4085-ad92-aa80b470c409"),
				ContainerUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
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
			ProcessSchemaLaneSet schemaSearchForParents = CreateSearchForParentsLaneSet();
			LaneSets.Add(schemaSearchForParents);
			ProcessSchemaLane schemaFirstSupportLine = CreateFirstSupportLineLane();
			schemaSearchForParents.Lanes.Add(schemaFirstSupportLine);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaUserTask searchforparentpreconfiguredpageusertask = CreateSearchForParentPreconfiguredPageUserTaskUserTask();
			FlowElements.Add(searchforparentpreconfiguredpageusertask);
			ProcessSchemaUserTask changedatausertask1 = CreateChangeDataUserTask1UserTask();
			FlowElements.Add(changedatausertask1);
			ProcessSchemaUserTask readconfitemdatausertask = CreateReadConfItemDataUserTaskUserTask();
			FlowElements.Add(readconfitemdatausertask);
			ProcessSchemaScriptTask preparecasecollection = CreatePrepareCaseCollectionScriptTask();
			FlowElements.Add(preparecasecollection);
			ProcessSchemaUserTask readcasedatausertask = CreateReadCaseDataUserTaskUserTask();
			FlowElements.Add(readcasedatausertask);
			ProcessSchemaUserTask preparetagcollection = CreatePrepareTagCollectionUserTask();
			FlowElements.Add(preparetagcollection);
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateParentCaseSelectedConditionalFlowConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("28f0db2a-3335-4fbc-9e26-3ad70bdfe215"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c54dcc84-10c3-4c6b-83d2-71375cca6121"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateParentCaseSelectedConditionalFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ParentCaseSelectedConditionalFlow",
				UId = new Guid("d0644cf4-411e-46d8-b79c-a9b7c342f134"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{3477457f-ec61-4efe-815d-337de90d35d3}].[Parameter:{6eda63e0-df98-4e32-8946-8d99267b8943}]#] != Guid.Empty",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(375, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow2",
				UId = new Guid("2da0d46f-94f2-4e7d-9630-22192cacad9a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(460, 184),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c54dcc84-10c3-4c6b-83d2-71375cca6121"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(742, 150));
			schemaFlow.PolylinePointPositions.Add(new Point(1050, 150));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("e115c96f-04f8-495e-8c9e-afeadb22cff2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(160, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bfc04a7f-3451-4aab-b2ce-0f992a937a13"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("1db82c5d-247c-4bb2-8955-62cc05eff9e6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(365, 206),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("192b4fb7-f0a5-4895-9b2b-c085503eec6f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(160, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("4350a31d-c5db-45f9-8efd-4f58d1b70544"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{f83d82b0-58af-4e46-968e-7c6ef3d7b958}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(526, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f223b416-07f8-4d28-be9a-ff5273b6274f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow5",
				UId = new Guid("fa967f5b-9630-4dd4-a1dc-530f33b346fb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(680, 224),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f223b416-07f8-4d28-be9a-ff5273b6274f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c54dcc84-10c3-4c6b-83d2-71375cca6121"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(560, 235));
			schemaFlow.PolylinePointPositions.Add(new Point(1050, 235));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("e12eb3c5-3171-47b2-a064-87d99fb6a700"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f223b416-07f8-4d28-be9a-ff5273b6274f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(494, 197));
			schemaFlow.PolylinePointPositions.Add(new Point(494, 192));
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateSearchForParentsLaneSet() {
			ProcessSchemaLaneSet schemaSearchForParents = new ProcessSchemaLaneSet(this) {
				UId = new Guid("5af10768-7fa4-4032-818c-4af36a769b60"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"SearchForParents",
				Position = new Point(5, 5),
				Size = new Size(1093, 400),
				UseBackgroundMode = false
			};
			return schemaSearchForParents;
		}

		protected virtual ProcessSchemaLane CreateFirstSupportLineLane() {
			ProcessSchemaLane schemaFirstSupportLine = new ProcessSchemaLane(this) {
				UId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("5af10768-7fa4-4032-818c-4af36a769b60"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"FirstSupportLine",
				Position = new Point(29, 0),
				Size = new Size(1064, 400),
				UseBackgroundMode = false
			};
			return schemaFirstSupportLine;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("bfc04a7f-3451-4aab-b2ce-0f992a937a13"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
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
				UId = new Guid("c54dcc84-10c3-4c6b-83d2-71375cca6121"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("4f61f5dc-c214-42b2-93aa-02d5c35156ab"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"Terminate1",
				Position = new Point(1037, 179),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaUserTask CreateSearchForParentPreconfiguredPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"SearchForParentPreconfiguredPageUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(708, 165),
				SchemaUId = new Guid("ac2ef13c-30dd-4023-9c04-58f580743b48"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeSearchForParentPreconfiguredPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateChangeDataUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"ChangeDataUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(911, 165),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeChangeDataUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadConfItemDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"ReadConfItemDataUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(253, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadConfItemDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareCaseCollectionScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("f223b416-07f8-4d28-be9a-ff5273b6274f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"PrepareCaseCollection",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(526, 165),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,85,93,111,218,48,20,125,30,18,255,193,226,41,145,42,107,123,109,11,18,226,163,202,212,13,86,216,246,48,245,193,139,47,193,91,98,83,219,97,66,235,254,251,174,237,36,124,20,214,169,66,125,65,145,227,123,206,185,231,220,92,214,76,19,48,15,3,102,128,116,137,132,95,100,36,173,176,155,89,186,132,130,125,42,65,111,162,207,6,244,64,73,9,169,21,74,210,221,11,31,152,100,25,232,11,210,113,8,157,248,170,221,170,208,104,159,243,129,202,203,66,70,157,132,159,122,115,7,153,48,22,52,240,137,236,196,116,162,57,232,161,208,129,9,5,237,31,208,33,152,20,36,23,50,219,129,27,139,28,17,140,131,141,234,179,129,6,102,33,188,249,42,236,114,202,52,43,192,93,139,194,225,64,21,43,166,133,81,114,190,89,1,253,168,236,232,161,100,57,54,130,98,47,72,34,83,193,65,218,132,199,241,153,169,106,158,153,101,182,52,52,49,99,33,89,142,156,11,150,27,56,74,119,171,50,145,178,124,178,2,205,42,99,14,143,102,86,139,212,210,190,228,88,191,14,161,158,47,208,227,97,190,64,223,68,31,148,86,78,190,220,69,208,107,145,66,98,161,64,11,239,128,113,167,123,200,44,115,77,206,153,249,73,239,192,148,185,13,77,210,27,176,161,145,47,44,47,33,218,173,119,141,121,251,189,125,254,250,45,14,103,229,162,123,188,14,32,189,200,243,40,185,112,101,39,185,144,39,15,14,215,160,89,41,120,95,107,182,65,204,45,1,157,129,187,23,21,221,94,225,244,185,254,248,142,200,235,201,247,31,248,190,23,117,106,74,175,148,206,149,199,138,28,186,88,144,168,65,167,3,85,74,27,197,164,219,37,111,99,242,187,221,122,115,78,203,191,53,50,164,243,250,210,253,220,211,250,16,83,184,65,33,116,84,172,236,198,219,249,135,0,14,246,235,203,104,252,8,42,66,4,150,101,230,88,162,83,13,72,2,115,150,109,99,123,38,77,132,170,195,116,168,77,140,164,219,35,207,4,137,52,199,51,172,49,247,35,108,183,206,111,30,186,149,72,212,113,25,218,187,167,248,252,138,217,157,160,175,251,175,35,251,223,197,251,111,58,191,210,177,172,249,186,181,15,214,125,133,21,22,166,117,24,243,193,150,172,75,115,133,107,109,123,107,111,199,158,44,222,93,167,11,133,186,211,101,228,183,76,14,5,46,2,34,100,37,41,118,78,31,80,132,166,195,205,202,150,196,56,184,237,149,190,116,83,248,164,78,134,193,154,1,211,233,114,172,52,198,131,24,56,234,41,126,37,34,43,241,111,119,138,219,190,217,94,251,160,62,76,132,117,171,91,102,244,189,18,184,253,31,209,201,67,158,106,240,161,219,243,70,62,25,123,227,1,112,236,19,254,110,111,232,157,56,13,182,212,146,88,93,194,213,95,229,84,203,163,141,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadCaseDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"ReadCaseDataUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(113, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCaseDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreatePrepareTagCollectionUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ae5885dd-d8e1-4822-b304-e90c2bf74a5e"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"),
				Name = @"PrepareTagCollection",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(393, 170),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializePrepareTagCollectionParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("83d33621-a790-4111-bab0-7772b4d07bcc"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("af4e550c-48e2-4633-8dc7-3d1cb7a5a757")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SearchForParent(userConnection);
		}

		public override object Clone() {
			return new SearchForParentSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a"));
		}

		#endregion

	}

	#endregion

	#region Class: SearchForParent

	/// <exclude/>
	public class SearchForParent : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessFirstSupportLine

		/// <exclude/>
		public class ProcessFirstSupportLine : ProcessLane
		{

			public ProcessFirstSupportLine(UserConnection userConnection, SearchForParent process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: SearchForParentPreconfiguredPageUserTaskFlowElement

		/// <exclude/>
		public class SearchForParentPreconfiguredPageUserTaskFlowElement : PreconfiguredPageUserTask
		{

			#region Constructors: Public

			public SearchForParentPreconfiguredPageUserTaskFlowElement(UserConnection userConnection, SearchForParent process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SearchForParentPreconfiguredPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("3477457f-ec61-4efe-815d-337de90d35d3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.FirstSupportLine;
				SerializeToDB = true;
				_caseId = () => (Guid)((process.IncidentId));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _title;
			public override LocalizableString Title {
				get {
					return _title ?? (_title = GetLocalizableString("eaad6977be784c4085ad1bbdd5573c1a",
						 "BaseElements.SearchForParentPreconfiguredPageUserTask.Parameters.Title.Value"));
				}
				set {
					_title = value;
				}
			}

			private Guid _clientUnitSchemaUId = new Guid("a463ec0c-c9f2-4b07-9247-27dcb61a6a91");
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

			public virtual Guid ServiceItem {
				get;
				set;
			}

			public virtual int TotalPages {
				get;
				set;
			}

			public virtual int CurrentPageNumber {
				get;
				set;
			}

			public virtual Guid Result {
				get;
				set;
			}

			public virtual string PageTitle {
				get;
				set;
			}

			public virtual bool HidePageNumbers {
				get;
				set;
			}

			internal Func<Guid> _caseId;
			public virtual Guid CaseId {
				get {
					return (_caseId ?? (_caseId = () => Guid.Empty)).Invoke();
				}
				set {
					_caseId = () => { return value; };
				}
			}

			public virtual string CaseCollectionParam {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Class: ChangeDataUserTask1FlowElement

		/// <exclude/>
		public class ChangeDataUserTask1FlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ChangeDataUserTask1FlowElement(UserConnection userConnection, SearchForParent process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ChangeDataUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("e02dce31-a6f7-4c9a-af3b-2e17cfbedd87");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_ParentCase = () => (Guid)((process.SearchForParentPreconfiguredPageUserTask.Result));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_ParentCase", () => _recordColumnValues_ParentCase.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_ParentCase;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,205,106,220,48,20,133,95,165,104,209,149,85,172,31,91,150,187,28,166,101,54,105,160,105,41,36,67,144,165,171,68,224,159,137,45,211,132,97,160,100,209,77,223,33,207,144,148,22,90,104,222,193,243,70,149,199,153,22,178,40,221,116,81,48,230,234,218,231,232,187,7,105,125,234,186,23,174,244,208,230,86,149,29,68,253,194,228,72,211,130,101,5,43,112,102,164,193,220,0,193,5,85,20,83,73,140,182,49,209,134,0,138,106,85,65,142,38,245,220,56,143,34,231,161,234,242,227,245,111,83,223,246,16,157,218,221,226,181,62,135,74,189,25,55,32,68,24,70,173,196,25,21,9,230,9,227,56,227,132,96,162,211,148,144,68,131,212,6,77,44,68,153,20,98,201,49,145,220,98,206,53,195,202,170,2,83,67,172,40,50,65,18,169,81,84,130,245,243,203,85,11,93,231,154,58,95,195,175,250,232,106,21,40,167,189,103,77,217,87,53,138,42,240,234,80,249,243,28,41,136,129,39,90,97,205,101,0,177,32,176,98,97,102,166,10,65,69,6,36,37,2,69,90,173,252,104,139,22,129,202,40,175,222,170,178,135,157,243,218,5,70,202,98,146,37,105,208,18,166,49,103,52,198,89,154,9,108,77,106,37,176,84,202,194,236,243,122,217,187,80,187,238,160,175,160,117,250,33,118,8,249,53,109,190,214,77,237,219,166,28,173,15,118,191,31,193,165,159,194,125,248,244,110,26,200,135,254,40,66,155,168,239,96,86,58,168,253,188,214,141,113,245,217,228,185,217,4,73,181,82,173,235,246,41,204,47,122,85,162,168,117,103,231,127,76,107,214,119,190,169,254,163,81,163,48,102,240,8,135,108,135,59,158,65,227,186,85,169,174,118,235,28,61,189,232,27,255,124,184,25,238,182,31,134,219,225,110,184,221,94,111,63,13,159,67,253,117,248,17,170,239,79,134,111,195,253,246,99,120,127,9,173,251,237,245,36,65,143,172,115,116,130,12,21,177,202,194,81,177,52,99,152,67,172,177,84,69,129,69,184,24,194,106,33,132,78,79,80,192,253,151,16,199,139,238,213,251,122,127,171,166,28,150,207,66,247,81,227,112,175,204,215,127,195,189,89,142,228,203,77,120,126,2,75,84,71,149,28,4,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,209,110,211,48,20,253,149,202,219,99,93,213,177,19,199,121,132,14,169,210,6,213,54,246,210,246,193,137,175,183,74,105,82,37,41,48,170,74,219,208,144,16,124,3,223,48,30,64,48,9,248,133,228,143,112,220,148,182,176,7,132,31,18,251,218,231,156,235,123,143,23,104,191,184,156,1,10,208,163,193,209,73,170,139,206,227,52,131,206,32,75,35,200,243,206,97,26,201,120,242,90,134,49,12,100,38,167,80,64,118,38,227,57,228,135,147,188,104,183,182,65,168,141,246,95,216,61,20,12,23,168,95,192,244,121,95,25,102,77,92,144,76,133,24,164,71,48,35,196,193,130,42,134,149,75,153,175,32,34,20,184,1,71,105,60,159,38,71,80,200,129,44,46,80,176,64,150,205,16,72,215,231,33,19,12,51,174,41,102,161,195,113,8,204,193,210,113,5,184,92,232,174,71,208,178,141,242,232,2,166,210,138,110,192,132,112,69,29,45,176,239,112,23,51,163,137,125,147,3,38,145,231,17,226,70,32,34,85,131,155,243,27,224,112,111,216,207,159,189,76,32,59,177,188,129,150,113,14,227,142,137,254,17,56,136,97,10,73,17,44,40,227,156,185,92,99,136,234,155,130,6,236,19,87,97,74,185,2,209,85,212,85,116,105,0,191,107,25,44,60,80,210,163,208,197,74,11,223,64,168,131,125,193,60,236,43,33,28,143,135,102,97,32,123,227,58,69,53,201,103,177,188,60,251,59,211,242,99,117,83,222,87,87,213,251,234,166,250,208,170,174,205,239,170,188,43,191,151,95,171,183,213,155,86,249,179,252,97,166,215,229,125,121,103,23,213,173,9,124,49,161,219,150,153,124,170,15,87,239,202,207,53,160,252,214,57,134,124,30,23,43,209,217,78,223,183,101,23,163,149,121,70,40,24,61,108,159,230,191,42,215,174,129,118,189,51,66,237,17,58,73,231,89,84,179,209,122,177,238,165,101,239,54,3,63,240,89,143,21,135,133,29,201,68,158,67,246,212,232,89,184,221,234,201,66,90,233,83,147,243,154,56,116,132,219,229,68,99,14,82,152,242,123,166,252,138,72,44,136,8,53,229,198,56,218,177,232,99,211,204,12,146,8,118,19,35,255,224,46,139,183,202,155,100,214,54,55,145,100,30,199,86,32,183,247,175,223,77,147,120,179,211,219,106,251,22,67,170,38,122,2,170,159,252,103,169,122,160,45,229,147,52,59,120,101,94,243,36,57,111,250,181,37,189,57,211,139,166,77,124,137,150,203,241,242,23,117,86,173,172,58,4,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "eaad6977be784c4085ad1bbdd5573c1a",
							"BaseElements.ChangeDataUserTask1.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
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

		#region Class: ReadConfItemDataUserTaskFlowElement

		/// <exclude/>
		public class ReadConfItemDataUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadConfItemDataUserTaskFlowElement(UserConnection userConnection, SearchForParent process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadConfItemDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("3d783dfa-9ba5-4ff8-a851-bd03abda1ffe");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,203,138,212,64,20,253,21,169,133,171,148,84,165,147,170,36,46,155,22,6,100,28,240,129,48,52,67,61,110,77,7,243,154,164,130,14,161,65,102,33,200,252,131,223,224,136,13,10,206,63,164,255,200,74,210,209,97,22,226,198,133,16,194,173,170,156,83,231,156,123,211,157,165,205,147,52,179,80,39,70,100,13,120,237,145,78,80,100,4,72,170,37,14,162,208,224,32,16,4,75,2,11,236,135,76,131,10,12,1,30,35,175,16,57,36,104,66,175,116,106,145,151,90,200,155,228,180,251,77,106,235,22,188,51,51,46,158,171,13,228,226,229,112,65,168,184,111,98,31,48,209,204,199,129,207,8,22,68,26,172,21,1,144,38,8,25,143,208,164,133,73,202,164,84,18,71,140,51,247,41,15,177,4,18,99,67,165,111,152,34,42,146,1,242,50,48,118,245,174,170,161,105,210,178,72,58,248,85,191,184,172,156,202,233,238,101,153,181,121,129,188,28,172,56,17,118,147,32,195,165,17,190,86,216,128,136,113,192,132,112,78,7,207,210,15,35,18,48,231,95,32,79,137,202,14,180,168,255,212,223,236,223,247,159,247,31,251,93,127,219,127,235,119,200,171,193,64,13,133,130,59,254,40,229,122,225,28,226,104,208,27,132,139,0,71,1,165,152,42,198,40,13,21,196,74,35,79,11,43,94,137,172,133,81,99,151,58,160,244,227,144,112,106,48,31,245,128,75,39,210,84,224,152,198,210,44,184,227,52,254,156,252,211,178,124,211,86,46,245,230,184,205,161,78,213,161,133,224,122,81,214,73,167,202,194,214,101,54,144,31,223,1,76,173,58,28,190,158,226,201,198,147,1,136,182,94,219,192,50,75,161,176,171,66,149,58,45,206,199,46,110,183,14,147,87,162,78,155,57,212,213,69,43,50,23,64,122,190,249,99,248,203,182,177,101,254,191,249,245,156,87,71,227,6,119,212,60,204,181,78,155,42,19,151,227,58,65,15,47,218,210,62,158,71,162,191,113,99,113,181,191,238,191,184,122,215,255,112,213,247,7,110,66,110,247,31,220,251,235,48,47,251,171,9,130,238,81,39,7,42,237,115,34,34,224,216,248,209,194,133,65,20,142,133,148,152,83,165,185,81,156,115,197,14,12,91,239,95,139,57,61,106,158,189,45,230,191,118,138,122,253,200,237,222,219,56,153,209,73,247,55,250,183,235,217,193,122,235,158,159,87,89,205,122,128,4,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,113,78,44,78,181,50,180,50,4,0,241,126,40,137,15,0,0,0 })));
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
								new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("5c72f92e-0d62-4260-a0bf-dc0eebf45678"));
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

		#region Class: ReadCaseDataUserTaskFlowElement

		/// <exclude/>
		public class ReadCaseDataUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCaseDataUserTaskFlowElement(UserConnection userConnection, SearchForParent process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCaseDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("2f48f577-b657-4507-a14f-b3d677f3f02a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,147,207,106,220,48,16,198,95,165,232,208,147,85,44,75,182,100,247,184,108,203,94,210,64,211,82,72,150,32,75,163,68,224,63,27,91,166,9,102,161,228,208,75,223,33,207,144,148,22,90,104,222,193,251,70,149,237,108,11,57,148,94,122,40,24,49,26,123,190,249,205,199,184,63,181,237,11,91,56,104,50,35,139,22,130,110,165,51,68,146,144,42,78,82,12,32,36,102,130,50,44,104,204,49,85,64,153,49,132,18,17,162,160,146,37,100,104,174,94,106,235,80,96,29,148,109,118,220,255,22,117,77,7,193,169,153,46,175,213,57,148,242,205,212,128,112,77,35,147,98,17,241,24,179,120,108,192,8,193,68,37,9,33,177,130,84,105,52,179,104,145,231,58,52,28,231,161,72,48,99,113,132,165,72,4,54,41,136,148,168,152,135,73,140,130,2,140,91,94,110,26,104,91,91,87,89,15,191,226,163,171,141,167,156,123,47,234,162,43,43,20,148,224,228,161,116,231,25,146,16,2,139,149,196,138,165,30,196,0,199,146,166,26,83,153,243,136,11,32,9,225,40,80,114,227,70,89,180,242,84,90,58,249,86,22,29,76,202,189,245,140,17,13,137,136,19,95,75,168,194,140,70,33,246,136,28,27,157,120,76,154,164,105,174,247,126,189,236,172,143,109,123,208,149,208,88,245,96,59,120,255,234,38,235,85,93,185,166,46,70,233,131,233,243,35,184,116,179,185,15,175,222,205,3,57,159,31,139,208,54,232,90,88,20,22,42,183,172,84,173,109,117,54,107,110,183,190,164,220,200,198,182,123,23,150,23,157,44,80,208,216,179,243,63,186,181,232,90,87,151,255,209,168,129,31,211,107,248,37,155,112,199,29,212,182,221,20,242,106,186,103,232,233,69,87,187,231,195,205,112,183,251,48,220,14,119,195,237,238,122,247,105,248,236,227,175,195,15,31,125,127,50,124,27,238,119,31,253,249,197,167,238,119,215,115,9,122,36,157,161,19,164,35,30,74,225,87,197,68,130,98,6,161,194,169,204,115,204,137,210,220,40,206,185,74,78,144,199,253,151,16,199,171,246,213,251,106,255,87,205,62,172,159,249,236,163,196,225,190,50,235,255,134,123,187,30,201,215,91,255,252,4,105,242,231,189,28,4,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,43,205,77,74,45,178,50,180,50,4,0,178,212,123,197,17,0,0,0 })));
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
								new Guid("117d32f9-8275-4534-8411-1c66115ce9cd")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"));
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

		#region Class: PrepareTagCollectionFlowElement

		/// <exclude/>
		public class PrepareTagCollectionFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public PrepareTagCollectionFlowElement(UserConnection userConnection, SearchForParent process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "PrepareTagCollection";
				IsLogging = true;
				SchemaElementUId = new Guid("4a618527-da26-4a7e-82d7-a0d4c8f6d67e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,77,107,220,48,16,253,43,69,135,158,172,98,201,178,101,185,199,101,11,129,146,4,250,65,33,44,97,60,26,101,213,250,43,182,76,27,204,254,247,106,215,187,109,200,161,244,208,75,193,7,105,164,247,230,189,55,242,114,239,167,119,190,9,52,86,14,154,137,146,249,202,86,172,48,169,74,157,1,158,167,96,185,146,2,57,128,149,60,43,50,5,90,164,89,86,58,150,116,208,82,197,86,244,214,250,192,18,31,168,157,170,187,229,55,105,24,103,74,238,221,105,243,1,247,212,194,167,99,3,139,70,213,86,58,158,231,105,206,85,89,35,47,177,208,92,89,89,107,2,109,106,202,217,170,69,230,166,52,89,234,56,24,225,184,50,46,94,5,68,46,44,90,161,82,68,43,21,75,26,114,97,251,99,24,105,154,124,223,85,11,253,90,127,124,26,162,202,181,247,166,111,230,182,99,73,75,1,110,33,236,43,6,25,213,37,101,5,47,108,30,133,216,210,114,131,66,113,145,202,26,181,113,164,74,96,9,194,16,142,180,236,166,254,74,24,141,142,228,104,164,14,233,153,39,33,180,205,164,51,188,148,58,82,229,153,226,165,18,130,11,44,10,33,114,36,131,150,37,22,2,124,134,102,166,147,174,197,71,96,45,77,158,234,104,46,58,55,92,81,33,121,105,5,112,35,76,237,50,29,57,157,188,164,253,190,239,191,205,67,76,122,186,158,91,26,61,158,199,70,49,255,126,172,22,236,187,48,246,205,145,252,250,25,96,29,207,249,240,203,26,73,115,58,57,2,217,33,153,39,218,52,158,186,176,237,176,183,190,123,56,77,238,112,136,152,118,128,209,79,151,32,183,143,51,52,49,0,255,176,255,99,224,155,121,10,125,251,191,249,77,162,215,72,19,31,235,73,243,241,45,91,63,13,13,60,157,246,21,123,253,56,247,225,237,237,216,99,52,75,246,149,239,208,219,72,179,214,217,11,252,229,190,149,58,133,146,52,119,178,204,162,227,20,185,129,186,230,90,160,213,14,181,214,88,156,25,14,201,63,233,120,119,53,221,124,239,46,255,220,26,218,238,77,172,190,40,220,94,208,213,242,55,34,15,187,139,204,221,33,126,63,1,218,179,228,98,62,4,0,0 })));
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,9,73,76,183,50,180,50,4,0,218,2,59,40,14,0,0,0 })));
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
								new Guid("dc94bd2f-5505-48bc-8c67-4d2b7ea79be5")),
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
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("dc94bd2f-5505-48bc-8c67-4d2b7ea79be5"));
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

		public SearchForParent(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SearchForParent";
			SchemaUId = new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_isCaseCollectionAny = () => { return (bool)(false); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eaad6977-be78-4c40-85ad-1bbdd5573c1a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SearchForParent, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SearchForParent, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid IncidentId {
			get;
			set;
		}

		private Func<bool> _isCaseCollectionAny;
		public virtual bool IsCaseCollectionAny {
			get {
				return (_isCaseCollectionAny ?? (_isCaseCollectionAny = () => false)).Invoke();
			}
			set {
				_isCaseCollectionAny = () => { return value; };
			}
		}

		private ProcessFirstSupportLine _firstSupportLine;
		public ProcessFirstSupportLine FirstSupportLine {
			get {
				return _firstSupportLine ?? ((_firstSupportLine) = new ProcessFirstSupportLine(UserConnection, this));
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
					SchemaElementUId = new Guid("bfc04a7f-3451-4aab-b2ce-0f992a937a13"),
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
					SchemaElementUId = new Guid("c54dcc84-10c3-4c6b-83d2-71375cca6121"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private SearchForParentPreconfiguredPageUserTaskFlowElement _searchForParentPreconfiguredPageUserTask;
		public SearchForParentPreconfiguredPageUserTaskFlowElement SearchForParentPreconfiguredPageUserTask {
			get {
				return _searchForParentPreconfiguredPageUserTask ?? (_searchForParentPreconfiguredPageUserTask = new SearchForParentPreconfiguredPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ChangeDataUserTask1FlowElement _changeDataUserTask1;
		public ChangeDataUserTask1FlowElement ChangeDataUserTask1 {
			get {
				return _changeDataUserTask1 ?? (_changeDataUserTask1 = new ChangeDataUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadConfItemDataUserTaskFlowElement _readConfItemDataUserTask;
		public ReadConfItemDataUserTaskFlowElement ReadConfItemDataUserTask {
			get {
				return _readConfItemDataUserTask ?? (_readConfItemDataUserTask = new ReadConfItemDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _prepareCaseCollection;
		public ProcessScriptTask PrepareCaseCollection {
			get {
				return _prepareCaseCollection ?? (_prepareCaseCollection = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareCaseCollection",
					SchemaElementUId = new Guid("f223b416-07f8-4d28-be9a-ff5273b6274f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = PrepareCaseCollectionExecute,
				});
			}
		}

		private ReadCaseDataUserTaskFlowElement _readCaseDataUserTask;
		public ReadCaseDataUserTaskFlowElement ReadCaseDataUserTask {
			get {
				return _readCaseDataUserTask ?? (_readCaseDataUserTask = new ReadCaseDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private PrepareTagCollectionFlowElement _prepareTagCollection;
		public PrepareTagCollectionFlowElement PrepareTagCollection {
			get {
				return _prepareTagCollection ?? (_prepareTagCollection = new PrepareTagCollectionFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessConditionalFlow _parentCaseSelectedConditionalFlow;
		public ProcessConditionalFlow ParentCaseSelectedConditionalFlow {
			get {
				return _parentCaseSelectedConditionalFlow ?? (_parentCaseSelectedConditionalFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ParentCaseSelectedConditionalFlow",
					SchemaElementUId = new Guid("d0644cf4-411e-46d8-b79c-a9b7c342f134"),
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
					SchemaElementUId = new Guid("4350a31d-c5db-45f9-8efd-4f58d1b70544"),
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
			FlowElements[SearchForParentPreconfiguredPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchForParentPreconfiguredPageUserTask };
			FlowElements[ChangeDataUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeDataUserTask1 };
			FlowElements[ReadConfItemDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadConfItemDataUserTask };
			FlowElements[PrepareCaseCollection.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareCaseCollection };
			FlowElements[ReadCaseDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCaseDataUserTask };
			FlowElements[PrepareTagCollection.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareTagCollection };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseDataUserTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SearchForParentPreconfiguredPageUserTask":
						if (ParentCaseSelectedConditionalFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ChangeDataUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ChangeDataUserTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ReadConfItemDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareTagCollection", e.Context.SenderName));
						break;
					case "PrepareCaseCollection":
						if (ConditionalFlow1ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchForParentPreconfiguredPageUserTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						Log.ErrorFormat(DeadEndGatewayLogMessage, "PrepareCaseCollection");
						break;
					case "ReadCaseDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadConfItemDataUserTask", e.Context.SenderName));
						break;
					case "PrepareTagCollection":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareCaseCollection", e.Context.SenderName));
						break;
			}
		}

		private bool ParentCaseSelectedConditionalFlowExpressionExecute() {
			bool result = Convert.ToBoolean((SearchForParentPreconfiguredPageUserTask.Result) != Guid.Empty);
			Log.InfoFormat(ConditionalExpressionLogMessage, "SearchForParentPreconfiguredPageUserTask", "ParentCaseSelectedConditionalFlow", "(SearchForParentPreconfiguredPageUserTask.Result) != Guid.Empty", result);
			return result;
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((IsCaseCollectionAny));
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareCaseCollection", "ConditionalFlow1", "(IsCaseCollectionAny)", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.ServiceItem")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.ServiceItem", SearchForParentPreconfiguredPageUserTask.ServiceItem, Guid.Empty);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.TotalPages")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.TotalPages", SearchForParentPreconfiguredPageUserTask.TotalPages, 0);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.CurrentPageNumber")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.CurrentPageNumber", SearchForParentPreconfiguredPageUserTask.CurrentPageNumber, 0);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.Result")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.Result", SearchForParentPreconfiguredPageUserTask.Result, Guid.Empty);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.PageTitle")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.PageTitle", SearchForParentPreconfiguredPageUserTask.PageTitle, null);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.HidePageNumbers")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.HidePageNumbers", SearchForParentPreconfiguredPageUserTask.HidePageNumbers, false);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.CaseId")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.CaseId", SearchForParentPreconfiguredPageUserTask.CaseId, Guid.Empty);
			}
			if (!HasMapping("SearchForParentPreconfiguredPageUserTask.CaseCollectionParam")) {
				writer.WriteValue("SearchForParentPreconfiguredPageUserTask.CaseCollectionParam", SearchForParentPreconfiguredPageUserTask.CaseCollectionParam, null);
			}
			if (!HasMapping("IncidentId")) {
				writer.WriteValue("IncidentId", IncidentId, Guid.Empty);
			}
			if (!HasMapping("IsCaseCollectionAny")) {
				writer.WriteValue("IsCaseCollectionAny", IsCaseCollectionAny, false);
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
			MetaPathParameterValues.Add("d270a8e7-f283-4e0c-9abb-71cd7fc777c6", () => IncidentId);
			MetaPathParameterValues.Add("f83d82b0-58af-4e46-968e-7c6ef3d7b958", () => IsCaseCollectionAny);
			MetaPathParameterValues.Add("425b83a9-1efb-4042-8357-a8bb999509f4", () => SearchForParentPreconfiguredPageUserTask.Title);
			MetaPathParameterValues.Add("22d91d0f-7c9a-4ab4-be73-b242a2d32322", () => SearchForParentPreconfiguredPageUserTask.Recommendation);
			MetaPathParameterValues.Add("1396cfec-96e9-4358-ba2a-db56f25466d7", () => SearchForParentPreconfiguredPageUserTask.ClientUnitSchemaUId);
			MetaPathParameterValues.Add("91d5ab47-a61f-4071-804e-e9f0565f3ccc", () => SearchForParentPreconfiguredPageUserTask.EntityId);
			MetaPathParameterValues.Add("3f5d1bed-0e68-4f37-b37a-fa58e5f88671", () => SearchForParentPreconfiguredPageUserTask.EntryPointId);
			MetaPathParameterValues.Add("f80ca0e3-df11-4e51-8ed1-7b98c0dffeee", () => SearchForParentPreconfiguredPageUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("a30c0fcd-9d71-4b13-82ee-e7dba8cf37b0", () => SearchForParentPreconfiguredPageUserTask.UseCardProcessModule);
			MetaPathParameterValues.Add("dea4a681-ca88-4b34-bd1d-b2d572da8b1b", () => SearchForParentPreconfiguredPageUserTask.OwnerId);
			MetaPathParameterValues.Add("659d70cd-0a71-48d8-9eff-11a205ff4b3d", () => SearchForParentPreconfiguredPageUserTask.ShowExecutionPage);
			MetaPathParameterValues.Add("b662c6d3-20ec-4889-a118-c2838daa4b62", () => SearchForParentPreconfiguredPageUserTask.InformationOnStep);
			MetaPathParameterValues.Add("c2cbff2b-348c-417e-8ba3-b85b5b4ef5b8", () => SearchForParentPreconfiguredPageUserTask.IsRunning);
			MetaPathParameterValues.Add("8ba33687-5e4c-454f-8aa0-d22b56e32508", () => SearchForParentPreconfiguredPageUserTask.Template);
			MetaPathParameterValues.Add("95c6ed03-2663-4205-847c-1137f59adb30", () => SearchForParentPreconfiguredPageUserTask.Module);
			MetaPathParameterValues.Add("8e7559c6-ad77-4d0f-8512-f964ffb9a186", () => SearchForParentPreconfiguredPageUserTask.PressedButtonCode);
			MetaPathParameterValues.Add("e05f2695-cd1e-4a51-ad6d-a9fa60f22136", () => SearchForParentPreconfiguredPageUserTask.Url);
			MetaPathParameterValues.Add("4c783172-9a5a-450a-baea-b52e66e02f52", () => SearchForParentPreconfiguredPageUserTask.CurrentActivityId);
			MetaPathParameterValues.Add("642ed77b-26bf-41d7-9c9c-98038397b24d", () => SearchForParentPreconfiguredPageUserTask.CreateActivity);
			MetaPathParameterValues.Add("3e47ec93-aacf-48c8-b3ce-f6281a04dc99", () => SearchForParentPreconfiguredPageUserTask.ActivityPriority);
			MetaPathParameterValues.Add("1f4f05a6-085a-4578-8188-cbe09e32ee8a", () => SearchForParentPreconfiguredPageUserTask.StartIn);
			MetaPathParameterValues.Add("04c34bd7-c7ac-46c8-b841-8acbd9d11b5e", () => SearchForParentPreconfiguredPageUserTask.StartInPeriod);
			MetaPathParameterValues.Add("9ea41743-58bb-4efa-8847-c42b2553eb3a", () => SearchForParentPreconfiguredPageUserTask.Duration);
			MetaPathParameterValues.Add("78518cc8-fc5d-4014-bc90-7588d6c84bc5", () => SearchForParentPreconfiguredPageUserTask.DurationPeriod);
			MetaPathParameterValues.Add("d83282e1-0bb3-44be-bb06-84420718be91", () => SearchForParentPreconfiguredPageUserTask.ShowInScheduler);
			MetaPathParameterValues.Add("6249bf0f-aa58-49c2-a544-c5fa3852885e", () => SearchForParentPreconfiguredPageUserTask.RemindBefore);
			MetaPathParameterValues.Add("1142a5af-7c39-4c81-878b-c9f0efae8c95", () => SearchForParentPreconfiguredPageUserTask.RemindBeforePeriod);
			MetaPathParameterValues.Add("835359b5-1e6b-4d27-8fbe-92df87561c96", () => SearchForParentPreconfiguredPageUserTask.ActivityResult);
			MetaPathParameterValues.Add("f9723d34-5a49-42e5-8f2a-717b8a87feee", () => SearchForParentPreconfiguredPageUserTask.IsActivityCompleted);
			MetaPathParameterValues.Add("0a201783-e5a9-49bb-aa18-483539cd7e45", () => SearchForParentPreconfiguredPageUserTask.ServiceItem);
			MetaPathParameterValues.Add("6220e5ea-1f4c-4e9b-b033-f97c376b240c", () => SearchForParentPreconfiguredPageUserTask.TotalPages);
			MetaPathParameterValues.Add("e9db3967-c4c4-4bc4-8167-944c1682b12c", () => SearchForParentPreconfiguredPageUserTask.CurrentPageNumber);
			MetaPathParameterValues.Add("6eda63e0-df98-4e32-8946-8d99267b8943", () => SearchForParentPreconfiguredPageUserTask.Result);
			MetaPathParameterValues.Add("929b077b-0f50-49ff-a5b4-a1f72fb2e16c", () => SearchForParentPreconfiguredPageUserTask.PageTitle);
			MetaPathParameterValues.Add("11939531-2013-4afa-b680-6c5672ac4563", () => SearchForParentPreconfiguredPageUserTask.HidePageNumbers);
			MetaPathParameterValues.Add("0662da67-49e4-4828-8aac-06b388cca81f", () => SearchForParentPreconfiguredPageUserTask.CaseId);
			MetaPathParameterValues.Add("21cdc12a-97d7-4875-9cbc-8e89b57b8f11", () => SearchForParentPreconfiguredPageUserTask.CaseCollectionParam);
			MetaPathParameterValues.Add("ace78947-8c57-47c0-ae85-c57a5821bb13", () => ChangeDataUserTask1.EntitySchemaUId);
			MetaPathParameterValues.Add("d8ec807d-7f8d-4037-b2ab-9c88007c0121", () => ChangeDataUserTask1.IsMatchConditions);
			MetaPathParameterValues.Add("d9594b77-041b-46f3-9024-1bd044d68726", () => ChangeDataUserTask1.DataSourceFilters);
			MetaPathParameterValues.Add("55f85150-f401-4e97-9d12-0f211ee35972", () => ChangeDataUserTask1.RecordColumnValues);
			MetaPathParameterValues.Add("b83b75e8-6acc-4689-bbf7-582ce39c2c52", () => ChangeDataUserTask1.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("cd861df3-40fb-4186-b65e-25dba80f9e24", () => ReadConfItemDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("84cb8b09-ef03-435e-8588-4e64e6ef5a4f", () => ReadConfItemDataUserTask.ResultType);
			MetaPathParameterValues.Add("97a0ecd6-d533-479c-a450-c4a2577641d4", () => ReadConfItemDataUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("05538184-0f57-423a-b191-c5dbdac068f8", () => ReadConfItemDataUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("c73f9f80-fd7b-4cf1-acb9-d60091d0f344", () => ReadConfItemDataUserTask.FunctionType);
			MetaPathParameterValues.Add("a13349cc-1228-4922-a0ff-008c512c950b", () => ReadConfItemDataUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("93e4cd31-714c-41ca-ae3a-d8696adcf3dd", () => ReadConfItemDataUserTask.OrderInfo);
			MetaPathParameterValues.Add("5f8f8252-4b03-4c7c-bd80-b7808545ec0c", () => ReadConfItemDataUserTask.ResultEntity);
			MetaPathParameterValues.Add("c76d235a-b599-4654-ba0e-21d29510a3b3", () => ReadConfItemDataUserTask.ResultCount);
			MetaPathParameterValues.Add("7fde92e2-24aa-451d-bd80-ee4640257ed9", () => ReadConfItemDataUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("0294f17d-4f4c-41a8-84bd-41091d1e9884", () => ReadConfItemDataUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("d1c4b637-39da-474d-980c-8c8ad96125c5", () => ReadConfItemDataUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("44873c50-da69-45fb-b889-4e99c0c63fba", () => ReadConfItemDataUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("4066fd99-ee9a-4434-9b7d-3d6cfe69c3ed", () => ReadConfItemDataUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("2b138545-6ab5-4b6c-bd27-a904e645cb89", () => ReadConfItemDataUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("cf362cd5-a00c-4a73-a580-9a64f6cb55ac", () => ReadConfItemDataUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("46bc0544-e508-430d-b9ad-6eb5ebd0d48b", () => ReadConfItemDataUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("b3b88c4d-1145-42ce-ad37-072eba74f9e9", () => ReadConfItemDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("fc16705b-812d-4776-9714-918b172caedb", () => ReadConfItemDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("acf43b55-9bc9-4f23-ab2f-4be0d0fda31f", () => ReadCaseDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("870b6336-1d39-430f-af59-ef5b32142e14", () => ReadCaseDataUserTask.ResultType);
			MetaPathParameterValues.Add("14b1a615-9e84-4bf2-95fa-7edb14a5255f", () => ReadCaseDataUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("dd90fd1c-0563-48f6-ab88-502b7089d065", () => ReadCaseDataUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("fbbe03b2-1467-4b16-bce2-946a0ea9dde1", () => ReadCaseDataUserTask.FunctionType);
			MetaPathParameterValues.Add("2a0c0741-97b6-4dfb-9773-ab3e71bf05e7", () => ReadCaseDataUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("e50d1955-15fb-4f03-add8-674d9bdd2878", () => ReadCaseDataUserTask.OrderInfo);
			MetaPathParameterValues.Add("72430e28-8bf4-41c4-8aa3-392123b79311", () => ReadCaseDataUserTask.ResultEntity);
			MetaPathParameterValues.Add("64981203-3d0d-4db5-b21e-8d95f119545f", () => ReadCaseDataUserTask.ResultCount);
			MetaPathParameterValues.Add("0594e91b-20aa-47ba-b7b9-c3c046612aff", () => ReadCaseDataUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("e97c2cc7-5ef7-4027-b501-41a79b2a21b2", () => ReadCaseDataUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("6fb0bacd-1017-4b1c-8458-a9b76a08c1d0", () => ReadCaseDataUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("380ab258-c3ad-496b-ad59-c7ba3f40c610", () => ReadCaseDataUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("6ce7255d-b559-43d6-bed7-f3e91167dbf8", () => ReadCaseDataUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("19c3b6f8-27ba-43df-be8e-76a89b378ea5", () => ReadCaseDataUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("1087a0aa-984b-42e6-b132-8d5478f65528", () => ReadCaseDataUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("4faa6e56-1123-4ec1-909d-aaad325be138", () => ReadCaseDataUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("ecf2b48d-c38d-48cb-a233-e4b616357e3c", () => ReadCaseDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("d7133309-cc59-49d6-b3fd-885a5d735a8b", () => ReadCaseDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6418d70e-c8df-4215-a8a3-cb363d472ec0", () => PrepareTagCollection.DataSourceFilters);
			MetaPathParameterValues.Add("ad80f9ab-24d3-4614-ac24-e78e1e7f8cc9", () => PrepareTagCollection.ResultType);
			MetaPathParameterValues.Add("fd932721-9572-4d4d-9ae0-a53f2f7a9404", () => PrepareTagCollection.ReadSomeTopRecords);
			MetaPathParameterValues.Add("8fe4967a-019f-4732-8095-d40150ef5806", () => PrepareTagCollection.NumberOfRecords);
			MetaPathParameterValues.Add("5fb9d631-8efe-459a-9bd5-6fed2139169c", () => PrepareTagCollection.FunctionType);
			MetaPathParameterValues.Add("e4e5c77d-f138-4aa2-94e0-b84a088abacc", () => PrepareTagCollection.AggregationColumnName);
			MetaPathParameterValues.Add("259d4266-8c7e-4c27-b0f0-98cdf9128a23", () => PrepareTagCollection.OrderInfo);
			MetaPathParameterValues.Add("21277763-11c1-45b5-85ba-7d1933f003a9", () => PrepareTagCollection.ResultEntity);
			MetaPathParameterValues.Add("fe355ae7-ae4c-401b-9d39-9d56030ea11c", () => PrepareTagCollection.ResultCount);
			MetaPathParameterValues.Add("db47687b-5a80-4a97-8e54-fd79fc9357df", () => PrepareTagCollection.ResultIntegerFunction);
			MetaPathParameterValues.Add("8db483e0-0d10-4173-987c-761a50993f1c", () => PrepareTagCollection.ResultFloatFunction);
			MetaPathParameterValues.Add("66a32598-4247-4928-9458-69deda5a2d2d", () => PrepareTagCollection.ResultDateTimeFunction);
			MetaPathParameterValues.Add("03fa10e4-0653-4807-96a6-5f7afd87fa99", () => PrepareTagCollection.ResultRowsCount);
			MetaPathParameterValues.Add("e7e86faa-f353-40d1-bda1-b828e648e3e6", () => PrepareTagCollection.CanReadUncommitedData);
			MetaPathParameterValues.Add("7964a7ec-d994-44ef-b450-d3fd3382705c", () => PrepareTagCollection.ResultEntityCollection);
			MetaPathParameterValues.Add("2ed44ec2-017e-412a-9306-9b3ae4a16754", () => PrepareTagCollection.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("9dd501c5-5d42-4870-8c69-3f4c0982c50a", () => PrepareTagCollection.IgnoreDisplayValues);
			MetaPathParameterValues.Add("0a753d00-49c7-4c86-aa62-204444f905ca", () => PrepareTagCollection.ResultCompositeObjectList);
			MetaPathParameterValues.Add("594f66a8-16d4-4085-ad92-aa80b470c409", () => PrepareTagCollection.ConsiderTimeInFilter);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SearchForParentPreconfiguredPageUserTask.ServiceItem":
					SearchForParentPreconfiguredPageUserTask.ServiceItem = reader.GetValue<System.Guid>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.TotalPages":
					SearchForParentPreconfiguredPageUserTask.TotalPages = reader.GetValue<System.Int32>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.CurrentPageNumber":
					SearchForParentPreconfiguredPageUserTask.CurrentPageNumber = reader.GetValue<System.Int32>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.Result":
					SearchForParentPreconfiguredPageUserTask.Result = reader.GetValue<System.Guid>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.PageTitle":
					SearchForParentPreconfiguredPageUserTask.PageTitle = reader.GetValue<System.String>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.HidePageNumbers":
					SearchForParentPreconfiguredPageUserTask.HidePageNumbers = reader.GetValue<System.Boolean>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.CaseId":
					SearchForParentPreconfiguredPageUserTask.CaseId = reader.GetValue<System.Guid>();
				break;
				case "SearchForParentPreconfiguredPageUserTask.CaseCollectionParam":
					SearchForParentPreconfiguredPageUserTask.CaseCollectionParam = reader.GetValue<System.String>();
				break;
				case "IncidentId":
					if (!hasValueToRead) break;
					IncidentId = reader.GetValue<System.Guid>();
				break;
				case "IsCaseCollectionAny":
					if (!hasValueToRead) break;
					IsCaseCollectionAny = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareCaseCollectionExecute(ProcessExecutingContext context) {
			var esqCase = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Case");
			esqCase.AddColumn("Id");
			esqCase.AddColumn("RegisteredOn").OrderDirection = OrderDirection.Descending;
			esqCase.Filters.Add(esqCase.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id", IncidentId));
			esqCase.Filters.Add(esqCase.CreateFilterWithParameters(FilterComparisonType.Equal, "Status.IsFinal", false));
			esqCase.Filters.LogicalOperation = LogicalOperationStrict.And;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Case");
			esq.AddColumn("Id");
			esq.Filters.LogicalOperation = LogicalOperationStrict.Or;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ServiceItem", ReadCaseDataUserTask.ResultEntity.GetColumnValue("ServiceItemId")));
			var entityList = new List<Entity>(ReadConfItemDataUserTask.ResultEntityCollection);
			var guidArray = entityList.Select(m=>m.GetTypedColumnValue<Object>("ConfItemId")).ToArray();
			if (guidArray.Count() == 0) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[ConfItemInCase:Case].ConfItem", Guid.Empty));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[ConfItemInCase:Case].ConfItem", guidArray));
			}
			var tags = new List<Entity>(PrepareTagCollection.ResultEntityCollection);
			var tagArray = tags.Select(m => m.GetTypedColumnValue<Object>("TagId")).ToArray();
			if (tagArray.Count() == 0)
			{
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[CaseInTag:Entity].Tag", Guid.Empty));
			} else {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[CaseInTag:Entity].Tag", tagArray));
			}
			esqCase.Filters.Add(esqCase.CreateFilter(FilterComparisonType.Equal, "Id", esq));
			var result = esqCase.GetEntityCollection(UserConnection);
			var localCollection = new EntityCollection(UserConnection, "Case");
			foreach(var element in result){
				localCollection.Add(element);
			}
			IsCaseCollectionAny = localCollection.Any();
			SearchForParentPreconfiguredPageUserTask.CaseCollectionParam = String.Join("|", localCollection.Select(e=>e.GetTypedColumnValue<string>("Id1")).ToArray());
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
			var cloneItem = (SearchForParent)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

