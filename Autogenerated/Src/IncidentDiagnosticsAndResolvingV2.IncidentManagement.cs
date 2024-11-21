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

	#region Class: IncidentDiagnosticsAndResolvingV2Schema

	/// <exclude/>
	public class IncidentDiagnosticsAndResolvingV2Schema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public IncidentDiagnosticsAndResolvingV2Schema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public IncidentDiagnosticsAndResolvingV2Schema(IncidentDiagnosticsAndResolvingV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "IncidentDiagnosticsAndResolvingV2";
			UId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb");
			CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"7.7.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsActiveVersion = false;
			IsCreatedInSvg = true;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = true;
			SerializeToMemory = true;
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			Version = 1;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb");
			Version = 1;
			PackageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateProcessUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("415d89df-f50f-46b6-8a77-b034e8173608"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ProcessUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"Guid.Parse(""6AEEED31-5D8C-452E-B157-ED9AD8B83E57"")",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsTaskExistsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ecd8a32c-df30-44e9-89f6-3adc6c3bdfd8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"IsTaskExists",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"false",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNotStartedActivityStatusIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ec21229b-9b25-49d7-92ad-eed18aa728e5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"NotStartedActivityStatusId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#Lookup.805aace4-8604-40e7-a9eb-0f54174593c0.384d4b84-58e6-df11-971b-001d60e938c6#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentTaskIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ae73a291-5391-4398-ad71-c61091bd78fe"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"CurrentTaskId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateTaskCaptionParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("7cdb4564-160f-4dc7-afbd-a2d9ac97aa23"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"TaskCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateTaskCaptionValueParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a0a5e89d-ee0e-4227-948e-7fcad6fbb49e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("391f4991-86a6-4a6d-9a3e-b08a114cc7d3"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"TaskCaptionValue",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateActivityDueDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("77719740-2177-4b8a-b22a-54a091ab6496"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ActivityDueDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActivityStartDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("aa6b400d-ea76-4b36-a31a-03f5695b31dc"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ActivityStartDate",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime"),
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreateProcessUIdParameter());
			Parameters.Add(CreateIsTaskExistsParameter());
			Parameters.Add(CreateNotStartedActivityStatusIdParameter());
			Parameters.Add(CreateCurrentTaskIdParameter());
			Parameters.Add(CreateTaskCaptionParameter());
			Parameters.Add(CreateTaskCaptionValueParameter());
			Parameters.Add(CreateActivityDueDateParameter());
			Parameters.Add(CreateActivityStartDateParameter());
		}

		protected virtual void InitializeCreatedNewIncidentStartSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("eb69a7f3-6d56-4292-8246-38c29e406529"),
				ContainerUId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b7921a8f-2af8-4912-99a2-e91f94ee1377"),
				ContainerUId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeModifiedInactiveIncidentStartSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ad68430c-33cb-4b0e-9767-a62d05a705bb"),
				ContainerUId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("133eafbe-3f14-4fbf-8b65-546fedfd2878"),
				ContainerUId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"117d32f9-8275-4534-8411-1c66115ce9cd",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
		}

		protected virtual void InitializeAddDiagnoseTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("47381106-439b-48de-a3be-7347358ad7d6"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"EntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2e5068e9-10ba-4629-9ad3-a2262e2be850"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b0c3a7d0-eda7-45fa-93f0-1e0bd05d687d"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordAddMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			recordAddModeParameter.SourceValue = new ProcessSchemaParameterValue(recordAddModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("2ff06d85-70bf-4fe3-84cb-f040ea533588"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"FilterEntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			filterEntitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(filterEntitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fb5c9609-3001-46fb-999e-e8f79c1d2ce2"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordDefValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordDefValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordDefValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,153,91,111,83,71,16,199,191,138,117,224,141,172,181,247,75,222,40,80,41,18,180,17,161,188,16,30,102,119,103,131,133,99,71,246,49,85,26,229,187,247,127,156,4,18,74,115,81,21,10,138,253,144,200,39,103,118,103,103,230,55,51,59,57,233,30,247,199,71,220,109,119,191,236,190,218,155,183,126,252,108,190,224,241,238,98,94,120,185,28,191,156,23,154,78,254,162,60,229,93,90,208,33,247,188,120,75,211,21,47,95,78,150,253,214,232,178,80,183,213,61,254,180,254,91,183,253,238,164,219,233,249,240,143,157,138,149,173,97,142,217,122,65,46,70,97,139,38,145,155,179,34,135,76,213,72,85,154,139,16,46,243,233,234,112,246,138,123,218,165,254,67,183,125,210,173,87,195,2,37,42,219,40,40,193,82,101,97,141,118,130,74,172,34,86,75,58,25,174,202,196,238,116,171,91,150,15,124,72,235,77,47,9,91,155,106,52,90,144,45,69,216,44,149,200,169,58,17,73,233,98,53,165,22,211,32,124,254,254,23,193,119,143,94,206,231,31,87,71,227,228,21,107,25,161,191,210,216,190,234,32,178,76,78,88,153,21,123,91,125,41,114,220,156,42,214,91,35,92,100,47,106,83,74,164,0,109,165,84,213,75,78,38,22,255,232,253,176,81,157,44,143,166,116,252,246,95,247,123,90,250,201,167,73,127,60,42,212,243,193,124,113,60,126,51,31,213,249,153,244,209,21,55,92,150,63,217,63,243,229,126,183,189,255,109,111,158,255,222,91,155,233,170,63,175,186,114,191,219,218,239,246,230,171,69,25,86,51,248,242,252,146,210,235,13,214,175,124,245,245,194,119,120,50,91,77,167,231,79,158,83,79,23,47,94,60,158,215,73,155,112,221,153,237,93,184,108,189,138,60,255,192,106,255,248,113,241,57,211,237,191,136,189,162,25,29,240,226,55,28,255,139,238,159,181,124,3,19,94,44,156,117,114,50,168,38,2,83,18,150,189,70,204,41,18,73,165,220,76,48,186,53,189,150,126,205,141,23,60,43,124,85,177,219,68,206,185,252,114,109,237,1,154,115,189,6,83,157,118,167,167,91,151,81,66,92,133,26,216,9,37,171,18,86,213,34,98,178,85,120,153,115,74,206,7,110,233,90,148,154,12,198,55,50,34,164,97,129,224,165,32,246,73,36,207,197,249,148,140,77,234,62,80,122,183,179,252,253,207,25,47,206,236,179,221,104,186,228,247,99,60,253,234,193,139,41,31,242,172,223,62,137,205,5,203,46,139,224,181,133,162,90,139,36,225,4,83,154,119,200,26,153,40,158,66,224,115,24,111,159,4,114,138,108,212,162,20,239,97,28,23,4,5,239,132,12,181,17,39,150,205,231,65,228,197,172,7,93,207,214,54,130,148,244,90,86,68,11,91,38,97,225,95,145,26,236,106,93,208,173,84,228,24,5,169,155,208,125,205,84,193,235,146,71,21,129,52,254,117,178,88,246,163,9,252,54,154,183,209,130,151,171,105,63,153,29,140,224,152,41,3,239,249,108,252,116,185,156,28,204,152,55,88,255,116,88,43,159,217,120,167,68,108,172,135,64,75,144,175,32,41,74,83,173,143,166,86,115,39,172,61,234,67,115,25,26,184,97,65,141,82,151,29,194,23,145,235,20,98,183,73,69,215,98,157,27,81,42,161,137,98,60,74,172,149,56,145,81,208,72,5,239,101,163,166,108,124,88,88,123,147,124,179,158,69,177,169,9,219,50,188,229,36,122,6,109,163,79,173,73,155,205,125,96,253,108,62,235,169,244,27,170,55,84,35,222,44,15,133,63,86,131,52,163,67,94,243,40,60,103,14,172,157,247,100,175,165,218,134,98,107,177,1,145,171,177,64,149,44,8,197,91,52,157,98,206,90,22,52,190,15,139,106,98,201,214,21,26,168,70,27,213,24,82,38,85,97,40,7,29,34,43,175,194,125,80,189,83,55,64,255,124,64,163,87,198,75,40,206,58,32,88,156,177,34,90,220,203,20,34,78,41,87,56,149,122,167,50,45,217,197,96,137,69,32,137,152,109,140,114,18,179,19,26,48,23,163,109,50,229,250,50,13,154,155,36,163,68,104,53,0,104,84,124,146,210,162,245,84,38,171,0,13,205,255,218,125,95,230,179,212,108,157,183,66,161,127,128,170,5,164,181,92,5,233,154,168,164,64,164,215,245,243,201,104,191,27,61,218,239,158,252,200,105,35,228,88,216,103,43,116,66,238,176,18,135,201,76,67,147,149,91,200,200,178,210,210,205,105,227,13,45,63,34,109,28,13,25,225,202,193,239,158,79,126,91,29,102,94,108,114,202,119,207,41,168,29,198,181,117,103,12,126,108,241,136,159,228,73,24,52,237,228,169,81,105,229,186,156,114,107,197,110,155,83,82,67,214,24,232,170,20,204,48,219,66,147,208,112,151,240,236,107,108,197,100,153,111,184,209,103,89,125,195,173,85,5,68,180,37,164,19,82,14,19,50,155,49,142,42,190,202,135,214,250,103,229,140,212,37,1,239,130,141,106,130,69,26,14,133,187,153,132,185,169,54,86,247,114,163,47,101,190,154,109,90,255,159,175,83,208,174,134,162,40,11,85,89,162,83,24,48,24,238,208,82,163,223,116,20,116,245,124,199,78,193,84,237,67,16,184,190,131,106,137,105,119,194,138,34,89,203,153,50,53,163,245,245,157,130,196,192,152,113,34,229,50,38,2,222,32,99,229,236,5,74,151,9,129,178,45,41,255,40,157,66,8,42,5,28,78,43,28,216,230,136,241,190,198,140,223,33,23,37,24,213,219,228,111,198,237,98,232,253,124,197,112,241,102,42,246,253,33,170,90,33,165,54,43,138,68,219,103,165,210,240,35,102,215,141,20,69,21,84,37,107,191,107,105,108,1,165,209,180,40,130,11,160,186,105,131,48,206,13,195,238,152,149,135,78,58,155,107,33,26,194,157,156,137,194,43,140,127,108,146,97,24,237,54,33,85,242,73,121,212,131,90,127,16,136,136,208,158,74,204,167,24,5,14,187,25,252,207,192,32,131,73,204,5,125,114,217,96,212,127,123,136,246,122,90,244,27,140,190,197,195,131,192,232,253,233,223,100,146,53,0,216,29,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("15433e0e-c833-4c29-9b51-7ec388ba323f"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("66971b22-af85-40d4-8000-b58148d0d4b7"),
				ContainerUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeReadCaseDataParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e20c98d0-9d0e-407b-930b-a6b43f524e3c"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,79,219,64,16,253,43,145,207,44,178,247,203,222,220,218,52,173,56,80,80,65,92,8,135,245,238,56,89,213,95,90,59,80,26,229,191,119,108,135,52,160,64,67,37,84,85,194,167,245,232,205,204,155,217,157,55,171,192,228,186,105,190,234,2,130,113,240,241,252,244,162,202,218,227,207,46,111,193,127,241,213,178,14,142,130,6,188,211,185,251,9,118,176,79,173,107,63,233,86,163,195,106,246,219,127,22,140,103,251,34,204,130,163,89,224,90,40,26,68,160,67,108,164,180,194,80,98,68,70,9,207,76,66,82,17,102,36,78,89,18,243,88,113,154,169,1,185,63,244,164,42,106,237,97,200,208,7,207,250,227,229,125,221,1,35,52,152,30,226,154,170,220,24,89,71,161,153,150,58,205,193,226,127,235,151,128,166,214,187,2,43,129,75,87,192,185,246,152,169,139,83,117,38,4,101,58,111,58,84,14,89,59,253,81,123,104,26,87,149,47,83,203,151,69,185,139,69,119,216,254,110,200,132,61,195,14,121,174,219,69,31,224,4,73,173,123,142,31,230,115,15,115,221,186,219,93,10,223,225,190,199,29,214,59,116,176,120,63,87,58,95,194,78,206,199,117,76,116,221,14,229,12,233,17,224,221,124,113,96,165,219,110,253,169,88,138,198,250,1,124,80,196,189,252,169,68,227,109,103,24,98,60,28,103,193,245,73,115,118,87,130,191,48,11,40,244,208,177,155,99,180,62,49,76,115,40,160,108,199,43,165,109,162,88,12,68,106,161,8,215,210,144,84,166,33,97,212,68,145,136,51,46,132,89,163,195,150,208,120,5,169,84,58,206,24,193,230,75,194,169,162,36,161,92,18,150,24,170,128,135,82,80,181,190,25,136,187,166,206,245,253,213,150,223,196,3,62,39,59,42,225,110,228,74,227,44,146,56,254,6,166,242,182,191,117,252,208,77,178,48,145,97,20,17,5,33,39,92,72,32,169,209,138,68,140,49,97,5,19,73,242,62,20,207,12,197,97,189,123,31,138,151,134,194,64,6,148,135,148,88,202,129,112,41,41,81,84,38,36,100,70,210,148,67,162,109,248,100,40,180,149,9,103,161,33,140,153,148,240,52,4,162,98,25,19,45,169,13,133,142,67,145,166,207,13,197,105,101,93,230,112,42,92,169,77,119,173,219,209,24,221,185,118,49,66,69,71,161,30,161,78,184,121,9,240,100,94,186,129,201,171,185,51,58,63,171,193,227,187,232,197,42,218,47,242,143,182,67,39,35,190,170,218,161,15,91,17,154,232,6,15,59,111,74,91,160,130,178,148,36,34,65,145,160,138,227,155,66,161,85,93,205,145,145,25,235,82,172,113,59,118,74,117,81,45,189,217,108,164,102,88,139,127,181,240,254,193,34,123,205,118,218,187,31,14,81,252,255,83,205,95,45,205,239,215,119,253,218,235,123,67,221,121,75,165,88,7,235,95,1,166,224,188,58,11,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fa34df5c-7b4e-47ae-a912-474e470b6c45"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultTypeParameter.SourceValue = new ProcessSchemaParameterValue(resultTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("90e6fe3b-6a23-4699-9d12-17cb6e9231df"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ReadSomeTopRecords",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			readSomeTopRecordsParameter.SourceValue = new ProcessSchemaParameterValue(readSomeTopRecordsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f4188d8f-b976-4570-97fc-41b0f9be5bfc"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"NumberOfRecords",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			numberOfRecordsParameter.SourceValue = new ProcessSchemaParameterValue(numberOfRecordsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dfebf7b5-d60e-4831-b0d2-43813be0a77d"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"FunctionType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			functionTypeParameter.SourceValue = new ProcessSchemaParameterValue(functionTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9adc4f45-21a7-4b76-9422-1980c48bcf46"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"AggregationColumnName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			aggregationColumnNameParameter.SourceValue = new ProcessSchemaParameterValue(aggregationColumnNameParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7754467c-fdaa-4a75-8546-a1292b5a6ded"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"OrderInfo",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			orderInfoParameter.SourceValue = new ProcessSchemaParameterValue(orderInfoParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,212,241,76,177,50,176,50,0,0,237,33,101,51,17,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("7a51a482-cc66-4157-a765-07dfae9e0f6b"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultEntity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityDataValueType")
			};
			resultEntityParameter.SourceValue = new ProcessSchemaParameterValue(resultEntityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f5018c00-5f7e-48d6-bf73-d4ce6cbf8adf"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultCountParameter.SourceValue = new ProcessSchemaParameterValue(resultCountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCountParameter);
			var resultIntegerFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cad8e278-2b4a-4f1b-8ccf-55db9d72df60"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultIntegerFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultIntegerFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultIntegerFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultIntegerFunctionParameter);
			var resultFloatFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("31c46bd6-ea7c-4f58-8530-fa76fa4e672f"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultFloatFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Float4")
			};
			resultFloatFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultFloatFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultFloatFunctionParameter);
			var resultDateTimeFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("81e76ac5-083c-40f7-a7a6-1a58511ec988"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultDateTimeFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime")
			};
			resultDateTimeFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultDateTimeFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDateTimeFunctionParameter);
			var resultRowsCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f3ab54a9-d46b-470b-9dd7-8f28314883aa"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultRowsCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultRowsCountParameter.SourceValue = new ProcessSchemaParameterValue(resultRowsCountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultRowsCountParameter);
			var canReadUncommitedDataParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("29febfab-7d22-4313-9fce-288ec640e85f"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"CanReadUncommitedData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			canReadUncommitedDataParameter.SourceValue = new ProcessSchemaParameterValue(canReadUncommitedDataParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("c73dce7a-814b-4024-bd5d-023c0ae8ff38"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultEntityCollection",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityCollectionDataValueType")
			};
			resultEntityCollectionParameter.SourceValue = new ProcessSchemaParameterValue(resultEntityCollectionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d2d9806f-75cc-4f82-957f-a0faf091d697"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"EntityColumnMetaPathes",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			entityColumnMetaPathesParameter.SourceValue = new ProcessSchemaParameterValue(entityColumnMetaPathesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("80b7264a-0735-4862-9f54-b35f79ae6dba"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"IgnoreDisplayValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreDisplayValuesParameter.SourceValue = new ProcessSchemaParameterValue(ignoreDisplayValuesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("deb1676b-e3ed-4d08-b4d4-40bb2d5e2294"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultCompositeObjectList",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("CompositeObjectList")
			};
			resultCompositeObjectListParameter.SourceValue = new ProcessSchemaParameterValue(resultCompositeObjectListParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("852a79b3-d625-4f18-b6ee-e2a25dd3c9b6"),
				ContainerUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeResolvedCatchSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("78f519cc-f8d2-4fac-9f87-2dc4c245ab29"),
				ContainerUId = new Guid("b64d7413-4571-4a80-9683-fa8ed03cf197"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b64d7413-4571-4a80-9683-fa8ed03cf197"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8f574e5b-7624-4722-90a9-3cf65d30baa8}].[Parameter:{7a51a482-cc66-4157-a765-07dfae9e0f6b}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeResolvedChangeDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("92796a3d-edaa-47bf-9730-0fb84a1bcb7f"),
				ContainerUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("69f7d295-e143-42e8-bb3c-c2f6f0421146"),
				ContainerUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("792c5022-ebba-44b5-955b-42c816843971"),
				ContainerUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,79,219,64,16,254,43,145,207,44,242,218,139,31,185,81,160,21,135,22,164,32,46,132,195,236,122,54,89,225,151,118,215,180,20,229,191,119,108,135,52,180,17,77,171,62,144,154,67,98,127,249,102,246,155,231,62,6,170,4,231,62,64,133,193,52,120,115,249,126,214,104,127,248,214,148,30,237,59,219,116,109,112,16,56,180,6,74,243,25,139,17,63,43,140,63,5,15,100,240,56,255,106,63,15,166,243,93,30,230,193,193,60,48,30,43,71,12,50,200,85,170,69,162,144,137,88,43,38,162,56,101,178,136,4,211,160,34,93,64,42,49,230,35,115,183,235,147,166,106,193,226,120,194,224,92,15,143,87,15,109,79,228,4,168,129,98,92,83,175,193,184,151,224,206,106,144,37,22,244,238,109,135,4,121,107,42,138,4,175,76,133,151,96,233,164,222,79,211,67,68,210,80,186,158,85,162,246,103,159,90,139,206,153,166,126,89,90,217,85,245,54,151,204,113,243,186,22,19,14,10,123,230,37,248,229,224,224,156,68,173,6,141,199,139,133,197,5,120,115,191,45,225,14,31,6,222,126,185,35,131,130,234,115,13,101,135,91,103,62,143,227,4,90,63,134,51,30,79,4,107,22,203,61,35,221,100,235,71,193,70,4,182,79,228,189,60,238,212,31,37,4,222,247,192,232,227,233,113,30,220,156,187,139,143,53,218,153,90,98,5,99,198,110,15,9,253,6,216,248,159,62,2,166,49,68,57,103,71,49,125,137,56,207,24,20,41,103,42,225,97,206,101,145,102,26,87,183,163,14,227,218,18,30,174,55,199,157,116,214,98,237,39,30,220,221,228,252,116,32,245,233,163,191,34,20,42,7,17,51,197,143,36,19,97,18,49,25,74,201,82,46,143,242,40,3,158,115,77,101,166,15,217,164,42,206,242,20,128,37,105,92,48,145,10,201,242,84,32,11,115,201,181,130,12,179,255,111,10,102,30,124,231,104,119,212,198,45,247,27,136,253,210,184,163,161,120,244,226,68,172,165,140,63,19,227,38,218,212,80,190,246,41,25,130,122,26,141,33,85,235,110,43,155,133,81,80,94,180,104,41,147,131,232,112,119,51,60,235,162,126,232,108,211,248,113,148,54,98,142,21,85,195,120,170,192,86,37,16,164,72,128,107,150,8,29,82,37,98,234,126,41,99,86,132,145,44,18,20,153,86,253,146,163,251,164,87,61,107,58,171,214,221,235,198,139,228,151,174,136,127,208,244,63,179,207,119,246,202,62,213,127,45,251,239,207,174,182,87,90,189,217,247,123,232,183,21,242,175,143,232,42,88,125,1,74,211,73,71,229,9,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("59ead31f-77ed-48f6-a880-82e8bb04a642"),
				ContainerUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,219,48,16,252,21,131,201,209,52,248,18,31,190,181,205,37,64,82,24,117,155,75,156,195,146,92,54,66,101,201,176,164,0,169,225,127,47,173,216,141,221,103,128,162,135,2,229,65,2,87,59,179,203,89,142,54,228,188,123,92,33,153,146,215,179,235,121,147,186,201,155,102,141,147,217,186,9,216,182,147,171,38,64,85,126,6,95,225,12,214,176,196,14,215,55,80,245,216,94,149,109,55,30,29,131,200,152,156,63,12,223,200,244,118,67,46,59,92,126,184,140,153,153,91,203,192,7,79,147,22,146,42,144,142,130,49,130,90,19,80,0,216,130,37,200,224,208,84,253,178,190,198,14,102,208,221,147,233,134,12,108,153,32,216,104,85,114,129,122,101,61,85,198,121,234,32,104,170,20,23,73,42,169,3,8,178,29,147,54,220,227,18,134,162,71,96,165,92,180,82,80,80,33,80,229,25,167,222,197,130,90,224,34,40,1,46,89,183,3,239,243,159,129,183,103,87,77,243,169,95,77,44,43,0,2,42,106,53,83,84,49,52,20,28,122,202,82,161,184,81,133,147,129,77,148,143,222,91,155,104,97,81,211,152,56,167,206,240,156,196,120,212,12,157,180,65,159,221,237,10,197,178,93,85,240,120,243,211,122,175,66,87,62,148,221,227,168,237,160,235,219,44,238,114,85,101,229,227,19,126,117,50,136,99,134,205,226,105,154,11,50,93,252,120,158,251,247,124,16,234,116,162,167,195,92,144,241,130,204,155,126,29,118,108,50,111,46,142,218,30,10,12,41,223,108,15,211,203,145,186,175,170,125,228,2,58,56,36,30,194,77,44,83,137,241,178,158,31,134,54,176,176,253,202,186,125,247,56,172,167,222,254,4,118,13,53,124,196,245,219,124,252,231,222,191,118,249,62,75,120,32,246,194,21,204,240,68,13,130,163,10,117,190,182,145,3,117,220,249,36,141,20,41,137,1,253,14,19,174,177,14,120,218,216,75,238,206,30,223,14,106,239,108,179,239,107,39,213,150,108,183,227,99,51,169,40,132,21,152,40,51,153,85,21,144,27,66,43,104,84,34,198,164,188,135,88,252,210,76,128,210,136,144,128,130,200,199,82,38,177,108,5,173,40,55,145,75,131,30,157,214,127,209,76,82,56,31,153,70,154,92,145,203,91,161,40,176,228,169,45,48,102,45,147,112,202,78,48,41,173,120,17,178,214,59,155,203,252,239,112,1,128,74,141,5,104,93,240,24,210,11,205,148,117,237,171,110,212,164,17,236,109,53,153,103,109,186,178,169,71,169,233,235,255,166,250,247,76,245,146,59,244,59,83,221,109,191,0,225,143,220,87,251,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("007d344c-9adf-43d3-8cdf-38202c99461b"),
				ContainerUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeCanceledCatchSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9e2aacd6-9c62-4726-94bc-1859bba3cced"),
				ContainerUId = new Guid("1ae2d9da-9762-47c2-8ddd-7f67b805d1fb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("1ae2d9da-9762-47c2-8ddd-7f67b805d1fb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8f574e5b-7624-4722-90a9-3cf65d30baa8}].[Parameter:{7a51a482-cc66-4157-a765-07dfae9e0f6b}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeCanceledChangeDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("183ecb6a-29e5-46cc-83dd-a8ec060bc191"),
				ContainerUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("58ab220b-a239-4004-a8b3-362b8616d6b5"),
				ContainerUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cb23be2e-d56f-4c76-8277-bea8232dc232"),
				ContainerUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,111,218,64,16,254,43,200,231,108,100,239,26,219,203,45,77,210,42,135,54,72,68,185,132,28,102,237,49,172,226,151,118,215,105,105,196,127,239,216,6,74,90,148,210,170,143,72,229,0,246,199,55,51,223,188,118,159,188,180,0,107,63,64,137,222,196,123,51,125,63,171,115,119,250,86,23,14,205,59,83,183,141,119,226,89,52,26,10,253,25,179,1,191,204,180,187,0,7,100,240,52,255,106,63,247,38,243,67,30,230,222,201,220,211,14,75,75,12,50,0,197,211,48,144,17,83,92,33,11,69,224,51,37,69,204,146,24,253,32,11,67,161,178,100,96,30,118,125,94,151,13,24,28,34,244,206,243,254,241,102,213,116,196,128,128,180,167,104,91,87,27,80,116,18,236,101,5,170,192,140,222,157,105,145,32,103,116,73,153,224,141,46,113,10,134,34,117,126,234,14,34,82,14,133,237,88,5,230,238,242,83,99,208,90,93,87,47,75,43,218,178,218,231,146,57,238,94,55,98,252,94,97,199,156,130,91,246,14,174,72,212,186,215,120,182,88,24,92,128,211,143,251,18,30,112,213,243,142,171,29,25,100,212,159,91,40,90,220,139,249,60,143,115,104,220,144,206,16,158,8,70,47,150,71,102,186,171,214,143,146,229,4,54,91,242,81,30,15,234,231,17,129,143,29,48,248,216,62,206,189,187,43,123,253,177,66,51,75,151,88,194,80,177,251,83,66,191,1,118,254,39,79,128,177,0,46,3,54,22,244,21,10,153,48,200,226,128,165,81,224,203,64,101,113,146,227,250,126,208,161,109,83,192,234,118,23,238,188,53,6,43,55,114,96,31,70,87,23,61,169,43,31,253,21,137,68,160,18,138,113,129,17,11,125,63,96,74,41,96,153,200,85,146,98,200,195,204,167,54,211,135,108,198,121,154,38,10,21,147,145,228,68,14,19,150,160,20,108,28,65,28,197,145,136,165,244,255,183,45,152,57,112,173,165,179,163,210,118,121,220,66,28,87,198,3,3,21,240,23,55,98,35,101,248,25,105,59,202,117,5,197,107,223,146,62,169,237,106,244,165,218,76,91,81,47,116,10,197,117,131,134,42,217,139,246,15,15,195,179,41,234,150,206,212,181,27,86,105,39,230,44,165,110,104,71,29,216,235,132,140,199,82,5,92,48,154,115,201,66,229,115,38,57,87,44,135,44,19,65,156,160,159,71,212,83,186,79,58,213,179,186,53,233,102,122,237,112,145,252,210,21,241,15,134,254,103,206,243,131,179,114,76,247,95,203,249,247,103,143,182,87,218,189,217,247,231,208,111,107,228,95,95,209,181,183,254,2,88,20,179,49,229,9,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1546ad35-5335-436b-9a67-31666d57fea3"),
				ContainerUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,219,48,16,252,21,131,205,209,52,248,126,248,214,38,151,0,73,97,212,109,46,113,14,75,114,217,24,149,45,195,146,3,164,134,255,189,180,34,55,118,159,1,138,30,10,148,7,73,164,118,102,151,59,59,91,114,214,62,174,144,140,201,155,201,245,180,206,237,232,188,94,227,104,178,174,35,54,205,232,170,142,80,205,63,67,168,112,2,107,88,96,139,235,27,168,54,216,92,205,155,118,56,56,6,145,33,57,123,232,254,145,241,237,150,92,182,184,248,112,153,10,51,68,157,65,102,164,33,235,64,21,218,76,131,101,146,10,27,180,151,201,139,16,100,1,199,186,218,44,150,215,216,194,4,218,123,50,222,146,142,173,16,68,151,156,202,62,210,160,92,33,176,62,80,15,209,80,165,184,200,82,73,19,65,144,221,144,52,241,30,23,208,37,61,2,43,229,147,147,130,130,138,145,170,192,56,13,62,105,234,128,139,168,4,248,236,252,30,220,199,63,3,111,95,93,213,245,167,205,106,228,152,6,136,168,168,51,76,81,197,208,82,240,24,40,203,90,113,171,202,29,34,27,9,198,99,14,224,168,118,104,104,202,156,83,111,121,9,98,60,25,134,94,186,104,94,221,237,19,165,121,179,170,224,241,230,167,249,94,199,118,254,48,111,31,7,77,11,237,166,25,157,195,50,98,133,233,9,190,58,209,225,152,96,59,123,18,115,70,198,179,31,203,217,191,167,93,159,78,5,61,213,114,70,134,51,50,173,55,235,184,103,147,101,115,113,84,117,151,160,11,249,102,123,16,175,156,44,55,85,213,159,92,64,11,135,192,195,113,157,230,121,142,233,114,57,61,104,214,177,176,126,149,182,125,247,56,172,167,218,254,4,118,13,75,248,136,235,183,229,250,207,181,127,173,242,125,105,225,129,56,8,175,153,229,153,90,4,95,70,215,8,234,18,7,234,185,15,89,90,41,114,22,29,250,29,102,92,99,209,233,180,176,151,140,78,143,111,186,110,239,93,211,215,181,111,213,142,236,118,195,99,47,89,97,128,57,231,169,5,201,11,161,118,197,85,130,209,104,12,115,1,52,87,204,253,210,75,128,210,138,152,129,130,40,215,82,54,179,226,4,163,40,183,137,75,139,1,189,49,127,209,75,82,248,144,152,65,154,189,46,233,157,80,20,88,14,212,105,76,165,151,89,120,229,70,41,132,204,144,51,154,149,9,148,171,242,101,180,119,123,47,105,157,152,146,130,169,23,122,169,244,117,83,181,131,58,15,160,119,213,127,59,177,127,214,78,47,153,158,223,217,233,110,247,5,227,194,240,149,244,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("393ddbb7-7225-496c-8519-19de2a93f2c6"),
				ContainerUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializePendingCatchSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("159c71ef-be09-4085-8d00-3c67a436bd4b"),
				ContainerUId = new Guid("d7674af7-e199-4c72-821d-36401cba0d75"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d7674af7-e199-4c72-821d-36401cba0d75"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8f574e5b-7624-4722-90a9-3cf65d30baa8}].[Parameter:{7a51a482-cc66-4157-a765-07dfae9e0f6b}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializePendingChangeDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("9ceb65d0-c08f-4758-80c4-0eb931174b9b"),
				ContainerUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2e50cca2-8933-4280-8cbf-18fdb137ab50"),
				ContainerUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fa758883-6271-4b3c-bbfa-6cbee86d2b5b"),
				ContainerUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,111,218,64,16,254,43,200,231,108,228,197,111,110,41,161,21,135,54,72,68,185,132,28,198,246,44,172,226,151,118,215,105,105,196,127,239,216,6,74,90,43,117,171,62,144,202,1,236,143,111,103,190,121,238,179,149,100,160,245,7,200,209,154,88,111,22,239,151,165,48,151,111,101,102,80,189,83,101,93,89,23,150,70,37,33,147,159,49,237,240,89,42,205,53,24,160,3,207,171,175,231,87,214,100,213,103,97,101,93,172,44,105,48,215,196,160,3,28,33,112,226,64,176,48,138,99,230,2,247,89,236,10,135,113,91,56,126,192,133,199,197,184,99,246,155,158,150,121,5,10,59,15,173,113,209,62,222,110,171,134,200,9,72,90,138,212,101,177,7,157,70,130,158,21,16,103,152,210,187,81,53,18,100,148,204,41,18,188,149,57,46,64,145,167,198,78,217,64,68,18,144,233,134,149,161,48,179,79,149,66,173,101,89,188,46,45,171,243,226,148,75,199,241,248,186,23,99,183,10,27,230,2,204,166,53,48,39,81,187,86,227,213,122,173,112,13,70,62,157,74,120,196,109,203,27,150,59,58,144,82,125,238,32,171,241,196,231,203,56,166,80,153,46,156,206,61,17,148,92,111,6,70,122,204,214,143,130,29,19,88,29,200,131,44,246,234,31,251,4,62,53,64,103,227,240,184,178,238,231,250,230,99,129,106,153,108,48,135,46,99,15,151,132,126,3,28,237,79,158,1,3,7,198,17,103,158,67,95,174,19,133,12,210,128,179,196,231,118,196,227,52,8,5,238,30,58,29,82,87,25,108,239,142,238,166,181,82,88,152,145,1,253,56,154,95,183,164,38,125,244,23,6,190,143,152,122,204,179,93,42,78,232,186,44,116,99,242,226,138,136,123,232,133,0,9,149,153,62,141,225,72,8,63,20,41,67,114,199,220,148,71,44,78,29,206,2,199,230,78,232,251,192,67,247,127,155,130,165,1,83,107,218,29,133,212,155,97,3,49,44,141,61,13,197,199,175,78,196,94,74,247,51,146,122,36,100,1,217,185,79,73,27,212,97,52,218,84,237,187,45,43,215,50,129,236,166,66,69,153,108,69,219,253,205,240,162,139,154,161,83,101,105,186,81,58,138,185,74,168,26,210,80,5,78,42,97,67,4,126,18,10,102,115,31,152,107,59,200,98,20,49,11,16,60,207,7,129,97,216,44,57,186,79,26,213,203,178,86,201,190,123,117,119,145,252,210,21,241,15,154,254,103,246,121,111,175,12,169,254,185,236,191,63,187,218,206,180,122,203,239,247,208,111,43,228,95,31,209,157,181,251,2,12,50,252,177,229,9,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("95810b4e-5292-4018-a8df-b266bc723708"),
				ContainerUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,219,48,16,252,21,131,201,209,107,136,15,137,164,111,105,115,9,144,20,70,221,230,18,231,176,36,151,141,80,217,114,245,8,144,6,254,247,210,138,221,216,125,6,40,122,40,80,29,36,144,218,153,93,206,112,30,217,105,247,176,38,54,101,175,102,87,243,58,118,147,215,117,67,147,89,83,123,106,219,201,101,237,177,42,63,163,171,104,134,13,46,169,163,230,26,171,158,218,203,178,237,198,163,67,16,27,179,211,251,225,31,155,222,60,178,139,142,150,239,47,66,98,38,110,8,141,231,80,16,106,80,220,231,96,140,35,144,185,15,94,90,65,92,137,4,246,117,213,47,87,87,212,225,12,187,59,54,125,100,3,91,34,240,38,24,21,173,7,167,140,3,165,173,3,139,190,0,165,184,136,82,201,194,163,96,155,49,107,253,29,45,113,104,122,0,86,202,6,35,5,160,242,30,148,203,56,56,27,210,8,200,133,87,2,109,52,118,11,222,213,63,3,111,78,46,235,250,99,191,158,152,44,71,244,164,192,20,153,2,149,145,6,180,228,32,139,185,226,90,229,86,250,108,162,92,112,206,152,8,185,161,2,66,228,28,172,230,169,40,227,161,200,200,74,227,139,147,219,109,163,80,182,235,10,31,174,127,218,239,204,119,229,125,217,61,140,218,14,187,190,77,226,46,215,85,82,62,60,225,215,71,70,28,50,60,46,158,220,92,176,233,226,199,126,238,190,243,65,168,99,71,143,205,92,176,241,130,205,235,190,241,91,54,153,22,231,7,99,15,13,134,146,111,150,123,247,210,206,170,175,170,221,206,57,118,184,47,220,111,215,161,140,37,133,139,213,124,111,218,192,146,237,158,164,219,119,175,253,243,52,219,159,192,174,112,133,31,168,121,147,142,255,60,251,215,41,223,37,9,247,196,78,216,60,211,60,130,38,180,160,168,16,96,2,71,176,220,186,40,181,20,49,138,1,253,150,34,53,180,242,116,60,216,75,238,206,14,223,14,106,111,99,179,155,107,43,213,134,109,54,227,195,48,169,160,157,166,88,128,136,137,75,97,186,98,206,36,106,174,136,50,18,156,139,220,253,50,76,72,82,11,31,17,80,164,99,41,29,179,20,133,34,17,232,192,165,38,71,182,40,254,98,152,164,176,46,100,5,65,180,121,106,111,132,2,204,162,3,147,83,72,90,70,97,149,153,144,148,36,115,107,128,103,82,130,10,220,128,17,92,64,46,21,218,220,107,67,154,191,48,76,73,215,190,234,70,117,28,225,46,86,147,179,16,202,174,172,87,88,141,202,85,172,155,37,110,87,163,134,62,245,101,243,63,101,255,96,202,94,114,169,126,151,178,219,205,23,152,140,224,97,12,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3fa1654a-da29-4e48-a8e1-dd36696db7fe"),
				ContainerUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeEscalationCatchSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cc1f93c0-6974-4f8b-b1e8-6a819c4b21e9"),
				ContainerUId = new Guid("9465eae5-e8e5-47ca-be99-632bc3fcb44c"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("9465eae5-e8e5-47ca-be99-632bc3fcb44c"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{8f574e5b-7624-4722-90a9-3cf65d30baa8}].[Parameter:{7a51a482-cc66-4157-a765-07dfae9e0f6b}].[EntityColumn:{ae0e45ca-c495-4fe7-a39d-3ab7278e1617}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeEscalationChangeDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("da080b93-b78a-437a-adbc-9f4eee898cc5"),
				ContainerUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a94e00f8-50cc-4b2b-9d7e-3c846c8fe91d"),
				ContainerUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b03d7915-a2be-4918-8d0b-ca7e158f79e6"),
				ContainerUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,111,218,64,16,254,43,200,231,108,228,247,218,220,82,66,43,14,109,144,136,114,9,57,140,237,89,88,197,47,237,174,211,210,136,255,222,177,13,148,180,86,74,171,62,144,202,1,236,225,219,153,111,230,155,153,125,182,210,28,180,254,0,5,90,99,235,205,252,253,162,18,230,242,173,204,13,170,119,170,106,106,235,194,210,168,36,228,242,51,102,189,125,154,73,115,13,6,232,192,243,242,235,249,165,53,94,14,121,88,90,23,75,75,26,44,52,33,232,0,231,192,61,17,133,44,138,147,152,249,118,16,48,200,68,194,210,36,139,185,155,216,161,195,121,143,28,118,61,169,138,26,20,246,17,58,231,162,123,188,221,212,45,208,33,67,218,65,164,174,202,157,209,107,41,232,105,9,73,142,25,189,27,213,32,153,140,146,5,101,130,183,178,192,57,40,138,212,250,169,90,19,129,4,228,186,69,229,40,204,244,83,173,80,107,89,149,175,83,203,155,162,60,198,210,113,60,188,238,200,216,29,195,22,57,7,179,238,28,204,136,212,182,227,120,181,90,41,92,129,145,79,199,20,30,113,211,225,78,171,29,29,200,72,159,59,200,27,60,138,249,50,143,9,212,166,79,167,15,79,0,37,87,235,19,51,61,84,235,71,201,186,100,172,247,224,147,60,14,242,119,67,50,62,181,134,222,199,254,113,105,221,207,244,205,199,18,213,34,93,99,1,125,197,30,46,201,250,141,225,224,127,252,12,200,61,112,99,135,5,30,125,249,94,28,81,21,185,195,210,208,177,99,39,201,120,36,112,251,208,243,144,186,206,97,115,119,8,55,105,148,194,210,140,12,232,199,209,236,186,3,181,229,163,191,18,20,145,147,241,132,9,17,114,230,131,231,50,240,99,151,185,33,186,110,16,197,153,39,98,146,153,62,109,3,132,220,135,216,79,89,24,115,159,192,137,199,18,225,38,44,12,124,112,68,224,249,78,132,255,219,20,44,12,152,70,211,238,40,165,94,159,54,16,167,149,113,160,161,28,247,213,137,216,81,233,127,70,82,143,132,44,33,63,247,41,233,146,218,143,70,87,170,93,183,229,213,74,166,144,223,212,168,168,146,29,105,123,184,25,94,116,81,59,116,170,170,76,63,74,7,50,87,41,169,33,13,41,112,164,68,20,114,210,1,61,6,156,22,146,239,219,54,131,52,202,152,147,102,46,247,184,239,217,24,144,166,116,159,180,172,23,85,163,210,93,247,234,254,34,249,165,43,226,31,52,253,207,236,243,193,94,57,69,253,115,217,127,127,118,181,157,169,122,139,239,247,208,111,19,242,175,143,232,214,218,126,1,114,206,120,40,229,9,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ecc66875-1982-4fd7-99ab-6d047904b215"),
				ContainerUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,219,48,16,252,21,131,201,209,52,248,18,69,250,214,54,61,4,72,10,163,110,115,137,115,88,146,203,70,168,108,185,122,4,72,13,255,123,105,89,110,236,62,3,20,61,20,40,15,18,72,238,236,14,103,57,220,144,243,246,113,141,100,74,94,206,174,231,85,108,39,175,170,26,39,179,186,242,216,52,147,171,202,67,89,124,6,87,226,12,106,88,98,139,245,13,148,29,54,87,69,211,142,71,199,32,50,38,231,15,253,30,153,222,110,200,101,139,203,247,151,33,101,246,70,10,15,204,211,220,233,72,149,180,158,26,174,179,52,149,220,56,229,131,212,54,129,125,85,118,203,213,53,182,48,131,246,158,76,55,164,207,214,39,8,70,197,4,115,202,56,170,114,235,168,5,175,169,82,92,68,169,164,246,32,200,118,76,26,127,143,75,232,139,30,129,149,178,33,49,160,160,188,167,202,49,78,157,13,25,53,192,133,87,2,108,52,118,7,30,226,159,128,183,103,87,85,245,177,91,79,12,203,0,60,42,106,52,83,84,49,204,41,88,116,148,197,76,241,92,101,86,122,54,81,46,56,103,76,164,153,65,77,67,228,156,218,156,167,32,198,131,102,104,165,241,250,236,110,87,40,20,205,186,132,199,155,159,214,123,225,219,226,161,104,31,71,77,11,109,215,36,113,151,235,50,41,31,246,248,245,73,35,142,51,108,22,251,110,46,200,116,241,227,126,14,255,121,47,212,105,71,79,155,185,32,227,5,153,87,93,237,119,217,100,154,92,28,209,238,11,244,33,223,76,15,221,75,43,171,174,44,135,149,11,104,225,16,120,88,174,66,17,11,12,151,171,249,161,105,125,22,54,140,164,219,119,159,195,216,115,251,19,216,53,172,224,3,214,111,210,241,159,184,127,101,249,46,73,120,72,236,132,205,88,206,35,205,17,44,85,168,5,53,129,3,181,220,186,40,115,41,98,20,61,250,45,70,172,113,229,241,148,216,115,238,206,128,111,122,181,119,182,25,120,237,164,218,146,237,118,124,108,38,165,88,102,163,19,251,75,172,180,77,92,132,240,148,101,153,9,24,163,180,44,252,210,76,128,50,23,62,2,5,145,142,165,242,200,146,21,180,162,60,15,92,230,232,208,106,253,23,205,36,133,117,129,105,164,209,102,169,188,17,138,2,139,142,154,12,67,210,50,10,171,204,36,249,57,75,7,97,84,231,50,169,14,105,223,106,161,41,67,224,144,229,137,129,85,207,52,83,210,181,43,219,81,21,71,48,216,106,242,186,73,143,26,180,69,181,26,213,248,169,43,234,255,206,250,7,157,245,156,139,244,59,103,221,109,191,0,18,32,76,2,0,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ce8c2f5a-cc7d-408e-8b05-bc44d01becf2"),
				ContainerUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeReadCaseCountDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6e10b476-de64-4b9b-8536-f53f0ce813e9"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,193,110,227,54,16,253,21,67,231,101,64,73,164,68,249,182,77,221,34,135,238,6,205,98,47,235,28,70,228,208,17,42,75,130,68,167,77,13,255,123,135,146,237,216,93,199,85,130,13,186,64,246,100,105,60,243,52,51,124,243,56,235,64,151,208,117,31,96,137,193,52,248,233,250,183,155,218,186,139,95,138,210,97,251,107,91,175,154,224,93,208,97,91,64,89,252,141,102,176,207,76,225,126,6,7,20,176,158,63,198,207,131,233,252,20,194,60,120,55,15,10,135,203,142,60,40,64,40,107,19,140,4,75,69,28,49,33,185,102,96,64,179,20,173,140,184,141,64,129,29,60,79,67,95,85,3,120,143,107,251,199,79,15,141,247,17,100,208,245,178,129,182,232,234,106,107,140,253,215,187,89,5,121,137,134,222,93,187,66,50,185,182,88,82,17,248,169,88,226,53,180,244,17,143,83,123,19,57,89,40,59,239,85,162,117,179,191,154,22,187,174,168,171,115,89,93,214,229,106,89,29,250,82,56,238,95,183,201,240,62,67,239,121,13,238,174,7,184,132,142,254,217,244,89,190,95,44,90,92,128,43,238,15,147,248,3,31,122,207,113,141,163,0,67,135,243,25,202,21,110,191,26,242,175,74,185,132,198,13,21,237,50,32,151,22,45,182,88,105,188,209,119,184,132,125,141,143,14,197,226,238,0,196,31,232,151,39,59,178,239,234,127,53,37,34,99,179,115,62,215,227,61,226,201,42,163,132,140,247,222,48,96,236,30,231,193,151,171,238,227,159,21,182,67,89,67,95,111,47,200,250,47,195,172,196,37,86,110,186,86,86,166,2,101,206,210,132,218,45,210,40,98,25,135,140,197,218,38,210,196,60,7,80,27,10,216,39,52,93,167,32,67,16,42,98,90,39,9,19,161,76,25,164,137,100,60,53,22,48,67,110,147,220,135,204,42,87,184,135,129,45,211,53,32,71,33,53,48,45,50,201,132,69,138,138,51,195,98,200,211,40,85,24,38,97,186,185,29,202,45,186,166,132,135,207,251,170,126,71,48,19,77,71,51,241,157,160,137,107,59,55,241,115,54,169,237,132,58,188,42,93,81,45,38,68,183,18,181,63,236,139,43,211,35,249,31,138,183,81,36,83,21,231,12,184,36,58,197,73,204,242,16,19,150,65,142,33,202,212,64,70,116,218,108,54,183,158,156,105,158,168,92,24,205,18,142,33,235,155,163,48,11,25,96,164,56,181,3,52,196,231,206,238,140,32,96,194,99,205,61,180,66,203,4,247,188,150,82,51,19,83,6,105,38,98,25,234,55,36,8,55,14,220,170,27,39,9,227,90,247,124,73,216,229,112,70,20,222,19,167,238,137,202,135,174,223,179,60,244,21,31,200,195,118,10,226,76,24,145,43,193,164,34,238,27,27,134,44,75,195,156,113,30,26,162,122,22,43,157,244,120,251,207,93,85,147,166,173,233,84,186,161,234,71,157,25,141,245,213,44,31,97,238,70,46,201,77,148,101,38,103,210,112,100,194,164,154,169,140,20,34,66,41,81,115,109,81,18,220,143,185,56,49,23,227,90,247,99,46,206,204,133,122,238,92,124,168,221,164,115,208,58,175,170,199,115,161,94,58,23,71,152,253,92,248,193,40,235,69,161,161,252,216,96,11,91,201,10,79,139,250,209,109,224,247,131,182,174,221,19,66,214,103,176,35,208,184,235,238,169,108,248,55,206,134,211,62,160,98,17,50,29,41,195,132,136,53,203,136,223,204,8,107,137,210,145,160,157,131,178,161,93,221,171,222,77,189,106,53,14,119,98,55,44,233,47,90,191,255,135,171,244,121,11,243,19,247,205,152,27,228,141,45,143,175,188,242,189,104,153,251,78,233,117,184,126,125,67,130,29,201,236,216,85,225,217,139,192,219,238,169,26,219,211,215,188,68,94,245,78,216,4,155,127,0,161,60,221,245,178,17,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var resultTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e57b1d74-578d-476a-b807-98eadc71a555"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultTypeParameter.SourceValue = new ProcessSchemaParameterValue(resultTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(resultTypeParameter);
			var readSomeTopRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f86d057a-db93-4c1d-a3b0-3470068d9d08"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ReadSomeTopRecords",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			readSomeTopRecordsParameter.SourceValue = new ProcessSchemaParameterValue(readSomeTopRecordsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(readSomeTopRecordsParameter);
			var numberOfRecordsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("fc0df9c8-409b-444e-a12d-e048877ca940"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"NumberOfRecords",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			numberOfRecordsParameter.SourceValue = new ProcessSchemaParameterValue(numberOfRecordsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(numberOfRecordsParameter);
			var functionTypeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d119c974-e8fb-423b-b661-fc9d3c080ea7"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"FunctionType",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			functionTypeParameter.SourceValue = new ProcessSchemaParameterValue(functionTypeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(functionTypeParameter);
			var aggregationColumnNameParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0676e49c-6b30-489d-83c5-ab83ad3e6093"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"AggregationColumnName",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			aggregationColumnNameParameter.SourceValue = new ProcessSchemaParameterValue(aggregationColumnNameParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,1,0,242,67,189,42,2,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(aggregationColumnNameParameter);
			var orderInfoParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c9b59582-9d62-471e-8bb4-aa7df0658127"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"OrderInfo",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			orderInfoParameter.SourceValue = new ProcessSchemaParameterValue(orderInfoParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,201,44,201,73,181,50,180,50,212,241,76,177,50,176,50,0,0,169,240,29,88,16,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(orderInfoParameter);
			var resultEntityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("e0685b0c-239b-47ce-8492-ff99b21d13a5"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultEntity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityDataValueType")
			};
			resultEntityParameter.SourceValue = new ProcessSchemaParameterValue(resultEntityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(resultEntityParameter);
			var resultCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("399de72a-ef6d-4a47-b355-3086cf7cc0cd"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultCountParameter.SourceValue = new ProcessSchemaParameterValue(resultCountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCountParameter);
			var resultIntegerFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b6b9ddf5-da1a-4be7-80c2-86cd883ed495"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultIntegerFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultIntegerFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultIntegerFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultIntegerFunctionParameter);
			var resultFloatFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("518f26fc-42e0-4dfd-bded-1ca5061316e6"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultFloatFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Float4")
			};
			resultFloatFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultFloatFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultFloatFunctionParameter);
			var resultDateTimeFunctionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c56a1f76-9f86-47e6-b3b7-33ab372ebaef"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultDateTimeFunction",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("DateTime")
			};
			resultDateTimeFunctionParameter.SourceValue = new ProcessSchemaParameterValue(resultDateTimeFunctionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDateTimeFunctionParameter);
			var resultRowsCountParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ace9d311-33b7-4a4f-8db5-5154787974c9"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultRowsCount",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			resultRowsCountParameter.SourceValue = new ProcessSchemaParameterValue(resultRowsCountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultRowsCountParameter);
			var canReadUncommitedDataParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("20e89035-f4c1-4152-b109-4eedc803888e"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"CanReadUncommitedData",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			canReadUncommitedDataParameter.SourceValue = new ProcessSchemaParameterValue(canReadUncommitedDataParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(canReadUncommitedDataParameter);
			var resultEntityCollectionParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("b1feaf4d-a320-4d9a-a665-cddda8e8bb59"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultEntityCollection",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityCollectionDataValueType")
			};
			resultEntityCollectionParameter.SourceValue = new ProcessSchemaParameterValue(resultEntityCollectionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(resultEntityCollectionParameter);
			var entityColumnMetaPathesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d49a261c-b0a1-4251-8c54-c4923cc2b11f"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"EntityColumnMetaPathes",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			entityColumnMetaPathesParameter.SourceValue = new ProcessSchemaParameterValue(entityColumnMetaPathesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entityColumnMetaPathesParameter);
			var ignoreDisplayValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bce2b23c-43d7-4ee3-99a6-d42915037782"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"IgnoreDisplayValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreDisplayValuesParameter.SourceValue = new ProcessSchemaParameterValue(ignoreDisplayValuesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("26fee922-21a7-4cbd-aaa5-6625b9d9ba29"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ResultCompositeObjectList",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("CompositeObjectList")
			};
			resultCompositeObjectListParameter.SourceValue = new ProcessSchemaParameterValue(resultCompositeObjectListParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f19d01c9-602a-413a-8523-48e2ede551bb"),
				ContainerUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeCompleteTasksChangeDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("99f2dd86-4eab-47c5-8ba2-01d496b9a3fb"),
				ContainerUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6a09dbe4-c830-4973-9ba2-bee31e9f77f2"),
				ContainerUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c8a7ec42-256a-40db-af79-d1e36121c71c"),
				ContainerUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,86,223,115,219,54,12,254,87,116,122,46,115,212,47,82,244,91,155,185,187,60,108,205,45,185,190,212,121,128,72,208,209,85,150,124,18,157,205,243,249,127,31,40,217,142,219,56,174,154,219,218,238,250,98,73,48,0,2,31,62,16,216,132,186,130,174,251,29,22,24,78,194,55,215,191,221,52,214,93,188,45,43,135,237,175,109,179,90,134,175,194,14,219,18,170,242,111,52,131,124,106,74,247,11,56,32,131,205,236,209,126,22,78,102,167,60,204,194,87,179,176,116,184,232,72,131,12,132,228,60,193,60,98,66,113,100,41,79,114,166,12,104,166,101,154,103,92,64,154,105,59,104,158,118,125,85,15,206,123,191,182,127,189,93,47,189,78,74,2,221,44,150,208,150,93,83,239,132,137,63,189,155,214,80,84,104,232,219,181,43,36,145,107,203,5,37,129,183,229,2,175,161,165,67,188,159,198,139,72,201,66,213,121,173,10,173,155,254,181,108,177,235,202,166,62,23,213,101,83,173,22,245,177,46,153,227,225,115,23,12,239,35,244,154,215,224,238,123,7,151,208,209,63,219,62,202,215,243,121,139,115,112,229,195,113,16,31,113,221,107,142,3,142,12,12,21,231,61,84,43,220,157,26,241,39,169,92,194,210,13,25,237,35,32,149,22,45,182,88,107,188,209,247,184,128,67,142,143,10,229,252,254,200,137,47,232,135,103,17,57,160,250,37,80,98,18,46,247,202,231,48,62,120,60,153,101,44,72,248,224,5,131,143,253,235,44,252,112,213,189,251,179,198,118,72,107,192,245,238,130,164,159,9,166,21,46,176,118,147,77,110,51,153,98,86,48,41,226,148,165,50,142,153,226,160,88,162,173,200,76,194,11,128,124,75,6,135,128,38,27,9,89,4,105,30,51,173,133,96,105,148,73,6,82,100,140,75,99,1,21,114,43,10,111,50,173,93,233,214,3,91,38,27,64,142,84,54,96,58,85,25,75,45,146,85,162,12,75,160,144,177,204,49,18,145,220,222,13,233,150,221,178,130,245,251,67,86,127,32,152,64,83,105,2,143,4,117,92,219,185,192,247,89,208,216,128,16,94,85,174,172,231,1,209,173,66,237,139,125,113,101,122,79,254,65,246,69,106,115,174,180,96,177,85,5,75,83,25,49,165,165,101,73,140,137,209,81,4,144,104,34,230,118,123,231,201,105,56,125,91,137,44,50,94,219,191,41,99,37,67,145,27,195,173,50,185,18,63,81,215,190,38,68,31,124,33,233,228,121,211,174,199,117,240,56,16,95,210,193,251,40,206,116,241,211,144,127,244,142,238,179,62,234,232,29,113,109,22,233,84,164,9,203,114,20,204,216,136,136,43,163,130,113,30,25,193,81,37,185,30,80,60,28,119,219,4,166,233,69,143,151,194,104,47,79,26,111,231,109,223,25,150,139,60,46,176,96,150,43,234,124,21,27,6,42,163,159,88,196,66,37,154,67,156,157,231,160,231,62,62,215,30,209,255,177,61,110,28,184,85,71,119,82,93,118,247,227,122,99,28,140,167,88,18,159,237,141,93,40,195,35,40,187,192,150,53,84,167,200,63,138,168,223,138,250,241,17,89,123,168,136,110,30,198,170,153,151,26,170,119,75,108,9,201,62,104,126,154,12,159,176,200,207,198,182,105,220,51,119,66,31,195,190,18,156,231,152,200,36,99,52,178,12,75,19,160,61,3,243,140,201,40,79,162,194,198,74,2,80,77,105,51,244,81,223,52,171,86,239,216,219,13,43,225,139,150,189,239,48,19,190,110,61,123,230,170,28,195,128,159,108,85,249,143,23,140,31,148,41,167,87,130,127,145,53,159,140,195,177,3,236,171,135,212,119,24,62,248,178,137,114,242,250,126,226,107,12,176,223,250,178,221,134,219,127,0,144,180,102,160,121,15,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cbba51f0-1bbc-4cab-9bfd-7c94e372df30"),
				ContainerUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,219,48,16,252,21,131,201,209,20,248,18,69,250,214,54,151,0,73,97,212,109,46,113,14,75,114,217,8,149,37,195,146,2,164,134,255,189,148,98,55,118,159,1,138,30,10,148,7,9,164,118,102,135,179,154,45,57,239,30,215,72,102,228,245,252,122,209,196,46,123,211,108,48,155,111,26,143,109,155,93,53,30,170,242,51,184,10,231,176,129,21,118,184,185,129,170,199,246,170,108,187,233,228,24,68,166,228,252,97,252,70,102,183,91,114,217,225,234,195,101,72,204,152,27,206,11,239,169,209,222,80,197,165,163,0,24,40,132,24,16,25,203,157,240,9,236,155,170,95,213,215,216,193,28,186,123,50,219,146,145,45,17,120,19,140,138,214,83,167,140,163,170,176,142,90,240,154,42,197,69,148,74,106,15,130,236,166,164,245,247,184,130,177,233,17,88,41,27,140,20,20,84,146,160,28,227,212,217,144,83,3,92,120,37,192,70,99,7,240,190,254,25,120,123,118,213,52,159,250,117,102,88,14,224,81,37,253,76,81,197,176,160,96,209,81,22,115,197,11,149,91,233,89,166,92,112,206,152,72,115,131,154,134,200,57,181,5,79,69,140,7,205,208,74,227,245,217,221,208,40,148,237,186,130,199,155,159,246,123,229,187,242,161,236,30,39,109,7,93,223,38,115,87,235,42,57,31,158,240,235,147,65,28,51,108,151,79,211,92,146,217,242,199,243,220,191,23,163,81,167,19,61,29,230,146,76,151,100,209,244,27,63,176,201,180,185,56,146,61,54,24,75,190,217,30,166,151,78,234,190,170,246,39,23,208,193,161,240,112,220,132,50,150,24,46,235,197,97,104,35,11,219,175,228,219,119,143,195,122,210,246,39,176,107,168,225,35,110,222,166,235,63,107,255,170,242,125,178,240,64,236,132,205,89,193,35,45,16,44,85,168,5,53,129,3,181,220,186,40,11,41,98,20,35,250,29,70,220,96,237,241,84,216,75,254,157,61,190,29,221,30,98,179,215,53,88,181,35,187,221,244,36,76,86,20,133,52,64,243,232,146,32,163,134,88,21,129,242,96,163,68,169,48,137,250,101,152,32,85,8,31,129,130,72,215,82,69,100,41,10,90,81,94,4,46,11,116,104,181,254,139,97,146,194,186,192,52,210,104,243,212,222,8,69,129,69,71,77,142,33,121,25,133,85,38,195,168,180,226,121,186,90,24,98,46,125,10,188,7,160,82,99,14,90,231,60,248,248,194,48,37,95,251,170,155,52,113,2,251,88,101,139,228,77,87,54,245,36,54,125,253,63,84,255,94,168,94,242,15,253,46,84,119,187,47,90,228,94,145,251,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("03049495-dcd9-42dd-af23-bec53dcdc252"),
				ContainerUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeCancelTasksChangeDataUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("e21b52d3-db26-4e4e-8254-fcc14a5f7386"),
				ContainerUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"EntitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaUIdParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("59deaa49-2d60-48b6-81d5-cecd7aaaf43b"),
				ContainerUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c590c5de-cb61-45ff-a24d-d8ee718c86e7"),
				ContainerUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,86,223,115,219,54,12,254,87,124,122,46,115,164,68,234,135,223,186,204,219,229,97,107,110,201,245,165,206,3,72,130,142,110,178,228,147,232,108,94,206,255,251,64,201,118,220,198,241,212,220,214,118,215,39,73,16,0,2,31,62,0,124,140,76,5,93,247,43,44,49,154,70,63,92,255,114,211,56,127,241,83,89,121,108,127,110,155,245,42,122,19,117,216,150,80,149,127,161,29,228,51,91,250,31,193,3,25,60,206,159,236,231,209,116,126,202,195,60,122,51,143,74,143,203,142,52,200,192,9,237,172,202,99,22,107,233,152,76,138,130,105,83,36,76,199,89,110,115,99,18,167,196,160,121,218,245,85,61,56,239,253,186,254,245,118,179,10,58,146,4,166,89,174,160,45,187,166,222,9,147,112,122,55,171,65,87,104,233,219,183,107,36,145,111,203,37,37,129,183,229,18,175,161,165,67,130,159,38,136,72,201,65,213,5,173,10,157,159,253,185,106,177,235,202,166,62,23,213,101,83,173,151,245,177,46,153,227,225,115,23,12,239,35,12,154,215,224,239,123,7,151,208,209,159,109,31,229,219,197,162,197,5,248,242,225,56,136,223,113,211,107,142,3,142,12,44,21,231,61,84,107,220,157,42,248,179,84,46,97,229,135,140,246,17,144,74,139,14,91,172,13,222,152,123,92,194,33,199,39,133,114,113,127,228,36,20,244,195,139,136,28,80,253,39,80,98,18,174,246,202,231,48,62,120,60,153,101,156,146,240,33,8,6,31,251,215,121,244,225,170,123,247,71,141,237,144,214,128,235,221,5,73,63,17,204,42,92,98,237,167,143,185,83,153,68,165,89,150,198,146,201,44,142,89,193,161,96,137,113,169,178,9,215,0,249,150,12,14,1,77,31,51,80,2,36,21,199,152,52,101,82,168,140,65,150,42,198,51,235,0,11,228,46,213,193,100,86,251,210,111,6,182,76,31,1,57,74,101,128,25,89,40,38,29,146,85,82,88,150,128,206,168,170,40,82,145,109,239,134,116,203,110,85,193,230,253,33,171,223,16,236,196,80,105,38,1,9,234,184,182,243,147,208,103,147,198,77,8,225,117,229,203,122,49,33,186,85,104,66,177,47,174,108,239,41,60,200,30,173,210,32,84,204,92,14,49,37,73,177,67,150,40,150,196,60,167,240,243,56,46,52,17,115,187,189,11,228,148,25,7,37,141,96,133,206,2,249,92,194,64,99,206,50,237,242,28,37,23,188,239,174,239,165,107,223,18,162,15,161,144,116,242,162,105,55,227,58,120,28,136,175,233,224,125,20,103,186,248,121,200,223,122,71,247,89,31,117,244,142,184,52,230,140,76,101,194,84,142,41,179,78,16,158,153,208,140,115,97,83,142,69,146,155,180,247,119,56,238,182,153,216,166,23,61,13,133,209,94,158,53,222,206,219,161,51,148,84,133,53,138,9,39,144,73,99,115,86,56,65,51,0,51,157,36,121,134,86,240,243,28,12,220,199,151,218,67,252,31,219,227,198,131,95,119,52,147,234,178,187,31,217,27,163,96,60,197,146,248,108,111,236,66,25,30,147,178,155,184,178,134,234,20,249,71,17,245,75,81,63,62,34,107,15,21,209,45,192,88,53,139,210,64,245,110,133,45,33,217,7,205,79,147,225,35,22,133,221,216,54,141,127,97,38,244,49,236,43,145,11,201,227,24,4,3,64,154,82,194,113,166,179,20,104,5,58,45,180,181,74,240,156,106,74,55,195,16,245,77,179,110,205,142,189,221,112,37,124,213,101,239,43,236,132,207,187,158,189,48,42,199,48,224,59,187,170,252,199,23,140,111,148,41,167,175,4,255,34,107,62,90,135,99,23,216,103,47,169,175,176,124,240,117,27,229,228,248,126,230,107,12,176,95,122,216,110,163,237,223,6,141,234,226,121,15,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6c0bc164-4425-4e9d-abaf-b243259091c3"),
				ContainerUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,203,110,219,48,16,252,149,128,201,209,20,72,138,146,72,223,218,228,98,192,46,140,186,205,37,206,97,73,46,27,161,178,101,72,84,0,215,240,191,151,150,165,196,238,3,40,80,30,36,112,185,51,59,156,145,14,228,46,236,119,72,166,228,227,114,177,170,125,72,238,235,6,147,101,83,91,108,219,100,94,91,168,202,31,96,42,92,66,3,27,12,216,60,66,213,97,59,47,219,48,185,185,4,145,9,185,123,237,207,200,244,233,64,102,1,55,95,103,46,50,27,204,83,101,184,160,60,119,64,37,83,138,154,44,45,104,154,91,6,10,120,97,153,143,96,91,87,221,102,187,192,0,75,8,47,100,122,32,61,91,36,176,202,41,233,181,165,70,42,67,101,161,13,213,96,115,42,37,23,62,149,145,7,4,57,78,72,107,95,112,3,253,208,11,176,148,218,169,84,80,144,214,82,105,24,167,70,187,140,198,193,194,74,1,218,43,125,2,15,253,239,192,167,219,121,93,127,239,118,137,98,25,128,69,73,85,206,100,212,143,5,5,141,134,50,159,73,94,200,76,167,150,37,130,113,235,13,40,154,41,204,169,243,156,83,93,240,216,196,184,203,25,234,84,217,252,246,249,52,200,149,237,174,130,253,227,95,231,125,176,161,124,45,195,254,166,13,16,186,54,185,135,173,197,10,221,25,190,187,202,225,146,224,176,62,135,185,38,211,245,159,227,28,222,171,222,167,235,64,175,179,92,147,201,154,172,234,174,177,39,182,52,110,30,46,84,247,3,250,150,95,182,99,120,177,178,237,170,106,168,60,64,128,177,113,44,215,174,244,37,186,217,118,53,102,214,179,176,97,69,219,126,123,140,235,172,237,127,96,11,216,194,55,108,62,197,235,191,107,127,83,249,37,90,56,18,27,161,51,86,112,79,11,4,77,37,230,130,42,199,129,106,174,141,79,139,84,120,47,122,244,103,244,216,96,204,233,90,216,191,124,58,3,190,237,221,62,253,53,131,174,147,85,71,114,60,62,31,127,2,129,97,90,91,165,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d4b8b9f6-cbed-4713-9af0-46cd9bfd1a56"),
				ContainerUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeRescheduledCatchSignalParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a46b9b07-561d-402a-bfce-8c12452a18d2"),
				ContainerUId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{ae73a291-5391-4398-ad71-c61091bd78fe}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
		}

		protected virtual void InitializeAddRescheduledTaskUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var entitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("92b7b385-b361-4426-aa17-35a191aa76c8"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"EntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			entitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(entitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(entitySchemaIdParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("b7e1b44d-217e-4e2f-a90c-17a5ebf74c94"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var recordAddModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d5038619-45b6-440d-9cef-0b9bb2381b70"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordAddMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			recordAddModeParameter.SourceValue = new ProcessSchemaParameterValue(recordAddModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordAddModeParameter);
			var filterEntitySchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("2e155463-3ff1-4ccf-8584-4ec8d7233111"),
				UId = new Guid("c587e107-d285-4719-941f-a1aa76cdf30e"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"FilterEntitySchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			filterEntitySchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(filterEntitySchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(filterEntitySchemaIdParameter);
			var recordDefValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("2a49baff-f87a-4844-8d6e-503b3b93151b"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordDefValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordDefValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordDefValuesParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,152,221,111,27,55,12,192,255,21,227,210,183,69,134,190,63,252,214,181,29,16,32,237,130,166,235,75,146,7,74,164,210,195,156,187,192,62,119,200,2,255,239,227,57,73,155,116,155,151,110,203,176,34,241,131,141,147,69,138,34,249,35,165,187,108,158,13,23,231,212,204,154,239,15,94,31,246,117,152,190,232,23,52,61,88,244,133,150,203,233,126,95,96,222,254,10,121,78,7,176,128,51,26,104,241,30,230,43,90,238,183,203,97,119,114,91,168,217,109,158,125,220,252,215,204,142,46,155,189,129,206,126,218,67,214,108,35,144,202,197,139,234,8,132,117,33,138,132,104,133,12,170,38,23,75,52,202,178,112,233,231,171,179,238,53,13,112,0,195,135,102,118,217,108,180,177,130,18,149,173,16,148,32,169,178,176,70,59,1,37,162,136,104,65,39,67,168,76,108,214,187,205,178,124,160,51,216,44,122,75,216,218,132,209,104,1,182,20,97,179,84,34,39,116,34,130,210,197,106,72,53,166,81,248,122,254,103,193,163,157,253,190,255,121,117,62,77,94,145,150,209,11,150,224,229,81,7,145,101,114,194,202,172,200,91,244,165,200,105,117,170,88,111,141,112,145,188,192,170,148,72,129,173,149,82,161,151,148,76,44,126,231,100,92,8,219,229,249,28,46,222,255,233,122,207,203,208,126,108,135,139,73,129,129,78,251,197,197,244,93,63,193,254,74,250,252,78,24,110,203,95,30,95,197,242,184,153,29,255,113,52,175,127,15,55,110,186,27,207,187,161,60,110,118,143,155,195,126,181,40,163,54,195,15,47,111,25,189,89,96,51,229,139,199,155,216,241,72,183,154,207,175,71,94,194,0,55,19,111,134,123,108,107,75,184,215,29,222,132,108,163,69,94,127,216,107,191,251,186,249,92,217,246,79,196,94,67,7,167,180,120,195,219,255,108,251,39,43,223,177,11,111,20,103,157,220,152,165,34,16,36,97,201,107,206,57,5,34,169,148,171,9,70,215,170,55,210,111,169,210,130,186,66,119,13,187,79,230,92,203,47,55,222,30,161,185,182,107,116,213,186,89,175,119,111,163,84,189,118,160,139,22,10,37,178,26,231,68,142,140,67,244,154,44,58,231,10,209,86,148,44,150,42,193,40,17,42,6,182,40,131,0,41,173,32,171,76,86,193,25,107,212,191,143,210,152,63,112,218,245,75,154,64,135,147,5,239,118,254,145,38,109,87,90,164,110,152,236,28,55,223,29,237,28,237,45,127,252,165,163,197,149,15,103,21,230,75,58,153,242,232,23,3,175,230,116,198,82,179,203,88,93,176,228,178,8,94,91,97,131,214,34,73,14,148,41,213,59,52,50,3,196,53,11,124,74,245,217,101,0,167,192,70,45,74,241,94,88,229,130,128,224,29,215,34,172,64,137,100,245,121,20,121,213,13,76,224,139,141,31,89,42,199,66,62,91,161,83,225,10,38,11,199,145,128,119,239,114,13,57,20,43,45,172,79,182,227,125,63,31,188,37,64,230,158,39,33,39,228,244,135,118,177,28,38,45,199,127,210,215,81,102,53,31,218,238,116,194,1,158,19,151,137,190,155,190,89,157,101,90,60,21,135,255,188,56,184,2,198,85,37,25,110,6,193,22,207,169,148,60,8,19,13,130,135,10,165,150,109,197,225,222,134,221,183,56,164,152,131,183,30,5,186,202,213,134,42,215,157,96,165,136,1,100,160,130,138,66,220,94,28,56,147,177,216,32,162,211,92,238,80,146,0,95,65,84,205,170,179,150,172,194,60,68,159,253,255,130,15,36,201,114,160,69,177,99,217,174,196,82,38,161,48,144,131,14,145,148,87,225,175,192,255,59,80,239,225,19,208,223,92,183,87,42,32,79,74,34,234,192,201,194,189,84,68,203,231,64,197,25,167,20,183,230,84,240,171,128,166,10,24,129,147,59,80,168,204,35,88,145,129,243,80,202,146,249,236,155,28,68,181,21,232,42,131,97,128,141,8,9,185,68,5,207,197,138,124,18,201,83,113,62,37,99,147,122,92,64,7,233,181,68,206,22,178,227,93,132,227,43,82,69,222,158,11,186,22,100,175,170,252,16,64,63,95,46,219,211,142,232,9,235,111,15,107,159,201,120,167,68,172,164,199,68,99,192,17,153,164,40,13,90,207,221,30,205,87,97,13,89,114,155,213,70,232,145,109,107,248,224,16,249,174,200,77,37,230,24,93,116,33,235,173,88,231,10,144,10,151,132,98,124,20,214,74,222,145,217,28,68,130,247,178,66,85,54,62,46,172,189,73,190,90,79,99,159,230,74,89,51,71,203,241,13,41,106,27,125,170,85,218,108,30,2,235,23,125,55,64,25,158,168,126,162,218,212,202,84,251,194,253,132,143,224,86,98,21,217,198,40,148,54,142,47,251,198,43,185,157,234,154,37,250,202,13,73,5,190,90,90,224,91,57,40,190,224,131,205,252,94,169,120,148,143,141,234,172,156,145,186,36,190,103,23,94,8,19,123,164,242,166,184,236,202,84,19,96,37,245,32,205,186,148,126,213,61,81,253,237,81,173,29,134,162,32,243,251,49,146,124,168,27,49,24,219,163,212,124,145,115,16,52,250,171,151,155,91,122,245,201,250,55,187,210,213,61,21,23,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordDefValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("538e3867-2d16-4738-823f-530a3f2cd5a7"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("104d9e8d-7905-42b4-acf2-bc19a2e3dd40"),
				ContainerUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				Name = @"ConsiderTimeInFilter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			considerTimeInFilterParameter.SourceValue = new ProcessSchemaParameterValue(considerTimeInFilterParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71")
			};
			parametrizedElement.Parameters.Add(considerTimeInFilterParameter);
		}

		protected virtual void InitializeOpenResheduledTaskEditPageUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var objectSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("f9f0b2ef-b537-4f31-a5bd-bc0b4387a477"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ObjectSchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			objectSchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(objectSchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"c449d832-a4cc-4b01-b9d5-8a12c42a9f89",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(objectSchemaIdParameter);
			var pageSchemaIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				UId = new Guid("73f9197d-3c80-4e5a-a6dd-fd7e5eb882d5"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"PageSchemaId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			pageSchemaIdParameter.SourceValue = new ProcessSchemaParameterValue(pageSchemaIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"6e5551de-a0fa-48af-8d1b-7dc896060a1e",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(pageSchemaIdParameter);
			var editModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a517303e-9785-4d9c-be67-2b59977d0b6c"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"EditMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			editModeParameter.SourceValue = new ProcessSchemaParameterValue(editModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"1",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(editModeParameter);
			var recordColumnValuesParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cdfee2f2-2914-43ad-8e30-4e93a8301ea1"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"RecordColumnValues",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("EntityColumnMappingCollectionDataValueType")
			};
			recordColumnValuesParameter.SourceValue = new ProcessSchemaParameterValue(recordColumnValuesParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,171,86,82,41,169,44,72,85,178,82,114,10,240,13,206,79,43,209,115,206,47,74,213,11,40,202,79,78,45,46,214,243,201,79,78,204,201,172,74,76,202,73,13,72,44,74,204,77,45,73,45,10,75,204,41,77,45,246,201,44,46,209,81,64,214,164,164,163,164,82,6,150,83,178,138,142,173,5,0,224,26,131,0,90,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var recordIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				UId = new Guid("2d261075-7320-45c5-a0b8-da25a32b1ce0"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"RecordId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			recordIdParameter.SourceValue = new ProcessSchemaParameterValue(recordIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{68ef5315-41e9-4b68-96d5-fdca74d37520}].[Parameter:{538e3867-2d16-4738-823f-530a3f2cd5a7}]#]",
				MetaPath = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{68ef5315-41e9-4b68-96d5-fdca74d37520}].[Parameter:{538e3867-2d16-4738-823f-530a3f2cd5a7}]#]",
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recordIdParameter);
			var executedModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("975dad01-0f9c-41f9-9dba-6c204620b59d"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ExecutedMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			executedModeParameter.SourceValue = new ProcessSchemaParameterValue(executedModeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executedModeParameter);
			var isMatchConditionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c2630eb6-4cab-45a0-a61a-f97018285882"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"IsMatchConditions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isMatchConditionsParameter.SourceValue = new ProcessSchemaParameterValue(isMatchConditionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isMatchConditionsParameter);
			var dataSourceFiltersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8553b6f1-1c80-4fc3-ae4d-08b5cd7171f8"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"DataSourceFilters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MetaDataTextDataValueType")
			};
			dataSourceFiltersParameter.SourceValue = new ProcessSchemaParameterValue(dataSourceFiltersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(dataSourceFiltersParameter);
			var generateDecisionsFromColumnParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6e47e63f-e942-4085-a3bd-6ab9010b12ff"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"GenerateDecisionsFromColumn",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			generateDecisionsFromColumnParameter.SourceValue = new ProcessSchemaParameterValue(generateDecisionsFromColumnParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(generateDecisionsFromColumnParameter);
			var decisionalColumnMetaPathParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d0d67c0b-b33d-46f1-a228-5a0a3f8db1a5"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"DecisionalColumnMetaPath",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			decisionalColumnMetaPathParameter.SourceValue = new ProcessSchemaParameterValue(decisionalColumnMetaPathParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(decisionalColumnMetaPathParameter);
			var resultParameterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("34934901-cc88-496d-874d-c790334668d4"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ResultParameter",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			resultParameterParameter.SourceValue = new ProcessSchemaParameterValue(resultParameterParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultParameterParameter);
			var isReexecutionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4fc12d51-aee6-4025-b7b7-9cb916b765c1"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"IsReexecution",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isReexecutionParameter.SourceValue = new ProcessSchemaParameterValue(isReexecutionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isReexecutionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("36fc1749-5e74-486d-9aa2-9997322bd096"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Specify start/end dates in the task",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("a4ce0f56-9fe5-4465-8f2e-2b52e4ea511a"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"f51c4643-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("8923c12b-3e36-466f-8b47-a61859bf4610"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysVariable.CurrentUserContact#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("77d923b9-b162-4dc3-a65a-f662c1683465"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cf9a71fe-d429-4b38-b8e7-dfe32a55ae55"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"DurationPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationPeriodParameter.SourceValue = new ProcessSchemaParameterValue(durationPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("3e7299c2-13e1-4fb6-9110-6637acbf7fa8"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"StartIn",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startInParameter.SourceValue = new ProcessSchemaParameterValue(startInParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("92526212-b4e7-4c84-b889-378fb2292a7a"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"StartInPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startInPeriodParameter.SourceValue = new ProcessSchemaParameterValue(startInPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("de781630-7327-4331-8d12-5d22d92e1737"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"RemindBefore",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforeParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("189d2378-a138-4c1f-876e-ca81238f2c0b"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"RemindBeforePeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforePeriodParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforePeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0b7d386f-a98b-4951-b236-c81c9d1971b1"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("ebd95a51-ddeb-44d8-bf32-63592a44c539"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("d6fdb102-6caa-49e9-a5b2-1c770ca6e847"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("ca853fd2-05a9-469a-a508-4e39f3da9059"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("9329119b-85e9-4b2b-8a37-3b22c75f7a41"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("8d6acd3b-9769-4126-94cb-a2c73f82c650"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("3dec8030-fe45-48ff-9399-e7952212a53c"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				UId = new Guid("27e6ba69-8288-4933-94c8-3077891add79"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("29631052-774c-49d8-b31d-f1c8820e0946"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("87e7e4d8-7bcb-4fc9-84c8-670dbb29fd6d"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a45b4882-0481-4d81-82ad-1c5b52de9081"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("cf1b147f-ba96-4412-a061-6dc9d86fe625"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6ea35da2-f744-4d97-ba95-f3db35c6a221"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"IsActivityCompleted",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isActivityCompletedParameter.SourceValue = new ProcessSchemaParameterValue(isActivityCompletedParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6351291c-9331-45a5-b9e7-07dcfb87ca72"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var pageTypeUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("bc0f1f42-e563-4d5d-a178-dc465ba0dd21"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"PageTypeUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			pageTypeUIdParameter.SourceValue = new ProcessSchemaParameterValue(pageTypeUIdParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"fbe0acdc-cfc0-df11-b00f-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(pageTypeUIdParameter);
			var activitySchemaUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a1876452-d45e-49e4-9764-f5701aa6c862"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ActivitySchemaUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activitySchemaUIdParameter.SourceValue = new ProcessSchemaParameterValue(activitySchemaUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activitySchemaUIdParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("6d3b9d72-0379-484c-91be-dbd4cfaa6087"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"InformationOnStep",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			informationOnStepParameter.SourceValue = new ProcessSchemaParameterValue(informationOnStepParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(informationOnStepParameter);
			var orderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("2eeff63d-d521-490d-a199-1ebc8eab8777"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f2e5410e-5ad0-434f-b0ff-e54c67b05726"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0d61e10b-5035-4def-a3ab-2b157dc34402"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("07cc0683-8fb0-412d-84e4-1129fe369a51"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("fb1686c8-d568-46c0-84ce-b39d2c502807"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("45923a9c-afb5-4081-b2ee-958f0892885b"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				UId = new Guid("dc430176-a84a-4020-9f66-3796a92959ce"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				UId = new Guid("fb3da557-5fd3-41cf-bc78-31f1210af7b7"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("c38a9663-79ef-4428-9487-8fdeadfe594e"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("ce7708dd-a1a2-4e62-be9e-757ab3935223"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"ActivityPriority",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityPriorityParameter.SourceValue = new ProcessSchemaParameterValue(activityPriorityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ab96fa02-7fe6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("12406193-22d3-49d9-84eb-58074f996740"),
				ContainerUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
		}

		protected virtual void InitializeUserQuestionUserTask1Parameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var branchingDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("675f0993-7e43-4f73-9a39-40712c295959"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"BranchingDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableParameterValuesListDataValueType")
			};
			branchingDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(branchingDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,157,207,203,138,19,65,20,6,224,87,9,197,44,115,66,85,117,93,186,178,52,131,48,16,37,224,101,35,46,78,87,157,194,198,140,61,116,247,8,78,8,200,108,116,225,222,149,62,195,160,6,4,47,207,80,253,70,86,103,33,145,129,48,184,59,197,169,255,240,127,27,118,210,191,185,32,54,103,247,86,15,30,53,177,159,45,154,150,102,171,182,241,212,117,179,101,227,113,93,95,97,181,166,21,182,120,78,61,181,79,113,125,73,221,178,238,250,233,228,48,196,166,236,228,245,126,199,230,207,54,236,172,167,243,39,103,33,95,150,36,172,176,206,131,83,65,128,146,34,0,86,200,65,71,163,140,143,214,99,57,134,199,191,27,182,191,144,67,70,42,105,20,90,16,90,90,80,165,36,192,82,115,240,81,40,162,128,174,224,154,109,167,236,97,46,117,152,59,37,95,119,117,243,138,143,203,5,94,244,121,30,247,117,183,244,87,251,234,108,222,183,151,52,253,155,72,31,211,77,250,146,118,195,219,225,125,250,62,92,15,31,198,232,41,197,197,11,242,47,233,159,86,247,113,221,17,219,110,167,135,62,109,140,182,198,17,72,39,17,20,89,9,206,112,4,169,171,104,133,55,206,7,126,203,87,68,84,129,100,128,146,199,8,202,105,132,202,122,13,78,218,96,100,12,186,66,60,230,19,119,247,125,30,174,211,207,180,75,191,254,75,231,121,89,74,129,26,120,145,219,42,50,28,28,105,15,69,89,69,20,220,6,17,244,45,93,168,124,144,94,56,40,60,18,40,27,2,84,34,79,200,149,208,162,40,74,97,212,49,157,188,187,238,83,86,189,203,186,175,233,247,36,19,119,147,244,45,191,126,164,155,227,214,199,249,74,166,62,223,254,1,14,19,36,158,2,3,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(branchingDecisionsParameter);
			var resultDecisionsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d7ddf2ac-d757-46b1-be45-23d92c75fac3"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = true,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ResultDecisions",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			resultDecisionsParameter.SourceValue = new ProcessSchemaParameterValue(resultDecisionsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultDecisionsParameter);
			var decisionModeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("000efa2d-fb03-4c16-a5d9-f25cf8f9d82d"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DecisionMode",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			decisionModeParameter.SourceValue = new ProcessSchemaParameterValue(decisionModeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(decisionModeParameter);
			var isDecisionRequiredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("215456ce-4520-4c29-b6d6-8259bd1cb74b"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"IsDecisionRequired",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isDecisionRequiredParameter.SourceValue = new ProcessSchemaParameterValue(isDecisionRequiredParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(isDecisionRequiredParameter);
			var questionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("51a4a529-9378-410d-8fa1-e469e0bfa4e0"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Question",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			questionParameter.SourceValue = new ProcessSchemaParameterValue(questionParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Какие действия необходимо выполнить с незавершенными задачами по инциденту?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(questionParameter);
			var windowCaptionParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c50c1d7b-3b09-46d8-91ca-188cb23ef8c2"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"WindowCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			windowCaptionParameter.SourceValue = new ProcessSchemaParameterValue(windowCaptionParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(windowCaptionParameter);
			var recommendationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("dc8b9fc3-346a-4e8b-a0ac-66c45ebc30b2"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Recommendation",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			recommendationParameter.SourceValue = new ProcessSchemaParameterValue(recommendationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"Какие действия необходимо выполнить с незавершенными задачами по инциденту?",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(recommendationParameter);
			var activityCategoryParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				UId = new Guid("f48bfc98-8af5-4b8b-8f0e-0f54a4b68120"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityCategory",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityCategoryParameter.SourceValue = new ProcessSchemaParameterValue(activityCategoryParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"f51c4643-58e6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityCategoryParameter);
			var ownerIdParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("ca4f9842-d9ff-4a15-b38b-1cd918ee9ed3"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = true,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"OwnerId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			ownerIdParameter.SourceValue = new ProcessSchemaParameterValue(ownerIdParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#SysVariable.CurrentUserContact#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(ownerIdParameter);
			var durationParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("622b9f2a-4cb2-43a8-8f4b-becabac69839"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Duration",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationParameter.SourceValue = new ProcessSchemaParameterValue(durationParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"5",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(durationParameter);
			var durationPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("acc42a39-4371-4da5-b7fc-d06c3e13ec03"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"DurationPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			durationPeriodParameter.SourceValue = new ProcessSchemaParameterValue(durationPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(durationPeriodParameter);
			var startInParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a5d59779-62f7-485f-b4a9-a0d09a870942"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"StartIn",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startInParameter.SourceValue = new ProcessSchemaParameterValue(startInParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInParameter);
			var startInPeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("43205693-5dcc-43f3-a331-b49c4bc9973d"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"StartInPeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			startInPeriodParameter.SourceValue = new ProcessSchemaParameterValue(startInPeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(startInPeriodParameter);
			var remindBeforeParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("d471d560-f33f-4ec8-b727-bf18cd94b7c2"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"RemindBefore",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforeParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforeParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforeParameter);
			var remindBeforePeriodParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e895a017-2743-4df7-be4f-c24ce2e71411"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"RemindBeforePeriod",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			remindBeforePeriodParameter.SourceValue = new ProcessSchemaParameterValue(remindBeforePeriodParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"0",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(remindBeforePeriodParameter);
			var showInSchedulerParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9dfce689-a334-4c71-8932-456ffbbfdca7"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowInScheduler",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showInSchedulerParameter.SourceValue = new ProcessSchemaParameterValue(showInSchedulerParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(showInSchedulerParameter);
			var showExecutionPageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("a9906e90-904c-47dc-a148-9c2ac1836a1f"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ShowExecutionPage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			showExecutionPageParameter.SourceValue = new ProcessSchemaParameterValue(showExecutionPageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb")
			};
			parametrizedElement.Parameters.Add(showExecutionPageParameter);
			var leadParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				UId = new Guid("3d2362be-d4ae-4a2b-b570-6dadadab9cfb"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Lead",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			leadParameter.SourceValue = new ProcessSchemaParameterValue(leadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(leadParameter);
			var accountParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				UId = new Guid("65dedf77-e2ac-4f6a-81b0-9b66c8145aa7"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Account",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			accountParameter.SourceValue = new ProcessSchemaParameterValue(accountParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(accountParameter);
			var contactParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				UId = new Guid("1663995d-0b3c-4b2c-a172-e140a6adcfc2"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contact",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contactParameter.SourceValue = new ProcessSchemaParameterValue(contactParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contactParameter);
			var opportunityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				UId = new Guid("eca4a8da-4536-4478-8fb8-db24bbdb8f90"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Opportunity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			opportunityParameter.SourceValue = new ProcessSchemaParameterValue(opportunityParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(opportunityParameter);
			var invoiceParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				UId = new Guid("972e2db6-3271-40c0-82a2-3d60f8cee668"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Invoice",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			invoiceParameter.SourceValue = new ProcessSchemaParameterValue(invoiceParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(invoiceParameter);
			var documentParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				UId = new Guid("1cea383e-0fcf-4a49-af48-76f2446e9056"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Document",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			documentParameter.SourceValue = new ProcessSchemaParameterValue(documentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(documentParameter);
			var incidentParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("40e4bd9f-a064-4a0a-9a39-d1d5e1f3a19c"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Incident",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			incidentParameter.SourceValue = new ProcessSchemaParameterValue(incidentParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(incidentParameter);
			var caseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				UId = new Guid("f2bc9f52-708a-476d-a06a-4e438caea1c8"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Case",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			caseParameter.SourceValue = new ProcessSchemaParameterValue(caseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(caseParameter);
			var activityResultParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("332854ec-8027-4a9f-be87-fd81e4c8cdc4"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityResult",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			activityResultParameter.SourceValue = new ProcessSchemaParameterValue(activityResultParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(activityResultParameter);
			var currentActivityIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8a4aa587-30b7-4d91-8af2-9c962132c668"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"CurrentActivityId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			currentActivityIdParameter.SourceValue = new ProcessSchemaParameterValue(currentActivityIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(currentActivityIdParameter);
			var isActivityCompletedParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8624a7a9-f290-4573-a493-1a331d465b0c"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"IsActivityCompleted",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			isActivityCompletedParameter.SourceValue = new ProcessSchemaParameterValue(isActivityCompletedParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"false",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(isActivityCompletedParameter);
			var executionContextParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("73499557-0a32-4d92-84b3-8bb67973374b"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = false,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ExecutionContext",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText")
			};
			executionContextParameter.SourceValue = new ProcessSchemaParameterValue(executionContextParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(executionContextParameter);
			var informationOnStepParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7bf7d250-d34e-4225-aaa6-dcddbf01f6d2"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"InformationOnStep",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType")
			};
			informationOnStepParameter.SourceValue = new ProcessSchemaParameterValue(informationOnStepParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(informationOnStepParameter);
			var orderParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				UId = new Guid("58d3775d-23b0-4670-9b6c-61eed72117e4"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Order",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			orderParameter.SourceValue = new ProcessSchemaParameterValue(orderParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(orderParameter);
			var requestsParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("8e07b990-896f-406b-b301-1ca5ad999a3b"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Requests",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			requestsParameter.SourceValue = new ProcessSchemaParameterValue(requestsParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(requestsParameter);
			var listingParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("33643c88-34dd-4205-98e0-a9d17513a406"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Listing",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			listingParameter.SourceValue = new ProcessSchemaParameterValue(listingParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(listingParameter);
			var propertyParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e6e31938-0b0f-4bba-a9bb-1722f1b6c875"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Property",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			propertyParameter.SourceValue = new ProcessSchemaParameterValue(propertyParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(propertyParameter);
			var contractParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				UId = new Guid("4ac1b552-b731-4e7f-a4aa-2104b7d151c1"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Contract",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			contractParameter.SourceValue = new ProcessSchemaParameterValue(contractParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(contractParameter);
			var projectParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				UId = new Guid("7abadf0a-2e61-4b8b-ae34-40e154e2bae6"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Project",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			projectParameter.SourceValue = new ProcessSchemaParameterValue(projectParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(projectParameter);
			var problemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("7ec5366d-8edf-4b7d-b94b-2bc2655cf230"),
				UId = new Guid("4790f3c7-f104-4440-a586-b32ca6f69887"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Problem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			problemParameter.SourceValue = new ProcessSchemaParameterValue(problemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(problemParameter);
			var changeParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				UId = new Guid("ee3e666e-6999-4800-8719-42b69d82985f"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Change",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			changeParameter.SourceValue = new ProcessSchemaParameterValue(changeParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(changeParameter);
			var releaseParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				UId = new Guid("e2b728c6-93b7-493c-978a-05eb21b9cdf3"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"Release",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			releaseParameter.SourceValue = new ProcessSchemaParameterValue(releaseParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(releaseParameter);
			var createActivityParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("14076b06-efec-4aed-89e3-2c03796d1f8d"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"CreateActivity",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			createActivityParameter.SourceValue = new ProcessSchemaParameterValue(createActivityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"true",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(createActivityParameter);
			var activityPriorityParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				UId = new Guid("1d9d7996-7757-41f9-b627-e742a0b24a2e"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				Name = @"ActivityPriority",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			activityPriorityParameter.SourceValue = new ProcessSchemaParameterValue(activityPriorityParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"ab96fa02-7fe6-df11-971b-001d60e938c6",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603")
			};
			parametrizedElement.Parameters.Add(activityPriorityParameter);
			var confItemParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("ad707075-cf25-40bf-85c1-f5da38cf0d5d"),
				UId = new Guid("3210c491-5bf8-4c44-809f-2ccea5bab678"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ConfItem",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			confItemParameter.SourceValue = new ProcessSchemaParameterValue(confItemParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(confItemParameter);
			var eventParameter = new ProcessSchemaParameter(this) {
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				UId = new Guid("f2efe05d-aea3-45b2-ac3b-b435686ba5c7"),
				ContainerUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"Event",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Lookup")
			};
			eventParameter.SourceValue = new ProcessSchemaParameterValue(eventParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(eventParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet1 = CreateLaneSet1LaneSet();
			LaneSets.Add(schemaLaneSet1);
			ProcessSchemaLane schemaLane1 = CreateLane1Lane();
			schemaLaneSet1.Lanes.Add(schemaLane1);
			ProcessSchemaTerminateEvent terminate1 = CreateTerminate1TerminateEvent();
			FlowElements.Add(terminate1);
			ProcessSchemaStartSignalEvent creatednewincidentstartsignal = CreateCreatedNewIncidentStartSignalStartSignalEvent();
			FlowElements.Add(creatednewincidentstartsignal);
			ProcessSchemaStartSignalEvent modifiedinactiveincidentstartsignal = CreateModifiedInactiveIncidentStartSignalStartSignalEvent();
			FlowElements.Add(modifiedinactiveincidentstartsignal);
			ProcessSchemaUserTask adddiagnosetask = CreateAddDiagnoseTaskUserTask();
			FlowElements.Add(adddiagnosetask);
			ProcessSchemaUserTask readcasedata = CreateReadCaseDataUserTask();
			FlowElements.Add(readcasedata);
			ProcessSchemaExclusiveGateway exclusivegateway1 = CreateExclusiveGateway1ExclusiveGateway();
			FlowElements.Add(exclusivegateway1);
			ProcessSchemaIntermediateCatchSignalEvent resolvedcatchsignal = CreateResolvedCatchSignalIntermediateCatchSignalEvent();
			FlowElements.Add(resolvedcatchsignal);
			ProcessSchemaEventBasedGateway eventbasedgateway1 = CreateEventBasedGateway1EventBasedGateway();
			FlowElements.Add(eventbasedgateway1);
			ProcessSchemaUserTask resolvedchangedatausertask = CreateResolvedChangeDataUserTaskUserTask();
			FlowElements.Add(resolvedchangedatausertask);
			ProcessSchemaIntermediateCatchSignalEvent canceledcatchsignal = CreateCanceledCatchSignalIntermediateCatchSignalEvent();
			FlowElements.Add(canceledcatchsignal);
			ProcessSchemaUserTask canceledchangedatausertask = CreateCanceledChangeDataUserTaskUserTask();
			FlowElements.Add(canceledchangedatausertask);
			ProcessSchemaIntermediateCatchSignalEvent pendingcatchsignal = CreatePendingCatchSignalIntermediateCatchSignalEvent();
			FlowElements.Add(pendingcatchsignal);
			ProcessSchemaUserTask pendingchangedatausertask = CreatePendingChangeDataUserTaskUserTask();
			FlowElements.Add(pendingchangedatausertask);
			ProcessSchemaIntermediateCatchSignalEvent escalationcatchsignal = CreateEscalationCatchSignalIntermediateCatchSignalEvent();
			FlowElements.Add(escalationcatchsignal);
			ProcessSchemaUserTask escalationchangedatausertask = CreateEscalationChangeDataUserTaskUserTask();
			FlowElements.Add(escalationchangedatausertask);
			ProcessSchemaScriptTask existsdiagnoseincidenttask = CreateExistsDiagnoseIncidentTaskScriptTask();
			FlowElements.Add(existsdiagnoseincidenttask);
			ProcessSchemaUserTask readcasecountdatausertask = CreateReadCaseCountDataUserTaskUserTask();
			FlowElements.Add(readcasecountdatausertask);
			ProcessSchemaUserTask completetaskschangedatausertask = CreateCompleteTasksChangeDataUserTaskUserTask();
			FlowElements.Add(completetaskschangedatausertask);
			ProcessSchemaUserTask canceltaskschangedatausertask = CreateCancelTasksChangeDataUserTaskUserTask();
			FlowElements.Add(canceltaskschangedatausertask);
			ProcessSchemaTerminateEvent terminateevent1 = CreateTerminateEvent1TerminateEvent();
			FlowElements.Add(terminateevent1);
			ProcessSchemaFormulaTask setcurrenttask = CreateSetCurrentTaskFormulaTask();
			FlowElements.Add(setcurrenttask);
			ProcessSchemaIntermediateCatchSignalEvent rescheduledcatchsignal = CreateRescheduledCatchSignalIntermediateCatchSignalEvent();
			FlowElements.Add(rescheduledcatchsignal);
			ProcessSchemaUserTask addrescheduledtaskusertask = CreateAddRescheduledTaskUserTaskUserTask();
			FlowElements.Add(addrescheduledtaskusertask);
			ProcessSchemaUserTask openresheduledtaskeditpageusertask = CreateOpenResheduledTaskEditPageUserTaskUserTask();
			FlowElements.Add(openresheduledtaskeditpageusertask);
			ProcessSchemaFormulaTask setrescheduledtaskformula = CreateSetRescheduledTaskFormulaFormulaTask();
			FlowElements.Add(setrescheduledtaskformula);
			ProcessSchemaUserTask userquestionusertask1 = CreateUserQuestionUserTask1UserTask();
			FlowElements.Add(userquestionusertask1);
			ProcessSchemaScriptTask scripttask1 = CreateScriptTask1ScriptTask();
			FlowElements.Add(scripttask1);
			FlowElements.Add(CreateDefaultSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow4SequenceFlow());
			FlowElements.Add(CreateSequenceFlow6SequenceFlow());
			FlowElements.Add(CreateSequenceFlow5SequenceFlow());
			FlowElements.Add(CreateSequenceFlow7SequenceFlow());
			FlowElements.Add(CreateSequenceFlow8SequenceFlow());
			FlowElements.Add(CreateSequenceFlow11SequenceFlow());
			FlowElements.Add(CreateSequenceFlow12SequenceFlow());
			FlowElements.Add(CreateSequenceFlow13SequenceFlow());
			FlowElements.Add(CreateSequenceFlow14SequenceFlow());
			FlowElements.Add(CreateSequenceFlow15SequenceFlow());
			FlowElements.Add(CreateSequenceFlow16SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow1ConditionalFlow());
			FlowElements.Add(CreateDefaultSequenceFlow2SequenceFlow());
			FlowElements.Add(CreateDefaultSequenceFlow3SequenceFlow());
			FlowElements.Add(CreateSequenceFlow17SequenceFlow());
			FlowElements.Add(CreateSequenceFlow18SequenceFlow());
			FlowElements.Add(CreateSequenceFlow19SequenceFlow());
			FlowElements.Add(CreateSequenceFlow20SequenceFlow());
			FlowElements.Add(CreateSequenceFlow21SequenceFlow());
			FlowElements.Add(CreateSequenceFlow23SequenceFlow());
			FlowElements.Add(CreateSequenceFlow24SequenceFlow());
			FlowElements.Add(CreateSequenceFlow22SequenceFlow());
			FlowElements.Add(CreateSequenceFlow9SequenceFlow());
			FlowElements.Add(CreateSequenceFlow10SequenceFlow());
			FlowElements.Add(CreateConditionalSequenceFlow2ConditionalFlow());
			FlowElements.Add(CreateConditionalSequenceFlow4ConditionalFlow());
			FlowElements.Add(CreateConditionalSequenceFlow3ConditionalFlow());
			FlowElements.Add(CreateSequenceFlow25SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow1",
				UId = new Guid("c124d32d-f4a9-4025-b54f-a3391f71f23b"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(261, 218),
				SequenceFlowStartPointPosition = new Point(224, 218),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b4dbfeb1-c536-4a67-b205-344a03d90f82"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("f7662a09-75e5-455d-8553-82e904aa11ad"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b4dbfeb1-c536-4a67-b205-344a03d90f82"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(196, 283));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("9f5f64ec-a801-47fc-b0ea-27e0de2a22fe"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b4dbfeb1-c536-4a67-b205-344a03d90f82"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(196, 146));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow3",
				UId = new Guid("d8fd141a-30c6-4788-8953-322cf033900c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(355, 218),
				SequenceFlowStartPointPosition = new Point(330, 218),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a5470c4b-b56a-4a48-87ba-c46af633f521"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow4SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow4",
				UId = new Guid("5cb5ec46-0721-46b5-9799-5590ce948346"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(554, 297));
			schemaFlow.PolylinePointPositions.Add(new Point(554, 216));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow6SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow6",
				UId = new Guid("e46dfcaa-8c91-42ba-b744-c74675968500"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b64d7413-4571-4a80-9683-fa8ed03cf197"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow5SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow5",
				UId = new Guid("27df56ec-5d63-4321-83cd-50eb7792d19d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("1ae2d9da-9762-47c2-8ddd-7f67b805d1fb"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(616, 311));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow7SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow7",
				UId = new Guid("16bbe664-2448-407b-aaba-79333d218be9"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b64d7413-4571-4a80-9683-fa8ed03cf197"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(616, 402));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow8SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow8",
				UId = new Guid("3d580ae9-3f3c-4ac2-b3a7-e9cfa1641be7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("1ae2d9da-9762-47c2-8ddd-7f67b805d1fb"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow11SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow11",
				UId = new Guid("f0938080-5382-4c81-8259-c7a180aa2897"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d7674af7-e199-4c72-821d-36401cba0d75"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow12SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow12",
				UId = new Guid("d39a07da-9daf-4306-bb48-9245659c53f1"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d7674af7-e199-4c72-821d-36401cba0d75"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(769, 216));
			schemaFlow.PolylinePointPositions.Add(new Point(769, 217));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow13SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow13",
				UId = new Guid("88874a96-92e7-4a97-9b28-4e07557e2b8f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("04869428-40a4-4d45-ba84-5c89ce37b217"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow14SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow14",
				UId = new Guid("cc7f219c-ad11-4ca7-8f46-b569809b644d"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("9465eae5-e8e5-47ca-be99-632bc3fcb44c"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(616, 132));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow15SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow15",
				UId = new Guid("f2e5c1bb-4171-4280-a270-9e8df84c77d8"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("9465eae5-e8e5-47ca-be99-632bc3fcb44c"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow16SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow16",
				UId = new Guid("3c48c743-4e11-4ceb-b7b1-cab3b3738212"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("04869428-40a4-4d45-ba84-5c89ce37b217"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1099, 132));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow1ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow1",
				UId = new Guid("1d38db98-8dc6-4042-9109-8a7749040b55"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{ecd8a32c-df30-44e9-89f6-3adc6c3bdfd8}]#]",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a5470c4b-b56a-4a48-87ba-c46af633f521"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			schemaFlow.PolylinePointPositions.Add(new Point(506, 217));
			schemaFlow.PolylinePointPositions.Add(new Point(506, 216));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow2",
				UId = new Guid("46a79fd0-8e80-43fd-854c-d322f0116884"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("a5470c4b-b56a-4a48-87ba-c46af633f521"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("7f8b1890-288d-4ede-ac71-15b759489e77"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateDefaultSequenceFlow3SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Default) {
				Name = "DefaultSequenceFlow3",
				UId = new Guid("fb04edf5-8ee9-435c-a469-f023d2bf3090"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("04869428-40a4-4d45-ba84-5c89ce37b217"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(998, 246));
			schemaFlow.PolylinePointPositions.Add(new Point(1099, 246));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow17SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow17",
				UId = new Guid("5f1814a8-43e5-487c-b104-63caf0fb92f2"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("815ee92a-d5be-44c7-9cb1-07a1bdb1fc7f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1372, 258));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow18SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow18",
				UId = new Guid("658297d6-6ddf-444a-a55a-61611c75576f"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("815ee92a-d5be-44c7-9cb1-07a1bdb1fc7f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1372, 432));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow19SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow19",
				UId = new Guid("e55b9f8f-6e8d-499c-ba83-9b1e260b2711"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("70881c66-7559-4967-b02f-2bb93def217f"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow20SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow20",
				UId = new Guid("e05747d6-2f01-455e-8c6c-8bf413fcc734"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("70881c66-7559-4967-b02f-2bb93def217f"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow21SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow21",
				UId = new Guid("bba41f6b-07a5-4a16-ae3b-94b29cdfee95"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086"),
				SourceSequenceFlowPointLocalPosition = new Point(0, -1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow23SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow23",
				UId = new Guid("2f328f1d-76a7-4371-a547-f5bcaffd91af"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 1),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("d3611d33-118c-47cc-a393-7f8025bbd3f8"),
				TargetSequenceFlowPointLocalPosition = new Point(0, -1),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow24SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow24",
				UId = new Guid("ac653afe-76e7-4e26-ba63-b2216690aa33"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("d3611d33-118c-47cc-a393-7f8025bbd3f8"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow22SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow22",
				UId = new Guid("a81be806-38eb-4b86-a29a-615e6c038463"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				SourceSequenceFlowPointLocalPosition = new Point(-1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				TargetSequenceFlowPointLocalPosition = new Point(1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow9SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow9",
				UId = new Guid("16155d91-0c1b-4224-8711-7b822b39a47c"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(925, 311));
			schemaFlow.PolylinePointPositions.Add(new Point(925, 354));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow10SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow10",
				UId = new Guid("6b232d69-35ab-4654-8a10-827443a21369"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			schemaFlow.PolylinePointPositions.Add(new Point(925, 402));
			schemaFlow.PolylinePointPositions.Add(new Point(925, 354));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow2ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow2",
				UId = new Guid("c441e48e-09cc-4a19-81e6-f377ad5c0d0c"),
				ConditionExpression = @"[#[IsOwnerSchema:false].[IsSchema:false].[Element:{e056d00a-f1bb-41c3-b364-ba74262573fd}].[Parameter:{399de72a-ef6d-4a47-b355-3086cf7cc0cd}]#]>0",
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow4ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow4",
				UId = new Guid("74d3d11b-a9f9-4b35-93b4-796e21acc9c4"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"), new Collection<Guid>() {
						new Guid("3fa4de2d-80ff-495a-b7c5-927d62fd5baa"),
					}},
				}
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1216, 354));
			schemaFlow.PolylinePointPositions.Add(new Point(1216, 432));
			return schemaFlow;
		}

		protected virtual ProcessSchemaConditionalFlow CreateConditionalSequenceFlow3ConditionalFlow() {
			ProcessSchemaConditionalFlow schemaFlow = new ProcessSchemaConditionalFlow(this) {
				Name = "ConditionalSequenceFlow3",
				UId = new Guid("f6bd99ed-2ff7-4c65-82fd-851a090f22e7"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
					{new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"), new Collection<Guid>() {
						new Guid("624264a7-1527-482e-a850-cf14eeda9305"),
					}},
				}
			};
			schemaFlow.PolylinePointPositions.Add(new Point(1217, 354));
			schemaFlow.PolylinePointPositions.Add(new Point(1217, 258));
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow25SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow25",
				UId = new Guid("94c617e9-8815-4fc9-ad4b-612ef616a019"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("7f8b1890-288d-4ede-ac71-15b759489e77"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet1LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet1 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("12402efe-b2f1-4a22-8403-6b47a8fd7f7e"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"LaneSet1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet1;
		}

		protected virtual ProcessSchemaLane CreateLane1Lane() {
			ProcessSchemaLane schemaLane1 = new ProcessSchemaLane(this) {
				UId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("12402efe-b2f1-4a22-8403-6b47a8fd7f7e"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"Lane1",
				Position = new Point(0, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane1;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminate1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("04869428-40a4-4d45-ba84-5c89ce37b217"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"Terminate1",
				Position = new Point(1086, 204),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateCreatedNewIncidentStartSignalStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Inserted,
				HasEntityColumnChange = false,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"CreatedNewIncidentStartSignal",
				NewEntityChangedColumns = false,
				Position = new Point(79, 133),
				SerializeToDB = false,
				Signal = @"Case",
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			InitializeCreatedNewIncidentStartSignalParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaStartSignalEvent CreateModifiedInactiveIncidentStartSignalStartSignalEvent() {
			ProcessSchemaStartSignalEvent schemaStartSignalEvent = new ProcessSchemaStartSignalEvent(this) {	UId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1129e72f-0e8c-445a-b2ea-463517e86395"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ModifiedInactiveIncidentStartSignal",
				NewEntityChangedColumns = false,
				Position = new Point(79, 270),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaStartSignalEvent.EntityChangedColumns.Add("70620d00-e4ea-48d1-9fdc-4572fcd8d41b");
			schemaStartSignalEvent.EntityChangedColumns.Add("a71adaea-3464-4dee-bb4f-c7a535450ad7");
			InitializeModifiedInactiveIncidentStartSignalParameters(schemaStartSignalEvent);
			return schemaStartSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateAddDiagnoseTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"AddDiagnoseTask",
				Position = new Point(450, 270),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddDiagnoseTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadCaseDataUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ReadCaseData",
				Position = new Point(261, 190),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCaseDataParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaExclusiveGateway CreateExclusiveGateway1ExclusiveGateway() {
			ProcessSchemaExclusiveGateway gateway = new ProcessSchemaExclusiveGateway(this) {
				UId = new Guid("b4dbfeb1-c536-4a67-b205-344a03d90f82"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ExclusiveGateway1",
				Position = new Point(169, 190),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateResolvedCatchSignalIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("b64d7413-4571-4a80-9683-fa8ed03cf197"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ResolvedCatchSignal",
				NewEntityChangedColumns = false,
				Position = new Point(695, 389),
				SerializeToDB = true,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("a71adaea-3464-4dee-bb4f-c7a535450ad7");
			InitializeResolvedCatchSignalParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaEventBasedGateway CreateEventBasedGateway1EventBasedGateway() {
			ProcessSchemaEventBasedGateway gateway = new ProcessSchemaEventBasedGateway(this) {
				UId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				Instantiate = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ddbda75-9cac-4e42-b94c-5cf1edb45846"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"EventBasedGateway1",
				Position = new Point(589, 189),
				SerializeToDB = false,
				Size = new Size(55, 55),
				UseBackgroundMode = false
			};
			return gateway;
		}

		protected virtual ProcessSchemaUserTask CreateResolvedChangeDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ResolvedChangeDataUserTask",
				Position = new Point(817, 375),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeResolvedChangeDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateCanceledCatchSignalIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("1ae2d9da-9762-47c2-8ddd-7f67b805d1fb"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"CanceledCatchSignal",
				NewEntityChangedColumns = false,
				Position = new Point(695, 298),
				SerializeToDB = true,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("a71adaea-3464-4dee-bb4f-c7a535450ad7");
			InitializeCanceledCatchSignalParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateCanceledChangeDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("469548be-7215-434c-8fda-7e541797fdf9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"CanceledChangeDataUserTask",
				Position = new Point(817, 284),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeCanceledChangeDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreatePendingCatchSignalIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("d7674af7-e199-4c72-821d-36401cba0d75"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"PendingCatchSignal",
				NewEntityChangedColumns = false,
				Position = new Point(695, 203),
				SerializeToDB = true,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("a71adaea-3464-4dee-bb4f-c7a535450ad7");
			InitializePendingCatchSignalParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreatePendingChangeDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"PendingChangeDataUserTask",
				Position = new Point(817, 190),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializePendingChangeDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateEscalationCatchSignalIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("9465eae5-e8e5-47ca-be99-632bc3fcb44c"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"EscalationCatchSignal",
				NewEntityChangedColumns = false,
				Position = new Point(695, 119),
				SerializeToDB = true,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("70620d00-e4ea-48d1-9fdc-4572fcd8d41b");
			schemaCatchSignalEvent.EntityChangedColumns.Add("9147230c-ab53-4eb4-b0b4-ac78be6f8326");
			InitializeEscalationCatchSignalParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateEscalationChangeDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"EscalationChangeDataUserTask",
				Position = new Point(817, 105),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeEscalationChangeDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateExistsDiagnoseIncidentTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("a5470c4b-b56a-4a48-87ba-c46af633f521"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ExistsDiagnoseIncidentTask",
				Position = new Point(355, 190),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,146,79,107,2,49,16,197,239,130,223,33,120,90,65,66,207,107,43,200,214,202,66,91,172,127,218,67,233,97,216,12,26,154,77,108,50,177,221,111,223,89,119,69,145,218,171,183,236,228,205,155,223,78,222,14,188,8,85,152,121,87,96,8,19,75,154,170,5,26,44,72,220,9,139,223,162,45,21,27,44,225,37,162,175,146,85,64,159,57,107,89,163,157,149,167,130,39,176,176,70,63,16,189,197,153,103,175,63,236,118,254,30,36,199,74,101,206,196,210,38,39,109,251,134,29,211,225,94,58,199,194,121,149,43,166,154,35,168,12,2,222,3,129,156,99,136,134,26,59,57,69,90,86,91,108,221,94,193,68,188,157,70,173,70,73,47,87,255,17,60,104,67,232,67,77,146,92,144,100,30,129,176,17,190,105,218,204,192,67,137,117,87,210,20,51,87,110,193,235,224,108,205,32,39,95,17,12,47,162,49,225,241,131,179,63,233,95,135,231,253,184,226,71,183,78,115,149,30,11,31,146,207,205,75,202,213,30,185,189,88,93,15,119,204,41,219,177,79,90,63,121,122,216,38,147,18,80,12,140,248,236,136,207,158,80,29,164,205,85,139,92,71,168,112,166,134,224,180,114,124,46,0,114,118,154,111,14,79,43,62,75,122,127,40,186,157,60,44,33,124,78,126,116,160,192,102,71,103,153,185,104,73,140,196,13,15,245,72,209,91,65,62,98,221,244,11,17,141,3,122,101,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateReadCaseCountDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ReadCaseCountDataUserTask",
				Position = new Point(964, 327),
				SchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeReadCaseCountDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateCompleteTasksChangeDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"CompleteTasksChangeDataUserTask",
				Position = new Point(1252, 231),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeCompleteTasksChangeDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateCancelTasksChangeDataUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"CancelTasksChangeDataUserTask",
				Position = new Point(1251, 405),
				SchemaUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeCancelTasksChangeDataUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaTerminateEvent CreateTerminateEvent1TerminateEvent() {
			ProcessSchemaTerminateEvent schemaTerminateEvent = new ProcessSchemaTerminateEvent(this) {
				UId = new Guid("815ee92a-d5be-44c7-9cb1-07a1bdb1fc7f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"TerminateEvent1",
				Position = new Point(1359, 341),
				SerializeToDB = false,
				Size = new Size(27, 27),
				ThrowToBase = false,
				UseBackgroundMode = false
			};
			
			return schemaTerminateEvent;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetCurrentTaskFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("70881c66-7559-4967-b02f-2bb93def217f"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"SetCurrentTask",
				Position = new Point(450, 361),
				ResultParameterMetaPath = @"ae73a291-5391-4398-ad71-c61091bd78fe",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,139,49,15,194,32,20,6,127,76,231,103,128,71,227,131,221,193,169,38,142,13,3,224,71,28,74,7,218,196,161,233,127,23,87,199,187,203,205,195,124,223,166,207,138,246,204,111,212,232,75,92,54,132,75,183,127,226,182,160,98,221,253,33,26,73,233,98,9,214,56,178,198,40,146,209,50,153,34,233,71,47,199,233,236,195,35,182,88,177,163,249,67,247,206,80,160,44,204,100,115,255,92,26,53,93,145,89,36,69,54,92,206,48,132,47,137,4,102,212,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaIntermediateCatchSignalEvent CreateRescheduledCatchSignalIntermediateCatchSignalEvent() {
			ProcessSchemaIntermediateCatchSignalEvent schemaCatchSignalEvent = new ProcessSchemaIntermediateCatchSignalEvent(this) {
				UId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086"),
				AttachedToUId = Guid.Empty,
				BoundaryItemAlignment = ProcessSchemaEditItemAlignment.None,
				CancelActivity = false,
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"RescheduledCatchSignal",
				NewEntityChangedColumns = false,
				Position = new Point(471, 444),
				SerializeToDB = true,
				Size = new Size(27, 27),
				UseBackgroundMode = false,
				WaitingEntitySignal = true,
				WaitingRandomSignal = false
			};
			schemaCatchSignalEvent.EntityChangedColumns.Add("ae372cfa-a21f-47f0-8a64-17d137ebe966");
			schemaCatchSignalEvent.EntityChangedColumns.Add("c8d84f9c-b48b-479b-9ac6-4412f3436ca2");
			InitializeRescheduledCatchSignalParameters(schemaCatchSignalEvent);
			return schemaCatchSignalEvent;
		}

		protected virtual ProcessSchemaUserTask CreateAddRescheduledTaskUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"AddRescheduledTaskUserTask",
				Position = new Point(450, 518),
				SchemaUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeAddRescheduledTaskUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenResheduledTaskEditPageUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"OpenResheduledTaskEditPageUserTask",
				Position = new Point(312, 518),
				SchemaUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenResheduledTaskEditPageUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaFormulaTask CreateSetRescheduledTaskFormulaFormulaTask() {
			ProcessSchemaFormulaTask FormulaTask = new ProcessSchemaFormulaTask(this) {
				UId = new Guid("d3611d33-118c-47cc-a393-7f8025bbd3f8"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"SetRescheduledTaskFormula",
				Position = new Point(312, 430),
				ResultParameterMetaPath = @"ae73a291-5391-4398-ad71-c61091bd78fe",
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,203,177,14,131,32,16,0,208,143,113,190,70,56,14,78,246,14,78,109,210,209,48,92,225,72,7,117,64,147,14,198,127,175,115,215,151,188,169,155,198,237,241,93,181,189,242,71,23,137,85,230,77,211,237,210,63,184,207,186,232,186,199,195,179,86,66,67,224,140,14,224,222,158,97,240,133,160,150,44,193,21,12,100,251,243,10,79,105,178,232,174,45,30,132,172,200,62,128,45,198,131,11,200,192,22,43,16,246,130,213,230,66,18,206,212,165,31,213,159,223,210,142,0,0,0 }
			};
			
			return FormulaTask;
		}

		protected virtual ProcessSchemaUserTask CreateUserQuestionUserTask1UserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"UserQuestionUserTask1",
				Position = new Point(1113, 327),
				SchemaUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				SerializeToDB = true,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeUserQuestionUserTask1Parameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaScriptTask CreateScriptTask1ScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("7f8b1890-288d-4ede-ac71-15b759489e77"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("d1efc494-00a3-4188-8c97-7c81e848542c"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd"),
				CreatedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"),
				Name = @"ScriptTask1",
				Position = new Point(355, 270),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,205,10,131,48,16,132,239,62,197,94,132,104,169,149,150,246,34,61,136,66,79,61,217,62,64,208,61,4,218,8,113,19,232,219,55,49,253,73,196,75,32,179,59,223,76,98,184,130,137,184,162,150,19,194,25,238,19,170,102,148,18,123,18,163,44,26,173,20,74,114,106,113,65,250,92,221,238,77,60,145,101,85,34,36,121,192,85,72,61,35,126,184,194,75,85,18,207,25,99,161,176,131,99,6,27,216,67,14,145,158,58,125,30,230,238,72,225,84,86,137,177,117,13,127,68,41,245,48,120,203,196,182,203,108,91,48,124,157,181,134,235,65,220,98,49,162,119,216,143,114,136,232,94,178,166,218,254,147,17,244,234,214,204,255,113,171,113,141,252,45,114,40,45,74,33,105,37,129,148,198,234,13,76,222,139,204,151,1,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new IncidentDiagnosticsAndResolvingV2(userConnection);
		}

		public override object Clone() {
			return new IncidentDiagnosticsAndResolvingV2Schema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb"));
		}

		#endregion

	}

	#endregion

	#region Class: IncidentDiagnosticsAndResolvingV2

	/// <exclude/>
	public class IncidentDiagnosticsAndResolvingV2 : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: AddDiagnoseTaskFlowElement

		/// <exclude/>
		public class AddDiagnoseTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddDiagnoseTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddDiagnoseTask";
				IsLogging = true;
				SchemaElementUId = new Guid("81eb01f4-e429-4220-8543-2f8b4220d93b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_ActivityCategory = () => (Guid)(new Guid("f51c4643-58e6-df11-971b-001d60e938c6"));
				_recordDefValues_Owner = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_recordDefValues_Contact = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
				_recordDefValues_Case = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_recordDefValues_Title = () => new LocalizableString((process.TaskCaption)+ " #"+((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<string>("Number") : null)));
				_recordDefValues_Account = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
				_recordDefValues_DueDate = () => (DateTime)((process.ActivityDueDate));
				_recordDefValues_StartDate = () => (DateTime)((process.ActivityStartDate));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_ActivityCategory", () => _recordDefValues_ActivityCategory.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Case", () => _recordDefValues_Case.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Title", () => _recordDefValues_Title.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_DueDate", () => _recordDefValues_DueDate.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_StartDate", () => _recordDefValues_StartDate.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_ActivityCategory;
			internal Func<Guid> _recordDefValues_Owner;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_Case;
			internal Func<string> _recordDefValues_Title;
			internal Func<Guid> _recordDefValues_Account;
			internal Func<DateTime> _recordDefValues_DueDate;
			internal Func<DateTime> _recordDefValues_StartDate;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,153,91,111,83,71,16,199,191,138,117,224,141,172,181,247,75,222,40,80,41,18,180,17,161,188,16,30,102,119,103,131,133,99,71,246,49,85,26,229,187,247,127,156,4,18,74,115,81,21,10,138,253,144,200,39,103,118,103,103,230,55,51,59,57,233,30,247,199,71,220,109,119,191,236,190,218,155,183,126,252,108,190,224,241,238,98,94,120,185,28,191,156,23,154,78,254,162,60,229,93,90,208,33,247,188,120,75,211,21,47,95,78,150,253,214,232,178,80,183,213,61,254,180,254,91,183,253,238,164,219,233,249,240,143,157,138,149,173,97,142,217,122,65,46,70,97,139,38,145,155,179,34,135,76,213,72,85,154,139,16,46,243,233,234,112,246,138,123,218,165,254,67,183,125,210,173,87,195,2,37,42,219,40,40,193,82,101,97,141,118,130,74,172,34,86,75,58,25,174,202,196,238,116,171,91,150,15,124,72,235,77,47,9,91,155,106,52,90,144,45,69,216,44,149,200,169,58,17,73,233,98,53,165,22,211,32,124,254,254,23,193,119,143,94,206,231,31,87,71,227,228,21,107,25,161,191,210,216,190,234,32,178,76,78,88,153,21,123,91,125,41,114,220,156,42,214,91,35,92,100,47,106,83,74,164,0,109,165,84,213,75,78,38,22,255,232,253,176,81,157,44,143,166,116,252,246,95,247,123,90,250,201,167,73,127,60,42,212,243,193,124,113,60,126,51,31,213,249,153,244,209,21,55,92,150,63,217,63,243,229,126,183,189,255,109,111,158,255,222,91,155,233,170,63,175,186,114,191,219,218,239,246,230,171,69,25,86,51,248,242,252,146,210,235,13,214,175,124,245,245,194,119,120,50,91,77,167,231,79,158,83,79,23,47,94,60,158,215,73,155,112,221,153,237,93,184,108,189,138,60,255,192,106,255,248,113,241,57,211,237,191,136,189,162,25,29,240,226,55,28,255,139,238,159,181,124,3,19,94,44,156,117,114,50,168,38,2,83,18,150,189,70,204,41,18,73,165,220,76,48,186,53,189,150,126,205,141,23,60,43,124,85,177,219,68,206,185,252,114,109,237,1,154,115,189,6,83,157,118,167,167,91,151,81,66,92,133,26,216,9,37,171,18,86,213,34,98,178,85,120,153,115,74,206,7,110,233,90,148,154,12,198,55,50,34,164,97,129,224,165,32,246,73,36,207,197,249,148,140,77,234,62,80,122,183,179,252,253,207,25,47,206,236,179,221,104,186,228,247,99,60,253,234,193,139,41,31,242,172,223,62,137,205,5,203,46,139,224,181,133,162,90,139,36,225,4,83,154,119,200,26,153,40,158,66,224,115,24,111,159,4,114,138,108,212,162,20,239,97,28,23,4,5,239,132,12,181,17,39,150,205,231,65,228,197,172,7,93,207,214,54,130,148,244,90,86,68,11,91,38,97,225,95,145,26,236,106,93,208,173,84,228,24,5,169,155,208,125,205,84,193,235,146,71,21,129,52,254,117,178,88,246,163,9,252,54,154,183,209,130,151,171,105,63,153,29,140,224,152,41,3,239,249,108,252,116,185,156,28,204,152,55,88,255,116,88,43,159,217,120,167,68,108,172,135,64,75,144,175,32,41,74,83,173,143,166,86,115,39,172,61,234,67,115,25,26,184,97,65,141,82,151,29,194,23,145,235,20,98,183,73,69,215,98,157,27,81,42,161,137,98,60,74,172,149,56,145,81,208,72,5,239,101,163,166,108,124,88,88,123,147,124,179,158,69,177,169,9,219,50,188,229,36,122,6,109,163,79,173,73,155,205,125,96,253,108,62,235,169,244,27,170,55,84,35,222,44,15,133,63,86,131,52,163,67,94,243,40,60,103,14,172,157,247,100,175,165,218,134,98,107,177,1,145,171,177,64,149,44,8,197,91,52,157,98,206,90,22,52,190,15,139,106,98,201,214,21,26,168,70,27,213,24,82,38,85,97,40,7,29,34,43,175,194,125,80,189,83,55,64,255,124,64,163,87,198,75,40,206,58,32,88,156,177,34,90,220,203,20,34,78,41,87,56,149,122,167,50,45,217,197,96,137,69,32,137,152,109,140,114,18,179,19,26,48,23,163,109,50,229,250,50,13,154,155,36,163,68,104,53,0,104,84,124,146,210,162,245,84,38,171,0,13,205,255,218,125,95,230,179,212,108,157,183,66,161,127,128,170,5,164,181,92,5,233,154,168,164,64,164,215,245,243,201,104,191,27,61,218,239,158,252,200,105,35,228,88,216,103,43,116,66,238,176,18,135,201,76,67,147,149,91,200,200,178,210,210,205,105,227,13,45,63,34,109,28,13,25,225,202,193,239,158,79,126,91,29,102,94,108,114,202,119,207,41,168,29,198,181,117,103,12,126,108,241,136,159,228,73,24,52,237,228,169,81,105,229,186,156,114,107,197,110,155,83,82,67,214,24,232,170,20,204,48,219,66,147,208,112,151,240,236,107,108,197,100,153,111,184,209,103,89,125,195,173,85,5,68,180,37,164,19,82,14,19,50,155,49,142,42,190,202,135,214,250,103,229,140,212,37,1,239,130,141,106,130,69,26,14,133,187,153,132,185,169,54,86,247,114,163,47,101,190,154,109,90,255,159,175,83,208,174,134,162,40,11,85,89,162,83,24,48,24,238,208,82,163,223,116,20,116,245,124,199,78,193,84,237,67,16,184,190,131,106,137,105,119,194,138,34,89,203,153,50,53,163,245,245,157,130,196,192,152,113,34,229,50,38,2,222,32,99,229,236,5,74,151,9,129,178,45,41,255,40,157,66,8,42,5,28,78,43,28,216,230,136,241,190,198,140,223,33,23,37,24,213,219,228,111,198,237,98,232,253,124,197,112,241,102,42,246,253,33,170,90,33,165,54,43,138,68,219,103,165,210,240,35,102,215,141,20,69,21,84,37,107,191,107,105,108,1,165,209,180,40,130,11,160,186,105,131,48,206,13,195,238,152,149,135,78,58,155,107,33,26,194,157,156,137,194,43,140,127,108,146,97,24,237,54,33,85,242,73,121,212,131,90,127,16,136,136,208,158,74,204,167,24,5,14,187,25,252,207,192,32,131,73,204,5,125,114,217,96,212,127,123,136,246,122,90,244,27,140,190,197,195,131,192,232,253,233,223,100,146,53,0,216,29,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.AddDiagnoseTask.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordDefValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordDefValues", getColumnValue);
					}
					return _recordDefValues;
				}
				set {
					_recordDefValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadCaseDataFlowElement

		/// <exclude/>
		public class ReadCaseDataFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCaseDataFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCaseData";
				IsLogging = true;
				SchemaElementUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,79,219,64,16,253,43,145,207,44,178,247,203,222,220,218,52,173,56,80,80,65,92,8,135,245,238,56,89,213,95,90,59,80,26,229,191,119,108,135,52,160,64,67,37,84,85,194,167,245,232,205,204,155,217,157,55,171,192,228,186,105,190,234,2,130,113,240,241,252,244,162,202,218,227,207,46,111,193,127,241,213,178,14,142,130,6,188,211,185,251,9,118,176,79,173,107,63,233,86,163,195,106,246,219,127,22,140,103,251,34,204,130,163,89,224,90,40,26,68,160,67,108,164,180,194,80,98,68,70,9,207,76,66,82,17,102,36,78,89,18,243,88,113,154,169,1,185,63,244,164,42,106,237,97,200,208,7,207,250,227,229,125,221,1,35,52,152,30,226,154,170,220,24,89,71,161,153,150,58,205,193,226,127,235,151,128,166,214,187,2,43,129,75,87,192,185,246,152,169,139,83,117,38,4,101,58,111,58,84,14,89,59,253,81,123,104,26,87,149,47,83,203,151,69,185,139,69,119,216,254,110,200,132,61,195,14,121,174,219,69,31,224,4,73,173,123,142,31,230,115,15,115,221,186,219,93,10,223,225,190,199,29,214,59,116,176,120,63,87,58,95,194,78,206,199,117,76,116,221,14,229,12,233,17,224,221,124,113,96,165,219,110,253,169,88,138,198,250,1,124,80,196,189,252,169,68,227,109,103,24,98,60,28,103,193,245,73,115,118,87,130,191,48,11,40,244,208,177,155,99,180,62,49,76,115,40,160,108,199,43,165,109,162,88,12,68,106,161,8,215,210,144,84,166,33,97,212,68,145,136,51,46,132,89,163,195,150,208,120,5,169,84,58,206,24,193,230,75,194,169,162,36,161,92,18,150,24,170,128,135,82,80,181,190,25,136,187,166,206,245,253,213,150,223,196,3,62,39,59,42,225,110,228,74,227,44,146,56,254,6,166,242,182,191,117,252,208,77,178,48,145,97,20,17,5,33,39,92,72,32,169,209,138,68,140,49,97,5,19,73,242,62,20,207,12,197,97,189,123,31,138,151,134,194,64,6,148,135,148,88,202,129,112,41,41,81,84,38,36,100,70,210,148,67,162,109,248,100,40,180,149,9,103,161,33,140,153,148,240,52,4,162,98,25,19,45,169,13,133,142,67,145,166,207,13,197,105,101,93,230,112,42,92,169,77,119,173,219,209,24,221,185,118,49,66,69,71,161,30,161,78,184,121,9,240,100,94,186,129,201,171,185,51,58,63,171,193,227,187,232,197,42,218,47,242,143,182,67,39,35,190,170,218,161,15,91,17,154,232,6,15,59,111,74,91,160,130,178,148,36,34,65,145,160,138,227,155,66,161,85,93,205,145,145,25,235,82,172,113,59,118,74,117,81,45,189,217,108,164,102,88,139,127,181,240,254,193,34,123,205,118,218,187,31,14,81,252,255,83,205,95,45,205,239,215,119,253,218,235,123,67,221,121,75,165,88,7,235,95,1,166,224,188,58,11,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private int _resultType = 0;
			public override int ResultType {
				get {
					return _resultType;
				}
				set {
					_resultType = value;
				}
			}

			private bool _readSomeTopRecords = true;
			public override bool ReadSomeTopRecords {
				get {
					return _readSomeTopRecords;
				}
				set {
					_readSomeTopRecords = value;
				}
			}

			private int _numberOfRecords = 1;
			public override int NumberOfRecords {
				get {
					return _numberOfRecords;
				}
				set {
					_numberOfRecords = value;
				}
			}

			private int _functionType = 0;
			public override int FunctionType {
				get {
					return _functionType;
				}
				set {
					_functionType = value;
				}
			}

			private string _orderInfo;
			public override string OrderInfo {
				get {
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,43,205,77,74,45,178,50,180,50,212,241,76,177,50,176,50,0,0,237,33,101,51,17,0,0,0 })));
				}
				set {
					_orderInfo = value;
				}
			}

			private Entity _resultEntity;
			public override Entity ResultEntity {
				get {
					return _resultEntity ?? (_resultEntity =
						new Entity(UserConnection) {
							Schema = UserConnection.EntitySchemaManager.GetInstanceByUId(
								new Guid("117d32f9-8275-4534-8411-1c66115ce9cd")),
							UseAdminRights = false
						});
				}
				set {
					_resultEntity = value;
				}
			}

			private bool _canReadUncommitedData = false;
			public override bool CanReadUncommitedData {
				get {
					return _canReadUncommitedData;
				}
				set {
					_canReadUncommitedData = value;
				}
			}

			private EntityCollection _resultEntityCollection;
			public override EntityCollection ResultEntityCollection {
				get {
					if (_resultEntityCollection == null) {
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ResolvedCatchSignalFlowElement

		/// <exclude/>
		public class ResolvedCatchSignalFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public ResolvedCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "ResolvedCatchSignal";
				IsLogging = true;
				SchemaElementUId = new Guid("b64d7413-4571-4a80-9683-fa8ed03cf197");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""a71adaea-3464-4dee-bb4f-c7a535450ad7""]}";
				EntityFilters = @"{""className"":""BPMSoft.FilterGroup"",""serializedFilterEditData"":""{\""className\"":\""BPMSoft.FilterGroup\"",\""items\"":{\""1fac16a5-a625-4773-a4aa-287aceb4b093\"":{\""className\"":\""BPMSoft.InFilter\"",\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Status\""},\""isAggregative\"":false,\""key\"":\""1fac16a5-a625-4773-a4aa-287aceb4b093\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Status\"",\""referenceSchemaName\"":\""CaseStatus\"",\""rightExpressions\"":[{\""className\"":\""BPMSoft.ParameterExpression\"",\""expressionType\"":2,\""parameter\"":{\""className\"":\""BPMSoft.Parameter\"",\""dataValueType\"":10,\""value\"":{\""Id\"":\""ae7f411e-f46b-1410-009b-0050ba5d6c38\"",\""Name\"":\""Resolved\"",\""value\"":\""ae7f411e-f46b-1410-009b-0050ba5d6c38\"",\""displayValue\"":\""Resolved\""}}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\"",\""key\"":\""dadc7b7d-b990-430e-b79d-5376e1f8beb0\""}"",""dataSourceFilters"":""{\""items\"":{\""1fac16a5-a625-4773-a4aa-287aceb4b093\"":{\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Status\""},\""rightExpressions\"":[{\""expressionType\"":2,\""parameter\"":{\""dataValueType\"":10,\""value\"":\""ae7f411e-f46b-1410-009b-0050ba5d6c38\""}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\""}""}";
				_recordId = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: ResolvedChangeDataUserTaskFlowElement

		/// <exclude/>
		public class ResolvedChangeDataUserTaskFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public ResolvedChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ResolvedChangeDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("cc3ba7b8-b66a-4e6a-9d64-0c10df04ce80");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("4bdbb88f-58e6-df11-971b-001d60e938c6"));
				_recordColumnValues_Result = () => (Guid)(new Guid("ef46415c-8dc6-43cb-9caa-36e5a6651dcf"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Result", () => _recordColumnValues_Result.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;
			internal Func<Guid> _recordColumnValues_Result;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,79,219,64,16,254,43,145,207,44,242,218,139,31,185,81,160,21,135,22,164,32,46,132,195,236,122,54,89,225,151,118,215,180,20,229,191,119,108,135,52,180,17,77,171,62,144,154,67,98,127,249,102,246,155,231,62,6,170,4,231,62,64,133,193,52,120,115,249,126,214,104,127,248,214,148,30,237,59,219,116,109,112,16,56,180,6,74,243,25,139,17,63,43,140,63,5,15,100,240,56,255,106,63,15,166,243,93,30,230,193,193,60,48,30,43,71,12,50,200,85,170,69,162,144,137,88,43,38,162,56,101,178,136,4,211,160,34,93,64,42,49,230,35,115,183,235,147,166,106,193,226,120,194,224,92,15,143,87,15,109,79,228,4,168,129,98,92,83,175,193,184,151,224,206,106,144,37,22,244,238,109,135,4,121,107,42,138,4,175,76,133,151,96,233,164,222,79,211,67,68,210,80,186,158,85,162,246,103,159,90,139,206,153,166,126,89,90,217,85,245,54,151,204,113,243,186,22,19,14,10,123,230,37,248,229,224,224,156,68,173,6,141,199,139,133,197,5,120,115,191,45,225,14,31,6,222,126,185,35,131,130,234,115,13,101,135,91,103,62,143,227,4,90,63,134,51,30,79,4,107,22,203,61,35,221,100,235,71,193,70,4,182,79,228,189,60,238,212,31,37,4,222,247,192,232,227,233,113,30,220,156,187,139,143,53,218,153,90,98,5,99,198,110,15,9,253,6,216,248,159,62,2,166,49,68,57,103,71,49,125,137,56,207,24,20,41,103,42,225,97,206,101,145,102,26,87,183,163,14,227,218,18,30,174,55,199,157,116,214,98,237,39,30,220,221,228,252,116,32,245,233,163,191,34,20,42,7,17,51,197,143,36,19,97,18,49,25,74,201,82,46,143,242,40,3,158,115,77,101,166,15,217,164,42,206,242,20,128,37,105,92,48,145,10,201,242,84,32,11,115,201,181,130,12,179,255,111,10,102,30,124,231,104,119,212,198,45,247,27,136,253,210,184,163,161,120,244,226,68,172,165,140,63,19,227,38,218,212,80,190,246,41,25,130,122,26,141,33,85,235,110,43,155,133,81,80,94,180,104,41,147,131,232,112,119,51,60,235,162,126,232,108,211,248,113,148,54,98,142,21,85,195,120,170,192,86,37,16,164,72,128,107,150,8,29,82,37,98,234,126,41,99,86,132,145,44,18,20,153,86,253,146,163,251,164,87,61,107,58,171,214,221,235,198,139,228,151,174,136,127,208,244,63,179,207,119,246,202,62,213,127,45,251,239,207,174,182,87,90,189,217,247,123,232,183,21,242,175,143,232,42,88,125,1,74,211,73,71,229,9,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,219,48,16,252,21,131,201,209,52,248,18,31,190,181,205,37,64,82,24,117,155,75,156,195,146,92,54,66,101,201,176,164,0,169,225,127,47,173,216,141,221,103,128,162,135,2,229,65,2,87,59,179,203,89,142,54,228,188,123,92,33,153,146,215,179,235,121,147,186,201,155,102,141,147,217,186,9,216,182,147,171,38,64,85,126,6,95,225,12,214,176,196,14,215,55,80,245,216,94,149,109,55,30,29,131,200,152,156,63,12,223,200,244,118,67,46,59,92,126,184,140,153,153,91,203,192,7,79,147,22,146,42,144,142,130,49,130,90,19,80,0,216,130,37,200,224,208,84,253,178,190,198,14,102,208,221,147,233,134,12,108,153,32,216,104,85,114,129,122,101,61,85,198,121,234,32,104,170,20,23,73,42,169,3,8,178,29,147,54,220,227,18,134,162,71,96,165,92,180,82,80,80,33,80,229,25,167,222,197,130,90,224,34,40,1,46,89,183,3,239,243,159,129,183,103,87,77,243,169,95,77,44,43,0,2,42,106,53,83,84,49,52,20,28,122,202,82,161,184,81,133,147,129,77,148,143,222,91,155,104,97,81,211,152,56,167,206,240,156,196,120,212,12,157,180,65,159,221,237,10,197,178,93,85,240,120,243,211,122,175,66,87,62,148,221,227,168,237,160,235,219,44,238,114,85,101,229,227,19,126,117,50,136,99,134,205,226,105,154,11,50,93,252,120,158,251,247,124,16,234,116,162,167,195,92,144,241,130,204,155,126,29,118,108,50,111,46,142,218,30,10,12,41,223,108,15,211,203,145,186,175,170,125,228,2,58,56,36,30,194,77,44,83,137,241,178,158,31,134,54,176,176,253,202,186,125,247,56,172,167,222,254,4,118,13,53,124,196,245,219,124,252,231,222,191,118,249,62,75,120,32,246,194,21,204,240,68,13,130,163,10,117,190,182,145,3,117,220,249,36,141,20,41,137,1,253,14,19,174,177,14,120,218,216,75,238,206,30,223,14,106,239,108,179,239,107,39,213,150,108,183,227,99,51,169,40,132,21,152,40,51,153,85,21,144,27,66,43,104,84,34,198,164,188,135,88,252,210,76,128,210,136,144,128,130,200,199,82,38,177,108,5,173,40,55,145,75,131,30,157,214,127,209,76,82,56,31,153,70,154,92,145,203,91,161,40,176,228,169,45,48,102,45,147,112,202,78,48,41,173,120,17,178,214,59,155,203,252,239,112,1,128,74,141,5,104,93,240,24,210,11,205,148,117,237,171,110,212,164,17,236,109,53,153,103,109,186,178,169,71,169,233,235,255,166,250,247,76,245,146,59,244,59,83,221,109,191,0,225,143,220,87,251,6,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.ResolvedChangeDataUserTask.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: CanceledCatchSignalFlowElement

		/// <exclude/>
		public class CanceledCatchSignalFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public CanceledCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "CanceledCatchSignal";
				IsLogging = true;
				SchemaElementUId = new Guid("1ae2d9da-9762-47c2-8ddd-7f67b805d1fb");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""a71adaea-3464-4dee-bb4f-c7a535450ad7""]}";
				EntityFilters = @"{""className"":""BPMSoft.FilterGroup"",""serializedFilterEditData"":""{\""className\"":\""BPMSoft.FilterGroup\"",\""items\"":{\""5ab56440-a4b9-4680-b192-23bb1a7c7981\"":{\""className\"":\""BPMSoft.InFilter\"",\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Status\""},\""isAggregative\"":false,\""key\"":\""5ab56440-a4b9-4680-b192-23bb1a7c7981\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Status\"",\""referenceSchemaName\"":\""CaseStatus\"",\""rightExpressions\"":[{\""className\"":\""BPMSoft.ParameterExpression\"",\""expressionType\"":2,\""parameter\"":{\""className\"":\""BPMSoft.Parameter\"",\""dataValueType\"":10,\""value\"":{\""Id\"":\""6e5f4218-f46b-1410-fe9a-0050ba5d6c38\"",\""Name\"":\""Cancelled\"",\""value\"":\""6e5f4218-f46b-1410-fe9a-0050ba5d6c38\"",\""displayValue\"":\""Cancelled\""}}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\"",\""key\"":\""543091b1-97e0-45d2-b947-6fda16831f3c\""}"",""dataSourceFilters"":""{\""items\"":{\""5ab56440-a4b9-4680-b192-23bb1a7c7981\"":{\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Status\""},\""rightExpressions\"":[{\""expressionType\"":2,\""parameter\"":{\""dataValueType\"":10,\""value\"":\""6e5f4218-f46b-1410-fe9a-0050ba5d6c38\""}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\""}""}";
				_recordId = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: CanceledChangeDataUserTaskFlowElement

		/// <exclude/>
		public class CanceledChangeDataUserTaskFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public CanceledChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "CanceledChangeDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("469548be-7215-434c-8fda-7e541797fdf9");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("201cfba8-58e6-df11-971b-001d60e938c6"));
				_recordColumnValues_Result = () => (Guid)(new Guid("dbbf0e10-f46b-1410-6598-00155d043204"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Result", () => _recordColumnValues_Result.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;
			internal Func<Guid> _recordColumnValues_Result;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,111,218,64,16,254,43,200,231,108,100,239,26,219,203,45,77,210,42,135,54,72,68,185,132,28,102,237,49,172,226,151,118,215,105,105,196,127,239,216,6,74,90,148,210,170,143,72,229,0,246,199,55,51,223,188,118,159,188,180,0,107,63,64,137,222,196,123,51,125,63,171,115,119,250,86,23,14,205,59,83,183,141,119,226,89,52,26,10,253,25,179,1,191,204,180,187,0,7,100,240,52,255,106,63,247,38,243,67,30,230,222,201,220,211,14,75,75,12,50,0,197,211,48,144,17,83,92,33,11,69,224,51,37,69,204,146,24,253,32,11,67,161,178,100,96,30,118,125,94,151,13,24,28,34,244,206,243,254,241,102,213,116,196,128,128,180,167,104,91,87,27,80,116,18,236,101,5,170,192,140,222,157,105,145,32,103,116,73,153,224,141,46,113,10,134,34,117,126,234,14,34,82,14,133,237,88,5,230,238,242,83,99,208,90,93,87,47,75,43,218,178,218,231,146,57,238,94,55,98,252,94,97,199,156,130,91,246,14,174,72,212,186,215,120,182,88,24,92,128,211,143,251,18,30,112,213,243,142,171,29,25,100,212,159,91,40,90,220,139,249,60,143,115,104,220,144,206,16,158,8,70,47,150,71,102,186,171,214,143,146,229,4,54,91,242,81,30,15,234,231,17,129,143,29,48,248,216,62,206,189,187,43,123,253,177,66,51,75,151,88,194,80,177,251,83,66,191,1,118,254,39,79,128,177,0,46,3,54,22,244,21,10,153,48,200,226,128,165,81,224,203,64,101,113,146,227,250,126,208,161,109,83,192,234,118,23,238,188,53,6,43,55,114,96,31,70,87,23,61,169,43,31,253,21,137,68,160,18,138,113,129,17,11,125,63,96,74,41,96,153,200,85,146,98,200,195,204,167,54,211,135,108,198,121,154,38,10,21,147,145,228,68,14,19,150,160,20,108,28,65,28,197,145,136,165,244,255,183,45,152,57,112,173,165,179,163,210,118,121,220,66,28,87,198,3,3,21,240,23,55,98,35,101,248,25,105,59,202,117,5,197,107,223,146,62,169,237,106,244,165,218,76,91,81,47,116,10,197,117,131,134,42,217,139,246,15,15,195,179,41,234,150,206,212,181,27,86,105,39,230,44,165,110,104,71,29,216,235,132,140,199,82,5,92,48,154,115,201,66,229,115,38,57,87,44,135,44,19,65,156,160,159,71,212,83,186,79,58,213,179,186,53,233,102,122,237,112,145,252,210,21,241,15,134,254,103,206,243,131,179,114,76,247,95,203,249,247,103,143,182,87,218,189,217,247,231,208,111,107,228,95,95,209,181,183,254,2,88,20,179,49,229,9,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,219,48,16,252,21,131,205,209,52,248,126,248,214,38,151,0,73,97,212,109,46,113,14,75,114,217,24,149,45,195,146,3,164,134,255,189,180,34,55,118,159,1,138,30,10,148,7,73,164,118,102,151,59,59,91,114,214,62,174,144,140,201,155,201,245,180,206,237,232,188,94,227,104,178,174,35,54,205,232,170,142,80,205,63,67,168,112,2,107,88,96,139,235,27,168,54,216,92,205,155,118,56,56,6,145,33,57,123,232,254,145,241,237,150,92,182,184,248,112,153,10,51,68,157,65,102,164,33,235,64,21,218,76,131,101,146,10,27,180,151,201,139,16,100,1,199,186,218,44,150,215,216,194,4,218,123,50,222,146,142,173,16,68,151,156,202,62,210,160,92,33,176,62,80,15,209,80,165,184,200,82,73,19,65,144,221,144,52,241,30,23,208,37,61,2,43,229,147,147,130,130,138,145,170,192,56,13,62,105,234,128,139,168,4,248,236,252,30,220,199,63,3,111,95,93,213,245,167,205,106,228,152,6,136,168,168,51,76,81,197,208,82,240,24,40,203,90,113,171,202,29,34,27,9,198,99,14,224,168,118,104,104,202,156,83,111,121,9,98,60,25,134,94,186,104,94,221,237,19,165,121,179,170,224,241,230,167,249,94,199,118,254,48,111,31,7,77,11,237,166,25,157,195,50,98,133,233,9,190,58,209,225,152,96,59,123,18,115,70,198,179,31,203,217,191,167,93,159,78,5,61,213,114,70,134,51,50,173,55,235,184,103,147,101,115,113,84,117,151,160,11,249,102,123,16,175,156,44,55,85,213,159,92,64,11,135,192,195,113,157,230,121,142,233,114,57,61,104,214,177,176,126,149,182,125,247,56,172,167,218,254,4,118,13,75,248,136,235,183,229,250,207,181,127,173,242,125,105,225,129,56,8,175,153,229,153,90,4,95,70,215,8,234,18,7,234,185,15,89,90,41,114,22,29,250,29,102,92,99,209,233,180,176,151,140,78,143,111,186,110,239,93,211,215,181,111,213,142,236,118,195,99,47,89,97,128,57,231,169,5,201,11,161,118,197,85,130,209,104,12,115,1,52,87,204,253,210,75,128,210,138,152,129,130,40,215,82,54,179,226,4,163,40,183,137,75,139,1,189,49,127,209,75,82,248,144,152,65,154,189,46,233,157,80,20,88,14,212,105,76,165,151,89,120,229,70,41,132,204,144,51,154,149,9,148,171,242,101,180,119,123,47,105,157,152,146,130,169,23,122,169,244,117,83,181,131,58,15,160,119,213,127,59,177,127,214,78,47,153,158,223,217,233,110,247,5,227,194,240,149,244,6,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.CanceledChangeDataUserTask.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: PendingCatchSignalFlowElement

		/// <exclude/>
		public class PendingCatchSignalFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public PendingCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "PendingCatchSignal";
				IsLogging = true;
				SchemaElementUId = new Guid("d7674af7-e199-4c72-821d-36401cba0d75");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""a71adaea-3464-4dee-bb4f-c7a535450ad7""]}";
				EntityFilters = @"{""className"":""BPMSoft.FilterGroup"",""serializedFilterEditData"":""{\""className\"":\""BPMSoft.FilterGroup\"",\""items\"":{\""2018e7a5-23fd-4373-a3ad-61c145d13fde\"":{\""className\"":\""BPMSoft.InFilter\"",\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Status\""},\""isAggregative\"":false,\""key\"":\""2018e7a5-23fd-4373-a3ad-61c145d13fde\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Status\"",\""referenceSchemaName\"":\""CaseStatus\"",\""rightExpressions\"":[{\""className\"":\""BPMSoft.ParameterExpression\"",\""expressionType\"":2,\""parameter\"":{\""className\"":\""BPMSoft.Parameter\"",\""dataValueType\"":10,\""value\"":{\""Id\"":\""3859c6e7-cbcb-486b-ba53-77808fe6e593\"",\""Name\"":\""Pending\"",\""value\"":\""3859c6e7-cbcb-486b-ba53-77808fe6e593\"",\""displayValue\"":\""Pending\""}}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\"",\""key\"":\""2348f93f-39d3-43a1-b8ec-124dffb0e7f2\""}"",""dataSourceFilters"":""{\""items\"":{\""2018e7a5-23fd-4373-a3ad-61c145d13fde\"":{\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Status\""},\""rightExpressions\"":[{\""expressionType\"":2,\""parameter\"":{\""dataValueType\"":10,\""value\"":\""3859c6e7-cbcb-486b-ba53-77808fe6e593\""}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\""}""}";
				_recordId = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: PendingChangeDataUserTaskFlowElement

		/// <exclude/>
		public class PendingChangeDataUserTaskFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public PendingChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "PendingChangeDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("41a9e18e-ba68-4a3e-9b87-c9033b84382e");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("4bdbb88f-58e6-df11-971b-001d60e938c6"));
				_recordColumnValues_Result = () => (Guid)(new Guid("e33e3598-1033-4d18-8212-534a95c78e71"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Result", () => _recordColumnValues_Result.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;
			internal Func<Guid> _recordColumnValues_Result;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,111,218,64,16,254,43,200,231,108,228,197,111,110,41,161,21,135,54,72,68,185,132,28,198,246,44,172,226,151,118,215,105,105,196,127,239,216,6,74,90,43,117,171,62,144,202,1,236,143,111,103,190,121,238,179,149,100,160,245,7,200,209,154,88,111,22,239,151,165,48,151,111,101,102,80,189,83,101,93,89,23,150,70,37,33,147,159,49,237,240,89,42,205,53,24,160,3,207,171,175,231,87,214,100,213,103,97,101,93,172,44,105,48,215,196,160,3,28,33,112,226,64,176,48,138,99,230,2,247,89,236,10,135,113,91,56,126,192,133,199,197,184,99,246,155,158,150,121,5,10,59,15,173,113,209,62,222,110,171,134,200,9,72,90,138,212,101,177,7,157,70,130,158,21,16,103,152,210,187,81,53,18,100,148,204,41,18,188,149,57,46,64,145,167,198,78,217,64,68,18,144,233,134,149,161,48,179,79,149,66,173,101,89,188,46,45,171,243,226,148,75,199,241,248,186,23,99,183,10,27,230,2,204,166,53,48,39,81,187,86,227,213,122,173,112,13,70,62,157,74,120,196,109,203,27,150,59,58,144,82,125,238,32,171,241,196,231,203,56,166,80,153,46,156,206,61,17,148,92,111,6,70,122,204,214,143,130,29,19,88,29,200,131,44,246,234,31,251,4,62,53,64,103,227,240,184,178,238,231,250,230,99,129,106,153,108,48,135,46,99,15,151,132,126,3,28,237,79,158,1,3,7,198,17,103,158,67,95,174,19,133,12,210,128,179,196,231,118,196,227,52,8,5,238,30,58,29,82,87,25,108,239,142,238,166,181,82,88,152,145,1,253,56,154,95,183,164,38,125,244,23,6,190,143,152,122,204,179,93,42,78,232,186,44,116,99,242,226,138,136,123,232,133,0,9,149,153,62,141,225,72,8,63,20,41,67,114,199,220,148,71,44,78,29,206,2,199,230,78,232,251,192,67,247,127,155,130,165,1,83,107,218,29,133,212,155,97,3,49,44,141,61,13,197,199,175,78,196,94,74,247,51,146,122,36,100,1,217,185,79,73,27,212,97,52,218,84,237,187,45,43,215,50,129,236,166,66,69,153,108,69,219,253,205,240,162,139,154,161,83,101,105,186,81,58,138,185,74,168,26,210,80,5,78,42,97,67,4,126,18,10,102,115,31,152,107,59,200,98,20,49,11,16,60,207,7,129,97,216,44,57,186,79,26,213,203,178,86,201,190,123,117,119,145,252,210,21,241,15,154,254,103,246,121,111,175,12,169,254,185,236,191,63,187,218,206,180,122,203,239,247,208,111,43,228,95,31,209,157,181,251,2,12,50,252,177,229,9,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,219,48,16,252,21,131,201,209,107,136,15,137,164,111,105,115,9,144,20,70,221,230,18,231,176,36,151,141,80,217,114,245,8,144,6,254,247,210,138,221,216,125,6,40,122,40,80,29,36,144,218,153,93,206,112,30,217,105,247,176,38,54,101,175,102,87,243,58,118,147,215,117,67,147,89,83,123,106,219,201,101,237,177,42,63,163,171,104,134,13,46,169,163,230,26,171,158,218,203,178,237,198,163,67,16,27,179,211,251,225,31,155,222,60,178,139,142,150,239,47,66,98,38,110,8,141,231,80,16,106,80,220,231,96,140,35,144,185,15,94,90,65,92,137,4,246,117,213,47,87,87,212,225,12,187,59,54,125,100,3,91,34,240,38,24,21,173,7,167,140,3,165,173,3,139,190,0,165,184,136,82,201,194,163,96,155,49,107,253,29,45,113,104,122,0,86,202,6,35,5,160,242,30,148,203,56,56,27,210,8,200,133,87,2,109,52,118,11,222,213,63,3,111,78,46,235,250,99,191,158,152,44,71,244,164,192,20,153,2,149,145,6,180,228,32,139,185,226,90,229,86,250,108,162,92,112,206,152,8,185,161,2,66,228,28,172,230,169,40,227,161,200,200,74,227,139,147,219,109,163,80,182,235,10,31,174,127,218,239,204,119,229,125,217,61,140,218,14,187,190,77,226,46,215,85,82,62,60,225,215,71,70,28,50,60,46,158,220,92,176,233,226,199,126,238,190,243,65,168,99,71,143,205,92,176,241,130,205,235,190,241,91,54,153,22,231,7,99,15,13,134,146,111,150,123,247,210,206,170,175,170,221,206,57,118,184,47,220,111,215,161,140,37,133,139,213,124,111,218,192,146,237,158,164,219,119,175,253,243,52,219,159,192,174,112,133,31,168,121,147,142,255,60,251,215,41,223,37,9,247,196,78,216,60,211,60,130,38,180,160,168,16,96,2,71,176,220,186,40,181,20,49,138,1,253,150,34,53,180,242,116,60,216,75,238,206,14,223,14,106,111,99,179,155,107,43,213,134,109,54,227,195,48,169,160,157,166,88,128,136,137,75,97,186,98,206,36,106,174,136,50,18,156,139,220,253,50,76,72,82,11,31,17,80,164,99,41,29,179,20,133,34,17,232,192,165,38,71,182,40,254,98,152,164,176,46,100,5,65,180,121,106,111,132,2,204,162,3,147,83,72,90,70,97,149,153,144,148,36,115,107,128,103,82,130,10,220,128,17,92,64,46,21,218,220,107,67,154,191,48,76,73,215,190,234,70,117,28,225,46,86,147,179,16,202,174,172,87,88,141,202,85,172,155,37,110,87,163,134,62,245,101,243,63,101,255,96,202,94,114,169,126,151,178,219,205,23,152,140,224,97,12,7,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.PendingChangeDataUserTask.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: EscalationCatchSignalFlowElement

		/// <exclude/>
		public class EscalationCatchSignalFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public EscalationCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "EscalationCatchSignal";
				IsLogging = true;
				SchemaElementUId = new Guid("9465eae5-e8e5-47ca-be99-632bc3fcb44c");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""70620d00-e4ea-48d1-9fdc-4572fcd8d41b"",""9147230c-ab53-4eb4-b0b4-ac78be6f8326""]}";
				EntityFilters = @"{""className"":""BPMSoft.FilterGroup"",""serializedFilterEditData"":""{\""className\"":\""BPMSoft.FilterGroup\"",\""items\"":{\""00341d8c-8bdd-4cd2-834e-302e3c28735b\"":{\""className\"":\""BPMSoft.IsNullFilter\"",\""filterType\"":2,\""comparisonType\"":2,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Owner\""},\""isAggregative\"":false,\""key\"":\""00341d8c-8bdd-4cd2-834e-302e3c28735b\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Assignee\"",\""referenceSchemaName\"":\""Contact\"",\""isNull\"":false},\""bf5aa442-2113-479a-afd5-bf5d470a810d\"":{\""className\"":\""BPMSoft.IsNullFilter\"",\""filterType\"":2,\""comparisonType\"":2,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Group\""},\""isAggregative\"":false,\""key\"":\""bf5aa442-2113-479a-afd5-bf5d470a810d\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Assignees group\"",\""referenceSchemaName\"":\""SysAdminUnit\"",\""isNull\"":false}},\""logicalOperation\"":1,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\"",\""key\"":\""dbb99e94-3913-4a55-a508-54e46e4e5b39\""}"",""dataSourceFilters"":""{\""items\"":{\""00341d8c-8bdd-4cd2-834e-302e3c28735b\"":{\""filterType\"":2,\""comparisonType\"":2,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Owner\""},\""isNull\"":false},\""bf5aa442-2113-479a-afd5-bf5d470a810d\"":{\""filterType\"":2,\""comparisonType\"":2,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Group\""},\""isNull\"":false}},\""logicalOperation\"":1,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Case\""}""}";
				_recordId = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: EscalationChangeDataUserTaskFlowElement

		/// <exclude/>
		public class EscalationChangeDataUserTaskFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public EscalationChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "EscalationChangeDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("ad170079-791f-4bd7-98e0-472fdd5812f3");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("4bdbb88f-58e6-df11-971b-001d60e938c6"));
				_recordColumnValues_Result = () => (Guid)(new Guid("ca253900-6739-4afb-9626-0ea1a57d8394"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Result", () => _recordColumnValues_Result.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;
			internal Func<Guid> _recordColumnValues_Result;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,85,75,111,218,64,16,254,43,200,231,108,228,247,218,220,82,66,43,14,109,144,136,114,9,57,140,237,89,88,197,47,237,174,211,210,136,255,222,177,13,148,180,86,74,171,62,144,202,1,236,225,219,153,111,230,155,153,125,182,210,28,180,254,0,5,90,99,235,205,252,253,162,18,230,242,173,204,13,170,119,170,106,106,235,194,210,168,36,228,242,51,102,189,125,154,73,115,13,6,232,192,243,242,235,249,165,53,94,14,121,88,90,23,75,75,26,44,52,33,232,0,231,192,61,17,133,44,138,147,152,249,118,16,48,200,68,194,210,36,139,185,155,216,161,195,121,143,28,118,61,169,138,26,20,246,17,58,231,162,123,188,221,212,45,208,33,67,218,65,164,174,202,157,209,107,41,232,105,9,73,142,25,189,27,213,32,153,140,146,5,101,130,183,178,192,57,40,138,212,250,169,90,19,129,4,228,186,69,229,40,204,244,83,173,80,107,89,149,175,83,203,155,162,60,198,210,113,60,188,238,200,216,29,195,22,57,7,179,238,28,204,136,212,182,227,120,181,90,41,92,129,145,79,199,20,30,113,211,225,78,171,29,29,200,72,159,59,200,27,60,138,249,50,143,9,212,166,79,167,15,79,0,37,87,235,19,51,61,84,235,71,201,186,100,172,247,224,147,60,14,242,119,67,50,62,181,134,222,199,254,113,105,221,207,244,205,199,18,213,34,93,99,1,125,197,30,46,201,250,141,225,224,127,252,12,200,61,112,99,135,5,30,125,249,94,28,81,21,185,195,210,208,177,99,39,201,120,36,112,251,208,243,144,186,206,97,115,119,8,55,105,148,194,210,140,12,232,199,209,236,186,3,181,229,163,191,18,20,145,147,241,132,9,17,114,230,131,231,50,240,99,151,185,33,186,110,16,197,153,39,98,146,153,62,109,3,132,220,135,216,79,89,24,115,159,192,137,199,18,225,38,44,12,124,112,68,224,249,78,132,255,219,20,44,12,152,70,211,238,40,165,94,159,54,16,167,149,113,160,161,28,247,213,137,216,81,233,127,70,82,143,132,44,33,63,247,41,233,146,218,143,70,87,170,93,183,229,213,74,166,144,223,212,168,168,146,29,105,123,184,25,94,116,81,59,116,170,170,76,63,74,7,50,87,41,169,33,13,41,112,164,68,20,114,210,1,61,6,156,22,146,239,219,54,131,52,202,152,147,102,46,247,184,239,217,24,144,166,116,159,180,172,23,85,163,210,93,247,234,254,34,249,165,43,226,31,52,253,207,236,243,193,94,57,69,253,115,217,127,127,118,181,157,169,122,139,239,247,208,111,19,242,175,143,232,214,218,126,1,114,206,120,40,229,9,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,219,48,16,252,21,131,201,209,52,248,18,69,250,214,54,61,4,72,10,163,110,115,137,115,88,146,203,70,168,108,185,122,4,72,13,255,123,105,89,110,236,62,3,20,61,20,40,15,18,72,238,236,14,103,57,220,144,243,246,113,141,100,74,94,206,174,231,85,108,39,175,170,26,39,179,186,242,216,52,147,171,202,67,89,124,6,87,226,12,106,88,98,139,245,13,148,29,54,87,69,211,142,71,199,32,50,38,231,15,253,30,153,222,110,200,101,139,203,247,151,33,101,246,70,10,15,204,211,220,233,72,149,180,158,26,174,179,52,149,220,56,229,131,212,54,129,125,85,118,203,213,53,182,48,131,246,158,76,55,164,207,214,39,8,70,197,4,115,202,56,170,114,235,168,5,175,169,82,92,68,169,164,246,32,200,118,76,26,127,143,75,232,139,30,129,149,178,33,49,160,160,188,167,202,49,78,157,13,25,53,192,133,87,2,108,52,118,7,30,226,159,128,183,103,87,85,245,177,91,79,12,203,0,60,42,106,52,83,84,49,204,41,88,116,148,197,76,241,92,101,86,122,54,81,46,56,103,76,164,153,65,77,67,228,156,218,156,167,32,198,131,102,104,165,241,250,236,110,87,40,20,205,186,132,199,155,159,214,123,225,219,226,161,104,31,71,77,11,109,215,36,113,151,235,50,41,31,246,248,245,73,35,142,51,108,22,251,110,46,200,116,241,227,126,14,255,121,47,212,105,71,79,155,185,32,227,5,153,87,93,237,119,217,100,154,92,28,209,238,11,244,33,223,76,15,221,75,43,171,174,44,135,149,11,104,225,16,120,88,174,66,17,11,12,151,171,249,161,105,125,22,54,140,164,219,119,159,195,216,115,251,19,216,53,172,224,3,214,111,210,241,159,184,127,101,249,46,73,120,72,236,132,205,88,206,35,205,17,44,85,168,5,53,129,3,181,220,186,40,115,41,98,20,61,250,45,70,172,113,229,241,148,216,115,238,206,128,111,122,181,119,182,25,120,237,164,218,146,237,118,124,108,38,165,88,102,163,19,251,75,172,180,77,92,132,240,148,101,153,9,24,163,180,44,252,210,76,128,50,23,62,2,5,145,142,165,242,200,146,21,180,162,60,15,92,230,232,208,106,253,23,205,36,133,117,129,105,164,209,102,169,188,17,138,2,139,142,154,12,67,210,50,10,171,204,36,249,57,75,7,97,84,231,50,169,14,105,223,106,161,41,67,224,144,229,137,129,85,207,52,83,210,181,43,219,81,21,71,48,216,106,242,186,73,143,26,180,69,181,26,213,248,169,43,234,255,206,250,7,157,245,156,139,244,59,103,221,109,191,0,18,32,76,2,0,7,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.EscalationChangeDataUserTask.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: ReadCaseCountDataUserTaskFlowElement

		/// <exclude/>
		public class ReadCaseCountDataUserTaskFlowElement : ReadDataUserTask
		{

			#region Constructors: Public

			public ReadCaseCountDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "ReadCaseCountDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("e056d00a-f1bb-41c3-b364-ba74262573fd");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
			}

			#endregion

			#region Properties: Public

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,193,110,227,54,16,253,21,67,231,101,64,73,164,68,249,182,77,221,34,135,238,6,205,98,47,235,28,70,228,208,17,42,75,130,68,167,77,13,255,123,135,146,237,216,93,199,85,130,13,186,64,246,100,105,60,243,52,51,124,243,56,235,64,151,208,117,31,96,137,193,52,248,233,250,183,155,218,186,139,95,138,210,97,251,107,91,175,154,224,93,208,97,91,64,89,252,141,102,176,207,76,225,126,6,7,20,176,158,63,198,207,131,233,252,20,194,60,120,55,15,10,135,203,142,60,40,64,40,107,19,140,4,75,69,28,49,33,185,102,96,64,179,20,173,140,184,141,64,129,29,60,79,67,95,85,3,120,143,107,251,199,79,15,141,247,17,100,208,245,178,129,182,232,234,106,107,140,253,215,187,89,5,121,137,134,222,93,187,66,50,185,182,88,82,17,248,169,88,226,53,180,244,17,143,83,123,19,57,89,40,59,239,85,162,117,179,191,154,22,187,174,168,171,115,89,93,214,229,106,89,29,250,82,56,238,95,183,201,240,62,67,239,121,13,238,174,7,184,132,142,254,217,244,89,190,95,44,90,92,128,43,238,15,147,248,3,31,122,207,113,141,163,0,67,135,243,25,202,21,110,191,26,242,175,74,185,132,198,13,21,237,50,32,151,22,45,182,88,105,188,209,119,184,132,125,141,143,14,197,226,238,0,196,31,232,151,39,59,178,239,234,127,53,37,34,99,179,115,62,215,227,61,226,201,42,163,132,140,247,222,48,96,236,30,231,193,151,171,238,227,159,21,182,67,89,67,95,111,47,200,250,47,195,172,196,37,86,110,186,86,86,166,2,101,206,210,132,218,45,210,40,98,25,135,140,197,218,38,210,196,60,7,80,27,10,216,39,52,93,167,32,67,16,42,98,90,39,9,19,161,76,25,164,137,100,60,53,22,48,67,110,147,220,135,204,42,87,184,135,129,45,211,53,32,71,33,53,48,45,50,201,132,69,138,138,51,195,98,200,211,40,85,24,38,97,186,185,29,202,45,186,166,132,135,207,251,170,126,71,48,19,77,71,51,241,157,160,137,107,59,55,241,115,54,169,237,132,58,188,42,93,81,45,38,68,183,18,181,63,236,139,43,211,35,249,31,138,183,81,36,83,21,231,12,184,36,58,197,73,204,242,16,19,150,65,142,33,202,212,64,70,116,218,108,54,183,158,156,105,158,168,92,24,205,18,142,33,235,155,163,48,11,25,96,164,56,181,3,52,196,231,206,238,140,32,96,194,99,205,61,180,66,203,4,247,188,150,82,51,19,83,6,105,38,98,25,234,55,36,8,55,14,220,170,27,39,9,227,90,247,124,73,216,229,112,70,20,222,19,167,238,137,202,135,174,223,179,60,244,21,31,200,195,118,10,226,76,24,145,43,193,164,34,238,27,27,134,44,75,195,156,113,30,26,162,122,22,43,157,244,120,251,207,93,85,147,166,173,233,84,186,161,234,71,157,25,141,245,213,44,31,97,238,70,46,201,77,148,101,38,103,210,112,100,194,164,154,169,140,20,34,66,41,81,115,109,81,18,220,143,185,56,49,23,227,90,247,99,46,206,204,133,122,238,92,124,168,221,164,115,208,58,175,170,199,115,161,94,58,23,71,152,253,92,248,193,40,235,69,161,161,252,216,96,11,91,201,10,79,139,250,209,109,224,247,131,182,174,221,19,66,214,103,176,35,208,184,235,238,169,108,248,55,206,134,211,62,160,98,17,50,29,41,195,132,136,53,203,136,223,204,8,107,137,210,145,160,157,131,178,161,93,221,171,222,77,189,106,53,14,119,98,55,44,233,47,90,191,255,135,171,244,121,11,243,19,247,205,152,27,228,141,45,143,175,188,242,189,104,153,251,78,233,117,184,126,125,67,130,29,201,236,216,85,225,217,139,192,219,238,169,26,219,211,215,188,68,94,245,78,216,4,155,127,0,161,60,221,245,178,17,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private int _resultType = 1;
			public override int ResultType {
				get {
					return _resultType;
				}
				set {
					_resultType = value;
				}
			}

			private bool _readSomeTopRecords = true;
			public override bool ReadSomeTopRecords {
				get {
					return _readSomeTopRecords;
				}
				set {
					_readSomeTopRecords = value;
				}
			}

			private int _numberOfRecords = 1;
			public override int NumberOfRecords {
				get {
					return _numberOfRecords;
				}
				set {
					_numberOfRecords = value;
				}
			}

			private int _functionType = 0;
			public override int FunctionType {
				get {
					return _functionType;
				}
				set {
					_functionType = value;
				}
			}

			private string _aggregationColumnName;
			public override string AggregationColumnName {
				get {
					return _aggregationColumnName ?? (_aggregationColumnName = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,1,0,242,67,189,42,2,0,0,0 })));
				}
				set {
					_aggregationColumnName = value;
				}
			}

			private string _orderInfo;
			public override string OrderInfo {
				get {
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,11,201,44,201,73,181,50,180,50,212,241,76,177,50,176,50,0,0,169,240,29,88,16,0,0,0 })));
				}
				set {
					_orderInfo = value;
				}
			}

			private Entity _resultEntity;
			public override Entity ResultEntity {
				get {
					return _resultEntity ?? (_resultEntity =
						new Entity(UserConnection) {
							Schema = UserConnection.EntitySchemaManager.GetInstanceByUId(
								new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89")),
							UseAdminRights = false
						});
				}
				set {
					_resultEntity = value;
				}
			}

			private bool _canReadUncommitedData = false;
			public override bool CanReadUncommitedData {
				get {
					return _canReadUncommitedData;
				}
				set {
					_canReadUncommitedData = value;
				}
			}

			private EntityCollection _resultEntityCollection;
			public override EntityCollection ResultEntityCollection {
				get {
					if (_resultEntityCollection == null) {
						_resultEntityCollection = new EntityCollection(UserConnection, new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"));
					}
					return _resultEntityCollection;
				}
				set {
					_resultEntityCollection = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: CompleteTasksChangeDataUserTaskFlowElement

		/// <exclude/>
		public class CompleteTasksChangeDataUserTaskFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public CompleteTasksChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "CompleteTasksChangeDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("3fceae6f-a629-4ceb-92b4-3aed7434c92b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("4bdbb88f-58e6-df11-971b-001d60e938c6"));
				_recordColumnValues_Result = () => (Guid)(new Guid("ef46415c-8dc6-43cb-9caa-36e5a6651dcf"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
						_getColumnValueFunctions.Add("_recordColumnValues_Result", () => _recordColumnValues_Result.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;
			internal Func<Guid> _recordColumnValues_Result;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,86,223,115,219,54,12,254,87,116,122,46,115,212,47,82,244,91,155,185,187,60,108,205,45,185,190,212,121,128,72,208,209,85,150,124,18,157,205,243,249,127,31,40,217,142,219,56,174,154,219,218,238,250,98,73,48,0,2,31,62,16,216,132,186,130,174,251,29,22,24,78,194,55,215,191,221,52,214,93,188,45,43,135,237,175,109,179,90,134,175,194,14,219,18,170,242,111,52,131,124,106,74,247,11,56,32,131,205,236,209,126,22,78,102,167,60,204,194,87,179,176,116,184,232,72,131,12,132,228,60,193,60,98,66,113,100,41,79,114,166,12,104,166,101,154,103,92,64,154,105,59,104,158,118,125,85,15,206,123,191,182,127,189,93,47,189,78,74,2,221,44,150,208,150,93,83,239,132,137,63,189,155,214,80,84,104,232,219,181,43,36,145,107,203,5,37,129,183,229,2,175,161,165,67,188,159,198,139,72,201,66,213,121,173,10,173,155,254,181,108,177,235,202,166,62,23,213,101,83,173,22,245,177,46,153,227,225,115,23,12,239,35,244,154,215,224,238,123,7,151,208,209,63,219,62,202,215,243,121,139,115,112,229,195,113,16,31,113,221,107,142,3,142,12,12,21,231,61,84,43,220,157,26,241,39,169,92,194,210,13,25,237,35,32,149,22,45,182,88,107,188,209,247,184,128,67,142,143,10,229,252,254,200,137,47,232,135,103,17,57,160,250,37,80,98,18,46,247,202,231,48,62,120,60,153,101,44,72,248,224,5,131,143,253,235,44,252,112,213,189,251,179,198,118,72,107,192,245,238,130,164,159,9,166,21,46,176,118,147,77,110,51,153,98,86,48,41,226,148,165,50,142,153,226,160,88,162,173,200,76,194,11,128,124,75,6,135,128,38,27,9,89,4,105,30,51,173,133,96,105,148,73,6,82,100,140,75,99,1,21,114,43,10,111,50,173,93,233,214,3,91,38,27,64,142,84,54,96,58,85,25,75,45,146,85,162,12,75,160,144,177,204,49,18,145,220,222,13,233,150,221,178,130,245,251,67,86,127,32,152,64,83,105,2,143,4,117,92,219,185,192,247,89,208,216,128,16,94,85,174,172,231,1,209,173,66,237,139,125,113,101,122,79,254,65,246,69,106,115,174,180,96,177,85,5,75,83,25,49,165,165,101,73,140,137,209,81,4,144,104,34,230,118,123,231,201,105,56,125,91,137,44,50,94,219,191,41,99,37,67,145,27,195,173,50,185,18,63,81,215,190,38,68,31,124,33,233,228,121,211,174,199,117,240,56,16,95,210,193,251,40,206,116,241,211,144,127,244,142,238,179,62,234,232,29,113,109,22,233,84,164,9,203,114,20,204,216,136,136,43,163,130,113,30,25,193,81,37,185,30,80,60,28,119,219,4,166,233,69,143,151,194,104,47,79,26,111,231,109,223,25,150,139,60,46,176,96,150,43,234,124,21,27,6,42,163,159,88,196,66,37,154,67,156,157,231,160,231,62,62,215,30,209,255,177,61,110,28,184,85,71,119,82,93,118,247,227,122,99,28,140,167,88,18,159,237,141,93,40,195,35,40,187,192,150,53,84,167,200,63,138,168,223,138,250,241,17,89,123,168,136,110,30,198,170,153,151,26,170,119,75,108,9,201,62,104,126,154,12,159,176,200,207,198,182,105,220,51,119,66,31,195,190,18,156,231,152,200,36,99,52,178,12,75,19,160,61,3,243,140,201,40,79,162,194,198,74,2,80,77,105,51,244,81,223,52,171,86,239,216,219,13,43,225,139,150,189,239,48,19,190,110,61,123,230,170,28,195,128,159,108,85,249,143,23,140,31,148,41,167,87,130,127,145,53,159,140,195,177,3,236,171,135,212,119,24,62,248,178,137,114,242,250,126,226,107,12,176,223,250,178,221,134,219,127,0,144,180,102,160,121,15,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,83,203,110,219,48,16,252,21,131,201,209,20,248,18,69,250,214,54,151,0,73,97,212,109,46,113,14,75,114,217,8,149,37,195,146,2,164,134,255,189,148,98,55,118,159,1,138,30,10,148,7,9,164,118,102,135,179,154,45,57,239,30,215,72,102,228,245,252,122,209,196,46,123,211,108,48,155,111,26,143,109,155,93,53,30,170,242,51,184,10,231,176,129,21,118,184,185,129,170,199,246,170,108,187,233,228,24,68,166,228,252,97,252,70,102,183,91,114,217,225,234,195,101,72,204,152,27,206,11,239,169,209,222,80,197,165,163,0,24,40,132,24,16,25,203,157,240,9,236,155,170,95,213,215,216,193,28,186,123,50,219,146,145,45,17,120,19,140,138,214,83,167,140,163,170,176,142,90,240,154,42,197,69,148,74,106,15,130,236,166,164,245,247,184,130,177,233,17,88,41,27,140,20,20,84,146,160,28,227,212,217,144,83,3,92,120,37,192,70,99,7,240,190,254,25,120,123,118,213,52,159,250,117,102,88,14,224,81,37,253,76,81,197,176,160,96,209,81,22,115,197,11,149,91,233,89,166,92,112,206,152,72,115,131,154,134,200,57,181,5,79,69,140,7,205,208,74,227,245,217,221,208,40,148,237,186,130,199,155,159,246,123,229,187,242,161,236,30,39,109,7,93,223,38,115,87,235,42,57,31,158,240,235,147,65,28,51,108,151,79,211,92,146,217,242,199,243,220,191,23,163,81,167,19,61,29,230,146,76,151,100,209,244,27,63,176,201,180,185,56,146,61,54,24,75,190,217,30,166,151,78,234,190,170,246,39,23,208,193,161,240,112,220,132,50,150,24,46,235,197,97,104,35,11,219,175,228,219,119,143,195,122,210,246,39,176,107,168,225,35,110,222,166,235,63,107,255,170,242,125,178,240,64,236,132,205,89,193,35,45,16,44,85,168,5,53,129,3,181,220,186,40,11,41,98,20,35,250,29,70,220,96,237,241,84,216,75,254,157,61,190,29,221,30,98,179,215,53,88,181,35,187,221,244,36,76,86,20,133,52,64,243,232,146,32,163,134,88,21,129,242,96,163,68,169,48,137,250,101,152,32,85,8,31,129,130,72,215,82,69,100,41,10,90,81,94,4,46,11,116,104,181,254,139,97,146,194,186,192,52,210,104,243,212,222,8,69,129,69,71,77,142,33,121,25,133,85,38,195,168,180,226,121,186,90,24,98,46,125,10,188,7,160,82,99,14,90,231,60,248,248,194,48,37,95,251,170,155,52,113,2,251,88,101,139,228,77,87,54,245,36,54,125,253,63,84,255,94,168,94,242,15,253,46,84,119,187,47,90,228,94,145,251,6,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.CompleteTasksChangeDataUserTask.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: CancelTasksChangeDataUserTaskFlowElement

		/// <exclude/>
		public class CancelTasksChangeDataUserTaskFlowElement : ChangeDataUserTask
		{

			#region Constructors: Public

			public CancelTasksChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "CancelTasksChangeDataUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("484f3905-6b35-4c22-a574-50b567b9a99b");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_recordColumnValues_Status = () => (Guid)(new Guid("201cfba8-58e6-df11-971b-001d60e938c6"));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordColumnValues_Status", () => _recordColumnValues_Status.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordColumnValues_Status;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaUId {
				get {
					return _entitySchemaUId;
				}
				set {
					_entitySchemaUId = value;
				}
			}

			private bool _isMatchConditions = true;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private string _dataSourceFilters;
			public override string DataSourceFilters {
				get {
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,229,86,223,115,219,54,12,254,87,124,122,46,115,164,68,234,135,223,186,204,219,229,97,107,110,201,245,165,206,3,72,130,142,110,178,228,147,232,108,94,206,255,251,64,201,118,220,198,241,212,220,214,118,215,39,73,16,0,2,31,62,0,124,140,76,5,93,247,43,44,49,154,70,63,92,255,114,211,56,127,241,83,89,121,108,127,110,155,245,42,122,19,117,216,150,80,149,127,161,29,228,51,91,250,31,193,3,25,60,206,159,236,231,209,116,126,202,195,60,122,51,143,74,143,203,142,52,200,192,9,237,172,202,99,22,107,233,152,76,138,130,105,83,36,76,199,89,110,115,99,18,167,196,160,121,218,245,85,61,56,239,253,186,254,245,118,179,10,58,146,4,166,89,174,160,45,187,166,222,9,147,112,122,55,171,65,87,104,233,219,183,107,36,145,111,203,37,37,129,183,229,18,175,161,165,67,130,159,38,136,72,201,65,213,5,173,10,157,159,253,185,106,177,235,202,166,62,23,213,101,83,173,151,245,177,46,153,227,225,115,23,12,239,35,12,154,215,224,239,123,7,151,208,209,159,109,31,229,219,197,162,197,5,248,242,225,56,136,223,113,211,107,142,3,142,12,44,21,231,61,84,107,220,157,42,248,179,84,46,97,229,135,140,246,17,144,74,139,14,91,172,13,222,152,123,92,194,33,199,39,133,114,113,127,228,36,20,244,195,139,136,28,80,253,39,80,98,18,174,246,202,231,48,62,120,60,153,101,156,146,240,33,8,6,31,251,215,121,244,225,170,123,247,71,141,237,144,214,128,235,221,5,73,63,17,204,42,92,98,237,167,143,185,83,153,68,165,89,150,198,146,201,44,142,89,193,161,96,137,113,169,178,9,215,0,249,150,12,14,1,77,31,51,80,2,36,21,199,152,52,101,82,168,140,65,150,42,198,51,235,0,11,228,46,213,193,100,86,251,210,111,6,182,76,31,1,57,74,101,128,25,89,40,38,29,146,85,82,88,150,128,206,168,170,40,82,145,109,239,134,116,203,110,85,193,230,253,33,171,223,16,236,196,80,105,38,1,9,234,184,182,243,147,208,103,147,198,77,8,225,117,229,203,122,49,33,186,85,104,66,177,47,174,108,239,41,60,200,30,173,210,32,84,204,92,14,49,37,73,177,67,150,40,150,196,60,167,240,243,56,46,52,17,115,187,189,11,228,148,25,7,37,141,96,133,206,2,249,92,194,64,99,206,50,237,242,28,37,23,188,239,174,239,165,107,223,18,162,15,161,144,116,242,162,105,55,227,58,120,28,136,175,233,224,125,20,103,186,248,121,200,223,122,71,247,89,31,117,244,142,184,52,230,140,76,101,194,84,142,41,179,78,16,158,153,208,140,115,97,83,142,69,146,155,180,247,119,56,238,182,153,216,166,23,61,13,133,209,94,158,53,222,206,219,161,51,148,84,133,53,138,9,39,144,73,99,115,86,56,65,51,0,51,157,36,121,134,86,240,243,28,12,220,199,151,218,67,252,31,219,227,198,131,95,119,52,147,234,178,187,31,217,27,163,96,60,197,146,248,108,111,236,66,25,30,147,178,155,184,178,134,234,20,249,71,17,245,75,81,63,62,34,107,15,21,209,45,192,88,53,139,210,64,245,110,133,45,33,217,7,205,79,147,225,35,22,133,221,216,54,141,127,97,38,244,49,236,43,145,11,201,227,24,4,3,64,154,82,194,113,166,179,20,104,5,58,45,180,181,74,240,156,106,74,55,195,16,245,77,179,110,205,142,189,221,112,37,124,213,101,239,43,236,132,207,187,158,189,48,42,199,48,224,59,187,170,252,199,23,140,111,148,41,167,175,4,255,34,107,62,90,135,99,23,216,103,47,169,175,176,124,240,117,27,229,228,248,126,230,107,12,176,95,122,216,110,163,237,223,6,141,234,226,121,15,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,203,110,219,48,16,252,149,128,201,209,20,72,138,146,72,223,218,228,98,192,46,140,186,205,37,206,97,73,46,27,161,178,101,72,84,0,215,240,191,151,150,165,196,238,3,40,80,30,36,112,185,51,59,156,145,14,228,46,236,119,72,166,228,227,114,177,170,125,72,238,235,6,147,101,83,91,108,219,100,94,91,168,202,31,96,42,92,66,3,27,12,216,60,66,213,97,59,47,219,48,185,185,4,145,9,185,123,237,207,200,244,233,64,102,1,55,95,103,46,50,27,204,83,101,184,160,60,119,64,37,83,138,154,44,45,104,154,91,6,10,120,97,153,143,96,91,87,221,102,187,192,0,75,8,47,100,122,32,61,91,36,176,202,41,233,181,165,70,42,67,101,161,13,213,96,115,42,37,23,62,149,145,7,4,57,78,72,107,95,112,3,253,208,11,176,148,218,169,84,80,144,214,82,105,24,167,70,187,140,198,193,194,74,1,218,43,125,2,15,253,239,192,167,219,121,93,127,239,118,137,98,25,128,69,73,85,206,100,212,143,5,5,141,134,50,159,73,94,200,76,167,150,37,130,113,235,13,40,154,41,204,169,243,156,83,93,240,216,196,184,203,25,234,84,217,252,246,249,52,200,149,237,174,130,253,227,95,231,125,176,161,124,45,195,254,166,13,16,186,54,185,135,173,197,10,221,25,190,187,202,225,146,224,176,62,135,185,38,211,245,159,227,28,222,171,222,167,235,64,175,179,92,147,201,154,172,234,174,177,39,182,52,110,30,46,84,247,3,250,150,95,182,99,120,177,178,237,170,106,168,60,64,128,177,113,44,215,174,244,37,186,217,118,53,102,214,179,176,97,69,219,126,123,140,235,172,237,127,96,11,216,194,55,108,62,197,235,191,107,127,83,249,37,90,56,18,27,161,51,86,112,79,11,4,77,37,230,130,42,199,129,106,174,141,79,139,84,120,47,122,244,103,244,216,96,204,233,90,216,191,124,58,3,190,237,221,62,253,53,131,174,147,85,71,114,60,62,31,127,2,129,97,90,91,165,3,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.CancelTasksChangeDataUserTask.Parameters.RecordColumnValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordColumnValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordColumnValues", getColumnValue);
					}
					return _recordColumnValues;
				}
				set {
					_recordColumnValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: RescheduledCatchSignalFlowElement

		/// <exclude/>
		public class RescheduledCatchSignalFlowElement : ProcessIntermediateCatchSignalEvent
		{

			#region Constructors: Public

			public RescheduledCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaIntermediateCatchSignalEvent";
				Name = "RescheduledCatchSignal";
				IsLogging = true;
				SchemaElementUId = new Guid("e615c390-d90a-4a82-a7af-2fd1be051086");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				Message = "";
				WaitingRandomSignal = false;
				WaitingEntitySignal = true;
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
				EntitySignal = EntityChangeType.Updated;
				HasEntityColumnChange = true;
				HasEntityFilters = true;
				EntityChangedColumns = @"{""$type"":""System.Collections.ObjectModel.Collection`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib"",""$values"":[""ae372cfa-a21f-47f0-8a64-17d137ebe966"",""c8d84f9c-b48b-479b-9ac6-4412f3436ca2""]}";
				EntityFilters = @"{""className"":""BPMSoft.FilterGroup"",""serializedFilterEditData"":""{\""className\"":\""BPMSoft.FilterGroup\"",\""items\"":{\""4ec38736-8c00-4dcc-8c9f-c250f63b860a\"":{\""className\"":\""BPMSoft.InFilter\"",\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Status\""},\""isAggregative\"":false,\""key\"":\""4ec38736-8c00-4dcc-8c9f-c250f63b860a\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Status\"",\""referenceSchemaName\"":\""ActivityStatus\"",\""rightExpressions\"":[{\""className\"":\""BPMSoft.ParameterExpression\"",\""expressionType\"":2,\""parameter\"":{\""className\"":\""BPMSoft.Parameter\"",\""dataValueType\"":10,\""value\"":{\""Id\"":\""4bdbb88f-58e6-df11-971b-001d60e938c6\"",\""Name\"":\""Completed\"",\""value\"":\""4bdbb88f-58e6-df11-971b-001d60e938c6\"",\""displayValue\"":\""Completed\""}}}]},\""645cd7c9-33b7-4b71-9f8b-a0fce4bac1af\"":{\""className\"":\""BPMSoft.InFilter\"",\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""className\"":\""BPMSoft.ColumnExpression\"",\""expressionType\"":0,\""columnPath\"":\""Result\""},\""isAggregative\"":false,\""key\"":\""645cd7c9-33b7-4b71-9f8b-a0fce4bac1af\"",\""dataValueType\"":10,\""leftExpressionCaption\"":\""Result\"",\""referenceSchemaName\"":\""ActivityResult\"",\""rightExpressions\"":[{\""className\"":\""BPMSoft.ParameterExpression\"",\""expressionType\"":2,\""parameter\"":{\""className\"":\""BPMSoft.Parameter\"",\""dataValueType\"":10,\""value\"":{\""Id\"":\""d87d32bc-f36b-1410-6598-00155d043204\"",\""Name\"":\""Rescheduled\"",\""value\"":\""d87d32bc-f36b-1410-6598-00155d043204\"",\""displayValue\"":\""Rescheduled\""}}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Activity\"",\""key\"":\""0a46b150-32d2-40e9-bf57-933b745bfc9a\""}"",""dataSourceFilters"":""{\""items\"":{\""4ec38736-8c00-4dcc-8c9f-c250f63b860a\"":{\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Status\""},\""rightExpressions\"":[{\""expressionType\"":2,\""parameter\"":{\""dataValueType\"":10,\""value\"":\""4bdbb88f-58e6-df11-971b-001d60e938c6\""}}]},\""645cd7c9-33b7-4b71-9f8b-a0fce4bac1af\"":{\""filterType\"":4,\""comparisonType\"":3,\""isEnabled\"":true,\""trimDateTimeParameterToDate\"":false,\""leftExpression\"":{\""expressionType\"":0,\""columnPath\"":\""Result\""},\""rightExpressions\"":[{\""expressionType\"":2,\""parameter\"":{\""dataValueType\"":10,\""value\"":\""d87d32bc-f36b-1410-6598-00155d043204\""}}]}},\""logicalOperation\"":0,\""isEnabled\"":true,\""filterType\"":6,\""rootSchemaName\"":\""Activity\""}""}";
				_recordId = () => (Guid)((process.CurrentTaskId));
			}

			#endregion

			#region Properties: Public

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		#region Class: AddRescheduledTaskUserTaskFlowElement

		/// <exclude/>
		public class AddRescheduledTaskUserTaskFlowElement : AddDataUserTask
		{

			#region Constructors: Public

			public AddRescheduledTaskUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "AddRescheduledTaskUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("68ef5315-41e9-4b68-96d5-fdca74d37520");
				CreatedInSchemaUId = process.InternalSchemaUId;
				SerializeToDB = true;
				_recordDefValues_ActivityCategory = () => (Guid)(new Guid("f51c4643-58e6-df11-971b-001d60e938c6"));
				_recordDefValues_Title = () => new LocalizableString("Diagnose and resolve incident #"+((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Number").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<string>("Number") : null)));
				_recordDefValues_Case = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Id").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id") : Guid.Empty)));
				_recordDefValues_Owner = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Owner").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("OwnerId") : Guid.Empty)));
				_recordDefValues_Contact = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Contact").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("ContactId") : Guid.Empty)));
				_recordDefValues_Account = () => (Guid)(((process.ReadCaseData.ResultEntity.IsColumnValueLoaded(process.ReadCaseData.ResultEntity.Schema.Columns.GetByName("Account").ColumnValueName) ? process.ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("AccountId") : Guid.Empty)));
			}

			private Dictionary<string, Func<object>> _getColumnValueFunctions;
			private Dictionary<string, Func<object>> GetColumnValueFunctions {
				get {
					if (_getColumnValueFunctions == null) {
						_getColumnValueFunctions = new Dictionary<string, Func<object>>();
						_getColumnValueFunctions.Add("_recordDefValues_ActivityCategory", () => _recordDefValues_ActivityCategory.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Title", () => _recordDefValues_Title.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Case", () => _recordDefValues_Case.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Owner", () => _recordDefValues_Owner.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Contact", () => _recordDefValues_Contact.Invoke());
						_getColumnValueFunctions.Add("_recordDefValues_Account", () => _recordDefValues_Account.Invoke());
					}
					return _getColumnValueFunctions;
				}
			}

			#endregion

			#region Fields: Internal

			internal Func<Guid> _recordDefValues_ActivityCategory;
			internal Func<string> _recordDefValues_Title;
			internal Func<Guid> _recordDefValues_Case;
			internal Func<Guid> _recordDefValues_Owner;
			internal Func<Guid> _recordDefValues_Contact;
			internal Func<Guid> _recordDefValues_Account;

			#endregion

			#region Properties: Public

			private Guid _entitySchemaId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid EntitySchemaId {
				get {
					return _entitySchemaId;
				}
				set {
					_entitySchemaId = value;
				}
			}

			private string _recordAddMode;
			public override string RecordAddMode {
				get {
					return _recordAddMode ?? (_recordAddMode = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,51,0,0,33,223,219,244,1,0,0,0 })));
				}
				set {
					_recordAddMode = value;
				}
			}

			private EntityColumnMappingValues _recordDefValues;
			public override EntityColumnMappingValues RecordDefValues {
				get {
					if (_recordDefValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,152,221,111,27,55,12,192,255,21,227,210,183,69,134,190,63,252,214,181,29,16,32,237,130,166,235,75,146,7,74,164,210,195,156,187,192,62,119,200,2,255,239,227,57,73,155,116,155,151,110,203,176,34,241,131,141,147,69,138,34,249,35,165,187,108,158,13,23,231,212,204,154,239,15,94,31,246,117,152,190,232,23,52,61,88,244,133,150,203,233,126,95,96,222,254,10,121,78,7,176,128,51,26,104,241,30,230,43,90,238,183,203,97,119,114,91,168,217,109,158,125,220,252,215,204,142,46,155,189,129,206,126,218,67,214,108,35,144,202,197,139,234,8,132,117,33,138,132,104,133,12,170,38,23,75,52,202,178,112,233,231,171,179,238,53,13,112,0,195,135,102,118,217,108,180,177,130,18,149,173,16,148,32,169,178,176,70,59,1,37,162,136,104,65,39,67,168,76,108,214,187,205,178,124,160,51,216,44,122,75,216,218,132,209,104,1,182,20,97,179,84,34,39,116,34,130,210,197,106,72,53,166,81,248,122,254,103,193,163,157,253,190,255,121,117,62,77,94,145,150,209,11,150,224,229,81,7,145,101,114,194,202,172,200,91,244,165,200,105,117,170,88,111,141,112,145,188,192,170,148,72,129,173,149,82,161,151,148,76,44,126,231,100,92,8,219,229,249,28,46,222,255,233,122,207,203,208,126,108,135,139,73,129,129,78,251,197,197,244,93,63,193,254,74,250,252,78,24,110,203,95,30,95,197,242,184,153,29,255,113,52,175,127,15,55,110,186,27,207,187,161,60,110,118,143,155,195,126,181,40,163,54,195,15,47,111,25,189,89,96,51,229,139,199,155,216,241,72,183,154,207,175,71,94,194,0,55,19,111,134,123,108,107,75,184,215,29,222,132,108,163,69,94,127,216,107,191,251,186,249,92,217,246,79,196,94,67,7,167,180,120,195,219,255,108,251,39,43,223,177,11,111,20,103,157,220,152,165,34,16,36,97,201,107,206,57,5,34,169,148,171,9,70,215,170,55,210,111,169,210,130,186,66,119,13,187,79,230,92,203,47,55,222,30,161,185,182,107,116,213,186,89,175,119,111,163,84,189,118,160,139,22,10,37,178,26,231,68,142,140,67,244,154,44,58,231,10,209,86,148,44,150,42,193,40,17,42,6,182,40,131,0,41,173,32,171,76,86,193,25,107,212,191,143,210,152,63,112,218,245,75,154,64,135,147,5,239,118,254,145,38,109,87,90,164,110,152,236,28,55,223,29,237,28,237,45,127,252,165,163,197,149,15,103,21,230,75,58,153,242,232,23,3,175,230,116,198,82,179,203,88,93,176,228,178,8,94,91,97,131,214,34,73,14,148,41,213,59,52,50,3,196,53,11,124,74,245,217,101,0,167,192,70,45,74,241,94,88,229,130,128,224,29,215,34,172,64,137,100,245,121,20,121,213,13,76,224,139,141,31,89,42,199,66,62,91,161,83,225,10,38,11,199,145,128,119,239,114,13,57,20,43,45,172,79,182,227,125,63,31,188,37,64,230,158,39,33,39,228,244,135,118,177,28,38,45,199,127,210,215,81,102,53,31,218,238,116,194,1,158,19,151,137,190,155,190,89,157,101,90,60,21,135,255,188,56,184,2,198,85,37,25,110,6,193,22,207,169,148,60,8,19,13,130,135,10,165,150,109,197,225,222,134,221,183,56,164,152,131,183,30,5,186,202,213,134,42,215,157,96,165,136,1,100,160,130,138,66,220,94,28,56,147,177,216,32,162,211,92,238,80,146,0,95,65,84,205,170,179,150,172,194,60,68,159,253,255,130,15,36,201,114,160,69,177,99,217,174,196,82,38,161,48,144,131,14,145,148,87,225,175,192,255,59,80,239,225,19,208,223,92,183,87,42,32,79,74,34,234,192,201,194,189,84,68,203,231,64,197,25,167,20,183,230,84,240,171,128,166,10,24,129,147,59,80,168,204,35,88,145,129,243,80,202,146,249,236,155,28,68,181,21,232,42,131,97,128,141,8,9,185,68,5,207,197,138,124,18,201,83,113,62,37,99,147,122,92,64,7,233,181,68,206,22,178,227,93,132,227,43,82,69,222,158,11,186,22,100,175,170,252,16,64,63,95,46,219,211,142,232,9,235,111,15,107,159,201,120,167,68,172,164,199,68,99,192,17,153,164,40,13,90,207,221,30,205,87,97,13,89,114,155,213,70,232,145,109,107,248,224,16,249,174,200,77,37,230,24,93,116,33,235,173,88,231,10,144,10,151,132,98,124,20,214,74,222,145,217,28,68,130,247,178,66,85,54,62,46,172,189,73,190,90,79,99,159,230,74,89,51,71,203,241,13,41,106,27,125,170,85,218,108,30,2,235,23,125,55,64,25,158,168,126,162,218,212,202,84,251,194,253,132,143,224,86,98,21,217,198,40,148,54,142,47,251,198,43,185,157,234,154,37,250,202,13,73,5,190,90,90,224,91,57,40,190,224,131,205,252,94,169,120,148,143,141,234,172,156,145,186,36,190,103,23,94,8,19,123,164,242,166,184,236,202,84,19,96,37,245,32,205,186,148,126,213,61,81,253,237,81,173,29,134,162,32,243,251,49,146,124,168,27,49,24,219,163,212,124,145,115,16,52,250,171,151,155,91,122,245,201,250,55,187,210,213,61,21,23,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.AddRescheduledTaskUserTask.Parameters.RecordDefValues.Value");
						dataList.LoadLocalizableValues();
						var packageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
						Func<string, object> getColumnValue = delegate(string memberName) {
							Func<object> getValueFunc = GetColumnValueFunctions[memberName];
							getValueFunc.CheckArgumentNull(memberName);
							return getValueFunc.Invoke();
						};
						_recordDefValues = new EntityColumnMappingValues(UserConnection, packageUId,
							(EntityColumnMappingCollection)dataList, "RecordDefValues", getColumnValue);
					}
					return _recordDefValues;
				}
				set {
					_recordDefValues = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: OpenResheduledTaskEditPageUserTaskFlowElement

		/// <exclude/>
		public class OpenResheduledTaskEditPageUserTaskFlowElement : OpenEditPageUserTask
		{

			#region Constructors: Public

			public OpenResheduledTaskEditPageUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenResheduledTaskEditPageUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("523cb373-bd6a-4f64-bca0-cd6a43ef1ae5");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_recordId = () => (Guid)((process.AddRescheduledTaskUserTask.RecordId));
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
			}

			#endregion

			#region Properties: Public

			private Guid _objectSchemaId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			public override Guid ObjectSchemaId {
				get {
					return _objectSchemaId;
				}
				set {
					_objectSchemaId = value;
				}
			}

			private Guid _pageSchemaId = new Guid("6e5551de-a0fa-48af-8d1b-7dc896060a1e");
			public override Guid PageSchemaId {
				get {
					return _pageSchemaId;
				}
				set {
					_pageSchemaId = value;
				}
			}

			private int _editMode = 1;
			public override int EditMode {
				get {
					return _editMode;
				}
				set {
					_editMode = value;
				}
			}

			internal Func<Guid> _recordId;
			public override Guid RecordId {
				get {
					return (_recordId ?? (_recordId = () => Guid.Empty)).Invoke();
				}
				set {
					_recordId = () => { return value; };
				}
			}

			private bool _isMatchConditions = false;
			public override bool IsMatchConditions {
				get {
					return _isMatchConditions;
				}
				set {
					_isMatchConditions = value;
				}
			}

			private bool _generateDecisionsFromColumn = false;
			public override bool GenerateDecisionsFromColumn {
				get {
					return _generateDecisionsFromColumn;
				}
				set {
					_generateDecisionsFromColumn = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("b98be122f42246da8bb7c0a3e83ee7cb",
						 "BaseElements.OpenResheduledTaskEditPageUserTask.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			internal Func<Guid> _ownerId;
			public override Guid OwnerId {
				get {
					return (_ownerId ?? (_ownerId = () => Guid.Empty)).Invoke();
				}
				set {
					_ownerId = () => { return value; };
				}
			}

			private int _duration = 5;
			public override int Duration {
				get {
					return _duration;
				}
				set {
					_duration = value;
				}
			}

			private int _durationPeriod = 0;
			public override int DurationPeriod {
				get {
					return _durationPeriod;
				}
				set {
					_durationPeriod = value;
				}
			}

			private int _startInPeriod = 0;
			public override int StartInPeriod {
				get {
					return _startInPeriod;
				}
				set {
					_startInPeriod = value;
				}
			}

			private int _remindBeforePeriod = 0;
			public override int RemindBeforePeriod {
				get {
					return _remindBeforePeriod;
				}
				set {
					_remindBeforePeriod = value;
				}
			}

			private bool _showInScheduler = false;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			private bool _showExecutionPage = true;
			public override bool ShowExecutionPage {
				get {
					return _showExecutionPage;
				}
				set {
					_showExecutionPage = value;
				}
			}

			private Guid _pageTypeUId = new Guid("fbe0acdc-cfc0-df11-b00f-001d60e938c6");
			public override Guid PageTypeUId {
				get {
					return _pageTypeUId;
				}
				set {
					_pageTypeUId = value;
				}
			}

			#endregion

		}

		#endregion

		#region Class: UserQuestionUserTask1FlowElement

		/// <exclude/>
		public class UserQuestionUserTask1FlowElement : UserQuestionUserTask
		{

			#region Constructors: Public

			public UserQuestionUserTask1FlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolvingV2 process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "UserQuestionUserTask1";
				IsLogging = true;
				SchemaElementUId = new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb");
				CreatedInSchemaUId = process.InternalSchemaUId;
				ProcessLane = process.Lane1;
				SerializeToDB = true;
				_ownerId = () => (Guid)(((Guid)UserConnection.SystemValueManager.GetValue(UserConnection, "CurrentUserContact")));
			}

			#endregion

			#region Properties: Public

			private LocalizableString _branchingDecisions;
			public override LocalizableString BranchingDecisions {
				get {
					if (_branchingDecisions == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,143,77,107,2,49,16,134,255,74,9,30,29,73,178,249,216,120,172,82,16,108,17,250,113,41,61,204,78,38,116,169,118,101,119,45,84,241,191,55,235,201,34,120,40,189,13,60,243,206,188,207,65,140,250,239,45,139,169,184,93,221,63,54,169,159,204,154,150,39,171,182,33,238,186,201,178,33,92,215,123,172,214,188,194,22,55,220,115,251,130,235,29,119,203,186,235,199,55,231,33,49,22,163,175,19,19,211,215,131,88,244,188,121,94,196,124,89,179,242,202,7,130,96,162,2,163,85,4,172,80,130,77,206,56,74,158,176,28,194,195,238,65,156,46,228,144,211,70,59,131,30,148,213,30,76,169,25,176,180,18,40,41,195,28,49,20,210,138,227,88,60,228,82,231,185,57,83,221,213,205,167,28,224,12,183,125,158,7,94,119,75,218,159,170,139,105,223,238,56,211,57,167,217,59,211,7,255,122,124,135,235,142,197,241,56,62,87,176,206,89,239,2,131,14,26,193,176,215,16,156,68,208,182,74,94,145,11,20,229,133,66,145,208,68,214,17,74,153,18,152,96,17,42,79,22,130,246,209,233,20,109,133,120,77,65,253,171,2,201,178,212,10,45,200,34,87,50,236,36,4,182,4,69,89,37,84,210,71,21,237,133,66,172,40,106,82,1,10,66,6,227,99,132,74,229,9,165,81,86,21,69,169,156,185,166,160,255,170,240,148,97,54,120,59,254,0,100,228,127,118,161,2,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "b98be122f42246da8bb7c0a3e83ee7cb",
							"BaseElements.UserQuestionUserTask1.Parameters.BranchingDecisions.Value");
						dataList.LoadLocalizableValues();
						_branchingDecisions = dataList.GetSerializedItems();
						};
					return _branchingDecisions;
				}
				set {
					_branchingDecisions = value;
				}
			}

			private int _decisionMode = 0;
			public override int DecisionMode {
				get {
					return _decisionMode;
				}
				set {
					_decisionMode = value;
				}
			}

			private bool _isDecisionRequired = true;
			public override bool IsDecisionRequired {
				get {
					return _isDecisionRequired;
				}
				set {
					_isDecisionRequired = value;
				}
			}

			private LocalizableString _question;
			public override LocalizableString Question {
				get {
					return _question ?? (_question = GetLocalizableString("b98be122f42246da8bb7c0a3e83ee7cb",
						 "BaseElements.UserQuestionUserTask1.Parameters.Question.Value"));
				}
				set {
					_question = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("b98be122f42246da8bb7c0a3e83ee7cb",
						 "BaseElements.UserQuestionUserTask1.Parameters.Recommendation.Value"));
				}
				set {
					_recommendation = value;
				}
			}

			internal Func<Guid> _ownerId;
			public override Guid OwnerId {
				get {
					return (_ownerId ?? (_ownerId = () => Guid.Empty)).Invoke();
				}
				set {
					_ownerId = () => { return value; };
				}
			}

			private int _duration = 5;
			public override int Duration {
				get {
					return _duration;
				}
				set {
					_duration = value;
				}
			}

			private int _durationPeriod = 0;
			public override int DurationPeriod {
				get {
					return _durationPeriod;
				}
				set {
					_durationPeriod = value;
				}
			}

			private bool _showInScheduler = false;
			public override bool ShowInScheduler {
				get {
					return _showInScheduler;
				}
				set {
					_showInScheduler = value;
				}
			}

			private bool _showExecutionPage = true;
			public override bool ShowExecutionPage {
				get {
					return _showExecutionPage;
				}
				set {
					_showExecutionPage = value;
				}
			}

			public virtual Guid ConfItem {
				get;
				set;
			}

			public virtual Guid Event {
				get;
				set;
			}

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"3fa4de2d-80ff-495a-b7c5-927d62fd5baa\",\"624264a7-1527-482e-a850-cf14eeda9305\"]";
			}

			#endregion

		}

		#endregion

		public IncidentDiagnosticsAndResolvingV2(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IncidentDiagnosticsAndResolvingV2";
			SchemaUId = new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_processUId = () => { return (Guid)(Guid.Parse("6AEEED31-5D8C-452E-B157-ED9AD8B83E57")); };
			_isTaskExists = () => { return (bool)(false); };
			_notStartedActivityStatusId = () => { return (Guid)(new Guid("384d4b84-58e6-df11-971b-001d60e938c6")); };
			_taskCaption = () => { return new LocalizableString((TaskCaptionValue)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b98be122-f422-46da-8bb7-c0a3e83ee7cb");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: IncidentDiagnosticsAndResolvingV2, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: IncidentDiagnosticsAndResolvingV2, Source element: {0}, None of the exclusive gateway conditions are met!";
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

		private Func<Guid> _processUId;
		public virtual Guid ProcessUId {
			get {
				return (_processUId ?? (_processUId = () => Guid.Empty)).Invoke();
			}
			set {
				_processUId = () => { return value; };
			}
		}

		private Func<bool> _isTaskExists;
		public virtual bool IsTaskExists {
			get {
				return (_isTaskExists ?? (_isTaskExists = () => false)).Invoke();
			}
			set {
				_isTaskExists = () => { return value; };
			}
		}

		private Func<Guid> _notStartedActivityStatusId;
		public virtual Guid NotStartedActivityStatusId {
			get {
				return (_notStartedActivityStatusId ?? (_notStartedActivityStatusId = () => Guid.Empty)).Invoke();
			}
			set {
				_notStartedActivityStatusId = () => { return value; };
			}
		}

		public virtual Guid CurrentTaskId {
			get;
			set;
		}

		private Func<LocalizableString> _taskCaption;
		public virtual LocalizableString TaskCaption {
			get {
				return (_taskCaption ?? (_taskCaption = () => null)).Invoke();
			}
			set {
				_taskCaption = () => { return value; };
			}
		}

		private LocalizableString _taskCaptionValue;
		public virtual LocalizableString TaskCaptionValue {
			get {
				return _taskCaptionValue ?? (_taskCaptionValue = GetLocalizableString("b98be122f42246da8bb7c0a3e83ee7cb",
						 "Parameters.TaskCaptionValue.Value"));
			}
			set {
				_taskCaptionValue = value;
			}
		}

		public virtual DateTime ActivityDueDate {
			get;
			set;
		}

		public virtual DateTime ActivityStartDate {
			get;
			set;
		}

		private ProcessLane1 _lane1;
		public ProcessLane1 Lane1 {
			get {
				return _lane1 ?? ((_lane1) = new ProcessLane1(UserConnection, this));
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
					SchemaElementUId = new Guid("04869428-40a4-4d45-ba84-5c89ce37b217"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessStartSignalEvent _createdNewIncidentStartSignal;
		public ProcessStartSignalEvent CreatedNewIncidentStartSignal {
			get {
				return _createdNewIncidentStartSignal ?? (_createdNewIncidentStartSignal = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "CreatedNewIncidentStartSignal",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("9ad8937e-6a59-4a6c-b6b0-32c1157f455c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessStartSignalEvent _modifiedInactiveIncidentStartSignal;
		public ProcessStartSignalEvent ModifiedInactiveIncidentStartSignal {
			get {
				return _modifiedInactiveIncidentStartSignal ?? (_modifiedInactiveIncidentStartSignal = new ProcessStartSignalEvent(UserConnection) {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartSignalEvent",
					Name = "ModifiedInactiveIncidentStartSignal",
					SerializeToDB = false,
					IsLogging = true,
					SchemaElementUId = new Guid("cefe2402-d24e-4662-9268-03c62b4e8ad0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private AddDiagnoseTaskFlowElement _addDiagnoseTask;
		public AddDiagnoseTaskFlowElement AddDiagnoseTask {
			get {
				return _addDiagnoseTask ?? (_addDiagnoseTask = new AddDiagnoseTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ReadCaseDataFlowElement _readCaseData;
		public ReadCaseDataFlowElement ReadCaseData {
			get {
				return _readCaseData ?? (_readCaseData = new ReadCaseDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("b4dbfeb1-c536-4a67-b205-344a03d90f82"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
						Question = GetLocalizableString(Schema.GetResourceManagerName(),
					"BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ResolvedCatchSignalFlowElement _resolvedCatchSignal;
		public ResolvedCatchSignalFlowElement ResolvedCatchSignal {
			get {
				return _resolvedCatchSignal ?? ((_resolvedCatchSignal) = new ResolvedCatchSignalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessExclusiveEventBasedGateway _eventBasedGateway1;
		public ProcessExclusiveEventBasedGateway EventBasedGateway1 {
			get {
				return _eventBasedGateway1 ?? (_eventBasedGateway1 = new ProcessExclusiveEventBasedGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventBasedGateway",
					Name = "EventBasedGateway1",
					SchemaElementUId = new Guid("ccf3540c-c804-4971-8995-4b3c3e683205"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Events = new Collection<string> { "CanceledCatchSignal", "ResolvedCatchSignal", "PendingCatchSignal", "EscalationCatchSignal", },
				});
			}
		}

		private ResolvedChangeDataUserTaskFlowElement _resolvedChangeDataUserTask;
		public ResolvedChangeDataUserTaskFlowElement ResolvedChangeDataUserTask {
			get {
				return _resolvedChangeDataUserTask ?? (_resolvedChangeDataUserTask = new ResolvedChangeDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private CanceledCatchSignalFlowElement _canceledCatchSignal;
		public CanceledCatchSignalFlowElement CanceledCatchSignal {
			get {
				return _canceledCatchSignal ?? ((_canceledCatchSignal) = new CanceledCatchSignalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private CanceledChangeDataUserTaskFlowElement _canceledChangeDataUserTask;
		public CanceledChangeDataUserTaskFlowElement CanceledChangeDataUserTask {
			get {
				return _canceledChangeDataUserTask ?? (_canceledChangeDataUserTask = new CanceledChangeDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private PendingCatchSignalFlowElement _pendingCatchSignal;
		public PendingCatchSignalFlowElement PendingCatchSignal {
			get {
				return _pendingCatchSignal ?? ((_pendingCatchSignal) = new PendingCatchSignalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private PendingChangeDataUserTaskFlowElement _pendingChangeDataUserTask;
		public PendingChangeDataUserTaskFlowElement PendingChangeDataUserTask {
			get {
				return _pendingChangeDataUserTask ?? (_pendingChangeDataUserTask = new PendingChangeDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private EscalationCatchSignalFlowElement _escalationCatchSignal;
		public EscalationCatchSignalFlowElement EscalationCatchSignal {
			get {
				return _escalationCatchSignal ?? ((_escalationCatchSignal) = new EscalationCatchSignalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private EscalationChangeDataUserTaskFlowElement _escalationChangeDataUserTask;
		public EscalationChangeDataUserTaskFlowElement EscalationChangeDataUserTask {
			get {
				return _escalationChangeDataUserTask ?? (_escalationChangeDataUserTask = new EscalationChangeDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _existsDiagnoseIncidentTask;
		public ProcessScriptTask ExistsDiagnoseIncidentTask {
			get {
				return _existsDiagnoseIncidentTask ?? (_existsDiagnoseIncidentTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ExistsDiagnoseIncidentTask",
					SchemaElementUId = new Guid("a5470c4b-b56a-4a48-87ba-c46af633f521"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ExistsDiagnoseIncidentTaskExecute,
				});
			}
		}

		private ReadCaseCountDataUserTaskFlowElement _readCaseCountDataUserTask;
		public ReadCaseCountDataUserTaskFlowElement ReadCaseCountDataUserTask {
			get {
				return _readCaseCountDataUserTask ?? (_readCaseCountDataUserTask = new ReadCaseCountDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private CompleteTasksChangeDataUserTaskFlowElement _completeTasksChangeDataUserTask;
		public CompleteTasksChangeDataUserTaskFlowElement CompleteTasksChangeDataUserTask {
			get {
				return _completeTasksChangeDataUserTask ?? (_completeTasksChangeDataUserTask = new CompleteTasksChangeDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private CancelTasksChangeDataUserTaskFlowElement _cancelTasksChangeDataUserTask;
		public CancelTasksChangeDataUserTaskFlowElement CancelTasksChangeDataUserTask {
			get {
				return _cancelTasksChangeDataUserTask ?? (_cancelTasksChangeDataUserTask = new CancelTasksChangeDataUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("815ee92a-d5be-44c7-9cb1-07a1bdb1fc7f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _setCurrentTask;
		public ProcessScriptTask SetCurrentTask {
			get {
				return _setCurrentTask ?? (_setCurrentTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetCurrentTask",
					SchemaElementUId = new Guid("70881c66-7559-4967-b02f-2bb93def217f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetCurrentTaskExecute,
				});
			}
		}

		private RescheduledCatchSignalFlowElement _rescheduledCatchSignal;
		public RescheduledCatchSignalFlowElement RescheduledCatchSignal {
			get {
				return _rescheduledCatchSignal ?? ((_rescheduledCatchSignal) = new RescheduledCatchSignalFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private AddRescheduledTaskUserTaskFlowElement _addRescheduledTaskUserTask;
		public AddRescheduledTaskUserTaskFlowElement AddRescheduledTaskUserTask {
			get {
				return _addRescheduledTaskUserTask ?? (_addRescheduledTaskUserTask = new AddRescheduledTaskUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private OpenResheduledTaskEditPageUserTaskFlowElement _openResheduledTaskEditPageUserTask;
		public OpenResheduledTaskEditPageUserTaskFlowElement OpenResheduledTaskEditPageUserTask {
			get {
				return _openResheduledTaskEditPageUserTask ?? (_openResheduledTaskEditPageUserTask = new OpenResheduledTaskEditPageUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _setRescheduledTaskFormula;
		public ProcessScriptTask SetRescheduledTaskFormula {
			get {
				return _setRescheduledTaskFormula ?? (_setRescheduledTaskFormula = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaFormulaTask",
					Name = "SetRescheduledTaskFormula",
					SchemaElementUId = new Guid("d3611d33-118c-47cc-a393-7f8025bbd3f8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetRescheduledTaskFormulaExecute,
				});
			}
		}

		private UserQuestionUserTask1FlowElement _userQuestionUserTask1;
		public UserQuestionUserTask1FlowElement UserQuestionUserTask1 {
			get {
				return _userQuestionUserTask1 ?? (_userQuestionUserTask1 = new UserQuestionUserTask1FlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("7f8b1890-288d-4ede-ac71-15b759489e77"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow1;
		public ProcessConditionalFlow ConditionalSequenceFlow1 {
			get {
				return _conditionalSequenceFlow1 ?? (_conditionalSequenceFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow1",
					SchemaElementUId = new Guid("1d38db98-8dc6-4042-9109-8a7749040b55"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow2;
		public ProcessConditionalFlow ConditionalSequenceFlow2 {
			get {
				return _conditionalSequenceFlow2 ?? (_conditionalSequenceFlow2 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow2",
					SchemaElementUId = new Guid("c441e48e-09cc-4a19-81e6-f377ad5c0d0c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow4;
		public ProcessConditionalFlow ConditionalSequenceFlow4 {
			get {
				return _conditionalSequenceFlow4 ?? (_conditionalSequenceFlow4 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow4",
					SchemaElementUId = new Guid("74d3d11b-a9f9-4b35-93b4-796e21acc9c4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"), new Collection<Guid>() {
							new Guid("3fa4de2d-80ff-495a-b7c5-927d62fd5baa"),
						}},
					},
				});
			}
		}

		private ProcessConditionalFlow _conditionalSequenceFlow3;
		public ProcessConditionalFlow ConditionalSequenceFlow3 {
			get {
				return _conditionalSequenceFlow3 ?? (_conditionalSequenceFlow3 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalSequenceFlow3",
					SchemaElementUId = new Guid("f6bd99ed-2ff7-4c65-82fd-851a090f22e7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
						ProcessActivitiesSelectedResults = new Dictionary<Guid, Collection<Guid>>() {
						{new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb"), new Collection<Guid>() {
							new Guid("624264a7-1527-482e-a850-cf14eeda9305"),
						}},
					},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[CreatedNewIncidentStartSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { CreatedNewIncidentStartSignal };
			FlowElements[ModifiedInactiveIncidentStartSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { ModifiedInactiveIncidentStartSignal };
			FlowElements[AddDiagnoseTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddDiagnoseTask };
			FlowElements[ReadCaseData.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCaseData };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ResolvedCatchSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { ResolvedCatchSignal };
			FlowElements[EventBasedGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventBasedGateway1 };
			FlowElements[ResolvedChangeDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ResolvedChangeDataUserTask };
			FlowElements[CanceledCatchSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { CanceledCatchSignal };
			FlowElements[CanceledChangeDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CanceledChangeDataUserTask };
			FlowElements[PendingCatchSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { PendingCatchSignal };
			FlowElements[PendingChangeDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PendingChangeDataUserTask };
			FlowElements[EscalationCatchSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { EscalationCatchSignal };
			FlowElements[EscalationChangeDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EscalationChangeDataUserTask };
			FlowElements[ExistsDiagnoseIncidentTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ExistsDiagnoseIncidentTask };
			FlowElements[ReadCaseCountDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ReadCaseCountDataUserTask };
			FlowElements[CompleteTasksChangeDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CompleteTasksChangeDataUserTask };
			FlowElements[CancelTasksChangeDataUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CancelTasksChangeDataUserTask };
			FlowElements[TerminateEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1 };
			FlowElements[SetCurrentTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetCurrentTask };
			FlowElements[RescheduledCatchSignal.SchemaElementUId] = new Collection<ProcessFlowElement> { RescheduledCatchSignal };
			FlowElements[AddRescheduledTaskUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddRescheduledTaskUserTask };
			FlowElements[OpenResheduledTaskEditPageUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenResheduledTaskEditPageUserTask };
			FlowElements[SetRescheduledTaskFormula.SchemaElementUId] = new Collection<ProcessFlowElement> { SetRescheduledTaskFormula };
			FlowElements[UserQuestionUserTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { UserQuestionUserTask1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Terminate1":
						CompleteProcess();
						break;
					case "CreatedNewIncidentStartSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "ModifiedInactiveIncidentStartSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExclusiveGateway1", e.Context.SenderName));
						break;
					case "AddDiagnoseTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EventBasedGateway1", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetCurrentTask", e.Context.SenderName));
						break;
					case "ReadCaseData":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ExistsDiagnoseIncidentTask", e.Context.SenderName));
						break;
					case "ExclusiveGateway1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseData", e.Context.SenderName));
						break;
					case "ResolvedCatchSignal":
						EventBasedGateway1.CancelNonexecutedEvents("ResolvedCatchSignal");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ResolvedChangeDataUserTask", e.Context.SenderName));
						break;
					case "EventBasedGateway1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CanceledCatchSignal", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ResolvedCatchSignal", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PendingCatchSignal", e.Context.SenderName));
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EscalationCatchSignal", e.Context.SenderName));
						break;
					case "ResolvedChangeDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseCountDataUserTask", e.Context.SenderName));
						break;
					case "CanceledCatchSignal":
						EventBasedGateway1.CancelNonexecutedEvents("CanceledCatchSignal");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CanceledChangeDataUserTask", e.Context.SenderName));
						break;
					case "CanceledChangeDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ReadCaseCountDataUserTask", e.Context.SenderName));
						break;
					case "PendingCatchSignal":
						EventBasedGateway1.CancelNonexecutedEvents("PendingCatchSignal");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PendingChangeDataUserTask", e.Context.SenderName));
						break;
					case "PendingChangeDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "EscalationCatchSignal":
						EventBasedGateway1.CancelNonexecutedEvents("EscalationCatchSignal");
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EscalationChangeDataUserTask", e.Context.SenderName));
						break;
					case "EscalationChangeDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "ExistsDiagnoseIncidentTask":
						if (ConditionalSequenceFlow1ExpressionExecute()) {
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("EventBasedGateway1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("ScriptTask1", e.Context.SenderName));
						Log.ErrorFormat(DeadEndGatewayLogMessage, "ExistsDiagnoseIncidentTask");
						break;
					case "ReadCaseCountDataUserTask":
						if (ConditionalSequenceFlow2ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("UserQuestionUserTask1", e.Context.SenderName));
							break;
						}
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("Terminate1", e.Context.SenderName));
						break;
					case "CompleteTasksChangeDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "CancelTasksChangeDataUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("TerminateEvent1", e.Context.SenderName));
						break;
					case "TerminateEvent1":
						CompleteProcess();
						break;
					case "SetCurrentTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RescheduledCatchSignal", e.Context.SenderName));
						break;
					case "RescheduledCatchSignal":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddRescheduledTaskUserTask", e.Context.SenderName));
						break;
					case "AddRescheduledTaskUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenResheduledTaskEditPageUserTask", e.Context.SenderName));
						break;
					case "OpenResheduledTaskEditPageUserTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetRescheduledTaskFormula", e.Context.SenderName));
						break;
					case "SetRescheduledTaskFormula":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("RescheduledCatchSignal", e.Context.SenderName));
						break;
					case "UserQuestionUserTask1":
						if (ConditionalSequenceFlow4ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CancelTasksChangeDataUserTask", e.Context.SenderName));
							break;
						}
						if (ConditionalSequenceFlow3ExpressionExecute()) {
							e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("CompleteTasksChangeDataUserTask", e.Context.SenderName));
							break;
						}
						Log.ErrorFormat(DeadEndGatewayLogMessage, "UserQuestionUserTask1");
						break;
					case "ScriptTask1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("AddDiagnoseTask", e.Context.SenderName));
						break;
			}
		}

		private bool ConditionalSequenceFlow1ExpressionExecute() {
			bool result = Convert.ToBoolean((IsTaskExists));
			Log.InfoFormat(ConditionalExpressionLogMessage, "ExistsDiagnoseIncidentTask", "ConditionalSequenceFlow1", "(IsTaskExists)", result);
			return result;
		}

		private bool ConditionalSequenceFlow2ExpressionExecute() {
			bool result = Convert.ToBoolean((ReadCaseCountDataUserTask.ResultCount)>0);
			Log.InfoFormat(ConditionalExpressionLogMessage, "ReadCaseCountDataUserTask", "ConditionalSequenceFlow2", "(ReadCaseCountDataUserTask.ResultCount)>0", result);
			return result;
		}

		private bool ConditionalSequenceFlow4ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalSequenceFlow4.ProcessActivitiesSelectedResults[new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "UserQuestionUserTask1", "ConditionalSequenceFlow4", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalSequenceFlow4.ProcessActivitiesSelectedResults[new Guid(\"4211020f-f647-4a9e-97d5-2c52d07813bb\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private bool ConditionalSequenceFlow3ExpressionExecute() {
			bool result = System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalSequenceFlow3.ProcessActivitiesSelectedResults[new Guid("4211020f-f647-4a9e-97d5-2c52d07813bb")])) != 0;
			Log.InfoFormat(ConditionalExpressionLogMessage, "UserQuestionUserTask1", "ConditionalSequenceFlow3", "System.Linq.Enumerable.Count(System.Linq.Enumerable.Intersect(JsonConvert.DeserializeObject<Collection<Guid>>(UserQuestionUserTask1.ResultDecisions), ConditionalSequenceFlow3.ProcessActivitiesSelectedResults[new Guid(\"4211020f-f647-4a9e-97d5-2c52d07813bb\")])) != 0", result);
			Log.Info($"UserQuestionUserTask1.ResultDecisions: {UserQuestionUserTask1.ResultDecisions}");
			return result;
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("UserQuestionUserTask1.ConfItem")) {
				writer.WriteValue("UserQuestionUserTask1.ConfItem", UserQuestionUserTask1.ConfItem, Guid.Empty);
			}
			if (!HasMapping("UserQuestionUserTask1.Event")) {
				writer.WriteValue("UserQuestionUserTask1.Event", UserQuestionUserTask1.Event, Guid.Empty);
			}
			if (!HasMapping("CurrentTaskId")) {
				writer.WriteValue("CurrentTaskId", CurrentTaskId, Guid.Empty);
			}
			if (!HasMapping("ActivityDueDate")) {
				writer.WriteValue("ActivityDueDate", ActivityDueDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("ActivityStartDate")) {
				writer.WriteValue("ActivityStartDate", ActivityStartDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("ProcessUId")) {
				writer.WriteValue("ProcessUId", ProcessUId, Guid.Empty);
			}
			if (!HasMapping("IsTaskExists")) {
				writer.WriteValue("IsTaskExists", IsTaskExists, false);
			}
			if (!HasMapping("NotStartedActivityStatusId")) {
				writer.WriteValue("NotStartedActivityStatusId", NotStartedActivityStatusId, Guid.Empty);
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
			MetaPathParameterValues.Add("415d89df-f50f-46b6-8a77-b034e8173608", () => ProcessUId);
			MetaPathParameterValues.Add("ecd8a32c-df30-44e9-89f6-3adc6c3bdfd8", () => IsTaskExists);
			MetaPathParameterValues.Add("ec21229b-9b25-49d7-92ad-eed18aa728e5", () => NotStartedActivityStatusId);
			MetaPathParameterValues.Add("ae73a291-5391-4398-ad71-c61091bd78fe", () => CurrentTaskId);
			MetaPathParameterValues.Add("7cdb4564-160f-4dc7-afbd-a2d9ac97aa23", () => TaskCaption);
			MetaPathParameterValues.Add("a0a5e89d-ee0e-4227-948e-7fcad6fbb49e", () => TaskCaptionValue);
			MetaPathParameterValues.Add("77719740-2177-4b8a-b22a-54a091ab6496", () => ActivityDueDate);
			MetaPathParameterValues.Add("aa6b400d-ea76-4b36-a31a-03f5695b31dc", () => ActivityStartDate);
			MetaPathParameterValues.Add("eb69a7f3-6d56-4292-8246-38c29e406529", () => CreatedNewIncidentStartSignal.RecordId);
			MetaPathParameterValues.Add("b7921a8f-2af8-4912-99a2-e91f94ee1377", () => CreatedNewIncidentStartSignal.EntitySchemaUId);
			MetaPathParameterValues.Add("ad68430c-33cb-4b0e-9767-a62d05a705bb", () => ModifiedInactiveIncidentStartSignal.RecordId);
			MetaPathParameterValues.Add("133eafbe-3f14-4fbf-8b65-546fedfd2878", () => ModifiedInactiveIncidentStartSignal.EntitySchemaUId);
			MetaPathParameterValues.Add("47381106-439b-48de-a3be-7347358ad7d6", () => AddDiagnoseTask.EntitySchemaId);
			MetaPathParameterValues.Add("2e5068e9-10ba-4629-9ad3-a2262e2be850", () => AddDiagnoseTask.DataSourceFilters);
			MetaPathParameterValues.Add("b0c3a7d0-eda7-45fa-93f0-1e0bd05d687d", () => AddDiagnoseTask.RecordAddMode);
			MetaPathParameterValues.Add("2ff06d85-70bf-4fe3-84cb-f040ea533588", () => AddDiagnoseTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("fb5c9609-3001-46fb-999e-e8f79c1d2ce2", () => AddDiagnoseTask.RecordDefValues);
			MetaPathParameterValues.Add("15433e0e-c833-4c29-9b51-7ec388ba323f", () => AddDiagnoseTask.RecordId);
			MetaPathParameterValues.Add("66971b22-af85-40d4-8000-b58148d0d4b7", () => AddDiagnoseTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e20c98d0-9d0e-407b-930b-a6b43f524e3c", () => ReadCaseData.DataSourceFilters);
			MetaPathParameterValues.Add("fa34df5c-7b4e-47ae-a912-474e470b6c45", () => ReadCaseData.ResultType);
			MetaPathParameterValues.Add("90e6fe3b-6a23-4699-9d12-17cb6e9231df", () => ReadCaseData.ReadSomeTopRecords);
			MetaPathParameterValues.Add("f4188d8f-b976-4570-97fc-41b0f9be5bfc", () => ReadCaseData.NumberOfRecords);
			MetaPathParameterValues.Add("dfebf7b5-d60e-4831-b0d2-43813be0a77d", () => ReadCaseData.FunctionType);
			MetaPathParameterValues.Add("9adc4f45-21a7-4b76-9422-1980c48bcf46", () => ReadCaseData.AggregationColumnName);
			MetaPathParameterValues.Add("7754467c-fdaa-4a75-8546-a1292b5a6ded", () => ReadCaseData.OrderInfo);
			MetaPathParameterValues.Add("7a51a482-cc66-4157-a765-07dfae9e0f6b", () => ReadCaseData.ResultEntity);
			MetaPathParameterValues.Add("f5018c00-5f7e-48d6-bf73-d4ce6cbf8adf", () => ReadCaseData.ResultCount);
			MetaPathParameterValues.Add("cad8e278-2b4a-4f1b-8ccf-55db9d72df60", () => ReadCaseData.ResultIntegerFunction);
			MetaPathParameterValues.Add("31c46bd6-ea7c-4f58-8530-fa76fa4e672f", () => ReadCaseData.ResultFloatFunction);
			MetaPathParameterValues.Add("81e76ac5-083c-40f7-a7a6-1a58511ec988", () => ReadCaseData.ResultDateTimeFunction);
			MetaPathParameterValues.Add("f3ab54a9-d46b-470b-9dd7-8f28314883aa", () => ReadCaseData.ResultRowsCount);
			MetaPathParameterValues.Add("29febfab-7d22-4313-9fce-288ec640e85f", () => ReadCaseData.CanReadUncommitedData);
			MetaPathParameterValues.Add("c73dce7a-814b-4024-bd5d-023c0ae8ff38", () => ReadCaseData.ResultEntityCollection);
			MetaPathParameterValues.Add("d2d9806f-75cc-4f82-957f-a0faf091d697", () => ReadCaseData.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("80b7264a-0735-4862-9f54-b35f79ae6dba", () => ReadCaseData.IgnoreDisplayValues);
			MetaPathParameterValues.Add("deb1676b-e3ed-4d08-b4d4-40bb2d5e2294", () => ReadCaseData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("852a79b3-d625-4f18-b6ee-e2a25dd3c9b6", () => ReadCaseData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("78f519cc-f8d2-4fac-9f87-2dc4c245ab29", () => ResolvedCatchSignal.RecordId);
			MetaPathParameterValues.Add("92796a3d-edaa-47bf-9730-0fb84a1bcb7f", () => ResolvedChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("69f7d295-e143-42e8-bb3c-c2f6f0421146", () => ResolvedChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("792c5022-ebba-44b5-955b-42c816843971", () => ResolvedChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("59ead31f-77ed-48f6-a880-82e8bb04a642", () => ResolvedChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("007d344c-9adf-43d3-8cdf-38202c99461b", () => ResolvedChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("9e2aacd6-9c62-4726-94bc-1859bba3cced", () => CanceledCatchSignal.RecordId);
			MetaPathParameterValues.Add("183ecb6a-29e5-46cc-83dd-a8ec060bc191", () => CanceledChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("58ab220b-a239-4004-a8b3-362b8616d6b5", () => CanceledChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("cb23be2e-d56f-4c76-8277-bea8232dc232", () => CanceledChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("1546ad35-5335-436b-9a67-31666d57fea3", () => CanceledChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("393ddbb7-7225-496c-8519-19de2a93f2c6", () => CanceledChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("159c71ef-be09-4085-8d00-3c67a436bd4b", () => PendingCatchSignal.RecordId);
			MetaPathParameterValues.Add("9ceb65d0-c08f-4758-80c4-0eb931174b9b", () => PendingChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("2e50cca2-8933-4280-8cbf-18fdb137ab50", () => PendingChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("fa758883-6271-4b3c-bbfa-6cbee86d2b5b", () => PendingChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("95810b4e-5292-4018-a8df-b266bc723708", () => PendingChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("3fa1654a-da29-4e48-a8e1-dd36696db7fe", () => PendingChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("cc1f93c0-6974-4f8b-b1e8-6a819c4b21e9", () => EscalationCatchSignal.RecordId);
			MetaPathParameterValues.Add("da080b93-b78a-437a-adbc-9f4eee898cc5", () => EscalationChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("a94e00f8-50cc-4b2b-9d7e-3c846c8fe91d", () => EscalationChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("b03d7915-a2be-4918-8d0b-ca7e158f79e6", () => EscalationChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("ecc66875-1982-4fd7-99ab-6d047904b215", () => EscalationChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("ce8c2f5a-cc7d-408e-8b05-bc44d01becf2", () => EscalationChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("6e10b476-de64-4b9b-8536-f53f0ce813e9", () => ReadCaseCountDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("e57b1d74-578d-476a-b807-98eadc71a555", () => ReadCaseCountDataUserTask.ResultType);
			MetaPathParameterValues.Add("f86d057a-db93-4c1d-a3b0-3470068d9d08", () => ReadCaseCountDataUserTask.ReadSomeTopRecords);
			MetaPathParameterValues.Add("fc0df9c8-409b-444e-a12d-e048877ca940", () => ReadCaseCountDataUserTask.NumberOfRecords);
			MetaPathParameterValues.Add("d119c974-e8fb-423b-b661-fc9d3c080ea7", () => ReadCaseCountDataUserTask.FunctionType);
			MetaPathParameterValues.Add("0676e49c-6b30-489d-83c5-ab83ad3e6093", () => ReadCaseCountDataUserTask.AggregationColumnName);
			MetaPathParameterValues.Add("c9b59582-9d62-471e-8bb4-aa7df0658127", () => ReadCaseCountDataUserTask.OrderInfo);
			MetaPathParameterValues.Add("e0685b0c-239b-47ce-8492-ff99b21d13a5", () => ReadCaseCountDataUserTask.ResultEntity);
			MetaPathParameterValues.Add("399de72a-ef6d-4a47-b355-3086cf7cc0cd", () => ReadCaseCountDataUserTask.ResultCount);
			MetaPathParameterValues.Add("b6b9ddf5-da1a-4be7-80c2-86cd883ed495", () => ReadCaseCountDataUserTask.ResultIntegerFunction);
			MetaPathParameterValues.Add("518f26fc-42e0-4dfd-bded-1ca5061316e6", () => ReadCaseCountDataUserTask.ResultFloatFunction);
			MetaPathParameterValues.Add("c56a1f76-9f86-47e6-b3b7-33ab372ebaef", () => ReadCaseCountDataUserTask.ResultDateTimeFunction);
			MetaPathParameterValues.Add("ace9d311-33b7-4a4f-8db5-5154787974c9", () => ReadCaseCountDataUserTask.ResultRowsCount);
			MetaPathParameterValues.Add("20e89035-f4c1-4152-b109-4eedc803888e", () => ReadCaseCountDataUserTask.CanReadUncommitedData);
			MetaPathParameterValues.Add("b1feaf4d-a320-4d9a-a665-cddda8e8bb59", () => ReadCaseCountDataUserTask.ResultEntityCollection);
			MetaPathParameterValues.Add("d49a261c-b0a1-4251-8c54-c4923cc2b11f", () => ReadCaseCountDataUserTask.EntityColumnMetaPathes);
			MetaPathParameterValues.Add("bce2b23c-43d7-4ee3-99a6-d42915037782", () => ReadCaseCountDataUserTask.IgnoreDisplayValues);
			MetaPathParameterValues.Add("26fee922-21a7-4cbd-aaa5-6625b9d9ba29", () => ReadCaseCountDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("f19d01c9-602a-413a-8523-48e2ede551bb", () => ReadCaseCountDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("99f2dd86-4eab-47c5-8ba2-01d496b9a3fb", () => CompleteTasksChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("6a09dbe4-c830-4973-9ba2-bee31e9f77f2", () => CompleteTasksChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("c8a7ec42-256a-40db-af79-d1e36121c71c", () => CompleteTasksChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("cbba51f0-1bbc-4cab-9bfd-7c94e372df30", () => CompleteTasksChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("03049495-dcd9-42dd-af23-bec53dcdc252", () => CompleteTasksChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e21b52d3-db26-4e4e-8254-fcc14a5f7386", () => CancelTasksChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("59deaa49-2d60-48b6-81d5-cecd7aaaf43b", () => CancelTasksChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("c590c5de-cb61-45ff-a24d-d8ee718c86e7", () => CancelTasksChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("6c0bc164-4425-4e9d-abaf-b243259091c3", () => CancelTasksChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("d4b8b9f6-cbed-4713-9af0-46cd9bfd1a56", () => CancelTasksChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a46b9b07-561d-402a-bfce-8c12452a18d2", () => RescheduledCatchSignal.RecordId);
			MetaPathParameterValues.Add("92b7b385-b361-4426-aa17-35a191aa76c8", () => AddRescheduledTaskUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("b7e1b44d-217e-4e2f-a90c-17a5ebf74c94", () => AddRescheduledTaskUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("d5038619-45b6-440d-9cef-0b9bb2381b70", () => AddRescheduledTaskUserTask.RecordAddMode);
			MetaPathParameterValues.Add("c587e107-d285-4719-941f-a1aa76cdf30e", () => AddRescheduledTaskUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("2a49baff-f87a-4844-8d6e-503b3b93151b", () => AddRescheduledTaskUserTask.RecordDefValues);
			MetaPathParameterValues.Add("538e3867-2d16-4738-823f-530a3f2cd5a7", () => AddRescheduledTaskUserTask.RecordId);
			MetaPathParameterValues.Add("104d9e8d-7905-42b4-acf2-bc19a2e3dd40", () => AddRescheduledTaskUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("f9f0b2ef-b537-4f31-a5bd-bc0b4387a477", () => OpenResheduledTaskEditPageUserTask.ObjectSchemaId);
			MetaPathParameterValues.Add("73f9197d-3c80-4e5a-a6dd-fd7e5eb882d5", () => OpenResheduledTaskEditPageUserTask.PageSchemaId);
			MetaPathParameterValues.Add("a517303e-9785-4d9c-be67-2b59977d0b6c", () => OpenResheduledTaskEditPageUserTask.EditMode);
			MetaPathParameterValues.Add("cdfee2f2-2914-43ad-8e30-4e93a8301ea1", () => OpenResheduledTaskEditPageUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("2d261075-7320-45c5-a0b8-da25a32b1ce0", () => OpenResheduledTaskEditPageUserTask.RecordId);
			MetaPathParameterValues.Add("975dad01-0f9c-41f9-9dba-6c204620b59d", () => OpenResheduledTaskEditPageUserTask.ExecutedMode);
			MetaPathParameterValues.Add("c2630eb6-4cab-45a0-a61a-f97018285882", () => OpenResheduledTaskEditPageUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("8553b6f1-1c80-4fc3-ae4d-08b5cd7171f8", () => OpenResheduledTaskEditPageUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("6e47e63f-e942-4085-a3bd-6ab9010b12ff", () => OpenResheduledTaskEditPageUserTask.GenerateDecisionsFromColumn);
			MetaPathParameterValues.Add("d0d67c0b-b33d-46f1-a228-5a0a3f8db1a5", () => OpenResheduledTaskEditPageUserTask.DecisionalColumnMetaPath);
			MetaPathParameterValues.Add("34934901-cc88-496d-874d-c790334668d4", () => OpenResheduledTaskEditPageUserTask.ResultParameter);
			MetaPathParameterValues.Add("4fc12d51-aee6-4025-b7b7-9cb916b765c1", () => OpenResheduledTaskEditPageUserTask.IsReexecution);
			MetaPathParameterValues.Add("36fc1749-5e74-486d-9aa2-9997322bd096", () => OpenResheduledTaskEditPageUserTask.Recommendation);
			MetaPathParameterValues.Add("a4ce0f56-9fe5-4465-8f2e-2b52e4ea511a", () => OpenResheduledTaskEditPageUserTask.ActivityCategory);
			MetaPathParameterValues.Add("8923c12b-3e36-466f-8b47-a61859bf4610", () => OpenResheduledTaskEditPageUserTask.OwnerId);
			MetaPathParameterValues.Add("77d923b9-b162-4dc3-a65a-f662c1683465", () => OpenResheduledTaskEditPageUserTask.Duration);
			MetaPathParameterValues.Add("cf9a71fe-d429-4b38-b8e7-dfe32a55ae55", () => OpenResheduledTaskEditPageUserTask.DurationPeriod);
			MetaPathParameterValues.Add("3e7299c2-13e1-4fb6-9110-6637acbf7fa8", () => OpenResheduledTaskEditPageUserTask.StartIn);
			MetaPathParameterValues.Add("92526212-b4e7-4c84-b889-378fb2292a7a", () => OpenResheduledTaskEditPageUserTask.StartInPeriod);
			MetaPathParameterValues.Add("de781630-7327-4331-8d12-5d22d92e1737", () => OpenResheduledTaskEditPageUserTask.RemindBefore);
			MetaPathParameterValues.Add("189d2378-a138-4c1f-876e-ca81238f2c0b", () => OpenResheduledTaskEditPageUserTask.RemindBeforePeriod);
			MetaPathParameterValues.Add("0b7d386f-a98b-4951-b236-c81c9d1971b1", () => OpenResheduledTaskEditPageUserTask.ShowInScheduler);
			MetaPathParameterValues.Add("ebd95a51-ddeb-44d8-bf32-63592a44c539", () => OpenResheduledTaskEditPageUserTask.ShowExecutionPage);
			MetaPathParameterValues.Add("d6fdb102-6caa-49e9-a5b2-1c770ca6e847", () => OpenResheduledTaskEditPageUserTask.Lead);
			MetaPathParameterValues.Add("ca853fd2-05a9-469a-a508-4e39f3da9059", () => OpenResheduledTaskEditPageUserTask.Account);
			MetaPathParameterValues.Add("9329119b-85e9-4b2b-8a37-3b22c75f7a41", () => OpenResheduledTaskEditPageUserTask.Contact);
			MetaPathParameterValues.Add("8d6acd3b-9769-4126-94cb-a2c73f82c650", () => OpenResheduledTaskEditPageUserTask.Opportunity);
			MetaPathParameterValues.Add("3dec8030-fe45-48ff-9399-e7952212a53c", () => OpenResheduledTaskEditPageUserTask.Invoice);
			MetaPathParameterValues.Add("27e6ba69-8288-4933-94c8-3077891add79", () => OpenResheduledTaskEditPageUserTask.Document);
			MetaPathParameterValues.Add("29631052-774c-49d8-b31d-f1c8820e0946", () => OpenResheduledTaskEditPageUserTask.Incident);
			MetaPathParameterValues.Add("87e7e4d8-7bcb-4fc9-84c8-670dbb29fd6d", () => OpenResheduledTaskEditPageUserTask.Case);
			MetaPathParameterValues.Add("a45b4882-0481-4d81-82ad-1c5b52de9081", () => OpenResheduledTaskEditPageUserTask.ActivityResult);
			MetaPathParameterValues.Add("cf1b147f-ba96-4412-a061-6dc9d86fe625", () => OpenResheduledTaskEditPageUserTask.CurrentActivityId);
			MetaPathParameterValues.Add("6ea35da2-f744-4d97-ba95-f3db35c6a221", () => OpenResheduledTaskEditPageUserTask.IsActivityCompleted);
			MetaPathParameterValues.Add("6351291c-9331-45a5-b9e7-07dcfb87ca72", () => OpenResheduledTaskEditPageUserTask.ExecutionContext);
			MetaPathParameterValues.Add("bc0f1f42-e563-4d5d-a178-dc465ba0dd21", () => OpenResheduledTaskEditPageUserTask.PageTypeUId);
			MetaPathParameterValues.Add("a1876452-d45e-49e4-9764-f5701aa6c862", () => OpenResheduledTaskEditPageUserTask.ActivitySchemaUId);
			MetaPathParameterValues.Add("6d3b9d72-0379-484c-91be-dbd4cfaa6087", () => OpenResheduledTaskEditPageUserTask.InformationOnStep);
			MetaPathParameterValues.Add("2eeff63d-d521-490d-a199-1ebc8eab8777", () => OpenResheduledTaskEditPageUserTask.Order);
			MetaPathParameterValues.Add("f2e5410e-5ad0-434f-b0ff-e54c67b05726", () => OpenResheduledTaskEditPageUserTask.Requests);
			MetaPathParameterValues.Add("0d61e10b-5035-4def-a3ab-2b157dc34402", () => OpenResheduledTaskEditPageUserTask.Listing);
			MetaPathParameterValues.Add("07cc0683-8fb0-412d-84e4-1129fe369a51", () => OpenResheduledTaskEditPageUserTask.Property);
			MetaPathParameterValues.Add("fb1686c8-d568-46c0-84ce-b39d2c502807", () => OpenResheduledTaskEditPageUserTask.Contract);
			MetaPathParameterValues.Add("45923a9c-afb5-4081-b2ee-958f0892885b", () => OpenResheduledTaskEditPageUserTask.Problem);
			MetaPathParameterValues.Add("dc430176-a84a-4020-9f66-3796a92959ce", () => OpenResheduledTaskEditPageUserTask.Change);
			MetaPathParameterValues.Add("fb3da557-5fd3-41cf-bc78-31f1210af7b7", () => OpenResheduledTaskEditPageUserTask.Release);
			MetaPathParameterValues.Add("c38a9663-79ef-4428-9487-8fdeadfe594e", () => OpenResheduledTaskEditPageUserTask.Project);
			MetaPathParameterValues.Add("ce7708dd-a1a2-4e62-be9e-757ab3935223", () => OpenResheduledTaskEditPageUserTask.ActivityPriority);
			MetaPathParameterValues.Add("12406193-22d3-49d9-84eb-58074f996740", () => OpenResheduledTaskEditPageUserTask.CreateActivity);
			MetaPathParameterValues.Add("675f0993-7e43-4f73-9a39-40712c295959", () => UserQuestionUserTask1.BranchingDecisions);
			MetaPathParameterValues.Add("d7ddf2ac-d757-46b1-be45-23d92c75fac3", () => UserQuestionUserTask1.ResultDecisions);
			MetaPathParameterValues.Add("000efa2d-fb03-4c16-a5d9-f25cf8f9d82d", () => UserQuestionUserTask1.DecisionMode);
			MetaPathParameterValues.Add("215456ce-4520-4c29-b6d6-8259bd1cb74b", () => UserQuestionUserTask1.IsDecisionRequired);
			MetaPathParameterValues.Add("51a4a529-9378-410d-8fa1-e469e0bfa4e0", () => UserQuestionUserTask1.Question);
			MetaPathParameterValues.Add("c50c1d7b-3b09-46d8-91ca-188cb23ef8c2", () => UserQuestionUserTask1.WindowCaption);
			MetaPathParameterValues.Add("dc8b9fc3-346a-4e8b-a0ac-66c45ebc30b2", () => UserQuestionUserTask1.Recommendation);
			MetaPathParameterValues.Add("f48bfc98-8af5-4b8b-8f0e-0f54a4b68120", () => UserQuestionUserTask1.ActivityCategory);
			MetaPathParameterValues.Add("ca4f9842-d9ff-4a15-b38b-1cd918ee9ed3", () => UserQuestionUserTask1.OwnerId);
			MetaPathParameterValues.Add("622b9f2a-4cb2-43a8-8f4b-becabac69839", () => UserQuestionUserTask1.Duration);
			MetaPathParameterValues.Add("acc42a39-4371-4da5-b7fc-d06c3e13ec03", () => UserQuestionUserTask1.DurationPeriod);
			MetaPathParameterValues.Add("a5d59779-62f7-485f-b4a9-a0d09a870942", () => UserQuestionUserTask1.StartIn);
			MetaPathParameterValues.Add("43205693-5dcc-43f3-a331-b49c4bc9973d", () => UserQuestionUserTask1.StartInPeriod);
			MetaPathParameterValues.Add("d471d560-f33f-4ec8-b727-bf18cd94b7c2", () => UserQuestionUserTask1.RemindBefore);
			MetaPathParameterValues.Add("e895a017-2743-4df7-be4f-c24ce2e71411", () => UserQuestionUserTask1.RemindBeforePeriod);
			MetaPathParameterValues.Add("9dfce689-a334-4c71-8932-456ffbbfdca7", () => UserQuestionUserTask1.ShowInScheduler);
			MetaPathParameterValues.Add("a9906e90-904c-47dc-a148-9c2ac1836a1f", () => UserQuestionUserTask1.ShowExecutionPage);
			MetaPathParameterValues.Add("3d2362be-d4ae-4a2b-b570-6dadadab9cfb", () => UserQuestionUserTask1.Lead);
			MetaPathParameterValues.Add("65dedf77-e2ac-4f6a-81b0-9b66c8145aa7", () => UserQuestionUserTask1.Account);
			MetaPathParameterValues.Add("1663995d-0b3c-4b2c-a172-e140a6adcfc2", () => UserQuestionUserTask1.Contact);
			MetaPathParameterValues.Add("eca4a8da-4536-4478-8fb8-db24bbdb8f90", () => UserQuestionUserTask1.Opportunity);
			MetaPathParameterValues.Add("972e2db6-3271-40c0-82a2-3d60f8cee668", () => UserQuestionUserTask1.Invoice);
			MetaPathParameterValues.Add("1cea383e-0fcf-4a49-af48-76f2446e9056", () => UserQuestionUserTask1.Document);
			MetaPathParameterValues.Add("40e4bd9f-a064-4a0a-9a39-d1d5e1f3a19c", () => UserQuestionUserTask1.Incident);
			MetaPathParameterValues.Add("f2bc9f52-708a-476d-a06a-4e438caea1c8", () => UserQuestionUserTask1.Case);
			MetaPathParameterValues.Add("332854ec-8027-4a9f-be87-fd81e4c8cdc4", () => UserQuestionUserTask1.ActivityResult);
			MetaPathParameterValues.Add("8a4aa587-30b7-4d91-8af2-9c962132c668", () => UserQuestionUserTask1.CurrentActivityId);
			MetaPathParameterValues.Add("8624a7a9-f290-4573-a493-1a331d465b0c", () => UserQuestionUserTask1.IsActivityCompleted);
			MetaPathParameterValues.Add("73499557-0a32-4d92-84b3-8bb67973374b", () => UserQuestionUserTask1.ExecutionContext);
			MetaPathParameterValues.Add("7bf7d250-d34e-4225-aaa6-dcddbf01f6d2", () => UserQuestionUserTask1.InformationOnStep);
			MetaPathParameterValues.Add("58d3775d-23b0-4670-9b6c-61eed72117e4", () => UserQuestionUserTask1.Order);
			MetaPathParameterValues.Add("8e07b990-896f-406b-b301-1ca5ad999a3b", () => UserQuestionUserTask1.Requests);
			MetaPathParameterValues.Add("33643c88-34dd-4205-98e0-a9d17513a406", () => UserQuestionUserTask1.Listing);
			MetaPathParameterValues.Add("e6e31938-0b0f-4bba-a9bb-1722f1b6c875", () => UserQuestionUserTask1.Property);
			MetaPathParameterValues.Add("4ac1b552-b731-4e7f-a4aa-2104b7d151c1", () => UserQuestionUserTask1.Contract);
			MetaPathParameterValues.Add("7abadf0a-2e61-4b8b-ae34-40e154e2bae6", () => UserQuestionUserTask1.Project);
			MetaPathParameterValues.Add("4790f3c7-f104-4440-a586-b32ca6f69887", () => UserQuestionUserTask1.Problem);
			MetaPathParameterValues.Add("ee3e666e-6999-4800-8719-42b69d82985f", () => UserQuestionUserTask1.Change);
			MetaPathParameterValues.Add("e2b728c6-93b7-493c-978a-05eb21b9cdf3", () => UserQuestionUserTask1.Release);
			MetaPathParameterValues.Add("14076b06-efec-4aed-89e3-2c03796d1f8d", () => UserQuestionUserTask1.CreateActivity);
			MetaPathParameterValues.Add("1d9d7996-7757-41f9-b627-e742a0b24a2e", () => UserQuestionUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("3210c491-5bf8-4c44-809f-2ccea5bab678", () => UserQuestionUserTask1.ConfItem);
			MetaPathParameterValues.Add("f2efe05d-aea3-45b2-ac3b-b435686ba5c7", () => UserQuestionUserTask1.Event);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "UserQuestionUserTask1.ConfItem":
					UserQuestionUserTask1.ConfItem = reader.GetValue<System.Guid>();
				break;
				case "UserQuestionUserTask1.Event":
					UserQuestionUserTask1.Event = reader.GetValue<System.Guid>();
				break;
				case "CurrentTaskId":
					if (!hasValueToRead) break;
					CurrentTaskId = reader.GetValue<System.Guid>();
				break;
				case "ActivityDueDate":
					if (!hasValueToRead) break;
					ActivityDueDate = reader.GetValue<System.DateTime>();
				break;
				case "ActivityStartDate":
					if (!hasValueToRead) break;
					ActivityStartDate = reader.GetValue<System.DateTime>();
				break;
				case "ProcessUId":
					if (!hasValueToRead) break;
					ProcessUId = reader.GetValue<System.Guid>();
				break;
				case "IsTaskExists":
					if (!hasValueToRead) break;
					IsTaskExists = reader.GetValue<System.Boolean>();
				break;
				case "NotStartedActivityStatusId":
					if (!hasValueToRead) break;
					NotStartedActivityStatusId = reader.GetValue<System.Guid>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool ExistsDiagnoseIncidentTaskExecute(ProcessExecutingContext context) {
			var sysProcessEntitySelect = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysProcessEntity");
			sysProcessEntitySelect.AddColumn("SysProcess");
			var entityRecordId = ReadCaseData.ResultEntity.GetTypedColumnValue<Guid>("Id");
			sysProcessEntitySelect.Filters.Add(sysProcessEntitySelect.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", entityRecordId));
			sysProcessEntitySelect.Filters.Add(sysProcessEntitySelect.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysProcessLog:Id:SysProcess].SysSchema.UId", ProcessUId));
			sysProcessEntitySelect.Filters.Add(sysProcessEntitySelect.CreateFilterWithParameters(FilterComparisonType.Equal, "[Activity:Case:EntityId].Status", NotStartedActivityStatusId));
			var collection = sysProcessEntitySelect.GetEntityCollection(UserConnection); 
			IsTaskExists = collection.Count > 0;
			return true; 
		}

		public virtual bool SetCurrentTaskExecute(ProcessExecutingContext context) {
			var localCurrentTaskId = (AddDiagnoseTask.RecordId);
			CurrentTaskId = (System.Guid)localCurrentTaskId;
			return true;
		}

		public virtual bool SetRescheduledTaskFormulaExecute(ProcessExecutingContext context) {
			var localCurrentTaskId = (AddRescheduledTaskUserTask.RecordId);
			CurrentTaskId = (System.Guid)localCurrentTaskId;
			return true;
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			var startDate = UserConnection.CurrentUser.GetCurrentDateTime();
			int startMinute = startDate.Minute;
			startMinute = (((startMinute / 5) + 2 * (startMinute % 5) / 5) * 5) % 60;
			var val = startDate.AddMinutes(-startDate.Minute);
			startDate = val.AddMinutes(startMinute);
			startDate = startDate.AddSeconds(-startDate.Second);
			ActivityStartDate = startDate;
			ActivityDueDate = startDate.AddMinutes(30);
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
			var cloneItem = (IncidentDiagnosticsAndResolvingV2)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

