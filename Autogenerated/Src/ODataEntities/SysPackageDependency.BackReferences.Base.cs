namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysPackageDependency

	/// <exclude/>
	public class SysPackageDependency : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPackageDependency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageDependency";
		}

		public SysPackageDependency(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPackageDependency";
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
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = new SysPackage(LookupColumnEntities.GetEntity("SysPackage")));
			}
		}

		/// <exclude/>
		public Guid DependOnPackageId {
			get {
				return GetTypedColumnValue<Guid>("DependOnPackageId");
			}
			set {
				SetColumnValue("DependOnPackageId", value);
				_dependOnPackage = null;
			}
		}

		/// <exclude/>
		public string DependOnPackageName {
			get {
				return GetTypedColumnValue<string>("DependOnPackageName");
			}
			set {
				SetColumnValue("DependOnPackageName", value);
				if (_dependOnPackage != null) {
					_dependOnPackage.Name = value;
				}
			}
		}

		private SysPackage _dependOnPackage;
		/// <summary>
		/// Depends on package.
		/// </summary>
		public SysPackage DependOnPackage {
			get {
				return _dependOnPackage ??
					(_dependOnPackage = new SysPackage(LookupColumnEntities.GetEntity("DependOnPackage")));
			}
		}

		/// <summary>
		/// Depends on package version.
		/// </summary>
		public string DependOnPackageVersion {
			get {
				return GetTypedColumnValue<string>("DependOnPackageVersion");
			}
			set {
				SetColumnValue("DependOnPackageVersion", value);
			}
		}

		#endregion

	}

	#endregion

}

