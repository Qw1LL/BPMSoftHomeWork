namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Case

	/// <exclude/>
	public class Case : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Case(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Case";
		}

		public Case(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Case";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByCase {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByCase {
			get;
			set;
		}

		public IEnumerable<Case> CaseCollectionByParentCase {
			get;
			set;
		}

		public IEnumerable<CaseFile> CaseFileCollectionByCase {
			get;
			set;
		}

		public IEnumerable<CaseInChat> CaseInChatCollectionByCase {
			get;
			set;
		}

		public IEnumerable<CaseInFolder> CaseInFolderCollectionByCase {
			get;
			set;
		}

		public IEnumerable<CaseInTag> CaseInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<CaseLifecycle> CaseLifecycleCollectionByCase {
			get;
			set;
		}

		public IEnumerable<CaseMessageHistory> CaseMessageHistoryCollectionByCase {
			get;
			set;
		}

		public IEnumerable<ConfItemInCase> ConfItemInCaseCollectionByCase {
			get;
			set;
		}

		public IEnumerable<DelayedNotification> DelayedNotificationCollectionByCase {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseInCase> KnowledgeBaseInCaseCollectionByCase {
			get;
			set;
		}

		public IEnumerable<MLSimilarCase> MLSimilarCaseCollectionByParentCase {
			get;
			set;
		}

		public IEnumerable<MLSimilarCase> MLSimilarCaseCollectionBySimilarCase {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByCase {
			get;
			set;
		}

		public IEnumerable<ProblemInCase> ProblemInCaseCollectionByCase {
			get;
			set;
		}

		public IEnumerable<SatisfactionUpdate> SatisfactionUpdateCollectionByCase {
			get;
			set;
		}

		public IEnumerable<VwDeclarerComments> VwDeclarerCommentsCollectionByCase {
			get;
			set;
		}

		public IEnumerable<VwMobileCaseMessageHistory> VwMobileCaseMessageHistoryCollectionByCase {
			get;
			set;
		}

		public IEnumerable<VwQueueItem> VwQueueItemCollectionByCase {
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
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Дата регистрации.
		/// </summary>
		public DateTime RegisteredOn {
			get {
				return GetTypedColumnValue<DateTime>("RegisteredOn");
			}
			set {
				SetColumnValue("RegisteredOn", value);
			}
		}

		/// <summary>
		/// Тема.
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
		/// Описание.
		/// </summary>
		public string Symptoms {
			get {
				return GetTypedColumnValue<string>("Symptoms");
			}
			set {
				SetColumnValue("Symptoms", value);
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
		/// Время реакции.
		/// </summary>
		public DateTime ResponseDate {
			get {
				return GetTypedColumnValue<DateTime>("ResponseDate");
			}
			set {
				SetColumnValue("ResponseDate", value);
			}
		}

		/// <summary>
		/// Время разрешения.
		/// </summary>
		public DateTime SolutionDate {
			get {
				return GetTypedColumnValue<DateTime>("SolutionDate");
			}
			set {
				SetColumnValue("SolutionDate", value);
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

		private CaseStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CaseStatus Status {
			get {
				return _status ??
					(_status = new CaseStatus(LookupColumnEntities.GetEntity("Status")));
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

		private CasePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public CasePriority Priority {
			get {
				return _priority ??
					(_priority = new CasePriority(LookupColumnEntities.GetEntity("Priority")));
			}
		}

		/// <exclude/>
		public Guid OriginId {
			get {
				return GetTypedColumnValue<Guid>("OriginId");
			}
			set {
				SetColumnValue("OriginId", value);
				_origin = null;
			}
		}

		/// <exclude/>
		public string OriginName {
			get {
				return GetTypedColumnValue<string>("OriginName");
			}
			set {
				SetColumnValue("OriginName", value);
				if (_origin != null) {
					_origin.Name = value;
				}
			}
		}

		private CaseOrigin _origin;
		/// <summary>
		/// Происхождение.
		/// </summary>
		public CaseOrigin Origin {
			get {
				return _origin ??
					(_origin = new CaseOrigin(LookupColumnEntities.GetEntity("Origin")));
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
		public Guid GroupId {
			get {
				return GetTypedColumnValue<Guid>("GroupId");
			}
			set {
				SetColumnValue("GroupId", value);
				_group = null;
			}
		}

		/// <exclude/>
		public string GroupName {
			get {
				return GetTypedColumnValue<string>("GroupName");
			}
			set {
				SetColumnValue("GroupName", value);
				if (_group != null) {
					_group.Name = value;
				}
			}
		}

		private SysAdminUnit _group;
		/// <summary>
		/// Группа ответственных.
		/// </summary>
		public SysAdminUnit Group {
			get {
				return _group ??
					(_group = new SysAdminUnit(LookupColumnEntities.GetEntity("Group")));
			}
		}

		/// <summary>
		/// Фактическая реакция.
		/// </summary>
		public DateTime RespondedOn {
			get {
				return GetTypedColumnValue<DateTime>("RespondedOn");
			}
			set {
				SetColumnValue("RespondedOn", value);
			}
		}

		/// <summary>
		/// Фактическое разрешение.
		/// </summary>
		public DateTime SolutionProvidedOn {
			get {
				return GetTypedColumnValue<DateTime>("SolutionProvidedOn");
			}
			set {
				SetColumnValue("SolutionProvidedOn", value);
			}
		}

		/// <summary>
		/// Дата закрытия.
		/// </summary>
		public DateTime ClosureDate {
			get {
				return GetTypedColumnValue<DateTime>("ClosureDate");
			}
			set {
				SetColumnValue("ClosureDate", value);
			}
		}

		/// <exclude/>
		public Guid ClosureCodeId {
			get {
				return GetTypedColumnValue<Guid>("ClosureCodeId");
			}
			set {
				SetColumnValue("ClosureCodeId", value);
				_closureCode = null;
			}
		}

		/// <exclude/>
		public string ClosureCodeName {
			get {
				return GetTypedColumnValue<string>("ClosureCodeName");
			}
			set {
				SetColumnValue("ClosureCodeName", value);
				if (_closureCode != null) {
					_closureCode.Name = value;
				}
			}
		}

		private ClosureCode _closureCode;
		/// <summary>
		/// Причина закрытия.
		/// </summary>
		public ClosureCode ClosureCode {
			get {
				return _closureCode ??
					(_closureCode = new ClosureCode(LookupColumnEntities.GetEntity("ClosureCode")));
			}
		}

		/// <summary>
		/// Решение.
		/// </summary>
		public string Solution {
			get {
				return GetTypedColumnValue<string>("Solution");
			}
			set {
				SetColumnValue("Solution", value);
			}
		}

		/// <exclude/>
		public Guid SatisfactionLevelId {
			get {
				return GetTypedColumnValue<Guid>("SatisfactionLevelId");
			}
			set {
				SetColumnValue("SatisfactionLevelId", value);
				_satisfactionLevel = null;
			}
		}

		/// <exclude/>
		public string SatisfactionLevelName {
			get {
				return GetTypedColumnValue<string>("SatisfactionLevelName");
			}
			set {
				SetColumnValue("SatisfactionLevelName", value);
				if (_satisfactionLevel != null) {
					_satisfactionLevel.Name = value;
				}
			}
		}

		private SatisfactionLevel _satisfactionLevel;
		/// <summary>
		/// Уровень удовлетворенности.
		/// </summary>
		public SatisfactionLevel SatisfactionLevel {
			get {
				return _satisfactionLevel ??
					(_satisfactionLevel = new SatisfactionLevel(LookupColumnEntities.GetEntity("SatisfactionLevel")));
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private CaseCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public CaseCategory Category {
			get {
				return _category ??
					(_category = new CaseCategory(LookupColumnEntities.GetEntity("Category")));
			}
		}

		/// <summary>
		/// Просрочен по реакции.
		/// </summary>
		public bool ResponseOverdue {
			get {
				return GetTypedColumnValue<bool>("ResponseOverdue");
			}
			set {
				SetColumnValue("ResponseOverdue", value);
			}
		}

		/// <summary>
		/// Просрочен по разрешению.
		/// </summary>
		public bool SolutionOverdue {
			get {
				return GetTypedColumnValue<bool>("SolutionOverdue");
			}
			set {
				SetColumnValue("SolutionOverdue", value);
			}
		}

		/// <summary>
		/// Комментарий к оценке.
		/// </summary>
		public string SatisfactionLevelComment {
			get {
				return GetTypedColumnValue<string>("SatisfactionLevelComment");
			}
			set {
				SetColumnValue("SatisfactionLevelComment", value);
			}
		}

		/// <summary>
		/// Осталось по разрешению.
		/// </summary>
		public Decimal SolutionRemains {
			get {
				return GetTypedColumnValue<Decimal>("SolutionRemains");
			}
			set {
				SetColumnValue("SolutionRemains", value);
			}
		}

		/// <exclude/>
		public Guid ServicePactId {
			get {
				return GetTypedColumnValue<Guid>("ServicePactId");
			}
			set {
				SetColumnValue("ServicePactId", value);
				_servicePact = null;
			}
		}

		/// <exclude/>
		public string ServicePactName {
			get {
				return GetTypedColumnValue<string>("ServicePactName");
			}
			set {
				SetColumnValue("ServicePactName", value);
				if (_servicePact != null) {
					_servicePact.Name = value;
				}
			}
		}

		private ServicePact _servicePact;
		/// <summary>
		/// Сервисный договор.
		/// </summary>
		public ServicePact ServicePact {
			get {
				return _servicePact ??
					(_servicePact = new ServicePact(LookupColumnEntities.GetEntity("ServicePact")));
			}
		}

		/// <exclude/>
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервис.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = new ServiceItem(LookupColumnEntities.GetEntity("ServiceItem")));
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
		public Guid SupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SupportLevelId");
			}
			set {
				SetColumnValue("SupportLevelId", value);
				_supportLevel = null;
			}
		}

		/// <exclude/>
		public string SupportLevelName {
			get {
				return GetTypedColumnValue<string>("SupportLevelName");
			}
			set {
				SetColumnValue("SupportLevelName", value);
				if (_supportLevel != null) {
					_supportLevel.Name = value;
				}
			}
		}

		private RoleInServiceTeam _supportLevel;
		/// <summary>
		/// Уровень поддержки.
		/// </summary>
		public RoleInServiceTeam SupportLevel {
			get {
				return _supportLevel ??
					(_supportLevel = new RoleInServiceTeam(LookupColumnEntities.GetEntity("SupportLevel")));
			}
		}

		/// <exclude/>
		public Guid SolvedOnSupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SolvedOnSupportLevelId");
			}
			set {
				SetColumnValue("SolvedOnSupportLevelId", value);
				_solvedOnSupportLevel = null;
			}
		}

		/// <exclude/>
		public string SolvedOnSupportLevelName {
			get {
				return GetTypedColumnValue<string>("SolvedOnSupportLevelName");
			}
			set {
				SetColumnValue("SolvedOnSupportLevelName", value);
				if (_solvedOnSupportLevel != null) {
					_solvedOnSupportLevel.Name = value;
				}
			}
		}

		private RoleInServiceTeam _solvedOnSupportLevel;
		/// <summary>
		/// Решено на уровне.
		/// </summary>
		public RoleInServiceTeam SolvedOnSupportLevel {
			get {
				return _solvedOnSupportLevel ??
					(_solvedOnSupportLevel = new RoleInServiceTeam(LookupColumnEntities.GetEntity("SolvedOnSupportLevel")));
			}
		}

		/// <exclude/>
		public Guid ParentCaseId {
			get {
				return GetTypedColumnValue<Guid>("ParentCaseId");
			}
			set {
				SetColumnValue("ParentCaseId", value);
				_parentCase = null;
			}
		}

		/// <exclude/>
		public string ParentCaseNumber {
			get {
				return GetTypedColumnValue<string>("ParentCaseNumber");
			}
			set {
				SetColumnValue("ParentCaseNumber", value);
				if (_parentCase != null) {
					_parentCase.Number = value;
				}
			}
		}

		private Case _parentCase;
		/// <summary>
		/// Родительское обращение.
		/// </summary>
		public Case ParentCase {
			get {
				return _parentCase ??
					(_parentCase = new Case(LookupColumnEntities.GetEntity("ParentCase")));
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
		public Guid ServiceCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ServiceCategoryId");
			}
			set {
				SetColumnValue("ServiceCategoryId", value);
				_serviceCategory = null;
			}
		}

		/// <exclude/>
		public string ServiceCategoryName {
			get {
				return GetTypedColumnValue<string>("ServiceCategoryName");
			}
			set {
				SetColumnValue("ServiceCategoryName", value);
				if (_serviceCategory != null) {
					_serviceCategory.Name = value;
				}
			}
		}

		private ServiceCategory _serviceCategory;
		/// <summary>
		/// Категория сервиса.
		/// </summary>
		public ServiceCategory ServiceCategory {
			get {
				return _serviceCategory ??
					(_serviceCategory = new ServiceCategory(LookupColumnEntities.GetEntity("ServiceCategory")));
			}
		}

		/// <summary>
		/// Первое решение.
		/// </summary>
		public DateTime FirstSolutionProvidedOn {
			get {
				return GetTypedColumnValue<DateTime>("FirstSolutionProvidedOn");
			}
			set {
				SetColumnValue("FirstSolutionProvidedOn", value);
			}
		}

		/// <exclude/>
		public Guid HolderId {
			get {
				return GetTypedColumnValue<Guid>("HolderId");
			}
			set {
				SetColumnValue("HolderId", value);
				_holder = null;
			}
		}

		/// <exclude/>
		public string HolderName {
			get {
				return GetTypedColumnValue<string>("HolderName");
			}
			set {
				SetColumnValue("HolderName", value);
				if (_holder != null) {
					_holder.Name = value;
				}
			}
		}

		private Contact _holder;
		/// <summary>
		/// Владелец.
		/// </summary>
		public Contact Holder {
			get {
				return _holder ??
					(_holder = new Contact(LookupColumnEntities.GetEntity("Holder")));
			}
		}

		/// <exclude/>
		public Guid ProcessingTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("ProcessingTimeUnitId");
			}
			set {
				SetColumnValue("ProcessingTimeUnitId", value);
				_processingTimeUnit = null;
			}
		}

		/// <exclude/>
		public string ProcessingTimeUnitName {
			get {
				return GetTypedColumnValue<string>("ProcessingTimeUnitName");
			}
			set {
				SetColumnValue("ProcessingTimeUnitName", value);
				if (_processingTimeUnit != null) {
					_processingTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _processingTimeUnit;
		/// <summary>
		/// Единица времени обработки.
		/// </summary>
		public TimeUnit ProcessingTimeUnit {
			get {
				return _processingTimeUnit ??
					(_processingTimeUnit = new TimeUnit(LookupColumnEntities.GetEntity("ProcessingTimeUnit")));
			}
		}

		/// <summary>
		/// Значение времени обработки.
		/// </summary>
		public int ProcessingTimeUnitValue {
			get {
				return GetTypedColumnValue<int>("ProcessingTimeUnitValue");
			}
			set {
				SetColumnValue("ProcessingTimeUnitValue", value);
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

		/// <exclude/>
		public Guid ParentActivityId {
			get {
				return GetTypedColumnValue<Guid>("ParentActivityId");
			}
			set {
				SetColumnValue("ParentActivityId", value);
				_parentActivity = null;
			}
		}

		/// <exclude/>
		public string ParentActivityTitle {
			get {
				return GetTypedColumnValue<string>("ParentActivityTitle");
			}
			set {
				SetColumnValue("ParentActivityTitle", value);
				if (_parentActivity != null) {
					_parentActivity.Title = value;
				}
			}
		}

		private Activity _parentActivity;
		/// <summary>
		/// Родительская активность.
		/// </summary>
		public Activity ParentActivity {
			get {
				return _parentActivity ??
					(_parentActivity = new Activity(LookupColumnEntities.GetEntity("ParentActivity")));
			}
		}

		#endregion

	}

	#endregion

}

