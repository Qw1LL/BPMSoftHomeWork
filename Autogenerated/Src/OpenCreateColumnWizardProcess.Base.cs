namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
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
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: OpenCreateColumnWizardProcessSchema

	/// <exclude/>
	public class OpenCreateColumnWizardProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public OpenCreateColumnWizardProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public OpenCreateColumnWizardProcessSchema(OpenCreateColumnWizardProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "OpenCreateColumnWizardProcess";
			UId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad");
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
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("78f55b98-0968-470a-970d-0ad5185fa34c"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("bf0e865d-f635-4c98-9902-5053187e4e34"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				SourcePath = @"UserConnection.ProcessEngine.GetEmbeddedEventsProcess(PageInstanceId).GetPropertyValue(""Page"")",
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreatePageParameter());
		}

		protected virtual void InitializeOpenCreateColumnWizardUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e1f7066c-e21c-4398-b7e5-ff650ce2238d"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			pageUIdParameter.SourceValue = new ProcessSchemaParameterValue(pageUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUIdParameter);
			var pageUrlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0f47b149-0a7d-45eb-afad-2ee38d1df383"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pageUrlParameter.SourceValue = new ProcessSchemaParameterValue(pageUrlParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUrlParameter);
			var openerInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("01d20c51-05a7-4e40-b459-8266ec226848"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"OpenerInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			openerInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(openerInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(openerInstanceIdParameter);
			var closeOpenerOnLoadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f788cf3d-f565-4327-a256-62d68beef461"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseOpenerOnLoad",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			closeOpenerOnLoadParameter.SourceValue = new ProcessSchemaParameterValue(closeOpenerOnLoadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeOpenerOnLoadParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("00350685-7f29-407c-b566-d0b29fd78fc5"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
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
			var widthParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("931b2e35-8723-4d03-a777-64085a3c7a6e"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Width",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			widthParameter.SourceValue = new ProcessSchemaParameterValue(widthParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(widthParameter);
			var closeMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("abeb135d-d973-4d98-bf5d-ced0e50d1399"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			closeMessageParameter.SourceValue = new ProcessSchemaParameterValue(closeMessageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeMessageParameter);
			var heightParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("433b37f6-ca64-4f51-9a07-030d1bb1a30d"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Height",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			heightParameter.SourceValue = new ProcessSchemaParameterValue(heightParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(heightParameter);
			var centeredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("daa3d180-ef77-41e2-b279-6edefd5f8229"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Centered",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			centeredParameter.SourceValue = new ProcessSchemaParameterValue(centeredParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(centeredParameter);
			var useOpenerRegisterScriptParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("65596c47-02a9-41df-9002-d6c261a3d099"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseOpenerRegisterScript",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useOpenerRegisterScriptParameter.SourceValue = new ProcessSchemaParameterValue(useOpenerRegisterScriptParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useOpenerRegisterScriptParameter);
			var useCurrentActivePageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("abd472c0-928d-41df-bc75-e83eeac9a566"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseCurrentActivePage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCurrentActivePageParameter.SourceValue = new ProcessSchemaParameterValue(useCurrentActivePageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useCurrentActivePageParameter);
			var ignoreProfileParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4db2480b-0bd7-4d13-936a-11c8a39d2453"),
				ContainerUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"IgnoreProfile",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreProfileParameter.SourceValue = new ProcessSchemaParameterValue(ignoreProfileParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreProfileParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet22 = CreateLaneSet22LaneSet();
			LaneSets.Add(schemaLaneSet22);
			ProcessSchemaLane schemaLane69 = CreateLane69Lane();
			schemaLaneSet22.Lanes.Add(schemaLane69);
			ProcessSchemaStartEvent startmessage = CreateStartMessageStartEvent();
			FlowElements.Add(startmessage);
			ProcessSchemaScriptTask scriptprepareopencolumnwizard = CreateScriptPrepareOpenColumnWizardScriptTask();
			FlowElements.Add(scriptprepareopencolumnwizard);
			ProcessSchemaUserTask opencreatecolumnwizardusertask = CreateOpenCreateColumnWizardUserTaskUserTask();
			FlowElements.Add(opencreatecolumnwizardusertask);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			FlowElements.Add(CreateSequenceFlow240SequenceFlow());
			FlowElements.Add(CreateSequenceFlow241SequenceFlow());
			FlowElements.Add(CreateSequenceFlow242SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow240SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow240",
				UId = new Guid("e580ece0-c6f7-4d6d-a1a7-259d82181bc4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				CurveCenterPosition = new Point(148, 77),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a968ab05-8211-4491-99c5-7c04c11ecc17"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("5c81bc7f-2811-483e-a243-bde02a52eb5a"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow241SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow241",
				UId = new Guid("d59f4927-f5f3-4868-a9e3-1b3e078eef85"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				CurveCenterPosition = new Point(303, 77),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5c81bc7f-2811-483e-a243-bde02a52eb5a"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow242SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow242",
				UId = new Guid("28c17e76-3a2a-4621-ab17-1cdfd3e83f7e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				CurveCenterPosition = new Point(463, 76),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e620ade0-dbfe-49a7-b69f-b27dfa62e5fe"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet22LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet22 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("19df4a3f-cb84-4808-a249-7c47fd7e83bd"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"LaneSet22",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet22;
		}

		protected virtual ProcessSchemaLane CreateLane69Lane() {
			ProcessSchemaLane schemaLane69 = new ProcessSchemaLane(this) {
				UId = new Guid("e6095aa3-e765-4ee6-a09e-3ea1d92e340b"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("19df4a3f-cb84-4808-a249-7c47fd7e83bd"),
				CreatedInOwnerSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"Lane69",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane69;
		}

		protected virtual ProcessSchemaStartEvent CreateStartMessageStartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("a968ab05-8211-4491-99c5-7c04c11ecc17"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6095aa3-e765-4ee6-a09e-3ea1d92e340b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"StartMessage",
				Position = new Point(50, 58),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptPrepareOpenColumnWizardScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("5c81bc7f-2811-483e-a243-bde02a52eb5a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6095aa3-e765-4ee6-a09e-3ea1d92e340b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"ScriptPrepareOpenColumnWizard",
				Position = new Point(148, 44),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,243,47,72,205,115,46,74,77,44,73,117,206,207,41,205,205,11,207,172,74,44,74,9,45,78,45,10,73,44,206,214,243,7,74,167,22,121,230,21,151,36,230,37,167,122,166,40,216,42,192,56,161,158,41,214,92,32,121,60,218,3,18,211,65,234,128,186,242,82,203,21,220,75,51,83,52,148,82,147,140,146,77,140,211,12,117,205,210,12,12,116,77,44,146,140,116,45,77,83,12,116,211,146,141,141,147,76,45,83,45,76,146,204,149,52,173,185,138,82,75,74,139,242,20,74,138,74,83,173,1,220,245,219,227,166,0,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenCreateColumnWizardUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6095aa3-e765-4ee6-a09e-3ea1d92e340b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"OpenCreateColumnWizardUserTask",
				Position = new Point(316, 44),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenCreateColumnWizardUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("e620ade0-dbfe-49a7-b69f-b27dfa62e5fe"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("e6095aa3-e765-4ee6-a09e-3ea1d92e340b"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"),
				Name = @"End1",
				Position = new Point(470, 58),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new OpenCreateColumnWizardProcess(userConnection);
		}

		public override object Clone() {
			return new OpenCreateColumnWizardProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad"));
		}

		#endregion

	}

	#endregion

	#region Class: OpenCreateColumnWizardProcess

	/// <exclude/>
	public class OpenCreateColumnWizardProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane69

		/// <exclude/>
		public class ProcessLane69 : ProcessLane
		{

			public ProcessLane69(UserConnection userConnection, OpenCreateColumnWizardProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenCreateColumnWizardUserTaskFlowElement

		/// <exclude/>
		public class OpenCreateColumnWizardUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenCreateColumnWizardUserTaskFlowElement(UserConnection userConnection, OpenCreateColumnWizardProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenCreateColumnWizardUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("7f62a51e-ecb0-4f65-afa0-b4d44d2d53c6");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public OpenCreateColumnWizardProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpenCreateColumnWizardProcess";
			SchemaUId = new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad");
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
				return new Guid("4f54f6c6-8dc5-4aed-a8b4-3c6bfbd1c8ad");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: OpenCreateColumnWizardProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: OpenCreateColumnWizardProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object Page {
			get;
			set;
		}

		private ProcessLane69 _lane69;
		public ProcessLane69 Lane69 {
			get {
				return _lane69 ?? ((_lane69) = new ProcessLane69(UserConnection, this));
			}
		}

		private ProcessFlowElement _startMessage;
		public ProcessFlowElement StartMessage {
			get {
				return _startMessage ?? (_startMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "StartMessage",
					SchemaElementUId = new Guid("a968ab05-8211-4491-99c5-7c04c11ecc17"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _scriptPrepareOpenColumnWizard;
		public ProcessScriptTask ScriptPrepareOpenColumnWizard {
			get {
				return _scriptPrepareOpenColumnWizard ?? (_scriptPrepareOpenColumnWizard = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptPrepareOpenColumnWizard",
					SchemaElementUId = new Guid("5c81bc7f-2811-483e-a243-bde02a52eb5a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptPrepareOpenColumnWizardExecute,
				});
			}
		}

		private OpenCreateColumnWizardUserTaskFlowElement _openCreateColumnWizardUserTask;
		public OpenCreateColumnWizardUserTaskFlowElement OpenCreateColumnWizardUserTask {
			get {
				return _openCreateColumnWizardUserTask ?? (_openCreateColumnWizardUserTask = new OpenCreateColumnWizardUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("e620ade0-dbfe-49a7-b69f-b27dfa62e5fe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage };
			FlowElements[ScriptPrepareOpenColumnWizard.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptPrepareOpenColumnWizard };
			FlowElements[OpenCreateColumnWizardUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenCreateColumnWizardUserTask };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptPrepareOpenColumnWizard", e.Context.SenderName));
						break;
					case "ScriptPrepareOpenColumnWizard":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenCreateColumnWizardUserTask", e.Context.SenderName));
						break;
					case "OpenCreateColumnWizardUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
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
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("StartMessage", string.Empty));
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
			MetaPathParameterValues.Add("78f55b98-0968-470a-970d-0ad5185fa34c", () => PageInstanceId);
			MetaPathParameterValues.Add("bf0e865d-f635-4c98-9902-5053187e4e34", () => Page);
			MetaPathParameterValues.Add("e1f7066c-e21c-4398-b7e5-ff650ce2238d", () => OpenCreateColumnWizardUserTask.PageUId);
			MetaPathParameterValues.Add("0f47b149-0a7d-45eb-afad-2ee38d1df383", () => OpenCreateColumnWizardUserTask.PageUrl);
			MetaPathParameterValues.Add("01d20c51-05a7-4e40-b459-8266ec226848", () => OpenCreateColumnWizardUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("f788cf3d-f565-4327-a256-62d68beef461", () => OpenCreateColumnWizardUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("00350685-7f29-407c-b566-d0b29fd78fc5", () => OpenCreateColumnWizardUserTask.PageParameters);
			MetaPathParameterValues.Add("931b2e35-8723-4d03-a777-64085a3c7a6e", () => OpenCreateColumnWizardUserTask.Width);
			MetaPathParameterValues.Add("abeb135d-d973-4d98-bf5d-ced0e50d1399", () => OpenCreateColumnWizardUserTask.CloseMessage);
			MetaPathParameterValues.Add("433b37f6-ca64-4f51-9a07-030d1bb1a30d", () => OpenCreateColumnWizardUserTask.Height);
			MetaPathParameterValues.Add("daa3d180-ef77-41e2-b279-6edefd5f8229", () => OpenCreateColumnWizardUserTask.Centered);
			MetaPathParameterValues.Add("65596c47-02a9-41df-9002-d6c261a3d099", () => OpenCreateColumnWizardUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("abd472c0-928d-41df-bc75-e83eeac9a566", () => OpenCreateColumnWizardUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("4db2480b-0bd7-4d13-936a-11c8a39d2453", () => OpenCreateColumnWizardUserTask.IgnoreProfile);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptPrepareOpenColumnWizardExecute(ProcessExecutingContext context) {
			OpenCreateColumnWizardUserTask.OpenerInstanceId = InstanceUId;
			OpenCreateColumnWizardUserTask.PageUId = new Guid("eb2c43f1-6f00-48b2-95d0-fc33b59e84b7");
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
			var cloneItem = (OpenCreateColumnWizardProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

