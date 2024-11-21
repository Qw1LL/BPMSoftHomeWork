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

	#region Class: ShowAccountAddressOnMapProcessSchema

	/// <exclude/>
	public class ShowAccountAddressOnMapProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ShowAccountAddressOnMapProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ShowAccountAddressOnMapProcessSchema(ShowAccountAddressOnMapProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ShowAccountAddressOnMapProcess";
			UId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"ru-RU";
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("531805de-05d1-4114-8344-f03894234ffe"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c634e950-a48a-4208-9548-4c4e81207f9b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTreeGridSelectedRowsIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5e34e306-6c0c-4fb6-aedc-71a080389d39"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"TreeGridSelectedRowsIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateTreeGridSelectedRowsIdsParameter());
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
			ProcessSchemaScriptTask prepareopenpageusertask = CreatePrepareOpenPageUserTaskScriptTask();
			FlowElements.Add(prepareopenpageusertask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("9f6ed268-8a8c-48fe-9c89-aece88bf03ca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7fd2ea8b-b16f-47f1-9fb3-568fa1ab6533"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3a655e33-5f7d-412a-a5ed-41d44cdb419b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("c233069f-22db-449f-9d45-8fb866934597"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3a655e33-5f7d-412a-a5ed-41d44cdb419b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("25137e8b-6cd8-4aa5-913b-4250ca1d2e04"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("a6991f22-da08-43b7-aaa1-38fdaf3ae168"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("842e8e8e-34bc-4a2c-bcef-29314d2b6046"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("a6991f22-da08-43b7-aaa1-38fdaf3ae168"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("7fd2ea8b-b16f-47f1-9fb3-568fa1ab6533"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("842e8e8e-34bc-4a2c-bcef-29314d2b6046"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
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
				UId = new Guid("25137e8b-6cd8-4aa5-913b-4250ca1d2e04"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("842e8e8e-34bc-4a2c-bcef-29314d2b6046"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"End1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareOpenPageUserTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("3a655e33-5f7d-412a-a5ed-41d44cdb419b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("842e8e8e-34bc-4a2c-bcef-29314d2b6046"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"),
				Name = @"PrepareOpenPageUserTask",
				Position = new Point(197, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,77,107,194,64,16,134,239,133,254,135,37,167,4,154,64,173,181,13,210,131,149,34,57,88,196,143,222,215,236,107,13,36,187,101,118,87,235,191,239,24,147,66,168,82,79,187,204,204,243,236,187,204,78,146,176,91,179,31,41,130,181,51,50,57,31,171,76,137,23,161,177,23,19,95,168,48,144,235,205,122,243,4,196,232,167,105,220,127,68,26,167,170,215,139,215,41,210,123,217,31,12,158,31,84,16,13,111,111,118,108,171,164,150,159,32,22,172,44,104,108,180,70,238,10,163,147,70,190,200,183,168,228,244,52,213,48,182,174,49,34,194,206,84,212,200,146,9,92,166,173,147,58,199,235,129,227,133,231,50,255,38,48,202,151,104,234,44,61,217,147,49,65,186,182,28,118,195,29,209,14,150,44,224,248,250,5,114,135,15,89,122,132,193,140,147,180,33,50,21,220,137,110,225,26,197,136,31,219,97,73,192,132,10,53,246,68,208,110,110,246,181,238,114,51,186,66,221,114,11,148,252,37,40,6,109,166,44,123,47,116,174,145,158,182,240,46,43,176,135,211,231,198,107,87,111,250,63,114,110,188,195,212,168,35,184,145,165,197,95,232,237,27,57,15,157,217,4,193,121,210,194,145,199,240,7,36,7,41,150,161,2,0,0 }
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
			return new ShowAccountAddressOnMapProcess(userConnection);
		}

		public override object Clone() {
			return new ShowAccountAddressOnMapProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56"));
		}

		#endregion

	}

	#endregion

	#region Class: ShowAccountAddressOnMapProcess

	/// <exclude/>
	public class ShowAccountAddressOnMapProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ShowAccountAddressOnMapProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ShowAccountAddressOnMapProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ShowAccountAddressOnMapProcess";
			SchemaUId = new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("23c82266-0fb3-4b53-b9be-b901b924ce56");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ShowAccountAddressOnMapProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ShowAccountAddressOnMapProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object TreeGridSelectedRowsIds {
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
					SchemaElementUId = new Guid("7fd2ea8b-b16f-47f1-9fb3-568fa1ab6533"),
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
					SchemaElementUId = new Guid("25137e8b-6cd8-4aa5-913b-4250ca1d2e04"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareOpenPageUserTask;
		public ProcessScriptTask PrepareOpenPageUserTask {
			get {
				return _prepareOpenPageUserTask ?? (_prepareOpenPageUserTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareOpenPageUserTask",
					SchemaElementUId = new Guid("3a655e33-5f7d-412a-a5ed-41d44cdb419b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareOpenPageUserTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[PrepareOpenPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareOpenPageUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareOpenPageUserTask", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "PrepareOpenPageUserTask":
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
			if (TreeGridSelectedRowsIds != null) {
				if (TreeGridSelectedRowsIds.GetType().IsSerializable ||
					TreeGridSelectedRowsIds.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("TreeGridSelectedRowsIds", TreeGridSelectedRowsIds, null);
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
			MetaPathParameterValues.Add("531805de-05d1-4114-8344-f03894234ffe", () => PageInstanceId);
			MetaPathParameterValues.Add("c634e950-a48a-4208-9548-4c4e81207f9b", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("5e34e306-6c0c-4fb6-aedc-71a080389d39", () => TreeGridSelectedRowsIds);
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
				case "TreeGridSelectedRowsIds":
					if (!hasValueToRead) break;
					TreeGridSelectedRowsIds = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareOpenPageUserTaskExecute(ProcessExecutingContext context) {
			var showAdressProcessUId = new Guid("abfbf7ee-e499-45e9-9d22-b9e91a46683d");
			var manager = UserConnection.ProcessSchemaManager;
			var schema =  (ProcessSchema)manager.GetInstanceByUId(showAdressProcessUId);
			var moduleProcess = schema.CreateProcess(UserConnection);
			moduleProcess.SetPropertyValue("PageInstanceId", PageInstanceId);
			moduleProcess.SetPropertyValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId);
			moduleProcess.SetPropertyValue("TreeGridSelectedRowsIds", TreeGridSelectedRowsIds);
			moduleProcess.SetPropertyValue("SchemaName", "Account");
			moduleProcess.SetPropertyValue("RouteMode", false);
			moduleProcess.Execute(UserConnection);
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
			var cloneItem = (ShowAccountAddressOnMapProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.TreeGridSelectedRowsIds = TreeGridSelectedRowsIds;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

