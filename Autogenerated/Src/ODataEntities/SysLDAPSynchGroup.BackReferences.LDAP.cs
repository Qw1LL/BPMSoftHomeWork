namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLDAPSynchGroup

	/// <exclude/>
	public class SysLDAPSynchGroup : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLDAPSynchGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLDAPSynchGroup";
		}

		public SysLDAPSynchGroup(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLDAPSynchGroup";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public string Id {
			get {
				return GetTypedColumnValue<string>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Dn.
		/// </summary>
		public string Dn {
			get {
				return GetTypedColumnValue<string>("Dn");
			}
			set {
				SetColumnValue("Dn", value);
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

		/// <summary>
		/// Synchronization identifier.
		/// </summary>
		public Guid LdapSyncId {
			get {
				return GetTypedColumnValue<Guid>("LdapSyncId");
			}
			set {
				SetColumnValue("LdapSyncId", value);
			}
		}

		#endregion

	}

	#endregion

}

