namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwMandrillRecipientV2

	/// <exclude/>
	public class VwMandrillRecipientV2 : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwMandrillRecipientV2(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwMandrillRecipientV2";
		}

		public VwMandrillRecipientV2(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwMandrillRecipientV2";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Email.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = new BulkEmail(LookupColumnEntities.GetEntity("BulkEmail")));
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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
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

		/// <exclude/>
		public Guid LinkedEntityId {
			get {
				return GetTypedColumnValue<Guid>("LinkedEntityId");
			}
			set {
				SetColumnValue("LinkedEntityId", value);
				_linkedEntity = null;
			}
		}

		/// <exclude/>
		public string LinkedEntityName {
			get {
				return GetTypedColumnValue<string>("LinkedEntityName");
			}
			set {
				SetColumnValue("LinkedEntityName", value);
				if (_linkedEntity != null) {
					_linkedEntity.Name = value;
				}
			}
		}

		private Contact _linkedEntity;
		/// <summary>
		/// Связанная сущность.
		/// </summary>
		public Contact LinkedEntity {
			get {
				return _linkedEntity ??
					(_linkedEntity = new Contact(LookupColumnEntities.GetEntity("LinkedEntity")));
			}
		}

		#endregion

	}

	#endregion

}

