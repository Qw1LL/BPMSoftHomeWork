namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
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

	#region Class: ActualizeBulkEmailRecipientsSchema

	/// <exclude/>
	public class ActualizeBulkEmailRecipientsSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ActualizeBulkEmailRecipientsSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ActualizeBulkEmailRecipientsSchema(ActualizeBulkEmailRecipientsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ActualizeBulkEmailRecipients";
			UId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481");
			CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.6.0.0";
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481");
			Version = 0;
			PackageUId = new Guid("789c617e-760f-4576-a608-ee12728eae0a");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateSessionKeyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ccf30a79-ff5e-451c-98a5-2d4d6cf1299a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"SessionKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("ShortText"),
			};
		}

		protected virtual ProcessSchemaParameter CreateLOGGERParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4449f3bb-5841-48c7-a613-6d90a9b7f456"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"LOGGER",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateSessionKeyParameter());
			Parameters.Add(CreateLOGGERParameter());
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
			ProcessSchemaScriptTask scriptmain = CreateScriptMainScriptTask();
			FlowElements.Add(scriptmain);
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("f1fca63b-3ea2-4f68-ba94-89dcf46af738"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CurveCenterPosition = new Point(373, 203),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("77f33242-6f7d-4ced-8c74-7346cfe812d0"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("af84af2a-d656-4916-8437-11132ba775d9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("0022e166-b714-4a74-a4ee-65379bbfa3b4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CurveCenterPosition = new Point(527, 208),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("af84af2a-d656-4916-8437-11132ba775d9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d3d157f1-a25d-44fb-a96d-539664c943d0"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("b13ff23e-a247-494f-9649-f91b05c59347"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"LaneSet1",
				Position = new Point(5, 5),
				Size = new Size(882, 400),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("f86465b4-1339-4651-87fe-38b2d48028bc"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("b13ff23e-a247-494f-9649-f91b05c59347"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"Lane1",
				Position = new Point(29, 0),
				Size = new Size(853, 400),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("77f33242-6f7d-4ced-8c74-7346cfe812d0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f86465b4-1339-4651-87fe-38b2d48028bc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = false,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"Start1",
				Position = new Point(50, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("d3d157f1-a25d-44fb-a96d-539664c943d0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f86465b4-1339-4651-87fe-38b2d48028bc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = false,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"Terminate1",
				Position = new Point(600, 184),
				SerializeToDB = false,
				Size = new Size(0, 0),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptMainScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("af84af2a-d656-4916-8437-11132ba775d9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f86465b4-1339-4651-87fe-38b2d48028bc"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = false,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Name = @"ScriptMain",
				OwnerSchemaManagerName = @"ProcessSchemaManager",
				Position = new Point(295, 170),
				SerializeToDB = false,
				Size = new Size(0, 0),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,77,204,204,211,208,180,230,229,42,74,45,41,45,202,83,40,41,42,77,181,6,0,176,217,148,41,21,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
			Methods.Add(CreateMainMethod());
			Methods.Add(CreateLogErrorMethod());
			Methods.Add(CreateGetLoggerMethod());
			Methods.Add(CreateDeleteOutdatedDataMethod());
			Methods.Add(CreateProcessTriggerEmailsMethod());
			Methods.Add(CreateProcessMassEmailsMethod());
			Methods.Add(CreateInitialEmailsToProccessMethod());
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("e3484efc-ebe3-4366-a991-1b0729f90297"),
				Name = "BPMSoft.Configuration.MandrillService",
				Alias = "",
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("cc216601-e3bc-4db4-a328-21462c6c475e"),
				Name = "System.Data",
				Alias = "",
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("1cfb36b4-606d-4fea-9001-ac2a86966701"),
				Name = "BPMSoft.Configuration",
				Alias = "",
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			});
		}

		protected virtual SchemaMethod CreateMainMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("85bd34ee-281a-40d1-bda5-17a9704e8550"),
				Name = "Main",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				ResultValueTypeName = "void"
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,65,106,195,64,12,69,215,245,41,68,86,14,20,251,0,161,155,198,37,43,99,131,147,238,213,25,217,21,76,102,90,73,19,112,78,223,113,161,180,208,141,224,243,254,127,168,109,219,243,208,13,112,197,21,222,8,236,157,132,128,21,148,162,43,49,65,86,2,79,51,220,48,228,66,102,112,41,71,3,250,204,24,20,238,36,9,170,27,10,120,92,143,223,228,9,106,142,182,127,30,251,41,205,214,28,147,80,57,113,230,37,11,26,167,216,76,171,78,100,198,113,209,166,122,56,145,189,110,238,250,162,36,165,24,201,109,173,71,216,245,24,189,112,8,147,149,157,26,187,203,135,71,163,145,132,147,239,112,213,221,254,80,141,146,28,169,158,133,151,133,228,229,138,28,180,254,121,230,151,247,168,250,31,118,20,200,104,200,182,121,139,210,240,15,253,2,123,218,55,242,27,1,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateLogErrorMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("29558aa7-8144-490a-b708-32f83c335ed4"),
				Name = "LogError",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("61d978b6-aa02-4c1c-93ba-8689cc50b2a0"),
				Name = "message",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "string",
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472")
			});
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("6b10f63d-c22b-4f14-b46f-da91d8e98fc8"),
				Name = "e",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Exception",
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,43,75,44,82,200,201,79,79,79,45,82,176,85,112,79,45,241,1,179,53,52,173,185,32,162,122,174,69,69,249,69,26,37,25,153,197,122,126,137,185,169,10,218,10,74,86,10,209,74,64,58,56,181,184,56,51,63,207,59,181,18,36,24,171,0,18,203,5,138,37,166,131,85,89,43,233,40,164,106,90,3,0,131,238,231,16,97,0,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateGetLoggerMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("998d222e-95a7-4fa7-96ae-03134231f511"),
				Name = "GetLogger",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("35882ed5-b82b-46d1-974a-718c2ed2f472"),
				ResultValueTypeName = "global::Common.Logging.ILog"
			};
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,142,77,10,194,48,16,133,215,205,41,66,87,201,38,7,104,233,74,74,16,107,10,214,11,68,140,49,144,31,73,82,165,72,239,110,26,90,93,185,122,51,195,123,239,155,39,247,80,59,41,133,135,13,236,122,74,219,19,228,1,74,237,46,92,87,213,206,25,227,44,233,146,67,89,73,246,105,168,129,186,65,180,101,26,104,71,173,49,124,131,226,91,243,39,156,244,200,45,79,30,66,69,92,174,194,163,120,87,129,48,110,4,174,65,177,242,155,245,163,26,204,153,21,162,207,240,192,18,170,247,173,121,196,9,13,34,4,229,236,65,76,56,211,127,123,202,211,81,93,9,19,175,69,17,38,103,55,228,10,84,178,50,113,102,224,69,28,189,221,48,31,183,168,15,183,4,1,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateDeleteOutdatedDataMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("c3a19e27-b010-44cd-8bc6-550d4b0f297b"),
				Name = "DeleteOutdatedData",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("96c06f30-d70a-40c7-996f-8be019477bf7"),
				Name = "dayCount",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "int",
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,93,107,219,48,20,125,118,32,255,65,228,73,134,33,210,183,177,46,131,58,118,70,32,163,93,150,173,143,67,177,238,26,49,89,242,36,185,77,40,253,239,189,178,236,36,14,99,244,97,193,241,199,213,213,57,231,222,123,180,146,206,127,148,218,127,34,219,70,253,46,42,46,213,122,41,28,153,17,13,79,100,213,175,210,244,122,60,250,6,10,74,79,202,29,148,49,243,107,3,246,208,165,198,69,250,221,129,157,27,173,241,93,26,157,142,71,9,155,27,213,84,154,78,16,119,210,6,22,214,84,116,146,245,124,49,120,191,3,11,52,101,197,30,57,29,197,80,146,252,19,23,127,108,99,106,122,213,127,244,60,29,77,8,69,166,47,92,11,43,149,90,67,41,107,9,218,31,215,35,233,73,74,43,145,45,93,241,167,225,234,92,226,59,18,229,183,82,111,173,0,155,29,110,92,137,69,245,152,115,211,4,96,194,93,39,25,27,54,30,121,236,207,51,238,105,156,212,15,132,230,89,177,135,178,241,198,18,177,61,190,206,200,176,58,86,104,215,88,200,179,83,136,166,105,139,211,3,45,115,238,249,26,56,10,33,54,62,102,151,131,97,145,0,98,26,61,17,246,88,201,211,78,42,32,52,2,176,144,119,228,73,146,129,31,216,141,16,23,51,96,121,182,57,212,128,129,71,176,30,247,231,217,15,174,26,216,152,165,246,61,230,103,240,109,144,78,211,52,88,8,113,95,194,61,220,240,255,66,74,238,203,29,161,197,190,132,58,160,18,232,4,172,204,67,97,173,177,116,178,64,13,32,136,55,68,106,233,37,87,68,96,241,228,23,118,174,84,192,45,241,80,213,36,40,13,173,241,124,171,192,225,192,32,240,33,199,120,132,153,192,3,11,58,121,96,115,4,28,218,62,114,227,245,136,176,14,91,5,226,206,154,18,4,142,163,247,249,48,122,209,20,244,137,119,245,207,28,29,224,161,247,221,109,227,81,49,136,48,179,73,219,133,11,104,118,47,253,238,142,91,94,225,46,75,207,37,189,33,93,240,67,107,190,244,58,40,239,29,247,255,44,151,156,246,225,25,171,42,172,106,35,43,48,141,71,152,171,247,211,105,156,235,165,200,206,125,231,190,107,19,219,209,191,97,238,206,91,44,128,45,140,173,184,63,119,129,104,155,75,58,23,224,9,255,155,1,24,57,63,212,31,200,243,244,5,61,49,232,108,103,145,214,135,227,209,43,12,10,91,97,9,5,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateProcessTriggerEmailsMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("a488f38b-423a-48c9-a734-84522a1bc039"),
				Name = "ProcessTriggerEmails",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("b60dbddb-cf7a-40ca-b7f9-0d6859902d49"),
				Name = "dayCount",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "int",
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,65,75,195,64,16,133,207,17,252,15,67,79,91,40,161,222,68,241,96,107,132,130,130,104,197,163,140,187,99,92,76,118,203,236,68,173,210,255,238,36,209,198,234,197,203,102,119,152,55,239,203,155,23,100,120,104,170,231,162,70,95,165,133,75,112,2,139,224,197,99,213,151,150,241,138,163,181,148,146,185,68,126,38,241,161,156,199,144,36,229,75,246,101,73,76,174,235,156,125,79,153,163,80,25,121,189,112,227,227,253,189,199,200,132,246,9,140,15,50,56,93,47,28,248,176,235,60,134,143,253,189,76,120,221,125,179,23,37,75,162,106,215,2,144,107,152,148,45,208,43,220,236,86,205,109,34,86,164,64,86,124,12,19,24,73,90,221,159,90,105,176,242,239,244,69,121,169,46,138,126,77,214,175,60,5,73,163,150,46,203,126,89,228,119,94,158,174,144,177,38,33,54,63,129,255,211,239,112,61,143,77,144,190,183,73,234,8,230,108,86,188,145,109,84,8,238,97,123,61,129,93,238,188,8,73,7,158,205,134,146,25,247,153,100,217,160,203,231,177,174,49,184,165,175,41,54,162,99,14,14,167,211,206,238,15,91,175,33,51,168,123,174,141,30,27,176,40,237,94,138,55,75,171,214,13,232,203,237,34,150,5,115,100,147,132,245,7,242,243,200,53,138,25,157,107,14,228,64,34,84,17,29,56,20,108,31,219,197,47,145,75,18,208,141,131,10,219,208,129,186,229,230,67,143,230,120,4,31,211,205,104,2,29,242,78,192,19,69,104,1,149,111,243,9,120,80,227,171,153,2,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateProcessMassEmailsMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("97e856b7-7a63-446f-b502-109f5a632dea"),
				Name = "ProcessMassEmails",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc"),
				ResultValueTypeName = "void"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("ce7241aa-abbd-42c2-a08c-3dd8c1d06bbf"),
				Name = "dayCount",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "int",
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,65,107,219,64,16,133,207,10,228,63,12,62,173,193,200,46,244,80,26,114,168,109,5,12,53,9,137,74,143,97,178,59,181,150,72,187,102,118,148,198,13,254,239,157,141,218,168,110,47,189,72,218,199,204,188,239,141,246,9,25,30,250,246,177,234,208,183,105,227,18,92,194,38,120,241,216,14,82,29,111,56,90,75,41,153,45,242,35,137,15,187,85,12,73,82,185,197,148,114,141,42,203,223,35,86,40,180,139,124,216,184,233,197,249,217,183,200,132,182,1,227,131,140,54,183,27,7,62,156,218,78,225,229,252,172,16,62,188,190,139,249,124,94,95,175,175,161,174,238,106,120,15,210,232,28,101,235,72,154,232,160,33,166,92,245,164,240,73,212,195,101,70,114,61,147,226,7,250,14,119,167,170,249,146,136,149,58,144,21,31,195,12,38,146,246,247,159,172,244,216,250,31,148,131,108,135,32,183,100,253,222,83,144,52,201,1,138,226,175,249,229,87,47,205,13,50,42,10,177,249,51,211,255,212,59,60,172,98,31,100,168,237,147,58,130,89,47,171,103,178,189,54,130,123,120,251,188,132,83,232,178,10,73,7,174,151,163,100,166,195,218,138,98,236,43,87,177,235,48,184,218,119,20,123,209,49,239,62,44,22,175,118,255,176,13,61,100,198,238,129,235,168,143,35,88,148,252,235,170,103,75,251,236,6,244,203,237,115,220,85,204,145,77,18,214,0,229,85,228,14,197,76,174,116,15,228,64,34,180,17,29,56,20,204,135,183,187,81,35,239,72,202,81,208,165,125,132,151,197,113,50,59,185,28,211,153,90,101,16,229,56,254,4,193,43,42,32,161,2,0,0 };
			return method;
		}

		protected virtual SchemaMethod CreateInitialEmailsToProccessMethod() {
			SchemaMethod method = new SchemaMethod() {
				UId = new Guid("921c066d-a600-4bf9-8829-cd6a6ef96b9f"),
				Name = "InitialEmailsToProccess",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc"),
				ResultValueTypeName = "List<int>"
			};
			method.Arguments.Add(new SchemaMethodArgument() {
				UId = new Guid("8be56cf3-11fa-41dc-b1a5-0d3737f5c353"),
				Name = "emailCategoryId",
				CreatedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				ModifiedInSchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"),
				Direction = BPMSoft.Common.ParameterDirection.Input,
				ValueTypeName = "Guid",
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			});
			method.ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,77,143,218,48,16,61,131,196,127,24,113,114,164,85,104,207,91,42,241,17,42,36,208,110,33,109,207,38,158,13,214,26,59,181,39,187,160,106,255,123,39,31,4,104,213,30,54,82,18,103,236,247,102,60,239,57,43,29,232,147,182,244,25,118,165,121,78,14,82,155,205,82,5,24,131,197,87,88,157,103,69,116,63,232,143,70,35,72,31,230,15,176,117,158,96,119,2,143,153,46,52,90,10,144,185,210,18,60,57,15,59,157,131,146,36,7,253,45,26,204,8,176,34,13,95,75,244,167,150,182,153,16,223,2,250,153,179,150,199,218,217,104,208,239,197,51,103,202,131,21,67,174,97,88,7,22,222,29,196,112,122,174,173,9,254,216,163,71,94,132,161,112,54,224,163,119,25,134,160,109,62,115,135,194,32,33,131,227,101,72,126,150,210,136,134,50,126,148,94,30,120,202,139,39,105,2,70,53,209,196,42,49,156,73,194,220,249,211,242,191,168,122,23,151,165,87,248,45,73,42,67,131,182,130,195,189,191,192,107,233,159,145,234,2,109,160,16,119,251,105,176,11,109,117,216,163,98,218,187,247,224,183,228,138,226,253,240,9,247,255,5,175,247,20,197,201,145,165,15,226,223,106,197,169,43,196,199,168,83,172,21,140,175,86,179,181,180,202,107,99,182,236,143,53,203,35,115,228,14,181,210,117,21,108,110,186,126,37,244,29,52,38,136,64,134,182,4,182,32,177,135,126,113,154,178,82,27,196,124,154,28,49,43,137,109,167,118,221,112,12,183,181,198,137,13,165,199,249,244,18,18,204,91,241,156,137,150,115,118,236,6,165,66,207,174,174,95,227,107,227,198,13,57,54,75,196,37,89,212,242,244,94,247,218,32,136,6,28,87,235,186,28,189,222,205,217,138,39,74,253,209,205,120,62,77,79,5,114,224,5,61,43,198,223,223,165,41,49,117,75,75,103,206,47,72,117,80,124,136,162,234,56,50,239,91,245,172,30,124,191,65,38,41,219,131,72,142,25,22,21,43,96,91,192,202,229,137,247,206,139,225,130,107,64,5,228,128,45,71,90,154,250,168,214,231,214,56,169,170,94,240,92,167,66,42,125,142,196,90,96,149,144,147,120,164,210,219,219,127,197,253,111,131,83,222,22,68,4,0,0 };
			return method;
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ActualizeBulkEmailRecipients(userConnection);
		}

		public override object Clone() {
			return new ActualizeBulkEmailRecipientsSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481"));
		}

		#endregion

	}

	#endregion

	#region Class: ActualizeBulkEmailRecipients

	/// <exclude/>
	public class ActualizeBulkEmailRecipients : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, ActualizeBulkEmailRecipients process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		public ActualizeBulkEmailRecipients(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActualizeBulkEmailRecipients";
			SchemaUId = new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = false;
			IsLogging = false;
			UseSystemSecurityContext = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("61c36017-c6ff-42bf-a2dc-e8d28ab4e481");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ActualizeBulkEmailRecipients, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ActualizeBulkEmailRecipients, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public virtual string SessionKey {
			get;
			set;
		}

		public virtual Object LOGGER {
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
					SchemaElementUId = new Guid("77f33242-6f7d-4ced-8c74-7346cfe812d0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("d3d157f1-a25d-44fb-a96d-539664c943d0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptMain;
		public ProcessScriptTask ScriptMain {
			get {
				return _scriptMain ?? (_scriptMain = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptMain",
					SchemaElementUId = new Guid("af84af2a-d656-4916-8437-11132ba775d9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					Script = ScriptMainExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ScriptMain.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptMain };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptMain", e.Context.SenderName));
						break;
					case "Terminate1":
						CompleteProcess();
						break;
					case "ScriptMain":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("SessionKey")) {
				writer.WriteValue("SessionKey", SessionKey, null);
			}
			if (LOGGER != null) {
				if (LOGGER.GetType().IsSerializable ||
					LOGGER.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("LOGGER", LOGGER, null);
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
			MetaPathParameterValues.Add("ccf30a79-ff5e-451c-98a5-2d4d6cf1299a", () => SessionKey);
			MetaPathParameterValues.Add("4449f3bb-5841-48c7-a613-6d90a9b7f456", () => LOGGER);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "SessionKey":
					if (!hasValueToRead) break;
					SessionKey = reader.GetValue<System.String>();
				break;
				case "LOGGER":
					if (!hasValueToRead) break;
					LOGGER = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptMainExecute(ProcessExecutingContext context) {
			Main();
			return true;
		}

		public virtual void Main() {
			///TODO may be there is sence to use def value if count equals zero 
			var dayCount = (int)BPMSoft.Core.Configuration.SysSettings.
				GetValue(UserConnection, "MandrillStatisticUpdatePeriodDays");
			ProcessTriggerEmails(dayCount);
			ProcessMassEmails(dayCount);
			DeleteOutdatedData(dayCount);
		}

		public virtual void LogError(string message, Exception e) {
			var logger = GetLogger();
			logger.Error(this.Name + ": [" + SessionKey + "] " + message + ";", e);
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

		public virtual void DeleteOutdatedData(int dayCount) {
			List<int> bulkEmailRIds = new List<int>();
			Select checkEmailQuery = new Select(UserConnection)
				.Column("RId")
				.From("BulkEmail")
				.Where().Exists(
						new Select(UserConnection)
							.Top(1)
							.Column("Id")
							.From("MandrillRecipient")
							.Where("BulkEmailRId").IsEqual("BulkEmail", "RId"))
				.OrderByAsc("RecipientCount") as Select;
			
			try {
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = checkEmailQuery.ExecuteReader(dbExecutor)) {
						while (reader.Read()) {
							bulkEmailRIds.Add(UserConnection.DBTypeConverter.DBValueToInt(reader.GetValue(0)));
						}
					}
				}
			} catch (Exception e) {
					LogError("Failed to initial data for clear temp mailing tables", e);
			}
			
			foreach (int bulkEmailRId in bulkEmailRIds) {
				
				var storedProcedure = new StoredProcedure(UserConnection, "tsp_DeleteMandrillOutdatedData");
				storedProcedure.WithParameter(bulkEmailRId);
				storedProcedure.WithParameter(dayCount);	
				try {
					using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
						dbExecutor.CommandTimeout = 1800;
						storedProcedure.Execute(dbExecutor);
					}
				} catch (Exception e) {
					LogError(string.Format("Failed to delete  data from temp mailing tables. BulkEmailRId: {0}", bulkEmailRId), e);
				}
			}
		}

		public virtual void ProcessTriggerEmails(int dayCount) {
			var bulkEmailsIds = InitialEmailsToProccess(MarketingConsts.TriggeredEmailBulkEmailCategoryId);
			foreach (int bulkEmailRId in bulkEmailsIds) {
				try {
					var storedProcedure = new StoredProcedure(UserConnection, "tsp_ActualizeTriggerMailingRecipients");
					storedProcedure.WithParameter(bulkEmailRId);
					storedProcedure.WithParameter(dayCount);
					using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
						dbExecutor.CommandTimeout = 1800;
						storedProcedure.Execute(dbExecutor);
					}
				} catch (Exception e) {
					LogError(string.Format("Failed to load data to BulkEmailTarget for trigger emails. BulkEmailRId: {0}", 
						bulkEmailRId), e);
				}
			}
		}

		public virtual void ProcessMassEmails(int dayCount) {
			var bulkEmailsIds = InitialEmailsToProccess(MarketingConsts.MassmailingBulkEmailCategoryId);
			foreach (int bulkEmailRId in bulkEmailsIds) {
				try {
					///TODO TEST 4 threads method here
					var storedProcedure = new StoredProcedure(UserConnection, "tsp_ActualizeMassMailingRecipients");
					storedProcedure.WithParameter(bulkEmailRId);
					storedProcedure.WithParameter(dayCount);
					using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
						dbExecutor.CommandTimeout = 1800;
						storedProcedure.Execute(dbExecutor);
					}
				} catch (Exception e) {
					LogError(string.Format("Failed to load data to BulkEmailTarget. BulkEmailRId: {0}", bulkEmailRId), e);
				}
			}
		}

		public virtual List<int> InitialEmailsToProccess(Guid emailCategoryId) {
			List<int> bulkEmailRIds = new List<int>();
			/// TODO Sort by recipients count for big data
			Select emailsQuery = new Select(UserConnection)
				.Column("RId")
				.From("BulkEmail")
				.Where("ResponseProcessingCompleted").IsEqual(Column.Parameter(false))
				.And("CategoryId").IsEqual(Column.Parameter(emailCategoryId))
				.And("StatusId").In(
					Column.Parameter(MarketingConsts.BulkEmailStatusFinishedId),
					Column.Parameter(MarketingConsts.BulkEmailStatusStoppedId),
					Column.Parameter(MarketingConsts.BulkEmailStatusActiveId))
				.And().Exists(new Select(UserConnection).Top(1).Column("Id")
							.From("MandrillSentMessage").Where("BulkEmailRId").IsEqual("BulkEmail", "RId")) as Select;
			try {
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = emailsQuery.ExecuteReader(dbExecutor)) {
						while (reader.Read()) {
							bulkEmailRIds.Add(UserConnection.DBTypeConverter.DBValueToInt(reader.GetValue(0)));
						}
					}
				}
			} catch (Exception e) {
					LogError("Failed to initial data for loading to BulkEmailTarget", e);
			}
			return bulkEmailRIds;
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
			var cloneItem = (ActualizeBulkEmailRecipients)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.LOGGER = LOGGER;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

