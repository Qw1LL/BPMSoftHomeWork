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

	#region Class: Calendar_Calendar_BPMSoftSchema

	/// <exclude/>
	public class Calendar_Calendar_BPMSoftSchema : BPMSoft.Configuration.BaseHierarchicalLookupSchema
	{

		#region Constructors: Public

		public Calendar_Calendar_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Calendar_Calendar_BPMSoftSchema(Calendar_Calendar_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Calendar_Calendar_BPMSoftSchema(Calendar_Calendar_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			RealUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			Name = "Calendar_Calendar_BPMSoft";
			ParentSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b642ae94-288a-475c-8585-1e13a73beb4b")) == null) {
				Columns.Add(CreateTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("81f7790d-dfee-4027-9a78-5025f58448b5")) == null) {
				Columns.Add(CreateDepthColumn());
			}
			if (Columns.FindByUId(new Guid("9e66d86f-4fb9-4e15-bd4b-8872144693cb")) == null) {
				Columns.Add(CreateAroundClockColumn());
			}
			if (Columns.FindByUId(new Guid("520498b0-fe65-40d1-af2b-b64ab21ae44e")) == null) {
				Columns.Add(CreateWithoutDayOffColumn());
			}
			if (Columns.FindByUId(new Guid("8bf7b8fc-61b4-4706-b5d4-9263fd930a6a")) == null) {
				Columns.Add(CreateUserColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b642ae94-288a-475c-8585-1e13a73beb4b"),
				Name = @"TimeZone",
				ReferenceSchemaUId = new Guid("a394a569-92d6-44d0-bdda-fa0578373b4f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"DefaultTimeZone"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDepthColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("81f7790d-dfee-4027-9a78-5025f58448b5"),
				Name = @"Depth",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateAroundClockColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9e66d86f-4fb9-4e15-bd4b-8872144693cb"),
				Name = @"AroundClock",
				CreatedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0")
			};
		}

		protected virtual EntitySchemaColumn CreateWithoutDayOffColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("520498b0-fe65-40d1-af2b-b64ab21ae44e"),
				Name = @"WithoutDayOff",
				CreatedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0")
			};
		}

		protected virtual EntitySchemaColumn CreateUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8bf7b8fc-61b4-4706-b5d4-9263fd930a6a"),
				Name = @"User",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				ModifiedInSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				CreatedInPackageId = new Guid("d1ee6d63-eb1a-404e-8c35-e71afdce13aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Calendar_Calendar_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Calendar_CalendarEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Calendar_Calendar_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Calendar_Calendar_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"));
		}

		#endregion

	}

	#endregion

	#region Class: Calendar_Calendar_BPMSoft

	/// <summary>
	/// Calendar.
	/// </summary>
	public class Calendar_Calendar_BPMSoft : BPMSoft.Configuration.BaseHierarchicalLookup
	{

		#region Constructors: Public

		public Calendar_Calendar_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Calendar_Calendar_BPMSoft";
		}

		public Calendar_Calendar_BPMSoft(Calendar_Calendar_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private Calendar _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public Calendar Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as Calendar);
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Time zone.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = LookupColumnEntities.GetEntity("TimeZone") as TimeZone);
			}
		}

		/// <summary>
		/// Level.
		/// </summary>
		public int Depth {
			get {
				return GetTypedColumnValue<int>("Depth");
			}
			set {
				SetColumnValue("Depth", value);
			}
		}

		/// <summary>
		/// Around the clock.
		/// </summary>
		public bool AroundClock {
			get {
				return GetTypedColumnValue<bool>("AroundClock");
			}
			set {
				SetColumnValue("AroundClock", value);
			}
		}

		/// <summary>
		/// Without day off.
		/// </summary>
		public bool WithoutDayOff {
			get {
				return GetTypedColumnValue<bool>("WithoutDayOff");
			}
			set {
				SetColumnValue("WithoutDayOff", value);
			}
		}

		/// <exclude/>
		public Guid UserId {
			get {
				return GetTypedColumnValue<Guid>("UserId");
			}
			set {
				SetColumnValue("UserId", value);
				_user = null;
			}
		}

		/// <exclude/>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
				if (_user != null) {
					_user.Name = value;
				}
			}
		}

		private SysAdminUnit _user;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit User {
			get {
				return _user ??
					(_user = LookupColumnEntities.GetEntity("User") as SysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Calendar_CalendarEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Calendar_Calendar_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Calendar_Calendar_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Calendar_Calendar_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Calendar_Calendar_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Calendar_CalendarEventsProcess

	/// <exclude/>
	public partial class Calendar_CalendarEventsProcess<TEntity> : BPMSoft.Configuration.BaseHierarchicalLookup_BaseEventsProcess<TEntity> where TEntity : Calendar_Calendar_BPMSoft
	{

		public Calendar_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Calendar_CalendarEventsProcess";
			SchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64");
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

	#region Class: Calendar_CalendarEventsProcess

	/// <exclude/>
	public class Calendar_CalendarEventsProcess : Calendar_CalendarEventsProcess<Calendar_Calendar_BPMSoft>
	{

		public Calendar_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Calendar_CalendarEventsProcess

	public partial class Calendar_CalendarEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

