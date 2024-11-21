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

	#region Class: IncidentDiagnosticsAndResolvingSchema

	/// <exclude/>
	public class IncidentDiagnosticsAndResolvingSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public IncidentDiagnosticsAndResolvingSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public IncidentDiagnosticsAndResolvingSchema(IncidentDiagnosticsAndResolvingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "IncidentDiagnosticsAndResolving";
			UId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57");
			CreatedInPackageId = new Guid("ce623b78-6526-411f-bc45-53ddeb08476f");
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
			Tag = @"Business process";
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			RealUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57");
			Version = 0;
			PackageUId = new Guid("76d633dd-63f4-4955-b36c-e6042cb74dfd");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreateProcessUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("415d89df-f50f-46b6-8a77-b034e8173608"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Name = @"ProcessUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"Guid.Parse(""6AEEED31-5D8C-452E-B157-ED9AD8B83E57"")",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateIsTaskExistsParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ecd8a32c-df30-44e9-89f6-3adc6c3bdfd8"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Name = @"IsTaskExists",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"false",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateNotStartedActivityStatusIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ec21229b-9b25-49d7-92ad-eed18aa728e5"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Name = @"NotStartedActivityStatusId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"[#Lookup.805aace4-8604-40e7-a9eb-0f54174593c0.384d4b84-58e6-df11-971b-001d60e938c6#]",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateCurrentTaskIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("ae73a291-5391-4398-ad71-c61091bd78fe"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Name = @"TaskCaption",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateTaskCaptionValueParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("a0a5e89d-ee0e-4227-948e-7fcad6fbb49e"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("391f4991-86a6-4a6d-9a3e-b08a114cc7d3"),
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Name = @"TaskCaptionValue",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("LocalizableStringDataValueType"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.ConstValue,
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateActivityDueDateParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("77719740-2177-4b8a-b22a-54a091ab6496"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = Guid.Empty
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = Guid.Empty
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,91,111,83,73,12,254,43,209,129,55,58,209,220,47,125,99,129,149,42,1,91,81,150,23,202,131,103,198,3,17,105,82,37,39,172,186,85,255,251,126,39,109,161,101,217,94,180,42,23,53,121,72,148,201,177,199,99,251,179,191,113,142,187,135,253,209,33,119,219,221,111,187,47,246,230,173,31,63,153,47,120,188,187,152,23,94,46,199,207,231,133,166,147,191,41,79,121,151,22,116,192,61,47,222,208,116,197,203,231,147,101,191,53,186,40,212,109,117,15,63,173,127,235,182,223,30,119,59,61,31,252,185,83,161,217,26,230,152,173,23,228,98,20,182,104,18,185,57,43,114,200,84,141,84,165,185,8,225,50,159,174,14,102,47,184,167,93,234,63,116,219,199,221,90,27,20,148,168,108,163,160,4,75,149,133,53,218,9,42,177,138,88,45,233,100,184,42,19,187,147,173,110,89,62,240,1,173,55,189,32,108,109,170,209,104,65,182,20,97,179,84,34,167,234,68,36,165,139,213,148,90,76,131,240,217,243,95,4,223,62,120,62,159,127,92,29,142,147,87,172,101,132,253,74,99,251,170,131,200,50,57,97,101,86,236,109,245,165,200,113,115,170,88,111,141,112,145,189,168,77,41,145,2,172,149,82,85,47,57,153,88,252,131,119,195,70,117,178,60,156,210,209,155,255,220,239,113,233,39,159,38,253,209,168,80,207,239,231,139,163,241,235,249,168,206,79,165,15,47,133,225,162,252,241,254,105,44,247,187,237,253,111,71,243,236,115,111,237,166,203,241,188,28,202,253,110,107,191,219,155,175,22,101,208,102,240,229,233,5,163,215,27,172,31,249,234,235,121,236,176,50,91,77,167,103,43,79,169,167,243,7,207,151,231,117,210,38,92,119,102,123,231,33,91,107,145,103,47,120,237,95,111,231,175,83,219,254,143,216,11,154,209,123,94,188,196,241,191,216,254,217,202,215,112,225,185,226,172,147,147,65,53,17,152,146,176,236,53,114,78,145,72,42,229,102,130,209,173,233,181,244,43,110,188,224,89,225,203,134,221,36,115,206,228,151,107,111,15,160,57,179,107,112,213,73,119,114,178,117,17,74,200,171,80,3,59,161,100,85,194,170,90,68,76,182,10,47,115,78,201,249,192,45,93,9,165,38,131,241,141,140,8,105,80,16,188,20,196,62,137,228,185,56,159,146,177,73,221,5,148,222,238,44,255,248,107,198,139,83,255,108,55,154,46,249,221,24,171,95,45,60,155,242,1,207,250,237,227,216,92,176,236,178,8,94,91,24,170,181,72,18,65,48,165,121,135,170,145,137,226,9,4,62,167,241,246,113,32,167,200,70,45,74,241,30,206,113,65,80,240,78,200,80,27,113,98,217,124,30,68,158,205,122,160,235,201,218,71,144,146,94,203,138,108,97,203,36,44,226,43,82,131,95,173,11,186,149,138,26,163,32,117,29,116,95,49,85,224,117,201,163,138,68,26,255,62,89,44,251,209,4,113,27,205,219,104,193,203,213,180,159,204,222,143,16,152,41,3,222,243,217,120,237,142,13,166,127,57,76,43,159,217,120,167,68,108,172,135,44,75,144,175,128,81,148,166,90,31,77,173,230,86,152,246,104,14,205,101,88,224,6,133,26,125,46,59,228,46,210,214,41,36,110,147,138,174,196,116,110,68,169,132,38,138,241,232,175,86,226,68,70,193,34,21,188,151,141,154,178,241,126,97,218,155,228,155,245,44,138,77,77,216,150,17,45,39,65,24,180,141,62,181,38,109,54,119,129,233,39,243,89,79,165,223,160,122,131,106,228,155,229,161,235,199,106,80,102,116,200,107,60,10,207,153,3,107,231,61,217,43,81,109,67,177,181,216,128,204,213,80,80,37,11,66,231,22,77,167,152,179,150,5,172,247,126,161,154,88,178,117,133,6,84,131,67,53,134,148,73,85,24,202,65,135,200,202,171,112,23,168,222,169,27,64,255,122,128,6,81,198,67,104,206,58,32,89,156,177,34,90,92,202,20,50,78,41,87,56,149,122,171,54,45,217,197,96,137,69,32,137,156,109,140,118,18,179,19,26,96,46,70,219,100,202,213,109,26,104,110,146,140,18,161,213,0,64,163,227,147,148,22,188,83,153,172,2,44,52,63,148,122,95,196,103,169,217,58,111,133,2,127,128,169,5,72,107,185,10,210,53,81,73,129,72,175,251,231,163,209,126,55,122,176,223,61,250,153,203,70,200,177,176,207,86,232,132,218,97,37,14,147,153,6,146,149,91,200,168,178,210,210,245,101,227,53,45,63,162,108,28,14,21,225,210,193,111,95,79,94,174,14,242,134,250,255,128,235,60,122,135,113,109,205,140,129,31,91,60,242,39,121,18,6,164,157,60,53,42,173,92,85,83,110,108,216,77,107,74,106,168,26,3,186,42,5,51,12,182,64,18,26,238,18,158,125,141,173,152,44,243,53,215,249,44,171,111,184,178,170,128,140,182,132,114,66,202,97,60,102,51,102,81,197,87,121,223,168,127,86,206,72,93,18,224,93,176,81,77,240,72,195,161,112,55,147,112,55,213,198,234,46,72,194,227,82,230,171,217,134,250,255,122,76,65,187,26,138,162,44,84,101,9,166,48,192,96,184,67,75,13,190,233,40,232,234,249,150,76,193,84,237,67,16,184,190,3,213,18,163,238,4,141,34,89,203,153,50,53,163,245,213,76,65,98,90,204,56,145,114,25,19,1,111,80,177,114,246,2,173,203,132,64,217,150,148,127,22,166,16,130,74,1,135,211,10,7,182,57,98,182,175,49,224,119,168,69,9,78,245,54,249,235,225,118,62,241,126,186,98,132,152,55,116,251,187,131,168,106,133,146,218,172,40,18,180,207,74,165,17,71,12,174,27,41,138,42,168,74,214,126,215,214,216,2,90,163,105,81,4,23,128,234,166,13,210,56,55,76,186,99,86,30,54,233,108,174,4,209,144,238,228,76,20,94,97,252,99,147,12,195,92,183,9,169,146,79,202,163,31,212,250,147,128,136,8,244,84,98,62,197,104,112,216,205,224,15,3,131,10,38,49,23,244,201,101,131,57,255,205,65,180,215,211,162,223,192,232,91,120,184,23,48,122,119,242,15,193,2,185,229,213,29,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				UId = new Guid("2693767a-5074-42b5-b438-00eecc753ddf"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,107,219,64,16,253,43,70,135,158,180,65,218,47,237,170,71,227,22,31,154,132,54,45,133,196,132,213,238,200,94,208,135,35,173,154,4,227,255,222,145,149,184,16,104,113,33,61,20,114,219,175,121,243,222,104,222,104,119,235,251,15,190,10,208,229,165,169,122,136,135,165,203,35,227,128,10,202,10,162,132,210,132,83,205,73,97,147,146,104,169,56,75,173,44,25,184,40,110,76,13,121,52,69,47,156,15,81,92,181,107,111,77,117,177,133,206,4,223,54,121,116,209,69,177,15,80,247,249,245,238,87,170,208,13,16,223,150,135,205,23,187,129,218,124,29,211,166,105,230,24,45,53,81,52,19,132,11,198,137,226,105,74,48,163,76,83,97,65,91,76,123,96,152,225,145,19,150,18,43,74,74,120,105,21,41,4,50,204,10,166,50,158,105,142,48,200,7,202,176,120,216,118,208,247,35,155,29,28,215,87,143,91,228,62,229,158,183,213,80,55,81,92,67,48,151,38,108,80,63,36,192,133,53,196,114,141,68,74,200,136,97,218,17,102,138,140,102,10,82,153,102,81,108,205,118,18,185,68,86,206,4,243,205,84,3,28,144,119,30,57,82,150,164,74,72,140,77,153,37,156,209,132,40,169,50,82,58,89,106,96,82,235,226,88,197,143,131,199,181,239,207,135,26,58,111,159,62,6,96,85,219,46,223,217,182,9,93,91,141,208,231,135,231,87,240,16,166,146,63,93,125,159,4,5,60,31,131,162,125,60,244,48,175,60,52,97,209,216,214,249,102,61,97,238,247,24,82,111,77,231,251,231,42,44,238,6,83,69,113,231,215,155,63,86,107,62,244,161,173,255,35,169,49,202,68,12,108,178,3,221,177,7,157,239,183,149,121,60,236,243,232,221,221,208,134,247,243,14,12,66,205,26,184,159,249,198,122,135,72,103,159,193,182,157,155,45,221,244,38,122,129,149,71,55,145,54,78,105,150,1,145,70,160,75,140,180,164,144,69,66,24,181,216,173,89,201,133,176,103,80,72,109,178,146,17,108,87,57,90,137,98,119,115,73,152,178,84,3,79,164,160,250,38,66,17,175,74,237,122,217,95,220,55,207,230,154,202,177,58,195,211,23,7,139,10,106,132,204,119,167,104,217,99,192,229,115,42,108,143,19,148,237,87,163,182,21,54,221,171,186,95,178,68,201,4,239,52,36,28,159,74,192,249,100,52,73,25,99,194,9,38,148,122,115,255,155,251,79,114,255,39,156,24,165,71,143,249,198,216,224,127,192,209,104,179,123,31,54,51,236,211,10,111,13,14,194,117,3,112,138,251,44,148,64,121,66,137,163,28,8,151,146,18,77,165,34,9,179,146,22,28,148,113,201,153,113,227,207,52,177,132,49,91,16,94,36,64,116,54,78,80,73,93,34,76,150,136,162,248,253,96,248,7,172,255,122,102,156,34,243,197,204,56,69,244,113,102,172,246,63,1,120,166,224,206,158,8,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,43,205,77,74,45,178,50,180,50,4,0,178,212,123,197,17,0,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("5a727670-17a9-45e0-a739-0f65fc0bd080"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f952b674-3801-42b7-86b1-f25623dfeaeb"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,75,79,219,64,16,254,43,145,207,44,242,218,139,31,185,81,160,21,135,22,164,32,46,132,195,236,122,54,89,225,151,118,215,180,20,229,191,119,108,135,52,180,17,77,171,170,69,106,115,72,236,47,223,204,124,243,218,125,12,84,9,206,125,128,10,131,105,240,230,242,253,172,209,254,240,173,41,61,218,119,182,233,218,224,32,112,104,13,148,230,51,22,35,126,86,24,127,10,30,200,224,113,254,213,126,30,76,231,187,60,204,131,131,121,96,60,86,142,24,100,144,171,84,139,68,33,19,177,86,76,68,113,202,100,17,9,166,65,69,186,128,84,98,204,71,230,110,215,39,77,213,130,197,49,194,224,92,15,143,87,15,109,79,228,4,168,129,98,92,83,175,193,184,151,224,206,106,144,37,22,244,238,109,135,4,121,107,42,202,4,175,76,133,151,96,41,82,239,167,233,33,34,105,40,93,207,42,81,251,179,79,173,69,231,76,83,191,44,173,236,170,122,155,75,230,184,121,93,139,9,7,133,61,243,18,252,114,112,112,78,162,86,131,198,227,197,194,226,2,188,185,223,150,112,135,15,3,111,191,218,145,65,65,253,185,134,178,195,173,152,207,243,56,129,214,143,233,140,225,137,96,205,98,185,103,166,155,106,253,40,217,136,192,246,137,188,151,199,157,250,163,132,192,251,30,24,125,60,61,206,131,155,115,119,241,177,70,59,83,75,172,96,172,216,237,33,161,223,0,27,255,211,71,192,52,134,40,231,236,40,166,47,17,231,25,131,34,229,76,37,60,204,185,44,210,76,227,234,118,212,97,92,91,194,195,245,38,220,73,103,45,214,126,226,193,221,77,206,79,7,82,95,62,250,43,66,161,114,16,49,83,252,72,50,17,38,17,147,161,148,44,229,242,40,143,50,224,57,215,212,102,250,144,77,170,226,44,79,1,88,146,198,5,19,169,144,44,79,5,178,48,151,92,43,200,48,251,247,182,96,230,193,119,142,206,142,218,184,229,126,11,177,95,25,119,12,20,143,94,220,136,181,148,241,103,98,220,68,155,26,202,215,190,37,67,82,79,171,49,148,106,61,109,101,179,48,10,202,139,22,45,85,114,16,29,238,30,134,103,83,212,47,157,109,26,63,174,210,70,204,177,162,110,24,79,29,216,234,4,130,20,9,112,205,18,161,67,234,68,76,211,47,101,204,138,48,146,69,130,34,211,170,63,228,232,62,233,85,207,154,206,170,245,244,186,241,34,249,165,43,226,47,12,253,207,156,231,59,103,101,159,238,255,63,255,178,87,222,226,217,247,135,213,111,235,246,31,223,227,85,176,250,2,244,5,54,43,10,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f54f4c78-60f1-449a-9601-358fc131b3a2"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,111,211,64,16,253,43,145,207,221,202,222,117,108,111,110,165,45,168,7,104,165,84,189,52,61,204,218,227,100,85,127,105,119,93,8,81,254,59,99,59,9,41,68,37,32,4,149,32,135,196,126,121,51,243,230,107,119,229,165,5,88,251,1,74,244,38,222,155,155,247,211,58,119,167,111,117,225,208,188,51,117,219,120,39,158,69,163,161,208,159,49,27,240,203,76,187,11,112,64,6,171,217,87,251,153,55,153,29,242,48,243,78,102,158,118,88,90,98,144,1,40,158,134,129,140,152,226,10,89,40,2,159,41,41,98,150,196,232,7,89,24,10,149,37,3,243,176,235,243,186,108,192,224,16,161,119,158,247,143,183,203,166,35,6,4,164,61,69,219,186,218,128,162,147,96,47,43,80,5,102,244,238,76,139,4,57,163,75,202,4,111,117,137,55,96,40,82,231,167,238,32,34,229,80,216,142,85,96,238,46,63,53,6,173,213,117,245,178,180,162,45,171,125,46,153,227,238,117,35,198,239,21,118,204,27,112,139,222,193,21,137,90,247,26,207,230,115,131,115,112,250,105,95,194,35,46,123,222,113,181,35,131,140,250,115,7,69,139,123,49,159,231,113,14,141,27,210,25,194,19,193,232,249,226,200,76,119,213,250,81,178,156,192,102,75,62,202,227,65,253,60,34,240,169,3,6,31,219,199,153,119,127,101,175,63,86,104,166,233,2,75,24,42,246,112,74,232,55,192,206,255,100,5,24,11,224,50,96,99,65,95,161,144,9,131,44,14,88,26,5,190,12,84,22,39,57,174,31,6,29,218,54,5,44,239,118,225,206,91,99,176,114,35,7,246,113,116,117,209,147,186,242,209,95,145,72,4,42,161,24,23,24,177,208,247,3,166,148,2,150,137,92,37,41,134,60,204,124,106,51,125,200,102,156,167,105,162,80,49,25,73,78,228,48,97,9,74,193,198,17,196,81,28,137,88,74,255,95,219,130,169,3,215,90,58,59,42,109,23,199,45,196,113,101,60,48,80,1,127,113,35,54,82,134,159,145,182,163,92,87,80,188,246,45,233,147,218,174,70,95,170,205,180,21,245,92,167,80,92,55,104,168,146,189,104,255,240,48,60,155,162,110,233,76,93,187,97,149,118,98,206,82,234,134,118,212,129,189,78,200,120,44,85,192,5,163,57,151,44,84,62,103,146,115,197,114,200,50,17,196,9,250,121,68,61,165,251,164,83,61,173,91,147,110,166,215,14,23,201,47,93,17,127,97,232,127,230,60,63,56,43,199,116,255,255,249,183,59,255,94,105,139,167,223,31,86,191,173,219,127,124,143,215,222,250,11,0,151,124,192,10,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0f14b785-7ed6-46c2-a054-1b40b0cdf754"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,75,111,218,64,16,254,43,200,231,108,228,197,111,110,41,161,21,135,54,72,68,185,196,57,140,237,89,88,197,47,237,174,211,82,196,127,239,216,6,151,180,40,165,85,213,70,106,57,128,253,241,237,204,55,207,221,90,105,14,90,127,128,2,173,137,245,102,241,126,89,9,115,249,86,230,6,213,59,85,53,181,117,97,105,84,18,114,249,25,179,30,159,101,210,92,131,1,58,176,141,191,158,143,173,73,124,202,66,108,93,196,150,52,88,104,98,208,1,142,16,56,73,32,88,24,37,9,115,129,251,44,113,133,195,184,45,28,63,224,194,227,98,220,51,79,155,158,86,69,13,10,123,15,157,113,209,61,222,110,234,150,200,9,72,59,138,212,85,185,7,157,86,130,158,149,144,228,152,209,187,81,13,18,100,148,44,40,18,188,149,5,46,64,145,167,214,78,213,66,68,18,144,235,150,149,163,48,179,79,181,66,173,101,85,190,44,45,111,138,242,152,75,199,113,120,221,139,177,59,133,45,115,1,102,221,25,152,147,168,93,167,241,106,181,82,184,2,35,159,142,37,60,226,166,227,157,151,59,58,144,81,125,238,32,111,240,200,231,243,56,166,80,155,62,156,222,61,17,148,92,173,207,140,116,200,214,143,130,29,19,88,31,200,103,89,60,169,127,236,19,248,212,2,189,141,195,99,108,221,207,245,205,199,18,213,50,93,99,1,125,198,30,46,9,253,6,24,236,79,182,128,129,3,227,136,51,207,161,47,215,137,66,6,89,192,89,234,115,59,226,73,22,132,2,119,15,189,14,169,235,28,54,119,131,187,105,163,20,150,102,100,64,63,142,230,215,29,169,77,31,253,133,129,239,35,102,30,243,108,151,138,19,186,46,11,221,132,188,184,34,226,30,122,33,64,74,101,166,79,107,56,18,194,15,69,198,144,220,49,55,227,17,75,50,135,179,192,177,185,19,250,62,240,208,253,215,166,96,105,192,52,154,118,71,41,245,250,188,129,56,47,141,39,26,138,143,95,156,136,189,148,254,103,36,245,72,200,18,242,215,62,37,93,80,135,209,232,82,181,239,182,188,90,201,20,242,155,26,21,101,178,19,109,159,110,134,103,93,212,14,157,170,42,211,143,210,32,230,42,165,106,72,67,21,56,170,132,13,17,248,105,40,152,205,125,96,174,237,32,75,80,36,44,64,240,60,31,4,134,97,187,228,232,62,105,85,47,171,70,165,251,238,213,253,69,242,75,87,196,95,104,250,159,217,231,39,123,229,156,234,255,223,127,195,254,123,165,37,94,126,191,172,126,91,181,255,248,28,239,172,221,23,139,77,36,63,10,10,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("0bd93df7-dde6-4316-869d-ab5b8ddb37be"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,201,110,219,48,16,253,21,131,135,158,196,64,20,41,46,234,45,134,91,228,146,6,72,90,20,72,140,96,184,197,68,180,56,18,133,38,48,252,239,165,173,184,45,140,160,232,122,200,69,162,70,156,153,55,15,239,205,230,54,12,239,66,29,93,95,121,168,7,151,141,103,182,66,146,11,197,140,163,24,132,215,152,177,60,199,96,164,197,196,216,66,80,193,104,238,74,148,181,208,184,10,77,217,11,27,34,202,66,116,205,80,93,111,190,23,141,253,232,178,91,191,255,184,52,43,215,192,199,93,3,195,152,178,146,22,24,152,49,152,233,156,96,173,108,137,37,144,194,176,2,148,151,10,77,88,132,0,65,189,228,88,42,173,48,203,203,18,131,77,168,140,182,74,20,58,231,68,8,148,213,206,199,197,227,186,119,195,16,186,182,218,184,111,231,171,167,117,66,57,245,158,119,245,216,180,40,107,92,132,11,136,171,10,129,203,29,43,13,96,195,84,137,153,119,2,3,85,22,83,208,162,16,210,145,84,30,101,6,214,113,87,22,157,89,148,89,136,240,9,234,209,237,43,111,66,194,88,208,156,200,146,167,92,66,211,56,180,200,177,228,82,96,111,185,87,142,114,165,180,61,240,245,126,12,233,28,134,243,177,113,125,48,207,180,187,196,95,215,87,27,211,181,177,239,234,93,233,243,253,245,43,247,24,39,114,159,127,125,158,6,138,41,190,75,66,219,108,28,220,188,14,174,141,139,214,116,54,180,119,83,205,237,54,165,52,107,232,195,112,96,97,241,48,66,141,178,62,220,173,126,202,214,124,28,98,215,188,162,81,179,52,102,170,145,68,182,135,187,211,160,13,195,186,134,167,253,119,133,222,60,140,93,124,59,31,251,62,37,207,34,12,247,179,96,167,32,58,74,174,208,77,146,133,160,80,40,130,75,154,30,140,42,153,68,39,8,54,156,228,138,104,43,164,119,55,40,1,250,187,54,215,103,195,135,47,237,193,25,211,44,203,147,20,61,10,92,28,50,171,205,175,32,219,46,119,216,150,73,0,255,212,137,134,11,6,105,47,96,174,4,195,12,52,197,218,23,26,243,146,1,241,37,101,68,186,63,119,98,218,47,146,121,101,176,102,50,237,28,161,52,86,96,120,218,62,164,240,148,81,110,160,56,209,60,245,80,146,166,61,144,167,75,206,185,164,62,86,98,207,161,164,222,210,162,116,230,7,187,94,70,136,227,112,50,189,102,97,152,249,208,238,12,240,130,174,85,174,121,169,189,196,185,247,137,7,194,8,150,66,40,92,176,34,79,7,240,42,23,7,93,159,118,93,237,160,253,13,105,207,87,206,220,159,118,143,199,210,78,92,152,123,157,226,255,195,197,23,7,213,188,174,129,95,240,242,177,115,246,23,247,10,95,110,191,2,87,222,244,191,194,6,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,219,48,16,252,21,131,201,209,52,248,18,69,250,214,54,61,4,72,10,163,105,115,137,115,88,146,203,70,168,108,185,122,4,72,3,255,123,105,218,110,108,244,1,163,64,15,5,202,131,4,138,156,153,229,14,71,207,228,188,127,90,33,153,146,215,179,235,155,38,246,147,55,77,139,147,89,219,120,236,186,201,85,227,161,174,190,130,171,113,6,45,44,176,199,246,22,234,1,187,171,170,235,199,163,67,16,25,147,243,199,188,70,166,119,207,228,178,199,197,199,203,144,152,189,145,194,3,243,180,116,58,82,37,173,167,134,235,34,77,37,55,78,249,32,181,77,96,223,212,195,98,121,141,61,204,160,127,32,211,103,146,217,50,65,48,42,38,152,83,198,81,85,90,71,45,120,77,149,226,34,74,37,181,7,65,214,99,210,249,7,92,64,22,61,0,43,101,67,170,128,130,242,158,42,199,56,117,54,20,212,0,23,94,9,176,209,216,13,120,183,255,5,120,119,118,213,52,159,135,213,196,176,2,192,163,162,70,51,69,21,195,146,130,69,71,89,44,20,47,85,97,165,103,19,229,130,115,198,68,90,24,212,52,68,206,169,45,121,218,196,120,208,12,173,52,94,159,221,111,132,66,213,173,106,120,186,253,165,222,43,223,87,143,85,255,52,234,122,232,135,46,53,119,177,170,83,231,195,22,191,58,50,226,144,225,121,190,117,115,78,166,243,159,251,185,123,223,228,70,29,59,122,108,230,156,140,231,228,166,25,90,191,97,147,155,201,190,185,153,157,237,70,58,223,15,143,253,216,114,100,216,53,44,225,19,182,239,146,94,134,231,165,11,232,33,75,127,72,53,239,137,157,176,5,43,121,164,37,130,165,10,181,160,38,112,160,150,91,23,101,41,69,140,34,163,223,99,196,22,151,30,143,11,59,197,172,140,207,202,47,197,236,239,93,250,178,28,234,58,11,116,249,252,155,139,188,43,124,183,114,113,224,224,1,67,19,170,88,97,184,92,254,97,171,54,37,124,239,201,78,109,77,214,235,241,97,152,148,98,133,141,78,108,47,177,210,54,181,70,8,79,89,81,152,128,49,74,203,194,111,195,4,40,75,225,35,80,16,169,203,170,140,44,69,65,43,202,203,192,101,137,14,173,214,127,49,76,82,88,23,152,70,26,109,145,228,141,80,20,88,116,212,20,24,146,181,81,88,101,38,41,207,69,58,8,163,186,148,233,18,64,90,183,90,104,202,16,56,20,101,170,192,170,19,195,148,92,28,234,126,212,196,17,236,98,53,121,219,165,159,26,244,85,179,28,181,248,101,168,218,255,201,138,39,36,235,20,231,254,177,100,221,175,191,1,98,16,40,180,0,7,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("1a7079ad-1f11-43e4-a861-de906c2749c4"),
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,193,110,227,54,16,253,21,67,231,101,64,73,164,68,249,182,77,221,34,135,238,6,205,98,47,235,28,70,228,208,17,42,75,130,68,167,77,13,255,123,135,146,237,216,93,199,85,130,93,52,192,230,100,105,60,243,52,51,124,243,56,235,64,151,208,117,31,96,137,193,52,248,233,250,183,155,218,186,139,95,138,210,97,251,107,91,175,154,224,93,208,97,91,64,89,252,141,102,176,207,76,225,126,6,7,20,176,158,63,198,207,131,233,252,20,194,60,120,55,15,10,135,203,142,60,40,64,40,107,19,140,4,75,69,28,49,33,185,102,96,64,179,20,173,140,184,141,64,129,29,60,79,67,95,85,3,120,143,107,251,199,79,15,141,247,17,100,208,245,178,129,182,232,234,106,107,140,253,215,187,89,5,121,137,134,222,93,187,66,50,185,182,88,82,17,248,169,88,226,53,180,244,17,143,83,123,19,57,89,40,59,239,85,162,117,179,191,154,22,187,174,168,171,115,89,93,214,229,106,89,29,250,82,56,238,95,183,201,240,62,67,239,121,13,238,174,7,184,132,142,254,217,244,89,190,95,44,90,92,128,43,238,15,147,248,3,31,122,207,113,141,163,0,67,135,243,25,202,21,110,191,26,242,175,74,185,132,198,13,21,237,50,32,151,22,45,182,88,105,188,209,119,184,132,125,141,143,14,197,226,238,0,196,31,232,151,39,59,178,239,234,127,53,37,34,99,179,115,62,215,227,61,226,201,42,163,132,140,247,222,48,96,236,30,231,193,151,171,238,227,159,21,182,67,89,67,95,111,47,200,250,47,195,172,196,37,86,110,186,86,86,166,2,101,206,210,132,218,45,210,40,98,25,135,140,197,218,38,210,196,60,7,80,27,10,216,39,52,93,167,32,67,16,42,98,90,39,9,19,161,76,25,164,137,100,60,53,22,48,67,110,147,220,135,204,42,87,184,135,129,45,211,53,32,71,33,53,48,45,50,201,132,69,138,138,51,195,98,200,211,40,85,24,38,97,186,185,29,202,45,186,166,132,135,207,251,170,126,71,48,19,77,71,51,241,157,160,137,107,59,55,241,115,54,169,237,132,58,188,42,93,81,45,38,68,183,18,181,63,236,139,43,211,35,249,31,138,183,81,36,83,21,231,12,184,36,58,197,73,204,242,16,19,150,65,142,33,202,212,64,70,116,218,108,54,183,158,156,105,158,168,92,24,205,18,142,33,235,155,163,48,11,25,96,164,56,181,3,52,196,231,206,238,140,32,96,194,99,205,61,180,66,203,4,247,188,150,82,51,19,83,6,105,38,98,25,234,31,72,16,110,28,184,85,55,78,18,198,181,238,249,146,176,203,225,140,40,188,39,78,221,19,149,15,93,95,179,60,244,21,31,200,195,118,10,226,76,24,145,43,193,164,34,238,27,27,134,44,75,195,156,113,30,26,162,122,22,43,157,244,120,251,207,93,85,147,166,173,233,84,186,161,234,71,157,25,141,245,213,44,31,97,238,70,46,201,77,148,101,38,103,210,112,100,194,164,154,169,140,20,34,66,41,81,115,109,81,18,220,219,92,156,152,139,113,173,123,155,139,51,115,161,158,59,23,31,106,55,233,28,180,206,171,234,241,92,168,151,206,197,17,102,63,23,126,48,202,122,81,104,40,63,54,216,194,86,178,194,211,162,126,116,27,248,253,160,173,107,247,132,144,245,25,236,8,52,238,186,123,42,27,254,141,179,225,180,15,168,88,132,76,71,202,48,33,98,205,50,226,55,51,194,90,162,116,36,104,231,160,108,104,87,247,170,119,83,175,90,141,195,157,216,13,75,250,139,214,239,255,225,42,125,222,194,252,196,125,51,230,6,121,91,30,95,231,242,248,162,181,240,149,18,245,112,145,251,134,84,61,18,236,177,75,199,179,87,138,31,187,167,106,108,79,191,231,117,244,93,111,151,77,176,249,7,176,192,144,122,252,17,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"False",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreDisplayValuesParameter);
			var resultCompositeObjectListParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("304b5d50-f28b-4aa7-96f5-bee147ac1599"),
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
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(resultCompositeObjectListParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4bc2db2c-fcdc-4b63-a62f-cb65b0932d14"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,223,115,219,54,12,254,87,116,122,46,115,212,47,82,244,91,151,185,187,60,108,205,45,185,190,212,121,128,72,208,209,85,150,124,18,157,205,243,249,127,31,40,217,142,187,56,158,154,219,181,217,181,47,150,4,3,32,240,225,3,129,77,168,43,232,186,223,96,129,225,36,252,233,250,215,155,198,186,139,119,101,229,176,253,165,109,86,203,240,77,216,97,91,66,85,254,133,102,144,79,77,233,126,6,7,100,176,153,61,218,207,194,201,236,148,135,89,248,102,22,150,14,23,29,105,144,129,144,156,39,152,71,76,40,142,44,229,73,206,148,1,205,180,76,243,140,11,72,51,109,7,205,211,174,175,234,193,121,239,215,246,175,183,235,165,215,73,73,160,155,197,18,218,178,107,234,157,48,241,167,119,211,26,138,10,13,125,187,118,133,36,114,109,185,160,36,240,182,92,224,53,180,116,136,247,211,120,17,41,89,168,58,175,85,161,117,211,63,151,45,118,93,217,212,231,162,186,108,170,213,162,62,214,37,115,60,124,238,130,225,125,132,94,243,26,220,125,239,224,18,58,250,103,219,71,249,118,62,111,113,14,174,124,56,14,226,19,174,123,205,113,192,145,129,161,226,124,128,106,133,187,83,35,254,36,149,75,88,186,33,163,125,4,164,210,162,197,22,107,141,55,250,30,23,112,200,241,81,161,156,223,31,57,241,5,253,248,44,34,7,84,255,13,148,152,132,203,189,242,57,140,15,30,79,102,25,11,18,62,120,193,224,99,255,58,11,63,94,117,239,255,168,177,29,210,26,112,189,187,32,233,63,4,211,10,23,88,187,201,38,183,153,76,49,43,152,20,113,202,82,25,199,76,113,80,44,209,86,100,38,225,5,64,190,37,131,67,64,147,141,132,44,130,52,143,153,214,66,176,52,202,36,3,41,50,198,165,177,128,10,185,21,133,55,153,214,174,116,235,129,45,147,13,32,71,42,27,48,157,170,140,165,22,201,42,81,134,37,80,200,88,230,24,137,72,110,239,134,116,203,110,89,193,250,195,33,171,223,17,76,160,169,52,129,71,130,58,174,237,92,224,251,44,104,108,64,8,175,42,87,214,243,128,232,86,161,246,197,190,184,50,189,39,255,32,251,34,181,57,87,90,176,216,170,130,165,169,140,152,210,210,178,36,198,196,232,40,2,72,52,17,115,187,189,243,228,52,156,190,173,68,22,25,175,237,223,148,177,146,161,200,141,225,86,153,92,137,239,168,107,223,18,162,15,190,144,116,242,188,105,215,227,58,120,28,136,47,233,224,125,20,103,186,248,105,200,175,189,163,251,172,143,58,122,71,92,155,69,58,21,105,194,178,28,5,51,54,34,226,202,168,96,156,71,70,112,84,73,174,7,20,15,199,221,54,129,105,122,209,227,165,48,218,203,147,198,219,121,219,119,134,229,34,143,11,44,152,229,138,58,95,197,134,129,202,232,39,22,177,80,137,230,16,103,231,57,232,185,143,207,181,71,244,127,108,143,27,7,110,213,209,157,84,151,221,253,184,222,24,7,227,41,150,196,103,123,99,23,202,240,8,202,46,176,101,13,213,41,242,143,34,234,215,162,126,124,68,214,30,42,162,155,135,177,106,230,165,134,234,253,18,91,66,178,15,154,159,38,195,103,44,242,179,177,109,26,247,204,157,208,199,176,175,4,231,57,38,50,201,24,141,44,195,210,4,104,207,192,60,99,50,202,147,168,176,177,146,0,84,83,218,12,125,212,55,205,170,213,59,246,118,195,74,248,162,101,239,27,204,132,47,91,207,158,185,42,199,48,224,199,170,242,58,87,149,87,202,185,211,203,197,127,200,191,207,6,235,216,81,248,197,227,238,27,140,49,124,217,108,58,57,8,158,248,26,3,236,215,190,182,183,225,246,111,66,222,9,236,195,15,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("11c4d1d4-2b34-4ebf-aabf-c8a0c4e0bae5"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,77,115,227,54,12,253,43,30,157,151,25,82,34,245,225,219,54,117,59,57,180,155,105,50,123,89,231,0,146,160,163,169,44,121,36,58,173,155,241,127,47,40,217,142,183,113,92,109,166,179,155,78,123,146,4,1,32,240,240,0,240,49,50,21,116,221,207,176,196,104,26,125,119,253,211,77,227,252,197,15,101,229,177,253,177,109,214,171,232,93,212,97,91,66,85,254,129,118,144,207,108,233,191,7,15,100,240,56,127,178,159,71,211,249,41,15,243,232,221,60,42,61,46,59,210,32,3,39,180,179,42,143,89,172,165,99,50,41,10,166,77,145,48,29,103,185,205,141,73,156,18,131,230,105,215,87,245,224,188,247,235,250,215,219,205,42,232,72,18,152,102,185,130,182,236,154,122,39,76,194,233,221,172,6,93,161,165,111,223,174,145,68,190,45,151,148,4,222,150,75,188,134,150,14,9,126,154,32,34,37,7,85,23,180,42,116,126,246,251,170,197,174,43,155,250,92,84,151,77,181,94,214,199,186,100,142,135,207,93,48,188,143,48,104,94,131,191,239,29,92,66,71,127,182,125,148,239,23,139,22,23,224,203,135,227,32,126,197,77,175,57,14,56,50,176,84,156,143,80,173,113,119,170,224,207,82,185,132,149,31,50,218,71,64,42,45,58,108,177,54,120,99,238,113,9,135,28,159,20,202,197,253,145,147,80,208,79,47,34,114,64,245,239,64,137,73,184,218,43,159,195,248,224,241,100,150,113,74,194,135,32,24,124,236,95,231,209,167,171,238,195,111,53,182,67,90,3,174,119,23,36,253,139,96,86,225,18,107,63,125,204,157,202,36,42,205,178,52,150,76,102,113,204,10,14,5,75,140,75,149,77,184,6,200,183,100,112,8,104,250,152,129,18,32,169,56,198,164,41,147,66,101,12,178,84,49,158,89,7,88,32,119,169,14,38,179,218,151,126,51,176,101,250,8,200,81,42,3,204,200,66,49,233,144,172,146,194,178,4,116,70,85,69,145,138,108,123,55,164,91,118,171,10,54,31,15,89,253,130,96,39,134,74,51,9,72,80,199,181,157,159,132,62,155,52,110,66,8,175,43,95,214,139,9,209,173,66,19,138,125,113,101,123,79,225,65,246,104,149,6,161,98,230,114,136,41,73,138,29,178,68,177,36,230,57,133,159,199,113,161,137,152,219,237,93,32,167,204,56,40,105,4,43,116,22,200,231,18,6,26,115,150,105,151,231,40,185,224,125,119,253,87,186,246,61,33,250,16,10,73,39,47,154,118,51,174,131,199,129,248,154,14,222,71,113,166,139,159,135,252,214,59,186,207,250,168,163,119,196,165,49,103,100,42,19,166,114,76,153,117,130,240,204,132,102,156,11,155,114,44,146,220,164,189,191,195,113,183,205,196,54,189,232,105,40,140,246,242,172,241,118,222,14,157,161,164,42,172,81,76,56,129,76,26,155,179,194,9,154,1,152,233,36,201,51,180,130,159,231,96,224,62,190,212,30,226,223,216,30,55,30,252,186,163,153,84,151,221,253,200,222,24,5,227,41,150,196,103,123,99,23,202,240,152,148,221,196,149,53,84,167,200,63,138,168,95,139,250,241,17,89,123,168,136,110,1,198,170,89,148,6,170,15,43,108,9,201,62,104,126,154,12,159,177,40,236,198,182,105,252,11,51,161,143,97,95,137,92,72,30,199,32,24,0,210,148,18,142,51,157,165,64,43,208,105,161,173,85,130,231,84,83,186,25,134,168,111,154,117,107,118,236,237,134,43,225,171,46,123,223,96,39,124,217,245,236,133,81,57,134,1,255,95,85,222,230,85,229,141,114,238,244,229,226,31,228,223,103,139,117,236,42,252,226,117,247,13,214,24,190,110,55,157,92,4,207,124,141,1,246,107,143,237,109,180,253,19,55,42,175,160,195,15,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
			};
			parametrizedElement.Parameters.Add(recordColumnValuesParameter);
			var considerTimeInFilterParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4bdd4293-8899-4f41-91f1-e5613516fb81"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,152,221,79,27,71,16,192,255,21,235,200,91,89,107,191,63,252,150,146,84,66,130,20,133,52,47,192,195,236,206,44,177,106,238,144,125,166,162,200,255,123,231,12,36,144,182,46,105,75,85,4,126,176,117,235,157,217,217,153,249,205,236,222,85,243,170,191,60,167,102,210,124,127,176,127,216,213,126,188,211,205,105,124,48,239,10,45,22,227,189,174,192,108,250,43,228,25,29,192,28,206,168,167,249,71,152,45,105,177,55,93,244,219,163,187,66,205,118,243,234,98,253,95,51,57,186,106,118,123,58,251,105,23,89,179,141,64,42,23,47,170,35,16,214,133,40,18,162,21,50,168,154,92,44,209,40,203,194,165,155,45,207,218,125,234,225,0,250,79,205,228,170,89,107,99,5,37,42,91,33,40,65,82,101,97,141,118,2,74,68,17,209,130,78,134,80,153,216,172,182,155,69,249,68,103,176,94,244,142,176,181,9,163,209,2,108,41,194,102,169,68,78,232,68,4,165,139,213,144,106,76,131,240,205,252,47,130,71,91,123,93,247,243,242,124,156,188,34,45,163,23,44,193,203,163,14,34,203,228,132,149,89,145,183,232,75,145,227,234,84,177,222,26,225,34,121,129,85,41,145,2,91,43,165,66,47,41,153,88,252,214,201,176,16,78,23,231,51,184,252,248,167,235,189,46,253,244,98,218,95,142,10,244,116,218,205,47,199,31,186,17,118,215,210,231,247,194,112,87,254,234,248,58,150,199,205,228,248,143,163,121,243,123,184,118,211,253,120,222,15,229,113,179,125,220,28,118,203,121,25,180,25,126,120,115,199,232,245,2,235,41,95,61,222,198,142,71,218,229,108,118,51,242,6,122,184,157,120,59,220,225,180,78,9,119,219,195,219,144,173,181,200,155,15,123,237,119,95,183,159,107,219,254,137,216,62,180,112,74,243,119,188,253,47,182,127,182,242,3,187,240,86,113,214,201,13,89,42,2,65,18,150,188,230,156,83,32,146,74,185,154,96,116,173,122,45,253,158,42,205,169,45,116,223,176,135,100,206,141,252,98,237,237,1,154,27,187,6,87,173,154,213,106,251,46,74,213,107,7,186,104,161,80,34,171,113,78,228,200,56,68,175,201,162,115,174,16,109,68,201,98,169,18,140,18,161,98,96,139,50,8,144,210,10,178,202,100,21,156,177,70,253,251,40,13,249,3,167,109,183,160,17,180,56,154,243,110,103,23,52,154,182,101,138,212,246,163,173,227,230,187,163,173,163,221,197,143,191,180,52,191,246,225,164,194,108,65,39,99,30,253,106,224,237,140,206,88,106,114,21,171,11,150,92,22,193,107,43,108,208,90,36,201,129,50,165,122,135,70,102,128,184,98,129,207,169,62,185,10,224,20,216,168,69,41,222,11,171,92,16,16,188,227,90,132,21,40,145,172,62,15,34,111,219,158,9,220,89,251,145,165,114,44,228,179,21,58,21,174,96,178,112,28,9,120,247,46,215,144,67,177,210,194,234,100,51,222,15,243,193,123,2,100,238,121,18,114,66,142,127,152,206,23,253,104,202,241,31,117,117,144,89,206,250,105,123,58,226,0,207,136,203,68,215,142,223,45,207,50,205,95,138,195,127,94,28,92,1,227,170,146,12,55,131,96,139,231,84,74,30,132,137,6,193,67,133,82,203,166,226,240,96,195,30,90,28,82,204,193,91,143,2,93,229,106,67,149,235,78,176,82,196,0,50,80,65,69,33,110,46,14,156,201,88,108,16,209,105,46,119,40,73,128,175,32,170,102,213,89,75,86,97,30,163,207,254,127,193,7,146,100,57,208,162,216,161,108,87,98,41,147,80,24,200,65,135,72,202,171,240,87,224,255,29,168,119,241,5,232,39,215,237,149,10,200,147,146,136,58,112,178,112,47,21,209,242,57,80,113,198,41,197,173,57,21,252,38,160,169,2,70,224,228,14,20,42,243,8,86,100,224,60,148,178,100,62,251,38,7,81,109,4,186,202,96,24,96,35,66,66,46,81,193,115,177,34,159,68,242,84,156,79,201,216,164,158,23,208,65,122,45,145,179,133,236,112,23,225,248,138,84,145,183,231,130,174,5,217,171,42,63,6,208,107,119,188,48,253,244,152,246,153,140,119,74,196,74,122,200,50,166,27,145,49,138,210,160,245,220,234,209,124,19,211,144,37,247,88,109,132,30,192,182,134,79,13,145,47,138,220,81,98,142,209,69,23,178,222,200,116,174,0,169,112,61,40,198,71,97,173,228,29,153,245,41,36,120,47,43,84,101,227,243,98,218,155,228,171,245,52,52,105,46,147,53,115,180,28,95,143,162,182,209,167,90,165,205,230,49,152,222,233,218,30,74,255,66,245,11,213,166,86,166,218,23,110,38,124,254,182,18,171,200,54,70,161,180,113,124,211,55,94,201,205,84,215,44,209,87,238,70,42,240,189,210,2,95,201,65,241,237,30,108,230,151,74,197,163,124,110,84,103,229,140,212,37,241,37,187,240,66,152,216,35,149,55,197,101,87,166,154,0,43,169,199,160,250,117,41,221,178,125,161,250,233,81,173,29,134,162,32,243,203,49,146,124,162,27,48,24,218,163,212,124,139,115,16,52,250,235,55,155,27,122,245,201,234,55,148,76,19,175,18,23,0,0 })),
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				UId = new Guid("a09251e9-751e-4ef4-9254-83ed2ca16d14"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				Value = @"",
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				UId = new Guid("bfd5bd69-9200-4555-9378-12ca5d68f3a8"),
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
				UId = new Guid("b7ea78b6-5287-47d3-8f10-bc466f99f8fa"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57")
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
				UId = new Guid("ab4fc8eb-93b6-442a-bc87-91e9f406adfe"),
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
				UId = new Guid("6071a8e6-e279-405b-b5d3-38b429fbbe9c"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b4dbfeb1-c536-4a67-b205-344a03d90f82"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("8f574e5b-7624-4722-90a9-3cf65d30baa8"),
				SourceSequenceFlowPointLocalPosition = new Point(1, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("a5470c4b-b56a-4a48-87ba-c46af633f521"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Default,
				ManagerItemUId = new Guid("573ed909-e069-4161-b193-ae8dd9437c68"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Conditional,
				ManagerItemUId = new Guid("dac675d4-ea84-4e44-9056-38bf918618e9"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				CurveCenterPosition = new Point(0, 0),
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				Name = @"ReadCaseData",
				Position = new Point(255, 190),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("bd9f7570-6c97-4f16-90e5-663a190c6c7c"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Gateway",
				ImageList = null,
				ImageName = null,
				Instantiate = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0ddbda75-9cac-4e42-b94c-5cf1edb45846"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("cb455b6f-78ff-4b1e-b241-c2bbc0b37e9f"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d3021ca7-7450-4678-a117-060171eb2976"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsLogging = true,
				ManagerItemUId = new Guid("1bd93619-0574-454e-bb4e-cf53b9eb9470"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Event",
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				EntitySignal = EntityChangeType.Updated,
				HasEntityColumnChange = true,
				HasEntityFilters = true,
				ImageList = null,
				ImageName = null,
				IsLogging = true,
				ManagerItemUId = new Guid("5ccad23d-fc4b-4ec7-8051-e3a825b698fc"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("db6abed1-0c5f-455b-8053-2665378cdb71"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("b0d3ad9f-7a27-46a3-9483-ed70c26872ae"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("d334d28f-b11a-477e-9ff0-0a95fa73d53b"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("fe10dd95-2d61-4aa1-8111-9fb23b032603"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
				CreatedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"),
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
			return new IncidentDiagnosticsAndResolving(userConnection);
		}

		public override object Clone() {
			return new IncidentDiagnosticsAndResolvingSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57"));
		}

		#endregion

	}

	#endregion

	#region Class: IncidentDiagnosticsAndResolving

	/// <exclude/>
	public class IncidentDiagnosticsAndResolving : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane1

		/// <exclude/>
		public class ProcessLane1 : ProcessLane
		{

			public ProcessLane1(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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

			public AddDiagnoseTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,89,91,111,83,73,12,254,43,209,129,55,58,209,220,47,125,99,129,149,42,1,91,81,150,23,202,131,103,198,3,17,105,82,37,39,172,186,85,255,251,126,39,109,161,101,217,94,180,42,23,53,121,72,148,201,177,199,99,251,179,191,113,142,187,135,253,209,33,119,219,221,111,187,47,246,230,173,31,63,153,47,120,188,187,152,23,94,46,199,207,231,133,166,147,191,41,79,121,151,22,116,192,61,47,222,208,116,197,203,231,147,101,191,53,186,40,212,109,117,15,63,173,127,235,182,223,30,119,59,61,31,252,185,83,161,217,26,230,152,173,23,228,98,20,182,104,18,185,57,43,114,200,84,141,84,165,185,8,225,50,159,174,14,102,47,184,167,93,234,63,116,219,199,221,90,27,20,148,168,108,163,160,4,75,149,133,53,218,9,42,177,138,88,45,233,100,184,42,19,187,147,173,110,89,62,240,1,173,55,189,32,108,109,170,209,104,65,182,20,97,179,84,34,167,234,68,36,165,139,213,148,90,76,131,240,217,243,95,4,223,62,120,62,159,127,92,29,142,147,87,172,101,132,253,74,99,251,170,131,200,50,57,97,101,86,236,109,245,165,200,113,115,170,88,111,141,112,145,189,168,77,41,145,2,172,149,82,85,47,57,153,88,252,131,119,195,70,117,178,60,156,210,209,155,255,220,239,113,233,39,159,38,253,209,168,80,207,239,231,139,163,241,235,249,168,206,79,165,15,47,133,225,162,252,241,254,105,44,247,187,237,253,111,71,243,236,115,111,237,166,203,241,188,28,202,253,110,107,191,219,155,175,22,101,208,102,240,229,233,5,163,215,27,172,31,249,234,235,121,236,176,50,91,77,167,103,43,79,169,167,243,7,207,151,231,117,210,38,92,119,102,123,231,33,91,107,145,103,47,120,237,95,111,231,175,83,219,254,143,216,11,154,209,123,94,188,196,241,191,216,254,217,202,215,112,225,185,226,172,147,147,65,53,17,152,146,176,236,53,114,78,145,72,42,229,102,130,209,173,233,181,244,43,110,188,224,89,225,203,134,221,36,115,206,228,151,107,111,15,160,57,179,107,112,213,73,119,114,178,117,17,74,200,171,80,3,59,161,100,85,194,170,90,68,76,182,10,47,115,78,201,249,192,45,93,9,165,38,131,241,141,140,8,105,80,16,188,20,196,62,137,228,185,56,159,146,177,73,221,5,148,222,238,44,255,248,107,198,139,83,255,108,55,154,46,249,221,24,171,95,45,60,155,242,1,207,250,237,227,216,92,176,236,178,8,94,91,24,170,181,72,18,65,48,165,121,135,170,145,137,226,9,4,62,167,241,246,113,32,167,200,70,45,74,241,30,206,113,65,80,240,78,200,80,27,113,98,217,124,30,68,158,205,122,160,235,201,218,71,144,146,94,203,138,108,97,203,36,44,226,43,82,131,95,173,11,186,149,138,26,163,32,117,29,116,95,49,85,224,117,201,163,138,68,26,255,62,89,44,251,209,4,113,27,205,219,104,193,203,213,180,159,204,222,143,16,152,41,3,222,243,217,120,237,142,13,166,127,57,76,43,159,217,120,167,68,108,172,135,44,75,144,175,128,81,148,166,90,31,77,173,230,86,152,246,104,14,205,101,88,224,6,133,26,125,46,59,228,46,210,214,41,36,110,147,138,174,196,116,110,68,169,132,38,138,241,232,175,86,226,68,70,193,34,21,188,151,141,154,178,241,126,97,218,155,228,155,245,44,138,77,77,216,150,17,45,39,65,24,180,141,62,181,38,109,54,119,129,233,39,243,89,79,165,223,160,122,131,106,228,155,229,161,235,199,106,80,102,116,200,107,60,10,207,153,3,107,231,61,217,43,81,109,67,177,181,216,128,204,213,80,80,37,11,66,231,22,77,167,152,179,150,5,172,247,126,161,154,88,178,117,133,6,84,131,67,53,134,148,73,85,24,202,65,135,200,202,171,112,23,168,222,169,27,64,255,122,128,6,81,198,67,104,206,58,32,89,156,177,34,90,92,202,20,50,78,41,87,56,149,122,171,54,45,217,197,96,137,69,32,137,156,109,140,118,18,179,19,26,96,46,70,219,100,202,213,109,26,104,110,146,140,18,161,213,0,64,163,227,147,148,22,188,83,153,172,2,44,52,63,148,122,95,196,103,169,217,58,111,133,2,127,128,169,5,72,107,185,10,210,53,81,73,129,72,175,251,231,163,209,126,55,122,176,223,61,250,153,203,70,200,177,176,207,86,232,132,218,97,37,14,147,153,6,146,149,91,200,168,178,210,210,245,101,227,53,45,63,162,108,28,14,21,225,210,193,111,95,79,94,174,14,242,134,250,255,128,235,60,122,135,113,109,205,140,129,31,91,60,242,39,121,18,6,164,157,60,53,42,173,92,85,83,110,108,216,77,107,74,106,168,26,3,186,42,5,51,12,182,64,18,26,238,18,158,125,141,173,152,44,243,53,215,249,44,171,111,184,178,170,128,140,182,132,114,66,202,97,60,102,51,102,81,197,87,121,223,168,127,86,206,72,93,18,224,93,176,81,77,240,72,195,161,112,55,147,112,55,213,198,234,46,72,194,227,82,230,171,217,134,250,255,122,76,65,187,26,138,162,44,84,101,9,166,48,192,96,184,67,75,13,190,233,40,232,234,249,150,76,193,84,237,67,16,184,190,3,213,18,163,238,4,141,34,89,203,153,50,53,163,245,213,76,65,98,90,204,56,145,114,25,19,1,111,80,177,114,246,2,173,203,132,64,217,150,148,127,22,166,16,130,74,1,135,211,10,7,182,57,98,182,175,49,224,119,168,69,9,78,245,54,249,235,225,118,62,241,126,186,98,132,152,55,116,251,187,131,168,106,133,146,218,172,40,18,180,207,74,165,17,71,12,174,27,41,138,42,168,74,214,126,215,214,216,2,90,163,105,81,4,23,128,234,166,13,210,56,55,76,186,99,86,30,54,233,108,174,4,209,144,238,228,76,20,94,97,252,99,147,12,195,92,183,9,169,146,79,202,163,31,212,250,147,128,136,8,244,84,98,62,197,104,112,216,205,224,15,3,131,10,38,49,23,244,201,101,131,57,255,205,65,180,215,211,162,223,192,232,91,120,184,23,48,122,119,242,15,193,2,185,229,213,29,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public ReadCaseDataFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,107,219,64,16,253,43,70,135,158,180,65,218,47,237,170,71,227,22,31,154,132,54,45,133,196,132,213,238,200,94,208,135,35,173,154,4,227,255,222,145,149,184,16,104,113,33,61,20,114,219,175,121,243,222,104,222,104,119,235,251,15,190,10,208,229,165,169,122,136,135,165,203,35,227,128,10,202,10,162,132,210,132,83,205,73,97,147,146,104,169,56,75,173,44,25,184,40,110,76,13,121,52,69,47,156,15,81,92,181,107,111,77,117,177,133,206,4,223,54,121,116,209,69,177,15,80,247,249,245,238,87,170,208,13,16,223,150,135,205,23,187,129,218,124,29,211,166,105,230,24,45,53,81,52,19,132,11,198,137,226,105,74,48,163,76,83,97,65,91,76,123,96,152,225,145,19,150,18,43,74,74,120,105,21,41,4,50,204,10,166,50,158,105,142,48,200,7,202,176,120,216,118,208,247,35,155,29,28,215,87,143,91,228,62,229,158,183,213,80,55,81,92,67,48,151,38,108,80,63,36,192,133,53,196,114,141,68,74,200,136,97,218,17,102,138,140,102,10,82,153,102,81,108,205,118,18,185,68,86,206,4,243,205,84,3,28,144,119,30,57,82,150,164,74,72,140,77,153,37,156,209,132,40,169,50,82,58,89,106,96,82,235,226,88,197,143,131,199,181,239,207,135,26,58,111,159,62,6,96,85,219,46,223,217,182,9,93,91,141,208,231,135,231,87,240,16,166,146,63,93,125,159,4,5,60,31,131,162,125,60,244,48,175,60,52,97,209,216,214,249,102,61,97,238,247,24,82,111,77,231,251,231,42,44,238,6,83,69,113,231,215,155,63,86,107,62,244,161,173,255,35,169,49,202,68,12,108,178,3,221,177,7,157,239,183,149,121,60,236,243,232,221,221,208,134,247,243,14,12,66,205,26,184,159,249,198,122,135,72,103,159,193,182,157,155,45,221,244,38,122,129,149,71,55,145,54,78,105,150,1,145,70,160,75,140,180,164,144,69,66,24,181,216,173,89,201,133,176,103,80,72,109,178,146,17,108,87,57,90,137,98,119,115,73,152,178,84,3,79,164,160,250,38,66,17,175,74,237,122,217,95,220,55,207,230,154,202,177,58,195,211,23,7,139,10,106,132,204,119,167,104,217,99,192,229,115,42,108,143,19,148,237,87,163,182,21,54,221,171,186,95,178,68,201,4,239,52,36,28,159,74,192,249,100,52,73,25,99,194,9,38,148,122,115,255,155,251,79,114,255,39,156,24,165,71,143,249,198,216,224,127,192,209,104,179,123,31,54,51,236,211,10,111,13,14,194,117,3,112,138,251,44,148,64,121,66,137,163,28,8,151,146,18,77,165,34,9,179,146,22,28,148,113,201,153,113,227,207,52,177,132,49,91,16,94,36,64,116,54,78,80,73,93,34,76,150,136,162,248,253,96,248,7,172,255,122,102,156,34,243,197,204,56,69,244,113,102,172,246,63,1,120,166,224,206,158,8,0,0 })));
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

			private bool _readSomeTopRecords = false;
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
					return _orderInfo ?? (_orderInfo = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,243,76,177,50,176,50,208,241,43,205,77,74,45,178,50,180,50,4,0,178,212,123,197,17,0,0,0 })));
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

			public ResolvedCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
				EntityFilters = @"{_isFilter:false,uId:""dadc7b7d-b990-430e-b79d-5376e1f8beb0"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""117d32f9-8275-4534-8411-1c66115ce9cd"",uId:""1fac16a5-a625-4773-a4aa-287aceb4b093"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""a71adaea-3464-4dee-bb4f-c7a535450ad7"",caption:""Status"",referenceSchemaUId:""99f35013-6b7a-47d6-b440-e3f1a0ba991c"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Resolved&quot;"",parameterValue:""&quot;ae7f411e-f46b-1410-009b-0050ba5d6c38&quot;""}]}}]}";
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

			public ResolvedChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,75,79,219,64,16,254,43,145,207,44,242,218,139,31,185,81,160,21,135,22,164,32,46,132,195,236,122,54,89,225,151,118,215,180,20,229,191,119,108,135,52,180,17,77,171,170,69,106,115,72,236,47,223,204,124,243,218,125,12,84,9,206,125,128,10,131,105,240,230,242,253,172,209,254,240,173,41,61,218,119,182,233,218,224,32,112,104,13,148,230,51,22,35,126,86,24,127,10,30,200,224,113,254,213,126,30,76,231,187,60,204,131,131,121,96,60,86,142,24,100,144,171,84,139,68,33,19,177,86,76,68,113,202,100,17,9,166,65,69,186,128,84,98,204,71,230,110,215,39,77,213,130,197,49,194,224,92,15,143,87,15,109,79,228,4,168,129,98,92,83,175,193,184,151,224,206,106,144,37,22,244,238,109,135,4,121,107,42,202,4,175,76,133,151,96,41,82,239,167,233,33,34,105,40,93,207,42,81,251,179,79,173,69,231,76,83,191,44,173,236,170,122,155,75,230,184,121,93,139,9,7,133,61,243,18,252,114,112,112,78,162,86,131,198,227,197,194,226,2,188,185,223,150,112,135,15,3,111,191,218,145,65,65,253,185,134,178,195,173,152,207,243,56,129,214,143,233,140,225,137,96,205,98,185,103,166,155,106,253,40,217,136,192,246,137,188,151,199,157,250,163,132,192,251,30,24,125,60,61,206,131,155,115,119,241,177,70,59,83,75,172,96,172,216,237,33,161,223,0,27,255,211,71,192,52,134,40,231,236,40,166,47,17,231,25,131,34,229,76,37,60,204,185,44,210,76,227,234,118,212,97,92,91,194,195,245,38,220,73,103,45,214,126,226,193,221,77,206,79,7,82,95,62,250,43,66,161,114,16,49,83,252,72,50,17,38,17,147,161,148,44,229,242,40,143,50,224,57,215,212,102,250,144,77,170,226,44,79,1,88,146,198,5,19,169,144,44,79,5,178,48,151,92,43,200,48,251,247,182,96,230,193,119,142,206,142,218,184,229,126,11,177,95,25,119,12,20,143,94,220,136,181,148,241,103,98,220,68,155,26,202,215,190,37,67,82,79,171,49,148,106,61,109,101,179,48,10,202,139,22,45,85,114,16,29,238,30,134,103,83,212,47,157,109,26,63,174,210,70,204,177,162,110,24,79,29,216,234,4,130,20,9,112,205,18,161,67,234,68,76,211,47,101,204,138,48,146,69,130,34,211,170,63,228,232,62,233,85,207,154,206,170,245,244,186,241,34,249,165,43,226,47,12,253,207,156,231,59,103,101,159,238,255,63,255,178,87,222,226,217,247,135,213,111,235,246,31,223,227,85,176,250,2,244,5,54,43,10,10,0,0 })));
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
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public CanceledCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
				EntityFilters = @"{_isFilter:false,uId:""543091b1-97e0-45d2-b947-6fda16831f3c"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""117d32f9-8275-4534-8411-1c66115ce9cd"",uId:""5ab56440-a4b9-4680-b192-23bb1a7c7981"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""a71adaea-3464-4dee-bb4f-c7a535450ad7"",caption:""Status"",referenceSchemaUId:""99f35013-6b7a-47d6-b440-e3f1a0ba991c"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Cancelled&quot;"",parameterValue:""&quot;6e5f4218-f46b-1410-fe9a-0050ba5d6c38&quot;""}]}}]}";
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

			public CanceledChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,77,111,211,64,16,253,43,145,207,221,202,222,117,108,111,110,165,45,168,7,104,165,84,189,52,61,204,218,227,100,85,127,105,119,93,8,81,254,59,99,59,9,41,68,37,32,4,149,32,135,196,126,121,51,243,230,107,119,229,165,5,88,251,1,74,244,38,222,155,155,247,211,58,119,167,111,117,225,208,188,51,117,219,120,39,158,69,163,161,208,159,49,27,240,203,76,187,11,112,64,6,171,217,87,251,153,55,153,29,242,48,243,78,102,158,118,88,90,98,144,1,40,158,134,129,140,152,226,10,89,40,2,159,41,41,98,150,196,232,7,89,24,10,149,37,3,243,176,235,243,186,108,192,224,16,161,119,158,247,143,183,203,166,35,6,4,164,61,69,219,186,218,128,162,147,96,47,43,80,5,102,244,238,76,139,4,57,163,75,202,4,111,117,137,55,96,40,82,231,167,238,32,34,229,80,216,142,85,96,238,46,63,53,6,173,213,117,245,178,180,162,45,171,125,46,153,227,238,117,35,198,239,21,118,204,27,112,139,222,193,21,137,90,247,26,207,230,115,131,115,112,250,105,95,194,35,46,123,222,113,181,35,131,140,250,115,7,69,139,123,49,159,231,113,14,141,27,210,25,194,19,193,232,249,226,200,76,119,213,250,81,178,156,192,102,75,62,202,227,65,253,60,34,240,169,3,6,31,219,199,153,119,127,101,175,63,86,104,166,233,2,75,24,42,246,112,74,232,55,192,206,255,100,5,24,11,224,50,96,99,65,95,161,144,9,131,44,14,88,26,5,190,12,84,22,39,57,174,31,6,29,218,54,5,44,239,118,225,206,91,99,176,114,35,7,246,113,116,117,209,147,186,242,209,95,145,72,4,42,161,24,23,24,177,208,247,3,166,148,2,150,137,92,37,41,134,60,204,124,106,51,125,200,102,156,167,105,162,80,49,25,73,78,228,48,97,9,74,193,198,17,196,81,28,137,88,74,255,95,219,130,169,3,215,90,58,59,42,109,23,199,45,196,113,101,60,48,80,1,127,113,35,54,82,134,159,145,182,163,92,87,80,188,246,45,233,147,218,174,70,95,170,205,180,21,245,92,167,80,92,55,104,168,146,189,104,255,240,48,60,155,162,110,233,76,93,187,97,149,118,98,206,82,234,134,118,212,129,189,78,200,120,44,85,192,5,163,57,151,44,84,62,103,146,115,197,114,200,50,17,196,9,250,121,68,61,165,251,164,83,61,173,91,147,110,166,215,14,23,201,47,93,17,127,97,232,127,230,60,63,56,43,199,116,255,255,249,183,59,255,94,105,139,167,223,31,86,191,173,219,127,124,143,215,222,250,11,0,151,124,192,10,10,0,0 })));
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
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public PendingCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
				EntityFilters = @"{_isFilter:false,uId:""2348f93f-39d3-43a1-b8ec-124dffb0e7f2"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""117d32f9-8275-4534-8411-1c66115ce9cd"",uId:""2018e7a5-23fd-4373-a3ad-61c145d13fde"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""a71adaea-3464-4dee-bb4f-c7a535450ad7"",caption:""Status"",referenceSchemaUId:""99f35013-6b7a-47d6-b440-e3f1a0ba991c"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Pending&quot;"",parameterValue:""&quot;3859c6e7-cbcb-486b-ba53-77808fe6e593&quot;""}]}}]}";
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

			public PendingChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,85,75,111,218,64,16,254,43,200,231,108,228,197,111,110,41,161,21,135,54,72,68,185,196,57,140,237,89,88,197,47,237,174,211,82,196,127,239,216,6,151,180,40,165,85,213,70,106,57,128,253,241,237,204,55,207,221,90,105,14,90,127,128,2,173,137,245,102,241,126,89,9,115,249,86,230,6,213,59,85,53,181,117,97,105,84,18,114,249,25,179,30,159,101,210,92,131,1,58,176,141,191,158,143,173,73,124,202,66,108,93,196,150,52,88,104,98,208,1,142,16,56,73,32,88,24,37,9,115,129,251,44,113,133,195,184,45,28,63,224,194,227,98,220,51,79,155,158,86,69,13,10,123,15,157,113,209,61,222,110,234,150,200,9,72,59,138,212,85,185,7,157,86,130,158,149,144,228,152,209,187,81,13,18,100,148,44,40,18,188,149,5,46,64,145,167,214,78,213,66,68,18,144,235,150,149,163,48,179,79,181,66,173,101,85,190,44,45,111,138,242,152,75,199,113,120,221,139,177,59,133,45,115,1,102,221,25,152,147,168,93,167,241,106,181,82,184,2,35,159,142,37,60,226,166,227,157,151,59,58,144,81,125,238,32,111,240,200,231,243,56,166,80,155,62,156,222,61,17,148,92,173,207,140,116,200,214,143,130,29,19,88,31,200,103,89,60,169,127,236,19,248,212,2,189,141,195,99,108,221,207,245,205,199,18,213,50,93,99,1,125,198,30,46,9,253,6,24,236,79,182,128,129,3,227,136,51,207,161,47,215,137,66,6,89,192,89,234,115,59,226,73,22,132,2,119,15,189,14,169,235,28,54,119,131,187,105,163,20,150,102,100,64,63,142,230,215,29,169,77,31,253,133,129,239,35,102,30,243,108,151,138,19,186,46,11,221,132,188,184,34,226,30,122,33,64,74,101,166,79,107,56,18,194,15,69,198,144,220,49,55,227,17,75,50,135,179,192,177,185,19,250,62,240,208,253,215,166,96,105,192,52,154,118,71,41,245,250,188,129,56,47,141,39,26,138,143,95,156,136,189,148,254,103,36,245,72,200,18,242,215,62,37,93,80,135,209,232,82,181,239,182,188,90,201,20,242,155,26,21,101,178,19,109,159,110,134,103,93,212,14,157,170,42,211,143,210,32,230,42,165,106,72,67,21,56,170,132,13,17,248,105,40,152,205,125,96,174,237,32,75,80,36,44,64,240,60,31,4,134,97,187,228,232,62,105,85,47,171,70,165,251,238,213,253,69,242,75,87,196,95,104,250,159,217,231,39,123,229,156,234,255,223,127,195,254,123,165,37,94,126,191,172,126,91,181,255,248,28,239,172,221,23,139,77,36,63,10,10,0,0 })));
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
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public EscalationCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
				EntityFilters = @"{_isFilter:false,uId:""dbb99e94-3913-4a55-a508-54e46e4e5b39"",name:""FilterEdit"",logicalOperation:""Or"",items:[{_isFilter:true,_filterSchemaUId:""117d32f9-8275-4534-8411-1c66115ce9cd"",uId:""00341d8c-8bdd-4cd2-834e-302e3c28735b"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""70620d00-e4ea-48d1-9fdc-4572fcd8d41b"",caption:""Owner"",referenceSchemaUId:""16be3651-8fe2-4159-8dd0-a803d4683dd3"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""IsNotNull""},{_isFilter:true,_filterSchemaUId:""117d32f9-8275-4534-8411-1c66115ce9cd"",uId:""bf5aa442-2113-479a-afd5-bf5d470a810d"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""9147230c-ab53-4eb4-b0b4-ac78be6f8326"",caption:""Group"",referenceSchemaUId:""84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""IsNotNull""}]}";
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

			public EscalationChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,201,110,219,48,16,253,21,131,135,158,196,64,20,41,46,234,45,134,91,228,146,6,72,90,20,72,140,96,184,197,68,180,56,18,133,38,48,252,239,165,173,184,45,140,160,232,122,200,69,162,70,156,153,55,15,239,205,230,54,12,239,66,29,93,95,121,168,7,151,141,103,182,66,146,11,197,140,163,24,132,215,152,177,60,199,96,164,197,196,216,66,80,193,104,238,74,148,181,208,184,10,77,217,11,27,34,202,66,116,205,80,93,111,190,23,141,253,232,178,91,191,255,184,52,43,215,192,199,93,3,195,152,178,146,22,24,152,49,152,233,156,96,173,108,137,37,144,194,176,2,148,151,10,77,88,132,0,65,189,228,88,42,173,48,203,203,18,131,77,168,140,182,74,20,58,231,68,8,148,213,206,199,197,227,186,119,195,16,186,182,218,184,111,231,171,167,117,66,57,245,158,119,245,216,180,40,107,92,132,11,136,171,10,129,203,29,43,13,96,195,84,137,153,119,2,3,85,22,83,208,162,16,210,145,84,30,101,6,214,113,87,22,157,89,148,89,136,240,9,234,209,237,43,111,66,194,88,208,156,200,146,167,92,66,211,56,180,200,177,228,82,96,111,185,87,142,114,165,180,61,240,245,126,12,233,28,134,243,177,113,125,48,207,180,187,196,95,215,87,27,211,181,177,239,234,93,233,243,253,245,43,247,24,39,114,159,127,125,158,6,138,41,190,75,66,219,108,28,220,188,14,174,141,139,214,116,54,180,119,83,205,237,54,165,52,107,232,195,112,96,97,241,48,66,141,178,62,220,173,126,202,214,124,28,98,215,188,162,81,179,52,102,170,145,68,182,135,187,211,160,13,195,186,134,167,253,119,133,222,60,140,93,124,59,31,251,62,37,207,34,12,247,179,96,167,32,58,74,174,208,77,146,133,160,80,40,130,75,154,30,140,42,153,68,39,8,54,156,228,138,104,43,164,119,55,40,1,250,187,54,215,103,195,135,47,237,193,25,211,44,203,147,20,61,10,92,28,50,171,205,175,32,219,46,119,216,150,73,0,255,212,137,134,11,6,105,47,96,174,4,195,12,52,197,218,23,26,243,146,1,241,37,101,68,186,63,119,98,218,47,146,121,101,176,102,50,237,28,161,52,86,96,120,218,62,164,240,148,81,110,160,56,209,60,245,80,146,166,61,144,167,75,206,185,164,62,86,98,207,161,164,222,210,162,116,230,7,187,94,70,136,227,112,50,189,102,97,152,249,208,238,12,240,130,174,85,174,121,169,189,196,185,247,137,7,194,8,150,66,40,92,176,34,79,7,240,42,23,7,93,159,118,93,237,160,253,13,105,207,87,206,220,159,118,143,199,210,78,92,152,123,157,226,255,195,197,23,7,213,188,174,129,95,240,242,177,115,246,23,247,10,95,110,191,2,87,222,244,191,194,6,0,0 })));
				}
				set {
					_dataSourceFilters = value;
				}
			}

			private EntityColumnMappingValues _recordColumnValues;
			public override EntityColumnMappingValues RecordColumnValues {
				get {
					if (_recordColumnValues == null) {
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,84,203,110,219,48,16,252,21,131,201,209,52,248,18,69,250,214,54,61,4,72,10,163,105,115,137,115,88,146,203,70,168,108,185,122,4,72,3,255,123,105,218,110,108,244,1,163,64,15,5,202,131,4,138,156,153,229,14,71,207,228,188,127,90,33,153,146,215,179,235,155,38,246,147,55,77,139,147,89,219,120,236,186,201,85,227,161,174,190,130,171,113,6,45,44,176,199,246,22,234,1,187,171,170,235,199,163,67,16,25,147,243,199,188,70,166,119,207,228,178,199,197,199,203,144,152,189,145,194,3,243,180,116,58,82,37,173,167,134,235,34,77,37,55,78,249,32,181,77,96,223,212,195,98,121,141,61,204,160,127,32,211,103,146,217,50,65,48,42,38,152,83,198,81,85,90,71,45,120,77,149,226,34,74,37,181,7,65,214,99,210,249,7,92,64,22,61,0,43,101,67,170,128,130,242,158,42,199,56,117,54,20,212,0,23,94,9,176,209,216,13,120,183,255,5,120,119,118,213,52,159,135,213,196,176,2,192,163,162,70,51,69,21,195,146,130,69,71,89,44,20,47,85,97,165,103,19,229,130,115,198,68,90,24,212,52,68,206,169,45,121,218,196,120,208,12,173,52,94,159,221,111,132,66,213,173,106,120,186,253,165,222,43,223,87,143,85,255,52,234,122,232,135,46,53,119,177,170,83,231,195,22,191,58,50,226,144,225,121,190,117,115,78,166,243,159,251,185,123,223,228,70,29,59,122,108,230,156,140,231,228,166,25,90,191,97,147,155,201,190,185,153,157,237,70,58,223,15,143,253,216,114,100,216,53,44,225,19,182,239,146,94,134,231,165,11,232,33,75,127,72,53,239,137,157,176,5,43,121,164,37,130,165,10,181,160,38,112,160,150,91,23,101,41,69,140,34,163,223,99,196,22,151,30,143,11,59,197,172,140,207,202,47,197,236,239,93,250,178,28,234,58,11,116,249,252,155,139,188,43,124,183,114,113,224,224,1,67,19,170,88,97,184,92,254,97,171,54,37,124,239,201,78,109,77,214,235,241,97,152,148,98,133,141,78,108,47,177,210,54,181,70,8,79,89,81,152,128,49,74,203,194,111,195,4,40,75,225,35,80,16,169,203,170,140,44,69,65,43,202,203,192,101,137,14,173,214,127,49,76,82,88,23,152,70,26,109,145,228,141,80,20,88,116,212,20,24,146,181,81,88,101,38,41,207,69,58,8,163,186,148,233,18,64,90,183,90,104,202,16,56,20,101,170,192,170,19,195,148,92,28,234,126,212,196,17,236,98,53,121,219,165,159,26,244,85,179,28,181,248,101,168,218,255,201,138,39,36,235,20,231,254,177,100,221,175,191,1,98,16,40,180,0,7,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public ReadCaseCountDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,193,110,227,54,16,253,21,67,231,101,64,73,164,68,249,182,77,221,34,135,238,6,205,98,47,235,28,70,228,208,17,42,75,130,68,167,77,13,255,123,135,146,237,216,93,199,85,130,93,52,192,230,100,105,60,243,52,51,124,243,56,235,64,151,208,117,31,96,137,193,52,248,233,250,183,155,218,186,139,95,138,210,97,251,107,91,175,154,224,93,208,97,91,64,89,252,141,102,176,207,76,225,126,6,7,20,176,158,63,198,207,131,233,252,20,194,60,120,55,15,10,135,203,142,60,40,64,40,107,19,140,4,75,69,28,49,33,185,102,96,64,179,20,173,140,184,141,64,129,29,60,79,67,95,85,3,120,143,107,251,199,79,15,141,247,17,100,208,245,178,129,182,232,234,106,107,140,253,215,187,89,5,121,137,134,222,93,187,66,50,185,182,88,82,17,248,169,88,226,53,180,244,17,143,83,123,19,57,89,40,59,239,85,162,117,179,191,154,22,187,174,168,171,115,89,93,214,229,106,89,29,250,82,56,238,95,183,201,240,62,67,239,121,13,238,174,7,184,132,142,254,217,244,89,190,95,44,90,92,128,43,238,15,147,248,3,31,122,207,113,141,163,0,67,135,243,25,202,21,110,191,26,242,175,74,185,132,198,13,21,237,50,32,151,22,45,182,88,105,188,209,119,184,132,125,141,143,14,197,226,238,0,196,31,232,151,39,59,178,239,234,127,53,37,34,99,179,115,62,215,227,61,226,201,42,163,132,140,247,222,48,96,236,30,231,193,151,171,238,227,159,21,182,67,89,67,95,111,47,200,250,47,195,172,196,37,86,110,186,86,86,166,2,101,206,210,132,218,45,210,40,98,25,135,140,197,218,38,210,196,60,7,80,27,10,216,39,52,93,167,32,67,16,42,98,90,39,9,19,161,76,25,164,137,100,60,53,22,48,67,110,147,220,135,204,42,87,184,135,129,45,211,53,32,71,33,53,48,45,50,201,132,69,138,138,51,195,98,200,211,40,85,24,38,97,186,185,29,202,45,186,166,132,135,207,251,170,126,71,48,19,77,71,51,241,157,160,137,107,59,55,241,115,54,169,237,132,58,188,42,93,81,45,38,68,183,18,181,63,236,139,43,211,35,249,31,138,183,81,36,83,21,231,12,184,36,58,197,73,204,242,16,19,150,65,142,33,202,212,64,70,116,218,108,54,183,158,156,105,158,168,92,24,205,18,142,33,235,155,163,48,11,25,96,164,56,181,3,52,196,231,206,238,140,32,96,194,99,205,61,180,66,203,4,247,188,150,82,51,19,83,6,105,38,98,25,234,31,72,16,110,28,184,85,55,78,18,198,181,238,249,146,176,203,225,140,40,188,39,78,221,19,149,15,93,95,179,60,244,21,31,200,195,118,10,226,76,24,145,43,193,164,34,238,27,27,134,44,75,195,156,113,30,26,162,122,22,43,157,244,120,251,207,93,85,147,166,173,233,84,186,161,234,71,157,25,141,245,213,44,31,97,238,70,46,201,77,148,101,38,103,210,112,100,194,164,154,169,140,20,34,66,41,81,115,109,81,18,220,219,92,156,152,139,113,173,123,155,139,51,115,161,158,59,23,31,106,55,233,28,180,206,171,234,241,92,168,151,206,197,17,102,63,23,126,48,202,122,81,104,40,63,54,216,194,86,178,194,211,162,126,116,27,248,253,160,173,107,247,132,144,245,25,236,8,52,238,186,123,42,27,254,141,179,225,180,15,168,88,132,76,71,202,48,33,98,205,50,226,55,51,194,90,162,116,36,104,231,160,108,104,87,247,170,119,83,175,90,141,195,157,216,13,75,250,139,214,239,255,225,42,125,222,194,252,196,125,51,230,6,121,91,30,95,231,242,248,162,181,240,149,18,245,112,145,251,134,84,61,18,236,177,75,199,179,87,138,31,187,167,106,108,79,191,231,117,244,93,111,151,77,176,249,7,176,192,144,122,252,17,0,0 })));
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

			private bool _readSomeTopRecords = false;
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

			public CompleteTasksChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,223,115,219,54,12,254,87,116,122,46,115,212,47,82,244,91,151,185,187,60,108,205,45,185,190,212,121,128,72,208,209,85,150,124,18,157,205,243,249,127,31,40,217,142,187,56,158,154,219,181,217,181,47,150,4,3,32,240,225,3,129,77,168,43,232,186,223,96,129,225,36,252,233,250,215,155,198,186,139,119,101,229,176,253,165,109,86,203,240,77,216,97,91,66,85,254,133,102,144,79,77,233,126,6,7,100,176,153,61,218,207,194,201,236,148,135,89,248,102,22,150,14,23,29,105,144,129,144,156,39,152,71,76,40,142,44,229,73,206,148,1,205,180,76,243,140,11,72,51,109,7,205,211,174,175,234,193,121,239,215,246,175,183,235,165,215,73,73,160,155,197,18,218,178,107,234,157,48,241,167,119,211,26,138,10,13,125,187,118,133,36,114,109,185,160,36,240,182,92,224,53,180,116,136,247,211,120,17,41,89,168,58,175,85,161,117,211,63,151,45,118,93,217,212,231,162,186,108,170,213,162,62,214,37,115,60,124,238,130,225,125,132,94,243,26,220,125,239,224,18,58,250,103,219,71,249,118,62,111,113,14,174,124,56,14,226,19,174,123,205,113,192,145,129,161,226,124,128,106,133,187,83,35,254,36,149,75,88,186,33,163,125,4,164,210,162,197,22,107,141,55,250,30,23,112,200,241,81,161,156,223,31,57,241,5,253,248,44,34,7,84,255,13,148,152,132,203,189,242,57,140,15,30,79,102,25,11,18,62,120,193,224,99,255,58,11,63,94,117,239,255,168,177,29,210,26,112,189,187,32,233,63,4,211,10,23,88,187,201,38,183,153,76,49,43,152,20,113,202,82,25,199,76,113,80,44,209,86,100,38,225,5,64,190,37,131,67,64,147,141,132,44,130,52,143,153,214,66,176,52,202,36,3,41,50,198,165,177,128,10,185,21,133,55,153,214,174,116,235,129,45,147,13,32,71,42,27,48,157,170,140,165,22,201,42,81,134,37,80,200,88,230,24,137,72,110,239,134,116,203,110,89,193,250,195,33,171,223,17,76,160,169,52,129,71,130,58,174,237,92,224,251,44,104,108,64,8,175,42,87,214,243,128,232,86,161,246,197,190,184,50,189,39,255,32,251,34,181,57,87,90,176,216,170,130,165,169,140,152,210,210,178,36,198,196,232,40,2,72,52,17,115,187,189,243,228,52,156,190,173,68,22,25,175,237,223,148,177,146,161,200,141,225,86,153,92,137,239,168,107,223,18,162,15,190,144,116,242,188,105,215,227,58,120,28,136,47,233,224,125,20,103,186,248,105,200,175,189,163,251,172,143,58,122,71,92,155,69,58,21,105,194,178,28,5,51,54,34,226,202,168,96,156,71,70,112,84,73,174,7,20,15,199,221,54,129,105,122,209,227,165,48,218,203,147,198,219,121,219,119,134,229,34,143,11,44,152,229,138,58,95,197,134,129,202,232,39,22,177,80,137,230,16,103,231,57,232,185,143,207,181,71,244,127,108,143,27,7,110,213,209,157,84,151,221,253,184,222,24,7,227,41,150,196,103,123,99,23,202,240,8,202,46,176,101,13,213,41,242,143,34,234,215,162,126,124,68,214,30,42,162,155,135,177,106,230,165,134,234,253,18,91,66,178,15,154,159,38,195,103,44,242,179,177,109,26,247,204,157,208,199,176,175,4,231,57,38,50,201,24,141,44,195,210,4,104,207,192,60,99,50,202,147,168,176,177,146,0,84,83,218,12,125,212,55,205,170,213,59,246,118,195,74,248,162,101,239,27,204,132,47,91,207,158,185,42,199,48,224,199,170,242,58,87,149,87,202,185,211,203,197,127,200,191,207,6,235,216,81,248,197,227,238,27,140,49,124,217,108,58,57,8,158,248,26,3,236,215,190,182,183,225,246,111,66,222,9,236,195,15,0,0 })));
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
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public CancelTasksChangeDataUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _dataSourceFilters ?? (_dataSourceFilters = Encoding.UTF8.GetString(Compressor.UnZip(new byte[] { 31,139,8,0,0,0,0,0,0,10,237,86,77,115,227,54,12,253,43,30,157,151,25,82,34,245,225,219,54,117,59,57,180,155,105,50,123,89,231,0,146,160,163,169,44,121,36,58,173,155,241,127,47,40,217,142,183,113,92,109,166,179,155,78,123,146,4,1,32,240,240,0,240,49,50,21,116,221,207,176,196,104,26,125,119,253,211,77,227,252,197,15,101,229,177,253,177,109,214,171,232,93,212,97,91,66,85,254,129,118,144,207,108,233,191,7,15,100,240,56,127,178,159,71,211,249,41,15,243,232,221,60,42,61,46,59,210,32,3,39,180,179,42,143,89,172,165,99,50,41,10,166,77,145,48,29,103,185,205,141,73,156,18,131,230,105,215,87,245,224,188,247,235,250,215,219,205,42,232,72,18,152,102,185,130,182,236,154,122,39,76,194,233,221,172,6,93,161,165,111,223,174,145,68,190,45,151,148,4,222,150,75,188,134,150,14,9,126,154,32,34,37,7,85,23,180,42,116,126,246,251,170,197,174,43,155,250,92,84,151,77,181,94,214,199,186,100,142,135,207,93,48,188,143,48,104,94,131,191,239,29,92,66,71,127,182,125,148,239,23,139,22,23,224,203,135,227,32,126,197,77,175,57,14,56,50,176,84,156,143,80,173,113,119,170,224,207,82,185,132,149,31,50,218,71,64,42,45,58,108,177,54,120,99,238,113,9,135,28,159,20,202,197,253,145,147,80,208,79,47,34,114,64,245,239,64,137,73,184,218,43,159,195,248,224,241,100,150,113,74,194,135,32,24,124,236,95,231,209,167,171,238,195,111,53,182,67,90,3,174,119,23,36,253,139,96,86,225,18,107,63,125,204,157,202,36,42,205,178,52,150,76,102,113,204,10,14,5,75,140,75,149,77,184,6,200,183,100,112,8,104,250,152,129,18,32,169,56,198,164,41,147,66,101,12,178,84,49,158,89,7,88,32,119,169,14,38,179,218,151,126,51,176,101,250,8,200,81,42,3,204,200,66,49,233,144,172,146,194,178,4,116,70,85,69,145,138,108,123,55,164,91,118,171,10,54,31,15,89,253,130,96,39,134,74,51,9,72,80,199,181,157,159,132,62,155,52,110,66,8,175,43,95,214,139,9,209,173,66,19,138,125,113,101,123,79,225,65,246,104,149,6,161,98,230,114,136,41,73,138,29,178,68,177,36,230,57,133,159,199,113,161,137,152,219,237,93,32,167,204,56,40,105,4,43,116,22,200,231,18,6,26,115,150,105,151,231,40,185,224,125,119,253,87,186,246,61,33,250,16,10,73,39,47,154,118,51,174,131,199,129,248,154,14,222,71,113,166,139,159,135,252,214,59,186,207,250,168,163,119,196,165,49,103,100,42,19,166,114,76,153,117,130,240,204,132,102,156,11,155,114,44,146,220,164,189,191,195,113,183,205,196,54,189,232,105,40,140,246,242,172,241,118,222,14,157,161,164,42,172,81,76,56,129,76,26,155,179,194,9,154,1,152,233,36,201,51,180,130,159,231,96,224,62,190,212,30,226,223,216,30,55,30,252,186,163,153,84,151,221,253,200,222,24,5,227,41,150,196,103,123,99,23,202,240,152,148,221,196,149,53,84,167,200,63,138,168,95,139,250,241,17,89,123,168,136,110,1,198,170,89,148,6,170,15,43,108,9,201,62,104,126,154,12,159,177,40,236,198,182,105,252,11,51,161,143,97,95,137,92,72,30,199,32,24,0,210,148,18,142,51,157,165,64,43,208,105,161,173,85,130,231,84,83,186,25,134,168,111,154,117,107,118,236,237,134,43,225,171,46,123,223,96,39,124,217,245,236,133,81,57,134,1,255,95,85,222,230,85,229,141,114,238,244,229,226,31,228,223,103,139,117,236,42,252,226,117,247,13,214,24,190,110,55,157,92,4,207,124,141,1,246,107,143,237,109,180,253,19,55,42,175,160,195,15,0,0 })));
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
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public RescheduledCatchSignalFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
				EntityFilters = @"{_isFilter:false,uId:""0a46b150-32d2-40e9-bf57-933b745bfc9a"",name:""FilterEdit"",items:[{_isFilter:true,_filterSchemaUId:""c449d832-a4cc-4b01-b9d5-8a12c42a9f89"",uId:""4ec38736-8c00-4dcc-8c9f-c250f63b860a"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""c8d84f9c-b48b-479b-9ac6-4412f3436ca2"",caption:""Status"",referenceSchemaUId:""805aace4-8604-40e7-a9eb-0f54174593c0"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Completed&quot;"",parameterValue:""&quot;4bdbb88f-58e6-df11-971b-001d60e938c6&quot;""}]}},{_isFilter:true,_filterSchemaUId:""c449d832-a4cc-4b01-b9d5-8a12c42a9f89"",uId:""645cd7c9-33b7-4b71-9f8b-a0fce4bac1af"",leftExpression:{expressionType:""SchemaColumn"",metaPath:""ae372cfa-a21f-47f0-8a64-17d137ebe966"",caption:""Result"",referenceSchemaUId:""329bd06e-f95f-4824-a0fb-85edff2f2948"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true}},comparisonType:""Equal"",rightExpression:{expressionType:""Parameter"",dataValueType:{id:""b295071f-7ea9-4e62-8d1a-919bf3732ff2"",name:""Lookup"",isNumeric:false,editor:{controlTypeName:""LookupEdit"",controlXType:""lookupedit""},useClientEncoding:true},parameterValues:[{displayValue:""&quot;Rescheduled&quot;"",parameterValue:""&quot;d87d32bc-f36b-1410-6598-00155d043204&quot;""}]}}]}";
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

			public AddRescheduledTaskUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
						var zippedData = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,152,221,79,27,71,16,192,255,21,235,200,91,89,107,191,63,252,150,146,84,66,130,20,133,52,47,192,195,236,206,44,177,106,238,144,125,166,162,200,255,123,231,12,36,144,182,46,105,75,85,4,126,176,117,235,157,217,217,153,249,205,236,222,85,243,170,191,60,167,102,210,124,127,176,127,216,213,126,188,211,205,105,124,48,239,10,45,22,227,189,174,192,108,250,43,228,25,29,192,28,206,168,167,249,71,152,45,105,177,55,93,244,219,163,187,66,205,118,243,234,98,253,95,51,57,186,106,118,123,58,251,105,23,89,179,141,64,42,23,47,170,35,16,214,133,40,18,162,21,50,168,154,92,44,209,40,203,194,165,155,45,207,218,125,234,225,0,250,79,205,228,170,89,107,99,5,37,42,91,33,40,65,82,101,97,141,118,2,74,68,17,209,130,78,134,80,153,216,172,182,155,69,249,68,103,176,94,244,142,176,181,9,163,209,2,108,41,194,102,169,68,78,232,68,4,165,139,213,144,106,76,131,240,205,252,47,130,71,91,123,93,247,243,242,124,156,188,34,45,163,23,44,193,203,163,14,34,203,228,132,149,89,145,183,232,75,145,227,234,84,177,222,26,225,34,121,129,85,41,145,2,91,43,165,66,47,41,153,88,252,214,201,176,16,78,23,231,51,184,252,248,167,235,189,46,253,244,98,218,95,142,10,244,116,218,205,47,199,31,186,17,118,215,210,231,247,194,112,87,254,234,248,58,150,199,205,228,248,143,163,121,243,123,184,118,211,253,120,222,15,229,113,179,125,220,28,118,203,121,25,180,25,126,120,115,199,232,245,2,235,41,95,61,222,198,142,71,218,229,108,118,51,242,6,122,184,157,120,59,220,225,180,78,9,119,219,195,219,144,173,181,200,155,15,123,237,119,95,183,159,107,219,254,137,216,62,180,112,74,243,119,188,253,47,182,127,182,242,3,187,240,86,113,214,201,13,89,42,2,65,18,150,188,230,156,83,32,146,74,185,154,96,116,173,122,45,253,158,42,205,169,45,116,223,176,135,100,206,141,252,98,237,237,1,154,27,187,6,87,173,154,213,106,251,46,74,213,107,7,186,104,161,80,34,171,113,78,228,200,56,68,175,201,162,115,174,16,109,68,201,98,169,18,140,18,161,98,96,139,50,8,144,210,10,178,202,100,21,156,177,70,253,251,40,13,249,3,167,109,183,160,17,180,56,154,243,110,103,23,52,154,182,101,138,212,246,163,173,227,230,187,163,173,163,221,197,143,191,180,52,191,246,225,164,194,108,65,39,99,30,253,106,224,237,140,206,88,106,114,21,171,11,150,92,22,193,107,43,108,208,90,36,201,129,50,165,122,135,70,102,128,184,98,129,207,169,62,185,10,224,20,216,168,69,41,222,11,171,92,16,16,188,227,90,132,21,40,145,172,62,15,34,111,219,158,9,220,89,251,145,165,114,44,228,179,21,58,21,174,96,178,112,28,9,120,247,46,215,144,67,177,210,194,234,100,51,222,15,243,193,123,2,100,238,121,18,114,66,142,127,152,206,23,253,104,202,241,31,117,117,144,89,206,250,105,123,58,226,0,207,136,203,68,215,142,223,45,207,50,205,95,138,195,127,94,28,92,1,227,170,146,12,55,131,96,139,231,84,74,30,132,137,6,193,67,133,82,203,166,226,240,96,195,30,90,28,82,204,193,91,143,2,93,229,106,67,149,235,78,176,82,196,0,50,80,65,69,33,110,46,14,156,201,88,108,16,209,105,46,119,40,73,128,175,32,170,102,213,89,75,86,97,30,163,207,254,127,193,7,146,100,57,208,162,216,161,108,87,98,41,147,80,24,200,65,135,72,202,171,240,87,224,255,29,168,119,241,5,232,39,215,237,149,10,200,147,146,136,58,112,178,112,47,21,209,242,57,80,113,198,41,197,173,57,21,252,38,160,169,2,70,224,228,14,20,42,243,8,86,100,224,60,148,178,100,62,251,38,7,81,109,4,186,202,96,24,96,35,66,66,46,81,193,115,177,34,159,68,242,84,156,79,201,216,164,158,23,208,65,122,45,145,179,133,236,112,23,225,248,138,84,145,183,231,130,174,5,217,171,42,63,6,208,107,119,188,48,253,244,152,246,153,140,119,74,196,74,122,200,50,166,27,145,49,138,210,160,245,220,234,209,124,19,211,144,37,247,88,109,132,30,192,182,134,79,13,145,47,138,220,81,98,142,209,69,23,178,222,200,116,174,0,169,112,61,40,198,71,97,173,228,29,153,245,41,36,120,47,43,84,101,227,243,98,218,155,228,171,245,52,52,105,46,147,53,115,180,28,95,143,162,182,209,167,90,165,205,230,49,152,222,233,218,30,74,255,66,245,11,213,166,86,166,218,23,110,38,124,254,182,18,171,200,54,70,161,180,113,124,211,55,94,201,205,84,215,44,209,87,238,70,42,240,189,210,2,95,201,65,241,237,30,108,230,151,74,197,163,124,110,84,103,229,140,212,37,241,37,187,240,66,152,216,35,149,55,197,101,87,166,154,0,43,169,199,160,250,117,41,221,178,125,161,250,233,81,173,29,134,162,32,243,203,49,146,124,162,27,48,24,218,163,212,124,139,115,16,52,250,235,55,155,27,122,245,201,234,55,148,76,19,175,18,23,0,0 };
						string serializedData =
							Encoding.UTF8.GetString(Compressor.UnZip(zippedData));
						LocalizableParameterValuesList dataList =
							LocalizableParameterValuesList.DeserializeData(serializedData);
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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

			public OpenResheduledTaskEditPageUserTaskFlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
					return _recommendation ?? (_recommendation = GetLocalizableString("6aeeed315d8c452eb157ed9ad8b83e57",
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

			public UserQuestionUserTask1FlowElement(UserConnection userConnection, IncidentDiagnosticsAndResolving process)
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
						dataList.InitializeLocalizableValues(Storage, "6aeeed315d8c452eb157ed9ad8b83e57",
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
					return _question ?? (_question = GetLocalizableString("6aeeed315d8c452eb157ed9ad8b83e57",
						 "BaseElements.UserQuestionUserTask1.Parameters.Question.Value"));
				}
				set {
					_question = value;
				}
			}

			private LocalizableString _recommendation;
			public override LocalizableString Recommendation {
				get {
					return _recommendation ?? (_recommendation = GetLocalizableString("6aeeed315d8c452eb157ed9ad8b83e57",
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

			#endregion

			#region Methods: Public

			public override string GetResultAllowedValues() {
				return "[\"3fa4de2d-80ff-495a-b7c5-927d62fd5baa\",\"624264a7-1527-482e-a850-cf14eeda9305\"]";
			}

			#endregion

		}

		#endregion

		public IncidentDiagnosticsAndResolving(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "IncidentDiagnosticsAndResolving";
			SchemaUId = new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = true;
			SerializeToMemory = true;
			IsLogging = true;
			UseSystemSecurityContext = false;
			_processUId = () => { return (Guid)(Guid.Parse("6AEEED31-5D8C-452E-B157-ED9AD8B83E57")); };
			_isTaskExists = () => { return (bool)(false); };
			_notStartedActivityStatusId = () => { return (Guid)(new Guid("384d4b84-58e6-df11-971b-001d60e938c6")); };
			_taskCaption = () => { return new LocalizableString((TaskCaptionValue)); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6aeeed31-5d8c-452e-b157-ed9ad8b83e57");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: IncidentDiagnosticsAndResolving, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: IncidentDiagnosticsAndResolving, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

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
				return _taskCaptionValue ?? (_taskCaptionValue = GetLocalizableString("6aeeed315d8c452eb157ed9ad8b83e57",
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
			MetaPathParameterValues.Add("2693767a-5074-42b5-b438-00eecc753ddf", () => AddDiagnoseTask.ConsiderTimeInFilter);
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
			MetaPathParameterValues.Add("5a727670-17a9-45e0-a739-0f65fc0bd080", () => ReadCaseData.ResultCompositeObjectList);
			MetaPathParameterValues.Add("f952b674-3801-42b7-86b1-f25623dfeaeb", () => ReadCaseData.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("78f519cc-f8d2-4fac-9f87-2dc4c245ab29", () => ResolvedCatchSignal.RecordId);
			MetaPathParameterValues.Add("92796a3d-edaa-47bf-9730-0fb84a1bcb7f", () => ResolvedChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("69f7d295-e143-42e8-bb3c-c2f6f0421146", () => ResolvedChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("792c5022-ebba-44b5-955b-42c816843971", () => ResolvedChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("59ead31f-77ed-48f6-a880-82e8bb04a642", () => ResolvedChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("f54f4c78-60f1-449a-9601-358fc131b3a2", () => ResolvedChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("9e2aacd6-9c62-4726-94bc-1859bba3cced", () => CanceledCatchSignal.RecordId);
			MetaPathParameterValues.Add("183ecb6a-29e5-46cc-83dd-a8ec060bc191", () => CanceledChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("58ab220b-a239-4004-a8b3-362b8616d6b5", () => CanceledChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("cb23be2e-d56f-4c76-8277-bea8232dc232", () => CanceledChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("1546ad35-5335-436b-9a67-31666d57fea3", () => CanceledChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("0f14b785-7ed6-46c2-a054-1b40b0cdf754", () => CanceledChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("159c71ef-be09-4085-8d00-3c67a436bd4b", () => PendingCatchSignal.RecordId);
			MetaPathParameterValues.Add("9ceb65d0-c08f-4758-80c4-0eb931174b9b", () => PendingChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("2e50cca2-8933-4280-8cbf-18fdb137ab50", () => PendingChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("fa758883-6271-4b3c-bbfa-6cbee86d2b5b", () => PendingChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("95810b4e-5292-4018-a8df-b266bc723708", () => PendingChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("0bd93df7-dde6-4316-869d-ab5b8ddb37be", () => PendingChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("cc1f93c0-6974-4f8b-b1e8-6a819c4b21e9", () => EscalationCatchSignal.RecordId);
			MetaPathParameterValues.Add("da080b93-b78a-437a-adbc-9f4eee898cc5", () => EscalationChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("a94e00f8-50cc-4b2b-9d7e-3c846c8fe91d", () => EscalationChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("b03d7915-a2be-4918-8d0b-ca7e158f79e6", () => EscalationChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("ecc66875-1982-4fd7-99ab-6d047904b215", () => EscalationChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("1a7079ad-1f11-43e4-a861-de906c2749c4", () => EscalationChangeDataUserTask.ConsiderTimeInFilter);
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
			MetaPathParameterValues.Add("304b5d50-f28b-4aa7-96f5-bee147ac1599", () => ReadCaseCountDataUserTask.ResultCompositeObjectList);
			MetaPathParameterValues.Add("4bc2db2c-fcdc-4b63-a62f-cb65b0932d14", () => ReadCaseCountDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("99f2dd86-4eab-47c5-8ba2-01d496b9a3fb", () => CompleteTasksChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("6a09dbe4-c830-4973-9ba2-bee31e9f77f2", () => CompleteTasksChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("c8a7ec42-256a-40db-af79-d1e36121c71c", () => CompleteTasksChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("cbba51f0-1bbc-4cab-9bfd-7c94e372df30", () => CompleteTasksChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("11c4d1d4-2b34-4ebf-aabf-c8a0c4e0bae5", () => CompleteTasksChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("e21b52d3-db26-4e4e-8254-fcc14a5f7386", () => CancelTasksChangeDataUserTask.EntitySchemaUId);
			MetaPathParameterValues.Add("59deaa49-2d60-48b6-81d5-cecd7aaaf43b", () => CancelTasksChangeDataUserTask.IsMatchConditions);
			MetaPathParameterValues.Add("c590c5de-cb61-45ff-a24d-d8ee718c86e7", () => CancelTasksChangeDataUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("6c0bc164-4425-4e9d-abaf-b243259091c3", () => CancelTasksChangeDataUserTask.RecordColumnValues);
			MetaPathParameterValues.Add("4bdd4293-8899-4f41-91f1-e5613516fb81", () => CancelTasksChangeDataUserTask.ConsiderTimeInFilter);
			MetaPathParameterValues.Add("a46b9b07-561d-402a-bfce-8c12452a18d2", () => RescheduledCatchSignal.RecordId);
			MetaPathParameterValues.Add("92b7b385-b361-4426-aa17-35a191aa76c8", () => AddRescheduledTaskUserTask.EntitySchemaId);
			MetaPathParameterValues.Add("b7e1b44d-217e-4e2f-a90c-17a5ebf74c94", () => AddRescheduledTaskUserTask.DataSourceFilters);
			MetaPathParameterValues.Add("d5038619-45b6-440d-9cef-0b9bb2381b70", () => AddRescheduledTaskUserTask.RecordAddMode);
			MetaPathParameterValues.Add("c587e107-d285-4719-941f-a1aa76cdf30e", () => AddRescheduledTaskUserTask.FilterEntitySchemaId);
			MetaPathParameterValues.Add("2a49baff-f87a-4844-8d6e-503b3b93151b", () => AddRescheduledTaskUserTask.RecordDefValues);
			MetaPathParameterValues.Add("538e3867-2d16-4738-823f-530a3f2cd5a7", () => AddRescheduledTaskUserTask.RecordId);
			MetaPathParameterValues.Add("a09251e9-751e-4ef4-9254-83ed2ca16d14", () => AddRescheduledTaskUserTask.ConsiderTimeInFilter);
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
			MetaPathParameterValues.Add("bfd5bd69-9200-4555-9378-12ca5d68f3a8", () => OpenResheduledTaskEditPageUserTask.ActivityPriority);
			MetaPathParameterValues.Add("b7ea78b6-5287-47d3-8f10-bc466f99f8fa", () => OpenResheduledTaskEditPageUserTask.CreateActivity);
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
			MetaPathParameterValues.Add("ab4fc8eb-93b6-442a-bc87-91e9f406adfe", () => UserQuestionUserTask1.CreateActivity);
			MetaPathParameterValues.Add("6071a8e6-e279-405b-b5d3-38b429fbbe9c", () => UserQuestionUserTask1.ActivityPriority);
			MetaPathParameterValues.Add("3210c491-5bf8-4c44-809f-2ccea5bab678", () => UserQuestionUserTask1.ConfItem);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "UserQuestionUserTask1.ConfItem":
					UserQuestionUserTask1.ConfItem = reader.GetValue<System.Guid>();
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
			var cloneItem = (IncidentDiagnosticsAndResolving)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

