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

	#region Class: ForecastHistoryRowSchema

	/// <exclude/>
	public class ForecastHistoryRowSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastHistoryRowSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastHistoryRowSchema(ForecastHistoryRowSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastHistoryRowSchema(ForecastHistoryRowSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d");
			RealUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d");
			Name = "ForecastHistoryRow";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ec0fd031-f3ca-461d-8a00-3cbda62b70a2")) == null) {
				Columns.Add(CreateRowColumn());
			}
			if (Columns.FindByUId(new Guid("cc05978d-c53d-4c04-8b99-0ceed885f632")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("abe7f661-57da-4da2-982f-9518fb738d6d")) == null) {
				Columns.Add(CreateSnapshotColumn());
			}
			if (Columns.FindByUId(new Guid("032c6b5b-1683-4e7c-b335-50523be296bf")) == null) {
				Columns.Add(CreateDeletedOnColumn());
			}
			if (Columns.FindByUId(new Guid("d25a5e95-d488-480c-aaa4-69563193f022")) == null) {
				Columns.Add(CreateSheetColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRowColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ec0fd031-f3ca-461d-8a00-3cbda62b70a2"),
				Name = @"Row",
				ReferenceSchemaUId = new Guid("01fb1058-f049-48ab-96fb-cbe5989efe01"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				ModifiedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cc05978d-c53d-4c04-8b99-0ceed885f632"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				ModifiedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSnapshotColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("abe7f661-57da-4da2-982f-9518fb738d6d"),
				Name = @"Snapshot",
				ReferenceSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				ModifiedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateDeletedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("032c6b5b-1683-4e7c-b335-50523be296bf"),
				Name = @"DeletedOn",
				CreatedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				ModifiedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSheetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d25a5e95-d488-480c-aaa4-69563193f022"),
				Name = @"Sheet",
				ReferenceSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
				ModifiedInSchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"),
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
			return new ForecastHistoryRow(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastHistoryRow_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastHistoryRowSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastHistoryRowSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastHistoryRow

	/// <summary>
	/// Исторические данные строк планирования.
	/// </summary>
	public class ForecastHistoryRow : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastHistoryRow(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastHistoryRow";
		}

		public ForecastHistoryRow(ForecastHistoryRow source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Forecast row.
		/// </summary>
		public ForecastRow Row {
			get {
				return _row ??
					(_row = LookupColumnEntities.GetEntity("Row") as ForecastRow);
			}
		}

		/// <summary>
		/// Entity identifier.
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
		/// Forecast snapshot.
		/// </summary>
		public ForecastSnapshot Snapshot {
			get {
				return _snapshot ??
					(_snapshot = LookupColumnEntities.GetEntity("Snapshot") as ForecastSnapshot);
			}
		}

		/// <summary>
		/// Deleted On.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastHistoryRow_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastHistoryRow(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastHistoryRow_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastHistoryRow_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastHistoryRow
	{

		public ForecastHistoryRow_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastHistoryRow_CoreForecastEventsProcess";
			SchemaUId = new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2c9152db-7e16-4e71-b2f1-2def7672640d");
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

	#region Class: ForecastHistoryRow_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastHistoryRow_CoreForecastEventsProcess : ForecastHistoryRow_CoreForecastEventsProcess<ForecastHistoryRow>
	{

		public ForecastHistoryRow_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastHistoryRow_CoreForecastEventsProcess

	public partial class ForecastHistoryRow_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastHistoryRowEventsProcess

	/// <exclude/>
	public class ForecastHistoryRowEventsProcess : ForecastHistoryRow_CoreForecastEventsProcess
	{

		public ForecastHistoryRowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

