namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: FileType

	/// <exclude/>
	public class FileType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public FileType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FileType";
		}

		public FileType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "FileType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountFile> AccountFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ActivityFile> ActivityFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<BulkEmailFile> BulkEmailFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitFile> BulkEmailSplitFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<CallFile> CallFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<CampaignFile> CampaignFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<CampaignPlannerFile> CampaignPlannerFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<CaseFile> CaseFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ChangeFile> ChangeFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ConfItemFile> ConfItemFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContactFile> ContactFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContentBlockFile> ContentBlockFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ContractFile> ContractFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<DocumentFile> DocumentFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateFile> EmailTemplateFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<EmployeeFile> EmployeeFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<EventFile> EventFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ExternalAccessFile> ExternalAccessFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<File> FileCollectionByType {
			get;
			set;
		}

		public IEnumerable<FileLead> FileLeadCollectionByType {
			get;
			set;
		}

		public IEnumerable<GeneratedWebFormFile> GeneratedWebFormFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<InvoiceFile> InvoiceFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<KnowledgeBaseFile> KnowledgeBaseFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<MailboxSettingsFile> MailboxSettingsFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<MkpInstalledAppNewsFile> MkpInstalledAppNewsFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<MktgActivityFile> MktgActivityFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<MLModelFile> MLModelFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<OAuth20AppFile> OAuth20AppFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<OmnichannelMessageFile> OmnichannelMessageFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<OmniChatFile> OmniChatFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<OpportunityFile> OpportunityFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<OrderFile> OrderFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<PartnershipFile> PartnershipFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<PortalMessageFile> PortalMessageFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProblemFile> ProblemFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProductFile> ProductFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ProjectFile> ProjectFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ReleaseFile> ReleaseFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ServiceItemFile> ServiceItemFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<ServicePactFile> ServicePactFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<SiteEventTypeFile> SiteEventTypeFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<SysProcessFile> SysProcessFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsFile> UsrTransportRequestsFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<VwProcessLibFile> VwProcessLibFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<VwSysProcessFile> VwSysProcessFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<WebServiceV2File> WebServiceV2FileCollectionByType {
			get;
			set;
		}

		public IEnumerable<WSColourOfFieldFile> WSColourOfFieldFileCollectionByType {
			get;
			set;
		}

		public IEnumerable<WSPatternFile> WSPatternFileCollectionByType {
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

