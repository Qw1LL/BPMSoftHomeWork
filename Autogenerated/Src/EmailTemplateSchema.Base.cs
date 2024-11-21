namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: EmailTemplate_Base_BPMSoftSchema

	/// <exclude/>
	public class EmailTemplate_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailTemplate_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailTemplate_Base_BPMSoftSchema(EmailTemplate_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailTemplate_Base_BPMSoftSchema(EmailTemplate_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			RealUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			Name = "EmailTemplate_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			if (Columns.FindByUId(new Guid("26bd9f25-0d50-4c47-829f-8b286576317c")) == null) {
				Columns.Add(CreateObjectColumn());
			}
			if (Columns.FindByUId(new Guid("382c1794-3e8d-4895-91ce-02c9f5e3553e")) == null) {
				Columns.Add(CreateRecipientColumn());
			}
			if (Columns.FindByUId(new Guid("085d7c7c-fdbc-443a-ad06-1f04ace34173")) == null) {
				Columns.Add(CreateCopyRecipientColumn());
			}
			if (Columns.FindByUId(new Guid("47e72ecd-b21c-4b09-933e-6c1263381425")) == null) {
				Columns.Add(CreateBlindCopyRecipientColumn());
			}
			if (Columns.FindByUId(new Guid("2e7c35e3-0774-4a4a-bea5-6ce4c8de1465")) == null) {
				Columns.Add(CreateSubjectColumn());
			}
			if (Columns.FindByUId(new Guid("feab52f3-9df5-4499-8425-855973838905")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("54425b16-8b5b-40a1-baf1-3997560a6b0e")) == null) {
				Columns.Add(CreateBodyColumn());
			}
			if (Columns.FindByUId(new Guid("698c2960-3832-4ba4-ad56-8a6489b32ad4")) == null) {
				Columns.Add(CreateIsHtmlBodyColumn());
			}
			if (Columns.FindByUId(new Guid("e6618002-83f7-419a-a866-63ea7599b123")) == null) {
				Columns.Add(CreateMacrosColumn());
			}
			if (Columns.FindByUId(new Guid("cf75d513-0d42-439c-b19f-8c7fe4234460")) == null) {
				Columns.Add(CreateSendIndividualEmailColumn());
			}
			if (Columns.FindByUId(new Guid("613d189f-c6a0-4ec4-b2b0-a43199cacef4")) == null) {
				Columns.Add(CreateSaveAsActivityColumn());
			}
			if (Columns.FindByUId(new Guid("b1b8aa8c-787f-42e0-8af1-603d1761f75a")) == null) {
				Columns.Add(CreateObjectFieldInActivityColumn());
			}
			if (Columns.FindByUId(new Guid("aa4c5784-7f68-47d8-b7bb-ee3f89221ac8")) == null) {
				Columns.Add(CreateShowBeforeSendingColumn());
			}
			if (Columns.FindByUId(new Guid("b4972436-c042-4a3b-a025-f04575f10532")) == null) {
				Columns.Add(CreateTemplateConfigColumn());
			}
			if (Columns.FindByUId(new Guid("2f0c4548-e688-4561-a3a3-e6e9422ff3f7")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("08aeb0b2-b929-4208-900f-d5d58700a872")) == null) {
				Columns.Add(CreateTemplateTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ca53e2c8-0767-4f2c-8a18-2ee5821f134e"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateObjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("26bd9f25-0d50-4c47-829f-8b286576317c"),
				Name = @"Object",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("382c1794-3e8d-4895-91ce-02c9f5e3553e"),
				Name = @"Recipient",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCopyRecipientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("085d7c7c-fdbc-443a-ad06-1f04ace34173"),
				Name = @"CopyRecipient",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBlindCopyRecipientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("47e72ecd-b21c-4b09-933e-6c1263381425"),
				Name = @"BlindCopyRecipient",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2e7c35e3-0774-4a4a-bea5-6ce4c8de1465"),
				Name = @"Subject",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("feab52f3-9df5-4499-8425-855973838905"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("54425b16-8b5b-40a1-baf1-3997560a6b0e"),
				Name = @"Body",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsHtmlBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("698c2960-3832-4ba4-ad56-8a6489b32ad4"),
				Name = @"IsHtmlBody",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMacrosColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("e6618002-83f7-419a-a866-63ea7599b123"),
				Name = @"Macros",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSendIndividualEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf75d513-0d42-439c-b19f-8c7fe4234460"),
				Name = @"SendIndividualEmail",
				ReferenceSchemaUId = new Guid("4faa5635-4485-41d9-bd19-6692a41c4e19"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"e75ac3fe-be9b-4a01-87db-c7dffd354f8c"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSaveAsActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("613d189f-c6a0-4ec4-b2b0-a43199cacef4"),
				Name = @"SaveAsActivity",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateObjectFieldInActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b1b8aa8c-787f-42e0-8af1-603d1761f75a"),
				Name = @"ObjectFieldInActivity",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateShowBeforeSendingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("aa4c5784-7f68-47d8-b7bb-ee3f89221ac8"),
				Name = @"ShowBeforeSending",
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b4972436-c042-4a3b-a025-f04575f10532"),
				Name = @"TemplateConfig",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("c7ae8823-851f-4a36-b6d4-2ab23c1078fe"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2f0c4548-e688-4561-a3a3-e6e9422ff3f7"),
				Name = @"Notes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateTemplateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("08aeb0b2-b929-4208-900f-d5d58700a872"),
				Name = @"TemplateType",
				ReferenceSchemaUId = new Guid("e7c7ec31-2e3f-4c8e-bcaa-b71e1989ba5c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				ModifiedInSchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailTemplate_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailTemplate_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailTemplate_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailTemplate_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("93030575-f70f-4041-902e-c4badaf62c63"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplate_Base_BPMSoft

	/// <summary>
	/// Шаблон сообщения.
	/// </summary>
	public class EmailTemplate_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailTemplate_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplate_Base_BPMSoft";
		}

		public EmailTemplate_Base_BPMSoft(EmailTemplate_Base_BPMSoft source)
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

		/// <exclude/>
		public Guid ObjectId {
			get {
				return GetTypedColumnValue<Guid>("ObjectId");
			}
			set {
				SetColumnValue("ObjectId", value);
				_object = null;
			}
		}

		/// <exclude/>
		public string ObjectCaption {
			get {
				return GetTypedColumnValue<string>("ObjectCaption");
			}
			set {
				SetColumnValue("ObjectCaption", value);
				if (_object != null) {
					_object.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _object;
		/// <summary>
		/// Объект.
		/// </summary>
		public VwSysSchemaInfo Object {
			get {
				return _object ??
					(_object = LookupColumnEntities.GetEntity("Object") as VwSysSchemaInfo);
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
					(_priority = LookupColumnEntities.GetEntity("Priority") as ActivityPriority);
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
		/// Тело в HTML-формате.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <exclude/>
		public Guid SendIndividualEmailId {
			get {
				return GetTypedColumnValue<Guid>("SendIndividualEmailId");
			}
			set {
				SetColumnValue("SendIndividualEmailId", value);
				_sendIndividualEmail = null;
			}
		}

		/// <exclude/>
		public string SendIndividualEmailName {
			get {
				return GetTypedColumnValue<string>("SendIndividualEmailName");
			}
			set {
				SetColumnValue("SendIndividualEmailName", value);
				if (_sendIndividualEmail != null) {
					_sendIndividualEmail.Name = value;
				}
			}
		}

		private EmailTemplateSendFlag _sendIndividualEmail;
		/// <summary>
		/// Отправлять индивидуальное e-mail сообщение каждому получателю.
		/// </summary>
		public EmailTemplateSendFlag SendIndividualEmail {
			get {
				return _sendIndividualEmail ??
					(_sendIndividualEmail = LookupColumnEntities.GetEntity("SendIndividualEmail") as EmailTemplateSendFlag);
			}
		}

		/// <summary>
		/// Сохранять как активность.
		/// </summary>
		public bool SaveAsActivity {
			get {
				return GetTypedColumnValue<bool>("SaveAsActivity");
			}
			set {
				SetColumnValue("SaveAsActivity", value);
			}
		}

		/// <summary>
		/// Поле связи с объектом.
		/// </summary>
		public Guid ObjectFieldInActivity {
			get {
				return GetTypedColumnValue<Guid>("ObjectFieldInActivity");
			}
			set {
				SetColumnValue("ObjectFieldInActivity", value);
			}
		}

		/// <summary>
		/// Открывать карточку активности перед отправкой.
		/// </summary>
		public bool ShowBeforeSending {
			get {
				return GetTypedColumnValue<bool>("ShowBeforeSending");
			}
			set {
				SetColumnValue("ShowBeforeSending", value);
			}
		}

		/// <summary>
		/// TemplateConfig.
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
		/// Notes.
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
		public Guid TemplateTypeId {
			get {
				return GetTypedColumnValue<Guid>("TemplateTypeId");
			}
			set {
				SetColumnValue("TemplateTypeId", value);
				_templateType = null;
			}
		}

		/// <exclude/>
		public string TemplateTypeName {
			get {
				return GetTypedColumnValue<string>("TemplateTypeName");
			}
			set {
				SetColumnValue("TemplateTypeName", value);
				if (_templateType != null) {
					_templateType.Name = value;
				}
			}
		}

		private MessageTemplateType _templateType;
		/// <summary>
		/// Тип шаблона.
		/// </summary>
		public MessageTemplateType TemplateType {
			get {
				return _templateType ??
					(_templateType = LookupColumnEntities.GetEntity("TemplateType") as MessageTemplateType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailTemplate_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailTemplate_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("EmailTemplate_Base_BPMSoftDeleting", e);
			Inserting += (s, e) => ThrowEvent("EmailTemplate_Base_BPMSoftInserting", e);
			Saving += (s, e) => ThrowEvent("EmailTemplate_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("EmailTemplate_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailTemplate_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplate_BaseEventsProcess

	/// <exclude/>
	public partial class EmailTemplate_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailTemplate_Base_BPMSoft
	{

		public EmailTemplate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailTemplate_BaseEventsProcess";
			SchemaUId = new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("93030575-f70f-4041-902e-c4badaf62c63");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _emailTemplateEventSubProcess;
		public ProcessFlowElement EmailTemplateEventSubProcess {
			get {
				return _emailTemplateEventSubProcess ?? (_emailTemplateEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmailTemplateEventSubProcess",
					SchemaElementUId = new Guid("9a4fbdfc-4eb0-4dc1-825b-f0a88f58836d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _emailTemplateInsertingStartMessage;
		public ProcessFlowElement EmailTemplateInsertingStartMessage {
			get {
				return _emailTemplateInsertingStartMessage ?? (_emailTemplateInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailTemplateInsertingStartMessage",
					SchemaElementUId = new Guid("1f309623-69c1-4cbb-b9f0-77c0fee4a88d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _emailTemplateSavingStartMessage;
		public ProcessFlowElement EmailTemplateSavingStartMessage {
			get {
				return _emailTemplateSavingStartMessage ?? (_emailTemplateSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailTemplateSavingStartMessage",
					SchemaElementUId = new Guid("3bda745f-4adc-4074-a069-5e99c9f16b69"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _emailTemplateDeletingStartMessage;
		public ProcessFlowElement EmailTemplateDeletingStartMessage {
			get {
				return _emailTemplateDeletingStartMessage ?? (_emailTemplateDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmailTemplateDeletingStartMessage",
					SchemaElementUId = new Guid("f3dbfad1-9404-4556-842a-9f600c540c35"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkCanManageLookupsScriptTask;
		public ProcessScriptTask CheckCanManageLookupsScriptTask {
			get {
				return _checkCanManageLookupsScriptTask ?? (_checkCanManageLookupsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanManageLookupsScriptTask",
					SchemaElementUId = new Guid("ca153e72-b0ee-4c6b-91b6-6ca9753799aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanManageLookupsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EmailTemplateEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailTemplateEventSubProcess };
			FlowElements[EmailTemplateInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailTemplateInsertingStartMessage };
			FlowElements[EmailTemplateSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailTemplateSavingStartMessage };
			FlowElements[EmailTemplateDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmailTemplateDeletingStartMessage };
			FlowElements[CheckCanManageLookupsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanManageLookupsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EmailTemplateEventSubProcess":
						break;
					case "EmailTemplateInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "EmailTemplateSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "EmailTemplateDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "CheckCanManageLookupsScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EmailTemplateInsertingStartMessage");
			ActivatedEventElements.Add("EmailTemplateSavingStartMessage");
			ActivatedEventElements.Add("EmailTemplateDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EmailTemplateEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EmailTemplateInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailTemplateInsertingStartMessage";
					result = EmailTemplateInsertingStartMessage.Execute(context);
					break;
				case "EmailTemplateSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailTemplateSavingStartMessage";
					result = EmailTemplateSavingStartMessage.Execute(context);
					break;
				case "EmailTemplateDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmailTemplateDeletingStartMessage";
					result = EmailTemplateDeletingStartMessage.Execute(context);
					break;
				case "CheckCanManageLookupsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanManageLookupsScriptTask";
					result = CheckCanManageLookupsScriptTask.Execute(context, CheckCanManageLookupsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckCanManageLookupsScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EmailTemplate_Base_BPMSoftInserting":
							if (ActivatedEventElements.Contains("EmailTemplateInsertingStartMessage")) {
							context.QueueTasks.Enqueue("EmailTemplateInsertingStartMessage");
						}
						break;
					case "EmailTemplate_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("EmailTemplateSavingStartMessage")) {
							context.QueueTasks.Enqueue("EmailTemplateSavingStartMessage");
						}
						break;
					case "EmailTemplate_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("EmailTemplateDeletingStartMessage")) {
							context.QueueTasks.Enqueue("EmailTemplateDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplate_BaseEventsProcess

	/// <exclude/>
	public class EmailTemplate_BaseEventsProcess : EmailTemplate_BaseEventsProcess<EmailTemplate_Base_BPMSoft>
	{

		public EmailTemplate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailTemplate_BaseEventsProcess

	public partial class EmailTemplate_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

