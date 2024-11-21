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

	#region Class: ForecastHistoryCellSchema

	/// <exclude/>
	public class ForecastHistoryCellSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastHistoryCellSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastHistoryCellSchema(ForecastHistoryCellSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastHistoryCellSchema(ForecastHistoryCellSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b");
			RealUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b");
			Name = "ForecastHistoryCell";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d07c15be-3f83-4fdc-a9ea-aad9ed069b01");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e33263d1-491e-4110-81ef-4bcb68ff268c")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("e983886b-73e5-485c-9b25-564622286970")) == null) {
				Columns.Add(CreateColumnColumn());
			}
			if (Columns.FindByUId(new Guid("e941104d-3920-4bf4-9317-bb6e227368f2")) == null) {
				Columns.Add(CreatePeriodColumn());
			}
			if (Columns.FindByUId(new Guid("325243da-fe03-41b4-b4b8-7e96083de088")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("501ab768-9d23-4322-81ff-00759048ffd8")) == null) {
				Columns.Add(CreateSnapshotColumn());
			}
			if (Columns.FindByUId(new Guid("f8e22883-c916-4f70-a32f-9fb16a9d763c")) == null) {
				Columns.Add(CreateSheetColumn());
			}
			if (Columns.FindByUId(new Guid("ba3dd07b-7a3f-4c26-b36f-3a2c75bf5074")) == null) {
				Columns.Add(CreateRowColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e33263d1-491e-4110-81ef-4bcb68ff268c"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e983886b-73e5-485c-9b25-564622286970"),
				Name = @"Column",
				ReferenceSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e941104d-3920-4bf4-9317-bb6e227368f2"),
				Name = @"Period",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("325243da-fe03-41b4-b4b8-7e96083de088"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSnapshotColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("501ab768-9d23-4322-81ff-00759048ffd8"),
				Name = @"Snapshot",
				ReferenceSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSheetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f8e22883-c916-4f70-a32f-9fb16a9d763c"),
				Name = @"Sheet",
				ReferenceSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateRowColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ba3dd07b-7a3f-4c26-b36f-3a2c75bf5074"),
				Name = @"Row",
				ReferenceSchemaUId = new Guid("01fb1058-f049-48ab-96fb-cbe5989efe01"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
				ModifiedInSchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"),
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
			return new ForecastHistoryCell(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastHistoryCell_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastHistoryCellSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastHistoryCellSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastHistoryCell

	/// <summary>
	/// Исторические данные ячеек планирования.
	/// </summary>
	public class ForecastHistoryCell : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastHistoryCell(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastHistoryCell";
		}

		public ForecastHistoryCell(ForecastHistoryCell source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Идентификатор сущности.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <exclude/>
		public Guid ColumnId {
			get {
				return GetTypedColumnValue<Guid>("ColumnId");
			}
			set {
				SetColumnValue("ColumnId", value);
				_column = null;
			}
		}

		/// <exclude/>
		public string ColumnTitle {
			get {
				return GetTypedColumnValue<string>("ColumnTitle");
			}
			set {
				SetColumnValue("ColumnTitle", value);
				if (_column != null) {
					_column.Title = value;
				}
			}
		}

		private ForecastColumn _column;
		/// <summary>
		/// Колонка планирования.
		/// </summary>
		public ForecastColumn Column {
			get {
				return _column ??
					(_column = LookupColumnEntities.GetEntity("Column") as ForecastColumn);
			}
		}

		/// <exclude/>
		public Guid PeriodId {
			get {
				return GetTypedColumnValue<Guid>("PeriodId");
			}
			set {
				SetColumnValue("PeriodId", value);
				_period = null;
			}
		}

		/// <exclude/>
		public string PeriodName {
			get {
				return GetTypedColumnValue<string>("PeriodName");
			}
			set {
				SetColumnValue("PeriodName", value);
				if (_period != null) {
					_period.Name = value;
				}
			}
		}

		private Period _period;
		/// <summary>
		/// Период.
		/// </summary>
		public Period Period {
			get {
				return _period ??
					(_period = LookupColumnEntities.GetEntity("Period") as Period);
			}
		}

		/// <summary>
		/// Значение.
		/// </summary>
		public Decimal Value {
			get {
				return GetTypedColumnValue<Decimal>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid SnapshotId {
			get {
				return GetTypedColumnValue<Guid>("SnapshotId");
			}
			set {
				SetColumnValue("SnapshotId", value);
				_snapshot = null;
			}
		}

		private ForecastSnapshot _snapshot;
		/// <summary>
		/// Слепок данных планирования.
		/// </summary>
		public ForecastSnapshot Snapshot {
			get {
				return _snapshot ??
					(_snapshot = LookupColumnEntities.GetEntity("Snapshot") as ForecastSnapshot);
			}
		}

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
		public Guid RowId {
			get {
				return GetTypedColumnValue<Guid>("RowId");
			}
			set {
				SetColumnValue("RowId", value);
				_row = null;
			}
		}

		private ForecastRow _row;
		/// <summary>
		/// Строка планирования.
		/// </summary>
		public ForecastRow Row {
			get {
				return _row ??
					(_row = LookupColumnEntities.GetEntity("Row") as ForecastRow);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastHistoryCell_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastHistoryCell(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastHistoryCell_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastHistoryCell_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastHistoryCell
	{

		public ForecastHistoryCell_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastHistoryCell_CoreForecastEventsProcess";
			SchemaUId = new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3a255ce3-be97-438f-bfc8-c5c20d9afa3b");
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

	#region Class: ForecastHistoryCell_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastHistoryCell_CoreForecastEventsProcess : ForecastHistoryCell_CoreForecastEventsProcess<ForecastHistoryCell>
	{

		public ForecastHistoryCell_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastHistoryCell_CoreForecastEventsProcess

	public partial class ForecastHistoryCell_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastHistoryCellEventsProcess

	/// <exclude/>
	public class ForecastHistoryCellEventsProcess : ForecastHistoryCell_CoreForecastEventsProcess
	{

		public ForecastHistoryCellEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

