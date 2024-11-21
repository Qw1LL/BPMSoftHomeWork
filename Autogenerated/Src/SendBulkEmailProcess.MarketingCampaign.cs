namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.MandrillService;
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

	#region Class: SendBulkEmailProcessSchema

	/// <exclude/>
	public class SendBulkEmailProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendBulkEmailProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendBulkEmailProcessSchema(SendBulkEmailProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendBulkEmailProcess";
			UId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf");
			CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b");
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,143,205,10,194,48,16,132,207,6,242,14,123,76,161,248,2,226,193,63,138,7,79,165,15,176,54,75,89,140,105,217,252,136,136,239,110,35,94,234,113,216,217,111,102,180,154,210,213,113,15,153,37,38,116,144,71,182,208,146,183,23,100,199,126,48,21,188,180,90,253,84,75,146,185,39,184,47,229,22,60,61,96,233,49,93,32,57,140,222,83,31,121,244,213,102,166,100,20,224,112,36,135,79,178,109,68,137,243,107,148,68,229,184,100,174,191,29,40,4,28,200,20,122,147,216,154,125,114,183,83,49,158,109,85,255,161,106,216,77,211,60,5,75,92,39,174,36,190,181,210,234,3,160,81,76,250,228,0,0,0 };
			RealUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf");
			Version = 0;
			PackageUId = new Guid("789c617e-760f-4576-a608-ee12728eae0a");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateBulkEmailIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("87c8cbe2-89da-4786-9907-a813ac8a6a60"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Name = @"BulkEmailId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateApplicationUrlParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dac9da52-7f6a-4472-9766-53c1d93d3257"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Name = @"ApplicationUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateBulkEmailIdParameter());
			Parameters.Add(CreateApplicationUrlParameter());
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
			ProcessSchemaScriptTask sendmailingscripttask = CreateSendMailingScriptTaskScriptTask();
			FlowElements.Add(sendmailingscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("7b495033-4376-47b6-96e5-6aea38183f50"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7750d93e-437e-4a6a-85c3-5f047a5d6e46"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d7295546-d583-4989-80b3-9f4b06e1b430"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("2b11410e-0663-4169-8f47-9ce1c7fe29da"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d7295546-d583-4989-80b3-9f4b06e1b430"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("545f30d0-9f4b-4bc5-8517-a7fbc5f33e63"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("74d6cf79-fc9c-4292-ab4e-18cd76d228a8"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("b364dea6-f7d2-4e24-9114-4a341b86d512"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("74d6cf79-fc9c-4292-ab4e-18cd76d228a8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("7750d93e-437e-4a6a-85c3-5f047a5d6e46"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b364dea6-f7d2-4e24-9114-4a341b86d512"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
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
				UId = new Guid("545f30d0-9f4b-4bc5-8517-a7fbc5f33e63"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b364dea6-f7d2-4e24-9114-4a341b86d512"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSendMailingScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d7295546-d583-4989-80b3-9f4b06e1b430"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b364dea6-f7d2-4e24-9114-4a341b86d512"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b"),
				CreatedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"),
				Name = @"SendMailingScriptTask",
				Position = new Point(281, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,78,205,75,241,77,204,204,201,204,75,215,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,6,29,63,23,28,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("6d185430-14bf-4b7e-9a9c-88c87f209a60"),
				Name = "BPMSoft.Configuration.MandrillService",
				Alias = "",
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d2b2efcf-b679-4d3a-ace8-40cfc53930db"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("3a81387c-e6ac-40c7-b70e-9a0c3966258b")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendBulkEmailProcess(userConnection);
		}

		public override object Clone() {
			return new SendBulkEmailProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2749de97-e411-4dbf-b535-eeaa891216bf"));
		}

		#endregion

	}

	#endregion

	#region Class: SendBulkEmailProcess

	/// <exclude/>
	public class SendBulkEmailProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SendBulkEmailProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SendBulkEmailProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendBulkEmailProcess";
			SchemaUId = new Guid("2749de97-e411-4dbf-b535-eeaa891216bf");
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
				return new Guid("2749de97-e411-4dbf-b535-eeaa891216bf");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendBulkEmailProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendBulkEmailProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string BulkEmailId {
			get;
			set;
		}

		public virtual string ApplicationUrl {
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
					SchemaElementUId = new Guid("7750d93e-437e-4a6a-85c3-5f047a5d6e46"),
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
					SchemaElementUId = new Guid("545f30d0-9f4b-4bc5-8517-a7fbc5f33e63"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _sendMailingScriptTask;
		public ProcessScriptTask SendMailingScriptTask {
			get {
				return _sendMailingScriptTask ?? (_sendMailingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendMailingScriptTask",
					SchemaElementUId = new Guid("d7295546-d583-4989-80b3-9f4b06e1b430"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SendMailingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SendMailingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendMailingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendMailingScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SendMailingScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("BulkEmailId")) {
				writer.WriteValue("BulkEmailId", BulkEmailId, null);
			}
			if (!HasMapping("ApplicationUrl")) {
				writer.WriteValue("ApplicationUrl", ApplicationUrl, null);
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
			MetaPathParameterValues.Add("87c8cbe2-89da-4786-9907-a813ac8a6a60", () => BulkEmailId);
			MetaPathParameterValues.Add("dac9da52-7f6a-4472-9766-53c1d93d3257", () => ApplicationUrl);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "BulkEmailId":
					if (!hasValueToRead) break;
					BulkEmailId = reader.GetValue<System.String>();
				break;
				case "ApplicationUrl":
					if (!hasValueToRead) break;
					ApplicationUrl = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SendMailingScriptTaskExecute(ProcessExecutingContext context) {
			SendMailing();
			return true;
		}

			
			public virtual void SendMailing() {
				MailingService mailingService = new MailingService(UserConnection);
				var isDelayedStart = true;
				mailingService.SendMessage(new Guid(BulkEmailId), isDelayedStart, ApplicationUrl);
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
			var cloneItem = (SendBulkEmailProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

