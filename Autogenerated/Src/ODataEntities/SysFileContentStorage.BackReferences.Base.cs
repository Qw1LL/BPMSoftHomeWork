namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysFileContentStorage

	/// <exclude/>
	public class SysFileContentStorage : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysFileContentStorage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysFileContentStorage";
		}

		public SysFileContentStorage(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysFileContentStorage";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountFile> AccountFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ActivityFile> ActivityFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<BulkEmailFile> BulkEmailFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitFile> BulkEmailSplitFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<CallFile> CallFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<CampaignFile> CampaignFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<CampaignPlannerFile> CampaignPlannerFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<CaseFile> CaseFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ChangeFile> ChangeFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ConfItemFile> ConfItemFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ContactFile> ContactFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ContentBlockFile> ContentBlockFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ContractFile> ContractFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<DocumentFile> DocumentFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFile> EmailTemplateFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<EmployeeFile> EmployeeFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<EventFile> EventFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ExternalAccessFile> ExternalAccessFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<File> FileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<FileLead> FileLeadCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormFile> GeneratedWebFormFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<InvoiceFile> InvoiceFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseFile> KnowledgeBaseFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<MailboxSettingsFile> MailboxSettingsFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<MkpInstalledAppNewsFile> MkpInstalledAppNewsFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<MktgActivityFile> MktgActivityFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<MLModelFile> MLModelFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<OAuth20AppFile> OAuth20AppFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<OmnichannelMessageFile> OmnichannelMessageFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<OmniChatFile> OmniChatFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<OpportunityFile> OpportunityFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<OrderFile> OrderFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<PartnershipFile> PartnershipFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<PortalMessageFile> PortalMessageFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ProblemFile> ProblemFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ProductFile> ProductFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ProjectFile> ProjectFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ReleaseFile> ReleaseFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ServiceItemFile> ServiceItemFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<ServicePactFile> ServicePactFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<SiteEventTypeFile> SiteEventTypeFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<SysProcessFile> SysProcessFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsFile> UsrTransportRequestsFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<VwProcessLibFile> VwProcessLibFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<VwSysProcessFile> VwSysProcessFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<WebServiceV2File> WebServiceV2FileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<WSColourOfFieldFile> WSColourOfFieldFileCollectionBySysFileStorage {
			get;
			set;
		}

		public IEnumerable<WSPatternFile> WSPatternFileCollectionBySysFileStorage {
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

		/// <summary>
		/// Название типа хранилища.
		/// </summary>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
			}
		}

		#endregion

	}

	#endregion

}

