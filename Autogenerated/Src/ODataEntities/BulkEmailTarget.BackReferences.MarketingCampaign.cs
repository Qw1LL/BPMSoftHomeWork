namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailTarget

	/// <exclude/>
	public class BulkEmailTarget : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailTarget(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailTarget";
		}

		public BulkEmailTarget(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailTarget";
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
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

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
		/// Рассылка.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = new BulkEmail(LookupColumnEntities.GetEntity("BulkEmail")));
			}
		}

		/// <exclude/>
		public Guid BulkEmailResponseId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailResponseId");
			}
			set {
				SetColumnValue("BulkEmailResponseId", value);
				_bulkEmailResponse = null;
			}
		}

		/// <exclude/>
		public string BulkEmailResponseName {
			get {
				return GetTypedColumnValue<string>("BulkEmailResponseName");
			}
			set {
				SetColumnValue("BulkEmailResponseName", value);
				if (_bulkEmailResponse != null) {
					_bulkEmailResponse.Name = value;
				}
			}
		}

		private BulkEmailResponse _bulkEmailResponse;
		/// <summary>
		/// Отклик.
		/// </summary>
		public BulkEmailResponse BulkEmailResponse {
			get {
				return _bulkEmailResponse ??
					(_bulkEmailResponse = new BulkEmailResponse(LookupColumnEntities.GetEntity("BulkEmailResponse")));
			}
		}

		/// <summary>
		/// Переходы.
		/// </summary>
		public int Clicks {
			get {
				return GetTypedColumnValue<int>("Clicks");
			}
			set {
				SetColumnValue("Clicks", value);
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
		/// Email адрес.
		/// </summary>
		public string EmailAddress {
			get {
				return GetTypedColumnValue<string>("EmailAddress");
			}
			set {
				SetColumnValue("EmailAddress", value);
			}
		}

		/// <summary>
		/// Extended entity.
		/// </summary>
		public Guid LinkedEntityId {
			get {
				return GetTypedColumnValue<Guid>("LinkedEntityId");
			}
			set {
				SetColumnValue("LinkedEntityId", value);
			}
		}

		/// <summary>
		/// MandrillId.
		/// </summary>
		public Guid MandrillId {
			get {
				return GetTypedColumnValue<Guid>("MandrillId");
			}
			set {
				SetColumnValue("MandrillId", value);
			}
		}

		/// <summary>
		/// Открытия.
		/// </summary>
		public int Opens {
			get {
				return GetTypedColumnValue<int>("Opens");
			}
			set {
				SetColumnValue("Opens", value);
			}
		}

		/// <summary>
		/// Провайдер отправки.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		#endregion

	}

	#endregion

}

