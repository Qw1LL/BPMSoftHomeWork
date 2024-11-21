namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.LDAPSysSettingsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.DirectoryServices.Protocols;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: RunLDAPImportSchema

	/// <exclude/>
	public class RunLDAPImportSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public RunLDAPImportSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public RunLDAPImportSchema(RunLDAPImportSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "RunLDAPImport";
			UId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80");
			CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.787";
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,81,75,195,48,20,133,159,87,232,127,184,228,169,133,80,244,85,241,65,167,194,64,97,116,236,201,250,80,187,203,8,166,201,72,110,42,165,244,191,155,44,113,56,152,146,151,112,110,114,206,119,110,158,29,220,135,20,29,12,194,144,107,37,12,90,236,96,105,176,37,172,177,23,106,39,212,254,97,92,27,221,161,181,69,9,83,158,45,94,30,239,215,91,18,82,208,88,253,249,116,107,209,44,181,82,216,145,208,138,3,171,157,10,31,87,253,65,27,98,28,226,165,70,235,36,113,80,78,74,14,100,28,150,183,121,54,231,89,56,151,216,86,202,27,83,112,122,146,216,163,162,31,170,161,53,16,228,13,154,65,116,8,119,160,240,43,42,163,221,32,145,199,179,105,88,132,144,99,143,36,84,23,108,207,27,148,255,99,61,107,211,183,169,77,97,201,248,48,232,253,30,218,61,70,188,164,153,227,139,215,56,241,140,81,174,226,247,130,77,83,195,62,113,108,216,13,52,108,186,154,27,191,168,134,37,163,164,94,123,117,158,57,227,222,117,145,70,252,20,22,138,253,94,237,165,12,239,146,8,108,240,124,243,65,239,48,207,62,235,12,239,84,249,27,207,210,34,102,38,2,0,0 };
			RealUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80");
			Version = 0;
			PackageUId = new Guid("bb1e143e-f3ee-4316-9450-851ddd02d999");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateInvalidCredentialsErrorCodeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9d81ee47-ce73-4140-a98c-b06d124466b8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"InvalidCredentialsErrorCode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"49",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateImportResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1f6b6e87-c958-4eb6-ade7-f1a63346c19e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"ImportResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0b3dd0bf-51b6-4622-805d-b939447f7a66"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"Success",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccesImportMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b814ba13-103e-4c7e-ae10-1dc0780cfbc7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"SuccesImportMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateErrorImportResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e7fa5a72-9783-470f-8eae-1615dcce02e7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"ErrorImportResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateInvalidCredentialMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("aa11b984-4bfd-47c3-8e6d-c348d4445e5e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"InvalidCredentialMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCouldNotEstablishConnectionMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("de938140-0b07-4363-af1c-d151afdd8da7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"CouldNotEstablishConnectionMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateInvalidCredentialsErrorCodeParameter());
			Parameters.Add(CreateImportResultParameter());
			Parameters.Add(CreateSuccessParameter());
			Parameters.Add(CreateSuccesImportMessageParameter());
			Parameters.Add(CreateErrorImportResultParameter());
			Parameters.Add(CreateInvalidCredentialMessageParameter());
			Parameters.Add(CreateCouldNotEstablishConnectionMessageParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaScriptTask insertldapelementsscripttask = CreateInsertLDAPElementsScriptTaskScriptTask();
			FlowElements.Add(insertldapelementsscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("e5d8f015-6bb9-477e-9462-163f9e5ddc94"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dc24efaf-c1d0-49dd-9e85-8f605527d79f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("12e5e535-1ea0-4ebc-b964-022beca1a65d"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("d3a49bee-aa9d-4c7d-a533-7b11dd96e698"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("12e5e535-1ea0-4ebc-b964-022beca1a65d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("37f753ec-2a7c-4ab5-95cf-e282f7e7658c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("3b4c88bf-673d-4f82-a2a5-b3b1f444ecd7"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("cc408f22-7e62-40bc-8e66-487801b41219"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("3b4c88bf-673d-4f82-a2a5-b3b1f444ecd7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("dc24efaf-c1d0-49dd-9e85-8f605527d79f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cc408f22-7e62-40bc-8e66-487801b41219"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("37f753ec-2a7c-4ab5-95cf-e282f7e7658c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cc408f22-7e62-40bc-8e66-487801b41219"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"Terminate1",
				Position = new Point(281, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateInsertLDAPElementsScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("12e5e535-1ea0-4ebc-b964-022beca1a65d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("cc408f22-7e62-40bc-8e66-487801b41219"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49"),
				CreatedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"),
				Name = @"InsertLDAPElementsScriptTask",
				Position = new Point(141, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,209,106,195,48,12,124,94,161,255,160,245,41,133,145,31,8,121,216,178,108,20,210,81,186,47,240,18,45,49,56,118,144,148,118,101,244,223,103,39,161,132,102,111,182,116,186,59,157,132,46,240,187,94,61,236,44,35,73,241,250,124,200,13,182,104,133,163,109,18,234,109,231,72,142,200,189,17,72,225,179,47,75,228,177,184,71,102,85,99,64,141,101,246,0,161,30,19,88,175,174,80,42,41,27,136,138,74,117,249,79,137,157,104,103,1,183,131,154,254,134,8,227,156,200,81,230,42,132,52,133,157,61,41,163,171,140,176,242,234,90,25,190,181,199,153,123,43,139,129,153,159,43,160,97,252,119,44,115,189,169,62,156,228,44,234,203,104,110,50,103,45,150,193,221,156,96,182,193,194,253,29,35,11,105,91,199,111,142,90,37,209,224,122,142,120,2,140,39,230,144,168,103,246,150,149,224,17,91,109,43,63,249,114,57,144,11,241,13,137,135,104,30,167,60,71,185,147,34,48,174,246,74,133,171,247,202,122,34,138,223,81,252,207,191,162,77,56,218,102,56,150,71,141,161,70,115,3,67,75,26,114,103,176,120,134,219,58,11,144,183,70,40,61,217,233,204,156,252,1,194,165,237,52,30,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4523771c-6100-4641-97a9-79419e0cad16"),
				Name = "System.DirectoryServices.Protocols",
				Alias = "",
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2ef9121c-b963-4001-9bdc-ce9f072168da"),
				Name = "BPMSoft.Configuration.LDAPSysSettingsService",
				Alias = "",
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("0c7ac8e1-c2e9-469c-ac15-4d07ad5ea5e8"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("5f0098c2-7f45-4d3a-8990-e0e0180240d8"),
				Name = "global::Common.Logging",
				Alias = "",
				CreatedInPackageId = new Guid("e430cf7d-0a41-4669-8668-da1aca11ad49")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new RunLDAPImport(userConnection);
		}

		public override object Clone() {
			return new RunLDAPImportSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e2b3685-3857-4b14-9986-04fe60398e80"));
		}

		#endregion

	}

	#endregion

	#region Class: RunLDAPImport

	/// <exclude/>
	public class RunLDAPImport : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, RunLDAPImport process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public RunLDAPImport(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunLDAPImport";
			SchemaUId = new Guid("5e2b3685-3857-4b14-9986-04fe60398e80");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_invalidCredentialsErrorCode = () => { return (int)(49); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5e2b3685-3857-4b14-9986-04fe60398e80");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: RunLDAPImport, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: RunLDAPImport, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<int> _invalidCredentialsErrorCode;
		public virtual int InvalidCredentialsErrorCode {
			get {
				return (_invalidCredentialsErrorCode ?? (_invalidCredentialsErrorCode = () => 0)).Invoke();
			}
			set {
				_invalidCredentialsErrorCode = () => { return value; };
			}
		}

		public virtual string ImportResult {
			get;
			set;
		}

		public virtual bool Success {
			get;
			set;
		}

		private LocalizableString _succesImportMessage;
		public virtual LocalizableString SuccesImportMessage {
			get {
				return _succesImportMessage ?? (_succesImportMessage = GetLocalizableString("5e2b368538574b14998604fe60398e80",
						 "Parameters.SuccesImportMessage.Value"));
			}
			set {
				_succesImportMessage = value;
			}
		}

		private LocalizableString _errorImportResult;
		public virtual LocalizableString ErrorImportResult {
			get {
				return _errorImportResult ?? (_errorImportResult = GetLocalizableString("5e2b368538574b14998604fe60398e80",
						 "Parameters.ErrorImportResult.Value"));
			}
			set {
				_errorImportResult = value;
			}
		}

		private LocalizableString _invalidCredentialMessage;
		public virtual LocalizableString InvalidCredentialMessage {
			get {
				return _invalidCredentialMessage ?? (_invalidCredentialMessage = GetLocalizableString("5e2b368538574b14998604fe60398e80",
						 "Parameters.InvalidCredentialMessage.Value"));
			}
			set {
				_invalidCredentialMessage = value;
			}
		}

		private string _couldNotEstablishConnectionMessage;
		public virtual string CouldNotEstablishConnectionMessage {
			get {
				return _couldNotEstablishConnectionMessage ?? (_couldNotEstablishConnectionMessage = GetLocalizableString("5e2b368538574b14998604fe60398e80",
						 "Parameters.CouldNotEstablishConnectionMessage.Value"));
			}
			set {
				_couldNotEstablishConnectionMessage = value;
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
					SchemaElementUId = new Guid("dc24efaf-c1d0-49dd-9e85-8f605527d79f"),
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
					SchemaElementUId = new Guid("37f753ec-2a7c-4ab5-95cf-e282f7e7658c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _insertLDAPElementsScriptTask;
		public ProcessScriptTask InsertLDAPElementsScriptTask {
			get {
				return _insertLDAPElementsScriptTask ?? (_insertLDAPElementsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InsertLDAPElementsScriptTask",
					SchemaElementUId = new Guid("12e5e535-1ea0-4ebc-b964-022beca1a65d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = InsertLDAPElementsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[InsertLDAPElementsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertLDAPElementsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("InsertLDAPElementsScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "InsertLDAPElementsScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("ImportResult")) {
				writer.WriteValue("ImportResult", ImportResult, null);
			}
			if (!HasMapping("Success")) {
				writer.WriteValue("Success", Success, false);
			}
			if (!HasMapping("CouldNotEstablishConnectionMessage")) {
				writer.WriteValue("CouldNotEstablishConnectionMessage", CouldNotEstablishConnectionMessage, null);
			}
			if (!HasMapping("InvalidCredentialsErrorCode")) {
				writer.WriteValue("InvalidCredentialsErrorCode", InvalidCredentialsErrorCode, 0);
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
			MetaPathParameterValues.Add("9d81ee47-ce73-4140-a98c-b06d124466b8", () => InvalidCredentialsErrorCode);
			MetaPathParameterValues.Add("1f6b6e87-c958-4eb6-ade7-f1a63346c19e", () => ImportResult);
			MetaPathParameterValues.Add("0b3dd0bf-51b6-4622-805d-b939447f7a66", () => Success);
			MetaPathParameterValues.Add("b814ba13-103e-4c7e-ae10-1dc0780cfbc7", () => SuccesImportMessage);
			MetaPathParameterValues.Add("e7fa5a72-9783-470f-8eae-1615dcce02e7", () => ErrorImportResult);
			MetaPathParameterValues.Add("aa11b984-4bfd-47c3-8e6d-c348d4445e5e", () => InvalidCredentialMessage);
			MetaPathParameterValues.Add("de938140-0b07-4363-af1c-d151afdd8da7", () => CouldNotEstablishConnectionMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "ImportResult":
					if (!hasValueToRead) break;
					ImportResult = reader.GetValue<System.String>();
				break;
				case "Success":
					if (!hasValueToRead) break;
					Success = reader.GetValue<System.Boolean>();
				break;
				case "CouldNotEstablishConnectionMessage":
					if (!hasValueToRead) break;
					CouldNotEstablishConnectionMessage = reader.GetValue<System.String>();
				break;
				case "InvalidCredentialsErrorCode":
					if (!hasValueToRead) break;
					InvalidCredentialsErrorCode = reader.GetValue<System.Int32>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool InsertLDAPElementsScriptTaskExecute(ProcessExecutingContext context) {
			try {
				InsertLDAPElements();
				ImportResult = SuccesImportMessage;
				Success = true; 
			} catch (LdapException e) {
				if (e.ErrorCode == InvalidCredentialsErrorCode) {
					ImportResult = InvalidCredentialMessage;
				} else {
					ImportResult = CouldNotEstablishConnectionMessage;
				}
			} catch (Exception e) {
				ImportResult = string.Format(ErrorImportResult, e.Message);
			}
			CreateRemindingByProcess();
			if (!Success) {
				var log = LogManager.GetLogger("LDAP");
				log.Error(ImportResult);
				throw new Exception(ImportResult);
			}
			return Success;
		}

			
			public virtual void CreateRemindingByProcess() {
				LDAPUtility.CreateRemindingByProcess(UserConnection, "RunLDAPImport", ImportResult, null, true);
			}
			
			
			public virtual void InsertLDAPElements() {
				var LDAPService = new LDAPSysSettingsService();
				LDAPService.InsertLDAPElements(UserConnection);
			}
			
			
			public virtual void FormatResult(string message) {
				string resultMessage = string.Format("{{\"key\": \"{0}\", \"message\": \"{1}\"}},",
					message, message);
				ImportResult = string.Format("{{ \"Messages\": [{0}] }}", resultMessage);
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
			var cloneItem = (RunLDAPImport)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

