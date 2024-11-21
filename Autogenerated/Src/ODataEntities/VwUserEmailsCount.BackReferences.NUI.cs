namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwUserEmailsCount

	/// <exclude/>
	public class VwUserEmailsCount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwUserEmailsCount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwUserEmailsCount";
		}

		public VwUserEmailsCount(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwUserEmailsCount";
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
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = new SysAdminUnit(LookupColumnEntities.GetEntity("SysAdminUnit")));
			}
		}

		/// <summary>
		/// Number of messages.
		/// </summary>
		public int EmailsCount {
			get {
				return GetTypedColumnValue<int>("EmailsCount");
			}
			set {
				SetColumnValue("EmailsCount", value);
			}
		}

		#endregion

	}

	#endregion

}

