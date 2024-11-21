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
	using BPMSoft.Sync;
	using BPMSoft.Sync.Exchange;
	using IntegrationApi.Interfaces;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: SyncExchangeActivitiesProcessSchema

	/// <exclude/>
	public class SyncExchangeActivitiesProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SyncExchangeActivitiesProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SyncExchangeActivitiesProcessSchema(SyncExchangeActivitiesProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SyncExchangeActivitiesProcess";
			UId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
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
			SerializeToMemory = false;
			Tag = @"Business Process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,86,77,111,26,49,16,61,19,41,255,193,181,122,88,148,213,170,189,38,37,18,37,208,34,37,180,10,201,169,244,224,176,19,178,138,215,70,182,151,148,160,253,239,29,239,71,216,15,19,66,83,33,4,178,103,222,204,155,121,99,251,248,104,153,220,241,104,78,86,145,50,9,227,100,37,163,144,76,215,98,254,160,164,136,158,193,235,146,205,241,81,231,82,46,46,224,46,89,120,31,105,101,147,192,159,249,3,19,11,32,108,110,162,85,100,34,208,68,27,166,12,132,228,94,42,178,153,130,8,65,13,99,22,241,126,24,42,208,58,165,221,51,4,140,238,137,215,222,12,198,122,146,112,254,3,23,151,102,237,117,243,224,135,68,7,165,108,220,9,64,56,5,115,171,65,213,227,118,70,82,197,204,92,131,78,184,241,218,102,185,145,2,147,40,97,255,166,248,93,49,69,30,128,47,65,145,30,17,240,68,134,194,68,102,93,73,69,125,207,182,189,204,59,55,13,6,28,152,106,91,122,54,216,64,10,1,152,180,20,153,199,176,32,114,107,34,142,230,193,5,112,48,144,213,160,159,83,91,143,148,140,203,255,175,192,249,164,52,194,53,109,116,112,195,244,227,205,122,9,183,227,48,175,187,48,132,45,151,18,127,99,16,230,82,206,25,31,100,193,245,64,38,194,248,213,221,107,136,165,129,234,182,133,208,70,69,98,81,183,179,213,188,194,242,49,236,70,143,228,22,65,70,192,122,236,237,223,22,234,16,253,212,169,7,223,192,140,245,8,24,182,14,134,130,221,113,8,61,58,129,167,43,0,131,233,140,133,129,133,98,214,148,58,132,133,134,36,138,151,82,153,55,102,144,201,66,35,157,41,174,33,40,242,30,112,166,245,8,213,40,213,218,166,243,101,60,221,238,159,123,116,192,56,162,49,69,253,76,70,89,139,84,98,205,251,106,145,88,250,30,77,230,184,219,208,72,30,175,18,43,152,218,20,115,185,165,4,184,134,156,79,83,72,54,124,185,54,54,16,235,150,92,218,244,124,98,145,58,56,248,189,243,54,163,175,76,67,137,104,209,127,42,185,138,16,1,217,149,203,253,109,55,171,22,212,207,112,59,187,153,215,82,107,87,97,159,191,110,81,161,46,126,221,2,72,38,102,167,134,125,210,216,117,204,73,203,191,57,43,69,33,155,61,169,78,49,214,102,142,17,39,44,134,188,151,197,132,26,156,90,71,72,187,252,234,76,230,6,21,34,111,153,62,235,244,214,177,251,127,2,251,119,125,217,35,205,33,172,119,234,234,221,178,218,11,99,236,41,100,157,5,94,113,133,10,173,136,90,77,203,181,181,67,3,91,15,183,222,14,145,91,161,26,213,84,76,109,1,207,181,93,99,82,30,196,31,138,3,191,126,123,183,120,149,167,110,29,254,164,71,232,25,161,228,196,173,222,244,213,24,53,40,199,169,62,116,61,80,94,134,32,187,12,10,250,59,133,127,74,54,181,40,206,135,68,61,15,199,27,226,144,39,12,166,176,103,14,17,209,126,92,111,183,90,90,69,131,227,34,175,172,60,174,166,111,239,236,81,230,238,209,205,102,70,31,97,61,163,167,100,70,55,159,210,25,234,118,70,11,160,98,245,51,174,166,169,143,59,8,235,154,243,50,46,102,124,41,89,152,39,229,138,133,104,69,38,218,98,255,194,128,191,73,154,34,114,171,176,25,117,23,241,151,10,187,72,55,167,2,141,241,149,101,173,43,57,34,244,95,237,206,13,172,16,11,0,0 };
			RealUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			Version = 0;
			PackageUId = new Guid("b8c22230-2173-426f-959e-be736709a63f");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1706a8e4-a8db-40dd-bcfe-70083813c584"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f363e086-ca54-4a07-b6a4-f2d793380738"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"LoadResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("f4f43cc4-e123-4ce2-9acd-20ddaba5c641"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetUserAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("264bbae8-6f36-4dcf-94e7-82abf4ec9e24"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"NeedSetUserAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncActivitySuccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d17b41bd-be12-494e-934a-ba442230f54f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"SyncActivitySuccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateLoadResultParameter());
			Parameters.Add(CreateCreateRemindingParameter());
			Parameters.Add(CreateNeedSetUserAddressParameter());
			Parameters.Add(CreateSyncActivitySuccessMessageParameter());
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
				UId = new Guid("41f16446-2ae5-4ea4-ac7d-30b3c1e71a02"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("01fff802-295f-4649-9bca-a1af184a280f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("e4a99538-e8d9-4f6d-a8d2-c4de8277151e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("49cf4a4b-4e8c-49da-a7bb-669368c326fc"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("9fc02540-1342-4ae4-bf1f-3768b697dea1"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("9fc02540-1342-4ae4-bf1f-3768b697dea1"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("01fff802-295f-4649-9bca-a1af184a280f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
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
				UId = new Guid("49cf4a4b-4e8c-49da-a7bb-669368c326fc"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
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
				UId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("0744a239-2513-49f9-b6fa-459d7ee83ba3"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3"),
				CreatedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"),
				Name = @"MainScriptTask",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,11,174,204,75,206,40,202,207,203,172,74,213,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,209,75,113,44,28,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("ccf59d5b-a728-418e-9389-ed5f74140b3b"),
				Name = "BPMSoft.Sync.Exchange",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e1699d33-d81c-428e-ab95-b9519e811946"),
				Name = "BPMSoft.Sync",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2cc2de4d-4a49-4023-84e0-87f513f606fd"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7d06a26f-7484-42fa-a34a-a289a78da842"),
				Name = "System.Collections.Generic",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7835e741-23c7-4f92-bfad-db3d847fa2ad"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c25553c6-8f82-4df6-aa2e-7aa7bdef3c27"),
				Name = "BPMSoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("405cd56e-8293-41da-83e9-a9cf9867a065")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("23df5e27-0cfa-4ef6-b0b4-19e72992cfcc"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("43f3a715-af06-427b-b896-54d69dab34cd"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SyncExchangeActivitiesProcess(userConnection);
		}

		public override object Clone() {
			return new SyncExchangeActivitiesProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncExchangeActivitiesProcess

	/// <exclude/>
	public class SyncExchangeActivitiesProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SyncExchangeActivitiesProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SyncExchangeActivitiesProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncExchangeActivitiesProcess";
			SchemaUId = new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
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
				return new Guid("e5873837-7f4e-4bce-93c3-0179fb72eb6a");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SyncExchangeActivitiesProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SyncExchangeActivitiesProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual string SenderEmailAddress {
			get;
			set;
		}

		public virtual string LoadResult {
			get;
			set;
		}

		public virtual bool CreateReminding {
			get;
			set;
		}

		private LocalizableString _needSetUserAddress;
		public virtual LocalizableString NeedSetUserAddress {
			get {
				return _needSetUserAddress ?? (_needSetUserAddress = GetLocalizableString("e58738377f4e4bce93c30179fb72eb6a",
						 "Parameters.NeedSetUserAddress.Value"));
			}
			set {
				_needSetUserAddress = value;
			}
		}

		private LocalizableString _syncActivitySuccessMessage;
		public virtual LocalizableString SyncActivitySuccessMessage {
			get {
				return _syncActivitySuccessMessage ?? (_syncActivitySuccessMessage = GetLocalizableString("e58738377f4e4bce93c30179fb72eb6a",
						 "Parameters.SyncActivitySuccessMessage.Value"));
			}
			set {
				_syncActivitySuccessMessage = value;
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
					SchemaElementUId = new Guid("01fff802-295f-4649-9bca-a1af184a280f"),
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
					SchemaElementUId = new Guid("49cf4a4b-4e8c-49da-a7bb-669368c326fc"),
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
					SchemaElementUId = new Guid("143c11fd-593c-4449-b58c-0f5cf0393adb"),
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
			if (!HasMapping("SenderEmailAddress")) {
				writer.WriteValue("SenderEmailAddress", SenderEmailAddress, null);
			}
			if (!HasMapping("LoadResult")) {
				writer.WriteValue("LoadResult", LoadResult, null);
			}
			if (!HasMapping("CreateReminding")) {
				writer.WriteValue("CreateReminding", CreateReminding, false);
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
			MetaPathParameterValues.Add("1706a8e4-a8db-40dd-bcfe-70083813c584", () => SenderEmailAddress);
			MetaPathParameterValues.Add("f363e086-ca54-4a07-b6a4-f2d793380738", () => LoadResult);
			MetaPathParameterValues.Add("f4f43cc4-e123-4ce2-9acd-20ddaba5c641", () => CreateReminding);
			MetaPathParameterValues.Add("264bbae8-6f36-4dcf-94e7-82abf4ec9e24", () => NeedSetUserAddress);
			MetaPathParameterValues.Add("d17b41bd-be12-494e-934a-ba442230f54f", () => SyncActivitySuccessMessage);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SenderEmailAddress":
					if (!hasValueToRead) break;
					SenderEmailAddress = reader.GetValue<System.String>();
				break;
				case "LoadResult":
					if (!hasValueToRead) break;
					LoadResult = reader.GetValue<System.String>();
				break;
				case "CreateReminding":
					if (!hasValueToRead) break;
					CreateReminding = reader.GetValue<System.Boolean>();
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
			Synchronize();
			return true;
		}

			
			public virtual void Synchronize() {
				LogDebug($"Synchronize exchange activities started for {SenderEmailAddress}");
				if (SenderEmailAddress.IsNullOrEmpty()) {
					LogDebug($"Synchronize exchange activities error {NeedSetUserAddress}");
					FormatResult(NeedSetUserAddress);
					return;
				}
				var helper = new EntitySynchronizerHelper();
				helper.ClearEntitySynchronizer(UserConnection);
				ExchangeUtility.DeleteEmptyActivityFromActivitySynchronizer(UserConnection, ActivityConsts.TaskTypeUId);
				int appointmentLocalChangesCount, appointmentRemoteChangesCount;
				string appointmentResultMessage = string.Empty;
				LogDebug($"Synchronize exchange appointments started for {SenderEmailAddress}");
				if (UserConnection.GetIsFeatureEnabled("NewMeetingIntegration")) {
					LogDebug($"New import started for {SenderEmailAddress}");
					var syncSession = ClassFactory.Get<ISyncSession>("Calendar", new ConstructorArgument("uc", UserConnection));
					syncSession.Start();
				} else {
					ExchangeUtility.SyncExchangeItems(UserConnection, SenderEmailAddress, 
						() => ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeAppointmentSyncProvider",
							new ConstructorArgument("userConnection", UserConnection),
							new ConstructorArgument("senderEmailAddress", SenderEmailAddress)),
						out appointmentResultMessage, out appointmentLocalChangesCount, out appointmentRemoteChangesCount, 
						ExchangeUtility.ActivitySyncProcessName);
				}
				int taskLocalChangesCount, taskRemoteChangesCount;
				string taskResultMessage;
				LogDebug($"Synchronize exchange tasks started for {SenderEmailAddress}");
				ExchangeUtility.SyncExchangeItems(UserConnection, SenderEmailAddress, 
					() => ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeTaskSyncProvider",
						new ConstructorArgument("userConnection", UserConnection),
						new ConstructorArgument("senderEmailAddress", SenderEmailAddress),
						new ConstructorArgument("settings", null)),
					out taskResultMessage, out taskLocalChangesCount, out taskRemoteChangesCount, 
					ExchangeUtility.ActivitySyncProcessName);
				string resultMessage;
				resultMessage = appointmentResultMessage;
				if (!string.IsNullOrEmpty(taskResultMessage)) {
					resultMessage += "; " + taskResultMessage;
				}
				if (!string.IsNullOrEmpty(resultMessage)) {
					LogDebug($"Exchange activities synchronization result for {SenderEmailAddress}: {resultMessage}");
					FormatResult(resultMessage);
					return;
				}
				LogDebug($"Synchronize exchange activities ended for {SenderEmailAddress}");
			}
			
			
			public virtual void FormatResult(string message) {
				string resultMessage = string.Format("{{\"key\": \"{0}\", \"message\": \"{1}\"}},", 
				SenderEmailAddress, message);
			LoadResult = string.Format("{{ \"Messages\": [{0}] }}", resultMessage);
			}
			
			public virtual void LogDebug(string message) {
				ExchangeUtility.Log.Debug(message);
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
			var cloneItem = (SyncExchangeActivitiesProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

