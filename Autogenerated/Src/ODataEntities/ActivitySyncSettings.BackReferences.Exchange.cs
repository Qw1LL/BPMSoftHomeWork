namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ActivitySyncSettings

	/// <exclude/>
	public class ActivitySyncSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ActivitySyncSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivitySyncSettings";
		}

		public ActivitySyncSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ActivitySyncSettings";
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
		public Guid MailboxSyncSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettingsId");
			}
			set {
				SetColumnValue("MailboxSyncSettingsId", value);
				_mailboxSyncSettings = null;
			}
		}

		/// <exclude/>
		public string MailboxSyncSettingsUserName {
			get {
				return GetTypedColumnValue<string>("MailboxSyncSettingsUserName");
			}
			set {
				SetColumnValue("MailboxSyncSettingsUserName", value);
				if (_mailboxSyncSettings != null) {
					_mailboxSyncSettings.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailboxSyncSettings;
		/// <summary>
		/// Mailbox synchronization settings.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = new MailboxSyncSettings(LookupColumnEntities.GetEntity("MailboxSyncSettings")));
			}
		}

		/// <summary>
		/// AppointmentLastSyncDate.
		/// </summary>
		public DateTime AppointmentLastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("AppointmentLastSyncDate");
			}
			set {
				SetColumnValue("AppointmentLastSyncDate", value);
			}
		}

		/// <summary>
		/// TaskLastSyncDate.
		/// </summary>
		public DateTime TaskLastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("TaskLastSyncDate");
			}
			set {
				SetColumnValue("TaskLastSyncDate", value);
			}
		}

		/// <summary>
		/// Import tasks.
		/// </summary>
		public bool ImportTasks {
			get {
				return GetTypedColumnValue<bool>("ImportTasks");
			}
			set {
				SetColumnValue("ImportTasks", value);
			}
		}

		/// <summary>
		/// All tasks.
		/// </summary>
		public bool ImportTasksAll {
			get {
				return GetTypedColumnValue<bool>("ImportTasksAll");
			}
			set {
				SetColumnValue("ImportTasksAll", value);
			}
		}

		/// <summary>
		/// ImportTasksFolders.
		/// </summary>
		public string ImportTasksFolders {
			get {
				return GetTypedColumnValue<string>("ImportTasksFolders");
			}
			set {
				SetColumnValue("ImportTasksFolders", value);
			}
		}

		/// <summary>
		/// Import tasks from folders.
		/// </summary>
		public bool ImportTasksFromFolders {
			get {
				return GetTypedColumnValue<bool>("ImportTasksFromFolders");
			}
			set {
				SetColumnValue("ImportTasksFromFolders", value);
			}
		}

		/// <summary>
		/// Import activities starting from.
		/// </summary>
		public DateTime ImportActivitiesFrom {
			get {
				return GetTypedColumnValue<DateTime>("ImportActivitiesFrom");
			}
			set {
				SetColumnValue("ImportActivitiesFrom", value);
			}
		}

		/// <summary>
		/// Import meetings.
		/// </summary>
		public bool ImportAppointments {
			get {
				return GetTypedColumnValue<bool>("ImportAppointments");
			}
			set {
				SetColumnValue("ImportAppointments", value);
			}
		}

		/// <summary>
		/// All meetings.
		/// </summary>
		public bool ImportAppointmentsAll {
			get {
				return GetTypedColumnValue<bool>("ImportAppointmentsAll");
			}
			set {
				SetColumnValue("ImportAppointmentsAll", value);
			}
		}

		/// <summary>
		/// Import meetings from calendars.
		/// </summary>
		public bool ImpAppointmentsFromCalendars {
			get {
				return GetTypedColumnValue<bool>("ImpAppointmentsFromCalendars");
			}
			set {
				SetColumnValue("ImpAppointmentsFromCalendars", value);
			}
		}

		/// <summary>
		/// ImportAppointmentsCalendars.
		/// </summary>
		public string ImportAppointmentsCalendars {
			get {
				return GetTypedColumnValue<string>("ImportAppointmentsCalendars");
			}
			set {
				SetColumnValue("ImportAppointmentsCalendars", value);
			}
		}

		/// <summary>
		/// Export activities.
		/// </summary>
		public bool ExportActivities {
			get {
				return GetTypedColumnValue<bool>("ExportActivities");
			}
			set {
				SetColumnValue("ExportActivities", value);
			}
		}

		/// <summary>
		/// All activities.
		/// </summary>
		public bool ExportActivitiesAll {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesAll");
			}
			set {
				SetColumnValue("ExportActivitiesAll", value);
			}
		}

		/// <summary>
		/// Export selected activities.
		/// </summary>
		public bool ExportActivitiesSelected {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesSelected");
			}
			set {
				SetColumnValue("ExportActivitiesSelected", value);
			}
		}

		/// <summary>
		/// Meetings.
		/// </summary>
		public bool ExportAppointments {
			get {
				return GetTypedColumnValue<bool>("ExportAppointments");
			}
			set {
				SetColumnValue("ExportAppointments", value);
			}
		}

		/// <summary>
		/// Tasks.
		/// </summary>
		public bool ExportTasks {
			get {
				return GetTypedColumnValue<bool>("ExportTasks");
			}
			set {
				SetColumnValue("ExportTasks", value);
			}
		}

		/// <summary>
		/// From calendar.
		/// </summary>
		public bool ExportActivitiesFromScheduler {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesFromScheduler");
			}
			set {
				SetColumnValue("ExportActivitiesFromScheduler", value);
			}
		}

		/// <summary>
		/// From folders.
		/// </summary>
		public bool ExportActivitiesFromGroups {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesFromGroups");
			}
			set {
				SetColumnValue("ExportActivitiesFromGroups", value);
			}
		}

		/// <summary>
		/// ExportActivitiesGroups.
		/// </summary>
		public string ExportActivitiesGroups {
			get {
				return GetTypedColumnValue<string>("ExportActivitiesGroups");
			}
			set {
				SetColumnValue("ExportActivitiesGroups", value);
			}
		}

		/// <exclude/>
		public Guid ActivitySyncPeriodId {
			get {
				return GetTypedColumnValue<Guid>("ActivitySyncPeriodId");
			}
			set {
				SetColumnValue("ActivitySyncPeriodId", value);
				_activitySyncPeriod = null;
			}
		}

		/// <exclude/>
		public string ActivitySyncPeriodName {
			get {
				return GetTypedColumnValue<string>("ActivitySyncPeriodName");
			}
			set {
				SetColumnValue("ActivitySyncPeriodName", value);
				if (_activitySyncPeriod != null) {
					_activitySyncPeriod.Name = value;
				}
			}
		}

		private MailSyncPeriod _activitySyncPeriod;
		/// <summary>
		/// Synchronization period.
		/// </summary>
		public MailSyncPeriod ActivitySyncPeriod {
			get {
				return _activitySyncPeriod ??
					(_activitySyncPeriod = new MailSyncPeriod(LookupColumnEntities.GetEntity("ActivitySyncPeriod")));
			}
		}

		#endregion

	}

	#endregion

}

