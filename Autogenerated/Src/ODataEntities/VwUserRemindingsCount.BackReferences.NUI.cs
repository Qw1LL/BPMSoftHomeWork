namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwUserRemindingsCount

	/// <exclude/>
	public class VwUserRemindingsCount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwUserRemindingsCount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwUserRemindingsCount";
		}

		public VwUserRemindingsCount(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwUserRemindingsCount";
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
		/// Number of notifications.
		/// </summary>
		public int RemindingsCount {
			get {
				return GetTypedColumnValue<int>("RemindingsCount");
			}
			set {
				SetColumnValue("RemindingsCount", value);
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
		/// Time of reminder.
		/// </summary>
		public DateTime RemindTime {
			get {
				return GetTypedColumnValue<DateTime>("RemindTime");
			}
			set {
				SetColumnValue("RemindTime", value);
			}
		}

		/// <summary>
		/// Time zone.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
			}
		}

		#endregion

	}

	#endregion

}

