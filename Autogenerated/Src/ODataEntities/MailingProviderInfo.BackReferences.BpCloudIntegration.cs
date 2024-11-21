namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MailingProviderInfo

	/// <exclude/>
	public class MailingProviderInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailingProviderInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailingProviderInfo";
		}

		public MailingProviderInfo(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MailingProviderInfo";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Is default.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
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
		/// Email provider.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		/// <summary>
		/// Is connected.
		/// </summary>
		public string IsConnected {
			get {
				return GetTypedColumnValue<string>("IsConnected");
			}
			set {
				SetColumnValue("IsConnected", value);
			}
		}

		#endregion

	}

	#endregion

}

