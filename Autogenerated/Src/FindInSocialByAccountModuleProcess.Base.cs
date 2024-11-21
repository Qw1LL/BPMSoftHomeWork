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
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: FindInSocialByAccountModuleProcessSchema

	/// <exclude/>
	public class FindInSocialByAccountModuleProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FindInSocialByAccountModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FindInSocialByAccountModuleProcessSchema(FindInSocialByAccountModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FindInSocialByAccountModuleProcess";
			UId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"ru-RU";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,207,106,2,49,16,198,207,93,240,29,166,158,118,97,217,23,40,61,184,219,42,30,44,162,109,47,165,135,49,206,106,32,59,41,179,137,34,197,119,111,246,79,169,43,197,64,66,248,38,243,251,50,223,40,250,242,27,163,21,28,180,56,143,6,242,229,98,109,75,151,21,150,75,189,243,130,78,91,206,38,74,89,207,14,102,228,250,107,156,192,247,40,186,59,160,0,118,202,90,237,169,66,120,132,183,154,36,180,51,169,182,247,153,157,118,167,174,186,64,198,29,73,22,56,115,174,29,178,162,252,244,130,21,197,227,158,59,78,30,134,216,0,28,24,100,133,16,58,234,168,241,208,43,1,172,111,79,208,192,55,214,26,40,201,169,253,138,106,111,46,28,178,105,163,78,197,86,79,121,60,116,93,138,174,80,78,133,53,190,226,20,38,193,239,64,175,66,52,19,189,45,188,8,177,91,217,227,124,155,2,211,241,227,179,77,7,110,175,171,185,90,116,157,77,53,111,243,222,232,29,141,167,46,159,230,28,39,233,63,212,115,27,153,46,33,190,191,152,42,233,63,240,23,35,123,99,154,151,231,176,133,156,23,254,45,6,53,136,163,232,7,107,110,98,176,14,2,0,0 };
			RealUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8ca30f19-9cae-41b2-9e53-50e6900eade9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f1fd73da-cef6-4f62-aa6d-20b9dd4afc4d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateGotoMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("00425624-ef91-4ef3-b40b-176be00367ff"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"GotoMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRecordsNotSelectedLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f121eaf0-90bf-4549-8aaf-973323d99855"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"RecordsNotSelectedLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateGotoMessageParameter());
			Parameters.Add(CreateRecordsNotSelectedLSParameter());
		}

		protected virtual void InitializeOpenMatchFoundWindowUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5ba49010-536e-487d-a830-9e6a8775935b"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			pageUIdParameter.SourceValue = new ProcessSchemaParameterValue(pageUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUIdParameter);
			var pageUrlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("24be2b71-1d40-40f4-a06b-d6b780a1af27"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pageUrlParameter.SourceValue = new ProcessSchemaParameterValue(pageUrlParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUrlParameter);
			var openerInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c89bb7f3-5063-4e57-870b-0bc7e0ba4f39"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"OpenerInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			openerInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(openerInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(openerInstanceIdParameter);
			var closeOpenerOnLoadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0423a29f-4e0c-456f-b873-792938f5e8c9"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseOpenerOnLoad",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			closeOpenerOnLoadParameter.SourceValue = new ProcessSchemaParameterValue(closeOpenerOnLoadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeOpenerOnLoadParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("08d541a2-13ad-4adb-b81c-5b5d541048dd"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageParameters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParametersParameter.SourceValue = new ProcessSchemaParameterValue(pageParametersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
			var widthParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cf7ec42b-628c-484f-99fa-4120d7f6e2ae"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Width",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			widthParameter.SourceValue = new ProcessSchemaParameterValue(widthParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(widthParameter);
			var closeMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4701c20a-64b0-45ba-930e-9f658bd6ac86"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			closeMessageParameter.SourceValue = new ProcessSchemaParameterValue(closeMessageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeMessageParameter);
			var heightParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("388d4574-b1e6-4401-ae1f-8ed913fb5456"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Height",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			heightParameter.SourceValue = new ProcessSchemaParameterValue(heightParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(heightParameter);
			var centeredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1483c481-5039-4511-982f-ce88ec124569"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Centered",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			centeredParameter.SourceValue = new ProcessSchemaParameterValue(centeredParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(centeredParameter);
			var useOpenerRegisterScriptParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("50a53dcc-51b0-44a4-8949-74491b0de081"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseOpenerRegisterScript",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useOpenerRegisterScriptParameter.SourceValue = new ProcessSchemaParameterValue(useOpenerRegisterScriptParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useOpenerRegisterScriptParameter);
			var useCurrentActivePageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2abe27c-5b71-43ae-ac11-3614df4aff14"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseCurrentActivePage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCurrentActivePageParameter.SourceValue = new ProcessSchemaParameterValue(useCurrentActivePageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useCurrentActivePageParameter);
			var ignoreProfileParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7e6c667f-2911-42c5-bad4-afd98940d6ab"),
				ContainerUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"IgnoreProfile",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreProfileParameter.SourceValue = new ProcessSchemaParameterValue(ignoreProfileParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreProfileParameter);
		}

		protected virtual void InitializeMessageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("516a23b1-866d-4279-b268-3015b55738ac"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParameter.SourceValue = new ProcessSchemaParameterValue(pageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParameter);
			var iconParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eee653b3-9460-4687-b24f-8881935762e7"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Icon",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			iconParameter.SourceValue = new ProcessSchemaParameterValue(iconParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(iconParameter);
			var buttonsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f0b46daf-66af-4af7-90ed-62cbe804a3bd"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Buttons",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			buttonsParameter.SourceValue = new ProcessSchemaParameterValue(buttonsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(buttonsParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b8498606-729d-45e7-9da8-0a905b16a68f"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var messageTextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f198834b-fa52-4d04-9b82-80cde79c9d6a"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"MessageText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			messageTextParameter.SourceValue = new ProcessSchemaParameterValue(messageTextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(messageTextParameter);
			var responseMessagesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("88a39807-124a-42f8-886e-b475151d31a0"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"ResponseMessages",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			responseMessagesParameter.SourceValue = new ProcessSchemaParameterValue(responseMessagesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(responseMessagesParameter);
			var processInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34800313-4062-4a2d-94ca-1440184eb100"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"ProcessInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			processInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(processInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(processInstanceIdParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("92c81a8c-6ceb-40fb-a244-72b8912644d2"),
				ContainerUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"PageParameters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParametersParameter.SourceValue = new ProcessSchemaParameterValue(pageParametersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask prepareopenmatchfoundwindowscripttask = CreatePrepareOpenMatchFoundWindowScriptTaskScriptTask();
			FlowElements.Add(prepareopenmatchfoundwindowscripttask);
			ProcessSchemaUserTask openmatchfoundwindowusertask = CreateOpenMatchFoundWindowUserTaskUserTask();
			FlowElements.Add(openmatchfoundwindowusertask);
			ProcessSchemaUserTask messageusertask = CreateMessageUserTaskUserTask();
			FlowElements.Add(messageusertask);
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("7ffe84d0-e599-473c-8cbc-82b9ccb7c0f8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2c1ba7e9-9e2c-4a41-8d51-39989cf3d9a5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("67ace457-11f5-40d7-90c5-fb3ea25990cc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("f6fd57bd-f3a8-4a5b-8687-7ea35e055c18"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				CurveCenterPosition = new Point(386, 42),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5fe281c8-d301-4145-aee1-a6f24779c9e9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("80755b51-a368-48c4-92e3-37b182c02c25"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				CurveCenterPosition = new Point(326, 109),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5fe281c8-d301-4145-aee1-a6f24779c9e9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("1c9993c2-1fec-4cd4-ab35-5a52e4c24535"),
				ConditionExpression = @"GotoMessage",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				CurveCenterPosition = new Point(175, 118),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("67ace457-11f5-40d7-90c5-fb3ea25990cc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("b6eca52a-6daf-4376-852a-56fae00b38c5"),
				ConditionExpression = @"!GotoMessage",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				CurveCenterPosition = new Point(258, 42),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("67ace457-11f5-40d7-90c5-fb3ea25990cc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("0aa70380-2028-4ed3-bf0d-1902e2505ab7"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("5be9909a-38f9-46db-ac17-f42d374ae5eb"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("0aa70380-2028-4ed3-bf0d-1902e2505ab7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("2c1ba7e9-9e2c-4a41-8d51-39989cf3d9a5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5be9909a-38f9-46db-ac17-f42d374ae5eb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"Start1",
				Position = new Point(36, 23),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("5fe281c8-d301-4145-aee1-a6f24779c9e9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5be9909a-38f9-46db-ac17-f42d374ae5eb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"End1",
				Position = new Point(393, 23),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareOpenMatchFoundWindowScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("67ace457-11f5-40d7-90c5-fb3ea25990cc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5be9909a-38f9-46db-ac17-f42d374ae5eb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"PrepareOpenMatchFoundWindowScriptTask",
				Position = new Point(106, 9),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,219,110,194,48,12,125,30,95,17,229,169,104,168,63,176,139,196,152,64,213,70,65,148,105,207,81,226,141,104,37,65,78,74,135,166,253,251,156,182,172,29,227,242,212,196,246,177,79,124,78,183,2,217,70,188,67,38,87,176,22,83,97,232,140,236,142,69,243,195,96,255,197,1,142,172,49,32,189,182,38,158,128,255,147,143,248,63,8,239,223,244,182,52,96,45,188,92,141,109,97,84,40,161,238,255,38,134,110,137,113,94,24,9,15,187,84,172,33,226,67,41,9,226,167,1,12,238,23,190,111,42,234,52,117,35,108,83,27,81,78,191,177,232,55,119,199,76,145,231,125,246,213,187,154,88,111,167,224,92,205,192,99,1,55,189,171,38,16,158,182,20,238,35,158,163,149,20,218,83,73,20,149,238,47,47,137,58,130,72,164,53,84,196,147,116,60,227,71,242,205,125,9,159,129,234,2,164,69,229,82,235,51,200,105,145,160,158,51,2,33,248,2,77,67,234,187,122,222,70,32,109,193,3,58,130,25,40,217,163,174,246,46,112,119,235,60,106,243,62,96,245,247,62,188,58,64,156,149,90,228,97,178,123,130,93,32,213,137,112,118,205,38,133,86,113,10,101,248,70,253,120,105,179,170,65,192,183,227,226,161,82,17,207,58,200,193,65,231,99,229,32,80,174,70,168,41,164,5,33,26,5,226,32,229,145,250,70,175,68,81,233,144,222,181,133,37,2,76,80,171,81,129,8,198,47,108,153,168,14,195,147,20,83,240,165,197,15,234,195,135,121,30,204,49,219,128,169,76,83,89,230,85,27,101,203,86,224,160,77,37,235,95,83,198,149,186,179,75,208,121,87,149,150,208,5,100,72,2,158,54,213,89,48,29,154,157,212,139,106,126,161,218,43,103,145,163,220,58,104,45,207,15,11,171,188,34,211,118,237,247,3,114,19,194,70,17,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenMatchFoundWindowUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5be9909a-38f9-46db-ac17-f42d374ae5eb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"OpenMatchFoundWindowUserTask",
				Position = new Point(239, 9),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenMatchFoundWindowUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5be9909a-38f9-46db-ac17-f42d374ae5eb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"),
				Name = @"MessageUserTask",
				Position = new Point(106, 128),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("21bb560b-03ed-4dd3-8390-5284ecfd0a8d"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d75f3aa9-1539-4e94-b0a2-27c43a546be6"),
				Name = "BPMSoft.UI.WebControls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FindInSocialByAccountModuleProcess(userConnection);
		}

		public override object Clone() {
			return new FindInSocialByAccountModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c8553767-fcca-4062-a6fd-562cc5f07928"));
		}

		#endregion

	}

	#endregion

	#region Class: FindInSocialByAccountModuleProcess

	/// <exclude/>
	public class FindInSocialByAccountModuleProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, FindInSocialByAccountModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenMatchFoundWindowUserTaskFlowElement

		/// <exclude/>
		public class OpenMatchFoundWindowUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenMatchFoundWindowUserTaskFlowElement(UserConnection userConnection, FindInSocialByAccountModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenMatchFoundWindowUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("55e1953e-0e74-491c-94a1-dee6892e7d84");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: MessageUserTaskFlowElement

		/// <exclude/>
		public class MessageUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public MessageUserTaskFlowElement(UserConnection userConnection, FindInSocialByAccountModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "MessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("47091845-3f55-47ee-af14-59a8d1ce5535");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public FindInSocialByAccountModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FindInSocialByAccountModuleProcess";
			SchemaUId = new Guid("c8553767-fcca-4062-a6fd-562cc5f07928");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c8553767-fcca-4062-a6fd-562cc5f07928");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FindInSocialByAccountModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FindInSocialByAccountModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual bool GotoMessage {
			get;
			set;
		}

		private LocalizableString _recordsNotSelectedLS;
		public virtual LocalizableString RecordsNotSelectedLS {
			get {
				return _recordsNotSelectedLS ?? (_recordsNotSelectedLS = GetLocalizableString("c8553767fcca4062a6fd562cc5f07928",
						 "Parameters.RecordsNotSelectedLS.Value"));
			}
			set {
				_recordsNotSelectedLS = value;
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
					SchemaElementUId = new Guid("2c1ba7e9-9e2c-4a41-8d51-39989cf3d9a5"),
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
					SchemaElementUId = new Guid("5fe281c8-d301-4145-aee1-a6f24779c9e9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareOpenMatchFoundWindowScriptTask;
		public ProcessScriptTask PrepareOpenMatchFoundWindowScriptTask {
			get {
				return _prepareOpenMatchFoundWindowScriptTask ?? (_prepareOpenMatchFoundWindowScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareOpenMatchFoundWindowScriptTask",
					SchemaElementUId = new Guid("67ace457-11f5-40d7-90c5-fb3ea25990cc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareOpenMatchFoundWindowScriptTaskExecute,
				});
			}
		}

		private OpenMatchFoundWindowUserTaskFlowElement _openMatchFoundWindowUserTask;
		public OpenMatchFoundWindowUserTaskFlowElement OpenMatchFoundWindowUserTask {
			get {
				return _openMatchFoundWindowUserTask ?? (_openMatchFoundWindowUserTask = new OpenMatchFoundWindowUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private MessageUserTaskFlowElement _messageUserTask;
		public MessageUserTaskFlowElement MessageUserTask {
			get {
				return _messageUserTask ?? (_messageUserTask = new MessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("1c9993c2-1fec-4cd4-ab35-5a52e4c24535"),
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
					SchemaElementUId = new Guid("b6eca52a-6daf-4376-852a-56fae00b38c5"),
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
			FlowElements[PrepareOpenMatchFoundWindowScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareOpenMatchFoundWindowScriptTask };
			FlowElements[OpenMatchFoundWindowUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenMatchFoundWindowUserTask };
			FlowElements[MessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MessageUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareOpenMatchFoundWindowScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "PrepareOpenMatchFoundWindowScriptTask":
						if (ConditionalFlow1ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("MessageUserTask", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow2ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenMatchFoundWindowUserTask", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "PrepareOpenMatchFoundWindowScriptTask");
						break;
					case "OpenMatchFoundWindowUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "MessageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(GotoMessage);
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareOpenMatchFoundWindowScriptTask", "ConditionalFlow1", "GotoMessage", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(!GotoMessage);
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareOpenMatchFoundWindowScriptTask", "ConditionalFlow2", "!GotoMessage", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("GotoMessage")) {
				writer.WriteValue("GotoMessage", GotoMessage, false);
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
			MetaPathParameterValues.Add("8ca30f19-9cae-41b2-9e53-50e6900eade9", () => PageInstanceId);
			MetaPathParameterValues.Add("f1fd73da-cef6-4f62-aa6d-20b9dd4afc4d", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("00425624-ef91-4ef3-b40b-176be00367ff", () => GotoMessage);
			MetaPathParameterValues.Add("f121eaf0-90bf-4549-8aaf-973323d99855", () => RecordsNotSelectedLS);
			MetaPathParameterValues.Add("5ba49010-536e-487d-a830-9e6a8775935b", () => OpenMatchFoundWindowUserTask.PageUId);
			MetaPathParameterValues.Add("24be2b71-1d40-40f4-a06b-d6b780a1af27", () => OpenMatchFoundWindowUserTask.PageUrl);
			MetaPathParameterValues.Add("c89bb7f3-5063-4e57-870b-0bc7e0ba4f39", () => OpenMatchFoundWindowUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("0423a29f-4e0c-456f-b873-792938f5e8c9", () => OpenMatchFoundWindowUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("08d541a2-13ad-4adb-b81c-5b5d541048dd", () => OpenMatchFoundWindowUserTask.PageParameters);
			MetaPathParameterValues.Add("cf7ec42b-628c-484f-99fa-4120d7f6e2ae", () => OpenMatchFoundWindowUserTask.Width);
			MetaPathParameterValues.Add("4701c20a-64b0-45ba-930e-9f658bd6ac86", () => OpenMatchFoundWindowUserTask.CloseMessage);
			MetaPathParameterValues.Add("388d4574-b1e6-4401-ae1f-8ed913fb5456", () => OpenMatchFoundWindowUserTask.Height);
			MetaPathParameterValues.Add("1483c481-5039-4511-982f-ce88ec124569", () => OpenMatchFoundWindowUserTask.Centered);
			MetaPathParameterValues.Add("50a53dcc-51b0-44a4-8949-74491b0de081", () => OpenMatchFoundWindowUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("e2abe27c-5b71-43ae-ac11-3614df4aff14", () => OpenMatchFoundWindowUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("7e6c667f-2911-42c5-bad4-afd98940d6ab", () => OpenMatchFoundWindowUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("516a23b1-866d-4279-b268-3015b55738ac", () => MessageUserTask.Page);
			MetaPathParameterValues.Add("eee653b3-9460-4687-b24f-8881935762e7", () => MessageUserTask.Icon);
			MetaPathParameterValues.Add("f0b46daf-66af-4af7-90ed-62cbe804a3bd", () => MessageUserTask.Buttons);
			MetaPathParameterValues.Add("b8498606-729d-45e7-9da8-0a905b16a68f", () => MessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("f198834b-fa52-4d04-9b82-80cde79c9d6a", () => MessageUserTask.MessageText);
			MetaPathParameterValues.Add("88a39807-124a-42f8-886e-b475151d31a0", () => MessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("34800313-4062-4a2d-94ca-1440184eb100", () => MessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("92c81a8c-6ceb-40fb-a244-72b8912644d2", () => MessageUserTask.PageParameters);
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
				case "GotoMessage":
					if (!hasValueToRead) break;
					GotoMessage = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareOpenMatchFoundWindowScriptTaskExecute(ProcessExecutingContext context) {
			var pageSchemaManager = (PageSchemaManager)UserConnection.GetSchemaManager("PageSchemaManager");
			var matchFoundPage = pageSchemaManager.GetInstanceByName("AccountMatchesFoundPage");
			var account = GetAccount();
			if (account == null) {
				GotoMessage = true;
				MessageUserTask.ProcessInstanceId = InstanceUId;
				MessageUserTask.Icon = "INFO";
				MessageUserTask.MessageText = RecordsNotSelectedLS;
				return true;
			}
			var parameters = new Dictionary<string, string>();
			var socialUsersKey = "socialUsers" + Guid.NewGuid().ToString();
			parameters.Add("SocialUsers", socialUsersKey);
			parameters.Add("SearchCriteria", account.Name);
			parameters.Add("AccountId", ActiveTreeGridCurrentRowId.ToString());
			parameters.Add("SocialNetwork", "All");
			OpenMatchFoundWindowUserTask.PageUId = matchFoundPage.UId;
			OpenMatchFoundWindowUserTask.PageParameters = parameters;
			OpenMatchFoundWindowUserTask.OpenerInstanceId = InstanceUId;
			OpenMatchFoundWindowUserTask.UseCurrentActivePage = true;
			OpenMatchFoundWindowUserTask.CloseMessage = "MatchFoundWindowClosed";
			return true;
		}

			
			public virtual BPMSoft.Configuration.Account GetAccount() {
				var accountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Account");
				var account = accountSchema.CreateEntity(UserConnection) as BPMSoft.Configuration.Account;
				bool fetchResult = account.FetchFromDB(accountSchema.PrimaryColumn, ActiveTreeGridCurrentRowId, new[] {
				                               accountSchema.Columns.FindByColumnValueName("Name"),
				                });
				if (!fetchResult){
				   account = null;
				}
				return account;
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
			var cloneItem = (FindInSocialByAccountModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

