namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLic

	/// <exclude/>
	public class SysLic : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLic(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLic";
		}

		public SysLic(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLic";
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
		/// Licensed configuration.
		/// </summary>
		public SysLicPackage SysLicPackage {
			get {
				return _sysLicPackage ??
					(_sysLicPackage = new SysLicPackage(LookupColumnEntities.GetEntity("SysLicPackage")));
			}
		}

		/// <summary>
		/// Quantity.
		/// </summary>
		public int Count {
			get {
				return GetTypedColumnValue<int>("Count");
			}
			set {
				SetColumnValue("Count", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// License type.
		/// </summary>
		public int? LicType {
			get {
				return GetTypedColumnValue<int>("LicType");
			}
			set {
				SetColumnValue("LicType", value);
			}
		}

		/// <summary>
		/// Quantity of objects available for portal users.
		/// </summary>
		public int SSPSchemaCount {
			get {
				return GetTypedColumnValue<int>("SSPSchemaCount");
			}
			set {
				SetColumnValue("SSPSchemaCount", value);
			}
		}

		/// <summary>
		/// Quantity of managed objects available for portal users.
		/// </summary>
		public int SSPAdministratedSchemaCount {
			get {
				return GetTypedColumnValue<int>("SSPAdministratedSchemaCount");
			}
			set {
				SetColumnValue("SSPAdministratedSchemaCount", value);
			}
		}

		/// <summary>
		/// Quantity of custom objects available for portal users.
		/// </summary>
		public int SSPCustomEntityCount {
			get {
				return GetTypedColumnValue<int>("SSPCustomEntityCount");
			}
			set {
				SetColumnValue("SSPCustomEntityCount", value);
			}
		}

		/// <summary>
		/// License version.
		/// </summary>
		public string LicVersion {
			get {
				return GetTypedColumnValue<string>("LicVersion");
			}
			set {
				SetColumnValue("LicVersion", value);
			}
		}

		#endregion

	}

	#endregion

}

