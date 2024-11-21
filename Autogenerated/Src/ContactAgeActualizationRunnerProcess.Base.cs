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

	#region Class: ContactAgeActualizationRunnerProcessSchema

	/// <exclude/>
	public class ContactAgeActualizationRunnerProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContactAgeActualizationRunnerProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContactAgeActualizationRunnerProcessSchema(ContactAgeActualizationRunnerProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContactAgeActualizationRunnerProcess";
			UId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259");
			CreatedInPackageId = new Guid("e328e2fc-98b1-4417-a1fa-f336c3ff3364");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = null;
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseSystemSecurityContext = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = true;
		}

		protected virtual ProcessSchemaParameter CreatePeriodStartDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d53b4f3b-3dba-4cbc-8854-c9aa81678523"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"PeriodStartDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Date"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePeriodStartDateParameter());
		}

		protected virtual void InitializeActualizeContactAgeSubprocessParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dateToParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("395304e1-4898-4208-839b-d8a6915e89db"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"DateTo",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime")
			};
			dateToParameter.SourceValue = new ProcessSchemaParameterValue(dateToParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysVariable.CurrentDate#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259")
			};
			parametrizedElement.Parameters.Add(dateToParameter);
			var dateFromParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4696d1a0-ad34-47d3-a3bf-98710eb1bd43"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"DateFrom",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime")
			};
			dateFromParameter.SourceValue = new ProcessSchemaParameterValue(dateFromParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"([#SysSettings.LastAgeActualizationDate<DateTime>#] != null && [#SysSettings.LastAgeActualizationDate<DateTime>#] != DateTime.MinValue && [#SysSettings.LastAgeActualizationDate<DateTime>#] != [#SysVariable.CurrentDate#]) ? ([#SysSettings.LastAgeActualizationDate<DateTime>#]).AddDays(1) : [#SysVariable.CurrentDate#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259")
			};
			parametrizedElement.Parameters.Add(dateFromParameter);
			var isActualizeAllRecordParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5201e962-c146-47e6-90b8-1846fb49732b"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"IsActualizeAllRecord",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isActualizeAllRecordParameter.SourceValue = new ProcessSchemaParameterValue(isActualizeAllRecordParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#BooleanValue.False#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259")
			};
			parametrizedElement.Parameters.Add(isActualizeAllRecordParameter);
			var chunkSizeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3226305e-d91e-46b3-a8e7-ac23b1341db5"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ChunkSize",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			chunkSizeParameter.SourceValue = new ProcessSchemaParameterValue(chunkSizeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(chunkSizeParameter);
			var maxDegreeOfParallelismParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4d2a0eb8-f5f6-495f-b681-6bf77abfe484"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"MaxDegreeOfParallelism",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			maxDegreeOfParallelismParameter.SourceValue = new ProcessSchemaParameterValue(maxDegreeOfParallelismParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(maxDegreeOfParallelismParameter);
			var chunkProcessingDelayParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("58d04aab-c253-4412-b17d-85ca88ac5282"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"ChunkProcessingDelay",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			chunkProcessingDelayParameter.SourceValue = new ProcessSchemaParameterValue(chunkProcessingDelayParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(chunkProcessingDelayParameter);
			var startNotificationTextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb4853be-8ed3-4d0c-af70-8aeb7a37838c"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"StartNotificationText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText")
			};
			startNotificationTextParameter.SourceValue = new ProcessSchemaParameterValue(startNotificationTextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(startNotificationTextParameter);
			var finishNotificationTextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dbd06a9a-0b70-4daf-a78c-4130ef618340"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"FinishNotificationText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText")
			};
			finishNotificationTextParameter.SourceValue = new ProcessSchemaParameterValue(finishNotificationTextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(finishNotificationTextParameter);
			var isNeedToNotifyUserParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("58775490-e567-4a30-b07e-b888064e2efc"),
				ContainerUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Direction = ProcessSchemaParameterDirection.In,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				Name = @"IsNeedToNotifyUser",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isNeedToNotifyUserParameter.SourceValue = new ProcessSchemaParameterValue(isNeedToNotifyUserParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b")
			};
			parametrizedElement.Parameters.Add(isNeedToNotifyUserParameter);
		}

		protected virtual void InitializeIntermediateCatchTimer1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var startOffsetParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0357bba3-0fc5-403f-9b01-2df8ff753ca7"),
				ContainerUId = new Guid("47f93b2e-3e09-4276-8e41-28a0f87266cd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"StartOffset",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startOffsetParameter.SourceValue = new ProcessSchemaParameterValue(startOffsetParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259")
			};
			parametrizedElement.Parameters.Add(startOffsetParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaSubProcess actualizecontactagesubprocess = CreateActualizeContactAgeSubprocessSubProcess();
			FlowElements.Add(actualizecontactagesubprocess);
			ProcessSchemaSubProcess ageactualizationjobrestartsubprocess = CreateAgeActualizationJobRestartSubprocessSubProcess();
			FlowElements.Add(ageactualizationjobrestartsubprocess);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaExclusiveGateway exclusivegateway2 = CreateExclusiveGateway2ExclusiveGateway();
			FlowElements.Add(exclusivegateway2);
			ProcessSchemaIntermediateCatchTimerEvent intermediatecatchtimer1 = CreateIntermediateCatchTimer1IntermediateCatchTimerEvent();
			FlowElements.Add(intermediatecatchtimer1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateIsDailyActualizationAllowedConditionalFlowConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("e3902975-0838-4c14-ac68-e030b936f418"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("58a80f81-db44-4926-b102-efdd77dda066"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("47f93b2e-3e09-4276-8e41-28a0f87266cd"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("d5743241-837f-442c-8e58-6d95980b9183"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("127fa174-9496-42a7-ad01-89a521a1cc5a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("e675b133-aab3-4d52-a0ba-ab32d4956230"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("127fa174-9496-42a7-ad01-89a521a1cc5a"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e2ae20ea-a3c4-4a84-913e-6b22fc8cae89"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateIsDailyActualizationAllowedConditionalFlowConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "IsDailyActualizationAllowedConditionalFlow",
				UId = new Guid("6942f372-46f4-430d-b1a4-fabf2a9dcdee"),
				ConditionExpression = @"[#SysSettings.ActualizeAge<Boolean>#] && [#SysSettings.RunAgeActualizationDaily<Boolean>#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("072e958c-3a57-4707-9807-cb7f0a6a0889"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("4a1fc05c-e26b-4960-8506-84eae0ef15d3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("072e958c-3a57-4707-9807-cb7f0a6a0889"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e2ae20ea-a3c4-4a84-913e-6b22fc8cae89"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(277, 136));
			schemaFlow.PolylinePointPositions.Add(new Point(798, 136));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("08fa7eee-6bc5-4ec3-b9c7-c8d9b76ff570"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("47f93b2e-3e09-4276-8e41-28a0f87266cd"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("072e958c-3a57-4707-9807-cb7f0a6a0889"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d201ddc0-a5e5-4c19-bbb9-38c10ad10c17"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d201ddc0-a5e5-4c19-bbb9-38c10ad10c17"),
				CreatedInOwnerSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("58a80f81-db44-4926-b102-efdd77dda066"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"StartEvent1",
				Position = new Point(80, 180),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("e2ae20ea-a3c4-4a84-913e-6b22fc8cae89"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"TerminateEvent1",
				Position = new Point(785, 180),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaSubProcess CreateActualizeContactAgeSubprocessSubProcess() {
			ProcessSchemaSubProcess schemaActualizeContactAgeSubprocess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"ActualizeContactAgeSubprocess",
				Position = new Point(505, 166),
				SchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			InitializeActualizeContactAgeSubprocessParameters(schemaActualizeContactAgeSubprocess);
			return schemaActualizeContactAgeSubprocess;
		}

		protected virtual ProcessSchemaSubProcess CreateAgeActualizationJobRestartSubprocessSubProcess() {
			ProcessSchemaSubProcess schemaAgeActualizationJobRestartSubprocess = new ProcessSchemaSubProcess(this) {
				UId = new Guid("127fa174-9496-42a7-ad01-89a521a1cc5a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				EntitySchemaUId = Guid.Empty,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("49eafdbb-a89e-4bdf-a29d-7f17b1670a45"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"AgeActualizationJobRestartSubprocess",
				Position = new Point(656, 166),
				SchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				TriggeredByEvent = false,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaAgeActualizationJobRestartSubprocess;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway2ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("072e958c-3a57-4707-9807-cb7f0a6a0889"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"ExclusiveGateway2",
				Position = new Point(250, 166),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaIntermediateCatchTimerEvent CreateIntermediateCatchTimer1IntermediateCatchTimerEvent() {
			ProcessSchemaIntermediateCatchTimerEvent schemaCatchTimerEvent = new ProcessSchemaIntermediateCatchTimerEvent(this) {
				UId = new Guid("47f93b2e-3e09-4276-8e41-28a0f87266cd"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d0f0790b-45ea-4f02-b60d-7200272e0e16"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97"),
				CreatedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("97d1af3d-ef13-465c-b6d8-5425f78bf000"),
				ModifiedInSchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"),
				Name = @"IntermediateCatchTimer1",
				Position = new Point(165, 180),
				Size = new Size(27, 27)
			};
			InitializeIntermediateCatchTimer1Parameters(schemaCatchTimerEvent);
			return schemaCatchTimerEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ContactAgeActualizationRunnerProcess(userConnection);
		}

		public override object Clone() {
			return new ContactAgeActualizationRunnerProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactAgeActualizationRunnerProcess

	/// <exclude/>
	public class ContactAgeActualizationRunnerProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ContactAgeActualizationRunnerProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: ActualizeContactAgeSubprocessFlowElement

		/// <exclude/>
		public class ActualizeContactAgeSubprocessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public ActualizeContactAgeSubprocessFlowElement(UserConnection userConnection, ContactAgeActualizationRunnerProcess process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("51734939-e406-46f0-b832-0b87c66b860b");
			}

			#endregion

			#region Properties: Public

			public DateTime DateTo {
				get {
					return GetParameterValue<DateTime>("DateTo");
				}
				set {
					SetParameterValue("DateTo", value);
				}
			}

			public bool IsActualizeAllRecord {
				get {
					return GetParameterValue<bool>("IsActualizeAllRecord");
				}
				set {
					SetParameterValue("IsActualizeAllRecord", value);
				}
			}

			public int ChunkSize {
				get {
					return GetParameterValue<int>("ChunkSize");
				}
				set {
					SetParameterValue("ChunkSize", value);
				}
			}

			public int MaxDegreeOfParallelism {
				get {
					return GetParameterValue<int>("MaxDegreeOfParallelism");
				}
				set {
					SetParameterValue("MaxDegreeOfParallelism", value);
				}
			}

			public int ChunkProcessingDelay {
				get {
					return GetParameterValue<int>("ChunkProcessingDelay");
				}
				set {
					SetParameterValue("ChunkProcessingDelay", value);
				}
			}

			public DateTime DateFrom {
				get {
					return GetParameterValue<DateTime>("DateFrom");
				}
				set {
					SetParameterValue("DateFrom", value);
				}
			}

			public string StartNotificationText {
				get {
					return GetParameterValue<string>("StartNotificationText");
				}
				set {
					SetParameterValue("StartNotificationText", value);
				}
			}

			public string FinishNotificationText {
				get {
					return GetParameterValue<string>("FinishNotificationText");
				}
				set {
					SetParameterValue("FinishNotificationText", value);
				}
			}

			public bool IsNeedToNotifyUser {
				get {
					return GetParameterValue<bool>("IsNeedToNotifyUser");
				}
				set {
					SetParameterValue("IsNeedToNotifyUser", value);
				}
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (ContactAgeActualizationRunnerProcess)owner;
				Name = "ActualizeContactAgeSubprocess";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("845629d7-6a9f-47ae-8c06-0703688e57ce");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (ContactAgeActualizationRunnerProcess)Owner;
				SetParameterValue("DateTo", (DateTime)(((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDate"))));
				SetParameterValue("DateFrom", (DateTime)((((DateTime)SysSettings.GetValue(UserConnection, "LastAgeActualizationDate")) != null && ((DateTime)SysSettings.GetValue(UserConnection, "LastAgeActualizationDate")) != DateTime.MinValue && ((DateTime)SysSettings.GetValue(UserConnection, "LastAgeActualizationDate")) != ((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDate"))) ? (((DateTime)SysSettings.GetValue(UserConnection, "LastAgeActualizationDate"))).AddDays(1) : ((DateTime)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentDate"))));
				SetParameterValue("IsActualizeAllRecord", (bool)(false));
			}

			#endregion

		}

		#endregion

		#region Class: AgeActualizationJobRestartSubprocessFlowElement

		/// <exclude/>
		public class AgeActualizationJobRestartSubprocessFlowElement : SubProcessProxy
		{

			#region Constructors: Public

			public AgeActualizationJobRestartSubprocessFlowElement(UserConnection userConnection, ContactAgeActualizationRunnerProcess process)
				: base(userConnection, process) {
				InitialSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			}

			#endregion

			#region Methods: Protected

			protected override void InitializeOwnProperties(Process owner) {
				base.InitializeOwnProperties(owner);
				var process = (ContactAgeActualizationRunnerProcess)owner;
				Name = "AgeActualizationJobRestartSubprocess";
				SerializeToDB = true;
				IsLogging = true;
				SchemaElementUId = new Guid("127fa174-9496-42a7-ad01-89a521a1cc5a");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
			}

			protected override void InitializeParameterValues() {
				base.InitializeParameterValues();
				var process = (ContactAgeActualizationRunnerProcess)Owner;
			}

			#endregion

		}

		#endregion

		#region Class: IntermediateCatchTimer1FlowElement

		/// <exclude/>
		public class IntermediateCatchTimer1FlowElement : ProcessIntermediateCatchTimerEvent
		{

			#region Constructors: Public

			public IntermediateCatchTimer1FlowElement(UserConnection userConnection, ContactAgeActualizationRunnerProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchTimerEvent";
				Name = "IntermediateCatchTimer1";
				IsLogging = true;
				SchemaElementUId = new Guid("47f93b2e-3e09-4276-8e41-28a0f87266cd");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

			#region Properties: Public

			private int _startOffset = 1;
			public override int StartOffset {
				get {
					return _startOffset;
				}
				set {
					_startOffset = value;
				}
			}

			#endregion

		}

		#endregion

		public ContactAgeActualizationRunnerProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactAgeActualizationRunnerProcess";
			SchemaUId = new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = true;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("db59d752-4f9e-4fcf-b854-d2eaa0b1f259");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContactAgeActualizationRunnerProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContactAgeActualizationRunnerProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual DateTime PeriodStartDate {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startEvent1;
		public ProcessFlowElement StartEvent1 {
			get {
				return _startEvent1 ?? (_startEvent1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartEvent1",
					SchemaElementUId = new Guid("58a80f81-db44-4926-b102-efdd77dda066"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessTerminateEvent _terminateEvent1;
		public ProcessTerminateEvent TerminateEvent1 {
			get {
				return _terminateEvent1 ?? (_terminateEvent1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1",
					SchemaElementUId = new Guid("e2ae20ea-a3c4-4a84-913e-6b22fc8cae89"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ActualizeContactAgeSubprocessFlowElement _actualizeContactAgeSubprocess;
		public ActualizeContactAgeSubprocessFlowElement ActualizeContactAgeSubprocess {
			get {
				return _actualizeContactAgeSubprocess ?? ((_actualizeContactAgeSubprocess) = new ActualizeContactAgeSubprocessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AgeActualizationJobRestartSubprocessFlowElement _ageActualizationJobRestartSubprocess;
		public AgeActualizationJobRestartSubprocessFlowElement AgeActualizationJobRestartSubprocess {
			get {
				return _ageActualizationJobRestartSubprocess ?? ((_ageActualizationJobRestartSubprocess) = new AgeActualizationJobRestartSubprocessFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("072e958c-3a57-4707-9807-cb7f0a6a0889"),
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

		private IntermediateCatchTimer1FlowElement _intermediateCatchTimer1;
		public IntermediateCatchTimer1FlowElement IntermediateCatchTimer1 {
			get {
				return _intermediateCatchTimer1 ?? ((_intermediateCatchTimer1) = new IntermediateCatchTimer1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessConditionalFlow _isDailyActualizationAllowedConditionalFlow;
		public ProcessConditionalFlow IsDailyActualizationAllowedConditionalFlow {
			get {
				return _isDailyActualizationAllowedConditionalFlow ?? (_isDailyActualizationAllowedConditionalFlow = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "IsDailyActualizationAllowedConditionalFlow",
					SchemaElementUId = new Guid("6942f372-46f4-430d-b1a4-fabf2a9dcdee"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessToken _exclusiveGateway2ActualizeContactAgeSubprocessToken;
		public ProcessToken ExclusiveGateway2ActualizeContactAgeSubprocessToken {
			get {
				return _exclusiveGateway2ActualizeContactAgeSubprocessToken ?? (_exclusiveGateway2ActualizeContactAgeSubprocessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ExclusiveGateway2ActualizeContactAgeSubprocessToken",
					SchemaElementUId = new Guid("ed580bfb-ba3c-4781-9bf2-3fa667655d3b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessToken _actualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken;
		public ProcessToken ActualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken {
			get {
				return _actualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken ?? (_actualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken = new ProcessToken(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaToken",
					Name = "ActualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken",
					SchemaElementUId = new Guid("a182feac-ab9a-42cf-9b8a-ac07b02d7606"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[ActualizeContactAgeSubprocess.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizeContactAgeSubprocess };
			FlowElements[AgeActualizationJobRestartSubprocess.SchemaElementUId] = new Collection<ProcessFlowElement> { AgeActualizationJobRestartSubprocess };
			FlowElements[ExclusiveGateway2.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2 };
			FlowElements[IntermediateCatchTimer1.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateCatchTimer1 };
			FlowElements[ExclusiveGateway2ActualizeContactAgeSubprocessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway2ActualizeContactAgeSubprocessToken };
			FlowElements[ActualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken.SchemaElementUId] = new Collection<ProcessFlowElement> { ActualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("IntermediateCatchTimer1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "ActualizeContactAgeSubprocess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken", e.Context.SenderName));
						break;
					case "AgeActualizationJobRestartSubprocess":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "ExclusiveGateway2":
						if (IsDailyActualizationAllowedConditionalFlowExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2ActualizeContactAgeSubprocessToken", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "IntermediateCatchTimer1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway2", e.Context.SenderName));
						break;
					case "ExclusiveGateway2ActualizeContactAgeSubprocessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ActualizeContactAgeSubprocess", e.Context.SenderName));
						break;
					case "ActualizeContactAgeSubprocessAgeActualizationJobRestartSubprocessToken":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AgeActualizationJobRestartSubprocess", e.Context.SenderName));
						break;
			}
		}

		private bool IsDailyActualizationAllowedConditionalFlowExpressionExecute() {
			bool result = Convert.ToBoolean(((Boolean)SysSettings.GetValue(UserConnection, "ActualizeAge")) && ((Boolean)SysSettings.GetValue(UserConnection, "RunAgeActualizationDaily")));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExclusiveGateway2", "IsDailyActualizationAllowedConditionalFlow", "((Boolean)SysSettings.GetValue(UserConnection, \"ActualizeAge\")) && ((Boolean)SysSettings.GetValue(UserConnection, \"RunAgeActualizationDaily\"))", result);
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("IntermediateCatchTimer1.StartOffset")) {
				writer.WriteValue("IntermediateCatchTimer1.StartOffset", IntermediateCatchTimer1.StartOffset, 0);
			}
			if (!HasMapping("PeriodStartDate")) {
				writer.WriteValue("PeriodStartDate", PeriodStartDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartEvent1", string.Empty));
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
			MetaPathParameterValues.Add("d53b4f3b-3dba-4cbc-8854-c9aa81678523", () => PeriodStartDate);
			MetaPathParameterValues.Add("395304e1-4898-4208-839b-d8a6915e89db", () => ActualizeContactAgeSubprocess.DateTo);
			MetaPathParameterValues.Add("4696d1a0-ad34-47d3-a3bf-98710eb1bd43", () => ActualizeContactAgeSubprocess.DateFrom);
			MetaPathParameterValues.Add("5201e962-c146-47e6-90b8-1846fb49732b", () => ActualizeContactAgeSubprocess.IsActualizeAllRecord);
			MetaPathParameterValues.Add("3226305e-d91e-46b3-a8e7-ac23b1341db5", () => ActualizeContactAgeSubprocess.ChunkSize);
			MetaPathParameterValues.Add("4d2a0eb8-f5f6-495f-b681-6bf77abfe484", () => ActualizeContactAgeSubprocess.MaxDegreeOfParallelism);
			MetaPathParameterValues.Add("58d04aab-c253-4412-b17d-85ca88ac5282", () => ActualizeContactAgeSubprocess.ChunkProcessingDelay);
			MetaPathParameterValues.Add("eb4853be-8ed3-4d0c-af70-8aeb7a37838c", () => ActualizeContactAgeSubprocess.StartNotificationText);
			MetaPathParameterValues.Add("dbd06a9a-0b70-4daf-a78c-4130ef618340", () => ActualizeContactAgeSubprocess.FinishNotificationText);
			MetaPathParameterValues.Add("58775490-e567-4a30-b07e-b888064e2efc", () => ActualizeContactAgeSubprocess.IsNeedToNotifyUser);
			MetaPathParameterValues.Add("0357bba3-0fc5-403f-9b01-2df8ff753ca7", () => IntermediateCatchTimer1.StartOffset);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "IntermediateCatchTimer1.StartOffset":
					IntermediateCatchTimer1.StartOffset = reader.GetValue<System.Int32>();
				break;
				case "PeriodStartDate":
					if (!hasValueToRead) break;
					PeriodStartDate = reader.GetValue<System.DateTime>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

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
			var cloneItem = (ContactAgeActualizationRunnerProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

