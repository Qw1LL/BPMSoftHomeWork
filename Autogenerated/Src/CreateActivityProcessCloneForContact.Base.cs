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

	#region Class: CreateActivityProcessCloneForContactSchema

	/// <exclude/>
	public class CreateActivityProcessCloneForContactSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CreateActivityProcessCloneForContactSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CreateActivityProcessCloneForContactSchema(CreateActivityProcessCloneForContactSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CreateActivityProcessCloneForContact";
			UId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4");
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
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("48afa22b-7602-4990-9f3e-061a442a8e6a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("68768651-b929-4d24-ad67-4b7f1dd06f1b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSelectedActivityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("53f2b15d-ec31-4215-8ef6-477f4dc3c0d9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"SelectedActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateSelectedActivityParameter());
		}

		protected virtual void InitializeOpenActivityTypeLookupUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("42dc96b1-61a3-478b-aba2-71b69748c018"),
				ContainerUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
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
			var processKeyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1860263d-4a87-430d-960c-b3eef1a54d60"),
				ContainerUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Name = @"ProcessKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			processKeyParameter.SourceValue = new ProcessSchemaParameterValue(processKeyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(processKeyParameter);
			var userContextKeyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c497cb10-efa3-42cc-a9ed-2bd10d7c2c81"),
				ContainerUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Name = @"UserContextKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			userContextKeyParameter.SourceValue = new ProcessSchemaParameterValue(userContextKeyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(userContextKeyParameter);
			var useCurrentActivePageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55d576a4-ca48-41c9-9ab5-75b09a45ad60"),
				ContainerUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				Name = @"UseCurrentActivePage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCurrentActivePageParameter.SourceValue = new ProcessSchemaParameterValue(useCurrentActivePageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useCurrentActivePageParameter);
		}

		protected virtual void InitializeOpenActivityEditPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a774fb61-a14b-4191-afa1-33fa00ba96d1"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("361405db-f93b-437c-a017-8721f176bedf"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("cbffe6d2-c37c-4630-a4d5-aea3e6e257d9"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("d1eee111-1b9e-4825-b743-bd9de3f1dafa"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("c3fcc3df-a1a2-4554-8887-1dcb375439ff"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("816dfa2f-c6a0-4b10-913e-b1a08acdd2e0"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("686d7d34-2d19-4459-a7c0-c65663a45337"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("9618a96d-af2a-40ab-a13f-a331a7f52a71"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("ec6b1af4-5782-4603-97c4-72b744149ad1"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("d02a7dcc-ab0d-4be1-8a45-bf3fc9bf1998"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("84a3fe47-5247-4960-9e53-a1c523901d17"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("ccf5f046-b4d6-4bbc-b6c9-da263f9ce84c"),
				ContainerUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
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

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet70 = CreateLaneSet70LaneSet();
			LaneSets.Add(schemaLaneSet70);
			ProcessSchemaLane schemaLane184 = CreateLane184Lane();
			schemaLaneSet70.Lanes.Add(schemaLane184);
			ProcessSchemaStartEvent createactivitystart = CreateCreateActivityStartStartEvent();
			FlowElements.Add(createactivitystart);
			ProcessSchemaEndEvent createactivityend = CreateCreateActivityEndEndEvent();
			FlowElements.Add(createactivityend);
			ProcessSchemaScriptTask beforeopenactivitytypelookupusertaskscripttask = CreateBeforeOpenActivityTypeLookupUserTaskScriptTaskScriptTask();
			FlowElements.Add(beforeopenactivitytypelookupusertaskscripttask);
			ProcessSchemaUserTask openactivitytypelookupusertask = CreateOpenActivityTypeLookupUserTaskUserTask();
			FlowElements.Add(openactivitytypelookupusertask);
			ProcessSchemaIntermediateCatchMessageEvent lookupgridpageclosedintermediatecatchmessageevent = CreateLookupGridPageClosedIntermediateCatchMessageEventIntermediateCatchMessageEvent();
			FlowElements.Add(lookupgridpageclosedintermediatecatchmessageevent);
			ProcessSchemaScriptTask beforeopenactivityeditpageusertaskscripttask = CreateBeforeOpenActivityEditPageUserTaskScriptTaskScriptTask();
			FlowElements.Add(beforeopenactivityeditpageusertaskscripttask);
			ProcessSchemaUserTask openactivityeditpageusertask = CreateOpenActivityEditPageUserTaskUserTask();
			FlowElements.Add(openactivityeditpageusertask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			FlowElements.Add(CreateSequenceFlow578SequenceFlow());
			FlowElements.Add(CreateSequenceFlow579SequenceFlow());
			FlowElements.Add(CreateSequenceFlow580SequenceFlow());
			FlowElements.Add(CreateSequenceFlow581SequenceFlow());
			FlowElements.Add(CreateSequenceFlow582SequenceFlow());
			FlowElements.Add(CreateSequenceFlow583SequenceFlow());
			FlowElements.Add(CreateSequenceFlow584SequenceFlow());
			FlowElements.Add(CreateConditionalFlow43ConditionalFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow578SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow578",
				UId = new Guid("0c4f094c-4d91-4bf6-b6b6-66251497ad4d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(169, 84),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6fc4602c-fc70-44c3-970e-fd8f8c346555"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c27651a6-c904-4c67-b6cd-02bcf3eef885"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow579SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow579",
				UId = new Guid("25133738-d010-4dcc-97e8-0478ab9fa550"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(528, 294),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("507d0b8e-760c-4043-aa61-4603a3736178"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow580SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow580",
				UId = new Guid("aa53f9fd-740d-434e-b186-4e3146651918"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(346, 200),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("467490ca-d037-45ec-a492-7d5378b331f1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("920b034f-e9f0-4a34-9ffe-6dd95c6d8119"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow581SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow581",
				UId = new Guid("951e2629-0b2d-485f-8466-c7e6827b297e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(366, 106),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c27651a6-c904-4c67-b6cd-02bcf3eef885"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow582SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow582",
				UId = new Guid("ee5128a2-2875-4375-bea1-e7fc9b896bc4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(497, 106),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("467490ca-d037-45ec-a492-7d5378b331f1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow583SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow583",
				UId = new Guid("e575667b-8c92-449b-ab8f-5a71b5dd2b4c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(364, 294),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("920b034f-e9f0-4a34-9ffe-6dd95c6d8119"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fcf1fb3c-8c28-4058-8f3a-6d49d8558e1b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow584SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow584",
				UId = new Guid("e8b1ad3a-ce2e-4539-b449-1dfa9136d177"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(412, 392),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fcf1fb3c-8c28-4058-8f3a-6d49d8558e1b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow43ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow43",
				UId = new Guid("815368f2-b9da-4d76-bed8-2086e6cdb5db"),
				ConditionExpression = @"!SelectedActivity",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				CurveCenterPosition = new Point(558, 300),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fcf1fb3c-8c28-4058-8f3a-6d49d8558e1b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("507d0b8e-760c-4043-aa61-4603a3736178"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet70LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet70 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("2ab231ce-25c1-4294-b43e-8e0e7f116999"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"LaneSet70",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet70;
		}

		protected virtual ProcessSchemaLane CreateLane184Lane() {
			ProcessSchemaLane schemaLane184 = new ProcessSchemaLane(this) {
				UId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("2ab231ce-25c1-4294-b43e-8e0e7f116999"),
				CreatedInOwnerSchemaUId = new Guid("9bbcfc0d-93c2-4a92-8a30-9ccf72b4610e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"Lane184",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane184;
		}

		protected virtual ProcessSchemaStartEvent CreateCreateActivityStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("6fc4602c-fc70-44c3-970e-fd8f8c346555"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"CreateActivityStart",
				Position = new Point(36, 86),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateCreateActivityEndEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("507d0b8e-760c-4043-aa61-4603a3736178"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"CreateActivityEnd",
				Position = new Point(631, 275),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateBeforeOpenActivityTypeLookupUserTaskScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c27651a6-c904-4c67-b6cd-02bcf3eef885"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"BeforeOpenActivityTypeLookupUserTaskScriptTask",
				Position = new Point(204, 72),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,209,106,194,64,16,69,223,243,21,67,158,34,152,208,98,162,134,181,130,180,20,164,45,250,160,31,176,217,157,216,173,113,55,236,78,108,243,247,93,9,173,173,72,171,111,195,112,239,157,51,119,81,163,158,9,82,123,69,237,170,173,241,217,152,109,83,175,29,218,21,119,219,100,105,141,64,231,158,176,133,59,16,70,19,126,208,215,50,153,107,71,92,11,92,207,37,11,28,89,165,55,224,196,43,238,184,223,120,125,56,202,138,84,14,242,34,206,50,41,226,180,144,195,120,44,111,111,226,65,153,230,60,27,203,124,40,70,33,3,8,22,255,80,240,13,46,185,229,59,36,180,206,39,107,124,135,7,229,13,70,115,219,194,164,59,222,7,83,188,161,160,105,212,99,193,158,91,168,79,125,65,244,135,171,7,87,97,176,224,119,124,50,147,50,10,191,255,15,251,199,46,60,206,57,45,74,69,47,70,162,151,150,188,114,232,101,247,166,170,60,139,39,156,28,73,79,65,167,80,170,234,71,19,151,153,14,165,156,163,232,158,124,236,18,15,40,221,228,213,22,169,177,26,200,54,200,62,1,46,160,243,209,40,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenActivityTypeLookupUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"OpenActivityTypeLookupUserTask",
				Position = new Point(351, 72),
				SchemaUId = new Guid("1aac6458-2318-40e5-8592-778f3a94fdae"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenActivityTypeLookupUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateLookupGridPageClosedIntermediateCatchMessageEventIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("467490ca-d037-45ec-a492-7d5378b331f1"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"LookupGridPageClosed",
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"LookupGridPageClosedIntermediateCatchMessageEvent",
				Position = new Point(470, 86),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateBeforeOpenActivityEditPageUserTaskScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("920b034f-e9f0-4a34-9ffe-6dd95c6d8119"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"BeforeOpenActivityEditPageUserTaskScriptTask",
				Position = new Point(204, 261),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,86,93,111,155,48,20,125,30,191,194,229,9,164,128,32,36,132,40,109,165,244,83,213,214,54,90,178,189,76,123,48,182,105,89,19,136,140,105,23,85,249,239,187,54,31,161,129,44,219,19,96,174,207,185,247,220,227,11,175,152,163,41,17,241,107,44,54,139,205,154,77,19,122,77,99,49,195,79,236,42,134,245,52,193,124,131,206,80,194,222,208,110,225,52,19,60,78,158,122,197,229,220,48,209,187,246,233,93,143,66,230,96,66,137,69,34,226,88,52,114,93,43,116,156,200,114,28,151,250,14,27,123,1,241,245,30,210,163,126,24,121,227,81,104,5,17,246,172,65,16,98,43,244,199,174,53,28,121,190,19,140,220,177,63,194,250,182,39,33,153,27,120,46,101,71,33,113,223,241,124,18,4,22,193,206,192,26,140,6,3,11,80,66,107,24,6,120,224,251,110,159,6,94,5,217,255,55,72,74,40,197,142,63,180,188,190,27,90,131,161,239,88,24,147,208,114,134,145,79,200,168,79,104,224,232,91,109,59,209,180,87,80,49,99,75,70,4,163,165,154,49,203,164,158,25,104,103,180,133,67,105,248,11,162,207,77,227,113,205,146,102,3,190,164,233,75,190,254,150,49,190,192,217,139,125,203,196,188,4,254,142,151,57,203,12,249,234,50,77,18,166,48,77,115,210,197,174,160,238,40,144,23,132,246,245,106,45,54,69,40,46,67,170,62,119,132,69,41,103,152,60,35,227,51,219,40,218,25,142,249,126,238,40,22,108,133,226,228,80,229,202,20,7,243,146,155,109,128,159,104,219,29,157,76,175,66,61,234,74,133,31,71,200,168,160,208,25,212,209,201,167,66,63,117,22,174,54,171,26,39,16,18,66,34,47,112,3,109,213,52,137,61,47,116,185,203,30,242,229,242,145,43,125,140,54,144,105,34,206,68,206,19,36,184,68,210,154,109,173,194,234,166,170,7,197,46,143,213,109,30,211,46,200,137,118,196,27,51,158,18,150,101,170,114,68,210,68,176,223,162,90,180,239,146,76,224,132,72,158,210,160,21,5,152,71,192,189,226,151,220,93,222,152,18,146,230,73,59,70,74,162,50,98,11,206,216,45,143,233,101,206,57,75,196,215,244,13,130,79,160,34,208,73,201,221,69,119,120,43,104,46,249,73,17,92,42,115,49,187,159,167,145,176,1,34,138,159,114,142,101,231,229,147,140,217,63,8,128,32,179,43,17,236,27,38,200,243,13,79,87,87,23,127,201,216,252,232,140,102,217,21,16,156,64,169,61,189,76,151,249,42,81,78,57,149,146,156,27,122,29,174,155,149,103,170,195,90,181,13,128,74,71,200,242,128,22,214,230,228,153,173,240,61,78,160,207,28,2,62,22,162,142,124,51,194,208,175,219,219,116,19,225,12,117,188,40,199,129,90,2,236,14,70,73,80,185,227,98,243,128,87,76,86,82,164,43,11,105,244,161,90,46,106,151,161,114,84,40,48,187,88,203,36,90,133,82,118,70,55,109,249,92,57,74,105,244,159,72,165,178,53,146,130,162,44,42,102,224,206,150,15,236,77,29,159,50,237,58,162,245,197,66,251,211,75,110,145,126,105,219,244,164,105,121,229,143,26,214,158,82,90,57,172,93,81,175,125,196,236,69,90,76,16,67,14,234,237,7,198,157,217,142,49,30,212,112,199,88,131,217,123,140,123,230,154,195,108,128,235,21,22,248,71,67,207,198,174,159,160,93,253,166,84,126,141,57,176,9,198,219,194,214,186,214,255,2,19,109,23,174,210,215,27,68,240,97,237,166,221,27,119,157,51,115,214,76,99,71,2,73,54,135,239,31,28,241,184,221,211,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenActivityEditPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"OpenActivityEditPageUserTask",
				Position = new Point(351, 415),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenActivityEditPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("fcf1fb3c-8c28-4058-8f3a-6d49d8558e1b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("49398f23-e44b-4ebd-86a8-a3994832afcc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"),
				Name = @"ExclusiveGateway1",
				Position = new Point(358, 261),
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

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CreateActivityProcessCloneForContact(userConnection);
		}

		public override object Clone() {
			return new CreateActivityProcessCloneForContactSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("934a3163-f2b2-429b-9019-ba61e13533a4"));
		}

		#endregion

	}

	#endregion

	#region Class: CreateActivityProcessCloneForContact

	/// <exclude/>
	public class CreateActivityProcessCloneForContact : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane184

		/// <exclude/>
		public class ProcessLane184 : ProcessLane
		{

			public ProcessLane184(UserConnection userConnection, CreateActivityProcessCloneForContact process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenActivityTypeLookupUserTaskFlowElement

		/// <exclude/>
		public class OpenActivityTypeLookupUserTaskFlowElement : OpenLookupUserTask
		{

			#region Constructors: Public

			public OpenActivityTypeLookupUserTaskFlowElement(UserConnection userConnection, CreateActivityProcessCloneForContact process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenActivityTypeLookupUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("3d73d129-a59e-4b61-bb05-e48e4209788e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: OpenActivityEditPageUserTaskFlowElement

		/// <exclude/>
		public class OpenActivityEditPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenActivityEditPageUserTaskFlowElement(UserConnection userConnection, CreateActivityProcessCloneForContact process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenActivityEditPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("f3dc3b97-cc97-4c25-a03c-a758f86145f9");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public CreateActivityProcessCloneForContact(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreateActivityProcessCloneForContact";
			SchemaUId = new Guid("934a3163-f2b2-429b-9019-ba61e13533a4");
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
				return new Guid("934a3163-f2b2-429b-9019-ba61e13533a4");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CreateActivityProcessCloneForContact, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CreateActivityProcessCloneForContact, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual bool SelectedActivity {
			get;
			set;
		}

		private ProcessLane184 _lane184;
		public ProcessLane184 Lane184 {
			get {
				return _lane184 ?? ((_lane184) = new ProcessLane184(UserConnection, this));
			}
		}

		private ProcessFlowElement _createActivityStart;
		public ProcessFlowElement CreateActivityStart {
			get {
				return _createActivityStart ?? (_createActivityStart = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "CreateActivityStart",
					SchemaElementUId = new Guid("6fc4602c-fc70-44c3-970e-fd8f8c346555"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _createActivityEnd;
		public ProcessEndEvent CreateActivityEnd {
			get {
				return _createActivityEnd ?? (_createActivityEnd = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "CreateActivityEnd",
					SchemaElementUId = new Guid("507d0b8e-760c-4043-aa61-4603a3736178"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _beforeOpenActivityTypeLookupUserTaskScriptTask;
		public ProcessScriptTask BeforeOpenActivityTypeLookupUserTaskScriptTask {
			get {
				return _beforeOpenActivityTypeLookupUserTaskScriptTask ?? (_beforeOpenActivityTypeLookupUserTaskScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BeforeOpenActivityTypeLookupUserTaskScriptTask",
					SchemaElementUId = new Guid("c27651a6-c904-4c67-b6cd-02bcf3eef885"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = BeforeOpenActivityTypeLookupUserTaskScriptTaskExecute,
				});
			}
		}

		private OpenActivityTypeLookupUserTaskFlowElement _openActivityTypeLookupUserTask;
		public OpenActivityTypeLookupUserTaskFlowElement OpenActivityTypeLookupUserTask {
			get {
				return _openActivityTypeLookupUserTask ?? (_openActivityTypeLookupUserTask = new OpenActivityTypeLookupUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _lookupGridPageClosedIntermediateCatchMessageEvent;
		public ProcessIntermediateCatchMessageEvent LookupGridPageClosedIntermediateCatchMessageEvent {
			get {
				return _lookupGridPageClosedIntermediateCatchMessageEvent ?? (_lookupGridPageClosedIntermediateCatchMessageEvent = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "LookupGridPageClosedIntermediateCatchMessageEvent",
					SchemaElementUId = new Guid("467490ca-d037-45ec-a492-7d5378b331f1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Message = "LookupGridPageClosed",
				});
			}
		}

		private ProcessScriptTask _beforeOpenActivityEditPageUserTaskScriptTask;
		public ProcessScriptTask BeforeOpenActivityEditPageUserTaskScriptTask {
			get {
				return _beforeOpenActivityEditPageUserTaskScriptTask ?? (_beforeOpenActivityEditPageUserTaskScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BeforeOpenActivityEditPageUserTaskScriptTask",
					SchemaElementUId = new Guid("920b034f-e9f0-4a34-9ffe-6dd95c6d8119"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = BeforeOpenActivityEditPageUserTaskScriptTaskExecute,
				});
			}
		}

		private OpenActivityEditPageUserTaskFlowElement _openActivityEditPageUserTask;
		public OpenActivityEditPageUserTaskFlowElement OpenActivityEditPageUserTask {
			get {
				return _openActivityEditPageUserTask ?? (_openActivityEditPageUserTask = new OpenActivityEditPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("fcf1fb3c-8c28-4058-8f3a-6d49d8558e1b"),
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

		private ProcessConditionalFlow _conditionalFlow43;
		public ProcessConditionalFlow ConditionalFlow43 {
			get {
				return _conditionalFlow43 ?? (_conditionalFlow43 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow43",
					SchemaElementUId = new Guid("815368f2-b9da-4d76-bed8-2086e6cdb5db"),
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
			FlowElements[CreateActivityStart.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateActivityStart };
			FlowElements[CreateActivityEnd.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateActivityEnd };
			FlowElements[BeforeOpenActivityTypeLookupUserTaskScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BeforeOpenActivityTypeLookupUserTaskScriptTask };
			FlowElements[OpenActivityTypeLookupUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenActivityTypeLookupUserTask };
			FlowElements[LookupGridPageClosedIntermediateCatchMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { LookupGridPageClosedIntermediateCatchMessageEvent };
			FlowElements[BeforeOpenActivityEditPageUserTaskScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BeforeOpenActivityEditPageUserTaskScriptTask };
			FlowElements[OpenActivityEditPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenActivityEditPageUserTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "CreateActivityStart":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("BeforeOpenActivityTypeLookupUserTaskScriptTask", e.Context.SenderName));
						break;
					case "CreateActivityEnd":
						CompleteProcess();
						break;
					case "BeforeOpenActivityTypeLookupUserTaskScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenActivityTypeLookupUserTask", e.Context.SenderName));
						break;
					case "OpenActivityTypeLookupUserTask":
						ActivatedEventElements.Add("LookupGridPageClosedIntermediateCatchMessageEvent");
						break;
					case "LookupGridPageClosedIntermediateCatchMessageEvent":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("BeforeOpenActivityEditPageUserTaskScriptTask", e.Context.SenderName));
						break;
					case "BeforeOpenActivityEditPageUserTaskScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "OpenActivityEditPageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateActivityEnd", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow43ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateActivityEnd", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenActivityEditPageUserTask", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow43ExpressionExecute() {
			bool result = Convert.ToBoolean(!SelectedActivity);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow43", "!SelectedActivity", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("SelectedActivity")) {
				writer.WriteValue("SelectedActivity", SelectedActivity, false);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateActivityStart", string.Empty));
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
			MetaPathParameterValues.Add("48afa22b-7602-4990-9f3e-061a442a8e6a", () => PageInstanceId);
			MetaPathParameterValues.Add("68768651-b929-4d24-ad67-4b7f1dd06f1b", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("53f2b15d-ec31-4215-8ef6-477f4dc3c0d9", () => SelectedActivity);
			MetaPathParameterValues.Add("42dc96b1-61a3-478b-aba2-71b69748c018", () => OpenActivityTypeLookupUserTask.PageParameters);
			MetaPathParameterValues.Add("1860263d-4a87-430d-960c-b3eef1a54d60", () => OpenActivityTypeLookupUserTask.ProcessKey);
			MetaPathParameterValues.Add("c497cb10-efa3-42cc-a9ed-2bd10d7c2c81", () => OpenActivityTypeLookupUserTask.UserContextKey);
			MetaPathParameterValues.Add("55d576a4-ca48-41c9-9ab5-75b09a45ad60", () => OpenActivityTypeLookupUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("a774fb61-a14b-4191-afa1-33fa00ba96d1", () => OpenActivityEditPageUserTask.PageUId);
			MetaPathParameterValues.Add("361405db-f93b-437c-a017-8721f176bedf", () => OpenActivityEditPageUserTask.PageUrl);
			MetaPathParameterValues.Add("cbffe6d2-c37c-4630-a4d5-aea3e6e257d9", () => OpenActivityEditPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("d1eee111-1b9e-4825-b743-bd9de3f1dafa", () => OpenActivityEditPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("c3fcc3df-a1a2-4554-8887-1dcb375439ff", () => OpenActivityEditPageUserTask.PageParameters);
			MetaPathParameterValues.Add("816dfa2f-c6a0-4b10-913e-b1a08acdd2e0", () => OpenActivityEditPageUserTask.Width);
			MetaPathParameterValues.Add("686d7d34-2d19-4459-a7c0-c65663a45337", () => OpenActivityEditPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("9618a96d-af2a-40ab-a13f-a331a7f52a71", () => OpenActivityEditPageUserTask.Height);
			MetaPathParameterValues.Add("ec6b1af4-5782-4603-97c4-72b744149ad1", () => OpenActivityEditPageUserTask.Centered);
			MetaPathParameterValues.Add("d02a7dcc-ab0d-4be1-8a45-bf3fc9bf1998", () => OpenActivityEditPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("84a3fe47-5247-4960-9e53-a1c523901d17", () => OpenActivityEditPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("ccf5f046-b4d6-4bbc-b6c9-da263f9ce84c", () => OpenActivityEditPageUserTask.IgnoreProfile);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "SelectedActivity":
					if (!hasValueToRead) break;
					SelectedActivity = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool BeforeOpenActivityTypeLookupUserTaskScriptTaskExecute(ProcessExecutingContext context) {
			OpenActivityTypeLookupUserTask.ProcessKey = context.Process.InstanceUId;
			string schemaUId = "75b4d39b-55dc-4bd6-8d10-3f49a58d96c7";  
			OpenActivityTypeLookupUserTask.PageParameters = new Dictionary <string, object>();
			var pageParameters = 
			(Dictionary <string, object>) OpenActivityTypeLookupUserTask.PageParameters;
			pageParameters.Add("schemaUId", schemaUId);
			pageParameters.Add("editMode", false);
			Collection<Dictionary<string, object>> filters = new Collection<Dictionary<string, object>>();
			pageParameters.Add("LookupFilters", filters);
			return true;
		}

		public virtual bool BeforeOpenActivityEditPageUserTaskScriptTaskExecute(ProcessExecutingContext context) {
			var ActivityTypeAndEditPageDictionary = new Dictionary<string,string>() {
				{"fbe0acdc-cfc0-df11-b00f-001d60e938c6", "f2bf397b-8fa3-48ba-b691-57360871967a"},
				{"e1831dec-cfc0-df11-b00f-001d60e938c6", "a2036c88-ca04-4744-967b-5b8a46612d83"},
				{"e2831dec-cfc0-df11-b00f-001d60e938c6", "dcdda065-321b-4560-aacb-05f6cc72cd80"}
			};
			
			var selectedActivitiesTypes = (Dictionary<string, object>)(OpenActivityTypeLookupUserTask.GetSelectedValues(UserConnection));
			var selectedActivityTypeId = string.Empty;
			var activityEditPageId = string.Empty;
			foreach (KeyValuePair<string, object> item in selectedActivitiesTypes) {
				selectedActivityTypeId = item.Key;
			}
			foreach (var item in ActivityTypeAndEditPageDictionary) {
				if (item.Key == selectedActivityTypeId) {
					activityEditPageId = item.Value;
					break;
				}
			}
			
			if (String.IsNullOrEmpty(activityEditPageId)) return true;
			
			OpenActivityEditPageUserTask.PageUId = new Guid(activityEditPageId);
			OpenActivityTypeLookupUserTask.ProcessKey = context.Process.InstanceUId;
			
			var activityContactId = Guid.Empty;
			var activityAccountId = Guid.Empty;
			if (ActiveTreeGridCurrentRowId != null) {
				activityContactId = ActiveTreeGridCurrentRowId;
				var contact = new BPMSoft.Configuration.Contact(UserConnection);
				if (contact.FetchFromDB(ActiveTreeGridCurrentRowId)) {
					activityAccountId = contact.GetTypedColumnValue<Guid>("AccountId");
				}
			}
			
			SelectedActivity = true;
			
			var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			var schema = entitySchemaManager.GetInstanceByName("Activity");
			var contactActivityColumnName = schema.Columns.GetByName("Contact").Name;
			var accountActivityColumnName = schema.Columns.GetByName("Account").Name;
			
			var defValuesId = Guid.NewGuid();
			var defValues = new Dictionary <string, object>();
			if (activityContactId != Guid.Empty) {
				defValues.Add(contactActivityColumnName, activityContactId.ToString());
			}
			if (activityAccountId != Guid.Empty) {
				defValues.Add(accountActivityColumnName, activityAccountId.ToString());
			}
			UserConnection.SessionData[defValuesId.ToString()] = defValues;
			
			var parameters = new Dictionary<string, string>();
			parameters.Add("defValuesId", defValuesId.ToString());
			OpenActivityEditPageUserTask.PageParameters = parameters;
			
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "LookupGridPageClosed":
					if (ActivatedEventElements.Remove("LookupGridPageClosedIntermediateCatchMessageEvent")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("LookupGridPageClosedIntermediateCatchMessageEvent", "LookupGridPageClosedIntermediateCatchMessageEvent"));
					}
					break;
			}
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
			var cloneItem = (CreateActivityProcessCloneForContact)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

