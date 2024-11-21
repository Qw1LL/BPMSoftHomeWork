namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ViewRecordAllChangesProcessSchema

	/// <exclude/>
	public class ViewRecordAllChangesProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ViewRecordAllChangesProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ViewRecordAllChangesProcessSchema(ViewRecordAllChangesProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ViewRecordAllChangesProcess";
			UId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438");
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
			RealUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("02ebc602-b614-42e3-92f4-72a724b1e92f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6c5bae4c-c34a-4bf9-80d0-61fbb7c91dd8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateShowGridParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3d7b9c01-8151-469d-8d94-64baf9bc6eb0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"ShowGrid",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentSchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("71d8fb77-af88-4aaf-8f7d-769f4bbfe83f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"CurrentSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0bd6afe1-e067-4ce7-ab1c-ad0f7b4a84a0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFilterByChangeTrackedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("23e517dd-2f43-4894-9151-37cd960f1d93"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"FilterByChangeTracked",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateRecordNotSelectedMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("17e3b620-2918-4660-8368-143d59c6da5c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"RecordNotSelectedMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreatePageParameter());
			Parameters.Add(CreateShowGridParameter());
			Parameters.Add(CreateCurrentSchemaUIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateFilterByChangeTrackedParameter());
			Parameters.Add(CreateRecordNotSelectedMessageParameter());
		}

		protected virtual void InitializeOpenGridPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fed1b265-7a88-40d5-9aab-2f730d5b56e1"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("b07ed27e-cda3-4074-bb4d-e220e23cc856"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("51420213-2e9e-4baf-9a53-f59359845b57"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("a01fbaa2-0025-46f5-8002-01973fdef582"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("946606ed-b8b0-4368-b3f2-829db7d972e1"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("a0bc2be7-315b-4f09-bd1b-f49aa523daae"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("63b7efcf-04a2-4483-b578-8e3e4669da36"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("b593d800-eeab-40e3-89c0-19c5bc4a90f8"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("3d9b4a78-0619-4888-91b8-c65860cb9772"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("e5937907-a215-4f63-903b-c6c0365e17b4"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("6c4ab842-4d6b-4775-8966-3f5c82086535"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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
				UId = new Guid("53b3ee84-6c68-48ae-92e2-d4fc720b1716"),
				ContainerUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
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

		protected virtual void InitializeShowMessageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a382ed28-d3b2-4968-ae8b-07582b718e61"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("df40cb7e-cde7-4f58-9cc2-fb0379775b4d"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("24d293f2-eef6-414a-ad10-6d56399173d5"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("236e33b0-2730-472b-9064-e3674474f378"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("428ecd53-04d3-4bc2-adc4-140ea47da2f9"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("abcd1e76-3775-47bd-88ea-5ae7b18cf86e"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("c675b7d1-5f91-47de-8a84-44dd3ba1ae8d"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
				UId = new Guid("0c518195-debc-47ba-a7ea-09ae20f853ee"),
				ContainerUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
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
			ProcessSchemaLaneSet schemaLaneSet16 = CreateLaneSet16LaneSet();
			LaneSets.Add(schemaLaneSet16);
			ProcessSchemaLane schemaLane52 = CreateLane52Lane();
			schemaLaneSet16.Lanes.Add(schemaLane52);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask checkparametersscripttask = CreateCheckParametersScriptTaskScriptTask();
			FlowElements.Add(checkparametersscripttask);
			ProcessSchemaUserTask opengridpageusertask = CreateOpenGridPageUserTaskUserTask();
			FlowElements.Add(opengridpageusertask);
			ProcessSchemaUserTask showmessageusertask = CreateShowMessageUserTaskUserTask();
			FlowElements.Add(showmessageusertask);
			FlowElements.Add(CreateSequenceFlow178SequenceFlow());
			FlowElements.Add(CreateConditionalFlow21ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow180SequenceFlow());
			FlowElements.Add(CreateSequenceFlow181SequenceFlow());
			FlowElements.Add(CreateSequenceFlow182SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow178SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow178",
				UId = new Guid("e2541e01-fc8f-4dac-8baf-b0c37073cd33"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d33f4bb1-0400-4d7d-8105-add7f1ad4217"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6f87a3e8-c275-4e15-92c5-6bcc7b918ad5"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow21ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow21",
				UId = new Guid("c8a1f7ce-0534-44a2-8765-e9385fa15f3c"),
				ConditionExpression = @"ShowGrid",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				CurveCenterPosition = new Point(330, 134),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6f87a3e8-c275-4e15-92c5-6bcc7b918ad5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow180SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow180",
				UId = new Guid("ada79fbc-3ebb-49c3-a463-7f26c4f0e0ce"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				CurveCenterPosition = new Point(330, 231),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6f87a3e8-c275-4e15-92c5-6bcc7b918ad5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow181SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow181",
				UId = new Guid("908bf2e3-cd3d-4023-b110-edd8b0592be0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				CurveCenterPosition = new Point(546, 138),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b20b653-c814-4972-ac2b-6dc1cd08e8c3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow182SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow182",
				UId = new Guid("d4587d72-dbb2-4098-92b8-9d0a73664ba8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				CurveCenterPosition = new Point(546, 248),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b20b653-c814-4972-ac2b-6dc1cd08e8c3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet16LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet16 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("b534fc13-4898-4125-a190-7cf1c0eedc51"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"LaneSet16",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet16;
		}

		protected virtual ProcessSchemaLane CreateLane52Lane() {
			ProcessSchemaLane schemaLane52 = new ProcessSchemaLane(this) {
				UId = new Guid("c138a33a-67d1-4ac0-8b98-e9193e8cfacc"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("b534fc13-4898-4125-a190-7cf1c0eedc51"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"Lane52",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane52;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("d33f4bb1-0400-4d7d-8105-add7f1ad4217"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c138a33a-67d1-4ac0-8b98-e9193e8cfacc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"Start1",
				Position = new Point(50, 163),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("9b20b653-c814-4972-ac2b-6dc1cd08e8c3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c138a33a-67d1-4ac0-8b98-e9193e8cfacc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"End1",
				Position = new Point(596, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateCheckParametersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("6f87a3e8-c275-4e15-92c5-6bcc7b918ad5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c138a33a-67d1-4ac0-8b98-e9193e8cfacc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"CheckParametersScriptTask",
				Position = new Point(176, 149),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,85,93,79,219,48,20,125,102,210,254,131,151,167,84,162,81,39,64,133,65,59,181,233,7,209,68,233,72,25,15,136,7,147,220,182,25,169,221,217,14,93,5,252,247,93,219,41,105,75,3,79,123,168,92,59,247,220,115,124,191,156,140,137,235,103,66,0,83,97,52,133,25,189,14,98,210,104,144,126,150,196,94,119,54,87,75,242,252,76,90,145,74,30,97,36,0,250,34,137,115,251,43,190,216,182,173,144,167,207,159,246,194,41,95,104,59,210,32,99,154,74,56,205,207,46,64,74,58,129,107,9,98,68,229,131,55,20,60,194,163,128,73,69,89,4,65,220,88,253,69,17,165,32,220,160,227,112,41,21,204,188,27,184,247,206,149,154,251,156,41,248,171,188,92,218,106,61,167,44,78,65,16,42,73,123,120,17,242,177,242,174,3,13,210,246,130,167,210,184,43,163,202,247,35,116,140,140,87,16,113,17,15,184,10,33,133,72,65,156,127,46,67,7,17,103,8,115,110,90,87,131,96,208,119,202,236,218,153,82,156,73,109,122,249,67,91,189,16,192,160,153,72,62,82,65,164,73,11,126,214,8,212,205,144,60,225,204,235,50,149,168,165,77,218,5,101,232,82,120,125,80,171,16,182,151,24,196,55,169,173,156,230,94,97,13,173,179,152,211,120,107,145,207,83,168,68,6,43,212,156,10,58,3,5,66,203,101,176,32,157,196,136,161,98,121,38,149,72,216,100,159,223,255,70,129,77,215,48,21,246,183,142,37,8,98,231,14,177,155,244,43,247,49,140,127,209,52,3,25,196,161,18,36,175,172,1,44,244,234,86,188,17,15,13,137,117,174,17,138,138,9,228,215,43,46,129,97,24,9,26,61,248,83,202,38,232,141,117,218,214,164,0,166,124,178,30,192,159,25,136,101,225,32,144,219,120,242,221,220,247,13,198,253,152,178,66,190,189,139,173,156,238,21,162,236,231,33,213,89,11,98,159,167,217,76,87,209,46,185,94,43,206,13,92,199,210,26,5,16,59,230,150,193,27,64,47,73,49,21,1,246,141,246,103,235,217,158,105,251,4,39,193,23,187,109,47,55,252,217,174,222,219,194,148,169,242,5,80,5,214,230,38,81,211,225,107,13,184,246,208,231,51,172,139,68,114,54,90,206,193,235,254,201,104,186,79,28,172,140,253,119,6,141,185,211,90,107,252,111,57,155,17,253,88,25,254,118,242,91,18,169,147,229,110,73,94,47,70,123,174,219,106,167,23,44,47,123,136,9,215,211,7,123,206,221,156,7,149,85,14,11,103,158,207,51,166,72,147,212,242,12,106,174,200,42,183,222,76,231,23,128,219,218,157,41,100,140,67,94,89,166,29,207,116,251,53,221,146,234,244,140,141,145,217,74,19,42,141,144,141,206,183,205,158,119,254,22,255,42,118,91,195,45,196,33,137,107,135,42,122,187,57,21,180,143,194,185,105,157,203,57,48,157,20,61,203,55,222,137,34,215,165,227,138,216,181,105,3,244,228,172,145,97,210,55,169,181,206,23,45,120,39,161,62,196,238,122,125,204,144,114,235,57,43,213,105,222,92,35,208,12,58,167,118,112,220,59,58,106,117,170,29,255,224,164,122,216,233,182,170,237,147,206,97,181,93,175,215,123,245,218,113,175,123,248,213,52,57,42,18,160,50,193,236,148,254,7,147,20,188,227,205,7,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenGridPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c138a33a-67d1-4ac0-8b98-e9193e8cfacc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"OpenGridPageUserTask",
				Position = new Point(344, 51),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenGridPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("c138a33a-67d1-4ac0-8b98-e9193e8cfacc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"),
				Name = @"ShowMessageUserTask",
				Position = new Point(344, 247),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeShowMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a369e679-44d1-4bd8-91bb-a9cd19d8850a"),
				Name = "BPMSoft.UI.WebControls.Controls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("decb8af7-e9e5-4c08-9d0f-e4636f42f1b6"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ViewRecordAllChangesProcess(userConnection);
		}

		public override object Clone() {
			return new ViewRecordAllChangesProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438"));
		}

		#endregion

	}

	#endregion

	#region Class: ViewRecordAllChangesProcess

	/// <exclude/>
	public class ViewRecordAllChangesProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane52

		/// <exclude/>
		public class ProcessLane52 : ProcessLane
		{

			public ProcessLane52(UserConnection userConnection, ViewRecordAllChangesProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenGridPageUserTaskFlowElement

		/// <exclude/>
		public class OpenGridPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenGridPageUserTaskFlowElement(UserConnection userConnection, ViewRecordAllChangesProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenGridPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("dfb5dc20-5d4d-4a72-9cca-5bc19567a0a6");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ShowMessageUserTaskFlowElement

		/// <exclude/>
		public class ShowMessageUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ShowMessageUserTaskFlowElement(UserConnection userConnection, ViewRecordAllChangesProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowMessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("f0a7f14d-5b44-4058-b8de-5b4f23742f32");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ViewRecordAllChangesProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ViewRecordAllChangesProcess";
			SchemaUId = new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438");
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
				return new Guid("d7111807-3e7b-4e7a-8a98-2d77f3250438");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ViewRecordAllChangesProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ViewRecordAllChangesProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object Page {
			get;
			set;
		}

		public virtual bool ShowGrid {
			get;
			set;
		}

		public virtual Guid CurrentSchemaUId {
			get;
			set;
		}

		public virtual Guid ActiveTreeGridCurrentRowId {
			get;
			set;
		}

		public virtual bool FilterByChangeTracked {
			get;
			set;
		}

		private LocalizableString _recordNotSelectedMessage;
		public virtual LocalizableString RecordNotSelectedMessage {
			get {
				return _recordNotSelectedMessage ?? (_recordNotSelectedMessage = GetLocalizableString("d71118073e7b4e7a8a982d77f3250438",
						 "Parameters.RecordNotSelectedMessage.Value"));
			}
			set {
				_recordNotSelectedMessage = value;
			}
		}

		private ProcessLane52 _lane52;
		public ProcessLane52 Lane52 {
			get {
				return _lane52 ?? ((_lane52) = new ProcessLane52(UserConnection, this));
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
					SchemaElementUId = new Guid("d33f4bb1-0400-4d7d-8105-add7f1ad4217"),
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
					SchemaElementUId = new Guid("9b20b653-c814-4972-ac2b-6dc1cd08e8c3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _checkParametersScriptTask;
		public ProcessScriptTask CheckParametersScriptTask {
			get {
				return _checkParametersScriptTask ?? (_checkParametersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckParametersScriptTask",
					SchemaElementUId = new Guid("6f87a3e8-c275-4e15-92c5-6bcc7b918ad5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CheckParametersScriptTaskExecute,
				});
			}
		}

		private OpenGridPageUserTaskFlowElement _openGridPageUserTask;
		public OpenGridPageUserTaskFlowElement OpenGridPageUserTask {
			get {
				return _openGridPageUserTask ?? (_openGridPageUserTask = new OpenGridPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ShowMessageUserTaskFlowElement _showMessageUserTask;
		public ShowMessageUserTaskFlowElement ShowMessageUserTask {
			get {
				return _showMessageUserTask ?? (_showMessageUserTask = new ShowMessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessConditionalFlow _conditionalFlow21;
		public ProcessConditionalFlow ConditionalFlow21 {
			get {
				return _conditionalFlow21 ?? (_conditionalFlow21 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow21",
					SchemaElementUId = new Guid("c8a1f7ce-0534-44a2-8765-e9385fa15f3c"),
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
			FlowElements[CheckParametersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckParametersScriptTask };
			FlowElements[OpenGridPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenGridPageUserTask };
			FlowElements[ShowMessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CheckParametersScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "CheckParametersScriptTask":
						if (ConditionalFlow21ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenGridPageUserTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageUserTask", e.Context.SenderName));
						Log.ErrorFormat(DeadEndGatewayLogMessage, "CheckParametersScriptTask");
						break;
					case "OpenGridPageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "ShowMessageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow21ExpressionExecute() {
			bool result = Convert.ToBoolean(ShowGrid);
			Log.InfoFormat(ConditionalExpressionLogMessage, "CheckParametersScriptTask", "ConditionalFlow21", "ShowGrid", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (Page != null) {
				if (Page.GetType().IsSerializable ||
					Page.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Page", Page, null);
				}
			}
			if (!HasMapping("ShowGrid")) {
				writer.WriteValue("ShowGrid", ShowGrid, false);
			}
			if (!HasMapping("CurrentSchemaUId")) {
				writer.WriteValue("CurrentSchemaUId", CurrentSchemaUId, Guid.Empty);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("FilterByChangeTracked")) {
				writer.WriteValue("FilterByChangeTracked", FilterByChangeTracked, false);
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
			MetaPathParameterValues.Add("02ebc602-b614-42e3-92f4-72a724b1e92f", () => PageInstanceId);
			MetaPathParameterValues.Add("6c5bae4c-c34a-4bf9-80d0-61fbb7c91dd8", () => Page);
			MetaPathParameterValues.Add("3d7b9c01-8151-469d-8d94-64baf9bc6eb0", () => ShowGrid);
			MetaPathParameterValues.Add("71d8fb77-af88-4aaf-8f7d-769f4bbfe83f", () => CurrentSchemaUId);
			MetaPathParameterValues.Add("0bd6afe1-e067-4ce7-ab1c-ad0f7b4a84a0", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("23e517dd-2f43-4894-9151-37cd960f1d93", () => FilterByChangeTracked);
			MetaPathParameterValues.Add("17e3b620-2918-4660-8368-143d59c6da5c", () => RecordNotSelectedMessage);
			MetaPathParameterValues.Add("fed1b265-7a88-40d5-9aab-2f730d5b56e1", () => OpenGridPageUserTask.PageUId);
			MetaPathParameterValues.Add("b07ed27e-cda3-4074-bb4d-e220e23cc856", () => OpenGridPageUserTask.PageUrl);
			MetaPathParameterValues.Add("51420213-2e9e-4baf-9a53-f59359845b57", () => OpenGridPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("a01fbaa2-0025-46f5-8002-01973fdef582", () => OpenGridPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("946606ed-b8b0-4368-b3f2-829db7d972e1", () => OpenGridPageUserTask.PageParameters);
			MetaPathParameterValues.Add("a0bc2be7-315b-4f09-bd1b-f49aa523daae", () => OpenGridPageUserTask.Width);
			MetaPathParameterValues.Add("63b7efcf-04a2-4483-b578-8e3e4669da36", () => OpenGridPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("b593d800-eeab-40e3-89c0-19c5bc4a90f8", () => OpenGridPageUserTask.Height);
			MetaPathParameterValues.Add("3d9b4a78-0619-4888-91b8-c65860cb9772", () => OpenGridPageUserTask.Centered);
			MetaPathParameterValues.Add("e5937907-a215-4f63-903b-c6c0365e17b4", () => OpenGridPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("6c4ab842-4d6b-4775-8966-3f5c82086535", () => OpenGridPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("53b3ee84-6c68-48ae-92e2-d4fc720b1716", () => OpenGridPageUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("a382ed28-d3b2-4968-ae8b-07582b718e61", () => ShowMessageUserTask.Page);
			MetaPathParameterValues.Add("df40cb7e-cde7-4f58-9cc2-fb0379775b4d", () => ShowMessageUserTask.Icon);
			MetaPathParameterValues.Add("24d293f2-eef6-414a-ad10-6d56399173d5", () => ShowMessageUserTask.Buttons);
			MetaPathParameterValues.Add("236e33b0-2730-472b-9064-e3674474f378", () => ShowMessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("428ecd53-04d3-4bc2-adc4-140ea47da2f9", () => ShowMessageUserTask.MessageText);
			MetaPathParameterValues.Add("abcd1e76-3775-47bd-88ea-5ae7b18cf86e", () => ShowMessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("c675b7d1-5f91-47de-8a84-44dd3ba1ae8d", () => ShowMessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("0c518195-debc-47ba-a7ea-09ae20f853ee", () => ShowMessageUserTask.PageParameters);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "Page":
					if (!hasValueToRead) break;
					Page = reader.GetSerializableObjectValue();
				break;
				case "ShowGrid":
					if (!hasValueToRead) break;
					ShowGrid = reader.GetValue<System.Boolean>();
				break;
				case "CurrentSchemaUId":
					if (!hasValueToRead) break;
					CurrentSchemaUId = reader.GetValue<System.Guid>();
				break;
				case "ActiveTreeGridCurrentRowId":
					if (!hasValueToRead) break;
					ActiveTreeGridCurrentRowId = reader.GetValue<System.Guid>();
				break;
				case "FilterByChangeTracked":
					if (!hasValueToRead) break;
					FilterByChangeTracked = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckParametersScriptTaskExecute(ProcessExecutingContext context) {
			if (CurrentSchemaUId == Guid.Empty || ActiveTreeGridCurrentRowId == Guid.Empty) {
				ShowGrid = false;
				ShowMessageUserTask.ProcessInstanceId=InstanceUId;
				ShowMessageUserTask.Page = System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page;
				ShowMessageUserTask.MessageText = RecordNotSelectedMessage;
				ShowMessageUserTask.Icon = "WARNING";
				ShowMessageUserTask.Buttons = "OK";
			} else {
				var schema = UserConnection.EntitySchemaManager.GetInstanceByUId(CurrentSchemaUId);
				var entitySchemaId = schema.UId;
				ShowGrid = true;
				var parameters = new Dictionary<string,object>();
				parameters["schemaId"] = entitySchemaId;
				var defValuesIdStr = Guid.NewGuid().ToString();
				var targetSchema = schema.GetTrackChangesInDBSchema();
				var logEntitySchemaQuery = schema.IsTrackChangesInDB ? new EntitySchemaQuery(schema.GetTrackChangesInDBSchema()) : new EntitySchemaQuery(schema);	
				var logSchemaParentIdColumn = logEntitySchemaQuery.AddColumn("ChangeTracked");
				IEntitySchemaQueryFilterItem logRecordFilter;
				if (!FilterByChangeTracked) {
					logRecordFilter = logEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", ActiveTreeGridCurrentRowId);
				} else {
					logRecordFilter = logEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "ChangeTracked", ActiveTreeGridCurrentRowId);
				}
				logEntitySchemaQuery.Filters.Add(logRecordFilter);
				var logRecords = logEntitySchemaQuery.GetEntityCollection(UserConnection);
				if (logRecords.Count > 0) {
					var currentEntityId = logRecords[0].GetTypedColumnValue<Guid>(logSchemaParentIdColumn.ValueQueryAlias);
					parameters["entityId"] = currentEntityId;
				}
				UserConnection.SessionData[defValuesIdStr] = parameters;	
				OpenGridPageUserTask.PageParameters = new Dictionary<string, string> {
					{"defValuesId", defValuesIdStr}
				};
				OpenGridPageUserTask.OpenerInstanceId = InstanceUId;
				OpenGridPageUserTask.PageUId = new Guid("038F55AD-DC39-4DEA-B9D4-B777F708FE41");
			}
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
			var cloneItem = (ViewRecordAllChangesProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

