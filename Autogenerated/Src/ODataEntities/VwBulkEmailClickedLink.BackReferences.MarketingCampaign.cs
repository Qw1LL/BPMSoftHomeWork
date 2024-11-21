namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwBulkEmailClickedLink

	/// <exclude/>
	public class VwBulkEmailClickedLink : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwBulkEmailClickedLink(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBulkEmailClickedLink";
		}

		public VwBulkEmailClickedLink(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwBulkEmailClickedLink";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid BulkEmailHyperlinkId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailHyperlinkId");
			}
			set {
				SetColumnValue("BulkEmailHyperlinkId", value);
				_bulkEmailHyperlink = null;
			}
		}

		/// <exclude/>
		public string BulkEmailHyperlinkCaption {
			get {
				return GetTypedColumnValue<string>("BulkEmailHyperlinkCaption");
			}
			set {
				SetColumnValue("BulkEmailHyperlinkCaption", value);
				if (_bulkEmailHyperlink != null) {
					_bulkEmailHyperlink.Caption = value;
				}
			}
		}

		private BulkEmailHyperlink _bulkEmailHyperlink;
		/// <summary>
		/// Ссылка.
		/// </summary>
		public BulkEmailHyperlink BulkEmailHyperlink {
			get {
				return _bulkEmailHyperlink ??
					(_bulkEmailHyperlink = new BulkEmailHyperlink(LookupColumnEntities.GetEntity("BulkEmailHyperlink")));
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

		#endregion

	}

	#endregion

}

