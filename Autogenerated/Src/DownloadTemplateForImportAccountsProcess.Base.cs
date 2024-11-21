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
	using System.IO;
	using System.Text;
	using System.Web;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: DownloadTemplateForImportAccountsProcessSchema

	/// <exclude/>
	public class DownloadTemplateForImportAccountsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public DownloadTemplateForImportAccountsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public DownloadTemplateForImportAccountsProcessSchema(DownloadTemplateForImportAccountsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "DownloadTemplateForImportAccountsProcess";
			UId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9");
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
			RealUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("07ee176b-7bb7-40cf-9ffa-4bf954aeb744"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a6b7b324-3872-4592-919e-2430c72143e7"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("c9b9b229-1262-40a7-a9d6-b0d8be831842"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateFileNameParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet75 = CreateLaneSet75LaneSet();
			LaneSets.Add(schemaLaneSet75);
			ProcessSchemaLane schemaLane191 = CreateLane191Lane();
			schemaLaneSet75.Lanes.Add(schemaLane191);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask downloadtemplatescript = CreateDownloadTemplateScriptScriptTask();
			FlowElements.Add(downloadtemplatescript);
			FlowElements.Add(CreateSequenceFlow596SequenceFlow());
			FlowElements.Add(CreateSequenceFlow597SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow596SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow596",
				UId = new Guid("d2d68bc8-db0b-4c70-bb26-ebb200d0b968"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("c162c2c1-9f48-4ce2-ab1c-3980d1ee14de"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow597SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow597",
				UId = new Guid("831ba719-e6e8-4111-808f-b6c625f03eb5"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("66c84dff-1700-4cbf-96b3-53b790f7ba46"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet75LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet75 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("302a86fe-362f-42ff-8bf5-55db0204deb9"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"LaneSet75",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet75;
		}

		protected virtual ProcessSchemaLane CreateLane191Lane() {
			ProcessSchemaLane schemaLane191 = new ProcessSchemaLane(this) {
				UId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("302a86fe-362f-42ff-8bf5-55db0204deb9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"Lane191",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane191;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("66c84dff-1700-4cbf-96b3-53b790f7ba46"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"Start1",
				Position = new Point(50, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("c162c2c1-9f48-4ce2-ab1c-3980d1ee14de"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"End1",
				Position = new Point(309, 177),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateDownloadTemplateScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("29a3acf2-59d3-4a3e-8b9d-e8e245697256"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"),
				Name = @"DownloadTemplateScript",
				Position = new Point(155, 163),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,82,193,110,218,64,16,61,131,196,63,172,124,90,75,102,101,74,148,52,66,137,84,92,154,86,85,163,180,208,166,18,226,176,198,99,178,149,189,75,119,103,147,88,81,254,189,187,54,148,98,115,175,47,150,61,111,222,123,51,243,30,185,38,32,81,96,53,95,63,64,201,191,112,201,55,160,201,21,249,110,64,39,74,74,88,163,80,146,205,186,160,201,160,255,216,106,119,125,39,216,216,13,224,39,105,144,203,53,76,171,91,94,2,13,62,75,245,84,64,182,129,41,55,240,65,20,16,132,19,210,37,252,106,65,87,142,85,194,19,153,181,255,211,19,90,209,81,59,243,98,161,51,218,48,103,28,121,162,10,91,202,150,209,154,142,189,203,178,166,74,131,247,14,233,28,13,250,93,148,51,139,160,141,71,211,65,191,215,5,36,26,56,66,3,187,23,248,112,199,181,115,225,123,60,190,215,20,18,85,110,185,22,70,201,69,181,5,54,251,109,121,17,145,227,181,4,81,61,183,74,127,185,35,44,87,228,197,127,221,88,145,209,0,178,244,98,148,199,231,195,252,236,60,29,142,206,70,241,16,46,223,198,195,55,241,58,31,199,233,248,114,124,49,14,194,215,240,63,140,224,87,222,113,238,47,236,11,108,161,230,168,133,220,208,157,185,127,79,238,150,95,52,113,59,121,30,151,162,89,11,71,143,83,234,9,69,78,118,185,56,192,88,162,172,68,114,77,226,144,188,184,1,246,89,248,43,115,128,46,227,149,23,154,86,8,230,7,47,44,208,67,104,154,52,17,194,13,73,93,125,185,154,16,247,236,248,52,152,173,146,6,28,231,71,196,173,51,133,240,140,44,177,90,59,13,246,109,87,246,33,239,45,230,174,156,139,141,213,188,182,119,231,146,187,7,176,123,45,16,232,158,46,170,141,70,100,191,192,136,180,155,107,37,137,245,13,126,150,133,127,251,61,188,250,221,106,64,171,37,65,109,97,242,7,136,130,182,226,235,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c08810e2-c3e1-47e0-88ca-79f5af1eda7f"),
				Name = "System.IO",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("24b3f1a0-f90a-4547-a96d-193f8950f726"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("94252392-0a05-490b-b4c9-b710369605d0"),
				Name = "BPMSoft.Configuration",
				Alias = "TSConfiguration",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new DownloadTemplateForImportAccountsProcess(userConnection);
		}

		public override object Clone() {
			return new DownloadTemplateForImportAccountsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9"));
		}

		#endregion

	}

	#endregion

	#region Class: DownloadTemplateForImportAccountsProcess

	/// <exclude/>
	public class DownloadTemplateForImportAccountsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane191

		/// <exclude/>
		public class ProcessLane191 : ProcessLane
		{

			public ProcessLane191(UserConnection userConnection, DownloadTemplateForImportAccountsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public DownloadTemplateForImportAccountsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DownloadTemplateForImportAccountsProcess";
			SchemaUId = new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9");
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
				return new Guid("81479373-d6ab-4d35-bf60-cb695df85ea9");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: DownloadTemplateForImportAccountsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: DownloadTemplateForImportAccountsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private LocalizableString _fileName;
		public virtual LocalizableString FileName {
			get {
				return _fileName ?? (_fileName = GetLocalizableString("81479373d6ab4d35bf60cb695df85ea9",
						 "Parameters.FileName.Value"));
			}
			set {
				_fileName = value;
			}
		}

		private ProcessLane191 _lane191;
		public ProcessLane191 Lane191 {
			get {
				return _lane191 ?? ((_lane191) = new ProcessLane191(UserConnection, this));
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
					SchemaElementUId = new Guid("66c84dff-1700-4cbf-96b3-53b790f7ba46"),
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
					SchemaElementUId = new Guid("c162c2c1-9f48-4ce2-ab1c-3980d1ee14de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _downloadTemplateScript;
		public ProcessScriptTask DownloadTemplateScript {
			get {
				return _downloadTemplateScript ?? (_downloadTemplateScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DownloadTemplateScript",
					SchemaElementUId = new Guid("bbe07d04-17aa-4529-b126-eecd86c61795"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = DownloadTemplateScriptExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[DownloadTemplateScript.SchemaElementUId] = new Collection<ProcessFlowElement> { DownloadTemplateScript };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("DownloadTemplateScript", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "DownloadTemplateScript":
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
			MetaPathParameterValues.Add("07ee176b-7bb7-40cf-9ffa-4bf954aeb744", () => PageInstanceId);
			MetaPathParameterValues.Add("a6b7b324-3872-4592-919e-2430c72143e7", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("c9b9b229-1262-40a7-a9d6-b0d8be831842", () => FileName);
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
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool DownloadTemplateScriptExecute(ProcessExecutingContext context) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName("KnowledgeBaseFile"); 
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			
			var dataColumn = entitySchemaQuery.AddColumn("Data");
			entitySchemaQuery.Filters.Add(
				entitySchemaQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, "KnowledgeBase", new object[] {new Guid("edb71f06-f46b-1410-e980-20cf30b39373")}));
			entitySchemaQuery.Filters.Add(
				entitySchemaQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, "Name", new object[] {FileName.ToString()}));
			
			var entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				var data = entityCollection[0].GetBytesValue(dataColumn.Name)  as byte[];    
				var response = HttpContext.Current.Response; 
				TSConfiguration.PageResponse.Write(response, data, FileName, TSConfiguration.ContentType.XmlType);
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
			var cloneItem = (DownloadTemplateForImportAccountsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

