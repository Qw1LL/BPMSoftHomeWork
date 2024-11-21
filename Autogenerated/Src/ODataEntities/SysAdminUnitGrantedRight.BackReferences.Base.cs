namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysAdminUnitGrantedRight

	/// <exclude/>
	public class SysAdminUnitGrantedRight : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysAdminUnitGrantedRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitGrantedRight";
		}

		public SysAdminUnitGrantedRight(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysAdminUnitGrantedRight";
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
		public Guid GrantorSysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("GrantorSysAdminUnitId");
			}
			set {
				SetColumnValue("GrantorSysAdminUnitId", value);
				_grantorSysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string GrantorSysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("GrantorSysAdminUnitName");
			}
			set {
				SetColumnValue("GrantorSysAdminUnitName", value);
				if (_grantorSysAdminUnit != null) {
					_grantorSysAdminUnit.Name = value;
				}
			}
		}

		private VwSysAdminUnit _grantorSysAdminUnit;
		/// <summary>
		/// Who grants permissions.
		/// </summary>
		public VwSysAdminUnit GrantorSysAdminUnit {
			get {
				return _grantorSysAdminUnit ??
					(_grantorSysAdminUnit = new VwSysAdminUnit(LookupColumnEntities.GetEntity("GrantorSysAdminUnit")));
			}
		}

		/// <exclude/>
		public Guid GranteeSysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("GranteeSysAdminUnitId");
			}
			set {
				SetColumnValue("GranteeSysAdminUnitId", value);
				_granteeSysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string GranteeSysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("GranteeSysAdminUnitName");
			}
			set {
				SetColumnValue("GranteeSysAdminUnitName", value);
				if (_granteeSysAdminUnit != null) {
					_granteeSysAdminUnit.Name = value;
				}
			}
		}

		private VwSysAdminUnit _granteeSysAdminUnit;
		/// <summary>
		/// Who receives permissions.
		/// </summary>
		public VwSysAdminUnit GranteeSysAdminUnit {
			get {
				return _granteeSysAdminUnit ??
					(_granteeSysAdminUnit = new VwSysAdminUnit(LookupColumnEntities.GetEntity("GranteeSysAdminUnit")));
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

