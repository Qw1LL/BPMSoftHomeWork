namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysAdminUnitInWorkplace

	/// <exclude/>
	public class SysAdminUnitInWorkplace : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysAdminUnitInWorkplace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitInWorkplace";
		}

		public SysAdminUnitInWorkplace(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysAdminUnitInWorkplace";
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
		public Guid SysWorkplaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkplaceId");
			}
			set {
				SetColumnValue("SysWorkplaceId", value);
				_sysWorkplace = null;
			}
		}

		/// <exclude/>
		public string SysWorkplaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkplaceName");
			}
			set {
				SetColumnValue("SysWorkplaceName", value);
				if (_sysWorkplace != null) {
					_sysWorkplace.Name = value;
				}
			}
		}

		private SysWorkplace _sysWorkplace;
		/// <summary>
		/// Workplace.
		/// </summary>
		public SysWorkplace SysWorkplace {
			get {
				return _sysWorkplace ??
					(_sysWorkplace = new SysWorkplace(LookupColumnEntities.GetEntity("SysWorkplace")));
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// Object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = new SysAdminUnit(LookupColumnEntities.GetEntity("SysAdminUnit")));
			}
		}

		#endregion

	}

	#endregion

}

