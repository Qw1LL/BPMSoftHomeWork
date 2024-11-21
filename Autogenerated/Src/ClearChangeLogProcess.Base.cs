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
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ClearChangeLogProcessSchema

	/// <exclude/>
	public class ClearChangeLogProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ClearChangeLogProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ClearChangeLogProcessSchema(ClearChangeLogProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ClearChangeLogProcess";
			UId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,82,201,110,194,48,16,61,7,137,127,176,124,178,37,20,245,94,113,129,64,133,132,186,1,173,212,170,7,147,12,96,145,216,116,236,64,81,213,127,239,56,27,162,141,18,107,150,204,155,55,111,220,239,29,202,117,174,83,118,212,232,75,149,179,163,213,25,27,231,160,112,110,183,83,139,19,227,181,63,139,187,146,194,80,217,139,116,7,133,154,101,3,150,40,15,75,93,0,91,195,198,34,72,246,221,239,69,11,200,33,245,204,171,117,14,247,170,128,198,31,50,3,39,86,59,98,229,0,199,214,24,178,181,53,50,78,180,243,218,80,66,198,99,155,151,133,17,60,148,114,25,79,209,22,130,191,156,22,103,215,244,53,175,22,247,238,160,210,144,126,221,1,130,224,171,89,70,206,204,77,62,105,4,17,26,61,149,128,231,71,133,132,226,1,197,53,115,41,153,114,13,151,91,162,92,58,109,182,76,36,163,201,23,164,165,183,200,178,117,103,14,217,53,219,120,98,92,137,144,140,46,33,33,235,209,91,160,163,34,132,80,249,71,132,184,6,133,103,80,25,145,186,52,105,235,163,211,78,231,32,50,140,195,47,29,108,20,57,143,1,185,195,35,236,58,68,122,153,84,121,193,73,32,62,160,174,239,55,31,241,210,46,170,164,144,3,198,105,141,92,134,41,233,169,136,17,21,31,0,130,76,73,229,252,219,71,165,122,215,172,147,121,188,83,102,11,75,84,233,30,178,7,195,101,141,26,69,36,253,28,156,19,245,242,226,139,238,225,118,188,89,3,51,179,177,129,234,17,208,135,216,210,174,124,42,154,107,67,36,219,155,196,101,75,181,166,217,42,38,154,240,79,56,195,65,31,189,253,222,47,245,5,10,79,192,2,0,0 };
			RealUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88798994-3a8b-4d20-854a-17028f8d0de8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b4246ed2-6dca-4604-a398-78215b1b7eb7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedShowMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f347d6a7-bc75-4d05-a5c6-3efae0852c5b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"NeedShowMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoggedEntitySchemasPresentParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("939c77c0-50c2-4e54-8262-b9916a10eaa0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"LoggedEntitySchemasPresent",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentSchemaUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88784240-8faa-4042-87d6-4b0cc3bc1a2a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"CurrentSchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateGridProcessUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5f56e336-ffea-4d08-814e-11d712a6b3e3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"GridProcessUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateClearingSuccessfulMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d8451c10-cf36-470a-b74e-1cc7774c2e43"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ClearingSuccessfulMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNoLoggedEntitySchemasMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4936d7ab-ede1-440e-a617-4f6b6df29680"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"NoLoggedEntitySchemasMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreatePageParameter());
			Parameters.Add(CreateNeedShowMessageParameter());
			Parameters.Add(CreateLoggedEntitySchemasPresentParameter());
			Parameters.Add(CreateCurrentSchemaUIdParameter());
			Parameters.Add(CreateGridProcessUIdParameter());
			Parameters.Add(CreateClearingSuccessfulMessageParameter());
			Parameters.Add(CreateNoLoggedEntitySchemasMessageParameter());
		}

		protected virtual void InitializeOpenSettingsPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("947ae31b-cd23-430a-bb8f-7241b4720103"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("9bde68e7-06a7-4751-9781-06b3754b48b7"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("49358ca4-34c7-47b5-a5aa-b5b67550d216"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("34038892-d974-4aba-8314-f1dd674ad0fe"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("8df2aea7-612c-4bad-84e9-e30ea7f09e8f"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("5cade72b-85a0-49fe-816c-1b22e2dc0d8a"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("4bb355ef-5767-4f36-bef7-76b3d4588aa7"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("f6b3d22f-3018-4520-b406-1cf86fccae76"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("91b530ef-ca1d-4eff-8d4f-3fefeb154b34"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("af84ebdf-f659-46b1-87f8-a4dcbe9855ca"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("828fea8b-d25c-476a-90a0-7236d248165c"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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
				UId = new Guid("618752b8-186d-44cf-8461-9fe563281840"),
				ContainerUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
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

		protected virtual void InitializeShowNoTrackedMessageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b1f8890e-49f8-483e-8367-ca7b2e363461"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("43ffb68a-6415-4275-82e2-25b8642ab04f"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("4138a7e3-d8a8-4c07-b0fb-dd2eca81d036"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("7c854a73-1b08-403b-8bd1-55a745b98e2d"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("c997df75-4855-4ae6-817a-bcb2aeb43b42"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("81ed9542-b4ee-4d60-9fd7-2b4018da7bba"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("e03fddf1-410e-4633-b63a-8e999b3af86b"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				UId = new Guid("c99bed8c-3a2a-43b0-98b2-ff8eefbb783a"),
				ContainerUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
		}

		protected virtual void InitializeShowClearedMessageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("91f526be-f71a-451c-877a-4a7e236e3d67"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("27d1ec03-d4cb-4a35-9477-ad537ff7e28e"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("9b66906c-369a-4fc8-bb76-d789c5c13b03"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("21615c4d-7cd2-4de7-922d-d8653ae3eda3"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("4eb22089-e449-43fe-a117-92ca5b74c36a"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("4f87cb10-e46e-4dec-bcd6-3008131751ae"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("d82c9d90-c135-401c-b232-9f50aea2ba7f"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				UId = new Guid("8a4dab2c-626e-4002-91e8-e38f45505adf"),
				ContainerUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet42 = CreateLaneSet42LaneSet();
			LaneSets.Add(schemaLaneSet42);
			ProcessSchemaLane schemaLane124 = CreateLane124Lane();
			schemaLaneSet42.Lanes.Add(schemaLane124);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask prepareparametersscripttask = CreatePrepareParametersScriptTaskScriptTask();
			FlowElements.Add(prepareparametersscripttask);
			ProcessSchemaUserTask opensettingspageusertask = CreateOpenSettingsPageUserTaskUserTask();
			FlowElements.Add(opensettingspageusertask);
			ProcessSchemaUserTask shownotrackedmessageusertask = CreateShowNoTrackedMessageUserTaskUserTask();
			FlowElements.Add(shownotrackedmessageusertask);
			ProcessSchemaIntermediateCatchMessageEvent settingswindowclosedintermediatecatchmessageevent1 = CreateSettingsWindowClosedIntermediateCatchMessageEvent1IntermediateCatchMessageEvent();
			FlowElements.Add(settingswindowclosedintermediatecatchmessageevent1);
			ProcessSchemaScriptTask clearifnecessaryscripttask = CreateClearIfNecessaryScriptTaskScriptTask();
			FlowElements.Add(clearifnecessaryscripttask);
			ProcessSchemaUserTask showclearedmessageusertask = CreateShowClearedMessageUserTaskUserTask();
			FlowElements.Add(showclearedmessageusertask);
			ProcessSchemaExclusiveGateway needshowmessageexclusivegateway = CreateNeedShowMessageExclusiveGatewayExclusiveGateway();
			FlowElements.Add(needshowmessageexclusivegateway);
			FlowElements.Add(CreateSequenceFlow411SequenceFlow());
			FlowElements.Add(CreateSequenceFlow412SequenceFlow());
			FlowElements.Add(CreateSequenceFlow413SequenceFlow());
			FlowElements.Add(CreateLoggedEntitySchemasPresentConditionalFlowConditionalFlow());
			FlowElements.Add(CreateSequenceFlow415SequenceFlow());
			FlowElements.Add(CreateSequenceFlow416SequenceFlow());
			FlowElements.Add(CreateSequenceFlow419SequenceFlow());
			FlowElements.Add(CreateNeedShowMessageConditionalFlowConditionalFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow411SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow411",
				UId = new Guid("71002e41-aea3-4652-828f-ce1a68353a97"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(406, 147),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2167cf96-f197-444f-971b-a5a77fc7ff57"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow412SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow412",
				UId = new Guid("8d2ca9a5-aead-447d-b403-f4026a4974a0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(295, 98),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow413SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow413",
				UId = new Guid("5f756cee-0c22-4f0d-929e-c43ca191a136"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(490, 220),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateLoggedEntitySchemasPresentConditionalFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "LoggedEntitySchemasPresentConditionalFlow",
				UId = new Guid("7f103fb4-92a5-4d9e-a378-f3cfc7d50992"),
				ConditionExpression = @"!LoggedEntitySchemasPresent",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(216, 166),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow415SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow415",
				UId = new Guid("339d6c0b-6049-4bff-a09e-ad5f37249a0c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(371, 173),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow416SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow416",
				UId = new Guid("69dc689f-11c1-4c2f-87ee-6b3d3fa3529a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(442, 232),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow419SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow419",
				UId = new Guid("d02022bf-f1bb-4e00-885e-e25323ef8b8d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(648, 159),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateNeedShowMessageConditionalFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "NeedShowMessageConditionalFlow",
				UId = new Guid("7db831e0-9d0f-40b6-b9ae-58be8fe89325"),
				ConditionExpression = @"NeedShowMessage",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(530, 156),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow1",
				UId = new Guid("4ac801fc-2d36-4b71-999b-d7f579866954"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(645, 222),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("578aca5d-d441-484a-980e-4efa94bde409"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				CurveCenterPosition = new Point(598, 194),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet42LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet42 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a0cf982f-1416-4d32-b099-0591539c3e11"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"LaneSet42",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet42;
		}

		protected virtual ProcessSchemaLane CreateLane124Lane() {
			ProcessSchemaLane schemaLane124 = new ProcessSchemaLane(this) {
				UId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a0cf982f-1416-4d32-b099-0591539c3e11"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"Lane124",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane124;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("2167cf96-f197-444f-971b-a5a77fc7ff57"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"Start1",
				Position = new Point(36, 79),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"End1",
				Position = new Point(680, 212),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareParametersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"PrepareParametersScriptTask",
				Position = new Point(148, 65),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,86,93,111,218,48,20,125,6,137,255,96,101,47,65,130,180,116,165,180,98,84,130,20,90,180,66,89,161,229,97,218,131,27,46,144,53,196,153,237,148,161,117,255,125,215,142,249,12,148,61,17,219,231,158,251,117,238,21,111,148,147,128,77,38,48,106,134,210,151,139,190,55,133,25,125,106,143,4,169,145,16,230,228,222,23,242,203,109,236,143,174,237,124,53,151,125,219,193,187,52,146,62,11,183,208,66,114,63,156,172,241,176,193,220,161,33,157,0,71,248,147,0,238,178,48,4,79,17,56,183,32,183,16,182,181,25,144,185,180,242,132,10,178,231,1,61,157,156,184,143,159,74,149,179,74,233,52,151,77,59,254,22,3,95,152,40,155,187,247,246,158,16,11,196,122,158,223,179,201,195,203,79,12,81,88,203,108,4,11,98,21,113,203,15,36,240,90,202,135,227,114,160,18,146,231,161,47,167,61,202,233,12,240,32,236,228,210,101,179,136,114,95,176,112,176,136,192,105,254,138,105,80,176,250,11,49,100,252,85,68,212,3,171,176,83,157,213,139,211,30,169,64,210,249,97,203,92,140,108,22,98,142,233,152,234,35,243,106,91,8,92,229,2,155,61,252,63,115,3,214,20,185,108,26,154,164,40,148,137,189,93,42,101,97,68,195,130,32,73,44,241,229,131,210,79,154,11,53,177,107,96,111,23,70,113,142,25,22,220,155,218,9,212,208,16,127,205,157,39,127,114,217,204,126,149,235,56,19,19,229,78,53,196,164,250,76,131,24,140,242,247,22,218,233,98,91,243,42,130,204,190,137,56,198,188,156,146,61,61,88,51,255,205,101,253,177,125,32,116,151,197,161,36,181,26,57,37,239,239,196,141,57,71,174,213,187,122,80,209,59,205,89,36,23,73,13,238,83,68,162,199,65,160,25,214,127,76,3,1,213,76,6,113,253,41,155,119,217,128,83,239,21,70,29,16,2,7,66,21,126,64,197,171,211,227,204,195,171,118,40,36,13,61,104,143,106,203,79,244,90,61,110,142,7,244,134,114,151,48,115,134,240,226,220,73,25,97,75,37,252,150,142,201,98,249,123,71,195,81,128,235,2,167,190,209,235,244,217,88,58,79,109,101,164,240,156,5,66,211,85,143,249,52,231,1,122,64,215,93,182,167,14,6,114,148,170,237,161,106,107,196,26,214,31,187,237,238,173,117,212,160,17,75,153,44,72,235,225,171,134,115,144,49,15,137,228,49,36,45,254,176,45,6,118,227,107,193,83,190,48,202,41,48,189,152,174,73,180,218,47,102,189,29,132,234,141,188,134,127,183,210,142,81,87,214,15,228,57,32,185,1,171,115,78,23,31,18,45,7,32,197,179,154,140,67,44,166,233,219,241,104,154,93,113,239,24,118,1,103,43,0,202,53,56,17,242,1,68,61,8,142,131,26,160,150,138,198,221,224,46,31,248,51,112,186,108,174,70,186,131,194,155,10,187,88,82,193,239,108,233,62,182,30,127,209,132,98,50,138,200,157,210,112,2,88,157,62,72,137,157,16,235,222,104,246,181,119,100,123,136,32,92,226,122,155,18,82,15,192,215,3,135,134,155,35,247,129,165,62,104,3,37,12,181,14,108,235,178,213,106,52,202,245,179,98,229,202,109,20,207,221,82,165,88,119,43,141,98,235,188,124,81,190,188,186,248,124,90,118,245,122,63,200,234,6,76,128,209,185,210,181,78,21,147,212,247,74,226,7,45,241,35,73,230,17,38,248,87,1,120,223,227,126,180,33,243,205,217,248,7,176,229,116,112,156,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenSettingsPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"OpenSettingsPageUserTask",
				Position = new Point(302, 65),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenSettingsPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowNoTrackedMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ShowNoTrackedMessageUserTask",
				Position = new Point(149, 200),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeShowNoTrackedMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchMessageEvent CreateSettingsWindowClosedIntermediateCatchMessageEvent1IntermediateCatchMessageEvent() {
			ProcessSchemaIntermediateCatchMessageEvent schemaCatchMessageEvent = new ProcessSchemaIntermediateCatchMessageEvent(this) {
				UId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("3cb9d737-779e-4085-ab4b-db590853e266"),
				Message = @"ClearLogClose",
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"SettingsWindowClosedIntermediateCatchMessageEvent1",
				Position = new Point(323, 198),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaCatchMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateClearIfNecessaryScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ClearIfNecessaryScriptTask",
				Position = new Point(442, 184),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,193,110,226,48,16,61,167,82,255,193,202,201,72,40,63,208,82,169,80,74,163,109,161,218,4,245,128,56,152,120,8,222,13,54,178,39,101,209,106,255,125,199,198,217,138,101,183,28,34,103,198,239,189,121,51,158,41,128,44,54,102,255,2,206,137,26,216,128,173,69,227,224,230,250,234,65,85,168,140,22,246,112,235,208,42,93,247,205,234,27,84,120,199,118,194,138,45,32,88,55,224,255,69,245,230,14,236,200,104,13,1,144,21,84,128,206,7,129,98,145,142,26,16,118,180,17,186,134,103,83,23,128,72,76,247,161,149,46,201,128,90,115,190,50,166,233,125,212,91,164,83,242,27,216,233,178,199,126,94,95,37,207,202,225,237,164,85,242,142,185,106,3,91,225,74,19,0,36,60,208,176,103,31,0,222,187,73,136,241,185,238,125,211,116,210,201,153,96,118,47,229,87,239,154,115,175,184,88,158,104,16,160,6,57,214,168,240,80,4,106,46,29,137,81,47,201,47,250,128,6,251,137,240,81,243,68,113,212,90,11,26,79,37,59,69,223,11,141,19,74,181,5,182,130,181,177,254,249,120,151,250,119,123,195,128,163,249,38,158,238,255,69,181,9,133,25,156,84,97,74,159,15,52,206,165,11,31,141,61,90,227,167,220,126,180,243,167,243,119,97,217,206,154,138,118,128,44,254,181,25,249,235,241,102,172,107,165,33,155,0,198,196,240,48,207,37,159,88,37,99,130,194,172,52,69,216,51,222,11,234,81,53,43,55,214,236,199,239,228,131,119,169,92,83,239,90,52,84,10,225,7,246,89,58,11,171,121,220,59,153,6,254,249,254,163,109,253,250,39,62,27,26,5,25,47,189,239,82,184,239,89,180,147,107,135,66,87,64,195,26,176,46,32,143,151,216,34,212,41,14,14,97,155,189,193,42,123,66,220,69,151,89,124,242,238,124,18,90,54,96,153,112,108,248,250,82,152,53,102,243,220,147,60,222,154,198,5,185,11,21,99,92,146,62,21,14,32,154,96,209,86,190,139,117,219,196,251,11,42,121,101,52,209,211,124,250,56,75,47,96,135,45,162,209,254,177,211,217,23,15,166,45,176,128,173,213,221,124,127,3,185,88,160,167,121,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowClearedMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"ShowClearedMessageUserTask",
				Position = new Point(464, 67),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeShowClearedMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateNeedShowMessageExclusiveGatewayExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b6ee5a9e-7eac-4a88-8074-6ac2ba479369"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"),
				Name = @"NeedShowMessageExclusiveGateway",
				Position = new Point(568, 135),
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

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6c62ab5d-9e27-4000-8ca4-81181c25c776"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("df193006-9f76-43bc-ab1a-6aec4e5ce5ad"),
				Name = "BPMSoft.UI.WebControls.Controls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("22b30d13-e760-4258-9b8a-fc8c307e26b7"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ClearChangeLogProcess(userConnection);
		}

		public override object Clone() {
			return new ClearChangeLogProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc"));
		}

		#endregion

	}

	#endregion

	#region Class: ClearChangeLogProcess

	/// <exclude/>
	public class ClearChangeLogProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane124

		/// <exclude/>
		public class ProcessLane124 : ProcessLane
		{

			public ProcessLane124(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenSettingsPageUserTaskFlowElement

		/// <exclude/>
		public class OpenSettingsPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenSettingsPageUserTaskFlowElement(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenSettingsPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("e7fb1ce8-d9a7-4c82-b432-c1907a9dd517");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ShowNoTrackedMessageUserTaskFlowElement

		/// <exclude/>
		public class ShowNoTrackedMessageUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ShowNoTrackedMessageUserTaskFlowElement(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowNoTrackedMessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("de7acea9-fd3f-47a2-ba11-fff451705433");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ShowClearedMessageUserTaskFlowElement

		/// <exclude/>
		public class ShowClearedMessageUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ShowClearedMessageUserTaskFlowElement(UserConnection userConnection, ClearChangeLogProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowClearedMessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("52564b96-a184-4562-b0fc-98b0c83b3909");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ClearChangeLogProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ClearChangeLogProcess";
			SchemaUId = new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
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
				return new Guid("3977290d-f2e7-4b06-8ae3-6fed38f3facc");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ClearChangeLogProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ClearChangeLogProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual bool NeedShowMessage {
			get;
			set;
		}

		public virtual bool LoggedEntitySchemasPresent {
			get;
			set;
		}

		public virtual Guid CurrentSchemaUId {
			get;
			set;
		}

		public virtual string GridProcessUId {
			get;
			set;
		}

		private LocalizableString _clearingSuccessfulMessage;
		public virtual LocalizableString ClearingSuccessfulMessage {
			get {
				return _clearingSuccessfulMessage ?? (_clearingSuccessfulMessage = GetLocalizableString("3977290df2e74b068ae36fed38f3facc",
						 "Parameters.ClearingSuccessfulMessage.Value"));
			}
			set {
				_clearingSuccessfulMessage = value;
			}
		}

		private LocalizableString _noLoggedEntitySchemasMessage;
		public virtual LocalizableString NoLoggedEntitySchemasMessage {
			get {
				return _noLoggedEntitySchemasMessage ?? (_noLoggedEntitySchemasMessage = GetLocalizableString("3977290df2e74b068ae36fed38f3facc",
						 "Parameters.NoLoggedEntitySchemasMessage.Value"));
			}
			set {
				_noLoggedEntitySchemasMessage = value;
			}
		}

		private ProcessLane124 _lane124;
		public ProcessLane124 Lane124 {
			get {
				return _lane124 ?? ((_lane124) = new ProcessLane124(UserConnection, this));
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
					SchemaElementUId = new Guid("2167cf96-f197-444f-971b-a5a77fc7ff57"),
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
					SchemaElementUId = new Guid("1de13ccc-8965-4159-818b-5449cac1fc0b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareParametersScriptTask;
		public ProcessScriptTask PrepareParametersScriptTask {
			get {
				return _prepareParametersScriptTask ?? (_prepareParametersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareParametersScriptTask",
					SchemaElementUId = new Guid("222ace1f-663b-41f4-b450-4d244b45013d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareParametersScriptTaskExecute,
				});
			}
		}

		private OpenSettingsPageUserTaskFlowElement _openSettingsPageUserTask;
		public OpenSettingsPageUserTaskFlowElement OpenSettingsPageUserTask {
			get {
				return _openSettingsPageUserTask ?? (_openSettingsPageUserTask = new OpenSettingsPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ShowNoTrackedMessageUserTaskFlowElement _showNoTrackedMessageUserTask;
		public ShowNoTrackedMessageUserTaskFlowElement ShowNoTrackedMessageUserTask {
			get {
				return _showNoTrackedMessageUserTask ?? (_showNoTrackedMessageUserTask = new ShowNoTrackedMessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessIntermediateCatchMessageEvent _settingsWindowClosedIntermediateCatchMessageEvent1;
		public ProcessIntermediateCatchMessageEvent SettingsWindowClosedIntermediateCatchMessageEvent1 {
			get {
				return _settingsWindowClosedIntermediateCatchMessageEvent1 ?? (_settingsWindowClosedIntermediateCatchMessageEvent1 = new ProcessIntermediateCatchMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateCatchMessageEvent",
					Name = "SettingsWindowClosedIntermediateCatchMessageEvent1",
					SchemaElementUId = new Guid("b00da5b8-c91d-499d-99fe-93e3b0516cfb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Message = "ClearLogClose",
				});
			}
		}

		private ProcessScriptTask _clearIfNecessaryScriptTask;
		public ProcessScriptTask ClearIfNecessaryScriptTask {
			get {
				return _clearIfNecessaryScriptTask ?? (_clearIfNecessaryScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearIfNecessaryScriptTask",
					SchemaElementUId = new Guid("baa0dd0f-5632-4baa-891d-5847954a2b64"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ClearIfNecessaryScriptTaskExecute,
				});
			}
		}

		private ShowClearedMessageUserTaskFlowElement _showClearedMessageUserTask;
		public ShowClearedMessageUserTaskFlowElement ShowClearedMessageUserTask {
			get {
				return _showClearedMessageUserTask ?? (_showClearedMessageUserTask = new ShowClearedMessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _needShowMessageExclusiveGateway;
		public ProcessExclusiveGateway NeedShowMessageExclusiveGateway {
			get {
				return _needShowMessageExclusiveGateway ?? (_needShowMessageExclusiveGateway = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "NeedShowMessageExclusiveGateway",
					SchemaElementUId = new Guid("9da7d414-98f0-403e-9bca-03052a544554"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.NeedShowMessageExclusiveGateway.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessConditionalFlow _loggedEntitySchemasPresentConditionalFlow;
		public ProcessConditionalFlow LoggedEntitySchemasPresentConditionalFlow {
			get {
				return _loggedEntitySchemasPresentConditionalFlow ?? (_loggedEntitySchemasPresentConditionalFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "LoggedEntitySchemasPresentConditionalFlow",
					SchemaElementUId = new Guid("7f103fb4-92a5-4d9e-a378-f3cfc7d50992"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _needShowMessageConditionalFlow;
		public ProcessConditionalFlow NeedShowMessageConditionalFlow {
			get {
				return _needShowMessageConditionalFlow ?? (_needShowMessageConditionalFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "NeedShowMessageConditionalFlow",
					SchemaElementUId = new Guid("7db831e0-9d0f-40b6-b9ae-58be8fe89325"),
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
			FlowElements[PrepareParametersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareParametersScriptTask };
			FlowElements[OpenSettingsPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenSettingsPageUserTask };
			FlowElements[ShowNoTrackedMessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowNoTrackedMessageUserTask };
			FlowElements[SettingsWindowClosedIntermediateCatchMessageEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { SettingsWindowClosedIntermediateCatchMessageEvent1 };
			FlowElements[ClearIfNecessaryScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearIfNecessaryScriptTask };
			FlowElements[ShowClearedMessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowClearedMessageUserTask };
			FlowElements[NeedShowMessageExclusiveGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { NeedShowMessageExclusiveGateway };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareParametersScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "PrepareParametersScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenSettingsPageUserTask", e.Context.SenderName));
						if (LoggedEntitySchemasPresentConditionalFlowExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowNoTrackedMessageUserTask", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "PrepareParametersScriptTask");
						break;
					case "OpenSettingsPageUserTask":
						ActivatedEventElements.Add("SettingsWindowClosedIntermediateCatchMessageEvent1");
						break;
					case "ShowNoTrackedMessageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "SettingsWindowClosedIntermediateCatchMessageEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ClearIfNecessaryScriptTask", e.Context.SenderName));
						break;
					case "ClearIfNecessaryScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("NeedShowMessageExclusiveGateway", e.Context.SenderName));
						break;
					case "ShowClearedMessageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "NeedShowMessageExclusiveGateway":
						if (NeedShowMessageConditionalFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowClearedMessageUserTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private bool LoggedEntitySchemasPresentConditionalFlowExpressionExecute() {
			bool result = Convert.ToBoolean(!LoggedEntitySchemasPresent);
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareParametersScriptTask", "LoggedEntitySchemasPresentConditionalFlow", "!LoggedEntitySchemasPresent", result);
			return result;
		}

		private bool NeedShowMessageConditionalFlowExpressionExecute() {
			bool result = Convert.ToBoolean(NeedShowMessage);
			Log.InfoFormat(ConditionalExpressionLogMessage, "NeedShowMessageExclusiveGateway", "NeedShowMessageConditionalFlow", "NeedShowMessage", result);
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
			if (!HasMapping("NeedShowMessage")) {
				writer.WriteValue("NeedShowMessage", NeedShowMessage, false);
			}
			if (!HasMapping("LoggedEntitySchemasPresent")) {
				writer.WriteValue("LoggedEntitySchemasPresent", LoggedEntitySchemasPresent, false);
			}
			if (!HasMapping("CurrentSchemaUId")) {
				writer.WriteValue("CurrentSchemaUId", CurrentSchemaUId, Guid.Empty);
			}
			if (!HasMapping("GridProcessUId")) {
				writer.WriteValue("GridProcessUId", GridProcessUId, null);
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
			MetaPathParameterValues.Add("88798994-3a8b-4d20-854a-17028f8d0de8", () => PageInstanceId);
			MetaPathParameterValues.Add("b4246ed2-6dca-4604-a398-78215b1b7eb7", () => Page);
			MetaPathParameterValues.Add("f347d6a7-bc75-4d05-a5c6-3efae0852c5b", () => NeedShowMessage);
			MetaPathParameterValues.Add("939c77c0-50c2-4e54-8262-b9916a10eaa0", () => LoggedEntitySchemasPresent);
			MetaPathParameterValues.Add("88784240-8faa-4042-87d6-4b0cc3bc1a2a", () => CurrentSchemaUId);
			MetaPathParameterValues.Add("5f56e336-ffea-4d08-814e-11d712a6b3e3", () => GridProcessUId);
			MetaPathParameterValues.Add("d8451c10-cf36-470a-b74e-1cc7774c2e43", () => ClearingSuccessfulMessage);
			MetaPathParameterValues.Add("4936d7ab-ede1-440e-a617-4f6b6df29680", () => NoLoggedEntitySchemasMessage);
			MetaPathParameterValues.Add("947ae31b-cd23-430a-bb8f-7241b4720103", () => OpenSettingsPageUserTask.PageUId);
			MetaPathParameterValues.Add("9bde68e7-06a7-4751-9781-06b3754b48b7", () => OpenSettingsPageUserTask.PageUrl);
			MetaPathParameterValues.Add("49358ca4-34c7-47b5-a5aa-b5b67550d216", () => OpenSettingsPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("34038892-d974-4aba-8314-f1dd674ad0fe", () => OpenSettingsPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("8df2aea7-612c-4bad-84e9-e30ea7f09e8f", () => OpenSettingsPageUserTask.PageParameters);
			MetaPathParameterValues.Add("5cade72b-85a0-49fe-816c-1b22e2dc0d8a", () => OpenSettingsPageUserTask.Width);
			MetaPathParameterValues.Add("4bb355ef-5767-4f36-bef7-76b3d4588aa7", () => OpenSettingsPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("f6b3d22f-3018-4520-b406-1cf86fccae76", () => OpenSettingsPageUserTask.Height);
			MetaPathParameterValues.Add("91b530ef-ca1d-4eff-8d4f-3fefeb154b34", () => OpenSettingsPageUserTask.Centered);
			MetaPathParameterValues.Add("af84ebdf-f659-46b1-87f8-a4dcbe9855ca", () => OpenSettingsPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("828fea8b-d25c-476a-90a0-7236d248165c", () => OpenSettingsPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("618752b8-186d-44cf-8461-9fe563281840", () => OpenSettingsPageUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("b1f8890e-49f8-483e-8367-ca7b2e363461", () => ShowNoTrackedMessageUserTask.Page);
			MetaPathParameterValues.Add("43ffb68a-6415-4275-82e2-25b8642ab04f", () => ShowNoTrackedMessageUserTask.Icon);
			MetaPathParameterValues.Add("4138a7e3-d8a8-4c07-b0fb-dd2eca81d036", () => ShowNoTrackedMessageUserTask.Buttons);
			MetaPathParameterValues.Add("7c854a73-1b08-403b-8bd1-55a745b98e2d", () => ShowNoTrackedMessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("c997df75-4855-4ae6-817a-bcb2aeb43b42", () => ShowNoTrackedMessageUserTask.MessageText);
			MetaPathParameterValues.Add("81ed9542-b4ee-4d60-9fd7-2b4018da7bba", () => ShowNoTrackedMessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("e03fddf1-410e-4633-b63a-8e999b3af86b", () => ShowNoTrackedMessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("c99bed8c-3a2a-43b0-98b2-ff8eefbb783a", () => ShowNoTrackedMessageUserTask.PageParameters);
			MetaPathParameterValues.Add("91f526be-f71a-451c-877a-4a7e236e3d67", () => ShowClearedMessageUserTask.Page);
			MetaPathParameterValues.Add("27d1ec03-d4cb-4a35-9477-ad537ff7e28e", () => ShowClearedMessageUserTask.Icon);
			MetaPathParameterValues.Add("9b66906c-369a-4fc8-bb76-d789c5c13b03", () => ShowClearedMessageUserTask.Buttons);
			MetaPathParameterValues.Add("21615c4d-7cd2-4de7-922d-d8653ae3eda3", () => ShowClearedMessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("4eb22089-e449-43fe-a117-92ca5b74c36a", () => ShowClearedMessageUserTask.MessageText);
			MetaPathParameterValues.Add("4f87cb10-e46e-4dec-bcd6-3008131751ae", () => ShowClearedMessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("d82c9d90-c135-401c-b232-9f50aea2ba7f", () => ShowClearedMessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("8a4dab2c-626e-4002-91e8-e38f45505adf", () => ShowClearedMessageUserTask.PageParameters);
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
				case "NeedShowMessage":
					if (!hasValueToRead) break;
					NeedShowMessage = reader.GetValue<System.Boolean>();
				break;
				case "LoggedEntitySchemasPresent":
					if (!hasValueToRead) break;
					LoggedEntitySchemasPresent = reader.GetValue<System.Boolean>();
				break;
				case "CurrentSchemaUId":
					if (!hasValueToRead) break;
					CurrentSchemaUId = reader.GetValue<System.Guid>();
				break;
				case "GridProcessUId":
					if (!hasValueToRead) break;
					GridProcessUId = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareParametersScriptTaskExecute(ProcessExecutingContext context) {
			var loggedEntitySchemaUIds = new List<Guid>();
			var loggedEntityCaptions = new List<string>();
			var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			//CR#172710
			
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "VwLogObjects");
			var solutionFilter=entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,"SysWorkspace",UserConnection.Workspace.Id);
			
			var entitySchemaUIdColumn = entitySchemaQuery.AddColumn("UId");
			var entityCaptionColumn = entitySchemaQuery.AddColumn("Caption");
			
			entitySchemaQuery.Filters.Add(solutionFilter);
			EntityCollection entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			foreach(Entity entity in entities) {
				loggedEntitySchemaUIds.Add(entity.GetTypedColumnValue<Guid>(entitySchemaUIdColumn.Name));
				loggedEntityCaptions.Add(entity.GetTypedColumnValue<string>(entityCaptionColumn.Name));
			}
			if(loggedEntitySchemaUIds.Count == 0 || CurrentSchemaUId == Guid.Empty) {
				LoggedEntitySchemasPresent = false;		
				ShowNoTrackedMessageUserTask.ProcessInstanceId=InstanceUId;	
				ShowNoTrackedMessageUserTask.Page = System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page;
				ShowNoTrackedMessageUserTask.MessageText = NoLoggedEntitySchemasMessage;
				ShowNoTrackedMessageUserTask.Icon = "WARNING";
				ShowNoTrackedMessageUserTask.Buttons = "OK";
				return true;
			}
			LoggedEntitySchemasPresent = true;
			Dictionary<string,object> parameters = new Dictionary<string,object>();
			parameters["LoggedEntitySchemaIds"] = loggedEntitySchemaUIds.ToArray();
			parameters["LoggedEntityCaptions"] = loggedEntityCaptions.ToArray();
			parameters["CurrentEntitySchemaId"] = CurrentSchemaUId;
			parameters["NeedClear"] = false;
			parameters["NeedClearAll"] = false;
			parameters["NeedClearBefore"] = DateTime.Now.AddMonths(-1);
			UserConnection.SessionData["ClearChangeLogSettingsDictionary"] = parameters;
			OpenSettingsPageUserTask.OpenerInstanceId = InstanceUId;
			OpenSettingsPageUserTask.PageUId = new Guid("8FFBB5A2-79CB-4C17-AC7B-F4565896305C");
			OpenSettingsPageUserTask.CloseMessage = "ClearLogClose";
			OpenSettingsPageUserTask.UseOpenerRegisterScript = true;
			return true;
		}

		public virtual bool ClearIfNecessaryScriptTaskExecute(ProcessExecutingContext context) {
			NeedShowMessage = false;
			Dictionary<string,object> parameters=(Dictionary<string,object>)UserConnection.SessionData["ClearChangeLogSettingsDictionary"];
			if((bool)parameters["NeedClear"]) {
				List<Guid> schemasToClearLog=new List<Guid>();	
				if((bool)parameters["NeedClearAll"]) {
					schemasToClearLog.AddRange((Guid[])parameters["LoggedEntitySchemaIds"]);
				}
				else {
					schemasToClearLog.Add((Guid)parameters["CurrentEntitySchemaId"]);
				}	
				DateTime before = (DateTime)parameters["NeedClearBefore"];		
				foreach(Guid entitySchemaId in schemasToClearLog) {
					ClearLogForEntity(entitySchemaId, before);
				}
				var process = UserConnection.IProcessEngine.GetProcessByUId(GridProcessUId.ToString());
				process.ThrowEvent(process.InternalContext, "ObjectChanged");
				NeedShowMessage = true;
				ShowClearedMessageUserTask.ProcessInstanceId = InstanceUId;
				ShowClearedMessageUserTask.Page = System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page;
				ShowClearedMessageUserTask.MessageText = ClearingSuccessfulMessage;
				ShowClearedMessageUserTask.Icon = "INFO";
				ShowClearedMessageUserTask.Buttons = "OK";
			}
			return true;
		}

			
			public virtual void ClearLogForEntity(Guid entitySchemaId, DateTime before) {
				Select tableNameSelect = new Select(UserConnection).Distinct().Column("Name").From("VwSysSchemaInWorkspace").Where("UId").IsEqual(new QueryParameter(entitySchemaId)) as Select;
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (var dr = tableNameSelect.ExecuteReader(dbExecutor)) {
						while(dr.Read()) {
							string tableName = string.Concat("Sys", dr[0].ToString(), "Log");
							var delete = new Delete(UserConnection).From(tableName).Where("ChangeTrackedOn")
									.IsLess(Column.Parameter(TimeZoneInfo.ConvertTimeToUtc(before), "DateTime"));
							delete.Execute();
						}
					}
				}
			}
			

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ClearLogClose":
					if (ActivatedEventElements.Remove("SettingsWindowClosedIntermediateCatchMessageEvent1")) {
						context.QueueTasksV2.Enqueue(new ProcessQueueElement("SettingsWindowClosedIntermediateCatchMessageEvent1", "SettingsWindowClosedIntermediateCatchMessageEvent1"));
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
			var cloneItem = (ClearChangeLogProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

