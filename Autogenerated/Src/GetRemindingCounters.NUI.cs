namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Messaging.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: GetRemindingCountersSchema

	/// <exclude/>
	public class GetRemindingCountersSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GetRemindingCountersSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GetRemindingCountersSchema(GetRemindingCountersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GetRemindingCounters";
			UId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
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
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			Version = 0;
			PackageUId = new Guid("a7d9c356-450c-46d7-bc85-72dca4e280ba");
			UseSystemSecurityContext = false;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaGetRemindingCountersLaneSet = CreateGetRemindingCountersLaneSetLaneSet();
			LaneSets.Add(schemaGetRemindingCountersLaneSet);
			ProcessSchemaLane schemaGetRemindingCountersLane = CreateGetRemindingCountersLaneLane();
			schemaGetRemindingCountersLaneSet.Lanes.Add(schemaGetRemindingCountersLane);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask getremindingcountersscripttask = CreateGetRemindingCountersScriptTaskScriptTask();
			FlowElements.Add(getremindingcountersscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("595bab57-506e-4a72-ba3b-ddb02fefaa42"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1d7eee7b-2f5a-41fa-b7b2-2dfaf51bf6ba"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("7d23619e-0249-456f-94fb-de2f5ea9713e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d3e3c68c-167f-497a-b5fa-df3a31fdabd1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateGetRemindingCountersLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaGetRemindingCountersLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("1d86ee0a-d2f4-407b-b055-fb95b10d07a6"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"GetRemindingCountersLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGetRemindingCountersLaneSet;
		}

		protected virtual ProcessSchemaLane CreateGetRemindingCountersLaneLane() {
			ProcessSchemaLane schemaGetRemindingCountersLane = new ProcessSchemaLane(this) {
				UId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("1d86ee0a-d2f4-407b-b055-fb95b10d07a6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"GetRemindingCountersLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGetRemindingCountersLane;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("1d7eee7b-2f5a-41fa-b7b2-2dfaf51bf6ba"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("d3e3c68c-167f-497a-b5fa-df3a31fdabd1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"End1",
				Position = new Point(309, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateGetRemindingCountersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("fe4066c8-e30d-4fce-a82e-6c6dab24e720"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3"),
				CreatedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"),
				Name = @"GetRemindingCountersScriptTask",
				Position = new Point(141, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,83,203,110,219,48,16,60,59,64,254,129,208,73,6,12,34,231,182,78,144,168,105,226,131,131,212,143,246,80,244,64,136,27,155,128,72,42,228,50,129,80,244,223,187,43,41,142,164,198,128,64,112,60,51,59,187,43,189,168,32,32,62,139,165,112,240,42,110,29,26,108,182,229,17,172,250,158,32,52,249,62,66,40,188,115,80,162,241,78,14,9,107,229,212,1,194,66,100,219,38,94,107,107,220,222,25,204,230,159,207,207,254,243,41,124,149,172,19,117,48,86,157,110,75,174,44,175,181,238,238,57,223,54,222,99,167,147,119,128,143,67,254,131,178,144,207,217,126,44,203,40,31,170,178,171,204,127,125,51,21,66,136,76,105,61,139,0,10,161,67,127,26,60,62,170,64,86,76,201,59,176,240,182,86,193,68,239,118,77,13,242,246,57,169,106,113,126,54,203,184,100,182,16,147,33,20,41,4,112,200,168,100,198,252,189,101,138,84,117,44,65,12,131,6,98,223,38,117,51,165,76,134,203,46,230,73,228,111,66,89,248,228,80,92,138,139,185,248,67,105,238,146,209,34,14,70,189,210,236,221,179,127,93,252,230,26,220,64,63,152,31,170,74,240,133,85,151,249,104,240,93,104,170,54,91,173,227,161,56,42,74,80,137,178,63,151,226,29,236,87,44,87,113,147,156,51,238,32,72,212,254,174,62,98,185,136,202,149,64,11,112,122,133,96,111,154,253,74,231,227,200,243,55,135,79,194,165,170,226,20,220,244,169,250,178,133,187,142,103,1,48,5,39,48,36,96,226,95,122,54,64,86,154,162,196,123,168,106,8,34,76,129,238,85,158,242,62,24,246,44,98,224,158,158,124,176,10,17,244,87,122,77,72,206,199,206,88,144,123,44,31,252,171,220,249,109,75,204,51,159,13,117,22,98,164,198,111,188,110,72,53,205,193,219,216,156,176,118,151,27,136,181,119,17,38,35,89,140,19,180,37,94,232,187,140,198,214,21,172,187,42,125,91,219,17,214,14,169,125,13,38,142,140,247,185,6,41,121,132,109,254,161,137,188,7,165,41,238,22,28,29,36,200,134,193,219,220,244,165,100,172,235,151,36,31,125,196,94,157,143,188,56,58,45,105,184,182,127,251,202,126,151,97,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1b9f6559-51a0-40df-8314-eeb73998eb93"),
				Name = "BPMSoft.Messaging.Common",
				Alias = "",
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("52c807d3-cd14-4c38-a2f6-b4fa50601032"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("85a972d5-aaea-43a7-af9b-d75884bd785b")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GetRemindingCounters(userConnection);
		}

		public override object Clone() {
			return new GetRemindingCountersSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7e1de80a-7626-454d-9afa-3c0771af5786"));
		}

		#endregion

	}

	#endregion

	#region Class: GetRemindingCounters

	/// <exclude/>
	public class GetRemindingCounters : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessGetRemindingCountersLane

		/// <exclude/>
		public class ProcessGetRemindingCountersLane : ProcessLane
		{

			public ProcessGetRemindingCountersLane(UserConnection userConnection, GetRemindingCounters process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GetRemindingCounters(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GetRemindingCounters";
			SchemaUId = new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7e1de80a-7626-454d-9afa-3c0771af5786");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GetRemindingCounters, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GetRemindingCounters, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		private ProcessGetRemindingCountersLane _getRemindingCountersLane;
		public ProcessGetRemindingCountersLane GetRemindingCountersLane {
			get {
				return _getRemindingCountersLane ?? ((_getRemindingCountersLane) = new ProcessGetRemindingCountersLane(UserConnection, this));
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
					SchemaElementUId = new Guid("1d7eee7b-2f5a-41fa-b7b2-2dfaf51bf6ba"),
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
					SchemaElementUId = new Guid("d3e3c68c-167f-497a-b5fa-df3a31fdabd1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _getRemindingCountersScriptTask;
		public ProcessScriptTask GetRemindingCountersScriptTask {
			get {
				return _getRemindingCountersScriptTask ?? (_getRemindingCountersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "GetRemindingCountersScriptTask",
					SchemaElementUId = new Guid("40197e3a-cf2f-4819-a92e-15fdefdc1aa6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = GetRemindingCountersScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[GetRemindingCountersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GetRemindingCountersScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GetRemindingCountersScriptTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "GetRemindingCountersScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
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
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool GetRemindingCountersScriptTaskExecute(ProcessExecutingContext context) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			EntitySchemaQueryColumn primaryColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			esq.AddColumn("Contact");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Name", UserConnection.CurrentUser.Name));
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				Guid sysAdminUnitId = entities[0].GetTypedColumnValue<Guid>(primaryColumn.Name);
				IMsgChannel channel = MsgChannelManager.IsRunning 
									? MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId)
									: null;
				if (channel == null) {
					return true;
				}
				RemindingsHelper remindingsHelper = new RemindingsHelper(UserConnection);
				string formattedDate = DateTime.UtcNow.ToString("o");
				string messageBody = remindingsHelper.GetRemindingsCountResponse(sysAdminUnitId, formattedDate);
				var simpleMessage = new SimpleMessage {
					Id = sysAdminUnitId,
					Body = messageBody
				};
				simpleMessage.Header.Sender = "GetRemindingCounters";
				channel.PostMessage(simpleMessage);
			}
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
			var cloneItem = (GetRemindingCounters)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

