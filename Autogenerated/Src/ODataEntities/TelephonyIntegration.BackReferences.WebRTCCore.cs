namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: TelephonyIntegration

	/// <exclude/>
	public class TelephonyIntegration : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TelephonyIntegration(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TelephonyIntegration";
		}

		public TelephonyIntegration(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TelephonyIntegration";
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
		/// Шаблон URL для получения записи звонка.
		/// </summary>
		public string CallRecordLinkUrlTemplate {
			get {
				return GetTypedColumnValue<string>("CallRecordLinkUrlTemplate");
			}
			set {
				SetColumnValue("CallRecordLinkUrlTemplate", value);
			}
		}

		/// <summary>
		/// Включить функцию прослушивания записи звонка.
		/// </summary>
		public bool EnableCallRecordingFeature {
			get {
				return GetTypedColumnValue<bool>("EnableCallRecordingFeature");
			}
			set {
				SetColumnValue("EnableCallRecordingFeature", value);
			}
		}

		/// <exclude/>
		public Guid LoginId {
			get {
				return GetTypedColumnValue<Guid>("LoginId");
			}
			set {
				SetColumnValue("LoginId", value);
				_login = null;
			}
		}

		/// <exclude/>
		public string LoginName {
			get {
				return GetTypedColumnValue<string>("LoginName");
			}
			set {
				SetColumnValue("LoginName", value);
				if (_login != null) {
					_login.Name = value;
				}
			}
		}

		private VwSysSetting _login;
		/// <summary>
		/// Логин.
		/// </summary>
		public VwSysSetting Login {
			get {
				return _login ??
					(_login = new VwSysSetting(LookupColumnEntities.GetEntity("Login")));
			}
		}

		/// <exclude/>
		public Guid PasswordId {
			get {
				return GetTypedColumnValue<Guid>("PasswordId");
			}
			set {
				SetColumnValue("PasswordId", value);
				_password = null;
			}
		}

		/// <exclude/>
		public string PasswordName {
			get {
				return GetTypedColumnValue<string>("PasswordName");
			}
			set {
				SetColumnValue("PasswordName", value);
				if (_password != null) {
					_password.Name = value;
				}
			}
		}

		private VwSysSetting _password;
		/// <summary>
		/// Пароль.
		/// </summary>
		public VwSysSetting Password {
			get {
				return _password ??
					(_password = new VwSysSetting(LookupColumnEntities.GetEntity("Password")));
			}
		}

		/// <exclude/>
		public Guid SysMsgLibId {
			get {
				return GetTypedColumnValue<Guid>("SysMsgLibId");
			}
			set {
				SetColumnValue("SysMsgLibId", value);
				_sysMsgLib = null;
			}
		}

		/// <exclude/>
		public string SysMsgLibName {
			get {
				return GetTypedColumnValue<string>("SysMsgLibName");
			}
			set {
				SetColumnValue("SysMsgLibName", value);
				if (_sysMsgLib != null) {
					_sysMsgLib.Name = value;
				}
			}
		}

		private SysMsgLib _sysMsgLib;
		/// <summary>
		/// Библиотека обмена сообщениями.
		/// </summary>
		public SysMsgLib SysMsgLib {
			get {
				return _sysMsgLib ??
					(_sysMsgLib = new SysMsgLib(LookupColumnEntities.GetEntity("SysMsgLib")));
			}
		}

		/// <exclude/>
		public Guid TokenId {
			get {
				return GetTypedColumnValue<Guid>("TokenId");
			}
			set {
				SetColumnValue("TokenId", value);
				_token = null;
			}
		}

		/// <exclude/>
		public string TokenName {
			get {
				return GetTypedColumnValue<string>("TokenName");
			}
			set {
				SetColumnValue("TokenName", value);
				if (_token != null) {
					_token.Name = value;
				}
			}
		}

		private VwSysSetting _token;
		/// <summary>
		/// Токен.
		/// </summary>
		public VwSysSetting Token {
			get {
				return _token ??
					(_token = new VwSysSetting(LookupColumnEntities.GetEntity("Token")));
			}
		}

		/// <summary>
		/// URL подключения.
		/// </summary>
		public string WebServiceURL {
			get {
				return GetTypedColumnValue<string>("WebServiceURL");
			}
			set {
				SetColumnValue("WebServiceURL", value);
			}
		}

		/// <exclude/>
		public Guid TelephonyAuthTypeId {
			get {
				return GetTypedColumnValue<Guid>("TelephonyAuthTypeId");
			}
			set {
				SetColumnValue("TelephonyAuthTypeId", value);
				_telephonyAuthType = null;
			}
		}

		/// <exclude/>
		public string TelephonyAuthTypeName {
			get {
				return GetTypedColumnValue<string>("TelephonyAuthTypeName");
			}
			set {
				SetColumnValue("TelephonyAuthTypeName", value);
				if (_telephonyAuthType != null) {
					_telephonyAuthType.Name = value;
				}
			}
		}

		private TelephonyAuthType _telephonyAuthType;
		/// <summary>
		/// Тип аутентификации.
		/// </summary>
		public TelephonyAuthType TelephonyAuthType {
			get {
				return _telephonyAuthType ??
					(_telephonyAuthType = new TelephonyAuthType(LookupColumnEntities.GetEntity("TelephonyAuthType")));
			}
		}

		/// <exclude/>
		public Guid TelephonyServerTimeZoneId {
			get {
				return GetTypedColumnValue<Guid>("TelephonyServerTimeZoneId");
			}
			set {
				SetColumnValue("TelephonyServerTimeZoneId", value);
				_telephonyServerTimeZone = null;
			}
		}

		/// <exclude/>
		public string TelephonyServerTimeZoneName {
			get {
				return GetTypedColumnValue<string>("TelephonyServerTimeZoneName");
			}
			set {
				SetColumnValue("TelephonyServerTimeZoneName", value);
				if (_telephonyServerTimeZone != null) {
					_telephonyServerTimeZone.Name = value;
				}
			}
		}

		private VwSysSetting _telephonyServerTimeZone;
		/// <summary>
		/// Часовой пояс сервера телефонии.
		/// </summary>
		public VwSysSetting TelephonyServerTimeZone {
			get {
				return _telephonyServerTimeZone ??
					(_telephonyServerTimeZone = new VwSysSetting(LookupColumnEntities.GetEntity("TelephonyServerTimeZone")));
			}
		}

		/// <exclude/>
		public Guid UisCallEndTimeShiftId {
			get {
				return GetTypedColumnValue<Guid>("UisCallEndTimeShiftId");
			}
			set {
				SetColumnValue("UisCallEndTimeShiftId", value);
				_uisCallEndTimeShift = null;
			}
		}

		/// <exclude/>
		public string UisCallEndTimeShiftName {
			get {
				return GetTypedColumnValue<string>("UisCallEndTimeShiftName");
			}
			set {
				SetColumnValue("UisCallEndTimeShiftName", value);
				if (_uisCallEndTimeShift != null) {
					_uisCallEndTimeShift.Name = value;
				}
			}
		}

		private VwSysSetting _uisCallEndTimeShift;
		/// <summary>
		/// Сдвиг времени завершения звонка.
		/// </summary>
		public VwSysSetting UisCallEndTimeShift {
			get {
				return _uisCallEndTimeShift ??
					(_uisCallEndTimeShift = new VwSysSetting(LookupColumnEntities.GetEntity("UisCallEndTimeShift")));
			}
		}

		/// <exclude/>
		public Guid UisCallStartTimeShiftId {
			get {
				return GetTypedColumnValue<Guid>("UisCallStartTimeShiftId");
			}
			set {
				SetColumnValue("UisCallStartTimeShiftId", value);
				_uisCallStartTimeShift = null;
			}
		}

		/// <exclude/>
		public string UisCallStartTimeShiftName {
			get {
				return GetTypedColumnValue<string>("UisCallStartTimeShiftName");
			}
			set {
				SetColumnValue("UisCallStartTimeShiftName", value);
				if (_uisCallStartTimeShift != null) {
					_uisCallStartTimeShift.Name = value;
				}
			}
		}

		private VwSysSetting _uisCallStartTimeShift;
		/// <summary>
		/// Сдвиг времени начала звонка.
		/// </summary>
		public VwSysSetting UisCallStartTimeShift {
			get {
				return _uisCallStartTimeShift ??
					(_uisCallStartTimeShift = new VwSysSetting(LookupColumnEntities.GetEntity("UisCallStartTimeShift")));
			}
		}

		#endregion

	}

	#endregion

}

