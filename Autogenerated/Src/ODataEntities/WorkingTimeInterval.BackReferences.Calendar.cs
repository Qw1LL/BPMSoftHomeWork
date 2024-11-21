namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: WorkingTimeInterval

	/// <exclude/>
	public class WorkingTimeInterval : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public WorkingTimeInterval(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WorkingTimeInterval";
		}

		public WorkingTimeInterval(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "WorkingTimeInterval";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
					(_dayInCalendar = new DayInCalendar(LookupColumnEntities.GetEntity("DayInCalendar")));
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
					(_dayOff = new DayOff(LookupColumnEntities.GetEntity("DayOff")));
			}
		}

		#endregion

	}

	#endregion

}

