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

	#region Class: CampaignCreateLeadProcessSchema

	/// <exclude/>
	public class CampaignCreateLeadProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CampaignCreateLeadProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CampaignCreateLeadProcessSchema(CampaignCreateLeadProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CampaignCreateLeadProcess";
			UId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625");
			CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
			CultureName = @"ru-RU";
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,87,75,111,219,56,16,62,187,64,255,3,171,67,33,163,130,144,93,160,151,36,54,208,58,110,224,108,146,186,112,218,30,210,30,104,137,118,24,200,164,151,162,210,120,131,252,247,29,114,40,137,148,229,6,104,30,150,65,114,94,223,204,124,67,189,126,181,173,150,5,207,200,3,87,186,162,5,121,144,60,39,19,197,168,102,151,140,230,241,144,60,189,126,53,120,160,138,20,114,189,102,138,140,200,186,144,75,90,28,31,79,228,102,35,69,122,9,235,92,172,205,243,138,10,10,103,210,115,166,205,42,83,177,190,227,101,186,200,238,216,134,166,215,116,195,134,39,78,155,166,106,205,244,76,172,228,68,22,5,203,52,151,2,116,223,244,45,211,146,204,166,162,218,48,69,151,5,59,253,135,237,190,209,162,98,115,202,213,233,121,197,243,132,152,207,241,216,232,230,43,18,247,234,126,51,34,162,42,10,140,103,48,21,154,235,29,58,70,10,8,212,125,29,145,175,37,83,19,41,4,138,165,254,65,47,188,153,40,53,21,25,251,184,51,81,197,145,193,42,178,193,13,206,184,149,164,106,119,90,106,5,200,36,68,46,239,65,221,152,8,56,219,184,94,130,49,208,116,198,86,180,42,52,120,90,109,68,25,27,69,11,205,182,179,28,181,113,161,73,38,43,161,45,244,71,118,237,146,151,218,6,62,174,97,204,3,16,5,251,69,218,51,49,42,90,73,72,106,118,71,226,67,240,121,41,33,92,244,38,200,129,231,208,179,184,185,175,35,15,196,20,203,7,119,226,16,79,244,101,208,74,166,11,11,1,134,111,253,42,227,222,67,222,137,56,90,128,119,218,64,133,41,217,48,161,231,74,102,172,44,163,132,172,104,81,178,151,117,124,129,114,231,43,206,0,59,161,105,6,32,130,108,27,117,106,143,57,53,253,224,117,211,187,133,69,3,93,152,230,26,180,160,230,208,19,200,172,125,132,232,97,37,164,159,184,200,93,121,25,197,41,152,118,222,216,34,119,162,97,89,255,54,98,148,72,172,155,65,116,131,103,251,192,79,173,118,181,46,99,198,87,71,31,88,60,108,45,237,215,94,250,33,207,189,238,243,93,182,202,222,189,171,75,121,76,222,31,29,181,170,6,224,234,156,150,37,115,181,239,181,65,147,19,207,78,163,180,207,135,9,184,172,234,26,130,159,110,247,52,145,214,143,160,140,13,152,120,12,119,51,170,77,222,167,143,25,219,218,246,98,143,141,219,200,136,233,119,170,196,39,169,54,84,35,15,16,168,22,200,172,45,42,242,35,122,58,122,254,17,145,140,66,93,72,77,150,140,100,182,61,242,244,233,239,231,169,82,82,29,147,167,191,158,163,4,117,118,11,48,1,131,233,21,20,54,148,121,66,166,2,120,90,10,83,239,233,53,251,117,201,69,157,67,235,173,253,240,24,48,128,197,192,0,184,55,168,255,9,228,198,0,252,195,159,249,237,140,142,223,16,223,62,207,25,202,33,142,232,154,17,179,199,143,134,201,14,171,197,36,251,109,245,165,98,80,190,172,252,215,201,238,237,197,47,211,123,66,162,9,221,64,147,172,133,241,15,89,29,84,154,226,70,239,227,232,98,241,249,186,119,163,150,196,77,87,85,153,167,14,28,51,34,0,72,47,63,38,53,38,245,44,11,100,195,102,183,16,214,251,179,28,52,251,135,141,137,155,221,214,208,91,67,1,110,32,52,94,2,229,97,94,67,224,109,27,183,161,36,158,17,60,126,241,65,41,186,35,247,248,176,99,12,68,184,77,83,97,106,55,112,219,13,50,8,198,9,184,48,200,219,183,78,197,126,113,206,236,252,234,73,61,62,199,99,146,99,61,225,200,0,31,176,125,156,190,27,249,217,150,200,233,139,122,234,241,56,192,5,199,200,134,117,129,188,64,109,52,105,22,162,158,131,214,124,112,210,174,68,157,177,113,216,129,32,14,51,60,130,184,26,170,49,232,249,59,128,24,240,11,23,37,216,142,3,159,135,0,171,163,185,23,4,106,223,61,74,223,71,1,2,243,213,220,6,182,126,54,36,187,15,74,191,96,109,179,149,108,103,25,138,121,197,241,166,83,150,253,49,251,238,247,21,114,123,50,33,49,50,199,208,112,131,233,5,223,242,176,29,25,193,124,104,152,213,252,43,166,43,213,157,240,39,135,24,209,245,201,126,123,56,98,48,221,129,95,91,14,188,47,101,3,96,187,223,219,205,174,132,124,58,186,192,186,183,90,220,215,17,249,56,191,90,200,149,78,221,133,253,2,246,240,227,140,1,249,112,184,6,253,199,226,198,238,208,220,183,157,158,154,133,60,117,33,7,249,246,206,168,54,23,232,246,236,109,68,243,220,196,27,253,236,232,108,148,90,153,206,29,198,97,92,111,223,70,237,235,200,153,223,28,78,171,197,248,164,47,73,56,202,251,83,99,223,115,186,35,208,50,234,214,91,73,130,23,143,243,3,87,110,116,252,235,54,7,47,73,101,31,56,136,112,8,225,198,30,209,55,4,139,239,60,209,208,132,96,238,108,113,228,59,5,244,139,57,79,231,84,65,217,193,85,6,238,131,237,254,16,229,190,223,49,5,151,90,195,232,233,76,196,93,145,178,231,74,0,141,3,248,161,119,6,63,207,243,116,250,200,178,10,156,54,69,101,1,252,31,185,27,195,42,41,14,0,0 };
			RealUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625");
			Version = 0;
			PackageUId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateLeadStepIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("eb87380c-a95a-4a44-95da-b83827b301b6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Name = @"LeadStepId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTargetInfoCollectionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ba95186c-0b66-4608-8e44-30714cb58500"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Name = @"TargetInfoCollection",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateLeadStepIdParameter());
			Parameters.Add(CreateTargetInfoCollectionParameter());
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
			ProcessSchemaScriptTask createleadscripttask = CreateCreateLeadScriptTaskScriptTask();
			FlowElements.Add(createleadscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("eebcd74c-6407-4aab-8e22-5a3c69e80227"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c453f4bb-0948-45ee-9f3c-531394a38393"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("94653132-aac7-4355-97f2-b2c31c58fd4f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("4f64caef-8293-4432-a27f-1ea8c4224231"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("94653132-aac7-4355-97f2-b2c31c58fd4f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ab63017c-3d97-4dfb-a462-9d975f3c007c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("cb83dccf-f722-4089-b444-79c61eeccf4f"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("3d83941c-854f-4239-9104-f7dae1bf1919"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("cb83dccf-f722-4089-b444-79c61eeccf4f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("c453f4bb-0948-45ee-9f3c-531394a38393"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3d83941c-854f-4239-9104-f7dae1bf1919"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
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
				UId = new Guid("ab63017c-3d97-4dfb-a462-9d975f3c007c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3d83941c-854f-4239-9104-f7dae1bf1919"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateCreateLeadScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("94653132-aac7-4355-97f2-b2c31c58fd4f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3d83941c-854f-4239-9104-f7dae1bf1919"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("2def6958-6e0c-463c-8c46-5a65b8967369"),
				CreatedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"),
				Name = @"CreateLeadScriptTask",
				Position = new Point(288, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,46,74,77,44,73,245,73,77,76,209,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,157,165,154,94,27,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CampaignCreateLeadProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignCreateLeadProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignCreateLeadProcess

	/// <exclude/>
	public class CampaignCreateLeadProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CampaignCreateLeadProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public CampaignCreateLeadProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignCreateLeadProcess";
			SchemaUId = new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625");
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
				return new Guid("35deb097-e755-4e60-bd6f-53c5f7baf625");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CampaignCreateLeadProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CampaignCreateLeadProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid LeadStepId {
			get;
			set;
		}

		public virtual Object TargetInfoCollection {
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
					SchemaElementUId = new Guid("c453f4bb-0948-45ee-9f3c-531394a38393"),
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
					SchemaElementUId = new Guid("ab63017c-3d97-4dfb-a462-9d975f3c007c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _createLeadScriptTask;
		public ProcessScriptTask CreateLeadScriptTask {
			get {
				return _createLeadScriptTask ?? (_createLeadScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CreateLeadScriptTask",
					SchemaElementUId = new Guid("94653132-aac7-4355-97f2-b2c31c58fd4f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CreateLeadScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[CreateLeadScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CreateLeadScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CreateLeadScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "CreateLeadScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("LeadStepId")) {
				writer.WriteValue("LeadStepId", LeadStepId, Guid.Empty);
			}
			if (TargetInfoCollection != null) {
				if (TargetInfoCollection.GetType().IsSerializable ||
					TargetInfoCollection.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("TargetInfoCollection", TargetInfoCollection, null);
				}
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
			MetaPathParameterValues.Add("eb87380c-a95a-4a44-95da-b83827b301b6", () => LeadStepId);
			MetaPathParameterValues.Add("ba95186c-0b66-4608-8e44-30714cb58500", () => TargetInfoCollection);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "LeadStepId":
					if (!hasValueToRead) break;
					LeadStepId = reader.GetValue<System.Guid>();
				break;
				case "TargetInfoCollection":
					if (!hasValueToRead) break;
					TargetInfoCollection = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool CreateLeadScriptTaskExecute(ProcessExecutingContext context) {
			CreateLead();
			return true;
		}

			
			public virtual void CreateLead() {
				var logger = global::Common.Logging.LogManager.GetLogger(this.Schema.Name);
				var targetInfoCollection = TargetInfoCollection as IEnumerable<KeyValuePair<Guid, Guid>>;
				if (targetInfoCollection != null) {
					EntitySchema leadSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Lead");
					Dictionary<string, object> nameValuePairs = GetDefaultColumns(LeadStepId);
					int counter = 0;
					List<Guid> targetIdCollection = new List<Guid>();
					foreach (KeyValuePair<Guid, Guid> targetInfo in targetInfoCollection) {
						Entity leadEntity = leadSchema.CreateEntity(UserConnection);
						leadEntity.SetDefColumnValues();
						leadEntity.SetColumnValue("StartLeadManagementProcess", false);
						leadEntity.SetColumnValue("QualifiedContactId", targetInfo.Value);
						foreach (KeyValuePair<string, object> pair in nameValuePairs) {
							EntitySchemaColumn column = leadSchema.Columns.FindByName(pair.Key);
							if (column != null) {
								leadEntity.SetColumnValue(column, pair.Value);
							}
						}
						try {
							if (leadEntity.Save()) {
								targetIdCollection.Add(targetInfo.Key);
								if (++counter > 500) {
									SetPassedStepId(LeadStepId, targetIdCollection);
									targetIdCollection.Clear();
									counter = 0;
								}
							}
							leadEntity = null;
						}
						catch (Exception ex) {
							logger.WarnFormat("Lead for contact \"{0}\" can not be created.{2}Error: {1}",
							targetInfo.Value, ex.Message, Environment.NewLine);
						}
					}
					if (targetIdCollection.Count > 0) {
						SetPassedStepId(LeadStepId, targetIdCollection);
					}
				}
			}
			
			
			public virtual Dictionary<string, object> GetDefaultColumns(Guid StepId) {
				var nameValuePairs = new Dictionary<string, object>();
				EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "CampaignStep");
				esq.AddColumn("JSON");
				esq.AddColumn("Campaign");
				Entity campaignStep = esq.GetEntity(UserConnection, StepId);
				if (campaignStep != null) {
					Guid campaignId = campaignStep.GetTypedColumnValue<Guid>("CampaignId");
					nameValuePairs.Add("Campaign", campaignId);
					JArray jArray = GetAdditionalInfo(campaignStep);
					if (jArray != null && jArray.Count > 0) {
						IList<Dictionary<string, string>> defaultValues = 
							jArray.ToObject<IList<Dictionary<string, string>>>();
						string columnNameKey = "ColumnName";
						string columnValueKey = "ColumnValue";
						foreach (Dictionary<string, string> defaultValue in defaultValues) {
							if (defaultValue.ContainsKey(columnNameKey) &&
								defaultValue.ContainsKey(columnValueKey)) {
									string columnName = defaultValue[columnNameKey];
									string columnValue = defaultValue[columnValueKey];
									if (columnValue != null && !nameValuePairs.ContainsKey(columnName)) {
										nameValuePairs.Add(columnName, (object)new Guid(columnValue));
									}
							}
						}
					}
				}
				return nameValuePairs;
			}
			
			
			public virtual JArray GetAdditionalInfo(Entity StepEntity) {
				var jsonValue = StepEntity.GetTypedColumnValue<string>("JSON");
				JObject jsonObject = BPMSoft.Common.Json.Json.Deserialize(jsonValue) as JObject;
				if (jsonObject != null) {
					JObject jsonData = jsonObject["addInfo"] as JObject;
					if (jsonData != null) {
						return jsonData["CreateLeadDefaultValues"] as JArray;
					}
				}
				return null;
			}
			
			
			public virtual void SetPassedStepId(Guid passedStepId, IEnumerable<Guid> targetIdCollection) {
				Update updateQuery = new Update(UserConnection, "CampaignTarget")
					.Set("PassedStepId", Column.Parameter(passedStepId))
					.Where("Id").In(Column.Parameters(targetIdCollection)) as Update;
				updateQuery.Execute();
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
			var cloneItem = (CampaignCreateLeadProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.TargetInfoCollection = TargetInfoCollection;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

