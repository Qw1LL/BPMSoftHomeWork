namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignPlanner

	/// <exclude/>
	public class CampaignPlanner : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignPlanner(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlanner";
		}

		public CampaignPlanner(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignPlanner";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CampaignPlannerFile> CampaignPlannerFileCollectionByCampaignPlanner {
			get;
			set;
		}

		public IEnumerable<CampaignPlannerInFolder> CampaignPlannerInFolderCollectionByCampaignPlanner {
			get;
			set;
		}

		public IEnumerable<CampaignPlannerInTag> CampaignPlannerInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<MktgActivity> MktgActivityCollectionByCampaignPlanner {
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
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private CampaignPlannerType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public CampaignPlannerType Type {
			get {
				return _type ??
					(_type = new CampaignPlannerType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private CampaignPlannerStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CampaignPlannerStatus Status {
			get {
				return _status ??
					(_status = new CampaignPlannerStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		/// <summary>
		/// Плановый бюджет.
		/// </summary>
		public Decimal PlannedBudget {
			get {
				return GetTypedColumnValue<Decimal>("PlannedBudget");
			}
			set {
				SetColumnValue("PlannedBudget", value);
			}
		}

		/// <summary>
		/// Фактический бюджет.
		/// </summary>
		public Decimal SpentBudget {
			get {
				return GetTypedColumnValue<Decimal>("SpentBudget");
			}
			set {
				SetColumnValue("SpentBudget", value);
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
		/// Заметки.
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
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = new Currency(LookupColumnEntities.GetEntity("Currency")));
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal CurrencyRate {
			get {
				return GetTypedColumnValue<Decimal>("CurrencyRate");
			}
			set {
				SetColumnValue("CurrencyRate", value);
			}
		}

		/// <summary>
		/// Плановый бюджет, базовая валюта.
		/// </summary>
		public Decimal PrimaryPlannedBudget {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPlannedBudget");
			}
			set {
				SetColumnValue("PrimaryPlannedBudget", value);
			}
		}

		/// <summary>
		/// Фактический бюджет, базовая валюта.
		/// </summary>
		public Decimal PrimarySpentBudget {
			get {
				return GetTypedColumnValue<Decimal>("PrimarySpentBudget");
			}
			set {
				SetColumnValue("PrimarySpentBudget", value);
			}
		}

		/// <exclude/>
		public Guid BrandId {
			get {
				return GetTypedColumnValue<Guid>("BrandId");
			}
			set {
				SetColumnValue("BrandId", value);
				_brand = null;
			}
		}

		/// <exclude/>
		public string BrandName {
			get {
				return GetTypedColumnValue<string>("BrandName");
			}
			set {
				SetColumnValue("BrandName", value);
				if (_brand != null) {
					_brand.Name = value;
				}
			}
		}

		private Brand _brand;
		/// <summary>
		/// Бренд.
		/// </summary>
		public Brand Brand {
			get {
				return _brand ??
					(_brand = new Brand(LookupColumnEntities.GetEntity("Brand")));
			}
		}

		#endregion

	}

	#endregion

}

