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

	#region Class: DownloadTemplateForImportProductsProcessSchema

	/// <exclude/>
	public class DownloadTemplateForImportProductsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public DownloadTemplateForImportProductsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public DownloadTemplateForImportProductsProcessSchema(DownloadTemplateForImportProductsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "DownloadTemplateForImportProductsProcess";
			UId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882");
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
			RealUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88b7ad1c-6588-423a-8941-0a507b54d72d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3e60d7c4-bc8b-4d82-b662-1da181b31d7a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTreeGridSelectedRowsIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6369036e-4ff6-4179-8e04-be2aa3fd2dc5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"TreeGridSelectedRowsIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateFileNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5b17a5a5-16f5-421f-b4f9-b424418475d9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"FileName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateTreeGridSelectedRowsIdsParameter());
			Parameters.Add(CreateFileNameParameter());
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
			ProcessSchemaScriptTask downloadtemplatescript = CreateDownloadTemplateScriptScriptTask();
			FlowElements.Add(downloadtemplatescript);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("c8bbfae0-9a06-4c26-af18-65a0a3931fe6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e2d0c608-0dfb-4732-b4fc-978b68d2a768"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("6118b6bd-5aab-4383-a4ad-5ec9fe577948"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("77cd5826-be90-4efc-9a39-a2597e5d0119"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("6118b6bd-5aab-4383-a4ad-5ec9fe577948"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4f7c47b7-7b03-46a0-ae9e-66ade8261fe1"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("1e70ad34-8066-470b-877b-7016b5662197"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d7cda00e-2279-401e-8cac-f8155c4472f0"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("1e70ad34-8066-470b-877b-7016b5662197"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("e2d0c608-0dfb-4732-b4fc-978b68d2a768"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d7cda00e-2279-401e-8cac-f8155c4472f0"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
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
				UId = new Guid("4f7c47b7-7b03-46a0-ae9e-66ade8261fe1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d7cda00e-2279-401e-8cac-f8155c4472f0"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"End1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateDownloadTemplateScriptScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("6118b6bd-5aab-4383-a4ad-5ec9fe577948"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d7cda00e-2279-401e-8cac-f8155c4472f0"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"),
				Name = @"DownloadTemplateScript",
				Position = new Point(141, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,82,209,106,219,48,20,125,110,32,255,32,252,36,131,35,156,165,180,43,97,131,197,203,186,49,86,218,37,91,7,33,15,114,124,157,106,216,82,38,93,181,53,165,255,94,201,78,154,198,206,251,158,140,124,207,61,231,220,123,207,61,215,4,36,10,172,102,171,59,40,249,15,46,249,26,52,249,64,126,25,208,137,146,18,86,40,148,100,211,46,104,220,239,221,183,218,93,223,17,54,118,9,248,77,26,228,114,5,147,234,138,151,64,131,239,82,61,20,144,173,97,194,13,124,17,5,4,225,152,116,9,111,44,232,202,177,74,120,32,211,246,127,122,68,43,58,104,103,94,44,116,70,27,230,140,35,79,84,97,75,217,50,90,211,177,79,89,214,84,105,240,217,33,157,163,126,175,139,114,102,17,180,241,104,218,239,157,116,1,137,6,142,208,192,110,5,222,93,115,237,92,248,30,143,63,105,10,137,42,55,92,11,163,228,188,218,0,155,254,179,188,136,200,225,90,130,168,158,91,165,127,221,17,22,75,242,228,95,151,86,100,52,128,44,61,31,230,241,217,32,63,61,75,7,195,211,97,60,128,139,247,241,224,93,188,202,71,113,58,186,24,157,143,130,240,57,252,15,35,248,149,119,156,251,11,251,2,155,171,25,106,33,215,116,107,238,237,201,221,242,139,38,110,71,207,227,82,52,109,225,232,97,74,61,161,200,201,54,23,123,24,75,148,149,72,62,146,56,36,79,110,128,93,22,94,101,246,208,69,188,244,66,147,10,193,252,230,133,5,186,15,77,147,38,66,184,33,169,171,47,150,62,177,53,153,6,179,81,210,128,35,252,138,184,113,142,16,30,145,37,86,107,39,192,126,110,203,53,126,62,115,229,92,172,173,230,181,183,107,23,219,29,128,221,106,129,64,119,116,81,237,50,34,187,237,69,164,221,92,43,73,172,15,240,167,44,252,215,47,225,217,47,86,3,90,45,9,106,11,227,23,34,21,157,95,232,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a737adf4-93b2-43dd-8b6c-c23eaa17d1d5"),
				Name = "BPMSoft.Configuration",
				Alias = "TSConfiguration",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d6eeeb93-5a21-4bef-9d6d-cd57ba605f50"),
				Name = "System.Web",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d36e7d98-3c7f-4be1-ae1b-531cf6d59c3c"),
				Name = "System.IO",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new DownloadTemplateForImportProductsProcess(userConnection);
		}

		public override object Clone() {
			return new DownloadTemplateForImportProductsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882"));
		}

		#endregion

	}

	#endregion

	#region Class: DownloadTemplateForImportProductsProcess

	/// <exclude/>
	public class DownloadTemplateForImportProductsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, DownloadTemplateForImportProductsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public DownloadTemplateForImportProductsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DownloadTemplateForImportProductsProcess";
			SchemaUId = new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882");
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
				return new Guid("fe482f04-3ecb-4916-ade0-0db6b2194882");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: DownloadTemplateForImportProductsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: DownloadTemplateForImportProductsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private LocalizableString _fileName;
		public virtual LocalizableString FileName {
			get {
				return _fileName ?? (_fileName = GetLocalizableString("fe482f043ecb4916ade00db6b2194882",
						 "Parameters.FileName.Value"));
			}
			set {
				_fileName = value;
			}
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
					SchemaElementUId = new Guid("e2d0c608-0dfb-4732-b4fc-978b68d2a768"),
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
					SchemaElementUId = new Guid("4f7c47b7-7b03-46a0-ae9e-66ade8261fe1"),
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
					SchemaElementUId = new Guid("6118b6bd-5aab-4383-a4ad-5ec9fe577948"),
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
			MetaPathParameterValues.Add("88b7ad1c-6588-423a-8941-0a507b54d72d", () => PageInstanceId);
			MetaPathParameterValues.Add("3e60d7c4-bc8b-4d82-b662-1da181b31d7a", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("6369036e-4ff6-4179-8e04-be2aa3fd2dc5", () => TreeGridSelectedRowsIds);
			MetaPathParameterValues.Add("5b17a5a5-16f5-421f-b4f9-b424418475d9", () => FileName);
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
			var cloneItem = (DownloadTemplateForImportProductsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.TreeGridSelectedRowsIds = TreeGridSelectedRowsIds;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

