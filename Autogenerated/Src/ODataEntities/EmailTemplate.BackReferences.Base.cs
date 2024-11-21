namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: EmailTemplate

	/// <exclude/>
	public class EmailTemplate : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EmailTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplate";
		}

		public EmailTemplate(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EmailTemplate";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CaseNotificationRule> CaseNotificationRuleCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateActivity> EmailTemplateActivityCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFile> EmailTemplateFileCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateInFolder> EmailTemplateInFolderCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<EmailTemplateInTag> EmailTemplateInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<EmailTemplateLang> EmailTemplateLangCollectionByEmailTemplate {
			get;
			set;
		}

		public IEnumerable<SocialFeedFavoriteTpl> SocialFeedFavoriteTplCollectionByEmailTemplate {
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
		/// Название шаблона.
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
		/// Источник макросов.
		/// </summary>
		public VwSysSchemaInfo Object {
			get {
				return _object ??
					(_object = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("Object")));
			}
		}

		/// <summary>
		/// Тема письма.
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
					(_priority = new ActivityPriority(LookupColumnEntities.GetEntity("Priority")));
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
					(_sendIndividualEmail = new EmailTemplateSendFlag(LookupColumnEntities.GetEntity("SendIndividualEmail")));
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
		/// Тип конфига.
		/// </summary>
		public int ConfigType {
			get {
				return GetTypedColumnValue<int>("ConfigType");
			}
			set {
				SetColumnValue("ConfigType", value);
			}
		}

		/// <exclude/>
		public Guid PreviewImageId {
			get {
				return GetTypedColumnValue<Guid>("PreviewImageId");
			}
			set {
				SetColumnValue("PreviewImageId", value);
				_previewImage = null;
			}
		}

		/// <exclude/>
		public string PreviewImageName {
			get {
				return GetTypedColumnValue<string>("PreviewImageName");
			}
			set {
				SetColumnValue("PreviewImageName", value);
				if (_previewImage != null) {
					_previewImage.Name = value;
				}
			}
		}

		private SysImage _previewImage;
		/// <summary>
		/// Изображения для предпросмотра.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = new SysImage(LookupColumnEntities.GetEntity("PreviewImage")));
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
					(_templateType = new MessageTemplateType(LookupColumnEntities.GetEntity("TemplateType")));
			}
		}

		#endregion

	}

	#endregion

}

