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
	using BPMSoft.Messaging.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: NotifyOfNewSocialMessagesSchema

	/// <exclude/>
	public class NotifyOfNewSocialMessagesSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public NotifyOfNewSocialMessagesSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public NotifyOfNewSocialMessagesSchema(NotifyOfNewSocialMessagesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "NotifyOfNewSocialMessages";
			UId = new Guid("67f0e555-b418-4344-b749-14a112bd6562");
			CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02");
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
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562");
			Version = 0;
			PackageUId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateAddedSocialMessageIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"AddedSocialMessageId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateAddedSocialMessageIdParameter());
		}

		protected virtual void InitializeStartSignal1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e8c4a37-083e-44ac-b45b-835ea64045a1"),
				ContainerUId = new Guid("398e34ea-ba8c-42ff-a78b-1b2f9308926c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaESNNotificationsLaneSet = CreateESNNotificationsLaneSetLaneSet();
			LaneSets.Add(schemaESNNotificationsLaneSet);
			ProcessSchemaLane schemaPostCommentLane = CreatePostCommentLaneLane();
			schemaESNNotificationsLaneSet.Lanes.Add(schemaPostCommentLane);
			ProcessSchemaTerminateEvent terminateprocess = CreateTerminateProcessTerminateEvent();
			FlowElements.Add(terminateprocess);
			ProcessSchemaScriptTask sendnotificationscripttask = CreateSendNotificationScriptTaskScriptTask();
			FlowElements.Add(sendnotificationscripttask);
			ProcessSchemaStartSignalEvent startsignal1 = CreateStartSignal1StartSignalEvent();
			FlowElements.Add(startsignal1);
			ProcessSchemaFormulaTask formulatask1 = CreateFormulaTask1FormulaTask();
			FlowElements.Add(formulatask1);
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("7850594b-b39d-4a6f-abe8-17e96c27fc2b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				CurveCenterPosition = new Point(825, 242),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				SequenceFlowEndPointPosition = new Point(552, 505),
				SequenceFlowStartPointPosition = new Point(459, 505),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b31e7b6c-362c-41a5-9e34-85da4aeff8e1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("fccae689-a911-4745-b22b-cc9677e324a5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				SequenceFlowEndPointPosition = new Point(215, 505),
				SequenceFlowStartPointPosition = new Point(142, 505),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("398e34ea-ba8c-42ff-a78b-1b2f9308926c"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("91b327fd-ce7b-4c60-a9da-04ea03e1daf5"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("11a6f99b-b2d2-487d-afad-33a98174fc5d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				SequenceFlowEndPointPosition = new Point(390, 505),
				SequenceFlowStartPointPosition = new Point(284, 505),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("91b327fd-ce7b-4c60-a9da-04ea03e1daf5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateESNNotificationsLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaESNNotificationsLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("bbb40bf8-7fa3-4cea-89cf-ea95f81755d8"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"ESNNotificationsLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaESNNotificationsLaneSet;
		}

		protected virtual ProcessSchemaLane CreatePostCommentLaneLane() {
			ProcessSchemaLane schemaPostCommentLane = new ProcessSchemaLane(this) {
				UId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("bbb40bf8-7fa3-4cea-89cf-ea95f81755d8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"PostCommentLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaPostCommentLane;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateProcessTerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("b31e7b6c-362c-41a5-9e34-85da4aeff8e1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"TerminateProcess",
				Position = new Point(552, 491),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSendNotificationScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"SendNotificationScriptTask",
				Position = new Point(390, 477),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,142,193,10,194,48,12,134,207,14,246,14,101,167,14,100,47,48,21,230,64,241,224,46,226,3,132,54,142,194,150,66,154,58,246,246,118,222,138,158,66,254,159,47,249,222,192,138,188,184,151,51,32,206,83,207,8,226,89,29,85,63,65,8,23,48,105,91,155,43,202,97,192,229,225,141,131,233,142,33,192,136,195,47,118,210,101,177,35,92,84,239,41,8,199,13,238,120,140,51,146,232,42,6,228,84,16,154,13,169,246,234,153,5,117,221,150,197,31,151,230,59,179,119,231,53,51,209,157,181,104,179,232,102,183,107,140,18,153,84,50,193,246,3,172,209,120,21,234,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateStartSignal1StartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("398e34ea-ba8c-42ff-a78b-1b2f9308926c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				EntitySchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"StartSignal1",
				NewEntityChangedColumns = false,
				Position = new Point(111, 489),
				SerializeToDB = false,
				Size = new Size(31, 31),
				UseBackgroundMode = true,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeStartSignal1Parameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateFormulaTask1FormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("91b327fd-ce7b-4c60-a9da-04ea03e1daf5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("5a387dbb-63f2-4c09-9a38-d1ce176371c6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("90ef497e-6e18-440d-b80e-d28f2f133509"),
				CreatedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562"),
				Name = @"FormulaTask1",
				Position = new Point(215, 477),
				ResultParameterMetaPath = @"f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,161,14,131,48,16,6,224,135,65,223,82,218,43,92,241,19,168,45,153,36,21,215,230,111,38,40,162,144,76,44,188,251,208,179,95,242,45,221,50,239,143,207,134,246,202,111,84,157,138,174,59,226,237,210,63,184,175,168,216,142,233,235,130,192,49,148,146,74,38,182,165,144,142,146,168,79,182,4,103,36,216,33,159,87,120,106,211,138,3,237,42,144,204,234,70,50,226,64,204,154,41,177,79,36,206,67,7,54,236,181,63,99,23,127,204,28,215,166,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ed792714-f7cc-4d65-861b-bf1701dd5157"),
				Name = "BPMSoft.Messaging.Common",
				Alias = "",
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("09668c8e-1e00-4d2a-a040-35cd7a7045d1"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("257f42e9-08c7-402e-8ccc-800826314b17"),
				Name = "Newtonsoft.Json",
				Alias = "",
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("22aaf901-be11-4228-b8c4-b254129c86d7"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("49b81747-4cc7-4572-80bc-6d30780bab02")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new NotifyOfNewSocialMessages(userConnection);
		}

		public override object Clone() {
			return new NotifyOfNewSocialMessagesSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("67f0e555-b418-4344-b749-14a112bd6562"));
		}

		#endregion

	}

	#endregion

	#region Class: NotifyOfNewSocialMessages

	/// <exclude/>
	public class NotifyOfNewSocialMessages : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessPostCommentLane

		/// <exclude/>
		public class ProcessPostCommentLane : ProcessLane
		{

			public ProcessPostCommentLane(UserConnection userConnection, NotifyOfNewSocialMessages process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public NotifyOfNewSocialMessages(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NotifyOfNewSocialMessages";
			SchemaUId = new Guid("67f0e555-b418-4344-b749-14a112bd6562");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("67f0e555-b418-4344-b749-14a112bd6562");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: NotifyOfNewSocialMessages, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: NotifyOfNewSocialMessages, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Guid AddedSocialMessageId {
			get;
			set;
		}

		private ProcessPostCommentLane _postCommentLane;
		public ProcessPostCommentLane PostCommentLane {
			get {
				return _postCommentLane ?? ((_postCommentLane) = new ProcessPostCommentLane(UserConnection, this));
			}
		}

		private ProcessTerminateEvent _terminateProcess;
		public ProcessTerminateEvent TerminateProcess {
			get {
				return _terminateProcess ?? (_terminateProcess = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateProcess",
					SchemaElementUId = new Guid("b31e7b6c-362c-41a5-9e34-85da4aeff8e1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _sendNotificationScriptTask;
		public ProcessScriptTask SendNotificationScriptTask {
			get {
				return _sendNotificationScriptTask ?? (_sendNotificationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendNotificationScriptTask",
					SchemaElementUId = new Guid("32d0ae3e-a939-4d47-95b8-8a0fefbe6a8c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SendNotificationScriptTaskExecute,
				});
			}
		}

		private ProcessStartSignalEvent _startSignal1;
		public ProcessStartSignalEvent StartSignal1 {
			get {
				return _startSignal1 ?? (_startSignal1 = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "StartSignal1",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("398e34ea-ba8c-42ff-a78b-1b2f9308926c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _formulaTask1;
		public ProcessScriptTask FormulaTask1 {
			get {
				return _formulaTask1 ?? (_formulaTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "FormulaTask1",
					SchemaElementUId = new Guid("91b327fd-ce7b-4c60-a9da-04ea03e1daf5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = FormulaTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[TerminateProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateProcess };
			FlowElements[SendNotificationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SendNotificationScriptTask };
			FlowElements[StartSignal1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSignal1 };
			FlowElements[FormulaTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { FormulaTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "TerminateProcess":
						CompleteProcess();
						break;
					case "SendNotificationScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateProcess", e.Context.SenderName));
						break;
					case "StartSignal1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("FormulaTask1", e.Context.SenderName));
						break;
					case "FormulaTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SendNotificationScriptTask", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("AddedSocialMessageId")) {
				writer.WriteValue("AddedSocialMessageId", AddedSocialMessageId, Guid.Empty);
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
			MetaPathParameterValues.Add("f0a3cf6a-71c5-4eef-add2-9dfe3c7b24a4", () => AddedSocialMessageId);
			MetaPathParameterValues.Add("3e8c4a37-083e-44ac-b45b-835ea64045a1", () => StartSignal1.RecordId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "AddedSocialMessageId":
					if (!hasValueToRead) break;
					AddedSocialMessageId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SendNotificationScriptTaskExecute(ProcessExecutingContext context) {
			var notificationCreator = ClassFactory.Get<NewSocialMessageNotificationCreator>(
				new ConstructorArgument("userConnection", UserConnection));
			notificationCreator.CreateNotificationBySocialMessage(AddedSocialMessageId);
			return true;
		}

		public virtual bool FormulaTask1Execute(ProcessExecutingContext context) {
			var localAddedSocialMessageId = (StartSignal1.RecordId);
			AddedSocialMessageId = (System.Guid)localAddedSocialMessageId;
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
			var cloneItem = (NotifyOfNewSocialMessages)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

