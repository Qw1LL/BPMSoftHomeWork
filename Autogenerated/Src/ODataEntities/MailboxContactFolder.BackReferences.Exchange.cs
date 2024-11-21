namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MailboxContactFolder

	/// <exclude/>
	public class MailboxContactFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailboxContactFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxContactFolder";
		}

		public MailboxContactFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MailboxContactFolder";
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

		/// <exclude/>
		public Guid ContactFolderId {
			get {
				return GetTypedColumnValue<Guid>("ContactFolderId");
			}
			set {
				SetColumnValue("ContactFolderId", value);
				_contactFolder = null;
			}
		}

		/// <exclude/>
		public string ContactFolderName {
			get {
				return GetTypedColumnValue<string>("ContactFolderName");
			}
			set {
				SetColumnValue("ContactFolderName", value);
				if (_contactFolder != null) {
					_contactFolder.Name = value;
				}
			}
		}

		private ContactFolder _contactFolder;
		/// <summary>
		/// Contact folder.
		/// </summary>
		public ContactFolder ContactFolder {
			get {
				return _contactFolder ??
					(_contactFolder = new ContactFolder(LookupColumnEntities.GetEntity("ContactFolder")));
			}
		}

		/// <summary>
		/// External storage folder Id.
		/// </summary>
		public string RemoteFolderId {
			get {
				return GetTypedColumnValue<string>("RemoteFolderId");
			}
			set {
				SetColumnValue("RemoteFolderId", value);
			}
		}

		#endregion

	}

	#endregion

}

