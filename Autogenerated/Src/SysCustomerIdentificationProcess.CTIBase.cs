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

	#region Class: SysCustomerIdentificationProcessSchema

	/// <exclude/>
	public class SysCustomerIdentificationProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SysCustomerIdentificationProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SysCustomerIdentificationProcessSchema(SysCustomerIdentificationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SysCustomerIdentificationProcess";
			UId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe");
			CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,91,75,195,48,20,126,222,96,255,33,244,41,133,145,63,32,62,200,80,172,136,183,77,124,110,211,35,11,182,201,76,147,233,16,255,187,39,189,216,180,107,97,15,162,34,50,216,150,147,115,190,239,203,185,205,166,27,155,100,130,147,173,208,198,198,25,217,42,145,146,37,196,154,175,23,74,154,152,155,130,222,90,208,59,60,165,194,8,37,201,115,231,56,39,137,82,25,145,0,233,133,18,242,38,214,32,205,42,78,50,8,201,219,108,58,217,198,154,20,144,1,55,228,24,189,94,16,220,29,232,125,1,26,65,36,254,71,148,16,61,217,66,101,54,151,52,168,137,163,52,240,205,213,15,67,130,56,7,3,154,86,42,163,52,236,5,231,185,149,130,199,14,118,181,219,64,15,38,184,178,121,2,218,217,216,153,86,249,39,93,39,48,8,143,102,83,241,72,232,232,187,170,55,49,119,71,221,151,163,98,17,190,71,207,73,3,89,18,79,216,117,251,166,0,47,157,32,22,21,167,207,152,239,17,246,22,194,57,163,148,247,217,180,38,124,88,131,6,218,173,65,200,78,100,74,67,118,250,42,10,172,215,161,89,206,157,230,100,183,71,221,100,172,73,207,160,95,233,49,246,250,190,99,147,131,1,34,63,19,99,130,58,134,70,93,149,136,125,208,133,74,193,131,117,201,40,27,184,109,156,224,102,173,36,116,2,203,160,185,83,58,124,87,245,152,203,242,161,50,189,214,155,28,82,237,193,80,87,250,186,238,203,13,112,241,184,187,82,151,138,63,157,11,137,117,118,183,110,188,132,196,42,155,165,63,100,145,103,234,55,1,214,201,40,148,178,138,170,9,186,131,194,102,85,175,178,37,24,127,254,80,89,51,101,99,42,209,220,155,168,154,181,210,93,206,145,39,6,123,20,184,53,64,235,174,118,159,241,21,116,194,185,178,242,7,86,80,77,252,93,43,168,166,251,202,21,84,67,122,227,215,88,246,6,111,144,189,133,248,95,65,127,106,5,141,85,123,161,126,209,10,106,91,239,59,86,208,7,126,40,2,83,6,9,0,0 };
			RealUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe");
			Version = 0;
			PackageUId = new Guid("5048abef-9ed6-4a50-97bd-e91dea4ac632");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCallerReverseParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("916cd8ab-5cb1-434b-b45f-9dd7911d4e98"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"CallerReverse",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0d3e248a-e509-42cd-afe9-a5fa1fb6e3c3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchNumberLengthParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dc8cede1-985f-4d23-90f1-cca476db36cc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchNumberLength",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#SysSettings.SearchNumberLength#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCallerSubSearchParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7f5896e4-61f2-43a1-9f10-292eadb29a3d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"CallerSubSearch",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateInternalNumberLengthParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("05116a88-6e14-473e-abf8-cda57547b65a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"InternalNumberLength",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#SysSettings.InternalNumberLength#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsManualSearchParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c3e46c6f-a811-4cd0-806d-548ffaabe04b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"IsManualSearch",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePhoneCommunicationCodeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9e547af5-46bf-4bb8-9e0f-ed9cb32ceb4c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"PhoneCommunicationCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dbc20a42-e0bb-4804-bb1f-a4ddc095bae2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCallerReverseParameter());
			Parameters.Add(CreateSearchIdParameter());
			Parameters.Add(CreateSearchNumberLengthParameter());
			Parameters.Add(CreateCallerSubSearchParameter());
			Parameters.Add(CreateInternalNumberLengthParameter());
			Parameters.Add(CreateIsManualSearchParameter());
			Parameters.Add(CreatePhoneCommunicationCodeParameter());
			Parameters.Add(CreateSearchNameParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaSysCustomerIdentificationLaneSet = CreateSysCustomerIdentificationLaneSetLaneSet();
			LaneSets.Add(schemaSysCustomerIdentificationLaneSet);
			ProcessSchemaLane schemaSysCustomerIdentificationLane = CreateSysCustomerIdentificationLaneLane();
			schemaSysCustomerIdentificationLaneSet.Lanes.Add(schemaSysCustomerIdentificationLane);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaFormulaTask formulatasksetsearchid = CreateFormulaTaskSetSearchIdFormulaTask();
			FlowElements.Add(formulatasksetsearchid);
			ProcessSchemaFormulaTask formulatasknumdersearch = CreateFormulaTaskNumderSearchFormulaTask();
			FlowElements.Add(formulatasknumdersearch);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaExclusiveGateway exclusivegateway3 = CreateExclusiveGateway3ExclusiveGateway();
			FlowElements.Add(exclusivegateway3);
			ProcessSchemaExclusiveGateway exclusivegateway4 = CreateExclusiveGateway4ExclusiveGateway();
			FlowElements.Add(exclusivegateway4);
			ProcessSchemaScriptTask deleteoldrecordsscripttask = CreateDeleteOldRecordsScriptTaskScriptTask();
			FlowElements.Add(deleteoldrecordsscripttask);
			ProcessSchemaScriptTask searchcontactsbynamescripttask = CreateSearchContactsByNameScriptTaskScriptTask();
			FlowElements.Add(searchcontactsbynamescripttask);
			ProcessSchemaScriptTask searchaccountsbynamescripttask = CreateSearchAccountsByNameScriptTaskScriptTask();
			FlowElements.Add(searchaccountsbynamescripttask);
			ProcessSchemaScriptTask searchcontactsstartswithnumbertask = CreateSearchContactsStartsWithNumberTaskScriptTask();
			FlowElements.Add(searchcontactsstartswithnumbertask);
			ProcessSchemaScriptTask searchaccountsstartswithnumberscripttask = CreateSearchAccountsStartsWithNumberScriptTaskScriptTask();
			FlowElements.Add(searchaccountsstartswithnumberscripttask);
			ProcessSchemaScriptTask searchcontactsequalsnumbertask = CreateSearchContactsEqualsNumberTaskScriptTask();
			FlowElements.Add(searchcontactsequalsnumbertask);
			ProcessSchemaScriptTask searchaccountsequalsnumbertask = CreateSearchAccountsEqualsNumberTaskScriptTask();
			FlowElements.Add(searchaccountsequalsnumbertask);
			ProcessSchemaTerminateEvent terminate2 = CreateTerminate2TerminateEvent();
			FlowElements.Add(terminate2);
			ProcessSchemaFormulaTask setsearchnameformulatask = CreateSetSearchNameFormulaTaskFormulaTask();
			FlowElements.Add(setsearchnameformulatask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateConditionalFlow1ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateConditionalFlow2ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateConditionalFlow3ConditionalFlow());
			FlowElements.Add(CreateConditionalFlow4ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("085f2770-358e-4cac-b602-c97349ef46f4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("38a27e74-f454-47ae-bdba-787192d3d42e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9156360a-f0c7-4a54-9aec-a744d3e3470b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("25906def-2f44-4dad-b249-46fa9b0cf5c2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6b525282-5ace-4919-8d75-a818882113b4"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b317722f-8ea8-4059-98bd-ca2a8b8f518e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("39fe90ec-bbdc-4692-9de1-980671066f74"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4a61c6f9-2761-4a74-b0f9-d66f3611a8bc"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d4f3f318-00c5-442c-b401-caf98d692954"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(515, 36));
			schemaFlow.PolylinePointPositions.Add(new Point(515, 127));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow1",
				UId = new Guid("73c3071e-f09c-45c0-9d67-c5254488cd62"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{916cd8ab-5cb1-434b-b45f-9dd7911d4e98}]#].Length >= [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dc8cede1-985f-4d23-90f1-cca476db36cc}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(466, 202),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5b3b7702-f66b-44e0-95a6-29c0034a0758"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4a61c6f9-2761-4a74-b0f9-d66f3611a8bc"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(336, 47));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("aaf7367e-990d-447e-b7a3-a0199f51d779"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(578, 264),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e87f397d-e22b-4461-bffc-7cbcb9ceae07"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d4f3f318-00c5-442c-b401-caf98d692954"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(515, 204));
			schemaFlow.PolylinePointPositions.Add(new Point(515, 127));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow8",
				UId = new Guid("9501823b-bbc2-4c32-a884-9b9a8b45b3ae"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(391, 266),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5b3b7702-f66b-44e0-95a6-29c0034a0758"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e87f397d-e22b-4461-bffc-7cbcb9ceae07"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(336, 204));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow2",
				UId = new Guid("3bb9ca04-03cd-4d79-8308-dfa7c31e2df2"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{916cd8ab-5cb1-434b-b45f-9dd7911d4e98}]#].Length <= [#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{05116a88-6e14-473e-abf8-cda57547b65a}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("25df9113-8047-4ea2-8562-6c0103dce080"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(360, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3c03a139-d8fc-41c6-a5e1-935c704530c8"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d467a680-c2ee-4e1d-9f0b-3a1ba7afc429"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow9",
				UId = new Guid("11f4bd96-30cb-4e91-9ae8-e54412fee1fc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("25df9113-8047-4ea2-8562-6c0103dce080"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(732, 219),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3c03a139-d8fc-41c6-a5e1-935c704530c8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5b3b7702-f66b-44e0-95a6-29c0034a0758"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(273, 127));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow4",
				UId = new Guid("1ea4ca0d-218b-4ee1-916a-f5daba864692"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d825fbe-4308-4081-a307-7964bcd2243e"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(236, 318),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b317722f-8ea8-4059-98bd-ca2a8b8f518e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3c03a139-d8fc-41c6-a5e1-935c704530c8"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow3",
				UId = new Guid("15a4413d-451a-4dec-b227-c37a1df36b1d"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{c3e46c6f-a811-4cd0-806d-548ffaabe04b}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d825fbe-4308-4081-a307-7964bcd2243e"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(138, 387),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b317722f-8ea8-4059-98bd-ca2a8b8f518e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1b5a8982-0970-4312-9b3a-f3bc2974af1e"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalFlow4",
				UId = new Guid("eb975285-0927-4df0-a5db-43104cb1a17d"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{dbc20a42-e0bb-4804-bb1f-a4ddc095bae2}]#].Length >= 3",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d825fbe-4308-4081-a307-7964bcd2243e"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(388, 510),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d53e11b-8807-41e7-b41e-5097f22fb088"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c8696baf-2afd-43f3-a99e-ed89773b6a27"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "SequenceFlow12",
				UId = new Guid("1ffff56f-c024-4088-a6fc-95529bdc92c0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d825fbe-4308-4081-a307-7964bcd2243e"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(662, 381),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3d53e11b-8807-41e7-b41e-5097f22fb088"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9307597f-1e4a-4fad-bc27-a307b264a9ba"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("a185f83c-2649-4cf6-9a8d-bd621d000dcb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5718c33a-2d04-45a2-a423-140ea6f39686"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9156360a-f0c7-4a54-9aec-a744d3e3470b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6b525282-5ace-4919-8d75-a818882113b4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("20aa5edb-c297-481d-b6f9-de3e99948b9c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(755, 512),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c8696baf-2afd-43f3-a99e-ed89773b6a27"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("355d7dac-42a4-4148-8d76-ccd3b30814fc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("8fe0d643-1103-4e9e-b46b-176d88d81352"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(866, 512),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("355d7dac-42a4-4148-8d76-ccd3b30814fc"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("683c0223-7f0e-45a8-b0db-e02d8c3a59fa"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(805, 477));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e5b4f316-f8de-4878-9082-b4867f0903bc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d4f3f318-00c5-442c-b401-caf98d692954"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5475b1a2-420b-44c0-9342-41eae9f20154"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("7281fdcf-6007-461a-8e1d-e2ca7bde6b64"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5475b1a2-420b-44c0-9342-41eae9f20154"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("683c0223-7f0e-45a8-b0db-e02d8c3a59fa"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("269e7a3f-f1d3-4fe3-a1b1-872916538908"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(957, 328),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d467a680-c2ee-4e1d-9f0b-3a1ba7afc429"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("be50be51-361c-4985-9ee7-3969aaa31291"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("968f255a-c435-41de-b6a7-992da8ee8ceb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(957, 328),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("be50be51-361c-4985-9ee7-3969aaa31291"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("683c0223-7f0e-45a8-b0db-e02d8c3a59fa"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("c34d113d-3a67-456d-8aec-f6f079cbda2e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				CurveCenterPosition = new Point(234, 510),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1b5a8982-0970-4312-9b3a-f3bc2974af1e"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3d53e11b-8807-41e7-b41e-5097f22fb088"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateSysCustomerIdentificationLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaSysCustomerIdentificationLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("7a2a246b-573d-43ab-b02f-6b133ae45d1e"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SysCustomerIdentificationLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaSysCustomerIdentificationLaneSet;
		}

		protected virtual ProcessSchemaLane CreateSysCustomerIdentificationLaneLane() {
			ProcessSchemaLane schemaSysCustomerIdentificationLane = new ProcessSchemaLane(this) {
				UId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("7a2a246b-573d-43ab-b02f-6b133ae45d1e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SysCustomerIdentificationLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaSysCustomerIdentificationLane;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("38a27e74-f454-47ae-bdba-787192d3d42e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"Start1",
				Position = new Point(92, 16),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("683c0223-7f0e-45a8-b0db-e02d8c3a59fa"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"Terminate1",
				Position = new Point(792, 317),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTaskSetSearchIdFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("6b525282-5ace-4919-8d75-a818882113b4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"FormulaTaskSetSearchId",
				Position = new Point(71, 191),
				ResultParameterMetaPath = @"0d3e248a-e509-42cd-afe9-a5fa1fb6e3c3",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,139,86,14,174,44,14,75,44,202,76,76,202,73,213,115,44,45,201,119,47,205,76,81,142,5,0,88,38,247,74,24,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTaskNumderSearchFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("4a61c6f9-2761-4a74-b0f9-d66f3611a8bc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"FormulaTaskNumderSearch",
				Position = new Point(414, 20),
				ResultParameterMetaPath = @"7f5896e4-61f2-43a1-9f10-292eadb29a3d",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,205,177,14,194,32,16,0,208,95,33,233,162,137,215,20,161,20,250,7,78,154,116,36,12,112,119,88,19,219,129,214,56,24,255,221,186,58,186,190,229,249,202,159,150,243,115,230,50,224,200,83,236,115,188,47,28,234,77,127,224,18,75,156,120,229,210,191,156,52,72,54,38,104,49,73,208,74,39,72,186,205,224,136,58,39,37,105,118,246,29,170,80,15,143,180,172,229,54,95,119,162,57,8,255,207,69,104,145,137,37,56,187,13,154,142,10,92,147,37,32,70,221,25,74,202,32,126,47,177,255,0,176,33,63,64,203,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("5b3b7702-f66b-44e0-95a6-29c0034a0758"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"ExclusiveGateway1",
				Position = new Point(309, 100),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("e87f397d-e22b-4461-bffc-7cbcb9ceae07"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"FormulaTask1",
				Position = new Point(414, 177),
				ResultParameterMetaPath = @"7f5896e4-61f2-43a1-9f10-292eadb29a3d",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,139,86,142,246,44,246,47,207,75,45,10,78,206,72,205,77,180,74,75,204,41,78,141,213,3,138,162,9,4,36,22,37,230,166,150,164,22,89,85,91,26,154,37,167,88,36,38,233,154,38,39,25,234,154,24,155,36,233,38,153,152,166,233,90,166,164,152,91,26,26,166,152,164,90,90,212,198,42,199,2,0,75,147,96,4,93,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("3c03a139-d8fc-41c6-a5e1-935c704530c8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("25df9113-8047-4ea2-8562-6c0103dce080"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"ExclusiveGateway2",
				Position = new Point(246, 303),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway3ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("b317722f-8ea8-4059-98bd-ca2a8b8f518e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d825fbe-4308-4081-a307-7964bcd2243e"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"ExclusiveGateway3",
				Position = new Point(78, 303),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway4ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("3d53e11b-8807-41e7-b41e-5097f22fb088"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("6d825fbe-4308-4081-a307-7964bcd2243e"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"ExclusiveGateway4",
				Position = new Point(246, 450),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaScriptTask CreateDeleteOldRecordsScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9156360a-f0c7-4a54-9aec-a744d3e3470b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5718c33a-2d04-45a2-a423-140ea6f39686"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"DeleteOldRecordsScriptTask",
				Position = new Point(71, 86),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,85,142,59,11,194,48,20,133,103,5,255,67,232,148,14,102,233,40,14,210,42,20,68,197,7,206,33,61,216,66,155,192,205,77,213,127,239,173,147,78,23,238,249,206,99,180,164,92,34,130,231,27,187,202,50,212,90,77,231,218,13,48,242,58,132,231,106,49,31,5,75,236,138,202,190,227,230,17,132,249,55,153,77,211,76,154,94,22,185,224,30,79,85,161,7,67,223,34,168,12,222,195,113,23,124,190,152,207,204,142,194,160,179,242,90,95,96,201,181,103,196,212,115,246,149,238,45,8,162,17,36,180,57,250,44,55,117,220,35,70,93,134,62,13,222,156,44,217,65,114,73,255,204,201,197,107,182,47,184,36,133,83,63,129,19,121,197,148,176,250,0,149,241,226,242,226,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchContactsByNameScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c8696baf-2afd-43f3-a99e-ed89773b6a27"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchContactsByNameScriptTask",
				Position = new Point(547, 450),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,79,205,10,130,64,16,62,43,248,14,203,158,20,150,94,64,58,69,183,136,204,160,243,98,83,46,212,106,179,179,148,132,239,222,104,161,45,29,191,111,190,191,41,60,96,183,106,236,201,144,105,172,184,135,112,41,44,60,68,17,146,175,36,142,54,112,166,245,179,69,112,238,79,119,245,55,59,223,82,201,78,210,21,73,37,228,86,223,64,102,138,3,166,184,67,215,2,251,195,142,129,92,148,164,145,142,134,234,65,191,55,151,250,167,209,177,101,216,17,77,189,59,141,28,78,128,169,44,65,99,85,143,93,74,204,32,99,125,159,196,125,158,196,31,242,59,204,165,225,215,74,16,122,200,88,134,64,30,237,8,243,55,14,66,39,144,41,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchAccountsByNameScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("355d7dac-42a4-4148-8d76-ccd3b30814fc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchAccountsByNameScriptTask",
				Position = new Point(680, 450),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,79,75,10,194,48,16,93,183,208,59,132,172,90,8,94,160,184,16,113,39,98,173,224,58,212,209,6,108,82,39,19,180,72,239,110,90,165,53,184,124,111,222,111,10,7,216,173,141,62,43,82,70,179,123,8,151,76,195,131,21,33,249,74,226,104,11,23,218,60,91,4,107,255,116,55,215,232,249,150,242,85,85,25,167,137,11,198,119,178,1,158,9,31,48,197,29,187,22,188,63,236,24,200,69,73,18,233,164,168,30,244,7,117,173,127,26,173,183,12,59,162,169,119,47,209,135,19,96,202,75,144,88,213,99,151,96,51,200,188,190,79,226,62,79,226,15,249,29,102,211,240,107,193,8,29,100,94,134,64,14,245,8,243,55,125,122,110,119,41,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchContactsStartsWithNumberTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d4f3f318-00c5-442c-b401-caf98d692954"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchContactsStartsWithNumberTask",
				Position = new Point(547, 100),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,223,10,130,48,20,198,175,19,124,135,177,43,5,233,5,164,43,233,46,34,51,232,122,218,49,7,110,218,217,25,37,225,187,183,97,88,214,229,190,125,127,126,156,220,2,14,89,167,47,146,100,167,217,109,249,220,48,13,119,150,47,197,103,24,172,118,80,211,246,209,35,24,243,231,107,173,210,159,191,136,187,36,137,138,178,78,41,171,101,37,124,9,79,24,47,64,96,213,236,173,42,1,121,156,184,214,121,227,52,244,224,74,151,195,94,92,23,36,144,206,146,26,239,63,202,107,243,133,97,92,196,195,173,102,152,131,64,161,128,0,29,133,104,91,192,194,150,211,172,3,248,81,98,151,28,195,96,76,195,96,18,222,220,38,90,30,37,97,181,104,13,196,206,135,64,22,53,35,180,144,190,0,184,19,86,165,73,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchAccountsStartsWithNumberScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("5475b1a2-420b-44c0-9342-41eae9f20154"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchAccountsStartsWithNumberScriptTask",
				Position = new Point(680, 100),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,65,11,130,64,16,133,207,10,254,135,101,79,10,210,31,144,14,33,221,34,50,131,206,171,141,185,224,174,54,59,75,73,248,223,91,49,44,235,56,111,222,188,247,49,153,5,236,211,86,95,36,201,86,179,219,114,92,51,13,119,150,45,197,103,224,123,59,168,104,251,232,16,140,249,243,53,86,233,207,46,228,155,178,108,173,166,180,85,202,106,89,138,49,132,199,140,231,32,176,172,247,86,21,128,60,138,93,234,220,113,234,59,112,161,203,226,81,92,229,36,144,206,146,234,209,127,148,215,250,11,195,184,147,17,206,155,97,14,2,133,2,2,12,121,42,154,6,48,183,197,84,235,0,126,148,200,93,14,129,63,36,129,63,9,111,110,19,46,159,18,179,74,52,6,34,231,67,32,139,154,17,90,72,94,253,189,244,145,73,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchContactsEqualsNumberTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d467a680-c2ee-4e1d-9f0b-3a1ba7afc429"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchContactsEqualsNumberTask",
				Position = new Point(547, 303),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,65,14,130,48,16,69,215,144,112,135,166,43,72,136,23,32,174,8,59,99,4,189,64,197,65,72,218,2,211,86,37,134,187,59,68,131,54,46,103,250,230,255,151,150,14,112,202,123,125,233,108,215,107,54,250,227,150,105,184,179,210,95,62,163,48,216,65,99,139,199,128,96,204,31,39,157,210,223,183,152,211,165,21,181,205,123,165,156,238,106,177,132,240,148,241,35,8,172,219,189,83,103,64,158,164,148,186,118,156,166,1,40,212,47,94,150,155,98,116,66,46,108,213,93,219,31,5,67,248,34,22,172,34,7,129,66,129,5,36,3,33,37,96,5,55,64,3,84,237,205,9,93,205,81,56,103,81,248,54,250,248,154,216,255,140,148,53,66,18,78,28,130,117,168,153,69,7,217,11,9,46,211,1,65,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchAccountsEqualsNumberTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("be50be51-361c-4985-9ee7-3969aaa31291"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SearchAccountsEqualsNumberTask",
				Position = new Point(680, 303),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,209,10,130,48,20,134,175,21,124,135,177,43,3,233,5,164,139,16,239,34,210,122,129,181,142,57,216,166,158,109,149,132,239,222,164,176,70,151,231,236,219,255,127,156,202,1,142,69,167,47,194,138,78,147,33,28,55,68,195,157,84,225,242,153,196,209,14,26,91,62,122,4,99,254,56,233,148,254,190,165,116,203,121,231,180,45,58,165,156,22,156,205,33,52,35,244,8,12,121,187,119,234,12,72,87,153,79,93,58,78,99,15,62,52,44,158,151,235,114,112,76,206,108,45,174,237,143,130,241,248,44,22,45,34,7,134,76,129,5,76,105,193,164,4,172,225,6,104,192,87,7,243,202,255,154,146,120,202,147,248,109,244,241,53,105,120,140,140,52,76,122,220,115,8,214,161,38,22,29,228,47,202,254,100,191,65,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate2TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("9307597f-1e4a-4fad-bc27-a307b264a9ba"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"Terminate2",
				Position = new Point(260, 590),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetSearchNameFormulaTaskFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("1b5a8982-0970-4312-9b3a-f3bc2974af1e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("2f31a2a0-28a3-4244-8734-1a1ea86b4332"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("70c9fed5-9999-4fb0-9d40-3b191b8e50a2"),
				CreatedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"),
				Name = @"SetSearchNameFormulaTask",
				Position = new Point(71, 450),
				ResultParameterMetaPath = @"dbc20a42-e0bb-4804-bb1f-a4ddc095bae2",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,139,86,142,246,44,246,47,207,75,45,10,78,206,72,205,77,180,74,75,204,41,78,141,213,3,138,162,9,4,36,22,37,230,166,150,164,22,89,85,91,26,154,37,167,88,36,38,233,154,38,39,25,234,154,24,155,36,233,38,153,152,166,233,90,166,164,152,91,26,26,166,152,164,90,90,212,198,42,199,2,0,75,147,96,4,93,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("df2ce92a-0bb7-4aa1-a398-4f26df454af0"),
				Name = "Newtonsoft.Json",
				Alias = "",
				CreatedInPackageId = new Guid("8db6947f-a1e0-41fa-b344-e271842ea6ea")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SysCustomerIdentificationProcess(userConnection);
		}

		public override object Clone() {
			return new SysCustomerIdentificationProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe"));
		}

		#endregion

	}

	#endregion

	#region Class: SysCustomerIdentificationProcess

	/// <exclude/>
	public class SysCustomerIdentificationProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessSysCustomerIdentificationLane

		/// <exclude/>
		public class ProcessSysCustomerIdentificationLane : ProcessLane
		{

			public ProcessSysCustomerIdentificationLane(UserConnection userConnection, SysCustomerIdentificationProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SysCustomerIdentificationProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysCustomerIdentificationProcess";
			SchemaUId = new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_searchNumberLength = () => { return (int)(((Int32)SysSettings.GetValue(UserConnection, "SearchNumberLength"))); };
			_internalNumberLength = () => { return (int)(((Int32)SysSettings.GetValue(UserConnection, "InternalNumberLength"))); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("84163ce8-4b34-48a6-a753-d0404758f7fe");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SysCustomerIdentificationProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SysCustomerIdentificationProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string CallerReverse {
			get;
			set;
		}

		public virtual Guid SearchId {
			get;
			set;
		}

		private Func<int> _searchNumberLength;
		public virtual int SearchNumberLength {
			get {
				return (_searchNumberLength ?? (_searchNumberLength = () => 0)).Invoke();
			}
			set {
				_searchNumberLength = () => { return value; };
			}
		}

		public virtual string CallerSubSearch {
			get;
			set;
		}

		private Func<int> _internalNumberLength;
		public virtual int InternalNumberLength {
			get {
				return (_internalNumberLength ?? (_internalNumberLength = () => 0)).Invoke();
			}
			set {
				_internalNumberLength = () => { return value; };
			}
		}

		public virtual bool IsManualSearch {
			get;
			set;
		}

		private string _phoneCommunicationCode;
		public virtual string PhoneCommunicationCode {
			get {
				return _phoneCommunicationCode ?? (_phoneCommunicationCode = GetLocalizableString("84163ce84b3448a6a753d0404758f7fe",
						 "Parameters.PhoneCommunicationCode.Value"));
			}
			set {
				_phoneCommunicationCode = value;
			}
		}

		public virtual string SearchName {
			get;
			set;
		}

		private ProcessSysCustomerIdentificationLane _sysCustomerIdentificationLane;
		public ProcessSysCustomerIdentificationLane SysCustomerIdentificationLane {
			get {
				return _sysCustomerIdentificationLane ?? ((_sysCustomerIdentificationLane) = new ProcessSysCustomerIdentificationLane(UserConnection, this));
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
					SchemaElementUId = new Guid("38a27e74-f454-47ae-bdba-787192d3d42e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("683c0223-7f0e-45a8-b0db-e02d8c3a59fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _formulaTaskSetSearchId;
		public ProcessScriptTask FormulaTaskSetSearchId {
			get {
				return _formulaTaskSetSearchId ?? (_formulaTaskSetSearchId = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTaskSetSearchId",
					SchemaElementUId = new Guid("6b525282-5ace-4919-8d75-a818882113b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTaskSetSearchIdExecute,
				});
			}
		}

		private ProcessScriptTask _formulaTaskNumderSearch;
		public ProcessScriptTask FormulaTaskNumderSearch {
			get {
				return _formulaTaskNumderSearch ?? (_formulaTaskNumderSearch = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTaskNumderSearch",
					SchemaElementUId = new Guid("4a61c6f9-2761-4a74-b0f9-d66f3611a8bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTaskNumderSearchExecute,
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
					SchemaElementUId = new Guid("5b3b7702-f66b-44e0-95a6-29c0034a0758"),
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

		private ProcessScriptTask _formulaTask1;
		public ProcessScriptTask FormulaTask1 {
			get {
				return _formulaTask1 ?? (_formulaTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask1",
					SchemaElementUId = new Guid("e87f397d-e22b-4461-bffc-7cbcb9ceae07"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
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
					SchemaElementUId = new Guid("3c03a139-d8fc-41c6-a5e1-935c704530c8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("b317722f-8ea8-4059-98bd-ca2a8b8f518e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway3.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
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
					SchemaElementUId = new Guid("3d53e11b-8807-41e7-b41e-5097f22fb088"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway4.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _deleteOldRecordsScriptTask;
		public ProcessScriptTask DeleteOldRecordsScriptTask {
			get {
				return _deleteOldRecordsScriptTask ?? (_deleteOldRecordsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DeleteOldRecordsScriptTask",
					SchemaElementUId = new Guid("9156360a-f0c7-4a54-9aec-a744d3e3470b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = DeleteOldRecordsScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _searchContactsByNameScriptTask;
		public ProcessScriptTask SearchContactsByNameScriptTask {
			get {
				return _searchContactsByNameScriptTask ?? (_searchContactsByNameScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchContactsByNameScriptTask",
					SchemaElementUId = new Guid("c8696baf-2afd-43f3-a99e-ed89773b6a27"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchContactsByNameScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _searchAccountsByNameScriptTask;
		public ProcessScriptTask SearchAccountsByNameScriptTask {
			get {
				return _searchAccountsByNameScriptTask ?? (_searchAccountsByNameScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchAccountsByNameScriptTask",
					SchemaElementUId = new Guid("355d7dac-42a4-4148-8d76-ccd3b30814fc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchAccountsByNameScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _searchContactsStartsWithNumberTask;
		public ProcessScriptTask SearchContactsStartsWithNumberTask {
			get {
				return _searchContactsStartsWithNumberTask ?? (_searchContactsStartsWithNumberTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchContactsStartsWithNumberTask",
					SchemaElementUId = new Guid("d4f3f318-00c5-442c-b401-caf98d692954"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchContactsStartsWithNumberTaskExecute,
				});
			}
		}

		private ProcessScriptTask _searchAccountsStartsWithNumberScriptTask;
		public ProcessScriptTask SearchAccountsStartsWithNumberScriptTask {
			get {
				return _searchAccountsStartsWithNumberScriptTask ?? (_searchAccountsStartsWithNumberScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchAccountsStartsWithNumberScriptTask",
					SchemaElementUId = new Guid("5475b1a2-420b-44c0-9342-41eae9f20154"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchAccountsStartsWithNumberScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _searchContactsEqualsNumberTask;
		public ProcessScriptTask SearchContactsEqualsNumberTask {
			get {
				return _searchContactsEqualsNumberTask ?? (_searchContactsEqualsNumberTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchContactsEqualsNumberTask",
					SchemaElementUId = new Guid("d467a680-c2ee-4e1d-9f0b-3a1ba7afc429"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchContactsEqualsNumberTaskExecute,
				});
			}
		}

		private ProcessScriptTask _searchAccountsEqualsNumberTask;
		public ProcessScriptTask SearchAccountsEqualsNumberTask {
			get {
				return _searchAccountsEqualsNumberTask ?? (_searchAccountsEqualsNumberTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchAccountsEqualsNumberTask",
					SchemaElementUId = new Guid("be50be51-361c-4985-9ee7-3969aaa31291"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SearchAccountsEqualsNumberTaskExecute,
				});
			}
		}

		private ProcessTerminateEvent _terminate2;
		public ProcessTerminateEvent Terminate2 {
			get {
				return _terminate2 ?? (_terminate2 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate2",
					SchemaElementUId = new Guid("9307597f-1e4a-4fad-bc27-a307b264a9ba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _setSearchNameFormulaTask;
		public ProcessScriptTask SetSearchNameFormulaTask {
			get {
				return _setSearchNameFormulaTask ?? (_setSearchNameFormulaTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetSearchNameFormulaTask",
					SchemaElementUId = new Guid("1b5a8982-0970-4312-9b3a-f3bc2974af1e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetSearchNameFormulaTaskExecute,
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
					SchemaElementUId = new Guid("73c3071e-f09c-45c0-9d67-c5254488cd62"),
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
					SchemaElementUId = new Guid("3bb9ca04-03cd-4d79-8308-dfa7c31e2df2"),
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
					SchemaElementUId = new Guid("15a4413d-451a-4dec-b227-c37a1df36b1d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow4;
		public ProcessConditionalFlow ConditionalFlow4 {
			get {
				return _conditionalFlow4 ?? (_conditionalFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow4",
					SchemaElementUId = new Guid("eb975285-0927-4df0-a5db-43104cb1a17d"),
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
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[FormulaTaskSetSearchId.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTaskSetSearchId };
			FlowElements[FormulaTaskNumderSearch.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTaskNumderSearch };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[ExclusiveGateway3.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway3 };
			FlowElements[ExclusiveGateway4.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway4 };
			FlowElements[DeleteOldRecordsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DeleteOldRecordsScriptTask };
			FlowElements[SearchContactsByNameScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchContactsByNameScriptTask };
			FlowElements[SearchAccountsByNameScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchAccountsByNameScriptTask };
			FlowElements[SearchContactsStartsWithNumberTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchContactsStartsWithNumberTask };
			FlowElements[SearchAccountsStartsWithNumberScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchAccountsStartsWithNumberScriptTask };
			FlowElements[SearchContactsEqualsNumberTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchContactsEqualsNumberTask };
			FlowElements[SearchAccountsEqualsNumberTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchAccountsEqualsNumberTask };
			FlowElements[Terminate2.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate2 };
			FlowElements[SetSearchNameFormulaTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetSearchNameFormulaTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DeleteOldRecordsScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "FormulaTaskSetSearchId":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway3", e.Context.SenderName));
						break;
					case "FormulaTaskNumderSearch":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchContactsStartsWithNumberTask", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTaskNumderSearch", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchContactsStartsWithNumberTask", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (ConditionalFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchContactsEqualsNumberTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ExclusiveGateway3":
						if (ConditionalFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetSearchNameFormulaTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ExclusiveGateway4":
						if (ConditionalFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchContactsByNameScriptTask", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate2", e.Context.SenderName));
						break;
					case "DeleteOldRecordsScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTaskSetSearchId", e.Context.SenderName));
						break;
					case "SearchContactsByNameScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchAccountsByNameScriptTask", e.Context.SenderName));
						break;
					case "SearchAccountsByNameScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "SearchContactsStartsWithNumberTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchAccountsStartsWithNumberScriptTask", e.Context.SenderName));
						break;
					case "SearchAccountsStartsWithNumberScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "SearchContactsEqualsNumberTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchAccountsEqualsNumberTask", e.Context.SenderName));
						break;
					case "SearchAccountsEqualsNumberTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "Terminate2":
						CompleteProcess();
						break;
					case "SetSearchNameFormulaTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway4", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((CallerReverse).Length >= (SearchNumberLength));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway1", "ConditionalFlow1", "(CallerReverse).Length >= (SearchNumberLength)", result);
			return result;
		}

		private bool ConditionalFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((CallerReverse).Length <= (InternalNumberLength));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "ConditionalFlow2", "(CallerReverse).Length <= (InternalNumberLength)", result);
			return result;
		}

		private bool ConditionalFlow3ExpressionExecute() {
			bool result = Convert.ToBoolean((IsManualSearch));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway3", "ConditionalFlow3", "(IsManualSearch)", result);
			return result;
		}

		private bool ConditionalFlow4ExpressionExecute() {
			bool result = Convert.ToBoolean((SearchName).Length >= 3);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway4", "ConditionalFlow4", "(SearchName).Length >= 3", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CallerReverse")) {
				writer.WriteValue("CallerReverse", CallerReverse, null);
			}
			if (!HasMapping("SearchId")) {
				writer.WriteValue("SearchId", SearchId, Guid.Empty);
			}
			if (!HasMapping("CallerSubSearch")) {
				writer.WriteValue("CallerSubSearch", CallerSubSearch, null);
			}
			if (!HasMapping("IsManualSearch")) {
				writer.WriteValue("IsManualSearch", IsManualSearch, false);
			}
			if (!HasMapping("PhoneCommunicationCode")) {
				writer.WriteValue("PhoneCommunicationCode", PhoneCommunicationCode, null);
			}
			if (!HasMapping("SearchName")) {
				writer.WriteValue("SearchName", SearchName, null);
			}
			if (!HasMapping("SearchNumberLength")) {
				writer.WriteValue("SearchNumberLength", SearchNumberLength, 0);
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
			MetaPathParameterValues.Add("916cd8ab-5cb1-434b-b45f-9dd7911d4e98", () => CallerReverse);
			MetaPathParameterValues.Add("0d3e248a-e509-42cd-afe9-a5fa1fb6e3c3", () => SearchId);
			MetaPathParameterValues.Add("dc8cede1-985f-4d23-90f1-cca476db36cc", () => SearchNumberLength);
			MetaPathParameterValues.Add("7f5896e4-61f2-43a1-9f10-292eadb29a3d", () => CallerSubSearch);
			MetaPathParameterValues.Add("05116a88-6e14-473e-abf8-cda57547b65a", () => InternalNumberLength);
			MetaPathParameterValues.Add("c3e46c6f-a811-4cd0-806d-548ffaabe04b", () => IsManualSearch);
			MetaPathParameterValues.Add("9e547af5-46bf-4bb8-9e0f-ed9cb32ceb4c", () => PhoneCommunicationCode);
			MetaPathParameterValues.Add("dbc20a42-e0bb-4804-bb1f-a4ddc095bae2", () => SearchName);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CallerReverse":
					if (!hasValueToRead) break;
					CallerReverse = reader.GetValue<System.String>();
				break;
				case "SearchId":
					if (!hasValueToRead) break;
					SearchId = reader.GetValue<System.Guid>();
				break;
				case "CallerSubSearch":
					if (!hasValueToRead) break;
					CallerSubSearch = reader.GetValue<System.String>();
				break;
				case "IsManualSearch":
					if (!hasValueToRead) break;
					IsManualSearch = reader.GetValue<System.Boolean>();
				break;
				case "PhoneCommunicationCode":
					if (!hasValueToRead) break;
					PhoneCommunicationCode = reader.GetValue<System.String>();
				break;
				case "SearchName":
					if (!hasValueToRead) break;
					SearchName = reader.GetValue<System.String>();
				break;
				case "SearchNumberLength":
					if (!hasValueToRead) break;
					SearchNumberLength = reader.GetValue<System.Int32>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool FormulaTaskSetSearchIdExecute(ProcessExecutingContext context) {
			var localSearchId = ((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "AutoGuid"));
			SearchId = (System.Guid)localSearchId;
			return true;
		}

		public virtual bool FormulaTaskNumderSearchExecute(ProcessExecutingContext context) {
			var localCallerSubSearch = (CallerReverse).Substring( 0, (SearchNumberLength) );
			CallerSubSearch = (System.String)localCallerSubSearch;
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localCallerSubSearch = (CallerReverse);
			CallerSubSearch = (System.String)localCallerSubSearch;
			return true;
		}

		public virtual bool DeleteOldRecordsScriptTaskExecute(ProcessExecutingContext context) {
			var currentUtcDate = DateTime.UtcNow;
			var utc3DaysAgo = currentUtcDate.AddDays(-3);
			new Delete(UserConnection)
				.From("CTISearchResult")
				.Where("CreatedOn").IsLess(Column.Parameter(utc3DaysAgo))
			.Execute();
			return true;
		}

		public virtual bool SearchContactsByNameScriptTaskExecute(ProcessExecutingContext context) {
			QueryCondition queryCondition = new QueryCondition {
				LeftExpression = new QueryColumnExpression("Contact", "Name"),
				ConditionType = QueryConditionType.StartWith,
				RightExpressions = {
					new QueryParameter("SearchName", SearchName)
				}
			};
			SearchContacts(queryCondition, true);
			return true;
		}

		public virtual bool SearchAccountsByNameScriptTaskExecute(ProcessExecutingContext context) {
			QueryCondition queryCondition = new QueryCondition {
				LeftExpression = new QueryColumnExpression("Account", "Name"),
				ConditionType = QueryConditionType.StartWith,
				RightExpressions = {
					new QueryParameter("SearchName", SearchName)
				}
			};
			SearchAccounts(queryCondition, true);
			return true;
		}

		public virtual bool SearchContactsStartsWithNumberTaskExecute(ProcessExecutingContext context) {
			QueryCondition queryCondition = new QueryCondition {
				LeftExpression = new QueryColumnExpression("ContactCommunication", "SearchNumber"),
				ConditionType = QueryConditionType.StartWith,
				RightExpressions = {
					new QueryParameter("CallerSubSearch", CallerSubSearch)
				}
			};
			SearchContacts(queryCondition, false);
			return true;
		}

		public virtual bool SearchAccountsStartsWithNumberScriptTaskExecute(ProcessExecutingContext context) {
			QueryCondition queryCondition = new QueryCondition {
				LeftExpression = new QueryColumnExpression("AccountCommunication", "SearchNumber"),
				ConditionType = QueryConditionType.StartWith,
				RightExpressions = {
					new QueryParameter("CallerSubSearch", CallerSubSearch)
				}
			};
			SearchAccounts(queryCondition, false);
			return true;
		}

		public virtual bool SearchContactsEqualsNumberTaskExecute(ProcessExecutingContext context) {
			QueryCondition queryCondition = new QueryCondition {
				LeftExpression = new QueryColumnExpression("ContactCommunication", "SearchNumber"),
				ConditionType = QueryConditionType.Equal,
				RightExpressions = {
					new QueryParameter("CallerReverse", CallerReverse)
				}
			};
			SearchContacts(queryCondition, false);
			return true;
		}

		public virtual bool SearchAccountsEqualsNumberTaskExecute(ProcessExecutingContext context) {
			QueryCondition queryCondition = new QueryCondition {
				LeftExpression = new QueryColumnExpression("AccountCommunication", "SearchNumber"),
				ConditionType = QueryConditionType.Equal,
				RightExpressions = {
					new QueryParameter("CallerReverse", CallerReverse)
				}
			};
			SearchAccounts(queryCondition, false);
			return true;
		}

		public virtual bool SetSearchNameFormulaTaskExecute(ProcessExecutingContext context) {
			var localSearchName = (CallerReverse);
			SearchName = (System.String)localSearchName;
			return true;
		}

			
			public virtual void SearchContacts(QueryCondition queryCondition, bool needJoinParentTable) {
				var select = new Select(UserConnection)
				.Column("ContactId")
				.Column(Column.Parameter(SearchId))
				.Column("CommunicationTypeId")
				.Column("Number")
			.From("ContactCommunication");
			if (needJoinParentTable) {
				select.Join(JoinType.Inner, "Contact")
					.On("Contact", "Id").IsEqual("ContactCommunication", "ContactId");
			}
			select.Where(queryCondition).And().Exists(new Select(UserConnection)
				.Column("ComTypebyCommunication", "Id")
				.From("ComTypebyCommunication")
				.Join(JoinType.Inner, "Communication")
					.On("Communication", "Id").IsEqual("ComTypebyCommunication", "CommunicationId")
				.Where("Communication", "Code").IsEqual(new QueryParameter("PhoneCommunicationCode",
					PhoneCommunicationCode))
				.And("ComTypebyCommunication", "CommunicationTypeId")
					.IsEqual("ContactCommunication", "CommunicationTypeId")
			);
			select.SpecifyNoLockHints();
			var insertSelect = new InsertSelect(UserConnection).Into("CTISearchResult")
				.Set("ContactId", "SearchId", "CommunicationTypeId", "Number")
			.FromSelect(select);
			insertSelect.Execute();
			}
			
			
			public virtual void SearchAccounts(QueryCondition queryCondition, bool needJoinParentTable) {
				var select = new Select(UserConnection)
				.Column("AccountId")
				.Column(Column.Parameter(SearchId))
				.Column("CommunicationTypeId")
				.Column("Number")
			.From("AccountCommunication");
			if (needJoinParentTable) {
				select.Join(JoinType.Inner, "Account")
					.On("Account", "Id").IsEqual("AccountCommunication", "AccountId");
			}
			select.Where(queryCondition).And().Exists(new Select(UserConnection)
				.Column("ComTypebyCommunication", "Id")
				.From("ComTypebyCommunication")
				.Join(JoinType.Inner, "Communication")
					.On("Communication", "Id").IsEqual("ComTypebyCommunication", "CommunicationId")
				.Where("Communication", "Code").IsEqual(new QueryParameter("PhoneCommunicationCode",
					PhoneCommunicationCode))
				.And("ComTypebyCommunication", "CommunicationTypeId")
					.IsEqual("AccountCommunication", "CommunicationTypeId")
			);
			select.SpecifyNoLockHints();
			var insertSelect = new InsertSelect(UserConnection).Into("CTISearchResult")
				.Set("AccountId", "SearchId", "CommunicationTypeId", "Number")
			.FromSelect(select);
			insertSelect.Execute();
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
			var cloneItem = (SysCustomerIdentificationProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

