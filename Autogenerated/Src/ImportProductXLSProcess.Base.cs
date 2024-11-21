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
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using System.Web;

	#region Class: ImportProductXLSProcessSchema

	/// <exclude/>
	public class ImportProductXLSProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportProductXLSProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportProductXLSProcessSchema(ImportProductXLSProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportProductXLSProcess";
			UId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2803";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("24749bc5-589e-48af-bf9d-8e667e8ee07e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9c15c94b-6b84-469d-ae16-c8bbca0e7e3d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTreeGridSelectedRowsIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fbd5ba2e-e88c-4c39-8ad9-5729bbe86616"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"TreeGridSelectedRowsIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateTreeGridSelectedRowsIdsParameter());
		}

		protected virtual void InitializeOpenImportProductsSettingsPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("68e4c1ec-a6d7-4838-9be9-6381c8b4365c"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("d721f8de-068e-414d-8974-d2ea54c3c436"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("423ed8b9-95e2-44d8-8894-315383286ea7"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("8c14ce01-acf7-4852-a4fe-523556c6af2d"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("028e1059-ab68-4842-85fc-37d0c190afea"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("6e3e266c-a405-456a-9ba2-4135ed63f254"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("9937dbb7-f7bc-45a0-92b0-540bbb9943f7"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("9ceb3f2c-a708-40bb-ba18-01a662a1cf3f"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("b8da5264-f2ce-457c-8f40-6795c18818fb"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("d4ce6e84-26e5-4e42-950c-885a484096fa"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("6012d09d-4f89-437e-882a-fb81808b1530"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				UId = new Guid("28a02e11-3a60-4d3e-b60a-9572687364a6"),
				ContainerUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreProfileParameter);
		}

		protected virtual void InitializeConfirmOpenLogFileParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2821e58d-2971-4cd0-ba15-3d4ab5f4f287"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("0ffbdc2f-bf43-459e-a8d9-089bcb2ef647"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("a906ae43-aaf9-41f8-a4be-dcdb423ed4c6"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("944b1b7a-4cdc-42f4-b214-b39010992825"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("ebd0df11-1cf8-480a-9bd1-1dbb3f6d7787"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("f33f0c23-5085-4f83-96c8-03b4f56338be"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("9d058c87-6398-4a5d-bfdb-08bd94b6adcf"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
				UId = new Guid("23d7b94c-3f16-46e8-afda-33eacecc21e9"),
				ContainerUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
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
			ProcessSchemaScriptTask setparametersscript = CreateSetParametersScriptScriptTask();
			FlowElements.Add(setparametersscript);
			ProcessSchemaUserTask openimportproductssettingspageusertask = CreateOpenImportProductsSettingsPageUserTaskUserTask();
			FlowElements.Add(openimportproductssettingspageusertask);
			ProcessSchemaIntermediateCatchMessageEvent showmessageboxstartmessage = CreateShowMessageBoxStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(showmessageboxstartmessage);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaScriptTask showmessageboxscript = CreateShowMessageBoxScriptScriptTask();
			FlowElements.Add(showmessageboxscript);
			ProcessSchemaScriptTask clearparametersscript = CreateClearParametersScriptScriptTask();
			FlowElements.Add(clearparametersscript);
			ProcessSchemaUserTask confirmopenlogfile = CreateConfirmOpenLogFileUserTask();
			FlowElements.Add(confirmopenlogfile);
			ProcessSchemaIntermediateCatchMessageEvent intermediatecatchmessageevent1nomessagestartmessage = CreateIntermediateCatchMessageEvent1NoMessageStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(intermediatecatchmessageevent1nomessagestartmessage);
			ProcessSchemaIntermediateCatchMessageEvent yesmessagestartmessage = CreateYesMessageStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(yesmessagestartmessage);
			ProcessSchemaScriptTask prepareuploadscript = CreatePrepareUploadScriptScriptTask();
			FlowElements.Add(prepareuploadscript);
			ProcessSchemaScriptTask savelogscripttask = CreateSaveLogScriptTaskScriptTask();
			FlowElements.Add(savelogscripttask);
			ProcessSchemaIntermediateCatchMessageEvent savelogintermediatecatchmessageevent = CreateSaveLogIntermediateCatchMessageEventIntermediateCatchMessageEvent();
			FlowElements.Add(savelogintermediatecatchmessageevent);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateOpenLogFileMessageLocalizableString());
			LocalizableStrings.Add(CreateProductsImportFileLogLocalizableString());
			LocalizableStrings.Add(CreateFileNameLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateOpenLogFileMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("bf31c472-b107-4b28-9746-91fd98160d90"),
				Name = "OpenLogFileMessage",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateProductsImportFileLogLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5dc9ea8b-c46b-4284-8be1-c4f233c24c88"),
				Name = "ProductsImportFileLog",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFileNameLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f14ec71f-8fdc-432a-ad19-4f2a3a80b900"),
				Name = "FileName",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("3d0cce52-e55d-44a3-b6ec-22811566e8f9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(490, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8c08bb88-200a-40c0-a4e6-d8a851dd4289"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b85a854b-31e4-48b4-a5f6-7f2088797c91"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a8e80546-5a55-4dea-a472-e9cbce8af064"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(490, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b85a854b-31e4-48b4-a5f6-7f2088797c91"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("57dc9979-1b7e-48ba-98b0-29401f4e18d1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(490, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("11d62f4f-3368-4fad-bbde-2e6a6da9404b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("a6641424-9ee8-4b8e-b9a0-0d0d558b57d3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(490, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("11d62f4f-3368-4fad-bbde-2e6a6da9404b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2af61120-002d-4b95-abdc-695dee67c56f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("737d3b41-01f1-4c3b-9a71-8b1c4bfb00cd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(490, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("98067f61-e2d0-4a31-ad1e-35118a86b892"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow5",
				UId = new Guid("909f5cc2-e029-4724-b97b-9d004d186002"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(636, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2af61120-002d-4b95-abdc-695dee67c56f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("98067f61-e2d0-4a31-ad1e-35118a86b892"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("2f510c9c-7883-429c-9c9f-8139a5c3713c"),
				ConditionExpression = @"UserConnection.SessionData[""ImportedRowsCount""] == null",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(864, 146),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2af61120-002d-4b95-abdc-695dee67c56f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c96bdc60-691c-4f7e-97bc-027f1f3f1fc8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("05e3b399-76a5-4ee5-927c-a0005e4b45ae"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(490, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e605002f-20e8-4f4e-8438-4516c4b4b44f"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("ac6ce302-8238-4c6e-85af-3c82662438c3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(938, 242),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1f4e90fa-76be-48e5-b12e-cc815ef9fd59"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("19cce46b-4b27-45a9-b7fc-4838d59cb6d9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(1078, 280),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1f4e90fa-76be-48e5-b12e-cc815ef9fd59"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6045e74e-bca1-4225-bc7a-87477706d4a4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("7f625cde-9a08-4706-a8df-6f8f288410b1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(1222, 289),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6045e74e-bca1-4225-bc7a-87477706d4a4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("998df316-b71b-4526-a3bf-2e8eee2cae8a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("9dd61785-fb9e-4016-bec5-0046713685ef"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(1298, 290),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("998df316-b71b-4526-a3bf-2e8eee2cae8a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b179149f-16fc-44e5-b2b0-c4788fd804a3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("16c0db33-3152-46fd-8f92-5a26123519f4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(1365, 240),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b179149f-16fc-44e5-b2b0-c4788fd804a3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("001304a2-9b92-4bf4-9b70-a1125ca808db"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("a9ff34da-3f17-4cf5-b662-d28dc7a865db"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(1085, 112),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e605002f-20e8-4f4e-8438-4516c4b4b44f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c96bdc60-691c-4f7e-97bc-027f1f3f1fc8"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("d47ef8e2-ade0-4252-9c5e-e513505d94ea"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				CurveCenterPosition = new Point(1300, 143),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c96bdc60-691c-4f7e-97bc-027f1f3f1fc8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("001304a2-9b92-4bf4-9b70-a1125ca808db"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("827342dc-9838-4c36-8dd9-887649922f40"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(1409, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("827342dc-9838-4c36-8dd9-887649922f40"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1380, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("8c08bb88-200a-40c0-a4e6-d8a851dd4289"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("001304a2-9b92-4bf4-9b70-a1125ca808db"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"End1",
				Position = new Point(1338, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSetParametersScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b85a854b-31e4-48b4-a5f6-7f2088797c91"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"SetParametersScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(120, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,187,14,194,48,12,69,103,144,248,135,168,19,12,173,16,143,150,168,98,128,14,168,3,162,18,240,1,73,234,150,10,72,144,227,80,62,159,148,199,222,205,215,215,62,215,62,60,64,231,247,135,65,42,208,148,78,145,61,2,81,163,107,91,136,26,206,22,240,36,236,53,250,136,188,100,107,166,161,101,59,215,148,227,64,241,114,158,76,87,50,156,207,128,135,11,33,121,200,171,101,18,86,146,75,21,87,177,136,151,179,96,146,142,134,135,126,25,221,24,96,174,45,9,173,224,19,166,140,38,120,81,228,247,20,88,27,253,77,127,74,58,96,172,55,58,187,25,11,123,79,240,77,143,13,142,23,211,254,228,214,188,130,116,208,155,228,139,204,33,130,166,141,162,230,9,157,233,137,132,14,252,167,8,228,80,127,213,27,63,171,96,200,90,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenImportProductsSettingsPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"OpenImportProductsSettingsPageUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(260, 170),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenImportProductsSettingsPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateShowMessageBoxStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("11d62f4f-3368-4fad-bbde-2e6a6da9404b"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"ShowMessageBox",
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"ShowMessageBoxStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(393, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("2af61120-002d-4b95-abdc-695dee67c56f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(491, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateShowMessageBoxScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("98067f61-e2d0-4a31-ad1e-35118a86b892"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"ShowMessageBoxScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(638, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,146,77,107,2,49,16,134,207,21,252,15,105,78,43,44,139,119,173,135,250,1,75,91,181,126,20,74,233,33,93,71,73,217,157,145,36,171,149,197,255,222,137,213,34,54,245,18,200,228,153,247,125,39,201,70,25,161,139,53,25,7,139,9,109,109,151,74,116,226,78,32,108,197,3,236,94,84,94,194,88,105,211,214,232,98,193,75,39,106,198,162,217,104,213,107,244,241,9,153,251,219,61,5,107,53,97,79,57,197,66,115,11,166,75,136,140,114,49,57,59,124,147,233,101,171,124,103,93,189,20,209,85,209,91,142,87,230,121,67,84,162,94,187,9,165,143,194,209,27,215,100,217,121,95,175,113,212,165,54,197,104,13,248,72,171,129,206,33,121,98,70,173,96,6,95,94,218,58,163,113,149,12,200,20,202,69,103,220,17,99,167,75,147,132,211,132,202,135,132,254,38,3,166,105,70,200,110,242,121,222,159,206,210,209,80,134,177,251,210,57,66,235,201,215,254,116,56,250,7,155,128,93,51,118,202,232,121,255,192,61,125,120,20,101,118,237,159,177,226,227,120,29,81,85,114,7,86,198,172,11,246,216,38,247,177,168,36,146,175,14,233,183,184,15,123,142,13,101,140,164,104,157,194,12,210,5,155,158,54,243,116,193,77,255,127,13,14,92,208,6,162,192,15,241,247,101,192,149,6,133,51,37,180,190,1,29,192,10,66,193,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateClearParametersScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c96bdc60-691c-4f7e-97bc-027f1f3f1fc8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"ClearParametersScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1135, 93),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,187,14,130,64,16,69,107,72,248,135,145,106,183,217,31,32,86,130,134,206,104,140,133,177,88,97,140,152,125,232,176,139,38,198,127,119,236,160,160,157,153,123,238,201,248,203,29,155,0,248,110,208,212,246,225,41,212,237,30,251,190,243,174,212,65,195,18,14,61,210,202,59,199,103,60,84,163,229,41,175,198,177,252,92,100,105,119,5,49,11,91,44,193,69,99,36,124,32,75,147,65,211,180,151,203,196,38,118,173,156,3,48,63,113,248,130,18,13,6,20,83,51,169,214,228,173,24,59,229,82,113,34,57,222,144,80,228,108,40,85,221,87,207,168,141,88,121,19,173,83,91,77,218,50,139,166,210,82,170,234,141,77,228,18,249,47,157,255,129,218,161,245,3,211,167,175,248,167,190,89,74,24,34,57,8,20,177,248,1,143,96,72,57,106,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateConfirmOpenLogFileUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"ConfirmOpenLogFile",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(785, 170),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeConfirmOpenLogFileParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateIntermediateCatchMessageEvent1NoMessageStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("e605002f-20e8-4f4e-8438-4516c4b4b44f"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"NoMessage",
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"IntermediateCatchMessageEvent1NoMessageStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(939, 107),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateYesMessageStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("1f4e90fa-76be-48e5-b12e-cc815ef9fd59"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"YesMessage",
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"YesMessageStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(939, 261),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareUploadScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("6045e74e-bca1-4225-bc7a-87477706d4a4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"PrepareUploadScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1051, 247),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,61,143,221,10,130,64,16,133,175,19,124,135,193,27,141,98,31,32,233,162,36,72,40,8,76,186,222,220,201,54,100,87,102,199,31,136,222,189,213,160,139,249,131,115,14,223,244,146,160,149,53,194,22,142,204,109,102,13,227,200,34,235,136,208,252,231,81,26,213,32,129,116,80,230,226,134,247,73,71,182,113,226,226,189,105,24,56,38,109,106,112,21,233,150,125,86,52,104,163,236,32,246,151,115,97,31,44,118,47,57,158,145,159,86,57,113,125,146,29,178,70,251,220,67,239,91,18,71,176,130,48,88,228,198,177,52,21,150,185,130,149,191,163,120,13,113,33,123,60,217,122,90,125,189,65,187,178,109,172,84,176,1,166,14,225,179,76,163,212,187,167,39,196,78,169,98,70,72,126,36,75,143,22,6,132,220,145,153,229,233,23,192,9,60,57,240,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSaveLogScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b179149f-16fc-44e5-b2b0-c4788fd804a3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"SaveLogScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1247, 247),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,203,110,219,48,16,60,171,64,255,129,225,137,2,82,54,119,193,7,63,99,3,45,18,52,14,124,72,122,96,164,181,77,128,34,85,62,18,7,65,254,189,75,83,178,101,7,45,144,131,68,136,28,206,238,204,238,74,174,9,187,119,96,199,70,107,40,189,52,154,223,129,115,184,78,132,23,15,116,186,43,65,45,234,198,88,191,168,232,111,114,49,32,58,40,149,147,55,242,245,75,246,44,44,129,62,130,12,8,187,14,178,202,63,193,89,180,68,206,91,169,55,163,32,85,5,22,137,52,188,144,187,254,30,203,59,168,50,155,159,200,40,54,224,58,32,40,12,117,38,37,231,99,163,66,173,25,109,209,75,216,121,154,243,153,53,53,235,167,241,195,108,104,142,220,25,95,109,193,2,59,75,49,231,11,55,253,19,132,98,137,143,223,10,43,106,240,152,210,137,250,60,113,220,88,76,118,244,58,116,37,163,99,11,194,67,117,163,19,191,112,109,166,81,73,112,168,141,176,40,168,122,154,238,160,12,222,68,225,103,222,77,181,11,22,38,163,227,22,203,209,255,72,215,50,44,162,175,191,64,68,223,234,164,20,105,122,38,241,196,14,9,195,142,209,58,162,236,101,43,21,16,214,222,230,17,120,136,146,101,114,125,56,122,184,234,55,65,58,206,78,74,199,135,77,3,186,234,93,224,75,147,10,137,148,197,255,174,208,71,251,136,78,181,152,247,253,178,127,199,87,124,162,87,107,204,52,10,70,137,167,36,199,40,93,159,52,201,137,185,247,13,186,231,177,250,124,28,172,5,125,88,231,66,87,10,109,195,194,220,47,248,10,158,34,206,26,229,176,198,27,232,120,44,184,198,104,23,185,154,100,79,250,46,226,16,116,135,124,31,66,251,229,107,19,129,52,134,251,222,40,33,53,45,250,176,97,85,205,83,29,104,123,227,219,68,226,153,147,177,182,244,178,85,197,103,198,214,194,51,42,188,23,229,182,70,92,177,215,174,177,245,6,111,87,239,220,99,51,95,146,91,107,170,80,122,151,154,112,134,0,236,230,228,243,33,228,202,74,15,172,51,238,244,108,138,190,239,119,226,24,77,176,57,17,121,62,70,31,6,6,71,34,150,165,157,150,79,141,72,215,139,41,232,191,255,19,104,114,109,158,63,206,34,222,194,78,176,224,131,213,196,219,0,197,95,44,185,207,19,196,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateSaveLogIntermediateCatchMessageEventIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("998df316-b71b-4526-a3bf-2e8eee2cae8a"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5f9cc305-8f9d-46de-a150-22f310351a46"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"SaveLog",
				ModifiedInSchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"),
				Name = @"SaveLogIntermediateCatchMessageEvent",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1170, 261),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7cc88e8b-13d0-4867-a95d-dce02c556310"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("0db5a8d2-b6fa-41e5-b460-2fcd1ed4da85"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9507611c-9281-473c-974f-45961d7c5e53"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportProductXLSProcess(userConnection);
		}

		public override object Clone() {
			return new ImportProductXLSProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportProductXLSProcess

	/// <exclude/>
	public class ImportProductXLSProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ImportProductXLSProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenImportProductsSettingsPageUserTaskFlowElement

		/// <exclude/>
		public class OpenImportProductsSettingsPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenImportProductsSettingsPageUserTaskFlowElement(UserConnection userConnection, ImportProductXLSProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenImportProductsSettingsPageUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("b3df4efb-40e2-47cb-aa09-302c434955d8");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ConfirmOpenLogFileFlowElement

		/// <exclude/>
		public class ConfirmOpenLogFileFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ConfirmOpenLogFileFlowElement(UserConnection userConnection, ImportProductXLSProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ConfirmOpenLogFile";
				IsLogging = false;
				SchemaElementUId = new Guid("363c1e61-4eeb-4881-9282-92bb21f7c63d");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ImportProductXLSProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportProductXLSProcess";
			SchemaUId = new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52");
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
				return new Guid("cee0c5cd-5ae7-4e2f-953d-e99a638f0c52");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportProductXLSProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportProductXLSProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string PageInstanceId {
			get;
			set;
		}

		public virtual Guid ActiveTreeGridCurrentRowId {
			get;
			set;
		}

		public virtual Object TreeGridSelectedRowsIds {
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
					SchemaElementUId = new Guid("8c08bb88-200a-40c0-a4e6-d8a851dd4289"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("001304a2-9b92-4bf4-9b70-a1125ca808db"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setParametersScript;
		public ProcessScriptTask SetParametersScript {
			get {
				return _setParametersScript ?? (_setParametersScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetParametersScript",
					SchemaElementUId = new Guid("b85a854b-31e4-48b4-a5f6-7f2088797c91"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetParametersScriptExecute,
				});
			}
		}

		private OpenImportProductsSettingsPageUserTaskFlowElement _openImportProductsSettingsPageUserTask;
		public OpenImportProductsSettingsPageUserTaskFlowElement OpenImportProductsSettingsPageUserTask {
			get {
				return _openImportProductsSettingsPageUserTask ?? (_openImportProductsSettingsPageUserTask = new OpenImportProductsSettingsPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _showMessageBoxStartMessage;
		public ProcessIntermediateCatchMessageEvent ShowMessageBoxStartMessage {
			get {
				return _showMessageBoxStartMessage ?? (_showMessageBoxStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "ShowMessageBoxStartMessage",
					SchemaElementUId = new Guid("11d62f4f-3368-4fad-bbde-2e6a6da9404b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "ShowMessageBox",
				});
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
					SchemaElementUId = new Guid("2af61120-002d-4b95-abdc-695dee67c56f"),
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

		private ProcessScriptTask _showMessageBoxScript;
		public ProcessScriptTask ShowMessageBoxScript {
			get {
				return _showMessageBoxScript ?? (_showMessageBoxScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ShowMessageBoxScript",
					SchemaElementUId = new Guid("98067f61-e2d0-4a31-ad1e-35118a86b892"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ShowMessageBoxScriptExecute,
				});
			}
		}

		private ProcessScriptTask _clearParametersScript;
		public ProcessScriptTask ClearParametersScript {
			get {
				return _clearParametersScript ?? (_clearParametersScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearParametersScript",
					SchemaElementUId = new Guid("c96bdc60-691c-4f7e-97bc-027f1f3f1fc8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ClearParametersScriptExecute,
				});
			}
		}

		private ConfirmOpenLogFileFlowElement _confirmOpenLogFile;
		public ConfirmOpenLogFileFlowElement ConfirmOpenLogFile {
			get {
				return _confirmOpenLogFile ?? (_confirmOpenLogFile = new ConfirmOpenLogFileFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _intermediateCatchMessageEvent1NoMessageStartMessage;
		public ProcessIntermediateCatchMessageEvent IntermediateCatchMessageEvent1NoMessageStartMessage {
			get {
				return _intermediateCatchMessageEvent1NoMessageStartMessage ?? (_intermediateCatchMessageEvent1NoMessageStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "IntermediateCatchMessageEvent1NoMessageStartMessage",
					SchemaElementUId = new Guid("e605002f-20e8-4f4e-8438-4516c4b4b44f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "NoMessage",
				});
			}
		}

		private ProcessIntermediateCatchMessageEvent _yesMessageStartMessage;
		public ProcessIntermediateCatchMessageEvent YesMessageStartMessage {
			get {
				return _yesMessageStartMessage ?? (_yesMessageStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "YesMessageStartMessage",
					SchemaElementUId = new Guid("1f4e90fa-76be-48e5-b12e-cc815ef9fd59"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "YesMessage",
				});
			}
		}

		private ProcessScriptTask _prepareUploadScript;
		public ProcessScriptTask PrepareUploadScript {
			get {
				return _prepareUploadScript ?? (_prepareUploadScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareUploadScript",
					SchemaElementUId = new Guid("6045e74e-bca1-4225-bc7a-87477706d4a4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = PrepareUploadScriptExecute,
				});
			}
		}

		private ProcessScriptTask _saveLogScriptTask;
		public ProcessScriptTask SaveLogScriptTask {
			get {
				return _saveLogScriptTask ?? (_saveLogScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SaveLogScriptTask",
					SchemaElementUId = new Guid("b179149f-16fc-44e5-b2b0-c4788fd804a3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveLogScriptTaskExecute,
				});
			}
		}

		private ProcessIntermediateCatchMessageEvent _saveLogIntermediateCatchMessageEvent;
		public ProcessIntermediateCatchMessageEvent SaveLogIntermediateCatchMessageEvent {
			get {
				return _saveLogIntermediateCatchMessageEvent ?? (_saveLogIntermediateCatchMessageEvent = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "SaveLogIntermediateCatchMessageEvent",
					SchemaElementUId = new Guid("998df316-b71b-4526-a3bf-2e8eee2cae8a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SaveLog",
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
					SchemaElementUId = new Guid("2f510c9c-7883-429c-9c9f-8139a5c3713c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private LocalizableString _openLogFileMessage;
		public LocalizableString OpenLogFileMessage {
			get {
				return _openLogFileMessage ?? (_openLogFileMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.OpenLogFileMessage.Value"));
			}
		}

		private LocalizableString _productsImportFileLog;
		public LocalizableString ProductsImportFileLog {
			get {
				return _productsImportFileLog ?? (_productsImportFileLog = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ProductsImportFileLog.Value"));
			}
		}

		private LocalizableString _fileName;
		public LocalizableString FileName {
			get {
				return _fileName ?? (_fileName = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.FileName.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[SetParametersScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetParametersScript };
			FlowElements[OpenImportProductsSettingsPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenImportProductsSettingsPageUserTask };
			FlowElements[ShowMessageBoxStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageBoxStartMessage };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ShowMessageBoxScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageBoxScript };
			FlowElements[ClearParametersScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearParametersScript };
			FlowElements[ConfirmOpenLogFile.SchemaElementUId] = new Collection<ProcessFlowElement> { ConfirmOpenLogFile };
			FlowElements[IntermediateCatchMessageEvent1NoMessageStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchMessageEvent1NoMessageStartMessage };
			FlowElements[YesMessageStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { YesMessageStartMessage };
			FlowElements[PrepareUploadScript.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareUploadScript };
			FlowElements[SaveLogScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLogScriptTask };
			FlowElements[SaveLogIntermediateCatchMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLogIntermediateCatchMessageEvent };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetParametersScript", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "SetParametersScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenImportProductsSettingsPageUserTask", e.Context.SenderName));
						break;
					case "OpenImportProductsSettingsPageUserTask":
						ActivatedEventElements.Add("ShowMessageBoxStartMessage");
						break;
					case "ShowMessageBoxStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearParametersScript", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageBoxScript", e.Context.SenderName));
						break;
					case "ShowMessageBoxScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ConfirmOpenLogFile", e.Context.SenderName));
						break;
					case "ClearParametersScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "ConfirmOpenLogFile":
						ActivatedEventElements.Add("IntermediateCatchMessageEvent1NoMessageStartMessage");
						ActivatedEventElements.Add("YesMessageStartMessage");
						break;
					case "IntermediateCatchMessageEvent1NoMessageStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearParametersScript", e.Context.SenderName));
						break;
					case "YesMessageStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareUploadScript", e.Context.SenderName));
						break;
					case "PrepareUploadScript":
						if (!ActivatedEventElements.Contains("SaveLogIntermediateCatchMessageEvent")) {
							ActivatedEventElements.Add("SaveLogIntermediateCatchMessageEvent");
						}
						break;
					case "SaveLogScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "SaveLogIntermediateCatchMessageEvent":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLogScriptTask", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(UserConnection.SessionData["ImportedRowsCount"] == null);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "UserConnection.SessionData[\"ImportedRowsCount\"] == null", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (TreeGridSelectedRowsIds != null) {
				if (TreeGridSelectedRowsIds.GetType().IsSerializable ||
					TreeGridSelectedRowsIds.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("TreeGridSelectedRowsIds", TreeGridSelectedRowsIds, null);
				}
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
			MetaPathParameterValues.Add("24749bc5-589e-48af-bf9d-8e667e8ee07e", () => PageInstanceId);
			MetaPathParameterValues.Add("9c15c94b-6b84-469d-ae16-c8bbca0e7e3d", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("fbd5ba2e-e88c-4c39-8ad9-5729bbe86616", () => TreeGridSelectedRowsIds);
			MetaPathParameterValues.Add("68e4c1ec-a6d7-4838-9be9-6381c8b4365c", () => OpenImportProductsSettingsPageUserTask.PageUId);
			MetaPathParameterValues.Add("d721f8de-068e-414d-8974-d2ea54c3c436", () => OpenImportProductsSettingsPageUserTask.PageUrl);
			MetaPathParameterValues.Add("423ed8b9-95e2-44d8-8894-315383286ea7", () => OpenImportProductsSettingsPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("8c14ce01-acf7-4852-a4fe-523556c6af2d", () => OpenImportProductsSettingsPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("028e1059-ab68-4842-85fc-37d0c190afea", () => OpenImportProductsSettingsPageUserTask.PageParameters);
			MetaPathParameterValues.Add("6e3e266c-a405-456a-9ba2-4135ed63f254", () => OpenImportProductsSettingsPageUserTask.Width);
			MetaPathParameterValues.Add("9937dbb7-f7bc-45a0-92b0-540bbb9943f7", () => OpenImportProductsSettingsPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("9ceb3f2c-a708-40bb-ba18-01a662a1cf3f", () => OpenImportProductsSettingsPageUserTask.Height);
			MetaPathParameterValues.Add("b8da5264-f2ce-457c-8f40-6795c18818fb", () => OpenImportProductsSettingsPageUserTask.Centered);
			MetaPathParameterValues.Add("d4ce6e84-26e5-4e42-950c-885a484096fa", () => OpenImportProductsSettingsPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("6012d09d-4f89-437e-882a-fb81808b1530", () => OpenImportProductsSettingsPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("28a02e11-3a60-4d3e-b60a-9572687364a6", () => OpenImportProductsSettingsPageUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("2821e58d-2971-4cd0-ba15-3d4ab5f4f287", () => ConfirmOpenLogFile.Page);
			MetaPathParameterValues.Add("0ffbdc2f-bf43-459e-a8d9-089bcb2ef647", () => ConfirmOpenLogFile.Icon);
			MetaPathParameterValues.Add("a906ae43-aaf9-41f8-a4be-dcdb423ed4c6", () => ConfirmOpenLogFile.Buttons);
			MetaPathParameterValues.Add("944b1b7a-4cdc-42f4-b214-b39010992825", () => ConfirmOpenLogFile.WindowCaption);
			MetaPathParameterValues.Add("ebd0df11-1cf8-480a-9bd1-1dbb3f6d7787", () => ConfirmOpenLogFile.MessageText);
			MetaPathParameterValues.Add("f33f0c23-5085-4f83-96c8-03b4f56338be", () => ConfirmOpenLogFile.ResponseMessages);
			MetaPathParameterValues.Add("9d058c87-6398-4a5d-bfdb-08bd94b6adcf", () => ConfirmOpenLogFile.ProcessInstanceId);
			MetaPathParameterValues.Add("23d7b94c-3f16-46e8-afda-33eacecc21e9", () => ConfirmOpenLogFile.PageParameters);
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
				case "TreeGridSelectedRowsIds":
					if (!hasValueToRead) break;
					TreeGridSelectedRowsIds = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SetParametersScriptExecute(ProcessExecutingContext context) {
			OpenImportProductsSettingsPageUserTask.PageUId = new Guid("c9d3708b-32e9-4ab9-9f57-fb9bc6f6a652");
			OpenImportProductsSettingsPageUserTask.OpenerInstanceId = context.Process.InstanceUId;	  
			OpenImportProductsSettingsPageUserTask.CloseMessage = "ShowMessageBox";	
			OpenImportProductsSettingsPageUserTask.UseCurrentActivePage = true;
			return true;
		}

		public virtual bool ShowMessageBoxScriptExecute(ProcessExecutingContext context) {
			var importedRowsCount = new KeyValuePair<int, int>(0, 0);
			object importedRowsCountSessionData = UserConnection.SessionData["ImportedRowsCount"];
			if (importedRowsCountSessionData != null) { 
				importedRowsCount = (KeyValuePair<int, int>)importedRowsCountSessionData;
			}
			ConfirmOpenLogFile.MessageText = string.Format(OpenLogFileMessage, importedRowsCount.Key, importedRowsCount.Value);
			ConfirmOpenLogFile.Icon = "QUESTION";
			ConfirmOpenLogFile.Buttons = "YESNO";
			ConfirmOpenLogFile.ResponseMessages = new Dictionary<string, string> {{"yes", "YesMessage"}, {"no", "NoMessage"}};
			ConfirmOpenLogFile.ProcessInstanceId = InstanceUId;
			UserConnection.SessionData.Remove("ImportedRowsCount");
			return true;
		}

		public virtual bool ClearParametersScriptExecute(ProcessExecutingContext context) {
			object excelImportIdSessionData = UserConnection.SessionData["ExcelImportId"];
			if (excelImportIdSessionData != null) { 
				var excelImportId = (Guid)excelImportIdSessionData;
				new Delete(UserConnection).From("ExcelImport").
					Where("Id").IsEqual(Column.Parameter(excelImportId)).Execute();
				UserConnection.SessionData.Remove("ExcelImportId");
			}
			return true;
		}

		public virtual bool PrepareUploadScriptExecute(ProcessExecutingContext context) {
			var page = HttpContext.Current.CurrentHandler as UI.WebControls.Page;
			string script = "window.BPMSoft.AjaxMethods.ThrowClientEvent('" + 
				InstanceUId +
				"', 'SaveLog', '', { isUpload : true });"; 
			page.AddScript(script);
			
			return true;
		}

		public virtual bool SaveLogScriptTaskExecute(ProcessExecutingContext context) {
			if (UserConnection.SessionData["ExcelImportId"] != null) { 
				var excelImportId = (Guid)UserConnection.SessionData["ExcelImportId"];
				var stringBuilder = new StringBuilder();
				var logMessages = new Select(UserConnection).Column("MessageText").From("ExcelImportLog")
					.Where("ExcelImportId").IsEqual(Column.Parameter(excelImportId))
					.OrderByAsc("CreatedOn")
					as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader message = logMessages.ExecuteReader(dbExecutor)) {
						while (message.Read()) {
							if (message[0] != null) {
								stringBuilder.Append(message[0].ToString());
								stringBuilder.Append("\r\n");
							}
						}
					}
				}
				var fileData = stringBuilder.ToString();
				var page = HttpContext.Current.CurrentHandler as UI.WebControls.Page;
				var response = page.Response; 
				response.ContentType = "text/plain";
				response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.txt", ProductsImportFileLog));
				response.Write(fileData);
				response.End();
				new Delete(UserConnection).From("ExcelImport").
					Where("Id").IsEqual(Column.Parameter(excelImportId)).Execute();
				UserConnection.SessionData.Remove("ExcelImportId");
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ShowMessageBox":
					if (ActivatedEventElements.Remove("ShowMessageBoxStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageBoxStartMessage", "ShowMessageBoxStartMessage"));
					}
					break;
					case "NoMessage":
					if (ActivatedEventElements.Remove("IntermediateCatchMessageEvent1NoMessageStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchMessageEvent1NoMessageStartMessage", "IntermediateCatchMessageEvent1NoMessageStartMessage"));
					}
					break;
					case "YesMessage":
					if (ActivatedEventElements.Remove("YesMessageStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("YesMessageStartMessage", "YesMessageStartMessage"));
					}
					break;
					case "SaveLog":
					if (ActivatedEventElements.Remove("SaveLogIntermediateCatchMessageEvent")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLogIntermediateCatchMessageEvent", "SaveLogIntermediateCatchMessageEvent"));
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
			var cloneItem = (ImportProductXLSProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.TreeGridSelectedRowsIds = TreeGridSelectedRowsIds;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

