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

	#region Class: SendEmailToContactProcessSchema

	/// <exclude/>
	public class SendEmailToContactProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SendEmailToContactProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SendEmailToContactProcessSchema(SendEmailToContactProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SendEmailToContactProcess";
			UId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2803";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
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
			RealUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateUseEmailParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("efca843f-447f-4525-b3f2-c7655939e677"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"UseEmail",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActivityIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("cf6e38de-27f0-4fda-b4e1-fe0e1627d1a2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"ActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMessagePanelParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0ee78034-e7d3-40a2-b5df-24c17844aa6c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"MessagePanel",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSendEmailStatusParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a6fb0596-3655-4a42-adac-da90d4e61305"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"SendEmailStatus",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateUseEmailParameter());
			Parameters.Add(CreateActivityIdParameter());
			Parameters.Add(CreateMessagePanelParameter());
			Parameters.Add(CreateSendEmailStatusParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet58 = CreateLaneSet58LaneSet();
			LaneSets.Add(schemaLaneSet58);
			ProcessSchemaLane schemaLane162 = CreateLane162Lane();
			schemaLaneSet58.Lanes.Add(schemaLane162);
			ProcessSchemaEventSubProcess sendemaileventsubprocess = CreateSendEmailEventSubProcessEventSubProcess();
			FlowElements.Add(sendemaileventsubprocess);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaIntermediateThrowMessageEvent sendemailintermediatethrowmessageevent = CreateSendEmailIntermediateThrowMessageEventIntermediateThrowMessageEvent();
			FlowElements.Add(sendemailintermediatethrowmessageevent);
			ProcessSchemaStartMessageEvent sendemailstartmessage = CreateSendEmailStartMessageStartMessageEvent();
			sendemaileventsubprocess.FlowElements.Add(sendemailstartmessage);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			sendemaileventsubprocess.FlowElements.Add(end1);
			FlowElements.Add(CreateSequenceFlow507SequenceFlow());
			FlowElements.Add(CreateSequenceFlow514SequenceFlow());
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateConfirmSendingEmailMessageLocalizableString());
			LocalizableStrings.Add(CreateWarningMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateConfirmSendingEmailMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e045168c-2638-4ae8-9a96-e91d2b601b86"),
				Name = "ConfirmSendingEmailMessage",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWarningMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ce8909c9-af55-45cd-8669-481f5b1bd11c"),
				Name = "WarningMessage",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2")
			};
			return localizableString;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow507SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow507",
				UId = new Guid("679cb9a1-3402-4d10-9a65-01d1ca75178e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				CurveCenterPosition = new Point(156, 78),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0a273e70-68fd-4eea-ab4e-001ef7f2b80b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("06d86512-8024-45a7-8c47-97339c880a62"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow514SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow514",
				UId = new Guid("f303cf14-be9c-415a-a338-688f7f49b879"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				CurveCenterPosition = new Point(174, 328),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0c66485c-8b03-4dcc-837c-2cc24acc41cd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("492b3d8b-2def-42d8-9434-cdd1c6af8954"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet58LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet58 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("b9ccb01d-a501-4769-94ad-eb12e749fd0b"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"LaneSet58",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(5, 5),
				Size = new Size(710, 416),
				UseBackgroundMode = false
			};
			return schemaLaneSet58;
		}

		protected virtual ProcessSchemaLane CreateLane162Lane() {
			ProcessSchemaLane schemaLane162 = new ProcessSchemaLane(this) {
				UId = new Guid("dbae19cb-4797-46a7-8d5e-7849ed4640f5"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("b9ccb01d-a501-4769-94ad-eb12e749fd0b"),
				CreatedInOwnerSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"Lane162",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(29, 0),
				Size = new Size(681, 416),
				UseBackgroundMode = false
			};
			return schemaLane162;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("0a273e70-68fd-4eea-ab4e-001ef7f2b80b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("dbae19cb-4797-46a7-8d5e-7849ed4640f5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"Start1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(71, 156),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaIntermediateThrowMessageEvent CreateSendEmailIntermediateThrowMessageEventIntermediateThrowMessageEvent() {
			ProcessSchemaIntermediateThrowMessageEvent schemaThrowMessageEvent = new ProcessSchemaIntermediateThrowMessageEvent(this) {
				UId = new Guid("06d86512-8024-45a7-8c47-97339c880a62"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("dbae19cb-4797-46a7-8d5e-7849ed4640f5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsLogging = false,
				ManagerItemUId = new Guid("7b8b16fb-d4c6-4e8b-a519-988250ac636f"),
				Message = @"SendEmail",
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"SendEmailIntermediateThrowMessageEvent",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(232, 156),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaThrowMessageEvent;
		}

		protected virtual ProcessSchemaEventSubProcess CreateSendEmailEventSubProcessEventSubProcess() {
			ProcessSchemaEventSubProcess schemaSendEmailEventSubProcess = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("99a7ffc0-15a2-4735-b829-1f74c756cdba"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("dbae19cb-4797-46a7-8d5e-7849ed4640f5"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"SendEmailEventSubProcess",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(43, 240),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(602, 156),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaSendEmailEventSubProcess;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateSendEmailStartMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("0c66485c-8b03-4dcc-837c-2cc24acc41cd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("99a7ffc0-15a2-4735-b829-1f74c756cdba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"SendEmail",
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"SendEmailStartMessage",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(21, 63),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("492b3d8b-2def-42d8-9434-cdd1c6af8954"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("99a7ffc0-15a2-4735-b829-1f74c756cdba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"),
				Name = @"End1",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(560, 63),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("90483fe1-0df5-4f67-b023-37b4988f946b"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SendEmailToContactProcess(userConnection);
		}

		public override object Clone() {
			return new SendEmailToContactProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2"));
		}

		#endregion

	}

	#endregion

	#region Class: SendEmailToContactProcess

	/// <exclude/>
	public class SendEmailToContactProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane162

		/// <exclude/>
		public class ProcessLane162 : ProcessLane
		{

			public ProcessLane162(UserConnection userConnection, SendEmailToContactProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SendEmailToContactProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendEmailToContactProcess";
			SchemaUId = new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("44589e2b-11fc-4e7e-b97f-9bd6d8f1dbd2");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SendEmailToContactProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SendEmailToContactProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual bool UseEmail {
			get;
			set;
		}

		public virtual Guid ActivityId {
			get;
			set;
		}

		public virtual Object MessagePanel {
			get;
			set;
		}

		public virtual string SendEmailStatus {
			get;
			set;
		}

		private ProcessLane162 _lane162;
		public ProcessLane162 Lane162 {
			get {
				return _lane162 ?? ((_lane162) = new ProcessLane162(UserConnection, this));
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
					SchemaElementUId = new Guid("0a273e70-68fd-4eea-ab4e-001ef7f2b80b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sendEmailIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SendEmailIntermediateThrowMessageEvent {
			get {
				return _sendEmailIntermediateThrowMessageEvent ?? (_sendEmailIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SendEmailIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("06d86512-8024-45a7-8c47-97339c880a62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SendEmail",
				});
			}
		}

		private ProcessFlowElement _sendEmailEventSubProcess;
		public ProcessFlowElement SendEmailEventSubProcess {
			get {
				return _sendEmailEventSubProcess ?? (_sendEmailEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SendEmailEventSubProcess",
					SchemaElementUId = new Guid("99a7ffc0-15a2-4735-b829-1f74c756cdba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sendEmailStartMessage;
		public ProcessFlowElement SendEmailStartMessage {
			get {
				return _sendEmailStartMessage ?? (_sendEmailStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SendEmailStartMessage",
					SchemaElementUId = new Guid("0c66485c-8b03-4dcc-837c-2cc24acc41cd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("492b3d8b-2def-42d8-9434-cdd1c6af8954"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private LocalizableString _confirmSendingEmailMessage;
		public LocalizableString ConfirmSendingEmailMessage {
			get {
				return _confirmSendingEmailMessage ?? (_confirmSendingEmailMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.ConfirmSendingEmailMessage.Value"));
			}
		}

		private LocalizableString _warningMessage;
		public LocalizableString WarningMessage {
			get {
				return _warningMessage ?? (_warningMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.WarningMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[SendEmailIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailIntermediateThrowMessageEvent };
			FlowElements[SendEmailEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailEventSubProcess };
			FlowElements[SendEmailStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SendEmailStartMessage };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailIntermediateThrowMessageEvent", e.Context.SenderName));
						break;
					case "SendEmailIntermediateThrowMessageEvent":
						break;
					case "SendEmailEventSubProcess":
						break;
					case "SendEmailStartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("UseEmail")) {
				writer.WriteValue("UseEmail", UseEmail, false);
			}
			if (!HasMapping("ActivityId")) {
				writer.WriteValue("ActivityId", ActivityId, Guid.Empty);
			}
			if (!HasMapping("SendEmailStatus")) {
				writer.WriteValue("SendEmailStatus", SendEmailStatus, null);
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
			ActivatedEventElements.Add("SendEmailStartMessage");
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
			MetaPathParameterValues.Add("efca843f-447f-4525-b3f2-c7655939e677", () => UseEmail);
			MetaPathParameterValues.Add("cf6e38de-27f0-4fda-b4e1-fe0e1627d1a2", () => ActivityId);
			MetaPathParameterValues.Add("0ee78034-e7d3-40a2-b5df-24c17844aa6c", () => MessagePanel);
			MetaPathParameterValues.Add("a6fb0596-3655-4a42-adac-da90d4e61305", () => SendEmailStatus);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "UseEmail":
					if (!hasValueToRead) break;
					UseEmail = reader.GetValue<System.Boolean>();
				break;
				case "ActivityId":
					if (!hasValueToRead) break;
					ActivityId = reader.GetValue<System.Guid>();
				break;
				case "SendEmailStatus":
					if (!hasValueToRead) break;
					SendEmailStatus = reader.GetValue<System.String>();
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
			switch(message) {
					case "SendEmail":
							if (ActivatedEventElements.Contains("SendEmailStartMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendEmailStartMessage", "SendEmailStartMessage"));
						}
						break;
			}
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
			var cloneItem = (SendEmailToContactProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.MessagePanel = MessagePanel;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

