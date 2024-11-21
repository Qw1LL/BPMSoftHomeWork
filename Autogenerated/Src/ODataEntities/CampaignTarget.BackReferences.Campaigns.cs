namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignTarget

	/// <exclude/>
	public class CampaignTarget : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignTarget(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignTarget";
		}

		public CampaignTarget(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignTarget";
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
		public Guid CampaignTargetStatusId {
			get {
				return GetTypedColumnValue<Guid>("CampaignTargetStatusId");
			}
			set {
				SetColumnValue("CampaignTargetStatusId", value);
				_campaignTargetStatus = null;
			}
		}

		/// <exclude/>
		public string CampaignTargetStatusName {
			get {
				return GetTypedColumnValue<string>("CampaignTargetStatusName");
			}
			set {
				SetColumnValue("CampaignTargetStatusName", value);
				if (_campaignTargetStatus != null) {
					_campaignTargetStatus.Name = value;
				}
			}
		}

		private CampaignTargetStatus _campaignTargetStatus;
		/// <summary>
		/// Участие в кампании.
		/// </summary>
		public CampaignTargetStatus CampaignTargetStatus {
			get {
				return _campaignTargetStatus ??
					(_campaignTargetStatus = new CampaignTargetStatus(LookupColumnEntities.GetEntity("CampaignTargetStatus")));
			}
		}

		/// <summary>
		/// IsFromGroup.
		/// </summary>
		public bool IsFromGroup {
			get {
				return GetTypedColumnValue<bool>("IsFromGroup");
			}
			set {
				SetColumnValue("IsFromGroup", value);
			}
		}

		/// <exclude/>
		public Guid CurrentStepId {
			get {
				return GetTypedColumnValue<Guid>("CurrentStepId");
			}
			set {
				SetColumnValue("CurrentStepId", value);
				_currentStep = null;
			}
		}

		/// <exclude/>
		public string CurrentStepTitle {
			get {
				return GetTypedColumnValue<string>("CurrentStepTitle");
			}
			set {
				SetColumnValue("CurrentStepTitle", value);
				if (_currentStep != null) {
					_currentStep.Title = value;
				}
			}
		}

		private CampaignStep _currentStep;
		/// <summary>
		/// Текущий шаг.
		/// </summary>
		public CampaignStep CurrentStep {
			get {
				return _currentStep ??
					(_currentStep = new CampaignStep(LookupColumnEntities.GetEntity("CurrentStep")));
			}
		}

		/// <exclude/>
		public Guid NextStepId {
			get {
				return GetTypedColumnValue<Guid>("NextStepId");
			}
			set {
				SetColumnValue("NextStepId", value);
				_nextStep = null;
			}
		}

		/// <exclude/>
		public string NextStepTitle {
			get {
				return GetTypedColumnValue<string>("NextStepTitle");
			}
			set {
				SetColumnValue("NextStepTitle", value);
				if (_nextStep != null) {
					_nextStep.Title = value;
				}
			}
		}

		private CampaignStep _nextStep;
		/// <summary>
		/// Следующий шаг.
		/// </summary>
		public CampaignStep NextStep {
			get {
				return _nextStep ??
					(_nextStep = new CampaignStep(LookupColumnEntities.GetEntity("NextStep")));
			}
		}

		/// <exclude/>
		public Guid PassedStepId {
			get {
				return GetTypedColumnValue<Guid>("PassedStepId");
			}
			set {
				SetColumnValue("PassedStepId", value);
				_passedStep = null;
			}
		}

		/// <exclude/>
		public string PassedStepTitle {
			get {
				return GetTypedColumnValue<string>("PassedStepTitle");
			}
			set {
				SetColumnValue("PassedStepTitle", value);
				if (_passedStep != null) {
					_passedStep.Title = value;
				}
			}
		}

		private CampaignStep _passedStep;
		/// <summary>
		/// Пройденный шаг.
		/// </summary>
		public CampaignStep PassedStep {
			get {
				return _passedStep ??
					(_passedStep = new CampaignStep(LookupColumnEntities.GetEntity("PassedStep")));
			}
		}

		#endregion

	}

	#endregion

}

