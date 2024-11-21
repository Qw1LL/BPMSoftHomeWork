namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Partnership

	/// <exclude/>
	public class Partnership : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Partnership(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Partnership";
		}

		public Partnership(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Partnership";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Fund> FundCollectionByPartnership {
			get;
			set;
		}

		public IEnumerable<MktgActivity> MktgActivityCollectionByPartnership {
			get;
			set;
		}

		public IEnumerable<PartnerParamHistory> PartnerParamHistoryCollectionByPartnership {
			get;
			set;
		}

		public IEnumerable<PartnershipFile> PartnershipFileCollectionByPartnership {
			get;
			set;
		}

		public IEnumerable<PartnershipInFolder> PartnershipInFolderCollectionByPartnership {
			get;
			set;
		}

		public IEnumerable<PartnershipInTag> PartnershipInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<PartnershipParameter> PartnershipParameterCollectionByPartnership {
			get;
			set;
		}

		public IEnumerable<PRMTransaction> PRMTransactionCollectionByPartnership {
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
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid PartnerLevelId {
			get {
				return GetTypedColumnValue<Guid>("PartnerLevelId");
			}
			set {
				SetColumnValue("PartnerLevelId", value);
				_partnerLevel = null;
			}
		}

		/// <exclude/>
		public string PartnerLevelName {
			get {
				return GetTypedColumnValue<string>("PartnerLevelName");
			}
			set {
				SetColumnValue("PartnerLevelName", value);
				if (_partnerLevel != null) {
					_partnerLevel.Name = value;
				}
			}
		}

		private PartnerLevel _partnerLevel;
		/// <summary>
		/// Уровень.
		/// </summary>
		public PartnerLevel PartnerLevel {
			get {
				return _partnerLevel ??
					(_partnerLevel = new PartnerLevel(LookupColumnEntities.GetEntity("PartnerLevel")));
			}
		}

		/// <summary>
		/// Дата начала.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Дата завершения.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Активно.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid PartnerTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnerTypeId");
			}
			set {
				SetColumnValue("PartnerTypeId", value);
				_partnerType = null;
			}
		}

		/// <exclude/>
		public string PartnerTypeName {
			get {
				return GetTypedColumnValue<string>("PartnerTypeName");
			}
			set {
				SetColumnValue("PartnerTypeName", value);
				if (_partnerType != null) {
					_partnerType.Name = value;
				}
			}
		}

		private PartnerType _partnerType;
		/// <summary>
		/// Тип.
		/// </summary>
		public PartnerType PartnerType {
			get {
				return _partnerType ??
					(_partnerType = new PartnerType(LookupColumnEntities.GetEntity("PartnerType")));
			}
		}

		/// <summary>
		/// Осталось до уровня.
		/// </summary>
		public int ScoreLeft {
			get {
				return GetTypedColumnValue<int>("ScoreLeft");
			}
			set {
				SetColumnValue("ScoreLeft", value);
			}
		}

		#endregion

	}

	#endregion

}

