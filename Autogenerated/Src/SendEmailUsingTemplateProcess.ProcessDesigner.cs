namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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
	using System.Linq;
	using System.Text;
	using System.Web;

	#region Class: SendEmailUsingTemplateProcessSchema

	/// <exclude/>
	public class SendEmailUsingTemplateProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendEmailUsingTemplateProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendEmailUsingTemplateProcessSchema(SendEmailUsingTemplateProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendEmailUsingTemplateProcess";
			UId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2803";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
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
			RealUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced");
			Version = 0;
			PackageUId = new Guid("6f46362b-0d60-47d7-b211-fc5e4117aecb");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateEmailTemplateIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b0d75fc7-0242-4088-89b7-66814178129b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"EmailTemplateId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSaveAsActivityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7128f6a5-f738-4c89-bc19-e25816dbe4be"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"SaveAsActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveRowPrimaryColumnValueParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e9cb394d-660c-4148-9a94-9771d98a5f8d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"ActiveRowPrimaryColumnValue",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateEmailTemplateExecutorParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2e80c981-5668-48d8-bf13-e97cd963cddf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"EmailTemplateExecutor",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessagePanelParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bd3ff53c-edd8-49c4-bd37-bb3db9434971"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"MessagePanel",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHaveEmptyRecipientParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5f0da840-e783-4500-b814-b8ca6f0ef3a0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"HaveEmptyRecipient",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIsEmptyListParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ee2a178d-7c76-4f37-a0ed-97361c8af636"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"IsEmptyList",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHasNextActivityParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("09d8fb2b-85c6-4a87-91ef-c8e14bf0ad99"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"HasNextActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMailboxSyncSettingsLinkIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("94c0e53d-f908-49dd-8961-4b496f1898c7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"MailboxSyncSettingsLinkId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessageAfterSendParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e709de1a-6466-49d6-bd5b-b8cca1569c23"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"MessageAfterSend",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateEmailTemplateIdParameter());
			Parameters.Add(CreateSaveAsActivityParameter());
			Parameters.Add(CreateActiveRowPrimaryColumnValueParameter());
			Parameters.Add(CreateEmailTemplateExecutorParameter());
			Parameters.Add(CreateMessagePanelParameter());
			Parameters.Add(CreateHaveEmptyRecipientParameter());
			Parameters.Add(CreateIsEmptyListParameter());
			Parameters.Add(CreateHasNextActivityParameter());
			Parameters.Add(CreateMailboxSyncSettingsLinkIdParameter());
			Parameters.Add(CreateMessageAfterSendParameter());
		}

		protected virtual void InitializeOpenEmailCardUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2ad2ae58-848d-466d-89f1-ba26a454c813"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("9ae4f72d-35af-4eed-b669-9e385b7dadd0"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("01d5dd6b-d2f3-4f37-bcae-dd06f02c663b"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("6106915a-7272-4224-af0f-9e424058c406"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("bacab600-93bc-4c8d-b5fa-5f7c5ca0a954"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("067c2f40-0e65-4eb2-aa1f-78a94885471e"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("1218d0e3-703a-444e-a248-3a8a3d13f328"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("6298157d-b97e-41dc-83c9-60d25d1dc8bf"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("d70540d4-0967-4889-9e05-107c74224ad5"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("b5a356f0-c239-4f78-b884-54a3194e3460"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("6b46040f-e793-4562-8671-c91e66aac4ed"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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
				UId = new Guid("488e9b78-424d-4af9-8569-357b2f048617"),
				ContainerUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
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

		protected virtual void InitializeShowMessageWindowUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5d123519-361b-4cc7-9b26-d440757daefe"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("e9a76bf3-30f5-4536-938b-87bcd99a9348"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("c9c687fd-e109-47df-b719-555727bd75d0"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("e5288b50-aeb3-40b2-9535-d10bdbd06f38"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("1ed98530-fbef-47ac-9c61-fbdfbeb7bf6f"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("9499dd19-c3ce-40d2-954d-9b01c15e0ffd"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("3a8b275d-5e6f-4669-bd8c-807c437fef53"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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
				UId = new Guid("a89345ca-3709-4404-9858-f550886f6ad4"),
				ContainerUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
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

		protected virtual void InitializeUserQuestionUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var branchingDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c90d19a7-f600-48e8-8385-91e0a35cb189"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"BranchingDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableParameterValuesListDataValueType")
			};
			branchingDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(branchingDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,93,75,195,48,20,134,255,138,132,93,246,140,164,77,210,116,151,110,8,131,57,6,126,128,136,23,39,201,9,22,59,59,154,78,112,163,255,221,116,23,178,33,138,119,7,222,247,57,188,207,145,77,250,207,29,177,25,187,222,220,222,181,161,159,206,219,142,166,155,174,117,20,227,116,213,58,108,234,3,218,134,54,216,225,150,122,234,30,177,217,83,92,213,177,207,174,206,33,150,177,201,199,41,99,179,231,35,91,246,180,125,88,250,244,89,104,107,20,87,10,108,85,42,144,165,178,128,74,18,56,229,10,83,114,207,77,168,18,60,118,143,236,244,33,65,36,69,48,54,84,64,101,73,32,157,208,128,194,9,200,117,208,218,86,210,82,78,108,200,216,58,141,58,231,22,228,234,88,183,239,124,12,231,184,235,211,61,230,117,92,185,195,105,58,155,245,221,158,178,111,226,41,13,78,221,5,133,249,43,185,55,186,152,113,159,170,108,24,178,11,31,227,130,21,200,193,89,17,64,22,92,1,6,238,193,84,130,168,212,222,20,94,253,240,225,228,184,14,40,129,140,16,32,189,68,192,66,230,224,67,46,11,178,200,209,185,191,124,196,191,125,214,237,239,58,55,216,196,209,231,101,248,2,209,137,89,65,249,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(branchingDecisionsParameter);
			var resultDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("abb01b39-e2e0-4ade-8896-1ee4ec37837d"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ResultDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			resultDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(resultDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDecisionsParameter);
			var decisionModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("317ea3aa-e0f6-41b1-b281-1504827c4800"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DecisionMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			decisionModeParameter.SourceValue = new ProcessSchemaParameterValue(decisionModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(decisionModeParameter);
			var isDecisionRequiredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dd8c89f0-87b7-4ff2-bda0-23066f538dc8"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"IsDecisionRequired",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isDecisionRequiredParameter.SourceValue = new ProcessSchemaParameterValue(isDecisionRequiredParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(isDecisionRequiredParameter);
			var questionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("74be3c5e-f0fb-439a-a2c6-fe18128c490f"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Question",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			questionParameter.SourceValue = new ProcessSchemaParameterValue(questionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"The email address is not specified for some contacts in the list of recipients. Send message to other recipients?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(questionParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f1d7cf7a-70ea-43ab-bf19-2b98e3fdcebd"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Answer selection page for ""Continue?"" item",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b11b59fe-f02e-4f00-8920-6bbd8620a8ed"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"The email address is not specified for some contacts in the list of recipients. Send message to other recipients?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("2bb6b709-4430-43ba-9c03-0ac095965f83"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"f51c4643-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("10f30bc8-8525-4947-b49d-725777c3debc"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("89f805c6-65cb-4930-a051-8d4f9214ea07"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"2",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("be3a8ead-7371-4b9d-b87a-c19a6f4d3107"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DurationPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationPeriodParameter.SourceValue = new ProcessSchemaParameterValue(durationPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a31e7e65-feee-481e-9a55-08640dcca1f7"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("614ab8f5-c81a-45ff-8497-3dd24309c148"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("aff41918-85a1-4ff7-bef7-49661ec076e2"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("41f6f394-b829-4163-ba39-113fc778920c"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4ccd06c0-32f7-426a-a23a-5a6c473d27e1"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9967fe17-6e9c-4fc8-832f-17ce3d92f13c"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9c00708c-01a0-4f67-8804-a2fa71ba9498"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("35bf2807-792d-4d13-ae8d-4e19b9b08b3c"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("caaaa922-90dc-448d-92b3-4f896e10390e"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("73d44222-3511-4efb-a983-8f1d6c93a4c1"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0e27af8f-095f-498f-9a07-f1a0f0641b32"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("46033570-c17f-4d83-b047-070223debf80"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cc24269d-27b6-4e23-821a-8a38c52aac15"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("801ed6fb-cac9-4c18-bab5-595b1300a209"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d57eb5c5-9ece-481a-bd84-7d84a3f8642e"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c6073f6d-6d7f-44ae-8a4b-42ee70a64ce7"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fd6db9ee-84df-434a-a179-9bd01fe0fe41"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dda3b1f3-0ce1-4418-b160-3f2effc18c79"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("92033d7f-e7e1-4f99-8211-16c61e9c81a2"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var orderParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f135b7e5-ecfb-49a8-8cfb-8990063d4713"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1796c06a-1878-42cd-9fb0-67535f3e8fb5"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2c9eba00-9fbf-411e-b360-3f67ff750de2"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ca966398-a970-40f1-a35e-b8ed082fb444"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("97edaefe-9346-4ff5-8d4d-59aa889b243d"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("de7aae6a-08f3-4c8a-aec0-b8145472b8a5"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5c03fbe7-4dd0-443b-b395-bd582d40b3d3"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c1609f0c-da91-443f-8631-1f360ab9dd2b"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("68e92442-0b7d-4ae0-8ce4-d1c35d6e0890"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9804b757-b455-46cb-a644-8ba4ad7de497"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("0d26149b-65d5-4044-8cbb-5494b212f2b7"),
				ContainerUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
		}

		protected virtual void InitializeMessageToUserParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var branchingDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b60b849c-eb5f-42a1-8986-3bd02a52bb13"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"BranchingDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableParameterValuesListDataValueType")
			};
			branchingDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(branchingDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,85,142,81,75,195,48,20,133,255,138,92,246,216,148,36,237,150,166,143,118,8,131,170,5,209,23,241,33,73,111,49,172,179,35,201,4,87,250,223,77,250,32,243,237,192,119,190,195,153,97,19,126,206,8,53,220,119,143,47,211,16,242,102,114,152,119,110,50,232,125,222,78,70,141,246,170,244,136,157,114,234,132,1,221,155,26,47,232,91,235,67,118,119,43,65,6,155,239,149,65,253,62,195,33,224,233,245,208,199,101,201,17,53,99,138,136,74,48,82,22,172,32,178,223,106,66,57,171,184,164,21,114,170,163,156,186,51,172,11,81,26,118,156,50,190,77,82,89,144,146,234,138,104,41,118,68,151,186,144,70,8,35,123,14,75,6,79,241,212,173,183,71,99,189,157,190,104,130,141,58,135,152,19,183,190,53,215,245,58,212,193,93,48,251,51,158,143,169,186,199,161,249,68,115,196,127,47,30,212,232,17,150,229,99,249,5,118,71,31,12,41,1,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(branchingDecisionsParameter);
			var resultDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b36ce965-8a18-4276-a3ac-d82f6185fd3b"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ResultDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			resultDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(resultDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDecisionsParameter);
			var decisionModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8f593c0e-abdd-4602-8419-de73b6b46ec7"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DecisionMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			decisionModeParameter.SourceValue = new ProcessSchemaParameterValue(decisionModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(decisionModeParameter);
			var isDecisionRequiredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9353eef2-6160-492c-922b-3668d47ffd14"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"IsDecisionRequired",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isDecisionRequiredParameter.SourceValue = new ProcessSchemaParameterValue(isDecisionRequiredParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(isDecisionRequiredParameter);
			var questionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e12e5781-8d70-48b0-b200-b89e3c92d5ee"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Question",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			questionParameter.SourceValue = new ProcessSchemaParameterValue(questionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @" ",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(questionParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("355cb365-54c0-4b80-84a9-32be527326fe"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Answer selection page for ""Message to user"" item",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("67cd3f7e-a364-47aa-be34-d46b64479882"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @" ",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("09ebfc70-0058-47cd-9598-caf3d40c3ca7"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"f51c4643-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("fc33576f-5dd6-4d3c-bb29-ab5e58b4beb4"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8ee1c52d-5363-44dd-8cc0-c6386afd4863"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"2",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3374d938-f7e9-418e-b09d-791666bb21de"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DurationPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationPeriodParameter.SourceValue = new ProcessSchemaParameterValue(durationPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2049708b-d019-4f52-bd18-3d0348409bc4"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("488987df-2cfe-4fe6-b1fd-2018761c2729"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15a4611a-cee7-4905-a893-814b5638f46f"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c178eb4f-a737-4300-8c26-4296e8db880f"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f81f56c5-79ae-444c-8139-3f97bb7ff777"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8d89ba5b-ed07-41d5-a512-8bfd56f4b899"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"True",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7e05c262-a8db-4f6f-b30d-e548761b1a59"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("36be22dc-915a-4e7d-adfa-65806f3e3a7f"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("ca419b05-508b-4ad8-b709-a48d5fc61cfc"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("791cb414-5bb0-414b-969d-1f35a04dc39c"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15dbb192-c2fa-4fed-b9de-96eb773e620c"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("720bd101-34cd-42a8-81e7-1c18a56796ee"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("537fa6aa-b2da-48e0-ad5a-2a6de9941cb3"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("785c2902-1b60-4f05-b62d-279dbe6c7c43"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7e0a85af-7cd8-4572-81dd-95606d64ec4c"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3dfbbe33-93f5-45f4-856d-db9ca77c2b13"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0bec513a-b941-42c6-967d-a6753abef9b1"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d67f399b-8d1c-4142-a33c-e57f0e5c1377"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e17a820b-be52-4c54-bd90-edf7ade293b1"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
			var orderParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7d13f292-4621-4055-b41e-167c271e6b9e"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e8eea506-c22a-468b-9c18-d47baf0d4744"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4c456705-e036-495c-80c0-9e229f3a7833"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("00ed305e-b753-4628-80e0-02166ecc5d7e"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e957e8fc-5fb0-420e-8627-2ab978ef1ba2"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e532f458-4be7-4068-8d9c-3c0b7ab8de79"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("53fb23dc-abef-4f7c-b3df-9148bafb7033"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d749cf73-b4be-453f-b207-bf8cd4b753c3"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3175c7fa-3ccc-4328-aa0b-34b313616ac7"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2750141a-9a9f-4f34-a209-dcd6edab0e3e"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("2a1029da-a16c-47e0-a6c6-6271d39fdc5b"),
				ContainerUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
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
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet = CreateLaneSetLaneSet();
			LaneSets.Add(schemaLaneSet);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask getemailtemplatedatascripttask = CreateGetEmailTemplateDataScriptTaskScriptTask();
			FlowElements.Add(getemailtemplatedatascripttask);
			ProcessSchemaExclusiveGateway createactivityexclusivegateway = CreateCreateActivityExclusiveGatewayExclusiveGateway();
			FlowElements.Add(createactivityexclusivegateway);
			ProcessSchemaUserTask openemailcardusertask = CreateOpenEmailCardUserTaskUserTask();
			FlowElements.Add(openemailcardusertask);
			ProcessSchemaScriptTask prepareactivitiesscripttask = CreatePrepareActivitiesScriptTaskScriptTask();
			FlowElements.Add(prepareactivitiesscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			ProcessSchemaUserTask showmessagewindowusertask = CreateShowMessageWindowUserTaskUserTask();
			FlowElements.Add(showmessagewindowusertask);
			ProcessSchemaScriptTask showmessagewindowscripttask = CreateShowMessageWindowScriptTaskScriptTask();
			FlowElements.Add(showmessagewindowscripttask);
			ProcessSchemaScriptTask sendemailscripttask = CreateSendEmailScriptTaskScriptTask();
			FlowElements.Add(sendemailscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway4 = CreateExclusiveGateway4ExclusiveGateway();
			FlowElements.Add(exclusivegateway4);
			ProcessSchemaUserTask userquestionusertask1 = CreateUserQuestionUserTask1UserTask();
			FlowElements.Add(userquestionusertask1);
			ProcessSchemaUserTask messagetouser = CreateMessageToUserUserTask();
			FlowElements.Add(messagetouser);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateConditionalFlow6ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateConditionalFlow5ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateWarningLocalizableString());
			LocalizableStrings.Add(CreateNoEmailRecipientsLocalizableString());
			LocalizableStrings.Add(CreateSetMailboxSyncSettingsLocalizableString());
			LocalizableStrings.Add(CreateSetSettingsNowLocalizableString());
			LocalizableStrings.Add(CreateHaveEmptyRecipientLSLocalizableString());
			LocalizableStrings.Add(CreateAfterSendEmailMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateWarningLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e5bb4fc3-569a-4a60-aaa4-90954e53bb17"),
				Name = "Warning",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNoEmailRecipientsLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("0b9af8e4-9ee0-470e-afa9-58f950c4a4a1"),
				Name = "NoEmailRecipients",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSetMailboxSyncSettingsLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("c347d4a0-4372-495e-82c3-ecc560d34010"),
				Name = "SetMailboxSyncSettings",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSetSettingsNowLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2166d515-b93a-4955-bfdd-c02c9cb0cd12"),
				Name = "SetSettingsNow",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateHaveEmptyRecipientLSLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1a147634-616f-4cb9-ad9d-dea26aa82599"),
				Name = "HaveEmptyRecipientLS",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateAfterSendEmailMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("de2f1b4d-1567-410b-9c27-fb0f6edea1f0"),
				Name = "AfterSendEmailMessage",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("20ce6b83-cf5b-4d35-b133-3520bfa9dcb0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ad5e1575-e647-4f92-b69d-726bdd6c0b75"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e38ec67e-a9ad-4d7b-951e-950b41c38f59"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("f10ca46f-6b64-4a64-9198-177265c2e22b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e38ec67e-a9ad-4d7b-951e-950b41c38f59"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("20a7c111-d676-4f27-9b4e-ea8f55d7471a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("c29724b6-9b3d-4724-9e43-6fe138288e3a"),
				ConditionExpression = @"SaveAsActivity",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(424, 200),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("20a7c111-d676-4f27-9b4e-ea8f55d7471a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f99161b5-174d-4458-b902-774d53a5c9aa"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("5e2dd1d9-6235-4dc1-a458-557f29beecaa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(706, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ea313b97-6f49-4d3e-a4d4-8eea43386101"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("ea139837-0016-4a06-b7ac-cd48f0641ff0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(380, 266),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("20a7c111-d676-4f27-9b4e-ea8f55d7471a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("80c4be13-a698-4c60-8b26-bc7b9b3d7552"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("6f1a94b0-1d89-4feb-94de-35072b7823e1"),
				ConditionExpression = @"IsEmptyList",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(668, 242),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("80c4be13-a698-4c60-8b26-bc7b9b3d7552"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("40ddeb0b-648b-4302-8cdc-0d9a20c46d2e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow7",
				UId = new Guid("a53b264a-0073-4eda-8fb6-59dd8f286a0c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(461, 318),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("80c4be13-a698-4c60-8b26-bc7b9b3d7552"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4a9d2dff-f5ca-4fb9-84a9-7d90e7ead669"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("cc996458-66da-4d9f-adef-1a6e88b87f0d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(672, 266),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("40ddeb0b-648b-4302-8cdc-0d9a20c46d2e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("3b42dc52-26a8-49e0-891d-ba42d7b78d1c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(806, 242),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5f02da6a-695b-4e27-93f5-a8e2c949c1df"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("0390f062-af82-4a4a-ae25-58ff8076c19e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(792, 320),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a445cc20-6b0e-4296-a80d-5afa2f56f798"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow12",
				UId = new Guid("72b93300-931f-4121-ac96-fee23574ff46"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(590, 444),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4a9d2dff-f5ca-4fb9-84a9-7d90e7ead669"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a445cc20-6b0e-4296-a80d-5afa2f56f798"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow6ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow6",
				UId = new Guid("35b9cfe0-75ed-4356-9935-2fc323fc04ae"),
				ConditionExpression = @"HasNextActivity",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(839, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ea313b97-6f49-4d3e-a4d4-8eea43386101"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f99161b5-174d-4458-b902-774d53a5c9aa"),
				TargetSequenceFlowPointLocalPosition = new Point(1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow13",
				UId = new Guid("0c251c22-5e00-46f5-82e9-04394b49d767"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(842, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ea313b97-6f49-4d3e-a4d4-8eea43386101"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5f02da6a-695b-4e27-93f5-a8e2c949c1df"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("0c164e95-8f15-4f6f-b732-a2cc2c24ec36"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(667, 101),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f99161b5-174d-4458-b902-774d53a5c9aa"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow5ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow5",
				UId = new Guid("11a14706-93fe-45b9-aca5-a2fd6c3b91c1"),
				ConditionExpression = @"HaveEmptyRecipient",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(505, 392),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4a9d2dff-f5ca-4fb9-84a9-7d90e7ead669"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow6",
				UId = new Guid("98fea5b2-f316-4641-b8ea-d9253b766c0e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ef267576-b651-4b27-a127-87502a98d2e8"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(730, 372),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5f02da6a-695b-4e27-93f5-a8e2c949c1df"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("d8116aa9-e69a-4119-9c3f-fac8de632b3d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(620, 457),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a445cc20-6b0e-4296-a80d-5afa2f56f798"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"), new Collection<Guid>() {
						new Guid("e41f8bf9-e77e-4c16-a1c1-26f66b94be2e"),
					}},
				}
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow3",
				UId = new Guid("39098ee8-bb67-4e41-8b58-29c56b9b84fa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				CurveCenterPosition = new Point(778, 404),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5f02da6a-695b-4e27-93f5-a8e2c949c1df"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("9ce777dd-5c66-407e-8bd5-f02659287042"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"LaneSet",
				Position = new Point(5, 5),
				Size = new Size(1199, 627),
				UseBackgroundMode = false
			};
			return schemaLaneSet;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("9ce777dd-5c66-407e-8bd5-f02659287042"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(1170, 627),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("ad5e1575-e647-4f92-b69d-726bdd6c0b75"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"Start1",
				Position = new Point(43, 289),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("5f02da6a-695b-4e27-93f5-a8e2c949c1df"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"End1",
				Position = new Point(785, 289),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateGetEmailTemplateDataScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("e38ec67e-a9ad-4d7b-951e-950b41c38f59"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"GetEmailTemplateDataScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(141, 275),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,83,193,106,227,48,16,61,59,144,127,80,123,178,193,136,222,75,15,105,72,137,161,129,80,39,219,195,210,131,26,143,195,176,178,100,70,227,52,166,244,223,119,156,117,211,132,181,193,32,235,233,189,55,79,35,233,96,72,65,101,208,110,160,170,173,97,88,28,97,215,176,39,245,160,28,124,168,199,245,42,247,37,235,185,119,37,238,27,50,140,222,233,197,144,34,190,66,179,34,85,179,29,227,1,94,252,199,154,176,50,212,206,189,109,42,247,203,216,6,82,181,13,64,226,234,64,72,222,37,247,211,201,65,178,212,102,15,82,58,111,3,67,165,95,225,93,47,153,107,225,49,28,37,69,67,4,238,60,46,141,43,44,144,50,225,156,115,155,117,162,142,79,222,6,189,22,187,222,185,130,16,100,182,54,14,172,84,24,17,108,25,45,50,66,208,61,244,3,60,161,43,122,48,238,98,126,51,194,239,187,183,84,221,62,154,0,171,139,26,183,169,98,106,32,81,211,73,52,30,240,252,115,41,149,196,185,57,192,44,156,26,136,220,74,222,193,67,210,215,52,209,97,169,226,155,107,52,153,78,62,37,195,229,254,245,220,130,161,184,107,122,132,101,124,51,108,190,145,19,35,16,36,7,87,128,208,19,213,25,93,59,205,138,162,143,30,191,26,114,232,246,169,10,76,50,234,39,79,149,225,56,7,94,137,253,187,63,230,173,219,201,140,101,49,164,106,0,124,70,247,39,43,18,89,251,103,185,105,107,208,153,43,79,70,253,45,137,34,2,110,200,169,210,216,208,29,110,244,53,157,200,183,148,77,47,170,154,219,23,216,97,141,114,61,70,187,246,63,85,108,178,112,130,158,49,140,11,47,56,162,24,124,5,99,90,225,247,185,187,91,113,255,23,169,151,54,218,120,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateCreateActivityExclusiveGatewayExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("20a7c111-d676-4f27-9b4e-ea8f55d7471a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"CreateActivityExclusiveGateway",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(281, 275),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateOpenEmailCardUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"OpenEmailCardUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(470, 16),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenEmailCardUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareActivitiesScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("f99161b5-174d-4458-b902-774d53a5c9aa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"PrepareActivitiesScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(274, 128),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,221,78,194,48,20,190,55,241,29,154,93,141,100,233,11,160,38,48,16,119,1,146,192,226,117,93,15,216,184,181,203,233,25,178,183,247,172,4,113,131,232,85,155,211,239,175,223,57,40,20,80,41,83,110,161,170,75,69,48,63,66,209,144,67,241,40,230,55,231,202,139,233,122,185,113,59,146,169,179,59,179,111,80,145,113,86,222,132,143,239,239,22,141,209,162,64,224,169,158,20,100,14,134,90,86,191,233,42,211,128,59,195,226,17,243,83,87,85,206,230,100,74,67,6,60,187,214,237,179,41,97,6,196,10,113,238,1,57,136,5,230,56,155,244,83,103,58,25,90,39,34,234,65,34,30,156,223,248,78,216,64,231,250,162,252,10,142,244,111,224,1,46,36,62,112,169,181,218,195,166,248,96,210,82,89,190,119,133,246,163,202,5,80,15,17,71,235,33,41,26,253,238,59,207,228,27,188,179,2,161,43,189,188,66,95,89,179,231,85,14,201,182,153,245,164,108,1,211,118,165,42,136,79,133,204,181,161,78,50,234,190,240,90,131,13,211,84,161,238,114,111,149,255,12,142,121,166,123,178,156,74,255,24,35,203,17,160,103,132,133,47,49,51,225,167,10,219,7,79,104,236,62,17,167,243,41,244,116,193,203,137,214,113,132,80,56,212,153,230,53,12,150,38,183,110,19,136,241,232,239,116,235,223,17,46,250,204,65,160,6,109,216,239,248,27,122,45,226,135,246,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("80c4be13-a698-4c60-8b26-bc7b9b3d7552"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"ExclusiveGateway2",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(386, 275),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("4a9d2dff-f5ca-4fb9-84a9-7d90e7ead669"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"ExclusiveGateway3",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(386, 387),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateShowMessageWindowUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"ShowMessageWindowUserTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(659, 275),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeShowMessageWindowUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateShowMessageWindowScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("40ddeb0b-648b-4302-8cdc-0d9a20c46d2e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"ShowMessageWindowScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(519, 275),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,77,10,194,64,12,133,247,130,119,24,60,192,92,64,92,104,17,29,196,42,214,210,245,216,70,29,172,73,73,82,212,219,59,245,111,103,87,73,94,222,151,71,178,51,221,214,32,226,79,80,4,172,232,150,11,240,222,203,197,110,153,202,184,112,40,234,177,4,87,77,190,109,238,170,241,112,144,253,39,163,100,38,38,123,136,194,213,22,112,176,75,213,38,33,84,184,171,77,90,102,192,95,93,122,172,106,96,227,197,204,182,235,140,142,106,115,215,65,157,159,169,150,215,185,222,60,87,18,198,188,81,49,221,165,46,93,140,122,205,179,86,149,80,58,255,102,213,111,125,143,137,111,52,188,2,10,207,24,240,212,203,124,212,125,252,52,18,41,205,175,62,212,59,40,67,19,226,179,18,89,6,109,25,141,114,11,227,39,165,115,65,250,126,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSendEmailScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a445cc20-6b0e-4296-a80d-5afa2f56f798"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"SendEmailScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(526, 492),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,193,74,3,65,12,134,207,46,236,59,204,113,22,150,121,129,210,67,45,21,4,11,181,91,245,28,119,179,203,192,108,34,153,76,91,21,223,221,78,45,130,176,61,120,10,36,127,190,255,15,217,131,24,28,193,135,29,142,111,1,20,87,71,108,147,178,152,185,177,171,201,1,68,115,187,89,55,220,171,91,50,245,126,72,2,234,153,220,164,188,154,149,133,239,141,189,98,50,55,148,66,168,204,103,89,220,92,203,65,120,248,143,163,253,211,189,239,106,179,104,213,239,113,203,135,141,248,17,228,125,201,33,141,244,12,33,97,109,158,34,202,137,74,120,18,49,229,184,95,101,49,25,197,53,72,221,25,110,179,108,141,49,194,128,59,206,4,247,152,48,102,192,37,239,3,183,16,252,7,188,6,108,84,60,13,54,158,139,187,99,25,65,237,162,87,148,95,222,5,85,79,191,226,231,204,248,2,49,47,96,87,101,119,65,77,66,70,37,225,236,27,45,221,137,54,197,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway4ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ea313b97-6f49-4d3e-a4d4-8eea43386101"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"ExclusiveGateway4",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(666, 128),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateUserQuestionUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"UserQuestionUserTask1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(526, 387),
				SchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserQuestionUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateMessageToUserUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("480456bc-22ec-410c-afd5-04b5d463e98b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8"),
				CreatedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				ModifiedInSchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"),
				Name = @"MessageToUser",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(652, 492),
				SchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				SerializeToDB = true,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeMessageToUserParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("dd4ef74b-6899-4a24-a396-8817df50fb30"),
				Name = "BPMSoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("deeb41a8-b471-4a93-8d93-df578af97b4f"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6af96fc8-192f-40eb-aea8-7b916f1cfa73"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("89a09fc6-622a-4c33-9d06-967f39a54221"),
				Name = "BPMSoft.UI.WebControls.Controls",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5720c369-d846-45b0-8f13-d613072f9534"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendEmailUsingTemplateProcess(userConnection);
		}

		public override object Clone() {
			return new SendEmailUsingTemplateProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0c51a3b-0801-486b-b297-03debeb38ced"));
		}

		#endregion

	}

	#endregion

	#region Class: SendEmailUsingTemplateProcess

	/// <exclude/>
	public class SendEmailUsingTemplateProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendEmailUsingTemplateProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenEmailCardUserTaskFlowElement

		/// <exclude/>
		public class OpenEmailCardUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenEmailCardUserTaskFlowElement(UserConnection userConnection, SendEmailUsingTemplateProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenEmailCardUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("7d7db021-d253-4347-b029-ee9abe9918df");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: ShowMessageWindowUserTaskFlowElement

		/// <exclude/>
		public class ShowMessageWindowUserTaskFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public ShowMessageWindowUserTaskFlowElement(UserConnection userConnection, SendEmailUsingTemplateProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ShowMessageWindowUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("29488d15-6236-42f5-9d6d-1ad63bd28f9a");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: UserQuestionUserTask1FlowElement

		/// <exclude/>
		public class UserQuestionUserTask1FlowElement : UserQuestionUserTask
		{

			#region Constructors: Public

			public UserQuestionUserTask1FlowElement(UserConnection userConnection, SendEmailUsingTemplateProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserQuestionUserTask1";
				IsLogging = false;
				SchemaElementUId = new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private LocalizableString _branchingDecisions;
			public override LocalizableString BranchingDecisions {
				get {
					if (_branchingDecisions == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,143,203,106,195,48,16,69,127,165,136,44,61,65,178,37,89,206,178,9,133,64,90,2,125,108,74,23,35,105,68,77,157,58,88,74,161,9,254,247,202,89,37,20,186,232,110,224,204,189,51,231,196,102,233,123,79,108,193,110,183,247,143,125,72,243,101,63,208,124,59,244,142,98,156,111,122,135,93,123,68,219,209,22,7,220,81,162,225,5,187,3,197,77,27,83,113,115,25,98,5,155,125,157,25,91,188,158,216,58,209,238,121,237,115,179,208,214,40,174,20,216,166,86,32,107,101,1,149,36,112,202,85,166,230,158,155,208,228,240,180,123,98,231,134,28,34,41,130,177,161,1,170,107,2,233,132,6,20,78,64,169,131,214,182,145,150,74,98,99,193,30,242,83,151,185,21,185,54,182,253,39,159,224,18,247,41,207,19,111,227,198,29,207,175,179,69,26,14,148,233,138,194,242,157,220,7,93,29,126,202,144,141,99,113,101,96,92,176,2,57,56,43,2,200,138,43,192,192,61,152,70,16,213,218,155,202,171,95,6,156,28,215,1,37,144,17,2,164,151,8,88,201,18,124,40,101,69,22,57,58,247,151,129,248,175,193,29,118,113,82,120,27,127,0,8,161,2,69,222,1,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "d0c51a3b0801486bb29703debeb38ced",
							"BaseElements.UserQuestionUserTask1.Parameters.BranchingDecisions.Value");
						dataList.LoadLocalizableValues();
						_branchingDecisions = dataList.GetSerializedItems();
						};
					return _branchingDecisions;
				}
				set {
					_branchingDecisions = value;
				}
			}

			private int _decisionMode = 0;
			public override int DecisionMode {
				get {
					return _decisionMode;
				}
				set {
					_decisionMode = value;
				}
			}

			private bool _isDecisionRequired = true;
			public override bool IsDecisionRequired {
				get {
					return _isDecisionRequired;
				}
				set {
					_isDecisionRequired = value;
				}
			}

			private LocalizableString _question;
			public override LocalizableString Question {
				get {
					return _question ?? (_question = GetLocalizableString("d0c51a3b0801486bb29703debeb38ced",
						 "BaseElements.UserQuestionUserTask1.Parameters.Question.Value"));
				}
				set {
					_question = value;
				}
			}

			private LocalizableString _windowCaption;
			public override LocalizableString WindowCaption {
				get {
					return _windowCaption ?? (_windowCaption = GetLocalizableString("d0c51a3b0801486bb29703debeb38ced",
						 "BaseElements.UserQuestionUserTask1.Parameters.WindowCaption.Value"));
				}
				set {
					_windowCaption = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("d0c51a3b0801486bb29703debeb38ced",
						 "BaseElements.UserQuestionUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: MessageToUserFlowElement

		/// <exclude/>
		public class MessageToUserFlowElement : UserQuestionUserTask
		{

			#region Constructors: Public

			public MessageToUserFlowElement(UserConnection userConnection, SendEmailUsingTemplateProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "MessageToUser";
				IsLogging = false;
				SchemaElementUId = new Guid("bcbeb172-8613-4626-909d-54ba685f98a7");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private LocalizableString _branchingDecisions;
			public override LocalizableString BranchingDecisions {
				get {
					if (_branchingDecisions == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,85,142,193,106,195,48,16,68,127,165,44,57,90,70,146,157,200,242,49,14,129,128,91,12,165,189,148,30,36,121,77,69,157,40,72,74,161,49,254,247,202,62,165,183,133,183,111,102,38,216,196,223,43,66,13,251,238,249,213,13,49,111,156,199,188,243,206,96,8,121,235,140,26,237,93,233,17,59,229,213,25,35,250,119,53,222,48,180,54,196,236,233,81,130,12,54,63,43,131,250,99,130,83,196,243,219,169,79,201,146,35,106,198,20,17,149,96,164,44,88,65,100,191,213,132,114,86,113,73,43,228,84,39,121,249,157,96,77,72,210,176,227,148,241,237,34,149,5,41,169,174,136,150,98,71,116,169,11,105,132,48,178,231,48,103,240,146,70,61,122,7,52,54,88,119,161,11,108,212,53,166,123,225,54,180,230,190,78,135,58,250,27,38,122,192,161,249,66,243,141,255,138,143,106,12,8,243,252,57,255,1,199,186,178,89,28,1,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "d0c51a3b0801486bb29703debeb38ced",
							"BaseElements.MessageToUser.Parameters.BranchingDecisions.Value");
						dataList.LoadLocalizableValues();
						_branchingDecisions = dataList.GetSerializedItems();
						};
					return _branchingDecisions;
				}
				set {
					_branchingDecisions = value;
				}
			}

			private int _decisionMode = 0;
			public override int DecisionMode {
				get {
					return _decisionMode;
				}
				set {
					_decisionMode = value;
				}
			}

			private bool _isDecisionRequired = false;
			public override bool IsDecisionRequired {
				get {
					return _isDecisionRequired;
				}
				set {
					_isDecisionRequired = value;
				}
			}

			private LocalizableString _question;
			public override LocalizableString Question {
				get {
					return _question ?? (_question = GetLocalizableString("d0c51a3b0801486bb29703debeb38ced",
						 "BaseElements.MessageToUser.Parameters.Question.Value"));
				}
				set {
					_question = value;
				}
			}

			private LocalizableString _windowCaption;
			public override LocalizableString WindowCaption {
				get {
					return _windowCaption ?? (_windowCaption = GetLocalizableString("d0c51a3b0801486bb29703debeb38ced",
						 "BaseElements.MessageToUser.Parameters.WindowCaption.Value"));
				}
				set {
					_windowCaption = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("d0c51a3b0801486bb29703debeb38ced",
						 "BaseElements.MessageToUser.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			#endregion

		}

		#endregion

		public SendEmailUsingTemplateProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendEmailUsingTemplateProcess";
			SchemaUId = new Guid("d0c51a3b-0801-486b-b297-03debeb38ced");
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
				return new Guid("d0c51a3b-0801-486b-b297-03debeb38ced");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendEmailUsingTemplateProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendEmailUsingTemplateProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Guid EmailTemplateId {
			get;
			set;
		}

		public virtual bool SaveAsActivity {
			get;
			set;
		}

		public virtual Guid ActiveRowPrimaryColumnValue {
			get;
			set;
		}

		public virtual Object EmailTemplateExecutor {
			get;
			set;
		}

		public virtual Object MessagePanel {
			get;
			set;
		}

		public virtual bool HaveEmptyRecipient {
			get;
			set;
		}

		public virtual bool IsEmptyList {
			get;
			set;
		}

		public virtual bool HasNextActivity {
			get;
			set;
		}

		public virtual Guid MailboxSyncSettingsLinkId {
			get;
			set;
		}

		private LocalizableString _messageAfterSend;
		public virtual LocalizableString MessageAfterSend {
			get {
				return _messageAfterSend ?? (_messageAfterSend = new LocalizableString());
			}
			set {
				_messageAfterSend = value;
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
					SchemaElementUId = new Guid("ad5e1575-e647-4f92-b69d-726bdd6c0b75"),
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
					SchemaElementUId = new Guid("5f02da6a-695b-4e27-93f5-a8e2c949c1df"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _getEmailTemplateDataScriptTask;
		public ProcessScriptTask GetEmailTemplateDataScriptTask {
			get {
				return _getEmailTemplateDataScriptTask ?? (_getEmailTemplateDataScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GetEmailTemplateDataScriptTask",
					SchemaElementUId = new Guid("e38ec67e-a9ad-4d7b-951e-950b41c38f59"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = GetEmailTemplateDataScriptTaskExecute,
				});
			}
		}

		private ProcessExclusiveGateway _createActivityExclusiveGateway;
		public ProcessExclusiveGateway CreateActivityExclusiveGateway {
			get {
				return _createActivityExclusiveGateway ?? (_createActivityExclusiveGateway = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "CreateActivityExclusiveGateway",
					SchemaElementUId = new Guid("20a7c111-d676-4f27-9b4e-ea8f55d7471a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.CreateActivityExclusiveGateway.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private OpenEmailCardUserTaskFlowElement _openEmailCardUserTask;
		public OpenEmailCardUserTaskFlowElement OpenEmailCardUserTask {
			get {
				return _openEmailCardUserTask ?? (_openEmailCardUserTask = new OpenEmailCardUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _prepareActivitiesScriptTask;
		public ProcessScriptTask PrepareActivitiesScriptTask {
			get {
				return _prepareActivitiesScriptTask ?? (_prepareActivitiesScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareActivitiesScriptTask",
					SchemaElementUId = new Guid("f99161b5-174d-4458-b902-774d53a5c9aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = PrepareActivitiesScriptTaskExecute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway2;
		public ProcessExclusiveGateway ExclusiveGateway2 {
			get {
				return _exclusiveGateway2 ?? (_exclusiveGateway2 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway2",
					SchemaElementUId = new Guid("80c4be13-a698-4c60-8b26-bc7b9b3d7552"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway2.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway3;
		public ProcessExclusiveGateway ExclusiveGateway3 {
			get {
				return _exclusiveGateway3 ?? (_exclusiveGateway3 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway3",
					SchemaElementUId = new Guid("4a9d2dff-f5ca-4fb9-84a9-7d90e7ead669"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway3.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ShowMessageWindowUserTaskFlowElement _showMessageWindowUserTask;
		public ShowMessageWindowUserTaskFlowElement ShowMessageWindowUserTask {
			get {
				return _showMessageWindowUserTask ?? (_showMessageWindowUserTask = new ShowMessageWindowUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _showMessageWindowScriptTask;
		public ProcessScriptTask ShowMessageWindowScriptTask {
			get {
				return _showMessageWindowScriptTask ?? (_showMessageWindowScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ShowMessageWindowScriptTask",
					SchemaElementUId = new Guid("40ddeb0b-648b-4302-8cdc-0d9a20c46d2e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ShowMessageWindowScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _sendEmailScriptTask;
		public ProcessScriptTask SendEmailScriptTask {
			get {
				return _sendEmailScriptTask ?? (_sendEmailScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendEmailScriptTask",
					SchemaElementUId = new Guid("a445cc20-6b0e-4296-a80d-5afa2f56f798"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SendEmailScriptTaskExecute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway4;
		public ProcessExclusiveGateway ExclusiveGateway4 {
			get {
				return _exclusiveGateway4 ?? (_exclusiveGateway4 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway4",
					SchemaElementUId = new Guid("ea313b97-6f49-4d3e-a4d4-8eea43386101"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway4.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private UserQuestionUserTask1FlowElement _userQuestionUserTask1;
		public UserQuestionUserTask1FlowElement UserQuestionUserTask1 {
			get {
				return _userQuestionUserTask1 ?? (_userQuestionUserTask1 = new UserQuestionUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private MessageToUserFlowElement _messageToUser;
		public MessageToUserFlowElement MessageToUser {
			get {
				return _messageToUser ?? (_messageToUser = new MessageToUserFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("c29724b6-9b3d-4724-9e43-6fe138288e3a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow3;
		public ProcessConditionalFlow ConditionalFlow3 {
			get {
				return _conditionalFlow3 ?? (_conditionalFlow3 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow3",
					SchemaElementUId = new Guid("6f1a94b0-1d89-4feb-94de-35072b7823e1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow6;
		public ProcessConditionalFlow ConditionalFlow6 {
			get {
				return _conditionalFlow6 ?? (_conditionalFlow6 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow6",
					SchemaElementUId = new Guid("35b9cfe0-75ed-4356-9935-2fc323fc04ae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow5;
		public ProcessConditionalFlow ConditionalFlow5 {
			get {
				return _conditionalFlow5 ?? (_conditionalFlow5 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow5",
					SchemaElementUId = new Guid("11a14706-93fe-45b9-aca5-a2fd6c3b91c1"),
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
					SchemaElementUId = new Guid("d8116aa9-e69a-4119-9c3f-fac8de632b3d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a"), new Collection<Guid>() {
							new Guid("e41f8bf9-e77e-4c16-a1c1-26f66b94be2e"),
						}},
					},
				});
			}
		}

		private LocalizableString _warning;
		public LocalizableString Warning {
			get {
				return _warning ?? (_warning = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.Warning.Value"));
			}
		}

		private LocalizableString _noEmailRecipients;
		public LocalizableString NoEmailRecipients {
			get {
				return _noEmailRecipients ?? (_noEmailRecipients = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NoEmailRecipients.Value"));
			}
		}

		private LocalizableString _setMailboxSyncSettings;
		public LocalizableString SetMailboxSyncSettings {
			get {
				return _setMailboxSyncSettings ?? (_setMailboxSyncSettings = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.SetMailboxSyncSettings.Value"));
			}
		}

		private LocalizableString _setSettingsNow;
		public LocalizableString SetSettingsNow {
			get {
				return _setSettingsNow ?? (_setSettingsNow = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.SetSettingsNow.Value"));
			}
		}

		private LocalizableString _haveEmptyRecipientLS;
		public LocalizableString HaveEmptyRecipientLS {
			get {
				return _haveEmptyRecipientLS ?? (_haveEmptyRecipientLS = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.HaveEmptyRecipientLS.Value"));
			}
		}

		private LocalizableString _afterSendEmailMessage;
		public LocalizableString AfterSendEmailMessage {
			get {
				return _afterSendEmailMessage ?? (_afterSendEmailMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AfterSendEmailMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[GetEmailTemplateDataScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GetEmailTemplateDataScriptTask };
			FlowElements[CreateActivityExclusiveGateway.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateActivityExclusiveGateway };
			FlowElements[OpenEmailCardUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenEmailCardUserTask };
			FlowElements[PrepareActivitiesScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareActivitiesScriptTask };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
			FlowElements[ShowMessageWindowUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageWindowUserTask };
			FlowElements[ShowMessageWindowScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ShowMessageWindowScriptTask };
			FlowElements[SendEmailScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailScriptTask };
			FlowElements[ExclusiveGateway4.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway4 };
			FlowElements[UserQuestionUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { UserQuestionUserTask1 };
			FlowElements[MessageToUser.SchemaElementUId] = new Collection<ProcessFlowElement> { MessageToUser };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GetEmailTemplateDataScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "GetEmailTemplateDataScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateActivityExclusiveGateway", e.Context.SenderName));
						break;
					case "CreateActivityExclusiveGateway":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareActivitiesScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "OpenEmailCardUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway4", e.Context.SenderName));
						break;
					case "PrepareActivitiesScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenEmailCardUserTask", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageWindowScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalFlow5ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserQuestionUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailScriptTask", e.Context.SenderName));
						break;
					case "ShowMessageWindowUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "ShowMessageWindowScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ShowMessageWindowUserTask", e.Context.SenderName));
						break;
					case "SendEmailScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("MessageToUser", e.Context.SenderName));
						break;
					case "ExclusiveGateway4":
						if (ConditionalFlow6ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareActivitiesScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "UserQuestionUserTask1":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "MessageToUser":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(SaveAsActivity);
			Log.InfoFormat(ConditionalExpressionLogMessage, "CreateActivityExclusiveGateway", "ConditionalFlow1", "SaveAsActivity", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean(IsEmptyList);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalFlow3", "IsEmptyList", result);
			return result;
		}

		private bool ConditionalFlow6ExpressionExecute() {
			bool result = Convert.ToBoolean(HasNextActivity);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway4", "ConditionalFlow6", "HasNextActivity", result);
			return result;
		}

		private bool ConditionalFlow5ExpressionExecute() {
			bool result = Convert.ToBoolean(HaveEmptyRecipient);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalFlow5", "HaveEmptyRecipient", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow2.ProcessActivitiesSelectedResults[new Guid("c52e9692-50c3-48b3-8e63-0e41de1f378a")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "UserQuestionUserTask1", "ConditionalFlow2", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalFlow2.ProcessActivitiesSelectedResults[new Guid(\"c52e9692-50c3-48b3-8e63-0e41de1f378a\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("EmailTemplateId")) {
				writer.WriteValue("EmailTemplateId", EmailTemplateId, Guid.Empty);
			}
			if (!HasMapping("SaveAsActivity")) {
				writer.WriteValue("SaveAsActivity", SaveAsActivity, false);
			}
			if (!HasMapping("ActiveRowPrimaryColumnValue")) {
				writer.WriteValue("ActiveRowPrimaryColumnValue", ActiveRowPrimaryColumnValue, Guid.Empty);
			}
			if (EmailTemplateExecutor != null) {
				if (EmailTemplateExecutor.GetType().IsSerializable ||
					EmailTemplateExecutor.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("EmailTemplateExecutor", EmailTemplateExecutor, null);
				}
			}
			if (MessagePanel != null) {
				if (MessagePanel.GetType().IsSerializable ||
					MessagePanel.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("MessagePanel", MessagePanel, null);
				}
			}
			if (!HasMapping("HaveEmptyRecipient")) {
				writer.WriteValue("HaveEmptyRecipient", HaveEmptyRecipient, false);
			}
			if (!HasMapping("IsEmptyList")) {
				writer.WriteValue("IsEmptyList", IsEmptyList, false);
			}
			if (!HasMapping("HasNextActivity")) {
				writer.WriteValue("HasNextActivity", HasNextActivity, false);
			}
			if (!HasMapping("MailboxSyncSettingsLinkId")) {
				writer.WriteValue("MailboxSyncSettingsLinkId", MailboxSyncSettingsLinkId, Guid.Empty);
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
			MetaPathParameterValues.Add("b0d75fc7-0242-4088-89b7-66814178129b", () => EmailTemplateId);
			MetaPathParameterValues.Add("7128f6a5-f738-4c89-bc19-e25816dbe4be", () => SaveAsActivity);
			MetaPathParameterValues.Add("e9cb394d-660c-4148-9a94-9771d98a5f8d", () => ActiveRowPrimaryColumnValue);
			MetaPathParameterValues.Add("2e80c981-5668-48d8-bf13-e97cd963cddf", () => EmailTemplateExecutor);
			MetaPathParameterValues.Add("bd3ff53c-edd8-49c4-bd37-bb3db9434971", () => MessagePanel);
			MetaPathParameterValues.Add("5f0da840-e783-4500-b814-b8ca6f0ef3a0", () => HaveEmptyRecipient);
			MetaPathParameterValues.Add("ee2a178d-7c76-4f37-a0ed-97361c8af636", () => IsEmptyList);
			MetaPathParameterValues.Add("09d8fb2b-85c6-4a87-91ef-c8e14bf0ad99", () => HasNextActivity);
			MetaPathParameterValues.Add("94c0e53d-f908-49dd-8961-4b496f1898c7", () => MailboxSyncSettingsLinkId);
			MetaPathParameterValues.Add("e709de1a-6466-49d6-bd5b-b8cca1569c23", () => MessageAfterSend);
			MetaPathParameterValues.Add("2ad2ae58-848d-466d-89f1-ba26a454c813", () => OpenEmailCardUserTask.PageUId);
			MetaPathParameterValues.Add("9ae4f72d-35af-4eed-b669-9e385b7dadd0", () => OpenEmailCardUserTask.PageUrl);
			MetaPathParameterValues.Add("01d5dd6b-d2f3-4f37-bcae-dd06f02c663b", () => OpenEmailCardUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("6106915a-7272-4224-af0f-9e424058c406", () => OpenEmailCardUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("bacab600-93bc-4c8d-b5fa-5f7c5ca0a954", () => OpenEmailCardUserTask.PageParameters);
			MetaPathParameterValues.Add("067c2f40-0e65-4eb2-aa1f-78a94885471e", () => OpenEmailCardUserTask.Width);
			MetaPathParameterValues.Add("1218d0e3-703a-444e-a248-3a8a3d13f328", () => OpenEmailCardUserTask.CloseMessage);
			MetaPathParameterValues.Add("6298157d-b97e-41dc-83c9-60d25d1dc8bf", () => OpenEmailCardUserTask.Height);
			MetaPathParameterValues.Add("d70540d4-0967-4889-9e05-107c74224ad5", () => OpenEmailCardUserTask.Centered);
			MetaPathParameterValues.Add("b5a356f0-c239-4f78-b884-54a3194e3460", () => OpenEmailCardUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("6b46040f-e793-4562-8671-c91e66aac4ed", () => OpenEmailCardUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("488e9b78-424d-4af9-8569-357b2f048617", () => OpenEmailCardUserTask.IgnoreProfile);
			MetaPathParameterValues.Add("5d123519-361b-4cc7-9b26-d440757daefe", () => ShowMessageWindowUserTask.Page);
			MetaPathParameterValues.Add("e9a76bf3-30f5-4536-938b-87bcd99a9348", () => ShowMessageWindowUserTask.Icon);
			MetaPathParameterValues.Add("c9c687fd-e109-47df-b719-555727bd75d0", () => ShowMessageWindowUserTask.Buttons);
			MetaPathParameterValues.Add("e5288b50-aeb3-40b2-9535-d10bdbd06f38", () => ShowMessageWindowUserTask.WindowCaption);
			MetaPathParameterValues.Add("1ed98530-fbef-47ac-9c61-fbdfbeb7bf6f", () => ShowMessageWindowUserTask.MessageText);
			MetaPathParameterValues.Add("9499dd19-c3ce-40d2-954d-9b01c15e0ffd", () => ShowMessageWindowUserTask.ResponseMessages);
			MetaPathParameterValues.Add("3a8b275d-5e6f-4669-bd8c-807c437fef53", () => ShowMessageWindowUserTask.ProcessInstanceId);
			MetaPathParameterValues.Add("a89345ca-3709-4404-9858-f550886f6ad4", () => ShowMessageWindowUserTask.PageParameters);
			MetaPathParameterValues.Add("c90d19a7-f600-48e8-8385-91e0a35cb189", () => UserQuestionUserTask1.BranchingDecisions);
			MetaPathParameterValues.Add("abb01b39-e2e0-4ade-8896-1ee4ec37837d", () => UserQuestionUserTask1.ResultDecisions);
			MetaPathParameterValues.Add("317ea3aa-e0f6-41b1-b281-1504827c4800", () => UserQuestionUserTask1.DecisionMode);
			MetaPathParameterValues.Add("dd8c89f0-87b7-4ff2-bda0-23066f538dc8", () => UserQuestionUserTask1.IsDecisionRequired);
			MetaPathParameterValues.Add("74be3c5e-f0fb-439a-a2c6-fe18128c490f", () => UserQuestionUserTask1.Question);
			MetaPathParameterValues.Add("f1d7cf7a-70ea-43ab-bf19-2b98e3fdcebd", () => UserQuestionUserTask1.WindowCaption);
			MetaPathParameterValues.Add("b11b59fe-f02e-4f00-8920-6bbd8620a8ed", () => UserQuestionUserTask1.Recommendation);
			MetaPathParameterValues.Add("2bb6b709-4430-43ba-9c03-0ac095965f83", () => UserQuestionUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("10f30bc8-8525-4947-b49d-725777c3debc", () => UserQuestionUserTask1.OwnerId);
			MetaPathParameterValues.Add("89f805c6-65cb-4930-a051-8d4f9214ea07", () => UserQuestionUserTask1.Duration);
			MetaPathParameterValues.Add("be3a8ead-7371-4b9d-b87a-c19a6f4d3107", () => UserQuestionUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("a31e7e65-feee-481e-9a55-08640dcca1f7", () => UserQuestionUserTask1.StartIn);
			MetaPathParameterValues.Add("614ab8f5-c81a-45ff-8497-3dd24309c148", () => UserQuestionUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("aff41918-85a1-4ff7-bef7-49661ec076e2", () => UserQuestionUserTask1.RemindBefore);
			MetaPathParameterValues.Add("41f6f394-b829-4163-ba39-113fc778920c", () => UserQuestionUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("4ccd06c0-32f7-426a-a23a-5a6c473d27e1", () => UserQuestionUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("9967fe17-6e9c-4fc8-832f-17ce3d92f13c", () => UserQuestionUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("9c00708c-01a0-4f67-8804-a2fa71ba9498", () => UserQuestionUserTask1.Lead);
			MetaPathParameterValues.Add("35bf2807-792d-4d13-ae8d-4e19b9b08b3c", () => UserQuestionUserTask1.Account);
			MetaPathParameterValues.Add("caaaa922-90dc-448d-92b3-4f896e10390e", () => UserQuestionUserTask1.Contact);
			MetaPathParameterValues.Add("73d44222-3511-4efb-a983-8f1d6c93a4c1", () => UserQuestionUserTask1.Opportunity);
			MetaPathParameterValues.Add("0e27af8f-095f-498f-9a07-f1a0f0641b32", () => UserQuestionUserTask1.Invoice);
			MetaPathParameterValues.Add("46033570-c17f-4d83-b047-070223debf80", () => UserQuestionUserTask1.Document);
			MetaPathParameterValues.Add("cc24269d-27b6-4e23-821a-8a38c52aac15", () => UserQuestionUserTask1.Incident);
			MetaPathParameterValues.Add("801ed6fb-cac9-4c18-bab5-595b1300a209", () => UserQuestionUserTask1.Case);
			MetaPathParameterValues.Add("d57eb5c5-9ece-481a-bd84-7d84a3f8642e", () => UserQuestionUserTask1.ActivityResult);
			MetaPathParameterValues.Add("c6073f6d-6d7f-44ae-8a4b-42ee70a64ce7", () => UserQuestionUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("fd6db9ee-84df-434a-a179-9bd01fe0fe41", () => UserQuestionUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("dda3b1f3-0ce1-4418-b160-3f2effc18c79", () => UserQuestionUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("92033d7f-e7e1-4f99-8211-16c61e9c81a2", () => UserQuestionUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("f135b7e5-ecfb-49a8-8cfb-8990063d4713", () => UserQuestionUserTask1.Order);
			MetaPathParameterValues.Add("1796c06a-1878-42cd-9fb0-67535f3e8fb5", () => UserQuestionUserTask1.Requests);
			MetaPathParameterValues.Add("2c9eba00-9fbf-411e-b360-3f67ff750de2", () => UserQuestionUserTask1.Listing);
			MetaPathParameterValues.Add("ca966398-a970-40f1-a35e-b8ed082fb444", () => UserQuestionUserTask1.Property);
			MetaPathParameterValues.Add("97edaefe-9346-4ff5-8d4d-59aa889b243d", () => UserQuestionUserTask1.Contract);
			MetaPathParameterValues.Add("de7aae6a-08f3-4c8a-aec0-b8145472b8a5", () => UserQuestionUserTask1.Project);
			MetaPathParameterValues.Add("5c03fbe7-4dd0-443b-b395-bd582d40b3d3", () => UserQuestionUserTask1.Problem);
			MetaPathParameterValues.Add("c1609f0c-da91-443f-8631-1f360ab9dd2b", () => UserQuestionUserTask1.Change);
			MetaPathParameterValues.Add("68e92442-0b7d-4ae0-8ce4-d1c35d6e0890", () => UserQuestionUserTask1.Release);
			MetaPathParameterValues.Add("9804b757-b455-46cb-a644-8ba4ad7de497", () => UserQuestionUserTask1.CreateActivity);
			MetaPathParameterValues.Add("0d26149b-65d5-4044-8cbb-5494b212f2b7", () => UserQuestionUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("b60b849c-eb5f-42a1-8986-3bd02a52bb13", () => MessageToUser.BranchingDecisions);
			MetaPathParameterValues.Add("b36ce965-8a18-4276-a3ac-d82f6185fd3b", () => MessageToUser.ResultDecisions);
			MetaPathParameterValues.Add("8f593c0e-abdd-4602-8419-de73b6b46ec7", () => MessageToUser.DecisionMode);
			MetaPathParameterValues.Add("9353eef2-6160-492c-922b-3668d47ffd14", () => MessageToUser.IsDecisionRequired);
			MetaPathParameterValues.Add("e12e5781-8d70-48b0-b200-b89e3c92d5ee", () => MessageToUser.Question);
			MetaPathParameterValues.Add("355cb365-54c0-4b80-84a9-32be527326fe", () => MessageToUser.WindowCaption);
			MetaPathParameterValues.Add("67cd3f7e-a364-47aa-be34-d46b64479882", () => MessageToUser.Recommendation);
			MetaPathParameterValues.Add("09ebfc70-0058-47cd-9598-caf3d40c3ca7", () => MessageToUser.ActivityCategory);
			MetaPathParameterValues.Add("fc33576f-5dd6-4d3c-bb29-ab5e58b4beb4", () => MessageToUser.OwnerId);
			MetaPathParameterValues.Add("8ee1c52d-5363-44dd-8cc0-c6386afd4863", () => MessageToUser.Duration);
			MetaPathParameterValues.Add("3374d938-f7e9-418e-b09d-791666bb21de", () => MessageToUser.DurationPeriod);
			MetaPathParameterValues.Add("2049708b-d019-4f52-bd18-3d0348409bc4", () => MessageToUser.StartIn);
			MetaPathParameterValues.Add("488987df-2cfe-4fe6-b1fd-2018761c2729", () => MessageToUser.StartInPeriod);
			MetaPathParameterValues.Add("15a4611a-cee7-4905-a893-814b5638f46f", () => MessageToUser.RemindBefore);
			MetaPathParameterValues.Add("c178eb4f-a737-4300-8c26-4296e8db880f", () => MessageToUser.RemindBeforePeriod);
			MetaPathParameterValues.Add("f81f56c5-79ae-444c-8139-3f97bb7ff777", () => MessageToUser.ShowInScheduler);
			MetaPathParameterValues.Add("8d89ba5b-ed07-41d5-a512-8bfd56f4b899", () => MessageToUser.ShowExecutionPage);
			MetaPathParameterValues.Add("7e05c262-a8db-4f6f-b30d-e548761b1a59", () => MessageToUser.Lead);
			MetaPathParameterValues.Add("36be22dc-915a-4e7d-adfa-65806f3e3a7f", () => MessageToUser.Account);
			MetaPathParameterValues.Add("ca419b05-508b-4ad8-b709-a48d5fc61cfc", () => MessageToUser.Contact);
			MetaPathParameterValues.Add("791cb414-5bb0-414b-969d-1f35a04dc39c", () => MessageToUser.Opportunity);
			MetaPathParameterValues.Add("15dbb192-c2fa-4fed-b9de-96eb773e620c", () => MessageToUser.Invoice);
			MetaPathParameterValues.Add("720bd101-34cd-42a8-81e7-1c18a56796ee", () => MessageToUser.Document);
			MetaPathParameterValues.Add("537fa6aa-b2da-48e0-ad5a-2a6de9941cb3", () => MessageToUser.Incident);
			MetaPathParameterValues.Add("785c2902-1b60-4f05-b62d-279dbe6c7c43", () => MessageToUser.Case);
			MetaPathParameterValues.Add("7e0a85af-7cd8-4572-81dd-95606d64ec4c", () => MessageToUser.ActivityResult);
			MetaPathParameterValues.Add("3dfbbe33-93f5-45f4-856d-db9ca77c2b13", () => MessageToUser.CurrentActivityId);
			MetaPathParameterValues.Add("0bec513a-b941-42c6-967d-a6753abef9b1", () => MessageToUser.IsActivityCompleted);
			MetaPathParameterValues.Add("d67f399b-8d1c-4142-a33c-e57f0e5c1377", () => MessageToUser.ExecutionContext);
			MetaPathParameterValues.Add("e17a820b-be52-4c54-bd90-edf7ade293b1", () => MessageToUser.InformationOnStep);
			MetaPathParameterValues.Add("7d13f292-4621-4055-b41e-167c271e6b9e", () => MessageToUser.Order);
			MetaPathParameterValues.Add("e8eea506-c22a-468b-9c18-d47baf0d4744", () => MessageToUser.Requests);
			MetaPathParameterValues.Add("4c456705-e036-495c-80c0-9e229f3a7833", () => MessageToUser.Listing);
			MetaPathParameterValues.Add("00ed305e-b753-4628-80e0-02166ecc5d7e", () => MessageToUser.Property);
			MetaPathParameterValues.Add("e957e8fc-5fb0-420e-8627-2ab978ef1ba2", () => MessageToUser.Contract);
			MetaPathParameterValues.Add("e532f458-4be7-4068-8d9c-3c0b7ab8de79", () => MessageToUser.Project);
			MetaPathParameterValues.Add("53fb23dc-abef-4f7c-b3df-9148bafb7033", () => MessageToUser.Problem);
			MetaPathParameterValues.Add("d749cf73-b4be-453f-b207-bf8cd4b753c3", () => MessageToUser.Change);
			MetaPathParameterValues.Add("3175c7fa-3ccc-4328-aa0b-34b313616ac7", () => MessageToUser.Release);
			MetaPathParameterValues.Add("2750141a-9a9f-4f34-a209-dcd6edab0e3e", () => MessageToUser.CreateActivity);
			MetaPathParameterValues.Add("2a1029da-a16c-47e0-a6c6-6271d39fdc5b", () => MessageToUser.ActivityPriority);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "EmailTemplateId":
					if (!hasValueToRead) break;
					EmailTemplateId = reader.GetValue<System.Guid>();
				break;
				case "SaveAsActivity":
					if (!hasValueToRead) break;
					SaveAsActivity = reader.GetValue<System.Boolean>();
				break;
				case "ActiveRowPrimaryColumnValue":
					if (!hasValueToRead) break;
					ActiveRowPrimaryColumnValue = reader.GetValue<System.Guid>();
				break;
				case "EmailTemplateExecutor":
					if (!hasValueToRead) break;
					EmailTemplateExecutor = reader.GetSerializableObjectValue();
				break;
				case "MessagePanel":
					if (!hasValueToRead) break;
					MessagePanel = reader.GetSerializableObjectValue();
				break;
				case "HaveEmptyRecipient":
					if (!hasValueToRead) break;
					HaveEmptyRecipient = reader.GetValue<System.Boolean>();
				break;
				case "IsEmptyList":
					if (!hasValueToRead) break;
					IsEmptyList = reader.GetValue<System.Boolean>();
				break;
				case "HasNextActivity":
					if (!hasValueToRead) break;
					HasNextActivity = reader.GetValue<System.Boolean>();
				break;
				case "MailboxSyncSettingsLinkId":
					if (!hasValueToRead) break;
					MailboxSyncSettingsLinkId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool GetEmailTemplateDataScriptTaskExecute(ProcessExecutingContext context) {
			var emailTemplateExecutor = new BPMSoft.Configuration.EmailTemplateExecutor(EmailTemplateId, ActiveRowPrimaryColumnValue, UserConnection);
			var page = System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page;
			var messagePanel = BPMSoft.UI.WebControls.Utilities.ControlUtilities.FindControl(page.Controls[0], "BaseMessagePanel", true) 
				as BPMSoft.UI.WebControls.Controls.MessagePanel;
			SaveAsActivity = emailTemplateExecutor.SaveAsActivity;
			if (!SaveAsActivity)
			{
				messagePanel.Clear();
				if(!emailTemplateExecutor.TryCreateSender()) {
					messagePanel.AddMessage(Warning, string.Format(SetMailboxSyncSettings, MailboxSyncSettingsLinkId), MessageType.Information);
					return false;
				}
			}
			HaveEmptyRecipient = emailTemplateExecutor.HaveEmptyRecipient;
			IsEmptyList = emailTemplateExecutor.IsEmptyList;
			EmailTemplateExecutor = emailTemplateExecutor;
			return true;
		}

		public virtual bool PrepareActivitiesScriptTaskExecute(ProcessExecutingContext context) {
			var emailTemplateExecutor = EmailTemplateExecutor as BPMSoft.Configuration.EmailTemplateExecutor;
			Guid createdActivity = emailTemplateExecutor.CreateActivity();
			CommonUtilities.CopyFileDetail(UserConnection, EmailTemplateId, createdActivity, "EmailTemplate", "Activity", true);
			HasNextActivity = emailTemplateExecutor.HasNextActivity();
			var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as BPMSoft.UI.WebControls.PageSchemaManager;
			var pageSchema = pageSchemaManager.GetInstanceByName("EmailEditPage");
			OpenEmailCardUserTask.PageUId = pageSchema.UId;
			var parameters = new Dictionary<string, string>();
			parameters.Add("recordId", createdActivity.ToString());
			OpenEmailCardUserTask.PageParameters = parameters;
			return true;
		}

		public virtual bool ShowMessageWindowScriptTaskExecute(ProcessExecutingContext context) {
			ShowMessageWindowUserTask.ProcessInstanceId=InstanceUId;
			ShowMessageWindowUserTask.Page = System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page;
			ShowMessageWindowUserTask.Icon = "WARNING";
			ShowMessageWindowUserTask.Buttons = "OK";
			ShowMessageWindowUserTask.WindowCaption = Warning;
			ShowMessageWindowUserTask.MessageText = NoEmailRecipients;
			return true;
		}

		public virtual bool SendEmailScriptTaskExecute(ProcessExecutingContext context) {
			var emailTemplateExecutor = (EmailTemplateExecutor as BPMSoft.Configuration.EmailTemplateExecutor);
			if (emailTemplateExecutor == null) {
				emailTemplateExecutor = new BPMSoft.Configuration.EmailTemplateExecutor(EmailTemplateId, ActiveRowPrimaryColumnValue, UserConnection);
			}
			emailTemplateExecutor.SendEmail();
			MessageToUser.Question = new LocalizableString(string.Format(AfterSendEmailMessage, emailTemplateExecutor.EmailsWasSended));
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
			var cloneItem = (SendEmailUsingTemplateProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.EmailTemplateExecutor = EmailTemplateExecutor;
			cloneItem.MessagePanel = MessagePanel;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

