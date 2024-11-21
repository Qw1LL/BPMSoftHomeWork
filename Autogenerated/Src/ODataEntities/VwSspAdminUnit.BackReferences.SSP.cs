namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSspAdminUnit

	/// <exclude/>
	public class VwSspAdminUnit : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSspAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSspAdminUnit";
		}

		public VwSspAdminUnit(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSspAdminUnit";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<VwSspAdminUnit> VwSspAdminUnitCollectionByParentRole {
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

		private VwSspAdminUnit _parentRole;
		/// <summary>
		/// Parent role.
		/// </summary>
		public VwSspAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = new VwSspAdminUnit(LookupColumnEntities.GetEntity("ParentRole")));
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
		/// Contact.
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

		/// <exclude/>
		public Guid PortalAccountId {
			get {
				return GetTypedColumnValue<Guid>("PortalAccountId");
			}
			set {
				SetColumnValue("PortalAccountId", value);
				_portalAccount = null;
			}
		}

		/// <exclude/>
		public string PortalAccountName {
			get {
				return GetTypedColumnValue<string>("PortalAccountName");
			}
			set {
				SetColumnValue("PortalAccountName", value);
				if (_portalAccount != null) {
					_portalAccount.Name = value;
				}
			}
		}

		private Account _portalAccount;
		/// <summary>
		/// Account.
		/// </summary>
		public Account PortalAccount {
			get {
				return _portalAccount ??
					(_portalAccount = new Account(LookupColumnEntities.GetEntity("PortalAccount")));
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitTypeId");
			}
			set {
				SetColumnValue("SysAdminUnitTypeId", value);
				_sysAdminUnitType = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitTypeName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitTypeName");
			}
			set {
				SetColumnValue("SysAdminUnitTypeName", value);
				if (_sysAdminUnitType != null) {
					_sysAdminUnitType.Name = value;
				}
			}
		}

		private SysAdminUnitType _sysAdminUnitType;
		/// <summary>
		/// Type.
		/// </summary>
		public SysAdminUnitType SysAdminUnitType {
			get {
				return _sysAdminUnitType ??
					(_sysAdminUnitType = new SysAdminUnitType(LookupColumnEntities.GetEntity("SysAdminUnitType")));
			}
		}

		/// <summary>
		/// License name.
		/// </summary>
		public string LicenseName {
			get {
				return GetTypedColumnValue<string>("LicenseName");
			}
			set {
				SetColumnValue("LicenseName", value);
			}
		}

		#endregion

	}

	#endregion

}

