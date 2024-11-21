namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysPackageSchemaDataColumn

	/// <exclude/>
	public class SysPackageSchemaDataColumn : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysPackageSchemaDataColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageSchemaDataColumn";
		}

		public SysPackageSchemaDataColumn(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysPackageSchemaDataColumn";
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
		public Guid SysPackageSchemaDataId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageSchemaDataId");
			}
			set {
				SetColumnValue("SysPackageSchemaDataId", value);
				_sysPackageSchemaData = null;
			}
		}

		private SysPackageSchemaData _sysPackageSchemaData;
		/// <summary>
		/// Package schema data.
		/// </summary>
		public SysPackageSchemaData SysPackageSchemaData {
			get {
				return _sysPackageSchemaData ??
					(_sysPackageSchemaData = new SysPackageSchemaData(LookupColumnEntities.GetEntity("SysPackageSchemaData")));
			}
		}

		/// <summary>
		/// Column Id.
		/// </summary>
		public Guid PackageSchemaColumnUId {
			get {
				return GetTypedColumnValue<Guid>("PackageSchemaColumnUId");
			}
			set {
				SetColumnValue("PackageSchemaColumnUId", value);
			}
		}

		/// <summary>
		/// Forced update.
		/// </summary>
		public bool IsForceUpdate {
			get {
				return GetTypedColumnValue<bool>("IsForceUpdate");
			}
			set {
				SetColumnValue("IsForceUpdate", value);
			}
		}

		/// <summary>
		/// Key.
		/// </summary>
		public bool IsKey {
			get {
				return GetTypedColumnValue<bool>("IsKey");
			}
			set {
				SetColumnValue("IsKey", value);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Data type Id.
		/// </summary>
		public Guid DataValueTypeUId {
			get {
				return GetTypedColumnValue<Guid>("DataValueTypeUId");
			}
			set {
				SetColumnValue("DataValueTypeUId", value);
			}
		}

		#endregion

	}

	#endregion

}

