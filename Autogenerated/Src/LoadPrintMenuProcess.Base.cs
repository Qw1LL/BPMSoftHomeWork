namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Store;
	using BPMSoft.Reports;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: LoadPrintMenuProcessSchema

	/// <exclude/>
	public class LoadPrintMenuProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LoadPrintMenuProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LoadPrintMenuProcessSchema(LoadPrintMenuProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LoadPrintMenuProcess";
			UId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,86,109,111,226,56,16,254,220,149,246,63,120,253,225,20,212,16,181,148,150,178,189,222,29,4,168,144,74,183,218,148,237,135,106,117,50,196,208,108,147,56,114,28,182,236,109,255,251,141,237,188,66,160,244,37,16,123,230,153,153,103,102,236,249,248,33,74,102,190,55,71,43,143,139,132,248,104,197,60,23,221,50,226,78,104,152,24,13,244,223,199,15,71,43,194,81,0,175,232,26,201,85,68,98,212,191,159,56,108,33,172,233,216,122,164,51,155,133,130,51,63,182,242,47,82,174,79,98,106,51,223,167,115,225,177,240,10,128,188,5,50,20,208,167,107,20,38,190,175,225,21,62,137,34,155,204,159,41,216,152,198,148,3,80,168,245,44,135,198,49,124,170,93,235,209,19,207,183,108,78,124,249,234,133,75,227,193,1,209,133,183,76,56,81,210,74,108,42,60,223,19,30,141,173,71,198,95,226,136,204,169,90,191,225,44,137,26,87,153,77,78,35,198,69,92,248,8,198,179,192,54,80,89,16,176,176,128,189,161,194,161,82,105,64,4,49,170,14,155,135,99,76,152,155,248,244,171,118,67,3,154,57,19,38,122,39,182,84,79,173,234,160,98,193,129,19,52,39,145,148,135,184,146,32,188,35,129,36,245,96,159,110,231,191,10,197,173,208,176,179,142,203,94,99,88,178,181,57,92,16,27,145,37,117,192,171,128,76,72,8,223,249,118,86,37,131,101,9,3,223,111,42,225,198,158,74,219,146,86,198,183,50,106,57,240,110,184,64,237,146,8,106,12,60,181,74,248,250,79,205,149,137,216,236,7,136,254,133,162,83,19,237,219,110,65,177,34,105,3,140,136,132,135,160,240,180,69,244,119,235,129,57,74,211,104,72,114,35,194,233,3,51,162,214,126,209,198,213,155,38,111,193,56,133,116,34,163,40,79,228,133,219,133,154,54,206,209,77,2,221,26,103,41,25,187,192,115,72,127,34,185,108,104,165,39,92,218,198,85,163,10,66,246,164,83,70,184,46,3,102,134,180,37,13,249,142,25,93,24,245,198,52,140,88,71,59,124,213,59,181,154,213,218,6,229,84,103,47,177,85,221,103,234,71,178,128,232,171,142,33,179,90,89,199,53,250,146,163,204,233,146,215,248,172,53,234,180,236,174,221,132,103,167,217,110,15,79,154,151,246,101,187,121,214,182,187,195,193,105,199,238,157,159,224,70,206,97,153,68,93,187,211,157,92,126,173,74,213,82,146,167,255,139,162,32,46,122,66,227,150,224,234,36,240,119,25,205,160,127,7,39,177,245,141,248,9,69,127,43,63,172,97,16,137,53,250,92,235,88,61,82,157,119,146,181,157,206,93,151,45,253,254,189,125,100,88,35,47,116,199,130,6,253,53,40,236,2,106,108,92,37,242,71,222,48,86,207,117,13,27,154,73,80,121,21,73,28,35,173,20,115,51,3,37,223,51,136,163,99,244,15,254,3,163,227,93,236,150,116,80,46,91,169,35,51,199,194,247,32,40,116,66,51,103,254,197,199,89,51,21,80,24,206,80,19,9,158,208,130,196,55,253,249,134,168,31,83,180,171,16,47,251,118,235,188,59,28,53,219,173,206,69,179,221,61,185,104,246,59,189,139,102,235,108,96,159,119,251,195,206,104,216,42,23,226,129,20,109,57,247,78,76,192,193,174,168,22,4,252,207,195,210,81,169,167,124,192,63,252,201,223,141,105,228,144,49,67,154,70,27,113,164,13,159,189,167,55,148,137,54,214,31,200,50,95,147,148,140,7,38,154,49,230,35,47,30,208,213,240,53,226,48,123,232,32,171,147,144,178,169,19,112,168,139,250,48,201,148,173,241,0,244,181,205,171,163,242,134,110,93,213,28,119,244,167,74,111,85,51,13,38,29,198,74,225,213,73,193,177,200,228,237,171,62,173,17,103,65,143,47,103,198,137,217,50,59,29,243,244,252,162,138,13,132,148,112,225,173,178,219,251,65,94,135,43,26,10,8,15,178,244,98,57,222,50,36,126,58,97,108,115,6,199,9,254,18,209,80,213,202,230,230,4,190,65,71,97,56,102,112,154,61,7,166,53,183,186,155,77,141,159,118,101,100,143,119,227,120,26,249,48,201,130,111,178,167,36,148,44,182,244,250,206,244,96,185,190,246,212,36,44,221,215,230,100,251,103,117,5,215,58,196,44,40,143,139,178,120,161,235,148,136,114,111,220,231,146,42,148,250,209,86,14,145,79,169,62,156,201,37,248,204,185,255,1,86,4,96,17,167,11,0,0 };
			RealUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateMenuParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8d814a0f-f49c-47b8-811a-9d7fcedd7c1f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"Menu",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSysModuleIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("720ead89-8627-4304-a359-d709a91ead74"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"SysModuleId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateMenuParameter());
			Parameters.Add(CreateSysModuleIdParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet4 = CreateLaneSet4LaneSet();
			LaneSets.Add(schemaLaneSet4);
			ProcessSchemaLane schemaLane8 = CreateLane8Lane();
			schemaLaneSet4.Lanes.Add(schemaLane8);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
			FlowElements.Add(CreateSequenceFlow18SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("f1217494-1fb3-445d-9f17-0fcfc701b6f6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				CurveCenterPosition = new Point(174, 92),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("97ae99d0-c2e3-47dd-a4dd-8a6878366ee1"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow18SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow18",
				UId = new Guid("99284bf7-21f1-4235-9ee8-97831b800760"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				CurveCenterPosition = new Point(324, 96),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b0634007-ed0b-46c9-860c-e2819299abfb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet4LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet4 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("22a03e1e-7d55-4798-a4f9-8501cbfc71d1"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"LaneSet4",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet4;
		}

		protected virtual ProcessSchemaLane CreateLane8Lane() {
			ProcessSchemaLane schemaLane8 = new ProcessSchemaLane(this) {
				UId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("22a03e1e-7d55-4798-a4f9-8501cbfc71d1"),
				CreatedInOwnerSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"Lane8",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane8;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("97ae99d0-c2e3-47dd-a4dd-8a6878366ee1"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"Start1",
				Position = new Point(57, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("b0634007-ed0b-46c9-860c-e2819299abfb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"End1",
				Position = new Point(316, 72),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("b499f499-2977-45ce-aa15-281af0a76bba"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"),
				Name = @"ScriptTask1",
				Position = new Point(169, 58),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,201,79,76,241,77,205,43,213,208,180,230,229,2,49,20,108,21,242,74,115,114,128,188,162,212,146,210,162,60,133,146,162,210,84,107,0,71,19,235,36,39,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7a147170-d041-4a67-b3b1-c7ff2b70fef8"),
				Name = "BPMSoft.Core.Entities",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1ea5759e-7be8-45c7-a793-b66f77ab8b4f"),
				Name = "BPMSoft.Core.Store",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("b00609b8-3139-4513-8337-2a8cafd4a7fb"),
				Name = "BPMSoft.Configuration",
				Alias = "TSConfiguration",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("15406e8e-7657-422a-9d4c-760556f1a647"),
				Name = "BPMSoft.Reports",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LoadPrintMenuProcess(userConnection);
		}

		public override object Clone() {
			return new LoadPrintMenuProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4"));
		}

		#endregion

	}

	#endregion

	#region Class: LoadPrintMenuProcess

	/// <exclude/>
	public class LoadPrintMenuProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane8

		/// <exclude/>
		public class ProcessLane8 : ProcessLane
		{

			public ProcessLane8(UserConnection userConnection, LoadPrintMenuProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public LoadPrintMenuProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoadPrintMenuProcess";
			SchemaUId = new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
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
				return new Guid("b7e6c182-5e8a-42d3-9de3-0e739f6632f4");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LoadPrintMenuProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LoadPrintMenuProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object Menu {
			get;
			set;
		}

		public virtual Guid SysModuleId {
			get;
			set;
		}

		private ProcessLane8 _lane8;
		public ProcessLane8 Lane8 {
			get {
				return _lane8 ?? ((_lane8) = new ProcessLane8(UserConnection, this));
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
					SchemaElementUId = new Guid("97ae99d0-c2e3-47dd-a4dd-8a6878366ee1"),
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
					SchemaElementUId = new Guid("b0634007-ed0b-46c9-860c-e2819299abfb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("776ac1f3-00bb-472b-a5ee-8a9a1b2a43be"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SysModuleId")) {
				writer.WriteValue("SysModuleId", SysModuleId, Guid.Empty);
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
			MetaPathParameterValues.Add("8d814a0f-f49c-47b8-811a-9d7fcedd7c1f", () => Menu);
			MetaPathParameterValues.Add("720ead89-8627-4304-a359-d709a91ead74", () => SysModuleId);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SysModuleId":
					if (!hasValueToRead) break;
					SysModuleId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			LoadMenu();
			Menu = null;
			return true;
		}

			
			public virtual void LoadMenu() {
				var menu = Menu as BPMSoft.UI.WebControls.Controls.MenuBaseCollection;
				if (menu != null) {
					var appCache = UserConnection.SessionCache.WithLocalCaching(TSConfiguration.CacheUtilities.WorkspaceCacheGroup);
					var reportsCollection = BPMSoft.Configuration.CommonUtilities.GetSelectData(UserConnection, BPMSoft.Configuration.CommonUtilities.GetModuleReportsSelect, appCache, TSConfiguration.CacheUtilities.ReportsCache);
					string captionColumnName = BPMSoft.Configuration.CommonUtilities.GetLczColumnName(UserConnection, "SysModuleReport", "Caption");
					var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as BPMSoft.UI.WebControls.PageSchemaManager;
					reportsCollection.Sort(delegate(Dictionary<string, object> p1, Dictionary<string, object> p2) { 
						return p1[captionColumnName].ToString().CompareTo(p2[captionColumnName].ToString());});
					foreach (var report in reportsCollection) {
						Guid sysModuleId = new Guid(report["sysModuleId"].ToString());
						if (SysModuleId == sysModuleId) {
							Guid reportId = new Guid(report["sysModuleReportId"].ToString());
							Guid typeId = new Guid(report["typeId"].ToString());
							string caption = report[captionColumnName].ToString();
							string helpContextId = report["helpContextId"].ToString();
							if (typeId == new Guid("32F72C9C-72C7-44E0-8C84-34C9ED17CA50")) {
								Guid reportSchemaUId = new Guid(report["sysReportSchemaUId"].ToString());
								Guid sysOptionsPageSchemaUId = report["sysOptionsPageSchemaUId"] == DBNull.Value ? Guid.Empty : new Guid(report["sysOptionsPageSchemaUId"].ToString());
								if (sysOptionsPageSchemaUId == Guid.Empty || pageSchemaManager.FindItemByUId(sysOptionsPageSchemaUId) != null) {
									menu.Add(CreateMenuItem(caption, reportSchemaUId.ToString()
										+ @"&" + sysOptionsPageSchemaUId.ToString() + @"&" + helpContextId,
										"PrintReportMenuItem_"+reportId.ToString("n"), true));
								}
							} else if (typeId == new Guid("8BC259EF-4276-4906-B7A6-23DC59BE7FE2")) {
								menu.Add(CreateMenuItem(caption, reportId.ToString("n"),
										"PrintReportMenuItem_" + reportId.ToString("n"), false));
							}
						}
					}
				}
			}
			
			
			public virtual BPMSoft.UI.WebControls.Controls.MenuItem CreateMenuItem(string MenuItemCaption, string MenuItemTag, string menuID, bool isDevExpressReport) {
				var menuItem = new BPMSoft.UI.WebControls.Controls.MenuItem();
				menuItem.ID = menuID;	
				menuItem.UId = Guid.NewGuid();
				menuItem.Caption = MenuItemCaption;
				menuItem.CaptionColor = Color.FromArgb(0,2,77,156);
				menuItem.Tag = MenuItemTag;
				menuItem.AjaxEvents.Click.SignalName = isDevExpressReport ? "OpenPrintDevExpressReportMessage" : "CreateMSWordReportMessage";
				if (!isDevExpressReport) {
					menuItem.AjaxEvents.Click.IsUpload = true;
				}
				return menuItem;
			}
			
			
			public virtual void OpenReportPage(string parameters) {
				var keyName = "PrintReportParameters";
				UserConnection.SessionData[keyName] = parameters;
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
			var cloneItem = (LoadPrintMenuProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Menu = Menu;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

