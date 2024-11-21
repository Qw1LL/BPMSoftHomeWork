namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwRemindingsCount

	/// <exclude/>
	public class VwRemindingsCount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwRemindingsCount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRemindingsCount";
		}

		public VwRemindingsCount(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwRemindingsCount";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Number of emails.
		/// </summary>
		public int EmailsCount {
			get {
				return GetTypedColumnValue<int>("EmailsCount");
			}
			set {
				SetColumnValue("EmailsCount", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
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
		/// Number of approvals.
		/// </summary>
		public int VisaCount {
			get {
				return GetTypedColumnValue<int>("VisaCount");
			}
			set {
				SetColumnValue("VisaCount", value);
			}
		}

		#endregion

	}

	#endregion

}

