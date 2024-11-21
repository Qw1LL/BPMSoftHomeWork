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

	#region Class: DayInCalendar_Calendar_BPMSoftSchema

	/// <exclude/>
	public class DayInCalendar_Calendar_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DayInCalendar_Calendar_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DayInCalendar_Calendar_BPMSoftSchema(DayInCalendar_Calendar_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DayInCalendar_Calendar_BPMSoftSchema(DayInCalendar_Calendar_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			RealUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			Name = "DayInCalendar_Calendar_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5a88c990-9162-4876-875d-dffcb3669f5a")) == null) {
				Columns.Add(CreateDayOfWeekColumn());
			}
			if (Columns.FindByUId(new Guid("d5ad1bba-36c0-4807-a99e-428d41eb01b6")) == null) {
				Columns.Add(CreateDayTypeColumn());
			}
			if (Columns.FindByUId(new Guid("424e20d8-274a-4a9c-b57a-3d189416b40f")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("e21b29e0-9bc7-40df-bcbb-cee71c414300")) == null) {
				Columns.Add(CreateCalendarColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDayOfWeekColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5a88c990-9162-4876-875d-dffcb3669f5a"),
				Name = @"DayOfWeek",
				ReferenceSchemaUId = new Guid("95592cd1-f2aa-4d34-a109-aa046cd5bbd5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateDayTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5ad1bba-36c0-4807-a99e-428d41eb01b6"),
				Name = @"DayType",
				ReferenceSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("424e20d8-274a-4a9c-b57a-3d189416b40f"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateCalendarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e21b29e0-9bc7-40df-bcbb-cee71c414300"),
				Name = @"Calendar",
				ReferenceSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				ModifiedInSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DayInCalendar_Calendar_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DayInCalendar_CalendarEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DayInCalendar_Calendar_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DayInCalendar_Calendar_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("13665ad9-ac50-479b-b43c-765d03988626"));
		}

		#endregion

	}

	#endregion

	#region Class: DayInCalendar_Calendar_BPMSoft

	/// <summary>
	/// Day in calendar.
	/// </summary>
	public class DayInCalendar_Calendar_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DayInCalendar_Calendar_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DayInCalendar_Calendar_BPMSoft";
		}

		public DayInCalendar_Calendar_BPMSoft(DayInCalendar_Calendar_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DayOfWeekId {
			get {
				return GetTypedColumnValue<Guid>("DayOfWeekId");
			}
			set {
				SetColumnValue("DayOfWeekId", value);
				_dayOfWeek = null;
			}
		}

		/// <exclude/>
		public string DayOfWeekName {
			get {
				return GetTypedColumnValue<string>("DayOfWeekName");
			}
			set {
				SetColumnValue("DayOfWeekName", value);
				if (_dayOfWeek != null) {
					_dayOfWeek.Name = value;
				}
			}
		}

		private DayOfWeek _dayOfWeek;
		/// <summary>
		/// Day of the week.
		/// </summary>
		public DayOfWeek DayOfWeek {
			get {
				return _dayOfWeek ??
					(_dayOfWeek = LookupColumnEntities.GetEntity("DayOfWeek") as DayOfWeek);
			}
		}

		/// <exclude/>
		public Guid DayTypeId {
			get {
				return GetTypedColumnValue<Guid>("DayTypeId");
			}
			set {
				SetColumnValue("DayTypeId", value);
				_dayType = null;
			}
		}

		/// <exclude/>
		public string DayTypeName {
			get {
				return GetTypedColumnValue<string>("DayTypeName");
			}
			set {
				SetColumnValue("DayTypeName", value);
				if (_dayType != null) {
					_dayType.Name = value;
				}
			}
		}

		private DayType _dayType;
		/// <summary>
		/// Day type.
		/// </summary>
		public DayType DayType {
			get {
				return _dayType ??
					(_dayType = LookupColumnEntities.GetEntity("DayType") as DayType);
			}
		}

		/// <summary>
		/// Date.
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
		public Guid CalendarId {
			get {
				return GetTypedColumnValue<Guid>("CalendarId");
			}
			set {
				SetColumnValue("CalendarId", value);
				_calendar = null;
			}
		}

		/// <exclude/>
		public string CalendarName {
			get {
				return GetTypedColumnValue<string>("CalendarName");
			}
			set {
				SetColumnValue("CalendarName", value);
				if (_calendar != null) {
					_calendar.Name = value;
				}
			}
		}

		private Calendar _calendar;
		/// <summary>
		/// Calendar.
		/// </summary>
		public Calendar Calendar {
			get {
				return _calendar ??
					(_calendar = LookupColumnEntities.GetEntity("Calendar") as Calendar);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DayInCalendar_CalendarEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DayInCalendar_Calendar_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("DayInCalendar_Calendar_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("DayInCalendar_Calendar_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DayInCalendar_Calendar_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: DayInCalendar_CalendarEventsProcess

	/// <exclude/>
	public partial class DayInCalendar_CalendarEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DayInCalendar_Calendar_BPMSoft
	{

		public DayInCalendar_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DayInCalendar_CalendarEventsProcess";
			SchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("13665ad9-ac50-479b-b43c-765d03988626");
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

	#region Class: DayInCalendar_CalendarEventsProcess

	/// <exclude/>
	public class DayInCalendar_CalendarEventsProcess : DayInCalendar_CalendarEventsProcess<DayInCalendar_Calendar_BPMSoft>
	{

		public DayInCalendar_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DayInCalendar_CalendarEventsProcess

	public partial class DayInCalendar_CalendarEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

