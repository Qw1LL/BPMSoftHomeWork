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
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using System.Web;

	#region Class: SendImmediatelyTriggeredEmailProcessSchema

	/// <exclude/>
	public class SendImmediatelyTriggeredEmailProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendImmediatelyTriggeredEmailProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendImmediatelyTriggeredEmailProcessSchema(SendImmediatelyTriggeredEmailProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendImmediatelyTriggeredEmailProcess";
			UId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9");
			CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = false;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,84,93,107,219,48,20,125,110,161,255,65,228,73,6,35,182,61,166,93,33,203,210,46,172,201,160,105,158,198,30,84,251,214,21,211,135,145,228,100,33,228,191,239,74,182,236,120,235,70,2,138,239,199,185,231,156,171,248,234,178,110,158,165,40,200,78,88,223,112,73,118,70,148,100,3,186,92,40,46,36,205,200,241,234,242,194,219,67,60,119,220,18,135,185,207,220,3,249,72,194,241,36,20,176,173,47,214,102,127,221,85,88,40,68,45,64,123,135,53,26,246,228,65,56,127,243,169,145,63,35,230,99,74,47,245,139,185,165,89,104,27,90,216,172,44,105,104,122,187,62,210,184,88,150,136,60,55,218,243,194,47,203,60,132,98,41,246,90,112,110,72,198,104,204,119,129,199,243,86,124,192,212,41,75,196,21,246,242,10,226,156,150,249,82,59,207,181,95,13,137,206,145,139,89,93,163,109,220,11,163,183,86,98,249,56,16,103,166,182,48,178,151,211,241,237,114,45,159,65,107,151,237,53,7,45,131,57,129,109,79,22,203,133,174,54,96,119,162,8,219,152,75,238,220,29,202,50,246,192,238,193,223,172,70,21,183,209,85,84,238,188,109,66,209,204,86,141,66,84,58,105,28,88,76,104,40,2,251,73,78,182,163,64,22,13,26,207,99,225,138,116,26,232,153,111,177,116,206,85,205,69,165,191,128,172,193,178,21,216,10,210,182,180,55,41,77,199,99,114,146,18,104,194,96,201,198,67,29,2,253,186,195,136,19,65,167,139,87,66,23,191,10,168,67,55,129,118,49,15,166,90,88,107,44,157,196,35,94,87,34,148,130,82,224,109,149,135,180,100,134,50,33,66,197,111,248,252,241,79,168,164,121,230,114,58,157,27,165,140,102,8,92,161,126,182,196,31,4,237,13,207,96,187,235,16,22,34,99,0,23,209,102,8,119,255,131,192,201,226,133,208,212,132,215,173,145,178,5,235,129,254,209,142,231,138,107,212,96,217,192,195,191,10,199,214,92,69,77,193,133,22,162,197,106,101,134,121,184,252,200,192,173,113,220,55,187,80,181,63,208,13,90,130,22,126,133,67,214,50,24,2,8,113,223,136,146,173,97,31,78,154,177,39,179,137,24,116,178,158,116,254,89,240,141,213,163,89,111,248,25,223,44,253,122,90,34,105,27,57,249,107,145,35,75,207,252,70,252,54,204,206,129,216,157,177,138,227,93,62,190,59,77,201,247,227,251,211,15,114,252,112,186,198,45,247,206,228,248,94,75,186,242,52,57,94,238,72,248,55,89,5,121,44,11,5,0,0 };
			RealUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9");
			Version = 0;
			PackageUId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCampaignIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("85d945df-7ab5-4264-a3c7-f611954a399a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"CampaignId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateBulkEmailIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e60bee11-c357-4094-b80e-1e60dc4ffd76"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"BulkEmailId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateBulkEmailStepIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3b00293a-64b5-44ae-9a0f-7b6b6d58aa1d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"BulkEmailStepId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateContactIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2544c42e-6fc8-4a6e-b641-d732f7f86c4a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"ContactId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateContactEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2f6dcf43-aa4d-43f8-964b-e1058549db84"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"ContactEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateBulkEmailRIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bd524a10-c122-4d51-b9eb-818c1cfe77be"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"BulkEmailRId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateContactRIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f780e797-a0f6-48e5-99ec-d7eace686960"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"ContactRId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
			};
		}

		protected virtual ProcessSchemaParameter CreateApplicationUrlParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("387d31a1-145f-4f8d-8f19-f74c35ddce78"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"ApplicationUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoggerParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2963f4f8-9d7b-492a-961c-75325ea3f492"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"Logger",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSessionKeyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a62e66d5-5e14-42e0-8b16-1104efe6697a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"SessionKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCampaignIdParameter());
			Parameters.Add(CreateBulkEmailIdParameter());
			Parameters.Add(CreateBulkEmailStepIdParameter());
			Parameters.Add(CreateContactIdParameter());
			Parameters.Add(CreateContactEmailParameter());
			Parameters.Add(CreateBulkEmailRIdParameter());
			Parameters.Add(CreateContactRIdParameter());
			Parameters.Add(CreateApplicationUrlParameter());
			Parameters.Add(CreateLoggerParameter());
			Parameters.Add(CreateSessionKeyParameter());
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
			ProcessSchemaScriptTask sendemailscripttask = CreateSendEmailScriptTaskScriptTask();
			FlowElements.Add(sendemailscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("f42246f1-51de-4704-bd65-76426cca40a0"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("eb76617b-474b-40d3-8f2e-3580df6254e1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c0156357-39c0-4c85-8b78-768090cc9239"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("02fc9bfb-6221-4bd2-b64c-882120920eff"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c0156357-39c0-4c85-8b78-768090cc9239"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0fd9a01d-d611-490c-8896-6ce8b5c06573"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("414c22c4-4416-4668-9b85-458fb0254378"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d5325679-4d7f-4d02-9ad6-c8452f19c750"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("414c22c4-4416-4668-9b85-458fb0254378"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("eb76617b-474b-40d3-8f2e-3580df6254e1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d5325679-4d7f-4d02-9ad6-c8452f19c750"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
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
				UId = new Guid("0fd9a01d-d611-490c-8896-6ce8b5c06573"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d5325679-4d7f-4d02-9ad6-c8452f19c750"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSendEmailScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("c0156357-39c0-4c85-8b78-768090cc9239"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d5325679-4d7f-4d02-9ad6-c8452f19c750"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4"),
				CreatedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"),
				Name = @"SendEmailScriptTask",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,78,205,75,113,205,77,204,204,209,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,60,56,4,160,26,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e4d8fa67-fff7-4036-bd67-61e03d6e2b54"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2d11a6f5-135b-474d-9c77-28e78be687aa"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("c0cb070c-6408-4a02-b2a7-9cfd918167e4")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2248d4cd-8afa-4dcd-9f6e-3dc03a4c041f"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("16671048-241e-49b4-b1e7-a6fbc820ffe7")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendImmediatelyTriggeredEmailProcess(userConnection);
		}

		public override object Clone() {
			return new SendImmediatelyTriggeredEmailProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9"));
		}

		#endregion

	}

	#endregion

	#region Class: SendImmediatelyTriggeredEmailProcess

	/// <exclude/>
	public class SendImmediatelyTriggeredEmailProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendImmediatelyTriggeredEmailProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SendImmediatelyTriggeredEmailProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendImmediatelyTriggeredEmailProcess";
			SchemaUId = new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a09dcafb-d873-4cb8-a919-bd00c88e4ae9");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendImmediatelyTriggeredEmailProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendImmediatelyTriggeredEmailProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid CampaignId {
			get;
			set;
		}

		public virtual Guid BulkEmailId {
			get;
			set;
		}

		public virtual Guid BulkEmailStepId {
			get;
			set;
		}

		public virtual Guid ContactId {
			get;
			set;
		}

		public virtual string ContactEmail {
			get;
			set;
		}

		public virtual int BulkEmailRId {
			get;
			set;
		}

		public virtual int ContactRId {
			get;
			set;
		}

		public virtual string ApplicationUrl {
			get;
			set;
		}

		public virtual Object Logger {
			get;
			set;
		}

		public virtual string SessionKey {
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
					SchemaElementUId = new Guid("eb76617b-474b-40d3-8f2e-3580df6254e1"),
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
					SchemaElementUId = new Guid("0fd9a01d-d611-490c-8896-6ce8b5c06573"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
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
					SchemaElementUId = new Guid("c0156357-39c0-4c85-8b78-768090cc9239"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SendEmailScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SendEmailScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SendEmailScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CampaignId")) {
				writer.WriteValue("CampaignId", CampaignId, Guid.Empty);
			}
			if (!HasMapping("BulkEmailId")) {
				writer.WriteValue("BulkEmailId", BulkEmailId, Guid.Empty);
			}
			if (!HasMapping("BulkEmailStepId")) {
				writer.WriteValue("BulkEmailStepId", BulkEmailStepId, Guid.Empty);
			}
			if (!HasMapping("ContactId")) {
				writer.WriteValue("ContactId", ContactId, Guid.Empty);
			}
			if (!HasMapping("ContactEmail")) {
				writer.WriteValue("ContactEmail", ContactEmail, null);
			}
			if (!HasMapping("BulkEmailRId")) {
				writer.WriteValue("BulkEmailRId", BulkEmailRId, 0);
			}
			if (!HasMapping("ContactRId")) {
				writer.WriteValue("ContactRId", ContactRId, 0);
			}
			if (!HasMapping("ApplicationUrl")) {
				writer.WriteValue("ApplicationUrl", ApplicationUrl, null);
			}
			if (Logger != null) {
				if (Logger.GetType().IsSerializable ||
					Logger.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Logger", Logger, null);
				}
			}
			if (!HasMapping("SessionKey")) {
				writer.WriteValue("SessionKey", SessionKey, null);
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
			MetaPathParameterValues.Add("85d945df-7ab5-4264-a3c7-f611954a399a", () => CampaignId);
			MetaPathParameterValues.Add("e60bee11-c357-4094-b80e-1e60dc4ffd76", () => BulkEmailId);
			MetaPathParameterValues.Add("3b00293a-64b5-44ae-9a0f-7b6b6d58aa1d", () => BulkEmailStepId);
			MetaPathParameterValues.Add("2544c42e-6fc8-4a6e-b641-d732f7f86c4a", () => ContactId);
			MetaPathParameterValues.Add("2f6dcf43-aa4d-43f8-964b-e1058549db84", () => ContactEmail);
			MetaPathParameterValues.Add("bd524a10-c122-4d51-b9eb-818c1cfe77be", () => BulkEmailRId);
			MetaPathParameterValues.Add("f780e797-a0f6-48e5-99ec-d7eace686960", () => ContactRId);
			MetaPathParameterValues.Add("387d31a1-145f-4f8d-8f19-f74c35ddce78", () => ApplicationUrl);
			MetaPathParameterValues.Add("2963f4f8-9d7b-492a-961c-75325ea3f492", () => Logger);
			MetaPathParameterValues.Add("a62e66d5-5e14-42e0-8b16-1104efe6697a", () => SessionKey);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CampaignId":
					if (!hasValueToRead) break;
					CampaignId = reader.GetValue<System.Guid>();
				break;
				case "BulkEmailId":
					if (!hasValueToRead) break;
					BulkEmailId = reader.GetValue<System.Guid>();
				break;
				case "BulkEmailStepId":
					if (!hasValueToRead) break;
					BulkEmailStepId = reader.GetValue<System.Guid>();
				break;
				case "ContactId":
					if (!hasValueToRead) break;
					ContactId = reader.GetValue<System.Guid>();
				break;
				case "ContactEmail":
					if (!hasValueToRead) break;
					ContactEmail = reader.GetValue<System.String>();
				break;
				case "BulkEmailRId":
					if (!hasValueToRead) break;
					BulkEmailRId = reader.GetValue<System.Int32>();
				break;
				case "ContactRId":
					if (!hasValueToRead) break;
					ContactRId = reader.GetValue<System.Int32>();
				break;
				case "ApplicationUrl":
					if (!hasValueToRead) break;
					ApplicationUrl = reader.GetValue<System.String>();
				break;
				case "Logger":
					if (!hasValueToRead) break;
					Logger = reader.GetSerializableObjectValue();
				break;
				case "SessionKey":
					if (!hasValueToRead) break;
					SessionKey = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SendEmailScriptTaskExecute(ProcessExecutingContext context) {
			SendEmail();
			return true;
		}

			
			public virtual void SendEmail() {
				try {
				var sendDate = DateTime.UtcNow;
				var recipients = new List<BulkEmailRecipientInfo>();
				recipients.Add(new BulkEmailRecipientInfo {
					Id = ContactId,
					EmailAddress = ContactEmail,
					ContactRId = ContactRId
				});
				var messageInfo = new InstantMessageInfo() {
					ApplicationUrl = ApplicationUrl,
					MessageId = BulkEmailId,
					MessageRId = BulkEmailRId,
					Recipients = recipients
				};
				var mailingService = ClassFactory.Get<MailingService>(new ConstructorArgument("userConnection", UserConnection));
				mailingService.SendMessage(messageInfo);
				CampaignHelper.MergeContactIntoCampaign(UserConnection, CampaignId, BulkEmailStepId, ContactId);
			} catch (Exception e) {
				LogError("Error send immediately message.", e);
			}
			}
			
			
			public virtual global::Common.Logging.ILog GetLogger() {
				var logger = Logger as global::Common.Logging.ILog;
			if (logger == null) {
				logger = global::Common.Logging.LogManager.GetLogger(this.Name);
				Logger = logger;
			}
			if (string.IsNullOrEmpty(SessionKey)) {
				SessionKey = Guid.NewGuid().ToString("N");
			}
			return logger;
			}
			
			
			public virtual void LogError(string message, Exception e) {
				var logger = GetLogger();
			logger.Error(string.Format("{0}: [{1}] {2};", this.Name, SessionKey, message));
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
			var cloneItem = (SendImmediatelyTriggeredEmailProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Logger = Logger;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

