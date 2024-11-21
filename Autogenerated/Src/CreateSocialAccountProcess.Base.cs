namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Social;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: CreateSocialAccountProcessSchema

	/// <exclude/>
	public class CreateSocialAccountProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CreateSocialAccountProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CreateSocialAccountProcessSchema(CreateSocialAccountProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CreateSocialAccountProcess";
			UId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
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
			RealUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateNewSocialAccountIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f263dd85-d3cd-4c40-b168-ae8daff43524"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"NewSocialAccountId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b1d146ff-40e8-4a5d-8b94-206a62e7f944"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialNetworkParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4e3fdba2-8339-42ed-860d-a7d96d66d755"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"SocialNetwork",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateApplyAccountPublicLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bce9a8f0-f858-4156-8a65-8715d4c703dc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ApplyAccountPublicLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateNewSocialAccountIdParameter());
			Parameters.Add(CreatePageParameter());
			Parameters.Add(CreateSocialNetworkParameter());
			Parameters.Add(CreateApplyAccountPublicLSParameter());
		}

		protected virtual void InitializeOpenMessageWindowParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ffaca191-2916-4e64-80ef-3d900be58e07"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("0c05c81a-1734-431a-88b8-61dc5472c229"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("68b45479-94c9-49fb-8c83-4703bccc4fcd"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("559e2e0e-1702-4631-8932-e2df756aa0c6"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("34aec6b7-5646-46a9-b104-d0fda1835eab"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("3348ed5e-3ee7-4dc4-8334-1f5ad4953e28"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("a0058817-6d78-4f09-bad5-d0162d5a9dfa"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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
				UId = new Guid("751da741-9f8e-4532-a1a1-f34181368335"),
				ContainerUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
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

		protected virtual void InitializeCreateSocialAccountUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var userIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1000931d-1c32-448b-ba0e-c66614e147a8"),
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"UserId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			userIdParameter.SourceValue = new ProcessSchemaParameterValue(userIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(userIdParameter);
			var socialNetworkParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a7b8a6fa-cf86-4400-90f5-45a23bd10537"),
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"SocialNetwork",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			socialNetworkParameter.SourceValue = new ProcessSchemaParameterValue(socialNetworkParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(socialNetworkParameter);
			var openerPageIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("96037c02-c530-4081-ab43-d03411c92f27"),
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"OpenerPageId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			openerPageIdParameter.SourceValue = new ProcessSchemaParameterValue(openerPageIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(openerPageIdParameter);
			var successEventNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("af330e9a-f3cb-4089-83f8-c51d5ecdc938"),
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"SuccessEventName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			successEventNameParameter.SourceValue = new ProcessSchemaParameterValue(successEventNameParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25")
			};
			parametrizedElement.Parameters.Add(successEventNameParameter);
			var failedEventNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fdbe7b1a-f0fd-4541-b4fd-f3aa818a61e4"),
				ContainerUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				Name = @"FailedEventName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			failedEventNameParameter.SourceValue = new ProcessSchemaParameterValue(failedEventNameParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25")
			};
			parametrizedElement.Parameters.Add(failedEventNameParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaEventSubProcess eventsubprocess2 = CreateEventSubProcess2EventSubProcess();
			FlowElements.Add(eventsubprocess2);
			ProcessSchemaEventSubProcess eventsubprocess3 = CreateEventSubProcess3EventSubProcess();
			FlowElements.Add(eventsubprocess3);
			ProcessSchemaEventSubProcess eventsubprocess4 = CreateEventSubProcess4EventSubProcess();
			FlowElements.Add(eventsubprocess4);
			ProcessSchemaStartMessageEvent socialaccountcreatedsuccessfullyeventstartmessage = CreateSocialAccountCreatedSuccessfullyEventStartMessageStartMessageEvent();
			eventsubprocess2.FlowElements.Add(socialaccountcreatedsuccessfullyeventstartmessage);
			ProcessSchemaScriptTask scripttask6 = CreateScriptTask6ScriptTask();
			eventsubprocess2.FlowElements.Add(scripttask6);
			ProcessSchemaUserTask openmessagewindow = CreateOpenMessageWindowUserTask();
			eventsubprocess2.FlowElements.Add(openmessagewindow);
			ProcessSchemaStartMessageEvent socialaccountcreationfailedeventstartmessage = CreateSocialAccountCreationFailedEventStartMessageStartMessageEvent();
			eventsubprocess3.FlowElements.Add(socialaccountcreationfailedeventstartmessage);
			ProcessSchemaScriptTask scripttask5 = CreateScriptTask5ScriptTask();
			eventsubprocess3.FlowElements.Add(scripttask5);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			eventsubprocess3.FlowElements.Add(end1);
			ProcessSchemaStartMessageEvent startmessage1 = CreateStartMessage1StartMessageEvent();
			eventsubprocess4.FlowElements.Add(startmessage1);
			ProcessSchemaStartMessageEvent startmessage2 = CreateStartMessage2StartMessageEvent();
			eventsubprocess4.FlowElements.Add(startmessage2);
			ProcessSchemaScriptTask scripttask7 = CreateScriptTask7ScriptTask();
			eventsubprocess4.FlowElements.Add(scripttask7);
			ProcessSchemaScriptTask scripttask8 = CreateScriptTask8ScriptTask();
			eventsubprocess4.FlowElements.Add(scripttask8);
			ProcessSchemaEndEvent end2 = CreateEnd2EndEvent();
			eventsubprocess4.FlowElements.Add(end2);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaScriptTask scripttask4 = CreateScriptTask4ScriptTask();
			FlowElements.Add(scripttask4);
			ProcessSchemaUserTask createsocialaccountusertask = CreateCreateSocialAccountUserTaskUserTask();
			FlowElements.Add(createsocialaccountusertask);
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("a850d536-caca-483e-8b4d-ca37434e27af"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(466, 162),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("7f80060c-d0bf-4ae2-b310-1a4a2ad3b4e5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(766, 260),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f4b0a237-00b7-4e35-b604-f9d844eaa29e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("f5d50557-7007-470d-92b3-df6e4acb8062"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(768, 94),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7816b0d8-3bb7-4490-ba7b-51b52c04338f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("7f2757b4-9ccf-4844-8f2c-913090f72fdc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(902, 92),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("70ddb426-9614-422b-839f-2ee510834c75"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1152, 56),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("92871b4f-382d-42ab-8800-564ecaba2f0a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("7f081a69-8405-4e59-853d-85cd5b3816ee"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1274, 66),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("7ec8ba54-0df7-4cd1-9c27-1a75de00f7f1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1300, 100),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b359fd68-27be-4b79-b92b-9e9d94ab5dd6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("f3b81b12-edd7-45ee-a82c-ed07e0041e76"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(192, 432),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("f2cfd8e7-b706-4cdc-ab23-ca9d82dbb0c3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("47479406-f8b6-4963-b4f9-77838c3efcaf"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(708, 258),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("68617c70-36fb-4a3a-a32e-cc51ec4a95d2"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("cf3e71d5-d5a8-4f13-8ebe-e24eb2297f37"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				CurveCenterPosition = new Point(1261, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5246cd69-4c89-426f-a40c-94980486f720"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("467afb00-02d5-4ba1-bebc-cb5f05c10da0"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("467afb00-02d5-4ba1-bebc-cb5f05c10da0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess2EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess2 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"EventSubProcess2",
				Position = new Point(435, 9),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(364, 154),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess2;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateSocialAccountCreatedSuccessfullyEventStartMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("7816b0d8-3bb7-4490-ba7b-51b52c04338f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"SocialAccountCreatedSuccessfullyEvent",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"SocialAccountCreatedSuccessfullyEventStartMessage",
				Position = new Point(28, 63),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask6ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask6",
				Position = new Point(120, 51),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,86,81,79,219,48,16,126,110,126,133,151,167,68,171,50,237,185,3,137,149,140,149,109,133,45,101,104,154,246,96,210,163,120,36,118,102,59,148,12,241,223,119,103,27,72,75,91,164,85,130,52,241,247,221,249,238,62,127,169,177,90,200,5,43,43,46,106,182,199,74,37,45,220,218,108,118,165,213,50,191,1,105,15,244,194,100,51,85,56,92,146,142,162,232,134,107,246,251,129,144,28,207,212,53,200,244,216,40,153,29,130,1,45,120,37,254,66,226,0,8,39,180,37,8,129,147,227,239,188,106,33,245,244,159,177,227,198,191,210,204,61,94,73,67,60,3,165,6,187,137,88,184,149,29,76,85,226,62,38,243,141,220,176,182,157,221,98,25,142,123,134,95,198,74,74,40,173,192,250,198,173,214,216,18,122,154,77,230,161,21,62,213,20,236,82,233,107,228,140,53,112,11,62,201,65,89,170,214,19,102,220,92,103,69,31,219,223,105,120,228,55,44,97,201,10,168,48,105,178,186,129,20,119,218,36,111,211,104,144,141,85,213,214,50,137,177,12,186,253,160,85,157,196,99,85,215,173,20,37,39,240,172,107,192,173,157,95,129,134,36,158,242,26,239,179,137,201,255,180,188,74,124,128,236,148,107,124,110,65,39,43,27,73,83,198,77,216,4,197,200,111,161,108,177,170,146,87,92,191,59,106,197,124,159,154,53,136,62,180,178,124,103,92,247,134,204,95,247,153,233,140,133,218,245,214,213,131,25,82,182,183,207,238,162,1,163,154,111,194,74,209,153,2,172,69,142,201,142,192,58,194,90,201,195,181,254,190,102,46,26,166,102,226,146,37,62,210,171,61,38,219,170,74,41,193,128,161,48,90,45,125,146,149,209,14,216,61,254,89,146,54,163,30,163,180,219,26,231,57,69,238,137,206,235,198,118,249,109,9,13,229,77,226,226,169,136,44,198,188,91,246,113,143,50,240,117,179,74,45,4,201,60,80,99,63,96,249,168,12,63,125,55,36,203,173,210,89,95,42,33,240,238,242,211,17,139,172,238,176,206,135,92,33,58,181,239,84,171,75,81,65,24,228,100,158,102,52,114,220,33,67,65,148,87,119,209,125,16,108,121,5,53,127,174,238,92,90,97,187,194,173,126,225,146,47,80,229,24,118,34,141,229,178,132,247,29,133,195,190,244,149,29,135,19,3,142,139,49,125,240,80,153,143,184,46,226,81,228,209,25,206,254,16,46,189,16,93,159,77,178,178,216,91,73,98,10,130,98,31,134,195,185,29,248,153,58,131,56,215,161,237,48,44,0,140,241,6,52,244,14,245,18,216,155,206,3,197,155,211,118,206,163,205,60,204,112,215,166,233,176,246,160,143,118,176,157,129,13,53,168,94,253,9,58,162,61,137,117,117,41,237,69,224,55,224,12,124,10,203,149,33,58,215,9,160,83,45,106,174,187,94,42,36,208,97,57,68,47,176,235,167,51,13,198,179,166,137,39,211,9,83,219,97,59,97,156,196,57,144,115,52,52,147,223,54,66,195,78,146,213,232,231,61,95,114,101,157,52,32,191,224,152,80,184,231,66,206,213,18,9,11,178,25,186,140,54,44,135,187,25,190,240,16,117,208,52,85,23,74,56,109,47,42,81,126,46,54,177,38,248,142,164,67,254,245,44,47,102,147,147,105,188,9,244,190,181,22,167,64,184,31,121,49,61,217,8,250,6,166,65,16,132,167,132,118,157,22,174,183,56,133,103,198,122,23,49,255,185,139,59,48,56,247,248,7,24,28,199,165,208,117,136,18,223,15,159,64,82,17,102,170,214,33,1,240,63,159,136,161,227,225,255,55,111,200,190,81,116,217,57,92,100,31,173,109,48,137,251,237,16,222,146,143,229,225,151,57,14,20,223,102,47,18,254,160,7,224,149,47,207,116,69,35,13,86,78,227,30,253,3,95,3,113,217,170,8,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenMessageWindowUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("a076b343-35fb-4593-b863-c0008611e92e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"OpenMessageWindow",
				Position = new Point(266, 49),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenMessageWindowParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess3EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess3 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"EventSubProcess3",
				Position = new Point(434, 168),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(315, 158),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess3;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateSocialAccountCreationFailedEventStartMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("f4b0a237-00b7-4e35-b604-f9d844eaa29e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"SocialAccountCreationFailedEvent",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"SocialAccountCreationFailedEventStartMessage",
				Position = new Point(29, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask5ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask5",
				Position = new Point(134, 58),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,74,45,41,45,202,83,40,41,42,77,181,6,0,0,22,62,211,12,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("68617c70-36fb-4a3a-a32e-cc51ec4a95d2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"End1",
				Position = new Point(253, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess4EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess4 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"EventSubProcess4",
				Position = new Point(813, 114),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(511, 158),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess4;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateStartMessage1StartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("92871b4f-382d-42ab-8800-564ecaba2f0a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"NoConfirmMessage",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"StartMessage1",
				Position = new Point(22, 37),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateStartMessage2StartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("b359fd68-27be-4b79-b92b-9e9d94ab5dd6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"YesConfirmMessage",
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"StartMessage2",
				Position = new Point(183, 100),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask7ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask7",
				Position = new Point(92, 23),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,206,177,10,194,48,20,64,209,185,249,138,103,166,4,74,126,160,56,72,41,210,69,10,165,56,199,228,21,3,105,82,211,23,170,136,255,174,232,36,221,239,129,235,70,16,39,92,251,104,156,246,7,99,98,14,212,90,216,237,225,152,157,85,205,52,211,67,194,147,21,1,87,24,102,171,9,197,176,96,170,99,8,104,200,197,80,2,255,211,92,178,162,80,61,146,224,93,190,120,103,120,9,117,244,121,10,170,211,73,79,72,152,196,168,253,130,242,91,158,175,152,80,240,214,114,169,218,165,185,101,237,197,166,223,46,254,112,115,71,147,63,75,178,98,47,150,144,114,10,64,41,99,245,6,210,7,197,195,216,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask8ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask8",
				Position = new Point(315, 49),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,174,44,46,73,205,213,11,79,77,210,243,40,41,41,112,206,207,43,73,173,40,209,115,46,45,42,74,205,43,209,11,74,45,46,200,207,43,78,5,50,82,50,139,82,147,75,52,130,9,105,40,44,77,45,6,210,137,229,161,69,57,154,214,92,69,169,37,165,69,121,10,37,69,165,169,214,0,4,250,253,74,109,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd2EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("5246cd69-4c89-426f-a40c-94980486f720"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"End2",
				Position = new Point(427, 63),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("f2cfd8e7-b706-4cdc-ab23-ca9d82dbb0c3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"Start1",
				Position = new Point(78, 156),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask4ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"ScriptTask4",
				Position = new Point(190, 142),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,141,177,14,194,48,16,67,247,126,69,190,32,253,128,136,1,101,202,2,72,208,15,56,93,45,84,21,221,161,203,69,252,62,132,78,44,149,216,108,203,246,203,6,114,92,149,23,122,28,153,181,137,79,21,118,163,186,198,45,61,193,95,106,107,56,132,31,159,134,188,51,237,162,204,159,77,23,89,69,192,190,168,196,220,204,176,245,98,153,211,48,142,97,239,230,15,226,249,9,129,93,232,142,47,183,72,117,18,198,212,41,6,111,38,193,173,33,189,1,202,16,158,172,241,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateCreateSocialAccountUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("56df13cc-24aa-4d5f-8160-0460b9161acd"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"),
				Name = @"CreateSocialAccountUserTask",
				Position = new Point(316, 142),
				SchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeCreateSocialAccountUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c6d99c62-8eeb-4c4a-a003-fd57aa3ad9b8"),
				Name = "BPMSoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e5c0f419-1ac4-460f-94ff-1cd00ef81561"),
				Name = "BPMSoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("faff42c8-6ee8-4c83-8a52-58fbf3f70692"),
				Name = "BPMSoft.Core.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8ba21389-7e56-4bdf-93f2-ce66cfd49c73"),
				Name = "BPMSoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CreateSocialAccountProcess(userConnection);
		}

		public override object Clone() {
			return new CreateSocialAccountProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78"));
		}

		#endregion

	}

	#endregion

	#region Class: CreateSocialAccountProcess

	/// <exclude/>
	public class CreateSocialAccountProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CreateSocialAccountProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenMessageWindowFlowElement

		/// <exclude/>
		public class OpenMessageWindowFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public OpenMessageWindowFlowElement(UserConnection userConnection, CreateSocialAccountProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenMessageWindow";
				IsLogging = true;
				SchemaElementUId = new Guid("a076b343-35fb-4593-b863-c0008611e92e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		#region Class: CreateSocialAccountUserTaskFlowElement

		/// <exclude/>
		public class CreateSocialAccountUserTaskFlowElement : CreateSocialAccountUserTask
		{

			#region Constructors: Public

			public CreateSocialAccountUserTaskFlowElement(UserConnection userConnection, CreateSocialAccountProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "CreateSocialAccountUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("71febcbb-2f80-4258-9e38-210a2188c99f");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public CreateSocialAccountProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CreateSocialAccountProcess";
			SchemaUId = new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
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
				return new Guid("e6eba3a0-9389-4e93-8432-5c0d5f2a6a78");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CreateSocialAccountProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CreateSocialAccountProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid NewSocialAccountId {
			get;
			set;
		}

		public virtual Object Page {
			get;
			set;
		}

		public virtual string SocialNetwork {
			get;
			set;
		}

		private LocalizableString _applyAccountPublicLS;
		public virtual LocalizableString ApplyAccountPublicLS {
			get {
				return _applyAccountPublicLS ?? (_applyAccountPublicLS = GetLocalizableString("e6eba3a093894e9384325c0d5f2a6a78",
						 "Parameters.ApplyAccountPublicLS.Value"));
			}
			set {
				_applyAccountPublicLS = value;
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("11ff12e8-b36f-4c21-bb0b-7abd0d9184c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _socialAccountCreatedSuccessfullyEventStartMessage;
		public ProcessFlowElement SocialAccountCreatedSuccessfullyEventStartMessage {
			get {
				return _socialAccountCreatedSuccessfullyEventStartMessage ?? (_socialAccountCreatedSuccessfullyEventStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialAccountCreatedSuccessfullyEventStartMessage",
					SchemaElementUId = new Guid("7816b0d8-3bb7-4490-ba7b-51b52c04338f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask6;
		public ProcessScriptTask ScriptTask6 {
			get {
				return _scriptTask6 ?? (_scriptTask6 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask6",
					SchemaElementUId = new Guid("f62fedb3-46b3-4d33-8de6-90196a27368a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask6Execute,
				});
			}
		}

		private OpenMessageWindowFlowElement _openMessageWindow;
		public OpenMessageWindowFlowElement OpenMessageWindow {
			get {
				return _openMessageWindow ?? (_openMessageWindow = new OpenMessageWindowFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("d948e393-a56e-49a8-ae90-e9609779fea6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _socialAccountCreationFailedEventStartMessage;
		public ProcessFlowElement SocialAccountCreationFailedEventStartMessage {
			get {
				return _socialAccountCreationFailedEventStartMessage ?? (_socialAccountCreationFailedEventStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialAccountCreationFailedEventStartMessage",
					SchemaElementUId = new Guid("f4b0a237-00b7-4e35-b604-f9d844eaa29e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask5;
		public ProcessScriptTask ScriptTask5 {
			get {
				return _scriptTask5 ?? (_scriptTask5 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask5",
					SchemaElementUId = new Guid("a9c60992-1b92-42f9-8053-8089951711ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask5Execute,
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
					SchemaElementUId = new Guid("68617c70-36fb-4a3a-a32e-cc51ec4a95d2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4;
		public ProcessFlowElement EventSubProcess4 {
			get {
				return _eventSubProcess4 ?? (_eventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4",
					SchemaElementUId = new Guid("2fc7d8c0-3543-41ee-bebc-75fa4ce6ec80"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("92871b4f-382d-42ab-8800-564ecaba2f0a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _startMessage2;
		public ProcessFlowElement StartMessage2 {
			get {
				return _startMessage2 ?? (_startMessage2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage2",
					SchemaElementUId = new Guid("b359fd68-27be-4b79-b92b-9e9d94ab5dd6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask7;
		public ProcessScriptTask ScriptTask7 {
			get {
				return _scriptTask7 ?? (_scriptTask7 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask7",
					SchemaElementUId = new Guid("caceadab-4ab9-4bac-ae41-dcfa07e60739"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask7Execute,
				});
			}
		}

		private ProcessScriptTask _scriptTask8;
		public ProcessScriptTask ScriptTask8 {
			get {
				return _scriptTask8 ?? (_scriptTask8 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask8",
					SchemaElementUId = new Guid("2103381a-b1fb-45ae-aebb-3a17c470d89e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask8Execute,
				});
			}
		}

		private ProcessEndEvent _end2;
		public ProcessEndEvent End2 {
			get {
				return _end2 ?? (_end2 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End2",
					SchemaElementUId = new Guid("5246cd69-4c89-426f-a40c-94980486f720"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("f2cfd8e7-b706-4cdc-ab23-ca9d82dbb0c3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask4;
		public ProcessScriptTask ScriptTask4 {
			get {
				return _scriptTask4 ?? (_scriptTask4 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4",
					SchemaElementUId = new Guid("e0108a76-0864-455f-ac82-95521b00e280"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask4Execute,
				});
			}
		}

		private CreateSocialAccountUserTaskFlowElement _createSocialAccountUserTask;
		public CreateSocialAccountUserTaskFlowElement CreateSocialAccountUserTask {
			get {
				return _createSocialAccountUserTask ?? (_createSocialAccountUserTask = new CreateSocialAccountUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SocialAccountCreatedSuccessfullyEventStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountCreatedSuccessfullyEventStartMessage };
			FlowElements[ScriptTask6.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask6 };
			FlowElements[OpenMessageWindow.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenMessageWindow };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[SocialAccountCreationFailedEventStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountCreationFailedEventStartMessage };
			FlowElements[ScriptTask5.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask5 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4 };
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[StartMessage2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage2 };
			FlowElements[ScriptTask7.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask7 };
			FlowElements[ScriptTask8.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask8 };
			FlowElements[End2.SchemaElementUId] = new Collection<ProcessFlowElement> { End2 };
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[ScriptTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4 };
			FlowElements[CreateSocialAccountUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateSocialAccountUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess2":
						break;
					case "SocialAccountCreatedSuccessfullyEventStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask6", e.Context.SenderName));
						break;
					case "ScriptTask6":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenMessageWindow", e.Context.SenderName));
						break;
					case "OpenMessageWindow":
						break;
					case "EventSubProcess3":
						break;
					case "SocialAccountCreationFailedEventStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask5", e.Context.SenderName));
						break;
					case "ScriptTask5":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "EventSubProcess4":
						break;
					case "StartMessage1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask7", e.Context.SenderName));
						break;
					case "StartMessage2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask8", e.Context.SenderName));
						break;
					case "ScriptTask7":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask8", e.Context.SenderName));
						break;
					case "ScriptTask8":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End2", e.Context.SenderName));
						break;
					case "End2":
						CompleteProcess();
						break;
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask4", e.Context.SenderName));
						break;
					case "ScriptTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateSocialAccountUserTask", e.Context.SenderName));
						break;
					case "CreateSocialAccountUserTask":
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("NewSocialAccountId")) {
				writer.WriteValue("NewSocialAccountId", NewSocialAccountId, Guid.Empty);
			}
			if (!HasMapping("SocialNetwork")) {
				writer.WriteValue("SocialNetwork", SocialNetwork, null);
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
			ActivatedEventElements.Add("SocialAccountCreatedSuccessfullyEventStartMessage");
			ActivatedEventElements.Add("SocialAccountCreationFailedEventStartMessage");
			ActivatedEventElements.Add("StartMessage1");
			ActivatedEventElements.Add("StartMessage2");
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
			MetaPathParameterValues.Add("f263dd85-d3cd-4c40-b168-ae8daff43524", () => NewSocialAccountId);
			MetaPathParameterValues.Add("b1d146ff-40e8-4a5d-8b94-206a62e7f944", () => Page);
			MetaPathParameterValues.Add("4e3fdba2-8339-42ed-860d-a7d96d66d755", () => SocialNetwork);
			MetaPathParameterValues.Add("bce9a8f0-f858-4156-8a65-8715d4c703dc", () => ApplyAccountPublicLS);
			MetaPathParameterValues.Add("ffaca191-2916-4e64-80ef-3d900be58e07", () => OpenMessageWindow.Page);
			MetaPathParameterValues.Add("0c05c81a-1734-431a-88b8-61dc5472c229", () => OpenMessageWindow.Icon);
			MetaPathParameterValues.Add("68b45479-94c9-49fb-8c83-4703bccc4fcd", () => OpenMessageWindow.Buttons);
			MetaPathParameterValues.Add("559e2e0e-1702-4631-8932-e2df756aa0c6", () => OpenMessageWindow.WindowCaption);
			MetaPathParameterValues.Add("34aec6b7-5646-46a9-b104-d0fda1835eab", () => OpenMessageWindow.MessageText);
			MetaPathParameterValues.Add("3348ed5e-3ee7-4dc4-8334-1f5ad4953e28", () => OpenMessageWindow.ResponseMessages);
			MetaPathParameterValues.Add("a0058817-6d78-4f09-bad5-d0162d5a9dfa", () => OpenMessageWindow.ProcessInstanceId);
			MetaPathParameterValues.Add("751da741-9f8e-4532-a1a1-f34181368335", () => OpenMessageWindow.PageParameters);
			MetaPathParameterValues.Add("1000931d-1c32-448b-ba0e-c66614e147a8", () => CreateSocialAccountUserTask.UserId);
			MetaPathParameterValues.Add("a7b8a6fa-cf86-4400-90f5-45a23bd10537", () => CreateSocialAccountUserTask.SocialNetwork);
			MetaPathParameterValues.Add("96037c02-c530-4081-ab43-d03411c92f27", () => CreateSocialAccountUserTask.OpenerPageId);
			MetaPathParameterValues.Add("af330e9a-f3cb-4089-83f8-c51d5ecdc938", () => CreateSocialAccountUserTask.SuccessEventName);
			MetaPathParameterValues.Add("fdbe7b1a-f0fd-4541-b4fd-f3aa818a61e4", () => CreateSocialAccountUserTask.FailedEventName);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "NewSocialAccountId":
					if (!hasValueToRead) break;
					NewSocialAccountId = reader.GetValue<System.Guid>();
				break;
				case "SocialNetwork":
					if (!hasValueToRead) break;
					SocialNetwork = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask6Execute(ProcessExecutingContext context) {
			string claim = context.ThrowEventArgs.ToString();
			
			var jclaim = (JToken)Json.Deserialize(claim);
			var token = ((JValue)jclaim["Token"]).Value.ToString();
			var secret = ((JValue)jclaim["Secret"]).Value.ToString();
			var socialId = ((JValue)jclaim["SocialId"]).Value.ToString();
			var userId = UserConnection.CurrentUser.Id;
			
			var socialNetwork = CreateSocialAccountUserTask.SocialNetwork;
			var socialNetworkId = (new Select(UserConnection).Top(1)
				.Column("Id")
				.From("CommunicationType")
				.Where("Name").IsEqual(Column.Parameter(socialNetwork)) as Select)
				.ExecuteScalar<Guid>();
				
			Func<string, string> systemValue = (name) => {
				 var value = SysSettings.GetValue(UserConnection, socialNetwork + name);
				 if (value != null) {
					 return value.ToString();
				 }
				 throw new ArgumentNullOrEmptyException("SystemValue." + socialNetwork + name);
			};
			
			string login = "System";
			var network = SocialCommutator.CreateSocialNetwork(UserConnection, socialNetwork); 
			try {
			login = network.GetProfile(socialId).Name;
			} catch{
			}
			
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialAccount");
			var entity = schema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			entity.SetColumnValue("UserId", userId);
			entity.SetColumnValue("Login", login);
			entity.SetColumnValue("AccessToken", token);
			entity.SetColumnValue("AccessSecretToken", secret);
			entity.SetColumnValue("SocialId", socialId);
			entity.SetColumnValue("TypeId", socialNetworkId);
			entity.SetColumnValue("ConsumerKey", systemValue("ConsumerKey"));
			entity.Save();
			
			NewSocialAccountId = entity.PrimaryColumnValue;
			
			new Delete(UserConnection).From("SocialAccount")
				.Where("UserId").IsEqual(Column.Parameter(userId))
				.And("IsExpired").IsEqual(Column.Parameter(true))
				.Execute();
			
			OpenMessageWindow.Page = Page;
			OpenMessageWindow.MessageText = ApplyAccountPublicLS;
			OpenMessageWindow.Icon = "QUESTION";
			OpenMessageWindow.Buttons = "YESNO";
			OpenMessageWindow.ResponseMessages = new Dictionary<string, string> {
			       {"yes", "YesConfirmMessage"},
			       {"no", "NoConfirmMessage"}                                                           
			 };
			 
			 // System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl);
			
			return true;
		}

		public virtual bool ScriptTask5Execute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool ScriptTask7Execute(ProcessExecutingContext context) {
			if (NewSocialAccountId != Guid.Empty) {
				new Update(UserConnection, "SocialAccount")
					.Set("Public", Column.Parameter(false))
					.Where("Id").IsEqual(Column.Parameter(NewSocialAccountId))
					.Execute();
			}
			return true;
		}

		public virtual bool ScriptTask8Execute(ProcessExecutingContext context) {
			System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl);
			return true;
		}

		public virtual bool ScriptTask4Execute(ProcessExecutingContext context) {
			CreateSocialAccountUserTask.SocialNetwork = SocialNetwork;
			CreateSocialAccountUserTask.UserId = UserConnection.CurrentUser.Id;
			// CreateSocialAccountUserTask.SocialNetwork;
			CreateSocialAccountUserTask.OpenerPageId = InstanceUId;
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialAccountCreatedSuccessfullyEvent":
							if (ActivatedEventElements.Contains("SocialAccountCreatedSuccessfullyEventStartMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("SocialAccountCreatedSuccessfullyEventStartMessage", "SocialAccountCreatedSuccessfullyEventStartMessage"));
						}
						break;
					case "SocialAccountCreationFailedEvent":
							if (ActivatedEventElements.Contains("SocialAccountCreationFailedEventStartMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("SocialAccountCreationFailedEventStartMessage", "SocialAccountCreationFailedEventStartMessage"));
						}
						break;
					case "NoConfirmMessage":
							if (ActivatedEventElements.Contains("StartMessage1")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartMessage1", "StartMessage1"));
						}
						break;
					case "YesConfirmMessage":
							if (ActivatedEventElements.Contains("StartMessage2")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartMessage2", "StartMessage2"));
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
			var cloneItem = (CreateSocialAccountProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

