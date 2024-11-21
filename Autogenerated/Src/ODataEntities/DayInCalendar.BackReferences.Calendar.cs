namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DayInCalendar

	/// <exclude/>
	public class DayInCalendar : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DayInCalendar(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DayInCalendar";
		}

		public DayInCalendar(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DayInCalendar";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<WorkingTimeInterval> WorkingTimeIntervalCollectionByDayInCalendar {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

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
					(_dayOfWeek = new DayOfWeek(LookupColumnEntities.GetEntity("DayOfWeek")));
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
					(_dayType = new DayType(LookupColumnEntities.GetEntity("DayType")));
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
					(_calendar = new Calendar(LookupColumnEntities.GetEntity("Calendar")));
			}
		}

		#endregion

	}

	#endregion

}

