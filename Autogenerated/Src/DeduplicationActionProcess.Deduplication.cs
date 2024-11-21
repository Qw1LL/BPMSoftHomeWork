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
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: DeduplicationActionProcessSchema

	/// <exclude/>
	public class DeduplicationActionProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public DeduplicationActionProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public DeduplicationActionProcessSchema(DeduplicationActionProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "DeduplicationActionProcess";
			UId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,77,111,219,48,12,61,39,64,254,3,219,67,43,3,129,209,251,98,23,93,178,101,1,214,22,168,49,244,48,236,160,217,140,45,192,145,12,73,206,16,108,251,239,163,165,124,200,117,58,244,178,219,128,124,64,79,124,228,163,248,56,25,55,237,247,90,228,176,21,218,182,188,134,173,18,5,220,115,33,89,4,63,39,227,145,88,3,123,108,80,115,43,148,92,21,144,36,176,192,162,109,136,227,160,185,146,198,154,56,67,174,243,42,8,244,236,81,150,87,184,225,15,124,131,144,64,112,184,189,5,99,181,144,101,252,97,211,216,221,187,46,214,3,95,191,129,57,198,153,30,43,206,168,172,101,215,191,174,35,71,88,43,141,60,175,128,121,102,192,3,33,195,44,241,115,133,26,153,116,50,82,184,200,124,233,149,121,104,235,250,81,63,87,194,98,214,240,220,135,68,209,94,252,200,53,167,219,220,42,125,167,203,118,131,210,6,105,143,80,2,18,127,192,153,96,118,121,138,190,156,6,84,175,255,108,254,214,160,38,92,98,222,61,228,91,106,244,25,84,231,75,15,216,215,234,77,237,206,221,124,194,154,6,6,60,60,36,48,175,185,49,31,9,84,122,23,47,209,206,94,101,166,108,248,24,83,87,108,116,190,139,189,148,176,96,252,30,75,33,189,125,152,191,255,77,63,221,247,237,238,187,71,93,226,208,124,159,133,177,179,101,43,138,20,14,28,52,29,72,93,46,14,192,19,230,74,23,171,194,0,55,112,98,56,37,11,225,148,114,189,155,121,139,209,12,221,127,10,26,141,170,183,88,144,130,53,37,178,157,83,159,6,24,165,124,61,135,43,33,104,182,165,86,109,211,117,7,140,142,209,81,218,210,227,62,142,94,226,47,190,61,45,73,4,87,87,47,219,189,32,247,16,163,187,241,227,57,84,164,139,155,97,124,60,87,45,201,74,225,230,31,45,66,160,246,255,34,200,112,17,156,147,217,126,60,211,23,115,153,14,93,215,219,24,250,76,198,127,0,21,82,213,56,210,5,0,0 };
			RealUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			Version = 0;
			PackageUId = new Guid("b5967e5d-641c-4d1f-ad1d-a02f69fcc776");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSchemaNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b3039b1a-323a-4fee-b5d7-437acd810775"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"SchemaName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateOperationIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f007b958-c46e-4876-8331-220fd44c5f13"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"OperationId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDuplicateRecordIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8a830a8e-6b86-43e9-9f30-0bee4ad0ab01"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"DuplicateRecordIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDuplicateGroupIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("12e32a26-3adb-4e83-8022-cee5d7aca001"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"DuplicateGroupId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateResolvedConflictsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3872c3e8-715d-44c8-9718-782b83aca273"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"ResolvedConflicts",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSchemaNameParameter());
			Parameters.Add(CreateOperationIdParameter());
			Parameters.Add(CreateDuplicateRecordIdsParameter());
			Parameters.Add(CreateDuplicateGroupIdParameter());
			Parameters.Add(CreateResolvedConflictsParameter());
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
				UId = new Guid("799ada9b-5721-4a7d-ad52-8698e17b1669"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ee9e24df-15f7-43b8-bc2f-fda897bde191"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("b4fd70d0-fa55-42b7-806f-e2402e3ee028"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("884985ea-3105-49b0-9fa8-d7bab09690f3"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("d90ef81b-0a9d-4bf1-8858-6d5856b6c40d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d90ef81b-0a9d-4bf1-8858-6d5856b6c40d"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("ee9e24df-15f7-43b8-bc2f-fda897bde191"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
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
				UId = new Guid("884985ea-3105-49b0-9fa8-d7bab09690f3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"Terminate1",
				Position = new Point(680, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateMainScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6cb6819d-e37b-4f6d-a546-d74bbdb40e8b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				CreatedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"),
				Name = @"MainScriptTask",
				Position = new Point(340, 170),
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
				UId = new Guid("e7af5a8c-13a2-430e-9323-59fa83ba2875"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("99f8556b-9d3f-42f2-823e-784708f4f25b"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("3669c994-a9bd-4e68-be31-75ce83e8ebbb"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c8636092-31d5-4e58-a47f-ac2a3230646c"),
				Name = "System",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("203753cd-b2e5-42a2-ae80-455ece8c8a7a"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new DeduplicationActionProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicationActionProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicationActionProcess

	/// <exclude/>
	public class DeduplicationActionProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, DeduplicationActionProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public DeduplicationActionProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicationActionProcess";
			SchemaUId = new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("21b965c8-37af-4e87-ae30-b6cc5866d666");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: DeduplicationActionProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: DeduplicationActionProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string SchemaName {
			get;
			set;
		}

		public virtual Guid OperationId {
			get;
			set;
		}

		public virtual Object DuplicateRecordIds {
			get;
			set;
		}

		public virtual Object DuplicateGroupId {
			get;
			set;
		}

		public virtual Object ResolvedConflicts {
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
					SchemaElementUId = new Guid("ee9e24df-15f7-43b8-bc2f-fda897bde191"),
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
					SchemaElementUId = new Guid("884985ea-3105-49b0-9fa8-d7bab09690f3"),
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
					SchemaElementUId = new Guid("df8220cf-a667-4938-ba9b-5e4a19232e43"),
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
			if (!HasMapping("SchemaName")) {
				writer.WriteValue("SchemaName", SchemaName, null);
			}
			if (!HasMapping("OperationId")) {
				writer.WriteValue("OperationId", OperationId, Guid.Empty);
			}
			if (DuplicateRecordIds != null) {
				if (DuplicateRecordIds.GetType().IsSerializable ||
					DuplicateRecordIds.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DuplicateRecordIds", DuplicateRecordIds, null);
				}
			}
			if (DuplicateGroupId != null) {
				if (DuplicateGroupId.GetType().IsSerializable ||
					DuplicateGroupId.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DuplicateGroupId", DuplicateGroupId, null);
				}
			}
			if (ResolvedConflicts != null) {
				if (ResolvedConflicts.GetType().IsSerializable ||
					ResolvedConflicts.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ResolvedConflicts", ResolvedConflicts, null);
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
			MetaPathParameterValues.Add("b3039b1a-323a-4fee-b5d7-437acd810775", () => SchemaName);
			MetaPathParameterValues.Add("f007b958-c46e-4876-8331-220fd44c5f13", () => OperationId);
			MetaPathParameterValues.Add("8a830a8e-6b86-43e9-9f30-0bee4ad0ab01", () => DuplicateRecordIds);
			MetaPathParameterValues.Add("12e32a26-3adb-4e83-8022-cee5d7aca001", () => DuplicateGroupId);
			MetaPathParameterValues.Add("3872c3e8-715d-44c8-9718-782b83aca273", () => ResolvedConflicts);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SchemaName":
					if (!hasValueToRead) break;
					SchemaName = reader.GetValue<System.String>();
				break;
				case "OperationId":
					if (!hasValueToRead) break;
					OperationId = reader.GetValue<System.Guid>();
				break;
				case "DuplicateRecordIds":
					if (!hasValueToRead) break;
					DuplicateRecordIds = reader.GetSerializableObjectValue();
				break;
				case "DuplicateGroupId":
					if (!hasValueToRead) break;
					DuplicateGroupId = reader.GetSerializableObjectValue();
				break;
				case "ResolvedConflicts":
					if (!hasValueToRead) break;
					ResolvedConflicts = reader.GetSerializableObjectValue();
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
				if (OperationId == DeduplicationConsts.SearchOperationId) {
					SchemaName = SchemaName ?? string.Empty;
					string[] schemaNames = SchemaName.Split('|');
					foreach (string schemaName in schemaNames.Where(name => !String.IsNullOrWhiteSpace(name))) {
						ConstructorArgument schemaNameArgument = new ConstructorArgument("schemaName", schemaName);
						ConstructorArgument userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
						DeduplicationActionHelper actionHelper = ClassFactory.Get<DeduplicationActionHelper>(schemaNameArgument,
							userConnectionArgument);
						actionHelper.BeginSearch();
					}
				}
				
				if (OperationId == DeduplicationConsts.MergeOperationId) {
					List<Guid> duplicatesList = DuplicateRecordIds as List<Guid>;
					Dictionary<string, string> resolvedConflicts = ResolvedConflicts as Dictionary<string, string>;
					int groupId = (int)DuplicateGroupId;
					if (!String.IsNullOrWhiteSpace(SchemaName) && duplicatesList != null && 
							groupId != 0 && duplicatesList.Count > 0) {
						ConstructorArgument schemaNameArgument = new ConstructorArgument("schemaName", SchemaName);
						ConstructorArgument userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
						DeduplicationActionHelper actionHelper = ClassFactory.Get<DeduplicationActionHelper>(schemaNameArgument,
							userConnectionArgument);
						actionHelper.BeginMerge(groupId, duplicatesList, resolvedConflicts);
					}
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
			var cloneItem = (DeduplicationActionProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.DuplicateRecordIds = DuplicateRecordIds;
			cloneItem.DuplicateGroupId = DuplicateGroupId;
			cloneItem.ResolvedConflicts = ResolvedConflicts;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

