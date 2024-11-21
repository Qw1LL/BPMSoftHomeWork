namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DomainInfo

	/// <exclude/>
	public class DomainInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DomainInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DomainInfo";
		}

		public DomainInfo(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DomainInfo";
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
		/// Domain.
		/// </summary>
		public string Domain {
			get {
				return GetTypedColumnValue<string>("Domain");
			}
			set {
				SetColumnValue("Domain", value);
			}
		}

		/// <summary>
		/// Verified.
		/// </summary>
		public bool DKIMVerified {
			get {
				return GetTypedColumnValue<bool>("DKIMVerified");
			}
			set {
				SetColumnValue("DKIMVerified", value);
			}
		}

		/// <summary>
		/// Is new.
		/// </summary>
		public bool IsNew {
			get {
				return GetTypedColumnValue<bool>("IsNew");
			}
			set {
				SetColumnValue("IsNew", value);
			}
		}

		#endregion

	}

	#endregion

}

