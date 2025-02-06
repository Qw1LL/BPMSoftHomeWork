namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: TagType

	/// <exclude/>
	public class TagType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TagType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TagType";
		}

		public TagType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TagType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountTag> AccountTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ActivityTag> ActivityTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<BulkEmailTag> BulkEmailTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<CallTag> CallTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<CampaignPlannerTag> CampaignPlannerTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<CampaignTag> CampaignTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<CaseTag> CaseTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ChangeTag> ChangeTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ConfItemTag> ConfItemTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContactTag> ContactTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContentBlockTag> ContentBlockTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContractTag> ContractTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<DocumentTag> DocumentTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<DuplicatesRuleTag> DuplicatesRuleTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateTag> EmailTemplateTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<EmployeeTag> EmployeeTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<EventTag> EventTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ExternalAccessTag> ExternalAccessTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormTag> GeneratedWebFormTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<InvoiceTag> InvoiceTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseTagV2> KnowledgeBaseTagV2CollectionByType {
			get;
			set;
		}

		public IEnumerable<LeadTag> LeadTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<LookupTag> LookupTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<MkpInstalledAppNewsTag> MkpInstalledAppNewsTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<MktgActivityTag> MktgActivityTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<MLModelTag> MLModelTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<OAuth20AppTag> OAuth20AppTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<OmniChatTag> OmniChatTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<OpportunityTag> OpportunityTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<OrderTag> OrderTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<PartnershipTag> PartnershipTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProblemTag> ProblemTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProductTag> ProductTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProjectTag> ProjectTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<QueueTag> QueueTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ReleaseTag> ReleaseTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<RtxBankTag> RtxBankTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ServiceItemTag> ServiceItemTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<ServicePactTag> ServicePactTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<SiteEventTypeTag> SiteEventTypeTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<SocialChannelTag> SocialChannelTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<SysTranslationTag> SysTranslationTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<UsrdderTag> UsrdderTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<UsrLoggerTag> UsrLoggerTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsTag> UsrTransportRequestsTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<WebServiceV2Tag> WebServiceV2TagCollectionByType {
			get;
			set;
		}

		public IEnumerable<WSColourOfFieldTag> WSColourOfFieldTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<WSPatternTag> WSPatternTagCollectionByType {
			get;
			set;
		}

		public IEnumerable<WSysAccountTag> WSysAccountTagCollectionByType {
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

		#endregion

	}

	#endregion

}

