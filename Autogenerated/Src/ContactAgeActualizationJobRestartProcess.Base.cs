namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Scheduler;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Quartz.Impl.Triggers;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ContactAgeActualizationJobRestartProcessSchema

	/// <exclude/>
	public class ContactAgeActualizationJobRestartProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ContactAgeActualizationJobRestartProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ContactAgeActualizationJobRestartProcessSchema(ContactAgeActualizationJobRestartProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ContactAgeActualizationJobRestartProcess";
			UId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84");
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
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,75,79,2,49,16,62,179,191,162,217,19,24,210,224,217,87,112,137,136,9,132,176,62,206,165,12,107,117,183,221,76,91,136,18,254,187,211,69,148,213,149,131,151,38,157,153,175,243,61,90,250,121,174,36,91,25,181,96,51,40,204,10,250,25,244,165,243,34,87,239,194,41,163,239,204,188,221,97,155,168,213,47,203,84,62,195,194,231,128,124,55,27,122,113,98,180,19,210,53,224,226,46,139,27,202,67,52,190,140,59,103,209,54,138,202,131,253,251,215,39,176,110,34,241,96,1,105,151,6,25,42,204,215,174,21,195,149,64,38,14,97,247,170,0,118,193,174,167,227,212,44,29,79,12,2,29,122,169,50,143,213,0,79,223,108,10,206,41,157,89,62,4,247,40,114,15,231,3,225,32,64,47,219,81,171,85,223,19,20,121,103,10,66,203,159,36,3,132,36,239,209,124,172,116,245,30,41,109,237,200,189,152,249,0,156,80,57,145,170,217,153,32,16,106,138,70,130,181,65,44,45,62,106,108,232,255,105,109,247,8,122,230,73,10,126,110,170,38,235,2,249,147,193,87,91,10,9,124,34,10,104,24,72,60,34,104,23,226,168,70,130,188,32,78,34,89,128,42,203,0,73,158,134,53,75,190,43,163,162,204,255,253,85,2,9,235,144,66,226,55,6,201,251,118,220,99,155,222,150,109,78,183,236,138,157,176,19,130,255,10,62,248,239,29,52,117,110,141,199,78,224,93,11,97,164,173,19,154,132,239,75,33,136,175,200,186,135,2,171,207,251,1,117,103,204,33,60,3,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = true;
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask removeoldjobscripttask = CreateRemoveOldJobScriptTaskScriptTask();
			FlowElements.Add(removeoldjobscripttask);
			ProcessSchemaScriptTask schedulenewjobscripttask = CreateScheduleNewJobScriptTaskScriptTask();
			FlowElements.Add(schedulenewjobscripttask);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("9feded6c-1ad9-4fc8-ad68-ab26829b95ca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5a8cd4ba-de14-4b74-a9a8-4e3749e90577"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c12367c3-452d-4949-bec2-3e771ef47b90"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0c19837c-e427-4b2c-95f0-8539375a7de3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("a59cfb8b-9d1f-478c-a486-241344290bf6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("0a579010-5a4b-4f8b-919a-a841aa7c77c5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0a579010-5a4b-4f8b-919a-a841aa7c77c5"),
				CreatedInOwnerSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("5a8cd4ba-de14-4b74-a9a8-4e3749e90577"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"TerminateEvent1",
				Position = new Point(518, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateRemoveOldJobScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"RemoveOldJobScriptTask",
				Position = new Point(220, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,74,205,205,47,75,117,76,79,117,76,46,41,77,204,201,172,74,44,201,204,207,243,202,79,210,208,180,230,42,74,45,41,45,202,83,40,41,42,77,181,230,2,0,113,236,245,29,42,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScheduleNewJobScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("524f976c-dc16-4613-afcd-8360daff9aa0"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"ScheduleNewJobScriptTask",
				Position = new Point(369, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,75,44,82,40,45,78,45,114,206,207,203,75,77,46,201,204,207,83,176,85,112,79,45,177,9,69,17,180,211,80,66,21,80,210,180,230,10,78,206,72,77,41,205,73,245,75,45,119,76,79,117,76,46,41,77,204,201,172,74,4,73,123,229,39,105,160,26,11,84,95,148,90,82,90,148,167,80,82,84,154,106,205,5,0,40,222,232,212,121,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("0c19837c-e427-4b2c-95f0-8539375a7de3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("7ce62765-1da7-4255-8d55-60a3aeab2b20"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("0f1116a2-88a9-4a2c-b333-bb375de9976f"),
				CreatedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"),
				Name = @"StartEvent1",
				Position = new Point(113, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("abd4bd9a-9cb7-4e0c-9340-f09d961bbeff"),
				Name = "BPMSoft.Core.Scheduler",
				Alias = "",
				CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d84579bc-b5ea-4f20-94c5-78667e4e4699"),
				Name = "Quartz.Impl.Triggers",
				Alias = "",
				CreatedInPackageId = new Guid("42c464a9-9677-4bbd-86c1-308caea3de84")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ContactAgeActualizationJobRestartProcess(userConnection);
		}

		public override object Clone() {
			return new ContactAgeActualizationJobRestartProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactAgeActualizationJobRestartProcessMethodsWrapper

	/// <exclude/>
	public class ContactAgeActualizationJobRestartProcessMethodsWrapper : ProcessModel
	{

		public ContactAgeActualizationJobRestartProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("RemoveOldJobScriptTaskExecute", RemoveOldJobScriptTaskExecute);
			AddScriptTaskMethod("ScheduleNewJobScriptTaskExecute", ScheduleNewJobScriptTaskExecute);
		}

		#region Methods: Private

		private bool RemoveOldJobScriptTaskExecute(ProcessExecutingContext context) {
			RemoveAgeActualizationJob();
			return true;
		}

		private bool ScheduleNewJobScriptTaskExecute(ProcessExecutingContext context) {
			var userConnection = Get<UserConnection>("UserConnection");
			ScheduleNewAgeActualizationJob(userConnection);
			return true;
		}

			public void RemoveAgeActualizationJob() {
				AppScheduler.RemoveJob("ContactAgeActualizationJob", "AgeActualizationJobGroup");
			}
			
			public void ScheduleNewAgeActualizationJob(UserConnection userConnection) {
				var actualizationTime = BPMSoft.Core.Configuration.SysSettings.GetValue<DateTime>(
					userConnection, "AutomaticAgeActualizationTime", DateTime.MinValue);
				
				var jobDetail = AppScheduler.CreateProcessJob(
					"ContactAgeActualizationJob",
					"AgeActualizationJobGroup",
					"ContactAgeActualizationRunnerProcess",
					userConnection.Workspace.Name,
					userConnection.CurrentUser.Name);
				var cronTrigger = new CronTriggerImpl("ContactAgeActualizationJob", "AgeActualizationJobGroup",
					string.Format("0 {0} {1} ? * *", actualizationTime.Minute, actualizationTime.Hour));
				AppScheduler.Instance.ScheduleJob(jobDetail, cronTrigger);
			}

		#endregion

	}

	#endregion

	#region Class: ContactAgeActualizationJobRestartProcess

	/// <exclude/>
	public class ContactAgeActualizationJobRestartProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ContactAgeActualizationJobRestartProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ContactAgeActualizationJobRestartProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactAgeActualizationJobRestartProcess";
			SchemaUId = new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = true;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			ProcessModel = new ContactAgeActualizationJobRestartProcessMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eef8c5e7-6f65-472e-9dff-b6f9abc54191");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ContactAgeActualizationJobRestartProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ContactAgeActualizationJobRestartProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("5a8cd4ba-de14-4b74-a9a8-4e3749e90577"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _removeOldJobScriptTask;
		public ProcessScriptTask RemoveOldJobScriptTask {
			get {
				return _removeOldJobScriptTask ?? (_removeOldJobScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemoveOldJobScriptTask",
					SchemaElementUId = new Guid("226ed5c6-81db-464a-a5cc-9ad05b8f46f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("RemoveOldJobScriptTaskExecute"),
				});
			}
		}

		private ProcessScriptTask _scheduleNewJobScriptTask;
		public ProcessScriptTask ScheduleNewJobScriptTask {
			get {
				return _scheduleNewJobScriptTask ?? (_scheduleNewJobScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScheduleNewJobScriptTask",
					SchemaElementUId = new Guid("9b477604-e16a-4138-babf-dc4d45021576"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScheduleNewJobScriptTaskExecute"),
				});
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
					SchemaElementUId = new Guid("0c19837c-e427-4b2c-95f0-8539375a7de3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[RemoveOldJobScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { RemoveOldJobScriptTask };
			FlowElements[ScheduleNewJobScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ScheduleNewJobScriptTask };
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "RemoveOldJobScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScheduleNewJobScriptTask", e.Context.SenderName));
						break;
					case "ScheduleNewJobScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RemoveOldJobScriptTask", e.Context.SenderName));
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
			var cloneItem = (ContactAgeActualizationJobRestartProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

