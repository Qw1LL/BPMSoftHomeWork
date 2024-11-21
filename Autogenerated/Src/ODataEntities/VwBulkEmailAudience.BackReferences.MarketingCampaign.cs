namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwBulkEmailAudience

	/// <exclude/>
	public class VwBulkEmailAudience : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwBulkEmailAudience(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBulkEmailAudience";
		}

		public VwBulkEmailAudience(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwBulkEmailAudience";
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

		/// <summary>
		/// Email.
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
		/// Отправлено.
		/// </summary>
		public bool IsSent {
			get {
				return GetTypedColumnValue<bool>("IsSent");
			}
			set {
				SetColumnValue("IsSent", value);
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
		/// Расширенный объект.
		/// </summary>
		public Contact LinkedEntity {
			get {
				return _linkedEntity ??
					(_linkedEntity = new Contact(LookupColumnEntities.GetEntity("LinkedEntity")));
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

		/// <exclude/>
		public Guid ReplicaId {
			get {
				return GetTypedColumnValue<Guid>("ReplicaId");
			}
			set {
				SetColumnValue("ReplicaId", value);
				_replica = null;
			}
		}

		/// <exclude/>
		public string ReplicaCaption {
			get {
				return GetTypedColumnValue<string>("ReplicaCaption");
			}
			set {
				SetColumnValue("ReplicaCaption", value);
				if (_replica != null) {
					_replica.Caption = value;
				}
			}
		}

		private DCReplica _replica;
		/// <summary>
		/// Реплика динамического контента.
		/// </summary>
		public DCReplica Replica {
			get {
				return _replica ??
					(_replica = new DCReplica(LookupColumnEntities.GetEntity("Replica")));
			}
		}

		/// <summary>
		/// Сессия.
		/// </summary>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		/// <remarks>
		/// Дата изменения.
		/// </remarks>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
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

