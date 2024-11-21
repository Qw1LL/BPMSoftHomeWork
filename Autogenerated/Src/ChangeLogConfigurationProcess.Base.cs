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

	#region Class: ChangeLogConfigurationProcessSchema

	/// <exclude/>
	public class ChangeLogConfigurationProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public ChangeLogConfigurationProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public ChangeLogConfigurationProcessSchema(ChangeLogConfigurationProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "ChangeLogConfigurationProcess";
			UId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6");
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
			RealUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("29ee49bd-375c-4b94-b85f-41144561bb2d"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreatePageParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("4c3f6cfd-a4e0-4ed8-ab28-135ca21cb39f"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"Page",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("8c94f218-e2a9-4e55-bd25-86726aa7b042"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"ActiveTreeGrid",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreatePageParameter());
			Parameters.Add(CreateActiveTreeGridParameter());
		}

		protected virtual void InitializeOpenChangelogConfigurationGridUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("71d8d49e-686e-4b15-9782-9114109196d0"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("a013d25e-f4e2-4667-927c-3abc6baa0703"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("76df3f04-6439-439e-ba32-4eb99b0572a8"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("bb1096ef-8880-4656-944f-4b89d713d8a7"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("ba063c09-03d3-491f-884f-6bafd84cb19a"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("0aef9e43-9378-4e08-9201-e37a4417e4aa"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("6acb5763-ae27-42df-a7e6-a10c836d7fa7"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("3d2dc031-a4c7-4790-b9d6-8b446c29a391"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("5ec0ad5a-24ab-463a-b4d6-645c12ce4db5"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("f3e1d654-1bb2-4e35-aa16-ae1fa95f2813"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("7dd2a314-7037-43f5-a2f6-57fd433a9ce1"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				UId = new Guid("e7898aab-6e88-4209-ba4f-c8aa84fc709e"),
				ContainerUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreProfileParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet56 = CreateLaneSet56LaneSet();
			LaneSets.Add(schemaLaneSet56);
			ProcessSchemaLane schemaLane159 = CreateLane159Lane();
			schemaLaneSet56.Lanes.Add(schemaLane159);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaEndEvent end1 = CreateEnd1EndEvent();
			FlowElements.Add(end1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			ProcessSchemaUserTask openchangelogconfigurationgridusertask = CreateOpenChangelogConfigurationGridUserTaskUserTask();
			FlowElements.Add(openchangelogconfigurationgridusertask);
			FlowElements.Add(CreateSequenceFlow502SequenceFlow());
			FlowElements.Add(CreateSequenceFlow503SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow502SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow502",
				UId = new Guid("c6158e5a-c50b-459c-a336-e050540b6c0d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("5dfe88e2-4ae2-49d9-8b45-d5432edec4b8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("61f803c7-b023-484a-a999-49b169d3c96b"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow503SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow503",
				UId = new Guid("e293c501-8a9e-4480-82e1-3b312e62b8e6"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				CurveCenterPosition = new Point(342, 204),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("61f803c7-b023-484a-a999-49b169d3c96b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("071ec38f-e974-4696-85ba-d767d9a5e2d8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				CurveCenterPosition = new Point(373, 199),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("fa05a51e-5c4d-4b43-91a3-b547173cecd6"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet56LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet56 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("fb362b30-2bbc-4563-bc45-f4a7a90452a2"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"LaneSet56",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet56;
		}

		protected virtual ProcessSchemaLane CreateLane159Lane() {
			ProcessSchemaLane schemaLane159 = new ProcessSchemaLane(this) {
				UId = new Guid("f5914ca8-4cc8-4ab3-8234-fba21f12d7a1"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("fb362b30-2bbc-4563-bc45-f4a7a90452a2"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"Lane159",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane159;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("5dfe88e2-4ae2-49d9-8b45-d5432edec4b8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f5914ca8-4cc8-4ab3-8234-fba21f12d7a1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"Start1",
				Position = new Point(57, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaEndEvent CreateEnd1EndEvent() {
			ProcessSchemaEndEvent schemaEndEvent = new ProcessSchemaEndEvent(this) {
				UId = new Guid("fa05a51e-5c4d-4b43-91a3-b547173cecd6"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f5914ca8-4cc8-4ab3-8234-fba21f12d7a1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("45ceaae2-4e1f-4c0c-86aa-cd4aeb4da913"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"End1",
				Position = new Point(652, 184),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaEndEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("61f803c7-b023-484a-a999-49b169d3c96b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f5914ca8-4cc8-4ab3-8234-fba21f12d7a1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"ScriptTask1",
				Position = new Point(197, 170),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,141,187,10,194,48,24,70,119,193,119,40,153,116,136,181,87,34,197,193,166,180,116,40,117,176,15,16,236,111,12,150,68,114,65,124,123,83,23,29,187,126,156,239,156,254,9,146,222,153,228,48,41,78,149,188,9,238,52,179,66,201,70,139,113,48,160,47,204,60,118,189,199,64,183,210,88,38,175,208,142,193,49,56,51,14,191,161,88,175,102,102,129,106,254,13,95,131,132,87,208,56,49,110,208,254,20,231,121,74,115,28,145,50,194,41,57,212,184,140,178,10,103,73,86,87,9,137,73,150,230,104,235,27,97,184,176,66,39,101,160,3,99,124,205,167,80,247,254,95,144,87,105,176,78,203,192,106,7,197,7,15,201,175,249,6,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenChangelogConfigurationGridUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("f5914ca8-4cc8-4ab3-8234-fba21f12d7a1"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"),
				Name = @"OpenChangelogConfigurationGridUserTask",
				Position = new Point(337, 170),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenChangelogConfigurationGridUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new ChangeLogConfigurationProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeLogConfigurationProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangeLogConfigurationProcess

	/// <exclude/>
	public class ChangeLogConfigurationProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane159

		/// <exclude/>
		public class ProcessLane159 : ProcessLane
		{

			public ProcessLane159(UserConnection userConnection, ChangeLogConfigurationProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenChangelogConfigurationGridUserTaskFlowElement

		/// <exclude/>
		public class OpenChangelogConfigurationGridUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenChangelogConfigurationGridUserTaskFlowElement(UserConnection userConnection, ChangeLogConfigurationProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenChangelogConfigurationGridUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("0e0315a7-7ed4-4b4e-b22b-79b87e46b447");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

			#endregion

		}

		#endregion

		public ChangeLogConfigurationProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangeLogConfigurationProcess";
			SchemaUId = new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6");
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
				return new Guid("487f002a-d78e-42e6-967d-98fedc9cceb6");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: ChangeLogConfigurationProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: ChangeLogConfigurationProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		public virtual Object ActiveTreeGrid {
			get;
			set;
		}

		private ProcessLane159 _lane159;
		public ProcessLane159 Lane159 {
			get {
				return _lane159 ?? ((_lane159) = new ProcessLane159(UserConnection, this));
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
					SchemaElementUId = new Guid("5dfe88e2-4ae2-49d9-8b45-d5432edec4b8"),
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
					SchemaElementUId = new Guid("fa05a51e-5c4d-4b43-91a3-b547173cecd6"),
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
					SchemaElementUId = new Guid("61f803c7-b023-484a-a999-49b169d3c96b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		private OpenChangelogConfigurationGridUserTaskFlowElement _openChangelogConfigurationGridUserTask;
		public OpenChangelogConfigurationGridUserTaskFlowElement OpenChangelogConfigurationGridUserTask {
			get {
				return _openChangelogConfigurationGridUserTask ?? (_openChangelogConfigurationGridUserTask = new OpenChangelogConfigurationGridUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[OpenChangelogConfigurationGridUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenChangelogConfigurationGridUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						break;
					case "End1":
						CompleteProcess();
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenChangelogConfigurationGridUserTask", e.Context.SenderName));
						break;
					case "OpenChangelogConfigurationGridUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("End1", e.Context.SenderName));
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (Page != null) {
				if (Page.GetType().IsSerializable ||
					Page.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Page", Page, null);
				}
			}
			if (ActiveTreeGrid != null) {
				if (ActiveTreeGrid.GetType().IsSerializable ||
					ActiveTreeGrid.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ActiveTreeGrid", ActiveTreeGrid, null);
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
			MetaPathParameterValues.Add("29ee49bd-375c-4b94-b85f-41144561bb2d", () => PageInstanceId);
			MetaPathParameterValues.Add("4c3f6cfd-a4e0-4ed8-ab28-135ca21cb39f", () => Page);
			MetaPathParameterValues.Add("8c94f218-e2a9-4e55-bd25-86726aa7b042", () => ActiveTreeGrid);
			MetaPathParameterValues.Add("71d8d49e-686e-4b15-9782-9114109196d0", () => OpenChangelogConfigurationGridUserTask.PageUId);
			MetaPathParameterValues.Add("a013d25e-f4e2-4667-927c-3abc6baa0703", () => OpenChangelogConfigurationGridUserTask.PageUrl);
			MetaPathParameterValues.Add("76df3f04-6439-439e-ba32-4eb99b0572a8", () => OpenChangelogConfigurationGridUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("bb1096ef-8880-4656-944f-4b89d713d8a7", () => OpenChangelogConfigurationGridUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("ba063c09-03d3-491f-884f-6bafd84cb19a", () => OpenChangelogConfigurationGridUserTask.PageParameters);
			MetaPathParameterValues.Add("0aef9e43-9378-4e08-9201-e37a4417e4aa", () => OpenChangelogConfigurationGridUserTask.Width);
			MetaPathParameterValues.Add("6acb5763-ae27-42df-a7e6-a10c836d7fa7", () => OpenChangelogConfigurationGridUserTask.CloseMessage);
			MetaPathParameterValues.Add("3d2dc031-a4c7-4790-b9d6-8b446c29a391", () => OpenChangelogConfigurationGridUserTask.Height);
			MetaPathParameterValues.Add("5ec0ad5a-24ab-463a-b4d6-645c12ce4db5", () => OpenChangelogConfigurationGridUserTask.Centered);
			MetaPathParameterValues.Add("f3e1d654-1bb2-4e35-aa16-ae1fa95f2813", () => OpenChangelogConfigurationGridUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("7dd2a314-7037-43f5-a2f6-57fd433a9ce1", () => OpenChangelogConfigurationGridUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("e7898aab-6e88-4209-ba4f-c8aa84fc709e", () => OpenChangelogConfigurationGridUserTask.IgnoreProfile);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "Page":
					if (!hasValueToRead) break;
					Page = reader.GetSerializableObjectValue();
				break;
				case "ActiveTreeGrid":
					if (!hasValueToRead) break;
					ActiveTreeGrid = reader.GetSerializableObjectValue();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			OpenChangelogConfigurationGridUserTask.OpenerInstanceId = PageInstanceId;
			OpenChangelogConfigurationGridUserTask.PageUId = new Guid("0A2664C6-18B1-489F-B15D-535FD3828546");
			//OpenChangelogConfigurationGridUserTask.CloseMessage = "MyCloseMessage";
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
			var cloneItem = (ChangeLogConfigurationProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			cloneItem.Page = Page;
			cloneItem.ActiveTreeGrid = ActiveTreeGrid;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

