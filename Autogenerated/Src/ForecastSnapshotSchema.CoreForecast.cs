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

	#region Class: ForecastSnapshotSchema

	/// <exclude/>
	public class ForecastSnapshotSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastSnapshotSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastSnapshotSchema(ForecastSnapshotSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastSnapshotSchema(ForecastSnapshotSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b");
			RealUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b");
			Name = "ForecastSnapshot";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8da2ea83-10dc-451c-ad07-17665f9a6635")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("9e043044-85be-4796-bb96-9bf9926c1157")) == null) {
				Columns.Add(CreateSheetColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("8da2ea83-10dc-451c-ad07-17665f9a6635"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
				ModifiedInSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSheetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9e043044-85be-4796-bb96-9bf9926c1157"),
				Name = @"Sheet",
				ReferenceSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
				ModifiedInSchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"),
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
			return new ForecastSnapshot(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastSnapshot_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastSnapshotSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastSnapshotSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastSnapshot

	/// <summary>
	/// Слепок данных планирования.
	/// </summary>
	public class ForecastSnapshot : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastSnapshot(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastSnapshot";
		}

		public ForecastSnapshot(ForecastSnapshot source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Дата снятия слепка.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
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
			var process = new ForecastSnapshot_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastSnapshot(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastSnapshot_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastSnapshot_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastSnapshot
	{

		public ForecastSnapshot_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastSnapshot_CoreForecastEventsProcess";
			SchemaUId = new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd25c821-128f-41b1-b924-b22bcbd3202b");
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

	#region Class: ForecastSnapshot_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastSnapshot_CoreForecastEventsProcess : ForecastSnapshot_CoreForecastEventsProcess<ForecastSnapshot>
	{

		public ForecastSnapshot_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastSnapshot_CoreForecastEventsProcess

	public partial class ForecastSnapshot_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastSnapshotEventsProcess

	/// <exclude/>
	public class ForecastSnapshotEventsProcess : ForecastSnapshot_CoreForecastEventsProcess
	{

		public ForecastSnapshotEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

