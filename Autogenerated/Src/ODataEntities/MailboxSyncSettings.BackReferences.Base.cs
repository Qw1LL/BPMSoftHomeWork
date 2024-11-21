namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MailboxSyncSettings

	/// <exclude/>
	public class MailboxSyncSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailboxSyncSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailboxSyncSettings";
		}

		public MailboxSyncSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MailboxSyncSettings";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ActivitySyncSettings> ActivitySyncSettingsCollectionByMailboxSyncSettings {
			get;
			set;
		}

		public IEnumerable<ContactSyncSettings> ContactSyncSettingsCollectionByMailboxSyncSettings {
			get;
			set;
		}

		public IEnumerable<EmailDefRights> EmailDefRightsCollectionByRecord {
			get;
			set;
		}

		public IEnumerable<MailboxContactFolder> MailboxContactFolderCollectionByMailboxSyncSettings {
			get;
			set;
		}

		public IEnumerable<MailboxFoldersCorrespondence> MailboxFoldersCorrespondenceCollectionByMailbox {
			get;
			set;
		}

		public IEnumerable<MailboxForIncidentRegistration> MailboxForIncidentRegistrationCollectionByMailboxSyncSettings {
			get;
			set;
		}

		public IEnumerable<MailboxSettingsFile> MailboxSettingsFileCollectionByMailboxSyncSettings {
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

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// Пользователь системы.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = new SysAdminUnit(LookupColumnEntities.GetEntity("SysAdminUnit")));
			}
		}

		/// <exclude/>
		public Guid MailServerId {
			get {
				return GetTypedColumnValue<Guid>("MailServerId");
			}
			set {
				SetColumnValue("MailServerId", value);
				_mailServer = null;
			}
		}

		/// <exclude/>
		public string MailServerName {
			get {
				return GetTypedColumnValue<string>("MailServerName");
			}
			set {
				SetColumnValue("MailServerName", value);
				if (_mailServer != null) {
					_mailServer.Name = value;
				}
			}
		}

		private MailServer _mailServer;
		/// <summary>
		/// Почтовый провайдер.
		/// </summary>
		public MailServer MailServer {
			get {
				return _mailServer ??
					(_mailServer = new MailServer(LookupColumnEntities.GetEntity("MailServer")));
			}
		}

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
			}
		}

		/// <summary>
		/// Пароль.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
			}
		}

		/// <summary>
		/// Загружать письма в BPMConstructor.
		/// </summary>
		public bool EnableMailSynhronization {
			get {
				return GetTypedColumnValue<bool>("EnableMailSynhronization");
			}
			set {
				SetColumnValue("EnableMailSynhronization", value);
			}
		}

		/// <summary>
		/// Автоматически загружать новые сообщения.
		/// </summary>
		public bool AutomaticallyAddNewEmails {
			get {
				return GetTypedColumnValue<bool>("AutomaticallyAddNewEmails");
			}
			set {
				SetColumnValue("AutomaticallyAddNewEmails", value);
			}
		}

		/// <summary>
		/// Циклически загружать новые сообщения.
		/// </summary>
		public bool CyclicallyAddNewEmails {
			get {
				return GetTypedColumnValue<bool>("CyclicallyAddNewEmails");
			}
			set {
				SetColumnValue("CyclicallyAddNewEmails", value);
			}
		}

		/// <summary>
		/// Интервал циклической загрузки.
		/// </summary>
		public int EmailsCyclicallyAddingInterval {
			get {
				return GetTypedColumnValue<int>("EmailsCyclicallyAddingInterval");
			}
			set {
				SetColumnValue("EmailsCyclicallyAddingInterval", value);
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
		/// IsCustomFlagsNotSuported.
		/// </summary>
		public bool IsCustomFlagsNotSuported {
			get {
				return GetTypedColumnValue<bool>("IsCustomFlagsNotSuported");
			}
			set {
				SetColumnValue("IsCustomFlagsNotSuported", value);
			}
		}

		/// <summary>
		/// LastSyncDate.
		/// </summary>
		public DateTime LastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("LastSyncDate");
			}
			set {
				SetColumnValue("LastSyncDate", value);
			}
		}

		/// <summary>
		/// Доступ для других пользователей.
		/// </summary>
		public bool IsShared {
			get {
				return GetTypedColumnValue<bool>("IsShared");
			}
			set {
				SetColumnValue("IsShared", value);
			}
		}

		/// <summary>
		/// Отправлять письма из BPMConstructor.
		/// </summary>
		public bool SendEmailsViaThisAccount {
			get {
				return GetTypedColumnValue<bool>("SendEmailsViaThisAccount");
			}
			set {
				SetColumnValue("SendEmailsViaThisAccount", value);
			}
		}

		/// <summary>
		/// Использовать по умолчанию при отправке.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		/// <summary>
		/// Загружать все сообщения из почтового ящика.
		/// </summary>
		public bool LoadAllEmailsFromMailBox {
			get {
				return GetTypedColumnValue<bool>("LoadAllEmailsFromMailBox");
			}
			set {
				SetColumnValue("LoadAllEmailsFromMailBox", value);
			}
		}

		/// <summary>
		/// Загружать сообщения начиная с даты.
		/// </summary>
		public DateTime LoadEmailsFromDate {
			get {
				return GetTypedColumnValue<DateTime>("LoadEmailsFromDate");
			}
			set {
				SetColumnValue("LoadEmailsFromDate", value);
			}
		}

		/// <summary>
		/// Название почтового ящика.
		/// </summary>
		public string MailboxName {
			get {
				return GetTypedColumnValue<string>("MailboxName");
			}
			set {
				SetColumnValue("MailboxName", value);
			}
		}

		/// <summary>
		/// E-mail адрес отправителя.
		/// </summary>
		public string SenderEmailAddress {
			get {
				return GetTypedColumnValue<string>("SenderEmailAddress");
			}
			set {
				SetColumnValue("SenderEmailAddress", value);
			}
		}

		/// <exclude/>
		public Guid MailSyncPeriodId {
			get {
				return GetTypedColumnValue<Guid>("MailSyncPeriodId");
			}
			set {
				SetColumnValue("MailSyncPeriodId", value);
				_mailSyncPeriod = null;
			}
		}

		/// <exclude/>
		public string MailSyncPeriodName {
			get {
				return GetTypedColumnValue<string>("MailSyncPeriodName");
			}
			set {
				SetColumnValue("MailSyncPeriodName", value);
				if (_mailSyncPeriod != null) {
					_mailSyncPeriod.Name = value;
				}
			}
		}

		private MailSyncPeriod _mailSyncPeriod;
		/// <summary>
		/// Загружать письма за период.
		/// </summary>
		public MailSyncPeriod MailSyncPeriod {
			get {
				return _mailSyncPeriod ??
					(_mailSyncPeriod = new MailSyncPeriod(LookupColumnEntities.GetEntity("MailSyncPeriod")));
			}
		}

		/// <summary>
		/// Анонимная авторизация.
		/// </summary>
		public bool IsAnonymousAuthentication {
			get {
				return GetTypedColumnValue<bool>("IsAnonymousAuthentication");
			}
			set {
				SetColumnValue("IsAnonymousAuthentication", value);
			}
		}

		/// <summary>
		/// Циклически синхронизировать контакты и активности.
		/// </summary>
		public bool ExchangeAutoSynchronization {
			get {
				return GetTypedColumnValue<bool>("ExchangeAutoSynchronization");
			}
			set {
				SetColumnValue("ExchangeAutoSynchronization", value);
			}
		}

		/// <summary>
		/// Интервал синхронизации контактов и активностей.
		/// </summary>
		public int ExchangeSyncInterval {
			get {
				return GetTypedColumnValue<int>("ExchangeSyncInterval");
			}
			set {
				SetColumnValue("ExchangeSyncInterval", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		public int ContactSyncInterval {
			get {
				return GetTypedColumnValue<int>("ContactSyncInterval");
			}
			set {
				SetColumnValue("ContactSyncInterval", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		public bool ExchangeAutoSyncActivity {
			get {
				return GetTypedColumnValue<bool>("ExchangeAutoSyncActivity");
			}
			set {
				SetColumnValue("ExchangeAutoSyncActivity", value);
			}
		}

		/// <summary>
		/// Задать псевдоним при отправке.
		/// </summary>
		public string SenderDisplayValue {
			get {
				return GetTypedColumnValue<string>("SenderDisplayValue");
			}
			set {
				SetColumnValue("SenderDisplayValue", value);
			}
		}

		/// <summary>
		/// Подпись.
		/// </summary>
		public string Signature {
			get {
				return GetTypedColumnValue<string>("Signature");
			}
			set {
				SetColumnValue("Signature", value);
			}
		}

		/// <summary>
		/// Использовать подпись при отправке.
		/// </summary>
		public bool UseSignature {
			get {
				return GetTypedColumnValue<bool>("UseSignature");
			}
			set {
				SetColumnValue("UseSignature", value);
			}
		}

		/// <summary>
		/// ActualizeMessageRelations.
		/// </summary>
		public bool ActualizeMessageRelations {
			get {
				return GetTypedColumnValue<bool>("ActualizeMessageRelations");
			}
			set {
				SetColumnValue("ActualizeMessageRelations", value);
			}
		}

		/// <exclude/>
		public Guid MessageLanguageId {
			get {
				return GetTypedColumnValue<Guid>("MessageLanguageId");
			}
			set {
				SetColumnValue("MessageLanguageId", value);
				_messageLanguage = null;
			}
		}

		/// <exclude/>
		public string MessageLanguageName {
			get {
				return GetTypedColumnValue<string>("MessageLanguageName");
			}
			set {
				SetColumnValue("MessageLanguageName", value);
				if (_messageLanguage != null) {
					_messageLanguage.Name = value;
				}
			}
		}

		private SysLanguage _messageLanguage;
		/// <summary>
		/// Язык общения.
		/// </summary>
		public SysLanguage MessageLanguage {
			get {
				return _messageLanguage ??
					(_messageLanguage = new SysLanguage(LookupColumnEntities.GetEntity("MessageLanguage")));
			}
		}

		/// <summary>
		/// Текст последней ошибки синхронизации.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <exclude/>
		public Guid ErrorCodeId {
			get {
				return GetTypedColumnValue<Guid>("ErrorCodeId");
			}
			set {
				SetColumnValue("ErrorCodeId", value);
				_errorCode = null;
			}
		}

		/// <exclude/>
		public string ErrorCodeName {
			get {
				return GetTypedColumnValue<string>("ErrorCodeName");
			}
			set {
				SetColumnValue("ErrorCodeName", value);
				if (_errorCode != null) {
					_errorCode.Name = value;
				}
			}
		}

		private SyncErrorMessage _errorCode;
		/// <summary>
		/// Идентификатор кода ошибки.
		/// </summary>
		public SyncErrorMessage ErrorCode {
			get {
				return _errorCode ??
					(_errorCode = new SyncErrorMessage(LookupColumnEntities.GetEntity("ErrorCode")));
			}
		}

		/// <summary>
		/// Количество повторных попыток синхронизации.
		/// </summary>
		public int RetryCounter {
			get {
				return GetTypedColumnValue<int>("RetryCounter");
			}
			set {
				SetColumnValue("RetryCounter", value);
			}
		}

		/// <exclude/>
		public Guid OAuthTokenStorageId {
			get {
				return GetTypedColumnValue<Guid>("OAuthTokenStorageId");
			}
			set {
				SetColumnValue("OAuthTokenStorageId", value);
				_oAuthTokenStorage = null;
			}
		}

		/// <exclude/>
		public string OAuthTokenStorageUserAppLogin {
			get {
				return GetTypedColumnValue<string>("OAuthTokenStorageUserAppLogin");
			}
			set {
				SetColumnValue("OAuthTokenStorageUserAppLogin", value);
				if (_oAuthTokenStorage != null) {
					_oAuthTokenStorage.UserAppLogin = value;
				}
			}
		}

		private OAuthTokenStorage _oAuthTokenStorage;
		/// <summary>
		/// Идентификатор OAuth хранилища токенов.
		/// </summary>
		public OAuthTokenStorage OAuthTokenStorage {
			get {
				return _oAuthTokenStorage ??
					(_oAuthTokenStorage = new OAuthTokenStorage(LookupColumnEntities.GetEntity("OAuthTokenStorage")));
			}
		}

		/// <summary>
		/// SyncDateMinutesOffset.
		/// </summary>
		public int SyncDateMinutesOffset {
			get {
				return GetTypedColumnValue<int>("SyncDateMinutesOffset");
			}
			set {
				SetColumnValue("SyncDateMinutesOffset", value);
			}
		}

		/// <summary>
		/// Отправлять уведомления о новых письмах по web сокету.
		/// </summary>
		public bool SendWebsocketNotifications {
			get {
				return GetTypedColumnValue<bool>("SendWebsocketNotifications");
			}
			set {
				SetColumnValue("SendWebsocketNotifications", value);
			}
		}

		/// <summary>
		/// PersonalMetrics.
		/// </summary>
		public bool PersonalMetrics {
			get {
				return GetTypedColumnValue<bool>("PersonalMetrics");
			}
			set {
				SetColumnValue("PersonalMetrics", value);
			}
		}

		/// <summary>
		/// Синхронизация остановлена.
		/// </summary>
		public bool SynchronizationStopped {
			get {
				return GetTypedColumnValue<bool>("SynchronizationStopped");
			}
			set {
				SetColumnValue("SynchronizationStopped", value);
			}
		}

		/// <summary>
		/// Помечать синхронизированые письма.
		/// </summary>
		public bool MarkEmailsAsSynchronized {
			get {
				return GetTypedColumnValue<bool>("MarkEmailsAsSynchronized");
			}
			set {
				SetColumnValue("MarkEmailsAsSynchronized", value);
			}
		}

		#endregion

	}

	#endregion

}

