namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Currency

	/// <exclude/>
	public class Currency : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Currency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Currency";
		}

		public Currency(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Currency";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountForecast> AccountForecastCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<CampaignPlanner> CampaignPlannerCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<Cashflow> CashflowCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<ContactForecast> ContactForecastCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<Contract> ContractCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<CurrencyRate> CurrencyRateCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<LeadTypeForecast> LeadTypeForecastCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<MktgActivity> MktgActivityCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<OppDepartmentForecast> OppDepartmentForecastCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<Order> OrderCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<OrderProduct> OrderProductCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<Product> ProductCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<ProductForecast> ProductForecastCollectionByCurrency {
			get;
			set;
		}

		public IEnumerable<ProductPrice> ProductPriceCollectionByCurrency {
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
		/// Краткое название.
		/// </summary>
		public string ShortName {
			get {
				return GetTypedColumnValue<string>("ShortName");
			}
			set {
				SetColumnValue("ShortName", value);
			}
		}

		/// <summary>
		/// Символ.
		/// </summary>
		public string Symbol {
			get {
				return GetTypedColumnValue<string>("Symbol");
			}
			set {
				SetColumnValue("Symbol", value);
			}
		}

		/// <summary>
		/// Формат ввода курса.
		/// </summary>
		public int RecalcDirection {
			get {
				return GetTypedColumnValue<int>("RecalcDirection");
			}
			set {
				SetColumnValue("RecalcDirection", value);
			}
		}

		/// <summary>
		/// Кратность.
		/// </summary>
		public int Division {
			get {
				return GetTypedColumnValue<int>("Division");
			}
			set {
				SetColumnValue("Division", value);
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
		/// Позиция символа валюты.
		/// </summary>
		public int CurrecySymbolPosition {
			get {
				return GetTypedColumnValue<int>("CurrecySymbolPosition");
			}
			set {
				SetColumnValue("CurrecySymbolPosition", value);
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal Rate {
			get {
				return GetTypedColumnValue<Decimal>("Rate");
			}
			set {
				SetColumnValue("Rate", value);
			}
		}

		#endregion

	}

	#endregion

}

