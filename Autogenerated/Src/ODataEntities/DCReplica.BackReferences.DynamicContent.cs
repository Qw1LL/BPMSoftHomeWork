namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DCReplica

	/// <exclude/>
	public class DCReplica : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DCReplica(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCReplica";
		}

		public DCReplica(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DCReplica";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<BulkEmailRecipientReplica> BulkEmailRecipientReplicaCollectionByDCReplica {
			get;
			set;
		}

		public IEnumerable<BulkEmailReplicaHeaders> BulkEmailReplicaHeadersCollectionByDCReplica {
			get;
			set;
		}

		public IEnumerable<DCBlockInReplica> DCBlockInReplicaCollectionByDCReplica {
			get;
			set;
		}

		public IEnumerable<DCRecipient> DCRecipientCollectionByDCReplica {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailAudience> VwBulkEmailAudienceCollectionByReplica {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailTarget> VwBulkEmailTargetCollectionByReplica {
			get;
			set;
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

		/// <summary>
		/// Mask.
		/// </summary>
		/// <remarks>
		/// Binary mask.
		/// </remarks>
		public int Mask {
			get {
				return GetTypedColumnValue<int>("Mask");
			}
			set {
				SetColumnValue("Mask", value);
			}
		}

		/// <summary>
		/// Content.
		/// </summary>
		/// <remarks>
		/// HTML content.
		/// </remarks>
		public string Content {
			get {
				return GetTypedColumnValue<string>("Content");
			}
			set {
				SetColumnValue("Content", value);
			}
		}

		/// <exclude/>
		public Guid DCTemplateId {
			get {
				return GetTypedColumnValue<Guid>("DCTemplateId");
			}
			set {
				SetColumnValue("DCTemplateId", value);
				_dCTemplate = null;
			}
		}

		private DCTemplate _dCTemplate;
		/// <summary>
		/// DCTemplate.
		/// </summary>
		public DCTemplate DCTemplate {
			get {
				return _dCTemplate ??
					(_dCTemplate = new DCTemplate(LookupColumnEntities.GetEntity("DCTemplate")));
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

	}

	#endregion

}

