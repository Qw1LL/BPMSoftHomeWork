namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Web.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ActualizeOrganizationalStructureProcessSchema

	/// <exclude/>
	public class ActualizeOrganizationalStructureProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ActualizeOrganizationalStructureProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ActualizeOrganizationalStructureProcessSchema(ActualizeOrganizationalStructureProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ActualizeOrganizationalStructureProcess";
			UId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a");
			CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
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
			SerializeToDB = true;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("845b7d47-dcdc-4417-87fd-3a6303ce3f2d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f607da52-c95e-438c-b42f-b9f4508f4efe"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTreeGridSelectedRowsIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("345b2d68-aa5a-4044-af6b-b3eb9285e2c3"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"TreeGridSelectedRowsIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("2a6d2a4f-148e-441d-95f5-8ce310796820"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"SuccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateTreeGridSelectedRowsIdsParameter());
			Parameters.Add(CreateSuccessMessageParameter());
		}

		protected virtual void InitializeUserTaskOpenMessageBoxParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2ec7f067-b206-4519-9227-e159baadec3e"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParameter.SourceValue = new ProcessSchemaParameterValue(pageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParameter);
			var iconParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e49a2ff8-0215-4a69-8feb-208c402d974b"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Icon",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			iconParameter.SourceValue = new ProcessSchemaParameterValue(iconParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(iconParameter);
			var buttonsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c5acfd7c-aaa1-409b-b752-44618abbb599"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"Buttons",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			buttonsParameter.SourceValue = new ProcessSchemaParameterValue(buttonsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(buttonsParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5040ada7-ee07-456d-ab46-ba1ce45464d3"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var messageTextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("da090272-0785-460e-90c2-c2f3b7ace3d5"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = true,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"MessageText",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			messageTextParameter.SourceValue = new ProcessSchemaParameterValue(messageTextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(messageTextParameter);
			var responseMessagesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4fdd111f-2023-4ed7-baf1-e3a9a1dd9cfa"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"ResponseMessages",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			responseMessagesParameter.SourceValue = new ProcessSchemaParameterValue(responseMessagesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(responseMessagesParameter);
			var processInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("be904acd-f3aa-44a6-bc4a-df6c02c58ee8"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"ProcessInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			processInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(processInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(processInstanceIdParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("57884fc3-5186-46ce-ae3f-b6820ce6efae"),
				ContainerUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				Name = @"PageParameters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParametersParameter.SourceValue = new ProcessSchemaParameterValue(pageParametersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
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
			ProcessSchemaScriptTask scripttaskexecutestoredprocedure = CreateScriptTaskExecuteStoredProcedureScriptTask();
			FlowElements.Add(scripttaskexecutestoredprocedure);
			ProcessSchemaUserTask usertaskopenmessagebox = CreateUserTaskOpenMessageBoxUserTask();
			FlowElements.Add(usertaskopenmessagebox);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("789c1629-8dec-40a3-9db1-fd28c9e69a24"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dd232d45-7502-431c-be9c-2eb57f643d9d"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ab074d9c-6cec-41c1-a6a5-2d210a4cf620"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("d66bd622-e1ac-4ff1-bdd7-c7cbd35e8298"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ab074d9c-6cec-41c1-a6a5-2d210a4cf620"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("14648d0f-7821-40c7-8c8f-15d148eb1b0b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("78dc0852-0c7a-4f4c-989b-7d3e5b240491"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("4c246673-bf38-419e-bad2-9e89fae3afed"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("a907fbfd-c6f8-4f7e-97a4-69d79eb760cb"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("4c246673-bf38-419e-bad2-9e89fae3afed"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("dd232d45-7502-431c-be9c-2eb57f643d9d"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a907fbfd-c6f8-4f7e-97a4-69d79eb760cb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
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
				UId = new Guid("78dc0852-0c7a-4f4c-989b-7d3e5b240491"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a907fbfd-c6f8-4f7e-97a4-69d79eb760cb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"End1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTaskExecuteStoredProcedureScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("ab074d9c-6cec-41c1-a6a5-2d210a4cf620"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a907fbfd-c6f8-4f7e-97a4-69d79eb760cb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"ScriptTaskExecuteStoredProcedure",
				Position = new Point(148, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,91,79,194,48,20,126,150,132,255,208,236,9,18,109,226,51,225,129,77,12,139,225,18,198,226,163,169,221,1,26,198,41,105,79,21,52,254,119,79,229,18,197,236,169,219,183,239,214,111,165,7,151,89,68,208,100,44,202,135,180,0,29,156,161,195,16,87,6,65,102,107,208,155,76,225,112,207,56,193,116,7,78,69,102,39,97,112,172,80,173,96,80,109,13,26,79,199,15,73,183,215,110,21,100,29,84,51,103,53,84,193,129,80,154,130,170,205,199,145,91,162,161,28,231,182,6,209,23,8,239,226,138,222,41,255,148,186,21,9,249,221,203,160,193,35,233,10,229,175,45,184,67,83,166,156,41,189,225,218,19,181,141,249,255,6,56,95,156,253,74,50,181,33,3,254,151,132,157,223,148,19,14,124,168,137,245,141,49,167,197,58,113,15,179,20,157,179,162,47,238,238,187,226,179,221,186,41,14,254,40,58,199,200,57,212,86,85,23,156,205,124,166,244,250,122,145,104,249,213,110,69,112,161,252,134,127,10,142,193,123,110,152,218,189,252,25,193,251,28,61,41,212,144,87,220,242,252,82,230,21,107,155,132,124,50,151,227,9,182,242,25,94,229,136,104,199,177,4,123,146,89,112,14,240,114,142,20,86,53,184,184,125,58,27,23,118,73,178,204,163,40,242,157,173,253,143,93,115,216,233,113,193,214,49,51,232,216,249,4,54,171,114,109,145,233,73,62,121,156,38,205,180,52,16,89,244,145,57,125,138,60,7,20,28,10,114,1,122,223,20,174,133,105,243,2,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateUserTaskOpenMessageBoxUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("a907fbfd-c6f8-4f7e-97a4-69d79eb760cb"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81"),
				CreatedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"),
				Name = @"UserTaskOpenMessageBox",
				Position = new Point(358, 170),
				SchemaUId = new Guid("496a664f-3aab-43d7-ab1b-2521ab601aab"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserTaskOpenMessageBoxParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a1302d98-2de7-4200-bd59-4507cfaae058"),
				Name = "BPMSoft.Web.Common",
				Alias = "",
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ActualizeOrganizationalStructureProcess(userConnection);
		}

		public override object Clone() {
			return new ActualizeOrganizationalStructureProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a"));
		}

		#endregion

	}

	#endregion

	#region Class: ActualizeOrganizationalStructureProcess

	/// <exclude/>
	public class ActualizeOrganizationalStructureProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ActualizeOrganizationalStructureProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: UserTaskOpenMessageBoxFlowElement

		/// <exclude/>
		public class UserTaskOpenMessageBoxFlowElement : QuestionUserTask
		{

			#region Constructors: Public

			public UserTaskOpenMessageBoxFlowElement(UserConnection userConnection, ActualizeOrganizationalStructureProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserTaskOpenMessageBox";
				IsLogging = true;
				SchemaElementUId = new Guid("8d9d1360-90b5-445b-acbb-fdc834197fc7");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ActualizeOrganizationalStructureProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActualizeOrganizationalStructureProcess";
			SchemaUId = new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a");
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
				return new Guid("ffe05a9e-09d7-4508-b3c6-ef89688e794a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ActualizeOrganizationalStructureProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ActualizeOrganizationalStructureProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private LocalizableString _successMessage;
		public virtual LocalizableString SuccessMessage {
			get {
				return _successMessage ?? (_successMessage = GetLocalizableString("ffe05a9e09d74508b3c6ef89688e794a",
						 "Parameters.SuccessMessage.Value"));
			}
			set {
				_successMessage = value;
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
					SchemaElementUId = new Guid("dd232d45-7502-431c-be9c-2eb57f643d9d"),
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
					SchemaElementUId = new Guid("78dc0852-0c7a-4f4c-989b-7d3e5b240491"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptTaskExecuteStoredProcedure;
		public ProcessScriptTask ScriptTaskExecuteStoredProcedure {
			get {
				return _scriptTaskExecuteStoredProcedure ?? (_scriptTaskExecuteStoredProcedure = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskExecuteStoredProcedure",
					SchemaElementUId = new Guid("ab074d9c-6cec-41c1-a6a5-2d210a4cf620"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTaskExecuteStoredProcedureExecute,
				});
			}
		}

		private UserTaskOpenMessageBoxFlowElement _userTaskOpenMessageBox;
		public UserTaskOpenMessageBoxFlowElement UserTaskOpenMessageBox {
			get {
				return _userTaskOpenMessageBox ?? (_userTaskOpenMessageBox = new UserTaskOpenMessageBoxFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[ScriptTaskExecuteStoredProcedure.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskExecuteStoredProcedure };
			FlowElements[UserTaskOpenMessageBox.SchemaElementUId] = new Collection<ProcessFlowElement> { UserTaskOpenMessageBox };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTaskExecuteStoredProcedure", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "ScriptTaskExecuteStoredProcedure":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserTaskOpenMessageBox", e.Context.SenderName));
						break;
					case "UserTaskOpenMessageBox":
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
			MetaPathParameterValues.Add("845b7d47-dcdc-4417-87fd-3a6303ce3f2d", () => PageInstanceId);
			MetaPathParameterValues.Add("f607da52-c95e-438c-b42f-b9f4508f4efe", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("345b2d68-aa5a-4044-af6b-b3eb9285e2c3", () => TreeGridSelectedRowsIds);
			MetaPathParameterValues.Add("2a6d2a4f-148e-441d-95f5-8ce310796820", () => SuccessMessage);
			MetaPathParameterValues.Add("2ec7f067-b206-4519-9227-e159baadec3e", () => UserTaskOpenMessageBox.Page);
			MetaPathParameterValues.Add("e49a2ff8-0215-4a69-8feb-208c402d974b", () => UserTaskOpenMessageBox.Icon);
			MetaPathParameterValues.Add("c5acfd7c-aaa1-409b-b752-44618abbb599", () => UserTaskOpenMessageBox.Buttons);
			MetaPathParameterValues.Add("5040ada7-ee07-456d-ab46-ba1ce45464d3", () => UserTaskOpenMessageBox.WindowCaption);
			MetaPathParameterValues.Add("da090272-0785-460e-90c2-c2f3b7ace3d5", () => UserTaskOpenMessageBox.MessageText);
			MetaPathParameterValues.Add("4fdd111f-2023-4ed7-baf1-e3a9a1dd9cfa", () => UserTaskOpenMessageBox.ResponseMessages);
			MetaPathParameterValues.Add("be904acd-f3aa-44a6-bc4a-df6c02c58ee8", () => UserTaskOpenMessageBox.ProcessInstanceId);
			MetaPathParameterValues.Add("57884fc3-5186-46ce-ae3f-b6820ce6efae", () => UserTaskOpenMessageBox.PageParameters);
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

		public virtual bool ScriptTaskExecuteStoredProcedureExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			StoredProcedure actualizeAdminUnitInRole = new StoredProcedure(UserConnection, "tsp_ActualizeAdminUnitInRole") as StoredProcedure;
			actualizeAdminUnitInRole.PackageName = UserConnection.DBEngine.CoreUtilitiesPackageName;
			var result = actualizeAdminUnitInRole.Execute();
			if (result == -1) {
				SysAdminUtilities.ReloadSysAdminUnitsCache(UserConnection);
			}
			UserTaskOpenMessageBox.ProcessInstanceId = InstanceUId;
			UserTaskOpenMessageBox.Page = System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page;
			UserTaskOpenMessageBox.MessageText = SuccessMessage;
			UserTaskOpenMessageBox.Icon = "INFO";
			UserTaskOpenMessageBox.Buttons = "OK";
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
			var cloneItem = (ActualizeOrganizationalStructureProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.TreeGridSelectedRowsIds = TreeGridSelectedRowsIds;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

