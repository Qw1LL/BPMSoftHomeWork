namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OptionalFuncSspRole

	/// <exclude/>
	public class OptionalFuncSspRole : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OptionalFuncSspRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OptionalFuncSspRole";
		}

		public OptionalFuncSspRole(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OptionalFuncSspRole";
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
		public Guid OrgRoleId {
			get {
				return GetTypedColumnValue<Guid>("OrgRoleId");
			}
			set {
				SetColumnValue("OrgRoleId", value);
				_orgRole = null;
			}
		}

		/// <exclude/>
		public string OrgRoleName {
			get {
				return GetTypedColumnValue<string>("OrgRoleName");
			}
			set {
				SetColumnValue("OrgRoleName", value);
				if (_orgRole != null) {
					_orgRole.Name = value;
				}
			}
		}

		private SysAdminUnit _orgRole;
		/// <summary>
		/// Organizational role.
		/// </summary>
		public SysAdminUnit OrgRole {
			get {
				return _orgRole ??
					(_orgRole = new SysAdminUnit(LookupColumnEntities.GetEntity("OrgRole")));
			}
		}

		/// <exclude/>
		public Guid FuncRoleId {
			get {
				return GetTypedColumnValue<Guid>("FuncRoleId");
			}
			set {
				SetColumnValue("FuncRoleId", value);
				_funcRole = null;
			}
		}

		/// <exclude/>
		public string FuncRoleName {
			get {
				return GetTypedColumnValue<string>("FuncRoleName");
			}
			set {
				SetColumnValue("FuncRoleName", value);
				if (_funcRole != null) {
					_funcRole.Name = value;
				}
			}
		}

		private SysAdminUnit _funcRole;
		/// <summary>
		/// Functional role.
		/// </summary>
		public SysAdminUnit FuncRole {
			get {
				return _funcRole ??
					(_funcRole = new SysAdminUnit(LookupColumnEntities.GetEntity("FuncRole")));
			}
		}

		#endregion

	}

	#endregion

}

