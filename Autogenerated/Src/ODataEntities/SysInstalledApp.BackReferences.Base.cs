namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysInstalledApp

	/// <exclude/>
	public class SysInstalledApp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysInstalledApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledApp";
		}

		public SysInstalledApp(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysInstalledApp";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysPackageInInstalledApp> SysPackageInInstalledAppCollectionBySysInstalledApp {
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
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
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
		/// Maintainer.
		/// </summary>
		public string Maintainer {
			get {
				return GetTypedColumnValue<string>("Maintainer");
			}
			set {
				SetColumnValue("Maintainer", value);
			}
		}

		/// <summary>
		/// Install date.
		/// </summary>
		public DateTime InstallDate {
			get {
				return GetTypedColumnValue<DateTime>("InstallDate");
			}
			set {
				SetColumnValue("InstallDate", value);
			}
		}

		/// <summary>
		/// Date last updated.
		/// </summary>
		public DateTime LastUpdate {
			get {
				return GetTypedColumnValue<DateTime>("LastUpdate");
			}
			set {
				SetColumnValue("LastUpdate", value);
			}
		}

		/// <summary>
		/// Marketplace link.
		/// </summary>
		public string MarketplaceLink {
			get {
				return GetTypedColumnValue<string>("MarketplaceLink");
			}
			set {
				SetColumnValue("MarketplaceLink", value);
			}
		}

		/// <summary>
		/// Help link.
		/// </summary>
		public string HelpLink {
			get {
				return GetTypedColumnValue<string>("HelpLink");
			}
			set {
				SetColumnValue("HelpLink", value);
			}
		}

		/// <summary>
		/// File link.
		/// </summary>
		public string FileLink {
			get {
				return GetTypedColumnValue<string>("FileLink");
			}
			set {
				SetColumnValue("FileLink", value);
			}
		}

		/// <summary>
		/// Support email.
		/// </summary>
		public string SupportEmail {
			get {
				return GetTypedColumnValue<string>("SupportEmail");
			}
			set {
				SetColumnValue("SupportEmail", value);
			}
		}

		/// <summary>
		/// Order link.
		/// </summary>
		public string OrderLink {
			get {
				return GetTypedColumnValue<string>("OrderLink");
			}
			set {
				SetColumnValue("OrderLink", value);
			}
		}

		/// <exclude/>
		public Guid SysInstalledAppStatusId {
			get {
				return GetTypedColumnValue<Guid>("SysInstalledAppStatusId");
			}
			set {
				SetColumnValue("SysInstalledAppStatusId", value);
				_sysInstalledAppStatus = null;
			}
		}

		/// <exclude/>
		public string SysInstalledAppStatusName {
			get {
				return GetTypedColumnValue<string>("SysInstalledAppStatusName");
			}
			set {
				SetColumnValue("SysInstalledAppStatusName", value);
				if (_sysInstalledAppStatus != null) {
					_sysInstalledAppStatus.Name = value;
				}
			}
		}

		private SysInstalledAppStatus _sysInstalledAppStatus;
		/// <summary>
		/// Application status.
		/// </summary>
		public SysInstalledAppStatus SysInstalledAppStatus {
			get {
				return _sysInstalledAppStatus ??
					(_sysInstalledAppStatus = new SysInstalledAppStatus(LookupColumnEntities.GetEntity("SysInstalledAppStatus")));
			}
		}

		/// <summary>
		/// Published version.
		/// </summary>
		public string MkpPublishedVersion {
			get {
				return GetTypedColumnValue<string>("MkpPublishedVersion");
			}
			set {
				SetColumnValue("MkpPublishedVersion", value);
			}
		}

		/// <summary>
		/// Release notes.
		/// </summary>
		public string MkpReleaseNotes {
			get {
				return GetTypedColumnValue<string>("MkpReleaseNotes");
			}
			set {
				SetColumnValue("MkpReleaseNotes", value);
			}
		}

		/// <summary>
		/// Notification status.
		/// </summary>
		public bool MkpNotificationStatus {
			get {
				return GetTypedColumnValue<bool>("MkpNotificationStatus");
			}
			set {
				SetColumnValue("MkpNotificationStatus", value);
			}
		}

		/// <summary>
		/// Changed on.
		/// </summary>
		public DateTime MkpChangedOn {
			get {
				return GetTypedColumnValue<DateTime>("MkpChangedOn");
			}
			set {
				SetColumnValue("MkpChangedOn", value);
			}
		}

		/// <summary>
		/// IsUpdated.
		/// </summary>
		public bool MkpIsUpdated {
			get {
				return GetTypedColumnValue<bool>("MkpIsUpdated");
			}
			set {
				SetColumnValue("MkpIsUpdated", value);
			}
		}

		/// <summary>
		/// Icon background color.
		/// </summary>
		/// <remarks>
		/// Code of the application icon background color.
		/// </remarks>
		public string IconBackground {
			get {
				return GetTypedColumnValue<string>("IconBackground");
			}
			set {
				SetColumnValue("IconBackground", value);
			}
		}

		#endregion

	}

	#endregion

}

