namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Activity

	/// <exclude/>
	public class Activity : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Activity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity";
		}

		public Activity(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Activity";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByActivityConnection {
			get;
			set;
		}

		public IEnumerable<ActivityCorrespondence> ActivityCorrespondenceCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<ActivityFile> ActivityFileCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<ActivityInFolder> ActivityInFolderCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<ActivityInTag> ActivityInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<ActivityParticipant> ActivityParticipantCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<Case> CaseCollectionByParentActivity {
			get;
			set;
		}

		public IEnumerable<EmailMessageData> EmailMessageDataCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<EmailRelation> EmailRelationCollectionByEmail {
			get;
			set;
		}

		public IEnumerable<EmailTemplateActivity> EmailTemplateActivityCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<VwLastActivityByQueue> VwLastActivityByQueueCollectionByActivity {
			get;
			set;
		}

		public IEnumerable<VwQueueItem> VwQueueItemCollectionByLastActivity {
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
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
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
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private ActivityPriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public ActivityPriority Priority {
			get {
				return _priority ??
					(_priority = new ActivityPriority(LookupColumnEntities.GetEntity("Priority")));
			}
		}

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Автор.
		/// </summary>
		public Contact Author {
			get {
				return _author ??
					(_author = new Contact(LookupColumnEntities.GetEntity("Author")));
			}
		}

		/// <summary>
		/// Напоминать автору.
		/// </summary>
		public bool RemindToAuthor {
			get {
				return GetTypedColumnValue<bool>("RemindToAuthor");
			}
			set {
				SetColumnValue("RemindToAuthor", value);
			}
		}

		/// <summary>
		/// Дата напоминания автору.
		/// </summary>
		public DateTime RemindToAuthorDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToAuthorDate");
			}
			set {
				SetColumnValue("RemindToAuthorDate", value);
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

		/// <summary>
		/// Напоминать ответственному.
		/// </summary>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <summary>
		/// Дата напоминания ответственному.
		/// </summary>
		public DateTime RemindToOwnerDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			}
			set {
				SetColumnValue("RemindToOwnerDate", value);
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

		private ActivityType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ActivityType Type {
			get {
				return _type ??
					(_type = new ActivityType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid ActivityCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ActivityCategoryId");
			}
			set {
				SetColumnValue("ActivityCategoryId", value);
				_activityCategory = null;
			}
		}

		/// <exclude/>
		public string ActivityCategoryName {
			get {
				return GetTypedColumnValue<string>("ActivityCategoryName");
			}
			set {
				SetColumnValue("ActivityCategoryName", value);
				if (_activityCategory != null) {
					_activityCategory.Name = value;
				}
			}
		}

		private ActivityCategory _activityCategory;
		/// <summary>
		/// Категория.
		/// </summary>
		public ActivityCategory ActivityCategory {
			get {
				return _activityCategory ??
					(_activityCategory = new ActivityCategory(LookupColumnEntities.GetEntity("ActivityCategory")));
			}
		}

		/// <summary>
		/// Отображать в расписании.
		/// </summary>
		public bool ShowInScheduler {
			get {
				return GetTypedColumnValue<bool>("ShowInScheduler");
			}
			set {
				SetColumnValue("ShowInScheduler", value);
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

		private ActivityStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ActivityStatus Status {
			get {
				return _status ??
					(_status = new ActivityStatus(LookupColumnEntities.GetEntity("Status")));
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
		/// Результат подробно.
		/// </summary>
		public string DetailedResult {
			get {
				return GetTypedColumnValue<string>("DetailedResult");
			}
			set {
				SetColumnValue("DetailedResult", value);
			}
		}

		/// <exclude/>
		public Guid TimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
				_timeZone = null;
			}
		}

		/// <exclude/>
		public string TimeZoneName {
			get {
				return GetTypedColumnValue<string>("TimeZoneName");
			}
			set {
				SetColumnValue("TimeZoneName", value);
				if (_timeZone != null) {
					_timeZone.Name = value;
				}
			}
		}

		private TimeZone _timeZone;
		/// <summary>
		/// Часовой пояс.
		/// </summary>
		public TimeZone TimeZone {
			get {
				return _timeZone ??
					(_timeZone = new TimeZone(LookupColumnEntities.GetEntity("TimeZone")));
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
		/// От кого.
		/// </summary>
		public string Sender {
			get {
				return GetTypedColumnValue<string>("Sender");
			}
			set {
				SetColumnValue("Sender", value);
			}
		}

		/// <summary>
		/// Кому.
		/// </summary>
		public string Recepient {
			get {
				return GetTypedColumnValue<string>("Recepient");
			}
			set {
				SetColumnValue("Recepient", value);
			}
		}

		/// <summary>
		/// Копия.
		/// </summary>
		public string CopyRecepient {
			get {
				return GetTypedColumnValue<string>("CopyRecepient");
			}
			set {
				SetColumnValue("CopyRecepient", value);
			}
		}

		/// <summary>
		/// Скрытая копия.
		/// </summary>
		public string BlindCopyRecepient {
			get {
				return GetTypedColumnValue<string>("BlindCopyRecepient");
			}
			set {
				SetColumnValue("BlindCopyRecepient", value);
			}
		}

		/// <summary>
		/// Тело.
		/// </summary>
		public string Body {
			get {
				return GetTypedColumnValue<string>("Body");
			}
			set {
				SetColumnValue("Body", value);
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

		/// <summary>
		/// Цвет.
		/// </summary>
		/// <remarks>
		/// Цвет задачи.
		/// </remarks>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		/// <summary>
		/// Отправлено.
		/// </summary>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		/// <exclude/>
		public Guid EmailSendStatusId {
			get {
				return GetTypedColumnValue<Guid>("EmailSendStatusId");
			}
			set {
				SetColumnValue("EmailSendStatusId", value);
				_emailSendStatus = null;
			}
		}

		/// <exclude/>
		public string EmailSendStatusName {
			get {
				return GetTypedColumnValue<string>("EmailSendStatusName");
			}
			set {
				SetColumnValue("EmailSendStatusName", value);
				if (_emailSendStatus != null) {
					_emailSendStatus.Name = value;
				}
			}
		}

		private EmailSendStatus _emailSendStatus;
		/// <summary>
		/// Состояние отправки сообщения.
		/// </summary>
		public EmailSendStatus EmailSendStatus {
			get {
				return _emailSendStatus ??
					(_emailSendStatus = new EmailSendStatus(LookupColumnEntities.GetEntity("EmailSendStatus")));
			}
		}

		/// <summary>
		/// Продолжительность (минут).
		/// </summary>
		public int DurationInMinutes {
			get {
				return GetTypedColumnValue<int>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Ошибка при отправке.
		/// </summary>
		public string ErrorOnSend {
			get {
				return GetTypedColumnValue<string>("ErrorOnSend");
			}
			set {
				SetColumnValue("ErrorOnSend", value);
			}
		}

		/// <summary>
		/// Продолжительность (часов, минут).
		/// </summary>
		public string DurationInMnutesAndHours {
			get {
				return GetTypedColumnValue<string>("DurationInMnutesAndHours");
			}
			set {
				SetColumnValue("DurationInMnutesAndHours", value);
			}
		}

		/// <summary>
		/// Возможные результаты.
		/// </summary>
		public string AllowedResult {
			get {
				return GetTypedColumnValue<string>("AllowedResult");
			}
			set {
				SetColumnValue("AllowedResult", value);
			}
		}

		/// <summary>
		/// Создано в InvisibleCRM.
		/// </summary>
		public bool CreatedByInvCRM {
			get {
				return GetTypedColumnValue<bool>("CreatedByInvCRM");
			}
			set {
				SetColumnValue("CreatedByInvCRM", value);
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
		public Guid MessageTypeId {
			get {
				return GetTypedColumnValue<Guid>("MessageTypeId");
			}
			set {
				SetColumnValue("MessageTypeId", value);
				_messageType = null;
			}
		}

		/// <exclude/>
		public string MessageTypeName {
			get {
				return GetTypedColumnValue<string>("MessageTypeName");
			}
			set {
				SetColumnValue("MessageTypeName", value);
				if (_messageType != null) {
					_messageType.Name = value;
				}
			}
		}

		private EmailType _messageType;
		/// <summary>
		/// Тип сообщения.
		/// </summary>
		public EmailType MessageType {
			get {
				return _messageType ??
					(_messageType = new EmailType(LookupColumnEntities.GetEntity("MessageType")));
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
		/// Тело письма в формате HTML.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <summary>
		/// Хеш код.
		/// </summary>
		public string MailHash {
			get {
				return GetTypedColumnValue<string>("MailHash");
			}
			set {
				SetColumnValue("MailHash", value);
			}
		}

		/// <summary>
		/// Элемент процесса.
		/// </summary>
		public Guid ProcessElementId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementId");
			}
			set {
				SetColumnValue("ProcessElementId", value);
			}
		}

		/// <summary>
		/// Глобальный идентификатор активности Outlook.
		/// </summary>
		public string GlobalActivityID {
			get {
				return GetTypedColumnValue<string>("GlobalActivityID");
			}
			set {
				SetColumnValue("GlobalActivityID", value);
			}
		}

		/// <summary>
		/// E-mail адрес пользователя.
		/// </summary>
		public string UserEmailAddress {
			get {
				return GetTypedColumnValue<string>("UserEmailAddress");
			}
			set {
				SetColumnValue("UserEmailAddress", value);
			}
		}

		/// <exclude/>
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = new Contract(LookupColumnEntities.GetEntity("Contract")));
			}
		}

		/// <exclude/>
		public Guid InvoiceId {
			get {
				return GetTypedColumnValue<Guid>("InvoiceId");
			}
			set {
				SetColumnValue("InvoiceId", value);
				_invoice = null;
			}
		}

		/// <exclude/>
		public string InvoiceNumber {
			get {
				return GetTypedColumnValue<string>("InvoiceNumber");
			}
			set {
				SetColumnValue("InvoiceNumber", value);
				if (_invoice != null) {
					_invoice.Number = value;
				}
			}
		}

		private Invoice _invoice;
		/// <summary>
		/// Счет.
		/// </summary>
		public Invoice Invoice {
			get {
				return _invoice ??
					(_invoice = new Invoice(LookupColumnEntities.GetEntity("Invoice")));
			}
		}

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = new Project(LookupColumnEntities.GetEntity("Project")));
			}
		}

		/// <summary>
		/// Проект.
		/// </summary>
		public string FullProjectName {
			get {
				return GetTypedColumnValue<string>("FullProjectName");
			}
			set {
				SetColumnValue("FullProjectName", value);
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

		/// <exclude/>
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = new Event(LookupColumnEntities.GetEntity("Event")));
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

		/// <summary>
		/// Нуждается в обработке.
		/// </summary>
		public bool IsNeedProcess {
			get {
				return GetTypedColumnValue<bool>("IsNeedProcess");
			}
			set {
				SetColumnValue("IsNeedProcess", value);
			}
		}

		/// <exclude/>
		public Guid ActivityConnectionId {
			get {
				return GetTypedColumnValue<Guid>("ActivityConnectionId");
			}
			set {
				SetColumnValue("ActivityConnectionId", value);
				_activityConnection = null;
			}
		}

		/// <exclude/>
		public string ActivityConnectionTitle {
			get {
				return GetTypedColumnValue<string>("ActivityConnectionTitle");
			}
			set {
				SetColumnValue("ActivityConnectionTitle", value);
				if (_activityConnection != null) {
					_activityConnection.Title = value;
				}
			}
		}

		private Activity _activityConnection;
		/// <summary>
		/// Активность.
		/// </summary>
		public Activity ActivityConnection {
			get {
				return _activityConnection ??
					(_activityConnection = new Activity(LookupColumnEntities.GetEntity("ActivityConnection")));
			}
		}

		/// <exclude/>
		public Guid ChangeId {
			get {
				return GetTypedColumnValue<Guid>("ChangeId");
			}
			set {
				SetColumnValue("ChangeId", value);
				_change = null;
			}
		}

		/// <exclude/>
		public string ChangeNumber {
			get {
				return GetTypedColumnValue<string>("ChangeNumber");
			}
			set {
				SetColumnValue("ChangeNumber", value);
				if (_change != null) {
					_change.Number = value;
				}
			}
		}

		private Change _change;
		/// <summary>
		/// Изменение.
		/// </summary>
		public Change Change {
			get {
				return _change ??
					(_change = new Change(LookupColumnEntities.GetEntity("Change")));
			}
		}

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релиз.
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = new Release(LookupColumnEntities.GetEntity("Release")));
			}
		}

		/// <exclude/>
		public Guid ProblemId {
			get {
				return GetTypedColumnValue<Guid>("ProblemId");
			}
			set {
				SetColumnValue("ProblemId", value);
				_problem = null;
			}
		}

		/// <exclude/>
		public string ProblemNumber {
			get {
				return GetTypedColumnValue<string>("ProblemNumber");
			}
			set {
				SetColumnValue("ProblemNumber", value);
				if (_problem != null) {
					_problem.Number = value;
				}
			}
		}

		private Problem _problem;
		/// <summary>
		/// Проблема.
		/// </summary>
		public Problem Problem {
			get {
				return _problem ??
					(_problem = new Problem(LookupColumnEntities.GetEntity("Problem")));
			}
		}

		/// <exclude/>
		public Guid OrganizerId {
			get {
				return GetTypedColumnValue<Guid>("OrganizerId");
			}
			set {
				SetColumnValue("OrganizerId", value);
				_organizer = null;
			}
		}

		/// <exclude/>
		public string OrganizerName {
			get {
				return GetTypedColumnValue<string>("OrganizerName");
			}
			set {
				SetColumnValue("OrganizerName", value);
				if (_organizer != null) {
					_organizer.Name = value;
				}
			}
		}

		private Contact _organizer;
		/// <summary>
		/// Организатор.
		/// </summary>
		public Contact Organizer {
			get {
				return _organizer ??
					(_organizer = new Contact(LookupColumnEntities.GetEntity("Organizer")));
			}
		}

		/// <summary>
		/// Место встречи.
		/// </summary>
		public string Location {
			get {
				return GetTypedColumnValue<string>("Location");
			}
			set {
				SetColumnValue("Location", value);
			}
		}

		/// <exclude/>
		public Guid ConfItemId {
			get {
				return GetTypedColumnValue<Guid>("ConfItemId");
			}
			set {
				SetColumnValue("ConfItemId", value);
				_confItem = null;
			}
		}

		/// <exclude/>
		public string ConfItemName {
			get {
				return GetTypedColumnValue<string>("ConfItemName");
			}
			set {
				SetColumnValue("ConfItemName", value);
				if (_confItem != null) {
					_confItem.Name = value;
				}
			}
		}

		private ConfItem _confItem;
		/// <summary>
		/// Конфигурационная единица.
		/// </summary>
		public ConfItem ConfItem {
			get {
				return _confItem ??
					(_confItem = new ConfItem(LookupColumnEntities.GetEntity("ConfItem")));
			}
		}

		/// <summary>
		/// Не опубликовано.
		/// </summary>
		public bool IsNotPublished {
			get {
				return GetTypedColumnValue<bool>("IsNotPublished");
			}
			set {
				SetColumnValue("IsNotPublished", value);
			}
		}

		/// <exclude/>
		public Guid CallDirectionId {
			get {
				return GetTypedColumnValue<Guid>("CallDirectionId");
			}
			set {
				SetColumnValue("CallDirectionId", value);
				_callDirection = null;
			}
		}

		/// <exclude/>
		public string CallDirectionName {
			get {
				return GetTypedColumnValue<string>("CallDirectionName");
			}
			set {
				SetColumnValue("CallDirectionName", value);
				if (_callDirection != null) {
					_callDirection.Name = value;
				}
			}
		}

		private CallDirection _callDirection;
		/// <summary>
		/// Направление звонка.
		/// </summary>
		public CallDirection CallDirection {
			get {
				return _callDirection ??
					(_callDirection = new CallDirection(LookupColumnEntities.GetEntity("CallDirection")));
			}
		}

		/// <exclude/>
		public Guid DocumentId {
			get {
				return GetTypedColumnValue<Guid>("DocumentId");
			}
			set {
				SetColumnValue("DocumentId", value);
				_document = null;
			}
		}

		/// <exclude/>
		public string DocumentNumber {
			get {
				return GetTypedColumnValue<string>("DocumentNumber");
			}
			set {
				SetColumnValue("DocumentNumber", value);
				if (_document != null) {
					_document.Number = value;
				}
			}
		}

		private Document _document;
		/// <summary>
		/// Документ.
		/// </summary>
		public Document Document {
			get {
				return _document ??
					(_document = new Document(LookupColumnEntities.GetEntity("Document")));
			}
		}

		/// <exclude/>
		public Guid QueueItemId {
			get {
				return GetTypedColumnValue<Guid>("QueueItemId");
			}
			set {
				SetColumnValue("QueueItemId", value);
				_queueItem = null;
			}
		}

		/// <exclude/>
		public string QueueItemCaption {
			get {
				return GetTypedColumnValue<string>("QueueItemCaption");
			}
			set {
				SetColumnValue("QueueItemCaption", value);
				if (_queueItem != null) {
					_queueItem.Caption = value;
				}
			}
		}

		private VwQueueItem _queueItem;
		/// <summary>
		/// Элемент очереди.
		/// </summary>
		public VwQueueItem QueueItem {
			get {
				return _queueItem ??
					(_queueItem = new VwQueueItem(LookupColumnEntities.GetEntity("QueueItem")));
			}
		}

		/// <summary>
		/// Свойства заголовка.
		/// </summary>
		public string HeaderProperties {
			get {
				return GetTypedColumnValue<string>("HeaderProperties");
			}
			set {
				SetColumnValue("HeaderProperties", value);
			}
		}

		/// <exclude/>
		public Guid EnrchEmailDataId {
			get {
				return GetTypedColumnValue<Guid>("EnrchEmailDataId");
			}
			set {
				SetColumnValue("EnrchEmailDataId", value);
				_enrchEmailData = null;
			}
		}

		/// <exclude/>
		public string EnrchEmailDataHash {
			get {
				return GetTypedColumnValue<string>("EnrchEmailDataHash");
			}
			set {
				SetColumnValue("EnrchEmailDataHash", value);
				if (_enrchEmailData != null) {
					_enrchEmailData.Hash = value;
				}
			}
		}

		private EnrchEmailData _enrchEmailData;
		/// <summary>
		/// Разобранный e-mail.
		/// </summary>
		public EnrchEmailData EnrchEmailData {
			get {
				return _enrchEmailData ??
					(_enrchEmailData = new EnrchEmailData(LookupColumnEntities.GetEntity("EnrchEmailData")));
			}
		}

		/// <summary>
		/// Статус процесса обогащения.
		/// </summary>
		public string EnrichStatus {
			get {
				return GetTypedColumnValue<string>("EnrichStatus");
			}
			set {
				SetColumnValue("EnrichStatus", value);
			}
		}

		/// <summary>
		/// Обработано процессами сервиса.
		/// </summary>
		public bool ServiceProcessed {
			get {
				return GetTypedColumnValue<bool>("ServiceProcessed");
			}
			set {
				SetColumnValue("ServiceProcessed", value);
			}
		}

		/// <summary>
		/// Автоматическое уведомление.
		/// </summary>
		public bool IsAutoSubmitted {
			get {
				return GetTypedColumnValue<bool>("IsAutoSubmitted");
			}
			set {
				SetColumnValue("IsAutoSubmitted", value);
			}
		}

		/// <exclude/>
		public Guid SenderContactId {
			get {
				return GetTypedColumnValue<Guid>("SenderContactId");
			}
			set {
				SetColumnValue("SenderContactId", value);
				_senderContact = null;
			}
		}

		/// <exclude/>
		public string SenderContactName {
			get {
				return GetTypedColumnValue<string>("SenderContactName");
			}
			set {
				SetColumnValue("SenderContactName", value);
				if (_senderContact != null) {
					_senderContact.Name = value;
				}
			}
		}

		private Contact _senderContact;
		/// <summary>
		/// Контакт отправителя.
		/// </summary>
		public Contact SenderContact {
			get {
				return _senderContact ??
					(_senderContact = new Contact(LookupColumnEntities.GetEntity("SenderContact")));
			}
		}

		/// <summary>
		/// Предпросмотр.
		/// </summary>
		public string Preview {
			get {
				return GetTypedColumnValue<string>("Preview");
			}
			set {
				SetColumnValue("Preview", value);
			}
		}

		/// <exclude/>
		public Guid OmniChatId {
			get {
				return GetTypedColumnValue<Guid>("OmniChatId");
			}
			set {
				SetColumnValue("OmniChatId", value);
				_omniChat = null;
			}
		}

		/// <exclude/>
		public string OmniChatName {
			get {
				return GetTypedColumnValue<string>("OmniChatName");
			}
			set {
				SetColumnValue("OmniChatName", value);
				if (_omniChat != null) {
					_omniChat.Name = value;
				}
			}
		}

		private OmniChat _omniChat;
		/// <summary>
		/// Чат.
		/// </summary>
		public OmniChat OmniChat {
			get {
				return _omniChat ??
					(_omniChat = new OmniChat(LookupColumnEntities.GetEntity("OmniChat")));
			}
		}

		/// <exclude/>
		public Guid OwnerRoleId {
			get {
				return GetTypedColumnValue<Guid>("OwnerRoleId");
			}
			set {
				SetColumnValue("OwnerRoleId", value);
				_ownerRole = null;
			}
		}

		/// <exclude/>
		public string OwnerRoleName {
			get {
				return GetTypedColumnValue<string>("OwnerRoleName");
			}
			set {
				SetColumnValue("OwnerRoleName", value);
				if (_ownerRole != null) {
					_ownerRole.Name = value;
				}
			}
		}

		private VwSysRole _ownerRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public VwSysRole OwnerRole {
			get {
				return _ownerRole ??
					(_ownerRole = new VwSysRole(LookupColumnEntities.GetEntity("OwnerRole")));
			}
		}

		/// <summary>
		/// Дата создания во внешнем календаре.
		/// </summary>
		public DateTime RemoteCreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("RemoteCreatedOn");
			}
			set {
				SetColumnValue("RemoteCreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid UsrTransportRequestId {
			get {
				return GetTypedColumnValue<Guid>("UsrTransportRequestId");
			}
			set {
				SetColumnValue("UsrTransportRequestId", value);
				_usrTransportRequest = null;
			}
		}

		/// <exclude/>
		public string UsrTransportRequestUsrName {
			get {
				return GetTypedColumnValue<string>("UsrTransportRequestUsrName");
			}
			set {
				SetColumnValue("UsrTransportRequestUsrName", value);
				if (_usrTransportRequest != null) {
					_usrTransportRequest.UsrName = value;
				}
			}
		}

		private UsrTransportRequests _usrTransportRequest;
		/// <summary>
		/// Заявка на транспорт.
		/// </summary>
		public UsrTransportRequests UsrTransportRequest {
			get {
				return _usrTransportRequest ??
					(_usrTransportRequest = new UsrTransportRequests(LookupColumnEntities.GetEntity("UsrTransportRequest")));
			}
		}

		#endregion

	}

	#endregion

}

