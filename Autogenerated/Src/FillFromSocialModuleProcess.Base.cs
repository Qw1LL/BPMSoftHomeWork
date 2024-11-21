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

	#region Class: FillFromSocialModuleProcessSchema

	/// <exclude/>
	public class FillFromSocialModuleProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FillFromSocialModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FillFromSocialModuleProcessSchema(FillFromSocialModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FillFromSocialModuleProcess";
			UId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd");
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,145,223,74,195,48,20,198,175,29,236,29,98,175,90,24,125,1,241,166,211,142,130,147,225,212,27,241,226,44,61,221,194,210,19,73,79,54,138,236,221,77,255,140,173,67,6,130,129,64,206,151,228,247,157,124,25,143,190,220,74,43,41,118,202,178,3,45,146,197,124,105,10,142,167,134,10,181,118,22,88,25,106,42,6,201,98,134,220,47,195,153,83,185,144,93,145,229,145,248,30,143,110,118,96,143,210,82,110,176,4,113,47,222,42,180,254,14,161,108,73,143,196,138,235,110,119,14,4,107,180,177,167,102,84,49,144,196,164,126,134,18,195,160,119,9,162,187,33,214,3,7,6,241,212,34,48,118,212,112,232,21,9,168,174,191,167,129,175,140,209,162,64,150,155,23,172,156,62,115,136,211,70,77,173,41,31,146,112,232,186,176,170,4,91,79,141,118,37,77,78,49,76,4,225,254,227,179,13,67,92,31,23,207,104,73,85,156,42,202,147,158,251,14,218,97,23,71,10,18,125,163,219,44,15,162,201,63,179,159,20,109,49,207,232,200,238,199,95,49,175,123,197,140,182,161,252,210,224,161,253,72,85,136,240,246,44,235,168,207,233,244,185,228,180,110,78,30,252,180,200,206,210,113,211,171,94,28,143,126,0,230,223,71,136,178,2,0,0 };
			RealUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c456b1b1-b53e-46fa-992c-ed8f91d6c622"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("70bda10c-ead4-4ce6-a62a-881ed650f8f1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsSocialFilledParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a1631a1b-cff9-4da3-a76e-2682695e4be7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"IsSocialFilled",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridClientIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e0972f96-959c-4537-a09c-b070836c6886"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"ActiveTreeGridClientId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsExecutedFromGridParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2dd7217e-8a71-4ad7-aebf-20a866f19d1e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"IsExecutedFromGrid",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateUserMessageTextParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d42a49f0-aa49-4b18-928b-91584b5e36a2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"UserMessageText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNoContactSelectedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("016e4f1a-446e-408c-8b63-a85ba5a9c373"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"NoContactSelected",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialFieldsEmptyMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("04dee99c-0708-4bc2-be67-7b4862673bcc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("47d9f451-70d6-4014-b0c9-4ad37a1eb8b7"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"SocialFieldsEmptyMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateIsSocialFilledParameter());
			Parameters.Add(CreateActiveTreeGridClientIdParameter());
			Parameters.Add(CreateIsExecutedFromGridParameter());
			Parameters.Add(CreateUserMessageTextParameter());
			Parameters.Add(CreateNoContactSelectedParameter());
			Parameters.Add(CreateSocialFieldsEmptyMessageParameter());
		}

		protected virtual void InitializeOpenSocialConflictingValuesPageParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7a937ee3-e2d7-4bdd-98fb-9452f2cb1b0c"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("d77c933c-447d-400f-b3ea-628a0d34ff59"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("f7b4d7b6-b4b1-4eb2-a160-2584e8019ce3"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("4cb79422-4a40-4dc7-82fc-b385df6b1e65"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("1cb0a5f4-a343-4501-acd9-40ce0cc4c8cc"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("ea33dee3-2f47-42c4-95a3-6af50e57373b"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("92cc7875-18f7-42ab-9a71-031227d9d11d"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("038f4c19-1375-4630-bd79-dac578315176"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("44772935-b2eb-46c4-a6e4-503987702737"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("ecae009d-16b5-4e02-8d03-5c405edc3009"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("cff60d0e-6cb4-49e1-bfcb-4baee03c2b2d"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("e5e7e988-29e6-4491-bcdd-bb686af517b9"),
				ContainerUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
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
				UId = new Guid("d63a102c-4540-46f8-896f-85dc4b1dcc50"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("96a8711a-27de-4857-9337-99b259c975dc"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("76aa069e-aab3-4eb4-84db-a225fe5fb22a"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("865295d1-5828-44f8-8b00-b184dac105e0"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("e66a6d1c-07fc-4085-a1dc-962045616072"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("e1910bbb-c6ad-4aa8-a3f9-4122d6784514"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("12bfd8b7-bf22-494a-b31d-47dac12834f3"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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
				UId = new Guid("1261ad05-c6af-4d90-bb59-dd38f27ca8fc"),
				ContainerUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
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

		protected virtual void InitializeOpenContactEditPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c602d22d-0ad7-45b1-b7c0-a01f01f1d6d7"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("63a442cf-f4d4-469e-9ca0-5f2657989108"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("07994bff-a7c5-43fb-b050-76b42ec28efd"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("a6867086-4c42-409a-85d2-10a342ef6e4a"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("166e03fc-59e7-41e3-9f46-42167ae8d120"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("87ba2eab-d793-4968-ae0f-cd33af806ee6"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("fd8d772c-9e62-44f3-ba50-ee097768f42f"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("6c7b2bf5-14bb-4322-a2aa-3922fd16651f"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("db8904e2-c5f6-4c5f-9a97-747f354a2266"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("70ffbfbb-18d8-417c-8aad-9c1628ec6b6b"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("40e3ccbc-6976-4348-a2bb-0beb5b8752f2"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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
				UId = new Guid("99bdf254-2cbd-4149-bd97-0c7eb1fe817a"),
				ContainerUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
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

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet85 = CreateLaneSet85LaneSet();
			LaneSets.Add(schemaLaneSet85);
			ProcessSchemaLane schemaLane211 = CreateLane211Lane();
			schemaLaneSet85.Lanes.Add(schemaLane211);
			ProcessSchemaEventSubProcess eventsubprocess1 = CreateEventSubProcess1EventSubProcess();
			FlowElements.Add(eventsubprocess1);
			ProcessSchemaEventSubProcess eventsubprocess2 = CreateEventSubProcess2EventSubProcess();
			FlowElements.Add(eventsubprocess2);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaUserTask opensocialconflictingvaluespage = CreateOpenSocialConflictingValuesPageUserTask();
			FlowElements.Add(opensocialconflictingvaluespage);
			ProcessSchemaScriptTask preparemessagescripttask = CreatePrepareMessageScriptTaskScriptTask();
			FlowElements.Add(preparemessagescripttask);
			ProcessSchemaUserTask showmessageusertask = CreateShowMessageUserTaskUserTask();
			FlowElements.Add(showmessageusertask);
			ProcessSchemaStartMessageEvent opencontactyesmessage = CreateOpenContactYesMessageStartMessageEvent();
			eventsubprocess1.FlowElements.Add(opencontactyesmessage);
			ProcessSchemaScriptTask prepareopencontacteditpagescripttask = CreatePrepareOpenContactEditPageScriptTaskScriptTask();
			eventsubprocess1.FlowElements.Add(prepareopencontacteditpagescripttask);
			ProcessSchemaUserTask opencontacteditpageusertask = CreateOpenContactEditPageUserTaskUserTask();
			eventsubprocess1.FlowElements.Add(opencontacteditpageusertask);
			ProcessSchemaStartMessageEvent opencontactnomessage = CreateOpenContactNoMessageStartMessageEvent();
			eventsubprocess2.FlowElements.Add(opencontactnomessage);
			ProcessSchemaScriptTask scripttask2 = CreateScriptTask2ScriptTask();
			eventsubprocess2.FlowElements.Add(scripttask2);
			FlowElements.Add(CreateSequenceFlow683SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow683SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow683",
				UId = new Guid("45778989-ff4d-49b4-b85a-3d9cd69cffb8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a3bbb75c-d7ef-4134-8a42-6be6e8ac5e92"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("506b13d9-7438-49b6-8521-ed0d91633ac3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6d7548f2-027a-4a41-884d-0d78853585a3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("483fb489-a939-4da5-a412-c07958b44099"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("a12e1aa1-0165-44b7-a3b4-f46b2d114418"),
				ConditionExpression = @"IsSocialFilled",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(272, 184),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("483fb489-a939-4da5-a412-c07958b44099"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a3bbb75c-d7ef-4134-8a42-6be6e8ac5e92"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("8a5a7948-d932-47e9-a551-4439fb34d000"),
				ConditionExpression = @"!IsSocialFilled",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(338, 106),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("483fb489-a939-4da5-a412-c07958b44099"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("55437407-9ac3-4488-83c9-a16332ad2ddf"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(156, 330),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("87e07465-563a-46f7-b345-43420cde640f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("450f75c1-5003-44be-823b-1dc0d024044b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("8630a4fc-ff10-49bc-b379-5ecc3ade35d9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(295, 328),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("450f75c1-5003-44be-823b-1dc0d024044b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("1c54205e-bcde-472c-af2f-581a0b9348e5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				CurveCenterPosition = new Point(562, 392),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ea3f6252-ef02-4f0a-888f-582c64fdbd2e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8b8fa0be-f4e0-4c47-90a1-55709eeaf182"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet85LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet85 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("6a0ad4c2-e023-4758-adb4-630f7475d41d"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"LaneSet85",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet85;
		}

		protected virtual ProcessSchemaLane CreateLane211Lane() {
			ProcessSchemaLane schemaLane211 = new ProcessSchemaLane(this) {
				UId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("6a0ad4c2-e023-4758-adb4-630f7475d41d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"Lane211",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane211;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("6d7548f2-027a-4a41-884d-0d78853585a3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"Start1",
				Position = new Point(50, 23),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a3bbb75c-d7ef-4134-8a42-6be6e8ac5e92"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"ScriptTask1",
				Position = new Point(204, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,221,106,194,64,16,133,239,11,125,135,37,87,17,36,47,208,31,176,41,216,64,91,165,106,123,61,100,199,100,33,206,202,236,68,241,237,59,107,138,109,170,72,110,178,217,225,156,239,156,217,29,176,217,66,133,139,178,198,13,188,1,233,63,155,7,179,10,200,185,39,194,82,156,167,108,138,210,83,164,201,252,191,41,25,25,8,230,108,124,119,123,179,235,101,40,252,44,48,242,11,10,2,84,226,211,225,29,54,152,38,154,46,80,202,194,151,14,26,189,172,27,167,93,168,250,132,166,197,16,115,146,145,194,103,91,164,43,154,44,126,86,133,237,165,102,58,56,245,98,77,19,228,160,10,194,189,121,142,4,79,192,135,251,32,172,172,177,233,206,199,52,198,253,234,179,137,181,105,194,88,122,182,133,77,198,102,162,198,29,46,25,113,202,206,230,45,51,146,124,248,125,97,179,165,95,28,25,233,232,18,67,126,44,151,40,141,83,72,97,135,110,58,255,187,206,246,116,25,224,206,53,7,25,227,67,9,183,56,192,241,229,172,212,253,119,61,142,6,88,95,208,85,181,244,189,221,108,72,211,198,7,140,34,228,25,189,122,136,149,215,208,132,216,153,81,90,166,110,131,111,194,110,182,45,219,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenSocialConflictingValuesPageUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"OpenSocialConflictingValuesPage",
				Position = new Point(407, 163),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenSocialConflictingValuesPageParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareMessageScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("483fb489-a939-4da5-a412-c07958b44099"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"PrepareMessageScriptTask",
				Position = new Point(204, 9),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,146,207,110,194,48,12,198,207,32,237,29,162,30,16,72,8,30,128,49,105,99,128,162,109,5,209,114,224,152,165,134,69,148,4,37,41,127,132,250,238,115,104,24,108,140,193,109,71,59,63,219,241,231,111,197,52,225,74,90,198,45,105,147,62,216,78,17,84,31,185,21,43,136,53,64,95,139,164,147,105,13,210,142,212,154,38,181,214,93,89,76,171,95,85,109,34,179,52,173,145,221,93,185,68,77,164,184,96,105,79,164,41,36,216,113,202,82,3,88,80,138,62,212,250,13,140,97,51,24,27,208,49,51,243,198,80,43,142,41,42,141,101,146,3,117,5,135,96,76,147,86,179,57,68,252,248,124,169,143,143,99,216,184,37,66,229,119,136,32,5,110,225,98,25,197,21,144,15,104,216,27,4,151,160,167,204,90,37,141,227,6,47,123,74,131,205,180,36,86,103,110,177,124,47,134,177,90,200,89,131,154,16,165,24,232,238,98,105,183,7,133,26,61,198,225,93,169,57,74,71,42,21,242,39,251,42,228,28,18,42,145,197,81,215,232,120,45,172,5,141,48,202,79,254,77,255,51,33,197,148,84,169,233,110,128,103,168,127,79,171,133,51,81,173,228,44,114,195,5,93,250,36,227,58,94,187,205,164,27,133,197,236,95,201,17,152,37,146,224,243,174,68,194,154,60,11,116,185,146,76,111,239,11,157,235,94,239,135,189,155,75,187,96,11,38,168,227,233,151,32,189,171,38,96,124,151,32,175,23,144,84,63,152,80,125,71,114,247,177,156,0,222,162,104,124,93,131,195,29,33,77,204,254,232,254,249,22,49,188,81,209,154,39,51,207,172,113,52,240,169,163,63,1,249,91,201,59,17,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateShowMessageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"ShowMessageUserTask",
				Position = new Point(379, 9),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeShowMessageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess1EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess1 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("ba2ebcf2-d493-4c86-a698-3927617f3582"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"EventSubProcess1",
				Position = new Point(57, 310),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(354, 155),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess1;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateOpenContactYesMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("87e07465-563a-46f7-b345-43420cde640f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba2ebcf2-d493-4c86-a698-3927617f3582"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"OpenContactYesMessage",
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"OpenContactYesMessage",
				Position = new Point(28, 56),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareOpenContactEditPageScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("450f75c1-5003-44be-823b-1dc0d024044b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba2ebcf2-d493-4c86-a698-3927617f3582"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"PrepareOpenContactEditPageScriptTask",
				Position = new Point(119, 42),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,81,75,195,48,20,133,223,247,43,66,158,90,24,253,3,83,97,86,153,5,117,195,85,124,190,52,215,54,184,221,140,155,219,142,253,123,147,22,153,221,160,250,148,230,112,206,249,78,218,1,171,3,212,184,173,26,220,195,11,80,248,102,117,171,222,61,114,238,136,176,18,235,40,91,161,140,28,137,222,92,134,116,170,192,171,43,121,49,235,70,136,208,125,197,139,245,5,121,1,170,240,254,244,10,123,76,116,128,11,84,242,104,172,196,78,157,46,102,235,3,210,133,28,103,150,224,191,178,254,82,152,81,123,22,132,31,60,135,82,65,246,193,64,120,84,15,182,127,23,240,233,198,11,91,170,231,106,56,239,146,0,58,219,179,165,49,137,102,172,28,155,194,232,185,90,134,92,135,37,35,174,216,154,188,101,70,146,55,119,44,76,86,186,109,95,145,164,255,216,186,249,189,232,204,155,14,230,129,133,140,241,149,194,45,78,155,63,172,145,102,252,63,122,105,58,245,132,182,110,100,28,27,180,63,166,237,156,199,104,64,94,211,179,131,184,241,19,118,62,140,100,148,150,105,88,252,13,1,143,48,163,111,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenContactEditPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ba2ebcf2-d493-4c86-a698-3927617f3582"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"OpenContactEditPageUserTask",
				Position = new Point(259, 42),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenContactEditPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess2EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess2 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("3b4156f3-7fcd-4bb2-8ee4-ecc954ed6df1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("ffc1b16d-7af3-4560-bad7-093a7e32518a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"EventSubProcess2",
				Position = new Point(449, 317),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(294, 144),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess2;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateOpenContactNoMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("ea3f6252-ef02-4f0a-888f-582c64fdbd2e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3b4156f3-7fcd-4bb2-8ee4-ecc954ed6df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"OpenContactNoMessage",
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"OpenContactNoMessage",
				Position = new Point(14, 56),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("8b8fa0be-f4e0-4c47-90a1-55709eeaf182"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3b4156f3-7fcd-4bb2-8ee4-ecc954ed6df1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"),
				Name = @"ScriptTask2",
				Position = new Point(105, 42),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,74,45,41,45,202,83,72,75,204,41,78,181,6,0,112,193,6,27,13,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("02624d45-7b37-4faa-aec8-0d1622e3f447"),
				Name = "BPMSoft.Core.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("745112bc-253c-48c4-9cb1-8ef5356ff258"),
				Name = "BPMSoft.UI.WebControls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FillFromSocialModuleProcess(userConnection);
		}

		public override object Clone() {
			return new FillFromSocialModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd"));
		}

		#endregion

	}

	#endregion

	#region Class: FillFromSocialModuleProcess

	/// <exclude/>
	public class FillFromSocialModuleProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane211

		/// <exclude/>
		public class ProcessLane211 : ProcessLane
		{

			public ProcessLane211(UserConnection userConnection, FillFromSocialModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenSocialConflictingValuesPageFlowElement

		/// <exclude/>
		public class OpenSocialConflictingValuesPageFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenSocialConflictingValuesPageFlowElement(UserConnection userConnection, FillFromSocialModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenSocialConflictingValuesPage";
				IsLogging = true;
				SchemaElementUId = new Guid("988a4d8c-71c3-4226-8527-75bc80be880d");
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

			public ShowMessageUserTaskFlowElement(UserConnection userConnection, FillFromSocialModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowMessageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("01cdf4f9-09ef-41e4-9b18-0bb3d23569da");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: OpenContactEditPageUserTaskFlowElement

		/// <exclude/>
		public class OpenContactEditPageUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenContactEditPageUserTaskFlowElement(UserConnection userConnection, FillFromSocialModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenContactEditPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("40cd8667-ace6-4558-a6bd-a1206d344224");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public FillFromSocialModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FillFromSocialModuleProcess";
			SchemaUId = new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd");
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
				return new Guid("6f83aa16-dc41-411a-8fa8-dd6199f571fd");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FillFromSocialModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FillFromSocialModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual bool IsSocialFilled {
			get;
			set;
		}

		public virtual string ActiveTreeGridClientId {
			get;
			set;
		}

		public virtual bool IsExecutedFromGrid {
			get;
			set;
		}

		private LocalizableString _userMessageText;
		public virtual LocalizableString UserMessageText {
			get {
				return _userMessageText ?? (_userMessageText = GetLocalizableString("6f83aa16dc41411a8fa8dd6199f571fd",
						 "Parameters.UserMessageText.Value"));
			}
			set {
				_userMessageText = value;
			}
		}

		private LocalizableString _noContactSelected;
		public virtual LocalizableString NoContactSelected {
			get {
				return _noContactSelected ?? (_noContactSelected = GetLocalizableString("6f83aa16dc41411a8fa8dd6199f571fd",
						 "Parameters.NoContactSelected.Value"));
			}
			set {
				_noContactSelected = value;
			}
		}

		private LocalizableString _socialFieldsEmptyMessage;
		public virtual LocalizableString SocialFieldsEmptyMessage {
			get {
				return _socialFieldsEmptyMessage ?? (_socialFieldsEmptyMessage = new LocalizableString());
			}
			set {
				_socialFieldsEmptyMessage = value;
			}
		}

		private ProcessLane211 _lane211;
		public ProcessLane211 Lane211 {
			get {
				return _lane211 ?? ((_lane211) = new ProcessLane211(UserConnection, this));
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
					SchemaElementUId = new Guid("6d7548f2-027a-4a41-884d-0d78853585a3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("a3bbb75c-d7ef-4134-8a42-6be6e8ac5e92"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		private OpenSocialConflictingValuesPageFlowElement _openSocialConflictingValuesPage;
		public OpenSocialConflictingValuesPageFlowElement OpenSocialConflictingValuesPage {
			get {
				return _openSocialConflictingValuesPage ?? (_openSocialConflictingValuesPage = new OpenSocialConflictingValuesPageFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _prepareMessageScriptTask;
		public ProcessScriptTask PrepareMessageScriptTask {
			get {
				return _prepareMessageScriptTask ?? (_prepareMessageScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareMessageScriptTask",
					SchemaElementUId = new Guid("483fb489-a939-4da5-a412-c07958b44099"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareMessageScriptTaskExecute,
				});
			}
		}

		private ShowMessageUserTaskFlowElement _showMessageUserTask;
		public ShowMessageUserTaskFlowElement ShowMessageUserTask {
			get {
				return _showMessageUserTask ?? (_showMessageUserTask = new ShowMessageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("ba2ebcf2-d493-4c86-a698-3927617f3582"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _openContactYesMessage;
		public ProcessFlowElement OpenContactYesMessage {
			get {
				return _openContactYesMessage ?? (_openContactYesMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpenContactYesMessage",
					SchemaElementUId = new Guid("87e07465-563a-46f7-b345-43420cde640f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareOpenContactEditPageScriptTask;
		public ProcessScriptTask PrepareOpenContactEditPageScriptTask {
			get {
				return _prepareOpenContactEditPageScriptTask ?? (_prepareOpenContactEditPageScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareOpenContactEditPageScriptTask",
					SchemaElementUId = new Guid("450f75c1-5003-44be-823b-1dc0d024044b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareOpenContactEditPageScriptTaskExecute,
				});
			}
		}

		private OpenContactEditPageUserTaskFlowElement _openContactEditPageUserTask;
		public OpenContactEditPageUserTaskFlowElement OpenContactEditPageUserTask {
			get {
				return _openContactEditPageUserTask ?? (_openContactEditPageUserTask = new OpenContactEditPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("3b4156f3-7fcd-4bb2-8ee4-ecc954ed6df1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _openContactNoMessage;
		public ProcessFlowElement OpenContactNoMessage {
			get {
				return _openContactNoMessage ?? (_openContactNoMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OpenContactNoMessage",
					SchemaElementUId = new Guid("ea3f6252-ef02-4f0a-888f-582c64fdbd2e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("8b8fa0be-f4e0-4c47-90a1-55709eeaf182"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask2Execute,
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
					SchemaElementUId = new Guid("a12e1aa1-0165-44b7-a3b4-f46b2d114418"),
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
					SchemaElementUId = new Guid("8a5a7948-d932-47e9-a551-4439fb34d000"),
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
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[OpenSocialConflictingValuesPage.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenSocialConflictingValuesPage };
			FlowElements[PrepareMessageScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareMessageScriptTask };
			FlowElements[ShowMessageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageUserTask };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[OpenContactYesMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenContactYesMessage };
			FlowElements[PrepareOpenContactEditPageScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareOpenContactEditPageScriptTask };
			FlowElements[OpenContactEditPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenContactEditPageUserTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[OpenContactNoMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenContactNoMessage };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareMessageScriptTask", e.Context.SenderName));
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenSocialConflictingValuesPage", e.Context.SenderName));
						break;
					case "OpenSocialConflictingValuesPage":
						break;
					case "PrepareMessageScriptTask":
						if (ConditionalFlow1ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
							break;
						}
						if (ConditionalFlow2ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageUserTask", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "PrepareMessageScriptTask");
						break;
					case "ShowMessageUserTask":
						break;
					case "EventSubProcess1":
						break;
					case "OpenContactYesMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareOpenContactEditPageScriptTask", e.Context.SenderName));
						break;
					case "PrepareOpenContactEditPageScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenContactEditPageUserTask", e.Context.SenderName));
						break;
					case "OpenContactEditPageUserTask":
						break;
					case "EventSubProcess2":
						break;
					case "OpenContactNoMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask2", e.Context.SenderName));
						break;
					case "ScriptTask2":
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(IsSocialFilled);
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareMessageScriptTask", "ConditionalFlow1", "IsSocialFilled", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean(!IsSocialFilled);
			Log.InfoFormat(ConditionalExpressionLogMessage, "PrepareMessageScriptTask", "ConditionalFlow2", "!IsSocialFilled", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("IsSocialFilled")) {
				writer.WriteValue("IsSocialFilled", IsSocialFilled, false);
			}
			if (!HasMapping("ActiveTreeGridClientId")) {
				writer.WriteValue("ActiveTreeGridClientId", ActiveTreeGridClientId, null);
			}
			if (!HasMapping("IsExecutedFromGrid")) {
				writer.WriteValue("IsExecutedFromGrid", IsExecutedFromGrid, false);
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
			ActivatedEventElements.Add("OpenContactYesMessage");
			ActivatedEventElements.Add("OpenContactNoMessage");
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
			MetaPathParameterValues.Add("c456b1b1-b53e-46fa-992c-ed8f91d6c622", () => PageInstanceId);
			MetaPathParameterValues.Add("70bda10c-ead4-4ce6-a62a-881ed650f8f1", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("a1631a1b-cff9-4da3-a76e-2682695e4be7", () => IsSocialFilled);
			MetaPathParameterValues.Add("e0972f96-959c-4537-a09c-b070836c6886", () => ActiveTreeGridClientId);
			MetaPathParameterValues.Add("2dd7217e-8a71-4ad7-aebf-20a866f19d1e", () => IsExecutedFromGrid);
			MetaPathParameterValues.Add("d42a49f0-aa49-4b18-928b-91584b5e36a2", () => UserMessageText);
			MetaPathParameterValues.Add("016e4f1a-446e-408c-8b63-a85ba5a9c373", () => NoContactSelected);
			MetaPathParameterValues.Add("04dee99c-0708-4bc2-be67-7b4862673bcc", () => SocialFieldsEmptyMessage);
			MetaPathParameterValues.Add("7a937ee3-e2d7-4bdd-98fb-9452f2cb1b0c", () => OpenSocialConflictingValuesPage.PageUId);
			MetaPathParameterValues.Add("d77c933c-447d-400f-b3ea-628a0d34ff59", () => OpenSocialConflictingValuesPage.PageUrl);
			MetaPathParameterValues.Add("f7b4d7b6-b4b1-4eb2-a160-2584e8019ce3", () => OpenSocialConflictingValuesPage.OpenerInstanceId);
			MetaPathParameterValues.Add("4cb79422-4a40-4dc7-82fc-b385df6b1e65", () => OpenSocialConflictingValuesPage.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("1cb0a5f4-a343-4501-acd9-40ce0cc4c8cc", () => OpenSocialConflictingValuesPage.PageParameters);
			MetaPathParameterValues.Add("ea33dee3-2f47-42c4-95a3-6af50e57373b", () => OpenSocialConflictingValuesPage.Width);
			MetaPathParameterValues.Add("92cc7875-18f7-42ab-9a71-031227d9d11d", () => OpenSocialConflictingValuesPage.CloseMessage);
			MetaPathParameterValues.Add("038f4c19-1375-4630-bd79-dac578315176", () => OpenSocialConflictingValuesPage.Height);
			MetaPathParameterValues.Add("44772935-b2eb-46c4-a6e4-503987702737", () => OpenSocialConflictingValuesPage.Centered);
			MetaPathParameterValues.Add("ecae009d-16b5-4e02-8d03-5c405edc3009", () => OpenSocialConflictingValuesPage.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("cff60d0e-6cb4-49e1-bfcb-4baee03c2b2d", () => OpenSocialConflictingValuesPage.UseCurrentActivePage);
			MetaPathParameterValues.Add("e5e7e988-29e6-4491-bcdd-bb686af517b9", () => OpenSocialConflictingValuesPage.IgnoreProfile);
			MetaPathParameterValues.Add("d63a102c-4540-46f8-896f-85dc4b1dcc50", () => ShowMessageUserTask.Page);
			MetaPathParameterValues.Add("96a8711a-27de-4857-9337-99b259c975dc", () => ShowMessageUserTask.Icon);
			MetaPathParameterValues.Add("76aa069e-aab3-4eb4-84db-a225fe5fb22a", () => ShowMessageUserTask.Buttons);
			MetaPathParameterValues.Add("865295d1-5828-44f8-8b00-b184dac105e0", () => ShowMessageUserTask.WindowCaption);
			MetaPathParameterValues.Add("e66a6d1c-07fc-4085-a1dc-962045616072", () => ShowMessageUserTask.MessageText);
			MetaPathParameterValues.Add("e1910bbb-c6ad-4aa8-a3f9-4122d6784514", () => ShowMessageUserTask.ResponseMessages);
			MetaPathParameterValues.Add("12bfd8b7-bf22-494a-b31d-47dac12834f3", () => ShowMessageUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("1261ad05-c6af-4d90-bb59-dd38f27ca8fc", () => ShowMessageUserTask.PageParameters);
			MetaPathParameterValues.Add("c602d22d-0ad7-45b1-b7c0-a01f01f1d6d7", () => OpenContactEditPageUserTask.PageUId);
			MetaPathParameterValues.Add("63a442cf-f4d4-469e-9ca0-5f2657989108", () => OpenContactEditPageUserTask.PageUrl);
			MetaPathParameterValues.Add("07994bff-a7c5-43fb-b050-76b42ec28efd", () => OpenContactEditPageUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("a6867086-4c42-409a-85d2-10a342ef6e4a", () => OpenContactEditPageUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("166e03fc-59e7-41e3-9f46-42167ae8d120", () => OpenContactEditPageUserTask.PageParameters);
			MetaPathParameterValues.Add("87ba2eab-d793-4968-ae0f-cd33af806ee6", () => OpenContactEditPageUserTask.Width);
			MetaPathParameterValues.Add("fd8d772c-9e62-44f3-ba50-ee097768f42f", () => OpenContactEditPageUserTask.CloseMessage);
			MetaPathParameterValues.Add("6c7b2bf5-14bb-4322-a2aa-3922fd16651f", () => OpenContactEditPageUserTask.Height);
			MetaPathParameterValues.Add("db8904e2-c5f6-4c5f-9a97-747f354a2266", () => OpenContactEditPageUserTask.Centered);
			MetaPathParameterValues.Add("70ffbfbb-18d8-417c-8aad-9c1628ec6b6b", () => OpenContactEditPageUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("40e3ccbc-6976-4348-a2bb-0beb5b8752f2", () => OpenContactEditPageUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("99bdf254-2cbd-4149-bd97-0c7eb1fe817a", () => OpenContactEditPageUserTask.IgnoreProfile);
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
				case "IsSocialFilled":
					if (!hasValueToRead) break;
					IsSocialFilled = reader.GetValue<System.Boolean>();
				break;
				case "ActiveTreeGridClientId":
					if (!hasValueToRead) break;
					ActiveTreeGridClientId = reader.GetValue<System.String>();
				break;
				case "IsExecutedFromGrid":
					if (!hasValueToRead) break;
					IsExecutedFromGrid = reader.GetValue<System.Boolean>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as PageSchemaManager;
			var pageSchema = pageSchemaManager.GetInstanceByName("ContactSocialConflictingValuesPage");
			OpenSocialConflictingValuesPage.PageUId = pageSchema.UId;
			var parameters = new Dictionary<string, string>();
			parameters.Add("recordId", ActiveTreeGridCurrentRowId.ToString());
			parameters.Add("treeGridId", ActiveTreeGridClientId);
			OpenSocialConflictingValuesPage.PageParameters = parameters;
			OpenSocialConflictingValuesPage.Centered = true;
			OpenSocialConflictingValuesPage.Width = pageSchema.Width;
			OpenSocialConflictingValuesPage.Height = pageSchema.Height;
			OpenSocialConflictingValuesPage.CloseOpenerOnLoad = false;
			return true;
		}

		public virtual bool PrepareMessageScriptTaskExecute(ProcessExecutingContext context) {
			var contact = GetContact(ActiveTreeGridCurrentRowId);
			if(contact == null) {
				IsSocialFilled = false;
				ShowMessageUserTask.ProcessInstanceId = InstanceUId;//PageInstanceId;
				ShowMessageUserTask.MessageText = NoContactSelected;
				ShowMessageUserTask.Icon = "INFO";
				ShowMessageUserTask.Buttons = "OK";
				return true;
			}
			if(string.IsNullOrEmpty(contact.FacebookId) && string.IsNullOrEmpty(contact.LinkedInId)
				&& string.IsNullOrEmpty(contact.TwitterId)) { 
				IsSocialFilled = false;
				ShowMessageUserTask.ProcessInstanceId = InstanceUId;//PageInstanceId;
				ShowMessageUserTask.Icon = "INFO";
				if (IsExecutedFromGrid)	{
					ShowMessageUserTask.MessageText = UserMessageText;
					ShowMessageUserTask.Buttons = "YESNO";
					ShowMessageUserTask.ResponseMessages = new Dictionary<string, string> {
					{"yes", "OpenContactYesMessage"},
					{"no", "OpenContactNoMessage"},
					};
				} else {
					ShowMessageUserTask.MessageText = SocialFieldsEmptyMessage;
					ShowMessageUserTask.Buttons = "OK";
				}
			} else {
				IsSocialFilled = true;
			}
			return true;
		}

		public virtual bool PrepareOpenContactEditPageScriptTaskExecute(ProcessExecutingContext context) {
			var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as PageSchemaManager;
			var pageSchema = pageSchemaManager.GetInstanceByName("ContactEditPage");
			OpenContactEditPageUserTask.PageUId = pageSchema.UId;
			var parameters = new Dictionary<string, string>();
			parameters.Add("recordId", ActiveTreeGridCurrentRowId.ToString());
			OpenContactEditPageUserTask.PageParameters = parameters;
			OpenContactEditPageUserTask.Centered = true;
			OpenContactEditPageUserTask.Width = pageSchema.Width;
			OpenContactEditPageUserTask.Height = pageSchema.Height;
			OpenContactEditPageUserTask.CloseOpenerOnLoad = false;
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			return false;
		}

			
			public virtual BPMSoft.Configuration.Contact GetContact(Guid contactId) {
				var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
				var contact = contactSchema.CreateEntity(UserConnection) as BPMSoft.Configuration.Contact;
				bool fetchResult = contact.FetchFromDB(contactSchema.PrimaryColumn, contactId, new[] {
				                               contactSchema.Columns.FindByColumnValueName("FacebookId"),
				                               contactSchema.Columns.FindByColumnValueName("LinkedInId"),
											   contactSchema.Columns.FindByColumnValueName("TwitterId")
				                });
				if (!fetchResult){
				   contact = null;
				}
				return contact;
			}
			

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "OpenContactYesMessage":
							if (ActivatedEventElements.Contains("OpenContactYesMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenContactYesMessage", "OpenContactYesMessage"));
						}
						break;
					case "OpenContactNoMessage":
							if (ActivatedEventElements.Contains("OpenContactNoMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenContactNoMessage", "OpenContactNoMessage"));
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
			var cloneItem = (FillFromSocialModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

