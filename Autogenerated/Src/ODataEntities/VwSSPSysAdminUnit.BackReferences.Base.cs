namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSSPSysAdminUnit

	/// <exclude/>
	public class VwSSPSysAdminUnit : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSSPSysAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSSPSysAdminUnit";
		}

		public VwSSPSysAdminUnit(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSSPSysAdminUnit";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<VwSSPSysAdminUnit> VwSSPSysAdminUnitCollectionByParentRole {
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
		/// Type.
		/// </summary>
		public int SysAdminUnitTypeValue {
			get {
				return GetTypedColumnValue<int>("SysAdminUnitTypeValue");
			}
			set {
				SetColumnValue("SysAdminUnitTypeValue", value);
			}
		}

		/// <exclude/>
		public Guid ParentRoleId {
			get {
				return GetTypedColumnValue<Guid>("ParentRoleId");
			}
			set {
				SetColumnValue("ParentRoleId", value);
				_parentRole = null;
			}
		}

		/// <exclude/>
		public string ParentRoleName {
			get {
				return GetTypedColumnValue<string>("ParentRoleName");
			}
			set {
				SetColumnValue("ParentRoleName", value);
				if (_parentRole != null) {
					_parentRole.Name = value;
				}
			}
		}

		private VwSSPSysAdminUnit _parentRole;
		/// <summary>
		/// Inherited from.
		/// </summary>
		public VwSSPSysAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = new VwSSPSysAdminUnit(LookupColumnEntities.GetEntity("ParentRole")));
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
		/// Employee.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <summary>
		/// Domain user.
		/// </summary>
		public bool IsDirectoryEntry {
			get {
				return GetTypedColumnValue<bool>("IsDirectoryEntry");
			}
			set {
				SetColumnValue("IsDirectoryEntry", value);
			}
		}

		/// <summary>
		/// Time zone.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Synchronize with LDAP.
		/// </summary>
		public bool SynchronizeWithLDAP {
			get {
				return GetTypedColumnValue<bool>("SynchronizeWithLDAP");
			}
			set {
				SetColumnValue("SynchronizeWithLDAP", value);
			}
		}

		/// <summary>
		/// LDAP element.
		/// </summary>
		public string LDAPEntry {
			get {
				return GetTypedColumnValue<string>("LDAPEntry");
			}
			set {
				SetColumnValue("LDAPEntry", value);
			}
		}

		/// <summary>
		/// LDAP element Id.
		/// </summary>
		public string LDAPEntryId {
			get {
				return GetTypedColumnValue<string>("LDAPEntryId");
			}
			set {
				SetColumnValue("LDAPEntryId", value);
			}
		}

		/// <summary>
		/// LDAP element unique name.
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <summary>
		/// Logged in now.
		/// </summary>
		public bool LoggedIn {
			get {
				return GetTypedColumnValue<bool>("LoggedIn");
			}
			set {
				SetColumnValue("LoggedIn", value);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = new SysCulture(LookupColumnEntities.GetEntity("SysCulture")));
			}
		}

		/// <summary>
		/// Number of logon attempts.
		/// </summary>
		public int LoginAttemptCount {
			get {
				return GetTypedColumnValue<int>("LoginAttemptCount");
			}
			set {
				SetColumnValue("LoginAttemptCount", value);
			}
		}

		/// <summary>
		/// Repository login.
		/// </summary>
		public string SourceControlLogin {
			get {
				return GetTypedColumnValue<string>("SourceControlLogin");
			}
			set {
				SetColumnValue("SourceControlLogin", value);
			}
		}

		/// <summary>
		/// Repository password.
		/// </summary>
		public string SourceControlPassword {
			get {
				return GetTypedColumnValue<string>("SourceControlPassword");
			}
			set {
				SetColumnValue("SourceControlPassword", value);
			}
		}

		/// <summary>
		/// Password expiration date.
		/// </summary>
		public DateTime PasswordExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("PasswordExpireDate");
			}
			set {
				SetColumnValue("PasswordExpireDate", value);
			}
		}

		/// <exclude/>
		public Guid HomePageId {
			get {
				return GetTypedColumnValue<Guid>("HomePageId");
			}
			set {
				SetColumnValue("HomePageId", value);
				_homePage = null;
			}
		}

		/// <exclude/>
		public string HomePageCaption {
			get {
				return GetTypedColumnValue<string>("HomePageCaption");
			}
			set {
				SetColumnValue("HomePageCaption", value);
				if (_homePage != null) {
					_homePage.Caption = value;
				}
			}
		}

		private SysModule _homePage;
		/// <summary>
		/// Home page.
		/// </summary>
		public SysModule HomePage {
			get {
				return _homePage ??
					(_homePage = new SysModule(LookupColumnEntities.GetEntity("HomePage")));
			}
		}

		/// <summary>
		/// Connection type.
		/// </summary>
		public int ConnectionType {
			get {
				return GetTypedColumnValue<int>("ConnectionType");
			}
			set {
				SetColumnValue("ConnectionType", value);
			}
		}

		#endregion

	}

	#endregion

}

