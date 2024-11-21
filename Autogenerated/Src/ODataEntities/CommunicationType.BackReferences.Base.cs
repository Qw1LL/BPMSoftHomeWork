namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CommunicationType

	/// <exclude/>
	public class CommunicationType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CommunicationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CommunicationType";
		}

		public CommunicationType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CommunicationType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountCommunication> AccountCommunicationCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<ComTypebyCommunication> ComTypebyCommunicationCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<ContactCommunication> ContactCommunicationCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<ContactCorrespondence> ContactCorrespondenceCollectionBySource {
			get;
			set;
		}

		public IEnumerable<CTISearchResult> CTISearchResultCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<EmailTemplateMacros> EmailTemplateMacrosCollectionByAccountCommunicationType {
			get;
			set;
		}

		public IEnumerable<EnrchTypeMapping> EnrchTypeMappingCollectionByCommunicationType {
			get;
			set;
		}

		public IEnumerable<SocialAccount> SocialAccountCollectionByType {
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
		/// Шаблон для формирования гиперссылки в реестре.
		/// </summary>
		public string HyperlinkTemplate {
			get {
				return GetTypedColumnValue<string>("HyperlinkTemplate");
			}
			set {
				SetColumnValue("HyperlinkTemplate", value);
			}
		}

		/// <summary>
		/// Использовать для контрагентов.
		/// </summary>
		public bool UseforAccounts {
			get {
				return GetTypedColumnValue<bool>("UseforAccounts");
			}
			set {
				SetColumnValue("UseforAccounts", value);
			}
		}

		/// <summary>
		/// Использовать для контактов.
		/// </summary>
		public bool UseforContacts {
			get {
				return GetTypedColumnValue<bool>("UseforContacts");
			}
			set {
				SetColumnValue("UseforContacts", value);
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

