namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OrderProduct

	/// <exclude/>
	public class OrderProduct : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OrderProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderProduct";
		}

		public OrderProduct(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OrderProduct";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SupplyPaymentElement> SupplyPaymentElementCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<SupplyPaymentProduct> SupplyPaymentProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<VwOrderProductFilter> VwOrderProductFilterCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<VwSupplyPaymentProduct> VwSupplyPaymentProductCollectionByOrderProduct {
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

		/// <summary>
		/// Произвольный продукт.
		/// </summary>
		public string CustomProduct {
			get {
				return GetTypedColumnValue<string>("CustomProduct");
			}
			set {
				SetColumnValue("CustomProduct", value);
			}
		}

		/// <summary>
		/// Дата доставки.
		/// </summary>
		public DateTime DeliveryDate {
			get {
				return GetTypedColumnValue<DateTime>("DeliveryDate");
			}
			set {
				SetColumnValue("DeliveryDate", value);
			}
		}

		/// <summary>
		/// Количество.
		/// </summary>
		public Decimal Quantity {
			get {
				return GetTypedColumnValue<Decimal>("Quantity");
			}
			set {
				SetColumnValue("Quantity", value);
			}
		}

		/// <exclude/>
		public Guid UnitId {
			get {
				return GetTypedColumnValue<Guid>("UnitId");
			}
			set {
				SetColumnValue("UnitId", value);
				_unit = null;
			}
		}

		/// <exclude/>
		public string UnitName {
			get {
				return GetTypedColumnValue<string>("UnitName");
			}
			set {
				SetColumnValue("UnitName", value);
				if (_unit != null) {
					_unit.Name = value;
				}
			}
		}

		private Unit _unit;
		/// <summary>
		/// Единица измерения.
		/// </summary>
		public Unit Unit {
			get {
				return _unit ??
					(_unit = new Unit(LookupColumnEntities.GetEntity("Unit")));
			}
		}

		/// <summary>
		/// Цена, б.в.
		/// </summary>
		public Decimal PrimaryPrice {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPrice");
			}
			set {
				SetColumnValue("PrimaryPrice", value);
			}
		}

		/// <summary>
		/// Цена.
		/// </summary>
		public Decimal Price {
			get {
				return GetTypedColumnValue<Decimal>("Price");
			}
			set {
				SetColumnValue("Price", value);
			}
		}

		/// <summary>
		/// Сумма, б.в.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
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
		/// Сумма скидки, б.в.
		/// </summary>
		public Decimal PrimaryDiscountAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryDiscountAmount");
			}
			set {
				SetColumnValue("PrimaryDiscountAmount", value);
			}
		}

		/// <summary>
		/// Сумма скидки.
		/// </summary>
		public Decimal DiscountAmount {
			get {
				return GetTypedColumnValue<Decimal>("DiscountAmount");
			}
			set {
				SetColumnValue("DiscountAmount", value);
			}
		}

		/// <summary>
		/// Скидка, %.
		/// </summary>
		public Decimal DiscountPercent {
			get {
				return GetTypedColumnValue<Decimal>("DiscountPercent");
			}
			set {
				SetColumnValue("DiscountPercent", value);
			}
		}

		/// <exclude/>
		public Guid TaxId {
			get {
				return GetTypedColumnValue<Guid>("TaxId");
			}
			set {
				SetColumnValue("TaxId", value);
				_tax = null;
			}
		}

		/// <exclude/>
		public string TaxName {
			get {
				return GetTypedColumnValue<string>("TaxName");
			}
			set {
				SetColumnValue("TaxName", value);
				if (_tax != null) {
					_tax.Name = value;
				}
			}
		}

		private Tax _tax;
		/// <summary>
		/// Налог.
		/// </summary>
		public Tax Tax {
			get {
				return _tax ??
					(_tax = new Tax(LookupColumnEntities.GetEntity("Tax")));
			}
		}

		/// <summary>
		/// Сумма налога, б.в.
		/// </summary>
		public Decimal PrimaryTaxAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryTaxAmount");
			}
			set {
				SetColumnValue("PrimaryTaxAmount", value);
			}
		}

		/// <summary>
		/// Сумма налога.
		/// </summary>
		public Decimal TaxAmount {
			get {
				return GetTypedColumnValue<Decimal>("TaxAmount");
			}
			set {
				SetColumnValue("TaxAmount", value);
			}
		}

		/// <summary>
		/// Итого, б.в.
		/// </summary>
		public Decimal PrimaryTotalAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryTotalAmount");
			}
			set {
				SetColumnValue("PrimaryTotalAmount", value);
			}
		}

		/// <summary>
		/// Итого.
		/// </summary>
		public Decimal TotalAmount {
			get {
				return GetTypedColumnValue<Decimal>("TotalAmount");
			}
			set {
				SetColumnValue("TotalAmount", value);
			}
		}

		/// <summary>
		/// Налог, %.
		/// </summary>
		public Decimal DiscountTax {
			get {
				return GetTypedColumnValue<Decimal>("DiscountTax");
			}
			set {
				SetColumnValue("DiscountTax", value);
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
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = new Order(LookupColumnEntities.GetEntity("Order")));
			}
		}

		/// <exclude/>
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = new Contract(LookupColumnEntities.GetEntity("Contract")));
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
		/// Количество, б.е.
		/// </summary>
		public Decimal BaseQuantity {
			get {
				return GetTypedColumnValue<Decimal>("BaseQuantity");
			}
			set {
				SetColumnValue("BaseQuantity", value);
			}
		}

		/// <exclude/>
		public Guid PriceListId {
			get {
				return GetTypedColumnValue<Guid>("PriceListId");
			}
			set {
				SetColumnValue("PriceListId", value);
				_priceList = null;
			}
		}

		/// <exclude/>
		public string PriceListName {
			get {
				return GetTypedColumnValue<string>("PriceListName");
			}
			set {
				SetColumnValue("PriceListName", value);
				if (_priceList != null) {
					_priceList.Name = value;
				}
			}
		}

		private Pricelist _priceList;
		/// <summary>
		/// Прайс-лист.
		/// </summary>
		public Pricelist PriceList {
			get {
				return _priceList ??
					(_priceList = new Pricelist(LookupColumnEntities.GetEntity("PriceList")));
			}
		}

		#endregion

	}

	#endregion

}

