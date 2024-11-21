namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailSubscription

	/// <exclude/>
	public class BulkEmailSubscription : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailSubscription(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSubscription";
		}

		public BulkEmailSubscription(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailSubscription";
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
		public Guid BulkEmailTypeId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailTypeId");
			}
			set {
				SetColumnValue("BulkEmailTypeId", value);
				_bulkEmailType = null;
			}
		}

		/// <exclude/>
		public string BulkEmailTypeName {
			get {
				return GetTypedColumnValue<string>("BulkEmailTypeName");
			}
			set {
				SetColumnValue("BulkEmailTypeName", value);
				if (_bulkEmailType != null) {
					_bulkEmailType.Name = value;
				}
			}
		}

		private BulkEmailType _bulkEmailType;
		/// <summary>
		/// Тип рассылки.
		/// </summary>
		public BulkEmailType BulkEmailType {
			get {
				return _bulkEmailType ??
					(_bulkEmailType = new BulkEmailType(LookupColumnEntities.GetEntity("BulkEmailType")));
			}
		}

		/// <exclude/>
		public Guid BulkEmailSubsStatusId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailSubsStatusId");
			}
			set {
				SetColumnValue("BulkEmailSubsStatusId", value);
				_bulkEmailSubsStatus = null;
			}
		}

		/// <exclude/>
		public string BulkEmailSubsStatusName {
			get {
				return GetTypedColumnValue<string>("BulkEmailSubsStatusName");
			}
			set {
				SetColumnValue("BulkEmailSubsStatusName", value);
				if (_bulkEmailSubsStatus != null) {
					_bulkEmailSubsStatus.Name = value;
				}
			}
		}

		private BulkEmailSubsStatus _bulkEmailSubsStatus;
		/// <summary>
		/// Статус подписки.
		/// </summary>
		public BulkEmailSubsStatus BulkEmailSubsStatus {
			get {
				return _bulkEmailSubsStatus ??
					(_bulkEmailSubsStatus = new BulkEmailSubsStatus(LookupColumnEntities.GetEntity("BulkEmailSubsStatus")));
			}
		}

		#endregion

	}

	#endregion

}

