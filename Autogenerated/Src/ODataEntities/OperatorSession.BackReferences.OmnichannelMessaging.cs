namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OperatorSession

	/// <exclude/>
	public class OperatorSession : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OperatorSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OperatorSession";
		}

		public OperatorSession(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OperatorSession";
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
		/// Session start.
		/// </summary>
		public DateTime SessionStartDate {
			get {
				return GetTypedColumnValue<DateTime>("SessionStartDate");
			}
			set {
				SetColumnValue("SessionStartDate", value);
			}
		}

		/// <summary>
		/// Session end.
		/// </summary>
		public DateTime SessionEndDate {
			get {
				return GetTypedColumnValue<DateTime>("SessionEndDate");
			}
			set {
				SetColumnValue("SessionEndDate", value);
			}
		}

		/// <exclude/>
		public Guid OperatorStateId {
			get {
				return GetTypedColumnValue<Guid>("OperatorStateId");
			}
			set {
				SetColumnValue("OperatorStateId", value);
				_operatorState = null;
			}
		}

		/// <exclude/>
		public string OperatorStateName {
			get {
				return GetTypedColumnValue<string>("OperatorStateName");
			}
			set {
				SetColumnValue("OperatorStateName", value);
				if (_operatorState != null) {
					_operatorState.Name = value;
				}
			}
		}

		private OperatorState _operatorState;
		/// <summary>
		/// Operator's current state.
		/// </summary>
		public OperatorState OperatorState {
			get {
				return _operatorState ??
					(_operatorState = new OperatorState(LookupColumnEntities.GetEntity("OperatorState")));
			}
		}

		/// <summary>
		/// Duration, min.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		#endregion

	}

	#endregion

}

