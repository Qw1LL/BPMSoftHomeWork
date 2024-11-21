namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignParticipantOp

	/// <exclude/>
	public class CampaignParticipantOp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignParticipantOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignParticipantOp";
		}

		public CampaignParticipantOp(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignParticipantOp";
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
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private CmpgnParticipantStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CmpgnParticipantStatus Status {
			get {
				return _status ??
					(_status = new CmpgnParticipantStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <exclude/>
		public Guid CampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("CampaignItemId");
			}
			set {
				SetColumnValue("CampaignItemId", value);
				_campaignItem = null;
			}
		}

		/// <exclude/>
		public string CampaignItemName {
			get {
				return GetTypedColumnValue<string>("CampaignItemName");
			}
			set {
				SetColumnValue("CampaignItemName", value);
				if (_campaignItem != null) {
					_campaignItem.Name = value;
				}
			}
		}

		private CampaignItem _campaignItem;
		/// <summary>
		/// Текущий шаг.
		/// </summary>
		public CampaignItem CampaignItem {
			get {
				return _campaignItem ??
					(_campaignItem = new CampaignItem(LookupColumnEntities.GetEntity("CampaignItem")));
			}
		}

		/// <summary>
		/// Дата изменения шага.
		/// </summary>
		public DateTime StepModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("StepModifiedOn");
			}
			set {
				SetColumnValue("StepModifiedOn", value);
			}
		}

		/// <summary>
		/// Дата изменения состояния шага.
		/// </summary>
		public DateTime StepCompletedOn {
			get {
				return GetTypedColumnValue<DateTime>("StepCompletedOn");
			}
			set {
				SetColumnValue("StepCompletedOn", value);
			}
		}

		/// <summary>
		/// Шаг выполнен.
		/// </summary>
		public bool StepCompleted {
			get {
				return GetTypedColumnValue<bool>("StepCompleted");
			}
			set {
				SetColumnValue("StepCompleted", value);
			}
		}

		/// <summary>
		/// SessionId.
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
		/// IsReadyToSync.
		/// </summary>
		public bool IsReadyToSync {
			get {
				return GetTypedColumnValue<bool>("IsReadyToSync");
			}
			set {
				SetColumnValue("IsReadyToSync", value);
			}
		}

		/// <exclude/>
		public Guid InitialCampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("InitialCampaignItemId");
			}
			set {
				SetColumnValue("InitialCampaignItemId", value);
				_initialCampaignItem = null;
			}
		}

		/// <exclude/>
		public string InitialCampaignItemName {
			get {
				return GetTypedColumnValue<string>("InitialCampaignItemName");
			}
			set {
				SetColumnValue("InitialCampaignItemName", value);
				if (_initialCampaignItem != null) {
					_initialCampaignItem.Name = value;
				}
			}
		}

		private CampaignItem _initialCampaignItem;
		/// <summary>
		/// Начальный шаг участника во фрагменте.
		/// </summary>
		public CampaignItem InitialCampaignItem {
			get {
				return _initialCampaignItem ??
					(_initialCampaignItem = new CampaignItem(LookupColumnEntities.GetEntity("InitialCampaignItem")));
			}
		}

		/// <exclude/>
		public Guid CampaignParticipantId {
			get {
				return GetTypedColumnValue<Guid>("CampaignParticipantId");
			}
			set {
				SetColumnValue("CampaignParticipantId", value);
				_campaignParticipant = null;
			}
		}

		private CampaignParticipant _campaignParticipant;
		/// <summary>
		/// CampaignParticipant.
		/// </summary>
		public CampaignParticipant CampaignParticipant {
			get {
				return _campaignParticipant ??
					(_campaignParticipant = new CampaignParticipant(LookupColumnEntities.GetEntity("CampaignParticipant")));
			}
		}

		#endregion

	}

	#endregion

}

