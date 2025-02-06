namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: FolderType

	/// <exclude/>
	public class FolderType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public FolderType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FolderType";
		}

		public FolderType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "FolderType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountFolder> AccountFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ActivityFolder> ActivityFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<BulkEmailFolder> BulkEmailFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitFolder> BulkEmailSplitFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<CallFolder> CallFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<CampaignFolder> CampaignFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<CampaignPlannerFolder> CampaignPlannerFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<CaseFolder> CaseFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ChangeFolder> ChangeFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ConfItemFolder> ConfItemFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ContactFolder> ContactFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ContractFolder> ContractFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<DocumentFolder> DocumentFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<DuplicatesRuleFolder> DuplicatesRuleFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFolder> EmailTemplateFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<EmployeeFolder> EmployeeFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<EventFolder> EventFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ExternalAccessFolder> ExternalAccessFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<FileFolder> FileFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormFolder> GeneratedWebFormFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<InvoiceFolder> InvoiceFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseFolder> KnowledgeBaseFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<LeadFolder> LeadFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<LookupFolder> LookupFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<MkpInstalledAppNewsFolder> MkpInstalledAppNewsFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<MktgActivityFolder> MktgActivityFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<MLModelFolder> MLModelFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<OAuth20AppFolder> OAuth20AppFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<OmniChatFolder> OmniChatFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<OpportunityFolder> OpportunityFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<OrderFolder> OrderFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<PartnershipFolder> PartnershipFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ProblemFolder> ProblemFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ProductFolder> ProductFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ProjectFolder> ProjectFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<QueueFolder> QueueFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<QueueItemFolder> QueueItemFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ReleaseFolder> ReleaseFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ReportFolder> ReportFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<RtxBankFolder> RtxBankFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ServiceItemFolder> ServiceItemFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<ServicePactFolder> ServicePactFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SiteEventTypeFolder> SiteEventTypeFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SocialChannelFolder> SocialChannelFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysAdminOperationFolder> SysAdminOperationFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysAdminUnitFolder> SysAdminUnitFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysLookupFolder> SysLookupFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysProcessLogFolder> SysProcessLogFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysProcessUserTaskFolder> SysProcessUserTaskFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysSettingsFolder> SysSettingsFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<SysTranslationFolder> SysTranslationFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<UsrdderFolder> UsrdderFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<UsrLoggerFolder> UsrLoggerFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsFolder> UsrTransportRequestsFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwFolderInCampaign> VwFolderInCampaignCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwProcessLibFolder> VwProcessLibFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwSysDcmLibFolder> VwSysDcmLibFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<VwSysProcessFolder> VwSysProcessFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<WebServiceV2Folder> WebServiceV2FolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<WSColourOfFieldFolder> WSColourOfFieldFolderCollectionByFolderType {
			get;
			set;
		}

		public IEnumerable<WSPatternFolder> WSPatternFolderCollectionByFolderType {
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
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Порядок.
		/// </summary>
		public int Order {
			get {
				return GetTypedColumnValue<int>("Order");
			}
			set {
				SetColumnValue("Order", value);
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
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Изображение.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = new SysImage(LookupColumnEntities.GetEntity("Image")));
			}
		}

		#endregion

	}

	#endregion

}

