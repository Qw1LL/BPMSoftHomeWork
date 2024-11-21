namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GoogleServices;
	using Google;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Net;
	using System.Text;

	#region Class: GCalendarSynchronizationModuleProcessSchema

	/// <exclude/>
	public class GCalendarSynchronizationModuleProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public GCalendarSynchronizationModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public GCalendarSynchronizationModuleProcessSchema(GCalendarSynchronizationModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "GCalendarSynchronizationModuleProcess";
			UId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89");
			CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.8.0.0";
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
			RealUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89");
			Version = 0;
			PackageUId = new Guid("8d48ade0-350e-7694-49aa-2a913c356ce1");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6a170f99-0994-46d9-8dd1-983048f8a5da"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("53ff815d-bf48-4c18-92ed-065c25e47d7e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateModifiedGEntitiesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b53b4501-8253-47d0-af2f-1e41a8b9cfb2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"ModifiedGEntities",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateModifiedBPMEntitiesParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3d2a46ec-1719-423b-a9cf-568038f56080"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"ModifiedBPMEntities",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentSyncDateTimeParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("6181b599-3bb7-434a-bd13-b10613943f8f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"CurrentSyncDateTime",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncProviderParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a3699fdc-c28f-4afe-808f-096cd393ca2e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"SyncProvider",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateBPMIsAConflictResolverParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("41e320fe-fd3e-4926-942f-cc7facb78796"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"BPMIsAConflictResolver",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
			};
		}

		protected virtual ProcessSchemaParameter CreateDefActivityCategoryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("0ba82835-fceb-4bad-b75d-d52fe03fa461"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"DefActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					Value = @"2365ae4f-58e6-df11-971b-001d60e938c6",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateResolvedConflictUIdsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8d1cdb9f-5c88-40f3-80ba-69dd9d1d9be2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"ResolvedConflictUIds",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLastSyncDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("97062d45-0d38-4cee-ba3c-9fece6c0a6f9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"LastSyncDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateGoogleAccountNameParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5b7f83bc-6e12-4a54-b45d-bc3970a3f965"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"GoogleAccountName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateAccessTokenParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("efefea24-99b5-4886-8785-53d0204c42ff"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"AccessToken",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridClientIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("749d5d34-d42d-4f8b-857d-fbc373706b93"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"ActiveTreeGridClientId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MediumText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSyncResultParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("3e8350ee-ed3a-4f83-8ed9-c1084d8f7bb9"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"SyncResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationSummaryLSParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("e6c70236-656b-4a05-aab8-4b0cdf5536d0"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"SynchronizationSummaryLS",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateSynchronizationSummaryParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b4593900-7bc9-44b1-9dff-438141dd5fd1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"SynchronizationSummary",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateGoogleModificationDateLiesTooFarInThePastErrorParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4643ae2d-19f0-4db8-860b-87461d18677c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"GoogleModificationDateLiesTooFarInThePastError",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateModifiedGEntitiesParameter());
			Parameters.Add(CreateModifiedBPMEntitiesParameter());
			Parameters.Add(CreateCurrentSyncDateTimeParameter());
			Parameters.Add(CreateSyncProviderParameter());
			Parameters.Add(CreateBPMIsAConflictResolverParameter());
			Parameters.Add(CreateDefActivityCategoryParameter());
			Parameters.Add(CreateResolvedConflictUIdsParameter());
			Parameters.Add(CreateLastSyncDateParameter());
			Parameters.Add(CreateGoogleAccountNameParameter());
			Parameters.Add(CreateAccessTokenParameter());
			Parameters.Add(CreateActiveTreeGridClientIdParameter());
			Parameters.Add(CreateSyncResultParameter());
			Parameters.Add(CreateSynchronizationSummaryLSParameter());
			Parameters.Add(CreateSynchronizationSummaryParameter());
			Parameters.Add(CreateGoogleModificationDateLiesTooFarInThePastErrorParameter());
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaGCalendarLaneSet = CreateGCalendarLaneSetLaneSet();
			LaneSets.Add(schemaGCalendarLaneSet);
			ProcessSchemaLane schemaGCalendarLane = CreateGCalendarLaneLane();
			schemaGCalendarLaneSet.Lanes.Add(schemaGCalendarLane);
			ProcessSchemaStartEvent gcalendarsyncstart = CreateGCalendarSyncStartStartEvent();
			FlowElements.Add(gcalendarsyncstart);
			ProcessSchemaEndEvent gcalendarend = CreateGCalendarEndEndEvent();
			FlowElements.Add(gcalendarend);
			ProcessSchemaScriptTask scriptaftersynchronizationactions = CreateScriptAfterSynchronizationActionsScriptTask();
			FlowElements.Add(scriptaftersynchronizationactions);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("00920ff3-cc66-428f-a197-c73b0fdabf68"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("dfb20310-345a-4cff-8ffb-b0bcd8b45909"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("dd952b34-b543-4d41-8d3f-40dc21e3b090"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				CurveCenterPosition = new Point(416, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7b47ad9d-d5fb-40b6-ac42-a7171812ede0"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateGCalendarLaneSetLaneSet() {
			ProcessSchemaLaneSet schemaGCalendarLaneSet = new ProcessSchemaLaneSet(this) {
				UId = new Guid("6837e75c-f237-434b-8c69-6044a6fa68de"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"GCalendarLaneSet",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGCalendarLaneSet;
		}

		protected virtual ProcessSchemaLane CreateGCalendarLaneLane() {
			ProcessSchemaLane schemaGCalendarLane = new ProcessSchemaLane(this) {
				UId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("6837e75c-f237-434b-8c69-6044a6fa68de"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"GCalendarLane",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaGCalendarLane;
		}

		protected virtual ProcessSchemaStartEvent CreateGCalendarSyncStartStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("dfb20310-345a-4cff-8ffb-b0bcd8b45909"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"GCalendarSyncStart",
				Position = new Point(57, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateGCalendarEndEndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("7b47ad9d-d5fb-40b6-ac42-a7171812ede0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"GCalendarEnd",
				Position = new Point(295, 51),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptAfterSynchronizationActionsScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("3928caa6-d858-4f5f-8d47-110e6d6ee5df"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"),
				Name = @"ScriptAfterSynchronizationActions",
				Position = new Point(171, 37),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,239,106,194,48,16,255,172,224,59,4,63,85,40,125,1,183,129,214,63,8,235,144,86,31,32,164,183,54,144,38,114,185,56,187,177,119,95,170,110,182,78,97,251,148,228,238,247,143,187,236,57,178,194,152,66,65,86,107,81,162,209,242,29,144,61,178,88,113,107,23,92,144,193,58,90,2,61,44,99,174,64,231,28,219,192,167,64,195,27,139,141,182,132,174,193,78,176,112,21,104,10,134,206,2,250,134,6,65,210,232,97,200,182,157,194,104,52,30,244,9,107,246,49,232,247,126,39,136,90,143,160,129,246,154,66,10,214,41,242,233,188,157,212,69,180,48,88,113,10,46,88,222,72,103,174,170,56,214,33,243,172,91,210,147,60,135,60,5,97,48,183,43,61,93,39,113,154,196,198,105,10,111,140,34,218,238,114,78,119,240,119,12,102,160,128,254,97,209,13,180,60,2,206,232,59,14,215,161,58,156,63,36,106,225,155,225,126,50,193,73,148,44,56,213,175,230,57,63,8,216,53,23,6,7,49,58,46,172,179,140,19,41,49,185,124,149,94,199,3,103,62,220,179,4,187,49,102,193,113,165,55,37,172,185,165,57,162,193,182,93,75,249,134,46,68,9,88,203,11,104,40,131,126,10,149,212,185,95,123,6,184,7,220,146,84,146,188,73,20,35,120,191,159,246,180,94,163,17,158,25,116,127,92,200,132,209,4,7,138,206,253,239,51,19,37,84,60,122,225,21,132,236,146,32,100,218,41,21,50,255,179,161,25,18,2,57,212,199,231,248,11,11,14,73,11,55,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("02a2c391-b9e5-458f-97be-5f31bfb34fdd"),
				Name = "BPMSoft.GoogleServices",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("d781d71c-c204-4235-b9a7-5e63cc91fa88"),
				Name = "System.Linq",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("09812775-15d2-4b28-8dfa-1247c6e09efc"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("96fe1089-e710-4448-a36d-026252f860d4"),
				Name = "BPMSoft.Common.Json",
				Alias = "",
				CreatedInPackageId = new Guid("d96ae870-4bfc-40ec-921c-ada84236f3fa")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("03482141-0ed0-4738-9956-3b23bd2b8a52"),
				Name = "BPMSoft.Common",
				Alias = "",
				CreatedInPackageId = new Guid("54856cde-81f7-468d-b20f-cb4c9b5ac12a")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("69ea79be-f47b-4328-9ee9-47ca3fb10939"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("58f026cd-7097-44c3-b0b4-b701d5441970"),
				Name = "Google",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("03dd0606-0cb6-4aea-b109-17228eeea122"),
				Name = "System.Net",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("9e903017-569a-4c4b-a511-9dd65a193b2f"),
				Name = "BPMSoft.Core.Factories",
				Alias = "",
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new GCalendarSynchronizationModuleProcess(userConnection);
		}

		public override object Clone() {
			return new GCalendarSynchronizationModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89"));
		}

		#endregion

	}

	#endregion

	#region Class: GCalendarSynchronizationModuleProcess

	/// <exclude/>
	public class GCalendarSynchronizationModuleProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessGCalendarLane

		/// <exclude/>
		public class ProcessGCalendarLane : ProcessLane
		{

			public ProcessGCalendarLane(UserConnection userConnection, GCalendarSynchronizationModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public GCalendarSynchronizationModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GCalendarSynchronizationModuleProcess";
			SchemaUId = new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89");
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
				return new Guid("7b07594d-d4d5-4dfa-af4c-f04c390e7b89");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: GCalendarSynchronizationModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: GCalendarSynchronizationModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object ModifiedGEntities {
			get;
			set;
		}

		public virtual Object ModifiedBPMEntities {
			get;
			set;
		}

		public virtual DateTime CurrentSyncDateTime {
			get;
			set;
		}

		public virtual Object SyncProvider {
			get;
			set;
		}

		public virtual bool BPMIsAConflictResolver {
			get;
			set;
		}

		private Guid _defActivityCategory = new Guid("2365ae4f-58e6-df11-971b-001d60e938c6");
		public Guid DefActivityCategory {
			get {
				return _defActivityCategory;
			}
			set {
				_defActivityCategory = value;
			}
		}

		public virtual Object ResolvedConflictUIds {
			get;
			set;
		}

		public virtual DateTime LastSyncDate {
			get;
			set;
		}

		public virtual string GoogleAccountName {
			get;
			set;
		}

		public virtual string AccessToken {
			get;
			set;
		}

		public virtual string ActiveTreeGridClientId {
			get;
			set;
		}

		public virtual string SyncResult {
			get;
			set;
		}

		private LocalizableString _synchronizationSummaryLS;
		public virtual LocalizableString SynchronizationSummaryLS {
			get {
				return _synchronizationSummaryLS ?? (_synchronizationSummaryLS = GetLocalizableString("7b07594dd4d54dfaaf4cf04c390e7b89",
						 "Parameters.SynchronizationSummaryLS.Value"));
			}
			set {
				_synchronizationSummaryLS = value;
			}
		}

		private LocalizableString _synchronizationSummary;
		public virtual LocalizableString SynchronizationSummary {
			get {
				return _synchronizationSummary ?? (_synchronizationSummary = GetLocalizableString("7b07594dd4d54dfaaf4cf04c390e7b89",
						 "Parameters.SynchronizationSummary.Value"));
			}
			set {
				_synchronizationSummary = value;
			}
		}

		private LocalizableString _googleModificationDateLiesTooFarInThePastError;
		public virtual LocalizableString GoogleModificationDateLiesTooFarInThePastError {
			get {
				return _googleModificationDateLiesTooFarInThePastError ?? (_googleModificationDateLiesTooFarInThePastError = GetLocalizableString("7b07594dd4d54dfaaf4cf04c390e7b89",
						 "Parameters.GoogleModificationDateLiesTooFarInThePastError.Value"));
			}
			set {
				_googleModificationDateLiesTooFarInThePastError = value;
			}
		}

		private ProcessGCalendarLane _gCalendarLane;
		public ProcessGCalendarLane GCalendarLane {
			get {
				return _gCalendarLane ?? ((_gCalendarLane) = new ProcessGCalendarLane(UserConnection, this));
			}
		}

		private ProcessFlowElement _gCalendarSyncStart;
		public ProcessFlowElement GCalendarSyncStart {
			get {
				return _gCalendarSyncStart ?? (_gCalendarSyncStart = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "GCalendarSyncStart",
					SchemaElementUId = new Guid("dfb20310-345a-4cff-8ffb-b0bcd8b45909"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessEndEvent _gCalendarEnd;
		public ProcessEndEvent GCalendarEnd {
			get {
				return _gCalendarEnd ?? (_gCalendarEnd = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "GCalendarEnd",
					SchemaElementUId = new Guid("7b47ad9d-d5fb-40b6-ac42-a7171812ede0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptAfterSynchronizationActions;
		public ProcessScriptTask ScriptAfterSynchronizationActions {
			get {
				return _scriptAfterSynchronizationActions ?? (_scriptAfterSynchronizationActions = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAfterSynchronizationActions",
					SchemaElementUId = new Guid("2c97b53d-c716-4254-952b-6c9d5300bc6b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptAfterSynchronizationActionsExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[GCalendarSyncStart.SchemaElementUId] = new Collection<ProcessFlowElement> { GCalendarSyncStart };
			FlowElements[GCalendarEnd.SchemaElementUId] = new Collection<ProcessFlowElement> { GCalendarEnd };
			FlowElements[ScriptAfterSynchronizationActions.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAfterSynchronizationActions };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "GCalendarSyncStart":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptAfterSynchronizationActions", e.Context.SenderName));
						break;
					case "GCalendarEnd":
						CompleteProcess();
						break;
					case "ScriptAfterSynchronizationActions":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("GCalendarEnd", e.Context.SenderName));
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
			if (ModifiedGEntities != null) {
				if (ModifiedGEntities.GetType().IsSerializable ||
					ModifiedGEntities.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ModifiedGEntities", ModifiedGEntities, null);
				}
			}
			if (ModifiedBPMEntities != null) {
				if (ModifiedBPMEntities.GetType().IsSerializable ||
					ModifiedBPMEntities.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ModifiedBPMEntities", ModifiedBPMEntities, null);
				}
			}
			if (!HasMapping("CurrentSyncDateTime")) {
				writer.WriteValue("CurrentSyncDateTime", CurrentSyncDateTime, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (SyncProvider != null) {
				if (SyncProvider.GetType().IsSerializable ||
					SyncProvider.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("SyncProvider", SyncProvider, null);
				}
			}
			if (!HasMapping("BPMIsAConflictResolver")) {
				writer.WriteValue("BPMIsAConflictResolver", BPMIsAConflictResolver, false);
			}
			if (!HasMapping("DefActivityCategory")) {
				writer.WriteValue("DefActivityCategory", DefActivityCategory, Guid.Empty);
			}
			if (ResolvedConflictUIds != null) {
				if (ResolvedConflictUIds.GetType().IsSerializable ||
					ResolvedConflictUIds.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ResolvedConflictUIds", ResolvedConflictUIds, null);
				}
			}
			if (!HasMapping("LastSyncDate")) {
				writer.WriteValue("LastSyncDate", LastSyncDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("GoogleAccountName")) {
				writer.WriteValue("GoogleAccountName", GoogleAccountName, null);
			}
			if (!HasMapping("AccessToken")) {
				writer.WriteValue("AccessToken", AccessToken, null);
			}
			if (!HasMapping("ActiveTreeGridClientId")) {
				writer.WriteValue("ActiveTreeGridClientId", ActiveTreeGridClientId, null);
			}
			if (!HasMapping("SyncResult")) {
				writer.WriteValue("SyncResult", SyncResult, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("GCalendarSyncStart", string.Empty));
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
			MetaPathParameterValues.Add("6a170f99-0994-46d9-8dd1-983048f8a5da", () => PageInstanceId);
			MetaPathParameterValues.Add("53ff815d-bf48-4c18-92ed-065c25e47d7e", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("b53b4501-8253-47d0-af2f-1e41a8b9cfb2", () => ModifiedGEntities);
			MetaPathParameterValues.Add("3d2a46ec-1719-423b-a9cf-568038f56080", () => ModifiedBPMEntities);
			MetaPathParameterValues.Add("6181b599-3bb7-434a-bd13-b10613943f8f", () => CurrentSyncDateTime);
			MetaPathParameterValues.Add("a3699fdc-c28f-4afe-808f-096cd393ca2e", () => SyncProvider);
			MetaPathParameterValues.Add("41e320fe-fd3e-4926-942f-cc7facb78796", () => BPMIsAConflictResolver);
			MetaPathParameterValues.Add("0ba82835-fceb-4bad-b75d-d52fe03fa461", () => DefActivityCategory);
			MetaPathParameterValues.Add("8d1cdb9f-5c88-40f3-80ba-69dd9d1d9be2", () => ResolvedConflictUIds);
			MetaPathParameterValues.Add("97062d45-0d38-4cee-ba3c-9fece6c0a6f9", () => LastSyncDate);
			MetaPathParameterValues.Add("5b7f83bc-6e12-4a54-b45d-bc3970a3f965", () => GoogleAccountName);
			MetaPathParameterValues.Add("efefea24-99b5-4886-8785-53d0204c42ff", () => AccessToken);
			MetaPathParameterValues.Add("749d5d34-d42d-4f8b-857d-fbc373706b93", () => ActiveTreeGridClientId);
			MetaPathParameterValues.Add("3e8350ee-ed3a-4f83-8ed9-c1084d8f7bb9", () => SyncResult);
			MetaPathParameterValues.Add("e6c70236-656b-4a05-aab8-4b0cdf5536d0", () => SynchronizationSummaryLS);
			MetaPathParameterValues.Add("b4593900-7bc9-44b1-9dff-438141dd5fd1", () => SynchronizationSummary);
			MetaPathParameterValues.Add("4643ae2d-19f0-4db8-860b-87461d18677c", () => GoogleModificationDateLiesTooFarInThePastError);
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
				case "ModifiedGEntities":
					if (!hasValueToRead) break;
					ModifiedGEntities = reader.GetSerializableObjectValue();
				break;
				case "ModifiedBPMEntities":
					if (!hasValueToRead) break;
					ModifiedBPMEntities = reader.GetSerializableObjectValue();
				break;
				case "CurrentSyncDateTime":
					if (!hasValueToRead) break;
					CurrentSyncDateTime = reader.GetValue<System.DateTime>();
				break;
				case "SyncProvider":
					if (!hasValueToRead) break;
					SyncProvider = reader.GetSerializableObjectValue();
				break;
				case "BPMIsAConflictResolver":
					if (!hasValueToRead) break;
					BPMIsAConflictResolver = reader.GetValue<System.Boolean>();
				break;
				case "DefActivityCategory":
					if (!hasValueToRead) break;
					DefActivityCategory = reader.GetValue<System.Guid>();
				break;
				case "ResolvedConflictUIds":
					if (!hasValueToRead) break;
					ResolvedConflictUIds = reader.GetSerializableObjectValue();
				break;
				case "LastSyncDate":
					if (!hasValueToRead) break;
					LastSyncDate = reader.GetValue<System.DateTime>();
				break;
				case "GoogleAccountName":
					if (!hasValueToRead) break;
					GoogleAccountName = reader.GetValue<System.String>();
				break;
				case "AccessToken":
					if (!hasValueToRead) break;
					AccessToken = reader.GetValue<System.String>();
				break;
				case "ActiveTreeGridClientId":
					if (!hasValueToRead) break;
					ActiveTreeGridClientId = reader.GetValue<System.String>();
				break;
				case "SyncResult":
					if (!hasValueToRead) break;
					SyncResult = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptAfterSynchronizationActionsExecute(ProcessExecutingContext context) {
			var googleSynchronizer = ClassFactory.Get<GCalendarSynchronizer>(new ConstructorArgument("userConnection", UserConnection));
			try {
				googleSynchronizer.Synchronize();
				SyncResult = string.Format(SynchronizationSummary, 
					googleSynchronizer.AddedRecordsInBPMCRMCount, googleSynchronizer.UpdatedRecordsInBPMCRMCount,
					googleSynchronizer.DeletedRecordsInBPMCRMCount, googleSynchronizer.AddedRecordsInGoogleCount, 
					googleSynchronizer.UpdatedRecordsInGoogleCount, googleSynchronizer.DeletedRecordsInGoogleCount);
			} catch (GoogleSynchronizationException exc) {
				SyncResult = GoogleModificationDateLiesTooFarInThePastError;
			} catch (Exception e) {
				SyncResult = e.Message;
			}
			RemindingServerUtilities.CreateRemindingByProcess(UserConnection, context.Process.ProcessSchema.Name, SyncResult, null, true);
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
			var cloneItem = (GCalendarSynchronizationModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.ModifiedGEntities = ModifiedGEntities;
			cloneItem.ModifiedBPMEntities = ModifiedBPMEntities;
			cloneItem.SyncProvider = SyncProvider;
			cloneItem.ResolvedConflictUIds = ResolvedConflictUIds;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

