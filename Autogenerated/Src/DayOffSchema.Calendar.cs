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

	#region Class: DayOff_Calendar_BPMSoftSchema

	/// <exclude/>
	public class DayOff_Calendar_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DayOff_Calendar_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DayOff_Calendar_BPMSoftSchema(DayOff_Calendar_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DayOff_Calendar_BPMSoftSchema(DayOff_Calendar_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a");
			RealUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a");
			Name = "DayOff_Calendar_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4b9a5e52-c6ce-485d-a9b6-6152f16f5c5d")) == null) {
				Columns.Add(CreateCalendarColumn());
			}
			if (Columns.FindByUId(new Guid("e79fb6b4-030f-48db-97e8-d3c52cac45d7")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("c5d23c34-8f74-4fdb-b189-e58d25644d0b")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("8e90637b-e100-4f04-8c30-2d097d7d9068")) == null) {
				Columns.Add(CreateDayTypeColumn());
			}
			if (Columns.FindByUId(new Guid("31b69968-ae38-4c59-927f-eca119064960")) == null) {
				Columns.Add(CreateIsRepeatedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCalendarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4b9a5e52-c6ce-485d-a9b6-6152f16f5c5d"),
				Name = @"Calendar",
				ReferenceSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				ModifiedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e79fb6b4-030f-48db-97e8-d3c52cac45d7"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				ModifiedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("c5d23c34-8f74-4fdb-b189-e58d25644d0b"),
				Name = @"Date",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				ModifiedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f")
			};
		}

		protected virtual EntitySchemaColumn CreateDayTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e90637b-e100-4f04-8c30-2d097d7d9068"),
				Name = @"DayType",
				ReferenceSchemaUId = new Guid("1ad5f24a-ea0a-416e-a275-f0a79291d552"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				ModifiedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				CreatedInPackageId = new Guid("d2179f89-6a33-4745-96ee-fd30f06a5c1f"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsRepeatedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("31b69968-ae38-4c59-927f-eca119064960"),
				Name = @"IsRepeated",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
				ModifiedInSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"),
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
			return new DayOff_Calendar_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DayOff_CalendarEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DayOff_Calendar_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DayOff_Calendar_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a"));
		}

		#endregion

	}

	#endregion

	#region Class: DayOff_Calendar_BPMSoft

	/// <summary>
	/// Days off.
	/// </summary>
	public class DayOff_Calendar_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DayOff_Calendar_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DayOff_Calendar_BPMSoft";
		}

		public DayOff_Calendar_BPMSoft(DayOff_Calendar_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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
		/// Repeated.
		/// </summary>
		public bool IsRepeated {
			get {
				return GetTypedColumnValue<bool>("IsRepeated");
			}
			set {
				SetColumnValue("IsRepeated", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DayOff_CalendarEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DayOff_Calendar_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("DayOff_Calendar_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DayOff_Calendar_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: DayOff_CalendarEventsProcess

	/// <exclude/>
	public partial class DayOff_CalendarEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DayOff_Calendar_BPMSoft
	{

		public DayOff_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DayOff_CalendarEventsProcess";
			SchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a");
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

	#region Class: DayOff_CalendarEventsProcess

	/// <exclude/>
	public class DayOff_CalendarEventsProcess : DayOff_CalendarEventsProcess<DayOff_Calendar_BPMSoft>
	{

		public DayOff_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DayOff_CalendarEventsProcess

	public partial class DayOff_CalendarEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

