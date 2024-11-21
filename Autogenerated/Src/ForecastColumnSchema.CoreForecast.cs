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

	#region Class: ForecastColumnSchema

	/// <exclude/>
	public class ForecastColumnSchema : BPMSoft.Configuration.BaseEntityWithPositionSchema
	{

		#region Constructors: Public

		public ForecastColumnSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastColumnSchema(ForecastColumnSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastColumnSchema(ForecastColumnSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d");
			RealUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d");
			Name = "ForecastColumn";
			ParentSchemaUId = new Guid("73d33bed-4682-45cb-ad25-a29b5ab88c96");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateSheetColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7e0f01d8-2a05-4f68-aaa7-5d4a31a988a2")) == null) {
				Columns.Add(CreateIndicatorColumn());
			}
			if (Columns.FindByUId(new Guid("4e1b5056-a250-45bc-baf5-743f632644cf")) == null) {
				Columns.Add(CreateSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("df4002ec-7efa-4d3f-8214-b42bff6def2e")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("e28b7cde-7e8f-4ca5-8bea-b9a3bccb6bf7")) == null) {
				Columns.Add(CreateIsHideColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSheetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5157b14b-d02d-4b41-b7f6-7fbbfdf32b96"),
				Name = @"Sheet",
				ReferenceSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				ModifiedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateIndicatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7e0f01d8-2a05-4f68-aaa7-5d4a31a988a2"),
				Name = @"Indicator",
				ReferenceSchemaUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				ModifiedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4e1b5056-a250-45bc-baf5-743f632644cf"),
				Name = @"Settings",
				CreatedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				ModifiedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("df4002ec-7efa-4d3f-8214-b42bff6def2e"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("afa4fe55-a6da-4b54-b24b-ad6c53b5b173"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				ModifiedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("40a2ff37-c69e-4c9a-85fb-9b5e8a568706"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				ModifiedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsHideColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e28b7cde-7e8f-4ca5-8bea-b9a3bccb6bf7"),
				Name = @"IsHide",
				CreatedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				ModifiedInSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ForecastColumn(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastColumn_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastColumnSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastColumnSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastColumn

	/// <summary>
	/// Колонка планирования.
	/// </summary>
	public class ForecastColumn : BPMSoft.Configuration.BaseEntityWithPosition
	{

		#region Constructors: Public

		public ForecastColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastColumn";
		}

		public ForecastColumn(ForecastColumn source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SheetId {
			get {
				return GetTypedColumnValue<Guid>("SheetId");
			}
			set {
				SetColumnValue("SheetId", value);
				_sheet = null;
			}
		}

		/// <exclude/>
		public string SheetName {
			get {
				return GetTypedColumnValue<string>("SheetName");
			}
			set {
				SetColumnValue("SheetName", value);
				if (_sheet != null) {
					_sheet.Name = value;
				}
			}
		}

		private ForecastSheet _sheet;
		/// <summary>
		/// Лист планирования.
		/// </summary>
		public ForecastSheet Sheet {
			get {
				return _sheet ??
					(_sheet = LookupColumnEntities.GetEntity("Sheet") as ForecastSheet);
			}
		}

		/// <exclude/>
		public Guid IndicatorId {
			get {
				return GetTypedColumnValue<Guid>("IndicatorId");
			}
			set {
				SetColumnValue("IndicatorId", value);
				_indicator = null;
			}
		}

		/// <exclude/>
		public string IndicatorName {
			get {
				return GetTypedColumnValue<string>("IndicatorName");
			}
			set {
				SetColumnValue("IndicatorName", value);
				if (_indicator != null) {
					_indicator.Name = value;
				}
			}
		}

		private ForecastIndicator _indicator;
		/// <summary>
		/// Показатель планирования.
		/// </summary>
		public ForecastIndicator Indicator {
			get {
				return _indicator ??
					(_indicator = LookupColumnEntities.GetEntity("Indicator") as ForecastIndicator);
			}
		}

		/// <summary>
		/// Настройки колонки.
		/// </summary>
		public string Settings {
			get {
				return GetTypedColumnValue<string>("Settings");
			}
			set {
				SetColumnValue("Settings", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ForecastColumnType _type;
		/// <summary>
		/// Тип колонки.
		/// </summary>
		public ForecastColumnType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ForecastColumnType);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Скрывать колонку.
		/// </summary>
		public bool IsHide {
			get {
				return GetTypedColumnValue<bool>("IsHide");
			}
			set {
				SetColumnValue("IsHide", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastColumn_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastColumn(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastColumn_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastColumn_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityWithPosition_BaseEventsProcess<TEntity> where TEntity : ForecastColumn
	{

		public ForecastColumn_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastColumn_CoreForecastEventsProcess";
			SchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("321d7bc3-45fe-41f8-af38-6643602b116d");
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

	#region Class: ForecastColumn_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastColumn_CoreForecastEventsProcess : ForecastColumn_CoreForecastEventsProcess<ForecastColumn>
	{

		public ForecastColumn_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastColumn_CoreForecastEventsProcess

	public partial class ForecastColumn_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		public override EntitySchemaQueryFilterCollection GetDetailFilter(Entity entity, EntitySchemaQuery esq) {
			EntitySchemaQueryFilterCollection filtersGroup = base.GetDetailFilter(entity, esq);
			Guid sheetId = entity.GetTypedColumnValue<Guid>("SheetId");
			if (filtersGroup == null) {
				filtersGroup = new EntitySchemaQueryFilterCollection(esq);
			}
			filtersGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", sheetId));
			return filtersGroup;
		}

		#endregion

	}

	#endregion


	#region Class: ForecastColumnEventsProcess

	/// <exclude/>
	public class ForecastColumnEventsProcess : ForecastColumn_CoreForecastEventsProcess
	{

		public ForecastColumnEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

