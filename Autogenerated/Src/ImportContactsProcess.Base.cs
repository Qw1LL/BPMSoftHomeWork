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

	#region Class: ImportContactsProcessSchema

	/// <exclude/>
	public class ImportContactsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ImportContactsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ImportContactsProcessSchema(ImportContactsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ImportContactsProcess";
			UId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2803";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
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
			RealUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("76781320-a58c-45fc-a406-1f67fff79a03"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("03c643ce-1198-4bc1-82ab-2962bf14c7fd"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
		}

		protected virtual void InitializeOpenImportContactsSettingsPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9b80a7d5-b718-4bd1-8805-8eb23c85fa06"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("a8e12097-31a5-4140-bed4-57ba21f938a0"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("de9bb92a-31a0-4d69-b1ff-e453a1c9ee8f"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("3616a10b-654d-4af4-8972-2fe21546d403"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("2b463efd-c836-4611-806a-474a398bd298"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("6cb21bd4-1287-4126-8668-bb04b06a03df"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("77db6981-c6a1-4862-9bd2-c3df82769b24"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("b218cbd1-2207-46be-ae59-11956148e0af"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
				UId = new Guid("ad99a52a-edf1-4386-afb1-f76ddba388c4"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
			var useCurrentActivePageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6646434d-92ab-455e-95a3-06118048e8cc"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
			var useOpenerRegisterScriptParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("60403cbb-bfff-432f-aca3-8b886fb18637"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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
			var ignoreProfileParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4d649ab8-b41b-48d5-aabe-4be4e03ebaae"),
				ContainerUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
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

		protected virtual void InitializeConfirmOpenLogFileParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6be93e77-cf14-4b1d-8108-46f7a7e97514"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("3628b891-fc9f-4f88-b112-60fb459f6f54"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("22be4377-6a20-46f9-a6e6-9932c4b90460"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("76cd0ed7-39c2-44ac-9c72-ea2a32da8ead"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("5c7eed2c-251e-4f83-9d43-ea47876dbac0"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("02e10f24-110f-4c36-b4c7-97dca146bf2d"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("dcdb729c-b149-4d84-b4ff-cc50e57424bc"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
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
				UId = new Guid("9cc9ac32-3187-4fdc-9f43-0e4728febca4"),
				ContainerUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
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
			ProcessSchemaLaneSet schemaLaneSet71 = CreateLaneSet71LaneSet();
			LaneSets.Add(schemaLaneSet71);
			ProcessSchemaLane schemaLane185 = CreateLane185Lane();
			schemaLaneSet71.Lanes.Add(schemaLane185);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask setparametersscript = CreateSetParametersScriptScriptTask();
			FlowElements.Add(setparametersscript);
			ProcessSchemaUserTask openimportcontactssettingspageusertask = CreateOpenImportContactsSettingsPageUserTaskUserTask();
			FlowElements.Add(openimportcontactssettingspageusertask);
			ProcessSchemaIntermediateCatchMessageEvent showmessageboxstartmessage = CreateShowMessageBoxStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(showmessageboxstartmessage);
			ProcessSchemaScriptTask showmessageboxscript = CreateShowMessageBoxScriptScriptTask();
			FlowElements.Add(showmessageboxscript);
			ProcessSchemaUserTask confirmopenlogfile = CreateConfirmOpenLogFileUserTask();
			FlowElements.Add(confirmopenlogfile);
			ProcessSchemaIntermediateCatchMessageEvent nomessagestartmessage = CreateNoMessageStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(nomessagestartmessage);
			ProcessSchemaIntermediateCatchMessageEvent yesmessagestartmessage = CreateYesMessageStartMessageIntermediateCatchMessageEvent();
			FlowElements.Add(yesmessagestartmessage);
			ProcessSchemaScriptTask savelogscripttask = CreateSaveLogScriptTaskScriptTask();
			FlowElements.Add(savelogscripttask);
			ProcessSchemaScriptTask clearparametersscript = CreateClearParametersScriptScriptTask();
			FlowElements.Add(clearparametersscript);
			ProcessSchemaIntermediateCatchMessageEvent savelogintermediatecatchmessageevent = CreateSaveLogIntermediateCatchMessageEventIntermediateCatchMessageEvent();
			FlowElements.Add(savelogintermediatecatchmessageevent);
			ProcessSchemaScriptTask prepareuploadscript = CreatePrepareUploadScriptScriptTask();
			FlowElements.Add(prepareuploadscript);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			FlowElements.Add(CreateSequenceFlow586SequenceFlow());
			FlowElements.Add(CreateSequenceFlow587SequenceFlow());
			FlowElements.Add(CreateSequenceFlow588SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1334SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateOpenLogFileMessageLocalizableString());
			LocalizableStrings.Add(CreateContactsImportFileLogLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateOpenLogFileMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("bd5f8d80-0d9f-44fb-88ac-7a811513f284"),
				Name = "OpenLogFileMessage",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateContactsImportFileLogLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("48f8ba67-c19c-4ddb-b37b-7727d38335c8"),
				Name = "ContactsImportFileLog",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow586SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow586",
				UId = new Guid("72f22043-6b0d-43c2-9403-863a68a3a403"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe4ae452-8d76-4b4c-b846-6ab2fb3a4855"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow587SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow587",
				UId = new Guid("96554ef0-d208-44b3-bf29-caffb4e245df"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("338e45f4-2641-4510-b351-29b831a9158c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow588SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow588",
				UId = new Guid("40b7441e-96cf-4af1-9566-0aeebb7d1f44"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(170, 201),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3fc92963-6e8d-4227-bc2f-9520e2630c1e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("338e45f4-2641-4510-b351-29b831a9158c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1334SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1334",
				UId = new Guid("f93a82d3-021a-48ee-b5cb-7be31d307227"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fe426351-3f9a-4c76-98a5-cac79d8e8278"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("b720930f-677d-45ff-9bb6-81314ad9a1ef"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71efbdc1-8124-418e-b777-3942b5866bf1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("065ab571-b300-493e-b852-d23f9d42271a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(780, 268),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6144b03e-ea35-4834-8de2-967f3e8207d4"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("a9f24578-fa33-4364-9ced-ad8d34b356d1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(862, 152),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("71efbdc1-8124-418e-b777-3942b5866bf1"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5b6dd4c3-ada9-41b3-bed0-9d87e30b9491"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("4e9262a7-0a4b-485a-8e08-39753dafa8e9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(870, 253),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6144b03e-ea35-4834-8de2-967f3e8207d4"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9e8b189b-60d8-4311-a454-95b6daa126d9"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("670a76e5-3243-46ba-8e31-05f85409d66e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(870, 253),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("23cfd787-25b5-4745-b9b9-b1569ff56d40"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2172d3b1-d2f7-4098-9e1b-96c99bc99481"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("8834861d-c4a6-4cb0-9bf4-cf7d81efc84c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(1049, 156),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5b6dd4c3-ada9-41b3-bed0-9d87e30b9491"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2172d3b1-d2f7-4098-9e1b-96c99bc99481"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("e91c5662-ea6f-46ca-b2d1-9e72a9f4f9e1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(870, 253),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b743d3c7-0058-4c95-8ea9-a41567638403"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("23cfd787-25b5-4745-b9b9-b1569ff56d40"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("a18ae9ea-2123-4c90-8722-f92c631e0110"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(870, 253),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9e8b189b-60d8-4311-a454-95b6daa126d9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b743d3c7-0058-4c95-8ea9-a41567638403"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("f3ac2b30-b215-48e6-a7ff-962cd3021d07"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(542, 197),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fe426351-3f9a-4c76-98a5-cac79d8e8278"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("90e25b55-428a-4f3d-9c3b-b22f7634ea21"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow10",
				UId = new Guid("507ad223-cd12-4fcd-b9cb-d49440a31f95"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(695, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("90e25b55-428a-4f3d-9c3b-b22f7634ea21"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fe4ae452-8d76-4b4c-b846-6ab2fb3a4855"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("2ff5f1a2-baec-4a3c-89db-3f02a4e6c5da"),
				ConditionExpression = @"UserConnection.SessionData[""ImportedRowsCount""] == null",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				CurveCenterPosition = new Point(930, 132),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("90e25b55-428a-4f3d-9c3b-b22f7634ea21"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5b6dd4c3-ada9-41b3-bed0-9d87e30b9491"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet71LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet71 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a2e76b3d-8e1f-4c33-a90b-8fafe42b7277"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"LaneSet71",
				Position = new Point(5, 5),
				Size = new Size(1454, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet71;
		}

		protected virtual ProcessSchemaLane CreateLane185Lane() {
			ProcessSchemaLane schemaLane185 = new ProcessSchemaLane(this) {
				UId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a2e76b3d-8e1f-4c33-a90b-8fafe42b7277"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"Lane185",
				Position = new Point(29, 0),
				Size = new Size(1425, 400),
				UseBackgroundMode = false
			};
			return schemaLane185;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("3fc92963-6e8d-4227-bc2f-9520e2630c1e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"Start1",
				Position = new Point(50, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("2172d3b1-d2f7-4098-9e1b-96c99bc99481"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"End1",
				Position = new Point(1366, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSetParametersScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("338e45f4-2641-4510-b351-29b831a9158c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"SetParametersScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(141, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,141,177,14,130,48,16,64,103,248,138,166,147,14,24,107,0,49,141,131,50,24,6,131,9,250,1,5,78,36,106,75,218,171,248,249,22,130,59,219,189,187,203,123,121,7,50,123,119,74,99,170,36,138,10,77,1,136,173,108,204,69,52,112,51,160,175,194,60,87,35,100,53,217,19,9,61,57,217,182,94,208,112,45,32,20,187,42,216,136,152,5,225,189,102,129,40,163,56,72,96,91,178,109,25,133,44,137,233,146,251,249,188,196,240,6,58,147,6,133,172,96,108,253,193,149,185,71,200,92,83,250,82,6,206,96,140,91,58,11,45,30,170,159,240,168,190,148,123,115,69,110,72,173,214,32,241,80,97,251,129,225,232,132,168,45,112,223,215,128,86,203,137,126,75,146,163,175,72,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenImportContactsSettingsPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"OpenImportContactsSettingsPageUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(281, 163),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenImportContactsSettingsPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateShowMessageBoxStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("fe426351-3f9a-4c76-98a5-cac79d8e8278"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"ShowMessageBox",
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"ShowMessageBoxStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(421, 177),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateShowMessageBoxScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("fe4ae452-8d76-4b4c-b846-6ab2fb3a4855"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"ShowMessageBoxScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(701, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,77,107,194,64,16,134,207,13,228,63,76,247,20,33,4,239,90,15,245,3,66,91,181,126,65,41,61,44,113,148,133,100,86,118,55,90,9,254,247,78,108,44,69,214,67,233,37,75,134,247,125,159,153,217,221,75,3,170,216,105,227,112,61,211,7,219,215,37,57,120,0,194,3,60,225,113,37,243,18,167,82,153,174,34,23,3,127,122,81,59,134,118,171,19,6,106,3,209,210,162,233,107,34,204,156,210,148,204,209,90,62,7,210,201,119,145,94,199,138,15,184,231,228,50,207,91,80,65,24,220,249,192,145,159,218,250,35,137,251,59,133,65,24,176,101,163,76,49,217,33,61,235,237,72,229,152,188,176,85,110,113,129,159,53,207,58,163,104,155,140,180,41,164,139,126,233,26,25,227,175,211,19,110,209,87,62,183,93,111,198,3,77,51,77,76,19,175,203,225,124,145,78,198,194,47,123,44,157,211,100,107,229,219,112,62,158,220,144,205,208,238,88,118,233,209,54,23,54,80,231,229,72,115,236,126,143,21,55,227,245,160,170,196,17,173,136,57,23,109,99,19,167,24,42,65,186,174,142,245,79,241,228,103,78,141,206,88,146,146,117,146,50,76,215,12,189,252,44,211,53,155,254,251,36,248,69,220,54,243,204,133,222,99,228,201,168,87,126,190,108,131,174,52,4,206,148,216,249,2,55,232,79,208,217,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateConfirmOpenLogFileUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"ConfirmOpenLogFile",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(869, 163),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeConfirmOpenLogFileParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateNoMessageStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("71efbdc1-8124-418e-b777-3942b5866bf1"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"NoMessage",
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"NoMessageStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1030, 100),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateYesMessageStartMessageIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("6144b03e-ea35-4834-8de2-967f3e8207d4"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"YesMessage",
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"YesMessageStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(967, 289),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSaveLogScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("23cfd787-25b5-4745-b9b9-b1569ff56d40"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"SaveLogScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1247, 268),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,203,110,219,48,16,60,203,95,193,242,68,1,41,155,187,224,67,252,106,12,180,72,209,184,200,33,201,129,149,214,54,1,137,84,201,101,226,32,240,191,119,41,202,177,236,160,5,114,144,4,112,135,179,59,179,35,189,102,226,151,7,55,181,198,64,137,218,26,121,11,222,211,119,166,80,221,243,249,174,132,122,217,180,214,225,178,226,143,236,211,152,153,80,215,57,123,101,163,236,73,57,6,67,0,27,51,241,53,232,42,255,0,101,49,74,68,30,157,54,155,73,208,117,5,142,136,12,60,179,219,225,153,200,139,132,172,237,230,59,17,170,13,248,3,14,106,234,116,38,36,151,83,91,135,198,8,222,163,87,176,67,158,203,133,179,141,24,78,241,205,110,120,62,202,50,121,183,5,7,226,108,192,92,46,253,252,79,80,181,72,116,242,135,114,170,1,164,129,78,180,231,29,197,141,163,73,39,47,87,190,20,124,234,64,33,84,55,166,99,87,190,31,147,84,4,79,178,152,136,98,170,223,243,29,148,1,109,212,124,102,219,220,248,224,96,54,57,30,137,156,156,39,178,158,96,25,29,253,9,42,58,214,36,145,196,50,240,71,38,114,72,24,113,108,214,243,100,207,91,93,3,19,253,101,25,113,135,30,89,166,215,111,149,251,203,225,238,187,106,118,178,49,121,213,182,96,170,1,94,174,108,218,31,17,22,255,185,193,31,220,3,89,148,32,251,248,142,47,122,246,125,50,214,52,98,20,74,210,78,9,142,13,250,100,56,240,173,53,62,154,112,141,216,146,111,72,59,151,211,224,28,24,36,117,169,92,80,118,15,80,217,129,12,174,94,218,120,141,199,11,95,218,90,105,195,139,1,234,170,170,174,147,135,188,191,240,121,166,169,230,117,92,11,191,232,39,147,11,235,26,133,130,43,68,85,110,27,194,21,221,252,134,34,51,126,189,220,75,164,12,94,176,200,161,74,244,41,60,11,2,80,8,59,155,222,58,222,57,141,32,14,218,79,74,115,114,141,14,70,89,204,254,140,66,69,192,243,236,191,75,57,5,153,108,237,35,254,161,92,31,66,148,122,254,251,215,38,127,27,251,244,254,7,42,70,180,73,7,24,156,97,232,2,20,127,1,150,126,21,235,117,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateClearParametersScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("5b6dd4c3-ada9-41b3-bed0-9d87e30b9491"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"ClearParametersScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1184, 86),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,142,189,10,194,48,20,70,231,230,41,174,153,146,37,47,80,58,181,85,186,137,34,14,226,16,234,21,11,249,209,155,164,22,196,119,55,99,43,56,56,221,229,158,243,157,225,10,226,16,144,106,239,28,246,113,240,78,237,49,132,124,27,29,245,137,183,83,143,166,179,119,79,177,187,240,51,172,42,112,201,24,9,47,96,197,168,9,112,254,0,21,136,77,26,46,242,15,101,201,10,135,79,104,208,96,196,175,22,169,214,228,173,152,35,92,42,86,20,199,27,18,10,158,121,169,186,208,62,146,54,162,246,38,89,167,182,154,180,205,42,18,139,52,41,85,59,97,159,242,134,204,147,191,3,213,14,173,31,179,124,217,153,161,55,99,132,49,145,131,72,9,203,15,37,156,123,209,59,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateSaveLogIntermediateCatchMessageEventIntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("b743d3c7-0058-4c95-8ea9-a41567638403"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = true,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"SaveLog",
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"SaveLogIntermediateCatchMessageEvent",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1156, 282),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareUploadScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9e8b189b-60d8-4311-a454-95b6daa126d9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"PrepareUploadScript",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(1051, 268),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,61,143,221,10,130,64,16,133,175,19,124,135,193,27,147,98,31,32,233,162,36,72,40,16,76,186,222,218,201,54,100,87,102,199,31,136,222,189,213,160,139,249,131,115,14,223,244,146,160,149,53,194,22,142,204,109,102,13,227,200,34,235,136,208,252,231,81,26,213,32,129,116,80,229,226,138,183,73,71,182,113,162,240,222,52,12,194,192,49,105,83,131,187,147,110,217,167,69,131,54,202,14,98,95,156,75,251,96,177,123,201,241,140,252,180,202,137,203,147,236,144,53,218,39,31,122,223,150,113,4,43,8,131,69,110,28,75,115,199,42,87,176,242,119,20,175,33,46,101,143,39,91,79,171,175,55,104,87,181,141,149,10,54,192,212,33,124,146,52,74,189,123,122,67,236,148,42,103,132,229,143,36,153,225,8,185,35,51,203,211,47,160,108,94,90,242,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("90e25b55-428a-4f3d-9c3b-b22f7634ea21"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("28b9417b-4a2b-4db5-ae61-f30fb4275175"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"),
				Name = @"ExclusiveGateway1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(547, 163),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a4923ba8-7c69-45d0-8d57-a23390324f98"),
				Name = "System.Text",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bd3334a9-3c98-400b-b42a-aa9393356348"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("cf0441d7-a076-4692-8583-ebffe9d1690a"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("397c5939-a759-4475-831c-436406ad81a6"),
				Name = "BPMSoft.UI.WebControls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ImportContactsProcess(userConnection);
		}

		public override object Clone() {
			return new ImportContactsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd"));
		}

		#endregion

	}

	#endregion

	#region Class: ImportContactsProcess

	/// <exclude/>
	public class ImportContactsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane185

		/// <exclude/>
		public class ProcessLane185 : ProcessLane
		{

			public ProcessLane185(UserConnection userConnection, ImportContactsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenImportContactsSettingsPageUserTaskFlowElement

		/// <exclude/>
		public class OpenImportContactsSettingsPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenImportContactsSettingsPageUserTaskFlowElement(UserConnection userConnection, ImportContactsProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenImportContactsSettingsPageUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("1f9fa2cb-791e-4eca-a186-cfaf4ee7d42a");
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

			public ConfirmOpenLogFileFlowElement(UserConnection userConnection, ImportContactsProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ConfirmOpenLogFile";
				IsLogging = false;
				SchemaElementUId = new Guid("2966e7e4-d4fe-4835-b534-ba3e432351e3");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ImportContactsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ImportContactsProcess";
			SchemaUId = new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd");
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
				return new Guid("897ae04b-666b-45f3-bc0a-bc7301dda4cd");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ImportContactsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ImportContactsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private ProcessLane185 _lane185;
		public ProcessLane185 Lane185 {
			get {
				return _lane185 ?? ((_lane185) = new ProcessLane185(UserConnection, this));
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
					SchemaElementUId = new Guid("3fc92963-6e8d-4227-bc2f-9520e2630c1e"),
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
					SchemaElementUId = new Guid("2172d3b1-d2f7-4098-9e1b-96c99bc99481"),
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
					SchemaElementUId = new Guid("338e45f4-2641-4510-b351-29b831a9158c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SetParametersScriptExecute,
				});
			}
		}

		private OpenImportContactsSettingsPageUserTaskFlowElement _openImportContactsSettingsPageUserTask;
		public OpenImportContactsSettingsPageUserTaskFlowElement OpenImportContactsSettingsPageUserTask {
			get {
				return _openImportContactsSettingsPageUserTask ?? (_openImportContactsSettingsPageUserTask = new OpenImportContactsSettingsPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("fe426351-3f9a-4c76-98a5-cac79d8e8278"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "ShowMessageBox",
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
					SchemaElementUId = new Guid("fe4ae452-8d76-4b4c-b846-6ab2fb3a4855"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ShowMessageBoxScriptExecute,
				});
			}
		}

		private ConfirmOpenLogFileFlowElement _confirmOpenLogFile;
		public ConfirmOpenLogFileFlowElement ConfirmOpenLogFile {
			get {
				return _confirmOpenLogFile ?? (_confirmOpenLogFile = new ConfirmOpenLogFileFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _noMessageStartMessage;
		public ProcessIntermediateCatchMessageEvent NoMessageStartMessage {
			get {
				return _noMessageStartMessage ?? (_noMessageStartMessage = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "NoMessageStartMessage",
					SchemaElementUId = new Guid("71efbdc1-8124-418e-b777-3942b5866bf1"),
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
					SchemaElementUId = new Guid("6144b03e-ea35-4834-8de2-967f3e8207d4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "YesMessage",
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
					SchemaElementUId = new Guid("23cfd787-25b5-4745-b9b9-b1569ff56d40"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SaveLogScriptTaskExecute,
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
					SchemaElementUId = new Guid("5b6dd4c3-ada9-41b3-bed0-9d87e30b9491"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ClearParametersScriptExecute,
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
					SchemaElementUId = new Guid("b743d3c7-0058-4c95-8ea9-a41567638403"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SaveLog",
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
					SchemaElementUId = new Guid("9e8b189b-60d8-4311-a454-95b6daa126d9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = PrepareUploadScriptExecute,
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
					SchemaElementUId = new Guid("90e25b55-428a-4f3d-9c3b-b22f7634ea21"),
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

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("2ff5f1a2-baec-4a3c-89db-3f02a4e6c5da"),
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

		private LocalizableString _contactsImportFileLog;
		public LocalizableString ContactsImportFileLog {
			get {
				return _contactsImportFileLog ?? (_contactsImportFileLog = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ContactsImportFileLog.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[SetParametersScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetParametersScript };
			FlowElements[OpenImportContactsSettingsPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenImportContactsSettingsPageUserTask };
			FlowElements[ShowMessageBoxStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageBoxStartMessage };
			FlowElements[ShowMessageBoxScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageBoxScript };
			FlowElements[ConfirmOpenLogFile.SchemaElementUId] = new Collection<ProcessFlowElement> { ConfirmOpenLogFile };
			FlowElements[NoMessageStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { NoMessageStartMessage };
			FlowElements[YesMessageStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { YesMessageStartMessage };
			FlowElements[SaveLogScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLogScriptTask };
			FlowElements[ClearParametersScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearParametersScript };
			FlowElements[SaveLogIntermediateCatchMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SaveLogIntermediateCatchMessageEvent };
			FlowElements[PrepareUploadScript.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareUploadScript };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
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
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenImportContactsSettingsPageUserTask", e.Context.SenderName));
						break;
					case "OpenImportContactsSettingsPageUserTask":
						ActivatedEventElements.Add("ShowMessageBoxStartMessage");
						break;
					case "ShowMessageBoxStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ShowMessageBoxScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ConfirmOpenLogFile", e.Context.SenderName));
						break;
					case "ConfirmOpenLogFile":
						ActivatedEventElements.Add("NoMessageStartMessage");
						ActivatedEventElements.Add("YesMessageStartMessage");
						break;
					case "NoMessageStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearParametersScript", e.Context.SenderName));
						break;
					case "YesMessageStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareUploadScript", e.Context.SenderName));
						break;
					case "SaveLogScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "ClearParametersScript":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "SaveLogIntermediateCatchMessageEvent":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SaveLogScriptTask", e.Context.SenderName));
						break;
					case "PrepareUploadScript":
						if (!ActivatedEventElements.Contains("SaveLogIntermediateCatchMessageEvent")) {
							ActivatedEventElements.Add("SaveLogIntermediateCatchMessageEvent");
						}
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearParametersScript", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageBoxScript", e.Context.SenderName));
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
			MetaPathParameterValues.Add("76781320-a58c-45fc-a406-1f67fff79a03", () => PageInstanceId);
			MetaPathParameterValues.Add("03c643ce-1198-4bc1-82ab-2962bf14c7fd", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("9b80a7d5-b718-4bd1-8805-8eb23c85fa06", () => OpenImportContactsSettingsPageUserTask.PageUId);
			MetaPathParameterValues.Add("a8e12097-31a5-4140-bed4-57ba21f938a0", () => OpenImportContactsSettingsPageUserTask.PageUrl);
			MetaPathParameterValues.Add("de9bb92a-31a0-4d69-b1ff-e453a1c9ee8f", () => OpenImportContactsSettingsPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("3616a10b-654d-4af4-8972-2fe21546d403", () => OpenImportContactsSettingsPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("2b463efd-c836-4611-806a-474a398bd298", () => OpenImportContactsSettingsPageUserTask.PageParameters);
			MetaPathParameterValues.Add("6cb21bd4-1287-4126-8668-bb04b06a03df", () => OpenImportContactsSettingsPageUserTask.Width);
			MetaPathParameterValues.Add("77db6981-c6a1-4862-9bd2-c3df82769b24", () => OpenImportContactsSettingsPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("b218cbd1-2207-46be-ae59-11956148e0af", () => OpenImportContactsSettingsPageUserTask.Height);
			MetaPathParameterValues.Add("ad99a52a-edf1-4386-afb1-f76ddba388c4", () => OpenImportContactsSettingsPageUserTask.Centered);
			MetaPathParameterValues.Add("6646434d-92ab-455e-95a3-06118048e8cc", () => OpenImportContactsSettingsPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("60403cbb-bfff-432f-aca3-8b886fb18637", () => OpenImportContactsSettingsPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("4d649ab8-b41b-48d5-aabe-4be4e03ebaae", () => OpenImportContactsSettingsPageUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("6be93e77-cf14-4b1d-8108-46f7a7e97514", () => ConfirmOpenLogFile.Page);
			MetaPathParameterValues.Add("3628b891-fc9f-4f88-b112-60fb459f6f54", () => ConfirmOpenLogFile.Icon);
			MetaPathParameterValues.Add("22be4377-6a20-46f9-a6e6-9932c4b90460", () => ConfirmOpenLogFile.Buttons);
			MetaPathParameterValues.Add("76cd0ed7-39c2-44ac-9c72-ea2a32da8ead", () => ConfirmOpenLogFile.WindowCaption);
			MetaPathParameterValues.Add("5c7eed2c-251e-4f83-9d43-ea47876dbac0", () => ConfirmOpenLogFile.MessageText);
			MetaPathParameterValues.Add("02e10f24-110f-4c36-b4c7-97dca146bf2d", () => ConfirmOpenLogFile.ResponseMessages);
			MetaPathParameterValues.Add("dcdb729c-b149-4d84-b4ff-cc50e57424bc", () => ConfirmOpenLogFile.ProcessInstanceId);
			MetaPathParameterValues.Add("9cc9ac32-3187-4fdc-9f43-0e4728febca4", () => ConfirmOpenLogFile.PageParameters);
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
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SetParametersScriptExecute(ProcessExecutingContext context) {
			OpenImportContactsSettingsPageUserTask.PageUId = new Guid("40ae4a9c-2a61-4fd1-ab56-8e7b17b54186");
			OpenImportContactsSettingsPageUserTask.OpenerInstanceId = InstanceUId;	  
			OpenImportContactsSettingsPageUserTask.CloseMessage = "ShowMessageBox";	
			OpenImportContactsSettingsPageUserTask.UseCurrentActivePage = true;
			
			return true;
		}

		public virtual bool ShowMessageBoxScriptExecute(ProcessExecutingContext context) {
			var importedRowsCount = new KeyValuePair<int, int>(0, 0);
			if (UserConnection.SessionData["ImportedRowsCount"] != null) { 
				importedRowsCount = (KeyValuePair<int, int>)UserConnection.SessionData["ImportedRowsCount"];
			}
			
			ConfirmOpenLogFile.MessageText = string.Format(OpenLogFileMessage, importedRowsCount.Key, importedRowsCount.Value);
			ConfirmOpenLogFile.Icon = "QUESTION";
			ConfirmOpenLogFile.Buttons = "YESNO";
			ConfirmOpenLogFile.ResponseMessages = new Dictionary<string, string> {{"yes", "YesMessage"}, {"no", "NoMessage"}};
			ConfirmOpenLogFile.ProcessInstanceId = InstanceUId;
			
			if (UserConnection.SessionData["ImportedRowsCount"] != null) {
				UserConnection.SessionData.Remove("ImportedRowsCount");
			}
			
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
				var response = HttpContext.Current.Response; 
				response.ContentType = "text/plain";
				response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.txt", ContactsImportFileLog));
				response.Write(fileData);
				response.End();
			
				new Delete(UserConnection).From("ExcelImport").
					Where("Id").IsEqual(Column.Parameter(excelImportId)).Execute();
			
				UserConnection.SessionData.Remove("ExcelImportId");
			}
			
			return true;
		}

		public virtual bool ClearParametersScriptExecute(ProcessExecutingContext context) {
			if (UserConnection.SessionData["ExcelImportId"] != null) { 
				var excelImportId = (Guid)UserConnection.SessionData["ExcelImportId"];
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

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ShowMessageBox":
					if (ActivatedEventElements.Remove("ShowMessageBoxStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageBoxStartMessage", "ShowMessageBoxStartMessage"));
					}
					break;
					case "NoMessage":
					if (ActivatedEventElements.Remove("NoMessageStartMessage")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("NoMessageStartMessage", "NoMessageStartMessage"));
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
			var cloneItem = (ImportContactsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

