namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Packages;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: ActualizeMoneyColumnsDbStructureSchema

	/// <exclude/>
	public class ActualizeMoneyColumnsDbStructureSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ActualizeMoneyColumnsDbStructureSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ActualizeMoneyColumnsDbStructureSchema(ActualizeMoneyColumnsDbStructureSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ActualizeMoneyColumnsDbStructure";
			UId = new Guid("da145d55-9e13-4850-b793-d144131e3849");
			CreatedInPackageId = new Guid("5e3d1956-5f66-4b70-a038-d893b5276a26");
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
			SerializeToMemory = false;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			UseForceCompile = true;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("da145d55-9e13-4850-b793-d144131e3849");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateWriteMessageActionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("9cded1e6-41ef-478e-a34b-0c9477d7d2d4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"WriteMessageAction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNotUpdateMoneyStructureStartDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("81396900-691f-4903-8800-fa97fb6e90b4"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"NotUpdateMoneyStructureStartDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#DateValue.06.08.2016#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateResultStringParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d765c621-e06e-42c3-9fe3-5ab78d8dcb6b"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"ResultString",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType"),
			};
		}

		protected virtual ProcessSchemaParameter CreateExcludedSchemasParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("63ceb59f-2bfb-4ece-b672-61602e2bfd57"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"ExcludedSchemas",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateWriteMessageActionParameter());
			Parameters.Add(CreateNotUpdateMoneyStructureStartDateParameter());
			Parameters.Add(CreateResultStringParameter());
			Parameters.Add(CreateExcludedSchemasParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaStartEvent startevent1 = CreateStartEvent1StartEvent();
			FlowElements.Add(startevent1);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("ba7d21c9-d4bb-4ff8-a549-5b15f80982bc"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9b8acda0-6cd5-4437-b641-254a5f98b191"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("9a48ca51-5d97-4a66-a28d-2f2b4b98bb91"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("113d9d4f-fa38-4872-9caf-37636da9d452"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("3dc9702d-8b43-479a-9ec1-ac5a8282935b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3dc9702d-8b43-479a-9ec1-ac5a8282935b"),
				CreatedInOwnerSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStartEvent1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("9b8acda0-6cd5-4437-b641-254a5f98b191"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"StartEvent1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("113d9d4f-fa38-4872-9caf-37636da9d452"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"TerminateEvent1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d3e3c893-0c1d-403b-853b-bf21225ccc3b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("92407950-4ff4-47a3-be70-ffefec778136"),
				CreatedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849"),
				Name = @"ScriptTask1",
				Position = new Point(291, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = true,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,87,91,111,26,57,20,126,166,82,255,131,51,15,149,71,69,163,118,31,211,64,5,132,84,172,114,169,10,73,30,86,171,149,51,115,50,88,157,241,176,182,7,194,70,252,247,61,190,204,13,16,137,148,40,96,159,235,247,157,139,179,102,146,72,80,101,166,175,139,52,5,73,6,68,192,134,204,181,228,34,29,151,60,75,64,210,240,219,199,15,163,88,243,66,92,40,123,209,39,55,160,20,75,97,177,93,193,144,100,69,186,40,38,133,80,69,6,104,224,7,232,139,19,226,67,26,60,74,174,193,159,57,201,224,29,62,208,52,205,221,89,159,104,60,13,201,96,72,94,63,126,232,241,103,66,59,65,156,97,26,101,150,133,246,182,215,190,218,179,128,94,123,59,252,109,99,16,141,86,43,16,201,85,33,115,166,105,240,250,101,119,78,94,191,238,94,255,216,5,78,43,90,20,14,32,26,246,73,109,111,42,214,92,22,34,7,161,163,91,216,92,115,97,205,239,240,247,94,129,68,255,2,108,130,164,236,126,117,136,117,101,16,164,238,129,5,200,33,67,224,37,206,202,4,146,121,188,132,156,41,111,192,93,162,226,180,123,109,53,215,200,243,158,218,53,87,26,85,157,90,52,83,183,8,216,157,124,92,34,53,243,21,139,129,238,201,135,8,211,119,91,29,70,179,118,103,142,207,247,109,71,243,85,198,53,69,225,191,254,38,175,36,232,7,100,215,247,85,101,175,238,86,38,41,21,253,130,188,88,195,52,95,233,237,84,224,53,168,16,209,53,14,104,24,97,246,107,144,122,148,101,20,147,28,18,21,45,36,207,105,104,18,50,148,31,73,40,26,137,45,10,88,222,145,118,26,44,150,32,129,48,252,173,164,137,114,226,231,36,32,159,171,244,255,44,184,160,72,47,254,28,177,26,118,138,49,154,137,103,91,27,152,129,101,216,193,171,126,243,21,102,88,198,186,148,112,191,74,152,134,75,120,102,88,86,115,205,164,190,196,239,158,41,243,113,193,115,64,174,110,11,237,68,111,10,1,219,90,189,214,176,228,85,242,199,92,180,109,207,183,106,14,90,99,62,42,66,63,15,44,43,129,118,139,173,143,184,4,147,140,99,145,58,253,127,222,140,160,255,158,204,76,152,72,32,215,91,7,219,13,19,136,22,214,220,145,179,193,94,3,68,71,20,209,220,85,41,226,139,31,37,79,250,164,6,140,164,160,157,220,53,83,85,218,212,17,122,63,75,234,129,96,248,136,139,172,204,133,177,130,50,230,143,175,113,58,177,23,209,188,40,101,12,238,11,13,234,252,110,138,132,63,115,72,238,176,229,250,228,168,108,91,196,78,16,9,168,41,8,165,115,200,48,167,208,142,80,251,113,15,126,83,220,43,250,213,244,76,175,23,121,123,77,160,254,252,74,22,57,70,132,108,218,196,2,127,124,39,113,24,143,183,151,160,226,67,157,71,83,231,56,52,102,73,37,62,83,211,127,75,86,167,251,147,73,150,131,198,113,222,192,21,134,209,244,5,226,18,203,40,102,25,147,173,202,172,70,151,237,245,54,65,195,14,167,234,145,235,229,164,148,18,68,188,117,158,16,237,35,172,155,130,156,105,200,21,109,26,28,227,108,247,56,55,236,29,83,189,226,34,153,9,165,153,136,97,188,197,192,41,143,108,248,198,128,75,220,234,242,106,238,147,79,159,200,25,71,4,30,184,212,136,65,253,253,114,252,192,97,115,160,231,153,80,118,122,96,185,12,73,28,33,20,204,118,144,105,121,194,21,177,253,209,57,61,8,224,236,216,68,194,12,53,227,66,97,208,183,200,64,53,6,39,69,190,194,177,36,13,173,92,176,108,150,138,66,194,132,41,111,182,2,169,26,222,109,208,23,69,213,252,190,104,253,218,62,36,203,234,227,180,2,22,47,9,181,99,202,94,16,46,222,226,209,13,81,163,194,208,7,203,248,127,144,248,142,59,232,66,95,83,150,21,211,16,102,58,239,105,13,79,78,47,191,169,253,130,195,201,237,231,109,179,160,170,117,236,28,227,70,254,178,35,44,195,196,146,45,41,173,177,132,224,50,197,69,29,145,57,122,138,162,200,140,46,23,151,3,190,27,145,13,212,46,137,198,221,201,57,223,219,17,200,20,184,72,79,243,17,141,146,196,99,82,61,49,240,199,209,243,18,131,93,126,88,235,213,71,213,225,175,22,160,245,162,123,195,89,179,243,60,128,185,74,15,145,187,28,155,19,95,48,27,142,109,242,4,53,116,152,169,197,52,48,27,162,119,100,43,158,14,193,79,59,223,78,6,110,28,46,38,115,131,47,70,115,26,88,83,100,216,33,154,101,217,189,230,248,60,192,119,128,135,228,39,139,127,163,218,108,239,118,127,174,218,162,219,147,65,55,246,160,42,165,207,102,85,96,21,200,180,222,19,54,60,60,136,222,199,255,41,47,83,41,11,121,212,71,67,179,45,11,227,174,230,216,21,97,171,47,7,111,33,109,134,97,133,51,182,27,25,12,140,183,186,243,90,182,12,11,205,122,52,130,238,77,252,189,82,104,189,99,201,121,187,85,172,161,234,177,105,242,186,57,86,79,46,227,205,146,103,85,25,181,234,11,145,243,22,109,89,245,201,202,17,105,159,210,117,99,218,190,180,235,202,132,228,185,182,213,83,55,103,229,191,75,141,245,125,130,148,57,91,227,78,51,46,46,199,53,118,244,125,69,236,223,154,6,81,124,239,203,210,61,227,155,222,183,239,202,153,38,10,112,157,17,189,100,26,7,81,70,52,123,202,176,108,27,8,112,103,52,19,167,154,85,102,40,157,126,75,226,19,142,6,191,236,255,35,142,29,212,232,252,123,210,176,214,122,8,215,21,214,204,2,189,148,197,198,54,209,40,77,37,164,152,107,93,119,56,71,11,172,14,11,174,34,69,28,99,192,137,231,178,10,218,176,159,60,53,9,185,183,177,119,228,131,245,47,31,131,210,183,255,1,185,209,76,83,76,14,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ca866da1-7106-4d5c-95d0-4b083397d6da"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("5e3d1956-5f66-4b70-a038-d893b5276a26")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("355e532d-aa5f-467b-a432-d3a32262ebad"),
				Name = "BPMSoft.Core.Packages",
				Alias = "",
				CreatedInPackageId = new Guid("5e3d1956-5f66-4b70-a038-d893b5276a26")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ActualizeMoneyColumnsDbStructure(userConnection);
		}

		public override object Clone() {
			return new ActualizeMoneyColumnsDbStructureSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da145d55-9e13-4850-b793-d144131e3849"));
		}

		#endregion

	}

	#endregion

	#region Class: ActualizeMoneyColumnsDbStructureMethodsWrapper

	/// <exclude/>
	public class ActualizeMoneyColumnsDbStructureMethodsWrapper : ProcessModel
	{

		public ActualizeMoneyColumnsDbStructureMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var resultLogger = new StringBuilder();
			Action<string, MessageType> logToConsole = Get<Action<string, MessageType>>("WriteMessageAction");
			Action<string, MessageType> log = (message, type) => {
				if (logToConsole != null) {
					logToConsole(message, type);
				}
				resultLogger.AppendFormat("{0}: {1}{2}", type.ToString(), message, Environment.NewLine);
			};
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			string excludedSchemas = Get<string>("ExcludedSchemas");
			var excludedSchemasList = string.IsNullOrWhiteSpace(excludedSchemas)
				? new List<string>()
				: excludedSchemas.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(s => s.Trim());
			if (excludedSchemasList.Any()) {
				log("There are excluded schemas: " + string.Join(", ", excludedSchemasList), MessageType.Information);
			}
			var skipStructureUpdateDefaultStartDate = Get<DateTime>("NotUpdateMoneyStructureStartDate");
			DateTime skipStructureUpdateStartDate = SysSettings.GetValue(userConnection,
				"ClientUpdate_NotUpdateMoneyStructureStartDate", skipStructureUpdateDefaultStartDate);
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Func<Guid, DateTime> getSchemaLastDate = (schemaUId) => {
				var columnFunc = Func.IsNull(Column.SourceColumn("StructureModifiedOn"), Column.SourceColumn("ModifiedOn"));
				return ((Select)new Select(userConnection).Top(1)
						.Column(columnFunc)
						.From("SysSchema")
						.OrderByDesc(columnFunc)
						.Where("UId")
						.IsEqual(Column.Parameter(schemaUId))).ExecuteScalar<DateTime>();
			};
			List<EntitySchema> entitySchemasWithCurrencyColumn = entitySchemaManager.GetItems().ToList()
				.ConvertAll(i => entitySchemaManager.FindInstanceByUId(i.UId))
				.Where(i => i != null && !i.IsVirtual && !i.IsDBView)
				.Where(i => i.Columns.Any(c => c.DataValueType is MoneyDataValueType))
				.Where(i => !excludedSchemasList.Contains(i.Name, StringComparer.OrdinalIgnoreCase))
				.ToList();
			var entitySchemasToUpdateStructure = new List<EntitySchema>();
			foreach (var schema in entitySchemasWithCurrencyColumn) {
				var actualizedDate = getSchemaLastDate(schema.UId);
				if (actualizedDate > skipStructureUpdateStartDate) {
					string logMessage = string.Format("Schema: {0} already updated on {1}. Skip...", schema.Name, actualizedDate);
					log(logMessage, MessageType.Information);
				} else {
					entitySchemasToUpdateStructure.Add(schema);
				}
			}
			List<Exception> exceptions = new List<Exception>();
			if (entitySchemasToUpdateStructure.Any()) {
				string msg = string.Format("DB structure will be updated for: {0}",
					string.Join(", ", entitySchemasToUpdateStructure.Select(i => i.Name)));
				log(msg, MessageType.Information);
				var installUtilities = new PackageInstallUtilities(userConnection);
				installUtilities.InstallMessage += (s, arg) => {
					log(arg.Message, MessageType.Information);
				};
				installUtilities.InstallError += (s, arg) => {
					exceptions.Add(arg.Exception);
					var schema = entitySchemasToUpdateStructure.Find(i => i.UId == arg.UId);
					var schemaName = (schema == null) ? arg.UId.ToString() : schema.Name;
					string errorMsg = string.Format("Error while update structure for schema: {0}, package: {1}", schemaName,
						arg.PackageName);
					log(errorMsg, MessageType.Error);
				};
				installUtilities.SaveSchemaDBStructure(entitySchemasToUpdateStructure.Select(s => s.UId), true);
			} else {
				log("It seems that all tables structure is actualized already.", MessageType.Information);
			}
			Set("ResultString", resultLogger.ToString());
			if (exceptions.Any()) {
				throw new AggregateException("Some errors occured while actualizing db structure", exceptions);
			}
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: ActualizeMoneyColumnsDbStructure

	/// <exclude/>
	public class ActualizeMoneyColumnsDbStructure : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ActualizeMoneyColumnsDbStructure process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ActualizeMoneyColumnsDbStructure(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActualizeMoneyColumnsDbStructure";
			SchemaUId = new Guid("da145d55-9e13-4850-b793-d144131e3849");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notUpdateMoneyStructureStartDate = () => { return (DateTime)(DateTime.ParseExact("06.08.2016", "dd.MM.yyyy", CultureInfo.InvariantCulture)); };
			ProcessModel = new ActualizeMoneyColumnsDbStructureMethodsWrapper(this);
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("da145d55-9e13-4850-b793-d144131e3849");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ActualizeMoneyColumnsDbStructure, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ActualizeMoneyColumnsDbStructure, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual Object WriteMessageAction {
			get;
			set;
		}

		private Func<DateTime> _notUpdateMoneyStructureStartDate;
		public virtual DateTime NotUpdateMoneyStructureStartDate {
			get {
				return (_notUpdateMoneyStructureStartDate ?? (_notUpdateMoneyStructureStartDate = () => DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture))).Invoke();
			}
			set {
				_notUpdateMoneyStructureStartDate = () => { return value; };
			}
		}

		public virtual string ResultString {
			get;
			set;
		}

		public virtual string ExcludedSchemas {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("9b8acda0-6cd5-4437-b641-254a5f98b191"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
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
					SchemaElementUId = new Guid("113d9d4f-fa38-4872-9caf-37636da9d452"),
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
					SchemaElementUId = new Guid("d8f2ee75-819e-4154-96b8-b2c435063954"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ProcessModel.GetScriptTaskMethod("ScriptTask1Execute"),
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartEvent1 };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartEvent1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (WriteMessageAction != null) {
				if (WriteMessageAction.GetType().IsSerializable ||
					WriteMessageAction.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("WriteMessageAction", WriteMessageAction, null);
				}
			}
			if (!HasMapping("ResultString")) {
				writer.WriteValue("ResultString", ResultString, null);
			}
			if (!HasMapping("ExcludedSchemas")) {
				writer.WriteValue("ExcludedSchemas", ExcludedSchemas, null);
			}
			if (!HasMapping("NotUpdateMoneyStructureStartDate")) {
				writer.WriteValue("NotUpdateMoneyStructureStartDate", NotUpdateMoneyStructureStartDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
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
			MetaPathParameterValues.Add("9cded1e6-41ef-478e-a34b-0c9477d7d2d4", () => WriteMessageAction);
			MetaPathParameterValues.Add("81396900-691f-4903-8800-fa97fb6e90b4", () => NotUpdateMoneyStructureStartDate);
			MetaPathParameterValues.Add("d765c621-e06e-42c3-9fe3-5ab78d8dcb6b", () => ResultString);
			MetaPathParameterValues.Add("63ceb59f-2bfb-4ece-b672-61602e2bfd57", () => ExcludedSchemas);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "WriteMessageAction":
					if (!hasValueToRead) break;
					WriteMessageAction = reader.GetSerializableObjectValue();
				break;
				case "ResultString":
					if (!hasValueToRead) break;
					ResultString = reader.GetValue<System.String>();
				break;
				case "ExcludedSchemas":
					if (!hasValueToRead) break;
					ExcludedSchemas = reader.GetValue<System.String>();
				break;
				case "NotUpdateMoneyStructureStartDate":
					if (!hasValueToRead) break;
					NotUpdateMoneyStructureStartDate = reader.GetValue<System.DateTime>();
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
			var cloneItem = (ActualizeMoneyColumnsDbStructure)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.WriteMessageAction = WriteMessageAction;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

