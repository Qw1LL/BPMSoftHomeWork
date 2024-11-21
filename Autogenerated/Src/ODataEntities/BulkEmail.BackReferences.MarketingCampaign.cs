namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: BulkEmail

	/// <exclude/>
	public class BulkEmail : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmail";
		}

		public BulkEmail(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "BulkEmail";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<BETArchiveFirstGeneration> BETArchiveFirstGenerationCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BETArchiveSecondGeneration> BETArchiveSecondGenerationCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailEventLog> BulkEmailEventLogCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailFile> BulkEmailFileCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailHyperlink> BulkEmailHyperlinkCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailInBulkEmailSplit> BulkEmailInBulkEmailSplitCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailInFolder> BulkEmailInFolderCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailInTag> BulkEmailInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<BulkEmailQueue> BulkEmailQueueCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailQueueOp> BulkEmailQueueOpCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailRecipientMacro> BulkEmailRecipientMacroCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailRecipientReplica> BulkEmailRecipientReplicaCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailReplicaHeaders> BulkEmailReplicaHeadersCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailReply> BulkEmailReplyCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailSegment> BulkEmailSegmentCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<BulkEmailTarget> BulkEmailTargetCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<FormSubmit> FormSubmitCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<SendingEmailProgress> SendingEmailProgressCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailAudience> VwBulkEmailAudienceCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailInCampaign> VwBulkEmailInCampaignCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailTarget> VwBulkEmailTargetCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<VwMandrillRecipient> VwMandrillRecipientCollectionByBulkEmail {
			get;
			set;
		}

		public IEnumerable<VwMandrillRecipientV2> VwMandrillRecipientV2CollectionByBulkEmail {
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

		private BulkEmailType _type;
		/// <summary>
		/// Тип рассылки.
		/// </summary>
		public BulkEmailType Type {
			get {
				return _type ??
					(_type = new BulkEmailType(LookupColumnEntities.GetEntity("Type")));
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

		private BulkEmailStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public BulkEmailStatus Status {
			get {
				return _status ??
					(_status = new BulkEmailStatus(LookupColumnEntities.GetEntity("Status")));
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
		/// Отправка начата.
		/// </summary>
		public DateTime SendStartDate {
			get {
				return GetTypedColumnValue<DateTime>("SendStartDate");
			}
			set {
				SetColumnValue("SendStartDate", value);
			}
		}

		/// <summary>
		/// Отправка завершена.
		/// </summary>
		public DateTime SendDueDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDueDate");
			}
			set {
				SetColumnValue("SendDueDate", value);
			}
		}

		/// <summary>
		/// Переходы, %.
		/// </summary>
		public Decimal Clicks {
			get {
				return GetTypedColumnValue<Decimal>("Clicks");
			}
			set {
				SetColumnValue("Clicks", value);
			}
		}

		/// <summary>
		/// Открытия, %.
		/// </summary>
		public Decimal Opens {
			get {
				return GetTypedColumnValue<Decimal>("Opens");
			}
			set {
				SetColumnValue("Opens", value);
			}
		}

		/// <summary>
		/// Soft Bounce, %.
		/// </summary>
		public Decimal SoftBounce {
			get {
				return GetTypedColumnValue<Decimal>("SoftBounce");
			}
			set {
				SetColumnValue("SoftBounce", value);
			}
		}

		/// <summary>
		/// Hard Bounce, %.
		/// </summary>
		public Decimal HardBounce {
			get {
				return GetTypedColumnValue<Decimal>("HardBounce");
			}
			set {
				SetColumnValue("HardBounce", value);
			}
		}

		/// <summary>
		/// Отписки, %.
		/// </summary>
		public Decimal Unsubscribe {
			get {
				return GetTypedColumnValue<Decimal>("Unsubscribe");
			}
			set {
				SetColumnValue("Unsubscribe", value);
			}
		}

		/// <summary>
		/// Спам, %.
		/// </summary>
		public Decimal Spam {
			get {
				return GetTypedColumnValue<Decimal>("Spam");
			}
			set {
				SetColumnValue("Spam", value);
			}
		}

		/// <summary>
		/// Переходы, кол-во.
		/// </summary>
		public int ClicksCount {
			get {
				return GetTypedColumnValue<int>("ClicksCount");
			}
			set {
				SetColumnValue("ClicksCount", value);
			}
		}

		/// <summary>
		/// Открытия, кол-во.
		/// </summary>
		public int OpensCount {
			get {
				return GetTypedColumnValue<int>("OpensCount");
			}
			set {
				SetColumnValue("OpensCount", value);
			}
		}

		/// <summary>
		/// Soft Bounce, кол-во.
		/// </summary>
		public int SoftBounceCount {
			get {
				return GetTypedColumnValue<int>("SoftBounceCount");
			}
			set {
				SetColumnValue("SoftBounceCount", value);
			}
		}

		/// <summary>
		/// Hard Bounce, кол-во.
		/// </summary>
		public int HardBounceCount {
			get {
				return GetTypedColumnValue<int>("HardBounceCount");
			}
			set {
				SetColumnValue("HardBounceCount", value);
			}
		}

		/// <summary>
		/// Отписки, кол-во.
		/// </summary>
		public int UnsubscribeCount {
			get {
				return GetTypedColumnValue<int>("UnsubscribeCount");
			}
			set {
				SetColumnValue("UnsubscribeCount", value);
			}
		}

		/// <summary>
		/// Спам, кол-во.
		/// </summary>
		public int SpamCount {
			get {
				return GetTypedColumnValue<int>("SpamCount");
			}
			set {
				SetColumnValue("SpamCount", value);
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
		/// Список контактов.
		/// </summary>
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = new SegmentStatus(LookupColumnEntities.GetEntity("SegmentsStatus")));
			}
		}

		/// <summary>
		/// Получатели.
		/// </summary>
		public int RecipientCount {
			get {
				return GetTypedColumnValue<int>("RecipientCount");
			}
			set {
				SetColumnValue("RecipientCount", value);
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
		/// Тема.
		/// </summary>
		public string TemplateSubject {
			get {
				return GetTypedColumnValue<string>("TemplateSubject");
			}
			set {
				SetColumnValue("TemplateSubject", value);
			}
		}

		/// <summary>
		/// Текст шаблона.
		/// </summary>
		public string TemplateBody {
			get {
				return GetTypedColumnValue<string>("TemplateBody");
			}
			set {
				SetColumnValue("TemplateBody", value);
			}
		}

		/// <summary>
		/// Доставлено.
		/// </summary>
		public int DeliveredCount {
			get {
				return GetTypedColumnValue<int>("DeliveredCount");
			}
			set {
				SetColumnValue("DeliveredCount", value);
			}
		}

		/// <summary>
		/// Не доставлено.
		/// </summary>
		public int NotDeliveredCount {
			get {
				return GetTypedColumnValue<int>("NotDeliveredCount");
			}
			set {
				SetColumnValue("NotDeliveredCount", value);
			}
		}

		/// <summary>
		/// В очереди.
		/// </summary>
		public int InQueueCount {
			get {
				return GetTypedColumnValue<int>("InQueueCount");
			}
			set {
				SetColumnValue("InQueueCount", value);
			}
		}

		/// <summary>
		/// Отменено, кол-во.
		/// </summary>
		public int CanceledCount {
			get {
				return GetTypedColumnValue<int>("CanceledCount");
			}
			set {
				SetColumnValue("CanceledCount", value);
			}
		}

		/// <summary>
		/// Email не заполнен .
		/// </summary>
		public int BlankEmailCount {
			get {
				return GetTypedColumnValue<int>("BlankEmailCount");
			}
			set {
				SetColumnValue("BlankEmailCount", value);
			}
		}

		/// <summary>
		/// Incorrect email.
		/// </summary>
		public int IncorrectEmailCount {
			get {
				return GetTypedColumnValue<int>("IncorrectEmailCount");
			}
			set {
				SetColumnValue("IncorrectEmailCount", value);
			}
		}

		/// <summary>
		/// Недоступный email.
		/// </summary>
		public int UnreachableEmailCount {
			get {
				return GetTypedColumnValue<int>("UnreachableEmailCount");
			}
			set {
				SetColumnValue("UnreachableEmailCount", value);
			}
		}

		/// <summary>
		/// Не использовать email.
		/// </summary>
		public int DoNotUseEmailCount {
			get {
				return GetTypedColumnValue<int>("DoNotUseEmailCount");
			}
			set {
				SetColumnValue("DoNotUseEmailCount", value);
			}
		}

		/// <summary>
		/// Отписан по типу рассылки.
		/// </summary>
		public int UnsubscribedByTypeCount {
			get {
				return GetTypedColumnValue<int>("UnsubscribedByTypeCount");
			}
			set {
				SetColumnValue("UnsubscribedByTypeCount", value);
			}
		}

		/// <summary>
		/// Дубль emailа.
		/// </summary>
		public int DuplicateEmailCount {
			get {
				return GetTypedColumnValue<int>("DuplicateEmailCount");
			}
			set {
				SetColumnValue("DuplicateEmailCount", value);
			}
		}

		/// <summary>
		/// Отклонено, кол-во.
		/// </summary>
		public int RejectedCount {
			get {
				return GetTypedColumnValue<int>("RejectedCount");
			}
			set {
				SetColumnValue("RejectedCount", value);
			}
		}

		/// <summary>
		/// Общая ошибка запроса, кол-во.
		/// </summary>
		public int CommonErrorCount {
			get {
				return GetTypedColumnValue<int>("CommonErrorCount");
			}
			set {
				SetColumnValue("CommonErrorCount", value);
			}
		}

		/// <summary>
		/// Некорректный адресат, кол-во.
		/// </summary>
		public int InvalidAddresseeCount {
			get {
				return GetTypedColumnValue<int>("InvalidAddresseeCount");
			}
			set {
				SetColumnValue("InvalidAddresseeCount", value);
			}
		}

		/// <summary>
		/// PercentWeight.
		/// </summary>
		public Decimal PercentWeight {
			get {
				return GetTypedColumnValue<Decimal>("PercentWeight");
			}
			set {
				SetColumnValue("PercentWeight", value);
			}
		}

		/// <summary>
		/// PercentActiveWeight.
		/// </summary>
		public Decimal PercentActiveWeight {
			get {
				return GetTypedColumnValue<Decimal>("PercentActiveWeight");
			}
			set {
				SetColumnValue("PercentActiveWeight", value);
			}
		}

		/// <summary>
		/// PercentInactiveWeight.
		/// </summary>
		public Decimal PercentInactiveWeight {
			get {
				return GetTypedColumnValue<Decimal>("PercentInactiveWeight");
			}
			set {
				SetColumnValue("PercentInactiveWeight", value);
			}
		}

		/// <summary>
		/// Отправлено.
		/// </summary>
		public int SendCount {
			get {
				return GetTypedColumnValue<int>("SendCount");
			}
			set {
				SetColumnValue("SendCount", value);
			}
		}

		/// <summary>
		/// Cancelled (communication limit).
		/// </summary>
		public int CommunicationLimitCount {
			get {
				return GetTypedColumnValue<int>("CommunicationLimitCount");
			}
			set {
				SetColumnValue("CommunicationLimitCount", value);
			}
		}

		/// <summary>
		/// utm_source.
		/// </summary>
		public string UtmSource {
			get {
				return GetTypedColumnValue<string>("UtmSource");
			}
			set {
				SetColumnValue("UtmSource", value);
			}
		}

		/// <summary>
		/// utm_medium.
		/// </summary>
		public string UtmMedium {
			get {
				return GetTypedColumnValue<string>("UtmMedium");
			}
			set {
				SetColumnValue("UtmMedium", value);
			}
		}

		/// <summary>
		/// utm_campaign.
		/// </summary>
		public string UtmCampaign {
			get {
				return GetTypedColumnValue<string>("UtmCampaign");
			}
			set {
				SetColumnValue("UtmCampaign", value);
			}
		}

		/// <summary>
		/// utm_term.
		/// </summary>
		public string UtmTerm {
			get {
				return GetTypedColumnValue<string>("UtmTerm");
			}
			set {
				SetColumnValue("UtmTerm", value);
			}
		}

		/// <summary>
		/// utm_content.
		/// </summary>
		public string UtmContent {
			get {
				return GetTypedColumnValue<string>("UtmContent");
			}
			set {
				SetColumnValue("UtmContent", value);
			}
		}

		/// <summary>
		/// Список доменов.
		/// </summary>
		public string Domains {
			get {
				return GetTypedColumnValue<string>("Domains");
			}
			set {
				SetColumnValue("Domains", value);
			}
		}

		/// <summary>
		/// Использовать UTM-метки.
		/// </summary>
		public bool UseUtm {
			get {
				return GetTypedColumnValue<bool>("UseUtm");
			}
			set {
				SetColumnValue("UseUtm", value);
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
		/// StatisticDate.
		/// </summary>
		public DateTime StatisticDate {
			get {
				return GetTypedColumnValue<DateTime>("StatisticDate");
			}
			set {
				SetColumnValue("StatisticDate", value);
			}
		}

		/// <summary>
		/// Обработка откликов завершена.
		/// </summary>
		public bool ResponseProcessingCompleted {
			get {
				return GetTypedColumnValue<bool>("ResponseProcessingCompleted");
			}
			set {
				SetColumnValue("ResponseProcessingCompleted", value);
			}
		}

		/// <exclude/>
		public Guid SplitTestId {
			get {
				return GetTypedColumnValue<Guid>("SplitTestId");
			}
			set {
				SetColumnValue("SplitTestId", value);
				_splitTest = null;
			}
		}

		/// <exclude/>
		public string SplitTestName {
			get {
				return GetTypedColumnValue<string>("SplitTestName");
			}
			set {
				SetColumnValue("SplitTestName", value);
				if (_splitTest != null) {
					_splitTest.Name = value;
				}
			}
		}

		private BulkEmailSplit _splitTest;
		/// <summary>
		/// Сплит-тест.
		/// </summary>
		public BulkEmailSplit SplitTest {
			get {
				return _splitTest ??
					(_splitTest = new BulkEmailSplit(LookupColumnEntities.GetEntity("SplitTest")));
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

		private BulkEmailCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public BulkEmailCategory Category {
			get {
				return _category ??
					(_category = new BulkEmailCategory(LookupColumnEntities.GetEntity("Category")));
			}
		}

		/// <exclude/>
		public Guid LaunchOptionId {
			get {
				return GetTypedColumnValue<Guid>("LaunchOptionId");
			}
			set {
				SetColumnValue("LaunchOptionId", value);
				_launchOption = null;
			}
		}

		/// <exclude/>
		public string LaunchOptionName {
			get {
				return GetTypedColumnValue<string>("LaunchOptionName");
			}
			set {
				SetColumnValue("LaunchOptionName", value);
				if (_launchOption != null) {
					_launchOption.Name = value;
				}
			}
		}

		private BulkEmailLaunchOption _launchOption;
		/// <summary>
		/// Вариант запуска.
		/// </summary>
		public BulkEmailLaunchOption LaunchOption {
			get {
				return _launchOption ??
					(_launchOption = new BulkEmailLaunchOption(LookupColumnEntities.GetEntity("LaunchOption")));
			}
		}

		/// <summary>
		/// Конфиг шаблона.
		/// </summary>
		public string TemplateConfig {
			get {
				return GetTypedColumnValue<string>("TemplateConfig");
			}
			set {
				SetColumnValue("TemplateConfig", value);
			}
		}

		/// <summary>
		/// Количество ошибок доставки.
		/// </summary>
		public int DeliveryError {
			get {
				return GetTypedColumnValue<int>("DeliveryError");
			}
			set {
				SetColumnValue("DeliveryError", value);
			}
		}

		/// <summary>
		/// Системная рассылка.
		/// </summary>
		public bool IsSystemEmail {
			get {
				return GetTypedColumnValue<bool>("IsSystemEmail");
			}
			set {
				SetColumnValue("IsSystemEmail", value);
			}
		}

		/// <summary>
		/// Шаблон отсутствует.
		/// </summary>
		public int TemplateNotFoundCount {
			get {
				return GetTypedColumnValue<int>("TemplateNotFoundCount");
			}
			set {
				SetColumnValue("TemplateNotFoundCount", value);
			}
		}

		/// <summary>
		/// Домен отправителя не подтвержден.
		/// </summary>
		public int SendersDomainNotVerifiedCount {
			get {
				return GetTypedColumnValue<int>("SendersDomainNotVerifiedCount");
			}
			set {
				SetColumnValue("SendersDomainNotVerifiedCount", value);
			}
		}

		/// <summary>
		/// Невалидное имя отправителя.
		/// </summary>
		public int SendersNameNotValidCount {
			get {
				return GetTypedColumnValue<int>("SendersNameNotValidCount");
			}
			set {
				SetColumnValue("SendersNameNotValidCount", value);
			}
		}

		/// <exclude/>
		public Guid AudienceSchemaId {
			get {
				return GetTypedColumnValue<Guid>("AudienceSchemaId");
			}
			set {
				SetColumnValue("AudienceSchemaId", value);
				_audienceSchema = null;
			}
		}

		/// <exclude/>
		public string AudienceSchemaDisplayName {
			get {
				return GetTypedColumnValue<string>("AudienceSchemaDisplayName");
			}
			set {
				SetColumnValue("AudienceSchemaDisplayName", value);
				if (_audienceSchema != null) {
					_audienceSchema.DisplayName = value;
				}
			}
		}

		private BulkEmailAudienceSchema _audienceSchema;
		/// <summary>
		/// Схема аудитории рассылки.
		/// </summary>
		public BulkEmailAudienceSchema AudienceSchema {
			get {
				return _audienceSchema ??
					(_audienceSchema = new BulkEmailAudienceSchema(LookupColumnEntities.GetEntity("AudienceSchema")));
			}
		}

		/// <summary>
		/// Аудитория инициализирована.
		/// </summary>
		public bool IsAudienceInited {
			get {
				return GetTypedColumnValue<bool>("IsAudienceInited");
			}
			set {
				SetColumnValue("IsAudienceInited", value);
			}
		}

		/// <exclude/>
		public Guid ThrottlingModeId {
			get {
				return GetTypedColumnValue<Guid>("ThrottlingModeId");
			}
			set {
				SetColumnValue("ThrottlingModeId", value);
				_throttlingMode = null;
			}
		}

		/// <exclude/>
		public string ThrottlingModeName {
			get {
				return GetTypedColumnValue<string>("ThrottlingModeName");
			}
			set {
				SetColumnValue("ThrottlingModeName", value);
				if (_throttlingMode != null) {
					_throttlingMode.Name = value;
				}
			}
		}

		private BulkEmailThrottlingMode _throttlingMode;
		/// <summary>
		/// Режим распределения.
		/// </summary>
		public BulkEmailThrottlingMode ThrottlingMode {
			get {
				return _throttlingMode ??
					(_throttlingMode = new BulkEmailThrottlingMode(LookupColumnEntities.GetEntity("ThrottlingMode")));
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

		private BulkEmailPriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public BulkEmailPriority Priority {
			get {
				return _priority ??
					(_priority = new BulkEmailPriority(LookupColumnEntities.GetEntity("Priority")));
			}
		}

		/// <summary>
		/// Срок действия рассылки.
		/// </summary>
		public DateTime ExpirationDate {
			get {
				return GetTypedColumnValue<DateTime>("ExpirationDate");
			}
			set {
				SetColumnValue("ExpirationDate", value);
			}
		}

		/// <summary>
		/// По.
		/// </summary>
		public DateTime BusinessTimeEnd {
			get {
				return GetTypedColumnValue<DateTime>("BusinessTimeEnd");
			}
			set {
				SetColumnValue("BusinessTimeEnd", value);
			}
		}

		/// <summary>
		/// С.
		/// </summary>
		public DateTime BusinessTimeStart {
			get {
				return GetTypedColumnValue<DateTime>("BusinessTimeStart");
			}
			set {
				SetColumnValue("BusinessTimeStart", value);
			}
		}

		/// <summary>
		/// Дни запланированной отправки.
		/// </summary>
		public string DeliveryScheduleDays {
			get {
				return GetTypedColumnValue<string>("DeliveryScheduleDays");
			}
			set {
				SetColumnValue("DeliveryScheduleDays", value);
			}
		}

		/// <exclude/>
		public Guid DeliveryScheduleId {
			get {
				return GetTypedColumnValue<Guid>("DeliveryScheduleId");
			}
			set {
				SetColumnValue("DeliveryScheduleId", value);
				_deliverySchedule = null;
			}
		}

		/// <exclude/>
		public string DeliveryScheduleName {
			get {
				return GetTypedColumnValue<string>("DeliveryScheduleName");
			}
			set {
				SetColumnValue("DeliveryScheduleName", value);
				if (_deliverySchedule != null) {
					_deliverySchedule.Name = value;
				}
			}
		}

		private EmailDeliverySchedule _deliverySchedule;
		/// <summary>
		/// Расписание отправки.
		/// </summary>
		public EmailDeliverySchedule DeliverySchedule {
			get {
				return _deliverySchedule ??
					(_deliverySchedule = new EmailDeliverySchedule(LookupColumnEntities.GetEntity("DeliverySchedule")));
			}
		}

		/// <exclude/>
		public Guid ThrottlingQueueId {
			get {
				return GetTypedColumnValue<Guid>("ThrottlingQueueId");
			}
			set {
				SetColumnValue("ThrottlingQueueId", value);
				_throttlingQueue = null;
			}
		}

		/// <exclude/>
		public string ThrottlingQueueName {
			get {
				return GetTypedColumnValue<string>("ThrottlingQueueName");
			}
			set {
				SetColumnValue("ThrottlingQueueName", value);
				if (_throttlingQueue != null) {
					_throttlingQueue.Name = value;
				}
			}
		}

		private EmailThrottlingQueue _throttlingQueue;
		/// <summary>
		/// Очередь распределения.
		/// </summary>
		public EmailThrottlingQueue ThrottlingQueue {
			get {
				return _throttlingQueue ??
					(_throttlingQueue = new EmailThrottlingQueue(LookupColumnEntities.GetEntity("ThrottlingQueue")));
			}
		}

		/// <summary>
		/// Остановлен (истек срок отправки), кол-во.
		/// </summary>
		public int ExpiredCount {
			get {
				return GetTypedColumnValue<int>("ExpiredCount");
			}
			set {
				SetColumnValue("ExpiredCount", value);
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

		/// <summary>
		/// Остановлено вручную, кол-во.
		/// </summary>
		public int StoppedSummaryCount {
			get {
				return GetTypedColumnValue<int>("StoppedSummaryCount");
			}
			set {
				SetColumnValue("StoppedSummaryCount", value);
			}
		}

		/// <summary>
		/// Остановлено вручную, кол-во.
		/// </summary>
		public int StoppedManuallyCount {
			get {
				return GetTypedColumnValue<int>("StoppedManuallyCount");
			}
			set {
				SetColumnValue("StoppedManuallyCount", value);
			}
		}

		/// <summary>
		/// Остановлено вручную (provider), кол-во.
		/// </summary>
		public int StoppedInProviderCount {
			get {
				return GetTypedColumnValue<int>("StoppedInProviderCount");
			}
			set {
				SetColumnValue("StoppedInProviderCount", value);
			}
		}

		/// <summary>
		/// Остановлен (истек срок отправки), кол-во.
		/// </summary>
		public int ExpiredSummaryCount {
			get {
				return GetTypedColumnValue<int>("ExpiredSummaryCount");
			}
			set {
				SetColumnValue("ExpiredSummaryCount", value);
			}
		}

		/// <summary>
		/// Остановлен (истек срок отправки), кол-во (от провайдера).
		/// </summary>
		public int ExpiredInProviderCount {
			get {
				return GetTypedColumnValue<int>("ExpiredInProviderCount");
			}
			set {
				SetColumnValue("ExpiredInProviderCount", value);
			}
		}

		/// <summary>
		/// Задержка между письмами.
		/// </summary>
		public int DelayBetweenEmail {
			get {
				return GetTypedColumnValue<int>("DelayBetweenEmail");
			}
			set {
				SetColumnValue("DelayBetweenEmail", value);
			}
		}

		/// <summary>
		/// Лимит писем в день.
		/// </summary>
		public int DailyLimit {
			get {
				return GetTypedColumnValue<int>("DailyLimit");
			}
			set {
				SetColumnValue("DailyLimit", value);
			}
		}

		/// <summary>
		/// Провайдер рассылок.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		#endregion

	}

	#endregion

}

