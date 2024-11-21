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

	#region Class: MLModelColumnSchema

	/// <exclude/>
	public class MLModelColumnSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MLModelColumnSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLModelColumnSchema(MLModelColumnSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLModelColumnSchema(MLModelColumnSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f");
			RealUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f");
			Name = "MLModelColumn";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dcca97db-652a-4afb-840e-08623a93f005")) == null) {
				Columns.Add(CreateMLModelColumn());
			}
			if (Columns.FindByUId(new Guid("388723d0-246c-41de-a78e-9fb562da862b")) == null) {
				Columns.Add(CreateColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("9b8345bc-323d-451b-b55f-2ba299f61621")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("6a613ade-2bb3-4592-bf0c-898357e3da9d")) == null) {
				Columns.Add(CreateColumnPathColumn());
			}
			if (Columns.FindByUId(new Guid("c59af29a-aa17-4c70-bf89-545b80c954de")) == null) {
				Columns.Add(CreateAggregationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("271f9f4a-8199-4727-939b-736399e8fc1a")) == null) {
				Columns.Add(CreateSubFiltersColumn());
			}
			if (Columns.FindByUId(new Guid("a2117463-9526-cb4d-90c9-88202e5c6eee")) == null) {
				Columns.Add(CreateColumnTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMLModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dcca97db-652a-4afb-840e-08623a93f005"),
				Name = @"MLModel",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("388723d0-246c-41de-a78e-9fb562da862b"),
				Name = @"ColumnUId",
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("9b8345bc-323d-451b-b55f-2ba299f61621"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateColumnPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6a613ade-2bb3-4592-bf0c-898357e3da9d"),
				Name = @"ColumnPath",
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("cad98641-0ee5-4173-9c03-6ef86b0857c5")
			};
		}

		protected virtual EntitySchemaColumn CreateAggregationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c59af29a-aa17-4c70-bf89-545b80c954de"),
				Name = @"AggregationType",
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f")
			};
		}

		protected virtual EntitySchemaColumn CreateSubFiltersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("271f9f4a-8199-4727-939b-736399e8fc1a"),
				Name = @"SubFilters",
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("73704ec6-562c-4400-8a4a-17477a18625f")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a2117463-9526-cb4d-90c9-88202e5c6eee"),
				Name = @"ColumnType",
				ReferenceSchemaUId = new Guid("cd028dd3-6f53-10d3-345f-cd38863ae5d4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				ModifiedInSchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"),
				CreatedInPackageId = new Guid("cad98641-0ee5-4173-9c03-6ef86b0857c5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLModelColumn(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLModelColumn_MLEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLModelColumnSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLModelColumnSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("209a40fb-5688-4207-a88e-dc4a1042117f"));
		}

		#endregion

	}

	#endregion

	#region Class: MLModelColumn

	/// <summary>
	/// ML model column.
	/// </summary>
	public class MLModelColumn : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MLModelColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLModelColumn";
		}

		public MLModelColumn(MLModelColumn source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MLModelId {
			get {
				return GetTypedColumnValue<Guid>("MLModelId");
			}
			set {
				SetColumnValue("MLModelId", value);
				_mLModel = null;
			}
		}

		/// <exclude/>
		public string MLModelName {
			get {
				return GetTypedColumnValue<string>("MLModelName");
			}
			set {
				SetColumnValue("MLModelName", value);
				if (_mLModel != null) {
					_mLModel.Name = value;
				}
			}
		}

		private MLModel _mLModel;
		/// <summary>
		/// Model.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = LookupColumnEntities.GetEntity("MLModel") as MLModel);
			}
		}

		/// <summary>
		/// Column identifier.
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
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Column path.
		/// </summary>
		public string ColumnPath {
			get {
				return GetTypedColumnValue<string>("ColumnPath");
			}
			set {
				SetColumnValue("ColumnPath", value);
			}
		}

		/// <summary>
		/// AggregationType.
		/// </summary>
		public int AggregationType {
			get {
				return GetTypedColumnValue<int>("AggregationType");
			}
			set {
				SetColumnValue("AggregationType", value);
			}
		}

		/// <summary>
		/// Sub-filters.
		/// </summary>
		public string SubFilters {
			get {
				return GetTypedColumnValue<string>("SubFilters");
			}
			set {
				SetColumnValue("SubFilters", value);
			}
		}

		/// <exclude/>
		public Guid ColumnTypeId {
			get {
				return GetTypedColumnValue<Guid>("ColumnTypeId");
			}
			set {
				SetColumnValue("ColumnTypeId", value);
				_columnType = null;
			}
		}

		/// <exclude/>
		public string ColumnTypeName {
			get {
				return GetTypedColumnValue<string>("ColumnTypeName");
			}
			set {
				SetColumnValue("ColumnTypeName", value);
				if (_columnType != null) {
					_columnType.Name = value;
				}
			}
		}

		private MLModelColumnType _columnType;
		/// <summary>
		/// Column type.
		/// </summary>
		public MLModelColumnType ColumnType {
			get {
				return _columnType ??
					(_columnType = LookupColumnEntities.GetEntity("ColumnType") as MLModelColumnType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLModelColumn_MLEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLModelColumn(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLModelColumn_MLEventsProcess

	/// <exclude/>
	public partial class MLModelColumn_MLEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MLModelColumn
	{

		public MLModelColumn_MLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLModelColumn_MLEventsProcess";
			SchemaUId = new Guid("209a40fb-5688-4207-a88e-dc4a1042117f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("209a40fb-5688-4207-a88e-dc4a1042117f");
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

	#region Class: MLModelColumn_MLEventsProcess

	/// <exclude/>
	public class MLModelColumn_MLEventsProcess : MLModelColumn_MLEventsProcess<MLModelColumn>
	{

		public MLModelColumn_MLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLModelColumn_MLEventsProcess

	public partial class MLModelColumn_MLEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLModelColumnEventsProcess

	/// <exclude/>
	public class MLModelColumnEventsProcess : MLModelColumn_MLEventsProcess
	{

		public MLModelColumnEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

