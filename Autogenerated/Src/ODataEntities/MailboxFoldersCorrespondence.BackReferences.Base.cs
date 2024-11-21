namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MailboxFoldersCorrespondence

	/// <exclude/>
	public class MailboxFoldersCorrespondence : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailboxFoldersCorrespondence(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxFoldersCorrespondence";
		}

		public MailboxFoldersCorrespondence(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MailboxFoldersCorrespondence";
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
		public Guid MailboxId {
			get {
				return GetTypedColumnValue<Guid>("MailboxId");
			}
			set {
				SetColumnValue("MailboxId", value);
				_mailbox = null;
			}
		}

		/// <exclude/>
		public string MailboxUserName {
			get {
				return GetTypedColumnValue<string>("MailboxUserName");
			}
			set {
				SetColumnValue("MailboxUserName", value);
				if (_mailbox != null) {
					_mailbox.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailbox;
		/// <summary>
		/// Mailbox.
		/// </summary>
		public MailboxSyncSettings Mailbox {
			get {
				return _mailbox ??
					(_mailbox = new MailboxSyncSettings(LookupColumnEntities.GetEntity("Mailbox")));
			}
		}

		/// <exclude/>
		public Guid ActivityFolderId {
			get {
				return GetTypedColumnValue<Guid>("ActivityFolderId");
			}
			set {
				SetColumnValue("ActivityFolderId", value);
				_activityFolder = null;
			}
		}

		/// <exclude/>
		public string ActivityFolderName {
			get {
				return GetTypedColumnValue<string>("ActivityFolderName");
			}
			set {
				SetColumnValue("ActivityFolderName", value);
				if (_activityFolder != null) {
					_activityFolder.Name = value;
				}
			}
		}

		private ActivityFolder _activityFolder;
		/// <summary>
		/// Activity folder.
		/// </summary>
		public ActivityFolder ActivityFolder {
			get {
				return _activityFolder ??
					(_activityFolder = new ActivityFolder(LookupColumnEntities.GetEntity("ActivityFolder")));
			}
		}

		/// <summary>
		/// Path to mailbox folder.
		/// </summary>
		public string FolderPath {
			get {
				return GetTypedColumnValue<string>("FolderPath");
			}
			set {
				SetColumnValue("FolderPath", value);
			}
		}

		/// <summary>
		/// UId of last downloaded letter.
		/// </summary>
		public string UId {
			get {
				return GetTypedColumnValue<string>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// UIdValidity of folder.
		/// </summary>
		public string UIdValidity {
			get {
				return GetTypedColumnValue<string>("UIdValidity");
			}
			set {
				SetColumnValue("UIdValidity", value);
			}
		}

		#endregion

	}

	#endregion

}

