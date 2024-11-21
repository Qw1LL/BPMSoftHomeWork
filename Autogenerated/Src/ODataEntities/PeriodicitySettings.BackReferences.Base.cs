namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: PeriodicitySettings

	/// <exclude/>
	public class PeriodicitySettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public PeriodicitySettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PeriodicitySettings";
		}

		public PeriodicitySettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "PeriodicitySettings";
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

		/// <summary>
		/// IsDaily.
		/// </summary>
		public bool IsDaily {
			get {
				return GetTypedColumnValue<bool>("IsDaily");
			}
			set {
				SetColumnValue("IsDaily", value);
			}
		}

		/// <summary>
		/// DailyPeriod.
		/// </summary>
		public int DailyPeriod {
			get {
				return GetTypedColumnValue<int>("DailyPeriod");
			}
			set {
				SetColumnValue("DailyPeriod", value);
			}
		}

		/// <summary>
		/// IsWeekly.
		/// </summary>
		public bool IsWeekly {
			get {
				return GetTypedColumnValue<bool>("IsWeekly");
			}
			set {
				SetColumnValue("IsWeekly", value);
			}
		}

		/// <summary>
		/// DayOfWeek.
		/// </summary>
		public int DayOfWeek {
			get {
				return GetTypedColumnValue<int>("DayOfWeek");
			}
			set {
				SetColumnValue("DayOfWeek", value);
			}
		}

		/// <summary>
		/// IsMonthly.
		/// </summary>
		public bool IsMonthly {
			get {
				return GetTypedColumnValue<bool>("IsMonthly");
			}
			set {
				SetColumnValue("IsMonthly", value);
			}
		}

		/// <summary>
		/// IsMonthlyCustom.
		/// </summary>
		public bool IsMonthlyCustom {
			get {
				return GetTypedColumnValue<bool>("IsMonthlyCustom");
			}
			set {
				SetColumnValue("IsMonthlyCustom", value);
			}
		}

		/// <summary>
		/// DayOfMonth.
		/// </summary>
		public int DayOfMonth {
			get {
				return GetTypedColumnValue<int>("DayOfMonth");
			}
			set {
				SetColumnValue("DayOfMonth", value);
			}
		}

		/// <summary>
		/// IsMonthlyLastDay.
		/// </summary>
		public bool IsMonthlyLastDay {
			get {
				return GetTypedColumnValue<bool>("IsMonthlyLastDay");
			}
			set {
				SetColumnValue("IsMonthlyLastDay", value);
			}
		}

		/// <summary>
		/// IsOnce.
		/// </summary>
		public bool IsOnce {
			get {
				return GetTypedColumnValue<bool>("IsOnce");
			}
			set {
				SetColumnValue("IsOnce", value);
			}
		}

		/// <summary>
		/// OnceAt.
		/// </summary>
		public DateTime OnceAt {
			get {
				return GetTypedColumnValue<DateTime>("OnceAt");
			}
			set {
				SetColumnValue("OnceAt", value);
			}
		}

		/// <summary>
		/// IsCustom.
		/// </summary>
		public bool IsCustom {
			get {
				return GetTypedColumnValue<bool>("IsCustom");
			}
			set {
				SetColumnValue("IsCustom", value);
			}
		}

		/// <summary>
		/// CustomPeriod.
		/// </summary>
		public int CustomPeriod {
			get {
				return GetTypedColumnValue<int>("CustomPeriod");
			}
			set {
				SetColumnValue("CustomPeriod", value);
			}
		}

		/// <summary>
		/// CustomPeriodType.
		/// </summary>
		public int CustomPeriodType {
			get {
				return GetTypedColumnValue<int>("CustomPeriodType");
			}
			set {
				SetColumnValue("CustomPeriodType", value);
			}
		}

		/// <summary>
		/// CustomFrom.
		/// </summary>
		public DateTime CustomFrom {
			get {
				return GetTypedColumnValue<DateTime>("CustomFrom");
			}
			set {
				SetColumnValue("CustomFrom", value);
			}
		}

		/// <summary>
		/// CustomTill.
		/// </summary>
		public DateTime CustomTill {
			get {
				return GetTypedColumnValue<DateTime>("CustomTill");
			}
			set {
				SetColumnValue("CustomTill", value);
			}
		}

		/// <summary>
		/// SchedulerStart.
		/// </summary>
		public DateTime SchedulerStart {
			get {
				return GetTypedColumnValue<DateTime>("SchedulerStart");
			}
			set {
				SetColumnValue("SchedulerStart", value);
			}
		}

		/// <summary>
		/// SchedulerFinish.
		/// </summary>
		public DateTime SchedulerFinish {
			get {
				return GetTypedColumnValue<DateTime>("SchedulerFinish");
			}
			set {
				SetColumnValue("SchedulerFinish", value);
			}
		}

		/// <summary>
		/// IsSchedulerEndless.
		/// </summary>
		public bool IsSchedulerEndless {
			get {
				return GetTypedColumnValue<bool>("IsSchedulerEndless");
			}
			set {
				SetColumnValue("IsSchedulerEndless", value);
			}
		}

		#endregion

	}

	#endregion

}

