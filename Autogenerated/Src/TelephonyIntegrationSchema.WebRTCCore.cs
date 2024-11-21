namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: TelephonyIntegrationSchema

	/// <exclude/>
	public class TelephonyIntegrationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TelephonyIntegrationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TelephonyIntegrationSchema(TelephonyIntegrationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TelephonyIntegrationSchema(TelephonyIntegrationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e");
			RealUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e");
			Name = "TelephonyIntegration";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c89d06fd-f605-48fc-a79f-6dafdba3db24")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("15543760-c7af-dcfb-8284-6f1a6c647483")) == null) {
				Columns.Add(CreateCallRecordLinkUrlTemplateColumn());
			}
			if (Columns.FindByUId(new Guid("310eb169-e0f5-57f5-ab89-4c6b39b2b54c")) == null) {
				Columns.Add(CreateEnableCallRecordingFeatureColumn());
			}
			if (Columns.FindByUId(new Guid("16a13744-e15f-d47b-36cb-9b279136646b")) == null) {
				Columns.Add(CreateLoginColumn());
			}
			if (Columns.FindByUId(new Guid("b1449939-1e20-a176-bb3e-452b1839cf82")) == null) {
				Columns.Add(CreatePasswordColumn());
			}
			if (Columns.FindByUId(new Guid("534453a0-ac28-6a6a-b120-81e2ab3d0617")) == null) {
				Columns.Add(CreateSysMsgLibColumn());
			}
			if (Columns.FindByUId(new Guid("3aed721c-e832-40e5-c741-43195e224b30")) == null) {
				Columns.Add(CreateTokenColumn());
			}
			if (Columns.FindByUId(new Guid("e635d5e4-4f06-3108-e218-2015b565e3d8")) == null) {
				Columns.Add(CreateWebServiceURLColumn());
			}
			if (Columns.FindByUId(new Guid("f70b8cc4-14a6-7ee9-a61f-744a2bbbfee0")) == null) {
				Columns.Add(CreateTelephonyAuthTypeColumn());
			}
			if (Columns.FindByUId(new Guid("f92e8cff-eae2-dcd0-8bc3-3fec5a80e6eb")) == null) {
				Columns.Add(CreateTelephonyServerTimeZoneColumn());
			}
			if (Columns.FindByUId(new Guid("79854a98-2522-a5c1-add5-35ee1095af88")) == null) {
				Columns.Add(CreateUisCallEndTimeShiftColumn());
			}
			if (Columns.FindByUId(new Guid("43902116-cc08-52a7-4254-c16cfc034f28")) == null) {
				Columns.Add(CreateUisCallStartTimeShiftColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("64770060-216b-4b9f-a66c-8619d21a1ada"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c89d06fd-f605-48fc-a79f-6dafdba3db24"),
				Name = @"Notes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateCallRecordLinkUrlTemplateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("15543760-c7af-dcfb-8284-6f1a6c647483"),
				Name = @"CallRecordLinkUrlTemplate",
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateEnableCallRecordingFeatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("310eb169-e0f5-57f5-ab89-4c6b39b2b54c"),
				Name = @"EnableCallRecordingFeature",
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16a13744-e15f-d47b-36cb-9b279136646b"),
				Name = @"Login",
				ReferenceSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b1449939-1e20-a176-bb3e-452b1839cf82"),
				Name = @"Password",
				ReferenceSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateSysMsgLibColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("534453a0-ac28-6a6a-b120-81e2ab3d0617"),
				Name = @"SysMsgLib",
				ReferenceSchemaUId = new Guid("89b9f170-8aed-4f41-8659-c787b50df837"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateTokenColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3aed721c-e832-40e5-c741-43195e224b30"),
				Name = @"Token",
				ReferenceSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateWebServiceURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e635d5e4-4f06-3108-e218-2015b565e3d8"),
				Name = @"WebServiceURL",
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateTelephonyAuthTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f70b8cc4-14a6-7ee9-a61f-744a2bbbfee0"),
				Name = @"TelephonyAuthType",
				ReferenceSchemaUId = new Guid("7aecaccf-4d96-44e0-b1e2-4b6eeec9cee3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2c830ff4-0158-4324-abfb-de8b0871c0d3"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTelephonyServerTimeZoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f92e8cff-eae2-dcd0-8bc3-3fec5a80e6eb"),
				Name = @"TelephonyServerTimeZone",
				ReferenceSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateUisCallEndTimeShiftColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("79854a98-2522-a5c1-add5-35ee1095af88"),
				Name = @"UisCallEndTimeShift",
				ReferenceSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected virtual EntitySchemaColumn CreateUisCallStartTimeShiftColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("43902116-cc08-52a7-4254-c16cfc034f28"),
				Name = @"UisCallStartTimeShift",
				ReferenceSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				ModifiedInSchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"),
				CreatedInPackageId = new Guid("56b4a2f3-f537-4916-9cef-ba7f631fd3cc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TelephonyIntegration(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TelephonyIntegration_WebRTCCoreEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TelephonyIntegrationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TelephonyIntegrationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e"));
		}

		#endregion

	}

	#endregion

	#region Class: TelephonyIntegration

	/// <summary>
	/// Интеграция с телефонией.
	/// </summary>
	public class TelephonyIntegration : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TelephonyIntegration(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TelephonyIntegration";
		}

		public TelephonyIntegration(TelephonyIntegration source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_login = LookupColumnEntities.GetEntity("Login") as VwSysSetting);
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
					(_password = LookupColumnEntities.GetEntity("Password") as VwSysSetting);
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
					(_sysMsgLib = LookupColumnEntities.GetEntity("SysMsgLib") as SysMsgLib);
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
					(_token = LookupColumnEntities.GetEntity("Token") as VwSysSetting);
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
					(_telephonyAuthType = LookupColumnEntities.GetEntity("TelephonyAuthType") as TelephonyAuthType);
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
					(_telephonyServerTimeZone = LookupColumnEntities.GetEntity("TelephonyServerTimeZone") as VwSysSetting);
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
					(_uisCallEndTimeShift = LookupColumnEntities.GetEntity("UisCallEndTimeShift") as VwSysSetting);
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
					(_uisCallStartTimeShift = LookupColumnEntities.GetEntity("UisCallStartTimeShift") as VwSysSetting);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TelephonyIntegration_WebRTCCoreEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TelephonyIntegration(this);
		}

		#endregion

	}

	#endregion

	#region Class: TelephonyIntegration_WebRTCCoreEventsProcess

	/// <exclude/>
	public partial class TelephonyIntegration_WebRTCCoreEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TelephonyIntegration
	{

		public TelephonyIntegration_WebRTCCoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TelephonyIntegration_WebRTCCoreEventsProcess";
			SchemaUId = new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d7a27063-3cae-4e9f-b454-486dae7d1e1e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: TelephonyIntegration_WebRTCCoreEventsProcess

	/// <exclude/>
	public class TelephonyIntegration_WebRTCCoreEventsProcess : TelephonyIntegration_WebRTCCoreEventsProcess<TelephonyIntegration>
	{

		public TelephonyIntegration_WebRTCCoreEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TelephonyIntegration_WebRTCCoreEventsProcess

	public partial class TelephonyIntegration_WebRTCCoreEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TelephonyIntegrationEventsProcess

	/// <exclude/>
	public class TelephonyIntegrationEventsProcess : TelephonyIntegration_WebRTCCoreEventsProcess
	{

		public TelephonyIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

