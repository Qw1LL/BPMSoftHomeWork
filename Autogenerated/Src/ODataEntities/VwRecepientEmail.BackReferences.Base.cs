namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwRecepientEmail

	/// <exclude/>
	public class VwRecepientEmail : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwRecepientEmail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRecepientEmail";
		}

		public VwRecepientEmail(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwRecepientEmail";
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
		/// Use email.
		/// </summary>
		public bool UseEmail {
			get {
				return GetTypedColumnValue<bool>("UseEmail");
			}
			set {
				SetColumnValue("UseEmail", value);
			}
		}

		/// <summary>
		/// Contact.
		/// </summary>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
			}
		}

		/// <summary>
		/// Mail address.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Contact name.
		/// </summary>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
			}
		}

		#endregion

	}

	#endregion

}

