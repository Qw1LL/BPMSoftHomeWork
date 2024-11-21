namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignLog

	/// <exclude/>
	public class CampaignLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignLog";
		}

		public CampaignLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignLog";
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
		/// Шаг.
		/// </summary>
		public CampaignItem CampaignItem {
			get {
				return _campaignItem ??
					(_campaignItem = new CampaignItem(LookupColumnEntities.GetEntity("CampaignItem")));
			}
		}

		/// <summary>
		/// Участники.
		/// </summary>
		public int Amount {
			get {
				return GetTypedColumnValue<int>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Дата запланированного выполнения.
		/// </summary>
		public DateTime ScheduledDate {
			get {
				return GetTypedColumnValue<DateTime>("ScheduledDate");
			}
			set {
				SetColumnValue("ScheduledDate", value);
			}
		}

		/// <summary>
		/// Дата начала.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Дата завершения.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <summary>
		/// Описание ошибки.
		/// </summary>
		public string ErrorText {
			get {
				return GetTypedColumnValue<string>("ErrorText");
			}
			set {
				SetColumnValue("ErrorText", value);
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

		private CampaignLogStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CampaignLogStatus Status {
			get {
				return _status ??
					(_status = new CampaignLogStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <exclude/>
		public Guid ActionId {
			get {
				return GetTypedColumnValue<Guid>("ActionId");
			}
			set {
				SetColumnValue("ActionId", value);
				_action = null;
			}
		}

		/// <exclude/>
		public string ActionName {
			get {
				return GetTypedColumnValue<string>("ActionName");
			}
			set {
				SetColumnValue("ActionName", value);
				if (_action != null) {
					_action.Name = value;
				}
			}
		}

		private CampaignLogItemType _action;
		/// <summary>
		/// Действие.
		/// </summary>
		public CampaignLogItemType Action {
			get {
				return _action ??
					(_action = new CampaignLogItemType(LookupColumnEntities.GetEntity("Action")));
			}
		}

		/// <summary>
		/// SessionId.
		/// </summary>
		/// <remarks>
		/// Session Id.
		/// </remarks>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		#endregion

	}

	#endregion

}

