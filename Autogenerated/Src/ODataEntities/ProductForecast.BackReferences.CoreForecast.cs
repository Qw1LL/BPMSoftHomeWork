namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ProductForecast

	/// <exclude/>
	public class ProductForecast : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ProductForecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductForecast";
		}

		public ProductForecast(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ProductForecast";
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
		public Guid PeriodId {
			get {
				return GetTypedColumnValue<Guid>("PeriodId");
			}
			set {
				SetColumnValue("PeriodId", value);
				_period = null;
			}
		}

		/// <exclude/>
		public string PeriodName {
			get {
				return GetTypedColumnValue<string>("PeriodName");
			}
			set {
				SetColumnValue("PeriodName", value);
				if (_period != null) {
					_period.Name = value;
				}
			}
		}

		private Period _period;
		/// <summary>
		/// Период.
		/// </summary>
		public Period Period {
			get {
				return _period ??
					(_period = new Period(LookupColumnEntities.GetEntity("Period")));
			}
		}

		/// <exclude/>
		public Guid SheetId {
			get {
				return GetTypedColumnValue<Guid>("SheetId");
			}
			set {
				SetColumnValue("SheetId", value);
				_sheet = null;
			}
		}

		/// <exclude/>
		public string SheetName {
			get {
				return GetTypedColumnValue<string>("SheetName");
			}
			set {
				SetColumnValue("SheetName", value);
				if (_sheet != null) {
					_sheet.Name = value;
				}
			}
		}

		private ForecastSheet _sheet;
		/// <summary>
		/// Лист планирования.
		/// </summary>
		public ForecastSheet Sheet {
			get {
				return _sheet ??
					(_sheet = new ForecastSheet(LookupColumnEntities.GetEntity("Sheet")));
			}
		}

		/// <exclude/>
		public Guid IndicatorId {
			get {
				return GetTypedColumnValue<Guid>("IndicatorId");
			}
			set {
				SetColumnValue("IndicatorId", value);
				_indicator = null;
			}
		}

		/// <exclude/>
		public string IndicatorName {
			get {
				return GetTypedColumnValue<string>("IndicatorName");
			}
			set {
				SetColumnValue("IndicatorName", value);
				if (_indicator != null) {
					_indicator.Name = value;
				}
			}
		}

		private ForecastIndicator _indicator;
		/// <summary>
		/// Показатель планирования.
		/// </summary>
		public ForecastIndicator Indicator {
			get {
				return _indicator ??
					(_indicator = new ForecastIndicator(LookupColumnEntities.GetEntity("Indicator")));
			}
		}

		/// <summary>
		/// Сумма.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Сумма в б.в.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
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
		/// Значение.
		/// </summary>
		public Decimal Value {
			get {
				return GetTypedColumnValue<Decimal>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid RowId {
			get {
				return GetTypedColumnValue<Guid>("RowId");
			}
			set {
				SetColumnValue("RowId", value);
				_row = null;
			}
		}

		private ForecastRow _row;
		/// <summary>
		/// Строка.
		/// </summary>
		public ForecastRow Row {
			get {
				return _row ??
					(_row = new ForecastRow(LookupColumnEntities.GetEntity("Row")));
			}
		}

		/// <exclude/>
		public Guid ForecastColumnId {
			get {
				return GetTypedColumnValue<Guid>("ForecastColumnId");
			}
			set {
				SetColumnValue("ForecastColumnId", value);
				_forecastColumn = null;
			}
		}

		/// <exclude/>
		public string ForecastColumnTitle {
			get {
				return GetTypedColumnValue<string>("ForecastColumnTitle");
			}
			set {
				SetColumnValue("ForecastColumnTitle", value);
				if (_forecastColumn != null) {
					_forecastColumn.Title = value;
				}
			}
		}

		private ForecastColumn _forecastColumn;
		/// <summary>
		/// Колонка планирования.
		/// </summary>
		public ForecastColumn ForecastColumn {
			get {
				return _forecastColumn ??
					(_forecastColumn = new ForecastColumn(LookupColumnEntities.GetEntity("ForecastColumn")));
			}
		}

		/// <exclude/>
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = new Product(LookupColumnEntities.GetEntity("Product")));
			}
		}

		#endregion

	}

	#endregion

}

