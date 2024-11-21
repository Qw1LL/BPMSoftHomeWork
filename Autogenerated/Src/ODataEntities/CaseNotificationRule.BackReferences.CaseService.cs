namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CaseNotificationRule

	/// <exclude/>
	public class CaseNotificationRule : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CaseNotificationRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseNotificationRule";
		}

		public CaseNotificationRule(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CaseNotificationRule";
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
		public Guid CaseStatusId {
			get {
				return GetTypedColumnValue<Guid>("CaseStatusId");
			}
			set {
				SetColumnValue("CaseStatusId", value);
				_caseStatus = null;
			}
		}

		/// <exclude/>
		public string CaseStatusName {
			get {
				return GetTypedColumnValue<string>("CaseStatusName");
			}
			set {
				SetColumnValue("CaseStatusName", value);
				if (_caseStatus != null) {
					_caseStatus.Name = value;
				}
			}
		}

		private CaseStatus _caseStatus;
		/// <summary>
		/// Состояния обращения.
		/// </summary>
		public CaseStatus CaseStatus {
			get {
				return _caseStatus ??
					(_caseStatus = new CaseStatus(LookupColumnEntities.GetEntity("CaseStatus")));
			}
		}

		/// <exclude/>
		public Guid CaseCategoryId {
			get {
				return GetTypedColumnValue<Guid>("CaseCategoryId");
			}
			set {
				SetColumnValue("CaseCategoryId", value);
				_caseCategory = null;
			}
		}

		/// <exclude/>
		public string CaseCategoryName {
			get {
				return GetTypedColumnValue<string>("CaseCategoryName");
			}
			set {
				SetColumnValue("CaseCategoryName", value);
				if (_caseCategory != null) {
					_caseCategory.Name = value;
				}
			}
		}

		private CaseCategory _caseCategory;
		/// <summary>
		/// Категория обращения.
		/// </summary>
		public CaseCategory CaseCategory {
			get {
				return _caseCategory ??
					(_caseCategory = new CaseCategory(LookupColumnEntities.GetEntity("CaseCategory")));
			}
		}

		/// <exclude/>
		public Guid EmailTemplateId {
			get {
				return GetTypedColumnValue<Guid>("EmailTemplateId");
			}
			set {
				SetColumnValue("EmailTemplateId", value);
				_emailTemplate = null;
			}
		}

		/// <exclude/>
		public string EmailTemplateName {
			get {
				return GetTypedColumnValue<string>("EmailTemplateName");
			}
			set {
				SetColumnValue("EmailTemplateName", value);
				if (_emailTemplate != null) {
					_emailTemplate.Name = value;
				}
			}
		}

		private EmailTemplate _emailTemplate;
		/// <summary>
		/// Шаблон email сообщения.
		/// </summary>
		public EmailTemplate EmailTemplate {
			get {
				return _emailTemplate ??
					(_emailTemplate = new EmailTemplate(LookupColumnEntities.GetEntity("EmailTemplate")));
			}
		}

		/// <exclude/>
		public Guid RuleUsageId {
			get {
				return GetTypedColumnValue<Guid>("RuleUsageId");
			}
			set {
				SetColumnValue("RuleUsageId", value);
				_ruleUsage = null;
			}
		}

		/// <exclude/>
		public string RuleUsageName {
			get {
				return GetTypedColumnValue<string>("RuleUsageName");
			}
			set {
				SetColumnValue("RuleUsageName", value);
				if (_ruleUsage != null) {
					_ruleUsage.Name = value;
				}
			}
		}

		private NotificationRuleUsage _ruleUsage;
		/// <summary>
		/// Правило использования.
		/// </summary>
		public NotificationRuleUsage RuleUsage {
			get {
				return _ruleUsage ??
					(_ruleUsage = new NotificationRuleUsage(LookupColumnEntities.GetEntity("RuleUsage")));
			}
		}

		/// <summary>
		/// Задержка отправки, минут.
		/// </summary>
		public int Delay {
			get {
				return GetTypedColumnValue<int>("Delay");
			}
			set {
				SetColumnValue("Delay", value);
			}
		}

		/// <summary>
		/// Процитировать оригинальный емейл.
		/// </summary>
		public bool IsQuoteOriginalEmail {
			get {
				return GetTypedColumnValue<bool>("IsQuoteOriginalEmail");
			}
			set {
				SetColumnValue("IsQuoteOriginalEmail", value);
			}
		}

		#endregion

	}

	#endregion

}

