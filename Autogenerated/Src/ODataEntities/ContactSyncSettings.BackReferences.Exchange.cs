namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ContactSyncSettings

	/// <exclude/>
	public class ContactSyncSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ContactSyncSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactSyncSettings";
		}

		public ContactSyncSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ContactSyncSettings";
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
		/// Import contacts.
		/// </summary>
		public bool ImportContacts {
			get {
				return GetTypedColumnValue<bool>("ImportContacts");
			}
			set {
				SetColumnValue("ImportContacts", value);
			}
		}

		/// <summary>
		/// Import all contacts.
		/// </summary>
		public bool ImportContactsAll {
			get {
				return GetTypedColumnValue<bool>("ImportContactsAll");
			}
			set {
				SetColumnValue("ImportContactsAll", value);
			}
		}

		/// <summary>
		/// Import contacts from folders.
		/// </summary>
		public bool ImportContactsFromFolders {
			get {
				return GetTypedColumnValue<bool>("ImportContactsFromFolders");
			}
			set {
				SetColumnValue("ImportContactsFromFolders", value);
			}
		}

		/// <summary>
		/// Import contacts from categories.
		/// </summary>
		public bool ImportContactsFromCategories {
			get {
				return GetTypedColumnValue<bool>("ImportContactsFromCategories");
			}
			set {
				SetColumnValue("ImportContactsFromCategories", value);
			}
		}

		/// <exclude/>
		public Guid LinkContactToAccountId {
			get {
				return GetTypedColumnValue<Guid>("LinkContactToAccountId");
			}
			set {
				SetColumnValue("LinkContactToAccountId", value);
				_linkContactToAccount = null;
			}
		}

		/// <exclude/>
		public string LinkContactToAccountName {
			get {
				return GetTypedColumnValue<string>("LinkContactToAccountName");
			}
			set {
				SetColumnValue("LinkContactToAccountName", value);
				if (_linkContactToAccount != null) {
					_linkContactToAccount.Name = value;
				}
			}
		}

		private LinkContactToAccount _linkContactToAccount;
		/// <summary>
		/// Connect contacts to accounts.
		/// </summary>
		public LinkContactToAccount LinkContactToAccount {
			get {
				return _linkContactToAccount ??
					(_linkContactToAccount = new LinkContactToAccount(LookupColumnEntities.GetEntity("LinkContactToAccount")));
			}
		}

		/// <summary>
		/// Export all contacts.
		/// </summary>
		public bool ExportContactsAll {
			get {
				return GetTypedColumnValue<bool>("ExportContactsAll");
			}
			set {
				SetColumnValue("ExportContactsAll", value);
			}
		}

		/// <summary>
		/// Export selected contacts.
		/// </summary>
		public bool ExportContactsSelected {
			get {
				return GetTypedColumnValue<bool>("ExportContactsSelected");
			}
			set {
				SetColumnValue("ExportContactsSelected", value);
			}
		}

		/// <summary>
		/// Export employee contacts.
		/// </summary>
		public bool ExportContactsEmployers {
			get {
				return GetTypedColumnValue<bool>("ExportContactsEmployers");
			}
			set {
				SetColumnValue("ExportContactsEmployers", value);
			}
		}

		/// <summary>
		/// Export customer contacts.
		/// </summary>
		public bool ExportContactsCustomers {
			get {
				return GetTypedColumnValue<bool>("ExportContactsCustomers");
			}
			set {
				SetColumnValue("ExportContactsCustomers", value);
			}
		}

		/// <summary>
		/// Export my contacts.
		/// </summary>
		public bool ExportContactsOwner {
			get {
				return GetTypedColumnValue<bool>("ExportContactsOwner");
			}
			set {
				SetColumnValue("ExportContactsOwner", value);
			}
		}

		/// <summary>
		/// Export contacts from folders.
		/// </summary>
		public bool ExportContactsFromGroups {
			get {
				return GetTypedColumnValue<bool>("ExportContactsFromGroups");
			}
			set {
				SetColumnValue("ExportContactsFromGroups", value);
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
		/// LastSyncDate.
		/// </summary>
		public DateTime LastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("LastSyncDate");
			}
			set {
				SetColumnValue("LastSyncDate", value);
			}
		}

		/// <summary>
		/// LoadContactsFromDate.
		/// </summary>
		public DateTime LoadContactsFromDate {
			get {
				return GetTypedColumnValue<DateTime>("LoadContactsFromDate");
			}
			set {
				SetColumnValue("LoadContactsFromDate", value);
			}
		}

		/// <summary>
		/// Export contacts.
		/// </summary>
		public bool ExportContacts {
			get {
				return GetTypedColumnValue<bool>("ExportContacts");
			}
			set {
				SetColumnValue("ExportContacts", value);
			}
		}

		/// <summary>
		/// Contact folders for import.
		/// </summary>
		public string ImportContactsFolders {
			get {
				return GetTypedColumnValue<string>("ImportContactsFolders");
			}
			set {
				SetColumnValue("ImportContactsFolders", value);
			}
		}

		/// <summary>
		/// Contact categories for import.
		/// </summary>
		public string ImportContactsCategories {
			get {
				return GetTypedColumnValue<string>("ImportContactsCategories");
			}
			set {
				SetColumnValue("ImportContactsCategories", value);
			}
		}

		/// <summary>
		/// Contact folders for export.
		/// </summary>
		public string ExportContactsGroups {
			get {
				return GetTypedColumnValue<string>("ExportContactsGroups");
			}
			set {
				SetColumnValue("ExportContactsGroups", value);
			}
		}

		#endregion

	}

	#endregion

}

