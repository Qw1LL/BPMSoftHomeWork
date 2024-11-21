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

	#region Class: WorkingTimeInterval_Calendar_BPMSoftSchema

	/// <exclude/>
	public class WorkingTimeInterval_Calendar_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WorkingTimeInterval_Calendar_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WorkingTimeInterval_Calendar_BPMSoftSchema(WorkingTimeInterval_Calendar_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WorkingTimeInterval_Calendar_BPMSoftSchema(WorkingTimeInterval_Calendar_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			RealUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			Name = "WorkingTimeInterval_Calendar_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1cca11f5-a9a8-4121-948c-9440212c73d5")) == null) {
				Columns.Add(CreateDayInCalendarColumn());
			}
			if (Columns.FindByUId(new Guid("d5043099-3e07-4aaf-9cf4-3faad2243c72")) == null) {
				Columns.Add(CreateFromColumn());
			}
			if (Columns.FindByUId(new Guid("45d1db09-15c2-47f6-b437-2ed41d7c1e61")) == null) {
				Columns.Add(CreateToColumn());
			}
			if (Columns.FindByUId(new Guid("1649e728-2418-4a49-b71d-556593140c7e")) == null) {
				Columns.Add(CreateIndexColumn());
			}
			if (Columns.FindByUId(new Guid("e669ecc9-ac38-4001-a477-92777c072f08")) == null) {
				Columns.Add(CreateDayOffColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDayInCalendarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1cca11f5-a9a8-4121-948c-9440212c73d5"),
				Name = @"DayInCalendar",
				ReferenceSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateFromColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("d5043099-3e07-4aaf-9cf4-3faad2243c72"),
				Name = @"From",
				CreatedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateToColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("45d1db09-15c2-47f6-b437-2ed41d7c1e61"),
				Name = @"To",
				CreatedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1649e728-2418-4a49-b71d-556593140c7e"),
				Name = @"Index",
				CreatedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateDayOffColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e669ecc9-ac38-4001-a477-92777c072f08"),
				Name = @"DayOff",
				ReferenceSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				ModifiedInSchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def"),
				CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WorkingTimeInterval_Calendar_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WorkingTimeInterval_CalendarEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WorkingTimeInterval_Calendar_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WorkingTimeInterval_Calendar_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3c971b13-45b1-49f4-af05-db8566668def"));
		}

		#endregion

	}

	#endregion

	#region Class: WorkingTimeInterval_Calendar_BPMSoft

	/// <summary>
	/// Working time intervals.
	/// </summary>
	public class WorkingTimeInterval_Calendar_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WorkingTimeInterval_Calendar_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WorkingTimeInterval_Calendar_BPMSoft";
		}

		public WorkingTimeInterval_Calendar_BPMSoft(WorkingTimeInterval_Calendar_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DayInCalendarId {
			get {
				return GetTypedColumnValue<Guid>("DayInCalendarId");
			}
			set {
				SetColumnValue("DayInCalendarId", value);
				_dayInCalendar = null;
			}
		}

		private DayInCalendar _dayInCalendar;
		/// <summary>
		/// Day in calendar.
		/// </summary>
		public DayInCalendar DayInCalendar {
			get {
				return _dayInCalendar ??
					(_dayInCalendar = LookupColumnEntities.GetEntity("DayInCalendar") as DayInCalendar);
			}
		}

		/// <summary>
		/// from.
		/// </summary>
		public DateTime From {
			get {
				return GetTypedColumnValue<DateTime>("From");
			}
			set {
				SetColumnValue("From", value);
			}
		}

		/// <summary>
		/// till.
		/// </summary>
		public DateTime To {
			get {
				return GetTypedColumnValue<DateTime>("To");
			}
			set {
				SetColumnValue("To", value);
			}
		}

		/// <summary>
		/// Index.
		/// </summary>
		public int Index {
			get {
				return GetTypedColumnValue<int>("Index");
			}
			set {
				SetColumnValue("Index", value);
			}
		}

		/// <exclude/>
		public Guid DayOffId {
			get {
				return GetTypedColumnValue<Guid>("DayOffId");
			}
			set {
				SetColumnValue("DayOffId", value);
				_dayOff = null;
			}
		}

		private DayOff _dayOff;
		/// <summary>
		/// Day off.
		/// </summary>
		public DayOff DayOff {
			get {
				return _dayOff ??
					(_dayOff = LookupColumnEntities.GetEntity("DayOff") as DayOff);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WorkingTimeInterval_CalendarEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WorkingTimeInterval_Calendar_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("WorkingTimeInterval_Calendar_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("WorkingTimeInterval_Calendar_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WorkingTimeInterval_Calendar_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: WorkingTimeInterval_CalendarEventsProcess

	/// <exclude/>
	public partial class WorkingTimeInterval_CalendarEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WorkingTimeInterval_Calendar_BPMSoft
	{

		public WorkingTimeInterval_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WorkingTimeInterval_CalendarEventsProcess";
			SchemaUId = new Guid("3c971b13-45b1-49f4-af05-db8566668def");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3c971b13-45b1-49f4-af05-db8566668def");
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

	#region Class: WorkingTimeInterval_CalendarEventsProcess

	/// <exclude/>
	public class WorkingTimeInterval_CalendarEventsProcess : WorkingTimeInterval_CalendarEventsProcess<WorkingTimeInterval_Calendar_BPMSoft>
	{

		public WorkingTimeInterval_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WorkingTimeInterval_CalendarEventsProcess

	public partial class WorkingTimeInterval_CalendarEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

