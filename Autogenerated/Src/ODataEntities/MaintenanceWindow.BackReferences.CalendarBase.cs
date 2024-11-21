namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MaintenanceWindow

	/// <exclude/>
	public class MaintenanceWindow : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MaintenanceWindow(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MaintenanceWindow";
		}

		public MaintenanceWindow(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MaintenanceWindow";
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

		/// <summary>
		/// Start time (UTC).
		/// </summary>
		public DateTime StartTime {
			get {
				return GetTypedColumnValue<DateTime>("StartTime");
			}
			set {
				SetColumnValue("StartTime", value);
			}
		}

		/// <summary>
		/// End time (UTC).
		/// </summary>
		public DateTime EndTime {
			get {
				return GetTypedColumnValue<DateTime>("EndTime");
			}
			set {
				SetColumnValue("EndTime", value);
			}
		}

		#endregion

	}

	#endregion

}

