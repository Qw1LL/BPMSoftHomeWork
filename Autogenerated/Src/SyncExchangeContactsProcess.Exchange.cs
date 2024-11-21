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
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: SyncExchangeContactsProcessSchema

	/// <exclude/>
	public class SyncExchangeContactsProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public SyncExchangeContactsProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public SyncExchangeContactsProcessSchema(SyncExchangeContactsProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "SyncExchangeContactsProcess";
			UId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63");
			CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041");
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
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,85,219,106,219,64,16,125,78,32,255,176,21,37,200,32,68,250,154,54,1,91,113,90,67,110,212,201,83,221,135,141,52,81,150,74,187,102,119,229,198,49,250,247,206,94,108,172,75,108,67,9,1,49,59,123,230,204,217,57,227,147,227,121,245,92,176,148,44,152,212,21,45,200,66,176,140,76,151,60,125,149,130,179,119,8,7,100,117,114,124,116,35,242,43,120,174,242,240,115,176,117,72,224,45,125,165,60,7,146,10,174,105,170,21,81,154,74,13,25,121,17,146,172,166,192,51,144,227,146,178,98,152,101,18,148,170,131,193,87,132,155,112,166,25,45,16,226,1,100,201,148,98,130,171,209,242,126,14,146,106,243,29,218,52,246,66,66,165,37,227,121,60,81,119,85,81,220,35,216,92,47,195,46,240,192,241,60,156,40,72,105,40,222,1,100,83,208,79,10,100,147,226,209,181,144,37,213,63,65,85,133,14,187,105,46,73,130,174,36,55,159,53,254,47,168,36,175,80,96,23,228,130,112,248,75,198,92,51,189,220,34,34,127,216,99,215,158,75,141,147,2,168,236,102,134,166,88,34,56,135,212,72,98,111,56,49,136,180,164,110,145,5,205,33,34,165,251,120,156,23,86,52,174,73,33,82,90,36,182,99,149,136,138,235,8,239,148,66,195,118,204,36,143,189,46,79,154,21,88,63,54,4,214,177,137,134,82,181,88,68,164,43,125,68,140,18,56,40,23,151,36,41,168,82,215,40,176,144,203,248,59,232,111,35,170,96,13,104,192,31,164,88,48,4,184,12,131,117,56,113,79,178,125,26,68,6,242,200,72,136,167,216,117,101,16,135,50,175,74,224,58,12,170,6,169,32,34,45,173,246,92,87,157,30,16,162,103,166,246,194,104,141,207,97,46,115,28,206,129,203,23,149,110,63,144,9,245,60,137,203,108,63,139,5,105,191,75,83,163,20,129,239,104,9,27,147,124,234,117,73,131,69,143,65,198,93,247,110,230,207,218,208,247,241,161,153,207,201,170,81,163,215,58,77,22,61,174,57,220,178,72,96,223,102,217,64,35,178,249,235,91,111,13,122,222,82,222,67,78,164,62,155,161,163,189,200,238,122,24,172,86,179,224,15,44,103,193,57,153,5,171,179,122,134,115,48,11,60,144,143,126,193,104,93,71,120,98,250,238,243,206,186,176,33,127,35,104,230,104,245,85,67,60,207,69,25,244,95,88,242,55,169,107,196,238,72,220,223,188,111,203,33,222,170,124,100,247,205,48,53,227,212,171,131,155,173,132,242,73,57,23,82,251,33,84,215,82,148,155,217,57,61,37,38,99,252,182,157,241,40,214,231,30,200,191,139,253,101,241,73,87,192,25,100,118,30,234,195,106,181,176,218,2,157,213,4,245,70,57,124,15,17,105,64,185,122,131,110,193,3,169,239,47,215,0,234,148,243,48,62,123,247,132,30,240,251,104,201,237,126,154,139,214,90,140,175,70,83,72,43,137,11,101,204,115,198,193,108,104,43,0,70,53,108,208,195,96,39,110,103,221,198,73,37,37,110,68,19,141,39,174,231,29,186,254,31,175,143,80,15,97,101,21,239,211,123,179,130,250,92,208,222,197,152,28,187,236,45,239,34,244,63,252,164,94,184,76,9,0,0 };
			RealUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63");
			Version = 0;
			PackageUId = new Guid("b8c22230-2173-426f-959e-be736709a63f");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSenderEmailAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7176f340-3ddc-4681-8284-213f3d143daf"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"SenderEmailAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLoadResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("dc028f17-14b6-40df-a81d-174aaa291cfa"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"LoadResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCreateRemindingParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("58981c59-df61-4099-90a2-9a7c7ea42640"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"CreateReminding",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"false",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCanImportContactsFromExchangeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("783b5729-cf20-49ae-b0a6-57c22c4b618a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"CanImportContactsFromExchange",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCanExportContactsToExchangeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("70f91b46-5189-4adf-9698-d9898ee2918f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"CanExportContactsToExchange",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateNeedSetUserAddressParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("04af54a0-4e98-4fb5-963a-ab07f56ff338"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"NeedSetUserAddress",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncContactsSuccessMessageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("88cc7109-429a-4df6-b4e6-8dd40e8225c9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"SyncContactsSuccessMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncContactsSuccessMessageCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("72f4667a-c301-40c7-a26e-5d67915e3c85"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"SyncContactsSuccessMessageCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncContactDeniedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0defec7e-3189-46e4-89a5-cc259329f38f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6ce04b71-5a25-42cb-ad4b-066c11bad2f1"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"SyncContactDenied",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateImportContactDeniedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0c6d02ed-fc54-42b7-b632-c620589e113a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6ce04b71-5a25-42cb-ad4b-066c11bad2f1"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"ImportContactDenied",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateExportContactDeniedParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("1732dfcd-210e-45f6-a830-92594051da34"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("6ce04b71-5a25-42cb-ad4b-066c11bad2f1"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"ExportContactDenied",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSenderEmailAddressParameter());
			Parameters.Add(CreateLoadResultParameter());
			Parameters.Add(CreateCreateRemindingParameter());
			Parameters.Add(CreateCanImportContactsFromExchangeParameter());
			Parameters.Add(CreateCanExportContactsToExchangeParameter());
			Parameters.Add(CreateNeedSetUserAddressParameter());
			Parameters.Add(CreateSyncContactsSuccessMessageParameter());
			Parameters.Add(CreateSyncContactsSuccessMessageCaptionParameter());
			Parameters.Add(CreateSyncContactDeniedParameter());
			Parameters.Add(CreateImportContactDeniedParameter());
			Parameters.Add(CreateExportContactDeniedParameter());
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
			ProcessSchemaScriptTask syncwithexchangecontactsscripttask = CreateSyncWithExchangeContactsScriptTaskScriptTask();
			FlowElements.Add(syncwithexchangecontactsscripttask);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("1ca893ee-fc53-4729-a96b-2986d35aa832"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d6eee404-7e5e-431b-9556-6e636da2acb2"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5c04c1d8-a5db-409d-9633-133572f5bf9a"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("5dd441c0-0fb4-436a-88a3-399f8d0421ca"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5c04c1d8-a5db-409d-9633-133572f5bf9a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5943caea-1c98-4cee-a479-e8bd87148fc5"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("30a2fe96-a8db-4c2a-81f1-3ada1076a775"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("20bf330f-b5f7-4426-bb42-a2f8dd4bcf0c"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("30a2fe96-a8db-4c2a-81f1-3ada1076a775"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("d6eee404-7e5e-431b-9556-6e636da2acb2"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("20bf330f-b5f7-4426-bb42-a2f8dd4bcf0c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
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
				UId = new Guid("5943caea-1c98-4cee-a479-e8bd87148fc5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("20bf330f-b5f7-4426-bb42-a2f8dd4bcf0c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSyncWithExchangeContactsScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("5c04c1d8-a5db-409d-9633-133572f5bf9a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("20bf330f-b5f7-4426-bb42-a2f8dd4bcf0c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041"),
				CreatedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"),
				Name = @"SyncWithExchangeContactsScriptTask",
				Position = new Point(288, 170),
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
				UId = new Guid("b44ef58f-14cf-436e-926c-a749ba553e75"),
				Name = "BPMSoft.Sync.Exchange",
				Alias = "",
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("2b77174c-a967-495f-a790-5191b16f9e7e"),
				Name = "BPMSoft.Sync",
				Alias = "",
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8e4a5993-bda8-4c62-8675-eb4326cd459a"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8cfdb105-54a9-456a-93b1-fdc30663c698"),
				Name = "System.Collections.Generic",
				Alias = "",
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("df88aa77-d3f3-411f-a4ec-eded0eb71bbf"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("c0930077-79d2-414b-99da-47efbce6a23c"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new SyncExchangeContactsProcess(userConnection);
		}

		public override object Clone() {
			return new SyncExchangeContactsProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63"));
		}

		#endregion

	}

	#endregion

	#region Class: SyncExchangeContactsProcess

	/// <exclude/>
	public class SyncExchangeContactsProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, SyncExchangeContactsProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public SyncExchangeContactsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SyncExchangeContactsProcess";
			SchemaUId = new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_createReminding = () => { return (bool)(false); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a0f18ce-f112-4078-9025-0c8243d9bf63");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: SyncExchangeContactsProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: SyncExchangeContactsProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<bool> _createReminding;
		public virtual bool CreateReminding {
			get {
				return (_createReminding ?? (_createReminding = () => false)).Invoke();
			}
			set {
				_createReminding = () => { return value; };
			}
		}

		public virtual bool CanImportContactsFromExchange {
			get;
			set;
		}

		public virtual bool CanExportContactsToExchange {
			get;
			set;
		}

		private LocalizableString _needSetUserAddress;
		public virtual LocalizableString NeedSetUserAddress {
			get {
				return _needSetUserAddress ?? (_needSetUserAddress = GetLocalizableString("9a0f18cef112407890250c8243d9bf63",
						 "Parameters.NeedSetUserAddress.Value"));
			}
			set {
				_needSetUserAddress = value;
			}
		}

		private LocalizableString _syncContactsSuccessMessage;
		public virtual LocalizableString SyncContactsSuccessMessage {
			get {
				return _syncContactsSuccessMessage ?? (_syncContactsSuccessMessage = GetLocalizableString("9a0f18cef112407890250c8243d9bf63",
						 "Parameters.SyncContactsSuccessMessage.Value"));
			}
			set {
				_syncContactsSuccessMessage = value;
			}
		}

		private LocalizableString _syncContactsSuccessMessageCaption;
		public virtual LocalizableString SyncContactsSuccessMessageCaption {
			get {
				return _syncContactsSuccessMessageCaption ?? (_syncContactsSuccessMessageCaption = GetLocalizableString("9a0f18cef112407890250c8243d9bf63",
						 "Parameters.SyncContactsSuccessMessageCaption.Value"));
			}
			set {
				_syncContactsSuccessMessageCaption = value;
			}
		}

		private LocalizableString _syncContactDenied;
		public virtual LocalizableString SyncContactDenied {
			get {
				return _syncContactDenied ?? (_syncContactDenied = GetLocalizableString("9a0f18cef112407890250c8243d9bf63",
						 "Parameters.SyncContactDenied.Value"));
			}
			set {
				_syncContactDenied = value;
			}
		}

		private LocalizableString _importContactDenied;
		public virtual LocalizableString ImportContactDenied {
			get {
				return _importContactDenied ?? (_importContactDenied = GetLocalizableString("9a0f18cef112407890250c8243d9bf63",
						 "Parameters.ImportContactDenied.Value"));
			}
			set {
				_importContactDenied = value;
			}
		}

		private LocalizableString _exportContactDenied;
		public virtual LocalizableString ExportContactDenied {
			get {
				return _exportContactDenied ?? (_exportContactDenied = GetLocalizableString("9a0f18cef112407890250c8243d9bf63",
						 "Parameters.ExportContactDenied.Value"));
			}
			set {
				_exportContactDenied = value;
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
					SchemaElementUId = new Guid("d6eee404-7e5e-431b-9556-6e636da2acb2"),
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
					SchemaElementUId = new Guid("5943caea-1c98-4cee-a479-e8bd87148fc5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _syncWithExchangeContactsScriptTask;
		public ProcessScriptTask SyncWithExchangeContactsScriptTask {
			get {
				return _syncWithExchangeContactsScriptTask ?? (_syncWithExchangeContactsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SyncWithExchangeContactsScriptTask",
					SchemaElementUId = new Guid("5c04c1d8-a5db-409d-9633-133572f5bf9a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SyncWithExchangeContactsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[SyncWithExchangeContactsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SyncWithExchangeContactsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SyncWithExchangeContactsScriptTask", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "SyncWithExchangeContactsScriptTask":
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
			if (!HasMapping("CanImportContactsFromExchange")) {
				writer.WriteValue("CanImportContactsFromExchange", CanImportContactsFromExchange, false);
			}
			if (!HasMapping("CanExportContactsToExchange")) {
				writer.WriteValue("CanExportContactsToExchange", CanExportContactsToExchange, false);
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
			MetaPathParameterValues.Add("7176f340-3ddc-4681-8284-213f3d143daf", () => SenderEmailAddress);
			MetaPathParameterValues.Add("dc028f17-14b6-40df-a81d-174aaa291cfa", () => LoadResult);
			MetaPathParameterValues.Add("58981c59-df61-4099-90a2-9a7c7ea42640", () => CreateReminding);
			MetaPathParameterValues.Add("783b5729-cf20-49ae-b0a6-57c22c4b618a", () => CanImportContactsFromExchange);
			MetaPathParameterValues.Add("70f91b46-5189-4adf-9698-d9898ee2918f", () => CanExportContactsToExchange);
			MetaPathParameterValues.Add("04af54a0-4e98-4fb5-963a-ab07f56ff338", () => NeedSetUserAddress);
			MetaPathParameterValues.Add("88cc7109-429a-4df6-b4e6-8dd40e8225c9", () => SyncContactsSuccessMessage);
			MetaPathParameterValues.Add("72f4667a-c301-40c7-a26e-5d67915e3c85", () => SyncContactsSuccessMessageCaption);
			MetaPathParameterValues.Add("0defec7e-3189-46e4-89a5-cc259329f38f", () => SyncContactDenied);
			MetaPathParameterValues.Add("0c6d02ed-fc54-42b7-b632-c620589e113a", () => ImportContactDenied);
			MetaPathParameterValues.Add("1732dfcd-210e-45f6-a830-92594051da34", () => ExportContactDenied);
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
				case "CanImportContactsFromExchange":
					if (!hasValueToRead) break;
					CanImportContactsFromExchange = reader.GetValue<System.Boolean>();
				break;
				case "CanExportContactsToExchange":
					if (!hasValueToRead) break;
					CanExportContactsToExchange = reader.GetValue<System.Boolean>();
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

		public virtual bool SyncWithExchangeContactsScriptTaskExecute(ProcessExecutingContext context) {
			Synchronize();
			return true;
		}

			
			public virtual void Synchronize() {
				LogDebug($"Synchronize exchange contacts started for {SenderEmailAddress}");
				InitializePermissionsByOperations();
				if (string.IsNullOrEmpty(SenderEmailAddress)) {
					LogDebug($"Synchronize exchange contacts error {NeedSetUserAddress}");
					FormatResult(NeedSetUserAddress);
					return;
				}
				var helper = new EntitySynchronizerHelper();
				helper.ClearEntitySynchronizer(UserConnection);
				string resultMessage, messageTpl;
				int localChangesCount, remoteChangesCount;
				ExchangeUtility.SyncExchangeItems(UserConnection, SenderEmailAddress, 
					() => ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeContactSyncProvider",
						new ConstructorArgument("userConnection", UserConnection),
						new ConstructorArgument("senderEmailAddress", SenderEmailAddress),
						new ConstructorArgument("settings", null)),
					out resultMessage, out localChangesCount, out remoteChangesCount,
					ExchangeUtility.ContactSyncProcessName);
				if (!string.IsNullOrEmpty(resultMessage)) {
					LogDebug($"Exchange contacts synchronization result for {SenderEmailAddress}: {resultMessage}");
					FormatResult(resultMessage);
					return;
				}
				LogDebug($"Synchronize exchange contacts ended for {SenderEmailAddress}");
				return;
			}
			
			
			public virtual void FormatResult(string message) {
				string resultMessage = string.Format("{{\"key\": \"{0}\", \"message\": \"{1}\"}},", 
					SenderEmailAddress, message);
				LoadResult = string.Format("{{ \"Messages\": [{0}] }}", resultMessage);
			}
			
			
			public virtual string FormatMsgBySyncAccess(string message) {
					if (!CanImportContactsFromExchange && !CanExportContactsToExchange) {
						return SyncContactDenied;
					}
					if (!CanImportContactsFromExchange) {
						return string.Format("{0} {1}", message, ImportContactDenied);
					}
					if (!CanExportContactsToExchange) {
						return string.Format("{0} {1}", message, ExportContactDenied);
					}
					return message;
			}
			
			
			public virtual void InitializePermissionsByOperations() {
				CanImportContactsFromExchange = UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanImportContactsFromExchange", UserConnection.CurrentUser.Id);
				CanExportContactsToExchange = UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanExportContactsToExchange", UserConnection.CurrentUser.Id);
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
			var cloneItem = (SyncExchangeContactsProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

