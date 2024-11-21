namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLDAPSynchUser

	/// <exclude/>
	public class SysLDAPSynchUser : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLDAPSynchUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLDAPSynchUser";
		}

		public SysLDAPSynchUser(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLDAPSynchUser";
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
		/// Modification date.
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
		/// Company.
		/// </summary>
		public string Company {
			get {
				return GetTypedColumnValue<string>("Company");
			}
			set {
				SetColumnValue("Company", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// Phone.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <summary>
		/// Job title.
		/// </summary>
		public string JobTitle {
			get {
				return GetTypedColumnValue<string>("JobTitle");
			}
			set {
				SetColumnValue("JobTitle", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Full name.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
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

