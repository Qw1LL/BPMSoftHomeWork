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

	#region Class: ForecastHistDrilldownSchema

	/// <exclude/>
	public class ForecastHistDrilldownSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastHistDrilldownSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastHistDrilldownSchema(ForecastHistDrilldownSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastHistDrilldownSchema(ForecastHistDrilldownSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac");
			RealUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac");
			Name = "ForecastHistDrilldown";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e6bfecae-a833-9e0f-5424-a683b32a0f0e")) == null) {
				Columns.Add(CreateDeletedOnColumn());
			}
			if (Columns.FindByUId(new Guid("bcc6ad53-abde-5966-cdce-e80bf14370c5")) == null) {
				Columns.Add(CreateSnapshotColumn());
			}
			if (Columns.FindByUId(new Guid("eb777a75-3cff-86dd-e6d8-a64c40ef56f7")) == null) {
				Columns.Add(CreateEntityDisplayValueColumn());
			}
			if (Columns.FindByUId(new Guid("66d37ead-7e44-7c50-63ab-664fb2d27581")) == null) {
				Columns.Add(CreateRefEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("c0b61af4-d1b8-4cef-0cf9-02977bd296d2")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("cd64cd6e-b55d-0c98-cfb8-e6b65a90f8a4")) == null) {
				Columns.Add(CreatePeriodColumn());
			}
			if (Columns.FindByUId(new Guid("0ee2f18b-35bd-2dc7-66a6-b1693bff01d7")) == null) {
				Columns.Add(CreateColumnColumn());
			}
			if (Columns.FindByUId(new Guid("c4aa693e-818c-cc0c-9d62-7a80408692c3")) == null) {
				Columns.Add(CreateValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDeletedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e6bfecae-a833-9e0f-5424-a683b32a0f0e"),
				Name = @"DeletedOn",
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSnapshotColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bcc6ad53-abde-5966-cdce-e80bf14370c5"),
				Name = @"Snapshot",
				ReferenceSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityDisplayValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("eb777a75-3cff-86dd-e6d8-a64c40ef56f7"),
				Name = @"EntityDisplayValue",
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateRefEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("66d37ead-7e44-7c50-63ab-664fb2d27581"),
				Name = @"RefEntityId",
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c0b61af4-d1b8-4cef-0cf9-02977bd296d2"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cd64cd6e-b55d-0c98-cfb8-e6b65a90f8a4"),
				Name = @"Period",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0ee2f18b-35bd-2dc7-66a6-b1693bff01d7"),
				Name = @"Column",
				ReferenceSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c4aa693e-818c-cc0c-9d62-7a80408692c3"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
				ModifiedInSchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"),
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
			return new ForecastHistDrilldown(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastHistDrilldown_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastHistDrilldownSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastHistDrilldownSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91e9246b-3256-19c6-1751-831c815fb4ac"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastHistDrilldown

	/// <summary>
	/// ForecastHistDrilldown.
	/// </summary>
	public class ForecastHistDrilldown : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastHistDrilldown(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastHistDrilldown";
		}

		public ForecastHistDrilldown(ForecastHistDrilldown source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Дата удаления.
		/// </summary>
		public DateTime DeletedOn {
			get {
				return GetTypedColumnValue<DateTime>("DeletedOn");
			}
			set {
				SetColumnValue("DeletedOn", value);
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

		/// <summary>
		/// Заголовок объекта сущности.
		/// </summary>
		public string EntityDisplayValue {
			get {
				return GetTypedColumnValue<string>("EntityDisplayValue");
			}
			set {
				SetColumnValue("EntityDisplayValue", value);
			}
		}

		/// <summary>
		/// Идентификатор ссылочной записи.
		/// </summary>
		public Guid RefEntityId {
			get {
				return GetTypedColumnValue<Guid>("RefEntityId");
			}
			set {
				SetColumnValue("RefEntityId", value);
			}
		}

		/// <summary>
		/// Идентификатор записи.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastHistDrilldown_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastHistDrilldown(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastHistDrilldown_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastHistDrilldown_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastHistDrilldown
	{

		public ForecastHistDrilldown_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastHistDrilldown_CoreForecastEventsProcess";
			SchemaUId = new Guid("91e9246b-3256-19c6-1751-831c815fb4ac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("91e9246b-3256-19c6-1751-831c815fb4ac");
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

	#region Class: ForecastHistDrilldown_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastHistDrilldown_CoreForecastEventsProcess : ForecastHistDrilldown_CoreForecastEventsProcess<ForecastHistDrilldown>
	{

		public ForecastHistDrilldown_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastHistDrilldown_CoreForecastEventsProcess

	public partial class ForecastHistDrilldown_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastHistDrilldownEventsProcess

	/// <exclude/>
	public class ForecastHistDrilldownEventsProcess : ForecastHistDrilldown_CoreForecastEventsProcess
	{

		public ForecastHistDrilldownEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

