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

	#region Class: LandingObjectDefaultsSchema

	/// <exclude/>
	public class LandingObjectDefaultsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LandingObjectDefaultsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LandingObjectDefaultsSchema(LandingObjectDefaultsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LandingObjectDefaultsSchema(LandingObjectDefaultsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateINYx9Ypgk5bz0pYaqPU08JGd3f8Index() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d3ef85f5-87ae-427d-ab18-c2f9be0b416a");
			index.Name = "INYx9Ypgk5bz0pYaqPU08JGd3f8";
			index.CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc");
			index.ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc");
			index.CreatedInPackageId = new Guid("91507ba4-1e7b-4fdd-954f-ec66d764e88d");
			EntitySchemaIndexColumn guidValueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3035c483-23a9-4a51-8c93-e2ce7bc80de2"),
				ColumnUId = new Guid("62da44b9-376d-4bfe-8a85-b0e89bb20cd6"),
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("91507ba4-1e7b-4fdd-954f-ec66d764e88d"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(guidValueIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc");
			RealUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc");
			Name = "LandingObjectDefaults";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bc8ea26d-108b-457e-ad6c-a8e44f21774c")) == null) {
				Columns.Add(CreateLandingColumn());
			}
			if (Columns.FindByUId(new Guid("42085559-ac54-4061-b0dd-8886f63a1320")) == null) {
				Columns.Add(CreateDisplayValueColumn());
			}
			if (Columns.FindByUId(new Guid("51c012a4-8568-4775-9682-3781d5d608c7")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("3ba9355c-1ab5-44f9-bd07-5b20c8327a31")) == null) {
				Columns.Add(CreateColumnCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("62da44b9-376d-4bfe-8a85-b0e89bb20cd6")) == null) {
				Columns.Add(CreateGuidValueColumn());
			}
			if (Columns.FindByUId(new Guid("8a9768bb-65c0-4282-8d51-425e472ceae6")) == null) {
				Columns.Add(CreateTextValueColumn());
			}
			if (Columns.FindByUId(new Guid("ea572b49-ed6a-43db-a2be-d65d046726ae")) == null) {
				Columns.Add(CreateIntegerValueColumn());
			}
			if (Columns.FindByUId(new Guid("366a8e23-807a-4093-9be6-732e51191f7f")) == null) {
				Columns.Add(CreateFloatValueColumn());
			}
			if (Columns.FindByUId(new Guid("8867f237-62d1-4645-a513-6b896810ebd8")) == null) {
				Columns.Add(CreateBooleanValueColumn());
			}
			if (Columns.FindByUId(new Guid("72963087-d24c-4812-9923-16ee8536bcfb")) == null) {
				Columns.Add(CreateDateTimeValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLandingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bc8ea26d-108b-457e-ad6c-a8e44f21774c"),
				Name = @"Landing",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("42085559-ac54-4061-b0dd-8886f63a1320"),
				Name = @"DisplayValue",
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("51c012a4-8568-4775-9682-3781d5d608c7"),
				Name = @"ColumnUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("3ba9355c-1ab5-44f9-bd07-5b20c8327a31"),
				Name = @"ColumnCaption",
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateGuidValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("62da44b9-376d-4bfe-8a85-b0e89bb20cd6"),
				Name = @"GuidValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateTextValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8a9768bb-65c0-4282-8d51-425e472ceae6"),
				Name = @"TextValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateIntegerValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ea572b49-ed6a-43db-a2be-d65d046726ae"),
				Name = @"IntegerValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateFloatValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("366a8e23-807a-4093-9be6-732e51191f7f"),
				Name = @"FloatValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateBooleanValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8867f237-62d1-4645-a513-6b896810ebd8"),
				Name = @"BooleanValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected virtual EntitySchemaColumn CreateDateTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("72963087-d24c-4812-9923-16ee8536bcfb"),
				Name = @"DateTimeValue",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				ModifiedInSchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"),
				CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateINYx9Ypgk5bz0pYaqPU08JGd3f8Index());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LandingObjectDefaults(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LandingObjectDefaults_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LandingObjectDefaultsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LandingObjectDefaultsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc"));
		}

		#endregion

	}

	#endregion

	#region Class: LandingObjectDefaults

	/// <summary>
	/// Default values for the object fields.
	/// </summary>
	public class LandingObjectDefaults : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LandingObjectDefaults(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LandingObjectDefaults";
		}

		public LandingObjectDefaults(LandingObjectDefaults source)
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
		/// Landing.
		/// </summary>
		public GeneratedWebForm Landing {
			get {
				return _landing ??
					(_landing = LookupColumnEntities.GetEntity("Landing") as GeneratedWebForm);
			}
		}

		/// <summary>
		/// Value.
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
		/// Field UId.
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
		/// Field.
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
		/// Lookup column value.
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
		/// Text value.
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
		/// Integer value.
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
		/// Float value.
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
		/// Boolean value.
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
		/// DateTime value.
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
			var process = new LandingObjectDefaults_WebFormEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LandingObjectDefaultsDeleted", e);
			Validating += (s, e) => ThrowEvent("LandingObjectDefaultsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LandingObjectDefaults(this);
		}

		#endregion

	}

	#endregion

	#region Class: LandingObjectDefaults_WebFormEventsProcess

	/// <exclude/>
	public partial class LandingObjectDefaults_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LandingObjectDefaults
	{

		public LandingObjectDefaults_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LandingObjectDefaults_WebFormEventsProcess";
			SchemaUId = new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("53c5ad19-3faf-4a01-97bc-17c9c817fcbc");
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

	#region Class: LandingObjectDefaults_WebFormEventsProcess

	/// <exclude/>
	public class LandingObjectDefaults_WebFormEventsProcess : LandingObjectDefaults_WebFormEventsProcess<LandingObjectDefaults>
	{

		public LandingObjectDefaults_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LandingObjectDefaults_WebFormEventsProcess

	public partial class LandingObjectDefaults_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LandingObjectDefaultsEventsProcess

	/// <exclude/>
	public class LandingObjectDefaultsEventsProcess : LandingObjectDefaults_WebFormEventsProcess
	{

		public LandingObjectDefaultsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

