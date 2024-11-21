namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign.Enums;
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

	#region Class: RunCampaignProcessSchema

	/// <exclude/>
	public class RunCampaignProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public RunCampaignProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public RunCampaignProcessSchema(RunCampaignProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "RunCampaignProcess";
			UId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db");
			CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = null;
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
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,80,203,78,195,48,16,60,59,95,97,229,228,72,200,63,80,218,75,20,74,36,84,1,81,225,188,56,91,106,225,71,234,216,64,132,250,239,56,110,69,232,227,98,173,103,118,103,103,167,11,111,74,10,186,12,178,165,75,244,37,232,14,228,187,105,196,22,53,172,235,150,37,70,28,225,186,189,161,235,30,93,105,141,65,225,165,53,52,156,124,11,250,147,145,147,145,63,37,58,79,91,120,165,59,63,204,50,242,9,142,246,168,226,220,83,64,55,68,218,224,23,109,18,194,206,84,51,66,120,105,85,208,134,229,23,22,243,68,223,57,171,39,50,79,216,235,22,29,178,124,108,225,117,95,237,2,40,118,144,225,143,224,64,163,71,199,166,219,138,130,66,127,116,16,13,254,51,199,155,14,133,220,12,43,251,96,197,199,189,52,190,103,197,89,75,245,141,34,120,124,70,104,163,106,11,30,14,37,157,47,198,80,200,181,64,166,46,62,134,159,172,189,128,10,120,59,70,181,184,122,108,92,187,31,31,135,62,56,115,153,243,44,219,255,2,61,42,236,187,213,1,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db");
			Version = 0;
			PackageUId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCampaignIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("78ff6226-18fd-4054-a8d7-8364f51fa82e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"CampaignId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateScheduledUtcFireTimeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a607a24d-8fb6-4aa5-a092-74b07f2048c7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"ScheduledUtcFireTime",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCampaignIdParameter());
			Parameters.Add(CreateScheduledUtcFireTimeParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask runcampaignscripttask = CreateRunCampaignScriptTaskScriptTask();
			FlowElements.Add(runcampaignscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("fdbe892f-d639-44ca-a24c-df1f84bb8742"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("fae6af65-f56c-4e17-9be2-c2f39b31efba"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4e9efb44-5b3d-44c3-bde2-da8629708298"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("755b919c-996f-41e5-82ae-d7d4384bc206"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4e9efb44-5b3d-44c3-bde2-da8629708298"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5247eb72-3c2f-4f40-b537-453f3a87006c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("956aac5c-eca4-4448-bee2-3098429fa400"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("8b224e5a-3fed-438a-9d16-c6dfecebd24c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("956aac5c-eca4-4448-bee2-3098429fa400"),
				CreatedInOwnerSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("fae6af65-f56c-4e17-9be2-c2f39b31efba"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8b224e5a-3fed-438a-9d16-c6dfecebd24c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"StartEvent1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("5247eb72-3c2f-4f40-b537-453f3a87006c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8b224e5a-3fed-438a-9d16-c6dfecebd24c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"TerminateEvent1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateRunCampaignScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("4e9efb44-5b3d-44c3-bde2-da8629708298"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("8b224e5a-3fed-438a-9d16-c6dfecebd24c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081"),
				CreatedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"),
				Name = @"RunCampaignScriptTask",
				Position = new Point(283, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,65,110,194,48,16,60,147,87,88,57,5,201,202,7,160,72,21,208,136,30,42,84,154,7,152,100,73,141,176,141,156,53,109,132,248,123,23,130,77,19,114,178,189,59,51,59,59,62,9,203,10,161,142,66,86,122,85,178,23,150,1,78,51,39,203,89,18,207,67,61,30,79,162,19,33,93,13,118,110,180,134,2,165,209,119,116,222,41,18,175,91,240,220,186,248,134,210,29,160,204,177,120,147,22,190,164,130,187,194,66,224,237,73,220,205,0,202,43,120,159,87,140,18,185,183,59,239,151,147,199,66,188,103,153,148,228,142,5,64,160,164,171,250,195,224,82,29,177,73,198,99,118,142,70,215,129,123,179,93,254,66,225,208,88,26,165,225,135,249,89,239,143,78,66,154,30,189,22,86,168,250,142,93,200,219,72,97,155,105,141,86,234,138,51,179,221,147,143,217,85,127,116,102,33,224,96,35,230,3,75,94,120,139,30,140,134,15,231,250,196,121,109,255,130,135,13,122,157,244,211,233,14,75,137,12,52,88,65,27,110,144,14,168,154,30,91,137,54,2,98,123,68,186,128,157,112,7,92,131,149,134,156,71,163,11,133,243,47,198,180,189,64,210,253,22,254,8,143,210,188,68,22,208,89,205,208,58,152,252,1,150,31,154,108,162,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6c04eb9b-f4bb-4657-b338-e7234d38b202"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("14282258-f9ae-4cbe-b740-b85af3eb3a4a"),
				Name = "BPMSoft.Core.Campaign.Enums",
				Alias = "",
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new RunCampaignProcess(userConnection);
		}

		public override object Clone() {
			return new RunCampaignProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db"));
		}

		#endregion

	}

	#endregion

	#region Class: RunCampaignProcessMethodsWrapper

	/// <exclude/>
	public class RunCampaignProcessMethodsWrapper : ProcessModel
	{

		public RunCampaignProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("RunCampaignScriptTaskExecute", RunCampaignScriptTaskExecute);
		}

		#region Methods: Private

		private bool RunCampaignScriptTaskExecute(ProcessExecutingContext context) {
			var campaignId = Get<Guid>("CampaignId");
			var userConnection = Get<UserConnection>("UserConnection");
			var scheduledUtcFireTime = Get<DateTime>("ScheduledUtcFireTime");
			var campaignSchemaUId = GetCampaignSchemaUId(campaignId, userConnection);
			if (campaignSchemaUId.IsNotEmpty()) {
				var jobExecutor = new CampaignJobExecutor();
				var jobParams = new Dictionary<string, object> {
					{ "CampaignSchemaUId", campaignSchemaUId },
					{ "ScheduledUtcFireTime", scheduledUtcFireTime },
					{ "ScheduledAction", CampaignScheduledAction.Run },
					{ "SchemaGeneratorStrategy", CampaignSchemaExecutionStrategy.DefaultPeriod }
				};
				jobExecutor.Execute(userConnection, jobParams);
			}
			return true;
		}

			public Guid GetCampaignSchemaUId(Guid campaignId, UserConnection userConnection) {
				Guid campaignSchemaUId = Guid.Empty;
				var selectQuery = new Select(userConnection)
					.Column("CampaignSchemaUId")
					.From("Campaign")
					.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
				selectQuery.SpecifyNoLockHints();
				selectQuery.ExecuteReader(dataReader => {
					campaignSchemaUId = dataReader.GetColumnValue<Guid>("CampaignSchemaUId");
				});
				return campaignSchemaUId;
			}

		#endregion

	}

	#endregion

	#region Class: RunCampaignProcess

	/// <exclude/>
	public class RunCampaignProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, RunCampaignProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public RunCampaignProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RunCampaignProcess";
			SchemaUId = new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new RunCampaignProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bf34bef3-8e0d-47f1-96c5-dace6f02c4db");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: RunCampaignProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: RunCampaignProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual DateTime ScheduledUtcFireTime {
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
					SchemaElementUId = new Guid("fae6af65-f56c-4e17-9be2-c2f39b31efba"),
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
					SchemaElementUId = new Guid("5247eb72-3c2f-4f40-b537-453f3a87006c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _runCampaignScriptTask;
		public ProcessScriptTask RunCampaignScriptTask {
			get {
				return _runCampaignScriptTask ?? (_runCampaignScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RunCampaignScriptTask",
					SchemaElementUId = new Guid("4e9efb44-5b3d-44c3-bde2-da8629708298"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("RunCampaignScriptTaskExecute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[RunCampaignScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RunCampaignScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RunCampaignScriptTask", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "RunCampaignScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CampaignId")) {
				writer.WriteValue("CampaignId", CampaignId, Guid.Empty);
			}
			if (!HasMapping("ScheduledUtcFireTime")) {
				writer.WriteValue("ScheduledUtcFireTime", ScheduledUtcFireTime, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
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
			MetaPathParameterValues.Add("78ff6226-18fd-4054-a8d7-8364f51fa82e", () => CampaignId);
			MetaPathParameterValues.Add("a607a24d-8fb6-4aa5-a092-74b07f2048c7", () => ScheduledUtcFireTime);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CampaignId":
					if (!hasValueToRead) break;
					CampaignId = reader.GetValue<System.Guid>();
				break;
				case "ScheduledUtcFireTime":
					if (!hasValueToRead) break;
					ScheduledUtcFireTime = reader.GetValue<System.DateTime>();
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
			var cloneItem = (RunCampaignProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

