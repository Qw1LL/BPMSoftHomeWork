namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Social;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: FindUsersInSocialNetworksSchema

	/// <exclude/>
	public class FindUsersInSocialNetworksSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FindUsersInSocialNetworksSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FindUsersInSocialNetworksSchema(FindUsersInSocialNetworksSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FindUsersInSocialNetworks";
			UId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"1.0.0.2803";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			Version = 0;
			PackageUId = new Guid("a7d9c356-450c-46d7-bc85-72dca4e280ba");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSearchCriteriaParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d2eee179-ad16-455d-8147-63165813c33a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SearchCriteria",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1418805c-fd9b-4e83-9dfb-3e550995e3e5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SocialNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7adb7cd7-6067-43c1-8295-c7f3eac4a985"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Out,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SearchResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateExceptionNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6c00e48-9350-4fc2-b412-ec33613180d4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"ExceptionNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccessTokenExceptionNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6450af3-54ad-4fd0-93ab-2a819e0601d6"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"AccessTokenExceptionNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSearchCriteriaParameter());
			Parameters.Add(CreateSocialNetworksParameter());
			Parameters.Add(CreateSearchResultParameter());
			Parameters.Add(CreateExceptionNetworksParameter());
			Parameters.Add(CreateAccessTokenExceptionNetworksParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startsearchsocialusersmessage = CreateStartSearchSocialUsersMessageStartEvent();
			FlowElements.Add(startsearchsocialusersmessage);
			ProcessSchemaEndEvent endsearchsocialusersmessage = CreateEndSearchSocialUsersMessageEndEvent();
			FlowElements.Add(endsearchsocialusersmessage);
			ProcessSchemaScriptTask searchsocialusersscripttask = CreateSearchSocialUsersScriptTaskScriptTask();
			FlowElements.Add(searchsocialusersscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("9cf9158a-a7a7-4386-9591-2c3988b13e58"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b2ad761d-b8d0-4e79-9cda-3ad4bbe8ea49"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("fa6dfbb8-7b2c-49c0-9874-fa36ddd43aa1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4c86d02b-fcb8-49f2-9c13-38f0a0574809"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("4df67273-36a7-4d16-8308-63da81a4189f"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(513, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("4df67273-36a7-4d16-8308-63da81a4189f"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(484, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartSearchSocialUsersMessageStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("b2ad761d-b8d0-4e79-9cda-3ad4bbe8ea49"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"StartSearchSocialUsersMessage",
				Position = new Point(141, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEndSearchSocialUsersMessageEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("4c86d02b-fcb8-49f2-9c13-38f0a0574809"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"EndSearchSocialUsersMessage",
				Position = new Point(442, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSearchSocialUsersScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("24844802-3984-48cd-a11e-d042fed29ec6"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f"),
				CreatedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"),
				Name = @"SearchSocialUsersScriptTask",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(239, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,77,79,2,49,16,61,67,194,127,24,189,80,226,102,163,30,53,28,8,129,4,15,96,68,127,64,45,131,86,187,45,153,118,69,93,247,191,219,178,11,82,20,228,212,100,230,245,189,55,95,114,14,204,58,146,250,41,29,217,113,174,212,132,6,217,194,125,176,41,114,18,207,125,146,14,73,242,78,7,138,86,179,65,232,114,210,224,40,199,235,86,179,108,53,167,70,72,174,198,232,150,134,94,65,215,111,23,162,120,218,83,202,195,229,156,157,252,45,181,13,182,181,212,15,87,156,239,12,116,158,165,183,156,44,50,247,177,64,51,223,201,39,177,184,77,86,118,59,149,223,55,78,32,76,150,229,142,59,67,158,92,227,178,198,247,55,97,246,96,145,250,70,107,20,78,26,157,172,235,10,28,131,119,129,139,16,93,211,255,42,118,108,116,104,78,79,8,180,246,222,188,162,62,250,207,143,179,116,243,103,34,68,78,132,51,56,235,194,12,21,62,113,135,108,180,211,247,4,54,120,192,170,127,210,15,22,65,90,136,140,44,164,167,170,0,141,127,28,238,180,245,32,250,43,104,241,63,181,210,136,198,23,217,40,1,149,245,214,214,6,35,192,134,187,54,121,132,179,253,118,246,48,239,181,180,82,116,207,100,150,16,198,209,240,11,83,94,87,75,147,251,149,8,218,55,214,104,191,26,111,72,46,157,134,203,80,242,19,39,143,47,126,85,216,214,248,134,82,207,194,22,217,95,119,228,249,170,208,29,218,92,57,79,89,223,196,208,80,198,29,59,45,138,149,214,21,20,231,101,2,124,187,163,235,2,175,218,197,69,217,78,0,223,227,194,125,252,178,108,151,229,105,82,249,77,226,129,236,180,41,189,55,211,149,52,243,55,115,40,27,60,199,151,255,13,173,126,63,242,54,4,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3853e2c8-0670-4b9e-a285-37e84b65b4b1"),
				Name = "BPMSoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("fbf2b1fd-1ae8-4544-8b6d-968bafccf538"),
				Name = "Newtonsoft.Json",
				Alias = "",
				CreatedInPackageId = new Guid("7f924b56-df05-4eb1-9ff1-3618e0fcf55f")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FindUsersInSocialNetworks(userConnection);
		}

		public override object Clone() {
			return new FindUsersInSocialNetworksSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc"));
		}

		#endregion

	}

	#endregion

	#region Class: FindUsersInSocialNetworks

	/// <exclude/>
	public class FindUsersInSocialNetworks : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, FindUsersInSocialNetworks process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public FindUsersInSocialNetworks(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FindUsersInSocialNetworks";
			SchemaUId = new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6ba7daa7-8f3a-4201-9308-97774cd319fc");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FindUsersInSocialNetworks, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FindUsersInSocialNetworks, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string SearchCriteria {
			get;
			set;
		}

		public virtual string SocialNetworks {
			get;
			set;
		}

		public virtual string SearchResult {
			get;
			set;
		}

		public virtual Object ExceptionNetworks {
			get;
			set;
		}

		public virtual Object AccessTokenExceptionNetworks {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
			}
		}

		private ProcessFlowElement _startSearchSocialUsersMessage;
		public ProcessFlowElement StartSearchSocialUsersMessage {
			get {
				return _startSearchSocialUsersMessage ?? (_startSearchSocialUsersMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartSearchSocialUsersMessage",
					SchemaElementUId = new Guid("b2ad761d-b8d0-4e79-9cda-3ad4bbe8ea49"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessEndEvent _endSearchSocialUsersMessage;
		public ProcessEndEvent EndSearchSocialUsersMessage {
			get {
				return _endSearchSocialUsersMessage ?? (_endSearchSocialUsersMessage = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "EndSearchSocialUsersMessage",
					SchemaElementUId = new Guid("4c86d02b-fcb8-49f2-9c13-38f0a0574809"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _searchSocialUsersScriptTask;
		public ProcessScriptTask SearchSocialUsersScriptTask {
			get {
				return _searchSocialUsersScriptTask ?? (_searchSocialUsersScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SearchSocialUsersScriptTask",
					SchemaElementUId = new Guid("ecd6952e-cb98-4f10-ad26-adf801c905b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = SearchSocialUsersScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartSearchSocialUsersMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { StartSearchSocialUsersMessage };
			FlowElements[EndSearchSocialUsersMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EndSearchSocialUsersMessage };
			FlowElements[SearchSocialUsersScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SearchSocialUsersScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartSearchSocialUsersMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SearchSocialUsersScriptTask", e.Context.SenderName));
						break;
					case "EndSearchSocialUsersMessage":
						CompleteProcess();
						break;
					case "SearchSocialUsersScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EndSearchSocialUsersMessage", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SearchCriteria")) {
				writer.WriteValue("SearchCriteria", SearchCriteria, null);
			}
			if (!HasMapping("SocialNetworks")) {
				writer.WriteValue("SocialNetworks", SocialNetworks, null);
			}
			if (!HasMapping("SearchResult")) {
				writer.WriteValue("SearchResult", SearchResult, null);
			}
			if (ExceptionNetworks != null) {
				if (ExceptionNetworks.GetType().IsSerializable ||
					ExceptionNetworks.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ExceptionNetworks", ExceptionNetworks, null);
				}
			}
			if (AccessTokenExceptionNetworks != null) {
				if (AccessTokenExceptionNetworks.GetType().IsSerializable ||
					AccessTokenExceptionNetworks.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("AccessTokenExceptionNetworks", AccessTokenExceptionNetworks, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartSearchSocialUsersMessage", string.Empty));
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
			MetaPathParameterValues.Add("d2eee179-ad16-455d-8147-63165813c33a", () => SearchCriteria);
			MetaPathParameterValues.Add("1418805c-fd9b-4e83-9dfb-3e550995e3e5", () => SocialNetworks);
			MetaPathParameterValues.Add("7adb7cd7-6067-43c1-8295-c7f3eac4a985", () => SearchResult);
			MetaPathParameterValues.Add("e6c00e48-9350-4fc2-b412-ec33613180d4", () => ExceptionNetworks);
			MetaPathParameterValues.Add("e6450af3-54ad-4fd0-93ab-2a819e0601d6", () => AccessTokenExceptionNetworks);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SearchCriteria":
					if (!hasValueToRead) break;
					SearchCriteria = reader.GetValue<System.String>();
				break;
				case "SocialNetworks":
					if (!hasValueToRead) break;
					SocialNetworks = reader.GetValue<System.String>();
				break;
				case "SearchResult":
					if (!hasValueToRead) break;
					SearchResult = reader.GetValue<System.String>();
				break;
				case "ExceptionNetworks":
					if (!hasValueToRead) break;
					ExceptionNetworks = reader.GetSerializableObjectValue();
				break;
				case "AccessTokenExceptionNetworks":
					if (!hasValueToRead) break;
					AccessTokenExceptionNetworks = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool SearchSocialUsersScriptTaskExecute(ProcessExecutingContext context) {
			if (string.IsNullOrEmpty(SearchCriteria)) {
				return true;
			}
			SocialNetwork network = SocialNetwork.All;
			if(!string.IsNullOrEmpty(SocialNetworks)) {
				network = (SocialNetwork)Enum.Parse(typeof(SocialNetwork), SocialNetworks, true);
			}
			var commutator = new SocialCommutator(UserConnection, network);
			ExceptionNetworks = SocialNetwork.None;
			AccessTokenExceptionNetworks = SocialNetwork.None;
			commutator.ExceptionOccurred += delegate(ISocialNetwork n, Exception e) {
				if (e is AccessTokenExpired) {
					AccessTokenExceptionNetworks = (SocialNetwork)AccessTokenExceptionNetworks | (e as AccessTokenExpired).SocialNetwork;
				} else if (e is SocialNetworkException) {
					ExceptionNetworks = (SocialNetwork)ExceptionNetworks | (e as SocialNetworkException).SocialNetwork;
				} else {
					throw e;
				}
			};
			var users = JsonConvert.SerializeObject(commutator.FindUsers(SearchCriteria));
			SearchResult = string.Format("{{users: {0}, accessTokenExNetworks:'{1}', exeptionNetworks:'{2}'}}", users, AccessTokenExceptionNetworks.ToString(), ExceptionNetworks.ToString());
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
			var cloneItem = (FindUsersInSocialNetworks)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.ExceptionNetworks = ExceptionNetworks;
			cloneItem.AccessTokenExceptionNetworks = AccessTokenExceptionNetworks;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

