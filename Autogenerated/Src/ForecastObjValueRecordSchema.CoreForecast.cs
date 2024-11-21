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

	#region Class: ForecastObjValueRecordSchema

	/// <exclude/>
	public class ForecastObjValueRecordSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastObjValueRecordSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastObjValueRecordSchema(ForecastObjValueRecordSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastObjValueRecordSchema(ForecastObjValueRecordSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8");
			RealUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8");
			Name = "ForecastObjValueRecord";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4839e315-346e-61e1-9544-da9464379656")) == null) {
				Columns.Add(CreateRefEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("a11ef22a-ab21-7db7-0fba-cc72c00fc4f6")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("e71cd81e-3f6d-8558-5820-b6c18a8bca42")) == null) {
				Columns.Add(CreatePeriodColumn());
			}
			if (Columns.FindByUId(new Guid("046c03c5-3adf-978d-a9f6-399ee11e3393")) == null) {
				Columns.Add(CreateColumnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRefEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4839e315-346e-61e1-9544-da9464379656"),
				Name = @"RefEntityId",
				CreatedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				ModifiedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a11ef22a-ab21-7db7-0fba-cc72c00fc4f6"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				ModifiedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e71cd81e-3f6d-8558-5820-b6c18a8bca42"),
				Name = @"Period",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				ModifiedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("046c03c5-3adf-978d-a9f6-399ee11e3393"),
				Name = @"Column",
				ReferenceSchemaUId = new Guid("321d7bc3-45fe-41f8-af38-6643602b116d"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
				ModifiedInSchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"),
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
			return new ForecastObjValueRecord(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastObjValueRecord_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastObjValueRecordSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastObjValueRecordSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastObjValueRecord

	/// <summary>
	/// Записи колонки "Выбор из системы" планирования.
	/// </summary>
	public class ForecastObjValueRecord : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastObjValueRecord(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastObjValueRecord";
		}

		public ForecastObjValueRecord(ForecastObjValueRecord source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastObjValueRecord_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastObjValueRecord(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastObjValueRecord_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastObjValueRecord_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastObjValueRecord
	{

		public ForecastObjValueRecord_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastObjValueRecord_CoreForecastEventsProcess";
			SchemaUId = new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a28664e2-66ae-a27e-627a-cb1a3bbf5db8");
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

	#region Class: ForecastObjValueRecord_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastObjValueRecord_CoreForecastEventsProcess : ForecastObjValueRecord_CoreForecastEventsProcess<ForecastObjValueRecord>
	{

		public ForecastObjValueRecord_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastObjValueRecord_CoreForecastEventsProcess

	public partial class ForecastObjValueRecord_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastObjValueRecordEventsProcess

	/// <exclude/>
	public class ForecastObjValueRecordEventsProcess : ForecastObjValueRecord_CoreForecastEventsProcess
	{

		public ForecastObjValueRecordEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

