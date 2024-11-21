namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
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
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: UpdateEmailAnaliticsProcessSchema

	/// <exclude/>
	public class UpdateEmailAnaliticsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public UpdateEmailAnaliticsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public UpdateEmailAnaliticsProcessSchema(UpdateEmailAnaliticsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "UpdateEmailAnaliticsProcess";
			UId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41");
			CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
			CultureName = @"en-US";
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,87,91,79,227,56,20,126,6,137,255,96,229,201,213,86,145,118,246,97,37,134,142,68,75,129,104,161,32,58,204,60,32,180,114,19,183,245,146,218,25,219,1,58,43,254,251,28,95,146,38,105,202,6,180,179,43,134,73,176,207,229,243,119,46,62,57,216,207,242,89,202,98,244,200,164,206,73,138,30,5,75,208,37,97,28,247,208,223,7,251,123,23,98,17,241,185,192,193,157,89,188,63,68,83,77,164,166,73,24,244,62,194,246,113,108,180,216,119,58,17,220,189,143,4,215,36,214,227,21,97,169,194,117,161,19,49,17,250,86,81,187,121,42,164,151,245,98,183,89,66,52,29,230,233,131,221,7,71,154,41,205,226,214,221,227,36,97,154,9,78,154,114,91,128,79,25,103,106,89,32,126,57,216,55,63,109,167,222,237,223,50,161,229,218,62,247,174,165,136,169,82,211,120,73,87,4,41,247,24,32,179,181,7,135,51,167,226,52,54,224,194,154,232,37,225,100,65,101,120,70,117,196,149,38,60,166,195,245,132,172,40,14,118,185,246,250,142,235,194,49,202,252,115,224,157,135,35,73,65,221,111,227,58,6,167,234,85,194,241,51,141,115,77,219,100,94,80,76,116,188,68,120,252,28,211,204,44,35,218,179,7,6,74,199,82,10,9,156,238,2,122,31,244,65,218,154,121,11,199,173,81,172,179,205,184,70,75,145,3,218,28,222,6,8,216,59,135,63,211,245,104,9,137,120,94,236,184,224,239,69,99,158,175,168,36,179,148,30,129,230,39,52,43,92,221,68,137,114,234,95,89,154,54,112,152,77,111,97,46,128,204,120,137,141,223,170,50,98,188,110,204,225,132,144,91,83,231,235,140,202,148,241,7,53,130,67,195,255,22,84,85,193,153,247,226,78,232,42,163,92,217,115,156,16,77,106,210,253,205,161,107,138,37,228,91,206,190,229,116,67,219,182,171,151,119,6,181,37,40,93,195,219,161,210,235,209,133,154,72,164,137,135,102,41,56,165,101,134,78,53,196,33,177,41,157,228,178,153,176,125,20,104,149,253,217,238,206,85,75,167,147,255,35,222,174,7,47,109,42,45,25,95,160,21,20,27,20,123,31,85,189,219,35,63,18,137,82,177,128,70,224,178,241,194,190,187,228,115,235,161,179,164,151,76,133,166,61,160,95,80,112,136,238,2,120,78,193,44,216,250,131,174,205,226,61,50,107,222,149,89,248,88,160,125,29,169,237,143,117,160,157,177,89,221,119,65,219,141,107,145,138,25,73,15,15,71,98,181,130,166,105,188,2,180,48,130,151,42,138,109,136,23,87,103,103,227,27,68,212,107,38,12,120,54,71,184,208,26,32,158,167,169,175,222,210,212,14,3,240,172,180,109,143,164,60,190,171,51,143,98,224,113,249,100,177,62,29,201,97,164,38,224,242,74,142,87,153,94,227,13,83,61,143,162,194,29,240,158,179,36,156,208,39,243,196,189,240,179,152,90,35,56,152,248,196,134,95,73,117,46,249,198,97,151,146,220,117,67,255,155,5,233,58,73,187,167,247,148,101,187,165,14,69,185,117,15,188,214,247,203,196,82,52,133,227,64,12,56,125,130,132,54,127,52,111,74,131,52,28,137,52,95,113,28,128,122,224,86,78,165,88,225,160,180,235,87,191,46,41,48,21,152,54,154,43,35,11,229,131,157,114,120,77,36,100,144,166,82,97,227,77,204,254,2,15,119,247,254,82,249,60,5,159,115,182,200,37,116,96,200,199,75,34,31,168,134,52,128,101,165,85,88,187,129,115,85,204,56,112,111,188,71,29,98,155,101,239,214,134,8,177,71,26,37,246,206,233,245,194,99,110,242,118,252,12,55,135,194,214,224,235,116,110,8,109,82,131,109,165,22,66,142,227,34,65,111,104,204,50,70,185,118,92,111,216,174,6,215,48,174,198,223,32,35,42,193,234,153,134,225,224,152,28,58,135,252,80,231,52,133,251,59,156,102,96,117,190,158,136,11,17,63,216,13,236,114,162,143,180,204,93,206,249,92,145,84,229,105,145,43,23,112,86,155,103,174,87,194,191,92,153,238,138,79,134,174,124,132,68,201,172,124,29,160,198,156,56,230,10,106,234,100,184,89,194,69,111,240,134,34,51,33,220,80,146,64,183,130,1,197,60,96,252,179,216,138,10,117,187,120,227,167,48,97,103,40,25,37,142,222,136,39,244,25,148,157,21,211,214,174,100,194,120,73,145,155,54,158,150,44,165,8,123,33,99,186,68,228,236,213,102,163,170,181,136,235,223,62,224,186,59,111,116,207,145,22,194,132,209,54,26,189,148,83,139,227,208,119,57,167,212,101,118,111,31,194,154,104,127,66,199,107,117,28,184,106,50,249,1,157,253,11,73,115,122,77,152,60,114,151,66,223,151,252,39,28,84,193,65,107,171,97,125,235,104,222,138,228,109,211,121,235,108,218,36,177,143,106,131,249,79,224,180,13,70,103,74,135,175,80,218,213,134,249,182,40,34,89,57,233,91,35,210,118,142,14,1,49,244,238,252,214,177,44,199,166,27,91,185,132,206,9,148,72,41,0,245,248,251,7,59,247,52,62,158,76,24,123,195,235,203,169,152,107,104,186,146,134,245,78,63,93,171,41,213,166,213,43,83,202,150,28,219,194,183,226,84,18,236,0,110,190,88,169,100,194,119,17,51,1,109,188,31,161,95,125,3,169,34,106,66,111,76,56,165,232,155,62,221,155,223,70,255,65,7,24,238,240,253,191,52,129,93,96,182,211,238,7,140,248,159,215,0,18,0,0 };
			RealUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41");
			Version = 0;
			PackageUId = new Guid("789c617e-760f-4576-a608-ee12728eae0a");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateLOGGERParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("231071ea-6643-4898-b33f-fe82c1526d35"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Name = @"LOGGER",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSessionKeyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("30944bf2-810c-4ad1-9ce6-01558b20047e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Name = @"SessionKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateLOGGERParameter());
			Parameters.Add(CreateSessionKeyParameter());
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
			ProcessSchemaScriptTask mainscripttask = CreateMainScriptTaskScriptTask();
			FlowElements.Add(mainscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("1418531f-a63d-4ad5-9116-b42ff97174f6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1fae9bb1-7179-4e6f-bc70-4fbd630d6a16"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b948883d-49cc-436b-9a6c-e02d5971d5ee"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("ce8c5fda-5c2a-4680-8509-b7549bfb29c1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b948883d-49cc-436b-9a6c-e02d5971d5ee"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("89d38304-7be6-4b99-9a47-f637b0ef69c4"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("4d4df1b5-735b-4be3-8f99-3bc85abc2611"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("1b46e01f-8c20-4efe-ab42-bc6bc456295d"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("4d4df1b5-735b-4be3-8f99-3bc85abc2611"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("1fae9bb1-7179-4e6f-bc70-4fbd630d6a16"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("1b46e01f-8c20-4efe-ab42-bc6bc456295d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
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
				UId = new Guid("89d38304-7be6-4b99-9a47-f637b0ef69c4"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("1b46e01f-8c20-4efe-ab42-bc6bc456295d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateMainScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b948883d-49cc-436b-9a6c-e02d5971d5ee"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("1b46e01f-8c20-4efe-ab42-bc6bc456295d"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414"),
				CreatedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"),
				Name = @"MainScriptTask",
				Position = new Point(274, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,204,204,211,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,176,217,148,41,21,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3c147ea6-a9b7-4999-ba05-f1062ef362f0"),
				Name = "BPMSoft.Configuration.MandrillService",
				Alias = "",
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e8084a72-4766-41d9-877f-c004b422c728"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("99c65a0f-7413-4117-a3f0-a052941ee8eb"),
				Name = "BPMSoft.Configuration",
				Alias = "TSConfiguration",
				CreatedInPackageId = new Guid("37b787ac-5e4e-4031-9f78-6e5fdb456414")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new UpdateEmailAnaliticsProcess(userConnection);
		}

		public override object Clone() {
			return new UpdateEmailAnaliticsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1dd85556-3227-499f-af34-bab27dfa7f41"));
		}

		#endregion

	}

	#endregion

	#region Class: UpdateEmailAnaliticsProcess

	/// <exclude/>
	public class UpdateEmailAnaliticsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, UpdateEmailAnaliticsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public UpdateEmailAnaliticsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UpdateEmailAnaliticsProcess";
			SchemaUId = new Guid("1dd85556-3227-499f-af34-bab27dfa7f41");
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
				return new Guid("1dd85556-3227-499f-af34-bab27dfa7f41");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: UpdateEmailAnaliticsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: UpdateEmailAnaliticsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object LOGGER {
			get;
			set;
		}

		public virtual string SessionKey {
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
					SchemaElementUId = new Guid("1fae9bb1-7179-4e6f-bc70-4fbd630d6a16"),
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
					SchemaElementUId = new Guid("89d38304-7be6-4b99-9a47-f637b0ef69c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _mainScriptTask;
		public ProcessScriptTask MainScriptTask {
			get {
				return _mainScriptTask ?? (_mainScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MainScriptTask",
					SchemaElementUId = new Guid("b948883d-49cc-436b-9a6c-e02d5971d5ee"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = MainScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[MainScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MainScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("MainScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "MainScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (LOGGER != null) {
				if (LOGGER.GetType().IsSerializable ||
					LOGGER.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("LOGGER", LOGGER, null);
				}
			}
			if (!HasMapping("SessionKey")) {
				writer.WriteValue("SessionKey", SessionKey, null);
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
			MetaPathParameterValues.Add("231071ea-6643-4898-b33f-fe82c1526d35", () => LOGGER);
			MetaPathParameterValues.Add("30944bf2-810c-4ad1-9ce6-01558b20047e", () => SessionKey);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "LOGGER":
					if (!hasValueToRead) break;
					LOGGER = reader.GetSerializableObjectValue();
				break;
				case "SessionKey":
					if (!hasValueToRead) break;
					SessionKey = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool MainScriptTaskExecute(ProcessExecutingContext context) {
			Main();
			return true;
		}

			
			public virtual void Main() {
				LogInfo("[Main]: Started.");
				ActualizeNonActualContactEmails();
				ActualizeDoNotUseEmailForContacts();
				UpdateBulkEmailStatistic();
				UpdateBulkEmailAdditionalStatistic();
				LogInfo("[Main]: Finished.");
			}
			
			
			public virtual void UpdateBulkEmailStatistic() {
				try {
					ProcessSchema schema = 
						UserConnection.ProcessSchemaManager.GetInstanceByName("UpdateBulkEmailStatisticProcess");
					Process process = schema.CreateProcess(UserConnection);
					process.Execute(UserConnection);
				} catch (Exception e){
					LogError("[UpdateBulkEmailStatistic]", e);
				}
			}
			
			
			public virtual void UpdateBulkEmailAdditionalStatistic() {
				try {
					int hourCount = GetHourlyChartHourCount();
					IEnumerable<int> bulkEmailRIds = GetWillUpdateBulkEmailRIds();
					foreach(int bulkEmailRId in bulkEmailRIds) {
						UpdateHyperlinksClicksCount(bulkEmailRId);
						UpdateClicksOpensChartData(bulkEmailRId, hourCount);
						UpdateBulkEmailUniqueStatistic(bulkEmailRId);
					}
				} catch (Exception e){
					LogError("[UpdateBulkEmailAdditionalStatistic]", e);
				}
			}
			
			
			public virtual void ActualizeDoNotUseEmailForContacts() {
				try {
					MandrillUtilities.ExecuteStoredProcedure(UserConnection, "tsp_ActualizeDoNotUseEmail");
				} catch (Exception e){
					LogError("[ActualizeDoNotUseEmailForContacts]", e);
				}
			}
			
			
			public virtual void LogError(string message, Exception e) {
				var logger = GetLogger();
				logger.Error(this.Name + ": [" + SessionKey + "] " + message + ";", e);
			}
			
			
			public virtual void LogInfo(string message) {
				var logger = GetLogger();
				logger.Info(this.Name + ": [" + SessionKey + "] " + message + ";");
			}
			
			
			public virtual global::Common.Logging.ILog GetLogger() {
				var logger = LOGGER as global::Common.Logging.ILog;
				if (logger == null) {
					logger = global::Common.Logging.LogManager.GetLogger(this.Name);
					LOGGER = logger;
				}
				if (string.IsNullOrEmpty(SessionKey)) {
					SessionKey = Guid.NewGuid().ToString("N");
				}
				return logger;
			}
			
			
			public virtual void ActualizeNonActualContactEmails() {
				try {
					MandrillUtilities.ExecuteStoredProcedure(UserConnection, "tsp_UpdateNonActualContactEmails");
				} catch (Exception e){
					LogError("[ActualizeNonActualContactEmails]", e);
				}
			}
			
			
			public virtual IEnumerable<int> GetWillUpdateBulkEmailRIds() {
				var select = new Select(UserConnection)
					.Column("RId")
					.From("BulkEmail")
					.Where("StatusId").In(Column.Parameters(new object[] {
						TSConfiguration.MarketingConsts.BulkEmailStatusFinishedId,
						TSConfiguration.MarketingConsts.BulkEmailStatusStoppedId,
						TSConfiguration.MarketingConsts.BulkEmailStatusActiveId
					})).And().Exists(
						new Select(UserConnection)
							.Column(Column.Parameter(null))
							.From("MandrillRecipient")
							.Where("BulkEmailRId").IsEqual("RId")
					) as Select;
				HintsHelper.SpecifyNoLockHints(select, true);
				
				var result = new List<int>();
				
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
						int rIdColumnIndex = reader.GetOrdinal("RId");
						while (reader.Read()) {
							int bulkEmailRId = reader.GetInt32(rIdColumnIndex);
							result.Add(bulkEmailRId);
						}
					}
				}
				
				return result;
			}
			
			
			public virtual void UpdateHyperlinksClicksCount(int bulkEmailRId) {
				try {
					MandrillUtilities.ExecuteStoredProcedure(UserConnection, "tsp_UpdateHyperlinksClicksCount",
						new KeyValuePair<string, object>("bulkEmailRId", bulkEmailRId));
				} catch (Exception e){
					LogError("[UpdateHyperlinksClicksCount]", e);
				}
			}
			
			
			public virtual void UpdateClicksOpensChartData(int bulkEmailRId, int hourCount) {
				try {
					MandrillUtilities.ExecuteStoredProcedure(UserConnection, "tsp_UpdateClicksOpensChartData",
						new KeyValuePair<string, object>("BulkEmailRId", bulkEmailRId),
						new KeyValuePair<string, object>("HoursCount", hourCount));
				} catch (Exception e){
					LogError("[UpdateClicksOpensChartData]", e);
				}
			}
			
			
			public virtual int GetHourlyChartHourCount() {
				const int defaultHourCount = 72;
				int hourCount = (int)BPMSoft.Core.Configuration.SysSettings.GetValue(
					UserConnection, "BulkEmailHourlyStatisticPeriod");
				if (hourCount < 1) {
					hourCount = defaultHourCount;
				}
				return hourCount;
			}
			
			
			public virtual void UpdateBulkEmailUniqueStatistic(int bulkEmailRId) {
				try {
					MandrillUtilities.ExecuteStoredProcedure(UserConnection, "tsp_UpdateBulkEmailUniqueStatistic",
						new KeyValuePair<string, object>("bulkEmailRId", bulkEmailRId));
				} catch (Exception e){
					LogError("[UpdateBulkEmailUniqueStatistic]", e);
				}
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
			var cloneItem = (UpdateEmailAnaliticsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.LOGGER = LOGGER;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

