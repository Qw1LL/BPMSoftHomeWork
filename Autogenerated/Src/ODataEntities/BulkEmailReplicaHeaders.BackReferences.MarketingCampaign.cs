namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmailReplicaHeaders

	/// <exclude/>
	public class BulkEmailReplicaHeaders : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailReplicaHeaders(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailReplicaHeaders";
		}

		public BulkEmailReplicaHeaders(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmailReplicaHeaders";
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
		/// BulkEmail.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = new BulkEmail(LookupColumnEntities.GetEntity("BulkEmail")));
			}
		}

		/// <exclude/>
		public Guid DCReplicaId {
			get {
				return GetTypedColumnValue<Guid>("DCReplicaId");
			}
			set {
				SetColumnValue("DCReplicaId", value);
				_dCReplica = null;
			}
		}

		/// <exclude/>
		public string DCReplicaCaption {
			get {
				return GetTypedColumnValue<string>("DCReplicaCaption");
			}
			set {
				SetColumnValue("DCReplicaCaption", value);
				if (_dCReplica != null) {
					_dCReplica.Caption = value;
				}
			}
		}

		private DCReplica _dCReplica;
		/// <summary>
		/// Реплика.
		/// </summary>
		public DCReplica DCReplica {
			get {
				return _dCReplica ??
					(_dCReplica = new DCReplica(LookupColumnEntities.GetEntity("DCReplica")));
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Pre-header.
		/// </summary>
		public string Preheader {
			get {
				return GetTypedColumnValue<string>("Preheader");
			}
			set {
				SetColumnValue("Preheader", value);
			}
		}

		/// <summary>
		/// Email отправителя.
		/// </summary>
		public string SenderEmail {
			get {
				return GetTypedColumnValue<string>("SenderEmail");
			}
			set {
				SetColumnValue("SenderEmail", value);
			}
		}

		/// <summary>
		/// Имя отправителя.
		/// </summary>
		public string SenderName {
			get {
				return GetTypedColumnValue<string>("SenderName");
			}
			set {
				SetColumnValue("SenderName", value);
			}
		}

		#endregion

	}

	#endregion

}

