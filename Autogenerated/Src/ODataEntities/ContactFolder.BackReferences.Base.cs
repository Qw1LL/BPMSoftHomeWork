namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ContactFolder

	/// <exclude/>
	public class ContactFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ContactFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactFolder";
		}

		public ContactFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ContactFolder";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<BulkEmailSegment> BulkEmailSegmentCollectionBySegment {
			get;
			set;
		}

		public IEnumerable<BulkEmailSplitSegment> BulkEmailSplitSegmentCollectionBySegment {
			get;
			set;
		}

		public IEnumerable<CampaignSegment> CampaignSegmentCollectionBySegment {
			get;
			set;
		}

		public IEnumerable<ContactFolder> ContactFolderCollectionByParent {
			get;
			set;
		}

		public IEnumerable<ContactInFolder> ContactInFolderCollectionByFolder {
			get;
			set;
		}

		public IEnumerable<EventSegment> EventSegmentCollectionBySegment {
			get;
			set;
		}

		public IEnumerable<MailboxContactFolder> MailboxContactFolderCollectionByContactFolder {
			get;
			set;
		}

		public IEnumerable<VwFolderInCampaign> VwFolderInCampaignCollectionByContactFolder {
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

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private ContactFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public ContactFolder Parent {
			get {
				return _parent ??
					(_parent = new ContactFolder(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid FolderTypeId {
			get {
				return GetTypedColumnValue<Guid>("FolderTypeId");
			}
			set {
				SetColumnValue("FolderTypeId", value);
				_folderType = null;
			}
		}

		/// <exclude/>
		public string FolderTypeName {
			get {
				return GetTypedColumnValue<string>("FolderTypeName");
			}
			set {
				SetColumnValue("FolderTypeName", value);
				if (_folderType != null) {
					_folderType.Name = value;
				}
			}
		}

		private FolderType _folderType;
		/// <summary>
		/// Тип группы.
		/// </summary>
		public FolderType FolderType {
			get {
				return _folderType ??
					(_folderType = new FolderType(LookupColumnEntities.GetEntity("FolderType")));
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

		/// <summary>
		/// Тип оптимизации.
		/// </summary>
		public int OptimizationType {
			get {
				return GetTypedColumnValue<int>("OptimizationType");
			}
			set {
				SetColumnValue("OptimizationType", value);
			}
		}

		#endregion

	}

	#endregion

}

