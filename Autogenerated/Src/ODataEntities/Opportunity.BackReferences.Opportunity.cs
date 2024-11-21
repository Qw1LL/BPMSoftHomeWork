namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Opportunity

	/// <exclude/>
	public class Opportunity : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Opportunity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Opportunity";
		}

		public Opportunity(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Opportunity";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<Call> CallCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<Document> DocumentCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<EmailFolderColumnValuesSetting> EmailFolderColumnValuesSettingCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityCompetitor> OpportunityCompetitorCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityContact> OpportunityContactCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityFile> OpportunityFileCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityInFolder> OpportunityInFolderCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityInStage> OpportunityInStageCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityInTag> OpportunityInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<OpportunityParticipant> OpportunityParticipantCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityProductInterest> OpportunityProductInterestCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityTacticHist> OpportunityTacticHistCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<OpportunityVisa> OpportunityVisaCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<Order> OrderCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<Project> ProjectCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<VwOpportFunnelData> VwOpportFunnelDataCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<VwOpportInStageForAnalysis> VwOpportInStageForAnalysisCollectionByOpportunity {
			get;
			set;
		}

		public IEnumerable<VwOpportunityInStage> VwOpportunityInStageCollectionByOpportunity {
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
		/// Название.
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

		private OpportunityType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public OpportunityType Type {
			get {
				return _type ??
					(_type = new OpportunityType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
				_stage = null;
			}
		}

		/// <exclude/>
		public string StageName {
			get {
				return GetTypedColumnValue<string>("StageName");
			}
			set {
				SetColumnValue("StageName", value);
				if (_stage != null) {
					_stage.Name = value;
				}
			}
		}

		private OpportunityStage _stage;
		/// <summary>
		/// Стадия.
		/// </summary>
		public OpportunityStage Stage {
			get {
				return _stage ??
					(_stage = new OpportunityStage(LookupColumnEntities.GetEntity("Stage")));
			}
		}

		/// <summary>
		/// Дата закрытия.
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
		public Guid CloseReasonId {
			get {
				return GetTypedColumnValue<Guid>("CloseReasonId");
			}
			set {
				SetColumnValue("CloseReasonId", value);
				_closeReason = null;
			}
		}

		/// <exclude/>
		public string CloseReasonName {
			get {
				return GetTypedColumnValue<string>("CloseReasonName");
			}
			set {
				SetColumnValue("CloseReasonName", value);
				if (_closeReason != null) {
					_closeReason.Name = value;
				}
			}
		}

		private OpportunityCloseReason _closeReason;
		/// <summary>
		/// Причина закрытия.
		/// </summary>
		public OpportunityCloseReason CloseReason {
			get {
				return _closeReason ??
					(_closeReason = new OpportunityCloseReason(LookupColumnEntities.GetEntity("CloseReason")));
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

		private OpportunityCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public OpportunityCategory Category {
			get {
				return _category ??
					(_category = new OpportunityCategory(LookupColumnEntities.GetEntity("Category")));
			}
		}

		/// <exclude/>
		public Guid MoodId {
			get {
				return GetTypedColumnValue<Guid>("MoodId");
			}
			set {
				SetColumnValue("MoodId", value);
				_mood = null;
			}
		}

		/// <exclude/>
		public string MoodName {
			get {
				return GetTypedColumnValue<string>("MoodName");
			}
			set {
				SetColumnValue("MoodName", value);
				if (_mood != null) {
					_mood.Name = value;
				}
			}
		}

		private OpportunityMood _mood;
		/// <summary>
		/// Настроение.
		/// </summary>
		public OpportunityMood Mood {
			get {
				return _mood ??
					(_mood = new OpportunityMood(LookupColumnEntities.GetEntity("Mood")));
			}
		}

		/// <summary>
		/// Первая продажа данному клиенту.
		/// </summary>
		public bool IsPrimary {
			get {
				return GetTypedColumnValue<bool>("IsPrimary");
			}
			set {
				SetColumnValue("IsPrimary", value);
			}
		}

		/// <exclude/>
		public Guid PartnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerId");
			}
			set {
				SetColumnValue("PartnerId", value);
				_partner = null;
			}
		}

		/// <exclude/>
		public string PartnerName {
			get {
				return GetTypedColumnValue<string>("PartnerName");
			}
			set {
				SetColumnValue("PartnerName", value);
				if (_partner != null) {
					_partner.Name = value;
				}
			}
		}

		private Account _partner;
		/// <summary>
		/// Партнер.
		/// </summary>
		public Account Partner {
			get {
				return _partner ??
					(_partner = new Account(LookupColumnEntities.GetEntity("Partner")));
			}
		}

		/// <summary>
		/// Бюджет клиента.
		/// </summary>
		public Decimal Budget {
			get {
				return GetTypedColumnValue<Decimal>("Budget");
			}
			set {
				SetColumnValue("Budget", value);
			}
		}

		/// <summary>
		/// Вероятность, %.
		/// </summary>
		public int Probability {
			get {
				return GetTypedColumnValue<int>("Probability");
			}
			set {
				SetColumnValue("Probability", value);
			}
		}

		/// <summary>
		/// Сумма продажи.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private OpportunitySource _source;
		/// <summary>
		/// Источник.
		/// </summary>
		public OpportunitySource Source {
			get {
				return _source ??
					(_source = new OpportunitySource(LookupColumnEntities.GetEntity("Source")));
			}
		}

		/// <exclude/>
		public Guid ResponsibleDepartmentId {
			get {
				return GetTypedColumnValue<Guid>("ResponsibleDepartmentId");
			}
			set {
				SetColumnValue("ResponsibleDepartmentId", value);
				_responsibleDepartment = null;
			}
		}

		/// <exclude/>
		public string ResponsibleDepartmentName {
			get {
				return GetTypedColumnValue<string>("ResponsibleDepartmentName");
			}
			set {
				SetColumnValue("ResponsibleDepartmentName", value);
				if (_responsibleDepartment != null) {
					_responsibleDepartment.Name = value;
				}
			}
		}

		private OpportunityDepartment _responsibleDepartment;
		/// <summary>
		/// Направление.
		/// </summary>
		public OpportunityDepartment ResponsibleDepartment {
			get {
				return _responsibleDepartment ??
					(_responsibleDepartment = new OpportunityDepartment(LookupColumnEntities.GetEntity("ResponsibleDepartment")));
			}
		}

		/// <summary>
		/// Наши слабые стороны.
		/// </summary>
		public string Weaknesses {
			get {
				return GetTypedColumnValue<string>("Weaknesses");
			}
			set {
				SetColumnValue("Weaknesses", value);
			}
		}

		/// <summary>
		/// Наши сильные стороны.
		/// </summary>
		public string Strength {
			get {
				return GetTypedColumnValue<string>("Strength");
			}
			set {
				SetColumnValue("Strength", value);
			}
		}

		/// <summary>
		/// Тактика продажи.
		/// </summary>
		public string Tactic {
			get {
				return GetTypedColumnValue<string>("Tactic");
			}
			set {
				SetColumnValue("Tactic", value);
			}
		}

		/// <summary>
		/// Дата проверки руководителем.
		/// </summary>
		public DateTime CheckDate {
			get {
				return GetTypedColumnValue<DateTime>("CheckDate");
			}
			set {
				SetColumnValue("CheckDate", value);
			}
		}

		/// <summary>
		/// Идентификатор процесса.
		/// </summary>
		public Guid ProcessId {
			get {
				return GetTypedColumnValue<Guid>("ProcessId");
			}
			set {
				SetColumnValue("ProcessId", value);
			}
		}

		/// <exclude/>
		public Guid WinnerId {
			get {
				return GetTypedColumnValue<Guid>("WinnerId");
			}
			set {
				SetColumnValue("WinnerId", value);
				_winner = null;
			}
		}

		/// <exclude/>
		public string WinnerName {
			get {
				return GetTypedColumnValue<string>("WinnerName");
			}
			set {
				SetColumnValue("WinnerName", value);
				if (_winner != null) {
					_winner.Name = value;
				}
			}
		}

		private Account _winner;
		/// <summary>
		/// Победитель.
		/// </summary>
		public Account Winner {
			get {
				return _winner ??
					(_winner = new Account(LookupColumnEntities.GetEntity("Winner")));
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

		/// <summary>
		/// Полнота наполнения.
		/// </summary>
		public int Completeness {
			get {
				return GetTypedColumnValue<int>("Completeness");
			}
			set {
				SetColumnValue("Completeness", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = new LeadType(LookupColumnEntities.GetEntity("LeadType")));
			}
		}

		/// <summary>
		/// По процессу.
		/// </summary>
		public bool ByProcess {
			get {
				return GetTypedColumnValue<bool>("ByProcess");
			}
			set {
				SetColumnValue("ByProcess", value);
			}
		}

		/// <summary>
		/// Предиктивная вероятность.
		/// </summary>
		public int PredictiveProbability {
			get {
				return GetTypedColumnValue<int>("PredictiveProbability");
			}
			set {
				SetColumnValue("PredictiveProbability", value);
			}
		}

		#endregion

	}

	#endregion

}

