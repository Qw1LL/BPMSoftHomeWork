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

	#region Class: SynchronizeWithGoogleModuleProcessSchema

	/// <exclude/>
	public class SynchronizeWithGoogleModuleProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SynchronizeWithGoogleModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SynchronizeWithGoogleModuleProcessSchema(SynchronizeWithGoogleModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SynchronizeWithGoogleModuleProcess";
			UId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58");
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,79,107,2,49,16,197,207,10,126,135,224,41,123,216,197,63,235,186,75,241,82,177,178,208,66,169,216,251,152,204,106,96,205,74,54,177,149,218,239,222,68,35,116,173,22,114,154,153,223,123,111,38,157,246,206,172,74,193,200,94,40,109,160,36,251,74,112,242,12,70,178,205,171,170,24,214,53,13,200,87,167,221,218,131,34,40,181,208,135,23,144,176,70,69,38,100,89,163,154,86,82,34,211,162,146,209,236,212,94,176,13,110,193,15,61,120,114,123,143,241,38,55,161,221,239,158,69,9,109,76,7,94,52,122,18,146,231,178,214,32,25,62,30,150,57,167,185,212,184,86,224,28,60,146,243,192,201,138,130,208,43,217,9,145,166,44,207,75,182,20,106,163,164,155,252,190,36,175,184,41,209,171,216,16,13,58,154,42,4,125,233,210,230,110,39,195,6,30,205,62,145,25,141,183,6,157,87,125,144,108,110,235,26,152,246,136,221,198,154,74,252,32,115,35,56,237,14,48,6,236,65,17,14,86,41,132,113,156,20,225,138,143,210,112,12,73,130,195,52,78,57,14,186,87,130,80,162,228,160,238,40,246,144,97,81,96,18,14,198,217,40,140,135,153,85,204,250,163,176,223,79,71,105,47,139,109,53,59,43,186,227,221,186,172,187,225,157,232,199,163,187,234,255,208,159,120,254,47,22,182,235,139,111,88,155,82,219,216,180,214,74,200,117,208,60,235,28,157,231,14,149,62,188,67,105,144,118,29,123,134,206,209,237,111,218,215,105,255,0,63,25,112,108,240,2,0,0 };
			RealUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58");
			Version = 0;
			PackageUId = new Guid("8d48ade0-350e-7694-49aa-2a913c356ce1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ab4ebe86-dc00-4849-814c-097f1b38241c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("90cd06a1-f3af-4b86-a0bd-55f20eea8232"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateUserTokenParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("eae8ec8f-7ecb-440f-ba06-8e8210066909"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"UserToken",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridClientIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bf422694-53ac-4597-9dc2-5eaabeb47bc5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"ActiveTreeGridClientId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateIntegrationProcessIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4197645b-e99d-4bce-8588-1e08cb338b65"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"IntegrationProcessId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncProcessResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fe90ca8a-69fe-41b3-9b7c-dd5b9da8518f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"SyncProcessResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationAuthenticationErrorMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("59f3910c-c741-4209-9af8-2740ec01a03d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("74528743-3768-4ea1-98c1-af5d8111ed6d"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"SynchronizationAuthenticationErrorMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateUserTokenParameter());
			Parameters.Add(CreateActiveTreeGridClientIdParameter());
			Parameters.Add(CreateIntegrationProcessIdParameter());
			Parameters.Add(CreateSyncProcessResultParameter());
			Parameters.Add(CreateSynchronizationAuthenticationErrorMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaEventSubProcess eventsubprocess1 = CreateEventSubProcess1EventSubProcess();
			FlowElements.Add(eventsubprocess1);
			ProcessSchemaStartMessageEvent socialaccountcreatedsuccessfullyeventstartmessage = CreateSocialAccountCreatedSuccessfullyEventStartMessageStartMessageEvent();
			eventsubprocess1.FlowElements.Add(socialaccountcreatedsuccessfullyeventstartmessage);
			ProcessSchemaScriptTask scripttask4 = CreateScriptTask4ScriptTask();
			eventsubprocess1.FlowElements.Add(scripttask4);
			ProcessSchemaScriptTask launchprocessscripttask2 = CreateLaunchProcessScriptTask2ScriptTask();
			eventsubprocess1.FlowElements.Add(launchprocessscripttask2);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			eventsubprocess1.FlowElements.Add(end1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaScriptTask findusertokenscripttask = CreateFindUserTokenScriptTaskScriptTask();
			FlowElements.Add(findusertokenscripttask);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaScriptTask runauthscripttask = CreateRunAuthScriptTaskScriptTask();
			FlowElements.Add(runauthscripttask);
			ProcessSchemaScriptTask launchprocessscripttask = CreateLaunchProcessScriptTaskScriptTask();
			FlowElements.Add(launchprocessscripttask);
			ProcessSchemaEndEvent end2 = CreateEnd2EndEvent();
			FlowElements.Add(end2);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("eb87faed-683d-47f4-8e88-ee483335e606"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6fce82da-c64e-4740-b5d8-5f76aac5db5a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5c827f43-43a9-41d7-b948-013e6a142885"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("2f3dd41b-e0eb-47a4-880b-0ba292e39994"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5c827f43-43a9-41d7-b948-013e6a142885"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ad35f2dc-2f17-4135-a912-c5a11b2e135b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("14b7d6bf-778c-4ec4-bc34-940b85ae1ae2"),
				ConditionExpression = @"UserToken == null",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(430, 240),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ad35f2dc-2f17-4135-a912-c5a11b2e135b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2cd2d6dd-5fe5-4526-acb8-10c2b90ba7cd"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("4a760236-a582-4dde-b401-629ac6dc11fa"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(192, 418),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6dcc1372-52d6-413a-9902-d9ff09cc3dcc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("aa361df6-244d-4fdc-b7b1-d8db1533f84b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("a2f3e668-5f1a-4ae4-ac26-ae665a393832"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(402, 124),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ad35f2dc-2f17-4135-a912-c5a11b2e135b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2576d3cd-66e5-4871-a310-eb3c567b5ba1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("8d975930-dd60-40ef-bed2-fdce62d6b240"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(326, 420),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("aa361df6-244d-4fdc-b7b1-d8db1533f84b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("18d6c71e-6ee4-49ad-a2c2-ecb254fc0b0f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("927e55ec-ed71-41f8-87a1-eac32bb94472"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(428, 426),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("18d6c71e-6ee4-49ad-a2c2-ecb254fc0b0f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7b3b1fcb-a8c3-42aa-87f3-b1694f3bd333"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("626252da-8562-4cf8-8d04-7681a49c47b6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(524, 114),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2576d3cd-66e5-4871-a310-eb3c567b5ba1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8c7eff9a-bf33-446d-876e-101a346c9e49"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("5b5d964d-de24-4bad-bd02-0a9a5428aeb5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("d96ae870-4bfc-40ec-921c-ada84236f3fa"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				CurveCenterPosition = new Point(506, 175),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2cd2d6dd-5fe5-4526-acb8-10c2b90ba7cd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8c7eff9a-bf33-446d-876e-101a346c9e49"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("05ab5dd0-2a73-4fcd-8031-1df3a1ff1832"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("05ab5dd0-2a73-4fcd-8031-1df3a1ff1832"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess1EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess1 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("2627d3ee-a78e-4add-97d1-c192c667608a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"EventSubProcess1",
				Position = new Point(70, 336),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(722, 226),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess1;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateSocialAccountCreatedSuccessfullyEventStartMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("6dcc1372-52d6-413a-9902-d9ff09cc3dcc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2627d3ee-a78e-4add-97d1-c192c667608a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"SocialAccountCreatedSuccessfullyEvent",
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"SocialAccountCreatedSuccessfullyEventStartMessage",
				Position = new Point(43, 65),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask4ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("aa361df6-244d-4fdc-b7b1-d8db1533f84b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2627d3ee-a78e-4add-97d1-c192c667608a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"ScriptTask4",
				Position = new Point(120, 51),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,74,45,41,45,202,83,40,41,42,77,181,6,0,0,22,62,211,12,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateLaunchProcessScriptTask2ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("18d6c71e-6ee4-49ad-a2c2-ecb254fc0b0f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2627d3ee-a78e-4add-97d1-c192c667608a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"LaunchProcessScriptTask2",
				Position = new Point(225, 51),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,44,205,75,206,8,40,202,79,78,45,46,214,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,112,150,72,86,30,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("7b3b1fcb-a8c3-42aa-87f3-b1694f3bd333"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2627d3ee-a78e-4add-97d1-c192c667608a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"End1",
				Position = new Point(358, 65),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("6fce82da-c64e-4740-b5d8-5f76aac5db5a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateFindUserTokenScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("5c827f43-43a9-41d7-b948-013e6a142885"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"FindUserTokenScriptTask",
				Position = new Point(141, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,61,77,187,14,130,48,20,221,251,21,53,44,176,20,227,74,28,4,212,48,8,137,212,201,24,211,208,11,105,128,219,228,182,104,252,123,65,141,211,57,57,207,192,180,124,85,238,101,45,119,101,190,59,231,155,251,154,199,49,151,85,94,177,135,34,62,42,84,29,16,223,242,84,57,200,44,186,105,4,18,210,246,128,167,175,231,174,181,109,140,26,74,240,79,75,189,56,90,219,13,112,75,216,197,1,125,130,115,251,183,35,14,6,245,95,79,95,11,45,116,184,192,188,141,208,120,99,81,100,19,17,160,95,84,81,232,249,172,246,100,176,11,163,40,97,1,160,54,45,35,240,19,33,247,52,65,242,6,250,253,214,106,196,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("ad35f2dc-2f17-4135-a912-c5a11b2e135b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"ExclusiveGateway1",
				Position = new Point(281, 170),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateRunAuthScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2cd2d6dd-5fe5-4526-acb8-10c2b90ba7cd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"RunAuthScriptTask",
				Position = new Point(393, 219),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,203,49,10,128,48,12,0,192,93,240,15,33,171,63,80,28,28,28,5,177,107,151,82,130,45,72,10,105,58,168,248,119,139,187,251,157,57,217,175,146,60,229,188,81,46,135,194,8,120,91,156,138,6,98,141,222,105,76,60,139,36,89,170,113,59,89,236,193,34,66,7,166,222,32,137,227,245,161,255,82,45,90,124,112,104,27,33,45,194,160,82,104,120,1,50,193,63,231,124,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateLaunchProcessScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2576d3cd-66e5-4871-a310-eb3c567b5ba1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"LaunchProcessScriptTask",
				Position = new Point(393, 79),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,73,44,205,75,206,8,40,202,79,78,45,46,214,208,180,230,42,74,45,41,45,202,83,40,41,42,77,181,6,0,232,39,152,71,29,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd2EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("8c7eff9a-bf33-446d-876e-101a346c9e49"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("33ae477c-9d33-4e4d-926f-fbf643897247"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"),
				Name = @"End2",
				Position = new Point(533, 142),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4f84704e-bd9a-478c-8f75-f3f84039a4a3"),
				Name = "BPMSoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7b9cd3eb-28ec-428b-8c68-e5a56f7f555d"),
				Name = "BPMSoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SynchronizeWithGoogleModuleProcess(userConnection);
		}

		public override object Clone() {
			return new SynchronizeWithGoogleModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58"));
		}

		#endregion

	}

	#endregion

	#region Class: SynchronizeWithGoogleModuleProcess

	/// <exclude/>
	public class SynchronizeWithGoogleModuleProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SynchronizeWithGoogleModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SynchronizeWithGoogleModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SynchronizeWithGoogleModuleProcess";
			SchemaUId = new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58");
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
				return new Guid("3d5ca9a9-8a90-433c-8e51-fab6c0c2cc58");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SynchronizeWithGoogleModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SynchronizeWithGoogleModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object UserToken {
			get;
			set;
		}

		public virtual string ActiveTreeGridClientId {
			get;
			set;
		}

		public virtual Guid IntegrationProcessId {
			get;
			set;
		}

		public virtual string SyncProcessResult {
			get;
			set;
		}

		private LocalizableString _synchronizationAuthenticationErrorMessage;
		public virtual LocalizableString SynchronizationAuthenticationErrorMessage {
			get {
				return _synchronizationAuthenticationErrorMessage ?? (_synchronizationAuthenticationErrorMessage = GetLocalizableString("3d5ca9a98a90433c8e51fab6c0c2cc58",
						 "Parameters.SynchronizationAuthenticationErrorMessage.Value"));
			}
			set {
				_synchronizationAuthenticationErrorMessage = value;
			}
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("2627d3ee-a78e-4add-97d1-c192c667608a"),
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
					SchemaElementUId = new Guid("6dcc1372-52d6-413a-9902-d9ff09cc3dcc"),
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
					SchemaElementUId = new Guid("aa361df6-244d-4fdc-b7b1-d8db1533f84b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask4Execute,
				});
			}
		}

		private ProcessScriptTask _launchProcessScriptTask2;
		public ProcessScriptTask LaunchProcessScriptTask2 {
			get {
				return _launchProcessScriptTask2 ?? (_launchProcessScriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LaunchProcessScriptTask2",
					SchemaElementUId = new Guid("18d6c71e-6ee4-49ad-a2c2-ecb254fc0b0f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = LaunchProcessScriptTask2Execute,
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
					SchemaElementUId = new Guid("7b3b1fcb-a8c3-42aa-87f3-b1694f3bd333"),
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
					SchemaElementUId = new Guid("6fce82da-c64e-4740-b5d8-5f76aac5db5a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _findUserTokenScriptTask;
		public ProcessScriptTask FindUserTokenScriptTask {
			get {
				return _findUserTokenScriptTask ?? (_findUserTokenScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "FindUserTokenScriptTask",
					SchemaElementUId = new Guid("5c827f43-43a9-41d7-b948-013e6a142885"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FindUserTokenScriptTaskExecute,
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
					SchemaElementUId = new Guid("ad35f2dc-2f17-4135-a912-c5a11b2e135b"),
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

		private ProcessScriptTask _runAuthScriptTask;
		public ProcessScriptTask RunAuthScriptTask {
			get {
				return _runAuthScriptTask ?? (_runAuthScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RunAuthScriptTask",
					SchemaElementUId = new Guid("2cd2d6dd-5fe5-4526-acb8-10c2b90ba7cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = RunAuthScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _launchProcessScriptTask;
		public ProcessScriptTask LaunchProcessScriptTask {
			get {
				return _launchProcessScriptTask ?? (_launchProcessScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LaunchProcessScriptTask",
					SchemaElementUId = new Guid("2576d3cd-66e5-4871-a310-eb3c567b5ba1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = LaunchProcessScriptTaskExecute,
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
					SchemaElementUId = new Guid("8c7eff9a-bf33-446d-876e-101a346c9e49"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("14b7d6bf-778c-4ec4-bc34-940b85ae1ae2"),
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
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SocialAccountCreatedSuccessfullyEventStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialAccountCreatedSuccessfullyEventStartMessage };
			FlowElements[ScriptTask4.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4 };
			FlowElements[LaunchProcessScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { LaunchProcessScriptTask2 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[FindUserTokenScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FindUserTokenScriptTask };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[RunAuthScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RunAuthScriptTask };
			FlowElements[LaunchProcessScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LaunchProcessScriptTask };
			FlowElements[End2.SchemaElementUId] = new Collection<ProcessFlowElement> { End2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SocialAccountCreatedSuccessfullyEventStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask4", e.Context.SenderName));
						break;
					case "ScriptTask4":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LaunchProcessScriptTask2", e.Context.SenderName));
						break;
					case "LaunchProcessScriptTask2":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FindUserTokenScriptTask", e.Context.SenderName));
						break;
					case "FindUserTokenScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RunAuthScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LaunchProcessScriptTask", e.Context.SenderName));
						break;
					case "RunAuthScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End2", e.Context.SenderName));
						break;
					case "LaunchProcessScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End2", e.Context.SenderName));
						break;
					case "End2":
						CompleteProcess();
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean(UserToken == null);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "UserToken == null", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (UserToken != null) {
				if (UserToken.GetType().IsSerializable ||
					UserToken.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("UserToken", UserToken, null);
				}
			}
			if (!HasMapping("ActiveTreeGridClientId")) {
				writer.WriteValue("ActiveTreeGridClientId", ActiveTreeGridClientId, null);
			}
			if (!HasMapping("IntegrationProcessId")) {
				writer.WriteValue("IntegrationProcessId", IntegrationProcessId, Guid.Empty);
			}
			if (!HasMapping("SyncProcessResult")) {
				writer.WriteValue("SyncProcessResult", SyncProcessResult, null);
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
			MetaPathParameterValues.Add("ab4ebe86-dc00-4849-814c-097f1b38241c", () => PageInstanceId);
			MetaPathParameterValues.Add("90cd06a1-f3af-4b86-a0bd-55f20eea8232", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("eae8ec8f-7ecb-440f-ba06-8e8210066909", () => UserToken);
			MetaPathParameterValues.Add("bf422694-53ac-4597-9dc2-5eaabeb47bc5", () => ActiveTreeGridClientId);
			MetaPathParameterValues.Add("4197645b-e99d-4bce-8588-1e08cb338b65", () => IntegrationProcessId);
			MetaPathParameterValues.Add("fe90ca8a-69fe-41b3-9b7c-dd5b9da8518f", () => SyncProcessResult);
			MetaPathParameterValues.Add("59f3910c-c741-4209-9af8-2740ec01a03d", () => SynchronizationAuthenticationErrorMessage);
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
				case "UserToken":
					if (!hasValueToRead) break;
					UserToken = reader.GetSerializableObjectValue();
				break;
				case "ActiveTreeGridClientId":
					if (!hasValueToRead) break;
					ActiveTreeGridClientId = reader.GetValue<System.String>();
				break;
				case "IntegrationProcessId":
					if (!hasValueToRead) break;
					IntegrationProcessId = reader.GetValue<System.Guid>();
				break;
				case "SyncProcessResult":
					if (!hasValueToRead) break;
					SyncProcessResult = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask4Execute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool LaunchProcessScriptTask2Execute(ProcessExecutingContext context) {
			LaunchProcess();
			return true;
		}

		public virtual bool FindUserTokenScriptTaskExecute(ProcessExecutingContext context) {
			#if !NETSTANDARD2_0 // TODO
			var manager = BaseConsumer.TokenManagers[SocialNetwork.Google];
			UserToken = manager.FindUserTokenByUserId(UserConnection.CurrentUser.Id.ToString());
			#endif
			return true;
		}

		public virtual bool RunAuthScriptTaskExecute(ProcessExecutingContext context) {
			SyncProcessResult = "{\"AuthenticationErrorMessage\": \"" + SynchronizationAuthenticationErrorMessage + "\"}";
			return true;
		}

		public virtual bool LaunchProcessScriptTaskExecute(ProcessExecutingContext context) {
			LaunchProcess();
			return true;
		}

			
			public virtual void LaunchProcess() {
				var entityManager = UserConnection.EntitySchemaManager;
				var manager = UserConnection.ProcessSchemaManager;
				var processSchema =  (ProcessSchema)manager.FindInstanceByUId(IntegrationProcessId);
				if (processSchema == null) {
					return;
				}
				var moduleProcess = processSchema.CreateProcess(UserConnection);
				moduleProcess.Execute(UserConnection);
				var syncGContactProcessUId = new Guid("2e4ae0af-2b8a-446f-bd58-7a66e3848de2");
				var syncGCalendarProcessUId = new Guid("0eceffe6-2795-439f-b915-118580947959");
				if (IntegrationProcessId == syncGContactProcessUId ||
					IntegrationProcessId == syncGCalendarProcessUId) {
					SyncProcessResult = (string)moduleProcess.GetPropertyValue("SyncResult");
				}
			}
			

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialAccountCreatedSuccessfullyEvent":
							if (ActivatedEventElements.Contains("SocialAccountCreatedSuccessfullyEventStartMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("SocialAccountCreatedSuccessfullyEventStartMessage", "SocialAccountCreatedSuccessfullyEventStartMessage"));
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
			var cloneItem = (SynchronizeWithGoogleModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.UserToken = UserToken;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

