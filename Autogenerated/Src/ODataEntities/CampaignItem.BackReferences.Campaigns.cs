namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignItem

	/// <exclude/>
	public class CampaignItem : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignItem";
		}

		public CampaignItem(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignItem";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CampaignAnalyticsLog> CampaignAnalyticsLogCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<CampaignLog> CampaignLogCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<CampaignParticipant> CampaignParticipantCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<CampaignParticipantOp> CampaignParticipantOpCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<CampaignParticipantOp> CampaignParticipantOpCollectionByInitialCampaignItem {
			get;
			set;
		}

		public IEnumerable<CampaignQueue> CampaignQueueCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<CampaignSignal> CampaignSignalCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailInCampaign> VwBulkEmailInCampaignCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<VwCampaignLog> VwCampaignLogCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<VwEventInCampaign> VwEventInCampaignCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<VwFolderInCampaign> VwFolderInCampaignCollectionByCampaignItem {
			get;
			set;
		}

		public IEnumerable<VwLandingInCampaign> VwLandingInCampaignCollectionByCampaignItem {
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

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = new Campaign(LookupColumnEntities.GetEntity("Campaign")));
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Удален.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
			}
		}

		/// <summary>
		/// Тип элемента кампании.
		/// </summary>
		public string CampaignElementType {
			get {
				return GetTypedColumnValue<string>("CampaignElementType");
			}
			set {
				SetColumnValue("CampaignElementType", value);
			}
		}

		/// <summary>
		/// Id связанной сущности.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// SysSchemaUId.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

