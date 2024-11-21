namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.CampaignEventHelper;
	using BPMSoft.Configuration.CampaignService;
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

	#region Class: CampaignSyncJobProcessSchema

	/// <exclude/>
	public class CampaignSyncJobProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public CampaignSyncJobProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public CampaignSyncJobProcessSchema(CampaignSyncJobProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "CampaignSyncJobProcess";
			UId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b");
			CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7");
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
			SerializeToMemory = false;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,209,106,195,48,12,69,159,23,200,63,136,62,57,80,250,3,107,7,89,216,214,189,21,182,126,128,103,139,212,224,218,198,178,61,218,209,127,159,147,146,46,163,126,19,87,186,58,186,170,43,23,191,180,18,144,148,15,145,107,72,86,73,232,248,209,113,213,155,143,128,142,246,78,242,128,172,129,159,186,122,72,220,131,152,119,183,220,72,141,30,54,208,105,78,244,202,69,176,254,180,122,195,176,238,10,115,79,204,224,55,116,214,80,240,113,24,109,125,31,143,104,2,91,68,66,159,27,6,69,80,214,44,150,176,255,39,52,205,99,230,151,216,171,86,12,167,171,51,142,234,243,105,2,179,169,120,151,75,200,60,28,87,76,226,22,181,203,230,107,188,73,164,79,238,123,12,173,56,40,76,200,138,184,157,183,2,137,80,222,76,119,183,206,57,47,41,199,187,194,110,175,155,107,27,24,95,114,223,97,133,165,133,5,127,241,71,145,102,169,7,203,165,174,234,234,23,87,176,221,177,231,1,0,0 };
			RealUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b");
			Version = 0;
			PackageUId = new Guid("f96c8402-9614-48d5-988e-1f34fea20081");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateCampaignIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("54028848-964b-421a-85c9-3841df6b4fdd"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Name = @"CampaignId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateCampaignIdParameter());
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
			ProcessSchemaScriptTask campaignstepsupdatescripttask = CreateCampaignStepsUpdateScriptTaskScriptTask();
			FlowElements.Add(campaignstepsupdatescripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("1ac14a9d-0379-41df-bd91-5ffecfe10ff5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9fae4d9b-42c0-4a72-a327-1b6dff178910"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a76fa5f0-fa40-4335-967c-4d7335a2353c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e27bc4ea-561f-4893-81c3-fc6acb8fe0d1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a76fa5f0-fa40-4335-967c-4d7335a2353c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0c7ee0aa-e8a7-4eb4-bffb-80836a52fb24"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("0f0aa66d-ef5e-4e13-b4cc-db74b96c38e5"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("70c5fd38-3a14-49a2-8047-aa3f478d74d0"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("0f0aa66d-ef5e-4e13-b4cc-db74b96c38e5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("9fae4d9b-42c0-4a72-a327-1b6dff178910"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("70c5fd38-3a14-49a2-8047-aa3f478d74d0"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
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
				UId = new Guid("0c7ee0aa-e8a7-4eb4-bffb-80836a52fb24"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("70c5fd38-3a14-49a2-8047-aa3f478d74d0"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateCampaignStepsUpdateScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a76fa5f0-fa40-4335-967c-4d7335a2353c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("70c5fd38-3a14-49a2-8047-aa3f478d74d0"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7"),
				CreatedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b"),
				Name = @"CampaignStepsUpdateScriptTask",
				Position = new Point(288, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,115,78,204,45,72,204,76,207,11,46,73,45,40,14,45,72,73,44,73,213,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,106,221,120,246,36,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1355700e-43a6-4207-a9d0-d855d921e60d"),
				Name = "BPMSoft.Configuration.CampaignService",
				Alias = "",
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("eba418dd-553d-4515-bd2d-63ee4ad1e969"),
				Name = "BPMSoft.Configuration.CampaignEventHelper",
				Alias = "",
				CreatedInPackageId = new Guid("99b5f9a8-cf5d-45be-a343-69b2dafeaaa7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("4c5374f2-2882-4cd6-88e3-291715451e11"),
				Name = "BPMSoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("7d972476-9a4e-4513-ae9f-e172d7a9f8f9")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9ead654e-6710-453f-b113-cdfef3f66095"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("87c82e9d-12e0-47a8-bdbc-f68fbefb89eb")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("54e531ce-91c9-4644-a11a-c1183211b64a"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("a23e3075-8314-4906-9149-dbbf998e030c")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new CampaignSyncJobProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignSyncJobProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("042cad72-a7b7-4e50-add6-540b5530464b"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignSyncJobProcess

	/// <exclude/>
	public class CampaignSyncJobProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, CampaignSyncJobProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public CampaignSyncJobProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignSyncJobProcess";
			SchemaUId = new Guid("042cad72-a7b7-4e50-add6-540b5530464b");
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
				return new Guid("042cad72-a7b7-4e50-add6-540b5530464b");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: CampaignSyncJobProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: CampaignSyncJobProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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
					SchemaElementUId = new Guid("9fae4d9b-42c0-4a72-a327-1b6dff178910"),
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
					SchemaElementUId = new Guid("0c7ee0aa-e8a7-4eb4-bffb-80836a52fb24"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _campaignStepsUpdateScriptTask;
		public ProcessScriptTask CampaignStepsUpdateScriptTask {
			get {
				return _campaignStepsUpdateScriptTask ?? (_campaignStepsUpdateScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CampaignStepsUpdateScriptTask",
					SchemaElementUId = new Guid("a76fa5f0-fa40-4335-967c-4d7335a2353c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = CampaignStepsUpdateScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[CampaignStepsUpdateScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignStepsUpdateScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CampaignStepsUpdateScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "CampaignStepsUpdateScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("CampaignId")) {
				writer.WriteValue("CampaignId", CampaignId, Guid.Empty);
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
			MetaPathParameterValues.Add("54028848-964b-421a-85c9-3841df6b4fdd", () => CampaignId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "CampaignId":
					if (!hasValueToRead) break;
					CampaignId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool CampaignStepsUpdateScriptTaskExecute(ProcessExecutingContext context) {
			CampaignStepsUpdate();
			return true;
		}

			
			public virtual void CampaignStepsUpdate() {
				var campaignStepsHandler = ClassFactory.Get<CampaignStepsHandler>(new ConstructorArgument("userConnection", UserConnection));
				campaignStepsHandler.ActualizeStepsByCampaign(CampaignId, true);
				CampaignHelper.UpdateCampaignsTargetAchieve(campaignStepsHandler.ProcessedCampaigns, UserConnection);
				CampaignEventHelper campaignEventHelper = new CampaignEventHelper(UserConnection);
				campaignEventHelper.ActualizeEvents(CampaignId);
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
			var cloneItem = (CampaignSyncJobProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

