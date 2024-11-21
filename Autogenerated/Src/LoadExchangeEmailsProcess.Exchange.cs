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

	#region Class: LoadExchangeEmailsProcessSchema

	/// <exclude/>
	public class LoadExchangeEmailsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public LoadExchangeEmailsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public LoadExchangeEmailsProcessSchema(LoadExchangeEmailsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "LoadExchangeEmailsProcess";
			UId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42");
			CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93");
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
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,85,77,111,218,64,16,61,39,82,254,195,118,211,131,145,44,212,94,211,38,82,74,160,162,77,72,5,141,122,40,61,44,246,224,88,93,239,70,251,65,67,145,255,123,103,119,13,177,177,35,184,84,92,208,124,188,121,59,243,102,124,118,250,100,23,60,79,200,42,87,198,50,78,86,50,79,201,108,45,146,71,37,69,254,23,162,30,217,156,157,158,220,202,236,6,22,54,139,222,210,154,147,192,115,242,200,68,134,127,10,150,115,77,180,97,202,64,74,150,82,145,205,12,68,10,106,232,60,215,105,170,64,235,146,246,62,32,88,190,36,145,54,42,23,89,127,172,39,150,243,123,140,122,50,235,168,157,209,11,229,143,173,15,74,185,202,19,128,116,6,230,65,131,106,86,62,25,73,85,48,51,5,109,185,137,218,97,33,72,129,177,74,184,191,101,197,246,141,139,25,72,33,32,49,185,20,253,207,96,198,122,4,12,227,96,40,216,130,67,26,209,123,158,122,234,99,97,32,83,204,5,210,45,255,97,69,244,193,228,60,55,235,254,20,10,185,2,247,148,47,114,17,53,209,99,210,238,67,76,204,99,174,251,19,86,64,224,184,98,138,104,76,159,161,19,115,200,37,25,112,166,245,136,37,70,170,181,35,248,113,60,123,241,95,69,212,195,209,152,8,248,67,176,24,14,192,186,216,107,149,217,2,132,137,168,77,208,219,164,210,139,93,173,147,87,83,116,139,40,66,116,77,209,115,174,241,237,207,156,82,162,96,175,13,183,206,153,56,156,67,90,218,27,86,13,170,99,28,100,25,70,134,200,126,102,49,145,60,168,125,91,210,11,152,36,140,243,131,149,207,81,24,147,225,247,209,244,250,110,248,227,126,250,21,77,65,212,68,121,121,221,97,40,203,192,11,94,24,194,37,162,14,188,8,244,64,90,97,98,140,43,164,129,186,205,5,239,75,197,209,219,218,198,6,10,125,148,92,92,107,112,119,47,175,218,186,248,196,52,108,1,29,248,55,37,87,57,2,56,141,84,102,143,85,247,209,3,66,176,13,74,255,77,71,7,96,184,100,97,230,122,164,100,113,195,12,32,204,109,203,216,59,226,49,120,23,12,206,210,241,16,120,161,122,33,71,90,211,156,46,42,200,118,206,54,68,238,207,215,131,236,15,248,238,165,215,9,162,238,118,220,31,158,206,59,217,160,208,113,34,135,251,103,121,119,50,195,26,132,252,87,245,125,65,54,141,10,157,199,179,201,161,99,21,207,17,56,95,30,255,237,56,102,219,119,21,176,128,251,117,125,188,26,44,171,141,44,42,154,190,83,93,91,138,247,179,234,116,72,143,232,102,51,167,191,97,61,167,23,100,78,55,239,202,57,42,97,78,43,160,202,250,30,173,101,25,163,199,61,191,107,13,183,133,29,121,39,196,64,171,171,26,226,85,92,180,67,255,137,37,127,145,178,68,236,86,167,253,227,187,158,190,235,116,215,179,247,101,135,193,253,16,93,35,89,254,3,22,76,169,69,17,8,0,0 };
			RealUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42");
			Version = 0;
			PackageUId = new Guid("b8c22230-2173-426f-959e-be736709a63f");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("82543a97-c9a8-4beb-941d-8ef4b3f14761"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("378fb237-3b1a-409e-a4b7-b409772eb5d8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"LoadResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e736a65f-4d19-4d0b-be8f-fba81c125580"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetUserAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7468e799-61c5-41b3-9071-7396ff10fa12"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"NeedSetUserAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSuccessLoadEmailsMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("68c595cd-9fa1-477c-bdbc-d7a5686bdcff"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"SuccessLoadEmailsMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadEmailsFromDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("23032bb7-f14e-4c42-8f0e-f0de93e358ae"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"LoadEmailsFromDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateLoadResultParameter());
			Parameters.Add(CreateCreateRemindingParameter());
			Parameters.Add(CreateNeedSetUserAddressParameter());
			Parameters.Add(CreateSuccessLoadEmailsMessageParameter());
			Parameters.Add(CreateLoadEmailsFromDateParameter());
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
			ProcessSchemaScriptTask loadexchangeemailscripttask = CreateLoadExchangeEmailScriptTaskScriptTask();
			FlowElements.Add(loadexchangeemailscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("2178232f-0167-4c4f-8412-e10940f40071"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("c810b5c3-95d5-43bb-93e2-f16b7b84f0a3"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ceaf2735-60b0-4ba1-8c27-a604399b7531"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("fc9c113d-852c-4c28-a48a-79195b92ef4a"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ceaf2735-60b0-4ba1-8c27-a604399b7531"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3c7ed91d-008c-4351-b8ab-13fff632de5a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("deba005a-95f2-4bf3-b2c9-7320be29feda"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("366e12ec-8725-426c-9436-7be163ac6e66"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("deba005a-95f2-4bf3-b2c9-7320be29feda"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("c810b5c3-95d5-43bb-93e2-f16b7b84f0a3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("366e12ec-8725-426c-9436-7be163ac6e66"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
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
				UId = new Guid("3c7ed91d-008c-4351-b8ab-13fff632de5a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("366e12ec-8725-426c-9436-7be163ac6e66"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateLoadExchangeEmailScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("ceaf2735-60b0-4ba1-8c27-a604399b7531"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("366e12ec-8725-426c-9436-7be163ac6e66"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93"),
				CreatedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"),
				Name = @"LoadExchangeEmailScriptTask",
				Position = new Point(274, 170),
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
				UId = new Guid("7ef76fa2-afb6-4ff1-b0d8-05122e2a708b"),
				Name = "BPMSoft.Sync.Exchange",
				Alias = "",
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("da06c9d8-9a38-4073-bc77-89b836cb6504"),
				Name = "BPMSoft.Sync",
				Alias = "",
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("261eafa1-808b-4377-aeb5-67d29bcc8923"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("bf52bc50-6b05-4e41-90f3-592b01faa181"),
				Name = "System.Collections.Generic",
				Alias = "",
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1e203cd8-80e1-4a0d-a0e2-4733b9d9e4d4"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("a87ff3b8-7f79-4ef2-8410-8ae2fea47c7e"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("af45d813-3b4d-4c55-bf0a-04fba228af5d"),
				Name = "IntegrationApi.Interfaces",
				Alias = "",
				CreatedInPackageId = new Guid("db389f08-56ad-464d-83c5-5e18ef486d93")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new LoadExchangeEmailsProcess(userConnection);
		}

		public override object Clone() {
			return new LoadExchangeEmailsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42"));
		}

		#endregion

	}

	#endregion

	#region Class: LoadExchangeEmailsProcess

	/// <exclude/>
	public class LoadExchangeEmailsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, LoadExchangeEmailsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public LoadExchangeEmailsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LoadExchangeEmailsProcess";
			SchemaUId = new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42");
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
				return new Guid("ed2b4c2d-5943-4145-8448-7d829df84c42");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: LoadExchangeEmailsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: LoadExchangeEmailsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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
				return _needSetUserAddress ?? (_needSetUserAddress = GetLocalizableString("ed2b4c2d5943414584487d829df84c42",
						 "Parameters.NeedSetUserAddress.Value"));
			}
			set {
				_needSetUserAddress = value;
			}
		}

		private LocalizableString _successLoadEmailsMessage;
		public virtual LocalizableString SuccessLoadEmailsMessage {
			get {
				return _successLoadEmailsMessage ?? (_successLoadEmailsMessage = GetLocalizableString("ed2b4c2d5943414584487d829df84c42",
						 "Parameters.SuccessLoadEmailsMessage.Value"));
			}
			set {
				_successLoadEmailsMessage = value;
			}
		}

		public virtual DateTime LoadEmailsFromDate {
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
					SchemaElementUId = new Guid("c810b5c3-95d5-43bb-93e2-f16b7b84f0a3"),
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
					SchemaElementUId = new Guid("3c7ed91d-008c-4351-b8ab-13fff632de5a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _loadExchangeEmailScriptTask;
		public ProcessScriptTask LoadExchangeEmailScriptTask {
			get {
				return _loadExchangeEmailScriptTask ?? (_loadExchangeEmailScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LoadExchangeEmailScriptTask",
					SchemaElementUId = new Guid("ceaf2735-60b0-4ba1-8c27-a604399b7531"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = LoadExchangeEmailScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[LoadExchangeEmailScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LoadExchangeEmailScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("LoadExchangeEmailScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "LoadExchangeEmailScriptTask":
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
			if (!HasMapping("LoadEmailsFromDate")) {
				writer.WriteValue("LoadEmailsFromDate", LoadEmailsFromDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
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
			MetaPathParameterValues.Add("82543a97-c9a8-4beb-941d-8ef4b3f14761", () => SenderEmailAddress);
			MetaPathParameterValues.Add("378fb237-3b1a-409e-a4b7-b409772eb5d8", () => LoadResult);
			MetaPathParameterValues.Add("e736a65f-4d19-4d0b-be8f-fba81c125580", () => CreateReminding);
			MetaPathParameterValues.Add("7468e799-61c5-41b3-9071-7396ff10fa12", () => NeedSetUserAddress);
			MetaPathParameterValues.Add("68c595cd-9fa1-477c-bdbc-d7a5686bdcff", () => SuccessLoadEmailsMessage);
			MetaPathParameterValues.Add("23032bb7-f14e-4c42-8f0e-f0de93e358ae", () => LoadEmailsFromDate);
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
				case "LoadEmailsFromDate":
					if (!hasValueToRead) break;
					LoadEmailsFromDate = reader.GetValue<System.DateTime>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool LoadExchangeEmailScriptTaskExecute(ProcessExecutingContext context) {
			Synchronize();
			return true;
		}

			
			public virtual void Synchronize() {
				LogDebug($"Synchronize exchange emails started for {SenderEmailAddress}");
				if (string.IsNullOrEmpty(SenderEmailAddress)) {
					LogDebug($"Synchronize exchange emails error {NeedSetUserAddress}");
					FormatResult(NeedSetUserAddress);
					return;
				}
				if (!UserConnection.GetIsFeatureEnabled("OldEmailIntegration")) {
					ExchangeUtility.RemoveSyncJob(UserConnection, SenderEmailAddress, this.Name);
					var syncSession = ClassFactory.Get<ISyncSession>("Email", new ConstructorArgument("uc", UserConnection),
						new ConstructorArgument("senderEmailAddress", SenderEmailAddress));
					syncSession.Start();
					LogDebug($"ISyncSession ended for {SenderEmailAddress}");
					return;
				}
				LogDebug($"OldEmailIntegration feature enabled, old SyncSession start called for {SenderEmailAddress}");
				#if NETFRAMEWORK
				string resultMessage;
				int localChangesCount, remoteChangesCount;
				ExchangeUtility.SyncExchangeItems(UserConnection, SenderEmailAddress, 
					() => ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeEmailSyncProvider",
						new ConstructorArgument("userConnection", UserConnection),
						new ConstructorArgument("senderEmailAddress", SenderEmailAddress),
						new ConstructorArgument("loadEmailsFromDate", LoadEmailsFromDate),
						new ConstructorArgument("userSettings", null)),
					out resultMessage, out localChangesCount, out remoteChangesCount,
					ExchangeUtility.MailSyncProcessName);
				if (!string.IsNullOrEmpty(resultMessage)) {
					LogDebug($"Exchange emails synchronization result for {SenderEmailAddress}: {resultMessage}");
					FormatResult(resultMessage);
					return;
				}
				#endif
				LogDebug($"Synchronize exchange emails ended for {SenderEmailAddress}");
				return;
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
			var cloneItem = (LoadExchangeEmailsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

