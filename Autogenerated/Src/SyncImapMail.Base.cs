namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using IntegrationApi.Interfaces;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: SyncImapMailSchema

	/// <exclude/>
	public class SyncImapMailSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SyncImapMailSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SyncImapMailSchema(SyncImapMailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SyncImapMail";
			UId = new Guid("237dd150-53cf-4801-bd72-d517975107f8");
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,83,0,0,69,207,108,233,1,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a54165a0-7744-4599-95de-a742bd292b40"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("57e04ecc-eb57-43da-bb56-54c46c31c8d3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMailUserNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("97325781-b945-49f7-8732-c6cfdd3aebc1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"MailUserName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LongText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5cda26a9-50cc-4292-9c8a-84b7533a2e06"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentUserIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("294c50f3-a39f-4a40-a91e-58e6766978b9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"CurrentUserId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadEmailsFromDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ed3fa5d3-4777-4bfb-95e1-e80decf6e0a9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"LoadEmailsFromDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7f27c14c-c3e5-4e1c-9b16-b0f669ff0e28"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateMailUserNameParameter());
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateCurrentUserIdParameter());
			Parameters.Add(CreateLoadEmailsFromDateParameter());
			Parameters.Add(CreateCreateRemindingParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("adfc9151-77b2-4fe4-a87b-92ae60725da1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8727a659-1a61-4eec-87bc-f4e360329497"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("1910142d-434b-41cb-9592-e2c24eee63bd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ac7eaae-3d0b-4972-89fe-e58baaedcc67"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("5d241632-5559-4887-b0c1-a279e8a744cf"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("5d241632-5559-4887-b0c1-a279e8a744cf"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("9ac7eaae-3d0b-4972-89fe-e58baaedcc67"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"Start1",
				Position = new Point(57, 44),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("8727a659-1a61-4eec-87bc-f4e360329497"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"End1",
				Position = new Point(246, 44),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("13ec4d62-a0e8-4c2f-8f8a-cfefd74363e3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8"),
				Name = @"ScriptTask1",
				Position = new Point(134, 30),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,86,109,79,219,48,16,254,92,36,254,131,9,95,82,169,10,236,245,195,120,153,74,91,88,39,160,29,41,219,199,201,77,12,120,114,236,98,59,45,25,226,191,239,108,167,77,154,54,99,69,67,170,162,198,190,123,238,238,241,249,185,236,210,27,180,115,217,27,133,163,246,101,183,125,213,125,251,115,31,237,237,161,209,160,59,64,219,91,83,44,145,34,81,42,201,136,60,104,116,132,208,181,34,178,35,56,39,145,166,130,7,93,172,241,119,204,82,50,202,38,228,2,115,124,75,100,112,70,116,159,43,141,121,68,78,178,75,156,16,223,11,23,32,94,19,97,133,138,247,37,132,3,23,18,246,36,225,218,196,234,199,16,181,179,244,190,115,132,206,82,26,7,189,100,162,51,244,185,178,251,169,154,98,105,59,232,199,16,161,199,53,213,89,24,221,145,4,127,75,137,204,208,189,125,30,33,78,102,104,101,215,175,224,149,13,242,138,91,64,85,163,225,93,96,202,198,226,33,204,120,20,18,173,41,191,85,94,19,2,90,248,160,29,199,29,193,210,132,251,158,65,52,188,212,239,14,177,82,51,33,227,245,22,38,80,72,228,20,42,130,85,73,148,122,214,110,40,164,126,214,8,34,135,225,249,179,102,125,21,106,44,245,136,213,132,13,9,143,137,236,37,224,177,154,222,41,101,154,72,101,236,125,183,210,145,4,107,226,214,127,80,125,55,196,18,184,49,70,190,91,236,136,100,130,37,85,130,155,30,9,122,247,41,102,150,114,47,204,84,59,78,40,191,230,84,195,225,122,173,229,214,105,190,82,216,50,255,140,137,153,45,181,43,102,156,9,28,195,177,67,30,90,166,228,181,194,247,56,30,51,98,147,200,248,157,20,156,254,198,166,53,95,57,236,154,99,109,161,213,69,27,222,9,7,131,43,3,215,202,69,6,85,8,237,202,186,91,101,124,32,136,169,9,50,140,225,4,41,102,10,69,165,255,238,122,86,44,124,227,152,42,224,28,249,38,102,60,238,61,128,180,104,33,193,126,229,226,42,208,156,238,73,177,228,55,155,232,17,74,43,1,0,61,80,15,56,187,236,3,7,71,174,236,178,95,192,231,158,13,144,79,127,199,57,5,198,104,14,217,104,24,180,201,130,221,60,253,46,181,129,177,204,14,149,150,16,181,133,196,248,23,4,58,206,189,26,143,232,95,137,70,79,173,133,203,146,6,86,175,1,122,178,118,79,7,139,188,20,168,87,156,50,91,104,135,129,214,156,226,8,138,178,135,116,120,50,188,8,197,141,14,12,213,65,191,159,224,137,81,180,175,98,28,206,189,142,45,237,128,181,192,129,218,19,49,37,185,97,229,112,91,37,30,114,71,13,109,59,179,140,180,229,109,154,64,170,189,135,136,76,236,161,120,41,120,163,88,16,133,184,208,232,14,79,9,50,101,35,28,69,34,229,78,198,160,28,243,40,53,72,48,87,85,168,41,63,16,168,198,105,146,29,48,57,227,199,126,177,107,135,211,190,237,88,40,198,110,35,137,103,115,245,221,20,233,77,142,228,154,162,192,1,197,188,76,25,27,72,59,178,138,22,169,102,95,138,91,76,93,131,110,163,158,10,121,14,250,178,66,110,41,80,51,24,137,208,230,230,215,144,244,69,40,189,105,89,111,243,178,202,56,102,158,212,226,80,174,87,64,222,173,1,49,243,70,177,90,152,177,16,108,5,231,253,26,156,249,56,218,12,233,195,58,164,213,91,182,33,89,31,29,42,16,15,191,93,128,163,55,219,91,182,33,42,114,100,190,146,212,41,168,49,156,179,83,244,216,247,6,44,182,193,251,92,147,91,233,84,61,111,151,23,233,201,38,106,98,178,54,169,255,63,129,120,161,60,216,4,236,71,148,82,176,191,46,133,126,88,236,31,251,158,45,4,202,50,148,0,48,80,145,26,219,185,182,128,164,68,176,91,25,57,86,61,107,61,212,6,211,174,81,202,214,53,163,171,95,18,56,92,110,135,242,129,235,135,250,175,237,237,242,24,163,57,167,127,99,96,206,251,130,5,8,88,95,255,82,233,235,185,168,117,46,93,16,51,90,138,183,102,222,154,149,116,3,243,223,164,103,26,196,50,81,186,10,101,78,254,0,149,64,65,244,125,12,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("699b2038-adc5-418a-bdd1-d4d0f094a7b3"),
				Name = "BPMSoft.Mail",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2a014b6d-9ec5-48df-a642-6190afc95cc5"),
				Name = "BPMSoft.Core",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d3124134-245b-4f52-9d71-d7d3dc858b19"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8ebced27-c4ad-4322-bdc4-d34ece6c78e1"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fb1fe6c6-00d9-494f-a471-a3a73bc90279"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("411c2ea8-1b30-46ea-8e80-a814bd7b2e00"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SyncImapMail(userConnection);
		}

		public override object Clone() {
			return new SyncImapMailSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("237dd150-53cf-4801-bd72-d517975107f8"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncImapMailMethodsWrapper

	/// <exclude/>
	public class SyncImapMailMethodsWrapper : ProcessModel
	{

		public SyncImapMailMethodsWrapper(Process process)
			: base(process) {
		}

		#region Methods: Private

			 

		#endregion

	}

	#endregion

	#region Class: SyncImapMail

	/// <exclude/>
	public class SyncImapMail : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SyncImapMail process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SyncImapMail(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncImapMail";
			SchemaUId = new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new SyncImapMailMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("237dd150-53cf-4801-bd72-d517975107f8");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SyncImapMail, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SyncImapMail, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string MailUserName {
			get;
			set;
		}

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		public virtual Guid CurrentUserId {
			get;
			set;
		}

		public virtual DateTime LoadEmailsFromDate {
			get;
			set;
		}

		public virtual bool CreateReminding {
			get;
			set;
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
					SchemaElementUId = new Guid("9ac7eaae-3d0b-4972-89fe-e58baaedcc67"),
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
					SchemaElementUId = new Guid("8727a659-1a61-4eec-87bc-f4e360329497"),
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
					SchemaElementUId = new Guid("1edb1620-1236-4a0a-91ef-2612ae3a0993"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("MailUserName")) {
				writer.WriteValue("MailUserName", MailUserName, null);
			}
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
			}
			if (!HasMapping("CurrentUserId")) {
				writer.WriteValue("CurrentUserId", CurrentUserId, Guid.Empty);
			}
			if (!HasMapping("LoadEmailsFromDate")) {
				writer.WriteValue("LoadEmailsFromDate", LoadEmailsFromDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("CreateReminding")) {
				writer.WriteValue("CreateReminding", CreateReminding, false);
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
			MetaPathParameterValues.Add("a54165a0-7744-4599-95de-a742bd292b40", () => PageInstanceId);
			MetaPathParameterValues.Add("57e04ecc-eb57-43da-bb56-54c46c31c8d3", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("97325781-b945-49f7-8732-c6cfdd3aebc1", () => MailUserName);
			MetaPathParameterValues.Add("5cda26a9-50cc-4292-9c8a-84b7533a2e06", () => SenderEmailAddress);
			MetaPathParameterValues.Add("294c50f3-a39f-4a40-a91e-58e6766978b9", () => CurrentUserId);
			MetaPathParameterValues.Add("ed3fa5d3-4777-4bfb-95e1-e80decf6e0a9", () => LoadEmailsFromDate);
			MetaPathParameterValues.Add("7f27c14c-c3e5-4e1c-9b16-b0f669ff0e28", () => CreateReminding);
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
				case "MailUserName":
					if (!hasValueToRead) break;
					MailUserName = reader.GetValue<System.String>();
				break;
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
				break;
				case "CurrentUserId":
					if (!hasValueToRead) break;
					CurrentUserId = reader.GetValue<System.Guid>();
				break;
				case "LoadEmailsFromDate":
					if (!hasValueToRead) break;
					LoadEmailsFromDate = reader.GetValue<System.DateTime>();
				break;
				case "CreateReminding":
					if (!hasValueToRead) break;
					CreateReminding = reader.GetValue<System.Boolean>();
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
			#if !NETSTANDARD2_0 // TODO 
			var secureText =  UserConnection.DataValueTypeManager.GetInstanceByName("SecureText") as SecureTextDataValueType;
			var currentUserId = CurrentUserId != Guid.Empty ? CurrentUserId : UserConnection.CurrentUser.Id;
			EntitySchemaQuery query = new EntitySchemaQuery(UserConnection.EntitySchemaManager, 
					"MailboxSyncSettings");
			query.AddColumn("UserName");
			query.AddColumn("UserPassword");
			query.AddColumn("MailServer.Address");
			query.AddColumn("MailServer.Port");
			query.AddColumn("MailServer.UseSSL");
			query.AddColumn("MailServer.IsStartTls");
			query.AddColumn("SenderEmailAddress");
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"SysAdminUnit.Id", currentUserId));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"MailServer.AllowEmailDownloading", true));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"EnableMailSynhronization", true));
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"SenderEmailAddress", SenderEmailAddress));
			var select = query.GetSelectQuery(UserConnection);
			 
			MailCredentials credentials = new MailCredentials();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if (!reader.Read()) {
						var parameters = new Dictionary<string, object> {
							{ "SenderEmailAddress", SenderEmailAddress },
							{ "CurrentUserId", currentUserId }
						};
						var scheduler = ClassFactory.Get<BPMSoft.Mail.IImapSyncJobScheduler>();
						scheduler.RemoveSyncJob(UserConnection, parameters);
						throw new ArgumentException("user does not have mail account");
					}
					credentials.UserName = reader.GetColumnValue<string>(reader.GetName(0));
					string rawPassword = reader.GetColumnValue<string>(reader.GetName(1));
					if (!rawPassword.IsNullOrEmpty()) {
						credentials.UserPassword = secureText.GetValueForLoad(UserConnection, rawPassword).ToString();
					}
					credentials.Host = reader.GetColumnValue<string>(reader.GetName(2));
					credentials.Port = reader.GetColumnValue<int>(reader.GetName(3));
					credentials.UseSsl = reader.GetColumnValue<bool>(reader.GetName(4));
					credentials.StartTls = reader.GetColumnValue<bool>(reader.GetName(5));
					credentials.SenderEmailAddress = reader.GetColumnValue<string>(reader.GetName(6));
				}
			}
			#endif
			if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
				var parameters = new Dictionary<string, object> {
					{ "SenderEmailAddress", SenderEmailAddress }
				};
				var scheduler = ClassFactory.Get<BPMSoft.Mail.IImapSyncJobScheduler>();
				scheduler.RemoveSyncJob(UserConnection, parameters);
				var syncSession = ClassFactory.Get<ISyncSession>("Email", new ConstructorArgument("uc", UserConnection),
					new ConstructorArgument("senderEmailAddress", SenderEmailAddress));
				syncSession.Start();
				return true;
			}
			#if !NETSTANDARD2_0 // TODO
			using (var imapSyncSession = ClassFactory.Get<IImapSyncSession>(
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("credentials", credentials))) {
				imapSyncSession.SyncImapMail();
			}
			#endif
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
			var cloneItem = (SyncImapMail)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

