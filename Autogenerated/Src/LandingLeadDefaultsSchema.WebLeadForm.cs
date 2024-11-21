namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: LandingLeadDefaultsSchema

	/// <exclude/>
	public class LandingLeadDefaultsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LandingLeadDefaultsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LandingLeadDefaultsSchema(LandingLeadDefaultsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LandingLeadDefaultsSchema(LandingLeadDefaultsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a");
			RealUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a");
			Name = "LandingLeadDefaults";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2cebfd9b-fa03-4242-8ecd-21cd2ca5b8ba");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateDisplayValueColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fcf2f5a1-d285-4f07-812e-1d2fb20d0388")) == null) {
				Columns.Add(CreateLandingColumn());
			}
			if (Columns.FindByUId(new Guid("60e8a89c-c7d6-471c-bd11-0404c42b77d5")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("f7263c94-1955-4e73-970b-6a202e3111c6")) == null) {
				Columns.Add(CreateColumnCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("2a8720f7-f29e-41ac-b88e-7e09663d0eaf")) == null) {
				Columns.Add(CreateGuidValueColumn());
			}
			if (Columns.FindByUId(new Guid("7ab20ae8-54c3-41b4-97f1-cdc62b1a0b79")) == null) {
				Columns.Add(CreateTextValueColumn());
			}
			if (Columns.FindByUId(new Guid("93abdf96-9e69-4c5e-acf7-e0dcf4c06a63")) == null) {
				Columns.Add(CreateIntegerValueColumn());
			}
			if (Columns.FindByUId(new Guid("4d3ff9f8-4304-4016-8e8f-45e204121ae8")) == null) {
				Columns.Add(CreateFloatValueColumn());
			}
			if (Columns.FindByUId(new Guid("873b4167-30f1-4bac-806a-fe8aa9ba0950")) == null) {
				Columns.Add(CreateBooleanValueColumn());
			}
			if (Columns.FindByUId(new Guid("5498d00f-8fb9-48e5-b9fe-d8d149012763")) == null) {
				Columns.Add(CreateDateTimeValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLandingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fcf2f5a1-d285-4f07-812e-1d2fb20d0388"),
				Name = @"Landing",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("2cebfd9b-fa03-4242-8ecd-21cd2ca5b8ba")
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("3fc79c7c-ddd6-4839-9ed4-c791481a2f02"),
				Name = @"DisplayValue",
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("202cd6f4-4bd7-46f3-ba65-b53cf8adb6f1")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("60e8a89c-c7d6-471c-bd11-0404c42b77d5"),
				Name = @"ColumnUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("2cebfd9b-fa03-4242-8ecd-21cd2ca5b8ba")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f7263c94-1955-4e73-970b-6a202e3111c6"),
				Name = @"ColumnCaption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("2cebfd9b-fa03-4242-8ecd-21cd2ca5b8ba")
			};
		}

		protected virtual EntitySchemaColumn CreateGuidValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2a8720f7-f29e-41ac-b88e-7e09663d0eaf"),
				Name = @"GuidValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("e3031532-a059-4130-8d2e-6bdf35a52945")
			};
		}

		protected virtual EntitySchemaColumn CreateTextValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7ab20ae8-54c3-41b4-97f1-cdc62b1a0b79"),
				Name = @"TextValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("202cd6f4-4bd7-46f3-ba65-b53cf8adb6f1")
			};
		}

		protected virtual EntitySchemaColumn CreateIntegerValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("93abdf96-9e69-4c5e-acf7-e0dcf4c06a63"),
				Name = @"IntegerValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("202cd6f4-4bd7-46f3-ba65-b53cf8adb6f1")
			};
		}

		protected virtual EntitySchemaColumn CreateFloatValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("4d3ff9f8-4304-4016-8e8f-45e204121ae8"),
				Name = @"FloatValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("202cd6f4-4bd7-46f3-ba65-b53cf8adb6f1")
			};
		}

		protected virtual EntitySchemaColumn CreateBooleanValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("873b4167-30f1-4bac-806a-fe8aa9ba0950"),
				Name = @"BooleanValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("202cd6f4-4bd7-46f3-ba65-b53cf8adb6f1")
			};
		}

		protected virtual EntitySchemaColumn CreateDateTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("5498d00f-8fb9-48e5-b9fe-d8d149012763"),
				Name = @"DateTimeValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				ModifiedInSchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"),
				CreatedInPackageId = new Guid("202cd6f4-4bd7-46f3-ba65-b53cf8adb6f1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LandingLeadDefaults(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LandingLeadDefaults_WebLeadFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LandingLeadDefaultsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LandingLeadDefaultsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a"));
		}

		#endregion

	}

	#endregion

	#region Class: LandingLeadDefaults

	/// <summary>
	/// Значения полей лида по умолчанию.
	/// </summary>
	public class LandingLeadDefaults : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LandingLeadDefaults(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LandingLeadDefaults";
		}

		public LandingLeadDefaults(LandingLeadDefaults source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LandingId {
			get {
				return GetTypedColumnValue<Guid>("LandingId");
			}
			set {
				SetColumnValue("LandingId", value);
				_landing = null;
			}
		}

		/// <exclude/>
		public string LandingName {
			get {
				return GetTypedColumnValue<string>("LandingName");
			}
			set {
				SetColumnValue("LandingName", value);
				if (_landing != null) {
					_landing.Name = value;
				}
			}
		}

		private GeneratedWebForm _landing;
		/// <summary>
		/// Лендинг.
		/// </summary>
		public GeneratedWebForm Landing {
			get {
				return _landing ??
					(_landing = LookupColumnEntities.GetEntity("Landing") as GeneratedWebForm);
			}
		}

		/// <summary>
		/// Значение.
		/// </summary>
		public string DisplayValue {
			get {
				return GetTypedColumnValue<string>("DisplayValue");
			}
			set {
				SetColumnValue("DisplayValue", value);
			}
		}

		/// <summary>
		/// UId поля лида.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Поле лида.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		/// <summary>
		/// Значение справочной колонки.
		/// </summary>
		public Guid GuidValue {
			get {
				return GetTypedColumnValue<Guid>("GuidValue");
			}
			set {
				SetColumnValue("GuidValue", value);
			}
		}

		/// <summary>
		/// TextValue.
		/// </summary>
		public string TextValue {
			get {
				return GetTypedColumnValue<string>("TextValue");
			}
			set {
				SetColumnValue("TextValue", value);
			}
		}

		/// <summary>
		/// IntegerValue.
		/// </summary>
		public int IntegerValue {
			get {
				return GetTypedColumnValue<int>("IntegerValue");
			}
			set {
				SetColumnValue("IntegerValue", value);
			}
		}

		/// <summary>
		/// FloatValue.
		/// </summary>
		public Decimal FloatValue {
			get {
				return GetTypedColumnValue<Decimal>("FloatValue");
			}
			set {
				SetColumnValue("FloatValue", value);
			}
		}

		/// <summary>
		/// BooleanValue.
		/// </summary>
		public bool BooleanValue {
			get {
				return GetTypedColumnValue<bool>("BooleanValue");
			}
			set {
				SetColumnValue("BooleanValue", value);
			}
		}

		/// <summary>
		/// DateTimeValue.
		/// </summary>
		public DateTime DateTimeValue {
			get {
				return GetTypedColumnValue<DateTime>("DateTimeValue");
			}
			set {
				SetColumnValue("DateTimeValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LandingLeadDefaults_WebLeadFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LandingLeadDefaultsDeleted", e);
			Validating += (s, e) => ThrowEvent("LandingLeadDefaultsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LandingLeadDefaults(this);
		}

		#endregion

	}

	#endregion

	#region Class: LandingLeadDefaults_WebLeadFormEventsProcess

	/// <exclude/>
	public partial class LandingLeadDefaults_WebLeadFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LandingLeadDefaults
	{

		public LandingLeadDefaults_WebLeadFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LandingLeadDefaults_WebLeadFormEventsProcess";
			SchemaUId = new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffb1d52b-8389-47ce-b239-0e3cb713c56a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: LandingLeadDefaults_WebLeadFormEventsProcess

	/// <exclude/>
	public class LandingLeadDefaults_WebLeadFormEventsProcess : LandingLeadDefaults_WebLeadFormEventsProcess<LandingLeadDefaults>
	{

		public LandingLeadDefaults_WebLeadFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LandingLeadDefaults_WebLeadFormEventsProcess

	public partial class LandingLeadDefaults_WebLeadFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LandingLeadDefaultsEventsProcess

	/// <exclude/>
	public class LandingLeadDefaultsEventsProcess : LandingLeadDefaults_WebLeadFormEventsProcess
	{

		public LandingLeadDefaultsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

