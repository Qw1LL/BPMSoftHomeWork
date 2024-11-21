namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Event

	/// <exclude/>
	public class Event : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Event(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Event";
		}

		public Event(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Event";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<EventFile> EventFileCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<EventInFolder> EventInFolderCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<EventInTag> EventInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<EventProduct> EventProductCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<EventSegment> EventSegmentCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<EventTarget> EventTargetCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<EventTeam> EventTeamCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<FormSubmit> FormSubmitCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<MarketingEventQueue> MarketingEventQueueCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<MarketingEventQueueOp> MarketingEventQueueOpCollectionByEvent {
			get;
			set;
		}

		public IEnumerable<VwEventInCampaign> VwEventInCampaignCollectionByEvent {
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

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private EventType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public EventType Type {
			get {
				return _type ??
					(_type = new EventType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
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

		private EventStatus _status;
		/// <summary>
		/// Состояние мероприятия.
		/// </summary>
		public EventStatus Status {
			get {
				return _status ??
					(_status = new EventStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <summary>
		/// Начало.
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
		/// Завершение.
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
		/// Цель.
		/// </summary>
		public string Goal {
			get {
				return GetTypedColumnValue<string>("Goal");
			}
			set {
				SetColumnValue("Goal", value);
			}
		}

		/// <exclude/>
		public Guid TerritoryId {
			get {
				return GetTypedColumnValue<Guid>("TerritoryId");
			}
			set {
				SetColumnValue("TerritoryId", value);
				_territory = null;
			}
		}

		/// <exclude/>
		public string TerritoryName {
			get {
				return GetTypedColumnValue<string>("TerritoryName");
			}
			set {
				SetColumnValue("TerritoryName", value);
				if (_territory != null) {
					_territory.Name = value;
				}
			}
		}

		private Territory _territory;
		/// <summary>
		/// Территория.
		/// </summary>
		public Territory Territory {
			get {
				return _territory ??
					(_territory = new Territory(LookupColumnEntities.GetEntity("Territory")));
			}
		}

		/// <exclude/>
		public Guid IndustryId {
			get {
				return GetTypedColumnValue<Guid>("IndustryId");
			}
			set {
				SetColumnValue("IndustryId", value);
				_industry = null;
			}
		}

		/// <exclude/>
		public string IndustryName {
			get {
				return GetTypedColumnValue<string>("IndustryName");
			}
			set {
				SetColumnValue("IndustryName", value);
				if (_industry != null) {
					_industry.Name = value;
				}
			}
		}

		private AccountIndustry _industry;
		/// <summary>
		/// Отрасль.
		/// </summary>
		public AccountIndustry Industry {
			get {
				return _industry ??
					(_industry = new AccountIndustry(LookupColumnEntities.GetEntity("Industry")));
			}
		}

		/// <summary>
		/// Фактический отклик.
		/// </summary>
		public string ActualResponse {
			get {
				return GetTypedColumnValue<string>("ActualResponse");
			}
			set {
				SetColumnValue("ActualResponse", value);
			}
		}

		/// <summary>
		/// Плановый бюджет, б.в.
		/// </summary>
		public Decimal PrimaryBudgetedCost {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryBudgetedCost");
			}
			set {
				SetColumnValue("PrimaryBudgetedCost", value);
			}
		}

		/// <summary>
		/// План продаж, б.в.
		/// </summary>
		public Decimal PrimaryExpectedRevenue {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryExpectedRevenue");
			}
			set {
				SetColumnValue("PrimaryExpectedRevenue", value);
			}
		}

		/// <summary>
		/// Фактические затраты, б.в.
		/// </summary>
		public Decimal PrimaryActualCost {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryActualCost");
			}
			set {
				SetColumnValue("PrimaryActualCost", value);
			}
		}

		/// <summary>
		/// Факт продаж, б.в.
		/// </summary>
		public Decimal PrimaryActualRevenue {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryActualRevenue");
			}
			set {
				SetColumnValue("PrimaryActualRevenue", value);
			}
		}

		/// <summary>
		/// Примечания.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid ActualizeStatusId {
			get {
				return GetTypedColumnValue<Guid>("ActualizeStatusId");
			}
			set {
				SetColumnValue("ActualizeStatusId", value);
				_actualizeStatus = null;
			}
		}

		/// <exclude/>
		public string ActualizeStatusName {
			get {
				return GetTypedColumnValue<string>("ActualizeStatusName");
			}
			set {
				SetColumnValue("ActualizeStatusName", value);
				if (_actualizeStatus != null) {
					_actualizeStatus.Name = value;
				}
			}
		}

		private SegmentStatus _actualizeStatus;
		/// <summary>
		/// Состояние актуализации сегмента.
		/// </summary>
		public SegmentStatus ActualizeStatus {
			get {
				return _actualizeStatus ??
					(_actualizeStatus = new SegmentStatus(LookupColumnEntities.GetEntity("ActualizeStatus")));
			}
		}

		/// <summary>
		/// Время последнего обновления.
		/// </summary>
		public DateTime LastActualizeDate {
			get {
				return GetTypedColumnValue<DateTime>("LastActualizeDate");
			}
			set {
				SetColumnValue("LastActualizeDate", value);
			}
		}

		/// <summary>
		/// Количество участников.
		/// </summary>
		public int RecipientCount {
			get {
				return GetTypedColumnValue<int>("RecipientCount");
			}
			set {
				SetColumnValue("RecipientCount", value);
			}
		}

		/// <exclude/>
		public Guid SegmentsStatusId {
			get {
				return GetTypedColumnValue<Guid>("SegmentsStatusId");
			}
			set {
				SetColumnValue("SegmentsStatusId", value);
				_segmentsStatus = null;
			}
		}

		/// <exclude/>
		public string SegmentsStatusName {
			get {
				return GetTypedColumnValue<string>("SegmentsStatusName");
			}
			set {
				SetColumnValue("SegmentsStatusName", value);
				if (_segmentsStatus != null) {
					_segmentsStatus.Name = value;
				}
			}
		}

		private SegmentStatus _segmentsStatus;
		/// <summary>
		/// Список лидов.
		/// </summary>
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = new SegmentStatus(LookupColumnEntities.GetEntity("SegmentsStatus")));
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

		#endregion

	}

	#endregion

}

