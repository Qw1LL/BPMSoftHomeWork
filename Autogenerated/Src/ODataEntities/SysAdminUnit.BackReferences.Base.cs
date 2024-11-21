namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysAdminUnit

	/// <exclude/>
	public class SysAdminUnit : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnit";
		}

		public SysAdminUnit(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysAdminUnit";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AdminUnitFeatureState> AdminUnitFeatureStateCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<Calendar> CalendarCollectionByUser {
			get;
			set;
		}

		public IEnumerable<Case> CaseCollectionByGroup {
			get;
			set;
		}

		public IEnumerable<CaseLifecycle> CaseLifecycleCollectionByGroup {
			get;
			set;
		}

		public IEnumerable<Change> ChangeCollectionByGroup {
			get;
			set;
		}

		public IEnumerable<ChatQueueOperator> ChatQueueOperatorCollectionByOperator {
			get;
			set;
		}

		public IEnumerable<ContractVisa> ContractVisaCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<ContractVisa> ContractVisaCollectionByVisaOwner {
			get;
			set;
		}

		public IEnumerable<EmailDefRights> EmailDefRightsCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<FirstFactorToken> FirstFactorTokenCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<FolderFavorite> FolderFavoriteCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<InvoiceVisa> InvoiceVisaCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<InvoiceVisa> InvoiceVisaCollectionByVisaOwner {
			get;
			set;
		}

		public IEnumerable<MailboxSyncSettings> MailboxSyncSettingsCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<MultiDeleteQueue> MultiDeleteQueueCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<OAuthApplications> OAuthApplicationsCollectionBySharedUser {
			get;
			set;
		}

		public IEnumerable<OAuthClientApp> OAuthClientAppCollectionBySystemUser {
			get;
			set;
		}

		public IEnumerable<OAuthTokenStorage> OAuthTokenStorageCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByDirectedOperator {
			get;
			set;
		}

		public IEnumerable<OmniChat> OmniChatCollectionByOperator {
			get;
			set;
		}

		public IEnumerable<OperatorSession> OperatorSessionCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<OpportunityDepartment> OpportunityDepartmentCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<OpportunityVisa> OpportunityVisaCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<OpportunityVisa> OpportunityVisaCollectionByVisaOwner {
			get;
			set;
		}

		public IEnumerable<OptionalFuncSspRole> OptionalFuncSspRoleCollectionByFuncRole {
			get;
			set;
		}

		public IEnumerable<OptionalFuncSspRole> OptionalFuncSspRoleCollectionByOrgRole {
			get;
			set;
		}

		public IEnumerable<OrderVisa> OrderVisaCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<OrderVisa> OrderVisaCollectionByVisaOwner {
			get;
			set;
		}

		public IEnumerable<OrganizationProperty> OrganizationPropertyCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<Problem> ProblemCollectionByGroup {
			get;
			set;
		}

		public IEnumerable<PushNotificationToken> PushNotificationTokenCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<QuickAddMenuSettings> QuickAddMenuSettingsCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<ReleaseTeam> ReleaseTeamCollectionByResponsible {
			get;
			set;
		}

		public IEnumerable<ServiceEngineer> ServiceEngineerCollectionByEngineer {
			get;
			set;
		}

		public IEnumerable<SocialAccount> SocialAccountCollectionByUser {
			get;
			set;
		}

		public IEnumerable<SocialChannelPublisher> SocialChannelPublisherCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialFeedFavoriteTpl> SocialFeedFavoriteTplCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialLike> SocialLikeCollectionByUser {
			get;
			set;
		}

		public IEnumerable<SocialSubscription> SocialSubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SocialUnsubscription> SocialUnsubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminOperationGrantee> SysAdminOperationGranteeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByParentRole {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitInFolder> SysAdminUnitInFolderCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitInRole> SysAdminUnitInRoleCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitInWorkplace> SysAdminUnitInWorkplaceCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitIPRange> SysAdminUnitIPRangeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysAlmRole> SysAlmRoleCollectionByRole {
			get;
			set;
		}

		public IEnumerable<SysEntityOperationGrantee> SysEntityOperationGranteeCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysEntitySchemaOperationRight> SysEntitySchemaOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysExtServiceOperationRight> SysExtServiceOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysFuncRoleInOrgRole> SysFuncRoleInOrgRoleCollectionByFuncRole {
			get;
			set;
		}

		public IEnumerable<SysFuncRoleInOrgRole> SysFuncRoleInOrgRoleCollectionByOrgRole {
			get;
			set;
		}

		public IEnumerable<SysLastUserPassword> SysLastUserPasswordCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysLicUser> SysLicUserCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysMsgUserSettings> SysMsgUserSettingsCollectionByUser {
			get;
			set;
		}

		public IEnumerable<SysProcessSchemaOperationRight> SysProcessSchemaOperationRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysProfileData> SysProfileDataCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysRecentEntity> SysRecentEntityCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysRegistrationData> SysRegistrationDataCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysRepositoryUser> SysRepositoryUserCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysRoleInMobWorkplace> SysRoleInMobWorkplaceCollectionBySysRole {
			get;
			set;
		}

		public IEnumerable<SysSchema> SysSchemaCollectionByLockedBy {
			get;
			set;
		}

		public IEnumerable<SysSettingsValue> SysSettingsValueCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<SysUserInRole> SysUserInRoleCollectionBySysRole {
			get;
			set;
		}

		public IEnumerable<SysUserInRole> SysUserInRoleCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<SysUserSession> SysUserSessionCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<TotpSecret> TotpSecretCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<TotpSetupToken> TotpSetupTokenCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwEmployeesHierarchy> VwEmployeesHierarchyCollectionByManagerUser {
			get;
			set;
		}

		public IEnumerable<VwOAuthAppUser> VwOAuthAppUserCollectionBySysUser {
			get;
			set;
		}

		public IEnumerable<VwRemindingsCount> VwRemindingsCountCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSocialSubscription> VwSocialSubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSocialUnsubscription> VwSocialUnsubscriptionCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwSysProcessSchemaUserRight> VwSysProcessSchemaUserRightCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwUserEmailsCount> VwUserEmailsCountCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwUserRemindingsCount> VwUserRemindingsCountCollectionBySysAdminUnit {
			get;
			set;
		}

		public IEnumerable<VwVisa> VwVisaCollectionByDelegatedFrom {
			get;
			set;
		}

		public IEnumerable<VwVisa> VwVisaCollectionByVisaOwner {
			get;
			set;
		}

		public IEnumerable<WSColourOfField> WSColourOfFieldCollectionByWSRole {
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

		/// <summary>
		/// Тип.
		/// </summary>
		public int SysAdminUnitTypeValue {
			get {
				return GetTypedColumnValue<int>("SysAdminUnitTypeValue");
			}
			set {
				SetColumnValue("SysAdminUnitTypeValue", value);
			}
		}

		/// <exclude/>
		public Guid ParentRoleId {
			get {
				return GetTypedColumnValue<Guid>("ParentRoleId");
			}
			set {
				SetColumnValue("ParentRoleId", value);
				_parentRole = null;
			}
		}

		/// <exclude/>
		public string ParentRoleName {
			get {
				return GetTypedColumnValue<string>("ParentRoleName");
			}
			set {
				SetColumnValue("ParentRoleName", value);
				if (_parentRole != null) {
					_parentRole.Name = value;
				}
			}
		}

		private SysAdminUnit _parentRole;
		/// <summary>
		/// Родительская роль.
		/// </summary>
		public SysAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = new SysAdminUnit(LookupColumnEntities.GetEntity("ParentRole")));
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

		/// <summary>
		/// Доменный пользователь.
		/// </summary>
		public bool IsDirectoryEntry {
			get {
				return GetTypedColumnValue<bool>("IsDirectoryEntry");
			}
			set {
				SetColumnValue("IsDirectoryEntry", value);
			}
		}

		/// <summary>
		/// Часовой пояс.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
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
		/// Активен.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Синхронизировать с LDAP.
		/// </summary>
		public bool SynchronizeWithLDAP {
			get {
				return GetTypedColumnValue<bool>("SynchronizeWithLDAP");
			}
			set {
				SetColumnValue("SynchronizeWithLDAP", value);
			}
		}

		/// <summary>
		/// Элемент LDAP.
		/// </summary>
		public string LDAPEntry {
			get {
				return GetTypedColumnValue<string>("LDAPEntry");
			}
			set {
				SetColumnValue("LDAPEntry", value);
			}
		}

		/// <summary>
		/// Id элемента LDAP.
		/// </summary>
		public string LDAPEntryId {
			get {
				return GetTypedColumnValue<string>("LDAPEntryId");
			}
			set {
				SetColumnValue("LDAPEntryId", value);
			}
		}

		/// <summary>
		/// Уникальное имя элемента LDAP.
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <summary>
		/// Вход выполнен.
		/// </summary>
		public bool LoggedIn {
			get {
				return GetTypedColumnValue<bool>("LoggedIn");
			}
			set {
				SetColumnValue("LoggedIn", value);
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
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Культура.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = new SysCulture(LookupColumnEntities.GetEntity("SysCulture")));
			}
		}

		/// <summary>
		/// Количество попыток входа.
		/// </summary>
		public int LoginAttemptCount {
			get {
				return GetTypedColumnValue<int>("LoginAttemptCount");
			}
			set {
				SetColumnValue("LoginAttemptCount", value);
			}
		}

		/// <summary>
		/// Логин к репозиторию.
		/// </summary>
		public string SourceControlLogin {
			get {
				return GetTypedColumnValue<string>("SourceControlLogin");
			}
			set {
				SetColumnValue("SourceControlLogin", value);
			}
		}

		/// <summary>
		/// Пароль к репозиторию.
		/// </summary>
		public string SourceControlPassword {
			get {
				return GetTypedColumnValue<string>("SourceControlPassword");
			}
			set {
				SetColumnValue("SourceControlPassword", value);
			}
		}

		/// <summary>
		/// Дата окончания действия пароля.
		/// </summary>
		public DateTime PasswordExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("PasswordExpireDate");
			}
			set {
				SetColumnValue("PasswordExpireDate", value);
			}
		}

		/// <exclude/>
		public Guid HomePageId {
			get {
				return GetTypedColumnValue<Guid>("HomePageId");
			}
			set {
				SetColumnValue("HomePageId", value);
				_homePage = null;
			}
		}

		/// <exclude/>
		public string HomePageCaption {
			get {
				return GetTypedColumnValue<string>("HomePageCaption");
			}
			set {
				SetColumnValue("HomePageCaption", value);
				if (_homePage != null) {
					_homePage.Caption = value;
				}
			}
		}

		private SysModule _homePage;
		/// <summary>
		/// Домашняя страница.
		/// </summary>
		public SysModule HomePage {
			get {
				return _homePage ??
					(_homePage = new SysModule(LookupColumnEntities.GetEntity("HomePage")));
			}
		}

		/// <summary>
		/// Тип подключения.
		/// </summary>
		public int ConnectionType {
			get {
				return GetTypedColumnValue<int>("ConnectionType");
			}
			set {
				SetColumnValue("ConnectionType", value);
			}
		}

		/// <summary>
		/// Время разблокировки.
		/// </summary>
		public DateTime UnblockTime {
			get {
				return GetTypedColumnValue<DateTime>("UnblockTime");
			}
			set {
				SetColumnValue("UnblockTime", value);
			}
		}

		/// <summary>
		/// Сбросить пароль.
		/// </summary>
		public bool ForceChangePassword {
			get {
				return GetTypedColumnValue<bool>("ForceChangePassword");
			}
			set {
				SetColumnValue("ForceChangePassword", value);
			}
		}

		/// <exclude/>
		public Guid DateTimeFormatId {
			get {
				return GetTypedColumnValue<Guid>("DateTimeFormatId");
			}
			set {
				SetColumnValue("DateTimeFormatId", value);
				_dateTimeFormat = null;
			}
		}

		/// <exclude/>
		public string DateTimeFormatName {
			get {
				return GetTypedColumnValue<string>("DateTimeFormatName");
			}
			set {
				SetColumnValue("DateTimeFormatName", value);
				if (_dateTimeFormat != null) {
					_dateTimeFormat.Name = value;
				}
			}
		}

		private SysLanguage _dateTimeFormat;
		/// <summary>
		/// Формат отображения даты и времени.
		/// </summary>
		public SysLanguage DateTimeFormat {
			get {
				return _dateTimeFormat ??
					(_dateTimeFormat = new SysLanguage(LookupColumnEntities.GetEntity("DateTimeFormat")));
			}
		}

		/// <summary>
		/// Таймаут сессии (минуты).
		/// </summary>
		public int SessionTimeout {
			get {
				return GetTypedColumnValue<int>("SessionTimeout");
			}
			set {
				SetColumnValue("SessionTimeout", value);
			}
		}

		/// <exclude/>
		public Guid PortalAccountId {
			get {
				return GetTypedColumnValue<Guid>("PortalAccountId");
			}
			set {
				SetColumnValue("PortalAccountId", value);
				_portalAccount = null;
			}
		}

		/// <exclude/>
		public string PortalAccountName {
			get {
				return GetTypedColumnValue<string>("PortalAccountName");
			}
			set {
				SetColumnValue("PortalAccountName", value);
				if (_portalAccount != null) {
					_portalAccount.Name = value;
				}
			}
		}

		private Account _portalAccount;
		/// <summary>
		/// PortalAccount.
		/// </summary>
		public Account PortalAccount {
			get {
				return _portalAccount ??
					(_portalAccount = new Account(LookupColumnEntities.GetEntity("PortalAccount")));
			}
		}

		/// <exclude/>
		public Guid LDAPElementId {
			get {
				return GetTypedColumnValue<Guid>("LDAPElementId");
			}
			set {
				SetColumnValue("LDAPElementId", value);
				_lDAPElement = null;
			}
		}

		/// <exclude/>
		public string LDAPElementName {
			get {
				return GetTypedColumnValue<string>("LDAPElementName");
			}
			set {
				SetColumnValue("LDAPElementName", value);
				if (_lDAPElement != null) {
					_lDAPElement.Name = value;
				}
			}
		}

		private LDAPElement _lDAPElement;
		/// <summary>
		/// Элемент LDAP.
		/// </summary>
		public LDAPElement LDAPElement {
			get {
				return _lDAPElement ??
					(_lDAPElement = new LDAPElement(LookupColumnEntities.GetEntity("LDAPElement")));
			}
		}

		/// <summary>
		/// Не использовать двухфакторную аутентификацию.
		/// </summary>
		public bool Disable2FA {
			get {
				return GetTypedColumnValue<bool>("Disable2FA");
			}
			set {
				SetColumnValue("Disable2FA", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// OpenID sub claim.
		/// </summary>
		public string OpenIDSub {
			get {
				return GetTypedColumnValue<string>("OpenIDSub");
			}
			set {
				SetColumnValue("OpenIDSub", value);
			}
		}

		/// <summary>
		/// Дата и время начала действия УЗ.
		/// </summary>
		public DateTime AccountBeginTime {
			get {
				return GetTypedColumnValue<DateTime>("AccountBeginTime");
			}
			set {
				SetColumnValue("AccountBeginTime", value);
			}
		}

		/// <summary>
		/// Дата и время окончания действия УЗ.
		/// </summary>
		public DateTime AccountExpireTime {
			get {
				return GetTypedColumnValue<DateTime>("AccountExpireTime");
			}
			set {
				SetColumnValue("AccountExpireTime", value);
			}
		}

		/// <summary>
		/// Время последней активности.
		/// </summary>
		public DateTime LastActivityTime {
			get {
				return GetTypedColumnValue<DateTime>("LastActivityTime");
			}
			set {
				SetColumnValue("LastActivityTime", value);
			}
		}

		#endregion

	}

	#endregion

}

