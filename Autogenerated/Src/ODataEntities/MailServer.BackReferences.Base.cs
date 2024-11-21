namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: MailServer

	/// <exclude/>
	public class MailServer : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailServer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailServer";
		}

		public MailServer(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MailServer";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<MailboxSyncSettings> MailboxSyncSettingsCollectionByMailServer {
			get;
			set;
		}

		public IEnumerable<MailServerDomain> MailServerDomainCollectionByMailServer {
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
		/// Имя или IP-адрес сервера входящей почты.
		/// </summary>
		public string Address {
			get {
				return GetTypedColumnValue<string>("Address");
			}
			set {
				SetColumnValue("Address", value);
			}
		}

		/// <summary>
		/// Порт.
		/// </summary>
		public int Port {
			get {
				return GetTypedColumnValue<int>("Port");
			}
			set {
				SetColumnValue("Port", value);
			}
		}

		/// <summary>
		/// Использовать протокол SSL для шифрования подключения.
		/// </summary>
		public bool UseSSL {
			get {
				return GetTypedColumnValue<bool>("UseSSL");
			}
			set {
				SetColumnValue("UseSSL", value);
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
		public Guid EmailProtocolId {
			get {
				return GetTypedColumnValue<Guid>("EmailProtocolId");
			}
			set {
				SetColumnValue("EmailProtocolId", value);
				_emailProtocol = null;
			}
		}

		/// <exclude/>
		public string EmailProtocolName {
			get {
				return GetTypedColumnValue<string>("EmailProtocolName");
			}
			set {
				SetColumnValue("EmailProtocolName", value);
				if (_emailProtocol != null) {
					_emailProtocol.Name = value;
				}
			}
		}

		private EmailProtocol _emailProtocol;
		/// <summary>
		/// Протокол подключения.
		/// </summary>
		public EmailProtocol EmailProtocol {
			get {
				return _emailProtocol ??
					(_emailProtocol = new EmailProtocol(LookupColumnEntities.GetEntity("EmailProtocol")));
			}
		}

		/// <summary>
		/// Разрешить загрузку e-mail сообщений.
		/// </summary>
		public bool AllowEmailDownloading {
			get {
				return GetTypedColumnValue<bool>("AllowEmailDownloading");
			}
			set {
				SetColumnValue("AllowEmailDownloading", value);
			}
		}

		/// <summary>
		/// Разрешить отправку e-mail сообщений.
		/// </summary>
		public bool AllowEmailSending {
			get {
				return GetTypedColumnValue<bool>("AllowEmailSending");
			}
			set {
				SetColumnValue("AllowEmailSending", value);
			}
		}

		/// <summary>
		/// Имя или IP-адрес сервера исходящей почты (SMTP).
		/// </summary>
		public string SMTPServerAddress {
			get {
				return GetTypedColumnValue<string>("SMTPServerAddress");
			}
			set {
				SetColumnValue("SMTPServerAddress", value);
			}
		}

		/// <summary>
		/// Порт.
		/// </summary>
		public int SMTPPort {
			get {
				return GetTypedColumnValue<int>("SMTPPort");
			}
			set {
				SetColumnValue("SMTPPort", value);
			}
		}

		/// <summary>
		/// Время ожидания ответа от сервера при отправке почты, секунд.
		/// </summary>
		public int SMTPServerTimeout {
			get {
				return GetTypedColumnValue<int>("SMTPServerTimeout");
			}
			set {
				SetColumnValue("SMTPServerTimeout", value);
			}
		}

		/// <summary>
		/// Использовать протокол SSL для шифрования подключения при отправке.
		/// </summary>
		public bool UseSSLforSending {
			get {
				return GetTypedColumnValue<bool>("UseSSLforSending");
			}
			set {
				SetColumnValue("UseSSLforSending", value);
			}
		}

		/// <summary>
		/// Адрес сервера.
		/// </summary>
		public string ExchangeEmailAddress {
			get {
				return GetTypedColumnValue<string>("ExchangeEmailAddress");
			}
			set {
				SetColumnValue("ExchangeEmailAddress", value);
			}
		}

		/// <summary>
		/// Автообнаружение.
		/// </summary>
		public bool IsExchengeAutodiscover {
			get {
				return GetTypedColumnValue<bool>("IsExchengeAutodiscover");
			}
			set {
				SetColumnValue("IsExchengeAutodiscover", value);
			}
		}

		/// <summary>
		/// Создавать зашифрованное соединение (STARTTLS).
		/// </summary>
		public bool IsStartTls {
			get {
				return GetTypedColumnValue<bool>("IsStartTls");
			}
			set {
				SetColumnValue("IsStartTls", value);
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

		private MailServerType _type;
		/// <summary>
		/// Тип почтового провайдера.
		/// </summary>
		public MailServerType Type {
			get {
				return _type ??
					(_type = new MailServerType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Вводить логин вручную.
		/// </summary>
		public bool UseLogin {
			get {
				return GetTypedColumnValue<bool>("UseLogin");
			}
			set {
				SetColumnValue("UseLogin", value);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Логотип.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = new SysImage(LookupColumnEntities.GetEntity("Logo")));
			}
		}

		/// <summary>
		/// Использовать имя почтового ящика как логин.
		/// </summary>
		public bool UseUserNameAsLogin {
			get {
				return GetTypedColumnValue<bool>("UseUserNameAsLogin");
			}
			set {
				SetColumnValue("UseUserNameAsLogin", value);
			}
		}

		/// <summary>
		/// Использовать email как логин.
		/// </summary>
		public bool UseEmailAddressAsLogin {
			get {
				return GetTypedColumnValue<bool>("UseEmailAddressAsLogin");
			}
			set {
				SetColumnValue("UseEmailAddressAsLogin", value);
			}
		}

		/// <summary>
		/// Стратегия.
		/// </summary>
		public string Strategy {
			get {
				return GetTypedColumnValue<string>("Strategy");
			}
			set {
				SetColumnValue("Strategy", value);
			}
		}

		/// <exclude/>
		public Guid OAuthApplicationId {
			get {
				return GetTypedColumnValue<Guid>("OAuthApplicationId");
			}
			set {
				SetColumnValue("OAuthApplicationId", value);
				_oAuthApplication = null;
			}
		}

		/// <exclude/>
		public string OAuthApplicationName {
			get {
				return GetTypedColumnValue<string>("OAuthApplicationName");
			}
			set {
				SetColumnValue("OAuthApplicationName", value);
				if (_oAuthApplication != null) {
					_oAuthApplication.Name = value;
				}
			}
		}

		private OAuthApplications _oAuthApplication;
		/// <summary>
		/// Идентификатор OAuth приложения.
		/// </summary>
		public OAuthApplications OAuthApplication {
			get {
				return _oAuthApplication ??
					(_oAuthApplication = new OAuthApplications(LookupColumnEntities.GetEntity("OAuthApplication")));
			}
		}

		/// <summary>
		/// SubscriptionTtl.
		/// </summary>
		public int SubscriptionTtl {
			get {
				return GetTypedColumnValue<int>("SubscriptionTtl");
			}
			set {
				SetColumnValue("SubscriptionTtl", value);
			}
		}

		/// <exclude/>
		public Guid SmtpSecureOptionId {
			get {
				return GetTypedColumnValue<Guid>("SmtpSecureOptionId");
			}
			set {
				SetColumnValue("SmtpSecureOptionId", value);
				_smtpSecureOption = null;
			}
		}

		/// <exclude/>
		public string SmtpSecureOptionName {
			get {
				return GetTypedColumnValue<string>("SmtpSecureOptionName");
			}
			set {
				SetColumnValue("SmtpSecureOptionName", value);
				if (_smtpSecureOption != null) {
					_smtpSecureOption.Name = value;
				}
			}
		}

		private MailSecureOption _smtpSecureOption;
		/// <summary>
		/// Варианты безопасности подключения к почтовому серверу smtp.
		/// </summary>
		public MailSecureOption SmtpSecureOption {
			get {
				return _smtpSecureOption ??
					(_smtpSecureOption = new MailSecureOption(LookupColumnEntities.GetEntity("SmtpSecureOption")));
			}
		}

		/// <exclude/>
		public Guid ImapSecureOptionId {
			get {
				return GetTypedColumnValue<Guid>("ImapSecureOptionId");
			}
			set {
				SetColumnValue("ImapSecureOptionId", value);
				_imapSecureOption = null;
			}
		}

		/// <exclude/>
		public string ImapSecureOptionName {
			get {
				return GetTypedColumnValue<string>("ImapSecureOptionName");
			}
			set {
				SetColumnValue("ImapSecureOptionName", value);
				if (_imapSecureOption != null) {
					_imapSecureOption.Name = value;
				}
			}
		}

		private MailSecureOption _imapSecureOption;
		/// <summary>
		/// Варианты безопасности подключения к почтовому серверу imap.
		/// </summary>
		public MailSecureOption ImapSecureOption {
			get {
				return _imapSecureOption ??
					(_imapSecureOption = new MailSecureOption(LookupColumnEntities.GetEntity("ImapSecureOption")));
			}
		}

		#endregion

	}

	#endregion

}

