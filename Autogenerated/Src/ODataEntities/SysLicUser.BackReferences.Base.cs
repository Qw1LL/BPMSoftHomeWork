namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLicUser

	/// <exclude/>
	public class SysLicUser : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLicUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLicUser";
		}

		public SysLicUser(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLicUser";
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

		/// <exclude/>
		public Guid SysLicPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysLicPackageId");
			}
			set {
				SetColumnValue("SysLicPackageId", value);
				_sysLicPackage = null;
			}
		}

		/// <exclude/>
		public string SysLicPackageName {
			get {
				return GetTypedColumnValue<string>("SysLicPackageName");
			}
			set {
				SetColumnValue("SysLicPackageName", value);
				if (_sysLicPackage != null) {
					_sysLicPackage.Name = value;
				}
			}
		}

		private SysLicPackage _sysLicPackage;
		/// <summary>
		/// Product.
		/// </summary>
		public SysLicPackage SysLicPackage {
			get {
				return _sysLicPackage ??
					(_sysLicPackage = new SysLicPackage(LookupColumnEntities.GetEntity("SysLicPackage")));
			}
		}

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SysUser")));
			}
		}

		/// <summary>
		/// License active.
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

		#endregion

	}

	#endregion

}

