namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Call

	/// <exclude/>
	public class Call : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Call(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call";
		}

		public Call(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Call";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CallFile> CallFileCollectionByCall {
			get;
			set;
		}

		public IEnumerable<CallInFolder> CallInFolderCollectionByCall {
			get;
			set;
		}

		public IEnumerable<CallInTag> CallInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<SysActiveCall> SysActiveCallCollectionByCall {
			get;
			set;
		}

		public IEnumerable<SysActiveCall> SysActiveCallCollectionByParentCall {
			get;
			set;
		}

		public IEnumerable<VwRecentCall> VwRecentCallCollectionByCall {
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
		/// Идентификатор звонка.
		/// </summary>
		public string IntegrationId {
			get {
				return GetTypedColumnValue<string>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <summary>
		/// Идентификатор исходного звонка.
		/// </summary>
		public string ParentCallId {
			get {
				return GetTypedColumnValue<string>("ParentCallId");
			}
			set {
				SetColumnValue("ParentCallId", value);
			}
		}

		/// <summary>
		/// Номер От.
		/// </summary>
		public string CallerId {
			get {
				return GetTypedColumnValue<string>("CallerId");
			}
			set {
				SetColumnValue("CallerId", value);
			}
		}

		/// <summary>
		/// Номер Кому.
		/// </summary>
		public string CalledId {
			get {
				return GetTypedColumnValue<string>("CalledId");
			}
			set {
				SetColumnValue("CalledId", value);
			}
		}

		/// <summary>
		/// Кто перевел.
		/// </summary>
		/// <remarks>
		/// Номер абонента, который перевел звонок.
		/// </remarks>
		public string RedirectingId {
			get {
				return GetTypedColumnValue<string>("RedirectingId");
			}
			set {
				SetColumnValue("RedirectingId", value);
			}
		}

		/// <summary>
		/// Куда перевели.
		/// </summary>
		/// <remarks>
		/// Номер абонента, на которого перевели звонок.
		/// </remarks>
		public string RedirectionId {
			get {
				return GetTypedColumnValue<string>("RedirectionId");
			}
			set {
				SetColumnValue("RedirectionId", value);
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
		/// Длительность.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		/// <summary>
		/// Время до соединения.
		/// </summary>
		public int BeforeConnectionTime {
			get {
				return GetTypedColumnValue<int>("BeforeConnectionTime");
			}
			set {
				SetColumnValue("BeforeConnectionTime", value);
			}
		}

		/// <summary>
		/// Время разговора.
		/// </summary>
		public int TalkTime {
			get {
				return GetTypedColumnValue<int>("TalkTime");
			}
			set {
				SetColumnValue("TalkTime", value);
			}
		}

		/// <summary>
		/// Время удержания.
		/// </summary>
		public int HoldTime {
			get {
				return GetTypedColumnValue<int>("HoldTime");
			}
			set {
				SetColumnValue("HoldTime", value);
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
		public Guid DirectionId {
			get {
				return GetTypedColumnValue<Guid>("DirectionId");
			}
			set {
				SetColumnValue("DirectionId", value);
				_direction = null;
			}
		}

		/// <exclude/>
		public string DirectionName {
			get {
				return GetTypedColumnValue<string>("DirectionName");
			}
			set {
				SetColumnValue("DirectionName", value);
				if (_direction != null) {
					_direction.Name = value;
				}
			}
		}

		private CallDirection _direction;
		/// <summary>
		/// Направление звонка.
		/// </summary>
		public CallDirection Direction {
			get {
				return _direction ??
					(_direction = new CallDirection(LookupColumnEntities.GetEntity("Direction")));
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
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private ActivityResult _result;
		/// <summary>
		/// Результат.
		/// </summary>
		public ActivityResult Result {
			get {
				return _result ??
					(_result = new ActivityResult(LookupColumnEntities.GetEntity("Result")));
			}
		}

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comment {
			get {
				return GetTypedColumnValue<string>("Comment");
			}
			set {
				SetColumnValue("Comment", value);
			}
		}

		/// <summary>
		/// Заметки.
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
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Активность.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = new Activity(LookupColumnEntities.GetEntity("Activity")));
			}
		}

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = new Case(LookupColumnEntities.GetEntity("Case")));
			}
		}

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = new Lead(LookupColumnEntities.GetEntity("Lead")));
			}
		}

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = new Opportunity(LookupColumnEntities.GetEntity("Opportunity")));
			}
		}

		/// <summary>
		/// Глобальный идентификатор звонка.
		/// </summary>
		public string GloballyUniqueCallLinkageId {
			get {
				return GetTypedColumnValue<string>("GloballyUniqueCallLinkageId");
			}
			set {
				SetColumnValue("GloballyUniqueCallLinkageId", value);
			}
		}

		/// <summary>
		/// Ссылка на запись разговора.
		/// </summary>
		public string CallRecordLink {
			get {
				return GetTypedColumnValue<string>("CallRecordLink");
			}
			set {
				SetColumnValue("CallRecordLink", value);
			}
		}

		/// <exclude/>
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = new Order(LookupColumnEntities.GetEntity("Order")));
			}
		}

		#endregion

	}

	#endregion

}

